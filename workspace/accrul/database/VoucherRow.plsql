-----------------------------------------------------------------------------
--
--  Logical unit: VoucherRow
--  Component:    ACCRUL
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  960416  xxxx   Base Table to Logical Unit Generator 1.0A
--  990710  Dhar   New version.
--  990927  Uma    Fixed Bug 11716
--  991103  SaCh   Fixed Bug # 67469
--  000229  Ruwan  Bug #32739 fixed.
--  000309  Uma    Closed dynamic cursors in Exceptions.
--  000313  Upul   Fixed Bug # 36028
--  000315  Uma    Added dynamic cursor in procedure Check_Project___.
--  000322  HiMu   Bug # 37332 fixed
--  000414  SaCh   Added RAISE to exceptions.
--  000529  Uma    Fixed Bug Id #41419.
--  000531  Uma    Fixed Bug Id #41865.
--  000707  BmEk   A527: Added columns in VOUCHER_ROW and added call to
--                 Account_Tax_Code_API.Check_Tax_Code in Unpack_Check_Insert___
--                 and Unpack_Check_Update___
--  000712  AsWi   Added procedures Internal_Manual_Postings___, Delete_Internal_Rows___
--                 to handle Internal manual postings.
--  000724  Uma    A536: Journal Code.
--  000808  Uma    Fixed Bug Id #16905
--  000811  BmEk   A527: Modified view Voucher_Row
--  000829  BmEk   A527: Replaced tax_method_manual with tax_direction
--  000904  BmEk   A527: Added columns in Vocher_Row. Also added Create_Tax_Transaction___,
--                 Check_Overwriting_Level___, Delete_Tax_Transaction___ and
--                 Calculate_Net_From_Gross.
--  000906  BmEk   A527: Added tax_base_amount and currency_tax_base_amount in
--                 Voucher_Row
--  000908  BmEk   A527: Added auto_tax_vou_entry in VOUCHER_ROW_QRY
--  000912  BmEk   A527: Added check on function_group in Unpack_Check_Insert and
--                 Unpack_Check_Update.
--  000918  Uma    Corrected Bug ID #48556/48558 - Added function_group to Insert_Row__.
--  000920  BmEk   A527: Modifed Modify__ (moved call to Delete_Tax_Transaction___).
--  000918  Uma    Corrected Bug ID #48556/48558 - Added function_group to Add_New_Row_.
--  000926  BmEk   A520: Added Tax_Code_In_Voucher_Row
--  001004  BmEk   A527: Added Get_Correction_All__, Prepare_Tax_Transaction___ and
--                 Counter_Tax_Transaction___
--  001013  prtilk BUG # 15677  Checked General_SYS.Init_Method
--  001017  BmEk   A807: Added check if tax code is mandatory in Voucher Entry.
--  001019  Chjalk Bug # 50240 (Foreign call id 16974) Fixed.
--  001020  BmEk   A527: Modifed Counter_Tax_Transaction___.
--  001026  Uma    Did Changes regarding function_group - uu.
--  001026  Uma    Corrected  Bug #51069.
--  001027  LaLi   Modified Check_Acquisition___ and Check_Code_String_Fa___
--  001030  BmEk   A527: Modifed Counter_Tax_Transaction___.
--  001030  BmEk   Call #51423. Added check on simulation voucher.
--  001219  Chajlk Call Id 18577 Corrected.
--  010115  Camk   Bug #19040 Corrected
--  010118         Bug #19146 Corrected.
--  010221  ToOs   Bug # 20177 Added Global Lu constants for check for transaction_sys calls
--  010226  ToOs   Bug # 20254 Added a check IF intled is installed
--  010425  DIFELK Bug # 21452 corrected. Deleted unused cursor(get_manual_count)
--                 and a variable(manual_count_) in procedure Create_Int_Manual_Postings__.
--  010427  JeGu   Bug #21600 Performance, Some Code Cleanup
--  010508  JeGu   Bug #21705 Implementation New Dummyinterface
--                 Changed Insert__ RETURNING rowid INTO objid_
--  010608  JeGu   Bug #22421 Added columns year_period_key and posting_combination_id
--                 to views and inserts.
--                 New view (VIEW3) VOUCHER_ROW_QRY_FINREP created
--                 New view (VIEW4) VOUCHER_ROW_QRY_PID_FINREP created
--  010704  JeGu   Bug #23059, Modified view VOUCHER_ROW_QRY
--  010712  Lali   Bug #23212 - Bad integration Accrul-FIxass
--  010713  LaLi   Bug #23251 - Integration Accrul-Genled-Fixass
--  010719  SUMALK Bug #22932 Fixed.Removed Dynamic Sql and added Execute Immediate.
--  010815  JeGu   Bug #23726 New columns object_id and voucher_date handled.
--                 Other changes for performance.
--                 Voucher_date taken from voucher_row_tab instead of voucher_tab etc
--                 Removed unused procedure Check_Methods
--  010830  GAWILK Bug #22967 fixed. Added checks for the project activity id in Check_Project___
--  010904  JeGu   Bug #24125 Some minor changes
--  010907  Thsrlk Bug #24054 corrected
--  010913  JeGu   Bug #24054 Recorrection
--  010917  JeGu   Bug #24449 Modified call to Create_Pa_Internal_Row
--  010925  JeGu   Fix third_currency_code in add_new_row_
--  011024  ovjose Bug #25777. Removed Bug correction 18577
--  020109  LiSv   IID 10001. Added new procedure Ncf_Create_Postings___. NOTE This is only used by companies in Norway.
--  020115  Thsrlk Bug# 21029 - corrections.
--  020123  UPULP  IID 10114 Job Costing
--  020131  rakolk Corrected Bug# 27384.
--  020314  Uma    Corrected Bug# 28316.
--  020517  Hecolk Bug# 27778 Merged. Add coding to get project code part when GENLED is not installed.
--  020521  rakolk Bug# 29705 Corrected.
--  020522  difelk Bug # 29704 corrected. When entering tax code with 0% it used to take the
--                 norwegian investment tax amount for AP6 and AP7. Now it takes the base amount.
--  020607  Hecolk Bug 28405, Corrected. In PROCEDURE Check_Project___
--  020613  Uma    Corrected Bug# 29291
--  020619  Uma    Corected Bug# 30153. Changed newrec_ to voucher_row_rec_.
--  020627  MACHLK Bug# 30116 Fixed. Called Internal_Manual_Postings___ for tax lines.
--  020708  Hecolk Bug 28405, Re-Corrected. Modified some error messages In PROCEDURE Check_Project___.
--  020708  Hecolk Bug 28405, Modified the condition to properly validate Activity Seq of Project Ids where the origin is 'PROJECT'
--  020724  RAKOLK Corrected Bug# 31775.
--  020801  DIFELK Bug # 31874 corrected. Modified error message.
--  020824  Hadilk Corrected bug 30853
--  020827  Uma    Corrected Bug# 32195. Handled deleting of tax lines in internal ledger.
--  021002  Nimalk   Removed usage of the view Company_Finance_Auth in VOUCHER_ROW view
--                   and replaced by view Company_Finance_Auth1 using EXISTS caluse instead of joins
--  021017  SAMBLK Increased the length of the voucher_group_ in Unpack_Check_Insert___ & Unpack_Check_Update___
--  030102  DAGALK Merge SP3 bugs exept external file transaction part.
--  030131  mgutse IID ITFI127N. New attribute reference_version added.
--  030221  RAFA   IID RDFI151N, added party_type to tavle and all views.
--  030327  Bmekse IID ITFI127N Added tax_item_id to table and view.
--  030801  Nimalk SP4 Merge
--  030825  Bmekse DEFI160N Modified view VOUCHER_ROW and VOUCHER_ROW_QRY
--  030909  Nimalk Changed Add_New_Row_()
--  030915  Brwelk Patch Merge.LCS Bug 38419,Modified coding as to apply the modified voucher date.
--  030915  Dagalk Patch Merge.LCS Bug 37743,comment code taxrec_.project_activity_id.
--  030923  Brenda Added Check_Project_Used for Rollback Project Completion.
--  030926  Thsrlk DEFI159N - Changed Check_Codestring___ to support PCA Budget code parts
--  031010  Gawilk LCS bug 38708 merged. Made the project_id NULL when modifiying
--  031010         a project code part in Update___.
--  040326  Gepelk 2004 SP1 Merge
--  040608  Hecolk IID FIPR228, Added Procedures Calculate_Cost_And_Progress and Get_Activity_Info
--  040611  Hecolk IID FIPR228, Added Procedures Create_Object_Connection___ & Remove_Object_Connection___
--                 Added related code in Procedures Insert___, Update___ & Delete___   
--  040615  Hecolk IID FIPR228, Added Procedure  Create_Object_Connection
--  040709  Hecolk IID FIPR228, Added Procedure Remove_Object_Connection
--  040716  Hecolk LCS Merge - Bug Id 44537
--  040722  Hecolk IID FIPR228, Set object_status_ in Calculate_Cost_And_Progress & Create_Object_Connection___
--  040826  Hecolk Added Call to Check_Exist___ in Remove_Object_Connection___
--  040916  nsillk LCs Merge - Bug Id 45926 A completed Financial or Job project can be used in creating voucher
--  040916  nsillk LCS Merge - Bug Id 46526     
--  040920  reanpl FIJP344 Japanese Tax Rounding, use Round_Amount to calculate taxes
--  041025  gawilk FIPR307. Added column inv_acc_row_id.
--  041103  gawilk FIPR307. Added function Fetch_Vou_Row_Id.
--  050104  Kagalk LCS Merge (47692, 47874)
--  050316  Saahlk LCS Merge (49494)
--  050321  viselk LCS Bug 44049 Merged.
--  050408  viselk LCS Bug 50119 Merged.
--  050408  NiFelk B121223, Added methods Check_Int_Vou_Row___, Get_Row and Internal_Manual_Postings.
--  050321  Nsillk LCS Merge(49506).Added the view ACCRUL_VOUCHER_ROW_QRY.
--  050518  Chprlk LCS Merge(51232). Validates Activity Seq No based on PCA(Percoss) setting.
--  050805  Umdolk LCS Merge(52175).
--  050915  Chajlk LCS Merge(33986). 
--  051104  ShFrlk LCS Bug 53684, Merged.
--  051114  THPELK FIAD377 - Added Rollback_Voucher_ parameter for Reverse_Voucher_Rows__().
--  051118  WAPELK Merged the Bug 52783. Correct the user group variable's width.
--  051202  GADALK Bug 128864 - Code string validations for Clear Rev/Cost vouchers.
--  051213  THPELK Call Id 129888. - Corrected in Add_New_Row_(). 
--  051214  VOHELK Call Id 129879. - Corrected in Insert___().
--  051221  THPELK Call Id 129888. - Corrected in Add_New_Row_().
--  060106  VOHELK Call Id 130531  - Changed : Check_Codestring___() added codestring_rec_.text 
--  060110  Gawilk Added function Get_Pca_Ext_Project.
--  060227  Rufelk LCS-55722 Merge. Modified the Interim_Voucher() Procedure.
--  060323  Miablk B136698 - Added PRJT3 to Get_Activity_Info() method. 
--  060427  DIFELK Bug 56983 corrected. Added new method Not_Updated_Code_Part_Exist.
--  060802  Kagalk LCS Merge - Bug 57046, Modified method Check_Codestring___.
--  060802         Removed the validation for process code when function group is P.
--  060802  Kagalk LCS Merge - Bug 57182.
--  061113  GaDaLK FIPL604A; Changes to reference_serie and reference_number
--  061115  GaDaLK FIPL604A; Changes in Create_Tax_Transaction___
--  061116  GaDaLK FIPL604A; Added Set_Row_Reference_Data()
--  061127  Thaylk LCS Merge 61693, corrected. Modifications made to add PRJT3 and PRJT4 for function group T.
--  070124  Shsalk LCS Merge 61873.Modified the Code_Part_Exist function so that it wont use decode,
--                 and added NOCHECK for code parts in view VOUCHER_ROW.
--  070124  Thpelk FIPL644A - Added modifiecations to Reverse_Voucher_Rows__() to get the new 
--                 Reversal voucher posting method when creating reversal vouchers. 
--  070126  Kagalk LCS Merge 62086, Modifications done to update costs for E vouchers.
--  070207  Kagalk LCS Merge 63090, Multiplication by -1 added when calculating rowrec_.currency_tax_amount
--  070207         and multiplication by -1 removed for rowrec_.tax_amount             
--  070222  GaDaLK FIPL633A, added row_group_id
--  070223  ShSaLK LCS Merge 63510 - Changes to the meathod Reverse_Voucher_Rows__.
--  070223  GaDaLK FIPL633A; Changed Set_Row_Reference_Data() to Set_Row_Data__() with row_group_id
--  070306  Paralk FIPL638A, Added Is_Voucher_Exist()
--  070307  GaDaLK FIPL633A; Changes in Create_Tax_Transaction___ added row_group_id
--  070212  ShSaLK LCS Merge 62772 corrected. Removed the project activity sequence validation for function group A.
--  070314  GaDalk FIPL633A: When row group validation: null value for row_group_id blocked, statistical accounts blocked
--  070315  GaDalk FIPL633A: Modified Add_New_Row_
--  070424  ShSalk LCS Merge 64874 corrected. Added Voucher group W to create object connection.
--  070509  Surmlk Added 'Set_Row_Data__' after the END of the procedure Set_Row_Data__
--  070514  Chsalk LCS Merge 64448;Added conversion factor to VOUCHER_ROW_QRY.
--  070516  Chhulk B142136 Modified Unpack_Check_Insert___() and Unpack_Check_Update___()
--  070522  Chsalk LCS Merge 64981; Added voucher group D to create object connection.
--  070530  Maselk B142976, Added Update_Row_No().
--  070608  Surmlk Corrected the method name in General_SYS.Init_Method of method Update_Row_No
--  070705  Hawalk Merged Bug 65797, Modification, inside Insert___(), made to voucher group D for invoices in object connections.
--  070814  Bmekse Merged Bug 66483. Changed Create_Object_Connection___ and Calculate_Cost_And_Progress.
--  071030  DIFELK Bug 67307 corrected. Modification made to check budget accounts when voucher rows are inserted and updated.
--  071106  DIFELK Bug 68932 corrected. Added voucher group K to create object connection.
--  071127  PRDILK Bug 69077 corrected, Added Corrected_Voucher_API.Exist_Db to check DB values
--  071128  cldase Bug 67432 Added entry_date in Select statement and Comment on Column to VOUCHER_ROW_QRY  
--  071201  Jeguse Bug 69803 Corrected.
--  080312  Nsillk Bug 72235 Corrected.Modified method Update_Row_No
--  080317  NUGALK Bug 69894 Corrected. Added Obj_Conn_Refresh_Req___
--  080317         since further checks are needed before calling the method Calculate_Cost_And_Progress in method Update___
--  080327  NiFelk Bug 69891, Corrected.
--  080413  cldase Bug 70198, Introduced global LU constant Avail_Mtd_IsActPostble_ instead of check with cursor
--  080428  JARALK Bug 73185, Merged Peak 75 code.
--  080502  MAKRLK Bug 69890 Corrected. 
--  080506  JARALK Bug 73185, re added the correction of the bug 73222.
--                 ( DIFELK Bug 73222 corrected. Declared new method Create_Object_Connection and
--                   Modifications made to create object connections for already saved vouchers.)
--  080524  AsHelk Bug 74066, Corrected
--  080610  Maaylk Bug 74514, Updated the reference row no values in voucher_row_tab and internal_hold_voucher_row_tab when row no values are updated
--  080619  Nirplk Bug 74252, Corrected. Igonore the validation for function group 'H' in Check_Project___().
--  080619  RUFELK Bug 74540, Corrected. Changed the Voucher Group Row ID for Calculated VAT Tax lines.
--  080627  NUGALK Bug 72589, Corrected. Modified view comments of VOUCHER_ROW_QRY, to be consistent witht the filed key types. 
--  080709  AsHelk Bug 74637, Corrected.
--  081027  MAWELK Bug 74222, Added a comment over the method Calculate_Cost_And_Progress() and Get_Activity_Info().
--  090102  Ersruk Validations added using exclude_proj_followup.
--  090122  Ersruk Added new function  All_Postings_Transferred_Acc.
--  090225  Makrlk Added new function  Check_Exist_Vourow_with_Pfe()
--  090303  Ersruk Added the validation right at the top to avoid unnecessary method calls.
--  090304  Thpelk Bug 80830, Corrected in VOUCHER_ROW View.
--  090406  Marulk Bug 81398, Added "ifs assert safe" annotation to the dynamic call in method Get_Subcon_Total_Used_Cost. 
--  090505  Nirplk Bug 79803, Corrected. checked for blocked code parts in Unpack_Check_Update___
--  090605  THPELK Bug 82609 - Added UNDEFINE section and the missing statements for VIEW5.
--  090317  Makrlk Modified the methods Create_Object_Connection_() Create_Object_Connection___() 
--                 and Calculate_Cost_And_Progress() to handle any code part value
--  00318   Ersruk Validations added in Check_Project___.      
--  090818  JARALK Bug 84633, Added new overloaded method Get_Currency_Rate() with trans_code as a parameter instead of row_id.
--  090915  Thpelk Bug 85766, Corrected in Sum_Currency_Amount and Sum_Amount()..
--  090917  Nirplk Bug 85764, Corrected in Unpack_Check_Insert__() and Unpack_Check_Update_()
--  090924  JOFISE Bug 85810, Added amount and quantity control in Unpack_Check_Insert___.
--  090929  RUFELK Bug 84652, Corrected. Modified in Handle_Object_Conns___() method.
--  090330  Makrlk Modified the methods Create_Object_Connection()
--  090730  Makrlk Added new function Get_Activity_Info().
--  090909  Ersruk Modified Get_Subcon_Total_Used_Cost() to fetch cost element from cord parts.
--  090925  Janslk Made changes in calls to Project_Connection_Util_API.Create_Connection and
--                 Project_Connection_Util_API.Refresh_Activity_Info according to the interface changes.
--  091014  THPELK Bug 76117, PRE Merge - Changed the parameters of project connection calls to use Attributes_Type variable instead of attribute string.
--                            Added Get_Codestring__() to retrive all the codeparts as a single string.
--  091208  MAZPSE ME3040, Eagle project, Modified SUB_CON_AFP_INVOICE_TAB to SUBVAL_INVOICE_TAB.
--  091216  Mawelk Bug 87869  Fixed.
--  100120  Makrlk  TWIN PEAKS Merge.             
--  100223  Maaylk Bug 88901, Removed a block of code that seemed to be obsolete.
--  100308  MAZPSE ME3040, Eagle project, Changed check against SUBCON to SUBVAL in Get_Subcon_Total_Used_Cost. 
--  100319  CLSTLK Bug 89485, Corrected. Modified Prepare_Tax_Transaction___(). Tax amount is multiplied by -1 when creating tax transaction.                                     
--  100422  THPELK Bug 90201, Corrected in Check_Project___().           
--  100701  Jaralk Bug 91425, Corrected in check_project__()  
--  100716  Umdolk  EANE-2936, Reverse engineering - Corrected reference in base view.
--  101027  WAPELK Bug 93703, Remove saving null currency types as default currency types.
--  101101  Elarse, RAVEN-985, Added Create_Cancel_Row_().
--  100608 Ersruk  Removed old Get_Activity_Info(). Added new method Get_Activity_Info(). Modified the methods Create_Object_Connection_() Create_Object_Connection___() 
--                 and Calculate_Cost_And_Progress() to add transaction values and currency code.
--  100616 Ersruk  Modified Get_Subcon_Total_Used_Cost to return used_cost and used_transacion cost.
--  100917 Insalk  Added PRJT5 and PRJT6 to Get_Activity_Info().
--  101018 Janslk  Added Calculate_Cost_And_Progress method with OUT parameters.
--  101021 Janslk  Changed Create_Object_Connection___ to have meaningful names for variables.
--  110112 Janslk  Changed Create_Object_Connection___ and Calculate_Cost_And_Progress to set base value 
--                 as the transaction value when transaction value is zero and base is non-zero.
--  110302 Makrlk  Modified Check_Exist_Vourow_with_Pfe()
--  110302 AsHelk  RAVEN-1877, Fixing problems in Project_id and Object_id columns.
--  110329 DIFELK  RAVEN-1437, modifications done in Create_Cancel_Row___. Called Internal_Manual_Postings___ to create IL voucher rows.
--  110330 DIFELK  RAVEN-1671 modified Create_Cancel_Row___. Validations removed for AP1-AP4.
--  110314 Ersruk  Voucher date added in Obj_Conn_Refresh_Req___().
--  110405 Ersruk  Added Refresh_Connection_Header(). It is called from Handle_Object_Conns___ if voucher dates are changed.
--  110105 SJayLK  EASTONE-19636, Merged Bug 94795, Added voucher_type_reference,voucher_no_reference and accounting_year_reference to VOUCHER_ROW_QRY view.  
--  110701 Sacalk  FIDEAGLE-931, Merged Bug 97430, Corrected in Remove().
--  110721 Sacalk  FIDEAGLE-317, Merged Bug 96287, Unpack_Check_Update___() and Unpack_Check_Insert___().
---------------------SIZZLER-------------------------------------------------
--  110810 Ersruk  Added new column activate_code.
--  111104 Ersruk  Removed function group 'P' from creating object connections.
--  110721 Shdilk  FIDEAGLE-1061, Merged bug 97579, Corrected in Insert___() - re-added the currency type since it is not completly handled.
--  110812 Mohrlk  FFIDEAGLE-211, Modified method Refresh_Connection_Header().
--  111018 Swralk  SFI-128, Added conditional compilation for the places that had called package FIXASS_CONNECTION_V871_API.
--  111020 Swralk  SFI-143, Added conditional compilation for the places that had called package INTLED_CONNECTION_V101_API,INTLED_CONNECTION_V130_API and INTLED_CONNECTION_V140SP3_API. 
--  111102 Maaylk  SFI-266, LCS bug 98908, Added method Get_Internal_Code_Parts()
--  111213 Clstlk  SFI-784, LCS bug 99676, Added method Create_Object_Connection().
--  120206 Swralk  SFI-1357, Merged correction done for SIZ-817.
--  120229 Umdolk  SFI-2389, Corrected in Calculate_Cost_And_Progress.
-----------------------------------------------------------------------------
--  120419 AmThLK  EASTRTM-9789, modified Check_Project_Used()
--  120518 Swralk  OCT-60, Corrected sub project completion.
--  120530 Umdolk  Bug 102875, Merged flexcap bugs.    
--  120618 NUVELK  Modified Refresh_Connection_Header to pass correct values when calling Project_Connection_Util_API.Refresh_Header_And_Dates.
--  120625 AmThLK  Bug 102875,  modified Check_Project_Used()
--  120627 THPELK  Bug 97225, Corrected in Unpack_Check_Insert___() and Unpack_Check_Update___().
--  120631 Janblk  EDEL-871, Modified the logic of Check_Code_String_Fa___ to allow multiple code string         
--  120812 THPELK  Bug 104100, Merged. Corrected the Performance improvement in fetching voucher row number.
--  120817 Umdolk  EDEL-1324, Modified Complete_Voucher__ method to update add_investment_info records when completing the voucher. 
--  120823 Umdolk  EDEL-1506, Corrected in Create_Add_Investment_Info___  and Re_Create_Mod_Add_Inv_Info___.
--  120824 AmGalk  Bug 104365,Added extra check for function_group 'E' to Insert_Row__.
--  120828 MAAYLK  Bug 101320, Removed Internal_Manual_Postings_ () 
--  120912 Umdolk  EDEL-1646, Modified Check_Code_Str_Fa method to suppport multiple code strings.
--  120918 Janblk  EDEL-1708, Modified Check_Code_Str_Fa__
--  120921 Umdolk  EDEL-1814, Modified Check_Code_Str_Fa__ to correct fresh installation error.
--  120925 Umdolk  EDEL-1708, rollbacked the correction.
--  120920  THPELK  Bug 103538, Corrected in Get_Subcon_Total_Used_Cost().
--  120926  chanlk  Bug 105181, Modified Check_Codestring___.
--  121123  Thpelk  Bug 106680 - Modified Conditional compilation to use single component package.
--  121210  Maaylk  PEPA-183, Removed global variables
--  121130  Nirplk  Bug 107103, Corrected in Create_Object_Connection().
--  121211  Mawelk  Bug 106183 Fixed
--  121214  Clstlk  Bug 106800, Added columns entered_by_user_group,userid,approved_by_user_group,approved_by_userid in view2.
--  130308  CLSTLK  Bug 108417, Modified Interim_Voucher().   
--  130318  Maaylk  Bug 108608, Added Row_Group_id to VOUCHER_ROW_QRY_FINREP
--  130818  THPELK  Bug 108987, Corrected in Unpack_Check_Insert___() and Unpack_Check_Update___(). 
--  130419  AmGalk  Bug 109491, Rollback the bug correction 104365.
--  121123  Janblk  DANU-122, Parallel currency implementation  
--  130531  NILILK  DANU-1230, Modified procedure Interim_Voucher. 
--  130717  CPriLK  BRZ-3774, Added function group 'MPR' for required locations.
--  130801  THPELK  Bug 111757, Corrected in Create_Add_Investment_Info___() and Re_Create_Mod_Add_Inv_Info___().
--  130605  SALIDE  EDEL-2187, Modified Create_Add_Investment_Info___() and Insert_Row() to handle FA Cash Discount.
--  130823  Shedlk  Bug 111220, Corrected END statements to match the corresponding procedure name
--  130902  MAWELK  Bug 111219 Fixed. 
--  130924  Mawelk  Bug 112628 Fixed
--  140206  Charlk  Set the context of Fa_Message_API.key_  in Check_Insert__ method.
--  140207  Charlk  Modified Check_Insert__ method.
--  140303  Mawelk  PBFI-5118 (Lcs Bug Id 114911)
--  140313  THPELK  PBFI-4122 - LCS Merge ( Bug 113054).
--  140313  CPriLK  PBPJ-2620, Added MCPR cost posting types to Get_Activity_Info().
--  140425  PRatlk  PBFI-6887, Sent third currency information to add investment info table.
--  140430  Nirylk  PBFI-5614, Added deliv_type_id column, Modified Create_Tax_Transaction___(),Add_New_Row_(), Interim_Voucher() and Create_Cancel_Row_()
--                             Added new procedure Validate_Delivery_Type_Id__ and function Get_Delivery_Type_Description
--  140612  Jeguse  PRPJ-534, Modified Create_Object_Connection___, Calculate_Cost_Progress and added Refresh_Connection
--  141115  Chgulk  PRFI-3337, Merged LCS patch 119340.
--  140328  THPELK  PRFI-3705, LCS Merg(Bug 115796) Corrected.
--  150128  AjPelk  PRFI-4489, Lcs merge Bug 120401, Added the new field CURRENCY_RATE_TYPinsert
--  150309  CPriLK  ANPJ-22, Removed the object_staus from project_connection_util_api related method calls.
--  150526  CPriLK  ANPJ-522, Added PRJT12, PRJT13, PRJC15, PRJC16 to Get_Activity_Info().
--  150618  THPELK  FISU-248 - Correccted in Create_Cancel_Row___() TO Allow cancel Manual GL functionality for row connected with Projects. 
--  150603  Raablk  Bug 121642, Modified PROCEDURE Reverse_Voucher_Rows__ to pass mpccom accounting id.
--  150707  Kanslk  Bug 123433, Removed code introduced on PRFI-5158
--  150820  AmThLK Bug 123956, Modified Get_Delivery_Type_Description -- changed the description field size to 2000  
--  150820  THPELK  FISU-275, Corrected.
--  150918  CPriLK  AFT-5492, Remove PRJC15,PRJC16 postings to delimit XPR cost reporting.
--  151118  Mawelk Bug 125057, Fixed.
--  160201  Chwilk  Bug 125076, Modified Insert_Row__.
--  160517  Chwtlk  Bug 129235, Modified Create_Tax_Transaction___.
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------


-------------------- PRIVATE DECLARATIONS -----------------------------------


-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------

PROCEDURE Handle_Object_Conns___ (
   newrec_               IN VOUCHER_ROW_TAB%ROWTYPE,
   oldrec_               IN VOUCHER_ROW_TAB%ROWTYPE,
   from_insert_          IN BOOLEAN,
   create_project_conn_  IN VARCHAR2 ) 
IS
   function_group_  VARCHAR2(30);
   old_excl_proj_flwup_     VARCHAR2(5);
   new_excl_proj_flwup_     VARCHAR2(5);   
BEGIN
   IF (from_insert_) THEN
      -- comming from insert___
      IF (create_project_conn_ = 'TRUE') THEN
            UPDATE voucher_tab
            SET proj_conn_created = 'TRUE'	          
            WHERE company         = newrec_.company
            AND   accounting_year = newrec_.accounting_year
            AND   voucher_type    = newrec_.voucher_type
            AND   voucher_no      = newrec_.voucher_no;
           
            IF (newrec_.project_id IS NOT NULL) AND ((NVL(newrec_.project_activity_id,0) != 0) AND (newrec_.project_activity_id != -123456)) THEN
               function_group_ := Voucher_API.Get_Function_Group(newrec_.company,
                                                                 newrec_.accounting_year,
                                                                 newrec_.voucher_type,
                                                                 newrec_.voucher_no); 
               IF (NOT (function_group_ = 'D' AND newrec_.inv_acc_row_id IS NOT NULL))
                  AND 
                  (NOT (function_group_ = 'K' AND (newrec_.party_type = 'CUSTOMER' OR newrec_.party_type = 'SUPPLIER') 
                                           AND newrec_.party_type IS NOT NULL))THEN
                  -- These belong to manual vouchers and object connections cannot be created at this
                  -- point until the final voucher number is known                  
                  IF (function_group_ IN ('0','L','T','O','V','TF','E','W','D','TP','TE','AFP', 'MPR')) THEN
                     Create_Object_Connection___(newrec_);                  
                  ELSIF function_group_ IN ('M','K','Q') THEN
                     -- This voucher row belongs to a manual voucher, therefore special handling
                     IF (newrec_.voucher_no > 0) THEN
                        -- This means that proper voucher number has been assigned  
                        -- for automatically alloting vouchers, the number would be negative until final voucher number is assigned
                        -- So this means that the voucher is either finalized or manually alloting.
                        -- Therefore need to create object connection here
                        Create_Object_Connection___(newrec_);
                     END IF;                          
                  END IF;
               END IF;      
            END IF;
      END IF;
   ELSE
      -- coming from update___
     function_group_ := Voucher_API.Get_Function_Group(newrec_.company,
                                                     newrec_.accounting_year,
                                                     newrec_.voucher_type,
                                                     newrec_.voucher_no);
   
      IF function_group_ IN ('M','Q','K') THEN
         IF (newrec_.project_id IS NOT NULL) AND (NVL(newrec_.project_activity_id,0) != 0)  THEN
            IF (NVL(oldrec_.project_activity_id,0) != 0) THEN
               IF (newrec_.project_activity_id != oldrec_.project_activity_id) THEN
                  -- Remove old Object Connection and Cost Info
                  Remove_Object_Connection___(oldrec_);
                  -- Create new Object Connection and Cost Info
                  Create_Object_Connection___(newrec_);
               ELSE                  
                  old_excl_proj_flwup_ := nvl(Account_API.Get_Exclude_Proj_Followup(oldrec_.company, oldrec_.account), 'FALSE');
                  new_excl_proj_flwup_ := nvl(Account_API.Get_Exclude_Proj_Followup(newrec_.company, newrec_.account), 'FALSE');
                  IF (old_excl_proj_flwup_='TRUE' AND new_excl_proj_flwup_='FALSE') THEN
                     --create connection
                     Create_Object_Connection___(newrec_);
                  END IF;
                  IF (old_excl_proj_flwup_='FALSE' AND new_excl_proj_flwup_='TRUE') THEN
                     --remove connection
                     Remove_Object_Connection___(oldrec_);
                  END IF; 
                 
                  IF (oldrec_.voucher_date != newrec_.voucher_date) THEN
                     Refresh_Connection_Header ( newrec_.company,
                                                 newrec_.voucher_type,
                                                 newrec_.accounting_year,
                                                 newrec_.voucher_no,
                                                 newrec_.row_no );
                  END IF;

                  IF (Obj_Conn_Refresh_Req___(oldrec_,newrec_)) THEN
                     -- Refresh Object Connection and Cost Info  
                     Calculate_Cost_And_Progress (newrec_.company,
                                                  newrec_.voucher_type,
                                                  newrec_.accounting_year,
                                                  newrec_.voucher_no,
                                                  newrec_.row_no);
                  END IF;
               END IF;
            ELSE
               -- Create new Object Connection and Cost Info
               Create_Object_Connection___(newrec_);
            END IF;
         ELSE
            IF (NVL(oldrec_.project_activity_id,0) != 0) THEN
               -- Remove old Object Connection and Cost Info
               Remove_Object_Connection___(oldrec_);
            END IF;
         END IF;
      END IF;
   END IF;     
END Handle_Object_Conns___;


PROCEDURE Check_Acquisition___ (
   newrec_           IN OUT VOUCHER_ROW_TAB%ROWTYPE,
   function_groupx_  IN     VARCHAR2,
   fa_code_partx_    IN     VARCHAR2 )
IS
   fa_code_part_           VARCHAR2(10);
   object_id_              VARCHAR2(20);
   account_                VARCHAR2(20);
   fa_codestring_rec_      Accounting_codestr_API.CodestrRec;
   is_acq_account_         BOOLEAN;
   function_group_         VARCHAR2(10);
   $IF Component_Fixass_SYS.INSTALLED $THEN
      object_acq_rec_         Fa_Object_API.Public_Object_Acq_Rec;
   $END
   no_action   EXCEPTION;
BEGIN
   -- Find out if FIXASS is installed
   $IF Component_Fixass_SYS.INSTALLED $THEN
      newrec_.object_id := NULL;
      -- Get function group. IF A and Q, skip
      function_group_ := function_groupx_;
      IF (function_group_ IS NULL) THEN
         function_group_ := Voucher_Type_Detail_API.Get_Function_Group( newrec_.company, newrec_.voucher_type );
      END IF;
      IF (function_group_ IN ( 'A', 'Q' ) ) THEN
         RAISE no_action;
      END IF;
      -- Get FA code part
      fa_code_part_ := fa_code_partx_;
      IF (fa_code_part_ IS NULL) THEN
         fa_code_part_ := Accounting_Code_Parts_API.Get_Codepart_Function(newrec_.company,'FAACC');
      END IF;
      account_ := newrec_.account;
      IF ( account_ IS NULL ) THEN
         RAISE no_action;
      END IF; 
      is_acq_account_ := Acquisition_Account_API.Is_Acquisition_Account (newrec_.company, account_);
      IF (is_acq_account_) THEN
         fa_codestring_rec_.code_a := newrec_.account;
         fa_codestring_rec_.code_b := newrec_.code_b;
         fa_codestring_rec_.code_c := newrec_.code_c;
         fa_codestring_rec_.code_d := newrec_.code_d;
         fa_codestring_rec_.code_e := newrec_.code_e;
         fa_codestring_rec_.code_f := newrec_.code_f;
         fa_codestring_rec_.code_g := newrec_.code_g;
         fa_codestring_rec_.code_h := newrec_.code_h;
         fa_codestring_rec_.code_i := newrec_.code_i;
         fa_codestring_rec_.code_j := newrec_.code_j;
         IF (upper(fa_code_part_) = 'B') THEN
            object_id_ := newrec_.code_b;
         ELSIF (upper(fa_code_part_) = 'C') THEN
            object_id_ := newrec_.code_c;
         ELSIF (upper(fa_code_part_) = 'D') THEN
            object_id_ := newrec_.code_d;
         ELSIF (upper(fa_code_part_) = 'E') THEN
            object_id_ := newrec_.code_e;
         ELSIF (upper(fa_code_part_) = 'F') THEN
            object_id_ := newrec_.code_f;
         ELSIF (upper(fa_code_part_) = 'G') THEN
            object_id_ := newrec_.code_g;
         ELSIF (upper(fa_code_part_) = 'H') THEN
            object_id_ := newrec_.code_h;
         ELSIF (upper(fa_code_part_) = 'I') THEN
            object_id_ := newrec_.code_i;
         ELSIF (upper(fa_code_part_) = 'J') THEN
            object_id_ := newrec_.code_j;
         END IF;
         newrec_.object_id := object_id_;
         --  Check Fa vouchers for the current object in the hold table
         IF ( object_id_ IS  NOT NULL) THEN
            Check_Code_String_Fa___ (newrec_.company,
                                     object_id_,
                                     fa_code_part_,
                                     fa_codestring_rec_,
                                     newrec_.voucher_type);
         END IF;
         --
         object_acq_rec_.company         := newrec_.company;
         object_acq_rec_.object_id       := object_id_;
         object_acq_rec_.account         := newrec_.account;
         object_acq_rec_.code_b          := newrec_.code_b;
         object_acq_rec_.code_c          := newrec_.code_c;
         object_acq_rec_.code_d          := newrec_.code_d;
         object_acq_rec_.code_e          := newrec_.code_e;
         object_acq_rec_.code_f          := newrec_.code_f;
         object_acq_rec_.code_g          := newrec_.code_g;
         object_acq_rec_.code_h          := newrec_.code_h;
         object_acq_rec_.code_i          := newrec_.code_i;
         object_acq_rec_.code_j          := newrec_.code_j;
         object_acq_rec_.voucher_type    := newrec_.voucher_type;
         object_acq_rec_.voucher_number  := newrec_.voucher_no;
         object_acq_rec_.accounting_year := newrec_.accounting_year;
         object_acq_rec_.function_group  := function_group_;
         object_acq_rec_.fa_code_part    := fa_code_part_;
         Fa_Object_API.Check_Acquisition ( object_acq_rec_ );
      END IF;
   $ELSE
      NULL;
   $END
EXCEPTION
  WHEN no_action THEN
     NULL;
END Check_Acquisition___;


PROCEDURE Check_Period_Allocation___ (
   newrec_ IN VOUCHER_ROW_TAB%ROWTYPE )
IS
   allocated_        NUMBER;
   voucher_date_     DATE;
   function_group_   voucher_type_detail_tab.function_group%TYPE;
BEGIN
   allocated_ := Period_Allocation_API.Any_Voucher( newrec_.company,
                                                    newrec_.voucher_type,
                                                    newrec_.voucher_no,
                                                    newrec_.accounting_year,
                                                    newrec_.row_no );
   IF (allocated_ = 1) THEN
      Error_SYS.Record_General(lu_name_, 'EXISTINPERALLOC: Can not change Voucher row that exists in Period Allocation');
   END IF;
   IF (newrec_.voucher_date IS NOT NULL) THEN
      voucher_date_ := newrec_.voucher_date;
   ELSE
      voucher_date_ := Voucher_API.Get_Voucher_Date (newrec_.company,
                                                     newrec_.accounting_year,
                                                     newrec_.voucher_type,
                                                     newrec_.voucher_no);
   END IF;
   $IF Component_Intled_SYS.INSTALLED $THEN
      function_group_ := Voucher_Type_API.Get_Voucher_Group(newrec_.company, newrec_.voucher_type);
      IF (((upper(newrec_.trans_code) != 'MANUAL') AND (NOT((upper(newrec_.trans_code) = 'EXTERNAL') AND function_group_ = 'D'))) 
      AND NOT ((Voucher_Type_API.Get_Use_Manual(newrec_.company,
                                                newrec_.voucher_type) = 'TRUE') AND
           (Internal_Voucher_Util_Pub_API.Check_If_Manual(newrec_.company,
                                                          newrec_.account,
                                                          voucher_date_) IS NOT NULL))) THEN
         IF (upper(newrec_.trans_code) = 'INTERIM') THEN
            Error_SYS.Record_General(lu_name_, 'NOINTERIM: The voucher is connected to an interim voucher and cannot be changed');
         ELSE
            Error_SYS.Record_General(lu_name_, 'NOMANUAL: The voucher row is automatically created and cannot be changed');
         END IF;
      END IF;
   $END
END Check_Period_Allocation___;


PROCEDURE Check_Codestring___ (
   newrec_                    IN VOUCHER_ROW_TAB%ROWTYPE,
   user_groupx_               IN VARCHAR2,
   check_codeparts_           BOOLEAN DEFAULT TRUE,
   check_demands_codeparts_   BOOLEAN DEFAULT TRUE,
   check_demands_quantity_    BOOLEAN DEFAULT TRUE,
   check_demands_process_     BOOLEAN DEFAULT TRUE,
   check_demands_text_        BOOLEAN DEFAULT TRUE )
IS
   codestring_rec_         Accounting_codestr_API.CodestrRec;
   head_                   Voucher_Api.Public_Rec;
   user_group_             user_group_member_finance_tab.user_group%TYPE;
   budget_account_         BOOLEAN;
BEGIN
   IF (user_groupx_ IS NULL) THEN
      head_ := Voucher_API.Get( newrec_.company,
                                newrec_.accounting_year,
                                newrec_.voucher_type,
                                newrec_.voucher_no );
      user_group_   := head_.user_group;
   ELSE
      user_group_   := user_groupx_;
   END IF;
   codestring_rec_.code_a       := newrec_.account;
   codestring_rec_.code_b       := newrec_.code_b;
   codestring_rec_.code_c       := newrec_.code_c;
   codestring_rec_.code_d       := newrec_.code_d;
   codestring_rec_.code_e       := newrec_.code_e;
   codestring_rec_.code_f       := newrec_.code_f;
   codestring_rec_.code_g       := newrec_.code_g;
   codestring_rec_.code_h       := newrec_.code_h;
   codestring_rec_.code_i       := newrec_.code_i;
   codestring_rec_.code_j       := newrec_.code_j;
   codestring_rec_.process_code := newrec_.process_code;
   codestring_rec_.quantity     := newrec_.quantity;
   codestring_rec_.text         := newrec_.text;
   --Bug 105181, Start
   codestring_rec_.function_group := Voucher_Type_Api.Get_Voucher_Group(newrec_.company, newrec_.voucher_type);
   --Bug 105181, End
   budget_account_              := Account_Api.Is_Budget_Account(newrec_.company, codestring_rec_.code_a);
   --Bug 105181, Start
   IF (codestring_rec_.function_group = 'Z') AND (budget_account_) THEN
      Accounting_Codestr_API.Validate_Budget_Codestring ( codestring_rec_,
                                                          newrec_.company,
                                                          newrec_.voucher_date,
                                                          user_group_ );
   ELSE
      Accounting_Codestr_API.Validate_Codestring(codestring_rec_,
                                                 newrec_.company,
                                                 newrec_.voucher_date,
                                                 user_group_,
                                                 check_codeparts_,
                                                 check_demands_codeparts_,
                                                 check_demands_quantity_,
                                                 check_demands_process_,
                                                 check_demands_text_);
   END IF;
   --Bug 105181, End
END Check_Codestring___;


PROCEDURE Check_Project___ (
   newrec_            IN OUT VOUCHER_ROW_TAB%ROWTYPE,
   function_group_    IN     VARCHAR2 )
 IS
   dummy_codepart_value_   VARCHAR2(20);
   dummy_project_id_       VARCHAR2(20);
   is_project_code_part_   VARCHAR2(1);
   project_origin_         VARCHAR2(30);
   module_                 VARCHAR2(100);
   view_name_              VARCHAR2(10);
   pkg_name_               VARCHAR2(15);
   internal_name_          VARCHAR2(200);
   ext_val_                VARCHAR2(5);



   CURSOR c1 IS
      SELECT code_part, view_name, pkg_name,
             Enterp_Comp_Connect_V170_API.Get_Company_Translation(company, 'ACCRUL', 'AccountingCodeParts', code_part)
      FROM   accounting_code_part_tab
      WHERE  company           = newrec_.company
      AND    logical_code_part = 'Project';
BEGIN
   Finance_Lib_API.Check_Module(module_);

   IF (module_ = 'ACCRUL' ) THEN
      OPEN  c1;
      FETCH c1 INTO is_project_code_part_, view_name_, pkg_name_, internal_name_;
      CLOSE c1;
   ELSE
      is_project_code_part_ := Accounting_Code_Parts_Api.Get_Codepart_Function(newrec_.company, 'PRACC');
   END IF;
   IF (is_project_code_part_ = 'B') THEN
      dummy_codepart_value_ := newrec_.code_b;
   ELSIF (is_project_code_part_ = 'C') THEN
      dummy_codepart_value_ := newrec_.code_c;
   ELSIF (is_project_code_part_ = 'D') THEN
      dummy_codepart_value_ := newrec_.code_d;
   ELSIF (is_project_code_part_ = 'E') THEN
      dummy_codepart_value_ := newrec_.code_e;
   ELSIF (is_project_code_part_ = 'F') THEN
      dummy_codepart_value_ := newrec_.code_f;
   ELSIF (is_project_code_part_ = 'G') THEN
      dummy_codepart_value_ := newrec_.code_g;
   ELSIF (is_project_code_part_ = 'H') THEN
      dummy_codepart_value_ := newrec_.code_h;
   ELSIF (is_project_code_part_ = 'I') THEN
      dummy_codepart_value_ := newrec_.code_i;
   ELSIF (is_project_code_part_ = 'J') THEN
      dummy_codepart_value_ := newrec_.code_j;
   END IF;
   dummy_project_id_ := dummy_codepart_value_;
   --  removed check on project status    
      
   IF NOT (newrec_.project_activity_id = -123456 ) THEN
      IF NOT(newrec_.trans_code = 'External') THEN
         IF (newrec_.project_activity_id IS NOT NULL AND 
             dummy_codepart_value_ IS NULL) THEN
            Error_SYS.Appl_General(lu_name_, 'NOPROJSPECIFIED: A Project must be specified in order for Activity Sequence No to have a value');
         END IF;
      END IF;
   END IF;
   -- since there is a possibility to run this( ACCRULL ) without GENLED accr to spec
   IF (dummy_codepart_value_ IS NOT NULL) THEN
      $IF Component_Genled_SYS.INSTALLED $THEN
         project_origin_:= Accounting_Project_API.Get_Project_Origin_Db( newrec_.company , dummy_codepart_value_ );
      $ELSE
         project_origin_:= NULL;
      $END
   END IF;   
   IF (project_origin_ = 'PROJECT') AND
      (newrec_.project_activity_id IS NOT NULL) AND
      (newrec_.project_activity_id > 0 ) AND
      NVL(Account_API.Get_Exclude_Proj_Followup(newrec_.company, newrec_.account), 'FALSE') = 'TRUE' THEN
      Error_SYS.Record_General(lu_name_, 'PROJACTINOTNULL: Account :P1 is marked for Exclude Project Follow Up and it is not allowed to post to a project activity. Remove the activity sequence before continuing.', newrec_.account);
   END IF;   
   IF (project_origin_ = 'PROJECT') AND 
      (newrec_.project_activity_id IS NULL) THEN
      IF (function_group_ != 'Z') AND 
         (function_group_ != 'A') AND
         (function_group_ != 'H') AND
         (function_group_ != 'PPC') THEN
         IF NVL(Account_API.Get_Exclude_Proj_Followup(newrec_.company, newrec_.account), 'FALSE') = 'FALSE' THEN
            Error_SYS.Record_General(lu_name_, 'PROJACTIMANDATORY: Activity Sequence No must have a value for Project :P1', dummy_codepart_value_);
         END IF;         

      ELSIF  (function_group_ = 'Z') THEN
         $IF Component_Percos_SYS.INSTALLED $THEN
            ext_val_ := Get_Pca_Ext_Project(newrec_.company);

            IF( ext_val_ = 'FALSE')THEN
               Error_SYS.Record_General(lu_name_,'NOTALLWDFOREXTPROJS: It is not allowed to create transactions for projects created in IFS/Project.');
            END IF;
         $ELSE
            NULL;
         $END
      ELSE
         newrec_.project_activity_id := NULL;
      END IF;
   ELSIF (project_origin_ = 'JOB') THEN
      IF (function_group_ NOT IN ('M', 'K', 'Q','A','P','R','Z','D', 'PPC')) THEN
         IF (newrec_.project_activity_id <> 0) THEN
            Error_SYS.Record_General(lu_name_, 'ACTSEQNOMUSTBEZERO: Activity Sequence No must be zero for Project :P1', dummy_codepart_value_);
         END IF;
      ELSE
         newrec_.project_activity_id := 0;
      END IF;
   ELSIF (newrec_.project_activity_id = -123456) THEN
      newrec_.project_activity_id := NULL;
   END IF;
   IF (project_origin_ = 'PROJECT') THEN
      $IF Component_Proj_SYS.INSTALLED $THEN
         IF (function_group_ NOT IN ( 'P') ) THEN
            IF (newrec_.project_activity_id IS NOT NULL) THEN
               IF (Activity_API.Is_Activity_Valid_For_Project(dummy_codepart_value_, newrec_.project_activity_id) = 0) THEN
                  Error_SYS.Record_General(lu_name_,'ACTIVITYINVALID: Activity sequence no :P1 is not connected to project :P2', newrec_.project_activity_id, dummy_codepart_value_);
               END IF;   
               IF (Activity_API.Is_Activity_Postable(dummy_codepart_value_, newrec_.project_activity_id) = 0) THEN
                  Error_SYS.Record_General(lu_name_,'ACTIDNOTPOSTABLE: In Project :P1 , Activity Sequence No :P2 is Planned, Closed or Cancelled. This operation is not allowed on Planned, Closed or Cancelled activities.',dummy_codepart_value_,newrec_.project_activity_id);
               END IF;
			      -- Bug 123433, removed code introduced on PRFI-5158
               /*
               stmt_ := 'BEGIN :postable_ := Activity_API.Is_Activity_Postable(:project_id_, :project_activity_id_); END;';
               -- ifs_assert_safe shsalk 20051111
               Execute Immediate stmt_ using IN OUT postable_,dummy_codepart_value_,newrec_.project_activity_id;

               IF (postable_ = 0) THEN
                  Error_SYS.Record_General(lu_name_,'ACTIDNOTPOSTABLE: In Project :P1 , Activity Sequence No :P2  is closed or cancelled. This operation is not allowed on closed or cancelled activities.',dummy_codepart_value_,newrec_.project_activity_id);
               END IF;   
               */
            END IF;
         END IF;
      $ELSE
         NULL;
      $END
   END IF;
   IF (function_group_ NOT IN ( 'P', 'PPC') AND project_origin_ IN ('FINPROJECT','JOB','PROJECT')) THEN
      $IF Component_Genled_SYS.INSTALLED $THEN
         IF ( ACCOUNTING_PROJECT_API.Get_Project_Db_Status(newrec_.company,dummy_codepart_value_) = 'C' ) THEN
            Error_SYS.Record_General(lu_name_,'COMPLETEDFINPROJ: This operation is not allowed on Completed Project :P1.',dummy_codepart_value_);
         END IF;
      $ELSE
         NULL;
      $END
   END IF;   
EXCEPTION
   WHEN NO_DATA_FOUND THEN
      RAISE;
   WHEN OTHERS THEN
      RAISE;
END Check_Project___;


PROCEDURE Internal_Manual_Postings___ (
   newrec_               IN VOUCHER_ROW_TAB%ROWTYPE,
   is_insert_            IN BOOLEAN,
   base_curr_rounding_   IN NUMBER,
   trans_curr_rounding_  IN NUMBER,
   third_curr_rounding_  IN NUMBER,
   from_pa_              IN BOOLEAN DEFAULT FALSE   )
IS
   voucher_date_            DATE;
   CURSOR get_manual_rows IS
      SELECT *
      FROM   INTERNAL_POSTINGS_ACCRUL_TAB
      WHERE  company             = newrec_.company
      AND    internal_seq_number = newrec_.internal_seq_number
      FOR UPDATE;
BEGIN
   $IF Component_Intled_SYS.INSTALLED $THEN
      IF (Voucher_Type_API.Is_Vou_Type_All_Ledger(newrec_.company, newrec_.voucher_type) = 'TRUE') THEN
         IF (NOT from_pa_) THEN
            IF (NOT is_insert_) THEN
               Internal_Voucher_Util_Pub_API.Delete_Internal_Rows (newrec_.company,
                                                                   newrec_.voucher_type,
                                                                   newrec_.accounting_year,
                                                                   newrec_.voucher_no,
                                                                   newrec_.account,
                                                                   newrec_.row_no);
            ELSE
               FOR rec_ IN get_manual_rows LOOP
               UPDATE INTERNAL_POSTINGS_ACCRUL_TAB
               SET    voucher_no   = newrec_.voucher_no,
                     voucher_type = newrec_.voucher_type,
                     ref_row_no   = newrec_.row_no
               WHERE CURRENT OF get_manual_rows;
               END LOOP;
            END IF;
         END IF;
         
         IF (newrec_.voucher_date IS NOT NULL) THEN
            voucher_date_ := newrec_.voucher_date;
         ELSE
            voucher_date_ := Voucher_API.Get_Voucher_Date (newrec_.company,
                                                           newrec_.accounting_year,
                                                           newrec_.voucher_type,
                                                           newrec_.voucher_no);
         END IF;
         IF ((Internal_Voucher_Util_Pub_API.Check_If_Manual (newrec_.company,
                                                             newrec_.account,
                                                             voucher_date_) IS NOT NULL) AND
              Voucher_Type_API.Get_Use_Manual(newrec_.company,
                                              newrec_.voucher_type) = 'TRUE') THEN
              Create_Int_Manual_Postings__ (newrec_.company,
                                            newrec_.voucher_type,
                                            newrec_.accounting_year,
                                            newrec_.voucher_no,
                                            newrec_.row_no,
                                            from_pa_);
         END IF;
           IF (from_pa_) THEN
               Internal_Voucher_Util_Pub_API.Create_Pa_Internal_Row (newrec_,
                                                                     NULL,
                                                                     base_curr_rounding_,   
                                                                     trans_curr_rounding_,  
                                                                     third_curr_rounding_); 
           ELSE
               Internal_Voucher_Util_Pub_API.Create_Internal_Row ( newrec_,
                                                                base_curr_rounding_,
                                                                trans_curr_rounding_,
                                                                third_curr_rounding_ );
           END IF;
      END IF;
   $ELSE
      NULL;
   $END
END Internal_Manual_Postings___;


PROCEDURE Internal_Manual_Postings___ (
   newrec_         IN VOUCHER_ROW_TAB%ROWTYPE,
   is_insert_      IN BOOLEAN DEFAULT FALSE,
   from_pa_        IN BOOLEAN DEFAULT FALSE   )
IS
   base_currency_code_         VARCHAR2(3);
   base_curr_rounding_         NUMBER;
   trans_curr_rounding_        NUMBER;
   third_currency_code_        VARCHAR2(3);
   third_curr_rounding_        NUMBER;
   voucher_date_               DATE;
BEGIN
   $IF Component_Intled_SYS.INSTALLED $THEN
      IF (newrec_.voucher_date IS NOT NULL) THEN
         voucher_date_ := newrec_.voucher_date;
      ELSE
         voucher_date_ := Voucher_API.Get_Voucher_Date (newrec_.company,
                                                        newrec_.accounting_year,
                                                        newrec_.voucher_type,
                                                        newrec_.voucher_no);
      END IF;
      base_currency_code_  := Company_Finance_Api.Get_Currency_Code (newrec_.company);
      base_curr_rounding_  := Currency_Code_API.Get_currency_rounding (newrec_.company,
                                                                       base_currency_code_);
      third_currency_code_ := Company_Finance_Api.Get_Parallel_Acc_Currency (newrec_.company,
                                                                             voucher_date_);
      IF (newrec_.currency_code = base_currency_code_) THEN
         trans_curr_rounding_ := base_curr_rounding_;
      ELSE
         trans_curr_rounding_ := Currency_Code_API.Get_currency_rounding (newrec_.company,
                                                                          newrec_.currency_code);
      END IF;
      IF (third_currency_code_ IS NOT NULL) THEN
         IF    (third_currency_code_ = base_currency_code_) THEN
            third_curr_rounding_ := base_curr_rounding_;
         ELSIF (third_currency_code_ = newrec_.currency_code) THEN
            third_curr_rounding_ := trans_curr_rounding_;
         ELSE
            third_curr_rounding_  := Currency_Code_API.Get_currency_rounding (newrec_.company,
                                                                              third_currency_code_);
         END IF;
      END IF;

      Internal_Manual_Postings___ ( newrec_,
                                    is_insert_,
                                    base_curr_rounding_,
                                    trans_curr_rounding_,
                                    third_curr_rounding_,
                                    from_pa_ );
   $ELSE
      NULL;
   $END
END Internal_Manual_Postings___;


PROCEDURE Check_And_Set_Amounts___ (
   newrec_            IN OUT VOUCHER_ROW_TAB%ROWTYPE,
   currency_amount_   IN     VOUCHER_ROW.currency_amount%TYPE,
   amount_            IN     VOUCHER_ROW.amount%TYPE,
   correction_        IN     VOUCHER_ROW.correction%TYPE)
IS
BEGIN
   IF ( NVL(newrec_.debet_amount,0) = 0 AND NVL(newrec_.credit_amount,0) = 0 ) THEN
      IF ( (amount_ > 0 AND correction_ = 'N') OR
           (amount_ < 0 AND correction_ = 'Y') ) THEN
         newrec_.debet_amount := amount_;
      ELSIF (amount_ = 0) THEN
         IF newrec_.debet_amount = 0 THEN
            newrec_.debet_amount := 0;
            newrec_.credit_amount := NULL;
         ELSIF newrec_.credit_amount = 0 THEN
            newrec_.credit_amount := 0;
            newrec_.debet_amount := NULL;
         ELSE
            newrec_.debet_amount := 0;
            newrec_.credit_amount := NULL;
         END IF;
      ELSE
         newrec_.credit_amount := -amount_;
      END IF;
   END IF;
   IF ( NVL(newrec_.currency_debet_amount,0) = 0 AND NVL(newrec_.currency_credit_amount,0) = 0 ) THEN
      IF ( (currency_amount_ > 0 AND correction_ = 'N') OR
           (currency_amount_ < 0 AND correction_ = 'Y') ) THEN
         newrec_.currency_debet_amount := currency_amount_;
         newrec_.currency_credit_amount := NULL;
      ELSIF (currency_amount_ = 0) THEN
        IF (amount_ <> 0) THEN
            IF (newrec_.debet_amount IS NOT NULL ) THEN
               newrec_.currency_debet_amount  := 0;
               newrec_.currency_credit_amount := NULL;
            ELSE
               newrec_.currency_debet_amount  := NULL;
               newrec_.currency_credit_amount := 0;
            END IF;
        ELSE
            IF newrec_.debet_amount = 0 THEN
                newrec_.currency_debet_amount  := 0;
                newrec_.currency_credit_amount := NULL;
            ELSIF newrec_.credit_amount = 0 THEN
                newrec_.currency_credit_amount := 0;
                newrec_.currency_debet_amount := NULL;
            ELSE
                newrec_.currency_debet_amount  := 0;
                newrec_.currency_credit_amount := NULL;
            END IF;
        END IF;
      ELSE
         newrec_.currency_credit_amount := -currency_amount_;
         newrec_.currency_debet_amount  := NULL;
      END IF;
   END IF;
END Check_And_Set_Amounts___;


PROCEDURE Check_Code_String_Fa___ (
   company_        IN VARCHAR2,
   object_id_      IN VARCHAR2,
   fa_code_part_   IN VARCHAR2,
   codestring_rec_ IN Accounting_codestr_API.CodestrRec,
   voucher_type_   IN VARCHAR2   )
IS
   TYPE FaCodestrRec IS RECORD (
      code_a        VARCHAR2(20),
      code_b        VARCHAR2(20),
      code_c        VARCHAR2(20),
      code_d        VARCHAR2(20),
      code_e        VARCHAR2(20),
      code_f        VARCHAR2(20),
      code_g        VARCHAR2(20),
      code_h        VARCHAR2(20),
      code_i        VARCHAR2(20),
      code_j        VARCHAR2(20));
   fa_codestring_rec_          FaCodestrRec;
   account_                    VOUCHER_ROW_TAB.ACCOUNT%TYPE;
   no_action                   EXCEPTION;
   ill_code_string_Fa          EXCEPTION;
   multiple_code_string_       VARCHAR2(5) := 'FALSE';

-- Authorization is not done for company because this is an
-- implementation procedure and that company should already been checked.
--
   CURSOR fa_codepart_ IS
      SELECT account code_a,
             code_b,
             code_c,
             code_d,
             code_e,
             code_f,
             code_g,
             code_h,
             code_i,
             code_j
      FROM   voucher_row_tab
      WHERE  company       = company_
      AND    account       = account_
      AND    object_id     = object_id_
      AND    object_id     IS NOT NULL;
BEGIN
   IF (object_id_ IS NULL ) THEN
      RAISE no_action;
   END IF;

--
-- Get previous used code strings for current object for given
-- code part. Only necessary to fetch one row.
--
   account_   := codestring_rec_.code_a;
   OPEN fa_codepart_;
   FETCH fa_codepart_ INTO fa_codestring_rec_;
   IF fa_codepart_%NOTFOUND THEN
      CLOSE fa_codepart_;
      RAISE no_action;
   END IF;

   IF Voucher_Type_API.Get_Voucher_Group(company_,voucher_type_) = 'A'  THEN
      multiple_code_string_ := 'TRUE';
   ELSE
      $IF Component_Fixass_SYS.INSTALLED $THEN
         multiple_code_string_ := Fnd_Boolean_API.Encode(Fa_Company_API.Get_Multiple_Code_String(company_));   
      $ELSE
         NULL;
      $END
   END IF;
--
-- Now check the code string
--

   IF ( object_id_ IS NOT NULL ) THEN
      IF ( codestring_rec_.code_a <> fa_codestring_rec_.code_a )  AND  multiple_code_string_ = 'FALSE'  THEN
         RAISE ill_code_string_FA;
      END IF;
      IF ( NVL(codestring_rec_.code_b,' ') <> NVL(fa_codestring_rec_.code_b,' ') )  AND  multiple_code_string_ = 'FALSE' THEN
         RAISE ill_code_string_FA;
      END IF;
      IF ( NVL(codestring_rec_.code_c,' ') <> NVL(fa_codestring_rec_.code_c,' ') ) AND  multiple_code_string_ = 'FALSE'  THEN
         RAISE ill_code_string_FA;
      END IF;
      IF ( NVL(codestring_rec_.code_d,' ') <> NVL(fa_codestring_rec_.code_d,' ') ) AND  multiple_code_string_ = 'FALSE'  THEN
         RAISE ill_code_string_FA;
      END IF;
      IF ( NVL(codestring_rec_.code_e,' ') <> NVL(fa_codestring_rec_.code_e,' ') ) AND  multiple_code_string_ = 'FALSE'  THEN
         RAISE ill_code_string_FA;
      END IF;
      IF ( NVL(codestring_rec_.code_f,' ') <> NVL(fa_codestring_rec_.code_f,' ') ) AND  multiple_code_string_ = 'FALSE'  THEN
         RAISE ill_code_string_FA;
      END IF;
      IF ( NVL(codestring_rec_.code_g,' ') <> NVL(fa_codestring_rec_.code_g,' ') ) AND  multiple_code_string_ = 'FALSE'  THEN
         RAISE ill_code_string_FA;
      END IF;
      IF ( NVL(codestring_rec_.code_h,' ') <> NVL(fa_codestring_rec_.code_h,' ') ) AND  multiple_code_string_ = 'FALSE'  THEN
         RAISE ill_code_string_FA;
      END IF;
      IF ( NVL(codestring_rec_.code_i,' ') <> NVL(fa_codestring_rec_.code_i,' ') ) AND  multiple_code_string_ = 'FALSE'  THEN
         RAISE ill_code_string_FA;
      END IF;
      IF ( NVL(codestring_rec_.code_j,' ') <> NVL(fa_codestring_rec_.code_j,' ') )  AND  multiple_code_string_ = 'FALSE' THEN
         RAISE ill_code_string_FA;
      END IF;
   END IF;
EXCEPTION
  WHEN no_action THEN
     NULL;
  WHEN ill_code_string_Fa THEN
     Error_SYS.Appl_General(lu_name_,
        'ILLFACODESTRING: Object :P1 has existing voucher rows (in the hold table)with a code string that differs from the voucher row to be created',
        object_id_ );
END Check_Code_String_Fa___;


PROCEDURE Check_Overwriting_Level___(
   newrec_           IN VOUCHER_ROW_TAB%ROWTYPE)
IS
   voucher_date_     DATE;
   div_factor_       NUMBER;
   amount_           NUMBER;
   amount_method_    VARCHAR2(200);
   tax_type_         VARCHAR2(200);


   CURSOR vou_head_info IS
      SELECT amount_method,
             voucher_date
      FROM   voucher_tab
      WHERE  company         = newrec_.company
      AND    accounting_year = newrec_.accounting_year
      AND    voucher_no      = newrec_.voucher_no
      AND    voucher_type    = newrec_.voucher_type ;
BEGIN
   IF (newrec_.optional_code IS NOT NULL AND newrec_.tax_amount IS NOT NULL) THEN
      OPEN vou_head_info;
      FETCH vou_head_info INTO amount_method_,
                               voucher_date_;
      CLOSE vou_head_info;

      div_factor_ := nvl(Currency_Rate_API.Get_Conv_Factor(newrec_.company,
                                                           newrec_.currency_code,
                                                           Currency_Type_API.Get_Default_Type(newrec_.company),
                                                                                              voucher_date_), 1);
      IF (amount_method_ IN ('GROSS')) THEN
         amount_ := abs(nvl(newrec_.debet_amount, newrec_.credit_amount)) + abs(newrec_.tax_amount);
      ELSIF (amount_method_ IN ('NET')) THEN
         amount_ := abs(nvl(newrec_.debet_amount, newrec_.credit_amount));
      END IF;

      Statutory_Fee_API.Get_Fee_Type (tax_type_,
                                      newrec_.company,
                                      newrec_.optional_code,
                                      voucher_date_);
      IF (tax_type_ <> 'NOTAX') THEN
         Level_Info_Util_API.Check_Level(newrec_.company,
                                      amount_,
                                      abs(newrec_.tax_amount),
                                      newrec_.optional_code,
                                      newrec_.currency_rate,
                                      div_factor_,
                                      amount_method_);
      END IF;

   END IF;
END Check_Overwriting_Level___;


PROCEDURE Delete_Internal_Rows___ (
   company_         IN VARCHAR2,
   voucher_type_    IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_      IN NUMBER,
   account_         IN VARCHAR2,
   ref_row_no_      IN NUMBER )
IS
BEGIN
   $IF Component_Intled_SYS.INSTALLED $THEN
      DELETE
      FROM  Internal_Postings_Accrul_Tab
      WHERE company           = company_
      AND   voucher_type      = voucher_type_
      AND   accounting_year   = accounting_year_
      AND   voucher_no        = voucher_no_
      AND   account           = account_
      AND   ref_row_no        = ref_row_no_;
      Internal_Voucher_Util_Pub_API.Delete_Internal_Rows (company_,
                                                          voucher_type_,
                                                          accounting_year_,
                                                          voucher_no_,
                                                          account_,
                                                          ref_row_no_);
   $ELSE
      NULL;
   $END
END Delete_Internal_Rows___;


PROCEDURE Prepare_Tax_Transaction___ (
   newrec_               IN VOUCHER_ROW_TAB%ROWTYPE )
IS
   rowrec_               VOUCHER_ROW_TAB%ROWTYPE;
   taxrec_               VOUCHER_ROW_TAB%ROWTYPE;
   voucher_date_         DATE;
   tax_type_             VARCHAR2(200);
   trans_code_           VARCHAR2(100);
   tax_percent_          NUMBER;
   currency_rounding_    NUMBER;
   rounding_             NUMBER;
   next_row_group_id_    NUMBER;

   CURSOR get_next_row_group_id IS
      SELECT MAX(row_group_id) + 1
      FROM   VOUCHER_ROW_TAB
      WHERE  company         = rowrec_.company
      AND    voucher_type    = rowrec_.voucher_type
      AND    accounting_year = rowrec_.accounting_year
      AND    voucher_no      = rowrec_.voucher_no;
BEGIN
   rowrec_ := newrec_;
   IF (rowrec_.optional_code IS NOT NULL AND 
       (rowrec_.tax_amount IS NOT NULL OR rowrec_.parallel_curr_tax_amount IS NOT NULL)   AND
       Voucher_Type_API.Get_Voucher_Group(rowrec_.company, rowrec_.voucher_type) != 'Q') THEN
      IF (rowrec_.voucher_date IS NOT NULL) THEN
         voucher_date_ := rowrec_.voucher_date;
      ELSE
         voucher_date_ := Voucher_API.Get_Voucher_Date (rowrec_.company,
                                                        rowrec_.accounting_year,
                                                        rowrec_.voucher_type,
                                                        rowrec_.voucher_no);
      END IF;
      Statutory_Fee_API.Get_Fee_Type (tax_type_,
                                      rowrec_.company,
                                      rowrec_.optional_code,
                                      voucher_date_);

      IF (tax_type_ != 'NOTAX') THEN
         IF (tax_type_ IN ('VAT')) THEN
            IF (rowrec_.tax_direction IN ('TAXRECEIVED')) THEN
               trans_code_ := 'AP1';
               Create_Tax_Transaction___(taxrec_,
                                         rowrec_,
                                         trans_code_,
                                         voucher_date_);
            ELSIF (rowrec_.tax_direction IN ('TAXDISBURSED')) THEN
               trans_code_ := 'AP2';
               Create_Tax_Transaction___(taxrec_,
                                         rowrec_,
                                         trans_code_,
                                         voucher_date_);
            END IF;
         ELSIF (tax_type_ IN ('CALCVAT')) THEN
            IF (rowrec_.tax_direction IN ('TAXRECEIVED')) THEN
               -- Calculate the tax amounts for the caluculated tax
               tax_percent_ := Statutory_Fee_API.Get_Calculated_Percent(rowrec_.company,
                                                                        tax_type_,
                                                                        rowrec_.optional_code,
                                                                        voucher_date_);
               IF (tax_percent_ = 0) THEN
                  rowrec_.currency_tax_amount := 0;
                  rowrec_.tax_amount          := 0;
               ELSE
                  currency_rounding_ := Currency_Code_API.Get_Currency_Rounding(rowrec_.company, rowrec_.currency_code);
                  rounding_          := Currency_Code_API.Get_Currency_Rounding(rowrec_.company,
                                                                                Currency_Code_API.Get_Currency_Code(rowrec_.company));
                  -- The amount is always Net
                  tax_percent_       := tax_percent_ / 100;
                  -- round currency tax amount according to rounding method
                  IF (rowrec_.debet_amount IS NOT NULL) THEN
                     rowrec_.currency_tax_amount := Currency_Amount_API.Round_Amount(Company_Finance_API.Get_Tax_Rounding_Method_Db(rowrec_.company),
                                                                                     rowrec_.currency_debet_amount * tax_percent_,
                                                                                     currency_rounding_);
                     IF rowrec_.currency_code = Currency_Code_API.Get_Currency_Code(rowrec_.company) THEN
                        rowrec_.tax_amount := rowrec_.currency_tax_amount;
                     ELSE
                        rowrec_.tax_amount := ROUND((rowrec_.debet_amount * tax_percent_), rounding_);
                     END IF;
                  ELSIF (rowrec_.credit_amount IS NOT NULL) THEN
                     rowrec_.currency_tax_amount := -1 * Currency_Amount_API.Round_Amount(Company_Finance_API.Get_Tax_Rounding_Method_Db(rowrec_.company),
                                                                                        rowrec_.currency_credit_amount * tax_percent_,
                                                                                        currency_rounding_);

                     IF rowrec_.currency_code = Currency_Code_API.Get_Currency_Code(rowrec_.company) THEN
                        rowrec_.tax_amount := rowrec_.currency_tax_amount;
                     ELSE
                        rowrec_.tax_amount := -1*ROUND(((rowrec_.credit_amount * tax_percent_)), rounding_);
                     END IF;
                  END IF;
               END IF;
               trans_code_ := 'AP3';
               OPEN get_next_row_group_id;
               FETCH get_next_row_group_id INTO next_row_group_id_;
               CLOSE get_next_row_group_id;

               rowrec_.row_group_id := next_row_group_id_;
               Create_Tax_Transaction___(taxrec_,
                                         rowrec_,
                                         trans_code_,
                                         voucher_date_);
               -- Create the counter posting for AP3
               taxrec_.trans_code := 'AP4';
               Counter_Tax_Transaction___(taxrec_, voucher_date_,rowrec_);
            ELSIF (rowrec_.tax_direction IN ('TAXDISBURSED')) THEN
               -- The tax transaction for CALCVAT and TAXDISBURSED should use AP2 as trans code.
               -- One transaction with 0 in amounts should be created.
               trans_code_ := 'AP2';
               Create_Tax_Transaction___(taxrec_,
                                         rowrec_,
                                         trans_code_,
                                         voucher_date_);
            END IF;
         END IF;
      END IF;
      --Ncf_Create_Postings___ (rowrec_, voucher_date_ );     NOTE : This is only used by companies in Norway.
   END IF;
END Prepare_Tax_Transaction___;


PROCEDURE Create_Tax_Transaction___ (
   taxrec_               OUT VOUCHER_ROW_TAB%ROWTYPE,
   rowrec_               IN  VOUCHER_ROW_TAB%ROWTYPE,
   trans_code_           IN  VARCHAR2,
   voucher_date_         IN  DATE )
IS
   control_value_attr_   VARCHAR2(2000);
   codestring_rec_       Accounting_Codestr_API.CodestrRec;
   base_currency_code_   VARCHAR2(50);
   third_currency_code_  VARCHAR2(50);
   is_base_emu_          VARCHAR2(5);
   is_third_emu_         VARCHAR2(5);
   objid_                VARCHAR2(2000);
   objversion_           VARCHAR2(2000);
   attr_                 VARCHAR2(2000);
   parallel_base_        VARCHAR2(25);
BEGIN
   taxrec_.trans_code      := trans_code_;
   taxrec_.company         := rowrec_.company;
   taxrec_.accounting_year := rowrec_.accounting_year;
   taxrec_.voucher_no      := rowrec_.voucher_no;
   taxrec_.voucher_type    := rowrec_.voucher_type;
   Client_SYS.Clear_Attr(control_value_attr_);
   Client_SYS.Add_To_Attr( 'AC1', '*', control_value_attr_);
   Client_SYS.Add_To_Attr( 'AC7', rowrec_.optional_code, control_value_attr_);
   Client_SYS.Add_To_Attr( 'AC10', '*', control_value_attr_);
   Posting_Ctrl_Api.Posting_Event ( codestring_rec_,
                                    rowrec_.company,
                                    taxrec_.trans_code,
                                    voucher_date_,
                                    control_value_attr_ );
                                    
   Add_Preaccounting___(codestring_rec_, rowrec_);
   
   taxrec_.row_group_id := rowrec_.row_group_id;
   taxrec_.account      := codestring_rec_.code_a;
   taxrec_.code_b       := codestring_rec_.code_b;
   taxrec_.code_c       := codestring_rec_.code_c;
   taxrec_.code_d       := codestring_rec_.code_d;
   taxrec_.code_e       := codestring_rec_.code_e;
   taxrec_.code_f       := codestring_rec_.code_f;
   taxrec_.code_g       := codestring_rec_.code_g;
   taxrec_.code_h       := codestring_rec_.code_h;
   taxrec_.code_i       := codestring_rec_.code_i;
   taxrec_.code_j       := codestring_rec_.code_j;
   taxrec_.deliv_type_id:= rowrec_.deliv_type_id; 
   IF (rowrec_.tax_amount > 0) THEN
      IF (rowrec_.debet_amount IS NOT NULL) THEN
         taxrec_.currency_debet_amount  := ABS(rowrec_.currency_tax_amount);
         taxrec_.currency_credit_amount := NULL;
         taxrec_.debet_amount           := ABS(rowrec_.tax_amount);
         taxrec_.credit_amount := NULL;
      ELSIF (rowrec_.credit_amount IS NOT NULL) THEN   -- The correction flag in the client is checked
         taxrec_.currency_credit_amount := rowrec_.currency_tax_amount * -1;
         taxrec_.currency_debet_amount  := NULL;
         taxrec_.credit_amount          := rowrec_.tax_amount * -1;
         taxrec_.debet_amount           := NULL;
      END IF;
   ELSIF (rowrec_.tax_amount < 0) THEN
      IF (rowrec_.credit_amount IS NOT NULL) THEN
         taxrec_.currency_credit_amount := ABS(rowrec_.currency_tax_amount);
         taxrec_.currency_debet_amount  := NULL;
         taxrec_.credit_amount          := ABS(rowrec_.tax_amount);
         taxrec_.debet_amount           := NULL;
      ELSIF (rowrec_.debet_amount IS NOT NULL) THEN   -- The correction flag in the client is checked
         taxrec_.currency_debet_amount  := rowrec_.currency_tax_amount;
         taxrec_.currency_credit_amount := NULL;
         taxrec_.debet_amount           := rowrec_.tax_amount;
         taxrec_.credit_amount          := NULL;
      END IF;
   ELSIF (rowrec_.tax_amount = 0) THEN                -- IF tax amount is 0 (for tax code '0' and 'E0')
      IF (rowrec_.debet_amount IS NOT NULL) THEN
         taxrec_.currency_debet_amount  := rowrec_.currency_tax_amount;
         taxrec_.currency_credit_amount := NULL;
         taxrec_.debet_amount           := rowrec_.tax_amount;
         taxrec_.credit_amount          := NULL;
      ELSIF (rowrec_.credit_amount IS NOT NULL) THEN
         taxrec_.currency_credit_amount := rowrec_.currency_tax_amount;
         taxrec_.currency_debet_amount  := NULL;
         taxrec_.credit_amount          := rowrec_.tax_amount;
         taxrec_.debet_amount           := NULL;
      END IF;
   END IF;

   IF (rowrec_.tax_amount IS NULL AND rowrec_.parallel_curr_tax_amount IS NOT NULL) THEN
      IF (rowrec_.parallel_curr_tax_amount > 0) THEN
         taxrec_.third_currency_debit_amount  := ABS(rowrec_.parallel_curr_tax_amount);
         taxrec_.third_currency_credit_amount := NULL;
      ELSIF (rowrec_.parallel_curr_tax_amount < 0) THEN
         taxrec_.third_currency_credit_amount := ABS(rowrec_.parallel_curr_tax_amount);
         taxrec_.third_currency_debit_amount  := NULL;      
      END IF;  
   END IF;

   taxrec_.currency_tax_amount          := NULL;
   taxrec_.tax_amount                   := NULL;
   taxrec_.currency_gross_amount        := NULL;
   taxrec_.gross_amount                 := NULL;
   taxrec_.optional_code                := rowrec_.optional_code;
   IF (rowrec_.tax_amount > 0) THEN
      IF (rowrec_.debet_amount IS NOT NULL) THEN
         taxrec_.tax_base_amount          := rowrec_.debet_amount;
         taxrec_.currency_tax_base_amount := rowrec_.currency_debet_amount;
      ELSIF (rowrec_.credit_amount IS NOT NULL) THEN   -- The correction flag in the client is checked
         taxrec_.tax_base_amount          := -rowrec_.credit_amount;
         taxrec_.currency_tax_base_amount := -rowrec_.currency_credit_amount;
      END IF;
   ELSIF (rowrec_.tax_amount < 0) THEN
      IF (rowrec_.credit_amount IS NOT NULL) THEN
         taxrec_.tax_base_amount          := -rowrec_.credit_amount;
         taxrec_.currency_tax_base_amount := -rowrec_.currency_credit_amount;
      ELSIF (rowrec_.debet_amount IS NOT NULL) THEN   -- The correction flag in the client is checked
         taxrec_.tax_base_amount          := rowrec_.debet_amount;
         taxrec_.currency_tax_base_amount := rowrec_.currency_debet_amount;
      END IF;
   ELSIF (rowrec_.tax_amount = 0) THEN                -- IF tax amount is 0 (for tax code '0' and 'E0')
      taxrec_.tax_base_amount          := nvl(rowrec_.debet_amount, -rowrec_.credit_amount);
      taxrec_.currency_tax_base_amount := nvl(rowrec_.currency_debet_amount, -rowrec_.currency_credit_amount);
   END IF;
   third_currency_code_ := Company_Finance_Api.Get_Parallel_Acc_Currency (rowrec_.company, voucher_date_);
   IF (third_currency_code_ IS NOT NULL) THEN
      base_currency_code_  := Company_Finance_Api.Get_Currency_Code (rowrec_.company);
      is_base_emu_  := Currency_Code_Api.Get_Valid_Emu (rowrec_.company,
                                                        base_currency_code_,
                                                        voucher_date_);
      is_third_emu_ := Currency_Code_Api.Get_Valid_Emu (rowrec_.company,
                                                        third_currency_code_,
                                                        voucher_date_);
      parallel_base_ := Company_Finance_API.Get_Parallel_Base_Db(rowrec_.company);                                                        

      IF rowrec_.parallel_curr_tax_amount IS NULL THEN
         IF (taxrec_.debet_amount IS NOT NULL) THEN
            taxrec_.third_currency_debit_amount := Currency_Amount_API.Calculate_Parallel_Curr_Amount( rowrec_.company,
                                                             voucher_date_, 
                                                             taxrec_.debet_amount,
                                                             taxrec_.currency_debet_amount,
                                                             base_currency_code_,
                                                             rowrec_.currency_code,
                                                             rowrec_.parallel_curr_rate_type,
                                                             third_currency_code_,
                                                             parallel_base_,
                                                             is_base_emu_,
                                                             is_third_emu_);
         END IF;
         IF (taxrec_.credit_amount IS NOT NULL) THEN
            taxrec_.third_currency_credit_amount := Currency_Amount_API.Calculate_Parallel_Curr_Amount(rowrec_.company,
                                                             voucher_date_,
                                                             taxrec_.credit_amount,
                                                             taxrec_.currency_credit_amount,
                                                             base_currency_code_,
                                                             rowrec_.currency_code,                                                          
                                                             rowrec_.parallel_curr_rate_type,
                                                             third_currency_code_,
                                                             parallel_base_,
                                                             is_base_emu_,
                                                             is_third_emu_);
         END IF;
      ELSE
         -- Bug 129235, Begin.
         IF (rowrec_.tax_amount > 0) THEN
            IF (rowrec_.debet_amount IS NOT NULL) THEN
               taxrec_.third_currency_debit_amount  := ABS(rowrec_.parallel_curr_tax_amount);
               taxrec_.third_currency_credit_amount := NULL;
            ELSIF (rowrec_.credit_amount IS NOT NULL) THEN
               taxrec_.third_currency_credit_amount := -rowrec_.parallel_curr_tax_amount;
               taxrec_.third_currency_debit_amount  := NULL;
            END IF;
         ELSIF (rowrec_.tax_amount < 0) THEN
            IF (rowrec_.credit_amount IS NOT NULL) THEN
               taxrec_.third_currency_credit_amount := ABS(rowrec_.parallel_curr_tax_amount);
               taxrec_.third_currency_debit_amount  := NULL;
            ELSIF (rowrec_.debet_amount IS NOT NULL) THEN
               taxrec_.third_currency_debit_amount  := rowrec_.parallel_curr_tax_amount;
               taxrec_.third_currency_credit_amount := NULL;
            END IF;
         END IF;  
         -- Bug 129235, End.
      END IF;

      IF (rowrec_.tax_amount > 0) THEN
         IF (rowrec_.third_currency_debit_amount IS NOT NULL) THEN
            taxrec_.parallel_curr_tax_base_amount := rowrec_.third_currency_debit_amount;
         ELSIF (rowrec_.third_currency_credit_amount IS NOT NULL) THEN   -- The correction flag in the client is checked
            taxrec_.parallel_curr_tax_base_amount := -rowrec_.third_currency_credit_amount;
         END IF;
      ELSIF (rowrec_.tax_amount < 0) THEN
         IF (rowrec_.third_currency_credit_amount IS NOT NULL) THEN
            taxrec_.parallel_curr_tax_base_amount := -rowrec_.third_currency_credit_amount;
         ELSIF (rowrec_.third_currency_debit_amount IS NOT NULL) THEN   -- The correction flag in the client is checked
            taxrec_.parallel_curr_tax_base_amount := rowrec_.third_currency_debit_amount;
         END IF;
      ELSIF (rowrec_.tax_amount = 0) THEN                -- IF tax amount is 0 (for tax code '0' and 'E0')
         taxrec_.parallel_curr_tax_base_amount := nvl(rowrec_.third_currency_debit_amount, -rowrec_.third_currency_credit_amount);
      END IF;
   
      taxrec_.parallel_currency_rate     := rowrec_.parallel_currency_rate;
      taxrec_.parallel_conversion_factor := rowrec_.parallel_conversion_factor;
      taxrec_.parallel_curr_rate_type    := rowrec_.parallel_curr_rate_type;
   END IF;

   taxrec_.accounting_period   := rowrec_.accounting_period;
   taxrec_.currency_code       := rowrec_.currency_code;
   taxrec_.currency_rate       := rowrec_.currency_rate;
   taxrec_.conversion_factor   := rowrec_.conversion_factor;
   taxrec_.text                := rowrec_.text;
   taxrec_.corrected           := rowrec_.corrected;
   taxrec_.tax_direction       := rowrec_.tax_direction;
   taxrec_.auto_tax_vou_entry  := 'TRUE';
   taxrec_.reference_row_no    := rowrec_.row_no;
   taxrec_.reference_serie     := rowrec_.reference_serie;
   taxrec_.reference_number    := rowrec_.reference_number;
   taxrec_.transfer_id         := rowrec_.transfer_id;
   Error_SYS.Check_Not_Null(lu_name_, 'COMPANY', taxrec_.company);
   Error_SYS.Check_Not_Null(lu_name_, 'ACCOUNTING_YEAR', taxrec_.accounting_year);
   Error_SYS.Check_Not_Null(lu_name_, 'VOUCHER_TYPE', taxrec_.voucher_type);
   Error_SYS.Check_Not_Null(lu_name_, 'VOUCHER_NO', taxrec_.voucher_no);
   Error_SYS.Check_Not_Null(lu_name_, 'ACCOUNT', taxrec_.account);
   Error_SYS.Check_Not_Null(lu_name_, 'ACCOUNTING_PERIOD', taxrec_.accounting_period);
   taxrec_.rowkey := NULL;
   Insert___(objid_, objversion_, taxrec_, attr_);
   Internal_Manual_Postings___(taxrec_, TRUE);
END Create_Tax_Transaction___;


PROCEDURE Counter_Tax_Transaction___ (
   taxrec_               IN OUT VOUCHER_ROW_TAB%ROWTYPE,
   voucher_date_         IN DATE,
   rowrec_               IN VOUCHER_ROW_TAB%ROWTYPE)
IS
   control_value_attr_   VARCHAR2(2000);
   codestring_rec_       Accounting_Codestr_API.CodestrRec;
   objid_                VARCHAR2(2000);
   objversion_           VARCHAR2(2000);
   attr_                 VARCHAR2(2000);
BEGIN
   Client_SYS.Clear_Attr(control_value_attr_);
   Client_SYS.Add_To_Attr( 'AC1', '*', control_value_attr_);
   Client_SYS.Add_To_Attr( 'AC7', taxrec_.optional_code, control_value_attr_);
   Client_SYS.Add_To_Attr( 'AC10', '*', control_value_attr_);
   Posting_Ctrl_Api.Posting_Event ( codestring_rec_,
                                    taxrec_.company,
                                    taxrec_.trans_code,
                                    voucher_date_,
                                    control_value_attr_ );
                                    
   Add_Preaccounting___(codestring_rec_, rowrec_);
   
   taxrec_.account := codestring_rec_.code_a;
   taxrec_.code_b  := codestring_rec_.code_b;
   taxrec_.code_c  := codestring_rec_.code_c;
   taxrec_.code_d  := codestring_rec_.code_d;
   taxrec_.code_e  := codestring_rec_.code_e;
   taxrec_.code_f  := codestring_rec_.code_f;
   taxrec_.code_g  := codestring_rec_.code_g;
   taxrec_.code_h  := codestring_rec_.code_h;
   taxrec_.code_i  := codestring_rec_.code_i;
   taxrec_.code_j  := codestring_rec_.code_j;
   IF (taxrec_.debet_amount IS NOT NULL) THEN
      taxrec_.currency_credit_amount       := taxrec_.currency_debet_amount;
      taxrec_.currency_debet_amount        := NULL;
      taxrec_.credit_amount                := taxrec_.debet_amount;
      taxrec_.debet_amount                 := NULL;
      taxrec_.third_currency_credit_amount := taxrec_.third_currency_debit_amount;
      taxrec_.third_currency_debit_amount  := NULL;
   ELSIF (taxrec_.credit_amount IS NOT NULL) THEN
      taxrec_.currency_debet_amount        := taxrec_.currency_credit_amount;
      taxrec_.currency_credit_amount       := NULL;
      taxrec_.debet_amount                 := taxrec_.credit_amount;
      taxrec_.credit_amount                := NULL;
      taxrec_.third_currency_debit_amount  := taxrec_.third_currency_credit_amount;
      taxrec_.third_currency_credit_amount := NULL;
   END IF;
   taxrec_.tax_base_amount                 := taxrec_.tax_base_amount * -1;
   taxrec_.currency_tax_base_amount        := taxrec_.currency_tax_base_amount * -1;
   taxrec_.parallel_curr_tax_base_amount   := taxrec_.parallel_curr_tax_base_amount * -1;
   taxrec_.tax_direction                   := 'TAXDISBURSED';
   Error_SYS.Check_Not_Null(lu_name_, 'COMPANY', taxrec_.company);
   Error_SYS.Check_Not_Null(lu_name_, 'ACCOUNTING_YEAR', taxrec_.accounting_year);
   Error_SYS.Check_Not_Null(lu_name_, 'VOUCHER_TYPE', taxrec_.voucher_type);
   Error_SYS.Check_Not_Null(lu_name_, 'VOUCHER_NO', taxrec_.voucher_no);
   Error_SYS.Check_Not_Null(lu_name_, 'ACCOUNT', taxrec_.account);
   Error_SYS.Check_Not_Null(lu_name_, 'ACCOUNTING_PERIOD', taxrec_.accounting_period);
   taxrec_.rowkey := NULL;
   Insert___(objid_, objversion_, taxrec_, attr_);
   Internal_Manual_Postings___(taxrec_, TRUE);
END Counter_Tax_Transaction___;


PROCEDURE Delete_Tax_Transaction___ (
   remrec_   IN VOUCHER_ROW_TAB%ROWTYPE )
IS
   CURSOR get_data IS
      SELECT account, row_no
      FROM VOUCHER_ROW_TAB
      WHERE company           = remrec_.company
      AND   voucher_type      = remrec_.voucher_type
      AND   accounting_year   = remrec_.accounting_year
      AND   voucher_no        = remrec_.voucher_no
      AND   reference_row_no  = remrec_.row_no;

BEGIN
   IF (remrec_.optional_code IS NOT NULL AND remrec_.tax_amount IS NOT NULL) THEN
      FOR rec_ IN get_data LOOP
          Delete_Internal_Rows___(remrec_.company, remrec_.voucher_type, remrec_.accounting_year, remrec_.voucher_no, rec_.account, rec_.row_no);
      END LOOP;
      DELETE
      FROM  VOUCHER_ROW_TAB
      WHERE company           = remrec_.company
      AND   voucher_type      = remrec_.voucher_type
      AND   accounting_year   = remrec_.accounting_year
      AND   voucher_no        = remrec_.voucher_no
      AND   reference_row_no  = remrec_.row_no;
   END IF;
END Delete_Tax_Transaction___;


PROCEDURE Create_Object_Connection___ (
   newrec_ IN voucher_row_tab%ROWTYPE )
IS
   project_cost_element_            VARCHAR2(100);
   code_string_                     VARCHAR2(2000); 
   exclude_proj_followup_           VARCHAR2(5);
   followup_element_type_           VARCHAR2(20);
   used_amount_                     NUMBER;
   used_cost_amount_                NUMBER;
   posted_revenue_amount_           NUMBER;
   used_transaction_amount_         NUMBER;
   used_cost_transaction_amount_    NUMBER;
   posted_rev_transaction_amount_   NUMBER;
   transaction_currency_code_       VARCHAR2(3);
   $IF Component_Proj_SYS.INSTALLED $THEN
   activity_info_tab_               Project_Connection_Util_API.Activity_Info_Tab_Type;
   activity_revenue_info_tab_       Project_Connection_Util_API.Activity_Revenue_Info_Tab_Type;
   count_                           NUMBER;
   attributes_                      Project_Connection_Util_API.Attributes_Type;
   $END
BEGIN
   $IF Component_Proj_SYS.INSTALLED $THEN
      exclude_proj_followup_               := Account_API.Get_Exclude_Proj_Followup(newrec_.company, newrec_.account);
      IF (NVL(exclude_proj_followup_, 'FALSE') = 'FALSE') THEN      
         Get_Activity_Info (used_amount_, used_transaction_amount_, newrec_ );
         transaction_currency_code_        := newrec_.currency_code;
         --if transaction amount is zero replace it with base amount
         IF (used_transaction_amount_ = 0 AND used_amount_ != 0) THEN
            used_transaction_amount_       := used_amount_;  
            transaction_currency_code_     := Company_Finance_API.Get_Currency_Code(newrec_.company);
         END IF;
         -- Here we send client value of Voucher State as it does in other object connections
         -- eventhough it is not a good practice since decoding of server value is not supported
         -- by the PROJECT_CONNECTIONS_SUMMARY View in PROJ due to performance reasons.
         project_cost_element_             := Cost_Element_To_Account_API.Get_Project_Follow_Up_Element (newrec_.company, newrec_.account, newrec_.code_b, newrec_.code_c, newrec_.code_d,
                                                                                                         newrec_.code_e, newrec_.code_f, newrec_.code_g, newrec_.code_h, newrec_.code_i,
                                                                                                         newrec_.code_j, newrec_.voucher_date, 'TRUE');
         followup_element_type_            := Project_Cost_Element_API.Get_Element_Type_Db (newrec_.company,project_cost_element_);
         
         IF (followup_element_type_ = 'COST') THEN
            used_cost_amount_              := used_amount_;
            used_cost_transaction_amount_  := used_transaction_amount_;
         ELSE
            posted_revenue_amount_         := -used_amount_;
            posted_rev_transaction_amount_ := -used_transaction_amount_;
         END IF;      
         code_string_                      := Get_Codestring__(newrec_.company, newrec_.voucher_type, newrec_.accounting_year, newrec_.voucher_no, newrec_.row_no);
            
         count_                                                       := activity_info_tab_.COUNT;
         activity_info_tab_(count_).control_category                  := project_cost_element_;
         activity_info_tab_(count_).used                              := used_cost_amount_;
         activity_info_tab_(count_).used_transaction                  := used_cost_transaction_amount_;
         activity_info_tab_(count_).transaction_currency_code         := transaction_currency_code_;
         activity_revenue_info_tab_(count_).control_category          := project_cost_element_;
         activity_revenue_info_tab_(count_).posted_revenue            := posted_revenue_amount_;
         activity_revenue_info_tab_(count_).posted_transaction        := posted_rev_transaction_amount_;
         activity_revenue_info_tab_(count_).transaction_currency_code := transaction_currency_code_;
         count_                                                       := count_ + 1;
         attributes_.codestring                                       := code_string_;
         attributes_.last_transaction_date                            := newrec_.voucher_date;

         Project_Connection_Util_API.Create_Connection (proj_lu_name_              => 'VR',
                                                        activity_seq_              => newrec_.project_activity_id,
                                                        system_ctrl_conn_          => 'TRUE',
                                                        keyref1_                   => newrec_.company,
                                                        keyref2_                   => newrec_.voucher_type,
                                                        keyref3_                   => newrec_.accounting_year,
                                                        keyref4_                   => newrec_.voucher_no,
                                                        keyref5_                   => newrec_.row_no,
                                                        keyref6_                   => '*',
                                                        object_description_        => 'VoucherRow',
                                                        activity_info_tab_         => activity_info_tab_,
                                                        activity_revenue_info_tab_ => activity_revenue_info_tab_,
                                                        attributes_                => attributes_);
      END IF;
   $ELSE
      NULL;
   $END
END Create_Object_Connection___;


PROCEDURE Remove_Object_Connection___ (
   remrec_              IN voucher_row_tab%ROWTYPE )
IS
   vourow_exists_          BOOLEAN         := FALSE;
   exclude_proj_followup_  VARCHAR2(5);  
   vourowrec_              voucher_row_tab%ROWTYPE;   
BEGIN
   IF (remrec_.account IS NULL)  THEN
      vourowrec_          := Get_Object_By_Keys___ (remrec_.company,remrec_.voucher_type,remrec_.accounting_year,remrec_.voucher_no,remrec_.row_no);
   ELSE
      vourowrec_.account  := remrec_.account;
   END IF;   
   vourow_exists_         := Check_Exist___ (remrec_.company, remrec_.voucher_type, remrec_.accounting_year, remrec_.voucher_no, remrec_.row_no );
   exclude_proj_followup_ := NVL(Account_API.Get_Exclude_Proj_Followup(remrec_.company, vourowrec_.account), 'FALSE');   
   $IF (Component_Proj_SYS.INSTALLED) $THEN
      IF (vourow_exists_ AND exclude_proj_followup_= 'FALSE') THEN  
         Project_Connection_Util_API.Remove_Connection (proj_lu_name_     => 'VR',
                                                        activity_seq_     => remrec_.project_activity_id,
                                                        keyref1_          => remrec_.company,
                                                        keyref2_          => remrec_.voucher_type,
                                                        keyref3_          => remrec_.accounting_year,
                                                        keyref4_          => remrec_.voucher_no,
                                                        keyref5_          => remrec_.row_no,
                                                        keyref6_          => '*');
      END IF;
   $END
END Remove_Object_Connection___;

   
FUNCTION Check_Int_Vou_Row___ (
   rec_  IN Internal_Postings_Accrul_Tab%ROWTYPE) RETURN BOOLEAN
IS
   posting_combination_id_ NUMBER;
   exist_                  VARCHAR2(5);
BEGIN
   $IF Component_Genled_SYS.INSTALLED $THEN
      Posting_Combination_API.Get_Combination(posting_combination_id_,
                                              rec_.account,
                                              rec_.code_b,
                                              rec_.code_c,
                                              rec_.code_d,
                                              rec_.code_e,
                                              rec_.code_f,
                                              rec_.code_g,
                                              rec_.code_h,
                                              rec_.code_i,
                                              rec_.code_j); 
   $END
   $IF Component_Intled_SYS.INSTALLED $THEN
      exist_ := Internal_Hold_Voucher_Row_API.Check_Combination(rec_.company,
                                                                rec_.ledger_id,                 
                                                                rec_.voucher_type,
                                                                rec_.accounting_year,
                                                                rec_.voucher_no,
                                                                rec_.ref_row_no,
                                                                posting_combination_id_);                                         
   $ELSE
      exist_ := NULL;
   $END

   IF (exist_ = 'TRUE') THEN
      RETURN TRUE;
   ELSE
      RETURN FALSE;
   END IF;                                                              
END Check_Int_Vou_Row___;


FUNCTION Obj_Conn_Refresh_Req___ (
   oldrec_     IN VOUCHER_ROW_TAB%ROWTYPE,
   newrec_     IN VOUCHER_ROW_TAB%ROWTYPE) RETURN BOOLEAN
IS
BEGIN
   IF ( ( NVL(oldrec_.debet_amount,0) != NVL(newrec_.debet_amount,0) ) OR ( NVL(oldrec_.credit_amount,0) != NVL(newrec_.credit_amount,0) ) OR ( oldrec_.account != newrec_.account ) 
     OR ( NVL(oldrec_.code_b,CHR(0)) != NVL(newrec_.code_b,CHR(0))) 
     OR ( NVL(oldrec_.code_c,CHR(0)) != NVL(newrec_.code_c,CHR(0))) OR (NVL(oldrec_.code_d,CHR(0)) != NVL(newrec_.code_d,CHR(0))) 
     OR ( NVL(oldrec_.code_e,CHR(0)) != NVL(newrec_.code_e,CHR(0))) OR (NVL(oldrec_.code_f,CHR(0)) != NVL(newrec_.code_f,CHR(0)))
     OR ( NVL(oldrec_.code_g,CHR(0)) != NVL(newrec_.code_g,CHR(0))) OR (NVL(oldrec_.code_h,CHR(0)) != NVL(newrec_.code_h,CHR(0))) 
     OR ( NVL(oldrec_.code_i,CHR(0)) != NVL(newrec_.code_i,CHR(0))) OR (NVL(oldrec_.code_j,CHR(0)) != NVL(newrec_.code_j,CHR(0)))
     OR ( oldrec_.voucher_date != newrec_.voucher_date) ) THEN
      RETURN TRUE;
   ELSE
      RETURN FALSE;
   END IF;
END Obj_Conn_Refresh_Req___;


PROCEDURE Create_Cancel_Row___ (
   row_rec_     IN OUT VOUCHER_ROW_TAB%ROWTYPE )
IS
   
   objid_      voucher_row.objid%TYPE;
   objversion_ voucher_row.objversion%TYPE;
   attr_       VARCHAR2(2000);
   indrec_     Indicator_Rec;
BEGIN
   IF (row_rec_.trans_code NOT IN ('CANCELLATION-AP1','CANCELLATION-AP2','CANCELLATION-AP3','CANCELLATION-AP4','CANCELLATION-GP3', 'CANCELLATION-GP4', 'CANCELLATION-GP5','CANCELLATION-Project')) THEN
      indrec_ := Get_Indicator_Rec___(row_rec_);
      Check_Insert___(row_rec_, indrec_, attr_);
   END IF;   
   row_rec_.rowkey := NULL;
   Insert___(objid_, objversion_, row_rec_, attr_);
   IF NOT (row_rec_.trans_code IN ('CANCELLATION-GP2','CANCELLATION-AUTOMATIC','CANCELLATION-GP3', 'CANCELLATION-GP4', 'CANCELLATION-GP5','CANCELLATION-Project')) THEN
      Internal_Manual_Postings___(row_rec_);
   END IF;
END Create_Cancel_Row___;


FUNCTION Get_Codestring___ (
   voucher_row_        IN VOUCHER_ROW_TAB%ROWTYPE) RETURN VARCHAR2
IS
   codestring_     VARCHAR2(2000);
   tmp_codestring_ VARCHAR2(2000);
   proj_code_part_ VARCHAR2(10);
BEGIN
   proj_code_part_ := Accounting_Code_Parts_API.Get_Codepart_Function_Db(voucher_row_.company, 'PRACC');
   
   Client_SYS.Add_To_Attr('ACCOUNT', voucher_row_.account,  tmp_codestring_);

   IF proj_code_part_ = 'B' THEN
      Client_SYS.Add_To_Attr('CODE_B', '',      tmp_codestring_);
   ELSE
      Client_SYS.Add_To_Attr('CODE_B', voucher_row_.code_b, tmp_codestring_);
   END IF;

   IF proj_code_part_ = 'C' THEN
      Client_SYS.Add_To_Attr('CODE_C', '',      tmp_codestring_);
   ELSE
      Client_SYS.Add_To_Attr('CODE_C', voucher_row_.code_c, tmp_codestring_);
   END IF;

   IF proj_code_part_ = 'D' THEN
      Client_SYS.Add_To_Attr('CODE_D', '',      tmp_codestring_);
   ELSE
      Client_SYS.Add_To_Attr('CODE_D', voucher_row_.code_d, tmp_codestring_);
   END IF;

   IF proj_code_part_ = 'E' THEN
      Client_SYS.Add_To_Attr('CODE_E', '',      tmp_codestring_);
   ELSE
      Client_SYS.Add_To_Attr('CODE_E', voucher_row_.code_e, tmp_codestring_);
   END IF;

   IF proj_code_part_ = 'F' THEN
      Client_SYS.Add_To_Attr('CODE_F', '',      tmp_codestring_);
   ELSE
      Client_SYS.Add_To_Attr('CODE_F', voucher_row_.code_f, tmp_codestring_);
   END IF;

   IF proj_code_part_ = 'G' THEN
      Client_SYS.Add_To_Attr('CODE_G', '',      tmp_codestring_);
   ELSE
      Client_SYS.Add_To_Attr('CODE_G', voucher_row_.code_g, tmp_codestring_);
   END IF;

   IF proj_code_part_ = 'H' THEN
      Client_SYS.Add_To_Attr('CODE_H', '',      tmp_codestring_);
   ELSE
      Client_SYS.Add_To_Attr('CODE_H', voucher_row_.code_h, tmp_codestring_);
   END IF;

   IF proj_code_part_ = 'I' THEN
      Client_SYS.Add_To_Attr('CODE_I', '',      tmp_codestring_);
   ELSE
      Client_SYS.Add_To_Attr('CODE_I', voucher_row_.code_i, tmp_codestring_);
   END IF;

   IF proj_code_part_ = 'J' THEN
      Client_SYS.Add_To_Attr('CODE_J', '',      tmp_codestring_);
   ELSE
      Client_SYS.Add_To_Attr('CODE_J', voucher_row_.code_j, tmp_codestring_);
   END IF;

   codestring_ := tmp_codestring_;
   
   RETURN codestring_;
END Get_Codestring___;

   
PROCEDURE Add_Preaccounting___ (
   codestring_rec_            IN OUT NOCOPY Accounting_Codestr_API.CodestrRec,
   vourow_codestr_rec_        IN            VOUCHER_ROW_TAB%ROWTYPE)
IS
BEGIN
   
   IF codestring_rec_.code_b = CHR(0) THEN
      codestring_rec_.code_b := vourow_codestr_rec_.code_b;
   END IF;
   IF codestring_rec_.code_c = CHR(0) THEN
      codestring_rec_.code_c := vourow_codestr_rec_.code_c;
   END IF;
   IF codestring_rec_.code_d = CHR(0) THEN
      codestring_rec_.code_d := vourow_codestr_rec_.code_d;
   END IF;
   IF codestring_rec_.code_e = CHR(0) THEN
      codestring_rec_.code_e := vourow_codestr_rec_.code_e;
   END IF;
   IF codestring_rec_.code_f = CHR(0) THEN
      codestring_rec_.code_f := vourow_codestr_rec_.code_f;
   END IF;
   IF codestring_rec_.code_g = CHR(0) THEN
      codestring_rec_.code_g := vourow_codestr_rec_.code_g;
   END IF;
   IF codestring_rec_.code_h = CHR(0) THEN
      codestring_rec_.code_h := vourow_codestr_rec_.code_h;
   END IF;
   IF codestring_rec_.code_i = CHR(0) THEN
      codestring_rec_.code_i := vourow_codestr_rec_.code_i;
   END IF;
   IF codestring_rec_.code_j = CHR(0) THEN
      codestring_rec_.code_j := vourow_codestr_rec_.code_j;
   END IF;
END Add_Preaccounting___;


PROCEDURE Create_Add_Investment_Info___ (
  newrec_        IN   VOUCHER_ROW_TAB%ROWTYPE)
IS
  add_investment_attr_ VARCHAR2(3000);
  voucher_date_        DATE;
  amount_              NUMBER;
  third_amount_        NUMBER;
  transaction_reason_  VARCHAR2(20);
BEGIN
   $IF Component_Fixass_SYS.INSTALLED $THEN
   -- Bug 111757, Begin - Exclude Voucher Type Q
      IF ( Voucher_API.Get_Function_Group( 
                          newrec_.company, 
                          newrec_.accounting_year, 
                          newrec_.voucher_type, 
                          newrec_.voucher_no ) NOT IN ('Q') )THEN
   
         IF (ABS(newrec_.debet_amount)>0) THEN
            amount_         := newrec_.debet_amount;
            third_amount_   := newrec_.third_currency_debit_amount;
         ELSE
            amount_         := -(newrec_.credit_amount);
            third_amount_   := -(newrec_.third_currency_credit_amount);
         END IF;

         voucher_date_      := Voucher_Api.Get_Voucher_Date (newrec_.company,
                                                             newrec_.accounting_year,
                                                             newrec_.voucher_type,
                                                             newrec_.voucher_no);
         Client_SYS.Clear_Attr(add_investment_attr_);
         Client_Sys.Add_To_Attr( 'COMPANY', newrec_.company, add_investment_attr_ );
         Client_Sys.Add_To_Attr( 'SOURCE_REF', 'VOUCHER', add_investment_attr_ );
         Client_Sys.Add_To_Attr( 'KEYREF1', newrec_.voucher_no, add_investment_attr_ );
         Client_Sys.Add_To_Attr( 'KEYREF2', newrec_.voucher_type, add_investment_attr_ );
         Client_Sys.Add_To_Attr( 'KEYREF3', newrec_.accounting_year, add_investment_attr_ );
         Client_Sys.Add_To_Attr( 'KEYREF4', newrec_.row_no, add_investment_attr_ );
         Client_Sys.Add_To_Attr( 'KEYREF5', '*', add_investment_attr_ );
         Client_Sys.Add_To_Attr( 'OBJECT_ID', newrec_.object_id, add_investment_attr_ );
         Client_Sys.Add_To_Attr( 'EVENT_DATE', voucher_date_, add_investment_attr_ );
         Client_Sys.Add_To_Attr( 'RETROACTIVE_DATE', voucher_date_, add_investment_attr_ );
         Client_Sys.Add_To_Attr( 'ACQ_ACCOUNT', newrec_.account, add_investment_attr_ );
         Client_Sys.Add_To_Attr( 'AMOUNT', amount_, add_investment_attr_ );
         Client_Sys.Add_To_Attr( 'THIRD_AMOUNT', third_amount_, add_investment_attr_ );
         IF (newrec_.trans_code = 'FA CASH DISCOUNT') THEN
            transaction_reason_ := Fa_Company_API.Get_Transaction_Reason(newrec_.company);
            IF (transaction_reason_ IS NULL) THEN
               Error_SYS.Record_General(lu_name_, 'NOFATRANSRSN: Transaction Reason for Cash Discount is not defined in company :P1', newrec_.company);
            END IF;
            Client_Sys.Add_To_Attr( 'ACQUISITION_REASON', transaction_reason_, add_investment_attr_ );
         END IF;
         Add_Investment_Info_Api.New_Item(add_investment_attr_, 'DO');
      END IF;
   -- Bug 111757, End
  $ELSE
     NULL;
  $END
END Create_Add_Investment_Info___;


PROCEDURE Re_Create_Mod_Add_Inv_Info___ (
  newrec_          IN     VOUCHER_ROW_TAB%ROWTYPE)
IS
  curr_object_id_      VARCHAR2(10);
  add_investment_attr_ VARCHAR2(3000);
  voucher_date_        DATE;
  amount_              NUMBER;
  third_amount_        NUMBER;
BEGIN
   $IF Component_Fixass_SYS.INSTALLED $THEN
      -- Bug 111757, begin - Exclude Voucher Type Q
      IF ( Voucher_API.Get_Function_Group( 
                          newrec_.company, 
                          newrec_.accounting_year, 
                          newrec_.voucher_type, 
                          newrec_.voucher_no ) NOT IN ( 'Q') )THEN

         Client_Sys.Clear_Attr(add_investment_attr_);
         Client_Sys.Add_To_Attr( 'SOURCE_REF', 'VOUCHER', add_investment_attr_ );
         Client_Sys.Add_To_Attr( 'COMPANY', newrec_.company, add_investment_attr_ );
         Client_Sys.Add_To_Attr( 'KEYREF1', newrec_.voucher_no, add_investment_attr_ );
         Client_Sys.Add_To_Attr( 'KEYREF2', newrec_.voucher_type, add_investment_attr_ );
         Client_Sys.Add_To_Attr( 'KEYREF3', newrec_.accounting_year, add_investment_attr_ );
         Client_Sys.Add_To_Attr( 'KEYREF4', newrec_.row_no, add_investment_attr_ );
         Client_Sys.Add_To_Attr( 'KEYREF5', '*', add_investment_attr_ );
         Client_Sys.Add_To_Attr( 'ACQ_ACCOUNT', newrec_.account, add_investment_attr_ );
         Client_Sys.Add_To_Attr( 'OBJECT_ID', newrec_.object_id, add_investment_attr_ );
         curr_object_id_ := Add_Investment_Info_Api.Get_Object_Id('VOUCHER',
                                                                   newrec_.company,
                                                                   newrec_.voucher_no, 
                                                                   newrec_.voucher_type, 
                                                                   newrec_.accounting_year,
                                                                   newrec_.row_no,
                                                                   '*');
         IF (ABS(newrec_.debet_amount)>0) THEN
            amount_         := newrec_.debet_amount;
            third_amount_   := newrec_.third_currency_debit_amount;
         ELSE
            amount_         := -(newrec_.credit_amount);
            third_amount_   := -(newrec_.third_currency_credit_amount);
         END IF;

         voucher_date_      := Voucher_Api.Get_Voucher_Date (newrec_.company,
                                                           newrec_.accounting_year,
                                                           newrec_.voucher_type,
                                                           newrec_.voucher_no);        
         --If the FA Object connected to the posting line has been changed, remove and re-create add investment information 
         IF ((newrec_.object_id IS NOT NULL AND curr_object_id_ IS NULL) OR (curr_object_id_ != newrec_.object_id)) THEN
           IF curr_object_id_ IS NOT NULL THEN
              Client_Sys.Set_Item_Value( 'OBJECT_ID', curr_object_id_, add_investment_attr_ );
              Add_Investment_Info_Api.Remove_Item(add_investment_attr_, 'DO');
           END IF;
           Client_Sys.Set_Item_Value( 'OBJECT_ID', newrec_.object_id, add_investment_attr_ );
           Client_Sys.Add_To_Attr( 'EVENT_DATE', voucher_date_, add_investment_attr_ );
           Client_Sys.Add_To_Attr( 'RETROACTIVE_DATE', voucher_date_, add_investment_attr_ );
           Client_Sys.Add_To_Attr( 'ACQ_ACCOUNT', newrec_.account, add_investment_attr_ );
           Client_Sys.Add_To_Attr( 'AMOUNT', amount_, add_investment_attr_ );
           Client_Sys.Add_To_Attr( 'THIRD_AMOUNT', third_amount_, add_investment_attr_ );
           Add_Investment_Info_Api.New_Item(add_investment_attr_,'DO');
         ELSE
           --FA Object connected to the  line has not been changed, just update the amount for the existing object
           Client_Sys.Add_To_Attr( 'EVENT_DATE', voucher_date_, add_investment_attr_ );
           Client_Sys.Add_To_Attr( 'RETROACTIVE_DATE', voucher_date_, add_investment_attr_ );
           Client_Sys.Add_To_Attr( 'AMOUNT', amount_, add_investment_attr_ );
           Client_Sys.Add_To_Attr( 'THIRD_AMOUNT', third_amount_, add_investment_attr_ );
           Add_Investment_Info_Api.Modify_Item(add_investment_attr_, 'DO'); 
         END IF;
      END IF;
   -- Bug 111757, End
   $ELSE
      NULL;
   $END
END Re_Create_Mod_Add_Inv_Info___;


PROCEDURE Remove_Add_Investment_Info___ (
   remrec_          IN     VOUCHER_ROW_TAB%ROWTYPE)
IS 
   add_investment_attr_ VARCHAR2(3000);
BEGIN
   $IF Component_Fixass_SYS.INSTALLED $THEN
      Client_Sys.Add_To_Attr( 'SOURCE_REF', 'VOUCHER', add_investment_attr_ );
      Client_Sys.Add_To_Attr( 'COMPANY', remrec_.company, add_investment_attr_ );
      Client_Sys.Add_To_Attr( 'KEYREF1', remrec_.voucher_no, add_investment_attr_ );
      Client_Sys.Add_To_Attr( 'KEYREF2', remrec_.voucher_type, add_investment_attr_ );
      Client_Sys.Add_To_Attr( 'KEYREF3', remrec_.accounting_year, add_investment_attr_ );
      Client_Sys.Add_To_Attr( 'KEYREF4', remrec_.row_no, add_investment_attr_ );
      Client_Sys.Add_To_Attr( 'KEYREF5', '*', add_investment_attr_ );
      Client_Sys.Add_To_Attr( 'OBJECT_ID', remrec_.object_id, add_investment_attr_ );

      Add_Investment_Info_Api.Remove_Item(add_investment_attr_, 'DO');
   $ELSE
      NULL;
   $END
END Remove_Add_Investment_Info___;


-- Check_Add_Par_Curr_Data___
--   Method that check that parallel currency fields are set (amount, rate and conversion factor).
--   If not set it will be set in the method.
PROCEDURE Check_Add_Par_Curr_Data___(
   newrec_        IN OUT NOCOPY VOUCHER_ROW_TAB%ROWTYPE,
   compfin_rec_   IN OUT NOCOPY Company_Finance_API.Public_Rec)
IS
   inverted_rate_                VARCHAR2(5);
   amount_                       NUMBER;
   currency_amount_              NUMBER;
   parallel_curr_amount_         NUMBER;
   is_debit_amount_              BOOLEAN := FALSE;
BEGIN
   IF (compfin_rec_.parallel_acc_currency IS NOT NULL) THEN
      IF (newrec_.parallel_curr_rate_type IS NULL) THEN
         newrec_.parallel_curr_rate_type := compfin_rec_.parallel_rate_type;
      END IF;
      -- set some temporary amount variables 
      IF (newrec_.debet_amount IS NOT NULL) THEN
         amount_ := newrec_.debet_amount;
      ELSE
         amount_ := newrec_.credit_amount;
      END IF;

      IF (newrec_.currency_debet_amount IS NOT NULL) THEN
         currency_amount_ := newrec_.currency_debet_amount;
         is_debit_amount_ := TRUE;
      ELSE
         currency_amount_ := newrec_.currency_credit_amount;
         is_debit_amount_ := FALSE;
      END IF;

      IF ((newrec_.third_currency_debit_amount IS NULL) AND (newrec_.third_currency_credit_amount IS NULL)) THEN
         -- parallel currency amount is not given then assume that rate and conversion factor is not given either. Then fetch rate and 
         -- conversion factor and calculate parallel amount
         Currency_Rate_API.Get_Parallel_Currency_Rate(newrec_.parallel_currency_rate,
                                                      newrec_.parallel_conversion_factor,
                                                      inverted_rate_,
                                                      newrec_.company,
                                                      newrec_.currency_code,
                                                      newrec_.voucher_date,
                                                      newrec_.parallel_curr_rate_type,
                                                      compfin_rec_.parallel_base,
                                                      compfin_rec_.currency_code,
                                                      compfin_rec_.parallel_acc_currency,
                                                      NULL,
                                                      NULL); 

         parallel_curr_amount_ := Currency_Amount_API.Calc_Parallel_Curr_Amt_Round(newrec_.company,
                                                                                   newrec_.voucher_date,
                                                                                   amount_,
                                                                                   currency_amount_,
                                                                                   compfin_rec_.currency_code,
                                                                                   newrec_.currency_code,
                                                                                   newrec_.parallel_curr_rate_type,
                                                                                   compfin_rec_.parallel_acc_currency,
                                                                                   compfin_rec_.parallel_base,
                                                                                   NULL,
                                                                                   NULL);
         IF (is_debit_amount_) THEN
            newrec_.third_currency_debit_amount := parallel_curr_amount_;
         ELSE
            newrec_.third_currency_credit_amount := parallel_curr_amount_;
         END IF;
      ELSE
         -- IF rate if null then assume that conversion factor is also null. Then calculate rate and fetch conversion factor.
         IF (newrec_.parallel_currency_rate IS NULL) THEN
            IF (is_debit_amount_) THEN
               parallel_curr_amount_ := newrec_.third_currency_debit_amount;
            ELSE
               parallel_curr_amount_ := newrec_.third_currency_credit_amount;
            END IF;
            newrec_.parallel_currency_rate := Currency_Amount_API.Calculate_Parallel_Curr_Rate(newrec_.company,
                                                                                               newrec_.voucher_date,
                                                                                               amount_,
                                                                                               currency_amount_,
                                                                                               parallel_curr_amount_,
                                                                                               compfin_rec_.currency_code,
                                                                                               newrec_.currency_code,
                                                                                               compfin_rec_.parallel_acc_currency,
                                                                                               compfin_rec_.parallel_base,
                                                                                               newrec_.parallel_curr_rate_type);
         END IF;
         IF (newrec_.parallel_conversion_factor IS NULL) THEN
            newrec_.parallel_conversion_factor := Currency_Rate_API.Get_Par_Curr_Rate_Conv_Factor(newrec_.company,
                                                                                                  newrec_.currency_code,
                                                                                                  newrec_.voucher_date,
                                                                                                  compfin_rec_.currency_code,
                                                                                                  compfin_rec_.parallel_acc_currency,
                                                                                                  compfin_rec_.parallel_base,
                                                                                                  newrec_.parallel_curr_rate_type);
         END IF;
      END IF;
   ELSE
      -- if parallel currency is not used then set amounts to null
      newrec_.third_currency_debit_amount := NULL;
      newrec_.third_currency_credit_amount := NULL;
   END IF;
END Check_Add_Par_Curr_Data___;


@Override
PROCEDURE Prepare_Insert___ (
   attr_  IN OUT VARCHAR2 )
IS
BEGIN
   super(attr_);
   Client_SYS.Add_To_Attr('TRANS_CODE', 'MANUAL', attr_);
END Prepare_Insert___;

@Override
PROCEDURE Check_Common___ (
   oldrec_ IN     voucher_row_tab%ROWTYPE,
   newrec_ IN OUT voucher_row_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS
BEGIN   
   super(oldrec_, newrec_, indrec_, attr_);
   IF (newrec_.parallel_curr_rate_type IS NOT NULL) THEN
      Currency_Rate_API.Check_If_Curr_Code_Exists( newrec_.company, newrec_.parallel_curr_rate_type, newrec_.currency_code);
   END IF;
END Check_Common___;

@Override
PROCEDURE Insert___ (
   objid_                OUT    VARCHAR2,
   objversion_           OUT    VARCHAR2,
   newrec_               IN OUT VOUCHER_ROW_TAB%ROWTYPE,
   attr_                 IN OUT VARCHAR2 )
IS
   create_project_conn_          VARCHAR2(5);
   base_curr_                    VARCHAR2(3);
   third_curr_                   VARCHAR2(3);
   rounded_                      VARCHAR2(5);
   voucher_date_                 DATE;
   base_curr_rounding_           NUMBER;
   trans_curr_rounding_          NUMBER;
   third_curr_rounding_          NUMBER;
   codestring_rec_               Accounting_codestr_API.CodestrRec;
   project_code_part_            VARCHAR2(1);
   object_code_part_             VARCHAR2(1);
   amount_to_allocate_           NUMBER;
   allocation_error_             VARCHAR2(2000);
   compfin_rec_                  Company_Finance_API.Public_Rec;
   -- Bug 104100, Removed cursor next_row
BEGIN
   create_project_conn_ := NVL(Client_SYS.Get_Item_Value('CREATE_PROJ_CONN', attr_), 'TRUE');
   -- Bug 104100, OPEN FETCH CLOSE related to cursor next_row
   -- Bug 104100, Begin
   newrec_.row_no                 := Voucher_API.Get_Next_Row_Number( newrec_.company,
                                                               newrec_.voucher_type,
                                                               newrec_.accounting_year,
                                                               newrec_.voucher_no );
   -- Bug 104100, End


   
   IF Account_API.Is_Budget_Account(newrec_.company, newrec_.account) THEN
      Error_SYS.Record_General(lu_name_, 'BUDACCONLY: Account :P1 is only allowed for budget.',newrec_.account);
   END IF;
   -- Removed gets of curr_rounding (only performed when rounded != TRUE)
   rounded_ := Client_SYS.Get_Item_Value ( 'ROUNDED', attr_ );
   IF (nvl(rounded_,'FALSE') != 'TRUE') THEN
      IF (newrec_.voucher_date IS NOT NULL) THEN
         voucher_date_        := newrec_.voucher_date;
      ELSE
         voucher_date_        := Voucher_API.Get_Voucher_Date (newrec_.company,
                                                               newrec_.accounting_year,
                                                               newrec_.voucher_type,
                                                               newrec_.voucher_no);
         newrec_.voucher_date := voucher_date_;
      END IF;
      base_curr_           := Currency_Code_API.Get_Currency_Code (newrec_.company);
      third_curr_          := Company_Finance_API.Get_Parallel_Acc_Currency(newrec_.company, voucher_date_);
      base_curr_rounding_  := Currency_Code_API.Get_Currency_Rounding (newrec_.company, base_curr_);
      IF (newrec_.currency_code = base_curr_) THEN
         trans_curr_rounding_ := base_curr_rounding_;
      ELSE
         trans_curr_rounding_ := Currency_Code_API.Get_Currency_Rounding (newrec_.company, newrec_.currency_code);
      END IF;
      IF (third_curr_ IS NOT NULL) THEN
         IF (third_curr_ = base_curr_) THEN
            third_curr_rounding_ := base_curr_rounding_;
         ELSIF (third_curr_ = newrec_.currency_code) THEN
            third_curr_rounding_ := trans_curr_rounding_;
         ELSE
            third_curr_rounding_ := Currency_Code_API.Get_Currency_Rounding (newrec_.company, third_curr_);
         END IF;
      END IF;
      newrec_.credit_amount                := ROUND(newrec_.credit_amount, base_curr_rounding_);
      newrec_.debet_amount                 := ROUND(newrec_.debet_amount, base_curr_rounding_);
      newrec_.currency_credit_amount       := ROUND(newrec_.currency_credit_amount, trans_curr_rounding_);
      newrec_.currency_debet_amount        := ROUND(newrec_.currency_debet_amount, trans_curr_rounding_);
      IF (third_curr_ IS NOT NULL) THEN
         IF (newrec_.third_currency_debit_amount <> 0) THEN
            newrec_.third_currency_debit_amount  := ROUND(newrec_.third_currency_debit_amount, third_curr_rounding_);
         END IF;
         IF (newrec_.third_currency_credit_amount <> 0) THEN
            newrec_.third_currency_credit_amount := ROUND(newrec_.third_currency_credit_amount, third_curr_rounding_);
         END IF;
      ELSE
         -- if parallel currency is not used then set amounts to null
         newrec_.third_currency_debit_amount := NULL;
         newrec_.third_currency_credit_amount := NULL;
      END IF;
      newrec_.tax_amount                   := ROUND(newrec_.tax_amount, base_curr_rounding_);
      newrec_.currency_tax_amount          := ROUND(newrec_.currency_tax_amount, trans_curr_rounding_);
      newrec_.gross_amount                 := ROUND(newrec_.gross_amount, base_curr_rounding_);
      newrec_.currency_gross_amount        := ROUND(newrec_.currency_gross_amount, trans_curr_rounding_);
      newrec_.tax_base_amount              := ROUND(newrec_.tax_base_amount, base_curr_rounding_);
      newrec_.currency_tax_base_amount     := ROUND(newrec_.currency_tax_base_amount, trans_curr_rounding_);
   END IF;
   newrec_.year_period_key := newrec_.accounting_year*100 + newrec_.accounting_period;
   codestring_rec_.code_a  := newrec_.account;
   codestring_rec_.code_b  := newrec_.code_b;
   codestring_rec_.code_c  := newrec_.code_c;
   codestring_rec_.code_d  := newrec_.code_d;
   codestring_rec_.code_e  := newrec_.code_e;
   codestring_rec_.code_f  := newrec_.code_f;
   codestring_rec_.code_g  := newrec_.code_g;
   codestring_rec_.code_h  := newrec_.code_h;
   codestring_rec_.code_i  := newrec_.code_i;
   codestring_rec_.code_j  := newrec_.code_j;
   Codestring_Comb_API.Get_Combination (newrec_.posting_combination_id, codestring_rec_);
   newrec_.curr_balance    := Account_API.Get_Currency_Balance (newrec_.company, newrec_.account);
   project_code_part_      := Accounting_Code_parts_api.Get_Codepart_Function ( newrec_.company, 'PRACC');
   object_code_part_       := Accounting_Code_parts_api.Get_Codepart_Function ( newrec_.company, 'FAACC');
   Accounting_Codestr_API.Get_Prj_And_Obj_Code_P_Values(newrec_.project_id,
                                                        newrec_.object_id,
                                                        codestring_rec_,
                                                        project_code_part_,
                                                        object_code_part_);
   
   -- Bug 97579, Begin - Re-added the setting default currency rate type.
   -- Bug Id 93703. Remove the assigning default currency types to null currency types. 
   IF (newrec_.currency_type IS NULL) THEN
      newrec_.currency_type := Currency_Type_API.Get_Default_Type(newrec_.company);
   END IF;
   -- Note- When conversion factor is NULL fetch it from the currency code.
   IF (newrec_.conversion_factor IS NULL) THEN
      newrec_.conversion_factor := Currency_Code_API.Get_Conversion_Factor(newrec_.company, newrec_.currency_code);
   END IF;   

   compfin_rec_ := Company_Finance_API.Get(newrec_.company);
   -- Check that parallel currency fields are set (amount, rate and conversion factor). IF not set it will be set in the method.
   Check_Add_Par_Curr_Data___(newrec_,
                              compfin_rec_);

   super(objid_, objversion_, newrec_, attr_);
   IF (newrec_.allocation_id IS NOT NULL) THEN
      IF (NVL(newrec_.currency_credit_amount,0) != 0) THEN
         amount_to_allocate_ := newrec_.currency_credit_amount * -1;
      ELSE
         amount_to_allocate_ := newrec_.currency_debet_amount;
      END IF;
      Period_Allocation_Rule_API.Create_Period_Allocations (allocation_error_,
                                                            newrec_.company,
                                                            newrec_.voucher_type,
                                                            newrec_.voucher_no,
                                                            newrec_.row_no,
                                                            newrec_.account,
                                                            newrec_.accounting_year,
                                                            newrec_.accounting_period,
                                                            newrec_.allocation_id,
                                                            newrec_.parent_allocation_id,
                                                            amount_to_allocate_);
      IF (allocation_error_ IS NOT NULL) THEN
         newrec_.update_error := allocation_error_;
      END IF;
   END IF;
   Client_SYS.Add_To_Attr('ROW_NO', newrec_.row_no, attr_ );

   -- Creating Object Connection and Cost Info
   Handle_Object_Conns___ (newrec_, NULL, TRUE, create_project_conn_);

EXCEPTION
   WHEN dup_val_on_index THEN
        Error_SYS.Record_Exist(lu_name_);
END Insert___;


@Override
PROCEDURE Update___ (
   objid_      IN     VARCHAR2,
   oldrec_     IN     VOUCHER_ROW_TAB%ROWTYPE,
   newrec_     IN OUT VOUCHER_ROW_TAB%ROWTYPE,
   attr_       IN OUT VARCHAR2,
   objversion_ IN OUT VARCHAR2,
   by_keys_    IN     BOOLEAN DEFAULT FALSE )
IS
   base_curr_                    VARCHAR2(3);
   third_curr_                   VARCHAR2(3);
   voucher_date_                 DATE;
   base_curr_rounding_           NUMBER;
   trans_curr_rounding_          NUMBER;
   third_curr_rounding_          NUMBER;
   codestring_rec_               Accounting_codestr_API.CodestrRec;
   project_code_part_            VARCHAR2(1);
   object_code_part_             VARCHAR2(1);
   compfin_rec_                  Company_Finance_API.Public_Rec;
BEGIN
   IF Account_API.Is_Budget_Account(newrec_.company, newrec_.account) THEN
      Error_SYS.Record_General(lu_name_, 'BUDACCONLY: Account :P1 is only allowed for budget.',newrec_.account);
   END IF;
   
   -- Only perform roundings when any amount is changed
   IF (newrec_.credit_amount                = oldrec_.credit_amount                AND
       newrec_.debet_amount                 = oldrec_.debet_amount                 AND
       newrec_.currency_credit_amount       = oldrec_.currency_credit_amount       AND
       newrec_.currency_debet_amount        = oldrec_.currency_debet_amount        AND
       newrec_.third_currency_debit_amount  = oldrec_.third_currency_debit_amount  AND
       newrec_.third_currency_credit_amount = oldrec_.third_currency_credit_amount AND
       newrec_.tax_amount                   = oldrec_.tax_amount                   AND
       newrec_.currency_tax_amount          = oldrec_.currency_tax_amount          AND
       newrec_.gross_amount                 = oldrec_.gross_amount                 AND
       newrec_.currency_gross_amount        = oldrec_.currency_gross_amount        AND
       newrec_.tax_base_amount              = oldrec_.tax_base_amount              AND
       newrec_.currency_tax_base_amount     = oldrec_.currency_tax_base_amount) THEN
      NULL;
   ELSE
      IF (newrec_.voucher_date IS NOT NULL) THEN
         voucher_date_        := newrec_.voucher_date;
      ELSE
         voucher_date_        := Voucher_Api.Get_Voucher_Date (newrec_.company,
                                                               newrec_.accounting_year,
                                                               newrec_.voucher_type,
                                                               newrec_.voucher_no);
         newrec_.voucher_date := voucher_date_;
      END IF;
      base_curr_           := Currency_Code_API.Get_Currency_Code (newrec_.company);
      third_curr_          := Company_Finance_Api.Get_Parallel_Acc_Currency (newrec_.company, voucher_date_);
      base_curr_rounding_  := Currency_Code_API.Get_currency_rounding (newrec_.company, base_curr_);
      IF (newrec_.currency_code = base_curr_) THEN
         trans_curr_rounding_ := base_curr_rounding_;
      ELSE
         trans_curr_rounding_ := Currency_Code_API.Get_currency_rounding (newrec_.company, newrec_.currency_code);
      END IF;
      IF (third_curr_ IS NOT NULL) THEN
         IF    (third_curr_ = base_curr_) THEN
            third_curr_rounding_ := base_curr_rounding_;
         ELSIF (third_curr_ = newrec_.currency_code) THEN
            third_curr_rounding_ := trans_curr_rounding_;
         ELSE
            third_curr_rounding_  := Currency_Code_API.Get_currency_rounding (newrec_.company, third_curr_);
         END IF;
      END IF;
      newrec_.credit_amount                := ROUND(newrec_.credit_amount, base_curr_rounding_);
      newrec_.debet_amount                 := ROUND(newrec_.debet_amount, base_curr_rounding_);
      newrec_.currency_credit_amount       := ROUND(newrec_.currency_credit_amount, trans_curr_rounding_);
      newrec_.currency_debet_amount        := ROUND(newrec_.currency_debet_amount, trans_curr_rounding_);
      newrec_.third_currency_debit_amount  := ROUND(newrec_.third_currency_debit_amount, third_curr_rounding_);
      newrec_.third_currency_credit_amount := ROUND(newrec_.third_currency_credit_amount, third_curr_rounding_);
      newrec_.tax_amount                   := ROUND(newrec_.tax_amount, base_curr_rounding_);
      newrec_.currency_tax_amount          := ROUND(newrec_.currency_tax_amount, trans_curr_rounding_);
      newrec_.gross_amount                 := ROUND(newrec_.gross_amount, base_curr_rounding_);
      newrec_.currency_gross_amount        := ROUND(newrec_.currency_gross_amount, trans_curr_rounding_);
      newrec_.tax_base_amount              := ROUND(newrec_.tax_base_amount, base_curr_rounding_);
      newrec_.currency_tax_base_amount     := ROUND(newrec_.currency_tax_base_amount, trans_curr_rounding_);
   END IF;
   newrec_.year_period_key := newrec_.accounting_year*100 + newrec_.accounting_period;
   IF (newrec_.account = oldrec_.account AND
       newrec_.code_b  = oldrec_.code_b  AND
       newrec_.code_c  = oldrec_.code_c  AND
       newrec_.code_d  = oldrec_.code_d  AND
       newrec_.code_e  = oldrec_.code_e  AND
       newrec_.code_f  = oldrec_.code_f  AND
       newrec_.code_g  = oldrec_.code_g  AND
       newrec_.code_h  = oldrec_.code_h  AND
       newrec_.code_i  = oldrec_.code_i  AND
       newrec_.code_j  = oldrec_.code_j) THEN
      NULL;
   ELSE
      codestring_rec_.code_a  := newrec_.account;
      codestring_rec_.code_b  := newrec_.code_b;
      codestring_rec_.code_c  := newrec_.code_c;
      codestring_rec_.code_d  := newrec_.code_d;
      codestring_rec_.code_e  := newrec_.code_e;
      codestring_rec_.code_f  := newrec_.code_f;
      codestring_rec_.code_g  := newrec_.code_g;
      codestring_rec_.code_h  := newrec_.code_h;
      codestring_rec_.code_i  := newrec_.code_i;
      codestring_rec_.code_j  := newrec_.code_j;
      Codestring_Comb_API.Get_Combination (newrec_.posting_combination_id, codestring_rec_);
      project_code_part_ := Accounting_Code_parts_api.Get_Codepart_Function ( newrec_.company, 'PRACC');
      object_code_part_       := Accounting_Code_parts_api.Get_Codepart_Function ( newrec_.company, 'FAACC');
      Accounting_Codestr_API.Get_Prj_And_Obj_Code_P_Values(newrec_.project_id,
                                                           newrec_.object_id,
                                                           codestring_rec_,
                                                           project_code_part_,
                                                           object_code_part_);
   END IF;
   -- Note- When conversion factor is NULL fetch it from the currency code.
   IF (newrec_.conversion_factor IS NULL) THEN
      newrec_.conversion_factor := Currency_Code_API.Get_Conversion_Factor(newrec_.company, newrec_.currency_code);
   END IF;

   compfin_rec_ := Company_Finance_API.Get(newrec_.company);
   -- Check that parallel currency fields are set (amount, rate and conversion factor). IF not set it will be set in the method.
   Check_Add_Par_Curr_Data___(newrec_, compfin_rec_);
   Delete_Tax_Transaction___(oldrec_);
   super(objid_, oldrec_, newrec_, attr_, objversion_, by_keys_);

   -- Handling Object Connection and Cost Info
   Handle_Object_Conns___ (newrec_, oldrec_, FALSE, 'FALSE');

   Internal_Manual_Postings___(newrec_);
   Prepare_Tax_Transaction___(newrec_);
   $IF Component_Fixass_SYS.INSTALLED $THEN
      Re_Create_Mod_Add_Inv_Info___(newrec_);
   $END

EXCEPTION
   WHEN dup_val_on_index THEN
      Error_SYS.Record_Exist(lu_name_);
END Update___;


@Override
PROCEDURE Check_Delete___ (
   remrec_ IN VOUCHER_ROW_TAB%ROWTYPE )
IS
   simulation_voucher_  VARCHAR2(5);
   allocated_ NUMBER;
BEGIN
   IF (upper(remrec_.trans_code) != 'MANUAL') THEN
      simulation_voucher_ := Voucher_Type_API.Get_Simulation_Voucher ( remrec_.company, remrec_.voucher_type);
      IF (simulation_voucher_ = 'FALSE') THEN
         Error_SYS.Record_General(lu_name_, 'NODELMANUAL: The voucher row is automatically created and cannot be deleted');
      END IF;
   END IF;
   allocated_ := Period_Allocation_API.Any_Voucher( remrec_.company,
                                                    remrec_.voucher_type,
                                                    remrec_.voucher_no,
                                                    remrec_.accounting_year,
                                                    remrec_.row_no );
   IF ( allocated_ = 1) THEN
      Error_SYS.Record_General(lu_name_, 'EXISTINPERALLOC: Can not change Voucher row that exists in Period Allocation');
   END IF;   
   super(remrec_);
END Check_Delete___;


@Override
PROCEDURE Delete___ (
   objid_  IN VARCHAR2,
   remrec_ IN VOUCHER_ROW_TAB%ROWTYPE )
IS
BEGIN
   -- Removing Object Connection and Cost Info
   IF NVL(remrec_.project_activity_id,0) != 0  THEN
      Remove_Object_Connection___(remrec_);   
   END IF;
   Delete_Tax_Transaction___(remrec_);
   super(objid_, remrec_);
   Delete_Internal_Rows___ (remrec_.company,
                            remrec_.voucher_type,
                            remrec_.accounting_year,
                            remrec_.voucher_no,
                            remrec_.account,
                            remrec_.row_no);
   
   $IF Component_Fixass_SYS.INSTALLED $THEN
      Remove_Add_Investment_Info___(remrec_);
   $END   
END Delete___;


FUNCTION Check_If_Code_Part_Used___(
   company_   IN VARCHAR2,
   code_part_ IN VARCHAR2 ) RETURN BOOLEAN
IS
   dummy_ NUMBER;
   CURSOR is_used_ IS
      SELECT 1
      FROM   voucher_row_tab
      WHERE  company = company_
      AND    DECODE(code_part_,'A',account,
                               'B',code_b,
                               'C',code_c,
                               'D',code_d,
                               'E',code_e,
                               'F',code_f,
                               'G',code_g,
                               'H',code_h,
                               'I',code_i,
                               'J',code_j) IS NOT NULL;
BEGIN
  OPEN  is_used_;
  FETCH is_used_ INTO dummy_;
  IF (is_used_%NOTFOUND) THEN
     CLOSE is_used_;
     RETURN FALSE;
  END IF;
  CLOSE is_used_;
  RETURN TRUE;
END Check_If_Code_Part_Used___;


@Override
PROCEDURE Check_Insert___ (
   newrec_ IN OUT voucher_row_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS
   name_                     VARCHAR2(30);
   value_ VARCHAR2(4000);
   head_                     Voucher_Api.Public_Rec;
   ledger_account_           BOOLEAN;
   function_group_           VARCHAR2(20);
   simulation_voucher_       VARCHAR2(20);
   user_group_               user_group_member_finance_tab.user_group%type;
   amount_method_            VARCHAR2(200);
   interim_tax_ledger_accnt_ VARCHAR2(5):= 'FALSE';
   -- Bug 97225, Begin
   tax_handling_value_       ACCOUNTING_CODE_PART_VALUE_TAB.tax_handling_value%TYPE;
   tax_direction_            VARCHAR2(100);
   -- Bug 97225, End
BEGIN
   IF(Client_SYS.Item_Exist('CODE_DEMAND',attr_)) THEN
      Error_SYS.Item_Insert(lu_name_, 'CODE_DEMAND');   
   END IF;
   IF(Client_SYS.Item_Exist('CODE_PART',attr_)) THEN
      Error_SYS.Item_Insert(lu_name_, 'CODE_PART');   
   END IF;
   --pre check insert
   IF (Client_SYS.Item_Exist('PERIOD_ALLOCATION', attr_)) THEN
      Error_SYS.Item_Insert(lu_name_, 'PERIOD_ALLOCATION');
   END IF;  
   
   super(newrec_, indrec_, attr_);
   
   interim_tax_ledger_accnt_ := NVL(Client_SYS.Cut_Item_Value('INTERIM_TAX_LEDGER_ACCNT', attr_), 'FALSE');
         
   IF (newrec_.currency_code IS NULL) THEN
      Error_sys.Record_General('VoucherRow', 'CURCODENULL: Voucher row should have a currency code');
   END IF;

   IF (newrec_.debet_amount IS NULL AND newrec_.credit_amount IS NULL AND (newrec_.third_currency_debit_amount IS NOT NULL OR newrec_.third_currency_credit_amount IS NOT NULL)) THEN
      IF (newrec_.third_currency_debit_amount IS NOT NULL) THEN
          newrec_.debet_amount := 0;
      ELSIF (newrec_.third_currency_credit_amount IS NOT NULL) THEN
          newrec_.credit_amount := 0;
      END IF;
   END IF;

   newrec_.corrected := NVL( newrec_.corrected, 'N' );
   head_ := Voucher_API.Get( newrec_.company,
                             newrec_.accounting_year,
                             newrec_.voucher_type,
                             newrec_.voucher_no );
   function_group_     := head_.function_group;
   simulation_voucher_ := head_.simulation_voucher;
   user_group_         := head_.user_group;
   amount_method_      := head_.amount_method;
   
   IF (newrec_.voucher_date IS NULL) THEN
      newrec_.voucher_date := head_.voucher_date;
   END IF;

   IF ( head_.interim_voucher = 'Y' AND UPPER( newrec_.trans_code) != 'INTERIM') THEN
      Error_SYS.Record_General(lu_name_, 'NOINTERIM: The voucher is connected to an interim voucher and cannot be changed');
   END IF;
   IF (newrec_.accounting_period IS NULL) THEN
      newrec_.accounting_period := head_.accounting_period;
   END IF;
   Calculate_Net_From_Gross (newrec_, amount_method_);

   -- Bug 108987, Begin - Modified the code added by bug 85810
   IF (function_group_ IN ('M', 'K', 'Q') AND newrec_.trans_code = 'MANUAL') THEN
      IF (Company_Finance_Api.Get_Parallel_Base_Db(newrec_.company) IN ('TRANSACTION_CURRENCY','ACCOUNTING_CURRENCY')) THEN
         IF ((NVL(newrec_.debet_amount,0) = 0) AND (NVL(newrec_.credit_amount,0) = 0) AND 
             (NVL(newrec_.third_currency_debit_amount,0) = 0) AND (NVL(newrec_.third_currency_credit_amount,0) = 0) AND
             (NVL(newrec_.currency_debet_amount,0) = 0) AND (NVL(newrec_.currency_credit_amount,0) = 0) AND 
             (NVL(newrec_.quantity,0) = 0)) THEN
               Error_SYS.Record_General(lu_name_,'NOAMOUNT: Amount or Quantity must have a value.');
         END IF;
      ELSE  
         --Bug 85810, Begin
         IF ((NVL(newrec_.debet_amount,0) = 0) AND (NVL(newrec_.credit_amount,0) = 0) AND 
             (NVL(newrec_.currency_debet_amount,0) = 0) AND (NVL(newrec_.currency_credit_amount,0) = 0) AND 
             (NVL(newrec_.quantity,0) = 0)) THEN
               Error_SYS.Record_General(lu_name_,'NOAMOUNT: Amount or Quantity must have a value.');
         END IF;
         --Bug 85810, End
      END IF;
   END IF;
   -- Bug 108987, End
   Error_SYS.Check_Not_Null(lu_name_, 'CURRENCY_RATE', newrec_.currency_rate);


   IF (Voucher_Type_API.Is_Row_Group_Validated(newrec_.company,newrec_.voucher_type)='Y') THEN
      Error_SYS.Check_Not_Null(lu_name_, 'ROW_GROUP_ID', newrec_.row_group_id);
      IF Account_API.Is_Stat_Account (newrec_.company, newrec_.account) = 'TRUE' THEN
         Error_SYS.Record_General('VoucherRow', 'DBLENTRYVALSTATAC: Statistical account :P1 excluded from voucher balance is not allowed with row group validation.',newrec_.account);
      END IF;
   ELSE
      newrec_.row_group_id := NULL;
   END IF;
   IF ((Voucher_Type_API.Is_Reference_Mandatory(newrec_.company,newrec_.voucher_type)='Y') AND 
        Voucher_API.Get_Vou_Status_Client_(newrec_.company,newrec_.accounting_year,newrec_.voucher_type, newrec_.voucher_no ) = 'Approved' ) THEN
      IF ( newrec_.reference_serie IS NULL AND newrec_.reference_number IS NULL) THEN
         Error_SYS.Record_General('VoucherRow', 'REFSERNUMNOTNULL: Reference Series and Reference Number cannot be null when Reference Mandatory is checked for Voucher Type :P1', newrec_.voucher_type );
      END IF;
   END IF;
   Check_Acquisition___(newrec_,
                        function_group_,
                        NULL);           -- fa_code_part
   ledger_account_ := Account_API.Is_Ledger_Account (newrec_.company, newrec_.account);
   IF (interim_tax_ledger_accnt_ = 'FALSE') THEN
      IF (ledger_account_) AND (function_group_ != 'Q') THEN
         Error_SYS.Record_General('VoucherRow', 'VOUISLEDGER: Ledger Account :P1 is not permitted for Manual Vouchers',newrec_.account);
      END IF;
   END IF;
   Check_Project___ (newrec_, function_group_ );
   Check_Codestring___ (newrec_, user_group_);
   IF (newrec_.optional_code IS NOT NULL) THEN
      IF (simulation_voucher_ = 'TRUE') THEN
         Error_SYS.Record_General('VoucherRow', 'SIMNOTAXCODE: It is not allowed to enter a Tax Code when using a Voucher Type defined as Simulation Voucher.');
      END IF;
   END IF;
   IF (simulation_voucher_ = 'FALSE') THEN
      IF (function_group_ IN ('M', 'Q')) THEN
         IF (newrec_.optional_code IS NULL) THEN
            IF (Account_API.Is_Tax_Code_Mandatory(newrec_.company, newrec_.account)) THEN
               Error_SYS.Record_General('VoucherRow', 'TAXCODEMAND: For Account :P1 it is mandatory to enter a Tax Code', newrec_.account);
            END IF;
         END IF;
      END IF;
   END IF;
   IF (function_group_ IN ('Q')) THEN
      newrec_.tax_base_amount := 0;
      newrec_.currency_tax_base_amount := 0;
   END IF;
   -- Bug 97225, Begin - Added the IF condition
   IF ( newrec_.optional_code IS NOT NULL AND function_group_ IN ('M', 'K','Q')) THEN
      Account_Tax_Code_API.Check_Tax_Code(tax_handling_value_, tax_direction_, newrec_.company, newrec_.account, newrec_.optional_code, check_deductible_ => 'TRUE' );
   ELSIF NOT (function_group_ IN ('R')) THEN
      -- Do not check Tax Code for Interim Vouchers
      Account_Tax_Code_API.Check_Tax_Code_Deduct (newrec_.company,
                                                  newrec_.account,
                                                  newrec_.optional_code);
   END IF;
   -- Bug 97225, End
   Check_Overwriting_Level___ (newrec_);
   IF (newrec_.currency_type IS NOT NULL) THEN
      Currency_Type_API.Curr_Type_Exist_Parallel(newrec_.company, newrec_.currency_type);
   END IF;
EXCEPTION
   WHEN value_error THEN
      Error_SYS.Item_Format(lu_name_, name_, value_);
END Check_Insert___;


@Override
PROCEDURE Unpack___ (
   newrec_   IN OUT NOCOPY voucher_row_tab%ROWTYPE,
   indrec_   IN OUT NOCOPY Indicator_Rec,
   attr_     IN OUT NOCOPY VARCHAR2 )
IS
BEGIN
   --added pre-unpack
   IF (newrec_.accounting_year IS NOT NULL) THEN
      IF (Client_SYS.Item_Exist('ACCOUNTING_YEAR', attr_)) THEN
         newrec_.accounting_year := Client_SYS.Cut_Item_Value('ACCOUNTING_YEAR', attr_);
      END IF;   
   END IF;   
   super(newrec_, indrec_, attr_);
END Unpack___;

@Override
PROCEDURE Check_Update___ (
   oldrec_ IN     voucher_row_tab%ROWTYPE,
   newrec_ IN OUT voucher_row_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS
   name_                VARCHAR2(30);
   value_ VARCHAR2(4000);
   genled_update_       VARCHAR2(20);
   ledger_account_      BOOLEAN;
   function_group_      VARCHAR2(20);
   simulation_voucher_  VARCHAR2(20);
   user_group_          user_group_member_finance_tab.user_group%type;
   amount_method_       VARCHAR2(200);
   head_                Voucher_Api.Public_Rec;
   req_rec_             Accounting_Codestr_API.CodestrRec;

   -- Bug 97225, Begin
   tax_handling_value_       ACCOUNTING_CODE_PART_VALUE_TAB.tax_handling_value%TYPE;
   tax_direction_            VARCHAR2(100);
   -- Bug 97225, End
BEGIN
   IF(Client_SYS.Item_Exist('CODE_DEMAND',attr_)) THEN
      Error_SYS.Item_Update(lu_name_, 'CODE_DEMAND');  
   END IF;
   
   -- pre check_update
   IF (Client_SYS.Item_Exist('PERIOD_ALLOCATION', attr_)) THEN
      Error_SYS.Item_Update(lu_name_, 'PERIOD_ALLOCATION');
   END IF;   
   super(oldrec_, newrec_, indrec_, attr_);
   
   IF (newrec_.currency_code IS NULL) THEN
      Error_sys.Record_General('VoucherRow', 'CURCODENULL: Voucher row should have a currency code');
   END IF;
   req_rec_ := Account_API.Get_Required_Code_Parts(newrec_.company, newrec_.account);
   IF req_rec_.code_b = 'S' THEN
      newrec_.code_b := NULL;
      Client_SYS.Set_Item_Value( 'CODE_B','', attr_ );
   END IF;
   IF req_rec_.code_c = 'S' THEN
      newrec_.code_c := NULL;
      Client_SYS.Set_Item_Value( 'CODE_C','', attr_ );
   END IF;
   IF req_rec_.code_d = 'S' THEN
      newrec_.code_d := NULL;
      Client_SYS.Set_Item_Value( 'CODE_D','', attr_ );
   END IF;
   IF req_rec_.code_e = 'S' THEN
      newrec_.code_e := NULL;
      Client_SYS.Set_Item_Value( 'CODE_E','', attr_ );
   END IF;
   IF req_rec_.code_f = 'S' THEN
      newrec_.code_f := NULL;
      Client_SYS.Set_Item_Value( 'CODE_F','', attr_ );
   END IF;
   IF req_rec_.code_g = 'S' THEN
      newrec_.code_g := NULL;
      Client_SYS.Set_Item_Value( 'CODE_G','', attr_ );
   END IF;
   IF req_rec_.code_h = 'S' THEN
      newrec_.code_h := NULL;
      Client_SYS.Set_Item_Value( 'CODE_H','', attr_ );
   END IF;
   IF req_rec_.code_i = 'S' THEN
      newrec_.code_i := NULL;
      Client_SYS.Set_Item_Value( 'CODE_I','', attr_ );
   END IF;
   IF req_rec_.code_j = 'S' THEN
      newrec_.code_j := NULL;
      Client_SYS.Set_Item_Value( 'CODE_J','', attr_ );   
   END IF;
   
   newrec_.corrected := 'Y';
   head_ := Voucher_API.Get( newrec_.company,
                             newrec_.accounting_year,
                             newrec_.voucher_type,
                             newrec_.voucher_no );
   function_group_     := head_.function_group;
   simulation_voucher_ := head_.simulation_voucher;
   user_group_         := head_.user_group;
   amount_method_      := head_.amount_method;
   IF (newrec_.voucher_date IS NULL) THEN
      newrec_.voucher_date := head_.voucher_date;
   END IF;
   IF (newrec_.voucher_date IS NULL) OR (newrec_.voucher_date != head_.voucher_date) THEN
      newrec_.voucher_date := head_.voucher_date;
   END IF;

   IF ( head_.interim_voucher = 'Y' )THEN
      Error_SYS.Record_General(lu_name_, 'ISINTERIM: The voucher is connected to an interim voucher and cannot be changed');
   END IF;

   Calculate_Net_From_Gross (newrec_, amount_method_);

   -- Bug 108987, Begin
   IF (function_group_ IN ('M', 'K', 'Q') AND newrec_.trans_code = 'MANUAL') THEN
      IF (Company_Finance_Api.Get_Parallel_Base_Db(newrec_.company) IN ('TRANSACTION_CURRENCY','ACCOUNTING_CURRENCY')) THEN
         IF ((NVL(newrec_.debet_amount,0) = 0) AND (NVL(newrec_.credit_amount,0) = 0) AND
             (NVL(newrec_.third_currency_debit_amount,0) = 0) AND (NVL(newrec_.third_currency_credit_amount,0) = 0) AND
             (NVL(newrec_.currency_debet_amount,0) = 0) AND (NVL(newrec_.currency_credit_amount,0) = 0) AND 
             (NVL(newrec_.quantity,0) = 0)) THEN
               Error_SYS.Record_General(lu_name_,'NOAMOUNT: Amount or Quantity must have a value.');
         END IF;
      ELSE  
         IF ((NVL(newrec_.debet_amount,0) = 0) AND (NVL(newrec_.credit_amount,0) = 0) AND 
             (NVL(newrec_.currency_debet_amount,0) = 0) AND (NVL(newrec_.currency_credit_amount,0) = 0) AND 
             (NVL(newrec_.quantity,0) = 0)) THEN
            Error_SYS.Record_General(lu_name_,'NOAMOUNT: Amount or Quantity must have a value.');
         END IF; 
     END IF;
   END IF;
   -- Bug 108987, End


   Error_SYS.Check_Not_Null(lu_name_, 'CURRENCY_RATE', newrec_.currency_rate);

   IF (Voucher_Type_API.Is_Row_Group_Validated(newrec_.company,newrec_.voucher_type)='Y') THEN
      Error_SYS.Check_Not_Null(lu_name_, 'ROW_GROUP_ID', newrec_.row_group_id);
      IF Account_API.Is_Stat_Account (newrec_.company, newrec_.account) = 'TRUE' THEN
         Error_SYS.Record_General('VoucherRow', 'DBLENTRYVALSTATAC: Statistical account :P1 excluded from voucher balance is not allowed with row group validation.',newrec_.account);
      END IF;
   ELSE
      newrec_.row_group_id := NULL;
   END IF;
   
   genled_update_ := NVL(Client_SYS.Get_Item_Value('GENLED_UPDATE', attr_), 'FALSE');
   IF (genled_update_ != 'TRUE') THEN
      Check_Period_Allocation___(newrec_);
   END IF;
   
   ledger_account_ := Account_API.Is_Ledger_Account (newrec_.company, newrec_.account);
   IF (ledger_account_) AND (function_group_ != 'Q') THEN
      Error_SYS.Record_General('VoucherRow', 'VOUISLEDGER: Ledger Account :P1 is not permitted for Manual Vouchers',newrec_.account);
   END IF;
   IF ((Voucher_Type_API.Is_Reference_Mandatory(newrec_.company,newrec_.voucher_type)='Y') AND 
        Voucher_API.Get_Vou_Status_Client_(newrec_.company,newrec_.accounting_year,newrec_.voucher_type, newrec_.voucher_no ) = 'Approved' ) THEN
      IF (newrec_.reference_serie IS NULL AND newrec_.reference_number IS NULL) THEN
         Error_SYS.Record_General('VoucherRow', 'REFSERNUMNOTNULL: Reference Series and Reference Number cannot be null when Reference Mandatory is checked for Voucher Type :P1', newrec_.voucher_type );
      END IF;
   END IF;
   Check_Acquisition___(newrec_,
                        function_group_,
                        NULL);           -- fa_code_part
   Check_Codestring___ (newrec_, user_group_);
   Check_Project___ (newrec_, function_group_ );
   IF (newrec_.optional_code IS NOT NULL) THEN
      IF (simulation_voucher_ = 'TRUE') THEN
         Error_SYS.Record_General('VoucherRow', 'SIMNOTAXCODE: It is not allowed to enter a Tax Code when using a Voucher Type defined as Simulation Voucher.');
      END IF;
   END IF;
   IF (simulation_voucher_ = 'FALSE') THEN
      IF (function_group_ IN ('M', 'Q')) THEN
         IF (newrec_.optional_code IS NULL) THEN
            IF (Account_API.Is_Tax_Code_Mandatory(newrec_.company, newrec_.account)) THEN
               Error_SYS.Record_General('VoucherRow', 'TAXCODEMAND: For Account :P1 it is mandatory to enter a Tax Code', newrec_.account);
            END IF;
         END IF;
      END IF;
   END IF;
   IF (function_group_ IN ('Q')) THEN
      newrec_.tax_base_amount := 0;
      newrec_.currency_tax_base_amount := 0;
   END IF;
   
      -- Bug 97225, Begin
   IF ( newrec_.optional_code IS NOT NULL ) THEN
      IF ( function_group_ IN ('M', 'K''Q')) THEN
         Account_Tax_Code_API.Check_Tax_Code(tax_handling_value_, tax_direction_, newrec_.company, newrec_.account, newrec_.optional_code, check_deductible_ => 'TRUE' );
      ELSE
         Account_Tax_Code_API.Check_Tax_Code(newrec_.company, newrec_.account, newrec_.optional_code );
      END IF;
   END IF;
   -- Bug 97225, End
  
   Check_Overwriting_Level___ (newrec_);
   IF (oldrec_.account != newrec_.account) THEN
      Delete_Internal_Rows___ (newrec_.company,
                               newrec_.voucher_type,
                               newrec_.accounting_year,
                               newrec_.voucher_no,
                               oldrec_.account,
                               newrec_.row_no);
   END IF;
   IF ((indrec_.currency_type) AND (newrec_.currency_type IS NOT NULL)) THEN
      Currency_Type_API.Curr_Type_Exist_Parallel(newrec_.company, newrec_.currency_type);
   END IF;
EXCEPTION
   WHEN value_error THEN
      Error_SYS.Item_Format(lu_name_, name_, value_);
END Check_Update___;


-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------

@Override
PROCEDURE New__ (
   info_       OUT    VARCHAR2,
   objid_      OUT    VARCHAR2,
   objversion_ OUT    VARCHAR2,
   attr_       IN OUT VARCHAR2,
   action_     IN     VARCHAR2 )
IS
   newrec_           VOUCHER_ROW_TAB%ROWTYPE;
BEGIN
   super(info_, objid_, objversion_, attr_, action_);
   IF (action_ = 'DO') THEN
      newrec_ := Get_Object_By_Id___(objid_);
      Internal_Manual_Postings___(newrec_, TRUE);
      Prepare_Tax_Transaction___(newrec_);
      $IF Component_Fixass_SYS.INSTALLED $THEN
         Create_Add_Investment_Info___(newrec_);
      $END      
   END IF;
END New__;


@UncheckedAccess
FUNCTION Calculate_Rate__ (
   company_            IN VARCHAR2,
   base_currency_code_ IN VARCHAR2,
   amount_             IN NUMBER,
   currency_amount_    IN NUMBER,
   conv_factor_        IN NUMBER,
   currency_code_      IN VARCHAR2 ) RETURN NUMBER
IS
BEGIN
   IF (nvl(currency_amount_, 0) = 0) OR (nvl(amount_, 0) = 0) THEN
      RETURN(0);
   END IF;
   IF Currency_Code_Api.Get_Inverted(company_, base_currency_code_)= 'TRUE' THEN
       RETURN(abs(round((currency_amount_/amount_) * conv_factor_, nvl(Currency_Code_API.Get_No_Of_Decimals_In_Rate(company_,currency_code_ ),0))));
   ELSE
       RETURN(abs(round((amount_/currency_amount_) * conv_factor_, nvl(Currency_Code_API.Get_No_Of_Decimals_In_Rate(company_,currency_code_ ),0))));
   END IF;
END Calculate_Rate__;


PROCEDURE Validate_Process_Code__ (
   company_           IN VARCHAR2,
   process_code_      IN VARCHAR2,
   voucher_date_      IN DATE )
IS
   result_               VARCHAR2(5);
BEGIN
   Account_Process_Code_API.Exist (company_, process_code_);
   Account_Process_Code_API.Validate_Process_Code (result_,
                                                   company_,
                                                   process_code_,
                                                   voucher_date_);
END Validate_Process_Code__;


PROCEDURE Reverse_Voucher_Rows__(
   company_               IN VARCHAR2,
   voucher_no_            IN NUMBER,
   accounting_year_       IN NUMBER,
   voucher_type_          IN VARCHAR2,
   reversal_voucher_no_   IN NUMBER,
   reversal_acc_year_     IN NUMBER,
   reversal_voucher_type_ IN VARCHAR2,
   rollback_voucher_      IN VARCHAR2 DEFAULT NULL )
IS
   CURSOR get_voucher_row IS
      SELECT   *
      FROM     voucher_row_tab
      WHERE    company         = company_
      AND      voucher_type    = voucher_type_
      AND      voucher_no      = voucher_no_
      AND      accounting_year = accounting_year_
      ORDER BY row_no;
   comp_fin_rec_                 Company_Finance_API.Public_Rec;
   head_                         Voucher_API.Public_Rec;
   reversal_rec_                 VOUCHER_ROW_TAB%ROWTYPE;
   emp_reversal_rec_             VOUCHER_ROW_TAB%ROWTYPE;
   voucher_date_                 DATE;
   base_currency_code_           VARCHAR2(3);
   third_currency_code_          VARCHAR2(3);
   is_base_emu_                  VARCHAR2(5);
   is_third_emu_                 VARCHAR2(5);
   attr_                         VARCHAR2(32000);
   objid_                        VARCHAR2(2000);
   objversion_                   VARCHAR2(2000);
   function_group_               VARCHAR2(20);
   simulation_voucher_           VARCHAR2(20);
   user_group_                   VARCHAR2(30);
   amount_method_                VARCHAR2(200);
   third_currency_debit_amount_  NUMBER;
   third_currency_credit_amount_ NUMBER;
   correction_type_              company_finance_tab.correction_type%TYPE;
   parallel_base_                VARCHAR2(25);
BEGIN
   voucher_date_        := Voucher_API.Get_Voucher_Date(company_,
                                                        reversal_acc_year_,
                                                        reversal_voucher_type_,
                                                        reversal_voucher_no_);
   comp_fin_rec_        := Company_Finance_API.Get(company_);
   base_currency_code_  := Company_Finance_API.Get_Currency_Code(company_);
   third_currency_code_ := Company_Finance_API.Get_Parallel_Acc_Currency(company_, voucher_date_);
   parallel_base_       := Company_Finance_API.Get_Parallel_Base_Db(company_);
   is_base_emu_         := Currency_Code_API.Get_Valid_Emu (company_,
                                                            base_currency_code_,
                                                            voucher_date_);
   IF (third_currency_code_ IS NOT NULL) THEN
      is_third_emu_     := Currency_Code_Api.Get_Valid_Emu (company_,
                                                            third_currency_code_,
                                                            voucher_date_);
   ELSE
      is_third_emu_     := 'FALSE';
   END IF; 
   --rollback_voucher_ = 'TRUE' if method is called to cancel the voucher ( CORRECTION_TYPE )
   --else it is called to create the reversal voucher ( REVERSAL_VOU_CORR_TYPE )
   IF ( rollback_voucher_ IS NOT NULL AND rollback_voucher_ = 'TRUE' ) THEN -- Cancellation voucher
      correction_type_ := comp_fin_rec_.correction_type;
   ELSE  -- Reversal voucher
      correction_type_ := comp_fin_rec_.reverse_vou_corr_type;
   END IF;
   FOR get_voucher_row_ IN get_voucher_row LOOP
      Client_SYS.Clear_Attr(attr_);
      reversal_rec_                     := emp_reversal_rec_;
      reversal_rec_.company             := company_;
      reversal_rec_.voucher_type        := reversal_voucher_type_; 
      reversal_rec_.accounting_year     := reversal_acc_year_;
      reversal_rec_.voucher_no          := reversal_voucher_no_; 
      reversal_rec_.voucher_date        := voucher_date_;
      reversal_rec_.row_no              := get_voucher_row_.row_no; 
      reversal_rec_.account             := get_voucher_row_.account; 
      reversal_rec_.code_b              := get_voucher_row_.code_b; 
      reversal_rec_.code_c              := get_voucher_row_.code_c; 
      reversal_rec_.code_d              := get_voucher_row_.code_d; 
      reversal_rec_.code_e              := get_voucher_row_.code_e; 
      reversal_rec_.code_f              := get_voucher_row_.code_f; 
      reversal_rec_.code_g              := get_voucher_row_.code_g; 
      reversal_rec_.code_h              := get_voucher_row_.code_h; 
      reversal_rec_.code_i              := get_voucher_row_.code_i; 
      reversal_rec_.code_j              := get_voucher_row_.code_j; 
      reversal_rec_.internal_seq_number := get_voucher_row_.internal_seq_number; 
      IF (correction_type_ = 'REVERSE') THEN
         reversal_rec_.currency_debet_amount        := get_voucher_row_.currency_credit_amount;
         reversal_rec_.currency_credit_amount       := get_voucher_row_.currency_debet_amount;
         reversal_rec_.debet_amount                 := get_voucher_row_.credit_amount;
         reversal_rec_.credit_amount                := get_voucher_row_.debet_amount;
         reversal_rec_.third_currency_debit_amount  := get_voucher_row_.third_currency_credit_amount;
         reversal_rec_.third_currency_credit_amount := get_voucher_row_.third_currency_debit_amount;
      ELSE
         reversal_rec_.currency_debet_amount        := - get_voucher_row_.currency_debet_amount;
         reversal_rec_.currency_credit_amount       := - get_voucher_row_.currency_credit_amount;
         reversal_rec_.debet_amount                 := - get_voucher_row_.debet_amount;
         reversal_rec_.credit_amount                := - get_voucher_row_.credit_amount;
         reversal_rec_.third_currency_debit_amount  := - get_voucher_row_.third_currency_debit_amount;
         reversal_rec_.third_currency_credit_amount := - get_voucher_row_.third_currency_credit_amount;
      END IF;
      reversal_rec_.tax_base_amount           := - get_voucher_row_.tax_base_amount;
      reversal_rec_.currency_tax_base_amount  := - get_voucher_row_.currency_tax_base_amount;
      reversal_rec_.tax_direction             := Tax_Direction_API.Decode(get_voucher_row_.tax_direction);
      reversal_rec_.currency_code             := get_voucher_row_.currency_code;
      reversal_rec_.quantity                  := - get_voucher_row_.quantity;
      reversal_rec_.process_code              := get_voucher_row_.process_code;
      reversal_rec_.optional_code             := get_voucher_row_.optional_code;
      reversal_rec_.project_activity_id       := get_voucher_row_.project_activity_id;
      reversal_rec_.text                      := get_voucher_row_.text;
      reversal_rec_.party_type_id             := get_voucher_row_.party_type_id;
      reversal_rec_.reference_serie           := get_voucher_row_.reference_serie;
      reversal_rec_.reference_number          := get_voucher_row_.reference_number;
      reversal_rec_.reference_version         := get_voucher_row_.reference_version;
      reversal_rec_.party_type                := get_voucher_row_.party_type;
      reversal_rec_.transfer_id               := get_voucher_row_.transfer_id;
      reversal_rec_.currency_rate             := get_voucher_row_.currency_rate;
      reversal_rec_.conversion_factor         := get_voucher_row_.conversion_factor;
      reversal_rec_.activate_code             := get_voucher_row_.activate_code;
      -- Bug 121642, begin
      reversal_rec_.mpccom_accounting_id      := get_voucher_row_.mpccom_accounting_id;
      -- Bug 121642, end
      reversal_rec_.parallel_currency_rate       := get_voucher_row_.parallel_currency_rate;
      reversal_rec_.parallel_conversion_factor   := get_voucher_row_.parallel_conversion_factor;
      reversal_rec_.parallel_curr_tax_amount     := - get_voucher_row_.parallel_curr_tax_amount;
      reversal_rec_.parallel_curr_gross_amount   := - get_voucher_row_.parallel_curr_gross_amount;
      reversal_rec_.parallel_curr_tax_base_amount:= - get_voucher_row_.parallel_curr_tax_base_amount;
      reversal_rec_.parallel_curr_rate_type      := get_voucher_row_.parallel_curr_rate_type;

      IF (third_currency_code_ IS NOT NULL) THEN
         IF ((get_voucher_row_.debet_amount IS NOT NULL) AND
             (get_voucher_row_.third_currency_debit_amount IS NULL)) THEN
            third_currency_debit_amount_ := Currency_Amount_Api.Calculate_Parallel_Curr_Amount(company_,
                                                             voucher_date_,
                                                             get_voucher_row_.debet_amount,
                                                             get_voucher_row_.currency_debet_amount,
                                                             base_currency_code_, 
                                                             get_voucher_row_.currency_code, 
                                                             get_voucher_row_.parallel_curr_rate_type, 
                                                             third_currency_code_,
                                                             parallel_base_,
                                                             is_base_emu_,
                                                             is_third_emu_);
            third_currency_debit_amount_              := NVL(-third_currency_debit_amount_,0);
            reversal_rec_.third_currency_debit_amount := third_currency_debit_amount_;
         END IF;
         IF ((get_voucher_row_.credit_amount IS NOT NULL) AND
             (get_voucher_row_.third_currency_credit_amount IS NULL)) THEN
            third_currency_credit_amount_ := Currency_Amount_Api.Calculate_Parallel_Curr_Amount(company_,
                                                             voucher_date_,
                                                             get_voucher_row_.credit_amount,
                                                             get_voucher_row_.currency_credit_amount,
                                                             base_currency_code_, 
                                                             get_voucher_row_.currency_code, 
                                                             get_voucher_row_.parallel_curr_rate_type, 
                                                             third_currency_code_,
                                                             parallel_base_,
                                                             is_base_emu_,
                                                             is_third_emu_);
            third_currency_credit_amount_ := NVL(-third_currency_credit_amount_,0);
            reversal_rec_.third_currency_credit_amount := third_currency_credit_amount_;
         END IF; 
      END IF;
      Voucher_API.Exist (reversal_rec_.company,
                         reversal_rec_.voucher_type,
                         reversal_rec_.accounting_year,
                         reversal_rec_.voucher_no);
      IF (reversal_rec_.currency_code IS NOT NULL) THEN
         Currency_Code_API.Exist (reversal_rec_.company, reversal_rec_.currency_code);
      ELSE
         Error_sys.Record_General('VoucherRow', 'CURCODENULL: Voucher row should have a currency code');
      END IF;
      IF (reversal_rec_.process_code IS NOT NULL) THEN
         Account_Process_Code_API.Exist (reversal_rec_.company, reversal_rec_.process_code);
      END IF;
      IF (reversal_rec_.optional_code IS NOT NULL) THEN
         Statutory_Fee_API.Exist (reversal_rec_.company, reversal_rec_.optional_code);
      END IF;
      IF (reversal_rec_.corrected IS NOT NULL) THEN
         Corrected_Voucher_API.Exist_Db(reversal_rec_.corrected);
      END IF;
      IF (reversal_rec_.tax_direction IS NOT NULL) THEN
         Tax_Direction_API.Exist_Db(reversal_rec_.tax_direction);
      END IF;
      reversal_rec_.corrected := NVL( reversal_rec_.corrected, 'N' );
      head_ := Voucher_API.Get( reversal_rec_.company,
                                reversal_rec_.accounting_year,
                                reversal_rec_.voucher_type,
                                reversal_rec_.voucher_no );
      function_group_     := head_.function_group;
      simulation_voucher_ := head_.simulation_voucher;
      user_group_         := head_.user_group;
      amount_method_      := head_.amount_method;
      reversal_rec_.accounting_period   := head_.accounting_period;  
      IF (rollback_voucher_ IS NULL) THEN
         reversal_rec_.trans_code          := 'REVERSAL-'||get_voucher_row_.trans_code;
      ELSIF (rollback_voucher_ = 'TRUE') THEN
         reversal_rec_.trans_code          := get_voucher_row_.trans_code;
      END IF;
      Calculate_Net_From_Gross (reversal_rec_, amount_method_);
      Error_SYS.Check_Not_Null(lu_name_, 'COMPANY', reversal_rec_.company);
      Error_SYS.Check_Not_Null(lu_name_, 'VOUCHER_TYPE', reversal_rec_.voucher_type);
      Error_SYS.Check_Not_Null(lu_name_, 'ACCOUNTING_YEAR', reversal_rec_.accounting_year);
      Error_SYS.Check_Not_Null(lu_name_, 'VOUCHER_NO', reversal_rec_.voucher_no);
      Error_SYS.Check_Not_Null(lu_name_, 'ACCOUNT', reversal_rec_.account);
      Error_SYS.Check_Not_Null(lu_name_, 'ACCOUNTING_PERIOD', reversal_rec_.accounting_period);
      Check_Acquisition___(reversal_rec_,
                           function_group_,
                           NULL);
      IF (function_group_ != 'P') THEN
         Check_Project___ (reversal_rec_, function_group_);
      END IF;
      Check_Codestring___ (reversal_rec_, user_group_);
      IF (reversal_rec_.optional_code IS NOT NULL) THEN
         IF (simulation_voucher_ = 'TRUE') THEN
            Error_SYS.Record_General('VoucherRow', 'SIMNOTAXCODE: It is not allowed to enter a Tax Code when using a Voucher Type defined as Simulation Voucher.');
         END IF;
      END IF;
      IF (simulation_voucher_ = 'FALSE') THEN
         IF (function_group_ IN ('M', 'Q')) THEN
            IF (reversal_rec_.optional_code IS NULL) THEN
               IF (Account_API.Is_Tax_Code_Mandatory(reversal_rec_.company, reversal_rec_.account)) THEN
                  Error_SYS.Record_General('VoucherRow', 'TAXCODEMAND: For Account :P1 it is mandatory to enter a Tax Code', reversal_rec_.account);
               END IF;
            END IF;
         END IF;
      END IF;
      IF (function_group_ IN ('Q')) THEN
         reversal_rec_.tax_base_amount := 0;
         reversal_rec_.currency_tax_base_amount := 0;
      END IF;
      reversal_rec_.rowkey := NULL;
      Insert___(objid_,
                objversion_,
                reversal_rec_,
                attr_);
      Internal_Manual_Postings___(reversal_rec_, TRUE);
      Prepare_Tax_Transaction___(reversal_rec_);
   END LOOP;
END Reverse_Voucher_Rows__;


@UncheckedAccess
FUNCTION Get_Codestring__ (
   company_              IN VARCHAR2,
   voucher_type_         IN VARCHAR2,
   accounting_year_      IN NUMBER,
   voucher_no_           IN NUMBER,
   row_no_               IN NUMBER ) RETURN VARCHAR2
IS 
   voucher_row_    VOUCHER_ROW_TAB%ROWTYPE;   
BEGIN
   voucher_row_ := Get_Row(company_, voucher_type_, accounting_year_, voucher_no_, row_no_);
   RETURN Get_Codestring___(voucher_row_);
END Get_Codestring__;


PROCEDURE Insert_Row__ (
   newrec_              IN OUT VOUCHER_ROW_TAB%ROWTYPE,
   create_project_conn_ IN      BOOLEAN DEFAULT TRUE)
IS
   attr_               VARCHAR2(2000);
   objversion_         VARCHAR2(2000);
   objid_              VARCHAR2(100);
   head_               Voucher_Api.Public_Rec;
   function_group_     VARCHAR2(20);            
   user_group_         user_group_member_finance_tab.user_group%TYPE;
   create_project_conn_str_ VARCHAR2(5);
BEGIN
   head_ := Voucher_API.Get( newrec_.company,
                             newrec_.accounting_year,
                             newrec_.voucher_type,
                             newrec_.voucher_no );
   function_group_     := head_.function_group;
   user_group_         := head_.user_group;
   IF (newrec_.voucher_date IS NULL) THEN
      newrec_.voucher_date := head_.voucher_date;
   END IF;
   Check_Codestring___ (newrec_,
                        user_group_);
   Check_Acquisition___(newrec_,
                        function_group_,
                        NULL);           -- fa_code_part
   Check_Project___ (newrec_,
                     function_group_ );
   -- Bug 109491, Rollback the bug correction 104365
   -- Bug 104365, Added check for function group E
   IF ((newrec_.optional_code  IS NOT NULL) AND 
      (upper(newrec_.trans_code) = 'EXTERNAL') AND
      (function_group_ IN ('I', 'J' ,'F'))) THEN
      Account_Tax_Code_API.Check_Tax_Code(newrec_.company, newrec_.account, newrec_.optional_code ); 
   END IF;
   -- Bug 104365, End
   -- Bug 109491, End
   -- Bug 125076, Begin
   IF (head_.simulation_voucher = 'FALSE') THEN
      IF (function_group_ IN ('M', 'Q')) THEN
         IF (newrec_.optional_code IS NULL) THEN
            IF (Account_API.Is_Tax_Code_Mandatory(newrec_.company, newrec_.account)) THEN
               Error_SYS.Record_General('VoucherRow', 'TAXCODEMAND: For Account :P1 it is mandatory to enter a Tax Code', newrec_.account);
            END IF;
         END IF;
      END IF;
   END IF;
   -- Bug 125076, End
   IF (create_project_conn_) THEN
      create_project_conn_str_ := 'TRUE';
   ELSE
      create_project_conn_str_ := 'FALSE';
   END IF;   
   Client_SYS.Add_To_Attr('CREATE_PROJ_CONN', create_project_conn_str_, attr_);
   newrec_.rowkey := NULL;
   Insert___(objid_,
             objversion_,
             newrec_,
             attr_);
$IF Component_Fixass_SYS.INSTALLED $THEN
   IF (newrec_.trans_code = 'FA CASH DISCOUNT' OR function_group_ = 'N') THEN
      Create_Add_Investment_Info___(newrec_);
   END IF;
$END
END Insert_Row__;


@UncheckedAccess
FUNCTION Get_Correction__ (
   amount_ IN NUMBER ) RETURN VARCHAR2
IS
BEGIN
   IF (amount_ >= 0) THEN
      RETURN('N');
   ELSE
      RETURN('Y');
   END IF;
END Get_Correction__;


@UncheckedAccess
FUNCTION Get_Correction_All__ (
   company_            IN VARCHAR2,
   voucher_type_       IN VARCHAR2,
   accounting_year_    IN NUMBER,
   voucher_no_         IN NUMBER,
   reference_row_no_   IN NUMBER,
   amount_             IN NUMBER,
   auto_tax_vou_entry_ IN VARCHAR2,
   parallel_amount_    IN NUMBER DEFAULT NULL ) RETURN VARCHAR2
IS
   correction_ref_no_  VARCHAR2(10);
   CURSOR get_correction IS
      SELECT correction
      FROM   VOUCHER_ROW
      WHERE  company          = company_
      AND    voucher_type     = voucher_type_
      AND    accounting_year  = accounting_year_
      AND    voucher_no       = voucher_no_
      AND    row_no           = reference_row_no_;
BEGIN
   IF amount_ IS NULL THEN
      RETURN('N');
   ELSIF (amount_ >= 0) THEN
      IF (amount_ = 0) THEN
         IF (auto_tax_vou_entry_ = 'TRUE') THEN
            -- Fetch correction for the referenced row no
            OPEN get_correction;
            FETCH get_correction INTO correction_ref_no_;
            CLOSE get_correction;
            IF (correction_ref_no_ = 'Y') THEN
               -- IF the referenced row no is a correction, the tax transaction
               -- connected to it also should be a correction.
               RETURN('Y');
            END IF;
         END IF;
         IF (NVL(parallel_amount_, 0) >= 0) THEN
            RETURN('N');
         ELSE
            RETURN('Y');
         END IF;
      END IF;
      RETURN('N');
   ELSE
      RETURN('Y');
   END IF;
END Get_Correction_All__;


PROCEDURE Create_Int_Manual_Postings__ (
   company_         IN VARCHAR2,
   voucher_type_    IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_      IN NUMBER,
   row_no_          IN NUMBER,
   from_pa_         IN BOOLEAN DEFAULT FALSE )
IS
   tmp_codestr_                  Accounting_codestr_API.CodestrRec;
   row_rec_                      VOUCHER_ROW_TAB%ROWTYPE;
   base_currency_code_           VARCHAR2(3);
   third_currency_code_          VARCHAR2(3);
   is_base_emu_                  VARCHAR2(5);
   is_third_emu_                 VARCHAR2(5);
   currency_amount_              VOUCHER_ROW.currency_amount%TYPE;
   amount_                       VOUCHER_ROW.amount%TYPE;
   voucher_date_                 DATE;
   temp_curr_tax_amount_         NUMBER;
   temp_tax_amount_              NUMBER;
   temp_amount_                  NUMBER;
   temp_currency_amount_         NUMBER;
   currency_debet_amount_        NUMBER;
   currency_credit_amount_       NUMBER;
   debet_amount_                 NUMBER;
   credit_amount_                NUMBER;
   third_currency_debit_amount_  NUMBER;
   third_currency_credit_amount_ NUMBER;
   currency_debet_amount_tot_    NUMBER;
   currency_credit_amount_tot_   NUMBER;
   debet_amount_tot_             NUMBER;
   credit_amount_tot_            NUMBER;
   third_curr_debit_amount_tot_  NUMBER;
   third_curr_credit_amount_tot_ NUMBER;
   count_                        NUMBER;
   base_curr_rounding_           NUMBER;
   trans_curr_rounding_          NUMBER;
   third_curr_rounding_          NUMBER;
   amount_method_                VARCHAR2(200);
   parallel_base_                VARCHAR2(25);

   CURSOR get_manual_rows IS
      SELECT *
      FROM   INTERNAL_POSTINGS_ACCRUL_TAB
      WHERE  company             = company_
      AND    internal_seq_number = row_rec_.internal_seq_number    
      ORDER BY row_no;

   CURSOR get_vou_row IS
      SELECT *
      FROM   VOUCHER_ROW_TAB
      WHERE  company          = company_
      AND    voucher_type     = voucher_type_
      AND    accounting_year  = accounting_year_
      AND    voucher_no       = voucher_no_
      AND    row_no           = row_no_
      ORDER BY row_no;

   comp_fin_rec_                 COMPANY_FINANCE_API.Public_Rec;
BEGIN
   OPEN  get_vou_row;
   FETCH get_vou_row INTO row_rec_;
   CLOSE get_vou_row;
   IF (row_rec_.voucher_date IS NOT NULL) THEN
      voucher_date_ := row_rec_.voucher_date;
   ELSE
      voucher_date_ := Voucher_API.Get_Voucher_Date(company_,
                                                    accounting_year_,
                                                    voucher_type_,
                                                    voucher_no_);
   END IF;
   amount_method_ := Voucher_API.Get_Amount_Method_Db (company_,
                                                    accounting_year_,
                                                    voucher_type_,
                                                    voucher_no_);
   tmp_codestr_.code_b           := row_rec_.code_b;
   tmp_codestr_.code_c           := row_rec_.code_c;
   tmp_codestr_.code_d           := row_rec_.code_d;
   tmp_codestr_.code_e           := row_rec_.code_e;
   tmp_codestr_.code_f           := row_rec_.code_f;
   tmp_codestr_.code_g           := row_rec_.code_g;
   tmp_codestr_.code_h           := row_rec_.code_h;
   tmp_codestr_.code_i           := row_rec_.code_i;
   tmp_codestr_.code_j           := row_rec_.code_j;
   temp_curr_tax_amount_         := row_rec_.currency_tax_amount;
   temp_tax_amount_              := row_rec_.tax_amount;
   temp_amount_                  := row_rec_.gross_amount;
   temp_currency_amount_         := row_rec_.currency_gross_amount;
   currency_debet_amount_        := row_rec_.currency_debet_amount;
   currency_credit_amount_       := row_rec_.currency_credit_amount;
   debet_amount_                 := row_rec_.debet_amount;
   credit_amount_                := row_rec_.credit_amount;
   third_currency_debit_amount_  := row_rec_.third_currency_debit_amount;
   third_currency_credit_amount_ := row_rec_.third_currency_credit_amount;
   count_                        := 0;
   currency_debet_amount_tot_    := 0;
   currency_credit_amount_tot_   := 0;
   debet_amount_tot_             := 0;
   credit_amount_tot_            := 0;
   third_curr_debit_amount_tot_  := 0;
   third_curr_credit_amount_tot_ := 0;
   base_currency_code_           := Company_Finance_API.Get_Currency_Code (company_);
   third_currency_code_          := Company_Finance_API.Get_Parallel_Acc_Currency (company_, voucher_date_);
   base_curr_rounding_           := Currency_Code_API.Get_currency_rounding (company_, base_currency_code_);
   is_base_emu_                  := Currency_Code_Api.Get_Valid_Emu (company_,
                                                                     base_currency_code_,
                                                                     voucher_date_);
   parallel_base_                := Company_Finance_API.Get_Parallel_Base_Db(company_);                                                        
   IF (row_rec_.currency_code = base_currency_code_) THEN
      trans_curr_rounding_       := base_curr_rounding_;
   ELSE
      trans_curr_rounding_       := Currency_Code_API.Get_currency_rounding (company_, row_rec_.currency_code);
   END IF;
   IF (third_currency_code_ IS NOT NULL) THEN
      third_curr_rounding_       := Currency_Code_API.Get_currency_rounding (company_, third_currency_code_);
      is_third_emu_              := Currency_Code_Api.Get_Valid_Emu (company_,
                                                                     third_currency_code_,
                                                                     voucher_date_);
   ELSE
      is_third_emu_              := 'FALSE';
   END IF;

   FOR rec_ IN get_manual_rows LOOP
      IF (NOT Check_Int_Vou_Row___(rec_)) THEN
         count_ := count_ + 1;
         row_rec_.account := rec_.account;
         row_rec_.code_b  := NVL(rec_.code_b, tmp_codestr_.code_b);
         row_rec_.code_c  := NVL(rec_.code_c, tmp_codestr_.code_c);
         row_rec_.code_d  := NVL(rec_.code_d, tmp_codestr_.code_d);
         row_rec_.code_e  := NVL(rec_.code_e, tmp_codestr_.code_e);
         row_rec_.code_f  := NVL(rec_.code_f, tmp_codestr_.code_f);
         row_rec_.code_g  := NVL(rec_.code_g, tmp_codestr_.code_g);
         row_rec_.code_h  := NVL(rec_.code_h, tmp_codestr_.code_h);
         row_rec_.code_i  := NVL(rec_.code_i, tmp_codestr_.code_i);
         row_rec_.code_j  := NVL(rec_.code_j, tmp_codestr_.code_j);
         IF (rec_.text IS NOT NULL) THEN
            row_rec_.text := rec_.text;
         END IF;

         amount_                          := nvl(rec_.debit_amount,-rec_.credit_amount);
         currency_amount_                 := nvl(rec_.currency_debit_amount,-rec_.currency_credit_amount);
         row_rec_.debet_amount            := rec_.debit_amount;
         row_rec_.credit_amount           := rec_.credit_amount;
         row_rec_.currency_debet_amount   := rec_.currency_debit_amount;
         row_rec_.currency_credit_amount  := rec_.currency_credit_amount;
         row_rec_.currency_tax_amount     := ROUND((temp_curr_tax_amount_*ROUND((currency_amount_/temp_currency_amount_),trans_curr_rounding_)),trans_curr_rounding_);
         row_rec_.tax_amount              := ROUND((temp_tax_amount_*ROUND((amount_/temp_amount_),base_curr_rounding_)),base_curr_rounding_);


         IF (row_rec_.conversion_factor IS NULL) THEN
            row_rec_.conversion_factor := Currency_Code_Api.Get_Conversion_Factor(rec_.company, row_rec_.currency_code);
         END IF;
         IF (third_currency_code_ IS NOT NULL) THEN
            IF (rec_.debit_amount IS NOT NULL) THEN
               row_rec_.third_currency_debit_amount := Currency_Amount_API.Calculate_Parallel_Curr_Amount(row_rec_.company,
                                                                voucher_date_,
                                                                rec_.debit_amount,
                                                                row_rec_.currency_debet_amount, 
                                                                base_currency_code_,
                                                                row_rec_.currency_code,
                                                                row_rec_.parallel_curr_rate_type,
                                                                third_currency_code_,
                                                                parallel_base_,
                                                                is_base_emu_,
                                                                is_third_emu_);
            END IF;
            IF (rec_.credit_amount IS NOT NULL) THEN
                row_rec_.third_currency_credit_amount := Currency_Amount_API.Calculate_Parallel_Curr_Amount(row_rec_.company,
                                                                voucher_date_, 
                                                                rec_.credit_amount,
                                                                row_rec_.currency_credit_amount,
                                                                base_currency_code_, 
                                                                row_rec_.currency_code,
                                                                row_rec_.parallel_curr_rate_type,
                                                                third_currency_code_,
                                                                parallel_base_,
                                                                is_base_emu_,
                                                                is_third_emu_);
            END IF;
         END IF;
         currency_debet_amount_tot_    := currency_debet_amount_tot_ + ROUND(row_rec_.currency_debet_amount,trans_curr_rounding_);
         currency_credit_amount_tot_   := currency_credit_amount_tot_ + ROUND(row_rec_.currency_credit_amount,trans_curr_rounding_);
         debet_amount_tot_             := debet_amount_tot_ + ROUND(row_rec_.debet_amount,base_curr_rounding_);
         credit_amount_tot_            := credit_amount_tot_ + ROUND(row_rec_.credit_amount,base_curr_rounding_);
         third_curr_debit_amount_tot_  := third_curr_debit_amount_tot_ + ROUND(row_rec_.third_currency_debit_amount,third_curr_rounding_);
         third_curr_credit_amount_tot_ := third_curr_credit_amount_tot_ + ROUND(row_rec_.third_currency_credit_amount,third_curr_rounding_);
         Calculate_Net_From_Gross (row_rec_,
                                   amount_method_,
                                   third_currency_code_,
                                   is_third_emu_,        
                                   base_currency_code_,  
                                   is_base_emu_);        
         Error_SYS.Check_Not_Null(lu_name_, 'COMPANY', row_rec_.company);
         Error_SYS.Check_Not_Null(lu_name_, 'VOUCHER_TYPE', row_rec_.voucher_type);
         Error_SYS.Check_Not_Null(lu_name_, 'ACCOUNTING_YEAR', row_rec_.accounting_year);
         Error_SYS.Check_Not_Null(lu_name_, 'VOUCHER_NO', row_rec_.voucher_no);
         Error_SYS.Check_Not_Null(lu_name_, 'ACCOUNT', row_rec_.account);
         Error_SYS.Check_Not_Null(lu_name_, 'ACCOUNTING_PERIOD', row_rec_.accounting_period);
         IF (from_pa_) THEN
            $IF Component_Intled_SYS.INSTALLED $THEN
               Internal_Voucher_Util_Pub_API.Create_Pa_Internal_Row (row_rec_,
                                                                     rec_.ledger_id,
                                                                     base_curr_rounding_,   
                                                                     trans_curr_rounding_,  
                                                                     third_curr_rounding_); 
            $ELSE
               NULL;
            $END
         ELSE
            IF (Voucher_Type_Detail_API.Get_Function_Group(rec_.company, rec_.voucher_type) = 'R') THEN
               comp_fin_rec_        := Company_Finance_API.Get (row_rec_.company);
               IF (comp_fin_rec_.correction_type = 'REVERSE') THEN
                  currency_debet_amount_                 := row_rec_.currency_debet_amount;
                  currency_credit_amount_                := row_rec_.currency_credit_amount;
                  debet_amount_                          := row_rec_.debet_amount;
                  credit_amount_                         := row_rec_.credit_amount;
                  IF (currency_credit_amount_ IS NULL) THEN
                     third_currency_credit_amount_ := NULL;
                     third_currency_debit_amount_  := row_rec_.third_currency_debit_amount;
                  ELSE
                     third_currency_credit_amount_ := row_rec_.third_currency_credit_amount;
                     third_currency_debit_amount_  := NULL;
                  END IF;
                  row_rec_.currency_debet_amount         := currency_credit_amount_;
                  row_rec_.currency_credit_amount        := currency_debet_amount_;
                  row_rec_.debet_amount                  := credit_amount_;
                  row_rec_.credit_amount                 := debet_amount_;
                  row_rec_.third_currency_debit_amount   := third_currency_credit_amount_;
                  row_rec_.third_currency_credit_amount  := third_currency_debit_amount_;
               ELSE
                  row_rec_.currency_debet_amount         := -row_rec_.currency_debet_amount;
                  row_rec_.currency_credit_amount        := -row_rec_.currency_credit_amount;
                  row_rec_.debet_amount                  := -row_rec_.debet_amount;
                  row_rec_.credit_amount                 := -row_rec_.credit_amount;
                  row_rec_.third_currency_debit_amount   := -row_rec_.third_currency_debit_amount;
                  row_rec_.third_currency_credit_amount  := -row_rec_.third_currency_credit_amount;
               END IF;
            END IF;
            $IF Component_Intled_SYS.INSTALLED $THEN
               Internal_Voucher_Util_Pub_API.Create_Internal_Row (rec_.ledger_id,
                                                                  row_rec_,
                                                                  base_curr_rounding_,
                                                                  trans_curr_rounding_,
                                                                  third_curr_rounding_);
            $END
         END IF;
      END IF;
   END LOOP;
END Create_Int_Manual_Postings__;


@SecurityCheck Company.UserAuthorized(company_)
PROCEDURE Set_Row_Data__(
   company_          IN VARCHAR2,
   voucher_type_     IN VARCHAR2,
   voucher_no_       IN NUMBER,
   accounting_year_  IN NUMBER,
   row_no_           IN NUMBER,
   reference_serie_  IN VARCHAR2,
   reference_number_ IN VARCHAR2,
   row_group_id_     IN NUMBER)
IS
BEGIN
   UPDATE VOUCHER_ROW_TAB
   SET    reference_serie  = reference_serie_,
          reference_number = reference_number_,
          row_group_id     = row_group_id_
   WHERE  company         = company_
   AND    voucher_type    = voucher_type_
   AND    voucher_no      = voucher_no_
   AND    accounting_year = accounting_year_
   AND    row_no          = row_no_;
END Set_Row_Data__;

-- Bug 127926,begin.
PROCEDURE Update_Vou_Row_Acc_Period__( 
   company_          IN VARCHAR2,
   accounting_year_  IN NUMBER,
   voucher_no_       IN NUMBER,
   voucher_type_     IN VARCHAR2,
   new_acc_period_   IN NUMBER)  
IS   
BEGIN
   IF new_acc_period_ IS NOT NULL THEN
      UPDATE voucher_row_tab
      SET accounting_period = new_acc_period_
      WHERE company         = company_
      AND accounting_year   = accounting_year_
      AND voucher_no        = voucher_no_
      AND voucher_type      = voucher_type_
      AND accounting_period != new_acc_period_;
   END IF;
END Update_Vou_Row_Acc_Period__;
-- Bug 127926,end.

-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

PROCEDURE Create_Object_Connection_(
   company_              IN VARCHAR2,
   voucher_type_         IN VARCHAR2,
   accounting_year_      IN NUMBER,
   voucher_no_           IN NUMBER,
   row_no_               IN NUMBER,
   account_              IN VARCHAR2,
   debet_amount_         IN NUMBER,
   credit_amount_        IN NUMBER,
   text_                 IN VARCHAR2,
   trans_code_           IN VARCHAR2,
   project_activity_id_  IN NUMBER,
   voucher_date_         IN DATE DEFAULT NULL,
   code_b_               IN VARCHAR2 DEFAULT NULL,
   code_c_               IN VARCHAR2 DEFAULT NULL,
   code_d_               IN VARCHAR2 DEFAULT NULL,
   code_e_               IN VARCHAR2 DEFAULT NULL,
   code_f_               IN VARCHAR2 DEFAULT NULL,   
   code_g_               IN VARCHAR2 DEFAULT NULL,            
   code_h_               IN VARCHAR2 DEFAULT NULL,
   code_i_               IN VARCHAR2 DEFAULT NULL,
   code_j_               IN VARCHAR2 DEFAULT NULL,
   currency_code_          IN VARCHAR2 DEFAULT NULL,
   currency_debet_amount_  IN NUMBER   DEFAULT NULL,
   currency_credit_amount_ IN NUMBER   DEFAULT NULL)
IS
   vourow_rec_      voucher_row_tab%ROWTYPE;
BEGIN
   
   vourow_rec_.company             := company_;
   vourow_rec_.voucher_type        := voucher_type_;
   vourow_rec_.accounting_year     := accounting_year_;
   vourow_rec_.voucher_no          := voucher_no_;
   vourow_rec_.row_no              := row_no_;
   vourow_rec_.account             := account_;
   vourow_rec_.debet_amount        := debet_amount_;
   vourow_rec_.credit_amount       := credit_amount_;
   vourow_rec_.text                := text_;
   vourow_rec_.trans_code          := trans_code_;
   vourow_rec_.project_activity_id := project_activity_id_;   
   vourow_rec_.voucher_date        := voucher_date_;
   vourow_rec_.code_b              := code_b_;
   vourow_rec_.code_c              := code_c_;
   vourow_rec_.code_d              := code_d_;
   vourow_rec_.code_e              := code_e_;
   vourow_rec_.code_f              := code_f_;
   vourow_rec_.code_g              := code_g_;
   vourow_rec_.code_h              := code_h_;
   vourow_rec_.code_i              := code_i_;
   vourow_rec_.code_j              := code_j_;   
   vourow_rec_.currency_code           := currency_code_;
   vourow_rec_.currency_debet_amount   := currency_debet_amount_;
   vourow_rec_.currency_credit_amount  := currency_credit_amount_;


   Create_Object_Connection___(vourow_rec_);
END Create_Object_Connection_;


PROCEDURE Add_New_Row_ (
   voucher_row_rec_     IN OUT Voucher_API.VoucherRowRecType,
   vou_row_attr_        OUT    VARCHAR2,
   base_currency_code_  IN     VARCHAR2,
   base_curr_rounding_  IN     NUMBER,
   is_base_emu_         IN     VARCHAR2,
   trans_curr_rounding_ IN     NUMBER,
   third_curr_rounding_ IN     NUMBER,
   is_third_emu_        IN     VARCHAR2,
   fa_code_part_        IN     VARCHAR2,
   project_code_part_   IN     VARCHAR2,
   create_project_conn_ IN     BOOLEAN DEFAULT TRUE )
IS
   newrec_                       VOUCHER_ROW_TAB%ROWTYPE;
   attr_                         VARCHAR2(2000);
   objversion_                   VARCHAR2(2000);
   objid_                        VARCHAR2(100);
   user_group_                   user_group_member_finance_tab.user_group%TYPE;
   third_currency_codex_         VARCHAR2(3);  
   is_third_emux_                VARCHAR2(5);  
   third_currency_debit_amount_  NUMBER;
   third_currency_credit_amount_ NUMBER;
   currency_amount_              VOUCHER_ROW.currency_amount%TYPE;
   amount_                       VOUCHER_ROW.amount%TYPE;
   correction_                   VOUCHER_ROW.correction%TYPE;
   function_group_               VARCHAR2(10);
   head_                         Voucher_Api.Public_Rec;
   curr_balance_                 VARCHAR2(1);
   inverted_rate_                VARCHAR2(5);
   parallel_amount_              NUMBER;
   acc_amount_                   NUMBER;
   trans_amount_                 NUMBER;
   compfin_rec_                  Company_Finance_API.Public_Rec;
   create_project_conn_str_ VARCHAR2(5);
BEGIN
   head_ := Voucher_API.Get( voucher_row_rec_.company,
                             voucher_row_rec_.accounting_year,
                             voucher_row_rec_.voucher_type,
                             voucher_row_rec_.voucher_no );
   function_group_     := head_.function_group;
   user_group_         := head_.user_group;
   IF (voucher_row_rec_.voucher_date IS NULL) THEN
      voucher_row_rec_.voucher_date := head_.voucher_date;
   END IF;
   newrec_.company                      := voucher_row_rec_.company;
   newrec_.voucher_type                 := voucher_row_rec_.voucher_type;
   newrec_.accounting_year              := voucher_row_rec_.accounting_year;
   newrec_.accounting_period            := voucher_row_rec_.accounting_period;
   newrec_.voucher_no                   := voucher_row_rec_.voucher_no;
   newrec_.voucher_date                 := voucher_row_rec_.voucher_date;
   newrec_.row_no                       := voucher_row_rec_.row_no;
   newrec_.row_group_id                 := voucher_row_rec_.row_group_id;
   newrec_.account                      := voucher_row_rec_.codestring_rec.code_a;
   newrec_.code_b                       := voucher_row_rec_.codestring_rec.code_b;
   newrec_.code_c                       := voucher_row_rec_.codestring_rec.code_c;
   newrec_.code_d                       := voucher_row_rec_.codestring_rec.code_d;
   newrec_.code_e                       := voucher_row_rec_.codestring_rec.code_e;
   newrec_.code_f                       := voucher_row_rec_.codestring_rec.code_f;
   newrec_.code_g                       := voucher_row_rec_.codestring_rec.code_g;
   newrec_.code_h                       := voucher_row_rec_.codestring_rec.code_h;
   newrec_.code_i                       := voucher_row_rec_.codestring_rec.code_i;
   newrec_.code_j                       := voucher_row_rec_.codestring_rec.code_j;
   newrec_.internal_seq_number          := voucher_row_rec_.internal_seq_number;
   newrec_.currency_debet_amount        := voucher_row_rec_.currency_debet_amount;
   newrec_.currency_credit_amount       := voucher_row_rec_.currency_credit_amount;
   newrec_.debet_amount                 := voucher_row_rec_.debet_amount;
   newrec_.credit_amount                := voucher_row_rec_.credit_amount;
   newrec_.currency_code                := voucher_row_rec_.currency_code;
   newrec_.quantity                     := voucher_row_rec_.quantity;
   newrec_.process_code                 := voucher_row_rec_.process_code;
   newrec_.optional_code                := voucher_row_rec_.optional_code;
   newrec_.project_activity_id          := voucher_row_rec_.project_activity_id;
   newrec_.text                         := voucher_row_rec_.text;
   newrec_.party_type_id                := voucher_row_rec_.party_type_id;
   newrec_.reference_serie              := voucher_row_rec_.reference_serie;
   newrec_.reference_number             := voucher_row_rec_.reference_number;
   newrec_.trans_code                   := voucher_row_rec_.trans_code;
   newrec_.update_error                 := voucher_row_rec_.update_error;
   newrec_.transfer_id                  := voucher_row_rec_.transfer_id;
   newrec_.corrected                    := NVL( voucher_row_rec_.corrected, 'N' );
   newrec_.third_currency_debit_amount  := voucher_row_rec_.third_currency_debit_amount;
   newrec_.third_currency_credit_amount := voucher_row_rec_.third_currency_credit_amount;
   newrec_.currency_rate                := voucher_row_rec_.currency_rate;
   amount_                              := voucher_row_rec_.amount;
   currency_amount_                     := voucher_row_rec_.currency_amount;
   correction_                          := voucher_row_rec_.correction;
   newrec_.auto_tax_vou_entry           := voucher_row_rec_.auto_tax_vou_entry;
   newrec_.tax_direction                := voucher_row_rec_.tax_direction;
   newrec_.tax_base_amount              := voucher_row_rec_.tax_base_amount;
   newrec_.currency_tax_base_amount     := voucher_row_rec_.currency_tax_base_amount;
   newrec_.reference_version            := voucher_row_rec_.reference_version;
   newrec_.party_type                   := voucher_row_rec_.party_type;
   newrec_.mpccom_accounting_id         := voucher_row_rec_.mpccom_accounting_id;
   newrec_.currency_type                := voucher_row_rec_.currency_type; 
   newrec_.activate_code                := voucher_row_rec_.activate_code;
   newrec_.parallel_currency_rate       := voucher_row_rec_.parallel_currency_rate;
   newrec_.parallel_conversion_factor   := voucher_row_rec_.parallel_curr_conv_fac;
   newrec_.parallel_curr_rate_type      := voucher_row_rec_.parallel_curr_rate_type;
   newrec_.deliv_type_id                := voucher_row_rec_.deliv_type_id;

   IF (newrec_.currency_debet_amount IS NULL) THEN
      newrec_.currency_debet_amount := newrec_.debet_amount;
   END IF;
   IF (newrec_.currency_credit_amount IS NULL) THEN
      newrec_.currency_credit_amount := newrec_.credit_amount;
   END IF;
   Accounting_Code_Part_A_API.Get_Curr_Balance(curr_balance_,
                                               voucher_row_rec_.company,
                                               voucher_row_rec_.codestring_rec.code_a );
   IF (nvl(amount_, 0) = 0) THEN
      amount_ := nvl(newrec_.debet_amount, 0) - nvl(newrec_.credit_amount,0);
   END IF;
   IF currency_amount_ IS NULL THEN
      currency_amount_ := nvl(newrec_.currency_debet_amount, 0) - nvl(newrec_.currency_credit_amount,0);
   END IF;
   IF ( newrec_.currency_rate IS NULL) THEN
      Currency_Amount_API.Calc_Currency_Rate (newrec_.currency_rate,
                                              voucher_row_rec_.company,
                                              voucher_row_rec_.currency_code,
                                              amount_,
                                              currency_amount_,
                                              base_currency_code_ );
   END IF;
   newrec_.conversion_factor     := Currency_Code_Api.Get_Conversion_Factor (voucher_row_rec_.company, voucher_row_rec_.currency_code);
   newrec_.multi_company_id      := voucher_row_rec_.multi_company_id;

   IF (NVL(correction_,'N') != 'Y') THEN
      correction_ := 'N';
   ELSE
      correction_ := 'Y';
   END IF;
   Check_And_Set_Amounts___ (newrec_,
                             currency_amount_,
                             amount_,
                             correction_);

   -- Parallel Currency handling
   
   compfin_rec_ := Company_Finance_API.Get(newrec_.company);
   third_currency_codex_ := Company_Finance_API.Get_Parallel_Acc_Currency(newrec_.company, newrec_.voucher_date);
   IF (third_currency_codex_ IS NOT NULL) THEN
      IF (is_third_emu_ IS NULL) THEN
         is_third_emux_ := Currency_Code_API.Get_Valid_Emu(newrec_.company,
                                                           third_currency_codex_,
                                                           newrec_.voucher_date);
      ELSE
         is_third_emux_ := is_third_emu_;
      END IF;

      third_currency_debit_amount_  := newrec_.third_currency_debit_amount;
      third_currency_credit_amount_ := newrec_.third_currency_credit_amount;

      -- IF the parallel currency amounts are not given then fetch the rate, conversion factor and rate type from basic data. Amounts will be calculated further down.
      -- IF the parallel currency amounts are given but not rate and conversion factor then calculate that data (although it should have been supplied by the calling method)
      IF (newrec_.third_currency_debit_amount IS NULL AND newrec_.third_currency_credit_amount IS NULL) THEN
         newrec_.parallel_curr_rate_type := compfin_rec_.parallel_rate_type;
         Currency_Rate_API.Get_Parallel_Currency_Rate(newrec_.parallel_currency_rate,
                                                      newrec_.parallel_conversion_factor,
                                                      inverted_rate_,
                                                      newrec_.company,
                                                      newrec_.currency_code,
                                                      newrec_.voucher_date,
                                                      newrec_.parallel_curr_rate_type,
                                                      compfin_rec_.parallel_base,
                                                      base_currency_code_,
                                                      third_currency_codex_,
                                                      is_base_emu_,
                                                      is_third_emux_);
      ELSE
         -- if rate is null then fetch conversion factor and inverted flag then calculate the rate. IF rate is not null then 
         -- assume that factor and rate type is given as well.
         IF (newrec_.parallel_currency_rate IS NULL) THEN
            newrec_.parallel_curr_rate_type := compfin_rec_.parallel_rate_type;
            IF (newrec_.third_currency_debit_amount IS NOT NULL) THEN
               parallel_amount_ := newrec_.third_currency_debit_amount;
               acc_amount_      := newrec_.debet_amount;
               trans_amount_    := newrec_.currency_debet_amount;
            ELSE
               parallel_amount_ := newrec_.third_currency_credit_amount;
               acc_amount_      := newrec_.credit_amount;
               trans_amount_    := newrec_.currency_credit_amount;
            END IF;
            newrec_.parallel_currency_rate := Currency_Amount_API.Calculate_Parallel_Curr_Rate(newrec_.company,
                                                                                               newrec_.voucher_date,
                                                                                               acc_amount_,
                                                                                               trans_amount_,
                                                                                               parallel_amount_,
                                                                                               base_currency_code_,
                                                                                               newrec_.currency_code,
                                                                                               third_currency_codex_,
                                                                                               compfin_rec_.parallel_base,
                                                                                               newrec_.parallel_curr_rate_type);

            newrec_.parallel_conversion_factor := Currency_Rate_API.Get_Par_Curr_Rate_Conv_Factor(newrec_.company,
                                                                                                  newrec_.currency_code,
                                                                                                  newrec_.voucher_date,
                                                                                                  base_currency_code_,
                                                                                                  third_currency_codex_,
                                                                                                  compfin_rec_.parallel_base,
                                                                                                  newrec_.parallel_curr_rate_type);
         ELSE
            -- Make sure that rate type is set
            IF (newrec_.parallel_curr_rate_type IS NULL) THEN
               newrec_.parallel_curr_rate_type := compfin_rec_.parallel_rate_type;
            END IF;
         END IF;
      END IF;

      newrec_.parallel_curr_tax_amount     := voucher_row_rec_.parallel_curr_tax_amt;
      newrec_.parallel_curr_gross_amount   := voucher_row_rec_.parallel_curr_gross_amt;
      newrec_.parallel_curr_tax_base_amount:= voucher_row_rec_.parallel_curr_tax_base_amt;

      IF ((newrec_.debet_amount IS NOT NULL) AND
          (newrec_.third_currency_debit_amount IS NULL)) THEN

         third_currency_debit_amount_ := Currency_Amount_API.Calculate_Parallel_Curr_Amount(newrec_.company,
                                                                                            newrec_.voucher_date,
                                                                                            newrec_.debet_amount,
                                                                                            newrec_.currency_debet_amount,
                                                                                            base_currency_code_,
                                                                                            newrec_.currency_code, 
                                                                                            newrec_.parallel_curr_rate_type,
                                                                                            third_currency_codex_,
                                                                                            compfin_rec_.parallel_base,
                                                                                            is_base_emu_,
                                                                                            is_third_emux_);
   
         newrec_.third_currency_debit_amount := NVL(third_currency_debit_amount_,0);
      END IF;
      IF ((newrec_.credit_amount IS NOT NULL) AND
          (newrec_.third_currency_credit_amount IS NULL)) THEN

         third_currency_credit_amount_ := Currency_Amount_API.Calculate_Parallel_Curr_Amount(newrec_.company,
                                                                                             newrec_.voucher_date,
                                                                                             newrec_.credit_amount,
                                                                                             newrec_.currency_credit_amount,
                                                                                             base_currency_code_,
                                                                                             newrec_.currency_code, 
                                                                                             newrec_.parallel_curr_rate_type,
                                                                                             third_currency_codex_,
                                                                                             compfin_rec_.parallel_base,
                                                                                             is_base_emu_,
                                                                                             is_third_emux_);
   
         newrec_.third_currency_credit_amount := NVL(third_currency_credit_amount_,0);
      END IF;
   ELSE
      -- if parallel currency is not used then set amounts to null
      newrec_.third_currency_debit_amount := NULL;
      newrec_.third_currency_credit_amount := NULL;
   END IF;
   
   Error_SYS.Check_Not_Null(lu_name_, 'COMPANY', newrec_.company);
   Error_SYS.Check_Not_Null(lu_name_, 'VOUCHER_TYPE', newrec_.voucher_type);
   Error_SYS.Check_Not_Null(lu_name_, 'ACCOUNTING_YEAR', newrec_.accounting_year);
   Error_SYS.Check_Not_Null(lu_name_, 'VOUCHER_NO', newrec_.voucher_no);
   Error_SYS.Check_Not_Null(lu_name_, 'ACCOUNT', newrec_.account);
   Error_SYS.Check_Not_Null(lu_name_, 'ACCOUNTING_PERIOD', newrec_.accounting_period);

   IF (NVL(voucher_row_rec_.ext_validate_codestr,'X') != 'E') THEN
      IF (voucher_row_rec_.revenue_cost_clear_voucher = 'TRUE') THEN
         Check_Codestring___ (newrec_                  => newrec_,
                              user_groupx_             => user_group_,
                              check_codeparts_         => TRUE,
                              check_demands_codeparts_ => FALSE,
                              check_demands_quantity_  => FALSE,
                              check_demands_process_   => FALSE,
                              check_demands_text_      => FALSE);
      ELSIF (function_group_ != 'YE') THEN
         Check_Codestring___ (newrec_,
                              user_group_);
      END IF;                       
   END IF;
   IF (function_group_ NOT IN ( 'A', 'Q', 'YE' )) THEN
      Check_Acquisition___(newrec_,
                           function_group_,
                           fa_code_part_);
   END IF;
   IF (function_group_ NOT IN ('YE', 'P', 'PPC'))THEN
      Check_Project___ (newrec_, function_group_ );
   END IF;
   -- Execute check_project__() for Project completion and avoid executing for revenue recognition vouchers.
   IF (function_group_ IN ('P', 'PPC') AND newrec_.project_activity_id = -123456) THEN
      Check_Project___ (newrec_, function_group_ );
   END IF;                                  
   newrec_.currency_debet_amount        := ROUND(newrec_.currency_debet_amount, trans_curr_rounding_);
   newrec_.currency_credit_amount       := ROUND(newrec_.currency_credit_amount, trans_curr_rounding_);
   newrec_.debet_amount                 := ROUND(newrec_.debet_amount, base_curr_rounding_);
   newrec_.credit_amount                := ROUND(newrec_.credit_amount, base_curr_rounding_);

   IF (third_currency_codex_ IS NOT NULL) THEN
      IF (newrec_.third_currency_debit_amount <> 0) THEN
         newrec_.third_currency_debit_amount  := ROUND(newrec_.third_currency_debit_amount, third_curr_rounding_);
      END IF;
      IF (newrec_.third_currency_credit_amount <> 0) THEN
         newrec_.third_currency_credit_amount := ROUND(newrec_.third_currency_credit_amount, third_curr_rounding_);
      END IF;
   END IF;
   -- these values never seems to be assigned to the newrec record, should they be removed or assign from record? 2012-12-14
   newrec_.tax_amount                   := ROUND(newrec_.tax_amount, base_curr_rounding_);
   newrec_.currency_tax_amount          := ROUND(newrec_.currency_tax_amount, trans_curr_rounding_);
   newrec_.gross_amount                 := ROUND(newrec_.gross_amount, base_curr_rounding_);
   newrec_.currency_gross_amount        := ROUND(newrec_.currency_gross_amount, trans_curr_rounding_);
   newrec_.tax_base_amount              := ROUND(newrec_.tax_base_amount, base_curr_rounding_);
   newrec_.currency_tax_base_amount     := ROUND(newrec_.currency_tax_base_amount, trans_curr_rounding_);
   -- Send ROUNDED,TRUE to tell Insert___ the amounts are already rounded
   Client_SYS.Clear_Attr(attr_);
   Client_SYS.Add_To_Attr( 'ROUNDED','TRUE',  attr_);
   IF (create_project_conn_) THEN
      create_project_conn_str_ := 'TRUE';
   ELSE
      create_project_conn_str_ := 'FALSE';
   END IF;     
   Client_SYS.Add_To_Attr('CREATE_PROJ_CONN', create_project_conn_str_, attr_);
   newrec_.rowkey := NULL;
   Insert___ (objid_,
              objversion_,
              newrec_,
              attr_);
   voucher_row_rec_.row_no := newrec_.row_no;
   Internal_Manual_Postings___ ( newrec_,
                                 TRUE,
                                 base_curr_rounding_,
                                 trans_curr_rounding_,    
                                 third_curr_rounding_ ); 
$IF Component_Fixass_SYS.INSTALLED $THEN
   IF (function_group_ NOT IN ( 'A', 'Q', 'YE' )) THEN
      Create_Add_Investment_Info___(newrec_);
   END IF;
$END
END Add_New_Row_;


PROCEDURE Add_New_Row_ (
   voucher_row_rec_     IN OUT Voucher_API.VoucherRowRecType,
   vou_row_attr_        OUT    VARCHAR2,
   create_project_conn_ IN     BOOLEAN DEFAULT TRUE )
IS
   project_code_part_          VARCHAR2(1);
   fa_code_part_               VARCHAR2(1);            
   base_currency_code_         VARCHAR2(3);
   third_currency_code_        VARCHAR2(3);
   is_base_emu_                VARCHAR2(5);
   is_third_emu_               VARCHAR2(5);
   voucher_date_               DATE;
   base_curr_rounding_         NUMBER;
   trans_curr_rounding_        NUMBER;
   third_curr_rounding_        NUMBER;
BEGIN
   IF (voucher_row_rec_.voucher_date IS NOT NULL) THEN
      voucher_date_ := voucher_row_rec_.voucher_date;
   ELSE
      Voucher_API.Get_Voucher_Date ( voucher_date_,
                                     voucher_row_rec_.company,
                                     voucher_row_rec_.voucher_type,
                                     voucher_row_rec_.accounting_year,
                                     voucher_row_rec_.voucher_no);
   END IF;
   project_code_part_ := Accounting_Code_Parts_Api.Get_Codepart_Function (voucher_row_rec_.company, 'PRACC');
   fa_code_part_ := Accounting_Code_Parts_Api.Get_Codepart_Function (voucher_row_rec_.company, 'FAACC');
   base_currency_code_  := Company_Finance_Api.Get_Currency_Code (voucher_row_rec_.company);
   is_base_emu_ := Currency_Code_Api.Get_Valid_Emu (voucher_row_rec_.company,
                                                    base_currency_code_,
                                                    voucher_date_);
   base_curr_rounding_  := Currency_Code_API.Get_currency_rounding (voucher_row_rec_.company, base_currency_code_);
   third_currency_code_ := Company_Finance_Api.Get_Parallel_Acc_Currency (voucher_row_rec_.company, voucher_date_);
   IF (voucher_row_rec_.currency_code = base_currency_code_) THEN
      trans_curr_rounding_ := base_curr_rounding_;
   ELSE
      trans_curr_rounding_ := Currency_Code_API.Get_currency_rounding (voucher_row_rec_.company, voucher_row_rec_.currency_code);
   END IF;
   IF (third_currency_code_ IS NOT NULL) THEN
      IF (third_currency_code_ = base_currency_code_) THEN
         third_curr_rounding_ := base_curr_rounding_;
      ELSIF (third_currency_code_ = voucher_row_rec_.currency_code) THEN
         third_curr_rounding_ := trans_curr_rounding_;
      ELSE
         third_curr_rounding_ := Currency_Code_API.Get_currency_rounding (voucher_row_rec_.company, third_currency_code_);
      END IF;
      is_third_emu_           := Currency_Code_Api.Get_Valid_Emu (voucher_row_rec_.company,
                                                                  third_currency_code_,
                                                                  voucher_date_);
   ELSE
      is_third_emu_           := 'FALSE';
   END IF;
   Add_New_Row_ ( voucher_row_rec_,
                  vou_row_attr_,
                  base_currency_code_,
                  base_curr_rounding_,
                  is_base_emu_,
                  trans_curr_rounding_,  -- Misc performance
                  third_curr_rounding_,  
                  is_third_emu_,         
                  fa_code_part_,
                  project_code_part_,
                  create_project_conn_ ); 
END Add_New_Row_;


PROCEDURE Modify_Row_ (
   info_       OUT    VARCHAR2,
   objversion_ IN OUT VARCHAR2,
   attr_       IN OUT VARCHAR2,
   objid_      IN     VARCHAR2,
   action_     IN     VARCHAR2 )
IS
BEGIN
   Modify__ ( info_, objid_, objversion_, attr_, 'DO');
END Modify_Row_;


PROCEDURE Create_Cancel_Row_ (
   voucher_row_rec_           IN OUT Voucher_Api.VoucherRowRecType )
IS
   row_rec_     VOUCHER_ROW_TAB%ROWTYPE;
BEGIN

   row_rec_.accounting_period            := voucher_row_rec_.accounting_period;
   row_rec_.company                      := voucher_row_rec_.company;
   row_rec_.voucher_type                 := voucher_row_rec_.voucher_type;
   row_rec_.accounting_year              := voucher_row_rec_.accounting_year;
   row_rec_.voucher_no                   := voucher_row_rec_.voucher_no;
   row_rec_.account                      := voucher_row_rec_.codestring_rec.code_a;
   row_rec_.code_b                       := voucher_row_rec_.codestring_rec.code_b;
   row_rec_.code_c                       := voucher_row_rec_.codestring_rec.code_c;
   row_rec_.code_d                       := voucher_row_rec_.codestring_rec.code_d;
   row_rec_.code_e                       := voucher_row_rec_.codestring_rec.code_e;
   row_rec_.code_f                       := voucher_row_rec_.codestring_rec.code_f;
   row_rec_.code_g                       := voucher_row_rec_.codestring_rec.code_g;
   row_rec_.code_h                       := voucher_row_rec_.codestring_rec.code_h;
   row_rec_.code_i                       := voucher_row_rec_.codestring_rec.code_i;
   row_rec_.code_j                       := voucher_row_rec_.codestring_rec.code_j;
   row_rec_.currency_debet_amount        := voucher_row_rec_.currency_debet_amount;
   row_rec_.currency_credit_amount       := voucher_row_rec_.currency_credit_amount;
   row_rec_.debet_amount                 := voucher_row_rec_.debet_amount;
   row_rec_.credit_amount                := voucher_row_rec_.credit_amount;
   row_rec_.third_currency_debit_amount  := voucher_row_rec_.third_currency_debit_amount;
   row_rec_.third_currency_credit_amount := voucher_row_rec_.third_currency_credit_amount;
   row_rec_.currency_code                := voucher_row_rec_.currency_code;
   row_rec_.quantity                     := voucher_row_rec_.quantity;
   row_rec_.process_code                 := voucher_row_rec_.process_code;
   row_rec_.optional_code                := voucher_row_rec_.optional_code;
   row_rec_.project_activity_id          := voucher_row_rec_.project_activity_id;
   row_rec_.text                         := voucher_row_rec_.text;
   row_rec_.party_type_id                := voucher_row_rec_.party_type_id;
   row_rec_.reference_number             := voucher_row_rec_.reference_number;
   row_rec_.reference_serie              := voucher_row_rec_.reference_serie;
   row_rec_.trans_code                   := voucher_row_rec_.trans_code;
   row_rec_.transfer_id                  := voucher_row_rec_.transfer_id;
   row_rec_.corrected                    := voucher_row_rec_.corrected;
   row_rec_.tax_direction                := voucher_row_rec_.tax_direction;
   row_rec_.tax_amount                   := voucher_row_rec_.tax_amount;
   row_rec_.currency_tax_amount          := voucher_row_rec_.currency_tax_amount;
   row_rec_.tax_base_amount              := voucher_row_rec_.tax_base_amount;
   row_rec_.currency_tax_base_amount     := voucher_row_rec_.currency_tax_base_amount;
   row_rec_.currency_rate                := voucher_row_rec_.currency_rate;
   row_rec_.reference_row_no             := voucher_row_rec_.reference_row_no;
   row_rec_.row_group_id                 := voucher_row_rec_.row_group_id;
   row_rec_.parallel_currency_rate       := voucher_row_rec_.parallel_currency_rate;
   row_rec_.parallel_conversion_factor   := voucher_row_rec_.parallel_curr_conv_fac;
   row_rec_.parallel_curr_rate_type      := voucher_row_rec_.parallel_curr_rate_type;
   row_rec_.parallel_curr_tax_amount     := voucher_row_rec_.parallel_curr_tax_amt;
   row_rec_.parallel_curr_tax_base_amount:= voucher_row_rec_.parallel_curr_tax_base_amt;
   row_rec_.parallel_curr_gross_amount   := voucher_row_rec_.parallel_curr_gross_amt;
   row_rec_.deliv_type_id                := voucher_row_rec_.deliv_type_id;
   row_rec_.activate_code                := voucher_row_rec_.activate_code;

   Create_Cancel_Row___(row_rec_);
END Create_Cancel_Row_;


@SecurityCheck Company.UserAuthorized(company_)
PROCEDURE Ready_To_Update_ (
   company_             IN     VARCHAR2,
   voucher_type_        IN     VARCHAR2,
   accounting_year_     IN     NUMBER,
   voucher_no_          IN     NUMBER )
IS
   dummy_      NUMBER;
   CURSOR row_exist IS
      SELECT 1
      FROM   VOUCHER_ROW_TAB
      WHERE  company         = company_
      AND    voucher_type    = voucher_type_
      AND    accounting_year = accounting_year_
      AND    voucher_no      = voucher_no_;
BEGIN
   OPEN row_exist;
   FETCH row_exist INTO dummy_;
   IF (row_exist%FOUND) THEN
      UPDATE voucher_row_tab
      SET    update_error = ''
      WHERE  company         = Company_
      AND    voucher_type    = voucher_type_
      AND    accounting_year = accounting_year_
      AND    voucher_no      = voucher_no_;
   END IF;
   CLOSE row_exist;
END Ready_To_Update_;


@SecurityCheck Company.UserAuthorized(company_)
PROCEDURE Drop_Voucher_Rows_ (
   company_         IN VARCHAR2,
   voucher_type_    IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_      IN NUMBER )
IS
BEGIN
   DELETE
   FROM voucher_row_tab
   WHERE company         = company_
   AND   voucher_type    = voucher_type_
   AND   accounting_year = accounting_year_
   AND   voucher_no      = voucher_no_;
   DELETE
   FROM  Internal_Postings_Accrul_Tab
   WHERE company           = company_
   AND   voucher_type      = voucher_type_
   AND   accounting_year   = accounting_year_
   AND   voucher_no        = voucher_no_;
END Drop_Voucher_Rows_;


@SecurityCheck Company.UserAuthorized(company_)
PROCEDURE Set_Accounting_Period_ (
   company_           IN VARCHAR2,
   accounting_year_   IN NUMBER,
   voucher_type_      IN VARCHAR2,
   voucher_no_        IN NUMBER,
   accounting_period_ IN NUMBER )
IS
BEGIN
   UPDATE Voucher_Row_Tab
   SET    accounting_period = accounting_period_
   WHERE  company         = company_
   AND    accounting_year = accounting_year_
   AND    voucher_type    = voucher_type_
   AND    voucher_no      = voucher_no_ ;
END Set_Accounting_Period_;

-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------

@UncheckedAccess
FUNCTION Code_Part_Exist (
   company_   IN VARCHAR2,
   code_part_ IN VARCHAR2,
   codevalue_ IN VARCHAR2 ) RETURN BOOLEAN
IS
   dummy_          NUMBER;
   stmt_           VARCHAR2(2000);
   codepart_       VARCHAR2(20);
   TYPE recordType IS REF CURSOR;
   rec_            recordType;
BEGIN
   IF (code_part_ = 'A') THEN
      codepart_ := 'account';
   ELSIF (code_part_ = 'B') THEN
      codepart_ := 'code_b';
   ELSIF (code_part_ = 'C') THEN
      codepart_ := 'code_c';
   ELSIF (code_part_ = 'D') THEN
      codepart_ := 'code_d';
   ELSIF (code_part_ = 'E') THEN
      codepart_ := 'code_e';
   ELSIF (code_part_ = 'F') THEN
      codepart_ := 'code_f';
   ELSIF (code_part_ = 'G') THEN
      codepart_ := 'code_g';
   ELSIF (code_part_ = 'H') THEN
      codepart_ := 'code_h';
   ELSIF (code_part_ = 'I') THEN
      codepart_ := 'code_i';
   ELSIF (code_part_ = 'J') THEN
      codepart_ := 'code_j';
   END IF;
   stmt_ := '   SELECT 1                                                    '||
            '     FROM Voucher_Row_Tab v, codestring_combination c          '||
            '    WHERE v.posting_combination_id = c.posting_combination_id  '||
            '      AND v.company                = :company_                 '||
            '      AND c.'||    codepart_    ||'= :codevalue_               ';
   @ApproveDynamicStatement(2007-01-24,shsalk)
   OPEN rec_ FOR stmt_ USING company_,
                             codevalue_;
   FETCH rec_ INTO dummy_;
   IF ( rec_%NOTFOUND ) THEN
      CLOSE rec_;
      RETURN FALSE;
   ELSE
      CLOSE rec_;
      RETURN TRUE;
   END IF;
END Code_Part_Exist;


PROCEDURE Project_Delete_Allowed (
   company_            IN VARCHAR2,
   project_id_         IN VARCHAR2 )
IS
   codepart_ VARCHAR2(1);
   exist     EXCEPTION;
BEGIN
   codepart_ := Accounting_Code_parts_api.Get_Codepart_Function ( company_, 'PRACC');
   IF Code_Part_Exist ( company_ ,codepart_, project_id_ ) THEN
      RAISE exist;
   END IF;
EXCEPTION
   WHEN exist THEN
      Error_SYS.appl_general(lu_name_, 'PROJEXIST: Delete is not allowed. Project id :P1 exists in Voucher',project_id_);
END Project_Delete_Allowed;

@SecurityCheck Company.UserAuthorized(company_)
PROCEDURE Drop_Voucher_Row (
   company_         IN VARCHAR2,
   voucher_type_    IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_      IN NUMBER,
   row_no_          IN NUMBER )
IS
BEGIN
   DELETE
   FROM  VOUCHER_ROW_TAB
   WHERE company         = company_
   AND   voucher_type    = voucher_type_
   AND   accounting_year = accounting_year_
   AND   voucher_no      = voucher_no_
   AND   row_no          = row_no_;
END Drop_Voucher_Row;


PROCEDURE Interim_Voucher (
   voucher_type_        IN     VARCHAR2,
   voucher_no_          IN     NUMBER,
   accounting_year_     IN     NUMBER,
   company_             IN     VARCHAR2,
   voucher_type_ref_    IN     VARCHAR2,
   voucher_no_ref_      IN     VARCHAR2,
   accounting_year_ref_ IN     NUMBER,
   transfer_id_         IN     VARCHAR2 DEFAULT NULL )
IS
   lu_rec_                       VOUCHER_ROW_TAB%ROWTYPE;
   attr_                         VARCHAR2(2000);
   info_                         VARCHAR2(2000);
   objversion_                   VARCHAR2(2000);
   objid_                        VARCHAR2(100);
   voucher_date_                 DATE;
   base_currency_code_           VARCHAR2(3);
   third_currency_code_          VARCHAR2(3);
   is_base_emu_                  VARCHAR2(5);
   is_third_emu_                 VARCHAR2(5);
   third_currency_debit_amount_  NUMBER;
   third_currency_credit_amount_ NUMBER;
   interim_period_               NUMBER;
   comp_fin_rec_                 COMPANY_FINANCE_API.Public_Rec;
   parallel_base_                VARCHAR2(25);

      -- Bug 108417 Begin, added transfer_id_ to cursor.
   CURSOR vou_head_info IS
      SELECT accounting_period,
             voucher_date
      FROM   voucher_tab
      WHERE  company         = company_
      AND    voucher_type    = voucher_type_ref_
      AND    accounting_year = accounting_year_ref_
      AND    voucher_no      = voucher_no_ref_
      AND    transfer_id     = transfer_id_;
   -- Bug 108417 End.

   CURSOR fetch_info IS
      SELECT *
      FROM   VOUCHER_ROW_TAB
      WHERE  company         = company_
      AND    voucher_type    = voucher_type_
      AND    accounting_year = accounting_year_
      AND    voucher_no      = voucher_no_ ;
BEGIN
   OPEN vou_head_info;
   FETCH vou_head_info INTO interim_period_,
                            voucher_date_;
   CLOSE vou_head_info;
   comp_fin_rec_        := Company_Finance_API.Get (company_);
   base_currency_code_  := Company_Finance_API.Get_Currency_Code (company_);
   third_currency_code_ := Company_Finance_API.Get_Parallel_Acc_Currency (company_, voucher_date_);
   parallel_base_       := Company_Finance_API.Get_Parallel_Base_Db(company_);                                                        
   is_base_emu_         := Currency_Code_API.Get_Valid_Emu (company_,
                                                            base_currency_code_,
                                                            voucher_date_);
   IF (third_currency_code_ IS NOT NULL) THEN
      is_third_emu_     := Currency_Code_Api.Get_Valid_Emu (company_,
                                                            third_currency_code_,
                                                            voucher_date_);
   ELSE
      is_third_emu_     := 'FALSE';
   END IF;
   OPEN  fetch_info;
   WHILE (TRUE) LOOP
      FETCH fetch_info INTO lu_rec_ ;
      EXIT WHEN fetch_info%NOTFOUND;
      -- new setting for the interim voucher
      lu_rec_.voucher_type    := voucher_type_ref_;
      lu_rec_.voucher_no      := voucher_no_ref_;
      lu_rec_.accounting_year := accounting_year_ref_;
      lu_rec_.trans_code      := 'INTERIM';
      -- Bug 108417 Begin
      lu_rec_.transfer_id     := transfer_id_;
      -- Bug 108417 End.
      Client_SYS.Clear_Attr(attr_);
      Client_SYS.Add_To_Attr( 'COMPANY', lu_rec_.company, attr_);
      Client_SYS.Add_To_Attr( 'VOUCHER_TYPE',  lu_rec_.voucher_type, attr_);
      Client_SYS.Add_To_Attr( 'ACCOUNTING_YEAR', lu_rec_.accounting_year, attr_);
      Client_SYS.Add_To_Attr( 'ACCOUNTING_PERIOD', interim_period_, attr_);
      Client_SYS.Add_To_Attr( 'VOUCHER_NO', lu_rec_.voucher_no, attr_);
      Client_SYS.Add_To_Attr( 'ROW_NO', lu_rec_.row_no, attr_);
      Client_SYS.Add_To_Attr( 'ACCOUNT', lu_rec_.account, attr_);
      Client_SYS.Add_To_Attr( 'CODE_B', lu_rec_.code_b, attr_);
      Client_SYS.Add_To_Attr( 'CODE_C', lu_rec_.code_c, attr_);
      Client_SYS.Add_To_Attr( 'CODE_D', lu_rec_.code_d, attr_);
      Client_SYS.Add_To_Attr( 'CODE_E', lu_rec_.code_e, attr_);
      Client_SYS.Add_To_Attr( 'CODE_F', lu_rec_.code_f, attr_);
      Client_SYS.Add_To_Attr( 'CODE_G', lu_rec_.code_g, attr_);
      Client_SYS.Add_To_Attr( 'CODE_H', lu_rec_.code_h, attr_);
      Client_SYS.Add_To_Attr( 'CODE_I', lu_rec_.code_i, attr_);
      Client_SYS.Add_To_Attr( 'CODE_J', lu_rec_.code_j, attr_);
      Client_SYS.Add_To_Attr( 'INTERNAL_SEQ_NUMBER', lu_rec_.internal_seq_number, attr_);
      IF (comp_fin_rec_.correction_type = 'REVERSE') THEN
         Client_SYS.Add_To_Attr( 'CURRENCY_DEBET_AMOUNT', lu_rec_.currency_credit_amount, attr_);
         Client_SYS.Add_To_Attr( 'CURRENCY_CREDIT_AMOUNT', lu_rec_.currency_debet_amount, attr_);
         Client_SYS.Add_To_Attr( 'DEBET_AMOUNT', lu_rec_.credit_amount, attr_);
         Client_SYS.Add_To_Attr( 'CREDIT_AMOUNT', lu_rec_.debet_amount, attr_);
         Client_SYS.Add_To_Attr( 'THIRD_CURRENCY_DEBIT_AMOUNT', lu_rec_.third_currency_credit_amount, attr_);
         Client_SYS.Add_To_Attr( 'THIRD_CURRENCY_CREDIT_AMOUNT', lu_rec_.third_currency_debit_amount, attr_);
      ELSE
         Client_SYS.Add_To_Attr( 'CURRENCY_DEBET_AMOUNT', -lu_rec_.currency_debet_amount, attr_);
         Client_SYS.Add_To_Attr( 'CURRENCY_CREDIT_AMOUNT', -lu_rec_.currency_credit_amount, attr_);
         Client_SYS.Add_To_Attr( 'DEBET_AMOUNT', -lu_rec_.debet_amount, attr_);
         Client_SYS.Add_To_Attr( 'CREDIT_AMOUNT', -lu_rec_.credit_amount, attr_);
         Client_SYS.Add_To_Attr( 'THIRD_CURRENCY_DEBIT_AMOUNT', -lu_rec_.third_currency_debit_amount, attr_);
         Client_SYS.Add_To_Attr( 'THIRD_CURRENCY_CREDIT_AMOUNT', -lu_rec_.third_currency_credit_amount, attr_);
      END IF;
      Client_SYS.Add_To_Attr( 'TAX_BASE_AMOUNT', -lu_rec_.tax_base_amount, attr_);
      Client_SYS.Add_To_Attr( 'CURRENCY_TAX_BASE_AMOUNT', -lu_rec_.currency_tax_base_amount, attr_);
      Client_SYS.Add_To_Attr( 'TAX_DIRECTION', Tax_Direction_API.Decode(lu_rec_.tax_direction), attr_);
      Client_SYS.Add_To_Attr( 'CURRENCY_CODE', lu_rec_.currency_code, attr_);
      Client_SYS.Add_To_Attr( 'QUANTITY', -lu_rec_.quantity, attr_);
      Client_SYS.Add_To_Attr( 'PROCESS_CODE', lu_rec_.process_code, attr_);
      Client_SYS.Add_To_Attr( 'OPTIONAL_CODE', lu_rec_.optional_code, attr_);
      Client_SYS.Add_To_Attr( 'PROJECT_ACTIVITY_ID', lu_rec_.project_activity_id, attr_);
      Client_SYS.Add_To_Attr( 'TEXT', lu_rec_.text, attr_);
      Client_SYS.Add_To_Attr( 'PARTY_TYPE_ID', lu_rec_.party_type_id, attr_);
      Client_SYS.Add_To_Attr( 'REFERENCE_SERIE', lu_rec_.reference_serie, attr_);
      Client_SYS.Add_To_Attr( 'REFERENCE_NUMBER', lu_rec_.reference_number, attr_);
      Client_SYS.Add_To_Attr( 'REFERENCE_VERSION', lu_rec_.reference_version , attr_);
      Client_SYS.Add_To_Attr( 'PARTY_TYPE', lu_rec_.party_type, attr_);
      Client_SYS.Add_To_Attr( 'TRANS_CODE', lu_rec_.trans_code, attr_);
      Client_SYS.Add_To_Attr( 'TRANSFER_ID', lu_rec_.transfer_id , attr_);
      Client_SYS.Add_To_Attr( 'CURRENCY_RATE', lu_rec_.currency_rate , attr_);
      Client_SYS.Add_To_Attr( 'CONVERSION_FACTOR', lu_rec_.conversion_factor , attr_);
      Client_SYS.Add_To_Attr( 'PARALLEL_CURR_RATE_TYPE', lu_rec_.parallel_curr_rate_type , attr_);
      Client_SYS.Add_To_Attr( 'PARALLEL_CURRENCY_RATE', lu_rec_.parallel_currency_rate , attr_);
      Client_SYS.Add_To_Attr( 'PARALLEL_CONVERSION_FACTOR', lu_rec_.parallel_conversion_factor , attr_);
      Client_SYS.Add_To_Attr( 'PARALLEL_CURR_GROSS_AMOUNT', lu_rec_.parallel_curr_gross_amount , attr_);
      Client_SYS.Add_To_Attr( 'PARALLEL_CURR_TAX_BASE_AMOUNT', -lu_rec_.parallel_curr_tax_base_amount , attr_);
      Client_SYS.Add_To_Attr( 'DELIV_TYPE_ID', lu_rec_.deliv_type_id , attr_);
      IF (Account_API.Is_Ledger_Account (lu_rec_.company,lu_rec_.account) AND lu_rec_.auto_tax_vou_entry = 'TRUE') THEN
         Client_SYS.Add_To_Attr( 'INTERIM_TAX_LEDGER_ACCNT', 'TRUE' , attr_);
      END IF;
      -- Handling Third currency amount in Interim Voucher. Calculation is done only
      -- if third currency amount is NULL.
      IF (third_currency_code_ IS NOT NULL) THEN
         IF ((lu_rec_.debet_amount IS NOT NULL) AND
             (lu_rec_.third_currency_debit_amount IS NULL)) THEN
            third_currency_debit_amount_ := Currency_Amount_Api.Calculate_Parallel_Curr_Amount(lu_rec_.company,
                                                             voucher_date_,
                                                             lu_rec_.debet_amount,
                                                             lu_rec_.currency_debet_amount,
                                                             base_currency_code_,
                                                             lu_rec_.currency_code,
                                                             lu_rec_.parallel_curr_rate_type,
                                                             third_currency_code_,
                                                             parallel_base_,
                                                             is_base_emu_,
                                                             is_third_emu_);
            third_currency_debit_amount_ := NVL(-third_currency_debit_amount_,0);
            Client_SYS.Add_To_Attr( 'THIRD_CURRENCY_DEBIT_AMOUNT', third_currency_debit_amount_, attr_);
         END IF;
         IF ((lu_rec_.credit_amount IS NOT NULL) AND
             (lu_rec_.third_currency_credit_amount IS NULL)) THEN
            third_currency_credit_amount_ := Currency_Amount_Api.Calculate_Parallel_Curr_Amount(lu_rec_.company,
                                                             voucher_date_,
                                                             lu_rec_.credit_amount,
                                                             lu_rec_.currency_credit_amount,
                                                             base_currency_code_,
                                                             lu_rec_.currency_code,
                                                             lu_rec_.parallel_curr_rate_type,
                                                             third_currency_code_,
                                                             parallel_base_,
                                                             is_base_emu_,
                                                             is_third_emu_);
            third_currency_credit_amount_ := NVL(-third_currency_credit_amount_,0);
            Client_SYS.Add_To_Attr( 'THIRD_CURRENCY_CREDIT_AMOUNT', third_currency_credit_amount_, attr_);
         END IF;
      END IF;
      New__ (info_,
             objid_,
             objversion_,
             attr_,
             'DO');
      -- update reference column of the original voucher ROW and the client have to be refreshed again --
      UPDATE voucher_row_tab
         SET trans_code = 'INTERIM',
             rowversion = sysdate
      WHERE  company = company_
      AND    voucher_type    = voucher_type_
      AND    voucher_no      = voucher_no_
      AND    accounting_year = accounting_year_
      AND    row_no          = lu_rec_.row_no;
   END LOOP;
   -- Bug 108417 Moved code to Voucher_API.Interim_Voucher()   END IF;
   CLOSE fetch_info;
END Interim_Voucher;


PROCEDURE Postings_In_Voucher_Row (
   result_     OUT   VARCHAR2,
   company_    IN    VARCHAR2,
   account_    IN    VARCHAR2 )
IS
   postings_   NUMBER;
   CURSOR check_postings IS
      SELECT 1
      FROM   voucher_row_tab
      WHERE  company = company_
      AND    account = account_;
BEGIN
   OPEN check_postings;
   FETCH check_postings INTO postings_;
   IF (check_postings%FOUND) THEN
      result_ := 'TRUE';
   ELSE
      result_ := 'FALSE';
   END IF;
   CLOSE check_postings;
END Postings_In_Voucher_Row;


PROCEDURE Postings_A_In_Voucher_Row (
   result_     OUT   VARCHAR2,
   company_    IN    VARCHAR2 )
IS
BEGIN
   Postings_X_In_Voucher_Row (result_, company_, 'A' );
END Postings_A_In_Voucher_Row;


PROCEDURE Postings_B_In_Voucher_Row (
   result_     OUT   VARCHAR2,
   company_    IN    VARCHAR2 )
IS
BEGIN
   Postings_X_In_Voucher_Row (result_, company_, 'B' );
END Postings_B_In_Voucher_Row;


PROCEDURE Postings_C_In_Voucher_Row (
   result_     OUT   VARCHAR2,
   company_    IN    VARCHAR2 )
IS
BEGIN
   Postings_X_In_Voucher_Row (result_, company_, 'C' );
END Postings_C_In_Voucher_Row;


PROCEDURE Postings_D_In_Voucher_Row (
   result_     OUT   VARCHAR2,
   company_    IN    VARCHAR2 )
IS
BEGIN
   Postings_X_In_Voucher_Row (result_, company_, 'D' );
END Postings_D_In_Voucher_Row;


PROCEDURE Postings_E_In_Voucher_Row (
   result_     OUT   VARCHAR2,
   company_    IN    VARCHAR2 )
IS
BEGIN
   Postings_X_In_Voucher_Row (result_, company_, 'E' );
END Postings_E_In_Voucher_Row;


PROCEDURE Postings_F_In_Voucher_Row (
   result_     OUT   VARCHAR2,
   company_    IN    VARCHAR2 )
IS
BEGIN
   Postings_X_In_Voucher_Row (result_, company_, 'F' );
END Postings_F_In_Voucher_Row;


PROCEDURE Postings_G_In_Voucher_Row (
   result_     OUT   VARCHAR2,
   company_    IN    VARCHAR2 )
IS
BEGIN
   Postings_X_In_Voucher_Row (result_, company_, 'G' );
END Postings_G_In_Voucher_Row;


PROCEDURE Postings_H_In_Voucher_Row (
   result_     OUT   VARCHAR2,
   company_    IN    VARCHAR2 )
IS
BEGIN
   Postings_X_In_Voucher_Row (result_, company_, 'H' );
END Postings_H_In_Voucher_Row;


PROCEDURE Postings_I_In_Voucher_Row (
   result_     OUT   VARCHAR2,
   company_    IN    VARCHAR2 )
IS
BEGIN
   Postings_X_In_Voucher_Row (result_, company_, 'I' );
END Postings_I_In_Voucher_Row;


PROCEDURE Postings_J_In_Voucher_Row (
   result_     OUT   VARCHAR2,
   company_    IN    VARCHAR2 )
IS
BEGIN
   Postings_X_In_Voucher_Row (result_, company_, 'J' );
END Postings_J_In_Voucher_Row;


@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Sum_Currency_Amount (
   company_            IN VARCHAR2,
   accounting_year_    IN NUMBER,
   voucher_type_       IN VARCHAR2,
   voucher_no_         IN NUMBER,
   function_group_     IN VARCHAR2 DEFAULT NULL ) RETURN NUMBER
IS
   sum_amount_          NUMBER;
   -- Bug Id 112628 Begin, Take the currency_debet_amount and currency_credit_amount instead of debet_amount and credit_amount in the cursor sum_currency_amount and sum_currency_amount_yr_end
   CURSOR sum_currency_amount IS
      SELECT SUM(NVL(currency_debet_amount,0) - NVL(currency_credit_amount,0) )
      FROM   accounting_code_part_value_tab a,
             voucher_row_tab v
      WHERE  v.company         = company_
      AND    v.voucher_type    = voucher_type_
      AND    v.accounting_year = accounting_year_
      AND    v.voucher_no      = voucher_no_
      AND    a.company         = v.company
      AND    a.code_part       = 'A'
      AND    a.code_part_value = v.account
      AND    a.stat_account    = 'N';

   CURSOR sum_currency_amount_yr_end IS
      SELECT SUM(NVL(currency_debet_amount,0) - NVL(currency_credit_amount,0) )
      FROM   accounting_code_part_value_tab a,
             voucher_row_tab v
      WHERE  v.company               = company_
      AND    v.voucher_type          = voucher_type_
      AND    v.accounting_year       = accounting_year_
      AND    v.voucher_no            = voucher_no_
      AND    a.company               = v.company
      AND    a.code_part             = 'A'
      AND    a.code_part_value       = v.account
      AND    a.stat_account          = 'N'
      AND    a.logical_account_type != 'O';
   -- Bug Id 112628 End

BEGIN
   IF ( function_group_ IS NOT NULL AND function_group_ = 'YE') THEN
      OPEN  sum_currency_amount_yr_end;
      FETCH sum_currency_amount_yr_end INTO sum_amount_;
      CLOSE sum_currency_amount_yr_end;
   ELSE
      OPEN  sum_currency_amount;
      FETCH sum_currency_amount INTO sum_amount_;
      CLOSE sum_currency_amount;
   END IF;
   RETURN sum_amount_;
END Sum_Currency_Amount;


@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Sum_Amount (
   company_            IN VARCHAR2,
   accounting_year_    IN NUMBER,
   voucher_type_       IN VARCHAR2,
   voucher_no_         IN NUMBER,
   function_group_     IN VARCHAR2 DEFAULT NULL ) RETURN NUMBER
IS
   sum_amount_            NUMBER;
   CURSOR get_sum_amount_ IS
      SELECT SUM(NVL(debet_amount,-credit_amount))
      FROM   VOUCHER_ROW_TAB V,
             accounting_code_part_value_tab A
      WHERE  A.company         = V.company
      AND    A.code_part_value = V.account
      AND    V.company         = company_
      AND    V.accounting_year = accounting_year_
      AND    V.voucher_type    = voucher_type_
      AND    V.voucher_no      = voucher_no_
      AND    A.code_part       = 'A'
      AND    A.stat_account    = 'N';

   CURSOR get_sum_amount_yr_end IS
      SELECT SUM(NVL(debet_amount,-credit_amount))
      FROM   VOUCHER_ROW_TAB V,
             accounting_code_part_value_tab A
      WHERE  A.company               = V.company
      AND    A.code_part_value       = V.account
      AND    V.company               = company_
      AND    V.accounting_year       = accounting_year_
      AND    V.voucher_type          = voucher_type_
      AND    V.voucher_no            = voucher_no_
      AND    A.code_part             = 'A'
      AND    A.stat_account          = 'N'
      AND    a.logical_account_type != 'O';
BEGIN
   IF ( function_group_ IS NOT NULL AND function_group_ = 'YE') THEN
      OPEN  get_sum_amount_yr_end;
      FETCH get_sum_amount_yr_end INTO sum_amount_;
      CLOSE get_sum_amount_yr_end;
   ELSE
      OPEN  get_sum_amount_;
      FETCH get_sum_amount_ INTO sum_amount_;
      CLOSE get_sum_amount_;
   END IF;
   RETURN sum_amount_;
END Sum_Amount;


PROCEDURE Validate_Currency_Code (
   currency_rate_       OUT NUMBER,
   decimals_in_amount_  OUT NUMBER,
   decimals_in_rate_    OUT NUMBER,
   conv_factor_         OUT NUMBER,
   company_             IN  VARCHAR2,
   currency_type_       IN  VARCHAR2,
   currency_code_       IN  VARCHAR2,
   voucher_date_        IN  DATE )
IS
   base_curr_code_   VOUCHER_ROW_TAB.currency_code%TYPE;
   base_curr_emu_    VARCHAR2(5);
   inverted_         VARCHAR2(5);
BEGIN
   base_curr_code_ := Company_Finance_API.Get_Currency_Code (company_);
   base_curr_emu_  := Currency_Code_API.Get_Valid_Emu (company_,
                                                       base_curr_code_,
                                                       voucher_date_);
   Currency_Rate_API.Fetch_Currency_Rate_Base(conv_factor_,
                                              currency_rate_,
                                              inverted_,
                                              company_,
                                              currency_code_,
                                              base_curr_code_,
                                              currency_type_,
                                              voucher_date_,
                                              base_curr_emu_);

   decimals_in_amount_ := NVL(Currency_Code_API.Get_Currency_Rounding(company_, currency_code_), 0);
   decimals_in_rate_   := NVL(Currency_Code_API.Get_No_Of_Decimals_In_Rate(company_, currency_code_), 0);
END Validate_Currency_Code;


@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Max_Row_No (
   company_            IN VARCHAR2,
   accounting_year_    IN NUMBER,
   voucher_type_       IN VARCHAR2,
   voucher_no_         IN NUMBER ) RETURN NUMBER
IS
   row_no_                NUMBER;
   CURSOR get_max_row_no_ IS
      SELECT MAX(row_no)
      FROM   VOUCHER_ROW_TAB
      WHERE  company         = company_
      AND    accounting_year = accounting_year_
      AND    voucher_type    = voucher_type_
      AND    voucher_no      = voucher_no_;
BEGIN
   OPEN get_max_row_no_;
   FETCH get_max_row_no_ INTO row_no_;
   IF (get_max_row_no_%FOUND) THEN
      CLOSE get_max_row_no_;
      RETURN(row_no_);
   ELSE
      CLOSE get_max_row_no_;
      RETURN(0);
   END IF;
END Get_Max_Row_No;


@UncheckedAccess
FUNCTION Check_Trans_Code (
   company_            IN VARCHAR2,
   accounting_year_    IN NUMBER,
   voucher_type_       IN VARCHAR2,
   voucher_no_         IN NUMBER ) RETURN VARCHAR2
IS
   trans_code_ VARCHAR2(100) := 'MANUAL';
   CURSOR get_trans_code IS
      SELECT trans_code
      FROM   VOUCHER_ROW_TAB
      WHERE  company         = company_
      AND    accounting_year = accounting_year_
      AND    voucher_type    = voucher_type_
      AND    voucher_no      = voucher_no_
      AND    trans_code      != 'MANUAL';
BEGIN
   OPEN get_trans_code;
   FETCH get_trans_code INTO trans_code_;
   IF get_trans_code%FOUND THEN
      CLOSE get_trans_code;
      RETURN(trans_code_);
   ELSE
      CLOSE get_trans_code;
      RETURN('MANUAL');
   END IF;
END Check_Trans_Code;


@UncheckedAccess
FUNCTION Is_Code_Part_Value_Used (
   company_                IN VARCHAR2,
   code_part_              IN VARCHAR2,
   code_part_value_        IN VARCHAR2 ) RETURN VARCHAR2
IS
BEGIN
   IF (Code_Part_Exist (company_,
                        code_part_,
                        code_part_value_)) THEN
      RETURN 'TRUE';
   ELSE
      RETURN 'FALSE';
   END IF;
END Is_Code_Part_Value_Used;


PROCEDURE Account_Exist (
  company_          IN    VARCHAR2,
  account_          IN    VARCHAR2 )
IS
BEGIN
   IF (Code_Part_Exist (company_,
                        'A',
                        account_)) THEN
      Error_SYS.Record_General('VoucherRow', 'ACCNTEXISTS: The account :P1 exists in Holding Table', account_);
   END IF;
END Account_Exist;


FUNCTION Fa_Related_Vou_In_Hold (
   company_             IN VARCHAR2,
   code_part_           IN VARCHAR2,
   code_part_value_     IN VARCHAR2,
   acquisition_account_ IN VARCHAR2 ) RETURN BOOLEAN
IS

   found_           BOOLEAN := FALSE;
   store_original_  VARCHAR2(1);
   CURSOR find_ver IS
      SELECT voucher_no, voucher_type, accounting_year
      FROM VOUCHER_ROW_TAB
      WHERE company   = company_
      AND   account   = acquisition_account_
      AND   DECODE ( code_part_, 'B', code_b,
                                 'C', code_c,
                                 'D', code_d,
                                 'E', code_e,
                                 'F', code_f,
                                 'G', code_g,
                                 'H', code_h,
                                 'I', code_i,
                                 'J', code_j ) = code_part_value_;
   CURSOR store_org (vou_type_ VARCHAR2)IS
      SELECT store_original
      FROM   voucher_type_detail_tab
      WHERE  company      = company_
      AND    voucher_type = vou_type_;
BEGIN
   FOR vou_row_rec_ IN find_ver LOOP
      -- Check whether the voucher is updated  or not.
      IF (Voucher_API.Get_Voucher_Updated_Db (company_ ,
                                              vou_row_rec_.accounting_year,
                                              vou_row_rec_.voucher_type,
                                              vou_row_rec_.voucher_no)='N') THEN
         found_ := TRUE;
      ELSE
         -- Voucher is Updated but still in hold table
         -- Check for Store Original
         OPEN  store_org (vou_row_rec_.voucher_type);
         FETCH store_org into store_original_;
         CLOSE store_org;
         IF (store_original_ ='N') THEN
            found_ := TRUE;
         END IF;
      END IF;
      EXIT WHEN found_ ;
   END LOOP;
   RETURN found_;
END Fa_Related_Vou_In_Hold;


PROCEDURE Validate_Currency_Code_Base (
   currency_rate_      OUT NUMBER,
   decimals_in_amount_ OUT NUMBER,
   decimals_in_rate_   OUT NUMBER,
   conv_factor_        OUT NUMBER,
   company_            IN  VARCHAR2,
   currency_type_      IN  VARCHAR2,
   currency_code_      IN  VARCHAR2,
   voucher_date_       IN  DATE,
   base_currency_code_ IN  VARCHAR2,
   is_base_emu_        IN  VARCHAR2 )
IS
   inverted_         VARCHAR2(5);
BEGIN
   Currency_Rate_API.Fetch_Currency_Rate_Base(conv_factor_,
                                              currency_rate_,
                                              inverted_,
                                              company_,
                                              currency_code_,
                                              base_currency_code_,
                                              currency_type_,
                                              voucher_date_,
                                              is_base_emu_);

   decimals_in_amount_ := NVL(Currency_Code_API.Get_Currency_Rounding (company_, currency_code_), 0);
   decimals_in_rate_   := NVL(Currency_Code_API.Get_No_Of_Decimals_In_Rate (company_, currency_code_), 0);
END Validate_Currency_Code_Base;


@UncheckedAccess
FUNCTION Is_Manual_Added (
   company_             IN VARCHAR2,
   internal_seq_number_ IN NUMBER,
   account_             IN VARCHAR2 ) RETURN VARCHAR2
IS
   dummy_      VARCHAR2(5);
   CURSOR get_int_manual IS
      SELECT 'TRUE'
      FROM   INTERNAL_POSTINGS_ACCRUL_TAB
      WHERE  company             = company_
      AND    internal_seq_number = internal_seq_number_
      AND    account             = account_;
BEGIN
   OPEN  get_int_manual;
   FETCH get_int_manual INTO dummy_;
   CLOSE get_int_manual;
   RETURN NVL(dummy_,'FALSE');
END Is_Manual_Added;


@UncheckedAccess
FUNCTION Is_Add_Internal (
   company_             IN VARCHAR2,
   internal_seq_number_ IN NUMBER,
   account_             IN VARCHAR2,
   voucher_type_        IN VARCHAR2,
   voucher_no_          IN NUMBER,
   accounting_year_     IN NUMBER ) RETURN VARCHAR2
IS
   CURSOR get_trans_code IS
      SELECT trans_code,
             voucher_date
      FROM   voucher_row_tab
      WHERE  company         = company_
      AND    voucher_type    = voucher_type_
      AND    voucher_no      = voucher_no_
      AND    accounting_year = accounting_year_
      AND    account         = account_;
   trans_code_    VARCHAR2(100);
   voucher_date_  DATE;
BEGIN
   OPEN get_trans_code;
   FETCH get_trans_code INTO trans_code_,
                             voucher_date_;
   CLOSE get_trans_code;
   IF (trans_code_ = 'PP12' OR trans_code_ = 'PP13') THEN
      RETURN 'FALSE';
   END IF;
   IF (voucher_date_ IS NULL) THEN
      voucher_date_ := Voucher_API.Get_Voucher_Date (company_,
                                                     accounting_year_,
                                                     voucher_type_,
                                                     voucher_no_);
   END IF;
   $IF Component_Intled_SYS.INSTALLED $THEN
      IF ((Is_Manual_Added (company_,
                            internal_seq_number_,
                            account_) = 'FALSE') AND
          (Voucher_Type_API.Get_Use_Manual (company_,
                                            voucher_type_) = 'TRUE') AND
          (Internal_Voucher_Util_Pub_API.Check_If_Manual (company_,
                                                          account_,
                                                          voucher_date_) IS NOT NULL)) THEN
         RETURN 'TRUE';
      END IF;
   $END
   RETURN 'FALSE';
END Is_Add_Internal;


PROCEDURE Tax_Code_In_Voucher_Row (
   result_     OUT   VARCHAR2,
   company_    IN    VARCHAR2,
   tax_code_   IN    VARCHAR2 )
IS
   postings_   NUMBER;
   CURSOR check_postings IS
      SELECT 1
      FROM   voucher_row_tab
      WHERE  company       = company_
      AND    optional_code = tax_code_;
BEGIN
   OPEN  check_postings;
   FETCH check_postings INTO postings_;
   IF (check_postings%FOUND) THEN
      result_ := 'TRUE';
   ELSE
      result_ := 'FALSE';
   END IF;
   CLOSE check_postings;
END Tax_Code_In_Voucher_Row;


PROCEDURE Calculate_Net_From_Gross (
   rowrec_               IN OUT VOUCHER_ROW_TAB%ROWTYPE,
   amount_methodx_       IN     VARCHAR2,
   third_currency_codex_ IN     VARCHAR2 DEFAULT NULL,
   is_third_emux_        IN     VARCHAR2 DEFAULT 'FALSE',
   base_currency_codex_  IN     VARCHAR2 DEFAULT NULL,
   is_base_emux_         IN     VARCHAR2 DEFAULT 'FALSE' )
IS
   voucher_date_         DATE;
   amount_method_        VARCHAR2(200);
   base_currency_code_   VARCHAR2(50);
   third_currency_code_  VARCHAR2(50);
   is_base_emu_          VARCHAR2(5);
   is_third_emu_         VARCHAR2(5);
   parallel_base_        VARCHAR2(25);
   CURSOR vou_head_info IS
      SELECT voucher_date, amount_method
      FROM   voucher_tab
      WHERE  company         = rowrec_.company
      AND    accounting_year = rowrec_.accounting_year
      AND    voucher_no      = rowrec_.voucher_no
      AND    voucher_type    = rowrec_.voucher_type ;
BEGIN
   IF (amount_methodx_ IS NULL OR
       rowrec_.voucher_date IS NULL) THEN
      OPEN  vou_head_info;
      FETCH vou_head_info INTO voucher_date_,
                               amount_method_;
      CLOSE vou_head_info;
   ELSE
      voucher_date_  := rowrec_.voucher_date;
      amount_method_ := amount_methodx_;
   END IF;
   IF (amount_method_ IN ('GROSS')) THEN
      IF (rowrec_.optional_code IS NOT NULL AND (rowrec_.tax_amount IS NOT NULL OR rowrec_.parallel_curr_tax_amount IS NOT NULL)) THEN
         rowrec_.currency_gross_amount     := nvl(rowrec_.currency_debet_amount,-rowrec_.currency_credit_amount);
         rowrec_.gross_amount              := nvl(rowrec_.debet_amount,-rowrec_.credit_amount);
         rowrec_.parallel_curr_gross_amount := nvl(rowrec_.third_currency_debit_amount,-rowrec_.third_currency_credit_amount);
         IF ((rowrec_.debet_amount IS NOT NULL) OR (rowrec_.third_currency_debit_amount IS NOT NULL)) THEN
            rowrec_.currency_debet_amount  := rowrec_.currency_debet_amount - rowrec_.currency_tax_amount;
            rowrec_.debet_amount           := rowrec_.debet_amount - rowrec_.tax_amount;
            rowrec_.third_currency_debit_amount   := rowrec_.third_currency_debit_amount - rowrec_.parallel_curr_tax_amount;
         ELSIF ((rowrec_.credit_amount IS NOT NULL) OR (rowrec_.third_currency_credit_amount IS NOT NULL) ) THEN
            rowrec_.currency_credit_amount := rowrec_.currency_credit_amount - (rowrec_.currency_tax_amount * -1);
            rowrec_.credit_amount          := rowrec_.credit_amount - (rowrec_.tax_amount * -1);
            rowrec_.third_currency_credit_amount  := rowrec_.third_currency_credit_amount - (rowrec_.parallel_curr_tax_amount * -1);
         END IF;
         IF (third_currency_codex_ IS NOT NULL) THEN
            third_currency_code_ := third_currency_codex_;    
            is_third_emu_        := is_third_emux_;           
         ELSE                                                 
            third_currency_code_ := Company_Finance_Api.Get_Parallel_Acc_Currency (rowrec_.company, voucher_date_);
         END IF;
         parallel_base_          := Company_Finance_API.Get_Parallel_Base_Db(rowrec_.company);                                                        
         IF (third_currency_code_ IS NOT NULL) THEN
            IF (base_currency_codex_ IS NOT NULL) THEN
               base_currency_code_ := base_currency_codex_;   
               is_base_emu_        := is_base_emux_;          
            ELSE                                              
               base_currency_code_ := Company_Finance_Api.Get_Currency_Code (rowrec_.company);
               is_base_emu_        := Currency_Code_Api.Get_Valid_Emu (rowrec_.company,
                                                                       base_currency_code_,
                                                                       voucher_date_);
            END IF;
            IF (third_currency_codex_ IS NULL) THEN           
               is_third_emu_       := Currency_Code_Api.Get_Valid_Emu (rowrec_.company,
                                                                       third_currency_code_,
                                                                       voucher_date_);
            END IF;
            IF ((rowrec_.debet_amount IS NOT NULL) AND (rowrec_.third_currency_debit_amount IS NULL)) THEN
               rowrec_.third_currency_debit_amount := Currency_Amount_Api.Calculate_Parallel_Curr_Amount(rowrec_.company,
                                                                voucher_date_,
                                                                rowrec_.debet_amount,
                                                                rowrec_.currency_debet_amount,
                                                                base_currency_code_,
                                                                rowrec_.currency_code,
                                                                rowrec_.parallel_curr_rate_type,                                                                
                                                                third_currency_code_,
                                                                parallel_base_,
                                                                is_base_emu_,
                                                                is_third_emu_);                                                                
            END IF;

            IF ((rowrec_.credit_amount IS NOT NULL) AND (rowrec_.third_currency_credit_amount IS NULL)) THEN
               rowrec_.third_currency_credit_amount := Currency_Amount_Api.Calculate_Parallel_Curr_Amount(rowrec_.company,
                                                                voucher_date_,
                                                                rowrec_.credit_amount,
                                                                rowrec_.currency_credit_amount,
                                                                base_currency_code_,
                                                                rowrec_.currency_code,
                                                                rowrec_.parallel_curr_rate_type,                                                                
                                                                third_currency_code_,
                                                                parallel_base_,
                                                                is_base_emu_,
                                                                is_third_emu_);
            END IF;
         END IF;
      END IF;
   END IF;
END Calculate_Net_From_Gross;


PROCEDURE Calculate_Net_From_Gross (
   rowrec_         IN OUT VOUCHER_ROW_TAB%ROWTYPE )
IS
   amount_method_        VARCHAR2(200);
BEGIN
   amount_method_ := Voucher_API.Get_Amount_Method_Db (rowrec_.company,
                                                    rowrec_.accounting_year,
                                                    rowrec_.voucher_type,
                                                    rowrec_.voucher_no);
   Calculate_Net_From_Gross ( rowrec_,
                              amount_method_ );
END Calculate_Net_From_Gross;


@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Is_Multi_Company_Voucher_Row(
   company_         IN VARCHAR2,
   voucher_type_    IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_      IN NUMBER,
   row_no_          IN NUMBER ) RETURN VARCHAR2
IS
   temp_ VOUCHER_ROW_TAB.multi_company_id%TYPE;
   CURSOR get_attr IS
      SELECT multi_company_id
      FROM   VOUCHER_ROW_TAB
      WHERE  company         = company_
      AND    voucher_type    = voucher_type_
      AND    accounting_year = accounting_year_
      AND    voucher_no      = voucher_no_
      AND    row_no          = row_no_;
BEGIN
   OPEN get_attr;
   FETCH get_attr INTO temp_;
   CLOSE get_attr;
   IF (temp_ IS NOT NULL) THEN
      RETURN 'TRUE';
   ELSE
      RETURN 'FALSE';
   END IF;
END Is_Multi_Company_Voucher_Row;


PROCEDURE Modify_Row (
   attr_            IN OUT VARCHAR2,
   company_         IN VARCHAR2,
   voucher_type_    IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_      IN NUMBER,
   row_no_          IN NUMBER )
IS
   info_               VARCHAR2(2000);
   objid_              voucher_row.objid%TYPE;
   objversion_         voucher_row.objversion%TYPE;
BEGIN
   Get_Id_Version_By_Keys___(objid_, objversion_, company_, voucher_type_, accounting_year_, voucher_no_, row_no_);
   IF ( objid_ IS NOT NULL AND objversion_ IS NOT NULL) THEN
      Modify__( info_, objid_, objversion_, attr_, 'DO');
   END IF;
END Modify_Row;


PROCEDURE New_Row (
   attr_ IN OUT VARCHAR2 )
IS
   info_       VARCHAR2(2000);
   objid_      voucher_row.objid%TYPE;
   objversion_ voucher_row.objversion%TYPE;
BEGIN
   New__( info_, objid_, objversion_, attr_, 'DO');
END New_Row;


PROCEDURE Remove_Row(
   company_         IN VARCHAR2,
   voucher_type_    IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_      IN NUMBER,
   row_no_          IN NUMBER,
   remove_all_      IN VARCHAR2 DEFAULT 'FALSE' )
IS
   voucher_rec_     VOUCHER_ROW_TAB%ROWTYPE;
   allocated_       NUMBER;
   CURSOR get_rec_ IS 
      SELECT *
      FROM VOUCHER_ROW_TAB
      WHERE company       = company_
      AND voucher_type    = voucher_type_
      AND accounting_year = accounting_year_
      AND voucher_no      = voucher_no_
      AND row_no          = row_no_;
BEGIN

   IF ( remove_all_ = 'TRUE') THEN
      OPEN  get_rec_;
       FETCH get_rec_ INTO voucher_rec_;
      CLOSE get_rec_;

      -- Removing Object Connection and Cost Info
      IF ( NVL(voucher_rec_.project_activity_id,0) != 0) THEN
         Remove_Object_Connection___(voucher_rec_);
      END IF;

      -- check for any period allocation
      allocated_ := Period_Allocation_API.Any_Voucher( voucher_rec_.company,
                                                       voucher_rec_.voucher_type,
                                                       voucher_rec_.voucher_no,
                                                       voucher_rec_.accounting_year,
                                                     voucher_rec_.row_no );
      IF ( allocated_ = 1) THEN
          Error_SYS.Record_General(lu_name_, 'EXISTINPERALLOC: Can not change Voucher row that exists in Period Allocation');
      END IF;
      -- Remove Tax Transactions
      Delete_Tax_Transaction___(voucher_rec_);

      -- Remove internal manual postings and internal voucher rows.
      Delete_Internal_Rows___ (voucher_rec_.company,
                              voucher_rec_.voucher_type,
                              voucher_rec_.accounting_year,
                              voucher_rec_.voucher_no,
                              voucher_rec_.account,
                              voucher_rec_.row_no);  
   END IF;

   Drop_Voucher_Row (company_,
                     voucher_type_,
                     accounting_year_,
                     voucher_no_,
                     row_no_);
END Remove_Row;


@Override
@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get (
   company_         IN VARCHAR2,
   voucher_type_    IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_      IN NUMBER,
   row_no_          IN NUMBER ) RETURN Public_Rec
IS
BEGIN
   RETURN super(company_, voucher_type_, accounting_year_, voucher_no_, row_no_);
END Get;


@UncheckedAccess
FUNCTION Is_Voucher_Exist (
   company_    IN VARCHAR2,
   code_part_  IN VARCHAR2,
   code_value_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   CURSOR get_voucher IS
       SELECT 1
       FROM voucher_row_tab
       WHERE company = company_
       AND DECODE (code_part_, 'A' , account,
                               'B' , code_b,
                               'C' , code_c,
                               'D' , code_d,
                               'E' , code_e,
                               'F' , code_f,
                               'G' , code_g,
                               'H' , code_h,
                               'I' , code_i,
                               'J' , code_j  ) = code_value_;
   vou_rec_   get_voucher%ROWTYPE;

BEGIN
   OPEN  get_voucher ;
   FETCH get_voucher INTO vou_rec_;
   IF (get_voucher%FOUND) THEN
      CLOSE get_voucher;
      RETURN 'TRUE';
   ELSE
      CLOSE get_voucher;
      RETURN 'FALSE';
   END IF;
END Is_Voucher_Exist;


PROCEDURE Check_Code_Str_Fa (
   company_        IN VARCHAR2,
   object_id_      IN VARCHAR2,
   fa_code_part_   IN VARCHAR2,
   codestring_rec_ IN Accounting_Codestr_API.CodestrRec)
IS
   TYPE FaCodestrRec IS RECORD (
      code_a        VARCHAR2(20),
      code_b        VARCHAR2(20),
      code_c        VARCHAR2(20),
      code_d        VARCHAR2(20),
      code_e        VARCHAR2(20),
      code_f        VARCHAR2(20),
      code_g        VARCHAR2(20),
      code_h        VARCHAR2(20),
      code_i        VARCHAR2(20),
      code_j        VARCHAR2(20));
   fa_codestring_rec_      FaCodestrRec;
   account_                VARCHAR2(20);
   multiple_code_string_   VARCHAR2(5);
   ill_code_str_           BOOLEAN := FALSE;
   CURSOR fa_codepart IS
      SELECT account code_a,
             code_b,
             code_c,
             code_d,
             code_e,
             code_f,
             code_g,
             code_h,
             code_i,
             code_j
      FROM   voucher_row_tab
      WHERE  company       = company_
      AND    account       = account_
      AND    object_id     = object_id_
      AND    object_id     IS NOT NULL;
BEGIN
   account_   := codestring_rec_.code_a; 
   multiple_code_string_ := 'FALSE';
   $IF Component_Fixass_SYS.INSTALLED $THEN
      multiple_code_string_ := Fnd_Boolean_API.Encode(Fa_Company_API.Get_Multiple_Code_String(company_));   
   $END                                  
   OPEN fa_codepart;
   FETCH fa_codepart INTO fa_codestring_rec_;
   IF fa_codepart%FOUND THEN
      IF ( codestring_rec_.code_a <> fa_codestring_rec_.code_a ) THEN
         ill_code_str_ := TRUE;
      ELSIF ( NVL(codestring_rec_.code_b,' ') <> NVL(fa_codestring_rec_.code_b,' ') ) AND  multiple_code_string_ = 'FALSE' THEN
         ill_code_str_ := TRUE;
      ELSIF ( NVL(codestring_rec_.code_c,' ') <> NVL(fa_codestring_rec_.code_c,' ') ) AND  multiple_code_string_ = 'FALSE' THEN
         ill_code_str_ := TRUE;
      ELSIF ( NVL(codestring_rec_.code_d,' ') <> NVL(fa_codestring_rec_.code_d,' ') ) AND  multiple_code_string_ = 'FALSE' THEN
         ill_code_str_ := TRUE;
      ELSIF ( NVL(codestring_rec_.code_e,' ') <> NVL(fa_codestring_rec_.code_e,' ') ) AND  multiple_code_string_ = 'FALSE' THEN
         ill_code_str_ := TRUE;
      ELSIF ( NVL(codestring_rec_.code_f,' ') <> NVL(fa_codestring_rec_.code_f,' ') ) AND  multiple_code_string_ = 'FALSE' THEN
         ill_code_str_ := TRUE;
      ELSIF ( NVL(codestring_rec_.code_g,' ') <> NVL(fa_codestring_rec_.code_g,' ') ) AND  multiple_code_string_ = 'FALSE' THEN
         ill_code_str_ := TRUE;
      ELSIF ( NVL(codestring_rec_.code_h,' ') <> NVL(fa_codestring_rec_.code_h,' ') ) AND  multiple_code_string_ = 'FALSE' THEN
         ill_code_str_ := TRUE;
      ELSIF ( NVL(codestring_rec_.code_i,' ') <> NVL(fa_codestring_rec_.code_i,' ') ) AND  multiple_code_string_ = 'FALSE' THEN
         ill_code_str_ := TRUE;
      ELSIF ( NVL(codestring_rec_.code_j,' ') <> NVL(fa_codestring_rec_.code_j,' ') ) AND  multiple_code_string_ = 'FALSE' THEN
         ill_code_str_ := TRUE;
      END IF;
   END IF;
   CLOSE fa_codepart;
   IF (ill_code_str_) THEN
      Error_SYS.Appl_General(lu_name_,
       'ILLFACODESTR2: Object :P1 has existing voucher rows (in the hold table)with a code string that differs from the code string specified',
       object_id_ );
   END IF;
END Check_Code_Str_Fa;


PROCEDURE Check_Project_Used (
   company_                IN VARCHAR2,
   code_part_              IN VARCHAR2,
   code_part_value_        IN VARCHAR2,
   is_rollback_            IN VARCHAR2 DEFAULT NULL)
IS
   code_part2_ VARCHAR2(10);
   CURSOR chk_prj_exist IS
      SELECT 1
      FROM   voucher_tab v, voucher_row_tab vr
      WHERE  v.company           = company_
      AND    v.company           = vr.company
      AND    v.accounting_year   = vr.accounting_year
      AND    v.accounting_period = vr.accounting_period
      AND    v.voucher_no        = vr.voucher_no
      AND    v.voucher_type      = vr.voucher_type
      AND    v.voucher_updated   = 'N'
      AND    DECODE (code_part2_, 'A' , account,
                                 'B' , code_b,
                                 'C' , code_c,
                                 'D' , code_d,
                                 'E' , code_e,
                                 'F' , code_f,
                                 'G' , code_g,
                                 'H' , code_h,
                                 'I' , code_i,
                                 'J' , code_j ) = code_part_value_;
   dummy_   NUMBER;
BEGIN
   -- Bug 102875, Begin.
   IF(code_part_ IS NULL) THEN
      code_part2_ := Accounting_Code_Parts_Api.Get_Codepart_Function(company_,'PRACC');
   ELSE
      code_part2_ := code_part_;
   END IF;
   -- Bug 102875, End.
   OPEN chk_prj_exist;
   FETCH chk_prj_exist INTO dummy_;
   IF (chk_prj_exist%FOUND) THEN
      CLOSE chk_prj_exist;
      IF (is_rollback_ = 'rollback') THEN 
         Error_SYS.Record_General('VoucherRow', 'PRJINHOLDTABRB: There are vouchers in the hold table related to this project. Update General Ledger before rollback operation.');
      ELSE
         Error_SYS.Record_General('VoucherRow', 'PRJINHOLDTAB: There are vouchers in the hold table related to this project. Update General Ledger before completing the project.');
      END IF;
   END IF;
   CLOSE chk_prj_exist;
END Check_Project_Used;


PROCEDURE Check_Sub_Project_Used (
   company_                IN VARCHAR2,
   code_part_              IN VARCHAR2,
   code_part_value_        IN VARCHAR2,
   sub_project_id_         IN VARCHAR2,
   is_rollback_            IN VARCHAR2 DEFAULT NULL)
IS
   $IF Component_Proj_SYS.INSTALLED $THEN 
      CURSOR chk_prj_exist IS
         SELECT 1
         FROM   voucher_tab v, voucher_row_tab vr
         WHERE  v.company           = company_
         AND    v.company           = vr.company
         AND    v.accounting_year   = vr.accounting_year
         AND    v.voucher_no        = vr.voucher_no
         AND    v.voucher_type      = vr.voucher_type
         AND    v.voucher_updated   = 'N'
         AND    DECODE (code_part_, 'A' , account,
                                    'B' , code_b,
                                    'C' , code_c,
                                    'D' , code_d,
                                    'E' , code_e,
                                    'F' , code_f,
                                    'G' , code_g,
                                    'H' , code_h,
                                    'I' , code_i,
                                    'J' , code_j ) = code_part_value_
         AND    vr.project_activity_id IN (SELECT  a.activity_seq
                                   FROM     ACTIVITY_TAB a
                                   WHERE    a.project_id = code_part_value_
                                   AND sub_project_id IN (SELECT s.sub_project_id 
                                                          FROM sub_project_tab s
                                                          START WITH s.sub_project_id = sub_project_id_ AND s.project_id = code_part_value_
                                                          CONNECT BY s.parent_sub_project_id = PRIOR s.sub_project_id AND s.project_id = code_part_value_));
      dummy_   NUMBER;
   $END
BEGIN
   $IF Component_Proj_SYS.INSTALLED $THEN 
      OPEN chk_prj_exist;
      FETCH chk_prj_exist INTO dummy_;
      IF (chk_prj_exist%FOUND) THEN
         CLOSE chk_prj_exist;
         IF (is_rollback_ = 'rollback') THEN 
            Error_SYS.Record_General('VoucherRow', 'SUBPRJINHOLDTABRB: There are vouchers in the GL hold table related to this project. Update General Ledger before rollback operation.');
         ELSE
            Error_SYS.Record_General('VoucherRow', 'SUBPRJINHOLDTAB: There are vouchers in the GL hold table related to this project. Update General Ledger before completing the sub project');
         END IF;
      END IF;
      CLOSE chk_prj_exist;
   $ELSE 
      NULL;
   $END
END Check_Sub_Project_Used;


PROCEDURE Calculate_Cost_And_Progress (
   company_         IN VARCHAR2,
   voucher_type_    IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_      IN NUMBER,
   row_no_          IN NUMBER )
IS
   $IF (Component_Proj_SYS.INSTALLED) $THEN
   activity_info_tab_         Project_Connection_Util_API.Activity_Info_Tab_Type;
   activity_revenue_info_tab_ Project_Connection_Util_API.Activity_Revenue_Info_Tab_Type;
   attributes_                Project_Connection_Util_API.Attributes_Type;
   $END
BEGIN
   $IF (Component_Proj_SYS.INSTALLED) $THEN
   Refresh_Project_Connection (activity_info_tab_         => activity_info_tab_,
                               activity_revenue_info_tab_ => activity_revenue_info_tab_,
                               attributes_                => attributes_,
                               activity_seq_              => NULL,
                               keyref1_                   => company_,
                               keyref2_                   => voucher_type_,
                               keyref3_                   => TO_CHAR(accounting_year_),
                               keyref4_                   => TO_CHAR(voucher_no_),
                               keyref5_                   => TO_CHAR(row_no_),
                               keyref6_                   => '*',
                               refresh_old_data_          => 'FALSE');
   $ELSE 
     NULL;
   $END
END Calculate_Cost_And_Progress;

   
--------------------------------------------------------------------------------------
--Note: Refresh_Project_Connection
--Note: Note that this method is directly called from Project_Conn_Refresh_Util_API.Refresh_Project_Connection___ method in PROJ. 
--Note: In all other places the method Refresh_Project_Connection is called from Calculate_Cost_And_Progress 
--Note: Refresh_Project_Connection is called to report cost to the project side.
--------------------------------------------------------------------------------------
@DynamicComponentDependency PROJ
PROCEDURE Refresh_Project_Connection (
   activity_info_tab_          IN OUT NOCOPY Project_Connection_Util_API.Activity_Info_Tab_Type,
   activity_revenue_info_tab_  IN OUT NOCOPY Project_Connection_Util_API.Activity_Revenue_Info_Tab_Type,
   attributes_                 IN OUT NOCOPY Project_Connection_Util_API.Attributes_Type,
   activity_seq_               IN     NUMBER,
   keyref1_                    IN     VARCHAR2,
   keyref2_                    IN     VARCHAR2,
   keyref3_                    IN     VARCHAR2,
   keyref4_                    IN     VARCHAR2,
   keyref5_                    IN     VARCHAR2,
   keyref6_                    IN     VARCHAR2,
   refresh_old_data_           IN     VARCHAR2 DEFAULT 'FALSE' )
IS
   company_                           VARCHAR2(20) := keyref1_;
   voucher_type_                      VARCHAR2(20) := keyref2_;
   accounting_year_                   NUMBER       := TO_NUMBER(keyref3_);
   voucher_no_                        NUMBER       := TO_NUMBER(keyref4_);
   row_no_                            NUMBER       := TO_NUMBER(keyref5_);
   count_                             PLS_INTEGER;
   countr_                            PLS_INTEGER;
   rec_                               voucher_row_tab%ROWTYPE;
   project_cost_element_              VARCHAR2(100);
   code_string_                       VARCHAR2(2000);    
   exclude_proj_followup_             VARCHAR2(5);   
   followup_element_type_             VARCHAR2(20);
   used_cost_amount_                  NUMBER;
   posted_revenue_amount_             NUMBER;
   used_transaction_amount_           NUMBER;
   used_cost_transaction_amount_      NUMBER;
   posted_rev_transaction_amount_     NUMBER;
   transaction_currency_code_         VARCHAR2(3);
   used_cost_amount_temp_             NUMBER;
BEGIN
   rec_                                                             := Get_Object_By_Keys___ (company_,  voucher_type_,  accounting_year_,  voucher_no_,  row_no_);
   exclude_proj_followup_                                           := Account_API.Get_Exclude_Proj_Followup (company_, rec_.account);
   IF (NVL(exclude_proj_followup_, 'FALSE') = 'FALSE') THEN      
      Get_Activity_Info (used_cost_amount_temp_, used_transaction_amount_, rec_ );
      transaction_currency_code_                                    := rec_.currency_code;
      --if transaction amount is zero replace it with base amount
      IF (used_transaction_amount_ = 0 AND used_cost_amount_temp_ != 0) THEN
         used_transaction_amount_                                   := used_cost_amount_temp_;  
         transaction_currency_code_                                 := Company_Finance_API.Get_Currency_Code (company_);
      END IF;
      -- Here we send client value of Voucher State as it does in other object connections
      -- eventhough it is not a good practice since decoding of server value is not supported
      -- by the PROJECT_CONNECTIONS_SUMMARY View in PROJ due to performance reasons.
      project_cost_element_                                         := Cost_Element_To_Account_API.Get_Project_Follow_Up_Element (company_, 
                                                                                                                                  rec_.account, rec_.code_b, rec_.code_c, rec_.code_d,
                                                                                                                                  rec_.code_e,  rec_.code_f, rec_.code_g, rec_.code_h, 
                                                                                                                                  rec_.code_i, rec_.code_j, 
                                                                                                                                  rec_.voucher_date, 'TRUE');
      followup_element_type_                                        := Project_Cost_Element_API.Get_Element_Type_Db (company_, project_cost_element_);
      IF (followup_element_type_ = 'COST') THEN
         used_cost_transaction_amount_                              := used_transaction_amount_;
         used_cost_amount_                                          := used_cost_amount_temp_;
      ELSE
         posted_revenue_amount_                                     := - used_cost_amount_temp_;
         posted_rev_transaction_amount_                             := - used_transaction_amount_;
      END IF;      

      code_string_                                                  := Get_Codestring___ (rec_);
      count_                                                        := activity_info_tab_.COUNT;
      countr_                                                       := activity_revenue_info_tab_.COUNT;
      activity_info_tab_(count_).control_category                   := project_cost_element_;
      activity_info_tab_(count_).used                               := used_cost_amount_;
      activity_info_tab_(count_).used_transaction                   := used_cost_transaction_amount_;
      activity_info_tab_(count_).transaction_currency_code          := transaction_currency_code_;
      activity_revenue_info_tab_(countr_).control_category          := project_cost_element_;
      activity_revenue_info_tab_(countr_).posted_revenue            := posted_revenue_amount_;
      activity_revenue_info_tab_(countr_).posted_transaction        := posted_rev_transaction_amount_;
      activity_revenue_info_tab_(countr_).transaction_currency_code := transaction_currency_code_;
      attributes_.codestring                                        := code_string_;
      attributes_.last_transaction_date                             := rec_.voucher_date;

      IF (refresh_old_data_ = 'FALSE') THEN
         Project_Connection_Util_API.Refresh_Connection (proj_lu_name_              => 'VR',
                                                         activity_seq_              => rec_.project_activity_id,
                                                         keyref1_                   => keyref1_,
                                                         keyref2_                   => keyref2_,
                                                         keyref3_                   => keyref3_,
                                                         keyref4_                   => keyref4_,
                                                         keyref5_                   => keyref5_,
                                                         keyref6_                   => keyref6_,
                                                         object_description_        => 'VoucherRow',
                                                         activity_info_tab_         => activity_info_tab_,
                                                         activity_revenue_info_tab_ => activity_revenue_info_tab_,
                                                         attributes_                => attributes_);

      END IF;
   END IF;   
END Refresh_Project_Connection;


PROCEDURE Create_Object_Connection (
   company_         IN VARCHAR2,
   voucher_type_    IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_      IN NUMBER )
IS   
   CURSOR getvourow IS
      SELECT row_no, account, code_b, code_c, code_d, code_e , code_f, code_g, code_h, code_i, code_j, 
             debet_amount, credit_amount, text, trans_code, project_activity_id, voucher_date, currency_code, currency_debet_amount, currency_credit_amount 
      FROM   VOUCHER_ROW_TAB
      WHERE  company         = company_
      AND    voucher_type    = voucher_type_
      AND    accounting_year = accounting_year_
      AND    voucher_no      = voucher_no_
      AND    project_id      IS NOT NULL
      AND    NVL(project_activity_id,0) != 0;
   vourow_rec_ VOUCHER_ROW_TAB%ROWTYPE;     
BEGIN
   FOR row_ IN getvourow LOOP
      vourow_rec_.company             := company_;
      vourow_rec_.voucher_type        := voucher_type_;
      vourow_rec_.accounting_year     := accounting_year_;
      vourow_rec_.voucher_no          := voucher_no_;
      vourow_rec_.row_no              := row_.row_no;
      vourow_rec_.account             := row_.account;
      vourow_rec_.debet_amount        := row_.debet_amount;
      vourow_rec_.credit_amount       := row_.credit_amount;
      vourow_rec_.text                := row_.text;
      vourow_rec_.trans_code          := row_.trans_code;
      vourow_rec_.project_activity_id := row_.project_activity_id;      
      vourow_rec_.code_b              := row_.code_b;
      vourow_rec_.code_c              := row_.code_c;
      vourow_rec_.code_d              := row_.code_d;
      vourow_rec_.code_e              := row_.code_e;
      vourow_rec_.code_f              := row_.code_f;
      vourow_rec_.code_g              := row_.code_g;
      vourow_rec_.code_h              := row_.code_h;
      vourow_rec_.code_i              := row_.code_i;
      vourow_rec_.code_j              := row_.code_j;
      vourow_rec_.voucher_date        := row_.voucher_date;      
      vourow_rec_.currency_code           := row_.currency_code;
      vourow_rec_.currency_debet_amount   := row_.currency_debet_amount;
      vourow_rec_.currency_credit_amount  := row_.currency_credit_amount;
      Create_Object_Connection___(vourow_rec_);
   END LOOP;    
END Create_Object_Connection;


PROCEDURE Create_Object_Connection (
   err_msg_             OUT VARCHAR2,
   project_activity_id_ OUT NUMBER,
   company_             IN  VARCHAR2,
   voucher_type_        IN  VARCHAR2,
   accounting_year_     IN  NUMBER,
   voucher_no_          IN  NUMBER )
IS
   -- Bug 107103, Begin, Added other code parts as well
   CURSOR getvourow IS
      SELECT row_no, account, code_b, code_c, code_d, code_e , code_f, code_g, code_h, code_i, code_j, debet_amount, credit_amount, text, trans_code, project_activity_id 
      FROM   VOUCHER_ROW_TAB
      WHERE  company         = company_
      AND    voucher_type    = voucher_type_
      AND    accounting_year = accounting_year_
      AND    voucher_no      = voucher_no_
      AND    project_id      IS NOT NULL
      AND    NVL(project_activity_id,0) != 0;
   -- Bug 107103, End
   vourow_rec_ VOUCHER_ROW_TAB%ROWTYPE;     
BEGIN
   FOR row_ IN getvourow LOOP
      vourow_rec_.company             := company_;
      vourow_rec_.voucher_type        := voucher_type_;
      vourow_rec_.accounting_year     := accounting_year_;
      vourow_rec_.voucher_no          := voucher_no_;
      vourow_rec_.row_no              := row_.row_no;
      vourow_rec_.account             := row_.account;
      -- Bug 107103, Begin
      vourow_rec_.code_b              := row_.code_b;
      vourow_rec_.code_c              := row_.code_c;
      vourow_rec_.code_d              := row_.code_d;
      vourow_rec_.code_e              := row_.code_e;
      vourow_rec_.code_f              := row_.code_f;
      vourow_rec_.code_g              := row_.code_g;
      vourow_rec_.code_h              := row_.code_h;
      vourow_rec_.code_i              := row_.code_i;
      vourow_rec_.code_j              := row_.code_j;
      -- Bug 107103, End
      vourow_rec_.debet_amount        := row_.debet_amount;
      vourow_rec_.credit_amount       := row_.credit_amount;
      vourow_rec_.text                := row_.text;
      vourow_rec_.trans_code          := row_.trans_code;
      vourow_rec_.project_activity_id := row_.project_activity_id;
      Create_Object_Connection___(vourow_rec_);
   END LOOP;
EXCEPTION
   WHEN OTHERS THEN
      IF ( vourow_rec_.project_activity_id IS NOT NULL ) THEN
         project_activity_id_ := vourow_rec_.project_activity_id;
         err_msg_             := SQLERRM;
      ELSE
         RAISE;
      END IF;
END Create_Object_Connection; 


PROCEDURE Create_Object_Connection(
   company_              IN VARCHAR2,
   voucher_type_         IN VARCHAR2,
   accounting_year_      IN NUMBER,
   voucher_no_           IN NUMBER,
   row_no_               IN NUMBER,
   account_              IN VARCHAR2,
   debet_amount_         IN NUMBER,
   credit_amount_        IN NUMBER,
   text_                 IN VARCHAR2,
   trans_code_           IN VARCHAR2,
   project_activity_id_  IN NUMBER )
IS
BEGIN
   Create_Object_Connection_(company_,
                             voucher_type_,
                             accounting_year_,
                             voucher_no_,
                             row_no_,
                             account_,
                             debet_amount_,
                             credit_amount_,
                             text_,
                             trans_code_,
                             project_activity_id_);
END Create_Object_Connection;


PROCEDURE Remove_Object_Connection (
   company_             IN VARCHAR2,
   voucher_type_        IN VARCHAR2,
   accounting_year_     IN NUMBER,
   voucher_no_          IN NUMBER,
   row_no_              IN NUMBER,
   project_activity_id_ IN NUMBER )
IS
   remrec_ VOUCHER_ROW_TAB%ROWTYPE;
BEGIN
   remrec_.company             := company_;
   remrec_.voucher_type        := voucher_type_;
   remrec_.accounting_year     := accounting_year_;
   remrec_.voucher_no          := voucher_no_;
   remrec_.row_no              := row_no_;
   remrec_.project_activity_id := project_activity_id_;
   Remove_Object_Connection___(remrec_);
END Remove_Object_Connection;


@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Amount_For_Account (
   company_              IN VARCHAR2,
   internal_seq_number_  IN NUMBER,
   account_              IN VARCHAR2 ) RETURN NUMBER
IS
   amount_                  NUMBER;
   CURSOR get_vou_amount IS
      SELECT NVL(debet_amount, credit_amount ) amount
      FROM   Voucher_Row_Tab
      WHERE  company              = company_
      AND    internal_seq_number  = internal_seq_number_
      AND    account              = account_;
BEGIN
   OPEN  get_vou_amount;
   FETCH get_vou_amount INTO amount_;
   CLOSE get_vou_amount;
   RETURN NVL(amount_, 0);
   RETURN amount_;
END Get_Amount_For_Account;


@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Fetch_Vou_Row_Id (
   company_         IN VARCHAR2,
   voucher_type_    IN VARCHAR2,
   voucher_no_      IN NUMBER,
   accounting_year_ IN NUMBER,
   invoice_id_      IN NUMBER,
   inv_item_id_     IN NUMBER,
   inv_row_id_      IN NUMBER ) RETURN NUMBER
IS
   CURSOR get_inv_row_info IS
      SELECT row_no, inv_acc_row_id
      FROM   Voucher_Row_Tab
      WHERE  company         = company_
      AND    voucher_no      = voucher_no_
      AND    voucher_type    = voucher_type_
      AND    accounting_year = accounting_year_;

   temp_invoice_id_ NUMBER;
   temp_item_id_    NUMBER;
   temp_row_id_     NUMBER;
BEGIN
   FOR rec_ IN get_inv_row_info LOOP
      temp_invoice_id_ := Client_SYS.Get_Item_Value_To_Number('INVOICE_ID', rec_.inv_acc_row_id, lu_name_);
      temp_item_id_    := Client_SYS.Get_Item_Value_To_Number('ITEM_ID', rec_.inv_acc_row_id, lu_name_);
      temp_row_id_     := Client_SYS.Get_Item_Value_To_Number('ROW_ID', rec_.inv_acc_row_id, lu_name_);
      IF temp_invoice_id_ = invoice_id_  AND 
         temp_item_id_    = inv_item_id_ AND
         temp_row_id_     = inv_row_id_ THEN
         RETURN rec_.row_no;
      END IF;
   END LOOP;
   RETURN 0;
END Fetch_Vou_Row_Id;


@UncheckedAccess
FUNCTION Get_Row (
   company_         IN VARCHAR2,
   voucher_type_    IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_      IN NUMBER,
   row_no_          IN NUMBER ) RETURN VOUCHER_ROW_TAB%ROWTYPE
IS
   rec_   VOUCHER_ROW_TAB%ROWTYPE;          
BEGIN
   IF (Company_Finance_API.Is_User_Authorized(company_)) THEN
      rec_ := Get_Object_By_Keys___(company_,
                                    voucher_type_,
                                    accounting_year_,
                                    voucher_no_,
                                    row_no_);
   END IF;
   RETURN rec_;                              
END Get_Row;   


PROCEDURE Internal_Manual_Postings (
   newrec_         IN VOUCHER_ROW_TAB%ROWTYPE,
   is_insert_      IN BOOLEAN DEFAULT FALSE,
   from_pa_        IN BOOLEAN DEFAULT FALSE   )
IS
BEGIN
   Internal_Manual_Postings___(newrec_, is_insert_, from_pa_);
END Internal_Manual_Postings;   


@UncheckedAccess
FUNCTION Get_Pca_Ext_Project (
   company_        IN VARCHAR2) RETURN VARCHAR2
IS
   ext_proj_       VARCHAR2(5) := 'FALSE';
BEGIN
   $IF Component_Percos_SYS.INSTALLED $THEN
      ext_proj_ := Company_Cost_Alloc_Info_API.Get_Pca_Ext_Project(company_); 
   $END
   RETURN ext_proj_;
END Get_Pca_Ext_Project;


@UncheckedAccess
FUNCTION Not_Updated_Code_Part_Exist (
   company_        IN VARCHAR2,
   code_part_      IN VARCHAR2,
   codevalue_      IN VARCHAR2 ) RETURN VARCHAR2
IS
   dummy_          NUMBER;
   CURSOR Code_Control IS
      SELECT 1
      FROM   voucher_tab v, voucher_row_tab vr
      WHERE  v.company           = vr.company
      AND    v.accounting_year   = vr.accounting_year
      AND    v.voucher_no        = vr.voucher_no
      AND    v.voucher_type      = vr.voucher_type
      AND    v.company           = company_
      AND    v.voucher_updated   = 'N'
      AND    DECODE (code_part_, 'A' , account,
                                 'B' , code_b,
                                 'C' , code_c,
                                 'D' , code_d,
                                 'E' , code_e,
                                 'F' , code_f,
                                 'G' , code_g,
                                 'H' , code_h,
                                 'I' , code_i,
                                 'J' , code_j  ) = codevalue_;
BEGIN
   OPEN Code_Control;
   FETCH Code_Control INTO dummy_;
   IF (Code_Control%NOTFOUND) THEN
      CLOSE Code_Control;
      RETURN 'FALSE';
   ELSE
      CLOSE Code_Control;
      RETURN 'TRUE';
   END IF;
END Not_Updated_Code_Part_Exist;


PROCEDURE Update_Row_No(
   company_         IN VARCHAR2,
   voucher_type_    IN VARCHAR2,
   voucher_no_      IN VARCHAR2,
   accounting_year_ IN NUMBER)
IS
   bulk_limit_  CONSTANT NUMBER := 1000;
   count_                NUMBER := 1;
   
   CURSOR get_data IS 
      SELECT row_no,project_activity_id 
      FROM   voucher_row_tab
      WHERE  company         = company_
      AND    voucher_type    = voucher_type_
      AND    voucher_no      = voucher_no_
      AND    accounting_year = accounting_year_
      ORDER BY row_no
      FOR UPDATE;
      
   CURSOR get_voucher_data IS 
      SELECT rowid, row_no, 0 new_row_no 
      FROM   voucher_row_tab
      WHERE  company         = company_
      AND    voucher_type    = voucher_type_
      AND    voucher_no      = voucher_no_
      AND    accounting_year = accounting_year_
      ORDER BY row_no
      FOR UPDATE;

   TYPE get_voucher_data_table_ IS TABLE OF  get_voucher_data%ROWTYPE
        INDEX BY BINARY_INTEGER;
   ref_get_voucher_data_table_               get_voucher_data_table_;
$IF Component_Intled_SYS.INSTALLED $THEN
   update_row_ref_arr_                       Internal_Hold_voucher_Row_API.Update_Row_Ref_Arr; 
$END 
BEGIN
   FOR rec_ IN get_data LOOP
      IF (rec_.project_activity_id IS NOT NULL) THEN
         Remove_Object_Connection(company_,
                                  voucher_type_,
                                  accounting_year_,
                                  voucher_no_,
                                  rec_.row_no,
                                  rec_.project_activity_id);
      END IF;
   END LOOP;
   
   OPEN get_voucher_data;
   LOOP
      FETCH get_voucher_data BULK COLLECT INTO ref_get_voucher_data_table_ LIMIT bulk_limit_;
      FOR i_ IN 1..ref_get_voucher_data_table_.count LOOP
         ref_get_voucher_data_table_(i_).new_row_no := count_;
$IF Component_Intled_SYS.INSTALLED $THEN
         update_row_ref_arr_(i_).new_row_ref     := count_;
         update_row_ref_arr_(i_).company         := company_;
         update_row_ref_arr_(i_).voucher_type    := voucher_type_;
         update_row_ref_arr_(i_).accounting_year := accounting_year_;
         update_row_ref_arr_(i_).voucher_no      := voucher_no_;
         update_row_ref_arr_(i_).old_row_ref     := ref_get_voucher_data_table_(i_).row_no;
$END
         count_ := count_ + 1;    
      END LOOP;

      -- Bug 125057, Begin
      Voucher_API.Update_Current_Row_Num(company_,voucher_type_,accounting_year_,voucher_no_,count_ - 1);
      -- Bug 125057, End

      FORALL j_ IN 1..ref_get_voucher_data_table_.count
         UPDATE voucher_row_tab
         SET row_no  = ref_get_voucher_data_table_(j_).new_row_no
         WHERE rowid = ref_get_voucher_data_table_(j_).rowid;

      FORALL k_ IN 1..ref_get_voucher_data_table_.count
         UPDATE voucher_row_tab
         SET reference_row_no   = ref_get_voucher_data_table_(k_).new_row_no
         WHERE company          = company_
         AND   voucher_type     = voucher_type_
         AND   voucher_no       = voucher_no_
         AND   accounting_year  = accounting_year_
         AND   reference_row_no = ref_get_voucher_data_table_(k_).row_no;

      FORALL m_ IN 1..ref_get_voucher_data_table_.count
         UPDATE period_allocation_tab
         SET   row_no          = ref_get_voucher_data_table_(m_).new_row_no
         WHERE company         = company_
         AND   voucher_type    = voucher_type_
         AND   accounting_year = accounting_year_
         AND   voucher_no      = voucher_no_
         AND   row_no          = ref_get_voucher_data_table_(m_).row_no;

$IF Component_Intled_SYS.INSTALLED $THEN
         Internal_Hold_voucher_Row_API.Update_Multi_Row_Ref(update_row_ref_arr_);
         FOR u_ IN 1..ref_get_voucher_data_table_.count LOOP
            update_row_ref_arr_(u_).new_row_ref            := NULL;
            update_row_ref_arr_(u_).company                := NULL;
            update_row_ref_arr_(u_).voucher_type           := NULL;
            update_row_ref_arr_(u_).accounting_year        := NULL;
            update_row_ref_arr_(u_).voucher_no             := NULL;
            update_row_ref_arr_(u_).old_row_ref            := NULL;
         END LOOP;
$END

      EXIT WHEN get_voucher_data%NOTFOUND;
   END LOOP;

   Create_Object_Connection(company_,
                            voucher_type_,
                            accounting_year_,
                            voucher_no_);
   
END Update_Row_No;


@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Subcon_Used_Cost (
   company_      IN VARCHAR2,
   sub_con_no_   IN VARCHAR2,
   activity_seq_ IN NUMBER,
   account_      IN VARCHAR2 ) RETURN NUMBER
IS
   used_value_            NUMBER;
   used_transaction_      NUMBER;
   t_misc_used_           NUMBER;

   CURSOR get_voucher_row IS
      SELECT *
      FROM   voucher_row_tab t
      WHERE  company               = company_
      AND    t.reference_serie     = sub_con_no_
      AND    t.trans_code          IN ('SCV1', 'SCV2', 'SCV3', 'SCV4', 'SCV6', 'SCV10', 'SCV13', 'SCV15')
      AND    t.project_activity_id = activity_seq_
      AND    t.account             = account_;
BEGIN
   t_misc_used_ := 0;
   FOR voucher_row_rec_ IN get_voucher_row LOOP
      Get_Activity_Info(used_value_,
                        used_transaction_,
                        voucher_row_rec_ );
      t_misc_used_ := t_misc_used_ + nvl(used_value_, 0);
   END LOOP;
   RETURN t_misc_used_;
END Get_Subcon_Used_Cost;


PROCEDURE Get_Subcon_Total_Used_Cost (
   used_cost_        OUT NUMBER,
   used_transaction_ OUT NUMBER,
   company_          IN VARCHAR2,
   sub_con_no_       IN VARCHAR2,
   activity_seq_     IN NUMBER,
   cost_element_     IN VARCHAR2,
   currency_code_    IN VARCHAR2 )
IS
   $IF Component_Subval_SYS.INSTALLED $THEN
      result_              NUMBER;
      result_transaction_  NUMBER;
      used_value_          NUMBER;
     
      CURSOR get_voucher_row IS
               SELECT t.*
                 FROM voucher_row_tab t
                WHERE t.company = company_
                  AND t.reference_serie = sub_con_no_
                  AND t.currency_code = currency_code_
                  AND t.trans_code LIKE ('SCV%')
                  AND t.project_activity_id = activity_seq_
                  AND cost_element_ = Cost_Element_To_Account_API.Get_Project_Follow_Up_Element( t.company,t.account,t.code_b,t.code_c,
                                                                              t.code_d,t.code_e,t.code_f,t.code_g,t.code_h,t.code_i,
                                                                              t.code_j,TRUNC(SYSDATE),'TRUE',t.trans_code)
                UNION
               SELECT v.* 
                 FROM subval_invoice t, invoice i, voucher_row_tab v, cost_element_to_account_tab c 
                WHERE t.invoice_id = i.Invoice_Id
                  AND i.series_id = v.Reference_Serie
                  AND i.invoice_no = v.reference_number
                  AND i.company = v.company
                  AND i.party_type_db = v.party_type
                  AND i.identity = v.party_type_id
                  AND v.company = company_
                  AND t.sub_con_no = sub_con_no_
                  AND v.currency_code = currency_code_
                  AND v.trans_code LIKE ('SCV%')
                  AND v.project_activity_id = activity_seq_
                  AND cost_element_ = Cost_Element_To_Account_API.Get_Project_Follow_Up_Element( v.company,v.account,v.code_b,v.code_c,
                                                                              v.code_d,v.code_e,v.code_f,v.code_g,v.code_h,v.code_i,
                                                                              v.code_j,TRUNC(SYSDATE),'TRUE',v.trans_code);
   $END
BEGIN
   $IF Component_Subval_SYS.INSTALLED $THEN      
      IF (Company_Finance_API.Is_User_Authorized(company_)) THEN
         result_              := 0;
         result_transaction_  := 0;

         FOR voucher_rec_ IN get_voucher_row LOOP
            Voucher_Row_API.Get_Activity_Info(used_value_,
                                              used_transaction_,
                                              voucher_rec_ );
            result_              := result_              + nvl(used_value_, 0);
            result_transaction_  := result_transaction_  + nvl(used_transaction_, 0);

         END LOOP;
         used_cost_          := result_;
         used_transaction_   := result_transaction_;
      END IF;
   $END
   used_cost_          := nvl(used_cost_, 0);
   used_transaction_   := nvl(used_transaction_, 0);
END Get_Subcon_Total_Used_Cost;


PROCEDURE Update_Allocation_Id (
   company_         IN VARCHAR2,
   voucher_type_    IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_      IN NUMBER,
   row_no_          IN NUMBER,
   allocation_id_   IN NUMBER )
IS
BEGIN
   UPDATE VOUCHER_ROW_TAB 
      SET allocation_id = allocation_id_
   WHERE  company         = company_
   AND    voucher_type    = voucher_type_
   AND    accounting_year = accounting_year_
   AND    voucher_no      = voucher_no_
   AND    row_no          = row_no_;
END Update_Allocation_Id;


@UncheckedAccess
FUNCTION Check_Exist_Alloc_Id (
   allocation_id_ IN NUMBER ) RETURN VARCHAR2
IS
   dummy_ NUMBER;
   CURSOR exist_control IS
      SELECT 1
      FROM   VOUCHER_ROW_TAB
      WHERE  allocation_id = allocation_id_;
BEGIN
   OPEN  exist_control;
   FETCH exist_control INTO dummy_;
   IF (exist_control%FOUND) THEN
      CLOSE exist_control;
      RETURN 'TRUE';
   END IF;
   CLOSE exist_control;
   RETURN 'FALSE';
END Check_Exist_Alloc_Id;


PROCEDURE Get_Internal_Code_Parts(
   code_b_              IN OUT VARCHAR2,
   code_c_              IN OUT VARCHAR2,
   code_d_              IN OUT VARCHAR2,
   code_e_              IN OUT VARCHAR2,
   code_f_              IN OUT VARCHAR2,
   code_g_              IN OUT VARCHAR2,
   code_h_              IN OUT VARCHAR2,
   code_i_              IN OUT VARCHAR2,
   code_j_              IN OUT VARCHAR2,
   company_             IN     VARCHAR2,
   accounting_year_     IN     NUMBER,
   voucher_type_        IN     VARCHAR2,
   voucher_no_          IN     NUMBER,
   row_no_              IN     NUMBER,
   internal_code_part_  IN     VARCHAR2)
IS
   code_b_tmp_         VARCHAR2(20);
   code_c_tmp_         VARCHAR2(20);
   code_d_tmp_         VARCHAR2(20);
   code_e_tmp_         VARCHAR2(20);
   code_f_tmp_         VARCHAR2(20);
   code_g_tmp_         VARCHAR2(20);
   code_h_tmp_         VARCHAR2(20);
   code_i_tmp_         VARCHAR2(20);
   code_j_tmp_         VARCHAR2(20);
   
   CURSOR get_code_parts IS
      SELECT code_b,
             code_c,
             code_d,
             code_e,
             code_f,
             code_g,
             code_h,
             code_i,
             code_j
      FROM   VOUCHER_ROW_TAB
      WHERE  company         = company_
      AND    accounting_year = accounting_year_
      AND    voucher_type    = voucher_type_
      AND    voucher_no      = voucher_no_
      AND    row_no          = row_no_;
BEGIN
   OPEN get_code_parts;
   FETCH get_code_parts INTO code_b_tmp_,
                             code_c_tmp_,
                             code_d_tmp_,
                             code_e_tmp_,
                             code_f_tmp_,
                             code_g_tmp_,
                             code_h_tmp_,
                             code_i_tmp_,
                             code_j_tmp_;
   CLOSE get_code_parts;

   IF INSTR(internal_code_part_,'B') >0 THEN
      code_b_ := code_b_tmp_;
   END IF;
   IF INSTR(internal_code_part_,'C') >0 THEN
      code_c_ := code_c_tmp_;
   END IF;
   IF INSTR(internal_code_part_,'D') >0 THEN
      code_d_ := code_d_tmp_;
   END IF;
   IF INSTR(internal_code_part_,'E') >0 THEN
      code_e_ := code_e_tmp_;
   END IF;
   IF INSTR(internal_code_part_,'F') >0 THEN
      code_f_ := code_f_tmp_;
   END IF;
   IF INSTR(internal_code_part_,'G') >0 THEN
      code_g_ := code_g_tmp_;
   END IF;
   IF INSTR(internal_code_part_,'H') >0 THEN
      code_h_ := code_h_tmp_;
   END IF;
   IF INSTR(internal_code_part_,'I') >0 THEN
      code_i_ := code_i_tmp_;
   END IF;
   IF INSTR(internal_code_part_,'J') >0 THEN
      code_j_ := code_j_tmp_;
   END IF;
END Get_Internal_Code_Parts;


-- All_Postings_Transferred_Acc
--   Check if all postings for the specified account and company
--   have been transferred to GL.
--   Should be called from ACCOUNT_API when inert/update exclude_proj_followup.
--   The return value will be the string 'TRUE' if all postings have been
--   transferred, 'FALSE' if not.
@UncheckedAccess
FUNCTION All_Postings_Transferred_Acc (
   company_    IN VARCHAR2,
   account_    IN VARCHAR2) RETURN VARCHAR2

IS
   CURSOR get_non_transferred IS
      SELECT 1
      FROM   voucher_tab v, voucher_row_tab vr
      WHERE  v.company           = company_
      AND    v.company           = vr.company
      AND    v.accounting_year   = vr.accounting_year
      AND    v.accounting_period = vr.accounting_period
      AND    v.voucher_no        = vr.voucher_no
      AND    v.voucher_type      = vr.voucher_type
      AND    v.voucher_updated   = 'N'
      AND    vr.account          = account_;

   dummy_                NUMBER;
   postings_transferred_ VARCHAR2(5);

BEGIN
   OPEN get_non_transferred;
   FETCH get_non_transferred INTO dummy_;
   IF (get_non_transferred%FOUND) THEN
      postings_transferred_ := 'FALSE';
   ELSE
      postings_transferred_ := 'TRUE';
   END IF;
   CLOSE get_non_transferred;

   RETURN postings_transferred_;
END All_Postings_Transferred_Acc;


@UncheckedAccess
FUNCTION Check_Exist_Vourow_with_Pfe (
   company_ IN VARCHAR2 ) RETURN BOOLEAN
IS
   -- Bug Id 111219 change the  v.voucher_no to vr.voucher_no  
   CURSOR get_acc_with_prjacc IS
      SELECT vr.account
      FROM   VOUCHER_TAB v, VOUCHER_ROW_TAB vr
      WHERE  v.company              = vr.company
      AND    v.accounting_year      = vr.accounting_year
      AND    v.voucher_no           = vr.voucher_no
      AND    v.voucher_type         = vr.voucher_type
      AND    v.voucher_updated      = 'N' 
      AND    vr.company             = company_
      AND    vr.project_activity_id IS NOT NULL;
BEGIN
   FOR acc_rec_ IN get_acc_with_prjacc LOOP
      IF (NVL(Account_API.Get_Exclude_Proj_Followup(company_, acc_rec_.account),'FALSE') = 'FALSE') THEN
         RETURN TRUE;
      END IF;
   END LOOP;
   RETURN FALSE;
END Check_Exist_Vourow_with_Pfe;


PROCEDURE Get_Activity_Info (
   used_value_       OUT NUMBER,
   used_trans_value_ OUT NUMBER,
   newrec_           IN  VOUCHER_ROW_TAB%ROWTYPE )
IS
   vou_group_            VARCHAR2(10);
   acc_type_             VARCHAR2(1);
   amount_              NUMBER;
   transaction_amount_  NUMBER;
BEGIN
   acc_type_            := Account_API.Get_Logical_Account_Type_Db(newrec_.company, newrec_.account);
   amount_              := NVL(newrec_.debet_amount,0) - NVL(newrec_.credit_amount,0);
   transaction_amount_  := NVL(newrec_.currency_debet_amount,0) - NVL(newrec_.currency_credit_amount,0);
   IF acc_type_ != 'R' THEN
      vou_group_ := substr(Voucher_Type_API.Get_Voucher_Group(newrec_.company, newrec_.voucher_type), 1, 2);
      IF (vou_group_ = 'T') THEN
         IF (newrec_.trans_code IN ('PRJT1', 'PRJT2', 'PRJT3', 'PRJT4', 'PRJT5', 'PRJT6', 'PRJT7', 'PRJT8', 'PRJT12', 'PRJT13','T1' , 'PRJC1', 'PRJC2', 'PRJC3', 'PRJC4', 'PRJC5', 'PRJC6', 'PRJC9', 'PRJC10')) THEN
            used_value_       := amount_;
            used_trans_value_ := transaction_amount_;
         END IF;
      ELSIF (vou_group_ = 'E') THEN
         IF (newrec_.trans_code IN ('TX1', 'TX4', 'TX6')) THEN
            used_value_       := amount_;
            used_trans_value_ := transaction_amount_;
         END IF;         
      ELSE
         used_value_       := amount_;
         used_trans_value_ := transaction_amount_;
      END IF;
   ELSE
      used_value_       := amount_;
      used_trans_value_ := transaction_amount_;
   END IF;
END Get_Activity_Info;


PROCEDURE Refresh_Connection_Header (
   company_                    IN  VARCHAR2,
   voucher_type_               IN  VARCHAR2,
   accounting_year_            IN  NUMBER,
   voucher_no_                 IN  NUMBER,
   row_no_                     IN  NUMBER )
IS
   rec_                       VOUCHER_ROW_TAB%ROWTYPE;
   dummy_                     VARCHAR2(10);
   
BEGIN
   
   $IF Component_Proj_SYS.INSTALLED $THEN
      rec_ := Get_Object_By_Keys___(company_, 
                                    voucher_type_, 
                                    accounting_year_, 
                                    voucher_no_, 
                                    row_no_);
      -- Here we send client value of Voucher State as it does in other object connections         
      -- eventhough it is not a good practice since decoding of server value is not supported
      -- by the PROJECT_CONNECTIONS_SUMMARY View in PROJ due to performance reasons.      
      Project_Connection_Util_API.Refresh_Header_And_Dates( rec_.project_activity_id,
                                                            company_,
                                                            voucher_type_,
                                                            accounting_year_,
                                                            voucher_no_,
                                                            row_no_,
                                                            dummy_,
                                                            'VR',
                                                            'VoucherRow',
                                                            rec_.voucher_date); 
   $ELSE
      NULL;  
   $END

END Refresh_Connection_Header;


@UncheckedAccess
FUNCTION Fetch_Exclude_Periodical_Cap(
   company_              IN VARCHAR2,
   account_              IN VARCHAR2,
   project_activity_id_  IN NUMBER ) RETURN VARCHAR2
IS
      act_excl_per_db_ VARCHAR2(5);
BEGIN
   IF Account_API.Get_Exclude_Periodical_Cap_Db(company_, account_) IN ('EXCLUDE_IN_ALL', 'EXCLUDE_IN_GL') THEN
      RETURN 'TRUE';
   ELSE
      $IF Component_Proj_SYS.INSTALLED $THEN
         IF (project_activity_id_ IS NOT NULL) THEN 
            act_excl_per_db_ := Activity_API.Get_Exclude_Periodical_Cap_Db( project_activity_id_);
         END IF;
         IF act_excl_per_db_ IN ('EXCLUDE_IN_ALL', 'EXCLUDE_IN_GL') THEN
            RETURN 'TRUE';
         END IF;
      $ELSE
         NULL;
      $END
   END IF;
   RETURN 'FALSE';
END;


@UncheckedAccess
FUNCTION Get_Parallel_Currency_Rate (
   company_          IN VARCHAR2,
   voucher_type_     IN VARCHAR2,
   accounting_year_  IN NUMBER,
   voucher_no_       IN NUMBER,
   row_no_           IN NUMBER ) RETURN NUMBER
IS
   temp_ VOUCHER_ROW_TAB.parallel_currency_rate%TYPE;
   CURSOR get_attr IS
      SELECT parallel_currency_rate
      FROM   VOUCHER_ROW_TAB
      WHERE  company = company_
       AND   voucher_type = voucher_type_
       AND   accounting_year = accounting_year_
       AND   voucher_no = voucher_no_
       AND   row_no = row_no_;
BEGIN
   OPEN get_attr;
   FETCH get_attr INTO temp_;
   CLOSE get_attr;
   RETURN temp_;
END Get_Parallel_Currency_Rate;


@UncheckedAccess
FUNCTION Get_Parallel_Conversion_Factor (
   company_          IN VARCHAR2,
   voucher_type_     IN VARCHAR2,
   accounting_year_  IN NUMBER,
   voucher_no_       IN NUMBER,
   row_no_           IN NUMBER ) RETURN NUMBER
IS
   temp_ VOUCHER_ROW_TAB.parallel_conversion_factor%TYPE;
   CURSOR get_attr IS
      SELECT parallel_conversion_factor
      FROM   VOUCHER_ROW_TAB
      WHERE  company = company_
       AND   voucher_type = voucher_type_
       AND   accounting_year = accounting_year_
       AND   voucher_no = voucher_no_
       AND   row_no = row_no_;
BEGIN
   OPEN get_attr;
   FETCH get_attr INTO temp_;
   CLOSE get_attr;
   RETURN temp_;
END Get_Parallel_Conversion_Factor;


@UncheckedAccess
FUNCTION Get_Parallel_Curr_Tax_Amount (
   company_          IN VARCHAR2,
   voucher_type_     IN VARCHAR2,
   accounting_year_  IN NUMBER,
   voucher_no_       IN NUMBER,
   row_no_           IN NUMBER ) RETURN NUMBER
IS
   temp_ VOUCHER_ROW_TAB.parallel_curr_tax_amount%TYPE;
   CURSOR get_attr IS
      SELECT parallel_curr_tax_amount
      FROM   VOUCHER_ROW_TAB
      WHERE  company = company_
       AND   voucher_type = voucher_type_
       AND   accounting_year = accounting_year_
       AND   voucher_no = voucher_no_
       AND   row_no = row_no_;
BEGIN
   OPEN get_attr;
   FETCH get_attr INTO temp_;
   CLOSE get_attr;
   RETURN temp_;
END Get_Parallel_Curr_Tax_Amount;


@UncheckedAccess
FUNCTION Get_Parallel_Curr_Gross_Amount (
   company_          IN VARCHAR2,
   voucher_type_     IN VARCHAR2,
   accounting_year_  IN NUMBER,
   voucher_no_       IN NUMBER,
   row_no_           IN NUMBER ) RETURN NUMBER
IS
   temp_ VOUCHER_ROW_TAB.parallel_curr_gross_amount%TYPE;
   CURSOR get_attr IS
      SELECT parallel_curr_gross_amount
      FROM   VOUCHER_ROW_TAB
      WHERE  company = company_
       AND   voucher_type = voucher_type_
       AND   accounting_year = accounting_year_
       AND   voucher_no = voucher_no_
       AND   row_no = row_no_;
BEGIN
   OPEN get_attr;
   FETCH get_attr INTO temp_;
   CLOSE get_attr;
   RETURN temp_;
END Get_Parallel_Curr_Gross_Amount;


@UncheckedAccess
FUNCTION Get_Parallel_Curr_Tax_Base_Amt (
   company_          IN VARCHAR2,
   voucher_type_     IN VARCHAR2,
   accounting_year_  IN NUMBER,
   voucher_no_       IN NUMBER,
   row_no_           IN NUMBER ) RETURN NUMBER
IS
   temp_ VOUCHER_ROW_TAB.parallel_curr_tax_base_amount%TYPE;
   CURSOR get_attr IS
      SELECT parallel_curr_tax_base_amount
      FROM   VOUCHER_ROW_TAB
      WHERE  company = company_
       AND   voucher_type = voucher_type_
       AND   accounting_year = accounting_year_
       AND   voucher_no = voucher_no_
       AND   row_no = row_no_;
BEGIN
   OPEN get_attr;
   FETCH get_attr INTO temp_;
   CLOSE get_attr;
   RETURN temp_;
END Get_Parallel_Curr_Tax_Base_Amt;


@UncheckedAccess
FUNCTION Get_Parallel_Curr_Rate_Type(
   company_          IN VARCHAR2,
   voucher_type_     IN VARCHAR2,
   accounting_year_  IN NUMBER,
   voucher_no_       IN NUMBER,
   row_no_           IN NUMBER ) RETURN VARCHAR2
IS
   temp_ VOUCHER_ROW_TAB.parallel_curr_rate_type%TYPE;
   CURSOR get_attr IS
      SELECT parallel_curr_rate_type
      FROM   VOUCHER_ROW_TAB
      WHERE  company = company_
       AND   voucher_type = voucher_type_
       AND   accounting_year = accounting_year_
       AND   voucher_no = voucher_no_
       AND   row_no = row_no_;
BEGIN
   OPEN get_attr;
   FETCH get_attr INTO temp_;
   CLOSE get_attr;
   RETURN temp_;
END Get_Parallel_Curr_Rate_Type;



@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Sum_Parallel_Tax_Amount (
   company_            IN VARCHAR2,
   accounting_year_    IN NUMBER,
   voucher_type_       IN VARCHAR2,
   voucher_no_         IN NUMBER,
   function_group_     IN VARCHAR2 DEFAULT NULL ) RETURN NUMBER
IS
   tax_sum_amount_          NUMBER;
   CURSOR tax_sum_currency_amount IS
      SELECT SUM(NVL(parallel_curr_tax_amount,0) )
      FROM   accounting_code_part_value_tab a,
             voucher_row_tab v
      WHERE  v.company         = company_
      AND    v.voucher_type    = voucher_type_
      AND    v.accounting_year = accounting_year_
      AND    v.voucher_no      = voucher_no_
      AND    a.company         = v.company
      AND    a.code_part       = 'A'
      AND    a.code_part_value = v.account
      AND    a.stat_account    = 'N';

   CURSOR tax_sum_currency_amount_yr_end IS
      SELECT SUM(NVL(parallel_curr_tax_amount,0) )
      FROM   accounting_code_part_value_tab a,
             voucher_row_tab v
      WHERE  v.company               = company_
      AND    v.voucher_type          = voucher_type_
      AND    v.accounting_year       = accounting_year_
      AND    v.voucher_no            = voucher_no_
      AND    a.company               = v.company
      AND    a.code_part             = 'A'
      AND    a.code_part_value       = v.account
      AND    a.stat_account          = 'N'
      AND    a.logical_account_type != 'O';
BEGIN  
   IF ( function_group_ IS NOT NULL AND function_group_ = 'YE') THEN
      OPEN  tax_sum_currency_amount_yr_end;
      FETCH tax_sum_currency_amount_yr_end INTO tax_sum_amount_;
      CLOSE tax_sum_currency_amount_yr_end;
   ELSE
      OPEN  tax_sum_currency_amount;
      FETCH tax_sum_currency_amount INTO tax_sum_amount_;
      CLOSE tax_sum_currency_amount;
   END IF;
   RETURN tax_sum_amount_; 
END Sum_Parallel_Tax_Amount;

@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Sum_Parallel_Currency_Amount (
   company_            IN VARCHAR2,
   accounting_year_    IN NUMBER,
   voucher_type_       IN VARCHAR2,
   voucher_no_         IN NUMBER,
   function_group_     IN VARCHAR2 DEFAULT NULL ) RETURN NUMBER
IS
   sum_amount_          NUMBER;
   CURSOR sum_currency_amount IS
      SELECT SUM(NVL(third_currency_debit_amount,0) - NVL(third_currency_credit_amount,0) )
      FROM   accounting_code_part_value_tab a,
             voucher_row_tab v
      WHERE  v.company         = company_
      AND    v.voucher_type    = voucher_type_
      AND    v.accounting_year = accounting_year_
      AND    v.voucher_no      = voucher_no_
      AND    a.company         = v.company
      AND    a.code_part       = 'A'
      AND    a.code_part_value = v.account
      AND    a.stat_account    = 'N';

   CURSOR sum_currency_amount_yr_end IS
      SELECT SUM(NVL(third_currency_debit_amount,0) - NVL(third_currency_credit_amount,0) )
      FROM   accounting_code_part_value_tab a,
             voucher_row_tab v
      WHERE  v.company               = company_
      AND    v.voucher_type          = voucher_type_
      AND    v.accounting_year       = accounting_year_
      AND    v.voucher_no            = voucher_no_
      AND    a.company               = v.company
      AND    a.code_part             = 'A'
      AND    a.code_part_value       = v.account
      AND    a.stat_account          = 'N'
      AND    a.logical_account_type != 'O';

BEGIN
   IF ( function_group_ IS NOT NULL AND function_group_ = 'YE') THEN
      OPEN  sum_currency_amount_yr_end;
      FETCH sum_currency_amount_yr_end INTO sum_amount_;
      CLOSE sum_currency_amount_yr_end;
   ELSE
      OPEN  sum_currency_amount;
      FETCH sum_currency_amount INTO sum_amount_;
      CLOSE sum_currency_amount;
   END IF;
   RETURN sum_amount_;
END Sum_Parallel_Currency_Amount;


PROCEDURE Postings_X_In_Voucher_Row (
   result_     OUT   VARCHAR2,
   company_    IN    VARCHAR2,
   code_part_  IN    VARCHAR2 )
IS
BEGIN
   IF (Check_If_Code_Part_Used___(company_, code_part_)) THEN
      result_ := 'TRUE';
   ELSE
      result_ := 'FALSE';
   END IF;
END Postings_X_In_Voucher_Row;


@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Currency_Rate (
   company_         IN VARCHAR2,
   voucher_type_    IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_      IN NUMBER,
   trans_code_      IN VARCHAR2 ) RETURN NUMBER
IS
   temp_ VOUCHER_ROW_TAB.currency_rate%TYPE;
   CURSOR get_attr IS
      SELECT currency_rate
      FROM   VOUCHER_ROW_TAB
      WHERE  company         = company_
      AND    voucher_type    = voucher_type_
      AND    accounting_year = accounting_year_
      AND    voucher_no      = voucher_no_
      AND    trans_code     = trans_code_;
BEGIN
   OPEN get_attr;
   FETCH get_attr INTO temp_;
   CLOSE get_attr;
   RETURN temp_;
END Get_Currency_Rate;

@Override
@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Text (
   company_ IN VARCHAR2,
   voucher_type_ IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_ IN NUMBER,
   row_no_ IN NUMBER ) RETURN VARCHAR2
IS
BEGIN
   RETURN super(company_, voucher_type_, accounting_year_, voucher_no_, row_no_);
END Get_Text;

@Override
@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Party_Type_Id (
   company_ IN VARCHAR2,
   voucher_type_ IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_ IN NUMBER,
   row_no_ IN NUMBER ) RETURN VARCHAR2
IS
BEGIN
   RETURN super(company_, voucher_type_, accounting_year_, voucher_no_, row_no_);
END Get_Party_Type_Id;

@Override
@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Corrected (
   company_ IN VARCHAR2,
   voucher_type_ IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_ IN NUMBER,
   row_no_ IN NUMBER ) RETURN VARCHAR2
IS
BEGIN
   RETURN super(company_, voucher_type_, accounting_year_, voucher_no_, row_no_);
END Get_Corrected;   

@Override
@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Currency_Rate (
   company_ IN VARCHAR2,
   voucher_type_ IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_ IN NUMBER,
   row_no_ IN NUMBER ) RETURN NUMBER
IS
BEGIN
   RETURN super(company_, voucher_type_, accounting_year_, voucher_no_, row_no_);
END Get_Currency_Rate;  

@Override
@UncheckedAccess
@SecurityCheck Company.UserAuthorized(company_)
FUNCTION Get_Allocation_Id (
   company_ IN VARCHAR2,
   voucher_type_ IN VARCHAR2,
   accounting_year_ IN NUMBER,
   voucher_no_ IN NUMBER,
   row_no_ IN NUMBER ) RETURN NUMBER
IS
BEGIN
   RETURN super(company_, voucher_type_, accounting_year_, voucher_no_, row_no_);
END Get_Allocation_Id;  

PROCEDURE Validate_Delivery_Type_Id__ (
   company_           IN VARCHAR2,
   delivery_type_id_      IN VARCHAR2)
IS
BEGIN
   $IF Component_Invoic_SYS.INSTALLED $THEN
      Delivery_Type_API.Exist (company_, delivery_type_id_);
   $ELSE 
      NULL;
   $END 
END Validate_Delivery_Type_Id__;

@UncheckedAccess
FUNCTION Get_Delivery_Type_Description(
   company_ IN VARCHAR2,
   deliv_type_id_ IN VARCHAR2 ) RETURN VARCHAR2
IS 
   -- Bug 123956, Begin
   ret_ VARCHAR2(2000);
   -- Bug 123956, End
BEGIN
   $IF Component_Invoic_SYS.INSTALLED $THEN
      ret_ := Delivery_Type_API.Get_Description(company_,deliv_type_id_);
   $END                                           
   RETURN ret_;
END Get_Delivery_Type_Description;


PROCEDURE Create_Row (
   company_         IN VARCHAR2,
   voucher_type_    IN VARCHAR2,
   voucher_no_      IN NUMBER,
   accounting_year_ IN NUMBER,
   row_ref_         IN NUMBER)     
IS
   newrec_          Voucher_Row_Tab%ROWTYPE;   
BEGIN

   newrec_ := Get_Row(company_,
                      voucher_type_,
                      accounting_year_,
                      voucher_no_,
                      row_ref_);

   Internal_Manual_Postings(newrec_,
                            TRUE);
END Create_Row;