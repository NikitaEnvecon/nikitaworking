-----------------------------------------------------------------------------
--
--  Logical unit: IntfaceExecutionUtil
--  Component:    FNDMIG
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------

TYPE intfdet_tab_type IS
   TABLE OF intface_detail_tab%ROWTYPE INDEX BY BINARY_INTEGER;
TYPE number_tabtype IS
   TABLE OF NUMBER
   INDEX BY BINARY_INTEGER;
TYPE attr_tabtype IS
   TABLE OF VARCHAR2(32000)
   INDEX BY BINARY_INTEGER;
TYPE varchar_tabtype IS
   TABLE OF VARCHAR2(2000)
   INDEX BY BINARY_INTEGER;
TYPE integer_tabtype IS
   TABLE OF INTEGER
   INDEX BY BINARY_INTEGER;
TYPE date_tabtype IS
   TABLE OF DATE
   INDEX BY BINARY_INTEGER;
TYPE boolean_tabtype IS
   TABLE OF BOOLEAN
   INDEX BY BINARY_INTEGER;
TYPE dynamic_record IS RECORD(
   method           varchar_tabtype,
   execute_seq      number_tabtype,
   error_count      number_tabtype,
   incomplete_count number_tabtype,
   commit_count     number_tabtype,
   last_row         number_tabtype,
   view_name        varchar_tabtype,
   orig_view_name   varchar_tabtype,
   attr             attr_tabtype,
   arg_attr         attr_tabtype,
   return_attr      attr_tabtype,
   column_name      varchar_tabtype,
   column_value     varchar_tabtype,
   on_new_master    varchar_tabtype,
   on_first_row     varchar_tabtype,
   method_mode      varchar_tabtype,
   reference        varchar_tabtype,
   repl_key         varchar_tabtype,
   upd_cur          integer_tabtype,
   h_cur            integer_tabtype);
TYPE result_record IS RECORD(
   activity         varchar_tabtype,
   line_no          number_tabtype,
   inserted_count   number_tabtype, -- LU Insert__
   updated_count    number_tabtype, -- LU Modify__
   skipped_count    number_tabtype, -- OTHER method validation skipped
   executed_count   number_tabtype);-- OTHER methods executed 

msg_sep_            CONSTANT VARCHAR2(2) := chr(13)||chr(10); 

-------------------- PRIVATE DECLARATIONS -----------------------------------


-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------

PROCEDURE String_To_Attr___ (
   attr_              IN OUT VARCHAR2,
   file_string_       IN     VARCHAR2,
   intf_format_error_ IN OUT VARCHAR2,
   int_dtail_tab_     IN     intfdet_tab_type,
   intface_name_      IN     VARCHAR2 )
IS
   trim_string_  VARCHAR2(32000);
BEGIN
   intf_format_error_ := NULL;
   -- Strip off Carriage Return at end of file
   trim_string_ := rtrim(file_string_,chr(13));

   Unpack_String_By_Separator___( attr_, trim_string_, intf_format_error_, int_dtail_tab_, intface_name_);

END String_To_Attr___;


PROCEDURE Unpack_String_By_Separator___ (
   attr_              IN OUT VARCHAR2,
   file_string_       IN     VARCHAR2,
   intf_format_error_ IN OUT VARCHAR2,
   intfdet_rec_       IN     intfdet_tab_type,
   intface_name_      IN     VARCHAR2 )
IS
   --
   column_name_        INTFACE_DETAIL.column_name%TYPE;
   data_type_          INTFACE_DETAIL.data_type%TYPE;
   pos_                INTFACE_DETAIL.pos%TYPE;
   length_             INTFACE_DETAIL.length%TYPE;
   pad_char_left_      INTFACE_DETAIL_TAB.pad_char_left%TYPE;
   pad_char_right_     INTFACE_DETAIL_TAB.pad_char_right%TYPE;
   decimal_point_      intface_header_tab.decimal_point%TYPE;
   column_separator_   intface_header_tab.column_separator%TYPE;
   thousand_separator_ intface_header_tab.thousand_separator%TYPE;
   column_embrace_     intface_header_tab.column_embrace%TYPE;
   amount_factor_      INTFACE_DETAIL.amount_factor%TYPE;
   decimal_length_     INTFACE_DETAIL.decimal_length%TYPE;
   minus_pos_          intface_header.minus_pos%TYPE;
   default_value_      INTFACE_DETAIL.default_value%TYPE;
   flags_              INTFACE_DETAIL.flags%TYPE;
   conv_list_id_       INTFACE_DETAIL.conv_list_id%TYPE;
   --
   convert_value_ VARCHAR2(2000);
   column_value_  VARCHAR2(2000);
   string_value_  VARCHAR2(2000);
   number_value_  NUMBER;
   date_value_    DATE;
   --
   from_          NUMBER;
   ptr_           NUMBER;
   -- New split of string
   TYPE field_tab_type IS
      TABLE OF VARCHAR2(2000) INDEX BY BINARY_INTEGER;
   fields_rec_    field_tab_type;
   fields_count_  INTEGER;
   field_         VARCHAR2(2000);
   curr_char_     VARCHAR2(10);
   text_on_       BOOLEAN;
   sep_error_     EXCEPTION;
   default_error_ EXCEPTION;
   convert_error_ EXCEPTION;
   number_error_  EXCEPTION;
   date_error_    EXCEPTION;
   string_error_  EXCEPTION;
   length_error_  EXCEPTION;
   error_message_ VARCHAR2(2000);
   continue_      BOOLEAN;
   pos_seq_       NUMBER;
   sort_attr_     VARCHAR2(32000);
   counter_       NUMBER;

   intf_insert_update_ VARCHAR2(30) := 'INSERT';
   sorted_rec_nbr_     NUMBER := 0;
   date_format_        VARCHAR2(30) := Client_SYS.Date_Format_;
   intfsort_rec_       intfdet_tab_type;

   CURSOR get_columns_sorted IS
      SELECT source_column
      FROM   intface_detail_tab
      WHERE intface_name    = intface_name_
      AND   (pos > 0 OR default_value IS NOT NULL)
      ORDER BY attr_seq;
BEGIN

   decimal_point_      := NVL(Intface_Format_Char_API.Get_Char(Intface_Header_API.Get_Decimal_Point(intface_name_)), '.');
   thousand_separator_ := NVL(Intface_Format_Char_API.Get_Char(Intface_Header_API.Get_Thousand_Separator(intface_name_)),',');
   column_separator_   := Intface_Format_Char_API.Get_Char(Intface_Header_API.Get_Column_Separator(intface_name_));
   minus_pos_          := Intface_Header_APi.Get_Minus_Pos(intface_name_);
   column_embrace_     := Intface_Format_Char_API.Get_Char(Intface_Header_API.Get_Column_Embrace(intface_name_));
   -- Split line from file into fields, based on column_separator
   field_ := NULL;
   text_on_ := FALSE;
   fields_count_ := 0;
   counter_ := 0;

   FOR intface_sorted_rec_ IN get_columns_sorted LOOP
      sorted_rec_nbr_ := sorted_rec_nbr_ + 1;
      intfsort_rec_(sorted_rec_nbr_).column_name := intface_sorted_rec_.source_column;
   END LOOP;
   --
   BEGIN
      FOR i_ IN 1..LENGTH(file_string_) LOOP
         curr_char_ := SUBSTR(file_string_, i_, 1);
         --
         -- Handle enclose character
         IF (curr_char_ = column_embrace_) THEN
            counter_ := counter_ + 1;
            -- Turn on text
            IF (NOT text_on_) THEN
               text_on_ := TRUE;
               field_ := NULL; -- Empty string if spaces etc. before text start
            ELSIF (SUBSTR(file_string_, i_ + 1, 1) = column_separator_) THEN
               IF (SUBSTR(file_string_, i_ - 2, 1) = column_embrace_) AND (SUBSTR(file_string_, i_ - 1, 1) = column_embrace_)  THEN
                  -- Handle end of a string
                  -- Turn off text
                  IF MOD(counter_, 2) = 1 THEN
                     text_on_ := TRUE;
                  ELSE
                     text_on_ := FALSE;
                  END IF; 
               ELSIF (SUBSTR(file_string_, i_ - 1, 1) = column_embrace_) THEN
                  -- Handle inside a string
                  -- Keep Text on
                  text_on_ := TRUE;
               ELSE
                  -- Turn off text
                  text_on_ := FALSE;    
               END IF;
            ELSIF (i_ < LENGTH(file_string_)) AND (NOT(SUBSTR(file_string_, i_ - 1, 1) = column_embrace_)) AND (MOD(counter_, 2) = 0) THEN
               field_ := field_ || curr_char_;
            ELSIF (i_ < LENGTH(file_string_)) AND (SUBSTR(file_string_, i_ - 1, 1) = column_embrace_) AND (MOD(counter_, 2) = 0) THEN
               field_ := field_ || curr_char_;
            END IF;
         ELSIF (curr_char_ = column_separator_) THEN
            -- Handle field separator character
            IF (NOT text_on_) THEN
               -- New field ready
               fields_count_ := fields_count_ + 1;
               fields_rec_(fields_count_) := field_;
               field_ := NULL;
               text_on_ := FALSE;
               counter_ := 0;
            ELSE
               field_ := field_ || curr_char_;
            END IF;
         ELSE
            field_ := field_ || curr_char_;
         END IF;
      END LOOP;
   EXCEPTION
      WHEN OTHERS THEN
         RAISE sep_error_;
   END;
   --
   fields_count_ := fields_count_ + 1;
   fields_rec_(fields_count_) := field_;
   -- Reading global table
   from_ := 1;
   ptr_  := length(file_string_);

   FOR rec_nbr_ IN 1..intfdet_rec_.count LOOP
      --
      column_value_  := NULL;
      string_value_  := NULL;
      number_value_  := NULL;
      date_value_    := NULL;
      --
      pos_                := intfdet_rec_(rec_nbr_).pos;
      length_             := intfdet_rec_(rec_nbr_).length;
      column_name_        := intfdet_rec_(rec_nbr_).column_name;
      data_type_          := intfdet_rec_(rec_nbr_).data_type;
      pad_char_left_      := intfdet_rec_(rec_nbr_).pad_char_left;
      pad_char_right_     := intfdet_rec_(rec_nbr_).pad_char_right;
      amount_factor_      := intfdet_rec_(rec_nbr_).amount_factor;
      decimal_length_     := NULL; --intfdet_rec_(rec_nbr_).decimal_length;
      default_value_      := intfdet_rec_(rec_nbr_).default_value;
      flags_              := intfdet_rec_(rec_nbr_).flags;
      conv_list_id_       := intfdet_rec_(rec_nbr_).conv_list_id;
      --
      IF ( pos_ > 0 ) THEN
         pos_seq_ := nvl(pos_seq_,0) +1;         -- Pos_seq to make sure we have
         IF ( pos_seq_ <= fields_count_) THEN
            column_value_ := fields_rec_(pos_seq_); -- same sequence as in fields_rec.
         ELSE
            length_ := -1 ; -- This column does not occur on the file string
         END IF;
      END IF;
      --
      IF ( intf_insert_update_ = 'INSERT' AND flags_ IN ('U','MU') ) THEN
       --   Flags indicates that this column should not be inserted
         continue_ := FALSE;
      ELSE
         continue_ := TRUE;
      END IF;
      --
      IF ( nvl(length_, 0) =  -1 ) THEN
         -- This column had no value on file, check if default value IS NULL
         --
         IF (default_value_ IS NOT NULL) THEN
            BEGIN
               column_value_ := nvl(ltrim(column_value_), Intface_Detail_API.Format_Default_Value_(default_value_, data_type_, date_format_));
            EXCEPTION
               WHEN OTHERS THEN
                  RAISE default_error_;
            END;
            length_ := intfdet_rec_(rec_nbr_).length; -- Reset correct length
         END IF;
      END IF;
      --
      -- If length equals zero, do nothing; this field should not be loaded.
      -- If continue_ is FALSE, do nothing.
      --
      IF ( ( nvl(length_, 0) > 0) AND continue_ ) THEN
         --
         -- Add default value if column_value_ IS NULL
         --
         IF (default_value_ IS NOT NULL) THEN
            BEGIN
               IF (column_value_ IS NOT NULL) THEN
                  column_value_ := nvl(ltrim(column_value_), Intface_Detail_API.Format_Default_Value_(default_value_, data_type_, date_format_));
               ELSE
                  column_value_  := NULL;
               END IF;  
            EXCEPTION
               WHEN OTHERS THEN
                  RAISE default_error_;
            END;
         END IF;
         -- First trim off characters if specified
         IF (pad_char_left_ IS NOT NULL) THEN
            column_value_ := ltrim(column_value_, pad_char_left_);
         END IF;
         IF (pad_char_right_ IS NOT NULL) THEN
            column_value_ := rtrim(column_value_, pad_char_right_);
         END IF;
         IF ( conv_list_id_ IS NOT NULL ) THEN
            -- Convert values for this column
            convert_value_ := NULL;
            --
            BEGIN
               convert_value_ := Intface_Conv_List_Cols_API.Get_New_Value(conv_list_id_ , column_value_ );
               column_value_ := nvl(convert_value_, column_value_);
            EXCEPTION
               WHEN OTHERS THEN
                  RAISE convert_error_;
            END;
         END IF;
         --
         IF (ltrim(column_value_) IS NOT NULL ) THEN
            IF ( column_value_ = 'NULLVALUE' ) THEN
              Client_Sys.Add_To_Attr(column_name_, '' , attr_);
            ELSIF ( data_type_ = 'NUMBER' ) THEN
               BEGIN
                  number_value_ := Intface_Detail_API.Format_Number_In_(column_value_, decimal_point_,
                  thousand_separator_, amount_factor_, decimal_length_, minus_pos_);
               EXCEPTION
                  WHEN OTHERS THEN
                     RAISE number_error_;
               END;
               Client_Sys.Add_To_Attr(column_name_, number_value_, attr_);
            ELSIF ( data_type_ = 'DATE' ) THEN
               BEGIN
                  date_value_ := Intface_Detail_API.Format_Date_In_(column_value_, date_format_);
               EXCEPTION
                  WHEN OTHERS THEN
                     RAISE date_error_;
               END;
               Client_Sys.Add_To_Attr(column_name_, date_value_, attr_);
            ELSE
            IF ( length(column_value_) > length_ ) THEN
               IF ( App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_trunc_value_cid_) ) THEN
                  -- Only read the length specified for column.
                  -- Rule for truncation is active
                  column_value_ := substr(column_value_,1,length_);
               ELSE
                  RAISE length_error_;
               END IF;
            END IF;
               BEGIN
                  string_value_ := Intface_Detail_API.Format_String_In_(intface_name_,column_value_);
                  Client_Sys.Add_To_Attr(column_name_, string_value_, attr_);
               EXCEPTION
                  WHEN OTHERS THEN
                     RAISE string_error_;
               END;
            END IF;
         ELSE
            Client_Sys.Add_To_Attr(column_name_, '' , attr_);
         END IF;
      END IF;
   END LOOP;
   Client_SYS.Clear_Attr(sort_attr_); -- Sort attr-string
   FOR rec_nbr_ IN 1..intfsort_rec_.count LOOP
      Intface_Detail_API.From_Attr_To_Attr(sort_attr_, attr_, intfsort_rec_(rec_nbr_).column_name);
   END LOOP;
   attr_ := sort_attr_;
   --
EXCEPTION
   WHEN sep_error_ THEN
      error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
         'UNPACKSEPSEP: Error reading column values by column separator',
         Fnd_Session_API.Get_Language);
      intf_format_error_ := error_message_;
   WHEN default_error_ THEN
      error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
         'UNPACKSEPDEF: Error formatting default value :P2 for :P1',
         Fnd_Session_API.Get_Language, column_name_, default_value_);
      intf_format_error_ := error_message_;
   WHEN convert_error_ THEN
      error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
         'UNPACKSEPCONV: Error converting value :P2 for :P1',
         Fnd_Session_API.Get_Language, column_name_, default_value_);
      intf_format_error_ := error_message_;
   WHEN number_error_ THEN
      error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
         'UNPACKSEPNUM: Error formatting numeric value :P2 for :P1',
         Fnd_Session_API.Get_Language, column_name_, column_value_);
      intf_format_error_ := error_message_;
   WHEN date_error_ THEN
      error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
         'UNPACKSEPDAT: Error formatting date value :P2 for :P1',
         Fnd_Session_API.Get_Language, column_name_, column_value_);
      intf_format_error_ := error_message_;
   WHEN string_error_ THEN
      error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
         'UNPACKSEPSTR: Error formatting string value :P2 for :P1',
         Fnd_Session_API.Get_Language, column_name_, column_value_);
      intf_format_error_ := error_message_;
   WHEN length_error_ THEN
      error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
         'TOOLONG: Specified length :P2 for column :P1 is exceeded by value :P3.',
         Fnd_Session_API.Get_Language, column_name_, length_, column_value_);
      intf_format_error_ := error_message_;
   WHEN OTHERS THEN
      error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
         'UNPACKSEP: Error occured while unpacking :P1 with value :P2',
         Fnd_Session_API.Get_Language, column_name_, column_value_);
      intf_format_error_ := error_message_;
END Unpack_String_By_Separator___;


PROCEDURE Migrate_Source_Data___ (
   info_          IN OUT VARCHAR2,
   activity_      IN     VARCHAR2,
   intface_name_  IN     VARCHAR2,
   ic_table_name_ IN     VARCHAR2,
   execution_id_  IN     NUMBER )
