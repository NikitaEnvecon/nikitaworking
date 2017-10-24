#region Copyright (c) IFS Research & Development
// ======================================================================================================
//
//                 IFS Research & Development
//
//  This program is protected by copyright law and by international
//  conventions. All licensing, renting, lending or copying (including
//  for private use), and all other use of the program, which is not
//  explicitly permitted by IFS, is a violation of the rights
//  of IFS. Such violations will be reported to the
//  appropriate authorities.
//
//  VIOLATIONS OF ANY COPYRIGHT IS PUNISHABLE BY LAW AND CAN LEAD
//  TO UP TO TWO YEARS OF IMPRISONMENT AND LIABILITY TO PAY DAMAGES.
// ======================================================================================================
#endregion
#region History
#endregion

using System.Text;
using PPJ.Runtime;

namespace Ifs.Application.Fndmig_
{

    /// <summary>
    /// </summary>
    public static class cIntfLight
    {
        /// <summary>
        /// </summary>
        /// <param name="ps_fileName"></param>
        /// <param name="ps_delimiter"></param>
        /// <param name="pwh_windowHandleDestination"></param>
        /// <param name="ps_columnNames"></param>
        /// <returns></returns>
        internal static SalBoolean Load(SalString ps_fileName, SalString ps_delimiter, SalWindowHandle pwh_windowHandleDestination, SalString ps_columnNames)
        {
            Sal.WaitCursor(true);

            // Get the column names and windowHandles in destination window
            SalArray<SalWindowHandle> lwh_colHandlesArrayDest = new SalArray<SalWindowHandle>();
            SalArray<SalString> ls_colNamesArrayDest = new SalArray<SalString>();

            SalNumber ln_colCountDestination = GetDestinationColumns(pwh_windowHandleDestination, ls_colNamesArrayDest, lwh_colHandlesArrayDest);
            SalBoolean lb_OK = ln_colCountDestination > 0;

            // Get Scource columnnames
            SalArray<SalString> ls_colNamesArraySource = new SalArray<SalString>();
            if (lb_OK)
            {
                SalNumber ln_colCountSource = GetSourceColumns(ref ps_columnNames, ls_colNamesArraySource);
                lb_OK = ln_colCountSource > 0;
            }
            // Insets data from source file into destination window
            if (lb_OK)
                lb_OK = SourceToDestination(ps_fileName, ps_delimiter, ls_colNamesArraySource, ls_colNamesArrayDest, lwh_colHandlesArrayDest, pwh_windowHandleDestination);

            // Cleaning up
            Sal.WaitCursor(false);
            return lb_OK;
        }

        /// <summary>
        /// Fill Data transfer object with data from file
        /// </summary>
        /// <param name="ps_fileName"></param>
        /// <param name="ps_delimiter"></param>
        /// <param name="ps_columnNamesArraySource"></param>
        /// <param name="ps_columnNamesArrayDestination"></param>
        /// <param name="pwh_colHandlesArrayDest"></param>
        /// <param name="pwh_windowHandleDestination"></param>
        /// <returns></returns>
        private static SalBoolean SourceToDestination(SalString ps_fileName, SalString ps_delimiter, SalArray<SalString> ps_columnNamesArraySource, SalArray<SalString> ps_columnNamesArrayDestination, SalArray<SalWindowHandle> pwh_colHandlesArrayDest, SalWindowHandle pwh_windowHandleDestination)
        {
            #region Local Variables
            SalNumber ln_rowCountScource = 0;
            SalNumber ln_rowInxSource = 0;
            SalArray<SalString> ls_DataBufferSourceArray = new SalArray<SalString>();
            SalArray<SalString> ls_DataBufferSource = new SalArray<SalString>();
            SalBoolean lb_OK = false;
            SalString line_no_info = null;
            SalNumber line_no = 0;
            #endregion

            #region Actions
            lb_OK = GetSourceData(ps_fileName, ls_DataBufferSource);
            if (lb_OK)
            {
                lb_OK = ls_DataBufferSource.GetUpperBound(1, ref ln_rowCountScource);
            }
            while (lb_OK && ln_rowInxSource <= ln_rowCountScource)
            {
                lb_OK = ls_DataBufferSource[ln_rowInxSource].Tokenize("", ps_delimiter, ls_DataBufferSourceArray);
                if (!(lb_OK))
                {
                    break;
                }
                // Make a new record in Destination window
                line_no = ln_rowInxSource + 1;
                line_no_info = "line_no:" + line_no.ToString();
                lb_OK = Sal.SendMsg(pwh_windowHandleDestination, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sal.HStringToNumber(line_no_info));
                if (!(lb_OK))
                {
                    break;
                }
                lb_OK = SetRecord(ps_columnNamesArraySource, ps_columnNamesArrayDestination, pwh_colHandlesArrayDest, ls_DataBufferSourceArray);
                if (!(lb_OK))
                {
                    break;
                }
                // Clears all elements of array
                lb_OK = ls_DataBufferSourceArray.SetUpperBound(1, -1);
                if (!(lb_OK))
                {
                    break;
                }
                ln_rowInxSource = ln_rowInxSource + 1;
            }
            return lb_OK;
            #endregion
        }

