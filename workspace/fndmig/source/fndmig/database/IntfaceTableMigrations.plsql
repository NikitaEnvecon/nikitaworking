-----------------------------------------------------------------------------
--
--  Logical unit: IntfaceTableMigrations
--  Component:    FNDMIG
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  080124  TRLYNO  Bug #70783 - Error 'Character buffer string too small' 
--                               when stmt_ to long to fit display buffer
--  071031  TRLYNO  Bug #70434 - Enable update of INTFACE_REPLICATION_LOG_TAB
--  060105  TRLYNO  Bug #55479 - Added functionality in Data Migration
--  050706  JHMASE  Create
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------


-------------------- PRIVATE DECLARATIONS -----------------------------------

allowed_params_  CONSTANT VARCHAR2(2000) := ';DM_OPERATION;DM_TABLE_OWNER;DM_TABLE_NAME;'||
                                            'DM_DB_LINK;DM_DATE_FORMAT;DM_KEY_COLUMNS;';
allowed_tables_  CONSTANT VARCHAR2(32000) := ';IC_;VMO'||';';
TYPE global_rec IS RECORD (
   operation_       VARCHAR2(100),
   owner_           VARCHAR2(100),
   table_name_      VARCHAR2(100),
   db_link_         VARCHAR2(250),
   date_format_     VARCHAR2(100),
   key_columns_     VARCHAR2(2000),
   column_names_    VARCHAR2(32767),
   column_values_   VARCHAR2(32767),
   where_           VARCHAR2(32767),
   stmt_            VARCHAR2(32767));
CURSOR column_data_type_cursor_ (owner_ VARCHAR2,table_name_ VARCHAR2,column_name_ VARCHAR2) IS
   SELECT data_type
   FROM   all_tab_columns
   WHERE  owner       = owner_
   AND    table_name  = table_name_
   AND    column_name = column_name_;

-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------

FUNCTION Get_Data_Type___ (
   owner_       IN VARCHAR2,
   table_name_  IN VARCHAR2,
   column_name_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   data_type_ all_tab_columns.data_type%TYPE;
BEGIN
   OPEN column_data_type_cursor_(owner_, table_name_, column_name_);
   FETCH column_data_type_cursor_ INTO data_type_;
   CLOSE column_data_type_cursor_;
   RETURN data_type_;
END Get_Data_Type___;


FUNCTION Get_Next_Key_Name___ (
   key_names_ IN OUT VARCHAR2,
   ptr_       IN OUT NUMBER, 
   name_      OUT    VARCHAR2 ) RETURN BOOLEAN
IS
   pos_ NUMBER;
BEGIN
   key_names_ := ltrim(key_names_,';');
   IF ( ptr_ IS NULL ) THEN
      pos_  := INSTR(key_names_, ';');
      name_ := SUBSTR(key_names_, 1, pos_ - 1);
      ptr_  := pos_ + 1;
      IF ( name_ IS NULL ) THEN
         RETURN FALSE;
      END IF;
   ELSE
      pos_  := INSTR(key_names_, ';', ptr_);
      name_ := SUBSTR(key_names_, ptr_, pos_ - ptr_);
      ptr_  := pos_ + 1;
      IF ( name_ IS NULL ) THEN
         RETURN FALSE;
      END IF;
   END IF;
   RETURN TRUE;
END Get_Next_Key_Name___;


PROCEDURE Add_Db_Link___ (
   global_rec_ IN OUT global_rec )
IS
BEGIN
   IF ( global_rec_.db_link_ IS NOT NULL ) THEN
      global_rec_.stmt_ :=  global_rec_.stmt_ || '@' || global_rec_.db_link_;
   END IF;
END Add_Db_Link___;


FUNCTION Get_Bind_Value___ (
   name_       IN OUT VARCHAR2,
   global_rec_ IN global_rec) RETURN VARCHAR2
IS
   bind_value_ VARCHAR2(2000);
BEGIN
   IF ( Get_Data_Type___(global_rec_.owner_, global_rec_.table_name_, name_) = 'DATE' ) THEN
      bind_value_ := 'to_date( :'||name_||','||''''||global_rec_.date_format_||''''||')';
   ELSE
      bind_value_ := ':'||name_;
   END IF;
   RETURN bind_value_;