IS
   dyna_count_         NUMBER := 0;
   dyna_rec_           dynamic_record;

   source_name_        intface_header.source_name%TYPE;
   source_owner_       intface_header.source_owner%TYPE;
   source_rowid_       rowid;
   count_              NUMBER := 0;
   cols_               VARCHAR2(32000);
   cols_value_         intface_detail.default_value%TYPE;
   stmt_               VARCHAR2(32000);
   dyna_stmt_          VARCHAR2(2000);
   upd_stmt_           VARCHAR2(2000);
   where_              VARCHAR2(32000);
   order_by_           VARCHAR2(2000);
   group_by_           VARCHAR2(2000);
   h_cur_              INTEGER;
   dummy_              NUMBER;
   attr_               VARCHAR2(32000);
   column_value_       VARCHAR2(2000);
   convert_value_      VARCHAR2(2000);
   column_name_        intface_detail.column_name%TYPE;
   conv_list_id_       intface_detail.conv_list_id%TYPE;
   row_count_          NUMBER := 0;
   commit_count_       NUMBER := 0;
   commit_seq_         NUMBER := 0;
   commit_seq_cnt_     NUMBER := 0;
   error_count_        NUMBER := 0;
   check_count_        NUMBER := 0;
   rowid_count_        NUMBER;
   dyna_attr_          VARCHAR2(32000);
   w_attr_             VARCHAR2(32000);
   objid_              VARCHAR2(2000);
   objversion_         VARCHAR2(2000);
   action_             VARCHAR2(10) := 'DO';
   date_format_start_  VARCHAR2(30) := 'to_char(';
   date_format_end_    VARCHAR2(100) := ','||''''||'YYYY-MM-DD-HH24.MI.SS'||''''||')';
   date_format_        VARCHAR2(30) := Client_SYS.Date_Format_;
   rowid_name_         VARCHAR2(30);
   start_time_         VARCHAR2(50) := to_char(sysdate,'DD-MON-YYYY HH24:MI:SS');
   message_start_      VARCHAR2(32000) := NULL;
   message_before_     VARCHAR2(32000) := NULL;
   message_select_     VARCHAR2(32000) := NULL;
   message_method_     VARCHAR2(32000) := NULL;
   all_methods_        VARCHAR2(32000) := NULL;
   method_result_      VARCHAR2(2000) := NULL;
   message_after_      VARCHAR2(32000) := NULL;
   header_message_     VARCHAR2(2000);
   execute_method_     BOOLEAN;
   start_ok_           BOOLEAN;
   execution_no_       NUMBER;
   incomplete_select_  EXCEPTION;
   method_error_       EXCEPTION;
   method_error_after_ EXCEPTION;
   no_restart_         EXCEPTION;
   no_execute_         EXCEPTION;
   no_start_           EXCEPTION;
   no_conn_start_      EXCEPTION;
   old_seq_            NUMBER;
   show_method_        VARCHAR2(100);
   add_objid_          BOOLEAN;
   rule_string_        intface_rules.rule_value%TYPE;
   method_upd_isopen_  BOOLEAN := FALSE;
   method_h_isopen_    BOOLEAN := FALSE;
   parse_intface_name_ intface_header_tab.intface_name%TYPE;
   parse_info_         VARCHAR2(2000);
   parse_attr_         VARCHAR2(2000);
   ref_attr_           VARCHAR2(2000);
   ref_value_          VARCHAR2(2000);
   dyna_view_          INTFACE_METHOD_LIST.view_name%TYPE;
   exec_seq_           VARCHAR2(10);
   method_raised_      NUMBER;
   -- To be used when inserting master/detail rows.
   new_master_         BOOLEAN := TRUE;
   first_row_          BOOLEAN := FALSE;
   master_key_value_   VARCHAR2(32000);
   old_master_value_   VARCHAR2(32000);
   -- Variables to check if methods before, in or after loop fails.
   -- To be used when intf_execution_ok_ is given value at end of procedure
   methods_before_ok_  BOOLEAN := TRUE;
   methods_in_ok_      BOOLEAN := TRUE;
   methods_after_ok_   BOOLEAN := TRUE;
   -- Variables used to check if methods New/Modify have
   -- been defined in pairs(after each other) in MethodList.
   -- That affects the execution.
   second_method_      BOOLEAN;
   --
   i_                  NUMBER := 0;
   value_list_         VARCHAR2(2000) := 'NO REPLICATION;';
   repl_destination_   VARCHAR2(20);
   convert_attr_       VARCHAR2(32000);
   arg_attr_           VARCHAR2(32000);
   return_attr_        VARCHAR2(32000);
   start_              DATE;
   row_err_count_      NUMBER := 0;
   log_seq_count_      NUMBER;
   log_seq_            NUMBER;
   cur_log_seq_        NUMBER;
   replication_        BOOLEAN := FALSE;
   repl_criteria_      intface_header_tab.repl_criteria%TYPE  := 'XX';
   repl_mode_          intface_header_tab.replication_mode%TYPE := 'XX';
   -- Variables to check how methods did execute
   incomplete_trans_   BOOLEAN := FALSE;
   method_executed_    BOOLEAN;
   incomplete_result_  VARCHAR2(2000) := NULL;
   error_result_       VARCHAR2(2000) := NULL;
   old_exe_seq_        NUMBER := 0;
   conn_job1_          VARCHAR2(30);
   use_nullvalue_      VARCHAR2(30) := 'NULLVALUE';
   dummy_proc_         VARCHAR2(100);
   source_specified_   BOOLEAN := TRUE;
   -- removed globals and added following variables
   intf_skip_lines_    NUMBER;
   intf_exit_lines_    NUMBER;
   intf_ignorexeerror_ BOOLEAN;
   intf_commit_seq_    NUMBER;
   rule_number_        NUMBER;
   --
   row_num_count_      NUMBER := 1;
   row_action_         VARCHAR2(100);
   result_rec_         result_record; 
   cols_value_sub_     VARCHAR2(32000);
   cols_sub_           VARCHAR2(32000);
   --
   const_insert_       CONSTANT VARCHAR2(10) := 'insert';
   const_update_       CONSTANT VARCHAR2(10) := 'update';
   const_error_        CONSTANT VARCHAR2(10) := 'error';
   const_execute_      CONSTANT VARCHAR2(10) := 'executed';
   const_no_op_        CONSTANT VARCHAR2(10) := 'none';
   const_no_obj_       CONSTANT VARCHAR2(10) := 'notexist';
   --
   -- Get methods to be executed
   CURSOR get_max_log_seq IS
      SELECT NVL(MAX(log_seq),0)
      FROM intface_replication_log_tab
      WHERE intface_name = intface_name_;
   --
   CURSOR get_min_log_seq IS
      SELECT NVL(MIN(log_seq),0)
      FROM intface_replication_log_tab
      WHERE intface_name = intface_name_
      AND repl_rowid = App_Context_SYS.Find_Value(Intface_Job_Detail_API.intf_repl_rowid_context_id_);
   --
   -- Get methods to be executed for one action value
   CURSOR Get_Method_List (action_ IN VARCHAR2 ) IS
      SELECT
         intface_name, execute_seq, view_name,
         method_name,
         decode(instr(column_name,'@'),
            '0','#'||Intface_Detail_API.Get_Pos(intface_name,column_name), -- Find pos and prefix with hash
            column_name) column_name,
         column_value, convert_attr, references,
         source_name, note_text, prefix_option, action, rowversion,
         on_modify,
         on_new,
         IntFace_Method_List_API.Get_Method_Type(method_name) method_type,
         nvl(on_new_master,'FALSE') on_new_master,
         nvl(on_first_row,'FALSE') on_first_row
      FROM intface_method_list_tab
      WHERE intface_name = intface_name_
      AND action = action_
      ORDER BY execute_seq;
   --
   CURSOR Get_Columns IS
      SELECT *
      FROM Intface_detail_tab
      WHERE intface_name = intface_name_
      AND ( source_column IS NOT NULL OR default_value IS NOT NULL)
      ORDER BY pos,attr_seq;
   --
   CURSOR check_proc IS
      SELECT object_name, execute_seq, status
      FROM all_objects, intface_method_list
      WHERE object_name(+) = Intface_Method_list_api.Get_Dynamic_Proc_Name(intface_name, execute_seq)
      AND object_type(+) = 'PROCEDURE'
      AND owner(+) = Fnd_Session_API.get_app_owner
      AND intface_name = intface_name_
      AND instr(method_name,'.') != 0;
   --
   -- Record definitions
   stack_     Intface_detail_API.varchar_tabtype;
   rec_       Intface_Detail_API.intdet_record;
   --
   PROCEDURE Get_Method_List_Attrib__ (
      ref_attr_      IN OUT VARCHAR2,
      convert_attr_  IN OUT VARCHAR2,
      arg_attr_      IN OUT VARCHAR2,
      repl_criteria_ IN VARCHAR2,
      method_type_   IN VARCHAR2,
      seq_           IN NUMBER )
   IS
      CURSOR get_data IS
         SELECT *
         FROM intface_method_list_attrib_tab
         WHERE intface_name = intface_name_
         AND   execute_seq = seq_
         AND   fixed_value IS NOT NULL -- Items marked from Map_Attributes_To_Pos
         ORDER BY column_sequence;
   BEGIN
      Trace_SYS.Message('REPL_CRITERIA : '||repl_criteria_);
      FOR crec_ IN get_data LOOP
         IF ( crec_.flags = 'ARG' ) THEN
               client_sys.add_to_attr(crec_.column_name, crec_.fixed_value, arg_attr_);
         END IF;
         IF ( method_type_ = 'NEW' ) THEN
            IF ( crec_.on_new = 'TRUE' OR crec_.flags in ('P','K') ) THEN
               client_sys.add_to_attr(crec_.column_name, crec_.fixed_value, convert_attr_);
            END IF;
         ELSIF ( method_type_ = 'MODIFY' ) THEN
            IF ( crec_.on_modify = 'TRUE' ) THEN
            client_sys.add_to_attr(crec_.column_name, crec_.fixed_value, convert_attr_);
            END IF;
            IF ( crec_.flags IN ('P','K') ) THEN
               client_sys.add_to_attr(crec_.column_name, crec_.fixed_value, ref_attr_);
         END IF;
         ELSIF ( method_type_ = 'OTHER' ) THEN
            IF ( crec_.flags IN ('P','K') ) THEN
               client_sys.add_to_attr(crec_.column_name, crec_.fixed_value, ref_attr_);
            ELSIF ( crec_.flags != 'ARG' ) THEN
               client_sys.add_to_attr(crec_.column_name, crec_.fixed_value, convert_attr_);
            END IF;
         END IF;
         IF ( ( repl_criteria_ = '1' AND crec_.column_name IN ( 'CONTRACT','CONTRACT_ID','CONTRACT_NO','SITE','CONTRACT_') ) OR
              ( repl_criteria_ = '2' AND crec_.column_name IN ( 'COMPANY','COMPANY_ID','COMPANY_NO','COMPANY_KEY','COMPANY_'))    ) THEN
            IF ( repl_destination_ IS NOT NULL ) THEN
               IF ( crec_.flags IN ('P','K') ) THEN
                  IF ( method_type_ = 'NEW') THEN
                     Client_SYS.Set_Item_Value(crec_.column_name, repl_destination_, convert_attr_);
                  ELSIF ( method_type_ = 'MODIFY' ) THEN
                     Client_SYS.Set_Item_Value(crec_.column_name, repl_destination_, ref_attr_);
                  END IF;
               ELSIF ( crec_.flags = 'ARG' ) THEN
                  Client_SYS.Set_Item_Value(crec_.column_name, repl_destination_, arg_attr_);
               END IF;
            END IF;
         END IF;
      END LOOP;
      --
      -- Make sure there are values in attr-strings
      ref_attr_ := nvl(ref_attr_,'EMPTY');
      arg_attr_ := nvl(arg_attr_,'EMPTY');
      convert_attr_ := nvl(convert_attr_,'EMPTY');
      -- Display them
      Intface_Detail_API.Trace_Long_Msg(method_type_||' ATTR : '||convert_attr_);
      Intface_Detail_API.Trace_Long_Msg('KEY ATTR : '||ref_attr_);
      Intface_Detail_API.Trace_Long_Msg('ARGUMENT ATTR : '||arg_attr_);
   END Get_Method_List_Attrib__;
   -- Made local procedure for closing all cursors after main loop is finished
   PROCEDURE Close_Cursors__ (cur_count_ IN NUMBER ) IS
   BEGIN
      IF ( h_cur_ != 0 ) THEN
         IF ( DBMS_SQL.Is_Open(h_cur_) ) THEN
            DBMS_SQL.Close_Cursor(h_cur_);
         END IF;
      END IF;
      FOR i IN 1..cur_count_ LOOP
         IF ( dyna_rec_.h_cur(i) !=0 ) THEN
            IF ( DBMS_SQL.Is_Open(dyna_rec_.h_cur(i)) ) THEN
               DBMS_SQL.Close_Cursor(dyna_rec_.h_cur(i));
            END IF;
         END IF;
         IF ( dyna_rec_.upd_cur(i) !=0 ) THEN
            IF ( DBMS_SQL.Is_Open(dyna_rec_.upd_cur(i))) THEN
               DBMS_SQL.Close_Cursor(dyna_rec_.upd_cur(i));
            END IF;
         END IF;
      END LOOP;
   EXCEPTION
      WHEN OTHERS THEN
        Trace_SYS.Message('CLOSE CURSORS FAILED '||SQLERRM);
   END Close_Cursors__;

   PROCEDURE Rebuild_Ref_Value___ (
      in_out_val_  IN OUT VARCHAR2,
      row_count_   IN     NUMBER,
      method_mode_ IN     VARCHAR2 )
   IS
      at_pos_       NUMBER;
      seq_          VARCHAR2(100);
      get_item_     VARCHAR2(100);
      ref_value1_    VARCHAR2(2000);
   BEGIN
      ref_value1_ := in_out_val_;
      at_pos_ := instr(ref_value1_,'@');
      seq_ := substr(ref_value1_,at_pos_ +1);
      in_out_val_ := NULL; -- Return NULL when IF-tests within LOOP fails
      FOR i IN 1..dyna_count_ LOOP

         -- For New__/Modify__ there will be two enties for each execute_seq.
         -- Ignore entries with empty return_attr
         IF ( seq_ = to_char(dyna_rec_.execute_seq(i)) AND dyna_rec_.return_attr(i) != 'EMPTY' ) THEN
            IF ( dyna_rec_.on_new_master(i) = 'TRUE' OR dyna_rec_.on_first_row(i) = 'TRUE' OR dyna_rec_.column_name(i) IS NOT NULL  ) THEN
               -- Condition defined for this method
               get_item_ := substr(ref_value1_,1,at_pos_ -1);
               in_out_val_ := Client_SYS.Get_Item_Value(get_item_, dyna_rec_.return_attr(i));
            ELSIF ( method_mode_ IN ('UPDATE','INSERT') AND dyna_rec_.method_mode(i) IN ('UPDATE','INSERT') ) THEN
               -- Method without conditions :
               -- new/modify methods must have match on row_count
               IF ( dyna_rec_.last_row(i) = row_count_ ) THEN
                  get_item_ := substr(ref_value1_,1,at_pos_ -1);
                  in_out_val_ := Client_SYS.Get_Item_Value(get_item_, dyna_rec_.return_attr(i));
               END IF;
            ELSE
               get_item_ := substr(ref_value1_,1,at_pos_ -1);
               in_out_val_ := Client_SYS.Get_Item_Value(get_item_, dyna_rec_.return_attr(i));
            END IF;
            EXIT;
         END IF;
      END LOOP;
   END Rebuild_Ref_Value___;

   PROCEDURE Get_Objid_From_Key_Values___ (
      objid_      IN OUT VARCHAR2,
      objversion_ IN OUT VARCHAR2,
      exec_meth_  IN OUT BOOLEAN,
      ref_attr_   IN OUT VARCHAR2,
      message_    IN OUT VARCHAR2,
      attr_       IN     VARCHAR2,
      row_count_  IN     NUMBER,
      meth_count_ IN     NUMBER,
      meth_mode_  IN     VARCHAR2 )
   IS
      ptr_        NUMBER;
      name_       intface_detail.column_name%TYPE;
      value_      VARCHAR2(32000);
      ref_value2_ VARCHAR2(32000);
      dummy2_      NUMBER;
      j_          NUMBER := 0;
      item_name_  VARCHAR2(200);
   BEGIN
      -- Get key-columns from attr stored in PL/Table stored attr
      WHILE (Client_SYS.Get_Next_From_Attr(dyna_rec_.reference(meth_count_), ptr_, name_, value_)) LOOP
         ref_value2_ := value_;
         IF ( instr(value_,'#') = 1 ) THEN      -- Mapped to pos
            IF ( instr(value_,';') = 0  ) THEN
               ref_value2_ := Client_SYS.Get_Item_Value(value_, attr_);
            ELSE
               value_ := value_||';'; -- To make instr work
               LOOP                   -- LOOP to find values from multiple values
                  IF j_ = 0 THEN
                     item_name_:= substr(value_,0,instr(value_,';',1,j_+1)-1);
                  ELSE
                     item_name_:= substr(value_,instr(value_,';',1,j_)+1,instr(value_,';',1,j_+1) -
                             instr(value_,';',1,j_)-1);
                  END IF;
                  EXIT WHEN item_name_ IS NULL;
                  ref_value2_ := Client_SYS.Get_Item_Value(item_name_, attr_);
                  EXIT WHEN ref_value2_ IS NOT NULL; -- Exit on first occurrence
                  j_ := j_ + 1;
               END LOOP;
            END IF;
         ELSIF ( instr(ref_value2_,'@') != 0  ) THEN
            -- Get values from a previous method
            Rebuild_Ref_Value___(ref_value2_, row_count_, meth_mode_);
         END IF;
         -- Send key-values to cursor
         Trace_SYS.Message('Send key-values to cursor : '||name_||'/'||ref_value2_);
         DBMS_SQL.bind_variable(dyna_rec_.upd_cur(meth_count_),name_,ref_value2_, 32000);
         -- Save values on ref-attr
         Client_SYS.Add_To_Attr( name_, ref_value2_, ref_attr_);
      END LOOP;
      BEGIN
         -- Execute select and get return-values
         dummy2_ := DBMS_SQL.Execute(dyna_rec_.upd_cur(meth_count_));
         DBMS_SQL.variable_value(dyna_rec_.upd_cur(meth_count_),'objid', objid_);
         DBMS_SQL.variable_value(dyna_rec_.upd_cur(meth_count_),'objversion', objversion_);
      EXCEPTION
         WHEN no_data_found THEN
            Trace_SYS.Message('Objid/objversion not found : '||SQLERRM);
            IF ( meth_mode_ = 'OTHER' ) THEN
               exec_meth_ := FALSE;
            END IF;
         WHEN OTHERS THEN
            message_ := SQLERRM;
            Trace_SYS.Message('Get objid/objversion failed : '||SQLERRM);
            IF ( meth_mode_ = 'OTHER' ) THEN
               exec_meth_ := FALSE;
            END IF;
      END;
   END Get_Objid_From_Key_Values___;

   PROCEDURE Rebuild_Attr_String___ (
      attr_         IN OUT VARCHAR2,
      source_attr_  IN     VARCHAR2,
      convert_attr_ IN     VARCHAR2,
      view_name_    IN     VARCHAR2,
      row_count_    IN     NUMBER,
      method_mode_  IN     VARCHAR2 )
   IS
      ptr_          NUMBER;
      name_         intface_detail.column_name%TYPE;
      value_        VARCHAR2(2000);
      source_value_ VARCHAR2(2000);
      k_            NUMBER := 0;
      item_name_    VARCHAR2(200);
   BEGIN
      ptr_ := NULL;
      Client_SYS.Clear_Attr(attr_);
      trace_sys.message('REBUILD method_attr for view '||view_name_||' :');
      Intface_Detail_API.Trace_Long_Msg(convert_attr_);
      WHILE (Client_SYS.Get_Next_From_Attr(convert_attr_, ptr_, name_, value_)) LOOP
         source_value_ := NULL;
         IF ( instr(value_,'#') = 1 ) THEN      -- Mapped to pos
            IF ( instr(value_,';') = 0  ) THEN
               source_value_ := Client_SYS.Get_Item_Value(value_, source_attr_);
            ELSE
               value_ := value_||';'; -- To make instr work
               LOOP                   -- LOOP to find values from multiple pos
                  IF k_ = 0 THEN
                     item_name_:= substr(value_,0,instr(value_,';',1,k_+1)-1);
                  ELSE
                     item_name_:= substr(value_,instr(value_,';',1,k_)+1,instr(value_,';',1,k_+1) -
                             instr(value_,';',1,k_)-1);
                  END IF;
                  EXIT WHEN item_name_ IS NULL;
                  source_value_ := Client_SYS.Get_Item_Value(item_name_, source_attr_);
                  EXIT WHEN source_value_ IS NOT NULL; -- Exit on first occurrence
                  k_ := k_ + 1;
               END LOOP;
            END IF;
         ELSE
            -- Value from convert_attr overrides
            source_value_ := value_;
            IF (instr(value_,'@') != 0 ) THEN
               Rebuild_Ref_Value___(source_value_, row_count_ , method_mode_);
            END IF;
         END IF;
         IF ( source_value_ IS NOT NULL ) THEN
            IF ( source_value_ = 'NULLVALUE' AND method_mode_ IN ( 'INSERT', 'ARGUMENTS' )  ) THEN
               NULL; -- Add no empty items on insert-attr and argument-attr
            ELSIF ( source_value_ = 'NULLVALUE' ) THEN
               Client_SYS.Add_To_Attr(name_, '', attr_);
            ELSE
               Client_SYS.Add_To_Attr(name_, source_value_, attr_);
            END IF;
         END IF;
      END LOOP;
      trace_sys.message('REBUILD OUT_attr : ');
      Intface_Detail_API.Trace_Long_Msg(attr_);
   END Rebuild_Attr_String___;
