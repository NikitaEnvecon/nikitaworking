-----------------------------------------------------------------------------
--
--  Logical unit: IntfaceReplStructCols
--  Component:    FNDMIG
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  040507  TRLY  Created
--                Bug #44483 - Replication of Object structure
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------

-------------------- PRIVATE DECLARATIONS -----------------------------------


-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------

@Override
PROCEDURE Prepare_Insert___ (
   attr_ IN OUT VARCHAR2 )
IS
BEGIN
   super(attr_);
   Client_SYS.Add_to_Attr('ON_INSERT','TRUE',attr_);
   Client_SYS.Add_to_Attr('ON_UPDATE','TRUE',attr_);
END Prepare_Insert___;


@Override
PROCEDURE Check_Insert___ (
   newrec_ IN OUT intface_repl_struct_cols_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS
BEGIN
   IF ( newrec_.data_type NOT IN ( 'NUMBER','DATE','VARCHAR2' ) ) THEN
      Error_SYS.Item_Format(lu_name_, 'DATA_TYPE', newrec_.data_type);
   END IF;
   Intface_Repl_Maint_Util_API.Check_Update_Allowed(newrec_.intface_name);
   super(newrec_, indrec_, attr_);
END Check_Insert___;

@Override
PROCEDURE Check_Update___ (
   oldrec_ IN     intface_repl_struct_cols_tab%ROWTYPE,
   newrec_ IN OUT intface_repl_struct_cols_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS
BEGIN
   IF ( newrec_.data_type NOT IN ( 'NUMBER','DATE','VARCHAR2' ) ) THEN
      Error_SYS.Item_Format(lu_name_, 'DATA_TYPE', newrec_.data_type);
   END IF;
   Intface_Repl_Maint_Util_API.Check_Update_Allowed(newrec_.intface_name);
   super(oldrec_, newrec_, indrec_, attr_);
END Check_Update___;

-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------

-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------

PROCEDURE Insert_Default_Cols (
   intface_name_  IN VARCHAR2,
   structure_seq_ IN VARCHAR2,
   view_name_     IN VARCHAR2 )
IS
   flags_           intface_repl_struct_cols_tab.flags%TYPE;
   description_     intface_repl_struct_cols_tab.description%TYPE;
   on_insert_       intface_repl_struct_cols_tab.on_insert%TYPE;
   on_update_       intface_repl_struct_cols_tab.on_update%TYPE;
   parent_key_name_ intface_repl_struct_cols_tab.parent_key_name%TYPE;
   --
   CURSOR get_columns IS
      SELECT a.column_name column_name, a.data_type data_type,
             to_number(decode(a.data_type, 'NUMBER', nvl(a.data_precision, 20), a.data_length)) length,
             to_number(nvl(a.data_scale, 0)) data_scale, to_number(a.column_id * 10) column_seq, b.comments
      FROM all_tab_columns a, user_col_comments B
      WHERE a.table_name = view_name_
      AND a.table_name  = b.table_name
      AND a.column_name = b.column_name
      -- Allow DB-columns,
      -- except for DataMigration LU
      -- This because we use an old FND template.
      AND ((nvl(substr(Dictionary_SYS.Comment_Value_('FLAGS', b.comments), 1, 4),'A---') != 'A---')
           or ( a.column_name like '%_DB' and substr(view_name_,1,7) != 'INTFACE'))
      ORDER BY a.column_id;
BEGIN
   FOR rec_ IN get_columns LOOP
      flags_ := substr(Dictionary_SYS.Comment_Value_('FLAGS', rec_.comments), 1, 4);
      IF ( substr(flags_, 1, 1) IN ('P', 'K') ) THEN
         flags_ := substr(flags_, 1, 1);
         parent_key_name_ := rec_.column_name;
      ELSE
         flags_ := replace(substr(flags_, 2, 3), '-', '');
         parent_key_name_ := NULL;
      END IF;
      description_ := Intface_Detail_API.Get_Column_Description(view_name_, rec_.column_name);
      IF ( rec_.column_name like '%_DB' ) THEN
         on_insert_ := 'FALSE';
         on_update_ := 'FALSE';
      ELSE
         on_insert_ := 'TRUE';
         on_update_ := 'TRUE';
      END IF;
      --
      INSERT INTO intface_repl_struct_cols_tab (
         intface_name, structure_seq, column_name, column_seq, description,
         on_insert, on_update, data_type, flags, parent_key_name, rowversion)
      VALUES ( intface_name_, structure_seq_, rec_.column_name, rec_.column_seq, description_,
         on_insert_, on_update_, rec_.data_type, nvl(flags_,'-'), parent_key_name_, sysdate );
   END LOOP;
END Insert_Default_Cols;