END Get_Bind_Value___;


PROCEDURE Display_Stmt___ (
   stmt_ IN VARCHAR2 )
IS
   start_  NUMBER := 1;
   end_    NUMBER := 250;
   length_ NUMBER := LENGTH(stmt_);
BEGIN
   WHILE ( start_ < length_ ) LOOP
      trace_sys.message(SUBSTR(stmt_, start_, end_));
      start_ := start_ + end_;
   END LOOP;
END Display_Stmt___;


PROCEDURE Create_Where_Stmt___ (
   attr_       IN VARCHAR2,
   global_rec_ IN OUT global_rec)
IS
   ptr_   NUMBER;
   name_  VARCHAR2(2000);
   bind_value_ VARCHAR2(2000);
   key_names_ VARCHAR2(32000);
BEGIN   
   key_names_ := ltrim(global_rec_.key_columns_,';');
   WHILE Get_Next_Key_Name___(key_names_, ptr_, name_) LOOP
      bind_value_ := Get_Bind_Value___(name_, global_rec_);
      IF ( global_rec_.where_ IS NULL ) THEN
         global_rec_.where_ := name_ || ' = ' || bind_value_;
      ELSE
         global_rec_.where_ := global_rec_.where_ || ' AND ' || name_ || ' = ' ||bind_value_;
      END IF;
   END LOOP;
END Create_Where_Stmt___;


PROCEDURE Unpack_Check___ (
   attr_       IN VARCHAR2,
   global_rec_ IN OUT global_rec) 
IS
BEGIN
   global_rec_.operation_   := Client_SYS.Get_Item_Value('DM_OPERATION', attr_);
   global_rec_.owner_       := Client_SYS.Get_Item_Value('DM_TABLE_OWNER', attr_);
   global_rec_.table_name_  := Client_SYS.Get_Item_Value('DM_TABLE_NAME', attr_);
   global_rec_.db_link_     := Client_SYS.Get_Item_Value('DM_DB_LINK', attr_);
   global_rec_.date_format_ := NVL(Client_SYS.Get_Item_Value('DM_DATE_FORMAT', attr_), Client_SYS.date_format_);
   global_rec_.key_columns_ := ';'||REPLACE(REPLACE(REPLACE(Client_SYS.Get_Item_Value('DM_KEY_COLUMNS', attr_)
                               , ',', ';'), ' ', ';'), ';;', ';') || ';';
   Error_SYS.Check_Not_Null(lu_name_, 'DM_TABLE_NAME', global_rec_.table_name_);
   --   
   global_rec_.table_name_ := ltrim(rtrim(global_rec_.table_name_));
   IF ( global_rec_.owner_ IS NULL ) THEN
      global_rec_.owner_ := Fnd_Session_API.Get_App_Owner;
   END IF;
   IF ( nvl(global_rec_.operation_, 'UPDATE') IN ('UPDATE','DELETE') ) THEN
      Error_SYS.Check_Not_Null(lu_name_, 'DM_KEY_COLUMNS', global_rec_.key_columns_);
      Create_Where_Stmt___(attr_, global_rec_);
   END IF;  
   IF ( Fnd_Session_API.Get_App_Owner = UPPER(global_rec_.owner_) ) THEN
      IF ( upper(global_rec_.table_name_) = 'INTFACE_REPLICATION_LOG_TAB' ) THEN
         NULL;
      ELSIF ( instr(allowed_tables_,';'||substr(global_rec_.table_name_,1,3)||';') != 0  ) THEN
         NULL;
      ELSE
         Error_SYS.Appl_General(lu_name_, ' TABERR: Cannot update :P2.:P1 ', global_rec_.table_name_, global_rec_.owner_);
      END IF;
   END IF;