        /// <summary>
        /// Get the column names and windowHandles in destination window
        /// </summary>
        /// <param name="ps_columnNames"></param>
        /// <param name="ps_columnNamesArrayTransfer"></param>
        /// <returns></returns>
        private static SalBoolean GetSourceColumns(ref SalString ps_columnNames, SalArray<SalString> ps_columnNamesArrayTransfer)
        {
            // Parse column names to transfer into column array
            return ps_columnNames.ToUpper().Tokenize("", ",", ps_columnNamesArrayTransfer);
        }

        /// <summary>
        /// Get the column names and windowHandles in destination window
        /// </summary>
        /// <param name="pwh_windowHandle"></param>
        /// <param name="ps_columnNamesArrayWindow"></param>
        /// <param name="pwh_columnHandlesArray"></param>
        /// <returns></returns>
        private static SalNumber GetDestinationColumns(SalWindowHandle pwh_windowHandle, SalArray<SalString> ps_columnNamesArrayWindow, SalArray<SalWindowHandle> pwh_columnHandlesArray)
        {
            #region Local Variables
            SalWindowHandle lwh_columnHandle = SalWindowHandle.Null;
            SalBoolean lb_OK = false;
            SalNumber ln_colID = 0;
            SalNumber ln_colCount = 0;
            #endregion

            #region Actions
            lb_OK = true;
            // Get the column names and windowHandles in destination window
            // Set ln_colID = 5, the first columns is system columns like __colObjid, __colVersion, __colObjState, __colObjid, __colObjEvents
            // Ignore those columns
            ln_colID = 5;
            while (lb_OK)
            {
                lwh_columnHandle = Sal.TblGetColumnWindow(pwh_windowHandle, ln_colID, Sys.COL_GetPos);
                if (lwh_columnHandle == SalWindowHandle.Null)
                {
                    // The last column in window is fetched
                    break;
                }
                pwh_columnHandlesArray[ln_colCount] = lwh_columnHandle;
                lb_OK = Sal.WindowGetProperty(lwh_columnHandle, Ifs.Fnd.ApplicationForms.Const.__PROPERTY_DItem_SqlColumns, ref ps_columnNamesArrayWindow.GetArray(ln_colCount)[ln_colCount]);
                if (lb_OK)
                {
                    ln_colID = ln_colID + 1;
                    ln_colCount = ln_colCount + 1;
                }
            }
            return ln_colCount;
            #endregion
        }

