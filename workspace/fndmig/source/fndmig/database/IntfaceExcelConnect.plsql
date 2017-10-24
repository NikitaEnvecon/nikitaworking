-----------------------------------------------------------------------------
--
--  Logical unit: IntfaceExcelConnect
--  Component:    FNDMIG
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------


-------------------- PRIVATE DECLARATIONS -----------------------------------


-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------

FUNCTION Get_Next_Seq_No___ RETURN VARCHAR2
IS
   no_ NUMBER;
BEGIN
   SELECT intface_excel_seq.nextval
     INTO no_
     FROM dual;
   RETURN (no_);
END Get_Next_Seq_No___; 


-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------

-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------

PROCEDURE Insert_Header (
   execution_id_   OUT  NUMBER,
   info_           OUT  VARCHAR2,
   intface_name_   IN   VARCHAR2)
IS
   attr_           VARCHAR2(2000);
   sequence_no_    NUMBER;
   ic_table_name_  VARCHAR2(2000);

BEGIN
   sequence_no_ := Get_Next_Seq_No___();
   execution_id_ := sequence_no_;
   ic_table_name_ := 'IC_'||execution_id_||'TAB';
   Client_SYS.Add_To_Attr('EXECUTION_ID', sequence_no_, attr_  );
   Client_SYS.Add_To_Attr('INTFACE_NAME', intface_name_, attr_  );
   Client_SYS.Add_To_Attr('IC_TABLE_NAME', ic_table_name_, attr_  );
   Intface_Execution_API.New(info_, attr_, 'DO');
END Insert_Header;


PROCEDURE Insert_Line (
   info_   OUT    VARCHAR2,
   attr_   IN OUT VARCHAR2,
   action_ IN     VARCHAR2 )
IS
BEGIN
   Intface_Execution_Detail_API.New(info_, attr_, action_);
END Insert_Line;


PROCEDURE Start_Online (
  info_             IN OUT VARCHAR2,
  activity_         IN     VARCHAR2,
  intface_name_     IN     VARCHAR2,
  execution_id_     IN     NUMBER )
IS
BEGIN
   Intface_Execution_Util_API.Start_Job(info_, activity_, intface_name_, execution_id_);
END Start_Online;

PROCEDURE Cleanup_Execution_Information (
   execution_id_ IN NUMBER)
IS
BEGIN
   Intface_Execution_API.Remove(execution_id_);
END Cleanup_Execution_Information;

FUNCTION Get_Url_Help_Base RETURN VARCHAR2
IS
   temp_ VARCHAR2 (1000);
BEGIN
   temp_ := Fnd_Setting_API.Get_Value('URL_HELP_BASE');
   RETURN temp_;
END Get_Url_Help_Base;


PROCEDURE Enumerate_Db_Values (
   db_values_ OUT VARCHAR2,
   lu_name_ IN VARCHAR2)
IS
   stmt_      VARCHAR2(8000);
   pkg_       VARCHAR2(100);
   method_    VARCHAR2(100):= 'Enumerate_Db'; 
BEGIN
   pkg_ := Dictionary_SYS.Get_Base_Package(lu_name_);
   Assert_SYS.Assert_Is_Package_Method(pkg_,method_);
   
   stmt_ := 'BEGIN '|| pkg_ ||'.'|| method_ ||'(:db_value_); END;';
   @ApproveDynamicStatement(2014-01-20,NipKlk)
   EXECUTE IMMEDIATE stmt_ USING OUT db_values_ ;

EXCEPTION
   WHEN OTHERS THEN
      Trace_SYS.Message('Error when fetching DB Values: ' || SQLERRM);
END Enumerate_Db_Values;


PROCEDURE Enumerate_Client_Values (
   client_values_ OUT VARCHAR2,
   lu_name_ IN VARCHAR2)
IS
   stmt_      VARCHAR2(8000);
   pkg_       VARCHAR2(100);
   method_    VARCHAR2(100):= 'Enumerate'; 
BEGIN
   pkg_ := Dictionary_SYS.Get_Base_Package(lu_name_);
   Assert_SYS.Assert_Is_Package_Method(pkg_,method_);
   
   stmt_ := 'BEGIN '|| pkg_ ||'.'|| method_ ||'(:client_values_); END;';
   @ApproveDynamicStatement(2014-01-20,NipKlk)
   EXECUTE IMMEDIATE stmt_ USING OUT client_values_ ;

EXCEPTION
   WHEN OTHERS THEN
      Trace_SYS.Message('Error when fetching DB Values: ' || SQLERRM);
END Enumerate_Client_Values;


PROCEDURE Check_Restricted_Methods(
   intface_name_ IN VARCHAR2,
   method_list_ OUT VARCHAR2)
IS
   CURSOR get_job_methods IS
      SELECT method_name,on_new,on_modify FROM intface_method_list WHERE intface_name = intface_name_;
   
BEGIN
   method_list_ := NULL;
   FOR rec IN get_job_methods LOOP
      IF (instr(rec.method_name,'.')>0) THEN
         IF( NOT Security_SYS.Is_Method_Available(rec.method_name)) THEN
            IF(method_list_ IS NULL) THEN
               method_list_ := rec.method_name; 
            ELSE
               method_list_ := method_list_||','||rec.method_name;
            END IF;
         END IF;
      ELSE
         IF(rec.on_new = 'TRUE') THEN
            IF( NOT Security_SYS.Is_Method_Available(rec.method_name||'.New__')) THEN
               IF(method_list_ IS NULL) THEN
                  method_list_ := rec.method_name||'.New__'; 
               ELSE
                  method_list_ := method_list_||','||rec.method_name||'.New__';
               END IF;
            END IF;
         END IF;
         IF(rec.on_modify = 'TRUE') THEN
            IF( NOT Security_SYS.Is_Method_Available(rec.method_name||'.Modify__')) THEN
               IF(method_list_ IS NULL) THEN
                  method_list_ := rec.method_name||'.Modify__'; 
               ELSE
                  method_list_ := method_list_||','||rec.method_name||'.Modify__';
               END IF;
            END IF;
         END IF;
      END IF;
   END LOOP;
END Check_Restricted_Methods;



