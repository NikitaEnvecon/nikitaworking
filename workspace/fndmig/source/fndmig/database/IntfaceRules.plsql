-----------------------------------------------------------------------------
--
--  Logical unit: IntfaceRules
--  Component:    FNDMIG
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  070918  TRLYNO Bug #70434 - Restricted use of rule CONNJOB; 
--                              only for jobs with CREATE_TABLE_FROM_FILE.
--                              Implement option NOBACKUP for rule CRETABCONF
--                              New Rule ALTREPLUSER
--  061029  TRLYNO Bug #61381 - Reset Check_Delete__ to standard
--  060329  TRLYNO Bug #56862 - FNDMIG added functionality, handling FILExxx-rules
--  060105  TRLYNO Bug #55479 - Added functionality in Data Migration
--  041222  JHMASE Bug #48786 - Make it work with double byte
--  040210  JHMASE Bug #42618 - Corrections
--  030708  TRLY  Prepared for new module FNDMI
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------


-------------------- PRIVATE DECLARATIONS -----------------------------------


-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------

PROCEDURE Check_File_Rules___ (
   intface_name_ IN     VARCHAR2,
   rule_id_      IN     VARCHAR2 )
IS
   direction_ VARCHAR2(200);
   CURSOR get_data IS
      SELECT *
      FROM intface_rules_tab
      WHERE intface_name = intface_name_
      AND rule_id IN ('FILEMOV','FILEBKP','FILERENAM','FILEDEL')
      AND rule_id NOT IN (rule_id_)
      AND rule_flag = '1';
BEGIN
   direction_ := Intface_Direction_API.Encode(Intface_Procedures_API.Get_Direction(
                    Intface_Header_API.Get_Procedure_Name(intface_name_)));
   FOR rec_ IN get_data LOOP
      IF (rule_id_ = 'FILEHEAD' ) THEN
         -- FILEHEAD can be activated separately
         NULL;
      ELSIF ( ( rule_id_ = 'FILEBKP' OR rec_.rule_id = 'FILEBKP') AND direction_ = '2' ) THEN
         -- FILEBKP can be activated separately for file out
         NULL;
      ELSE
         -- FILExxx-rules excludes each other and can only be activated one by one
         Error_SYS.Record_General(lu_name_, ' FILERULEERR: Rule :P1 cannot be active as long as :P2 is active', rule_id_, rec_.rule_id);
      END IF;
   END LOOP;
END Check_File_Rules___;

PROCEDURE Check_Valid_Rule___(
   rule_id_        IN VARCHAR2,
   procedure_name_ IN VARCHAR2 )
IS
   dummy_ NUMBER;
   CURSOR get_valid_rules IS
      SELECT 1 
        FROM INTFACE_RULES_LOV
       WHERE rule_id = rule_id_;
BEGIN
   App_Context_SYS.Set_Value('INTFACE_RULES_API.INTF_PROCEDURE_NAME_', procedure_name_);
   OPEN get_valid_rules;
   FETCH get_valid_rules INTO dummy_;
   IF (get_valid_rules%NOTFOUND) THEN
      Error_SYS.Record_General(lu_name_, 'CHECKRULEERROR: Rule :P1 is not valid for procedure name :P2.', rule_id_, procedure_name_);
   END IF;
   CLOSE get_valid_rules;
END Check_Valid_Rule___;   

PROCEDURE Check_Connection___ (
   check_job_    IN OUT VARCHAR2,
   intface_name_ IN     VARCHAR2,
   rule_value_   IN     VARCHAR2 )
IS 
   CURSOR find_connections IS
      SELECT intface_name
      FROM intface_rules_tab
      WHERE rule_flag = '1'
      AND intface_name != intface_name_
      AND rule_value = rule_value_;
BEGIN
   OPEN  find_connections;
   FETCH find_connections INTO check_job_;
   CLOSE find_connections;
END Check_Connection___;


