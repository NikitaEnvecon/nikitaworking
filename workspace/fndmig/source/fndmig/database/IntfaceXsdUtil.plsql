-----------------------------------------------------------------------------
--
--  Logical unit: IntfaceXsdUtil
--  Component:    FNDMIG
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  071116  JHMASE Created
--  071120  TRLYNO Bug #69973 Added procedure for client file
--  100525  JHMASE Bug #90876 Error in namespace declaratio
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------


-------------------- PRIVATE DECLARATIONS -----------------------------------

TYPE xsd_line_type_   IS TABLE OF VARCHAR2(200)  INDEX BY BINARY_INTEGER;

-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------

PROCEDURE Add_To_Array___ (
   value_ IN VARCHAR2,
   xsd_array_ IN OUT NOCOPY xsd_line_type_,
   xsd_idx_ IN OUT NOCOPY BINARY_INTEGER)
IS
BEGIN
   xsd_idx_ := xsd_idx_ + 1;
   xsd_array_(xsd_idx_) := value_;
END Add_To_Array___;


PROCEDURE Clear_Array___(
   xsd_array_ IN OUT NOCOPY xsd_line_type_,
   xsd_idx_ IN OUT NOCOPY BINARY_INTEGER)
IS
   xsd_array_empty_      xsd_line_type_;
BEGIN
   xsd_array_ := xsd_array_empty_;
   xsd_idx_ := 0;
END Clear_Array___;


PROCEDURE Create_Simple_Elements___ (
   xsd_name_      IN VARCHAR2,
   structure_seq_ IN NUMBER,
   view_name_     IN VARCHAR2,
   xsd_array_ IN OUT NOCOPY xsd_line_type_,
   xsd_idx_ IN OUT NOCOPY BINARY_INTEGER)
IS
   nillable_  VARCHAR2(5) := 'false';
   minoccurs_ VARCHAR2(1);
   CURSOR columns_ (intface_name_  VARCHAR2,
                    structuer_seq_ NUMBER,
                    view_name_     VARCHAR2) is
      SELECT NVL(a.column_alias,a.column_name) column_name,
             a.data_type,
             b.data_length,
             NVL(b.nullable,'Y') nullable
      FROM   intface_repl_struct_cols a,
             user_tab_columns b
      WHERE  a.intface_name  = intface_name_
      AND    a.structure_seq = structure_seq_
      AND    b.table_name    = view_name_
      AND    a.column_name   = b.column_name
      AND    (a.on_insert    = 'TRUE' 
         OR   a.on_update    = 'TRUE')
      ORDER BY a.column_seq;
BEGIN
   FOR rec_ IN columns_ (xsd_name_, structure_seq_, view_name_) LOOP
      IF (rec_.nullable = 'Y') THEN minoccurs_ := '0';
      ELSE                          minoccurs_ := '1';
      END IF;
      IF    (rec_.data_type = 'DATE') THEN
         add_to_array___('<xs:element type="xs:date" minOccurs="' || minoccurs_ || '" nillable="' || nillable_ || '" name="' || rec_.column_name || '">',xsd_array_,xsd_idx_);
      ELSIF (rec_.data_type = 'BLOB') THEN
         add_to_array___('<xs:element type="xs:base64Binary" minOccurs="' || minoccurs_ || '" nillable="' || nillable_ || '" name="' || rec_.column_name || '">',xsd_array_,xsd_idx_);
      ELSIF (rec_.data_type IN ('NUMBER','FLOAT')) THEN
         add_to_array___('<xs:element type="xs:float" minOccurs="' || minoccurs_ || '" nillable="' || nillable_ || '" name="' || rec_.column_name || '">',xsd_array_,xsd_idx_);
      ELSE
         add_to_array___('<xs:element minOccurs="' || minoccurs_ || '" nillable="' || nillable_ || '" name="' || rec_.column_name || '">',xsd_array_,xsd_idx_);
         add_to_array___('<xs:simpleType>',xsd_array_,xsd_idx_);
         add_to_array___('<xs:restriction base="xs:string">',xsd_array_,xsd_idx_);
         add_to_array___('<xs:maxLength value="' || TO_CHAR(rec_.data_length) || '"></xs:maxLength>',xsd_array_,xsd_idx_);
         add_to_array___('</xs:restriction>',xsd_array_,xsd_idx_);
         add_to_array___('</xs:simpleType>',xsd_array_,xsd_idx_);
      END IF;
      add_to_array___('</xs:element>',xsd_array_,xsd_idx_);
   END LOOP;
