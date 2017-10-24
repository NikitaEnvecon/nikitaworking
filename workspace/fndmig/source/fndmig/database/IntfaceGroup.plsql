-----------------------------------------------------------------------------
--
--  Logical unit: IntfaceGroup
--  Component:    FNDMIG
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  050307  TRLY  Bug #50034 - Enhancements for CPS4, added column HIDE_FLAG
--  030708  TRLY  Prepared for new module FNDMI
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------


-------------------- PRIVATE DECLARATIONS -----------------------------------


-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------


-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------

-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------


@Override
FUNCTION Get_Hide_Flag (
   group_id_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   temp_ intface_group_tab.hide_flag%TYPE;
BEGIN
   --Add pre-processing code here
   temp_ := super(group_id_);
   RETURN nvl(temp_,'FALSE');
END Get_Hide_Flag;






