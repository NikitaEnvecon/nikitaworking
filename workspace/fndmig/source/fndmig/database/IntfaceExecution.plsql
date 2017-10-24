-----------------------------------------------------------------------------
--
--  Logical unit: IntfaceExecution
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

-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------

PROCEDURE New (
   info_     OUT    VARCHAR2,
   attr_     IN OUT VARCHAR2,
   action_   IN     VARCHAR2)
IS
   newrec_     INTFACE_EXECUTION_TAB%ROWTYPE;
   objid_      VARCHAR2(2000);
   objversion_ VARCHAR2(2000);
   indrec_     Indicator_Rec;

BEGIN
   IF (action_ = 'DO') THEN
      Unpack___(newrec_, indrec_, attr_);
      Check_Insert___(newrec_, indrec_, attr_);    
      Insert___(objid_, objversion_, newrec_, attr_);
   END IF;
END New;

PROCEDURE Remove (
   execution_id_ intface_execution_tab.execution_id%TYPE )
IS
   remrec_ intface_execution_tab%ROWTYPE;
BEGIN
   remrec_ := Lock_By_Keys_Nowait___(execution_id_);
   Check_Delete___(remrec_);
   Delete___(remrec_);
END Remove;