BEGIN
   Trace_SYS.Message(' TRACE >>>> Starting Source Migration.');
   -- Lookup relevant Rules
   -- This is used to do the validation from the add-in's Execute button.
   IF (activity_ = 'VALIDATE') THEN
      action_ := 'CHECK';
   END IF;

   IF ( Intface_Rules_API.Rule_Is_Active(
      rule_string_, 'NONULLVAL', intface_name_) ) THEN
      use_nullvalue_ := NULL;
   END IF;
   /*IF ( Intface_Header_API.Get_Procedure_Name(intface_name_) = 'REPLICATION') THEN
      replication_   := TRUE;
      repl_criteria_ := Intface_Replic_Criteria_API.Encode(Intface_Header_API.Get_Repl_Criteria(intface_name_)) ;
      repl_mode_     := Intface_Mode_API.Encode(Intface_Header_API.Get_Replication_Mode(intface_name_)) ;
      value_list_    := nvl(Intface_Header_API.Get_Value_List(intface_name_),'NO REPLICATION')||';';
   END IF;*/


   -- Added the below 4 rule checks to avoid global usage
   IF ( Intface_Rules_API.Rule_Is_Active(
           rule_number_, 'SKIPLINES', intface_name_) ) THEN
      intf_skip_lines_ := rule_number_;
   ELSE
      intf_skip_lines_ := 0;
   END IF;
   
   
   IF ( Intface_Rules_API.Rule_Is_Active(
           rule_number_, 'EXITLINES', intface_name_) ) THEN
      intf_exit_lines_ := rule_number_;
   ELSE
      intf_exit_lines_ := 99999999;
   END IF;


  /* IF ( Intface_Rules_API.Rule_Is_Active(
           rule_string_, 'IGNOREXEERROR', intface_name_) ) THEN
      intf_ignorexeerror_ := TRUE;
   ELSE
      intf_ignorexeerror_ := FALSE;
   END IF; */

   intf_ignorexeerror_ := TRUE;


   IF ( Intface_Rules_API.Rule_Is_Active(
           rule_number_, 'COMMITSEQ', intface_name_) ) THEN
      intf_commit_seq_ := rule_number_;
   ELSE
      intf_commit_seq_ := NULL;
   END IF;
   
   --Create procedures before SAVEPOINTS are defined
   IF ( Intface_Rules_API.Rule_Is_Active(
      dummy_proc_, 'KEEPDYNAMPROC', intface_name_) ) THEN
      FOR rec2_ IN check_proc LOOP
         -- Only create procedures that have not been created before,
         -- or if status is INVALID
         IF ( rec2_.status IS NULL ) THEN
            Intface_Method_List_API.Create_One_Dynamic_Proc( intface_name_, rec2_.execute_seq );
         ELSIF ( rec2_.status = 'INVALID' ) THEN
            stmt_ := 'ALTER PROCEDURE '||rec2_.object_name||' COMPILE';
            BEGIN
               @ApproveDynamicStatement(2012-05-07,jhmase)
               EXECUTE IMMEDIATE stmt_;
            EXCEPTION
               WHEN OTHERS THEN NULL; -- May be invalid still
            END;
         END IF;
      END LOOP;
   ELSE
      Intface_Method_List_API.Create_All_Dynamic_Procs( intface_name_ );
   END IF; 
   --
   @ApproveTransactionStatement(2014-02-18,chmulk)
   SAVEPOINT new_job_;
   --
   -- Update FIXED_VALUE in IntfaceMethodListAttrib temporarily
   -- to mark items that may have value on attr-string.
   -- See also Unmap_Attributes_To_Pos
   Intface_Method_List_API.Map_Attributes_To_Pos(intface_name_);
   --
   message_start_ := Language_SYS.Translate_Constant(lu_name_, ' TIMESTAMP1 : Start time - :P1   :P2', Fnd_Session_API.Get_Language, start_time_, intface_name_);
   source_name_   := ic_table_name_;
   source_owner_  := Intface_Header_API.Get_Source_Owner(intface_name_);
   IF ( source_name_ IS NULL ) THEN
      -- No source specified
      source_specified_ := FALSE;
   END IF;

   -- Lookup relevant Rule
   IF ( Intface_Rules_API.Rule_Is_Active(
           rule_string_, 'ADDOBJID', intface_name_) ) THEN
      add_objid_ := TRUE;
   ELSE
      add_objid_ := FALSE;
   END IF; 
   --
   @ApproveTransactionStatement(2014-02-18,chmulk)
   SAVEPOINT new_job_;

   IF ( source_owner_ IS NOT NULL ) THEN
      source_name_ := source_owner_||chr(46)||source_name_;
   END IF;
  
   start_ok_ := TRUE;

   -- Execute methods to be processed before main loop start.
   -- They have action=1
   IF (action_ = 'DO') THEN
      trace_sys.message('TRACE >>>>>>>>>>>>>>>>>>>>>>> EXECUTING JOBS BEFORE LOOP');
      FOR brec_ IN Get_Method_List('1') LOOP
         @ApproveTransactionStatement(2014-02-18,chmulk)
         SAVEPOINT new_method_;
         BEGIN
            header_message_ := Language_SYS.Translate_Constant(lu_name_, ' HEADMSG : EXECUTING METHOD NO. :P1 : ', Fnd_Session_API.Get_Language, to_char(brec_.execute_seq));
            IF ( message_before_ IS NULL ) THEN
               message_before_ := header_message_||msg_sep_||'       ';
            ELSE
               message_before_ := message_before_||msg_sep_||msg_sep_||header_message_||msg_sep_||'       ';
            END IF;
            Client_SYS.Clear_Attr(parse_attr_);
            Get_Method_List_Attrib__ ( ref_attr_, convert_attr_ ,parse_attr_,
                                      '0', 'BEFORE_LOOP', brec_.execute_seq );
               Intface_Detail_API.Trace_Long_Msg('Parse_Attr '||parse_attr_);
            IF ( instr(upper(brec_.method_name),'INTFACE_HEADER_API.START_JOB') != 0 ) THEN
               parse_intface_name_ := Client_SYS.Get_Item_Value('INTFACE_NAME_', parse_attr_);
               -- This starts another migration job
               IF ( parse_intface_name_ IS NULL ) THEN
                  message_before_ := message_before_||Language_SYS.Translate_Constant(lu_name_, ' NONAME : Value for Job ID is missing on attr-string for method no. :P1 ', Fnd_Session_API.Get_Language, to_char(brec_.execute_seq));
                  RAISE no_execute_ ;
               ELSIF ( parse_intface_name_ = intface_name_ ) THEN
                  message_before_ := message_before_||Language_SYS.Translate_Constant(lu_name_, ' DUPNAME : Method no. :P1 - Value for Job ID cannot be equal to main job  ', Fnd_Session_API.Get_Language, to_char(brec_.execute_seq));
                  RAISE no_execute_ ;
               END IF;
            END IF;
            -- May contain hardcoded value:
            info_ := Client_SYS.Get_Item_Value('INFO_', parse_attr_);
            -- Execute procedure
            Client_SYS.Clear_Attr(attr_);
            Intface_Method_List_API.Execute_Dynamic_Proc ( info_,
                                                         objid_,      -- Dummy
                                                         objversion_, -- Dummy
                                                         attr_,       -- Dummy
                                                         parse_attr_,
                                                         'DO',        --Action
                                                         Intface_Method_List_API.Get_Dynamic_Proc_Name( intface_name_, brec_.execute_seq ));
            IF ( Client_SYS.Get_Item_Value('EXEC_FLAG', attr_) = 'FALSE' ) THEN
               -- Job failed
               @ApproveTransactionStatement(2014-02-18,chmulk)
               SAVEPOINT new_method_;
               RAISE no_execute_;
            END IF;
            info_ := nvl(info_, Language_SYS.Translate_Constant(lu_name_, ' EXEOK :  Executed without error ', Fnd_Session_API.Get_Language));
         EXCEPTION
            WHEN no_execute_ THEN
               Trace_SYS.Message(' Get_Method_List no_execute_');
               methods_before_ok_ := FALSE;
               IF ( NOT intf_ignorexeerror_ ) THEN
                  message_before_ := message_before_||msg_sep_||SQLERRM;
                  RAISE method_error_after_;
               ELSE
                  @ApproveTransactionStatement(2014-02-18,chmulk)
                  ROLLBACK TO SAVEPOINT new_method_;
                  message_before_ := message_before_||msg_sep_||SQLERRM;
               END IF;
            WHEN OTHERS THEN
               Trace_SYS.Message('Get_Method_List OTHERS');
               methods_before_ok_ := FALSE;
               IF ( NOT intf_ignorexeerror_ ) THEN
                  message_before_ := message_before_||msg_sep_||SQLERRM;
                  RAISE method_error_after_;
               ELSE
                  @ApproveTransactionStatement(2014-02-18,chmulk)
                  ROLLBACK TO SAVEPOINT new_method_;
                  message_before_ := message_before_||msg_sep_||SQLERRM;
               END IF;
         END;
         -- Info variable may contain returnvalue from procedure
         -- or errormessage from EXCEPTION. Save info for each turn in loop.
         IF ( info_ IS NOT NULL ) THEN
            message_before_ := message_before_||msg_sep_||info_;
         END IF;
         info_ := NULL;
         parse_info_ := NULL;
         parse_intface_name_ := NULL;

      END LOOP;
   ELSIF (action_ = 'CHECK') THEN
      trace_sys.message('TRACE >>>>>>>>>>>>>>>>>>>>>>> EXECUTING JOBS BEFORE LOOP - SKIPPED since validate');
   END IF;
   -- This flag may have been set to FALSE by preceeding filejobs. Reset it here
  -- Intface_Job_Detail_API.intf_no_file_ := TRUE;
   --
   IF ( source_specified_ ) THEN
      -- Make this IF-test to avoid error-messages if no selection has bee specified.
      -- The job may contain methods that shoud be executed 'BeforeLoop' or 'AfterLoop'.
      trace_sys.message('TRACE >>>>>>>>>>>>>>>>>>>>>>> BUILDING SELECT STATEMENT');
      --
      -- Now we start to build the main selection,
      -- and first we make a column-list based on Intface_Details SOURCE_COLUMN and DEFAULT_VALUE
      -- We also save COLUMN_NAME in a PL/SQL-table (rec_)
      -- for use later when we build the main attr-string
     FOR x IN Get_Columns LOOP
         --IF (Match_Null_Cols___(ic_table_name_, x.source_column) OR x.default_value IS NOT NULL) THEN
         -- The first key items in list are 'master' keys
            IF (x.flags NOT IN ('P','K') ) THEN
               new_master_ := FALSE;
            END IF;
            cols_value_ := NULL;
            cols_value_sub_ := NULL;
            IF ( x.source_column IS NULL ) THEN
               cols_value_ := x.default_value;
            ELSIF ( x.default_value IS NOT NULL ) THEN
               IF(x.source_column IS NOT NULL) THEN
                  cols_value_sub_ := x.source_column;
               END IF;    
               cols_value_ := 'nvl('||x.source_column||','||x.default_value||')';    
            ELSE
               cols_value_sub_ := x.source_column;
               cols_value_ := x.source_column;
            END IF;
            --
            IF ( x.data_type = 'DATE') THEN
               -- Format dates to char values
               cols_value_ := date_format_start_||cols_value_||date_format_end_;
            END IF;
            IF ( x.column_name = 'OBJID' ) THEN
               rowid_name_ := cols_value_;
            ELSE
               cols_  := cols_ || cols_value_|| ', ';
               IF (cols_value_sub_ IS NOT NULL) THEN
                  cols_sub_ := cols_sub_ || cols_value_sub_|| ', ';
               END IF;
                   
               count_ := count_ + 1;
               rec_.cols_(count_) := x.column_name;
               rec_.pos_(count_) := x.pos;
               rec_.conv_list_id_(count_) := x.conv_list_id ;
               -- Mark items
               IF ( new_master_ ) THEN
                  -- Mark items that are 'master' keys
                  rec_.data_type_(count_) := 'MASTER' ;
               ELSE
                  rec_.data_type_(count_) := 'NOMASTER' ;
               END IF;
            END IF;
         --END IF;
      END LOOP;
      -- Add OBJID/rowid to select list if we have any + put it in PL/SQL table
      -- In this way we always make sure OBJID is last column in select list
      IF ( rowid_name_ IS NOT NULL ) THEN
         rowid_count_ := count_ +1; -- We have to keep track of number of columns both
                                    -- with and without rowid
         rec_.cols_(rowid_count_)      := upper(rowid_name_);
         cols_ := cols_||rowid_name_;
         cols_sub_ := cols_sub_||rowid_name_;
      ELSE
         IF ( add_objid_) THEN
            -- OBJID should be part of select when rule is active
            message_select_ := Language_SYS.Translate_Constant(lu_name_, ' NOOBJID : OBJID not in select, but Rule ADDOBJID is active ', Fnd_Session_API.Get_Language );
            RAISE no_start_;
         ELSE
            rowid_count_ := count_;
            cols_ := rtrim(rtrim(cols_,' '),',');
            cols_sub_ := rtrim(rtrim(cols_sub_,' '),','); 
         END IF;
      END IF;
      --
      IF ( replication_ AND repl_mode_  IN ('2','3') ) THEN
         log_seq_count_ := rowid_count_ +1;
         rec_.cols_(log_seq_count_) := 'IRL.LOG_SEQ';
         cols_ := cols_||', IRL.LOG_SEQ';
         stmt_ := 'SELECT ' || cols_ || ' FROM ' || source_name_||' tbl,Intface_Replication_Log_tab irl' ;
      ELSE
         -- We add IC_ROW_NO to the select statement to identify the error lines by checking the select value of the IC_ROW_NO
         cols_ := cols_||', IC_ROW_NO ';
         cols_sub_ :=  cols_sub_||', IC_ROW_NO ';
         stmt_ := 'SELECT ' || cols_sub_ || ' FROM ' || source_name_ || ' ORDER BY '|| 'IC_TBL_LINE_NO' ;
         stmt_  := 'SELECT ' || cols_ || ' FROM ('||stmt_||')';
      END IF;
   
      --
      message_select_ := Language_SYS.Translate_Constant(lu_name_, ' INCOMPLSELECT : Incomplete select not executed  -  :P1 ', Fnd_Session_API.Get_Language, substr(stmt_,length(stmt_)-1900) );
      IF ( cols_ IS NULL OR source_name_ IS NULL ) THEN
         IF ( cols_ IS NOT NULL OR source_name_ IS NOT NULL ) THEN
            NULL ; -- OK
         ELSE
            message_select_ := Language_SYS.Translate_Constant(lu_name_, ' NOSELECT : No select specified  ', Fnd_Session_API.Get_Language);
         END IF;
         RAISE incomplete_select_;
      END IF;
      --
      -- Add where-clause to main select. 
      --
      --
      IF ( nvl(App_Context_SYS.Find_Value(Intface_Job_Detail_API.intf_in_info_cid_),'**') = 'RESTART' AND rowid_name_ IS NOT NULL ) THEN
         -- If this is a restarted job, and we have rowid on source, we
         -- should select only rows with errors from Intface_Job_History,
         -- so we make a sub-query from this table
         --
         IF ( instr(Intface_Header_API.Get_Source_Name(intface_name_),',') != 0 ) THEN
            -- This is a JOIN, keep original WHERE + add subquery
            where_ := Intface_Header_API.Get_Complete_Where(intface_name_)||
                   ' AND '||rowid_name_||' IN (select source_rowid from intface_job_hist_detail_tab'||
                                                ' where intface_name = '||''''||intface_name_||''''||
                                                ' and execution_no = '||execution_no_||')';
         ELSE
         where_ := ' WHERE '||rowid_name_||' IN (select source_rowid from intface_job_hist_detail_tab'||
                                                ' where intface_name = '||''''||intface_name_||''''||
                                                ' and execution_no = '||execution_no_||')';
         END IF;
         --
      ELSIF ( nvl(App_Context_SYS.Find_Value(Intface_Job_Detail_API.intf_in_info_cid_),'**') = 'RESTART' AND rowid_name_ IS NULL ) THEN
         -- Automatic restart is not possible
         message_select_ := Language_SYS.Translate_Constant(lu_name_, ' NORESTART : Restart impossible - :P1 contains no rowid ', Fnd_Session_API.Get_Language, source_name_ );
         RAISE no_restart_; 
     
      ELSIF ( start_ok_ ) THEN
         -- No error lines in IntfaceJobDetail
         -- Make standard where
         where_ := Intface_Header_API.Get_Complete_Where(intface_name_);
      ELSE
         -- There are error lines in IntfaceJobDetail, end job
         message_select_ := Language_SYS.Translate_Constant(lu_name_, ' NOSTART : :P1 have :P2 error lines and cannot be started ', Fnd_Session_API.Get_Language, intface_name_, to_char(check_count_));
         RAISE no_start_;
      END IF;
   
   
      
      -- the following If statement is not needed for this job
      IF ( replication_ AND repl_mode_  IN ('2','3') ) THEN
   
         IF ( repl_mode_ = '2' ) THEN
            -- Mode = Automatic, i.e. process transactions in same order as they occurred
            OPEN get_min_log_seq;
            FETCH get_min_log_seq INTO log_seq_;
            CLOSE get_min_log_seq;
         ELSE
            -- Mode = Batch, process all occurrences since last job-execution
            OPEN get_max_log_seq;
            FETCH get_max_log_seq INTO log_seq_;
            CLOSE get_max_log_seq;
         END IF;
         where_ := Intface_Header_API.Get_Complete_Where(intface_name_);
         IF ( where_ IS NULL ) THEN
             where_ :=  ' WHERE tbl.objid = irl.repl_rowid' ||
                  ' and irl.intface_name = :intface_name ' ||
                       ' AND irl.log_seq <= :log_seq' ||
                     ' and tbl.objid = nvl(:repl_rowid ,tbl.objid) ';
         ELSE
             where_ := where_|| ' AND tbl.objid = irl.repl_rowid' ||
                  ' and irl.intface_name = :intface_name ' ||
                       ' AND irl.log_seq <= :log_seq' ||
                     ' and tbl.objid = nvl(:repl_rowid ,tbl.objid) ';
         END IF;
      END IF;
   
      --
      stmt_ := stmt_ || where_;
      --
      -- Finally, add group_by and order-by clause to statement
      --
      group_by_ := Intface_Header_API.Get_Group_By_Clause(intface_name_);
      IF ( group_by_ IS NOT NULL) THEN
         group_by_ := ' GROUP BY '||group_by_;
         stmt_ := stmt_ || group_by_;
      END IF;
      order_by_ := Intface_Header_API.Get_Order_By_Clause(intface_name_);
      IF ( replication_ AND repl_mode_  IN ('2','3') ) THEN
         IF  ( order_by_ IS NOT NULL) THEN
            order_by_ := order_by_ || ',';
         END IF;
         order_by_ := order_by_ ||'irl.log_seq';
      END IF;

      /*
      IF ( order_by_ IS NOT NULL) THEN
         stmt_ := stmt_ || ' ORDER BY '|| order_by_;
      END IF;
      */
      -- stmt_ := stmt_ || ' ORDER BY '|| 'IC_TBL_LINE_NO';
      --
      -- Save statement, except for column list . Used in building info-variable later
      -- Make newline before FROM and WHERE
      --
      message_select_ := Language_SYS.Translate_Constant(lu_name_, ' SELECTSTMT : Created select  :  ', Fnd_Session_API.Get_Language)||
                         msg_sep_||replace(replace(substr(stmt_,instr(upper(stmt_),' FROM ')),'FROM',msg_sep_||'FROM'),'WHERE',msg_sep_||'WHERE') ;
      --
      h_cur_ := 0;   -- Dummyvalue, replaced further down
      --
      -- Open cursor and parse main select statement
      h_cur_ := DBMS_SQL.Open_Cursor;
      Intface_Detail_API.Trace_Long_Msg(stmt_);
      BEGIN
         @ApproveDynamicStatement(2011-05-19,jhmase)
         DBMS_SQL.Parse(h_cur_, stmt_, DBMS_SQL.native);
   
         IF ( replication_ AND repl_mode_  IN ('2','3') ) THEN
               DBMS_SQL.bind_variable(h_cur_,'intface_name', intface_name_, 2000);
               DBMS_SQL.bind_variable(h_cur_,'log_seq', log_seq_, 2000);
               DBMS_SQL.bind_variable(h_cur_,'repl_rowid', App_Context_SYS.Find_Value(Intface_Job_Detail_API.intf_repl_rowid_context_id_), 2000);
         END IF;
      EXCEPTION
         WHEN OTHERS THEN
            Trace_SYS.Message('PARSE FAILED '||SQLERRM);
            Intface_Detail_API.Trace_Long_Msg(stmt_);
            message_select_ := Language_SYS.Translate_Constant(lu_name_, ' SELECTSTMT : Error in  select  :P1 - :P2 ', Fnd_Session_API.Get_Language, null , substr(SQLERRM,1,1950));
            RAISE no_start_;
      END;
      -- Execute as many Define_Columns as we have selected columns.
      -- These get a number in the 'Stack' and we fetch the return-value
      -- in the main select loop further down
      IF ( replication_ AND repl_mode_  IN ('2','3') ) THEN
         FOR i IN 1..log_seq_count_ LOOP
            stack_(i) := NULL;
            DBMS_SQL.Define_Column(h_cur_, i, stack_(i), 2000);
         END LOOP;
   ELSE
      -- Since we are adding ic_row_no to the select we need one more row to be fetched 
         FOR i IN 1..(rowid_count_ + 1) LOOP
            stack_(i) := NULL;
            DBMS_SQL.Define_Column(h_cur_, i, stack_(i), 2000);
         END LOOP;
      END IF;
      --
      -- Now, the main select is ready to be executed, but first we fetch
      -- all methods in Intface_Method_List with action=2, put them in a PL/SQL table,
      -- open a cursor and parse each statement. This is done before looping on main selection
      -- to avoid parsing within this loop.
      -- If this is a standard new method, we also send in the values for
      -- info, objid and objversion, because they have the same in-value(NULL) each time
      --
      trace_sys.message('TRACE >>>>>>>>>>>>>>>>>>>>>>> BUILDING DYNAMIC PL-TABLE');
      BEGIN
      dyna_count_ := 0;
      LOOP
         IF i_ = 0 THEN
            repl_destination_:= substr(value_list_,0,instr(value_list_,';',1,i_+1)-1);
         ELSE
            repl_destination_:= substr(value_list_,instr(value_list_,';',1,i_)+1,instr(value_list_,';',1,i_+1) -
                    instr(value_list_,';',1,i_)-1);
         END IF;
         EXIT WHEN repl_destination_ IS NULL;
         Trace_SYS.Message(i_||'   '||repl_destination_||'   '||length(repl_destination_));
         i_ := i_ + 1;
         IF ( repl_destination_ = 'NO REPLICATION' ) THEN
            repl_destination_ := NULL;
         END IF;
         FOR drec_ IN Get_Method_List('2') LOOP
            -- Put methods to be executed in a PL/SQL-table (dyna_rec_).
            -- dyna_count_ := get_method_list%ROWCOUNT;
            -- Creates convert_attr and reference
            Client_SYS.Clear_Attr(ref_attr_);
            Client_SYS.Clear_Attr(convert_attr_);
            Client_SYS.Clear_Attr(arg_attr_);
            -- Save original view name by trimming off extensions (if any)
            dyna_view_ := drec_.view_name;
            IF ( drec_.prefix_option = '2' ) THEN
               -- Trim off execute_seq from end of view_name
               exec_seq_ := to_char(drec_.execute_seq);
               IF substr(drec_.view_name, length(drec_.view_name) - length(exec_seq_) + 1, length(exec_seq_)) = exec_seq_ THEN
                  dyna_view_ := substr(drec_.view_name,1, length(drec_.view_name) - length(exec_seq_));
               END IF;
            END IF;
            Trace_SYS.Message('TRACE >>>>>>>>>>>>>>>>>>>>>>> Exec_Seq_'||drec_.execute_seq);
            -- Set common PL/TABLE values
            IF ( drec_.on_modify = 'TRUE' AND drec_.method_type != 'OTHER') THEN
               -- Standard Modify__ method
               -- Build attribute variables
               Get_Method_List_Attrib__ ( ref_attr_, convert_attr_ ,arg_attr_,
                                         repl_criteria_, 'MODIFY' , drec_.execute_seq );
               -- .. and load info into dynamic table
               dyna_count_ := dyna_count_ + 1;
               dyna_rec_.on_new_master(dyna_count_) := drec_.on_new_master;
               dyna_rec_.on_first_row(dyna_count_) := drec_.on_first_row;
               dyna_rec_.column_name(dyna_count_) := drec_.column_name;
               dyna_rec_.column_value(dyna_count_) := drec_.column_value;
               dyna_rec_.error_count(dyna_count_) := 0 ;
               dyna_rec_.incomplete_count(dyna_count_) := 0 ;
               dyna_rec_.commit_count(dyna_count_) := 0 ;
               dyna_rec_.last_row(dyna_count_) := 0 ;
               dyna_rec_.execute_seq(dyna_count_) := drec_.execute_seq;
               dyna_rec_.view_name(dyna_count_) := drec_.view_name;
               dyna_rec_.upd_cur(dyna_count_) := 0; -- Dummyvalue, replaced further down
               dyna_rec_.h_cur(dyna_count_) := 0;   -- Dummyvalue, replaced further down
               dyna_rec_.orig_view_name(dyna_count_) := drec_.view_name;
               dyna_rec_.return_attr(dyna_count_) := 'EMPTY';
               dyna_rec_.attr(dyna_count_) := convert_attr_;
               dyna_stmt_ := 'Begin '||drec_.method_name||'.MODIFY__(:info,:objid,:objversion,:attr, :action ); End;';
               dyna_rec_.method(dyna_count_) := dyna_stmt_;
               dyna_rec_.method_mode(dyna_count_)    := 'UPDATE';
               dyna_rec_.reference(dyna_count_)      := ref_attr_;
               dyna_rec_.h_cur(dyna_count_)          := DBMS_SQL.Open_Cursor;
               method_h_isopen_                      := TRUE;
               -- Parse statement and keep cursor
               @ApproveDynamicStatement(2011-05-19,jhmase)
               DBMS_SQL.Parse(dyna_rec_.h_cur(dyna_count_), dyna_rec_.method(dyna_count_), DBMS_SQL.native);
               DBMS_SQL.bind_variable(dyna_rec_.h_cur(dyna_count_),'info', info_, 2000);
               DBMS_SQL.bind_variable(dyna_rec_.h_cur(dyna_count_),'objid', objid_, 2000);
               DBMS_SQL.bind_variable(dyna_rec_.h_cur(dyna_count_),'objversion', objversion_, 2000);
               DBMS_SQL.bind_variable(dyna_rec_.h_cur(dyna_count_),'attr', return_attr_, 32000);
               DBMS_SQL.bind_variable(dyna_rec_.h_cur(dyna_count_),'action', action_, 2000);
               --
               IF ( ref_attr_ IS NOT NULL ) THEN
                  -- Also parse select for getting objid, objversion
                  Intface_Method_List_API.Build_Get_Objid_Stmt__ ( upd_stmt_, dyna_view_,date_format_, ref_attr_);
                  Intface_Detail_API.Trace_Long_Msg('Get_Objid_Stmt '||upd_stmt_);
                  -- Parse select-statement
                  dyna_rec_.upd_cur(dyna_count_) := DBMS_SQL.Open_Cursor;
                  method_upd_isopen_ := TRUE;
                  -- Safe due to appending values are not directly exposed to user inputs
                  @ApproveDynamicStatement(2009-11-27,nabalk)
                  DBMS_SQL.Parse(dyna_rec_.upd_cur(dyna_count_), upd_stmt_ , DBMS_SQL.native);
                  DBMS_SQL.bind_variable(dyna_rec_.upd_cur(dyna_count_),'objid', objid_, 2000);
                  DBMS_SQL.bind_variable(dyna_rec_.upd_cur(dyna_count_),'objversion', objversion_, 2000);
               END IF;
               IF ( repl_destination_ IS NOT NULL ) THEN
                  dyna_rec_.repl_key(dyna_count_) := Intface_Replic_Criteria_API.Decode(repl_criteria_)||' '||repl_destination_||' : ';
               ELSE
                  dyna_rec_.repl_key(dyna_count_) := ' ';
               END IF;
            END IF;
            IF ( drec_.on_new = 'TRUE' ) THEN
               -- Standard New__ method
               Trace_SYS.Message('NEW');
               Client_SYS.Clear_Attr(ref_attr_);
               Client_SYS.Clear_Attr(convert_attr_);
               -- Build attribute variables
               Get_Method_List_Attrib__( ref_attr_, convert_attr_ ,arg_attr_,
                                         repl_criteria_, 'NEW', drec_.execute_seq );
               -- .. and load info into dynamic table
               dyna_count_ := dyna_count_ + 1;
               dyna_rec_.on_new_master(dyna_count_) := drec_.on_new_master;
               dyna_rec_.on_first_row(dyna_count_) := drec_.on_first_row;
               dyna_rec_.column_name(dyna_count_) := drec_.column_name;
               dyna_rec_.column_value(dyna_count_) := drec_.column_value;
               dyna_rec_.error_count(dyna_count_) := 0 ;
               dyna_rec_.incomplete_count(dyna_count_) := 0 ;
               dyna_rec_.commit_count(dyna_count_) := 0 ;
               dyna_rec_.last_row(dyna_count_) := 0 ;
               dyna_rec_.execute_seq(dyna_count_) := drec_.execute_seq;
               dyna_rec_.view_name(dyna_count_) := drec_.view_name;
               dyna_rec_.upd_cur(dyna_count_) := 0; -- Dummyvalue, replaced further down
               dyna_rec_.h_cur(dyna_count_) := 0;   -- Dummyvalue, replaced further down
               dyna_rec_.orig_view_name(dyna_count_) := drec_.view_name;
               dyna_rec_.return_attr(dyna_count_) := 'EMPTY';
               dyna_rec_.attr(dyna_count_) := convert_attr_;
               dyna_stmt_ := 'Begin '||drec_.method_name||'.NEW__(:info,:objid,:objversion,:attr, :action ); End;';
               dyna_rec_.method(dyna_count_) := dyna_stmt_;
               dyna_rec_.method_mode(dyna_count_) := 'INSERT';
               dyna_rec_.h_cur(dyna_count_) := DBMS_SQL.Open_Cursor;
               method_h_isopen_ := TRUE;
               @ApproveDynamicStatement(2011-05-19,jhmase)
               DBMS_SQL.Parse(dyna_rec_.h_cur(dyna_count_), dyna_rec_.method(dyna_count_), DBMS_SQL.native);
               DBMS_SQL.bind_variable(dyna_rec_.h_cur(dyna_count_),'info', info_, 2000);
               DBMS_SQL.bind_variable(dyna_rec_.h_cur(dyna_count_),'objid', objid_, 2000);
               DBMS_SQL.bind_variable(dyna_rec_.h_cur(dyna_count_),'objversion', objversion_, 2000);
               DBMS_SQL.bind_variable(dyna_rec_.h_cur(dyna_count_),'attr', return_attr_, 32000);
               DBMS_SQL.bind_variable(dyna_rec_.h_cur(dyna_count_),'action', action_, 2000);
               IF ( repl_destination_ IS NOT NULL ) THEN
                  dyna_rec_.repl_key(dyna_count_) := Intface_Replic_Criteria_API.Decode(repl_criteria_)||' '||repl_destination_||' : ';
               ELSE
                  dyna_rec_.repl_key(dyna_count_) := ' ';
               END IF;
            END IF;
            IF ( drec_.method_type = 'OTHER' ) THEN
               -- Any other method.
               -- Build attr-strings...
               Get_Method_List_Attrib__ ( ref_attr_, convert_attr_ ,arg_attr_,
                                         repl_criteria_, drec_.method_type, drec_.execute_seq );
               -- .. and load info into dynamic table
               dyna_count_ := dyna_count_ + 1;
               dyna_rec_.on_new_master(dyna_count_) := drec_.on_new_master;
               dyna_rec_.on_first_row(dyna_count_) := drec_.on_first_row;
               dyna_rec_.column_name(dyna_count_) := drec_.column_name;
               dyna_rec_.column_value(dyna_count_) := drec_.column_value;
               dyna_rec_.error_count(dyna_count_) := 0 ;
               dyna_rec_.incomplete_count(dyna_count_) := 0 ;
               dyna_rec_.commit_count(dyna_count_) := 0 ;
               dyna_rec_.last_row(dyna_count_) := 0 ;
               dyna_rec_.execute_seq(dyna_count_) := drec_.execute_seq;
               dyna_rec_.view_name(dyna_count_) := drec_.view_name;
               dyna_rec_.upd_cur(dyna_count_) := 0; -- Dummyvalue, replaced further down
               dyna_rec_.h_cur(dyna_count_) := 0;   -- Dummyvalue, replaced further down
               dyna_rec_.orig_view_name(dyna_count_) := drec_.view_name;
               dyna_rec_.return_attr(dyna_count_) := 'EMPTY';
               dyna_rec_.method_mode(dyna_count_) := 'OTHER';
               dyna_stmt_ := 'Begin '||Intface_Method_List_API.Get_Dynamic_Proc_Name(intface_name_, drec_.execute_seq)||
                              '(:info,:objid,:objversion,:attr,:arg_attr,:action); End;';
               dyna_rec_.method(dyna_count_) := dyna_stmt_;
               dyna_rec_.attr(dyna_count_) := convert_attr_;
               dyna_rec_.reference(dyna_count_) := ref_attr_;
               dyna_rec_.arg_attr(dyna_count_) := arg_attr_;
               dyna_rec_.h_cur(dyna_count_) := DBMS_SQL.Open_Cursor;
               method_h_isopen_ := TRUE;
               @ApproveDynamicStatement(2011-05-19,jhmase)
               DBMS_SQL.Parse(dyna_rec_.h_cur(dyna_count_), dyna_rec_.method(dyna_count_), DBMS_SQL.native);
               DBMS_SQL.bind_variable(dyna_rec_.h_cur(dyna_count_),'info', info_, 2000);
               IF ( drec_.on_modify = 'TRUE' AND ref_attr_ IS NOT NULL ) THEN
                  -- Also parse select for getting objid, objversion
                  Intface_Method_List_API.Build_Get_Objid_Stmt__ ( upd_stmt_, dyna_view_,date_format_, ref_attr_);
                  Intface_Detail_API.Trace_Long_Msg('Get_Objid_Stmt '||upd_stmt_);
                  -- Parse select-statement
                  dyna_rec_.upd_cur(dyna_count_) := DBMS_SQL.Open_Cursor;
                  method_upd_isopen_ := TRUE;
                  -- Safe due to appending values are not directly exposed to user inputs
                  @ApproveDynamicStatement(2009-11-27,nabalk)
                  DBMS_SQL.Parse(dyna_rec_.upd_cur(dyna_count_), upd_stmt_ , DBMS_SQL.native);
                  DBMS_SQL.bind_variable(dyna_rec_.upd_cur(dyna_count_),'objid', objid_, 2000);
                  DBMS_SQL.bind_variable(dyna_rec_.upd_cur(dyna_count_),'objversion', objversion_, 2000);
               END IF;
            END IF;
            Trace_SYS.Message('dyna_stmt_'||dyna_stmt_);
            Trace_SYS.Message('dyna_rec_.upd_cur(dyna_count_)'||dyna_rec_.upd_cur(dyna_count_));
            dyna_stmt_ := NULL;
            upd_stmt_ := NULL;
         END LOOP;
      END LOOP;
      start_ := SYSDATE;
      EXCEPTION
         WHEN OTHERS THEN
            Trace_SYS.Message('PARSE METHODS FAILED '||SQLERRM);
            message_method_ := substr(dyna_stmt_||' - '||SQLERRM,1,2000);
            Trace_SYS.Message('ROLLBACK to SAVEPOINT new_job_') ;
            @ApproveTransactionStatement(2014-02-18,chmulk)
            ROLLBACK to SAVEPOINT new_job_;
            RAISE method_error_;
      END;
      -- Reset attribute mappings
      Intface_Method_List_API.Unmap_Attributes_To_Pos(intface_name_);  
      -- Commit unfinished transactions before executing cursor
      @ApproveTransactionStatement(2014-02-18,chmulk)
      COMMIT;
      @ApproveTransactionStatement(2014-02-18,chmulk)
      SAVEPOINT new_job_;
   END IF;
   -- Execute main selection only if there are methods to be executed
   IF ( method_upd_isopen_ OR method_h_isopen_ ) THEN
      BEGIN
         -- Check for errors
         dummy_ := DBMS_SQL.Execute(h_cur_);
      EXCEPTION
         WHEN OTHERS THEN
            Trace_SYS.Message('EXECUTE MAIN  FAILED '||SQLERRM);
            message_select_ := stmt_||msg_sep_||msg_sep_|| SQLERRM;
            @ApproveTransactionStatement(2014-02-18,chmulk)
            ROLLBACK TO SAVEPOINT new_job_;
            RAISE no_start_;
      END;
      trace_sys.message('TRACE >>>>>>>>>>>>>>>>>>>>>>> START FETCHING DATA FROM SELECT');
      LOOP -- Start SELECT loop
         -- Init result
         result_rec_.inserted_count(row_num_count_) := 0;
         result_rec_.updated_count(row_num_count_) := 0;
         result_rec_.skipped_count(row_num_count_) := 0;
         result_rec_.executed_count(row_num_count_) := 0;
         result_rec_.activity(row_num_count_) := const_no_op_;
         @ApproveTransactionStatement(2014-02-18,chmulk)
         SAVEPOINT new_row_;
         BEGIN
            -- Check for errors
            IF (DBMS_SQL.Fetch_Rows(h_cur_) = 0) THEN
               EXIT;
            END IF;
         EXCEPTION
            WHEN OTHERS THEN
               Trace_SYS.Message('FETCH ROWS  FAILED '||SQLERRM);
               message_select_ := stmt_||msg_sep_||msg_sep_|| SQLERRM;
               @ApproveTransactionStatement(2014-02-18,chmulk)
               ROLLBACK TO SAVEPOINT new_job_;
               RAISE no_start_;
         END;
         -- Start to fetch return-values from main selection
         -- keep track of number rows read
         row_count_ := row_count_ + 1;
         commit_seq_ := commit_seq_ + 1;
         Trace_SYS.Message('DBMS_SQL.Fetch_row_ '||to_char(row_count_)) ;
         
         -- We check the ic_row_no value to identify if the row has a previous error in unpack
         DBMS_SQL.Column_Value(h_cur_, (rowid_count_ + 1), stack_((rowid_count_ + 1)));
         IF (stack_((rowid_count_ + 1 )) = 0) THEN
            CONTINUE;
         END IF;
         
         -- Empty variables that are used only within each row
         attr_             := NULL;
         master_key_value_ := NULL;
         old_seq_          := NULL;
         ref_value_        := NULL;
         --
         IF ( intf_skip_lines_ >= row_count_ ) THEN  
            -- Rule SKIPLINES is active
            NULL;
         ELSIF ( intf_exit_lines_ < row_count_ ) THEN
            -- Rule EXITLINES is active
            EXIT;
         ELSE
            --
            -- Get defined columns from selection
            FOR i IN 1..count_ LOOP
               -- For each selected row, we find values in the 'Stack' and match
               -- them with COLUMN_NAME that we have saved in PL/SQL-table
               DBMS_SQL.Column_Value(h_cur_, i, stack_(i));
               column_value_ := nvl(stack_(i),use_nullvalue_);
               -- Use hash + pos to name items on attr
               -- Map_Attributes_To_Pos has already marked items
               -- on dyna_rec_.attr with this item (in fixed_value),
               -- and Rebuild_Attr_String will perform faster
               column_name_  := '#'||rec_.pos_(i);
               conv_list_id_ := rec_.conv_list_id_(i);
               IF ( conv_list_id_ IS NOT NULL ) THEN
                  -- Convert values for this column
                  BEGIN
                     convert_value_ := NULL;
                     convert_value_ := Intface_Conv_List_Cols_API.Get_New_Value(conv_list_id_ ,column_value_ );
                     column_value_ := nvl(convert_value_, column_value_);
                  EXCEPTION
                     WHEN OTHERS THEN
                        message_method_ := substr(SQLERRM,1,2000);
                  END;
               END IF;
               client_sys.add_to_attr(column_name_ , column_value_, attr_);
               IF ( rec_.data_type_(i) = 'MASTER' ) THEN
                  -- Save value og master item
                  master_key_value_ := master_key_value_||column_value_||';';
               END IF;
            END LOOP;
            Trace_SYS.Message('After column LOOP, SELECT attr_ :');
            Intface_Detail_API.Trace_Long_Msg(attr_);
            IF ( replication_ AND repl_mode_  IN ('2','3') ) THEN
               DBMS_SQL.Column_Value(h_cur_, log_seq_count_, stack_(log_seq_count_));
               cur_log_seq_ := stack_(log_seq_count_);
               Trace_SYS.Message('Log_seq: '||cur_log_seq_);
               DELETE fROM Intface_Replication_Log_TAB
               WHERE  log_seq = cur_log_seq_;
               Trace_SYS.Message('After delete');
            END IF;
            IF ( nvl(old_master_value_,'x$x$') != master_key_value_ ) THEN
               -- Check if this is a new master record
               client_sys.add_to_attr( 'NEW_MASTER', 'TRUE', attr_);
               new_master_ := TRUE;
            ELSE
               client_sys.add_to_attr( 'NEW_MASTER', 'FALSE', attr_);
               new_master_ := FALSE;
            END IF;
            Trace_SYS.Message('MASTER Key '||master_key_value_);
            old_master_value_ := master_key_value_;
            --
            first_row_ := FALSE;
            IF ( row_count_ = 1 ) THEN
               first_row_ := TRUE;
            END IF;
            IF ( count_ != rowid_count_ ) THEN
               -- Save value of rowid. To be used in error-handling
               DBMS_SQL.Column_Value(h_cur_, rowid_count_, stack_(rowid_count_));
               source_rowid_ := stack_(rowid_count_);
            END IF;
            -- Now we have built an attr-string, then loop on defined methods,
            @ApproveTransactionStatement(2014-02-18,chmulk)
            SAVEPOINT new_method_;
            trace_sys.message('TRACE >>>>>>>>>>>>>>>>>>>>>>> EXECUTE METHOD LIST');
            Trace_SYS.Message('Dyna count_ '||dyna_count_);
            FOR i IN 1..dyna_count_ LOOP -- Start method loop
               trace_sys.message('TRACE >>>>>>>>>>>>>>>>>>>>>>> Checking method no.'||dyna_rec_.execute_seq(i)) ;
               Trace_SYS.Message('Method MODE '||dyna_rec_.method_mode(i)) ;
               @ApproveTransactionStatement(2014-02-18,chmulk)
               SAVEPOINT new_repl_;
               IF ( replication_ ) THEN
                   row_err_count_ := row_err_count_ + 1;
               ELSE
                   row_err_count_ := row_count_;
               END IF;
               ref_attr_ := NULL;
               arg_attr_ := NULL;
               return_attr_ := NULL;
               dyna_attr_ := NULL;
               second_method_ := FALSE;
               IF ( dyna_rec_.method_mode(i) IN ( 'INSERT','UPDATE' ) ) THEN
                  -- Rebuild attr moved further down.
                  IF ( nvl(old_seq_,-1) = dyna_rec_.execute_seq(i)) THEN
                     -- Find out if this is method #1 or #2.
                     second_method_ := TRUE;
                  END IF;
               END IF;
               -- Check if this method should be executed, based
               -- on values in COLUMN_NAME and COLUMN_VALUE
               Trace_SYS.Message('MethodList.column_name(i) '||dyna_rec_.column_name(i));
               Trace_SYS.Message('MethodList.column_value(i) '||dyna_rec_.column_value(i));
               IF ( dyna_rec_.column_name(i) IS NULL ) THEN
                  execute_method_ := TRUE;
               ELSE
                  IF ( instr( dyna_rec_.column_name(i),'@' ) != 0 ) THEN
                     -- Check value from previous method
                     ref_value_ := dyna_rec_.column_name(i);
                     Rebuild_Ref_Value___(ref_value_, row_count_, dyna_rec_.method_mode(i));
                  ELSE
                     -- Check if value exists on SELECT-attr
                      ref_value_ := Client_SYS.Get_Item_Value(dyna_rec_.column_name(i),attr_ );
                  END IF;
                  --
                  IF ( nvl(ref_value_,'NULLVALUE') = 'NULLVALUE' ) THEN
                     IF ( dyna_rec_.column_value(i) IS NULL ) THEN
                        execute_method_ := TRUE;
                     ELSE
                        execute_method_ := FALSE;
                     END IF;
                  ELSIF ( ref_value_ LIKE dyna_rec_.column_value(i) ) THEN
                     execute_method_ := TRUE;
                  ELSE
                     execute_method_ := FALSE;
                  END IF;
               END IF;
               Trace_SYS.Message('Selected column value '||ref_value_);
               IF ( execute_method_ ) THEN
                  -- Final check on ON_NEW_MASTER/ON_FIRST_ROW options
                  IF ( dyna_rec_.on_new_master(i) = 'TRUE' ) THEN
                     execute_method_ := new_master_;
                  END IF;
                  IF ( dyna_rec_.on_first_row(i) = 'TRUE' ) THEN
                     execute_method_ := first_row_;
                  END IF;
               END IF;
               -- Execute this method
               IF ( execute_method_ ) THEN
                  dyna_rec_.return_attr(i) := 'EMPTY';
                  IF ( dyna_rec_.method_mode(i) = 'UPDATE' ) THEN
                     --
                     objid_ := NULL;
                     objversion_ := NULL;
                     -- Perform Modify, but first find value for key columns and lookup objid/objversion
                     Get_Objid_From_Key_Values___(
                        objid_, objversion_,
                        execute_method_,ref_attr_, message_method_, attr_,
                        row_count_, i , dyna_rec_.method_mode(i)) ;
                     --
                     IF (objid_ IS NULL) THEN
                        result_rec_.line_no(row_num_count_) := row_count_;
                        result_rec_.activity(row_num_count_) := const_no_obj_;
                     END IF;

                     IF ( objid_ IS NOT NULL ) THEN
                        Rebuild_Attr_String___(dyna_attr_, attr_, dyna_rec_.attr(i),dyna_rec_.view_name(i),row_count_, dyna_rec_.method_mode(i));
                        Trace_SYS.Message('Existing objid/objversion : '||objid_||'/'||objversion_);
                        -- Record exists, execute Modify
                        DBMS_SQL.bind_variable(dyna_rec_.h_cur(i),'attr', dyna_attr_, 32000);
                        DBMS_SQL.bind_variable(dyna_rec_.h_cur(i),'objid', objid_, 32000);
                        DBMS_SQL.bind_variable(dyna_rec_.h_cur(i),'objversion', objversion_, 32000);
                        BEGIN
                           Trace_SYS.Message('Method Statement '||dyna_rec_.method(i)) ;
                           dummy_ := DBMS_SQL.Execute(dyna_rec_.h_cur(i));
                           DBMS_SQL.variable_value(dyna_rec_.h_cur(i),'objid', objid_);
                           DBMS_SQL.variable_value(dyna_rec_.h_cur(i),'objversion', objversion_);
                           DBMS_SQL.variable_value(dyna_rec_.h_cur(i),'attr', return_attr_);
                           old_seq_ := dyna_rec_.execute_seq(i);
                           dyna_rec_.commit_count(i) := dyna_rec_.commit_count(i) + 1;
                           dyna_rec_.last_row(i) := row_count_;
                           dyna_rec_.return_attr(i) := Intface_Method_List_API.Complete_Return_Attr__(return_attr_,objid_, objversion_);
                           -- We add the line number and the activity to a temporarly table
                           result_rec_.activity(row_num_count_) := const_update_;
                           result_rec_.line_no(row_num_count_) := row_count_;
                           result_rec_.updated_count(row_num_count_) := result_rec_.updated_count(row_num_count_) +1;
                        EXCEPTION
                           WHEN OTHERS THEN
                              result_rec_.line_no(row_num_count_) := row_count_;
                              result_rec_.activity(row_num_count_) := const_error_;
                              dyna_rec_.error_count(i) := dyna_rec_.error_count(i) + 1;
                              -- Add ref_attr to dyna_attr in order to display keyvalues
                              -- on error handling in IntfaceJobDetail
                              dyna_attr_ := ref_attr_||dyna_attr_;
                              message_method_ := substr(SQLERRM,1,2000);
                              Trace_SYS.Message('Method MODIFY failed : '||SQLERRM);
                        END;
                     END IF;
                     old_seq_ := dyna_rec_.execute_seq(i);
                  ELSIF ( dyna_rec_.method_mode(i) = 'INSERT' ) THEN
                     IF ( ( second_method_ ) AND ( objid_ IS NOT NULL ) ) THEN
                        -- This record has been modified, no insert necessary
                           NULL;
                     ELSE
                        Rebuild_Attr_String___(dyna_attr_, attr_, dyna_rec_.attr(i),dyna_rec_.view_name(i),row_count_, dyna_rec_.method_mode(i));
                        BEGIN
                           Trace_SYS.Message('Method Statement '||dyna_rec_.method(i)) ;
                        DBMS_SQL.bind_variable(dyna_rec_.h_cur(i),'attr', dyna_attr_, 32000);
                           dummy_ := DBMS_SQL.Execute(dyna_rec_.h_cur(i));
                           DBMS_SQL.variable_value(dyna_rec_.h_cur(i),'objid', objid_);
                           DBMS_SQL.variable_value(dyna_rec_.h_cur(i),'objversion', objversion_);
                           DBMS_SQL.variable_value(dyna_rec_.h_cur(i),'attr', return_attr_);
                           old_seq_ := dyna_rec_.execute_seq(i);
                           dyna_rec_.commit_count(i) := dyna_rec_.commit_count(i) + 1;
                           dyna_rec_.last_row(i) := row_count_;
                           dyna_rec_.return_attr(i) := Intface_Method_List_API.Complete_Return_Attr__(return_attr_,objid_, objversion_);
                           -- We add the line number and the activity to a temporarly table
                           result_rec_.activity(row_num_count_) := const_insert_;
                           result_rec_.inserted_count(row_num_count_) := result_rec_.inserted_count(row_num_count_) +1;
                           result_rec_.line_no(row_num_count_) := row_count_;
                        EXCEPTION
                           WHEN OTHERS THEN
                              result_rec_.line_no(row_num_count_) := row_count_;
                              result_rec_.activity(row_num_count_) := const_error_;
                              dyna_rec_.error_count(i) := dyna_rec_.error_count(i) + 1;
                              Trace_SYS.Message('Method NEW failed : '||SQLERRM);
                              message_method_ := substr(SQLERRM,1,2000);
                        END;
                     END IF;
                     objid_ := NULL;
                     objversion_ := NULL;
                  ELSE
                     -- Other procedure
                     IF ( dyna_rec_.attr(i) != 'EMPTY' ) THEN
                        Rebuild_Attr_String___(dyna_attr_, attr_, dyna_rec_.attr(i), nvl(dyna_rec_.view_name(i),'METHOD'||dyna_rec_.execute_seq(i)), row_count_,dyna_rec_.method_mode(i));
                     END IF;
                     IF ( dyna_rec_.arg_attr(i)  != 'EMPTY' ) THEN
                        Rebuild_Attr_String___(arg_attr_, attr_, dyna_rec_.arg_attr(i),'METHOD'||dyna_rec_.execute_seq(i),row_count_, 'ARGUMENTS');
                     END IF;
                     IF ( dyna_rec_.upd_cur(i) != 0 ) THEN -- Find objid and objversion
                        Trace_SYS.Message('Get_Objid_From_Key_Values___');
                        -- Must find objid/objversion from key-values first.....
                        Get_Objid_From_Key_Values___(
                           objid_, objversion_,
                           execute_method_,ref_attr_, message_method_, attr_,
                           row_count_, i , dyna_rec_.method_mode(i)) ;
                     END IF;
                     --
                     -- Cannot guarantee that the procedure supports the CHECK mode, so only execute
                     -- when action_ is DO
                     IF ( execute_method_ AND action_ = 'DO') THEN
                        Trace_SYS.Message('Method Statement '||dyna_rec_.method(i)) ;
                        DBMS_SQL.bind_variable(dyna_rec_.h_cur(i),'objid', objid_, 32000);
                        DBMS_SQL.bind_variable(dyna_rec_.h_cur(i),'objversion', objversion_, 32000);
                        DBMS_SQL.bind_variable(dyna_rec_.h_cur(i),'attr', dyna_attr_, 32000);
                        DBMS_SQL.bind_variable(dyna_rec_.h_cur(i),'arg_attr', arg_attr_, 32000);
                        DBMS_SQL.bind_variable(dyna_rec_.h_cur(i),'action', action_, 32000);
                        BEGIN
                           dummy_ := DBMS_SQL.Execute(dyna_rec_.h_cur(i));
                           DBMS_SQL.variable_value(dyna_rec_.h_cur(i),'attr', return_attr_);
                           dyna_rec_.return_attr(i) := Intface_Method_List_API.Complete_Return_Attr__(return_attr_,objid_, objversion_);
                           dyna_rec_.commit_count(i) := dyna_rec_.commit_count(i) + 1;
                           dyna_rec_.last_row(i) := row_count_;
                           IF result_rec_.activity(row_num_count_) NOT IN (const_insert_,const_update_) THEN
                              result_rec_.activity(row_num_count_) := const_execute_;
                           END IF;   
                           result_rec_.line_no(row_num_count_) := row_count_;
                           result_rec_.executed_count(row_num_count_) := result_rec_.executed_count(row_num_count_) +1;
                        EXCEPTION
                           WHEN OTHERS THEN
                              dyna_rec_.error_count(i) := dyna_rec_.error_count(i) + 1;
                              -- Parse SELECT-attr if dyna_attr_ is null
                              IF ( nvl(dyna_attr_,'EMPTY') = 'EMPTY' ) THEN
                                 dyna_attr_ := attr_;
                              END IF;
                              --Ref_attr_ may containg key-values
                              dyna_attr_ := nvl(ref_attr_||dyna_attr_,return_attr_);
                              message_method_ := substr(SQLERRM,1,2000);
                              result_rec_.line_no(row_num_count_) := row_count_;
                              result_rec_.activity(row_num_count_) := const_error_;
                              Trace_SYS.Message('Method OTHER failed : '||SQLERRM);
                        END;
                     ELSIF (action_ = 'CHECK') THEN
                        Trace_SYS.Message('Method Statement '||dyna_rec_.method(i)|| ' skipped, method execute - ('||
                                          sys.diutil.bool_to_int(execute_method_) ||') action '|| action_);
                        result_rec_.line_no(row_num_count_) := row_count_;
                        result_rec_.skipped_count(row_num_count_) := result_rec_.skipped_count(row_num_count_) +1;
                     END IF;
                    objid_ := NULL;
                    objversion_ := NULL;
                  END IF;
               ELSE
                  trace_sys.message('TRACE >>>>>>>>>>>>>>>>>>>>>>> Method no.'||dyna_rec_.execute_seq(i)||' not executed') ;
                  result_rec_.line_no(row_num_count_) := row_count_;
               END IF;
               -- Message_method has only been used if errors have occured
               IF ( message_method_ IS NOT NULL ) THEN
                  -- This method has failed
                  -- Make w_attr_ for presentation in case of error-handling
                  w_attr_ := dyna_attr_;
                  IF ( NOT intf_ignorexeerror_ ) THEN  
                     error_count_ := error_count_ + 1;
                     method_raised_ := i;               -- For error-handling in EXCEPTION
                     RAISE method_error_;
                  ELSE
                     IF ( NOT replication_ ) THEN
                        BEGIN
                           -- If server methods have execeuted COMMIT,
                           -- this ROLLBACK will fail. In that case we'll
                           -- have incomplete transactions
                           Trace_SYS.Message('ROLLBACK to SAVEPOINT new_method_') ;
                           @ApproveTransactionStatement(2014-02-18,chmulk)
                           ROLLBACK TO SAVEPOINT new_method_;
                           @ApproveTransactionStatement(2014-02-18,chmulk)
                           SAVEPOINT new_method_;
                        EXCEPTION
                           WHEN OTHERS THEN
                              Trace_SYS.Message('ROLLBACK to new_method FAILED ');
                              dyna_rec_.incomplete_count(i) := dyna_rec_.incomplete_count(i) + 1;
                              message_method_ := substr('INCOMPLETE ROW : '||message_method_,1,2000);
                        END;
                     ELSE
                        @ApproveTransactionStatement(2014-02-18,chmulk)
                        ROLLBACK TO SAVEPOINT new_repl_;
                     END IF;
                     -- error handling
                     UPDATE intface_execution_detail_tab 
                        SET   error_message  = message_method_   
                        WHERE execution_id   = execution_id_
                        AND   line_no        = row_err_count_;  

                     IF ( replication_ ) THEN
                        @ApproveTransactionStatement(2014-02-18,chmulk)
                        COMMIT;
                        message_method_ := NULL;
                     ELSE
                        EXIT;
                     END IF;
                  END IF;
               END IF;
            END LOOP; -- End method loop
            Trace_SYS.Message('Method LOOP finished');
            --
            -- Keep track of number rows COMMITed
            --
            row_num_count_ := row_num_count_ + 1;
            IF ( message_method_ IS NOT NULL ) THEN
               error_count_ := error_count_ + 1;
               message_method_ := NULL;
            ELSE
               commit_count_ := commit_count_ + 1;
            END IF;
         END IF;
         IF ( replication_ ) THEN
            @ApproveTransactionStatement(2014-02-18,chmulk)
            COMMIT;
            @ApproveTransactionStatement(2014-02-18,chmulk)
            SAVEPOINT new_job_;
         ELSIF ( nvl(intf_commit_seq_, commit_seq_+1) <= commit_seq_ ) THEN 
            @ApproveTransactionStatement(2014-02-18,chmulk)
            COMMIT;
            Trace_SYS.Message(' TRACE>>>>>>> Commit ');
            commit_seq_cnt_ := commit_seq_cnt_ + commit_seq_;
            commit_seq_ := 0;
            @ApproveTransactionStatement(2014-02-18,chmulk)
            SAVEPOINT new_job_;
         END IF;
      END LOOP; -- End SELECT loop
      IF ( replication_ AND repl_mode_  IN ('2','3') ) THEN
         -- IF there have been added a WHERE-clause to the job,
         -- there may be rows in the log-table that never meets this clause,
         -- and therefore never will be handled.
         -- Perform this extra DELETE to remove 'leftovers'
         Trace_SYS.Message('Delete prior to Log_seq: '||log_seq_);
         DELETE FROM Intface_Replication_Log_TAB
         WHERE  intface_name = intface_name_
         AND log_seq < log_seq_;
      END IF;
      --
      -- Check how each method have executed.
      -- Build info message
      error_count_ := 0;
      FOR i IN 1..dyna_count_ LOOP
         Trace_SYS.Message('check method no '||to_char(i));
         -- Extract method_name
         show_method_ := REPLACE(SUBSTR(dyna_rec_.method(i),1,INSTR(dyna_rec_.method(i),'(')-1),'Begin ','');
         IF ( dyna_rec_.method_mode(i) != 'OTHER' ) THEN
            show_method_ := substr(show_method_,1,instr(show_method_,'.')-1);
         END IF;
         method_result_ := NULL;
         IF ( old_exe_seq_ != dyna_rec_.execute_seq(i) ) THEN
            IF ( action_ = 'CHECK') THEN
               method_result_ := Language_SYS.Translate_Constant(lu_name_, ' METHCHK : :P1 :P2  with CHECK option ', Fnd_Session_API.Get_Language, lpad(to_char(dyna_rec_.execute_seq(i)),3,' '), show_method_ );
            ELSE
               method_result_ := Language_SYS.Translate_Constant(lu_name_, ' METHNAME : :P1 :P2 ', Fnd_Session_API.Get_Language, lpad(to_char(dyna_rec_.execute_seq(i)),3,' '), show_method_ );
            END IF;
            method_result_ := msg_sep_||method_result_;
         END IF;
         method_executed_ := TRUE;
         incomplete_result_ := NULL;
         error_result_ := NULL;
         IF ( dyna_rec_.incomplete_count(i) > 0 ) THEN
            incomplete_trans_ := TRUE;
            incomplete_result_ := msg_sep_||Language_SYS.Translate_Constant(lu_name_, ' INCOMPLETE : :P1 incomplete transactions due to COMMIT or ROLLBACK in a called method ', Fnd_Session_API.Get_Language, to_char(dyna_rec_.incomplete_count(i)));
            methods_in_ok_ := FALSE;
            error_count_ := error_count_ + dyna_rec_.incomplete_count(i);
         ELSIF ( dyna_rec_.error_count(i) > 0 ) THEN
            error_result_ := Language_SYS.Translate_Constant(lu_name_, ' METHFAILED : , Errors : :P1  ', Fnd_Session_API.Get_Language, to_char(dyna_rec_.error_count(i)));
            methods_in_ok_ := FALSE;
            error_count_ := error_count_ + dyna_rec_.error_count(i);
         ELSIF ( dyna_rec_.commit_count(i) > 0 ) THEN
            NULL ;
         ELSE
            method_executed_  := FALSE;
         END IF;
         IF ( method_executed_ ) THEN
            IF ( replication_ AND repl_destination_ IS NOT NULL ) THEN
               method_result_ := method_result_||msg_sep_||'       '||dyna_rec_.repl_key(i);
            ELSE
               method_result_ := method_result_||msg_sep_||'       ';
            END IF;
            
            IF ( dyna_rec_.method_mode(i) = 'INSERT' ) THEN
               method_result_ := method_result_ ||
                  Language_SYS.Translate_Constant(lu_name_, ' METHINS : New rows      : :P1  ', Fnd_Session_API.Get_Language, to_char(dyna_rec_.commit_count(i)));
            ELSIF ( dyna_rec_.method_mode(i) = 'UPDATE' ) THEN
               method_result_ := method_result_ ||
                  Language_SYS.Translate_Constant(lu_name_, ' METHUPD : Updated rows  : :P1  ', Fnd_Session_API.Get_Language, to_char(dyna_rec_.commit_count(i)));
            ELSE
               method_result_ := method_result_ ||
                  Language_SYS.Translate_Constant(lu_name_, ' METHPRC : Processed rows  : :P1  ', Fnd_Session_API.Get_Language, to_char(dyna_rec_.commit_count(i)));
            END IF;
            method_result_ := method_result_ || error_result_|| incomplete_result_;
         END IF;
         IF ( all_methods_ IS NULL ) THEN
            all_methods_ := method_result_;
         ELSE
            all_methods_ := substr(all_methods_||method_result_,1,30000);
         END IF;
         old_exe_seq_ := dyna_rec_.execute_seq(i);
      END LOOP;
      Close_Cursors__(dyna_count_);
   ELSIF ( h_cur_ != 0  ) THEN
      message_select_ := NULL; -- Select parsed, but not executed
      IF ( DBMS_SQL.Is_Open(h_cur_) ) THEN
         DBMS_SQL.Close_Cursor(h_cur_);
      END IF;
   END IF;
   --  
   IF (action_ = 'DO') THEN
      trace_sys.message('TRACE >>>>>>>>>>>>>>>>>>>>>>> EXECUTE METHODS AFTER LOOP');
      -- Finally, execute methods after main loop ends. They have action=3
      FOR arec_ IN Get_Method_List('3') LOOP
         @ApproveTransactionStatement(2014-02-18,chmulk)
         SAVEPOINT new_method_;
         BEGIN
            header_message_ := Language_SYS.Translate_Constant(lu_name_, ' HEADMSG : EXECUTING METHOD NO. :P1 : ', Fnd_Session_API.Get_Language, to_char(arec_.execute_seq));
            IF ( message_after_ IS NULL ) THEN
               message_after_ := header_message_||msg_sep_||'       ';
            ELSE
               message_after_ := message_after_||msg_sep_||msg_sep_||header_message_||msg_sep_||'       ';
            END IF;
            Client_SYS.Clear_Attr(parse_attr_);
            Get_Method_List_Attrib__ ( ref_attr_, convert_attr_ ,parse_attr_,
                                      '0', 'AFTER_LOOP', arec_.execute_seq );
            IF ( instr(upper(arec_.method_name),'INTFACE_HEADER_API.START_JOB') != 0) THEN
               -- This starts another migration job
               parse_intface_name_ := Client_SYS.Get_Item_Value('INTFACE_NAME_', parse_attr_);
               IF ( parse_intface_name_ IS NULL ) THEN
                  message_after_ := message_after_||Language_SYS.Translate_Constant(lu_name_, ' NONAME : Value for Job ID is missing on attr-string for method no. :P1 ', Fnd_Session_API.Get_Language, to_char(arec_.execute_seq));
                  RAISE no_execute_;
               ELSIF ( parse_intface_name_ = intface_name_ ) THEN
                  message_after_ := message_after_||Language_SYS.Translate_Constant(lu_name_, ' DUPNAME : Method no. :P1 - Value for Job ID cannot be equal to main job  ', Fnd_Session_API.Get_Language, to_char(arec_.execute_seq));
                  RAISE no_execute_ ;
               END IF;
            END IF;
            -- May contain hardcoded value:
            info_ := Client_SYS.Get_Item_Value('INFO_', parse_attr_);
            --
            Client_SYS.Clear_Attr(attr_);
            Intface_Method_List_API.Execute_Dynamic_Proc ( info_,
                                                         objid_,      -- Dummy
                                                         objversion_, -- Dummy
                                                         attr_,       -- Dummy
                                                         parse_attr_,
                                                         'DO',        --Action
                                                         Intface_Method_List_API.Get_Dynamic_Proc_Name( intface_name_, arec_.execute_seq ));
            IF ( Client_SYS.Get_Item_Value('EXEC_FLAG', attr_) = 'FALSE' ) THEN
               -- Job failed
               @ApproveTransactionStatement(2014-02-18,chmulk)
               SAVEPOINT new_method_;
               RAISE no_execute_;
            END IF;
            info_ := nvl(info_, Language_SYS.Translate_Constant(lu_name_, ' EXEOK :  Executed without error', Fnd_Session_API.Get_Language));
         EXCEPTION
            WHEN no_execute_ THEN
               Trace_SYS.Message(' Get_Method_List no_execute_');
               methods_after_ok_ := FALSE;
               IF ( NOT intf_ignorexeerror_ ) THEN 
                  message_after_ := message_after_||msg_sep_||SQLERRM;
                  RAISE method_error_after_;
               ELSE
                  @ApproveTransactionStatement(2014-02-18,chmulk)
                  ROLLBACK TO SAVEPOINT new_method_;
                  message_after_ := message_after_||msg_sep_||SQLERRM;
               END IF;
            WHEN OTHERS THEN
               Trace_SYS.Message('Get_Method_List OTHERS');
               methods_after_ok_ := FALSE;
               IF ( NOT intf_ignorexeerror_ ) THEN
                  message_after_ := message_after_||msg_sep_||SQLERRM;
                  RAISE method_error_after_;
               ELSE
                  @ApproveTransactionStatement(2014-02-18,chmulk)
                  ROLLBACK TO SAVEPOINT new_method_;
                  message_after_ := message_after_||msg_sep_||SQLERRM;
               END IF;
         END;
         -- Info variable may contain returnvalue from procedure
         -- or errormessage from EXCEPTION. Save info for each turn in loop.
         IF ( info_ IS NOT NULL ) THEN
            message_after_ := message_after_||msg_sep_||info_;
         END IF;
         info_ := NULL;
         parse_info_ := NULL;
         parse_intface_name_ := NULL;
      END LOOP;
   ELSE
      Trace_SYS.Message('TRACE >>>>>>>>>>>>>>>>>>>>>>> EXECUTE METHODS AFTER LOOP - SKIPPED since validate');
      
   END IF;
   
   FOR i IN 1..(row_num_count_ - 1) LOOP
      --
      -- IF action_ = CHECK THEN
      --    IF inserted_count OR updated_count OR skipped_count > 0 THEN
      --       VALIDATION OK;
      --    END IF;
      -- ELSE action_ = DO THEN
      --    IF inserted_count > 0 AND updated_count > 0 THEN
      --       INSERTED/UPDATED
      --    ELSIF inserted > 0 THEN
      --       INSERTED
      --    ELSIF updated > 0 THEN
      --       UPDATED
      --    ELSIF executed > 0 THEN
      --       PROCESSED -> Processed is shown when only methods were executed.
      --                    If Insert or Update happened show that result instead.
      --    END IF;
      -- END IF;
      
      -- Errors are already handled
      IF (result_rec_.activity(i) != const_error_) THEN
         IF (action_ = 'CHECK') THEN
            IF (result_rec_.inserted_count(i) > 0 OR result_rec_.updated_count(i) > 0 OR result_rec_.skipped_count(i) > 0) THEN
               row_action_ := Language_Sys.Translate_Constant(lu_name_, 'STATOK: Validate OK');
            END IF;   
         ELSIF (action_ = 'DO') THEN
            IF result_rec_.inserted_count(i) > 0 AND result_rec_.updated_count(i) > 0 THEN
               row_action_ := Language_Sys.Translate_Constant(lu_name_, 'STATINSERT: Inserted') || '/' || Language_Sys.Translate_Constant(lu_name_, 'STATUPDATE: Updated');
            ELSIF result_rec_.inserted_count(i) > 0 THEN
               row_action_ := Language_Sys.Translate_Constant(lu_name_, 'STATINSERT: Inserted');
            ELSIF result_rec_.updated_count(i) > 0 THEN
               row_action_ := Language_Sys.Translate_Constant(lu_name_, 'STATUPDATE: Updated');
            ELSIF result_rec_.executed_count(i) > 0 THEN
               row_action_ := Language_Sys.Translate_Constant(lu_name_, 'STATPROC: Processed');
            END IF;   
         END IF;
            
         IF (result_rec_.activity(i) = const_no_obj_) THEN
            row_action_ := Language_Sys.Translate_Constant(lu_name_, 'STATNOTEXT: Object does not exist');
         ELSIF (result_rec_.activity(i) = const_no_op_ AND result_rec_.skipped_count(i) = 0) THEN
            row_action_ := Language_Sys.Translate_Constant(lu_name_, 'STATNOOP: No Operation');
         END IF;   
            
         -- Trace stats
         Trace_SYS.Message('--- Row stats - ('||i||')'||'-'||action_);
         Trace_SYS.Message(' Insert       : '||result_rec_.inserted_count(i));
         Trace_SYS.Message(' Update       : '||result_rec_.updated_count(i));
         IF (action_ = 'DO') THEN
            Trace_SYS.Message(' Meth Executed: '||result_rec_.executed_count(i));
         ELSIF (action_ = 'CHECK') THEN
            Trace_SYS.Message(' Meth Skipped : '||result_rec_.skipped_count(i));
         END IF;
         Trace_SYS.Message('---');
         --
         UPDATE intface_execution_detail_tab
            SET error_message = row_action_
          WHERE execution_id  = execution_id_
            AND line_no       = result_rec_.line_no(i);
      END IF;   
   END LOOP;
   --
   -- Build info variable.
   -- Send action to make alternate message for CHECKed rows
   info_ := action_;
   Build_Info_String___(info_,message_start_,message_before_, message_select_, all_methods_ ,message_after_, start_time_,row_count_, incomplete_trans_, commit_count_,error_count_, intface_name_);
   
   Close_Cursors__(dyna_count_);
   IF ( Intface_Job_Detail_API.Get_String%ISOPEN ) THEN
      CLOSE Intface_Job_Detail_API.Get_String;
   END IF;
   @ApproveTransactionStatement(2014-02-18,chmulk)
   COMMIT;
 
