-----------------------------------------------------------------------------
--
--  Logical unit: AccountingCodePartValue
--  Component:    ACCRUL
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  960404  MIJO  Created.
--  960528  ToRe  Validation of ac code part is only performed if not null in
--                function Validate_Code_Part.
--  970624  SLKO  Converted to Foundation1 1.2.2d
--  970627  PICZ  Added columns: CONS_COMPANY abd CONS_CODE_PART_VALUE;
--                procedure Validate_Cons_Value___;
--                Consolidation functions: Validate_Parent_Code_Part_Val  and
--                Clear_Parent_Code_Part_Val
--  970722  PICZ  Removed call to Validate_Cons_Value___ in Unpack_Check_Insert___;
--                Fixed uncorrect checks for cons_company and cons_code_part_value
--                Added method Calcul_Parent_Code_Part_Value
--  970901  PICZ  Added function Codepart_Exist_In_Cons_Company
--  970812  ANDJ  Fixed Bug 97-0033. Changed description_ to VARCHAR2(100).
--  971001  PICZ  Fixed bug in Get_Cons_Code_Part_Value
--  971103  PICZ  Fixed bug in Validate_Cons_Value___: veryfing aginst consolidation
--                code part and consolidation company
--  980107  SLKO  Converted to Foundation1 2.0.0
--  980123  PICZ  Added function: Code_Part_Value_Exist
--  980211  PICZ  Added Are_Changed_Values
--  980217  PICZ  Changed condition in Are_Changed_Values's cursor;
--                removed outputs
--  980225  PICZ  Added column CONS_CODE_PART
--  980325  PICZ  Changed Unpack_Check_Insert (bug 1315)
--  980811  Kanchi Added view Code_P_Value_For_Cons_Tmp for orrection bug #4975 Kanchi
--  980708  Kanchi Modified this file to redirect all functions calls to Code_* Lu ( code*.ap*)
--                 [ Moving Code Parts to individual LU:s ]
--                 Ex.  Accounting_Code_Part_Value    -->   CodeB Lu:
                                                      -->   CodeC Lu: etc
--  980916  Ruwan  Removed the Get_Description overloaded function(Bug ID:4973)
--  990416  Ruwan  Modified with respect to new template
--  010219  ARMOLK Bug # 15677 Add call to General_SYS.Init_Method
--  010221  ToOs   Bug # 20177 Added Global Lu constants for check for transaction_sys calls
--  010410  JeGu   Bug #21018 Changed some functions/procedures wich are common to all codepart-LU's
--                 ** From now all this type of functions/procedures are put in this package **
--  010509  JeGu     Bug #21705 Implementation New Dummyinterface
--  010531  NiWi   #20510 - New veiw ACCOUNTING_CODEPART_VAL_FINREP is added (to used only in finrep)
--  010612  ARMOLK Bug # 15677 Add call to General_SYS.Init_Method
--  010922  Chablk Bug # 22010 fixed. Add a new column accnt_type to Accounting_Code_Part_value view
--  020207  MaNi   Company Translation support, replaced TextFielsTranslation.
--  020826  Rora  Bug# 32112 ,added new functiona called Check_Cons_Code_Part_Value.
--  021002  Nimalk   Removed usage of the view Company_Finance_Auth in ACCOUNTING_CODE_PART_VALUE
--                   CODE_PART_VALUE_FOR_CONS and CODE_P_VALUE_FOR_CONS_TMP view
--                   and replaced by view Company_Finance_Auth1 using EXISTS caluse instead of joins
--  021211  ovjose Added the field description to LU.
--  021224  ISJALK SP3 merge, Bug 34188.
--  030618  Thsrlk   IIID DEFI159N - Add new view BUDGET_ACC_CODE_PART_VALUE
--  050201  nsillk   Merged Bug 42667.
--  051024  Nsillk  Removed views BUDGET_ACC_CODE_PART_VALUE and CODE_P_VALUE_FOR_CONS_TMP
--                  because they are not used anymore.
--  051229  Nsillk  LCS Merge (54796/54798).
--  050103  Nsillk  Added view BUDGET_ACC_CODE_PART_VALUE because it is used.
--  060215  Nsillk  Changed the size of sort_value to 20.
--  060727  DHSELK  Modified to_date() function to work with Persian Calander.
--  081022  MAKRLK  Bug 76650 corrected. Added new method Validate_Code_Part().
--  090605  THPELK  Bug 82609 - Removed the aditional UNDEFINE statement for VIEW_CONS_TMP.
--  091209  HimRlk  Reverse engineering, Added REF to AccountingCodeParts from column code_part in view comments
--  091209          in ACCOUNTING_CODE_PART_VALUE view.
--  110322  DIFELK  RAVEN-1930, modifications done to Check_Delete___ related code.
--  110528  THPELK  EASTONE-21645 Added missing General_SYS and PRAGMA.
--  110826  MAAYLK  FIDEAGLE-306 LCS Merge 95982, Moved method Validate_Cons_Value__(), Get_Code_Part_Function__() methods in other code part pkgs into this package
--  111018  Shdilk  SFI-135, Conditional compilation.
--  120514  SALIDE   EDEL-698, Added VIEW_AUDIT
--  121123  Thpelk  Bug 106680 - Modified Conditional compilation to use single component package.
--  121204  Maaylk  PEPA-183, Removed global variables
--  130816  Clstlk  Bug 111221, Corrected functions without RETURN statement in all code paths.
--  131101  Hiralk  PBFI-572, Removed obsolete lu NcfNorwegianTax.
--  131204  Janblk  PBFI-892, Refactoring in AccountingCodePartValue entity
--  131204  MEALLK  PBFI-1984, modified code in Get_Description.
--  131205  MEALLK  PBFI-1985, modifed code in Get_Description.
--  150810  Maaylk  Bug 123649, Added code to check if code_part exists in Code_part_value tab into Check_Delete___()
-- **************************************************************************************
-- ** DO NOT MODIFY ANY FUNCTION IN THIS FILE. DO ALL MODIFICATIONS IN THE CORRECT LU: **
--    IT WILL ONLY BE WITH COMMON FUNCS/PROCS WHICH ARE COMMON TO ALL THE LUs.
--    ALL VIEWS ARE COPIED TO CODE_* LU,
--     ***  WHEN MODIFIYING VIEWS PLEASE REFLECT THE CHANGE IN BOTH FILES  ( Accounting_Code_Part_Value   AND  Code_* Lu )
--    In all views in the Code_* lus, Code_Part is removed and Code_Part_Value
--    is renamed to Code_*.
--    ex.   Accounting_Code_Part_value          Code_B        Code_C      Code_D
--          ---------------------------------------------------------------------
--                 CODE_PART_VALUE              CODE_B        CODE_C      CODE_D
-- *************************************************************************************
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------
TYPE Public_Rec IS RECORD
  (company                        ACCOUNTING_CODE_PART_VALUE_TAB.company%TYPE,
   code_part_value                ACCOUNTING_CODE_PART_VALUE_TAB.code_part_value%TYPE,
   "rowid"                        rowid,
   rowversion                     ACCOUNTING_CODE_PART_VALUE_TAB.rowversion%TYPE,
   rowkey                         ACCOUNTING_CODE_PART_VALUE_TAB.rowkey%TYPE,
   rowtype                        ACCOUNTING_CODE_PART_VALUE_TAB.rowtype%TYPE,
   valid_from                     ACCOUNTING_CODE_PART_VALUE_TAB.valid_from%TYPE,
   valid_until                    ACCOUNTING_CODE_PART_VALUE_TAB.valid_until%TYPE,
   accounting_text_id             ACCOUNTING_CODE_PART_VALUE_TAB.accounting_text_id%TYPE);


-------------------- PRIVATE DECLARATIONS -----------------------------------