END Create_Simple_Elements___;


PROCEDURE Create_Complex_Elements___ (
   xsd_name_      IN VARCHAR2,
   structure_seq_ IN NUMBER,
   xsd_array_ IN OUT NOCOPY xsd_line_type_,
   xsd_idx_ IN OUT NOCOPY BINARY_INTEGER)
IS
   nillable_  VARCHAR2(5) := 'false';
   minoccurs_ VARCHAR2(1) := '0';
   maxoccurs_ VARCHAR2(9) := 'unbounded';
   CURSOR records_ (intface_name_  VARCHAR2,
                    structure_seq_ NUMBER) is
      SELECT a.record_name,
             a.element_name,
             a.view_name,
             a.structure_seq
      FROM   intface_repl_structure a
      WHERE  a.intface_name  = intface_name_
      AND    a.parent_seq    = structure_seq_;
BEGIN
   FOR rec_ IN records_ (xsd_name_, structure_seq_) LOOP
      IF (rec_.record_name IS NOT NULL) THEN
         add_to_array___('<xs:element minOccurs="' || minoccurs_ || '" nillable="' || nillable_ || '" name="' || rec_.element_name || '">',xsd_array_,xsd_idx_);
         add_to_array___('<xs:complexType>',xsd_array_,xsd_idx_);
         add_to_array___('<xs:sequence minOccurs="' || minoccurs_ || '" maxOccurs="' || maxoccurs_ || '">',xsd_array_,xsd_idx_);
         add_to_array___('<xs:element name="' || rec_.record_name || '">',xsd_array_,xsd_idx_);
         add_to_array___('<xs:complexType>',xsd_array_,xsd_idx_);
         add_to_array___('<xs:all>',xsd_array_,xsd_idx_);
         create_simple_elements___(xsd_name_, rec_.structure_seq, rec_.view_name,xsd_array_,xsd_idx_);
         create_complex_elements___(xsd_name_, rec_.structure_seq,xsd_array_,xsd_idx_);
         add_to_array___('</xs:all>',xsd_array_,xsd_idx_);
         add_to_array___('</xs:complexType>',xsd_array_,xsd_idx_);
         add_to_array___('</xs:element>',xsd_array_,xsd_idx_);           
         add_to_array___('</xs:sequence>',xsd_array_,xsd_idx_);
         add_to_array___('</xs:complexType>',xsd_array_,xsd_idx_);
         add_to_array___('</xs:element>',xsd_array_,xsd_idx_);
      ELSE
         add_to_array___('<xs:element name="' || rec_.element_name || '">',xsd_array_,xsd_idx_);
         add_to_array___('<xs:complexType>',xsd_array_,xsd_idx_);
         add_to_array___('<xs:all>',xsd_array_,xsd_idx_);
         create_simple_elements___(xsd_name_, rec_.structure_seq, rec_.view_name,xsd_array_,xsd_idx_);
         create_complex_elements___(xsd_name_, rec_.structure_seq,xsd_array_,xsd_idx_);
         add_to_array___('</xs:all>',xsd_array_,xsd_idx_);
         add_to_array___('</xs:complexType>',xsd_array_,xsd_idx_);
         add_to_array___('</xs:element>',xsd_array_,xsd_idx_);
      END IF;
   END LOOP;
END Create_Complex_Elements___;


PROCEDURE Create_Start_Point___ (
   xsd_name_  IN VARCHAR2,
   xsd_array_ IN OUT NOCOPY xsd_line_type_,
   xsd_idx_ IN OUT NOCOPY BINARY_INTEGER)
IS
   CURSOR records_ (intface_name_  VARCHAR2) is
      SELECT a.record_name,
             a.element_name,
             a.view_name,
             a.structure_seq
      FROM   intface_repl_structure a
      WHERE  a.intface_name  = intface_name_
--      AND    a.start_point   = 'TRUE';
      AND    a.parent_seq IS NULL;