EXCEPTION
   WHEN no_conn_start_ THEN
      message_select_ := Language_SYS.Translate_Constant(lu_name_, ' CONNERR : Cannot start this job. Connected job :P1 has errors.', Fnd_Session_API.Get_Language, conn_job1_ );
      Build_Info_String___(info_,message_start_,message_before_, message_select_,message_method_,message_after_, start_time_,row_count_,incomplete_trans_,commit_count_,error_count_, intface_name_);
      trace_sys.message('TRACE >>>>>>>>>>>>>>>>>>>>>>> JOB ABORTED - no_conn_start_');
   WHEN incomplete_select_ THEN
      trace_sys.message('TRACE >>>>>>>>>>>>>>>>>>>>>>> JOB ABORTED - incomplete_select_ rollback');
      --ROLLBACK TO SAVEPOINT new_job_;
      @ApproveTransactionStatement(2014-02-18,chmulk)
      ROLLBACK;
      -- Send action to make alternate message for CHECKed rows
      info_ := action_;
      Build_Info_String___(info_,message_start_,message_before_, message_select_,message_method_,message_after_, start_time_,row_count_,incomplete_trans_,commit_count_,error_count_, intface_name_);
   WHEN no_restart_ THEN
      trace_sys.message('TRACE >>>>>>>>>>>>>>>>>>>>>>> JOB ABORTED - no_restart_ rollback');
      --ROLLBACK TO SAVEPOINT new_job_;
      @ApproveTransactionStatement(2014-02-18,chmulk)
      ROLLBACK;
      -- Send action to make alternate message for CHECKed rows
      info_ := action_;
      Build_Info_String___(info_,message_start_,message_before_, message_select_,message_method_,message_after_, start_time_,row_count_,incomplete_trans_,commit_count_,error_count_, intface_name_);
   WHEN no_start_ THEN
      trace_sys.message('TRACE >>>>>>>>>>>>>>>>>>>>>>> JOB ABORTED - no_start_');
      --ROLLBACK TO SAVEPOINT new_job_;
      @ApproveTransactionStatement(2014-02-18,chmulk)
      ROLLBACK;
      -- Send action to make alternate message for CHECKed rows
      info_ := action_;
      Build_Info_String___(info_,message_start_,message_before_, message_select_,message_method_,message_after_, start_time_,row_count_,incomplete_trans_,commit_count_,error_count_, intface_name_);
   WHEN method_error_ THEN
      trace_sys.message('TRACE >>>>>>>>>>>>>>>>>>>>>>> JOB ABORTED - method_error_ ');
      BEGIN
         @ApproveTransactionStatement(2014-02-18,chmulk)
         ROLLBACK TO SAVEPOINT new_job_;
         Trace_SYS.Message('Rollback OK ');
      EXCEPTION
         -- If ROLLBACK fails, make warning
         WHEN OTHERS THEN
            IF ( nvl(method_raised_,0) != 0 ) THEN
               dyna_rec_.incomplete_count(method_raised_) := dyna_rec_.incomplete_count(method_raised_) + 1;
            END IF;
            Trace_SYS.Message('ROLLBACK failed, RAISE '||SQLERRM);
            message_method_ := Language_SYS.Translate_Constant(lu_name_, ' INCOMPLROW1 : INCOMPLETE ROW : ', Fnd_Session_API.Get_Language )||message_method_ ;
      END;
      IF ( intf_commit_seq_ IS NULL ) THEN
         commit_count_ := 0;
      END IF;
      -- Check how each method have executed.
      -- Build info message
      error_count_ := 0;
      FOR i IN 1..dyna_count_ LOOP
         Trace_SYS.Message('check method no '||to_char(i));
         -- Extract method_name
         show_method_ := REPLACE(SUBSTR(dyna_rec_.method(i),1,INSTR(dyna_rec_.method(i),'(')-1),'Begin ','');
         IF ( dyna_rec_.method_mode(i) != 'OTHER' ) THEN
            show_method_ := substr(show_method_,1,instr(show_method_,'.')-1);
         END IF;
         method_result_ := NULL;
         IF ( old_exe_seq_ != dyna_rec_.execute_seq(i) ) THEN
            IF ( action_ = 'CHECK') THEN
               method_result_ := Language_SYS.Translate_Constant(lu_name_, ' METHCHK : :P1 :P2  with CHECK option ', Fnd_Session_API.Get_Language, lpad(to_char(dyna_rec_.execute_seq(i)),3,' '), show_method_ );
            ELSE
               method_result_ := Language_SYS.Translate_Constant(lu_name_, ' METHNAME : :P1 :P2 ', Fnd_Session_API.Get_Language, lpad(to_char(dyna_rec_.execute_seq(i)),3,' '), show_method_ );
            END IF;
            method_result_ := msg_sep_||method_result_;
         END IF;
         method_executed_ := TRUE;
         incomplete_result_ := NULL;
         error_result_ := NULL;
         IF ( dyna_rec_.incomplete_count(i) > 0 ) THEN
            incomplete_trans_ := TRUE;
            incomplete_result_ := msg_sep_||Language_SYS.Translate_Constant(lu_name_, ' INCOMPLETE : :P1 incomplete transactions due to COMMIT or ROLLBACK in a called method ', Fnd_Session_API.Get_Language, to_char(dyna_rec_.incomplete_count(i)));
            methods_in_ok_ := FALSE;
            error_count_ := error_count_ + dyna_rec_.incomplete_count(i);
         ELSIF ( dyna_rec_.error_count(i) > 0 ) THEN
            error_result_ := Language_SYS.Translate_Constant(lu_name_, ' METHFAILED : , Errors : :P1  ', Fnd_Session_API.Get_Language, to_char(dyna_rec_.error_count(i)));
            methods_in_ok_ := FALSE;
            error_count_ := error_count_ + dyna_rec_.error_count(i);
         ELSIF ( dyna_rec_.commit_count(i) > 0 ) THEN
            NULL ;
         ELSE
            method_executed_  := FALSE;
         END IF;
         IF ( method_executed_ ) THEN
            IF ( replication_ AND repl_destination_ IS NOT NULL ) THEN
               method_result_ := method_result_||msg_sep_||'       '||dyna_rec_.repl_key(i);
            ELSE
               method_result_ := method_result_||msg_sep_||'       ';
            END IF;
            --
            IF ( dyna_rec_.method_mode(i) = 'INSERT' ) THEN
               method_result_ := method_result_ ||
                  Language_SYS.Translate_Constant(lu_name_, ' METHINS : New rows      : :P1  ', Fnd_Session_API.Get_Language, to_char(dyna_rec_.commit_count(i)));
            ELSIF ( dyna_rec_.method_mode(i) = 'UPDATE' ) THEN
               method_result_ := method_result_ ||
                  Language_SYS.Translate_Constant(lu_name_, ' METHUPD : Updated rows  : :P1  ', Fnd_Session_API.Get_Language, to_char(dyna_rec_.commit_count(i)));
            ELSE
               method_result_ := method_result_ ||
                  Language_SYS.Translate_Constant(lu_name_, ' METHPRC : Processed rows  : :P1  ', Fnd_Session_API.Get_Language, to_char(dyna_rec_.commit_count(i)));
            END IF;
            method_result_ := method_result_ || error_result_|| incomplete_result_;
         END IF;
         IF ( all_methods_ IS NULL ) THEN
            all_methods_ := method_result_;
         ELSE
            all_methods_ := substr(all_methods_||method_result_,1,30000);
         END IF;
         old_exe_seq_ := dyna_rec_.execute_seq(i);
      END LOOP;
      IF ( commit_seq_cnt_ > 0) THEN
         all_methods_ := all_methods_||msg_sep_||msg_sep_||
            Language_SYS.Translate_Constant(lu_name_, ' COMMITSEQ :  Rows committed by Rule COMMITSEQ : :P1 ', Fnd_Session_API.Get_Language , to_char(commit_seq_cnt_));
      END IF;
      Trace_SYS.Message('Close cursors');
      Close_Cursors__(dyna_count_);
      Trace_SYS.Message('Update job details');
      IF ( nvl(method_raised_,0) != 0 ) THEN
         -- Update details only if this Exception is raised
         -- for a method InLoop
         BEGIN        
         -- error handling
            UPDATE intface_execution_detail_tab 
               SET error_message = message_method_   
             WHERE execution_id  = execution_id_
               AND line_no       = row_count_;             
         EXCEPTION
            WHEN OTHERS THEN
               Trace_SYS.Message(SQLERRM);
         END;
      END IF;
      Trace_SYS.Message('Build info');
      -- Send action to make alternate message for CHECKed rows
      info_ := action_;
      Build_Info_String___(info_,message_start_,message_before_, message_select_,all_methods_ ,message_after_, start_time_,row_count_,incomplete_trans_,commit_count_,error_count_, intface_name_);
      Trace_SYS.Message('Build OK');
   WHEN method_error_after_ THEN
      Trace_SYS.Message('TRACE >>>>>>>>>>>>>>>>>>>>>>> JOB ABORTED - method_error_after_ ');
      Build_Info_String___(info_,message_start_,message_before_, message_select_,all_methods_ ,message_after_, start_time_,row_count_,incomplete_trans_,commit_count_,error_count_, intface_name_);
   WHEN OTHERS THEN
      Trace_SYS.Message('TRACE >>>>>>>>>>>>>>>>>>>>>>> JOB ABORTED - OTHERS') ;
      Trace_SYS.Message('OTHERS '||SQLERRM);
      Trace_SYS.Message(dbms_utility.format_error_backtrace);
      @ApproveTransactionStatement(2014-02-18,chmulk)
      ROLLBACK TO SAVEPOINT new_job_;
      commit_count_ := 0;
      Close_Cursors__(dyna_count_);
      Build_Info_String___(info_,message_start_,message_before_, message_select_,message_method_,message_after_, start_time_,row_count_,incomplete_trans_,commit_count_,error_count_, intface_name_);