        /// <summary>
        /// JOVINO O18 19991230
        /// This function find a strings in an array and return its indexes in an array
        /// if no string is found, the returnvalue is 0 else count is returned
        /// </summary>
        /// <param name="ps_string"></param>
        /// <param name="ps_stringArray"></param>
        /// <param name="ln_indexArray"></param>
        /// <returns></returns>
        private static SalNumber IntfPalArrayStrFind(SalString ps_string, SalArray<SalString> ps_stringArray, SalArray<SalNumber> ln_indexArray)
        {
            #region Local Variables
            SalNumber ln_rowCount = 0;
            SalNumber ln_matcCount = 0;
            SalNumber ln_rowInx = 0;
            #endregion

            #region Actions
            if (!(ps_stringArray.GetUpperBound(1, ref ln_rowCount)))
            {
                return 0;
            }
            while (ln_rowInx <= ln_rowCount)
            {
                if (ps_stringArray[ln_rowInx] == ps_string)
                {
                    ln_indexArray[ln_matcCount] = ln_rowInx;
                    ln_matcCount = ln_matcCount + 1;
                }
                ln_rowInx = ln_rowInx + 1;
            }
            return ln_matcCount;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="ps_columnNamesArraySource"></param>
        /// <param name="ps_columnNamesArrayDestination"></param>
        /// <param name="pwh_colHandlesArrayDest"></param>
        /// <param name="ps_DataBufferSourceArray"></param>
        /// <returns></returns>
        private static SalBoolean SetRecord(SalArray<SalString> ps_columnNamesArraySource, SalArray<SalString> ps_columnNamesArrayDestination, SalArray<SalWindowHandle> pwh_colHandlesArrayDest, SalArray<SalString> ps_DataBufferSourceArray)
        {
            #region Local Variables
            SalNumber ln_colInxSource = 0;
            SalNumber ln_colCountScource = 0;
            SalNumber ln_indexesCount = 0;
            SalArray<SalNumber> ln_indexes = new SalArray<SalNumber>();
            SalBoolean lb_OK = false;
            #endregion

            #region Actions
            lb_OK = ps_columnNamesArraySource.GetUpperBound(1, ref ln_colCountScource);
            while (ln_colInxSource <= ln_colCountScource)
            {
                ln_indexesCount = IntfPalArrayStrFind(ps_columnNamesArraySource[ln_colInxSource].Trim(), ps_columnNamesArrayDestination, ln_indexes);
                lb_OK = ln_indexesCount == 1;
                if (!(lb_OK))
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.INTF_Column + " " + ps_columnNamesArraySource[ln_colInxSource] + " " + Properties.Resources.INTF_ExistWin, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                    break;
                }

                // Check datatype
                // Set lb_OK = SalWindowGetProperty(  pwh_colHandlesArrayDest[ln_indexes[0]], __PROPERTY_DItem_DataType,  ls_dataType )
                // If not lb_OK
                // Break
                // If ls_dataType = 'Date/Time'
                lb_OK = Sal.SendMsg(pwh_colHandlesArrayDest[ln_indexes[0]], Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, ps_DataBufferSourceArray[ln_colInxSource].ToHandle());
                // Else If ls_dataType = 'Number'
                // Else
                // Data type is String or Long String
                // Inserts item into window column
                ln_colInxSource = ln_colInxSource + 1;
            }
            return lb_OK;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="ps_fileName"></param>
        /// <param name="ps_sourceData"></param>
        /// <returns></returns>
        private static SalBoolean GetSourceData(SalString ps_fileName, SalArray<SalString> ps_sourceData)
        {
            // Open file
            SalBoolean lb_OK = System.IO.File.Exists(ps_fileName);
            if (!lb_OK)
            {
                Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.INTF_FileOpenError + " " + ps_fileName, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
            }
            else
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(ps_fileName, Encoding.Default))
                {
                    string s = "";
                    SalNumber ln_colInxSource = 0;
                    while ((s = sr.ReadLine()) != null)
                    {
                        ps_sourceData[ln_colInxSource] = s;
                        ln_colInxSource++;
                    }
                }
            }
            return lb_OK;
        }
    }
}
