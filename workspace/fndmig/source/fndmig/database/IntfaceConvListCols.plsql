-----------------------------------------------------------------------------
--
--  Logical unit: IntfaceConvListCols
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
FUNCTION Get_New_Value (
   conv_list_id_ IN VARCHAR2,
   old_value_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   temp_ INTFACE_CONV_LIST_COLS.new_value%TYPE;
   CURSOR get_attr IS
      SELECT nvl(new_value,'NULLVALUE')
      FROM INTFACE_CONV_LIST_COLS
      WHERE conv_list_id = conv_list_id_
      AND   old_value_ LIKE old_value
      ORDER BY old_value DESC;
BEGIN
   OPEN get_attr;
   FETCH get_attr INTO temp_;
   CLOSE get_attr;
   RETURN temp_;
END Get_New_Value;