END Migrate_Source_Data___;


PROCEDURE Build_Info_String___ (
   info_           IN OUT VARCHAR2,
   message_start_  IN     VARCHAR2,
   message_before_ IN     VARCHAR2,
   message_select_ IN     VARCHAR2,
   message_method_ IN     VARCHAR2,
   message_after_  IN     VARCHAR2,
   start_time_     IN     VARCHAR2,
   row_count_      IN     NUMBER,
   incompl_trans_  IN     BOOLEAN,
   commit_count_   IN     NUMBER,
   error_count_    IN     NUMBER,
   intface_name_   IN     VARCHAR2 )
IS
   w_info_          VARCHAR2(32000);
   message_count_   VARCHAR2(2000);
   message_commit_  VARCHAR2(2000);
   message_error_   VARCHAR2(2000);
   message_end_     VARCHAR2(2000);
   message_elapse_  VARCHAR2(2000);
   message_avg_     VARCHAR2(2000);
   end_time_        VARCHAR2(50) := to_char(sysdate,'DD-MON-YYYY HH24:MI:SS');
   elapsed_time_    NUMBER;
   elapsed_hours_   NUMBER;
   elapsed_minutes_ NUMBER;
   total_minutes_   NUMBER;
   avg_rows_        NUMBER;
   start_pos_       NUMBER;
   mode_            VARCHAR2(2000);
   max_info_length_ NUMBER := 4000;

   FUNCTION add_to_w_info_ (
      w_info_   IN VARCHAR2,
      string01_ IN VARCHAR2,
      string02_ IN VARCHAR2 DEFAULT NULL,
      string03_ IN VARCHAR2 DEFAULT NULL,
      string04_ IN VARCHAR2 DEFAULT NULL,
      string05_ IN VARCHAR2 DEFAULT NULL,
      string06_ IN VARCHAR2 DEFAULT NULL,
      string07_ IN VARCHAR2 DEFAULT NULL,
      string08_ IN VARCHAR2 DEFAULT NULL,
      string09_ IN VARCHAR2 DEFAULT NULL,
      string10_ IN VARCHAR2 DEFAULT NULL,
      string11_ IN VARCHAR2 DEFAULT NULL,
      string12_ IN VARCHAR2 DEFAULT NULL) RETURN VARCHAR2
   IS
   BEGIN
      IF ( string01_ IS NULL ) THEN
         RETURN w_info_;
      END IF;
      RETURN w_info_ || string01_ || string02_ || string03_ || string04_ ||
                        string05_ || string06_ || string07_ || string08_ ||
                        string09_ || string10_ || string11_ || string12_;
   EXCEPTION
      WHEN OTHERS THEN
         RETURN w_info_ || ' (...) ';
   END add_to_w_info_;
