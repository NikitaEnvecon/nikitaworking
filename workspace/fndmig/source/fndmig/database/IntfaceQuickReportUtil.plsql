-----------------------------------------------------------------------------
--
--  Logical unit: IntfaceQuickReportUtil
--  Component:    FNDMIG
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  091125  NABALK Bug #84218 - Certified the assert safe for dynamic SQLs
--  081128  JHMASE Bug #78954 - Removal of obsolete remarks.
--  041101  JHMASE Unicode
--  040507  TRLY  Create
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------

-------------------- PRIVATE DECLARATIONS -----------------------------------


-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------

-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------


-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------
@Deprecated
PROCEDURE Import_Reports (
   attr_ IN VARCHAR2 ) 
IS
BEGIN
   Error_SYS.Appl_General(lu_name_, 'DEPREC: This Functionality is Deprecated. Use the built in Import/Export functionality in Quick Reports instead.');
END Import_Reports;

@Deprecated
PROCEDURE Quick_Reports_Out (
   info_         IN OUT VARCHAR2,
   intface_name_ IN     VARCHAR2 )
IS
BEGIN
   Error_SYS.Appl_General(lu_name_, 'DEPREC: This Functionality is Deprecated. Use the built in Import/Export functionality in Quick Reports instead.');
END Quick_Reports_Out;



