-----------------------------------------------------------------------------
--
--  Logical unit: IntfaceEvents
--  Component:    FNDMIG
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  050306  TRLY  Bug #50034 - Fixed event-handling.
--  030708  TRLY  Prepared for new module FNDMI
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------


-------------------- PRIVATE DECLARATIONS -----------------------------------


-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------

-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------

-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------

PROCEDURE Notify_Job_Finished (
   min_status_ IN VARCHAR2,
   max_status_ IN VARCHAR2,
   intf_info_rec_ IN OUT NOCOPY Intface_Job_Detail_API.Intface_Info_Collection )
IS
   fnd_user_     VARCHAR2(30);
   msg_          VARCHAR2(32000);
   date_format_  VARCHAR2(30) := Client_SYS.date_format_;
   line_no_      NUMBER;
   error_msg_    VARCHAR2(2000);
   attrib_       VARCHAR2(2000);
   event_id_     VARCHAR2(100);
   --
   CURSOR get_error IS
   SELECT line_no, error_message, attribute_string
   FROM intface_job_detail
   WHERE intface_name = intf_info_rec_.intface_name_ 
   AND error_message IS NOT NULL;
   --
BEGIN
   IF ( intf_info_rec_.event_ ) THEN
      IF ( min_status_ = '3' OR max_status_ = '3'  ) THEN -- Errors, get one error line
         -- Fetch one error
         OPEN  get_error;
         FETCH get_error INTO line_no_, error_msg_, attrib_;
         CLOSE get_error;
         msg_ := Message_SYS.Construct('NOTIFY_ERROR_JOB');
         event_id_ := 'NOTIFY_ERROR_JOB';
      ELSIF ( NOT App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_execution_ok_cid_)) THEN -- Error, but no job details
         msg_ := Message_SYS.Construct('NOTIFY_ERROR_JOB');
         error_msg_ := Intface_Header_API.Get_Last_Info(intf_info_rec_.intface_name_);
         event_id_ := 'NOTIFY_ERROR_JOB';
      ELSE
         msg_ := Message_SYS.Construct('NOTIFY_FINISHED_JOB');
         event_id_ := 'NOTIFY_FINISHED_JOB';
      END IF;
      --
      IF (Event_SYS.Event_Enabled('IntfaceEvents', event_id_ )) THEN
         fnd_user_ := Fnd_Session_API.Get_Fnd_User;
         Message_SYS.Add_Attribute( msg_, 'EXECUTED_BY', fnd_user_ );
         Message_SYS.Add_Attribute( msg_, 'USER_DESCRIPTION', Fnd_User_API.Get_Description(fnd_user_));
         Message_SYS.Add_Attribute( msg_, 'USER_MAIL_ADDRESS', Fnd_User_API.Get_Property(fnd_user_, 'SMTP_MAIL_ADDRESS'));
         Message_SYS.Add_Attribute( msg_, 'USER_MOBILE_PHONE', Fnd_User_API.Get_Property(fnd_user_, 'MOBILE_PHONE'));
         Message_SYS.Add_Attribute( msg_, 'INTFACE_NAME', intf_info_rec_.intface_name_);
         Message_SYS.Add_Attribute( msg_, 'INTFACE_DESC', Intface_Header_API.Get_Description(intf_info_rec_.intface_name_));
         Message_SYS.Add_Attribute( msg_, 'PROCEDURE_NAME', Intface_Header_API.Get_Procedure_Name(intf_info_rec_.intface_name_));
         Message_SYS.Add_Attribute( msg_, 'DATE_EXECUTED', to_char(App_Context_SYS.Find_Date_Value(Intface_Job_Detail_API.intf_date_executed_cid_), date_format_));
         Message_SYS.Add_Attribute( msg_, 'LAST_INFO', Intface_Job_Detail_API.Get_Ctx_Val_Intf_Last_Info);
         Message_SYS.Add_Attribute( msg_, 'SOURCE', Intface_Header_API.Get_Intface_Source(intf_info_rec_.intface_name_));
         Message_SYS.Add_Attribute( msg_, 'WHERE_CLAUSE', Intface_Header_API.Get_Complete_Where(intf_info_rec_.intface_name_));
         Message_SYS.Add_Attribute( msg_, 'EXECUTION_NO', App_Context_SYS.Find_Number_Value(Intface_Job_Detail_API.intf_execution_no_cid_));
         Message_SYS.Add_Attribute( msg_, 'LINE_NO', line_no_ );
         Message_SYS.Add_Attribute( msg_, 'ERROR_MESSAGE', error_msg_ );
         Message_SYS.Add_Attribute( msg_, 'ATTRIBUTE_STRING', attrib_ );

         Event_SYS.Event_Execute('IntfaceEvents', event_id_ , msg_);

      END IF;
   END IF;
END Notify_Job_Finished;


