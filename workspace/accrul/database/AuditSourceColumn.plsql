-----------------------------------------------------------------------------
--
--  Logical unit: AuditSourceColumn
--  Component:    ACCRUL
--
--  IFS Developer Studio Template Version 3.0
--
--  Date      Sign    History
--  ------    ------  ---------------------------------------------------------
--  11-03-14  PRatlk  PBFI-5898, Changes in Basic Data Insertion methods.
--  16-11-15  Nudilk  Bug 125759, Corrected in Insert_Lu_Data_Rec.
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------


-------------------- PRIVATE DECLARATIONS -----------------------------------


-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------

-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------

-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------

PROCEDURE Insert_Lu_Data_Rec (
   insrec_        IN AUDIT_SOURCE_COLUMN_TAB%ROWTYPE)
IS
   dummy_      VARCHAR2(1);
   -- Bug 125759,begin.
   newrec_     audit_source_column_tab%ROWTYPE;
   -- Bug 125759,end.
   CURSOR Exist IS
      SELECT 'X'
      FROM AUDIT_SOURCE_COLUMN_TAB
      WHERE audit_source = insrec_.audit_source
      AND   source_column = insrec_.source_column;
BEGIN
   -- Bug 125759,begin.
   newrec_        := insrec_;
   newrec_.rowkey := NVL(newrec_.rowkey, sys_guid());
   -- Bug 125759,end.
   
   OPEN Exist;
      FETCH Exist INTO dummy_;
      IF (Exist%NOTFOUND) THEN
         INSERT
         INTO audit_source_column_tab
         VALUES newrec_;
         -- Bug 125759,moved code outside of if conditon.
      ELSE
         -- Bug 125759,moved code outside of if conditon.
   -- Remark: Only update the attribute that is supposed to be translated, in this case description
   -- Always use the key of the LU in the Where statement.
         UPDATE AUDIT_SOURCE_COLUMN_TAB
            SET selection_date_title = newrec_.selection_date_title
            WHERE audit_source  = newrec_.audit_source
            AND   source_column = newrec_.source_column;
      END IF;
      CLOSE Exist;
   -- Bug 125759,begin.   
   Basic_Data_Translation_API.Insert_Prog_Translation(module_, lu_name_, newrec_.audit_source || '^' || newrec_.source_column || '^DESCRIPTION', newrec_.selection_date_title);
   -- Bug 125759,end.
END Insert_Lu_Data_Rec;


@UncheckedAccess
FUNCTION Get_Selection_Date_Title (
   audit_source_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   temp_ AUDIT_SOURCE_COLUMN_TAB.selection_date_title%TYPE;
   CURSOR get_attr IS
      SELECT selection_date_title
      FROM   AUDIT_SOURCE_COLUMN
      WHERE  audit_source = audit_source_
        AND  selection_date_db = 'TRUE';
BEGIN
   OPEN get_attr;
   FETCH get_attr INTO temp_;
   CLOSE get_attr;
   RETURN temp_;
END Get_Selection_Date_Title;