-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------
PROCEDURE Raise_Too_Many_Rows___ (
   company_ IN VARCHAR2,
   code_part_value_ IN VARCHAR2,
   methodname_ IN VARCHAR2 )
IS
BEGIN
   Error_SYS.Too_Many_Rows(Accounting_Code_Part_Value_API.lu_name_, NULL, methodname_);
END Raise_Too_Many_Rows___;

PROCEDURE Raise_Record_Not_Exist___ (
   company_ IN VARCHAR2,
   code_part_value_ IN VARCHAR2 )
IS
   
BEGIN
   Error_SYS.Record_Not_Exist(Accounting_Code_Part_Value_API.lu_name_);
END Raise_Record_Not_Exist___;



FUNCTION Check_Exist___ (
   company_ IN VARCHAR2,
   code_part_value_ IN VARCHAR2 ) RETURN BOOLEAN
IS
   dummy_ NUMBER;
BEGIN
   SELECT 1
      INTO  dummy_
      FROM  accounting_code_part_value_tab
      WHERE company = company_
      AND   code_part_value = code_part_value_;
   RETURN TRUE;
EXCEPTION
   WHEN no_data_found THEN
      RETURN FALSE;
   WHEN too_many_rows THEN
      Raise_Too_Many_Rows___(company_, code_part_value_, 'Check_Exist___');

END Check_Exist___;



PROCEDURE Prepare_Insert___ (
   attr_ IN OUT VARCHAR2 )
IS
   company_        ACCOUNTING_CODE_PART_VALUE_TAB.company%TYPE;
   cons_company_   ACCOUNTING_CODE_PART_VALUE.cons_company%TYPE;
BEGIN
   company_      := Client_SYS.Get_Item_Value( 'COMPANY', attr_ );
   cons_company_ := Company_Finance_API.Get_Cons_Company(company_);
   Client_SYS.Clear_Attr(attr_);
   Client_SYS.Add_To_Attr( 'VALID_FROM', SYSDATE, attr_);
   Client_SYS.Add_To_Attr( 'VALID_UNTIL', to_date('20991231', 'YYYYMMDD', 'NLS_CALENDAR=GREGORIAN'), attr_);
   IF (cons_company_ IS NOT NULL) THEN
      Client_SYS.Add_To_Attr( 'CONS_COMPANY',cons_company_, attr_ );
   END IF;
END Prepare_Insert___;




@SecurityCheck Company.UserExist(remrec_.company)
PROCEDURE Check_Delete___ (
   remrec_ IN ACCOUNTING_CODE_PART_VALUE_TAB%ROWTYPE )
IS
   key_      VARCHAR2(2000);
   used_     VARCHAR2(5);
   function_ VARCHAR2(10);
BEGIN
   -- <<<Put your code here for all attribute checking before deleting object>>>
   function_ := Accounting_Code_Parts_Api.Get_Code_Part_Function_Db(remrec_.company, remrec_.code_part);
   Check_Delete_Allowed_Parent (remrec_.company, remrec_.code_part_value, remrec_.code_part);   
   
   -- Check, if codepart value is used either in wait table or in general ledger ...
   used_ := Voucher_Row_API.Is_Code_Part_Value_Used(remrec_.company,
                                                    remrec_.code_part,
                                                    remrec_.code_part_value);
   IF (used_ = 'TRUE') THEN
      IF function_ = 'FAACC' THEN
         Error_SYS.Record_General(lu_name_,
                               'CHKDELFA_1: Object :P1 is used in wait table',
                               remrec_.code_part_value);      
      ELSIF function_ = 'PRACC' THEN
         Error_SYS.Record_General(lu_name_,
                               'CHKDELPR_1: Project :P1 is used in wait table',
                               remrec_.code_part_value);      
      ELSE
         Error_SYS.Record_General(lu_name_,
                               'CHKDEL_1: Codepart value :P1 is used in wait table',
                               remrec_.code_part_value);
      END IF;   
   END IF;

   $IF Component_Genled_SYS.INSTALLED $THEN
      Gen_Led_Voucher_Row_API.Is_Code_Part_Value_Used ( remrec_.company,
                                                        remrec_.code_part,
                                                        remrec_.code_part_value );

      Budget_Year_Amount_API.Exist_Code_Part_Value ( remrec_.company,
                                                     remrec_.code_part,
                                                     remrec_.code_part_value );
   $END
   -- Bug 123649, Begin
   $IF Component_Intled_SYS.INSTALLED $THEN
      Internal_Hold_Voucher_Row_API.Is_Code_Part_Value_Used(remrec_.company,
                                                            remrec_.code_part,
                                                            remrec_.code_part_value );
      
      Internal_Voucher_Row_API.Is_Code_Part_Value_Used(remrec_.company,
                                                       remrec_.code_part,
                                                       remrec_.code_part_value );
   $END
   -- Bug 123649, End
   IF NOT Accounting_Codestr_Compl_API.Check_Delete_Allowed_( remrec_.company, remrec_.code_part_value, remrec_.code_part) THEN
      IF function_ = 'FAACC' THEN
         Error_SYS.Record_General(lu_name_,
            'OBEXISTINCOMPL: Delete not allowed. Object :P1 exist in codestring completion.',
            remrec_.code_part_value);      
      ELSIF function_ = 'PRACC' THEN
         Error_SYS.Record_General(lu_name_,
            'PREXISTINCOMPL: Delete not allowed. Project :P1 exist in codestring completion.',
            remrec_.code_part_value);
      ELSE
         Error_SYS.Record_General(lu_name_,
            'CPEXISTINCOMPL: Delete not allowed. Codepart value :P1 exist in codestring completion.',
            remrec_.code_part_value);
      END IF;   
   END IF;   
   Check_Delete_Allowed2 ( remrec_.company, remrec_.code_part_value , remrec_.code_part, function_);

   key_ := remrec_.company||'^'||remrec_.code_part||'^'||remrec_.code_part_value||'^';
   Reference_SYS.Check_Restricted_Delete(lu_name_, key_);
   
END Check_Delete___;



PROCEDURE Delete___ (
   objid_  IN VARCHAR2,
   remrec_ IN ACCOUNTING_CODE_PART_VALUE_TAB%ROWTYPE )
IS
   key_ VARCHAR2(2000);
BEGIN
   key_ := remrec_.company||'^'||remrec_.code_part_value||'^';
   Reference_SYS.Do_Cascade_Delete(lu_name_, key_);
   DELETE
      FROM  accounting_code_part_value_tab
      WHERE rowid = objid_;

  Enterp_Comp_Connect_V170_API.Remove_Company_Attribute_Key( remrec_.company,
                                                              'ACCRUL',
                                                              ACCOUNTING_CODE_PART_VALUE_API.Get_Lu_For_Code_Part__(remrec_.company, remrec_.code_part),
                                                              remrec_.code_part_value );   
    
END Delete___;


FUNCTION Check_Exist___ (
   company_         IN VARCHAR2,
   code_part_       IN VARCHAR2,
   code_part_value_ IN VARCHAR2 ) RETURN BOOLEAN
IS
   dummy_ NUMBER;
   CURSOR exist_control IS
      SELECT 1
      FROM   accounting_code_part_value_tab
      WHERE  company = company_
      AND    code_part = code_part_
      AND    code_part_value = code_part_value_;
BEGIN
   OPEN exist_control;
   FETCH exist_control INTO dummy_;
   IF (exist_control%FOUND) THEN
      CLOSE exist_control;
      RETURN(TRUE);
   END IF;
   CLOSE exist_control;
   RETURN(FALSE);
END Check_Exist___;

FUNCTION Get_Object_By_Keys___ (
   company_ IN VARCHAR2,
   code_part_ IN VARCHAR2,
   code_part_value_ IN VARCHAR2 ) RETURN ACCOUNTING_CODE_PART_VALUE_TAB%ROWTYPE