END Unpack_Check___;


PROCEDURE Build_Column_Info___ (
   attr_       IN VARCHAR2,
   global_rec_ IN OUT global_rec) 
IS
   ptr_        NUMBER;
   name_       VARCHAR2(2000);
   value_      VARCHAR2(2000);
   bind_value_ VARCHAR2(2000);
   nocolumns_  EXCEPTION;
BEGIN
   ptr_ := NULL;
   global_rec_.column_values_ := NULL;
   global_rec_.column_names_ := NULL;
   WHILE (Client_SYS.Get_Next_From_Attr(attr_, ptr_, name_, value_)) LOOP
      IF (instr(allowed_params_,';'||name_||';') != 0 ) THEN
         NULL;
      ELSE
         bind_value_ := Get_Bind_Value___(name_, global_rec_);
         IF ( global_rec_.operation_ = 'INSERT' ) THEN
            global_rec_.column_names_  := global_rec_.column_names_ || ', ' || name_;
            global_rec_.column_values_ := global_rec_.column_values_ || ',' ||bind_value_;  
         ELSIF ( global_rec_.operation_ = 'UPDATE' AND instr(global_rec_.key_columns_, ';'||name_||';') = 0 ) THEN
            global_rec_.column_values_ := global_rec_.column_values_ || ', ' || name_ || ' = ' ||bind_value_;
         END IF;
         global_rec_.column_names_ := ltrim(global_rec_.column_names_,',');
         global_rec_.column_values_ := ltrim(global_rec_.column_values_,',');
      END IF;
   END LOOP;
--   IF ( operation_ = 'UPDATE' AND column_names_ IS NULL ) THEN
--      RAISE nocolumns_;
--   END IF;
EXCEPTION
   WHEN nocolumns_ THEN
      Error_SYS.Appl_General(lu_name_, ' NOCOL: No columns to update');
END Build_Column_Info___;


PROCEDURE Build_Insert___ (
   attr_       IN VARCHAR2,
   global_rec_ IN OUT global_rec)
IS
BEGIN
   global_rec_.stmt_ := ' BEGIN INSERT INTO ' || global_rec_.owner_ || '.' || global_rec_.table_name_;
   Add_Db_Link___(global_rec_);
   Build_Column_Info___(attr_, global_rec_);
   global_rec_.stmt_ := global_rec_.stmt_ || ' (' || global_rec_.column_names_ || ') VALUES(' || global_rec_.column_values_ || ')' || '; END;';
END Build_Insert___;


PROCEDURE Build_Update___ (
   attr_       IN VARCHAR2,
   global_rec_ IN OUT global_rec)
IS
BEGIN
   global_rec_.stmt_ := 'BEGIN UPDATE ' || global_rec_.owner_ || '.' || global_rec_.table_name_;
   Add_Db_Link___(global_rec_);
   Build_Column_Info___(attr_, global_rec_);
   global_rec_.stmt_ := global_rec_.stmt_ || ' SET ' || global_rec_.column_values_ || ' WHERE ' || global_rec_.where_ || '; END;'; 
END Build_Update___;


PROCEDURE Build_Delete___ (
   attr_       IN VARCHAR2,
   global_rec_ IN OUT global_rec)
IS
BEGIN
   global_rec_.stmt_ := 'BEGIN DELETE FROM ' || global_rec_.owner_ || '.' || global_rec_.table_name_;
   Add_Db_Link___(global_rec_);
   global_rec_.stmt_ := global_rec_.stmt_ || ' WHERE ' || global_rec_.where_ || '; END;';
END Build_Delete___;


FUNCTION Execute_Stmt___ (
   err_msg_    IN OUT VARCHAR2,
   attr_       IN VARCHAR2,
   global_rec_ IN OUT global_rec) RETURN BOOLEAN
