-----------------------------------------------------------------------------
--
--  Logical unit: IntfaceViews
--  Component:    FNDMIG
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  070927  JHMASE Bug #68013 - Displays VARCHAR2 length in bytes, not characters
--  061102  JHMASE Bug #61592 - Remove unnecessary references
--  060808  TRLYNO Bug #59318 - FNDMIG bugfixes, removed objid/objversion
--                              from view definintions. 
--                              (Causes errors in Security when granting PresObj)
--  060209  TRLYNO Bug #55643 - Change view-definitions from user_ to dba_
--  030708  TRLY  Prepared for new module FNDMI
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------


-------------------- PRIVATE DECLARATIONS -----------------------------------


-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------

FUNCTION Check_Exist___ (
   view_name_ IN VARCHAR2 ) RETURN BOOLEAN
IS
   dummy_ NUMBER;
   CURSOR exist_control IS
      SELECT 1
      FROM   INTFACE_VIEWS
      WHERE  view_name = view_name_;
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


-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------

-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------

-- Exist
--   Checks if given pointer (e.g. primary key) to an instance of this
--   logical unit exists. If not an exception will be raised.
@UncheckedAccess
PROCEDURE Exist (
   view_name_ IN VARCHAR2 )
IS
BEGIN
   IF (NOT Check_Exist___(view_name_)) THEN
      Error_SYS.Record_Not_Exist(lu_name_);
   END IF;
END Exist;



