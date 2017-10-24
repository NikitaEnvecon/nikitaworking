-----------------------------------------------------------------------------
--
--  Logical unit: IntfaceMethodListAttrib
--  Component:    FNDMIG
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  060329  TRLYNO Bug #56862 - FNDMIG added functionality,
--                 Add checks when changing FIXED_VALUES
--  050306  TRLY   Bug #50034 - Insert rows in IntfaceDetai
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------


-------------------- PRIVATE DECLARATIONS -----------------------------------


-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------

PROCEDURE Check_At_Pos___ (
   intface_name_ IN VARCHAR2,
   execute_seq_  IN NUMBER,
   fixed_value_  IN VARCHAR2 )
IS
   at_pos_    NUMBER;
   seq_       VARCHAR2(100);
   found_seq_ NUMBER;
   CURSOR get_data IS
      SELECT execute_seq
      FROM intface_method_list_tab
      WHERE intface_name = intface_name_
      AND execute_seq = to_number(seq_);
BEGIN
   at_pos_ := instr(fixed_value_,'@');
   seq_ := ltrim(substr(fixed_value_,at_pos_ +1),'0');
   IF ( seq_ BETWEEN '1' AND '9999999999') THEN
      OPEN  get_data;
      FETCH get_data INTO found_seq_;
      IF ( get_data%NOTFOUND ) THEN
         CLOSE get_data;
         Error_SYS.Record_General(lu_name_, 'WRONGSEQ1: EXECUTE_SEQ :P1 does not exist ', seq_);
      END IF;
      CLOSE get_data;
      IF ( execute_seq_ <= found_seq_ ) THEN
         Error_SYS.Record_General(lu_name_, 'WRONGSEQ2: Referred EXECUTE_SEQ must be prior to this one ');
      END IF;
   END IF;
END Check_At_Pos___ ;


PROCEDURE Insert_Intface_Details___ (
   newrec_ IN INTFACE_METHOD_LIST_ATTRIB_TAB%ROWTYPE )
IS
   max_pos_      NUMBER;
   max_attr_seq_ NUMBER;
   view_name_    intface_method_list.view_name%TYPE;
   --
   CURSOR get_max_values IS
      SELECT nvl(max(pos), 0) pos, nvl(max(attr_seq), 0) attr_seq
      FROM intface_detail
      WHERE intface_name = newrec_.intface_name
      AND column_name != 'OBJID';
BEGIN
   OPEN  get_max_values;
   FETCH get_max_values INTO max_pos_, max_attr_seq_;
   CLOSE get_max_values;
   --
   view_name_ := Intface_Method_List_API.Get_View_Name(newrec_.intface_name , newrec_.execute_seq );
   IF ( view_name_ IS NULL ) THEN
      view_name_ := 'METHOD'||to_char(newrec_.execute_seq);
   END IF;
   --
   BEGIN
   INSERT INTO Intface_Detail_Tab(
      INTFACE_NAME, COLUMN_NAME, DATA_TYPE, LENGTH, flags,
      CHANGE_DEFAULTS, DESCRIPTION,  ATTR_SEQ, POS, ROWVERSION)
   VALUES(newrec_.intface_name, view_name_||'.'||newrec_.column_name , 'VARCHAR2',  2000, newrec_.flags,
      '2',  newrec_.description, max_attr_seq_ + 10, max_pos_ + 10, sysdate);   
   EXCEPTION
      WHEN OTHERS THEN NULL ; -- May exists
   END;
END Insert_Intface_Details___;


PROCEDURE Check_Dynamic_Procs___ (
   newrec_ IN INTFACE_METHOD_LIST_ATTRIB_TAB%ROWTYPE )
IS
   method_name_ intface_method_list_tab.method_name%TYPE;
   dummy_       VARCHAR2(2000);
BEGIN
   IF ( Intface_Rules_API.Rule_Is_Active(
      dummy_, 'KEEPDYNAMPROC', newrec_.intface_name) ) THEN
      method_name_ := Intface_Method_List_API.Get_Method_Name(newrec_.intface_name, newrec_.execute_seq);
      IF ( INSTR(method_name_,'.') != 0 ) THEN
         -- Fixed-values has been changed, drop procedure, so that it will be re-generated
         -- next time job starts
         Intface_Method_List_API.Drop_One_Dynamic_Proc(newrec_.intface_name, newrec_.execute_seq);
      END IF;
   END IF;
END Check_Dynamic_Procs___;


@Override
PROCEDURE Check_Insert___ (
   newrec_ IN OUT intface_method_list_attrib_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS
BEGIN
      -- Check that sequence for demanded item is lower than this one
   IF ( instr(newrec_.fixed_value,'@') != 0  ) THEN
      Check_At_Pos___(newrec_.intface_name, newrec_.execute_seq, newrec_.fixed_value);
   END IF;
   Insert_Intface_Details___ (newrec_ );
   --
   super(newrec_, indrec_, attr_);
END Check_Insert___;


@Override
PROCEDURE Check_Update___ (
   oldrec_ IN     intface_method_list_attrib_tab%ROWTYPE,
   newrec_ IN OUT intface_method_list_attrib_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS
BEGIN
   -- Check that sequence for demanded item is lower than this one
   IF ( instr(newrec_.fixed_value,'@') != 0  ) THEN
      Check_At_Pos___(newrec_.intface_name, newrec_.execute_seq, newrec_.fixed_value);
   END IF;
   super(oldrec_, newrec_, indrec_, attr_);
END Check_Update___;

@Override
PROCEDURE Update___ (
   objid_      IN     VARCHAR2,
   oldrec_     IN     intface_method_list_attrib_tab%ROWTYPE,
   newrec_     IN OUT intface_method_list_attrib_tab%ROWTYPE,
   attr_       IN OUT VARCHAR2,
   objversion_ IN OUT VARCHAR2,
   by_keys_    IN     BOOLEAN DEFAULT FALSE )
IS
BEGIN
   super(objid_, oldrec_, newrec_, attr_, objversion_, by_keys_);
   -- Check if fixed_value has been changed
   IF ( (newrec_.fixed_value IS NOT NULL AND oldrec_.fixed_value IS NULL) OR
        (newrec_.fixed_value != oldrec_.fixed_value )  ) THEN
      Check_Dynamic_Procs___(newrec_);
   END IF;
END Update___;


-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------

-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------