BEGIN
   mode_ := info_;
   info_ := NULL;
   --
   elapsed_time_ := to_date(end_time_, 'DD-MON-YYYY HH24:MI:SS') - to_date(start_time_, 'DD-MON-YYYY HH24:MI:SS');
   IF ( elapsed_time_ = 0 ) THEN
      elapsed_time_ := 0.00001157; -- set 1 second as minimum
   END IF;
   IF ( nvl(row_count_,0) != 0 and nvl(elapsed_time_,0) != 0 ) THEN
      elapsed_hours_   := trunc(elapsed_time_ * 24);
      elapsed_minutes_ := round((elapsed_time_ * 24 * 60) - (trunc(elapsed_time_ * 24) * 60),1);
      total_minutes_   := (elapsed_time_ * (24 * 60));
      avg_rows_        := trunc(row_count_ / total_minutes_);
      IF ( mode_ = 'CHECK' ) THEN
         message_count_ := Language_SYS.Translate_Constant(lu_name_, ' CHKCOUNT : :P1 rows checked ', Fnd_Session_API.Get_Language, lpad(to_char(nvl(row_count_, 0)), 8, ' '));
      ELSE
         message_count_ := Language_SYS.Translate_Constant(lu_name_, ' MSGCOUNT : :P1 rows selected ', Fnd_Session_API.Get_Language, lpad(to_char(nvl(row_count_, 0)), 8, ' '));
      END IF;
      IF ( incompl_trans_ ) THEN
         message_commit_ := Language_SYS.Translate_Constant(lu_name_, ' INCOMPLTRANS : Check result. Transactions may be partially committed ', Fnd_Session_API.Get_Language );
         BEGIN
            message_commit_ := message_commit_||msg_sep_||
                            Language_SYS.Translate_Constant(lu_name_, ' INCOMPLROW : Search for INCOMPLETE ROW in Error Message', Fnd_Session_API.Get_Language )||msg_sep_;
         EXCEPTION
            WHEN OTHERS THEN NULL;
         END;
      ELSIF ( mode_ = 'CREATE_TABLE' ) THEN
         message_commit_ := Language_SYS.Translate_Constant(lu_name_, ' MSGCOMMIT : :P1 rows committed ', Fnd_Session_API.Get_Language, lpad(to_char(nvl(commit_count_, 0)), 8, ' '));
         BEGIN
            message_commit_ := message_commit_||msg_sep_;
         EXCEPTION
            WHEN OTHERS THEN NULL;
         END;
      END IF;
      message_error_  := Language_SYS.Translate_Constant(lu_name_, ' MSGERR : :P1 rows failed ', Fnd_Session_API.Get_Language, lpad(to_char(nvl(error_count_, 0)), 8, ' '));
      message_elapse_ := Language_SYS.Translate_Constant(lu_name_, ' MSGLAPSE : Used :P1 hours and :P2 minutes ', Fnd_Session_API.Get_Language, to_char(elapsed_hours_), to_char(elapsed_minutes_));
      message_avg_    := Language_SYS.Translate_Constant(lu_name_, ' MSGAVG : Average of  :P1 rows per minute ', Fnd_Session_API.Get_Language, to_char(avg_rows_));
   END IF ;
   --
   w_info_ := add_to_w_info_(w_info_,message_start_,msg_sep_,msg_sep_);
   w_info_ := add_to_w_info_(w_info_,message_before_,msg_sep_,msg_sep_);
   w_info_ := add_to_w_info_(w_info_,message_select_,msg_sep_,msg_sep_);
   w_info_ := add_to_w_info_(w_info_,message_method_,msg_sep_,msg_sep_);
   w_info_ := add_to_w_info_(w_info_,message_after_,msg_sep_,msg_sep_);
   IF ( nvl(row_count_,0) != 0 ) THEN
      w_info_ := add_to_w_info_(w_info_,message_count_,msg_sep_,message_commit_,message_error_,msg_sep_,msg_sep_,
                                message_elapse_,msg_sep_,message_avg_,msg_sep_,msg_sep_);
   END IF;
   IF ( mode_ != 'CREATE_TABLE' ) THEN
      message_end_ := Language_SYS.Translate_Constant(lu_name_, ' TIMESTAMP2 : End time - :P1   :P2 ', Fnd_Session_API.Get_Language, end_time_ ,intface_name_ )||msg_sep_||msg_sep_;
   END IF;
   w_info_ := add_to_w_info_(w_info_,message_end_);
   --
   -- Info is saved in a table; must not exceed 4000 chars.
   IF ( length(w_info_) > max_info_length_ ) THEN
      -- Cut info, but always start with message_start_
      start_pos_ := -1 * (max_info_length_ - length(message_start_) - 2 * length(msg_sep_));
      info_ := message_start_||msg_sep_||msg_sep_||substr(w_info_,start_pos_);
   ELSE
      info_ := w_info_;
   END IF;
   Check_Drop_Procedures___( intface_name_);
   -- Make sure hash-marked attributes are reset.
   Intface_Method_List_API.Unmap_Attributes_To_Pos(intface_name_);