BEGIN
   FOR rec_ IN records_ (xsd_name_) LOOP
      add_to_array___('<xs:element name="' || rec_.record_name || '">',xsd_array_,xsd_idx_);
      add_to_array___('<xs:complexType>',xsd_array_,xsd_idx_);
      add_to_array___('<xs:all>',xsd_array_,xsd_idx_);
      create_simple_elements___(xsd_name_, rec_.structure_seq, rec_.view_name,xsd_array_,xsd_idx_);
      create_complex_elements___(xsd_name_, rec_.structure_seq,xsd_array_,xsd_idx_);
      add_to_array___('</xs:all>',xsd_array_,xsd_idx_);
      add_to_array___('</xs:complexType>',xsd_array_,xsd_idx_);
      add_to_array___('</xs:element>',xsd_array_,xsd_idx_);
   END LOOP;
END Create_Start_Point___;


PROCEDURE Save_To_File___ (
   intface_name_  IN VARCHAR2,
   xsd_array_ IN xsd_line_type_,
   xsd_idx_ IN BINARY_INTEGER)
IS
BEGIN
trace_sys.message('Trace >>>>>>>>>>>>  start save_to_file');
trace_sys.message('Trace >>>>>>>>>>>>  XSD_IDX_ '||xsd_idx_);
   FOR i IN 1..xsd_idx_ LOOP
      IF ( App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_file_is_on_client_cid_) ) THEN
trace_sys.message('Trace >>>>>>>>>>>>  write to client '||i||' '||xsd_array_(i));
        Intface_Job_Detail_API.Process_Job_Details(intface_name_, i ,xsd_array_(i), null , 'OUTPUT_TO_CLIENT', null);
      ELSE
trace_sys.message('Trace >>>>>>>>>>>>  write to server '||i||' '||xsd_array_(i));
        UTL_FILE.PUT_LINE (Intface_Detail_API.intf_file_handle_, Database_SYS.Db_To_File_Encoding(xsd_array_(i)));
      END IF;
   END LOOP;
END Save_To_File___;


-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------

-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

FUNCTION Create_Xsd_ (
   xsd_name_ IN VARCHAR2,
   p_intface_name_ IN VARCHAR2) RETURN VARCHAR2
IS
BEGIN
   create_xsd(xsd_name_,p_intface_name_);
   RETURN 'X';
END Create_Xsd_;


-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------

PROCEDURE Create_Xsd_Client(
  info_          IN OUT VARCHAR2,
  intface_name_  IN     VARCHAR2 ) 
IS
   xsd_array_ xsd_line_type_;
   xsd_idx_ BINARY_INTEGER;
BEGIN
   clear_array___(xsd_array_,xsd_idx_);
   add_to_array___('<?xml version="1.0" encoding="UTF-8"?>',xsd_array_,xsd_idx_);
   add_to_array___('<xs:schema xmlns:xs="http://www.w3.org/2001/XMLSchema">',xsd_array_,xsd_idx_);
   create_start_point___(intface_name_,xsd_array_,xsd_idx_);
   add_to_array___('</xs:schema>',xsd_array_,xsd_idx_);
   App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_file_is_on_client_cid_,TRUE);      
   Intface_Job_Detail_API.Delete_Details(intface_name_);
   save_to_file___(intface_name_,xsd_array_,xsd_idx_);
   info_ := Language_SYS.Translate_Constant(lu_name_, ' XSDCRE: XSD created as Client File, :P1 lines ', Fnd_Session_API.Get_Language, xsd_idx_);
END Create_Xsd_Client;


PROCEDURE Create_Xsd(
   xsd_name_  IN VARCHAR2,
   p_intface_name_ IN VARCHAR2) 
IS
   xsd_array_ xsd_line_type_;
   xsd_idx_ BINARY_INTEGER;
BEGIN
   clear_array___(xsd_array_,xsd_idx_);
   add_to_array___('<?xml version="1.0" encoding="UTF-8"?>',xsd_array_,xsd_idx_);
   add_to_array___('<xs:schema xmlns:xs="http://www.w3.org/2001/XMLSchema">',xsd_array_,xsd_idx_);
   create_start_point___(xsd_name_,xsd_array_,xsd_idx_);
   add_to_array___('</xs:schema>',xsd_array_,xsd_idx_);
   save_to_file___(p_intface_name_,xsd_array_,xsd_idx_);
   App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_execution_ok_cid_,TRUE);
END Create_Xsd;