IS
   lu_rec_ ACCOUNTING_CODE_PART_VALUE_TAB%ROWTYPE;
   CURSOR getrec IS
      SELECT *
      FROM  accounting_code_part_value_tab
      WHERE company = company_
      AND   code_part = code_part_
      AND   code_part_value = code_part_value_;
BEGIN
   OPEN getrec;
   FETCH getrec INTO lu_rec_;
   CLOSE getrec;
   RETURN(lu_rec_);
END Get_Object_By_Keys___;

FUNCTION Get_Object_By_Id___ (
   objid_ IN VARCHAR2 ) RETURN ACCOUNTING_CODE_PART_VALUE_TAB%ROWTYPE
IS
   lu_rec_ ACCOUNTING_CODE_PART_VALUE_TAB%ROWTYPE;
   CURSOR getrec IS
      SELECT *
      FROM   ACCOUNTING_CODE_PART_VALUE_TAB
      WHERE  rowid = objid_;
BEGIN
   OPEN getrec;
   FETCH getrec INTO lu_rec_;
   IF (getrec%NOTFOUND) THEN
      Error_SYS.Record_Removed(lu_name_);
   END IF;
   CLOSE getrec;
   RETURN(lu_rec_);
END Get_Object_By_Id___;

FUNCTION Lock_By_Id___ (
   objid_      IN  VARCHAR2,
   objversion_ IN  VARCHAR2 ) RETURN ACCOUNTING_CODE_PART_VALUE_TAB%ROWTYPE
IS
   row_changed EXCEPTION;
   row_deleted EXCEPTION;
   row_locked  EXCEPTION;
   PRAGMA      exception_init(row_locked, -0054);
   rec_        ACCOUNTING_CODE_PART_VALUE_TAB%ROWTYPE;
   dummy_      NUMBER;
   CURSOR lock_control IS
      SELECT *
      FROM   ACCOUNTING_CODE_PART_VALUE_TAB
      WHERE  rowid = objid_
      AND    ltrim(lpad(to_char(rowversion,'YYYYMMDDHH24MISS'),2000)) = objversion_
      FOR UPDATE NOWAIT;
   CURSOR exist_control IS
      SELECT 1
      FROM   ACCOUNTING_CODE_PART_VALUE_TAB
      WHERE  rowid = objid_;
BEGIN
   OPEN lock_control;
   FETCH lock_control INTO rec_;
   IF (lock_control%FOUND) THEN
      CLOSE lock_control;
      RETURN rec_;
   END IF;
   CLOSE lock_control;
   OPEN exist_control;
   FETCH exist_control INTO dummy_;
   IF (exist_control%FOUND) THEN
      CLOSE exist_control;
      RAISE row_changed;
   ELSE
      CLOSE exist_control;
      RAISE row_deleted;
   END IF;
EXCEPTION
   WHEN row_locked THEN
      Error_SYS.Record_Locked(lu_name_);
   WHEN row_changed THEN
      Error_SYS.Record_Modified(lu_name_);
   WHEN row_deleted THEN
      Error_SYS.Record_Removed(lu_name_);
END Lock_By_Id___;

@UncheckedAccess
PROCEDURE Lock__ (
   info_       OUT VARCHAR2,
   objid_      IN  VARCHAR2,
   objversion_ IN  VARCHAR2 )
IS
   dummy_ ACCOUNTING_CODE_PART_VALUE_TAB%ROWTYPE;
BEGIN
   dummy_ := Lock_By_Id___(objid_, objversion_);
   info_ := Client_SYS.Get_All_Info;
END Lock__;




-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------


PROCEDURE New__ (
   info_       OUT    VARCHAR2,
   objid_      OUT    VARCHAR2,
   objversion_ OUT    VARCHAR2,
   attr_       IN OUT VARCHAR2,
   action_     IN     VARCHAR2 )
IS
   code_part_      VARCHAR2(1);
BEGIN
-- Modifications 8.50 [ Move Codeparts ]
   code_part_ := Client_SYS.Get_Item_Value('CODE_PART', attr_);
   IF    (code_part_ = 'B') THEN
      CODE_B_API.New__(info_, objid_, objversion_, attr_, action_);
   ELSIF (code_part_ = 'C') THEN
      CODE_C_API.New__(info_, objid_, objversion_, attr_, action_);
   ELSIF (code_part_ = 'D') THEN
      CODE_D_API.New__(info_, objid_, objversion_, attr_, action_);
   ELSIF (code_part_ = 'E') THEN
      CODE_E_API.New__(info_, objid_, objversion_, attr_, action_);
   ELSIF (code_part_ = 'F') THEN
      CODE_F_API.New__(info_, objid_, objversion_, attr_, action_);
   ELSIF (code_part_ = 'G') THEN
      CODE_G_API.New__(info_, objid_, objversion_, attr_, action_);
   ELSIF (code_part_ = 'H') THEN
      CODE_H_API.New__(info_, objid_, objversion_, attr_, action_);
   ELSIF (code_part_ = 'I') THEN
      CODE_I_API.New__(info_, objid_, objversion_, attr_, action_);
   ELSIF (code_part_ = 'J') THEN
      CODE_J_API.New__(info_, objid_, objversion_, attr_, action_);
   END IF;
END New__;



PROCEDURE Modify__ (
   info_       OUT    VARCHAR2,
   objid_      IN     VARCHAR2,
   objversion_ IN OUT VARCHAR2,
   attr_       IN OUT VARCHAR2,
   action_     IN     VARCHAR2 )
IS
   newrec_ ACCOUNTING_CODE_PART_VALUE_TAB%ROWTYPE;
BEGIN
-- Modifications 8.50 [ Move Codeparts ]
   newrec_ := Get_Object_By_Id___(objid_);
   IF    (newrec_.code_part = 'B') THEN
      CODE_B_API.Modify__(info_, objid_, objversion_, attr_, action_);
   ELSIF (newrec_.code_part = 'C') THEN
      CODE_C_API.Modify__(info_, objid_, objversion_, attr_, action_);
   ELSIF (newrec_.code_part = 'D') THEN
      CODE_D_API.Modify__(info_, objid_, objversion_, attr_, action_);
   ELSIF (newrec_.code_part = 'E') THEN
      CODE_E_API.Modify__(info_, objid_, objversion_, attr_, action_);
   ELSIF (newrec_.code_part = 'F') THEN
      CODE_F_API.Modify__(info_, objid_, objversion_, attr_, action_);
   ELSIF (newrec_.code_part = 'G') THEN
      CODE_G_API.Modify__(info_, objid_, objversion_, attr_, action_);
   ELSIF (newrec_.code_part = 'H') THEN
      CODE_H_API.Modify__(info_, objid_, objversion_, attr_, action_);
   ELSIF (newrec_.code_part = 'I') THEN
      CODE_I_API.Modify__(info_, objid_, objversion_, attr_, action_);
   ELSIF (newrec_.code_part = 'J') THEN
      CODE_J_API.Modify__(info_, objid_, objversion_, attr_, action_);
   END IF;
END Modify__;



PROCEDURE Remove__ (
   info_       OUT VARCHAR2,
   objid_      IN  VARCHAR2,
   objversion_ IN  VARCHAR2,
   action_     IN  VARCHAR2 )
IS
   remrec_ ACCOUNTING_CODE_PART_VALUE_TAB%ROWTYPE;