END Build_Info_String___;


PROCEDURE Check_Drop_Procedures___ (
   intface_name_ IN  VARCHAR2 )
IS
   rule_value_ intface_rules_tab.rule_value%TYPE;
BEGIN
   IF ( Intface_Rules_API.Rule_Is_Active(
      rule_value_, 'KEEPDYNAMPROC', intface_name_) ) THEN
      NULL;
   ELSE
      Intface_Method_List_API.Drop_All_Dynamic_Proc(intface_name_);
   END IF;
END Check_Drop_Procedures___;

PROCEDURE Drop_Object___ (
   object_name_ IN VARCHAR2,
   type_        IN VARCHAR2)
IS
   stmt_ VARCHAR2(2000) := 'DROP '||type_||' '||object_name_;
BEGIN
   Trace_SYS.Message('Dropping '||type_||' '||object_name_);
   @ApproveDynamicStatement(2014-03-26,chmulk)
   EXECUTE IMMEDIATE stmt_;
EXCEPTION
   WHEN OTHERS THEN
      Trace_SYS.Message('Error when executing : '||stmt_);
      Trace_SYS.Message(SQLERRM);
END Drop_Object___;  

PROCEDURE Cleanup_Tables___ (
   table_name_        IN VARCHAR2,
   view_name_         IN VARCHAR2 )
IS
BEGIN
   Trace_SYS.Message('Cleaning up after execution');
   Drop_Object___(view_name_, 'VIEW');
   Drop_Object___(table_name_,'TABLE');
END Cleanup_Tables___;


PROCEDURE Validate_Source_Columns___ (
   intface_name_  IN VARCHAR2,
   column_name_   IN VARCHAR2,
   default_value_ IN VARCHAR2 )
IS
BEGIN
   IF (Check_Exist_Source___(intface_name_, column_name_)) THEN
      Error_SYS.Record_General(lu_name_, 'SOURCEDUPLIC: Source column should be unique.');
   END IF;
 /*  IF (column_name_ IS NULL AND default_value_ IS NULL) THEN
      Error_SYS.Record_General(lu_name_, 'BLANKCOLUMNS: Either Source column or default value must have a value');
   END IF; */
   IF ((Length(column_name_)) > 30) THEN
      Error_SYS.Record_General(lu_name_, 'INVALIDLENGTH: Source column should not exceed thirty characters');
   END IF;
END Validate_Source_Columns___;


FUNCTION Check_Exist_Source___ (
   intface_name_ IN VARCHAR2,
   column_name_  IN VARCHAR2 ) RETURN BOOLEAN
IS
   dummy_ NUMBER;
   CURSOR exist_control IS
      SELECT 1
      FROM   INTFACE_DETAIL
      WHERE  intface_name = intface_name_
      AND    source_column = column_name_;
BEGIN
   OPEN exist_control;
   FETCH exist_control INTO dummy_;
   IF (exist_control%FOUND) THEN
      CLOSE exist_control;
      RETURN(TRUE);
   END IF;
   CLOSE exist_control;
   RETURN(FALSE);
END Check_Exist_Source___;


PROCEDURE Check_Souce_Coulumns___ (
   intface_name_ IN VARCHAR2 )
IS
   dummy_ NUMBER;
   CURSOR exist_dup_clmns IS
      SELECT     1
      FROM       intface_detail_tab
      WHERE      intface_name = intface_name_
      GROUP BY   source_column
      HAVING     (COUNT(source_column) > 1);
      
   CURSOR exist_inval_length IS
      SELECT     1
      FROM       intface_detail_tab
      WHERE      intface_name = intface_name_
      GROUP BY   source_column
      HAVING     (LENGTH(source_column)> 30); 
      
