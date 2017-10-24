-----------------------------------------------------------------------------
--
--  Logical unit: IntfaceDefaultRules
--  Component:    FNDMIG
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  040507  TRLY   Bug #44483 - New rules for connecting jobs + truncate values
--  040210  JHMASE Bug #42618 - Corrections
--  030708  TRLY  Prepared for new module FNDMI
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------


-------------------- PRIVATE DECLARATIONS -----------------------------------


-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------

@Override
PROCEDURE Check_Update___ (
   oldrec_ IN     intface_default_rules_tab%ROWTYPE,
   newrec_ IN OUT intface_default_rules_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS
   value_flag_db_ VARCHAR2(20);
BEGIN
   -- Get valueflag to check format for item RULE_VALUE
   value_flag_db_ := Intface_Default_Rules_API.Get_Value_Flag_Db(newrec_.rule_id);
   IF ( value_flag_db_ = '2' ) THEN
      newrec_.rule_value := Client_SYS.Attr_Value_To_Number(newrec_.rule_value);
   END IF;
      -- Check rule_value according to value_flag
   IF ( newrec_.rule_value IS NOT NULL ) THEN
      IF ( value_flag_db_ = '1') THEN
         Error_SYS.Item_Update( lu_name_, 'RULE_VALUE');
      END IF;
   ELSIF ( Intface_Rule_Flag_API.Encode(newrec_.rule_flag) = '1' ) THEN
      IF ( value_flag_db_ IN ('2','3','4')  ) THEN
          Error_SYS.Check_Not_Null( lu_name_, 'RULE_VALUE', newrec_.rule_value);
      END IF;
   END IF;
   super(oldrec_, newrec_, indrec_, attr_);
END Check_Update___;


PROCEDURE Items_To_Localize___
IS
   text_dummy_ VARCHAR2(2000);
BEGIN
   text_dummy_ :=  Language_SYS.Translate_Constant('IntfaceDefaultRules','IGNOREXEERROR: Continue procedure even if errors occur');
   text_dummy_ :=  Language_SYS.Translate_Constant('IntfaceDefaultRules','IGNOREADERROR: Continue reading file even if errors occur');
   text_dummy_ :=  Language_SYS.Translate_Constant('IntfaceDefaultRules','SKIPLINES: Start reading file after this line number');
   text_dummy_ :=  Language_SYS.Translate_Constant('IntfaceDefaultRules','EXITLINES: Stop reading file after this line number');
   text_dummy_ :=  Language_SYS.Translate_Constant('IntfaceDefaultRules','SERVFILOAD: Load serverfile before job starts');
   text_dummy_ :=  Language_SYS.Translate_Constant('IntfaceDefaultRules','FILEBKP: Backup file after successful completion');
   text_dummy_ :=  Language_SYS.Translate_Constant('IntfaceDefaultRules','SAVEJOBDAYS: Number of days to save job-history ');
   text_dummy_ :=  Language_SYS.Translate_Constant('IntfaceDefaultRules','CLEANUP: Clear errordetails automatically');
   text_dummy_ :=  Language_SYS.Translate_Constant('IntfaceDefaultRules','COMMITSEQ: Number of rows between each commit');
   text_dummy_ :=  Language_SYS.Translate_Constant('IntfaceDefaultRules','CREATEDET: Create new column details based on views in MethodList');
   text_dummy_ :=  Language_SYS.Translate_Constant('IntfaceDefaultRules','ADDOBJID: Create extra column detail for OBJID');
   text_dummy_ :=  Language_SYS.Translate_Constant('IntfaceDefaultRules','NOCLEANUP: Keep all job details for client files');
   text_dummy_ :=  Language_SYS.Translate_Constant('IntfaceDefaultRules','EVENTMESS: Notify Event Server when job is finished');
   text_dummy_ :=  Language_SYS.Translate_Constant('IntfaceDefaultRules','INSUPD: Execute either INSERT or UPDATE');
   text_dummy_ :=  Language_SYS.Translate_Constant('IntfaceDefaultRules','FILEHEAD: Create fileheader with column names. CSV-files only ');
   text_dummy_ :=  Language_SYS.Translate_Constant('IntfaceDefaultRules','CHECKOPTION: Perform methods New and Modify with CHECK option');
   text_dummy_ :=  Language_SYS.Translate_Constant('IntfaceDefaultRules','SAVEJOBERR: Save only errors in history log');
   text_dummy_ :=  Language_SYS.Translate_Constant('IntfaceDefaultRules','SYNCDETAILS: Synchronize job details with columns in file-header');
   text_dummy_ :=  Language_SYS.Translate_Constant('IntfaceDefaultRules','CONNJOB: Start this job first ');
   text_dummy_ :=  Language_SYS.Translate_Constant('IntfaceDefaultRules','CRETABCONF: Options for container table ');
   text_dummy_ :=  Language_SYS.Translate_Constant('IntfaceDefaultRules','TRUNCVAL: Truncate values exceeding column length ');
   text_dummy_ :=  Language_SYS.Translate_Constant('IntfaceDefaultRules','FETCHCONDITION: Sets if the Job can be used to fetch data. If Multiple LUs are used specify the join condition ');
END Items_To_Localize___;


-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------


-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------


@UncheckedAccess
FUNCTION Get_Description (
   rule_id_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   temp_ INTFACE_DEFAULT_RULES.description%TYPE;
   CURSOR get_attr IS
      SELECT description
      FROM INTFACE_DEFAULT_RULES
      WHERE rule_id = rule_id_;
BEGIN
   OPEN get_attr;
   FETCH get_attr INTO temp_;
   CLOSE get_attr;
   RETURN temp_;
END Get_Description;


@UncheckedAccess
FUNCTION Get_Rule_Value (
   rule_id_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   temp_ INTFACE_DEFAULT_RULES.rule_value%TYPE;
   CURSOR get_attr IS
      SELECT rule_value
      FROM INTFACE_DEFAULT_RULES
      WHERE rule_id = rule_id_;
BEGIN
   OPEN get_attr;
   FETCH get_attr INTO temp_;
   CLOSE get_attr;
   RETURN temp_;
END Get_Rule_Value;



@UncheckedAccess
FUNCTION Get_Rule_Flag (
   rule_id_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   temp_ INTFACE_DEFAULT_RULES.rule_flag%TYPE;
   CURSOR get_attr IS
      SELECT rule_flag
      FROM INTFACE_DEFAULT_RULES
      WHERE rule_id = rule_id_;
BEGIN
   OPEN get_attr;
   FETCH get_attr INTO temp_;
   CLOSE get_attr;
   RETURN temp_;
END Get_Rule_Flag;


@UncheckedAccess
FUNCTION Get_Value_Flag (
   rule_id_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   temp_ INTFACE_DEFAULT_RULES.value_flag%TYPE;
   CURSOR get_attr IS
      SELECT value_flag
      FROM INTFACE_DEFAULT_RULES
      WHERE rule_id = rule_id_;
BEGIN
   OPEN get_attr;
   FETCH get_attr INTO temp_;
   CLOSE get_attr;
   RETURN temp_;
END Get_Value_Flag;



@UncheckedAccess
FUNCTION Get_Value_Flag_Db (
   rule_id_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   temp_ INTFACE_DEFAULT_RULES.value_flag_db%TYPE;
   CURSOR get_attr IS
      SELECT value_flag_db
      FROM INTFACE_DEFAULT_RULES
      WHERE rule_id = rule_id_;
BEGIN
   OPEN get_attr;
   FETCH get_attr INTO temp_;
   CLOSE get_attr;
   RETURN temp_;
END Get_Value_Flag_Db;

PROCEDURE Rule_Exist (
   rule_id_ IN VARCHAR2 )
IS
   dummy_ NUMBER;
   CURSOR exist_control IS
      SELECT 1
      FROM   INTFACE_DEFAULT_RULES
      WHERE rule_id = rule_id_;
BEGIN
   OPEN exist_control;
   FETCH exist_control INTO dummy_;
   IF (exist_control%FOUND) THEN
      NULL;
   ELSE
      Error_SYS.Record_Not_Exist(lu_name_);
   END IF;
   CLOSE exist_control;
END Rule_Exist;