@Override
PROCEDURE Check_Insert___ (
   newrec_ IN OUT intface_rules_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS
   value_flag_db_ VARCHAR2(20);
   check_job_ VARCHAR2(30);
   dummy_     VARCHAR2(30);
   procedure_name_ VARCHAR2(100);
BEGIN
   --Add pre-processing code here
   IF ( newrec_.rule_flag = '1' ) THEN   
      IF ( newrec_.rule_id = 'CONNJOB' ) THEN
         Intface_Header_API.Exist(newrec_.rule_value);
         Check_Connection___ ( check_job_, newrec_.intface_name, newrec_.rule_value);
         IF ( check_job_ IS NOT NULL ) THEN
            Error_SYS.Record_General( lu_name_, ' ERRCONN : Job :P1 is already connected to :P2 ',newrec_.rule_value, check_job_ );
         END IF;
         IF ( Intface_Header_API.Get_Procedure_Name(newrec_.rule_value) != 'CREATE_TABLE_FROM_FILE' ) THEN
            Error_SYS.Record_General( lu_name_, ' ERRCONN2 : Job :P1 must be using procedure CREATE_TABLE_FROM_FILE',newrec_.rule_value );
         END IF;
      ELSIF ( newrec_.rule_id = 'CRETABCONF' ) THEN
         IF ( newrec_.rule_value NOT IN ('KEEPERR','KEEPALL','NOBACKUP') ) THEN
            Error_SYS.Record_General( lu_name_, ' ERRORVAL1 : Valid values are KEEPALL , KEEPERR or NOBACKUP');
         END IF;
      ELSIF ( newrec_.rule_id = 'INSUPD' ) THEN
         IF ( newrec_.rule_value NOT IN ('INSERT','UPDATE') ) THEN
            Error_SYS.Record_General( lu_name_, ' ERRORVAL2 : Valid values are INSERT or UPDATE');
         END IF;
      ELSIF ( newrec_.rule_id = 'INSUPD' ) THEN
         IF ( nvl(newrec_.rule_value,'AFTER') NOT IN ('BEFORE','AFTER') ) THEN
            Error_SYS.Record_General( lu_name_, ' ERRORVAL3 : Valid values are BEFORE or AFTER');
         END IF;
      ELSIF ( newrec_.rule_id = 'ALTREPLUSER' ) THEN
         Validate_Repl_User(dummy_, newrec_.intface_name);
      END IF;
   END IF;   
   -- Get valueflag to check format for item RULE_VALUE
   value_flag_db_ := Intface_Default_Rules_API.Get_Value_Flag_Db(newrec_.rule_id);
   IF ( value_flag_db_ = '2' ) THEN
      newrec_.rule_value := Client_SYS.Attr_Value_To_Number(newrec_.rule_value);
   ELSIF ( value_flag_db_ = '4' ) THEN
      newrec_.rule_value := Client_SYS.Attr_Value_To_Date(
               to_char(to_date( newrec_.rule_value, nvl(Intface_Header_API.Get_Date_Format(newrec_.intface_name),'xx')),
                  CLient_SYS.Date_Format_) );
   END IF;
   -- Check rule_value according to value_flag
   IF ( newrec_.rule_value IS NOT NULL ) THEN
      IF ( value_flag_db_ = '1') THEN
         Error_SYS.Item_Update(lu_name_, 'RULE_VALUE');
      END IF;
   ELSIF ( newrec_.rule_flag = '1' ) THEN
      IF ( value_flag_db_ IN ('2','3','4') ) THEN
          Error_SYS.Check_Not_Null(lu_name_, 'RULE_VALUE', newrec_.rule_value);
      END IF;
   END IF;
   -- Restrictions on Active-flag on FILExxx-rules
   IF ( (newrec_.rule_id LIKE 'FILE%') AND          
        newrec_.rule_flag = '1' ) THEN
      Check_File_Rules___( newrec_.intface_name,newrec_.rule_id); 
   END IF;
   -- Check valid rules for EXCEL_MIGRATION jobs.
   procedure_name_ := Intface_Header_API.Get_Procedure_Name(newrec_.intface_name);
   IF (procedure_name_ = 'EXCEL_MIGRATION') THEN
      Check_Valid_Rule___(newrec_.rule_id, procedure_name_);      
   END IF;
   super(newrec_, indrec_, attr_);
END Check_Insert___;


@Override
PROCEDURE Check_Update___ (
   oldrec_ IN     intface_rules_tab%ROWTYPE,
   newrec_ IN OUT intface_rules_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS
   value_flag_db_ VARCHAR2(20);
   check_job_ VARCHAR2(30);
   dummy_     VARCHAR2(30);
   procedure_name_ VARCHAR2(100);
BEGIN
   --Add pre-processing code here
      -- Get valueflag to check format for item RULE_VALUE
   value_flag_db_ := Intface_Default_Rules_API.Get_Value_Flag_Db(newrec_.rule_id);
   IF ( value_flag_db_ = '2' ) THEN -- Number
            newrec_.rule_value := Client_SYS.Attr_Value_To_Number(newrec_.rule_value);
   ELSIF ( value_flag_db_ = '4' ) THEN -- Date
            newrec_.rule_value := Client_SYS.Attr_Value_To_Date(
               to_char(to_date( newrec_.rule_value, nvl(Intface_Header_API.Get_Date_Format(newrec_.intface_name),'xx')),
                  CLient_SYS.Date_Format_) );
   END IF;
   
   -- Check rule_value according to value_flag
   IF ( newrec_.rule_value IS NOT NULL ) THEN
      IF ( value_flag_db_ = '1') THEN
         Error_SYS.Item_Update(lu_name_, 'RULE_VALUE');
      END IF;
   ELSIF ( newrec_.rule_flag = '1' ) THEN
      IF ( value_flag_db_ IN ('2','3','4') ) THEN
          Error_SYS.Check_Not_Null(lu_name_, 'RULE_VALUE', newrec_.rule_value);
      END IF;
   END IF;
   IF ( newrec_.rule_flag = '1' ) THEN   
      IF ( newrec_.rule_id = 'CONNJOB' ) THEN
         Intface_Header_API.Exist(newrec_.rule_value);
         Check_Connection___ ( check_job_, newrec_.intface_name, newrec_.rule_value);
         IF ( check_job_ IS NOT NULL ) THEN
            Error_SYS.Record_General( lu_name_, ' ERRCONN : Job :P1 is already connected to :P2 ',newrec_.rule_value, check_job_ );
         END IF;
         IF ( Intface_Header_API.Get_Procedure_Name(newrec_.rule_value) != 'CREATE_TABLE_FROM_FILE' ) THEN
            Error_SYS.Record_General( lu_name_, ' ERRCONN2 : Job :P1 must be using procedure CREATE_TABLE_FROM_FILE',newrec_.rule_value );
         END IF;
      ELSIF ( newrec_.rule_id = 'CRETABCONF' ) THEN
         IF ( newrec_.rule_value NOT IN ('KEEPERR','KEEPALL','NOBACKUP') ) THEN
            Error_SYS.Record_General( lu_name_, ' ERRORVAL1 : Valid values are KEEPALL , KEEPERR or NOBACKUP');
         END IF;
      ELSIF ( newrec_.rule_id = 'INSUPD' ) THEN
         IF ( newrec_.rule_value NOT IN ('INSERT','UPDATE') ) THEN
            Error_SYS.Record_General( lu_name_, ' ERRORVAL2 : Valid values are INSERT or UPDATE');
         END IF;
      ELSIF ( newrec_.rule_id = 'INSUPD' ) THEN
         IF ( nvl(newrec_.rule_value,'AFTER') NOT IN ('BEFORE','AFTER') ) THEN
            Error_SYS.Record_General( lu_name_, ' ERRORVAL3 : Valid values are BEFORE or AFTER');
         END IF;
      ELSIF ( newrec_.rule_id = 'ALTREPLUSER' ) THEN
         Validate_Repl_User(dummy_, newrec_.intface_name);
      END IF;
      -- Restrictions on Active-flag on FILExxx-rules
      IF ( newrec_.rule_id LIKE 'FILE%' ) THEN
         Check_File_Rules___( newrec_.intface_name,newrec_.rule_id); 
      END IF;
   END IF;
   procedure_name_ := Intface_Header_API.Get_Procedure_Name(newrec_.intface_name);
   IF (procedure_name_ = 'EXCEL_MIGRATION') THEN
      Check_Valid_Rule___(newrec_.rule_id, procedure_name_);      
   END IF;
   super(oldrec_, newrec_, indrec_, attr_);
END Check_Update___;


@Override
PROCEDURE Prepare_Insert___ (
   attr_ IN OUT VARCHAR2 )
IS
BEGIN
   super(attr_);
   Client_SYS.Add_To_Attr('RULE_FLAG',Intface_Rule_Flag_API.Decode('1'), attr_);
END Prepare_Insert___;


@Override
PROCEDURE Update___ (
   objid_      IN     VARCHAR2,
   oldrec_     IN     intface_rules_tab%ROWTYPE,
   newrec_     IN OUT intface_rules_tab%ROWTYPE,
   attr_       IN OUT VARCHAR2,
   objversion_ IN OUT VARCHAR2,
   by_keys_    IN     BOOLEAN DEFAULT FALSE )
IS
BEGIN
   --Add pre-processing code here
   super(objid_, oldrec_, newrec_, attr_, objversion_, by_keys_);
   IF (  newrec_.rule_id = 'SAVEJOBDAYS' ) THEN
      IF ( newrec_.rule_flag = '1' ) THEN
         Intface_Job_Detail_API.Delete_History( newrec_.intface_name);
      END IF;
   END IF;
END Update___;

PROCEDURE Check_Rule_Id_Ref___ (
   newrec_ IN OUT intface_rules_tab%ROWTYPE )
IS
BEGIN
   Intface_Default_Rules_API.Rule_Exist(newrec_.rule_id);
END Check_Rule_Id_Ref___;

-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------

-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------


@UncheckedAccess
FUNCTION Rule_Is_Active (
   rule_value_   IN OUT VARCHAR2,
   rule_id_      IN     VARCHAR2,
   intface_name_ IN     VARCHAR2 ) RETURN BOOLEAN
IS
   result_     BOOLEAN;
   CURSOR get_attr IS
      SELECT rule_value
      FROM INTFACE_RULES
      WHERE intface_name = intface_name_
      AND   rule_id = rule_id_
      AND   rule_flag_db = '1';
BEGIN
   OPEN get_attr;
   FETCH get_attr INTO rule_value_;
      result_ := get_attr%FOUND;
   CLOSE get_attr;
   RETURN result_;
END Rule_Is_Active;




PROCEDURE Insert_Default_Rules (
   intface_name_   IN VARCHAR2,
   procedure_name_ IN VARCHAR2 )
IS
   attr_       VARCHAR2(32000);
   objid_      VARCHAR2(2000);
   objversion_ VARCHAR2(2000);
   newrec_     INTFACE_RULES_TAB%ROWTYPE;
   indrec_     Indicator_Rec;
   --
   CURSOR get_attr IS
      SELECT *
      FROM intface_default_rules
      WHERE  (( procedure_name_ LIKE  procedure_name||'%' ) OR
            (procedure_name = '*' AND rule_flag_db = '1'))
      ORDER BY procedure_name desc;
BEGIN
   FOR rec_ IN get_attr LOOP
      Client_SYS.Clear_Attr(attr_);
      Client_SYS.Add_To_Attr('INTFACE_NAME', intface_name_, attr_);
      Client_SYS.Add_To_Attr('RULE_ID', rec_.rule_id, attr_);
      Client_SYS.Add_To_Attr('RULE_FLAG', rec_.rule_flag, attr_);
      Client_SYS.Add_To_Attr('RULE_VALUE', rec_.rule_value, attr_);
--    Rule may be declared both for specific procedure name
--    and for procedure_name = '*'. Ignore duplicates
      BEGIN
         Unpack___(newrec_, indrec_, attr_);
         Check_Insert___(newrec_, indrec_, attr_);
         Insert___(objid_, objversion_, newrec_, attr_);
      EXCEPTION
         WHEN OTHERS THEN NULL;
      END;
      --
   END LOOP;
END Insert_Default_Rules;


@UncheckedAccess
FUNCTION Restart_Is_Allowed (
   intface_name_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   found_      BOOLEAN;
   dummy_      VARCHAR2(1);
   return_     VARCHAR2(5);
   CURSOR get_attr IS
      SELECT 'X'
      FROM INTFACE_RULES
      WHERE intface_name = intface_name_
      AND   rule_id = 'IGNOREXEERROR'
      AND   rule_flag_db = '1';
BEGIN
   OPEN get_attr;
   FETCH get_attr INTO dummy_ ;
      found_ := get_attr%FOUND;
   CLOSE get_attr;
   IF ( found_ ) THEN
      return_ := 'TRUE';
   ELSE
      return_ := 'FALSE';
   END IF;
   RETURN return_;
END Restart_Is_Allowed;




PROCEDURE Cleanup_Default_Rules (
   intface_name_  IN VARCHAR2,
   old_proc_name_ IN VARCHAR2,
   new_proc_name_ IN VARCHAR2 )
IS
   CURSOR get_obsolete_rules IS
      SELECT ROWID
      FROM intface_rules_tab a
      WHERE a.intface_name = intface_name_
      AND a.rule_id IN (SELECT b.rule_id
                        FROM intface_default_rules b
                        WHERE b.rule_id = a.rule_id
                        AND old_proc_name_ LIKE b.procedure_name);
BEGIN
   -- Delete default-rules for old procedure
   FOR rec_ IN get_obsolete_rules LOOP
      DELETE FROM intface_rules_tab
      WHERE ROWID = rec_.ROWID;
   END LOOP;   
   Insert_Default_Rules(intface_name_, new_proc_name_);
END Cleanup_Default_Rules;


PROCEDURE Validate_Repl_User (
   repl_user_    IN OUT VARCHAR2,
   intface_name_ IN     VARCHAR2 )
IS
BEGIN
   IF ( Intface_Header_API.Get_Procedure_Name(intface_name_) != 'REPLICATION' ) THEN
      Error_SYS.Record_General( lu_name_, ' REPLUSR1 : This rule can be used for REPLICATION jobs only' );
   END IF;
   repl_user_ := nvl(Fnd_Setting_API.Get_Value('FNDMIG_ALT_REPL_USR'),'*');
   IF ( repl_user_ = '*' ) THEN
      Error_SYS.Record_General( lu_name_, ' REPLUSR2 : Alternative user not defined in System Parameters in Admin.exe' );            
   ELSIF ( repl_user_ = Fnd_Session_API.Get_App_Owner ) THEN
      Error_SYS.Record_General( lu_name_, ' REPLUSR3 : Alternative user cannot be defined equal to Appowner in System Parameters in Admin.exe' );            
   END IF;
END Validate_Repl_User;