BEGIN
-- Modifications 8.50 [ Move Codeparts ]
   remrec_ := Get_Object_By_Id___(objid_);
   IF    (remrec_.code_part = 'B') THEN
      CODE_B_API.Remove__(info_, objid_, objversion_, action_);
   ELSIF (remrec_.code_part = 'C') THEN
      CODE_C_API.Remove__(info_, objid_, objversion_, action_);
   ELSIF (remrec_.code_part = 'D') THEN
      CODE_D_API.Remove__(info_, objid_, objversion_, action_);
   ELSIF (remrec_.code_part = 'E') THEN
      CODE_E_API.Remove__(info_, objid_, objversion_, action_);
   ELSIF (remrec_.code_part = 'F') THEN
      CODE_F_API.Remove__(info_, objid_, objversion_, action_);
   ELSIF (remrec_.code_part = 'G') THEN
      CODE_G_API.Remove__(info_, objid_, objversion_, action_);
   ELSIF (remrec_.code_part = 'H') THEN
      CODE_H_API.Remove__(info_, objid_, objversion_, action_);
   ELSIF (remrec_.code_part = 'I') THEN
      CODE_I_API.Remove__(info_, objid_, objversion_, action_);
   ELSIF (remrec_.code_part = 'J') THEN
      CODE_J_API.Remove__(info_, objid_, objversion_, action_);
   END IF;
END Remove__;