IS
   h_cur_ INTEGER;
   dummy_ NUMBER;   
   ptr_   NUMBER;
   name_  VARCHAR2(2000);
   value_ VARCHAR2(2000);
   is_ok_ BOOLEAN := FALSE;
BEGIN
   h_cur_ := DBMS_SQL.Open_Cursor;
   ptr_ := NULL;
   @ApproveDynamicStatement(2011-05-19,jhmase)
   DBMS_SQL.Parse(h_cur_, global_rec_.stmt_, DBMS_SQL.native);
   IF ( global_rec_.operation_ = 'DELETE' ) THEN
      WHILE Get_Next_Key_Name___(global_rec_.key_columns_, ptr_, name_)  LOOP
         value_ := Client_SYS.Get_Item_Value(name_,attr_);
         DBMS_SQL.bind_variable(h_cur_,name_, value_, 2000);
      END LOOP;
   ELSE
      WHILE (Client_SYS.Get_Next_From_Attr(attr_, ptr_, name_, value_) ) LOOP
         IF (instr(allowed_params_,';'||name_||';') != 0 ) THEN
            NULL;
         ELSE
            DBMS_SQL.bind_variable(h_cur_,name_, value_, 2000);
         END IF;
      END LOOP;
   END IF;
   dummy_ := DBMS_SQL.Execute(h_cur_);
   DBMS_SQL.Close_Cursor(h_cur_);
   is_ok_ := TRUE;
   RETURN is_ok_;
EXCEPTION
   WHEN OTHERS THEN
      err_msg_ := SQLERRM;
      DBMS_SQL.Close_Cursor(h_cur_);
      RETURN is_ok_;
END Execute_Stmt___;


PROCEDURE Start_Processing___ (
   attr_       IN VARCHAR2,
   action_     IN VARCHAR2,
   global_rec_ IN OUT global_rec) 
IS
   error_message_ VARCHAR2(2000);
   proc_error_    EXCEPTION;
BEGIN
   IF ( global_rec_.operation_ IS NOT NULL ) THEN   
      IF ( action_ = 'DO') THEN
         IF NOT ( Execute_Stmt___( error_message_, attr_, global_rec_) ) THEN
            RAISE proc_error_;
         END IF;
      END IF;
   ELSIF ( action_ = 'DO') THEN
      -- Operation has not been specified,
      -- Try insert first, if EXCEPTION try update
      global_rec_.operation_ := 'INSERT';
      Build_Insert___(attr_, global_rec_);
      IF NOT ( Execute_Stmt___( error_message_, attr_, global_rec_) ) THEN
         global_rec_.operation_ := 'UPDATE';
         Build_Update___(attr_, global_rec_);
         IF NOT ( Execute_Stmt___( error_message_, attr_, global_rec_) ) THEN
            RAISE proc_error_;
         END IF;
      END IF;
   END IF;
   IF ( action_ != 'DO' ) THEN 
      Display_Stmt___(global_rec_.stmt_);
   END IF;
EXCEPTION
   WHEN proc_error_ THEN
      Error_SYS.Appl_General(lu_name_, ' PROCERR: Error :P1 ', error_message_);
END Start_Processing___;


-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------

-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------

PROCEDURE Process_Table (
   attr_       IN OUT VARCHAR2,
   action_     IN VARCHAR2 DEFAULT 'DO' )
IS
   global_rec_ global_rec;
BEGIN
   Unpack_Check___(attr_, global_rec_);
   IF ( global_rec_.operation_ = 'INSERT' ) THEN
      Build_Insert___(attr_, global_rec_);
   ELSIF ( global_rec_.operation_ = 'UPDATE' ) THEN 
      Build_Update___(attr_, global_rec_);
   ELSIF ( global_rec_.operation_ = 'DELETE' ) THEN 
      Build_Delete___(attr_, global_rec_);
   END IF;
   Display_Stmt___(global_rec_.stmt_);
   Start_Processing___(attr_, action_, global_rec_);
END Process_Table;



