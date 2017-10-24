-----------------------------------------------------------------------------
--
--  Logical unit: IntfaceExecutionDetail
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

-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------

-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

PROCEDURE Set_Error_Message_ (
   error_message_ IN VARCHAR2,
   line_rowid_    IN VARCHAR2 )
IS
BEGIN
   IF ( line_rowid_ IS NOT NULL ) THEN
      UPDATE intface_execution_detail_tab
         SET error_message = error_message_
         WHERE rowid = line_rowid_;
   END IF;  
END Set_Error_Message_;


-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------

PROCEDURE New (
   info_     OUT    VARCHAR2,
   attr_     IN OUT VARCHAR2,
   action_   IN     VARCHAR2)
IS
   newrec_     INTFACE_EXECUTION_DETAIL_TAB%ROWTYPE;
   objid_      VARCHAR2(2000);
   objversion_ VARCHAR2(2000);
   indrec_     Indicator_Rec;

BEGIN
   IF (action_ = 'DO') THEN
      Client_SYS.Add_To_Attr('DATE_EXECUTED', sysdate , attr_);
      Client_SYS.Add_To_Attr('STATUS', Intface_Job_Status_API.Decode('2'), attr_);
      Unpack___(newrec_, indrec_, attr_);
      Check_Insert___(newrec_, indrec_, attr_);      
      Insert___(objid_, objversion_, newrec_, attr_);
   END IF;
END New;