@UncheckedAccess
FUNCTION Get_Lu_For_Code_Part__ (
   company_ IN VARCHAR2,
   code_part_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   temp_       Accounting_Code_Parts_API.Public_Rec;
   temp2_      VARCHAR2(30);
   lu_name_    VARCHAR2(30);
BEGIN
      temp_ := Accounting_Code_Parts_API.Get(company_, code_part_);
      temp2_ := temp_.code_part_function;
      IF (temp2_ = 'FAACC') THEN
         lu_name_ := 'FaObject';
      ELSIF ( temp2_ = 'PRACC' ) THEN
         lu_name_ := 'AccountingProject';      
      ELSE
         IF ( code_part_ = 'A' ) THEN
            lu_name_ := 'Account';
         ELSE
            lu_name_ := 'Code'||code_part_;
         END IF;
      END IF;
      RETURN lu_name_;
END Get_Lu_For_Code_Part__;


@UncheckedAccess
FUNCTION Get_Code_Part_Function__(
   company_       IN VARCHAR2,
   code_part_     IN VARCHAR2) RETURN VARCHAR2
IS
   code_part_function_db_  VARCHAR2(6);

   CURSOR get_code_part_function IS
      SELECT code_part_function
      FROM ACCOUNTING_CODE_PART_TAB
      WHERE company = company_
      AND code_part = code_part_;
BEGIN
   OPEN get_code_part_function;
   FETCH get_code_part_function INTO code_part_function_db_;
   CLOSE get_code_part_function;
   IF code_part_function_db_ IS NULL THEN
      RETURN 'NULL';
   END IF;
   RETURN code_part_function_db_;
END Get_Code_Part_Function__;


PROCEDURE Validate_Cons_Value__ (
   company_                IN VARCHAR2,
   cons_company_           IN VARCHAR2,
   code_part_              IN VARCHAR2,
   cons_code_part_value_   IN VARCHAR2 )
IS
   value_forbiden          EXCEPTION;
   parent_code_part_       VARCHAR2(1);
   no_parent_codepart      EXCEPTION;
BEGIN
   IF (cons_code_part_value_ IS NOT NULL) THEN
      IF (cons_company_ IS NULL) THEN
         RAISE value_forbiden;
      END IF;
      parent_code_part_ := Accounting_Code_Parts_API.Get_Parent_Code_Part(company_, code_part_);
      IF (parent_code_part_ IS NOT NULL) THEN
         Exist( cons_company_, parent_code_part_, cons_code_part_value_ );
      ELSE
         RAISE no_parent_codepart;
      END IF;
   END IF;
EXCEPTION
   WHEN value_forbiden THEN
      Error_SYS.Record_General( lu_name_,
                                'VAL_VAL_01: You can not specifiy parent code part value :P1 if parent company is not defined',
                                cons_code_part_value_ );
   WHEN no_parent_codepart THEN
      Error_SYS.Record_General( lu_name_,
                                'VAL_VAL_02: No parent code part is defined for the child code part :P1', code_part_);
END Validate_Cons_Value__;




-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------
@UncheckedAccess
PROCEDURE Exist (
   company_ IN VARCHAR2,
   code_part_value_ IN VARCHAR2 )
IS

BEGIN
   IF (NOT Check_Exist___(company_, code_part_value_)) THEN
      Raise_Record_Not_Exist___(company_, code_part_value_);
   END IF;
END Exist;



@UncheckedAccess
FUNCTION Exists (
   company_ IN VARCHAR2,
   code_part_value_ IN VARCHAR2 ) RETURN BOOLEAN
IS
   
BEGIN
   RETURN Check_Exist___(company_, code_part_value_);
END Exists;


@UncheckedAccess
PROCEDURE Exist (
   company_ IN VARCHAR2,
   code_part_ IN VARCHAR2,
   code_part_value_ IN VARCHAR2 )
IS
BEGIN

-- Modifications 8.50 [ Move Codeparts ]
   IF    (code_part_ = 'A') THEN
      ACCOUNTING_CODE_PART_A_API.Exist(company_,code_part_, code_part_value_ );
   ELSIF (code_part_ = 'B') THEN
      CODE_B_API.Exist(company_, code_part_value_ );
   ELSIF (code_part_ = 'C') THEN
      CODE_C_API.Exist(company_, code_part_value_ );
   ELSIF (code_part_ = 'D') THEN
      CODE_D_API.Exist(company_, code_part_value_ );
   ELSIF (code_part_ = 'E') THEN
      CODE_E_API.Exist(company_, code_part_value_ );
   ELSIF (code_part_ = 'F') THEN
      CODE_F_API.Exist(company_, code_part_value_ );
   ELSIF (code_part_ = 'G') THEN
      CODE_G_API.Exist(company_, code_part_value_ );
   ELSIF (code_part_ = 'H') THEN
      CODE_H_API.Exist(company_, code_part_value_ );
   ELSIF (code_part_ = 'I') THEN
      CODE_I_API.Exist(company_, code_part_value_ );
   ELSIF (code_part_ = 'J') THEN
      CODE_J_API.Exist(company_, code_part_value_ );
   ELSIF (code_part_ = 'P') THEN
      ACCOUNT_PROCESS_CODE_API.Exist(company_, code_part_value_ );
   END IF;
END Exist;


@UncheckedAccess
FUNCTION Validate_Code_Part (
   company_          IN VARCHAR2,
   code_part_        IN VARCHAR2,
   code_part_value_  IN VARCHAR2,
   budget_year_      IN NUMBER,
   period_           IN NUMBER,
   period_from_      IN NUMBER,
   period_to_        IN NUMBER) RETURN BOOLEAN
IS
   date_from_   DATE;
   date_until_  DATE;

   from_date_range_from_  DATE;
   from_date_range_until_ DATE;
   to_date_range_from_    DATE;
   to_date_range_until_   DATE;
   min_period_            NUMBER;
   max_period_            NUMBER;
   bud_period_from_       NUMBER;
   bud_period_to_         NUMBER;


   dummy_       VARCHAR2(1);

   CURSOR get_value IS
      SELECT 'X'
      FROM   ACCOUNTING_CODE_PART_VALUE_TAB
      WHERE  company         = company_
      AND    code_part       = code_part_
      AND    code_part_value = code_part_value_
      AND    (valid_from <= date_until_
             AND valid_until >= date_from_);
BEGIN
   IF (code_part_value_ IS NOT NULL) THEN
         Accounting_Period_API.Get_Period_Date (date_from_,
                                                date_until_,
                                                company_,
                                                budget_year_,
                                                period_ );

         bud_period_from_ :=period_from_;
         bud_period_to_   :=period_to_;

      IF (period_  IS NULL    AND  period_from_ IS NULL AND  period_to_  IS NULL)  THEN
         Accounting_Period_API.Get_Min_Max_Period(min_period_,
                                                  max_period_,
                                                  company_,
                                                  budget_year_);
         bud_period_from_ :=min_period_;
         bud_period_to_   :=max_period_;

      END IF;


      IF (period_ IS NULL) THEN
         Accounting_Period_API.Get_Period_Date (from_date_range_from_,
                                                from_date_range_until_,
                                                company_,
                                                budget_year_,
                                                bud_period_from_);

         Accounting_Period_API.Get_Period_Date (to_date_range_from_,
                                                to_date_range_until_,
                                                company_,
                                                budget_year_,
                                                bud_period_to_);

         date_until_ :=from_date_range_until_;
         date_from_  := to_date_range_from_;
      END IF;
      OPEN get_value;
      FETCH get_value INTO dummy_;
         IF (get_value%NOTFOUND) THEN
             CLOSE get_value;
             RETURN FALSE;
         ELSE
             CLOSE get_value;
            RETURN TRUE;
         END IF;
   END IF;
   RETURN TRUE;
END Validate_Code_Part;


PROCEDURE Validate_Code_Part (
   result_          OUT VARCHAR2,
   company_         IN  VARCHAR2,
   code_part_       IN  VARCHAR2,
   code_part_value_ IN  VARCHAR2,
   date_            IN  DATE )
IS
   dummy_      BOOLEAN;
BEGIN
   dummy_ := Validate_Code_Part (company_,
                                 code_part_,
                                 code_part_value_,
                                 date_ );
   IF ( dummy_ ) THEN
      result_ := 'TRUE' ;
   ELSE
      result_ := 'FALSE' ;
   END IF;
END  Validate_Code_Part;


@UncheckedAccess
FUNCTION Validate_Code_Part (
   company_          IN VARCHAR2,
   code_part_        IN VARCHAR2,
   code_part_value_  IN VARCHAR2,
   date_             IN DATE ) RETURN BOOLEAN
IS
   tdate_   DATE         := TRUNC(date_);
   dummy_   VARCHAR2(1);
   CURSOR get_value IS
     SELECT 'X'
     FROM   ACCOUNTING_CODE_PART_VALUE_TAB
     WHERE  company         = company_
     AND    code_part       = code_part_
     AND    code_part_value = code_part_value_
     AND    tdate_ BETWEEN valid_from AND valid_until;
BEGIN
  IF (code_part_value_ IS NOT NULL) THEN
      OPEN get_value;
      FETCH get_value INTO dummy_;
      IF (get_value%NOTFOUND) THEN
         CLOSE get_value;
         RETURN FALSE;
      ELSE
         CLOSE get_value;
         RETURN TRUE;
      END IF;
   END IF;
   RETURN TRUE;
END Validate_Code_Part;


@UncheckedAccess
FUNCTION Validate_Code_Part (
   company_          IN VARCHAR2,
   code_part_        IN VARCHAR2,
   code_part_value_  IN VARCHAR2,
   from_date_        IN DATE,
   untill_date_      IN DATE) RETURN BOOLEAN
IS
   dummy_   VARCHAR2(1);
   CURSOR get_value IS
     SELECT 'X'
     FROM   ACCOUNTING_CODE_PART_VALUE_TAB
     WHERE  company         = company_
     AND    code_part       = code_part_
     AND    code_part_value = code_part_value_
     AND    (valid_from <= untill_date_
             AND valid_until >= from_date_);
BEGIN
  IF (code_part_value_ IS NOT NULL) THEN
      OPEN get_value;
      FETCH get_value INTO dummy_;
      IF (get_value%NOTFOUND) THEN
         CLOSE get_value;
         RETURN FALSE;
      ELSE
         CLOSE get_value;
         RETURN TRUE;
      END IF;
  END IF;
  RETURN TRUE;
END Validate_Code_Part;


@UncheckedAccess
FUNCTION Get_Description (
   company_         IN VARCHAR2,
   code_part_       IN VARCHAR2,
   code_part_value_ IN VARCHAR2,
   lang_code_       IN VARCHAR2 DEFAULT NULL ) RETURN VARCHAR2
IS
BEGIN
   -- Modifications 8.50 [ Move Codeparts ]
   IF    (code_part_ = 'A') THEN
      RETURN ACCOUNT_API.Get_Description(company_, code_part_value_);
   ELSIF (code_part_ = 'B') THEN
      RETURN CODE_B_API.Get_Description(company_, code_part_value_, lang_code_);
   ELSIF (code_part_ = 'C') THEN
      RETURN CODE_C_API.Get_Description(company_, code_part_value_, lang_code_);
   ELSIF (code_part_ = 'D') THEN
      RETURN CODE_D_API.Get_Description(company_, code_part_value_, lang_code_);
   ELSIF (code_part_ = 'E') THEN
      RETURN CODE_E_API.Get_Description(company_, code_part_value_);
   ELSIF (code_part_ = 'F') THEN
      RETURN CODE_F_API.Get_Description(company_, code_part_value_);
   ELSIF (code_part_ = 'G') THEN
      RETURN CODE_G_API.Get_Description(company_, code_part_value_);
   ELSIF (code_part_ = 'H') THEN
      RETURN CODE_H_API.Get_Description(company_, code_part_value_, lang_code_);
   ELSIF (code_part_ = 'I') THEN
      RETURN CODE_I_API.Get_Description(company_, code_part_value_, lang_code_);
   ELSIF (code_part_ = 'J') THEN
      RETURN CODE_J_API.Get_Description(company_, code_part_value_, lang_code_);
   ELSE
      RETURN NULL;
   END IF;
END Get_Description;


@UncheckedAccess
FUNCTION Exist_Code_Part_Value (
   company_          IN VARCHAR2,
   code_part_        IN VARCHAR2 ) RETURN BOOLEAN
IS
   dummy_   VARCHAR2(1);
   CURSOR exist_value IS
     SELECT 'X'
     FROM   ACCOUNTING_CODE_PART_VALUE_TAB
     WHERE  company = company_
     AND    code_part = code_part_;
BEGIN
   OPEN exist_value;
   FETCH exist_value INTO dummy_;
   IF (exist_value%NOTFOUND) THEN
      CLOSE exist_value;
      RETURN FALSE;
   ELSE
      CLOSE exist_value;
      RETURN TRUE;
   END IF;
END Exist_Code_Part_Value;

FUNCTION Exist_Code_Part_Value2 (
   master_company_  IN VARCHAR2,
   code_part_       IN VARCHAR2,
   code_part_value_ IN VARCHAR2) RETURN BOOLEAN
IS
      dummy_ NUMBER;
      CURSOR exist_control IS
         SELECT 1
         FROM   ACCOUNTING_CODE_PART_VALUE_TAB
         WHERE  company  = master_company_
          AND   code_part       = code_part_
          AND   code_part_value = code_part_value_;
   BEGIN
      OPEN exist_control;
      FETCH exist_control INTO dummy_;
      IF (exist_control%FOUND) THEN
         CLOSE exist_control;
         RETURN(TRUE);
      ELSE
         CLOSE exist_control;
         RETURN(FALSE);
      END IF;
END Exist_Code_Part_Value2;


PROCEDURE Check_Valid_From_To (
   company_          IN VARCHAR2,
   code_part_        IN VARCHAR2,
   code_part_value_  IN VARCHAR2,
   valid_from_       IN DATE,
   valid_to_         IN DATE )
IS
BEGIN

   IF (valid_from_ > valid_to_) THEN
      Error_SYS.appl_general(lu_name_,'FROM_GT_TO: Valid from cannot be greater than valid to.');
   END IF;
END Check_Valid_From_To;


PROCEDURE New_Code_Part_Value (
   attr_ IN VARCHAR2 )
IS
   code_part_      VARCHAR2(1);
BEGIN
   -- Modifications 8.50 [ Move Codeparts ]
   code_part_ := Client_SYS.Get_Item_Value('CODE_PART', attr_);
   IF    (code_part_ = 'B') THEN
      CODE_B_API.New_Code_Part_Value(attr_);
   ELSIF (code_part_ = 'C') THEN
      CODE_C_API.New_Code_Part_Value(attr_);
   ELSIF (code_part_ = 'D') THEN
      CODE_D_API.New_Code_Part_Value(attr_);
   ELSIF (code_part_ = 'E') THEN
      CODE_E_API.New_Code_Part_Value(attr_);
   ELSIF (code_part_ = 'F') THEN
      CODE_F_API.New_Code_Part_Value(attr_);
   ELSIF (code_part_ = 'G') THEN
      CODE_G_API.New_Code_Part_Value(attr_);
   ELSIF (code_part_ = 'H') THEN
      CODE_H_API.New_Code_Part_Value(attr_);
   ELSIF (code_part_ = 'I') THEN
      CODE_I_API.New_Code_Part_Value(attr_);
   ELSIF (code_part_ = 'J') THEN
      CODE_J_API.New_Code_Part_Value(attr_);
   END IF;
END New_Code_Part_Value;


PROCEDURE Modify_Code_Part_Value (
   attr_ IN VARCHAR2 )
IS
   code_part_      VARCHAR2(1);
BEGIN
-- Modifications 8.50 [ Move Codeparts ]

   code_part_ := Client_SYS.Get_Item_Value('CODE_PART', attr_);
   IF    (code_part_ = 'A') THEN
      ACCOUNT_API.Modify_Code_Part_Value(attr_);
   ELSIF (code_part_ = 'B') THEN
      CODE_B_API.Modify_Code_Part_Value(attr_);
   ELSIF (code_part_ = 'C') THEN
      CODE_C_API.Modify_Code_Part_Value(attr_);
   ELSIF (code_part_ = 'D') THEN
      CODE_D_API.Modify_Code_Part_Value(attr_);
   ELSIF (code_part_ = 'E') THEN
      CODE_E_API.Modify_Code_Part_Value(attr_);
   ELSIF (code_part_ = 'F') THEN
      CODE_F_API.Modify_Code_Part_Value(attr_);
   ELSIF (code_part_ = 'G') THEN
      CODE_G_API.Modify_Code_Part_Value(attr_);
   ELSIF (code_part_ = 'H') THEN
      CODE_H_API.Modify_Code_Part_Value(attr_);
   ELSIF (code_part_ = 'I') THEN
      CODE_I_API.Modify_Code_Part_Value(attr_);
   ELSIF (code_part_ = 'J') THEN
      CODE_J_API.Modify_Code_Part_Value(attr_);
   END IF;
END Modify_Code_Part_Value;


PROCEDURE Remove_Code_Part_Value (
   attr_ IN  VARCHAR2 )
IS
   code_part_      VARCHAR2(1);
BEGIN
-- Modifications 8.50 [ Move Codeparts ]
   code_part_ := Client_SYS.Get_Item_Value('CODE_PART', attr_);
   IF    (code_part_ = 'B') THEN
      CODE_B_API.Remove_Code_Part_Value(attr_);
   ELSIF (code_part_ = 'C') THEN
      CODE_C_API.Remove_Code_Part_Value(attr_);
   ELSIF (code_part_ = 'D') THEN
      CODE_D_API.Remove_Code_Part_Value(attr_);
   ELSIF (code_part_ = 'E') THEN
      CODE_E_API.Remove_Code_Part_Value(attr_);
   ELSIF (code_part_ = 'F') THEN
      CODE_F_API.Remove_Code_Part_Value(attr_);
   ELSIF (code_part_ = 'G') THEN
      CODE_G_API.Remove_Code_Part_Value(attr_);
   ELSIF (code_part_ = 'H') THEN
      CODE_H_API.Remove_Code_Part_Value(attr_);
   ELSIF (code_part_ = 'I') THEN
      CODE_I_API.Remove_Code_Part_Value(attr_);
   ELSIF (code_part_ = 'J') THEN
      CODE_J_API.Remove_Code_Part_Value(attr_);
   END IF;
END Remove_Code_Part_Value;


@UncheckedAccess
FUNCTION Code_Part_Value_Exist (
   company_             IN VARCHAR2,
   code_part_           IN VARCHAR2,
   code_part_value_     IN VARCHAR2 ) RETURN VARCHAR2
IS
   CURSOR look_for_value IS
      SELECT code_part_value
      FROM   ACCOUNTING_CODE_PART_VALUE_TAB
      WHERE  company         = company_
      AND    code_part       = code_part_
      AND    code_part_value = code_part_value_;
   dummy_              VARCHAR2(20);
BEGIN
   OPEN  look_for_value;
   FETCH look_for_value INTO dummy_;
   IF (look_for_value%NOTFOUND) THEN
      CLOSE  look_for_value;
      RETURN 'FALSE';
   END IF;
   CLOSE look_for_value;
   RETURN ('TRUE');
END Code_Part_Value_Exist;


@UncheckedAccess
FUNCTION Generate_Sort_Value (
   code_part_value_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   num_sort_value_  NUMBER;
   generated_value_ VARCHAR2(20);

BEGIN
   generated_value_ := code_part_value_;
   IF (code_part_value_ IS NOT NULL) THEN
      BEGIN
         num_sort_value_  := TO_NUMBER(code_part_value_);
         generated_value_ := LPAD(code_part_value_,20,'0');

      EXCEPTION
         WHEN OTHERS THEN
            NULL;
      END;
   END IF;
   RETURN generated_value_;
END Generate_Sort_Value;

@SecurityCheck Company.UserAuthorized(company_)
PROCEDURE Validate_Parent_Code_Part_Val (
   company_      IN VARCHAR2,
   cons_company_ IN VARCHAR2 )
IS
   CURSOR all_cons_vals IS
      SELECT code_part,
             cons_code_part_value
      FROM   ACCOUNTING_CODE_PART_VALUE_TAB
      WHERE  company = company_
      AND  NVL(bud_account, 'N') = 'N';
   cons_row_          ACCOUNTING_CODE_PART_VALUE_TAB%ROWTYPE;
   code_part_value_   ACCOUNTING_CODE_PART_VALUE_TAB.code_part_value%TYPE;
   code_part_         ACCOUNTING_CODE_PART_VALUE_TAB.code_part%TYPE;
   no_such_value      EXCEPTION;
BEGIN
   FOR row_ IN all_cons_vals LOOP
      IF (row_.cons_code_part_value IS NOT NULL) THEN
         cons_row_ := Get_Object_By_Keys___( cons_company_,
                        row_.code_part, row_.cons_code_part_value );
         IF (cons_row_.company IS NULL ) THEN
            -- set values for error message ....
            code_part_       := row_.code_part;
            code_part_value_ := row_.cons_code_part_value;
            RAISE no_such_value;
         END IF;
      END IF;
   END LOOP;
EXCEPTION
   WHEN no_such_value THEN
      Error_SYS.Record_General(lu_name_,
         'CDP_VAL_01: Code Part Value :P1 for Code Part :P2 does not exist in consolidation company :P3',
         code_part_value_, code_part_, cons_company_ );
END Validate_Parent_Code_Part_Val;


PROCEDURE Clear_Parent_Code_Part_Val (
   company_       IN VARCHAR2 )
IS
BEGIN
   UPDATE accounting_code_part_value_tab
      SET cons_code_part_value = NULL
      WHERE company = company_;
END Clear_Parent_Code_Part_Val;


FUNCTION Codepart_Exist_In_Cons_Company (
   cons_company_         IN VARCHAR2,
   code_part_            IN VARCHAR2,
   code_part_value_      IN VARCHAR2 ) RETURN BOOLEAN
IS
BEGIN
   -- Modifications 8.50 [ Move Codeparts ]
   -- Bug 111221, Begin
   IF    (code_part_ = 'B') THEN
      RETURN CODE_B_API.Codepart_Exist_In_Cons_Company(cons_company_, code_part_value_);
   ELSIF (code_part_ = 'C') THEN
      RETURN CODE_C_API.Codepart_Exist_In_Cons_Company(cons_company_, code_part_value_);
   ELSIF (code_part_ = 'D') THEN
      RETURN CODE_D_API.Codepart_Exist_In_Cons_Company(cons_company_, code_part_value_);
   ELSIF (code_part_ = 'E') THEN
      RETURN CODE_E_API.Codepart_Exist_In_Cons_Company(cons_company_, code_part_value_);
   ELSIF (code_part_ = 'F') THEN
      RETURN CODE_F_API.Codepart_Exist_In_Cons_Company(cons_company_, code_part_value_);
   ELSIF (code_part_ = 'G') THEN
      RETURN CODE_G_API.Codepart_Exist_In_Cons_Company(cons_company_, code_part_value_);
   ELSIF (code_part_ = 'H') THEN
      RETURN CODE_H_API.Codepart_Exist_In_Cons_Company(cons_company_, code_part_value_);
   ELSIF (code_part_ = 'I') THEN
      RETURN CODE_I_API.Codepart_Exist_In_Cons_Company(cons_company_, code_part_value_);
   ELSIF (code_part_ = 'J') THEN
      RETURN CODE_J_API.Codepart_Exist_In_Cons_Company(cons_company_, code_part_value_);
   ELSE
      RETURN NULL;
   -- Bug 111221, End
   END IF;
END Codepart_Exist_In_Cons_Company;


@UncheckedAccess
FUNCTION Get_Cons_Code_Part_Value (
   company_          IN VARCHAR2,
   code_part_        IN VARCHAR2,
   code_part_value_  IN VARCHAR2 ) RETURN VARCHAR2
IS
   cons_code_part_value_   ACCOUNTING_CODE_PART_VALUE_TAB.cons_code_part_value%TYPE;
   CURSOR getrec IS
      SELECT cons_code_part_value
      FROM   ACCOUNTING_CODE_PART_VALUE_TAB
      WHERE  company         = company_
      AND    code_part       = code_part_
      AND    code_part_value = code_part_value_;
BEGIN
   OPEN  getrec;
   FETCH getrec INTO cons_code_part_value_;
   CLOSE getrec;
   RETURN ( nvl(cons_code_part_value_,code_part_value_));
END Get_Cons_Code_Part_Value;


@UncheckedAccess
FUNCTION Calcul_Cons_Code_Part_Value (
   company_         IN VARCHAR2,
   code_part_       IN VARCHAR2,
   code_part_value_ IN VARCHAR2 ) RETURN VARCHAR2
IS
BEGIN
   -- Modifications 8.50 [ Move Codeparts ]
   -- Bug 111221,Begin
   IF    (code_part_ = 'B') THEN
      RETURN CODE_B_API.Calcul_Cons_Code_Part_Value(company_, code_part_value_);
   ELSIF (code_part_ = 'C') THEN
      RETURN CODE_C_API.Calcul_Cons_Code_Part_Value(company_, code_part_value_);
   ELSIF (code_part_ = 'D') THEN
      RETURN CODE_D_API.Calcul_Cons_Code_Part_Value(company_, code_part_value_);
   ELSIF (code_part_ = 'E') THEN
      RETURN CODE_E_API.Calcul_Cons_Code_Part_Value(company_, code_part_value_);
   ELSIF (code_part_ = 'F') THEN
      RETURN CODE_F_API.Calcul_Cons_Code_Part_Value(company_, code_part_value_);
   ELSIF (code_part_ = 'G') THEN
      RETURN CODE_G_API.Calcul_Cons_Code_Part_Value(company_, code_part_value_);
   ELSIF (code_part_ = 'H') THEN
      RETURN CODE_H_API.Calcul_Cons_Code_Part_Value(company_, code_part_value_);
   ELSIF (code_part_ = 'I') THEN
      RETURN CODE_I_API.Calcul_Cons_Code_Part_Value(company_, code_part_value_);
   ELSIF (code_part_ = 'J') THEN
      RETURN CODE_J_API.Calcul_Cons_Code_Part_Value(company_, code_part_value_);
   ELSE
      RETURN NULL;
   END IF;
   -- Bug 111221,End
END Calcul_Cons_Code_Part_Value;


@UncheckedAccess
FUNCTION Are_Changed_Values (
   company_    IN VARCHAR2,
   date_from_  IN DATE,
   date_until_ IN DATE ) RETURN VARCHAR2
IS
   CURSOR get_changed_values IS
      SELECT code_part_value, valid_from, valid_until
      FROM   ACCOUNTING_CODE_PART_VALUE_TAB
      WHERE  company = company_
      AND    NVL(bud_account, 'N') = 'N';
BEGIN
   IF ( Company_Finance_API.Is_User_Authorized(company_) ) THEN
      FOR row_ IN get_changed_values LOOP
         IF (row_.valid_from > date_from_) THEN
            RETURN 'TRUE';
         END IF;
         IF (row_.valid_until < date_until_ AND row_.valid_until > date_from_) THEN
            RETURN 'TRUE';
         END IF;
      END LOOP;
      RETURN 'FALSE';
   ELSE
      RETURN 'FALSE';
   END IF;
END Are_Changed_Values;


@UncheckedAccess
FUNCTION Get_Desc_For_Code_Part (
   company_ IN VARCHAR2,
   code_part_ IN VARCHAR2,
   code_part_value_ IN VARCHAR2 )  RETURN VARCHAR2
IS
   lu_name_ VARCHAR2(30);
   desc_    VARCHAR2(100);
   component_  VARCHAR2(30) :='ACCRUL';
   CURSOR get_desc IS
      SELECT description
      FROM accounting_code_part_value_tab
      WHERE company = company_
      AND code_part = code_part_
      AND code_part_value = code_part_value_;
BEGIN
   lu_name_ := Accounting_Code_Part_Value_API.Get_Lu_For_Code_Part__(company_, code_part_);
   IF (lu_name_ = 'FaObject') THEN
      component_ := 'FIXASS';
   ELSIF (lu_name_ = 'AccountingProject') THEN
      component_ := 'GENLED';
   END IF;
   desc_ := Substr(Enterp_Comp_Connect_V170_API.Get_Company_Translation(company_,
                                                                        component_,
                                                                        lu_name_,
                                                                        code_part_value_ ),1,100);
   IF (desc_ IS NULL) THEN
      OPEN get_desc;
      FETCH get_desc INTO desc_;
      CLOSE get_desc;
   END IF;
   RETURN desc_;
END Get_Desc_For_Code_Part;


PROCEDURE Check_Delete_Allowed_Parent (
   company_         IN VARCHAR2,
   code_part_value_ IN VARCHAR2,
   code_part_       IN VARCHAR2)
IS
   dummy_              NUMBER;
   func_               VARCHAR2(100);
   code_               VARCHAR2(100);
   TYPE view_code      IS REF CURSOR;
   strsql_             VARCHAR2(100);
   cur_code_           view_code;
   raise_error_        BOOLEAN;
   CURSOR get_function IS
      SELECT t2.code_part_function,
             t2.code_part
      FROM   accounting_code_part_tab t2,
             company_finance_tab      t3
      WHERE  t2.company          = t3.company
      AND    t3.cons_company     = company_
      AND    t2.parent_code_part = code_part_;
BEGIN
   OPEN  get_function;
   FETCH get_function INTO func_,code_;
   CLOSE get_function;
   IF (func_='PRACC') THEN
      $IF Component_Genled_SYS.INSTALLED $THEN
         IF (Accounting_Project_API.Check_Project_Exist_CodePart(company_,code_part_value_,code_part_) = 'TRUE') THEN
            Error_SYS.Record_General('AccountingCodePartValue', 'EXISTINPAR: The code part value :P1 is mapped to a subsidiary code part value',code_part_value_);
         END IF;
      $ELSE
         NULL;
      $END
   ELSIF(func_='FAACC') THEN
      $IF Component_Fixass_SYS.INSTALLED $THEN
         IF (Fa_Object_API.Avail_Fa_Exist_CodePart(company_,code_part_value_,code_part_) = 'TRUE') THEN
            Error_SYS.Record_General('AccountingCodePartValue', 'EXISTINPAR: The code part value :P1 is mapped to a subsidiary code part value',code_part_value_);
         END IF;
      $ELSE
         NULL;
      $END
   ELSIF(code_ IS NOT NULL) THEN
      code_  := 'CODE_'||code_;
      strsql_ :=  ' SELECT (1) FROM ' || code_ ||
                 ' WHERE cons_company = :company_ ' ||
                 ' AND cons_code_part_value = :code_part_value_';
      @ApproveDynamicStatement(2006-01-27,jeguse)
      OPEN  cur_code_ FOR  strsql_ USING company_,code_part_value_ ;
      FETCH cur_code_ INTO dummy_;
      IF (cur_code_%FOUND) THEN
         raise_error_ := TRUE;
      END IF;
      CLOSE cur_code_;
      IF (raise_error_)THEN
         Error_SYS.Record_General('AccountingCodePartValue', 'EXISTINPAR: The code part value :P1 is mapped to a subsidiary code part value',code_part_value_);
      END IF;
   END IF;
END Check_Delete_Allowed_Parent;


PROCEDURE Check_Delete_Allowed2 (
   company_         IN VARCHAR2,
   code_part_value_ IN VARCHAR2,
   code_part_       IN VARCHAR2,
   function_        IN VARCHAR2 DEFAULT NULL )
IS
   postctrlexist   EXCEPTION;
BEGIN
   IF Posting_Ctrl_Api.Code_part_Exist(company_,code_part_,code_part_value_) THEN
      RAISE postctrlexist;
   END IF;
EXCEPTION
  WHEN postctrlexist THEN
      IF function_ = 'FAACC' THEN
         Error_SYS.appl_general(lu_name_,'EXISTCTRLFA: The object :P1 exists in the posting control and not allowed to delete.',
                                code_part_value_);      
      ELSIF function_ = 'PRACC' THEN
         Error_SYS.appl_general(lu_name_,'EXISTCTRLPR: The project :P1 exists in the posting control and not allowed to delete.',
                                code_part_value_);      
      ELSE
         Error_SYS.appl_general(lu_name_,'EXISTCTRL: The code :P1 for code part :P2 is in the posting control and not allowed to delete.',
                                code_part_value_, code_part_);      
      END IF;  
END Check_Delete_Allowed2;


PROCEDURE Check_Delete_Allowed (
   company_          IN VARCHAR2,
   code_part_        IN VARCHAR2,
   code_part_value_  IN VARCHAR2 )
IS
BEGIN
-- Modifications 8.50 [ Move Codeparts ]
   IF    (code_part_ = 'A') THEN
      Account_API.Check_Delete_Allowed(company_, code_part_value_);
   ELSIF (code_part_ = 'B') THEN
      Code_B_API.Check_Delete_Allowed(company_, code_part_value_);
   ELSIF (code_part_ = 'C') THEN
      Code_C_API.Check_Delete_Allowed(company_, code_part_value_);
   ELSIF (code_part_ = 'D') THEN
      Code_D_API.Check_Delete_Allowed(company_, code_part_value_);
   ELSIF (code_part_ = 'E') THEN
      Code_E_API.Check_Delete_Allowed(company_, code_part_value_);
   ELSIF (code_part_ = 'F') THEN
      Code_F_API.Check_Delete_Allowed(company_, code_part_value_);
   ELSIF (code_part_ = 'G') THEN
      Code_G_API.Check_Delete_Allowed(company_, code_part_value_);
   ELSIF (code_part_ = 'H') THEN
      Code_H_API.Check_Delete_Allowed(company_, code_part_value_);
   ELSIF (code_part_ = 'I') THEN
      Code_I_API.Check_Delete_Allowed(company_, code_part_value_);
   ELSIF (code_part_ = 'J') THEN
      Code_J_API.Check_Delete_Allowed(company_, code_part_value_);
   END IF;
END Check_Delete_Allowed;


PROCEDURE Check_Delete (
   company_          IN VARCHAR2,
   code_part_        IN VARCHAR2,
   code_part_value_  IN VARCHAR2 )
IS
   remrec_            ACCOUNTING_CODE_PART_VALUE_TAB%ROWTYPE;
BEGIN
   remrec_ := Get_Object_By_Keys___(company_, code_part_, code_part_value_);
   Check_Delete___(remrec_);
END Check_Delete;

PROCEDURE Exist_Code_Part (
   master_company_ IN VARCHAR2,
   code_part_      IN VARCHAR2,
   code_part_value_ IN VARCHAR2,
   internal_name_ IN VARCHAR2   )
IS
BEGIN
   IF NOT(Check_Exist___(master_company_,code_part_,code_part_value_)) THEN    
      Error_SYS.Record_Not_Exist(lu_name_,'NOTEXIST: ":P1" :P2 does not exist.',code_part_value_,internal_name_);
   END IF;
END Exist_Code_Part;

@UncheckedAccess
FUNCTION Get_Valid_From (
   company_         IN VARCHAR2,
   code_part_       IN VARCHAR2,
   code_part_value_ IN VARCHAR2 ) RETURN DATE
IS
   temp_ ACCOUNTING_CODE_PART_VALUE_TAB.valid_from%TYPE;
   CURSOR get_attr IS
      SELECT valid_from
      FROM   accounting_code_part_value_tab
      WHERE  company         = company_
      AND    code_part       = code_part_
      AND    code_part_value = code_part_value_;
BEGIN

   OPEN get_attr;
   FETCH get_attr INTO temp_;
   CLOSE get_attr;
   RETURN temp_;
END Get_Valid_From;

@UncheckedAccess
FUNCTION Get_Valid_Until (
   company_         IN VARCHAR2,
   code_part_       IN VARCHAR2,
   code_part_value_ IN VARCHAR2 ) RETURN DATE
IS

   temp_ ACCOUNTING_CODE_PART_VALUE_TAB.valid_until%TYPE;
   CURSOR get_attr IS
      SELECT valid_until
      FROM   accounting_code_part_value_tab
      WHERE  company         = company_
      AND    code_part       = code_part_
      AND    code_part_value = code_part_value_;
BEGIN
   OPEN get_attr;
   FETCH get_attr INTO temp_;
   CLOSE get_attr;
   RETURN temp_;
END Get_Valid_Until;

@UncheckedAccess
FUNCTION Get_Accounting_Text_Id (
   company_         IN VARCHAR2,
   code_part_       IN VARCHAR2,
   code_part_value_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   temp_ ACCOUNTING_CODE_PART_VALUE_TAB.accounting_text_id%TYPE;
   CURSOR get_attr IS
      SELECT accounting_text_id
      FROM   accounting_code_part_value_tab
      WHERE  company         = company_
      AND    code_part       = code_part_
      AND    code_part_value = code_part_value_;
BEGIN
   OPEN get_attr;
   FETCH get_attr INTO temp_;
   CLOSE get_attr;
   RETURN temp_;
END Get_Accounting_Text_Id;

@UncheckedAccess
FUNCTION Get (
   company_ IN VARCHAR2,
   code_part_ IN VARCHAR2,
   code_part_value_ IN VARCHAR2 ) RETURN Public_Rec
IS
   temp_ Public_Rec;
   CURSOR get_attr IS
      SELECT company, code_part_value,
             rowid, rowversion, rowkey, rowtype,
             valid_from, 
             valid_until, 
             accounting_text_id
      FROM accounting_code_part_value_tab
      WHERE company = company_
      AND   code_part = code_part_
      AND   code_part_value = code_part_value_;
BEGIN
   OPEN get_attr;
   FETCH get_attr INTO temp_;
   CLOSE get_attr;
   RETURN temp_;
END Get;
