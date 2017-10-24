-----------------------------------------------------------------------------
--
--  Logical unit: IntfaceUser
--  Component:    FNDMIG
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  030708  TRLY  Prepared for new module FNDMI
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------


-------------------- PRIVATE DECLARATIONS -----------------------------------


-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------


-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------


-------------------- LU SPECIFIC PROTECTED METHODS --------------------------


-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------

@UncheckedAccess   
FUNCTION Has_Update_Privilege(
   fnd_user_ IN VARCHAR2 DEFAULT Fnd_Session_API.Get_Fnd_User ) RETURN VARCHAR2
IS
BEGIN
   -- bypass for AppOwner
   IF (fnd_user_ = Fnd_Session_API.Get_App_Owner ) THEN 
      RETURN ('TRUE');
   ELSIF (Intface_User_API.Get_Privilege_Db(fnd_user_) = Intface_Privilege_API.DB_UPDATE_ALLOWED) THEN
      RETURN ('TRUE');
   ELSE
      RETURN ('FALSE');
   END IF;
END Has_Update_Privilege;