BEGIN
  
   OPEN exist_dup_clmns;
   FETCH exist_dup_clmns INTO dummy_;
   IF (exist_dup_clmns%FOUND) THEN
      Client_SYS.Add_Info(lu_name_, 'DUPEXIST: Duplicate source columns exist. Please resolve the duplicates before executing');
   END IF;
   CLOSE exist_dup_clmns;

   OPEN exist_inval_length;
   FETCH exist_inval_length INTO dummy_;
   IF (exist_inval_length%FOUND) THEN
      Client_SYS.Add_Info(lu_name_, 'LNGTHINVAL: Source columns exceeding 30 characters exist. Please resolve the source column lengths before executing');
   END IF;
   CLOSE exist_inval_length;

END Check_Souce_Coulumns___;


-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------

-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------

PROCEDURE Start_Job (
   info_         IN OUT VARCHAR2,
   activity_     IN     VARCHAR2,
   intface_name_ IN     VARCHAR2,
   execution_id_ IN     NUMBER  )
IS
   rec_nbr_            NUMBER;
   no_details_         EXCEPTION;
   separator_flag_     VARCHAR2(1);
   attr_               VARCHAR2(32000);
   file_string_        VARCHAR2(32000);
   error_in_create_    EXCEPTION;
   error_in_syntax_    EXCEPTION;
   error_in_index_     EXCEPTION;
   error_create_view_  EXCEPTION;
   error_in_grant_     EXCEPTION;
   ambigous_column_    VARCHAR2(2000);
   line_objid_         VARCHAR2(2000);
   table_name_         VARCHAR2(35);
   index_name_         VARCHAR2(35);
   view_name_          VARCHAR2(30);
   tablespace_data_    VARCHAR2(100) := Fnd_Setting_API.Get_Value('FNDMIG_TBLSPACE_DATA');
   tablespace_index_   VARCHAR2(100) := Fnd_Setting_API.Get_Value('FNDMIG_TBLSPACE_IND');
   ptr_                NUMBER;
   name_               intface_detail.column_name%TYPE;
   value_              VARCHAR2(32000);
   column_list_        VARCHAR2(32000);
   index_list_         VARCHAR2(32000) := NULL;
   value_list_         VARCHAR2(32000);
   create_list_        VARCHAR2(32000);
   describe_msg_       VARCHAR2(32000);
   error_msg_          VARCHAR2(2000);
   describe_tabulator_ VARCHAR2(10) := '       ';
   line_no_            NUMBER := 0;
   status_             intface_job_detail_tab.status%TYPE;
   data_type_          VARCHAR2(30);
   date_format_        VARCHAR2(30) := Client_SYS.Date_Format_;
   create_table_stmt_  VARCHAR2(32000);
   create_view_stmt_   VARCHAR2(2000);
   view_comment_stmt_  VARCHAR2(100);
   grant_stmt_         VARCHAR2(1000);
   drop_index_stmt_    VARCHAR2(32000);
   create_index_stmt_  VARCHAR2(32000);
   insert_stmt_        VARCHAR2(32000);
   i_cur_              INTEGER;
   ins_dummy_          NUMBER;
   error_count_        NUMBER := 0;
   row_count_          NUMBER := 0;
   dummy_nbr_          NUMBER := NULL;
   column_name_        intface_detail.column_name%TYPE;
   length_             NUMBER;
   unique_ind_         VARCHAR2(30);
   intf_format_error_  VARCHAR2(2000);
   intfdet_rec_        intfdet_tab_type;


   CURSOR get_details IS
      SELECT intface_name, column_name, data_type, pos, length,
             decimal_length, amount_factor, default_value,
             default_where, pad_char_left, pad_char_right, change_defaults,
             flags, conv_list_id, source_column
      FROM   intface_detail_tab
      WHERE  intface_name = intface_name_
      AND    (pos > 0 OR default_value IS NOT NULL)
      ORDER BY decode(separator_flag_,
                  '0', attr_seq,
                  '1', decode(pos,'0',999,pos), decode(default_value,null,2,1), column_name);


   CURSOR get_key_columns IS
      SELECT column_name
      FROM   Intface_detail_tab
      WHERE  intface_name = intface_name_
      AND    substr(flags,1,1) IN ('P','K')
      ORDER BY attr_seq, pos, column_name;


   CURSOR Get_String (intface_name_ IN VARCHAR2, execution_id_ IN NUMBER ) IS
      SELECT line_no, file_string, status,  rowid
      FROM   intface_execution_detail_tab
      WHERE  intface_name = intface_name_
      AND    execution_id = execution_id_
      AND    status < '4'
      ORDER BY line_no;


   PROCEDURE Execute_Stmt ( 
      error_msg_    IN OUT VARCHAR2 , 
      count_        IN OUT NUMBER,
      stmt_         IN     VARCHAR2 , 
      return_error_ IN     VARCHAR2 ) 
   IS
   BEGIN
      Intface_Detail_API.Trace_Long_Msg(stmt_);
      IF ( count_ IS NULL ) THEN
         @ApproveDynamicStatement(2011-05-19,jhmase)
         EXECUTE IMMEDIATE stmt_;
      ELSE
         @ApproveDynamicStatement(2011-05-19,jhmase)
         EXECUTE IMMEDIATE stmt_
         USING IN OUT count_;
      END IF;
   EXCEPTION
      WHEN OTHERS THEN
         IF ( return_error_ = 'TRUE' ) THEN
            error_msg_ := SQLERRM;
            Intface_Detail_API.Trace_Long_Msg(error_msg_);
         ELSE
            error_msg_ := NULL;
         END IF;
   END Execute_Stmt;


   FUNCTION Get_Bind_Value (
      date_form_ IN VARCHAR2,
      data_type_ IN VARCHAR2,
      name_      IN VARCHAR2 ) RETURN VARCHAR2
   IS
      bind_value_ VARCHAR2(2000);
   BEGIN
      IF ( data_type_ = 'DATE' ) THEN
         bind_value_ := 'to_date( :'||name_||','||''''||date_form_||''''||')';
      ELSE
         bind_value_ := ' :'||name_;
      END IF;
      RETURN bind_value_;
   END Get_Bind_Value;

   --
BEGIN

   table_name_        := 'IC_'||execution_id_||'_TAB';
   index_name_        := 'IC_'||execution_id_||'_IX1';
   view_name_         := 'IC_'||execution_id_;

   IF (Intface_Header_API.Get_Column_Separator(intface_name_) IS NULL ) THEN
      separator_flag_ := '0';
   ELSE
      separator_flag_ := '1';
   END IF; 

   IF (activity_ = 'EXECUTE') THEN
      UPDATE intface_execution_detail_tab
      SET    executed_by  = Fnd_Session_Api.Get_Fnd_User()
      WHERE  execution_id = execution_id_;      
   END IF;
   --
   -- Loads formatting information from intface header and detail
   -- into global table + variables
   rec_nbr_ := 0;
   -- Reset the PLS/SQL table
   intfdet_rec_.DELETE;
   -- intf_convert_cols_ := NULL;
   FOR intface_detail_rec_ IN get_details LOOP
      IF (intface_detail_rec_.source_column IS NOT NULL) THEN
         rec_nbr_ := rec_nbr_ + 1;
         intfdet_rec_(rec_nbr_).intface_name := intface_detail_rec_.intface_name;
         intfdet_rec_(rec_nbr_).column_name := intface_detail_rec_.source_column;
         intfdet_rec_(rec_nbr_).data_type := intface_detail_rec_.data_type;
         intfdet_rec_(rec_nbr_).pos := intface_detail_rec_.pos;
         intfdet_rec_(rec_nbr_).length := intface_detail_rec_.length;
         intfdet_rec_(rec_nbr_).decimal_length := intface_detail_rec_.decimal_length;
         intfdet_rec_(rec_nbr_).amount_factor := intface_detail_rec_.amount_factor;
         intfdet_rec_(rec_nbr_).default_value := intface_detail_rec_.default_value;
         intfdet_rec_(rec_nbr_).default_where := intface_detail_rec_.default_where;
         intfdet_rec_(rec_nbr_).pad_char_left := Intface_Format_Char_API.Get_Char(intface_detail_rec_.pad_char_left);
         intfdet_rec_(rec_nbr_).pad_char_right := Intface_Format_Char_API.Get_Char(intface_detail_rec_.pad_char_right);
         intfdet_rec_(rec_nbr_).change_defaults := intface_detail_rec_.change_defaults;
         intfdet_rec_(rec_nbr_).flags := intface_detail_rec_.flags;
         intfdet_rec_(rec_nbr_).conv_list_id := intface_detail_rec_.conv_list_id;
      END IF;
   END LOOP;

   rec_nbr_ := 0;
   FOR rec_nbr2_ IN 1..intfdet_rec_.count LOOP
      data_type_   := intfdet_rec_(rec_nbr2_).data_type;
      column_name_ := intfdet_rec_(rec_nbr2_).column_name;
      length_      := intfdet_rec_(rec_nbr2_).length;
      -- Lookup data loaded in global table
      IF (length_ != 0 ) THEN
         -- Dash or space in column name creates trouble 
         -- for CREATE TABLE statement
         IF ( ( instr( column_name_,' ') != 0 ) OR
               ( instr( column_name_,'-') != 0 ) ) THEN
            ambigous_column_ := column_name_;
            RAISE error_in_syntax_;
         END IF;
         -- Build list of columns for the create statement +formatted list of columns to be displayed in info message
         IF (data_type_ = 'VARCHAR2' ) THEN
            create_list_ := create_list_||column_name_||' '||'VARCHAR2('||length_||')'||',';
            describe_msg_ := describe_msg_||describe_tabulator_||column_name_||' '||'VARCHAR2('||length_||')'||','||msg_sep_;
         ELSE
            create_list_ := create_list_||column_name_||' '||data_type_||',';
            describe_msg_ := describe_msg_||describe_tabulator_||column_name_||' '||data_type_||','||msg_sep_;
         END IF;
      END IF;
   END LOOP;

   describe_msg_ := describe_msg_||describe_tabulator_||'IC_ROW_NO NUMBER'||')';
   IF ( length(describe_msg_) > 1000 ) THEN
      -- Do not display list of columns if this is a long statement
      describe_msg_ := 'CREATE TABLE '||table_name_;
   END IF;
      create_list_ := create_list_||'IC_ROW_NO NUMBER,';
      create_list_ := create_list_||'IC_TBL_LINE_NO NUMBER';
   IF ( nvl(tablespace_data_,'*') != '*'  ) THEN
      tablespace_data_ := ' TABLESPACE '||tablespace_data_;
      describe_msg_ := describe_msg_||msg_sep_||tablespace_data_;
   ELSE
      tablespace_data_ := NULL;
   END IF;
      --Complete create statement
   create_table_stmt_ := 'CREATE TABLE '||table_name_||'('||create_list_||') '||
                      tablespace_data_;
               
   create_view_stmt_  := 'CREATE OR REPLACE VIEW '|| view_name_ ||' AS SELECT * FROM '|| table_name_;
   view_comment_stmt_ := 'COMMENT ON TABLE '|| view_name_ ||' IS ''MODULE=IGNORE^''';
   grant_stmt_        := 'GRANT SELECT ON '|| view_name_  || ' TO IFSSYS';
      
   column_list_ := NULL;

      -- Execute create table statement
   Execute_Stmt(error_msg_, dummy_nbr_, create_table_stmt_ , 'TRUE');
   IF ( error_msg_ IS NOT NULL ) THEN
      RAISE error_in_create_;
   END IF;
   -- Create index if rule is active
   IF ( Intface_Rules_API.Rule_Is_Active(unique_ind_, 'CREINDEX', intface_name_) ) THEN
      IF ( nvl(tablespace_index_,'*') != '*'  ) THEN
         tablespace_index_ := ' TABLESPACE '||tablespace_index_;
      ELSE
         tablespace_index_ := NULL;
      END IF;
      -- Get key columns
      FOR keyrec_ IN get_key_columns LOOP
         index_list_ := index_list_||','||keyrec_.column_name;
         END LOOP;
         index_list_  := ltrim(index_list_ ,',');
         drop_index_stmt_ := 'DROP INDEX '||index_name_;
         create_index_stmt_ := 'CREATE '||unique_ind_||' INDEX '||index_name_||' ON '||table_name_||'('||index_list_||')'
                                ||tablespace_index_;
         Execute_Stmt(error_msg_, dummy_nbr_, drop_index_stmt_, 'FALSE');
         Execute_Stmt(error_msg_, dummy_nbr_, create_index_stmt_, 'TRUE');
         IF ( error_msg_ IS NOT NULL ) THEN
            RAISE error_in_index_;
         END IF;
         describe_msg_ := describe_msg_||msg_sep_||
            Language_SYS.Translate_Constant(lu_name_, ' CREIND : Created :P1 index on column :P2 ', Fnd_Session_API.Get_Language, unique_ind_, index_list_ );
   END IF;
   -- Execute create view statement
   Execute_Stmt(error_msg_, dummy_nbr_, create_view_stmt_ , 'TRUE');
   IF ( error_msg_ IS NOT NULL ) THEN
      RAISE error_create_view_;
   END IF;
   -- Execute view comment statement
   Execute_Stmt(error_msg_, dummy_nbr_, view_comment_stmt_ , 'TRUE');
   IF ( error_msg_ IS NOT NULL ) THEN
      RAISE error_create_view_;
   END IF;
   -- Execute grant view statement
   Execute_Stmt(error_msg_, dummy_nbr_, grant_stmt_ , 'TRUE');
   IF ( error_msg_ IS NOT NULL ) THEN
      RAISE error_in_grant_;
   END IF;

   -- Building the attr- and the insert statement to IC table
   OPEN Get_String(intface_name_, execution_id_ );
   LOOP
      FETCH Get_String INTO line_no_, file_string_, status_, line_objid_;
      EXIT WHEN  Get_String%NOTFOUND;

      CLient_Sys.Clear_Attr(attr_);
      row_count_ := row_count_ + 1;

      String_To_Attr___( attr_, file_string_, intf_format_error_, intfdet_rec_, intface_name_ );
      ptr_ := NULL;
      WHILE (Client_SYS.Get_Next_From_Attr(attr_, ptr_, name_, value_)) LOOP
         IF ( value_ IS NOT NULL ) THEN
            -- LOOP on ATTR-string to build insert column list + values list
            -- Look up PL/SQL-table to find data-type for each column
            rec_nbr_ := 0;
            FOR rec_nbr3_ IN 1..intfdet_rec_.count LOOP
               --
               data_type_   := intfdet_rec_(rec_nbr3_).data_type;
               column_name_ := intfdet_rec_(rec_nbr3_).column_name;
               length_      := intfdet_rec_(rec_nbr3_).length;
               IF ( name_ = column_name_ ) THEN
                  IF (length_ != 0 ) THEN
                     IF (intf_format_error_ IS NOT NULL) THEN
                       NULL;             
                     ELSE
                       column_list_ := column_list_||name_||',';
                       value_list_  := value_list_||Get_Bind_Value(date_format_,data_type_, name_)||',';
                     END IF;
                  END IF;
                  EXIT;
               END IF;
            END LOOP;
         END IF;
      END LOOP;
      value_list_ := value_list_||':IC_ROW_NO,';
      column_list_ := column_list_||'IC_ROW_NO,';

      value_list_ := value_list_||':IC_TBL_LINE_NO';
      column_list_ := column_list_||'IC_TBL_LINE_NO';

      insert_stmt_ := 'INSERT INTO '||table_name_||' ('||column_list_||') VALUES ('||value_list_||' )';
      -- Execute insert by DBMS_SQL to be able to parse bind-variables
      ptr_ := NULL;
      i_cur_ := DBMS_SQL.Open_Cursor;
      @ApproveDynamicStatement(2011-05-19,jhmase)
      DBMS_SQL.Parse(i_cur_, insert_stmt_ , DBMS_SQL.native);
         
      -- IF there is an unpack error in the line we will make the IC_ROW_NO > 0 to identify the error row in actual Migration
      IF (intf_format_error_ IS NULL) THEN
         WHILE (Client_SYS.Get_Next_From_Attr(attr_, ptr_, name_, value_)) LOOP
            IF ( value_ IS NOT NULL ) THEN
               value_ := REPLACE(value_, 'NULLVALUE','');
               DBMS_SQL.bind_variable(i_cur_,name_, value_, 2000);
            END IF;
         END LOOP;
         DBMS_SQL.bind_variable(i_cur_,'IC_ROW_NO', row_count_, 2000);
      ELSE
         DBMS_SQL.bind_variable(i_cur_,'IC_ROW_NO', 0, 2000);    
      END IF;
         DBMS_SQL.bind_variable(i_cur_,'IC_TBL_LINE_NO', row_count_, 2000); 
      --
      BEGIN
         ins_dummy_ := DBMS_SQL.Execute(i_cur_);
         DBMS_SQL.Close_Cursor(i_cur_);
         EXCEPTION
            WHEN OTHERS THEN
               error_msg_ := SQLERRM;
               DBMS_SQL.Close_Cursor(i_cur_);
      END;

      value_list_  := NULL;
      column_list_ := NULL;
      error_msg_   := NULL;
      -- Set the error message to the line as unpack error
      IF (intf_format_error_ IS NOT NULL OR error_msg_ IS NOT NULL) THEN
         IF ( error_msg_ IS NOT NULL ) THEN
            intf_format_error_ := error_msg_;
         END IF;
         error_count_ := error_count_ + 1;
         Intface_Execution_Detail_API.Set_Error_Message_(intf_format_error_ , line_objid_ );
         Trace_SYS.Message(' ERROR: '||intf_format_error_ ||' in line '||line_objid_);
      END IF;

      value_list_  := NULL;
      column_list_ := NULL;
      error_msg_   := NULL;              
      @ApproveTransactionStatement(2014-02-18,chmulk)
      COMMIT;
      Trace_SYS.Message(' TRACE>>>>>>> Commit ');
      @ApproveTransactionStatement(2014-02-18,chmulk)
      SAVEPOINT new_job_;
   END LOOP;
   Migrate_Source_Data___(info_, activity_, intface_name_, table_name_, execution_id_);
   
   -- Dropping the temporary IC table and view that has been created 
   Cleanup_Tables___(table_name_, view_name_);

EXCEPTION
   WHEN no_details_ THEN
      Error_SYS.Record_General(lu_name_, 'NODET: No details found for  :P1', intface_name_ );
   WHEN error_in_create_ THEN
      Error_SYS.Record_General(lu_name_, 'JOBRUNERROR: Error in executing job :P1', intface_name_ );
   WHEN OTHERS THEN
      Error_SYS.Record_General(lu_name_, 'LOADERR: Error loading migration job info :P1', SQLERRM );
END Start_Job;


PROCEDURE Validate_Job_Lines (
  intface_name_     IN VARCHAR2,
  source_column_    IN VARCHAR2,
  default_value_    IN VARCHAR2)
IS
BEGIN
   Validate_Source_Columns___(intface_name_, source_column_, default_value_);
END Validate_Job_Lines;


PROCEDURE Validate_Job_Lines_For_Header (
  intface_name_     IN VARCHAR2 )
IS
BEGIN
   Check_Souce_Coulumns___(intface_name_);
END Validate_Job_Lines_For_Header;



