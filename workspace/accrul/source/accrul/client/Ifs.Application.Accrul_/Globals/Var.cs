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

using System;

namespace Ifs.Application.Accrul_
{

	public sealed class Var
	{
        // TODO: Following thread static variables seems to be unused and should probably be removed.
        // ACCRUL Team: Please verify above and remove if not needed. /Rakuse
        [ThreadStatic]
        private static string codeB;
        [ThreadStatic]
        private static string codeC;
        [ThreadStatic]
        private static string codeD;
        [ThreadStatic]
        private static string codeE;
        [ThreadStatic]
        private static string codeF;
        [ThreadStatic]
        private static string codeG;
        [ThreadStatic]
        private static string codeH;
        [ThreadStatic]
        private static string codeI;
        [ThreadStatic]
        private static string codeJ;
        [ThreadStatic]
        private static bool useTemFCS;

        internal static string g_sFCSTemCodeB
        {
            get
            {
                if (codeB == null)
                    codeB = "";
                return codeB;
            }
            set { codeB = value; }
        }

        internal static string g_sFCSTemCodeC
        {
            get
            {
                if (codeC == null)
                    codeC = "";
                return codeC;
            }
            set { codeC = value; }
        }

        internal static string g_sFCSTemCodeD
        {
            get
            {
                if (codeD == null)
                    codeD = "";
                return codeD;
            }
            set { codeD = value; }
        }

        internal static string g_sFCSTemCodeE
        {
            get
            {
                if (codeE == null)
                    codeE = "";
                return codeE;
            }
            set { codeE = value; }
        }

        internal static string g_sFCSTemCodeF
        {
            get
            {
                if (codeF == null)
                    codeF = "";
                return codeF;
            }
            set { codeF = value; }
        }

        internal static string g_sFCSTemCodeG
        {
            get
            {
                if (codeG == null)
                    codeG = "";
                return codeG;
            }
            set { codeG = value; }
        }

        internal static string g_sFCSTemCodeH
        {
            get
            {
                if (codeH == null)
                    codeH = "";
                return codeH;
            }
            set { codeH = value; }
        }

        internal static string g_sFCSTemCodeI
        {
            get
            {
                if (codeI == null)
                    codeI = "";
                return codeI;
            }
            set { codeI = value; }
        }

        internal static string g_sFCSTemCodeJ
        {
            get
            {
                if (codeJ == null)
                    codeJ = "";
                return codeI;
            }
            set { codeJ = value; }
        }

        internal static bool g_bUseTemFCS
        {
            get { return useTemFCS; }
            set { useTemFCS = value; }
        }
	}
}
