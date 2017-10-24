-----------------------------------------------------------------------------
--
--  Logical unit: IntfaceDetail
--  Component:    FNDMIG
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  141002  AsBaLK Bug #118320- Client column flag taken as _DB column flag in INSERT_OR_UPDATE
--  130706  DUWILK Bug #109774- Display the line number for jobs with errors when IGNOREXEERROR rule is false.
--  130122  JHMASE Bug #108000- Unable to update data using FNDMIG when there are dependent columns
--  120222  DUWILK Bug #101215- Fixed wrong data loading when column and string delimiter include as data(RDTERUNTIME-2247).
--  101108  JHMASE Bug #94105 - Failure in Insert_Or_Update when signle quotes in key value
--  100714  JHMASE Bug #91948 - Added keywords for file names
--  100104  JHMASE Bug #87399 - Changed primary key columns and updateable columns cursors in 
--                              Insert_Or_Update to use job description, not data dictionary
--  091124  NABALK Bug #84218 - Certified the assert safe for dynamic SQLs
--  081028  JHMASE Bug #78118 - Wrong characters set conversion of logfiles
--  080923  JHMASE Bug #76644 - Drop IC table when CREATE_TABLE_FROM_FILE job is removed
--  080507  TRLYNO Bug #73740 - Increased buffersize in Create_Output_File for lengthy queries
--  080404  TRLYNO Big #72912 - Support use of generic variables in backup filename (USER,TIME osv)
--  080307  DUWILK Bug #71239 - Increased buffersize in Create_Output_File for lengthy queries
--  071224  SUMALK Bug #69730 - double quotes in text file import  
--  061202  TRLYNO Bug #61381 - Fixed trimming of leading/trailing blanks
--  061102  JHMASE Bug #61592 - Remove unnecessary references
--  060706  JHMASE Bug #59275 - Concatenated string used in call to Language_SYS
--  060105  TRLYNO Bug #55479 - Added functionality in Data Migration
--  051130  JHMASE Bug #54818 - Source Column length
--  051019  JHMASE Bug #54042 - Fail to migrate data when LU uses 'column names'
--                              longer than 30 characters in action PREPARE.
--  050916  JHMASE Bug #53440 - Fail to migrate separated double byte data with
--                              'Error reading column values by column separator',
--  050615  TRLY   Bug #53249 - Not possible to use INSERT_OR_UPDATE when
--                              primary key is generated.
--                              Use Key-column definitions from IntfaceDetail
--                              instead of ColumnComments
--  050306  TRLY   Bug #50034 - Allowed wildcard in filename on export.
--  041222  JHMASE Bug #48786 - Make it work with double byte
--  040908  JHMASE Bug #46897 - Performance improvments
--  040507  TRLY   Bug #44483 - New rules for truncating values +
--                                bugfix texts starting with letter Y
--  040407  JHMASE Bug #43996 - Max Open Cursors failure on install
--  040325  JHMASE Bug #43733 - Fail to compile on fresh install
--  040210  JHMASE Bug #42618 - Corrections
--  030708  TRLY   Prepared for new module FNDMI
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------
@ApproveGlobalVariable(2014-07-03,wawi)
intf_file_handle_          UTL_FILE.FILE_TYPE;

TYPE varchar_tabtype IS
   TABLE OF VARCHAR2(2000)
   INDEX BY BINARY_INTEGER;

TYPE number_tabtype IS
   TABLE OF NUMBER
   INDEX BY BINARY_INTEGER;

TYPE intdet_record IS RECORD(
   pos_          varchar_tabtype,
   cols_         varchar_tabtype,
   length_       number_tabtype,
   data_type_    varchar_tabtype,
   conv_list_id_ varchar_tabtype,
   ext_attr_     varchar_tabtype);


-------------------- PRIVATE DECLARATIONS -----------------------------------

context_id_file_path_ CONSTANT VARCHAR2(60) := 'INTFACE_DETAIL_API.INTF_FILE_PATH_';

context_id_file_name_ CONSTANT VARCHAR2(60) := 'INTFACE_DETAIL_API.INTF_FILE_NAME_';


-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------

FUNCTION Replace_Keywords___ (
   name_         IN VARCHAR2,
   intface_name_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   new_name_    VARCHAR2(2000) := name_;

   FUNCTION get_date_format RETURN VARCHAR2
   IS
      format_ VARCHAR2(30);
   BEGIN
      SELECT NVL(date_format,'yyyymmdd')
      INTO   format_
      FROM   intface_header_tab
      WHERE  intface_name = intface_name_;
      RETURN format_;
   EXCEPTION
      WHEN OTHERS THEN
         RETURN 'yyyymmdd';   
   END get_date_format;
   
   FUNCTION get_sys_guid RETURN VARCHAR2 
   IS
      a_ VARCHAR2(100);
   BEGIN
      @ApproveDynamicStatement(2010-07-07,jhmase)
      EXECUTE IMMEDIATE 'SELECT SYS_GUID() FROM dual' INTO a_;
      RETURN a_;
   EXCEPTION
      WHEN OTHERS THEN
         RETURN NULL;
   END get_sys_guid;

   FUNCTION get_seq_no RETURN VARCHAR2 
   IS
      no_ NUMBER;
   BEGIN
      SELECT intface_backup_file_seq.nextval
      INTO   no_
      FROM dual;
      RETURN TO_CHAR(no_);
   END get_seq_no;
BEGIN
   IF ( INSTR(new_name_,CHR(38)||'DATF') > 0 ) THEN
      new_name_ := REPLACE(new_name_,CHR(38)||'DATF',TO_CHAR(SYSDATE,get_date_format));
   END IF;
   IF ( INSTR(new_name_,CHR(38)||'DATE') > 0 ) THEN
      new_name_ := REPLACE(new_name_,CHR(38)||'DATE',TO_CHAR(SYSDATE,'yyyymmdd'));
   END IF;
   IF ( INSTR(new_name_,CHR(38)||'USER') > 0 ) THEN
      new_name_ := REPLACE(new_name_,CHR(38)||'USER',Fnd_Session_API.Get_Fnd_User);
   END IF;
   IF ( INSTR(new_name_,CHR(38)||'GUID') > 0 ) THEN
      new_name_ := REPLACE(new_name_,CHR(38)||'GUID',get_sys_guid);
   END IF;
   IF ( INSTR(new_name_,CHR(38)||'TIME') > 0 ) THEN
      new_name_ := REPLACE(new_name_,CHR(38)||'TIME',TO_CHAR(SYSDATE,'hh24miss'));
   END IF;
   IF ( INSTR(new_name_,CHR(38)||'SEQN') > 0 ) THEN
      new_name_ := REPLACE(new_name_,CHR(38)||'SEQN',get_seq_no);
   END IF;
   RETURN new_name_;
END Replace_Keywords___;


@Override
PROCEDURE Prepare_Insert___ (
   attr_ IN OUT VARCHAR2 )
IS
BEGIN
   super(attr_);
   Client_Sys.Add_To_Attr('CHANGE_DEFAULTS', Intface_Change_Defaults_API.Decode('2'), attr_);
END Prepare_Insert___;


@Override
PROCEDURE Check_Insert___ (
   newrec_ IN OUT intface_detail_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS
BEGIN
   IF ( newrec_.data_type NOT IN ( 'NUMBER','DATE','VARCHAR2' ) ) THEN
      Error_SYS.Item_Format(lu_name_, 'DATA_TYPE', newrec_.data_type);
   END IF;
   IF ( newrec_.default_where IS NOT NULL  ) THEN
      IF ( Intface_Direction_API.Encode(
              Intface_Procedures_API.Get_Direction(
                 Intface_Header_API.Get_Procedure_name(newrec_.intface_name))) = '1' ) THEN
         Error_SYS.Item_Update(lu_name_, 'DEFAULT_WHERE' , ' ERRWHERE : Default-where not in use for direction = :P1 ', Intface_Direction_API.Decode('1') );
      END IF;
   END IF;
   IF ( newrec_.change_defaults = '3'  ) THEN
      IF ( Intface_Direction_API.Encode(
              Intface_Procedures_API.Get_Direction(
                 Intface_Header_API.Get_Procedure_name(newrec_.intface_name))) != '2' ) THEN
         Error_SYS.Item_Update(lu_name_, 'CHANGE_DEFAULTS' , ' ERRDEFAULT : :P1 only used when direction = :P2 ',Intface_Change_Defaults_API.Decode('3'), Intface_Direction_API.Decode('2') );
      END IF;
   END IF;
   IF ( indrec_.source_column AND Intface_Header_API.Get_Procedure_Name(newrec_.intface_name)= 'EXCEL_MIGRATION') THEN
      Intface_Execution_Util_API.Validate_Job_Lines(newrec_.intface_name, newrec_.source_column, newrec_.default_value);
   END IF;
   Error_SYS.Check_Not_Null(lu_name_, 'DESCRIPTION', newrec_.description);
   super(newrec_, indrec_, attr_);
END Check_Insert___;


@Override
PROCEDURE Check_Update___ (
   oldrec_ IN     intface_detail_tab%ROWTYPE,
   newrec_ IN OUT intface_detail_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS
   value_ VARCHAR2(4000);
BEGIN
   IF ( newrec_.data_type NOT IN ( 'NUMBER','DATE','VARCHAR2' ) ) THEN
      Error_SYS.Item_Format(lu_name_, 'DATA_TYPE', newrec_.data_type);
   END IF;
   BEGIN
      IF ( Intface_Direction_API.Encode(
         Intface_Procedures_API.Get_Direction(
            Intface_Header_API.Get_Procedure_name(newrec_.intface_name))) NOT IN ('4','6') ) THEN
               
               IF ( newrec_.data_type = 'NUMBER' ) THEN
                  newrec_.default_value := Client_SYS.Attr_Value_To_Number(newrec_.default_value);
               ELSIF ( newrec_.data_type = 'DATE' ) THEN
                  IF ( upper(newrec_.default_value) = 'SYSDATE'  ) THEN
                     NULL;
                  ELSE
                     value_ := Client_SYS.Attr_Value_To_Date(
                        to_char(to_date( newrec_.default_value, nvl(Intface_Header_API.Get_Date_Format(newrec_.intface_name),'xx')),
                        CLient_SYS.Date_Format_) );
                     newrec_.default_value := value_; -- Formatting in Foundation OK, accecpt value;
                  END IF;
               ELSE
                  NULL;
               END IF;
      ELSE
         NULL;
      END IF;
   EXCEPTION
      WHEN OTHERS THEN
         Error_SYS.Item_Format(lu_name_, 'DEFAULT_VALUE', newrec_.default_value);
   END;
   IF ( newrec_.default_where IS NOT NULL  ) THEN
      IF ( Intface_Direction_API.Encode(
         Intface_Procedures_API.Get_Direction(
            Intface_Header_API.Get_Procedure_name(newrec_.intface_name))) = '1' ) THEN
               Error_SYS.Item_Update(lu_name_, 'DEFAULT_WHERE' , ' ERRWHERE : Default-where not in use for direction = :P1 ', Intface_Direction_API.Decode('1') );
      END IF;
   END IF;
   IF ( newrec_.change_defaults = '3'  ) THEN
      IF ( Intface_Direction_API.Encode(
         Intface_Procedures_API.Get_Direction(
            Intface_Header_API.Get_Procedure_name(newrec_.intface_name))) != '2' ) THEN
               Error_SYS.Item_Update(lu_name_, 'CHANGE_DEFAULTS' , ' ERRDEFAULT : :P1 only used when direction = :P2 ',Intface_Change_Defaults_API.Decode('3'), Intface_Direction_API.Decode('2') );
      END IF;
   END IF;
   Error_SYS.Check_Not_Null(lu_name_, 'DESCRIPTION', newrec_.description);
   IF ( indrec_.source_column AND Intface_Header_API.Get_Procedure_Name(newrec_.intface_name)= 'EXCEL_MIGRATION') THEN
      Intface_Execution_Util_API.Validate_Job_Lines(newrec_.intface_name, newrec_.source_column, newrec_.default_value);     
   END IF;
   super(oldrec_, newrec_, indrec_, attr_);
END Check_Update___;

@Override
PROCEDURE Insert___ (
   objid_         OUT VARCHAR2,
   objversion_    OUT VARCHAR2,
   newrec_     IN OUT intface_detail_tab%ROWTYPE,
   attr_       IN OUT VARCHAR2 )
IS
BEGIN
   super(objid_, objversion_, newrec_, attr_);
   -- Translation is only supported for EXCEL_MIGRATION jobs
   IF Intface_Header_API.Get_Procedure_Name(newrec_.intface_name) = 'EXCEL_MIGRATION' THEN
      Basic_Data_Translation_API.Insert_Basic_Data_Translation('FNDMIG', 'IntfaceDetail',
                                                               newrec_.intface_name||'^'||newrec_.column_name||'^'||'DESCRIPTION',
                                                               NULL, newrec_.description);
      Basic_Data_Translation_API.Insert_Basic_Data_Translation('FNDMIG', 'IntfaceDetail',
                                                               newrec_.intface_name||'^'||newrec_.column_name||'^'||'NOTE_TEXT',
                                                               NULL, newrec_.note_text);
   END IF;
END Insert___;

@Override
PROCEDURE Update___ (
   objid_      IN     VARCHAR2,
   oldrec_     IN     intface_detail_tab%ROWTYPE,
   newrec_     IN OUT intface_detail_tab%ROWTYPE,
   attr_       IN OUT VARCHAR2,
   objversion_ IN OUT VARCHAR2,
   by_keys_    IN     BOOLEAN DEFAULT FALSE )
IS
BEGIN
   super(objid_, oldrec_, newrec_, attr_, objversion_, by_keys_);
   IF Intface_Header_API.Get_Procedure_Name(newrec_.intface_name) = 'EXCEL_MIGRATION' THEN
      Basic_Data_Translation_API.Insert_Basic_Data_Translation('FNDMIG', 'IntfaceDetail',
                                                               newrec_.intface_name||'^'||newrec_.column_name||'^'||'DESCRIPTION',
                                                               NULL, newrec_.description, oldrec_.description);
      Basic_Data_Translation_API.Insert_Basic_Data_Translation('FNDMIG', 'IntfaceDetail',
                                                               newrec_.intface_name||'^'||newrec_.column_name||'^'||'NOTE_TEXT',
                                                               NULL, newrec_.note_text, oldrec_.note_text);
   END IF;
END Update___;

@Override
PROCEDURE Delete___ (
   objid_  IN     VARCHAR2,
   remrec_ IN     intface_detail_tab%ROWTYPE )
IS
BEGIN
   super(objid_, remrec_);
   IF Intface_Header_API.Get_Procedure_Name(remrec_.intface_name) = 'EXCEL_MIGRATION' THEN
      Basic_Data_Translation_API.Remove_Basic_Data_Translation('FNDMIG', 'IntfaceDetail', remrec_.intface_name||'^'||remrec_.column_name||'^'||'DESCRIPTION');
      Basic_Data_Translation_API.Remove_Basic_Data_Translation('FNDMIG', 'IntfaceDetail', remrec_.intface_name||'^'||remrec_.column_name||'^'||'NOTE_TEXT');
   END IF;
END Delete___;

-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------

-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

FUNCTION Format_Column_Out_ (
   column_name_        IN VARCHAR2,
   column_value_       IN VARCHAR2,
   data_type_          IN VARCHAR2,
   pos_                IN NUMBER,
   length_             IN NUMBER,
   pad_char_left_      IN VARCHAR2,
   pad_char_right_     IN VARCHAR2,
   decimal_point_      IN VARCHAR2,
   thousand_separator_ IN VARCHAR2,
   column_embrace_     IN VARCHAR2,
   amount_factor_      IN NUMBER,
   decimal_length_     IN NUMBER,
   minus_pos_          IN NUMBER,
   date_format_        IN VARCHAR2,
   intf_format_error_  IN OUT VARCHAR2 ) RETURN VARCHAR2
IS
   --
   column_string_      VARCHAR2(4000);
   number_error_       EXCEPTION;
   date_error_         EXCEPTION;
   error_message_      VARCHAR2(2000);
BEGIN
   --
   IF (data_type_ = 'NUMBER') THEN
      BEGIN
trace_sys.message('Column_name '||column_name_);
         column_string_ := Format_Number_Out_(column_value_, pos_, length_,
            decimal_point_, thousand_separator_, amount_factor_,
            decimal_length_, minus_pos_, pad_char_left_, pad_char_right_);
      EXCEPTION
         WHEN OTHERS THEN
            RAISE number_error_;
      END;
   ELSIF (data_type_ = 'DATE') THEN
      BEGIN
         column_string_ := Format_Date_Out_(column_value_, date_format_,
            pad_char_left_, pad_char_right_, length_);
      EXCEPTION
         WHEN OTHERS THEN
            RAISE date_error_;
      END;
   ELSE
      column_string_ := substr(column_value_,1,length_);
   END IF;
   --
   --
   -- Pad left or right
   --
   IF (pad_char_left_ IS NOT NULL) THEN
      column_string_ := lpad(nvl(column_string_,pad_char_left_), length_, pad_char_left_);
   ELSIF (pad_char_right_ IS NOT NULL) THEN
      column_string_ := rpad(nvl(column_string_,pad_char_right_), length_, pad_char_right_);
   END IF;
   RETURN column_embrace_ || column_string_ || column_embrace_;
EXCEPTION
   WHEN number_error_ THEN
      IF(LENGTH(column_value_) < 500) THEN
         error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
            'COLOUTNUM: Error formatting :P1 with numeric value :P2',
            Fnd_Session_API.Get_Language, column_name_, column_value_);
      ELSE
         error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
            'COLOUTNUM2: Error formatting numeric column :P1',
            Fnd_Session_API.Get_Language, column_name_);
      END IF;
      intf_format_error_ := error_message_;
   WHEN date_error_ THEN
      IF(LENGTH(column_value_) < 500) THEN
         error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
            'COLOUTDAT: Error formatting :P1 with date value :P2',
            Fnd_Session_API.Get_Language, column_name_, column_value_);
      ELSE
         error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
            'COLOUTDAT2: Error formatting date column :P1',
            Fnd_Session_API.Get_Language, column_name_);
      END IF;
      intf_format_error_ := error_message_;
   WHEN OTHERS THEN
      IF(LENGTH(column_value_) < 500) THEN
         error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
            'COLUMNOUT: Error formatting :P1 with value :P2',
            Fnd_Session_API.Get_Language, column_name_, column_value_);
      ELSE
         error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
            'COLUMNOUT2: Error formatting column :P1',
            Fnd_Session_API.Get_Language, column_name_);
      END IF;
      intf_format_error_ := error_message_;
END Format_Column_Out_;


FUNCTION Format_String_Out_ (
   attr_ IN VARCHAR2, 
   intf_format_error_ IN OUT VARCHAR2,
   intf_last_pos_     NUMBER,
   intface_name_ IN VARCHAR2,
   intfdet_rec_  IN Intface_Detail_Util_API.intfdet_tab_type ) RETURN VARCHAR2
IS
   column_value_       VARCHAR2(4000);
   column_string_      VARCHAR2(4000);
   file_string_        VARCHAR2(32000);
   column_name_        INTFACE_DETAIL.column_name%TYPE;
   data_type_          INTFACE_DETAIL.data_type%TYPE;
   conv_list_id_       INTFACE_DETAIL.conv_list_id%TYPE;
   pos_                INTFACE_DETAIL.pos%TYPE;
   length_             INTFACE_DETAIL.length%TYPE;
   pad_char_left_      VARCHAR2(1);
   pad_char_right_     VARCHAR2(1);
   decimal_point_      VARCHAR2(1);
   thousand_separator_ VARCHAR2(1);
   column_embrace_     VARCHAR2(1);
   amount_factor_      INTFACE_DETAIL.amount_factor%TYPE;
   decimal_length_     INTFACE_DETAIL.decimal_length%TYPE;
   default_value_      INTFACE_DETAIL.default_value%TYPE;
   minus_pos_          intface_header.minus_pos%TYPE;
   w_attr_             VARCHAR2(32000);
   error_message_      VARCHAR2(2000);
   convert_value_      VARCHAR2(4000);
   convert_error_      EXCEPTION;
   intf_date_format_   intface_header_tab.date_format%TYPE;
   intf_column_separator_ intface_header_tab.column_separator%TYPE;
BEGIN
   file_string_ := NULL;
   column_string_ := NULL;
   intf_date_format_ := nvl(Intface_Header_APi.Get_Date_Format(intface_name_),'YYYY-MM-DD-HH24.MI.SS');
   intf_column_separator_ := Intface_Format_Char_API.Get_Char(Intface_Header_API.Get_Column_Separator(intface_name_));
   Client_SYS.Clear_Attr(w_attr_);
   w_attr_ := attr_;
   
   decimal_point_      := Intface_Format_Char_API.Get_Char(Intface_Header_API.Get_Decimal_Point(intface_name_));
   thousand_separator_ := Intface_Format_Char_API.Get_Char(Intface_Header_API.Get_Thousand_Separator(intface_name_));
   minus_pos_          := Intface_Header_API.Get_Minus_Pos(intface_name_);
   column_embrace_     := Intface_Format_Char_API.Get_Char(Intface_Header_API.Get_Column_Embrace(intface_name_));
   --
   -- Read from global table
   --
   FOR rec_nbr_ IN 1..intfdet_rec_.count LOOP
      column_value_  := NULL;
      column_string_ := NULL;
      --
      pos_                := intfdet_rec_(rec_nbr_).pos;
      length_             := intfdet_rec_(rec_nbr_).length;
      column_name_        := intfdet_rec_(rec_nbr_).column_name;
      data_type_          := intfdet_rec_(rec_nbr_).data_type;
      pad_char_left_      := intfdet_rec_(rec_nbr_).pad_char_left;
      pad_char_right_     := intfdet_rec_(rec_nbr_).pad_char_right;
      amount_factor_      := intfdet_rec_(rec_nbr_).amount_factor;
      decimal_length_     := intfdet_rec_(rec_nbr_).decimal_length;
      default_value_      := intfdet_rec_(rec_nbr_).default_value;
      conv_list_id_       := intfdet_rec_(rec_nbr_).conv_list_id;
      --
      -- Find value in Attr for actual column
      --
      column_value_ := Client_SYS.Get_Item_Value(column_name_, w_attr_);
      IF ( conv_list_id_ IS NOT NULL ) THEN
         -- Convert values for this column
         BEGIN
            convert_value_ := NULL;
            convert_value_ := Intface_Conv_List_Cols_API.Get_New_Value(conv_list_id_ ,column_value_ );
            column_value_ := nvl(convert_value_, column_value_);
         EXCEPTION
            WHEN OTHERS THEN
               RAISE convert_error_;
         END;
      END IF;
      IF ( column_value_ = 'NULLVALUE' ) THEN
         column_value_ := NULL;
      ELSIF ( column_value_ IS NULL ) THEN
         column_value_ := default_value_;
      END IF;
      -- Format this value to output format
      --
      column_string_ := Format_Column_Out_(column_name_, column_value_,
      data_type_, pos_, length_,
      pad_char_left_, pad_char_right_, decimal_point_,
      thousand_separator_, column_embrace_, amount_factor_,
      decimal_length_, minus_pos_, intf_date_format_, intf_format_error_);
      --
      -- Build filestring
      --
      IF (pos_ = intf_last_pos_ ) THEN
         file_string_ := file_string_ || column_string_;
      ELSE
         file_string_ := file_string_ || column_string_ || intf_column_separator_;
      END IF;
      --
      column_string_ := NULL;
      --
   END LOOP;
   RETURN file_string_;
   --
EXCEPTION
   WHEN convert_error_ THEN
      IF(LENGTH(column_value_) < 500) THEN
         error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
            'STRINGOUTCONV: Error converting value :P2 for :P1',
            Fnd_Session_API.Get_Language, column_name_, column_value_);
      ELSE
         error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
            'STRINGOUTCONV2: Error converting column :P1',
            Fnd_Session_API.Get_Language, column_name_);
      END IF;
      intf_format_error_ := error_message_;
   WHEN OTHERS THEN
      IF(LENGTH(column_value_) < 500) THEN
         error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
            'STRINGOUT: Error formatting :P1 with value :P2',
            Fnd_Session_API.Get_Language, column_name_, column_value_);
      ELSE
         error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
            'STRINGOUT2: Error formatting column :P1',
            Fnd_Session_API.Get_Language, column_name_);
      END IF;
      intf_format_error_ := error_message_;
END Format_String_Out_;


FUNCTION Format_Date_Out_ (
   column_value_   IN VARCHAR2,
   date_format_    IN VARCHAR2,
   pad_char_left_  IN VARCHAR2,
   pad_char_right_ IN VARCHAR2,
   length_         IN NUMBER ) RETURN VARCHAR2
IS
   column_string_  VARCHAR2(30);
BEGIN
   --
   -- Format date
   --
   column_string_ := to_char(to_date(column_value_,'YYYY-MM-DD-HH24.MI.SS'), date_format_);
   --
   -- Pad left or right
   --
   IF (pad_char_left_ IS NOT NULL) THEN
      column_string_ := lpad(column_string_, length_, pad_char_left_);
   ELSIF (pad_char_right_ IS NOT NULL) THEN
      column_string_ := rpad(column_string_, length_, pad_char_right_);
   END IF;
   --
   -- Return formatted value
   --
   RETURN column_string_;
END Format_Date_Out_;


FUNCTION Format_Number_In_ (
   column_value_       IN VARCHAR2,
   decimal_point_      IN VARCHAR2,
   thousand_separator_ IN VARCHAR2,
   amount_factor_      IN NUMBER,
   decimal_length_     IN NUMBER,
   minus_pos_          IN NUMBER ) RETURN NUMBER
IS
   conv_factor_         NUMBER;
   local_column_value_  VARCHAR2(20);
   number_value_        NUMBER;
BEGIN
   --
   -- IF number is negative, remove minus-sign (added later)
   --
   IF (instr(column_value_, '-') != 0) THEN
      conv_factor_ := -1;
      local_column_value_ := translate(column_value_, '1-', '1');
   ELSE
      conv_factor_ := 1;
      -- Remove plus-sign if any
      local_column_value_ := translate(column_value_, '1+', '1');
   END IF;
   --
   -- Remove thousand separator
   --
   IF (thousand_separator_ IS NOT NULL) THEN
      local_column_value_ := translate(local_column_value_, '1' || thousand_separator_, '1');
   END IF;
   --
   -- Replace decimal point
   --
   IF (nvl(decimal_point_, '.') != '.') THEN
      local_column_value_ := translate(local_column_value_, '1' || decimal_point_, '1.');
   END IF;
   --
   -- Convert amount according to factor and sign
   --
   IF decimal_length_ IS NOT NULL THEN
      IF (nvl(amount_factor_, 0) != 0) THEN
         number_value_ := (round((to_number(local_column_value_)/amount_factor_), decimal_length_)* conv_factor_);
      ELSE
         number_value_ := (round(to_number(local_column_value_), decimal_length_)* conv_factor_);
      END IF;
   ELSE
      IF (nvl(amount_factor_, 0) != 0) THEN
         number_value_ := ((to_number(local_column_value_)/amount_factor_)* conv_factor_);
      ELSE
         number_value_ := ((to_number(local_column_value_))* conv_factor_);
      END IF;
   END IF;

   RETURN number_value_;
END Format_Number_In_;


FUNCTION Format_Number_Out_ (
   column_value_       IN VARCHAR2,
   pos_                IN NUMBER,
   length_             IN NUMBER,
   decimal_point_      IN VARCHAR2,
   thousand_separator_ IN VARCHAR2,
   amount_factor_      IN NUMBER,
   decimal_length_     IN NUMBER,
   minus_pos_          IN NUMBER,
   pad_char_left_      IN VARCHAR2,
   pad_char_right_     IN VARCHAR2 ) RETURN VARCHAR2
IS
   decimal_pos_        NUMBER;
   integ_value_        VARCHAR2(100);
   decimal_value_      VARCHAR2(100);
   column_string_      VARCHAR2(4000);
   number_is_negative_ BOOLEAN := FALSE;
   index_length_       NUMBER;
   build_value_        VARCHAR2(100) := NULL;
   local_column_value_ VARCHAR2(100);
BEGIN
   --
   -- Round value according to factor and decimal length
   --
   IF ( nvl(amount_factor_, 1) != 1 ) THEN
      local_column_value_ := round((column_value_/nvl(amount_factor_, 1)),
         nvl(decimal_length_, 0));
   ELSE
      local_column_value_ := column_value_;
   END IF;
   --
   -- IF number is negative, remove minus-sign (added later)
   --
   IF (instr(local_column_value_, '-') != 0) THEN
      number_is_negative_ := TRUE;
      local_column_value_ := to_char(abs(to_number(local_column_value_)));
   END IF;
   --
   -- Split numbers before and after comma-sign
   --
   decimal_pos_ := instr(local_column_value_, '.');
   IF (decimal_pos_ != 0) THEN
      integ_value_ := substr(local_column_value_, 1, decimal_pos_-1);
      decimal_value_ := substr(local_column_value_, decimal_pos_+1,
      length(local_column_value_)-decimal_pos_);
   ELSE
      integ_value_   := local_column_value_;
      decimal_value_ := NULL;
   END IF;
   --
   -- Place thousand-separator in rigth position
   --
   IF (thousand_separator_ IS NOT NULL) THEN
      IF (length(integ_value_) > 3 ) THEN
         index_length_ := length(integ_value_);
         WHILE (index_length_ >= 4) LOOP
            build_value_ := thousand_separator_ ||
            substr(integ_value_, index_length_-2, 3) || build_value_;
            index_length_ := index_length_ - 3;
         END LOOP;
         build_value_ := substr(integ_value_, 1, index_length_) || build_value_;
      ELSE
         build_value_ := integ_value_;
      END IF;
   ELSE
      build_value_ := integ_value_;
   END IF;
   --
   -- Place decimal-point
   --
   IF (decimal_length_ IS NULL ) THEN
      IF ( decimal_value_ IS NOT NULL ) THEN
         column_string_ := build_value_ || decimal_point_ || decimal_value_;
      ELSE
         column_string_ := build_value_;
      END IF;
   ELSIF ( decimal_length_ > 0 ) THEN
      decimal_value_ := nvl(decimal_value_,'0');
      IF ( length(decimal_value_) < decimal_length_ ) THEN
         decimal_value_ := rpad(decimal_value_ , decimal_length_, '0');
      ELSIF ( length(decimal_value_) > decimal_length_ ) THEN
         decimal_value_ := substr(decimal_value_, 1, decimal_length_);
      END IF;
      column_string_ := nvl(build_value_,'0') || decimal_point_ || decimal_value_;
   ELSIF ( decimal_length_  = 0 ) THEN
      column_string_ := build_value_;
   END IF;
   --
   -- Place pad-characters and minus-sign.
   --
   -- Left-padded string:
   IF ( pad_char_left_ IS NOT NULL ) THEN
      IF ( number_is_negative_ ) THEN
         IF ( nvl(minus_pos_, -1) = 1 ) THEN
            column_string_ := '-' || lpad((column_string_), length_ -1, pad_char_left_);
         ELSIF ( nvl(minus_pos_, -1) = 0 ) THEN
            column_string_ := lpad((column_string_ || '-'), length_ , pad_char_left_);
         ELSE
            column_string_ := lpad(('-' || column_string_), length_ , pad_char_left_);
         END IF;
      ELSE
         column_string_ := lpad(column_string_, length_, pad_char_left_);
      END IF;
      --
      -- Right-padded string:
      --
   ELSIF ( pad_char_right_ IS NOT NULL ) THEN
      IF ( number_is_negative_ ) THEN
         IF ( nvl(minus_pos_, 999) = 0 ) THEN
            column_string_ := rpad((column_string_ || '-'), length_, pad_char_right_);
         ELSIF ( nvl(minus_pos_, 99999) = 99999 ) THEN
            column_string_ := '-' || rpad(column_string_, length_ -1, pad_char_right_);
         ELSE
            column_string_ := rpad((column_string_), length_ -1, pad_char_right_) || '-';
         END IF;
      ELSE
         column_string_ := rpad(column_string_, length_, pad_char_right_);
      END IF;
      --
      -- No padding
      --
   ELSE
      IF ( number_is_negative_ ) THEN
         IF ( nvl(minus_pos_, -1) = 0 ) THEN
            column_string_ := (column_string_ || '-');
         ELSE
            column_string_ := ('-' || column_string_);
         END IF;
      END IF;
   END IF;
   --
   -- Return formatted value
   --
   RETURN column_string_;
END Format_Number_Out_;


PROCEDURE Unpack_String_By_Pos_ (
   attr_        IN OUT VARCHAR2,
   file_string_ IN     VARCHAR2,
   intf_format_error_ IN OUT VARCHAR2,
   intface_name_      IN VARCHAR2,
   intfdet_rec_       IN Intface_Detail_Util_API.intfdet_tab_type )
IS
   --
   column_name_        INTFACE_DETAIL.column_name%TYPE;
   data_type_          INTFACE_DETAIL.data_type%TYPE;
   pos_                INTFACE_DETAIL.pos%TYPE;
   length_             INTFACE_DETAIL.length%TYPE;
   pad_char_left_      VARCHAR2(1);
   pad_char_right_     VARCHAR2(1);
   decimal_point_      VARCHAR2(1);
   thousand_separator_ VARCHAR2(1);
   column_embrace_     VARCHAR2(1);
   amount_factor_      INTFACE_DETAIL.amount_factor%TYPE;
   decimal_length_     INTFACE_DETAIL.decimal_length%TYPE;
   minus_pos_          intface_header.minus_pos%TYPE;
   default_value_      INTFACE_DETAIL.default_value%TYPE;
   conv_list_id_       INTFACE_DETAIL.conv_list_id%TYPE;
   flags_              INTFACE_DETAIL.flags%TYPE;
   --
   convert_value_ VARCHAR2(4000);
   column_value_  VARCHAR2(4000);
   string_value_  VARCHAR2(4000);
   number_value_  NUMBER;
   date_value_    DATE;
   --
   convert_error_ EXCEPTION;
   default_error_ EXCEPTION;
   number_error_  EXCEPTION;
   date_error_    EXCEPTION;
   string_error_  EXCEPTION;
   error_message_ VARCHAR2(2000);
   --
   intf_date_format_ intface_header_tab.date_format%TYPE;
   intf_procedure_name_ intface_header_tab.procedure_name%TYPE;
BEGIN
   intf_date_format_ := nvl(Intface_Header_APi.Get_Date_Format(intface_name_),'YYYY-MM-DD-HH24.MI.SS');
   intf_procedure_name_ := Intface_Header_API.Get_Procedure_Name(intface_name_);
   decimal_point_      := Intface_Format_Char_API.Get_Char(Intface_Header_API.Get_Decimal_Point(intface_name_));
   thousand_separator_ := Intface_Format_Char_API.Get_Char(Intface_Header_API.Get_Thousand_Separator(intface_name_));
   minus_pos_          := Intface_Header_API.Get_Minus_Pos(intface_name_);
   column_embrace_     := Intface_Format_Char_API.Get_Char(Intface_Header_API.Get_Column_Embrace(intface_name_));
   -- Reading global table
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
      decimal_length_     := intfdet_rec_(rec_nbr_).decimal_length;
      default_value_      := intfdet_rec_(rec_nbr_).default_value;
      flags_              := intfdet_rec_(rec_nbr_).flags;
      conv_list_id_       := intfdet_rec_(rec_nbr_).conv_list_id;
      --
      --
      -- IF length equals zero, do nothing; this field should not be loaded.
      --
      IF ( ( nvl(length_, 0) > 0)) THEN
         IF (default_value_ IS NOT NULL) THEN
            --
            -- IF this is a column from file, add default value only if column is NULL.
            --
            BEGIN
               IF ( pos_ > 0 ) THEN
                  column_value_ := nvl(ltrim(substr(file_string_, pos_, length_)),
                  Format_Default_Value_(default_value_, data_type_, intf_date_format_));
               ELSE
                  column_value_ := Format_Default_Value_(default_value_, data_type_, intf_date_format_);
               END IF;
            EXCEPTION
               WHEN OTHERS THEN
                  RAISE default_error_;
            END;
         ELSE
            column_value_ := substr(file_string_, pos_, length_);
            --
         END IF;
         -- Check if column embrace exists
         IF ( column_embrace_ IS NOT NULL ) THEN
            IF ( nvl(substr(column_value_,1,1),'X') = column_embrace_ ) THEN
               column_value_ := rtrim(ltrim(column_value_, column_embrace_),column_embrace_);
            END IF;
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
                  convert_value_ := Intface_Conv_List_Cols_API.Get_New_Value(conv_list_id_ ,column_value_ );
                  column_value_ := nvl(convert_value_, column_value_);
               EXCEPTION
                  WHEN OTHERS THEN
                     RAISE convert_error_;
               END;
         END IF;
         --
         IF (ltrim(column_value_) IS NOT NULL ) THEN
            IF ( column_value_ = 'NULLVALUE' ) THEN
               IF ( intf_procedure_name_ = 'CREATE_TABLE_FROM_FILE' ) THEN
                  Client_Sys.Add_To_Attr(column_name_, 'NULLVALUE' , attr_);
               ELSIF ( intf_procedure_name_ = 'INSERT_BY_METHOD_NEW' ) THEN
                  NULL;
               ELSE
                  Client_Sys.Add_To_Attr(column_name_, '' , attr_);
               END IF;
            ELSIF ( data_type_ = 'NUMBER' ) THEN
               BEGIN
                  number_value_ := Format_Number_In_(column_value_, decimal_point_,
                  thousand_separator_, amount_factor_, decimal_length_, minus_pos_);
               EXCEPTION
                  WHEN OTHERS THEN
                     RAISE number_error_;
               END;
               Client_Sys.Add_To_Attr(column_name_, number_value_, attr_);
            ELSIF ( data_type_ = 'DATE' ) THEN
               BEGIN
                  date_value_ := Format_Date_In_(column_value_, intf_date_format_);
                  Client_Sys.Add_To_Attr(column_name_, date_value_, attr_);
               EXCEPTION
                  WHEN OTHERS THEN
                     RAISE date_error_;
               END;
            ELSE
               BEGIN
                  string_value_ := Format_String_In_(intface_name_, column_value_);
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
   --
EXCEPTION
   WHEN default_error_ THEN
      error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
         'UNPACKPOSDEF: Error formatting default value :P2 for :P1',
         Fnd_Session_API.Get_Language, column_name_, default_value_);
      intf_format_error_ := error_message_;
   WHEN convert_error_ THEN
      error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
         'UNPACKPOSCONV: Error converting value :P2 for :P1',
         Fnd_Session_API.Get_Language, column_name_, default_value_);
      intf_format_error_ := error_message_;
   WHEN number_error_ THEN
      IF(LENGTH(column_value_) < 500) THEN
         error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
            'UNPACKPOSNUM: Error formatting numeric value :P2 for :P1',
            Fnd_Session_API.Get_Language, column_name_, column_value_);
      ELSE
         error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
            'UNPACKPOSNUM2: Error formatting numeric column :P1',
            Fnd_Session_API.Get_Language, column_name_);
      END IF;
      intf_format_error_ := error_message_;
   WHEN date_error_ THEN
      IF(LENGTH(column_value_) < 500) THEN
         error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
            'UNPACKPOSDAT: Error formatting date value :P2 for :P1',
            Fnd_Session_API.Get_Language, column_name_, column_value_);
      ELSE
         error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
            'UNPACKPOSDAT2: Error formatting date column :P1',
            Fnd_Session_API.Get_Language, column_name_);
      END IF;
      intf_format_error_ := error_message_;
   WHEN string_error_ THEN
      IF(LENGTH(column_value_) < 500) THEN
         error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
            'UNPACKPOSSTR: Error formatting string value :P2 for :P1',
            Fnd_Session_API.Get_Language, column_name_, column_value_);
      ELSE
         error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
            'UNPACKPOSSTR2: Error formatting string column :P1',
            Fnd_Session_API.Get_Language, column_name_);
      END IF;
      intf_format_error_ := error_message_;
   WHEN OTHERS THEN
      IF(LENGTH(column_value_) < 500) THEN
         error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
            'UNPACKPOS: Error occured while unpacking :P1 with value :P2',
            Fnd_Session_API.Get_Language, column_name_, column_value_);
      ELSE
         error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
            'UNPACKPOS2: Error occured while unpacking column :P1',
            Fnd_Session_API.Get_Language, column_name_);
      END IF;
      intf_format_error_ := error_message_;
END Unpack_String_By_Pos_;


PROCEDURE Unpack_String_By_Separator_ (
   attr_        IN OUT VARCHAR2,
   file_string_ IN     VARCHAR2,
   intf_format_error_ IN OUT VARCHAR2,
   intface_name_      IN VARCHAR2,
   intfsorted_cols_   IN Intface_Detail_Util_API.intfdet_col_tab_type,
   intfdet_rec_       IN Intface_Detail_Util_API.intfdet_tab_type,
   trunc_val_         IN BOOLEAN )
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
   convert_value_ VARCHAR2(4000);
   column_value_  VARCHAR2(4000);
   string_value_  VARCHAR2(4000);
   number_value_  NUMBER;
   date_value_    DATE;
   --
   from_          NUMBER;
   ptr_           NUMBER;
   -- New split of string
   TYPE field_tab_type IS
      TABLE OF VARCHAR2(4000) INDEX BY BINARY_INTEGER;
   fields_rec_    field_tab_type;
   fields_count_  INTEGER;
   field_         VARCHAR2(4000);
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
   pos_seq_       NUMBER;
   sort_attr_     VARCHAR2(32000);
   counter_       NUMBER;
   --
   intf_date_format_ intface_header_tab.date_format%TYPE;
   intf_procedure_name_ intface_header_tab.procedure_name%TYPE;
   
BEGIN
   --
   intf_date_format_ := nvl(Intface_Header_APi.Get_Date_Format(intface_name_),'YYYY-MM-DD-HH24.MI.SS');
   intf_procedure_name_ := Intface_Header_API.Get_Procedure_Name(intface_name_);
   --
   decimal_point_      := Intface_Format_Char_API.Get_Char(Intface_Header_API.Get_Decimal_Point(intface_name_));
   thousand_separator_ := Intface_Format_Char_API.Get_Char(Intface_Header_API.Get_Thousand_Separator(intface_name_));
   column_separator_   := Intface_Format_Char_API.Get_Char(Intface_Header_API.Get_Column_Separator(intface_name_));
   minus_pos_          := Intface_Header_APi.Get_Minus_Pos(intface_name_);
   column_embrace_     := Intface_Format_Char_API.Get_Char(Intface_Header_API.Get_Column_Embrace(intface_name_));
   -- Split line from file into fields, based on column_separator
   field_ := NULL;
   text_on_ := FALSE;
   fields_count_ := 0;
   counter_ := 0;
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
               IF (SUBSTR(file_string_, i_ - 2, 1) in (column_embrace_, column_separator_)) AND (SUBSTR(file_string_, i_ - 1, 1) = column_embrace_)  THEN
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
      decimal_length_     := intfdet_rec_(rec_nbr_).decimal_length;
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
      --
      IF ( nvl(length_, 0) =  -1 ) THEN
         -- This column had no value on file, check if default value IS NULL
         --
         IF (default_value_ IS NOT NULL) THEN
            BEGIN
               column_value_ := nvl(ltrim(column_value_), Format_Default_Value_(default_value_, data_type_, intf_date_format_));
            EXCEPTION
               WHEN OTHERS THEN
                  RAISE default_error_;
            END;
            length_ := intfdet_rec_(rec_nbr_).length; -- Reset correct length
         END IF;
      END IF;
      --
      -- IF length equals zero, do nothing; this field should not be loaded.
      --
      IF ( ( nvl(length_, 0) > 0)) THEN
         --
         -- Add default value if column_value_ IS NULL
         --
         IF (default_value_ IS NOT NULL) THEN
            BEGIN
               column_value_ := nvl(ltrim(column_value_), Format_Default_Value_(default_value_, data_type_, intf_date_format_));
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
               IF ( intf_procedure_name_ = 'CREATE_TABLE_FROM_FILE' ) THEN
                  Client_Sys.Add_To_Attr(column_name_, 'NULLVALUE' , attr_);
               ELSIF ( intf_procedure_name_ = 'INSERT_BY_METHOD_NEW' ) THEN
                  NULL;
               ELSE
                  Client_Sys.Add_To_Attr(column_name_, '' , attr_);
               END IF;
            ELSIF ( data_type_ = 'NUMBER' ) THEN
               BEGIN
                  number_value_ := Format_Number_In_(column_value_, decimal_point_,
                  thousand_separator_, amount_factor_, decimal_length_, minus_pos_);
               EXCEPTION
                  WHEN OTHERS THEN
                     RAISE number_error_;
               END;
               Client_Sys.Add_To_Attr(column_name_, number_value_, attr_);
            ELSIF ( data_type_ = 'DATE' ) THEN
               BEGIN
                  date_value_ := Format_Date_In_(column_value_, intf_date_format_);
               EXCEPTION
                  WHEN OTHERS THEN
                     RAISE date_error_;
               END;
               Client_Sys.Add_To_Attr(column_name_, date_value_, attr_);
            ELSE
            IF ( length(column_value_) > length_ ) THEN
               IF ( trunc_val_ ) THEN
                  -- Only read the length specified for column.
                  -- Rule for truncation is active
                  column_value_ := substr(column_value_,1,length_);
               ELSE
                  RAISE length_error_;
               END IF;
            END IF;
               BEGIN
                  string_value_ := Format_String_In_(intface_name_, column_value_ );
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
   --
   -- Not necessary to sort the attr string in 'CREATE_TABLE_FROM_FILE'
   IF (intf_procedure_name_ != 'CREATE_TABLE_FROM_FILE') THEN
      Client_SYS.Clear_Attr(sort_attr_); -- Sort attr-string
      FOR rec_nbr_ IN 1..intfsorted_cols_.count LOOP
         From_Attr_To_Attr(sort_attr_, attr_, intfsorted_cols_(rec_nbr_));
      END LOOP;
      attr_ := sort_attr_;
   END IF;
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
      IF(LENGTH(column_value_) < 500) THEN
         error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
            'UNPACKSEPNUM: Error formatting numeric value :P2 for :P1',
            Fnd_Session_API.Get_Language, column_name_, column_value_);
      ELSE
         error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
            'UNPACKSEPNUM2: Error formatting numeric column :P1',
            Fnd_Session_API.Get_Language, column_name_);
      END IF;
      intf_format_error_ := error_message_;
   WHEN date_error_ THEN
      IF(LENGTH(column_value_) < 500) THEN
         error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
            'UNPACKSEPDAT: Error formatting date value :P2 for :P1',
            Fnd_Session_API.Get_Language, column_name_, column_value_);
      ELSE
         error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
            'UNPACKSEPDAT2: Error formatting date column :P1',
            Fnd_Session_API.Get_Language, column_name_);
      END IF;
      intf_format_error_ := error_message_;
   WHEN string_error_ THEN
      IF(LENGTH(column_value_) < 500) THEN
         error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
            'UNPACKSEPSTR: Error formatting string value :P2 for :P1',
             Fnd_Session_API.Get_Language, column_name_, column_value_);
      ELSE
         error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
            'UNPACKSEPSTR2: Error formatting string column :p1',
            Fnd_Session_API.Get_Language, column_name_);
      END IF;
      intf_format_error_ := error_message_;
   WHEN length_error_ THEN
      IF(LENGTH(column_value_) < 500) THEN
         error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
            'TOOLONG: Specified length :P2 for column :P1 is exceeded by value :P3. Rule TRUNCVAL may solve this.',
            Fnd_Session_API.Get_Language, column_name_, length_, column_value_);
      ELSE
         error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
            'TOOLONG2: Specified length :P2 for column :P1 is exceeded. Rule TRUNCVAL may solve this.',
            Fnd_Session_API.Get_Language, column_name_, length_);
      END IF;
      intf_format_error_ := error_message_;
   WHEN OTHERS THEN
      IF(LENGTH(column_value_) < 500) THEN
         error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
            'UNPACKSEP: Error occured while unpacking :P1 with value :P2',
            Fnd_Session_API.Get_Language, column_name_, column_value_);
      ELSE
         error_message_ := Language_SYS.Translate_Constant( lu_name_ ,
            'UNPACKSEP2: Error occured while unpacking column :P1',
            Fnd_Session_API.Get_Language, column_name_);
      END IF;
      intf_format_error_ := error_message_;
END Unpack_String_By_Separator_;


FUNCTION Format_Date_In_ (
   column_value_ IN VARCHAR2,
   date_format_  IN VARCHAR2 ) RETURN DATE
IS
   date_value_    DATE;
BEGIN
   date_value_ := to_date(column_value_, translate(date_format_, 'Yy', 'Rr'));
   RETURN date_value_;
END Format_Date_In_;


FUNCTION Format_String_In_ (
   intface_name_   IN VARCHAR2,
   column_value_   IN VARCHAR2) RETURN VARCHAR2
IS
   string_value_  VARCHAR2(4000);
   rule_value_    VARCHAR2(4000);
BEGIN
   IF ( Intface_Rules_API.Rule_Is_Active(
      rule_value_, 'KEEPBLANKS', intface_name_) ) THEN
      string_value_ := column_value_;   
   ELSE
      -- Trim off leading or trailing spaces
      string_value_ := ltrim(rtrim(column_value_));
   END IF;
   RETURN string_value_;
END Format_String_In_;


FUNCTION Format_Default_Value_ (
   default_value_ IN VARCHAR2,
   data_type_     IN VARCHAR2,
   date_format_   IN VARCHAR2 ) RETURN VARCHAR2
IS
   return_value_  VARCHAR2(2000);
BEGIN
   --
   -- Allow 'sysdate' as default date value in. Convert -YY to -RR in format.
   --
   IF (data_type_ = 'DATE') THEN
      IF (upper(default_value_) = 'SYSDATE' ) THEN
         return_value_ := to_char(sysdate, translate(date_format_, 'Yy', 'Rr'));
      ELSE
         return_value_ := default_value_;
      END IF;
   ELSE
      return_value_ := default_value_;
   END IF;
   RETURN return_value_;
END Format_Default_Value_;


FUNCTION Exec_Base_Method_ (
   info_           IN OUT VARCHAR2,
   objid_          IN OUT VARCHAR2,
   objversion_     IN OUT VARCHAR2,
   attr_           IN OUT VARCHAR2,
   action_         IN     VARCHAR2 ,
   mode_           IN     VARCHAR2, 
   method_error_   IN OUT VARCHAR2,
   intf_insert_h_cur_  IN INTEGER,
   intf_update_h_cur_  IN INTEGER) RETURN BOOLEAN
IS
   --
   h_cur_           INTEGER;
   dummy_           NUMBER;
   error_in_method_ EXCEPTION;
BEGIN
   @ApproveTransactionStatement(2013-11-20,wawilk)
   SAVEPOINT base_rec_;
   method_error_ := null;
   -- Mode is set in calling method
   IF ( mode_ = 'INSERT' ) THEN
      h_cur_ := intf_insert_h_cur_;
   ELSIF ( mode_ = 'UPDATE' ) THEN
      h_cur_ := intf_update_h_cur_;
   END IF;
   DBMS_SQL.bind_variable(h_cur_,'info', info_, 2000);
   DBMS_SQL.bind_variable(h_cur_,'objid', objid_, 2000);
   DBMS_SQL.bind_variable(h_cur_,'objversion', objversion_, 2000);
   DBMS_SQL.bind_variable(h_cur_,'attr', attr_, 32000);
   DBMS_SQL.bind_variable(h_cur_,'action', action_, 32000);
   BEGIN
      dummy_ := DBMS_SQL.Execute(h_cur_);
   EXCEPTION
      WHEN OTHERS THEN
         @ApproveTransactionStatement(2013-11-20,wawilk)
         ROLLBACK TO SAVEPOINT base_rec_;
         info_ := SQLERRM;
         method_error_ := info_;
         RAISE error_in_method_;
   END;
   DBMS_SQL.variable_value(h_cur_,'info', info_);
   DBMS_SQL.variable_value(h_cur_,'objid', objid_);
   DBMS_SQL.variable_value(h_cur_,'objversion', objversion_);
   DBMS_SQL.variable_value(h_cur_,'attr', attr_);
   RETURN TRUE;
EXCEPTION
   WHEN error_in_method_ THEN
      RETURN FALSE;
   WHEN OTHERS THEN
      info_ := SQLERRM;
      method_error_ := info_;
      RETURN FALSE;
END Exec_Base_Method_;


PROCEDURE Set_Current_File_Path_ (
   intf_file_path_ IN VARCHAR2)
IS
BEGIN
   App_Context_SYS.Set_Value(context_id_file_path_,intf_file_path_);
END Set_Current_File_Path_;


PROCEDURE Set_Current_File_Name_ (
   intf_file_name_ IN VARCHAR2)
IS
BEGIN
   App_Context_SYS.Set_Value(context_id_file_name_,intf_file_name_);
END Set_Current_File_Name_;


-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------

@UncheckedAccess
FUNCTION Get_Current_File_Path RETURN VARCHAR2
IS
BEGIN
   RETURN App_Context_SYS.Find_Value(context_id_file_path_);
END Get_Current_File_Path; 




@UncheckedAccess
FUNCTION Get_Current_File_Name RETURN VARCHAR2
IS
BEGIN
   RETURN App_Context_SYS.Find_Value(context_id_file_name_);
END Get_Current_File_Name;




FUNCTION Attr_To_String (
   string_value_ IN OUT VARCHAR2,
   attr_         IN     VARCHAR2,
   intf_last_pos_ IN NUMBER,
   intface_name_ IN VARCHAR2,
   intfdet_rec_  IN Intface_Detail_Util_API.intfdet_tab_type ) RETURN BOOLEAN
IS
   intf_format_error_ VARCHAR2(2000);
BEGIN
   intf_format_error_ := NULL;
   string_value_ := Format_String_Out_( attr_, intf_format_error_, intf_last_pos_, intface_name_, intfdet_rec_);
   IF ( intf_format_error_ IS NULL ) THEN
      RETURN TRUE;
   ELSE
      RETURN FALSE;
   END IF;
END Attr_To_String;


FUNCTION String_To_Attr (
   attr_        IN OUT VARCHAR2,
   file_string_       IN     VARCHAR2,
   intf_format_error_ IN OUT VARCHAR2,
   intface_name_ IN VARCHAR2,
   intfsorted_cols_ IN Intface_Detail_Util_API.intfdet_col_tab_type,
   intfdet_rec_     IN Intface_Detail_Util_API.intfdet_tab_type,
   trunc_val_       IN BOOLEAN ) RETURN BOOLEAN
IS
   trim_string_ VARCHAR2(32000);
   intf_column_separator_ intface_header_tab.column_separator%TYPE;
BEGIN
   intf_format_error_ := NULL;
   intf_column_separator_ := Intface_Format_Char_API.Get_Char(Intface_Header_API.Get_Column_Separator(intface_name_));
   @ApproveTransactionStatement(2013-11-20,wawilk)
   SAVEPOINT new_string_;
   --
   -- Strip off Carriage Return at end of file
   trim_string_ := rtrim(file_string_,chr(13));
   --
   IF ( intf_column_separator_ IS NULL ) THEN
      Unpack_String_By_Pos_( attr_, trim_string_, intf_format_error_, intface_name_, intfdet_rec_);
   ELSE
      Unpack_String_By_Separator_( attr_, trim_string_, intf_format_error_, intface_name_, intfsorted_cols_, intfdet_rec_, trunc_val_);
   END IF;
   IF ( intf_format_error_ IS NULL ) THEN
      RETURN TRUE;
   ELSE
      @ApproveTransactionStatement(2013-11-20,wawilk)
      ROLLBACK TO new_string_;
      RETURN FALSE;
   END IF;
END String_To_Attr;


PROCEDURE Create_Output_File (
   info_         IN OUT VARCHAR2,
   intface_name_ IN     VARCHAR2 )
IS
   --
   CURSOR Get_Columns IS
      SELECT *
      FROM INTFACE_DETAIL
      WHERE intface_name = intface_name_
      AND ( pos > 0 OR nvl(ext_attr,'FALSE') = 'TRUE')
      AND change_defaults_db != '3'
      ORDER BY pos;
   --
   CURSOR Get_Fixed_Values IS
      SELECT pos, column_name, default_value, nvl(ext_attr,'FALSE') ext_attr
      FROM INTFACE_DETAIL_TAB
      WHERE intface_name = intface_name_
      AND default_value IS NOT NULL
      AND ( change_defaults = '3' OR nvl(ext_attr,'FALSE') = 'TRUE') 
      ORDER BY pos;
   --
   CURSOR Get_Last_Pos IS
      SELECT max(pos)
      FROM INTFACE_DETAIL_TAB
      WHERE intface_name = intface_name_
      AND   pos > 0
      ORDER BY pos;
   --
   CURSOR get_globals IS
      SELECT intface_name, column_name, data_type, pos, length,
             decimal_length, amount_factor,
             default_value,  default_where,
             pad_char_left, pad_char_right,
             change_defaults, conv_list_id
      FROM  INTFACE_DETAIL_TAB
      WHERE intface_name = intface_name_
      AND   pos > 0
      ORDER BY pos;
   --
   CURSOR get_header IS
      SELECT column_name
      FROM INTFACE_DETAIL_TAB
      WHERE intface_name = intface_name_
      AND pos > 0
      ORDER BY pos;
   header_             VARCHAR2(2000) := NULL;
   rule_string_        VARCHAR2(2000);
   count_              NUMBER := 0;
   cols_               VARCHAR2(32000) := NULL;
   stmt_               VARCHAR2(32000) := NULL;
   where_              VARCHAR2(32000) := NULL;
   order_by_           VARCHAR2(32000);
   group_by_           VARCHAR2(32000);
   source_name_        VARCHAR2(32000);
   source_owner_       VARCHAR2(2000);
   h_cur_              INTEGER;
   dummy_              NUMBER;
   attr_               VARCHAR2(32767);
   stack_              varchar_tabtype;
   rec_                intdet_record;
   --
   string_value_       VARCHAR2(32000);
   error_in_view_      EXCEPTION;
   error_in_attr_      EXCEPTION;
   error_in_format_    EXCEPTION;
   line_no_            NUMBER := 0;
   fixed_attr_         VARCHAR2(32000);
   rec_nbr_            NUMBER;
   write_count_        NUMBER := 0;
   error_count_        NUMBER := 0;
   write_text_         VARCHAR2(200);
   error_text_         VARCHAR2(200);
   msg_sep_            VARCHAR2(2) := chr(13)||chr(10);
   date_format_start_  VARCHAR2(30) := 'to_char(';
   date_format_end_    VARCHAR2(30) := ','||''''||'YYYY-MM-DD-HH24.MI.SS'||''''||')';
   ext_attr_           VARCHAR2(32767);
   fixed_ext_attr_     VARCHAR2(32000);
   item_name_          VARCHAR2(200);
   ext_stmt_           VARCHAR2(2000);
   intf_format_error_  VARCHAR2(2000);
   --
   intf_last_pos_      NUMBER;
   intf_column_separator_ intface_header_tab.column_separator%TYPE;
   intfdet_rec_        Intface_Detail_Util_API.intfdet_tab_type;
   --
   intf_file_is_on_client_ BOOLEAN := App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_file_is_on_client_cid_);
   intf_file_is_on_server_ BOOLEAN := App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_file_is_on_server_cid_);
   FUNCTION Find_Alias (
      column_name_ IN VARCHAR2 ) RETURN VARCHAR2
   IS
      return_name_ VARCHAR2(200);
   BEGIN
      return_name_ := column_name_;
      IF ( instr(column_name_,' ') != 0 ) THEN
         return_name_ :=  substr(column_name_, instr(column_name_,' ')+1);
      END IF;
      RETURN return_name_;
   END Find_Alias;
BEGIN
   --
   IF ( Intface_Rules_API.Rule_Is_Active(
      ext_stmt_, 'CALLEXTPROC', intface_name_) ) THEN
      -- Add bindvariable. Execute this at end of main LOOP
      ext_stmt_ := 'BEGIN '||ext_stmt_ ||'( :ATTR);End;';
   END IF;
   info_         := NULL;
   --
   -- Load into global table (to be used in Format_String_Out)
   --
   rec_nbr_ := 0;
   --intf_date_format_        := nvl(Intface_Header_APi.Get_Date_Format(intface_name_),'YYYY-MM-DD-HH24.MI.SS');
   intf_column_separator_   := Intface_Format_Char_API.Get_Char(Intface_Header_API.Get_Column_Separator(intface_name_));
   --intf_thousand_separator_ := Intface_Format_Char_API.Get_Char(Intface_Header_API.Get_Thousand_Separator(intface_name_));
   --intf_column_embrace_     := Intface_Format_Char_API.Get_Char(Intface_Header_API.Get_Column_Embrace(intface_name_));
   --intf_decimal_point_      := Intface_Format_Char_API.Get_Char(Intface_Header_API.Get_Decimal_Point(intface_name_));
   --intf_minus_pos_          := Intface_Header_APi.Get_Minus_Pos(intface_name_);
   intfdet_rec_.DELETE;
   @ApproveTransactionStatement(2013-11-20,wawilk)
   SAVEPOINT new_job_;
   FOR intface_detail_rec_ IN get_globals LOOP
      rec_nbr_ := rec_nbr_ + 1;
      intfdet_rec_(rec_nbr_).intface_name := intface_detail_rec_.intface_name;
      intfdet_rec_(rec_nbr_).column_name := intface_detail_rec_.column_name;
      intfdet_rec_(rec_nbr_).data_type := intface_detail_rec_.data_type;
      intfdet_rec_(rec_nbr_).pos := intface_detail_rec_.pos;
      intfdet_rec_(rec_nbr_).length := intface_detail_rec_.length;
      intfdet_rec_(rec_nbr_).decimal_length := intface_detail_rec_.decimal_length;
      intfdet_rec_(rec_nbr_).amount_factor := intface_detail_rec_.amount_factor;
      intfdet_rec_(rec_nbr_).default_value := intface_detail_rec_.default_value;
      intfdet_rec_(rec_nbr_).pad_char_left := Intface_Format_Char_API.Get_Char(intface_detail_rec_.pad_char_left);
      intfdet_rec_(rec_nbr_).pad_char_right := Intface_Format_Char_API.Get_Char(intface_detail_rec_.pad_char_right);
      intfdet_rec_(rec_nbr_).change_defaults := intface_detail_rec_.change_defaults;
      intfdet_rec_(rec_nbr_).conv_list_id := intface_detail_rec_.conv_list_id;
   END LOOP;
   --
   -- Add items with fixed default value to attr
   --
   Client_SYS.Clear_Attr(fixed_attr_);
   FOR x IN Get_Fixed_Values LOOP
      IF ( x.pos > 0 ) THEN
         Client_Sys.Add_To_Attr(x.column_name, x.default_value, fixed_attr_);
      END IF;
      IF ( x.ext_attr = 'TRUE' ) THEN
         Client_Sys.Add_To_Attr(x.column_name, x.default_value, fixed_ext_attr_);
      END IF;
   END LOOP;
   --
   -- Find last pos, put it into global variable
   --
   OPEN  get_last_pos;
   FETCH get_last_pos INTO intf_last_pos_;
   CLOSE get_last_pos;
   --
   -- Build column selection
   --
   FOR x IN Get_Columns LOOP
      IF ( x.data_type = 'DATE') THEN
         -- Format dates to char values
         -- Will be finally formatted in Format_Date_Out
         cols_ := cols_ || date_format_start_ ||x.column_name || date_format_end_ ||' '|| x.column_name|| ',';
      ELSE
         cols_  := cols_ || x.column_name || ',';
      END IF;
      count_ := count_ + 1;
      rec_.cols_(count_)      := x.column_name;
      rec_.length_(count_)    := x.length;
      rec_.data_type_(count_) := x.data_type;
      rec_.ext_attr_(count_) := nvl(x.ext_attr,'FALSE');
      rec_.pos_(count_) := x.pos;
   END LOOP;
   cols_ := RTrim(cols_, ',');
   -- Decide what source to select from
   source_name_   := Intface_Header_API.Get_Source_Name(intface_name_);
   IF ( source_name_ IS NOT NULL ) THEN
      source_owner_  := Intface_Header_API.Get_Source_Owner(intface_name_);
      IF ( source_owner_ IS NOT NULL ) THEN
         source_name_ := source_owner_||chr(46)||source_name_;
      END IF;
   ELSE
      source_name_ := Intface_Header_API.Get_View_Name(intface_name_);
   END IF;
   --
   -- Build select statement
   --
   stmt_ := 'SELECT ' || cols_ || ' FROM ' || source_name_;
   --
   -- Add complete where-clause if any.
   --
   where_ := Intface_Header_API.Get_Complete_Where(intface_name_);
   --
   stmt_ := stmt_ || where_;
   --
   -- Finally, add group by and order by clauses to statement
   --
   group_by_ := Intface_Header_API.Get_Group_By_Clause(intface_name_);
   IF ( group_by_ IS NOT NULL) THEN
      group_by_ := ' GROUP BY '||group_by_;
      stmt_ := stmt_ || group_by_;
   END IF;
   --
   order_by_ := Intface_Header_API.Get_Order_By_Clause(intface_name_);
   IF ( order_by_ IS NOT NULL) THEN
      order_by_ := ' ORDER BY '||order_by_;
      stmt_ := stmt_ || order_by_;
   END IF;
   -- Display stmt_ for trace
   Trace_Long_Msg(stmt_);
   --
   h_cur_ := DBMS_SQL.Open_Cursor;
   BEGIN
      -- Safe due to appending values are derived
      @ApproveDynamicStatement(2009-11-24,nabalk)
      DBMS_SQL.Parse(h_cur_, stmt_, DBMS_SQL.native);
   EXCEPTION
      WHEN OTHERS THEN
         RAISE error_in_view_;
   END;
   -- Build header column if specified
   IF ( Intface_Rules_API.Rule_Is_Active( rule_string_, 'FILEHEAD', intface_name_) ) THEN
      IF ( intf_column_separator_ IS NOT NULL ) THEN
         FOR x IN get_header LOOP
            item_name_ := Find_Alias(x.column_name);
            header_  := header_ || item_name_ || intf_column_separator_;
         END LOOP;
         header_ := RTrim(header_, intf_column_separator_);
         -- Insert column header at start of file
         IF ( intf_file_is_on_client_ ) THEN
            Intface_Job_Detail_API.Process_Job_Details(intface_name_,
               0  ,header_ , null , 'OUTPUT_TO_CLIENT' , null );
         ELSE
            UTL_FILE.PUT_LINE (intf_file_handle_, Database_SYS.Db_To_File_Encoding(header_));
         END IF;
      END IF;
   END IF;
   FOR i IN 1..count_ LOOP
      stack_(i) := NULL;
      DBMS_SQL.Define_Column(h_cur_, i, stack_(i), 2000);
   END LOOP;
   --
   dummy_ := DBMS_SQL.Execute(h_cur_);
   --
   -- Build attr_ string
   --
   LOOP
      IF (DBMS_SQL.Fetch_Rows(h_cur_) = 0) THEN
         EXIT;
      END IF;
      -- Previous selected fixed values added to attr_
      attr_ := fixed_attr_;
      ext_attr_ := fixed_ext_attr_;
      FOR i IN 1..count_ LOOP
         DBMS_SQL.Column_Value(h_cur_, i, stack_(i));
         IF ( rec_.pos_(i) > 0 ) THEN
            client_sys.add_to_attr(rec_.cols_(i), stack_(i), attr_);
         END IF;
         IF ( rec_.ext_attr_(i) = 'TRUE' ) THEN
            item_name_ := Find_Alias(rec_.cols_(i));
            client_sys.add_to_attr(item_name_ , stack_(i), ext_attr_);
         END IF;
      END LOOP;
      -- Format attr_ string to string_value_ and write to file
      --
      line_no_ := line_no_ + 1;
      @ApproveTransactionStatement(2013-11-20,wawilk)
      SAVEPOINT new_string_;
      IF ( Intface_Detail_API.Attr_To_String(string_value_, attr_,intf_last_pos_, intface_name_, intfdet_rec_) ) THEN
         -- Write result to file or to Intface_Job_Detail
         IF ( intf_file_is_on_client_ ) THEN
            Intface_Job_Detail_API.Process_Job_Details(intface_name_,
               line_no_ ,string_value_ , null , 'OUTPUT_TO_CLIENT' , null );
         ELSE
            UTL_FILE.PUT_LINE (intf_file_handle_, Database_SYS.Db_To_File_Encoding(string_value_));
         END IF;
         write_count_ := write_count_ +1;
      ELSE
         RAISE error_in_format_;
      END IF;
      --
      IF ( ext_stmt_ IS NOT NULL ) THEN
         Trace_SYS.Message(stmt_);
         intface_Detail_API.Trace_Long_Msg(ext_attr_);
         -- Safe due to ext_stmt_ is fully derived
         @ApproveDynamicStatement(2009-11-24,nabalk)
         EXECUTE IMMEDIATE ext_stmt_
         USING IN OUT ext_attr_;
      END IF;
      --
      client_sys.clear_attr(attr_);
      client_sys.clear_attr(ext_attr_);
   END LOOP;
   DBMS_SQL.Close_Cursor(h_cur_);
   Client_SYS.Add_Info(lu_name_, 'CREINTFACEOK: Migration job :P1 completed', intface_name_);
   info_ := Client_Sys.Get_All_Info;
   info_ := info_||msg_sep_;
   IF ( write_count_ > 0 ) THEN
      write_text_ := Language_SYS.Translate_Constant (lu_name_, 'ROWSWRITTEN: :P1 rows written', Fnd_Session_API.Get_Language, to_char( write_count_));
      info_ := info_||msg_sep_||write_text_;
   END IF;
   IF ( error_count_ > 0 ) THEN
      error_text_ := Language_SYS.Translate_Constant (lu_name_, 'ROWSFAILED: :P1 rows failed', Fnd_Session_API.Get_Language, to_char( error_count_));
      info_ := info_||msg_sep_||error_text_;
   END IF;
   IF ( write_count_ + error_count_ = 0 ) THEN
      error_text_ := Language_SYS.Translate_Constant (lu_name_, 'WRNOROWS: No rows processed', Fnd_Session_API.Get_Language );
      info_ := info_||msg_sep_||error_text_;
   END IF;
   IF ( intf_file_is_on_server_ ) THEN
      UTL_FILE.FFLUSH(intf_file_handle_);
   END IF;
   App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_execution_ok_cid_,TRUE);
EXCEPTION
   WHEN error_in_format_ THEN
      @ApproveTransactionStatement(2013-11-20,wawilk)
      ROLLBACK TO SAVEPOINT new_job_;
      Intface_Job_Detail_API.Process_Job_Details(intface_name_,
         line_no_ ,string_value_ , attr_ , intf_format_error_ , null );
      Client_SYS.Add_Info(lu_name_, 'CREFORMAT: Create file failed - :P1', intf_format_error_);
      info_ := Client_Sys.Get_All_Info;
   WHEN error_in_view_ THEN
      info_ := SQLERRM ||':'||stmt_;
   WHEN error_in_attr_ THEN
      Client_SYS.Add_Info(lu_name_, 'CREERRORATTR: Create file from :P1 failed.', Intface_Header_API.Get_View_Name(intface_name_) );
      info_ := Client_Sys.Get_All_Info;
      Intface_Job_Detail_API.Process_Job_Details(intface_name_,
         0 ,string_value_ , attr_ , info_ , null );
   WHEN OTHERS THEN
      info_ := SQLERRM;
      Intface_Job_Detail_API.Process_Job_Details(intface_name_,
         0 ,string_value_ , attr_ , info_ , null );
END Create_Output_File;


PROCEDURE Insert_By_Method_New (
   info_         IN OUT VARCHAR2,
   intface_name_ IN     VARCHAR2 )
IS
   string_attr_     VARCHAR2(32000);
   prepare_attr_    VARCHAR2(32000);
   attr_            VARCHAR2(32000);
   objid_           VARCHAR2(2000);
   objversion_      VARCHAR2(2000);
   end_of_file_     BOOLEAN := FALSE;
   file_string_     VARCHAR2(32000);
   status_          intface_job_detail_tab.status%TYPE;
   line_no_         intface_job_detail_tab.line_no%TYPE;
   line_objid_      rowid;
   commit_seq_      NUMBER := 0;
   commit_count_    NUMBER := 0;
   --
   view_name_       VARCHAR2(35) := Intface_Header_API.Get_View_Name(intface_name_);
   pkg_name_        VARCHAR2(100) := view_name_||'_API.New__';
   error_in_format_ EXCEPTION;
   execute_error_   EXCEPTION;
   stmt_            VARCHAR2(2000);
   insert_count_    NUMBER := 0;
   error_count_     NUMBER := 0;
   error_line_      NUMBER;
   insert_text_     VARCHAR2(200);
   error_text_      VARCHAR2(200);
   msg_sep_         VARCHAR2(2) := chr(13)||chr(10);
   intf_format_error_      VARCHAR2(2000);
   intf_base_method_error_ VARCHAR2(2000);
   --
   intf_insert_h_cur_ INTEGER;
   intf_update_h_cur_ INTEGER;
   
   intfsorted_cols_ Intface_Detail_Util_API.intfdet_col_tab_type;
   intfdet_rec_     Intface_Detail_Util_API.intfdet_tab_type;

   trunc_val_       BOOLEAN;
   test_            VARCHAR2(100);
   intf_file_is_on_client_ BOOLEAN := App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_file_is_on_client_cid_);
   intf_file_is_on_server_ BOOLEAN := App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_file_is_on_server_cid_);
   intf_ignoreaderror_     BOOLEAN := App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_ignoreaderror_cid_);
   intf_ignorexeerror_     BOOLEAN := App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_ignorexeerror_cid_);
BEGIN
   @ApproveTransactionStatement(2013-11-20,wawilk)
   SAVEPOINT new_job_;
   IF ( Intface_Rules_API.Rule_Is_Active(test_, 'TRUNCVAL', intface_name_) ) THEN
      trunc_val_ := TRUE;
   ELSE
      trunc_val_ := FALSE;
   END IF;
   --
   -- Declare statement, open cursor an parse before LOOP
   stmt_ := 'Begin '||pkg_name_||'(:info,:objid,:objversion,:attr, :action ); End;';
   intf_insert_h_cur_ := DBMS_SQL.Open_Cursor;
   -- Safe due to stmt_ is fully derived
   @ApproveDynamicStatement(2009-11-24,nabalk)
   DBMS_SQL.Parse(intf_insert_h_cur_, stmt_, DBMS_SQL.native);
   intfsorted_cols_ := Intface_Detail_Util_API.Get_Sorted_Intface_Columns(intface_name_);
   intfdet_rec_ := Intface_Detail_Util_API.Get_Intface_Details(intface_name_);
   LOOP
      IF ( intf_file_is_on_client_ ) THEN
         FETCH Intface_Job_Detail_API.Get_String INTO line_no_, file_string_, status_, line_objid_;
         EXIT WHEN  Intface_Job_Detail_API.Get_String%NOTFOUND;
      ELSIF ( intf_file_is_on_server_ ) THEN
         Intface_Job_Detail_API.Get_Next_Line(line_no_, file_string_, end_of_file_);
         EXIT WHEN end_of_file_;
      END IF;
      Client_Sys.Clear_Attr(attr_);
      Client_Sys.Clear_Attr(string_attr_);
      commit_seq_ := commit_seq_ +1;
      @ApproveTransactionStatement(2013-11-20,wawilk)
      SAVEPOINT new_string_;
      IF ( String_To_Attr( string_attr_, file_string_, intf_format_error_, intface_name_, intfsorted_cols_, intfdet_rec_, trunc_val_) ) THEN
         IF ( prepare_attr_ IS NULL ) THEN
            -- Execute PREPARE once
            IF ( Exec_Base_Method_( info_, objid_, objversion_, prepare_attr_, 'PREPARE', 'INSERT', intf_base_method_error_, intf_insert_h_cur_, intf_update_h_cur_) ) THEN
               IF ( prepare_attr_ IS NULL ) THEN
                  prepare_attr_ :=  'NOPREPARE' ;
               ELSE
                  trace_sys.message(' PREPARE attr : ');
                  trace_sys.message(prepare_attr_);
               END IF;
            ELSE
               Intface_Job_Detail_API.Process_Job_Details(intface_name_,
                  line_no_ ,file_string_ , attr_ , intf_base_method_error_ , line_objid_ );
               IF ( NOT intf_ignorexeerror_ ) THEN
                  error_line_ := line_no_;
                  RAISE execute_error_;
               END IF;
            END IF;
         END IF;
         IF ( prepare_attr_  != 'NOPREPARE' ) THEN
            -- Prepare attr has values, complete attr-string
            attr_ := Merge_Attr_Strings(string_attr_, prepare_attr_);
         ELSE
            attr_ := string_attr_;
         END IF;
         IF ( Exec_Base_Method_( info_, objid_, objversion_, attr_, 'DO', 'INSERT', intf_base_method_error_, intf_insert_h_cur_, intf_update_h_cur_) ) THEN
            IF ( intf_file_is_on_client_ ) THEN
               Intface_Job_Detail_API.Process_Job_Details(intface_name_,
                  line_no_ ,file_string_ , attr_ , null , line_objid_ );
            END IF;
            insert_count_ := insert_count_ + 1;
         ELSE
            Intface_Job_Detail_API.Process_Job_Details(intface_name_,
               line_no_ ,file_string_ , attr_ , intf_base_method_error_ , line_objid_ );
            error_count_ := error_count_ + 1;
            IF ( NOT intf_ignorexeerror_ ) THEN
               error_line_ := line_no_;
               RAISE execute_error_;
            END IF;
         END IF;
      ELSE
         Intface_Job_Detail_API.Process_Job_Details(intface_name_,
            line_no_ ,file_string_ , attr_ , intf_format_error_ , line_objid_ );
         error_count_ := error_count_ + 1;
         IF ( NOT intf_ignoreaderror_ ) THEN
            error_line_ := line_no_;
            RAISE error_in_format_;
         END IF;
      END IF;
      IF ( nvl(App_Context_SYS.Find_Number_Value(Intface_Job_Detail_API.intf_commit_seq_cid_),commit_seq_+1) <= commit_seq_ ) THEN
         @ApproveTransactionStatement(2013-11-20,wawilk)
         COMMIT;
         Trace_SYS.Message(' TRACE>>>>>>> Commit ');
         commit_count_ := commit_count_ + commit_seq_;
         commit_seq_ := 0;
         @ApproveTransactionStatement(2013-11-20,wawilk)
         SAVEPOINT new_job_;
      END IF;
   END LOOP;
   info_ := Language_SYS.Translate_Constant (lu_name_, 'INSINTOK: Migration job :P1 completed ', Fnd_Session_API.Get_Language, intface_name_);
   info_ := info_||msg_sep_;
   IF ( insert_count_ > 0 ) THEN
      insert_text_ := Language_SYS.Translate_Constant (lu_name_, 'INSINTINS: :P1 new rows inserted', Fnd_Session_API.Get_Language, to_char( insert_count_));
      info_ := info_||msg_sep_||insert_text_;
   END IF;
   IF ( error_count_ > 0 ) THEN
      error_text_ := Language_SYS.Translate_Constant (lu_name_, 'INSINTERR: :P1 rows failed', Fnd_Session_API.Get_Language, to_char( error_count_));
      info_ := info_||msg_sep_||error_text_;
   END IF;
   IF ( insert_count_ + error_count_ = 0 ) THEN
      error_text_ := Language_SYS.Translate_Constant (lu_name_, 'INSINTNOROWS: No rows processed', Fnd_Session_API.Get_Language );
      info_ := info_||msg_sep_||error_text_;
   END IF;
   IF ( dbms_sql.is_open(intf_insert_h_cur_)) THEN
      DBMS_SQL.Close_Cursor(intf_insert_h_cur_);
   END IF;
   App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_execution_ok_cid_,TRUE);
EXCEPTION
   WHEN execute_error_ THEN
      @ApproveTransactionStatement(2013-11-20,wawilk)
      ROLLBACK TO SAVEPOINT new_job_;
      IF ( dbms_sql.is_open(intf_insert_h_cur_)) THEN
         DBMS_SQL.Close_Cursor(intf_insert_h_cur_);
      END IF;
      Client_SYS.Add_Info(lu_name_, 'INSERRORNEW: Insert into :P1 failed - :P2 (Error caused by line: :P3)', view_name_||'_TAB', intf_base_method_error_, error_line_);
      IF ( commit_count_ > 0 ) THEN
         Client_SYS.Add_Info(lu_name_, 'COMMITCNT:  :P1 Number of rows commited : :P2', msg_sep_ , to_char(commit_count_));
      END IF;
      info_ := Client_Sys.Get_All_Info;
   WHEN error_in_format_ THEN
      @ApproveTransactionStatement(2013-11-20,wawilk)
      ROLLBACK TO SAVEPOINT new_job_;
      IF ( dbms_sql.is_open(intf_insert_h_cur_)) THEN
         DBMS_SQL.Close_Cursor(intf_insert_h_cur_);
      END IF;
      Client_SYS.Add_Info(lu_name_, 'INSERRORNEW: Insert into :P1 failed - :P2 (Error caused by line: :P3)', view_name_||'_TAB', intf_format_error_, error_line_);
      IF ( commit_count_ > 0 ) THEN
         Client_SYS.Add_Info(lu_name_, 'COMMITCNT:  :P1 Number of rows commited : :P2', msg_sep_ , to_char(commit_count_));
      END IF;
      info_ := Client_Sys.Get_All_Info;
   WHEN OTHERS THEN
      @ApproveTransactionStatement(2013-11-20,wawilk)
      ROLLBACK TO SAVEPOINT new_string_;
      IF ( dbms_sql.is_open(intf_insert_h_cur_)) THEN
         DBMS_SQL.Close_Cursor(intf_insert_h_cur_);
      END IF;
      info_ := SQLERRM;
END Insert_By_Method_New;


PROCEDURE From_Attr_To_Attr (
   to_attr_   IN OUT VARCHAR2,
   from_attr_ IN     VARCHAR2,
   name_      IN     VARCHAR2 )
IS
   ptr_        NUMBER;
   from_name_  VARCHAR2(30);
   from_value_ VARCHAR2(4000);
BEGIN
   ptr_ := NULL;
   WHILE (Client_SYS.Get_Next_From_Attr(from_attr_, ptr_, from_name_, from_value_)) LOOP
      IF (from_name_ = name_ ) THEN
         Client_Sys.Add_To_Attr( name_, from_value_, to_attr_);
         EXIT; -- from_attr_ contain only distinct names
      END IF;
   END LOOP;
END From_Attr_To_Attr;


PROCEDURE Check_By_Method_New (
   info_         IN OUT VARCHAR2,
   intface_name_ IN VARCHAR2 )
IS
   string_attr_     VARCHAR2(32000);
   prepare_attr_    VARCHAR2(32000);
   attr_            VARCHAR2(32000);
   objid_           VARCHAR2(2000);
   objversion_      VARCHAR2(2000);
   end_of_file_     BOOLEAN := FALSE;
   file_string_     VARCHAR2(32000);
   status_          intface_job_detail_tab.status%TYPE;
   line_no_         intface_job_detail_tab.line_no%TYPE;
   line_objid_      rowid;
   --
   view_name_       VARCHAR2(35) := Intface_Header_API.Get_View_Name(intface_name_);
   pkg_name_        VARCHAR2(100) := view_name_||'_API.New__';
   error_in_format_ EXCEPTION;
   execute_error_   EXCEPTION;
   stmt_            VARCHAR2(2000);
   insert_count_    NUMBER := 0;
   error_count_     NUMBER := 0;
   insert_text_     VARCHAR2(200);
   error_text_      VARCHAR2(200);
   error_line_      NUMBER;
   msg_sep_         VARCHAR2(2) := chr(13)||chr(10);
   old_intf_info_   VARCHAR2(2000);   --
   make_check_      BOOLEAN;
   dummy_           VARCHAR2(1);
   commit_seq_      NUMBER := 0;
   commit_count_    NUMBER := 0;
   intf_format_error_      VARCHAR2(2000);
   intf_base_method_error_ VARCHAR2(2000);
   
   --
   intf_insert_h_cur_ INTEGER;
   intf_update_h_cur_ INTEGER;
   
   intfsorted_cols_ Intface_Detail_Util_API.intfdet_col_tab_type;
   intfdet_rec_     Intface_Detail_Util_API.intfdet_tab_type;
   
   trunc_val_ BOOLEAN;
   test_      VARCHAR2(100);
   intf_file_is_on_client_ BOOLEAN := App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_file_is_on_client_cid_);
   intf_file_is_on_server_ BOOLEAN := App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_file_is_on_server_cid_);
   intf_ignoreaderror_     BOOLEAN := App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_ignoreaderror_cid_);
   intf_ignorexeerror_     BOOLEAN := App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_ignorexeerror_cid_);
   
   CURSOR check_error_message IS
      SELECT 'x'
      FROM intface_job_detail_tab
      where rowid = line_objid_
      and error_message IS NOT NULL;
BEGIN
   @ApproveTransactionStatement(2013-11-20,wawilk)
   SAVEPOINT new_job_;
 
   IF ( Intface_Rules_API.Rule_Is_Active(test_, 'TRUNCVAL', intface_name_) ) THEN
      trunc_val_ := TRUE;
   ELSE
      trunc_val_ := FALSE;
   END IF;
   
   intfsorted_cols_ := Intface_Detail_Util_API.Get_Sorted_Intface_Columns(intface_name_);
   intfdet_rec_ := Intface_Detail_Util_API.Get_Intface_Details(intface_name_);

   --
   -- Save old info, change it temporarily to CHECK
   -- Used in Intface_Job_Detail_API.Process_Job_Details
   -- 
   old_intf_info_ := App_Context_SYS.Find_Value(Intface_Job_Detail_API.intf_in_info_cid_);
   App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_in_info_cid_,'CHECK');
   -- Declare statement, open cursor an parse before LOOP
   stmt_ := 'Begin '||pkg_name_||'(:info,:objid,:objversion,:attr, :action ); End;';
   intf_insert_h_cur_ := DBMS_SQL.Open_Cursor;
   -- Safe due to stmt_ is fully derived
   @ApproveDynamicStatement(2009-11-24,nabalk)
   DBMS_SQL.Parse(intf_insert_h_cur_, stmt_, DBMS_SQL.native);
   LOOP
      make_check_ := TRUE;
      IF ( intf_file_is_on_client_ ) THEN
         FETCH Intface_Job_Detail_API.Get_String INTO line_no_, file_string_, status_, line_objid_;
         EXIT WHEN  Intface_Job_Detail_API.Get_String%NOTFOUND;
      ELSIF ( intf_file_is_on_server_ ) THEN
         Intface_Job_Detail_API.Get_Next_Line(line_no_, file_string_, end_of_file_);
         EXIT WHEN end_of_file_;
      END IF;
      Client_Sys.Clear_Attr(attr_);
      Client_Sys.Clear_Attr(string_attr_);
      commit_seq_ := commit_seq_ +1;
      @ApproveTransactionStatement(2013-11-20,wawilk)
      SAVEPOINT new_string_;
      IF ( old_intf_info_ = 'RESTART' ) THEN
         -- IF RESTART, we shall not check OK rows over again
         OPEN  check_error_message;
         FETCH check_error_message INTO dummy_;
            make_check_ := check_error_message%FOUND;
         CLOSE check_error_message;
      END IF;
      IF ( make_check_ ) THEN
         IF ( String_To_Attr( string_attr_, file_string_, intf_format_error_, intface_name_, intfsorted_cols_, intfdet_rec_, trunc_val_) ) THEN
            IF ( prepare_attr_ IS NULL ) THEN
               -- Execute PREPARE once
               IF ( Exec_Base_Method_( info_, objid_, objversion_, prepare_attr_, 'PREPARE', 'INSERT', intf_base_method_error_, intf_insert_h_cur_, intf_update_h_cur_) ) THEN
                  IF ( prepare_attr_ IS NULL ) THEN
                     prepare_attr_ :=  'NOPREPARE' ;
                  ELSE
                     trace_sys.message(' PREPARE attr : ');
                     trace_sys.message(prepare_attr_);
                  END IF;
               ELSE
                  Intface_Job_Detail_API.Process_Job_Details(intface_name_,
                     line_no_ ,file_string_ , attr_ , intf_base_method_error_ , line_objid_ );
                  IF ( NOT intf_ignorexeerror_ ) THEN
                     error_line_ := line_no_;
                     RAISE execute_error_;
                  END IF;
               END IF;
            END IF;
            IF ( prepare_attr_  != 'NOPREPARE' ) THEN
               -- Prepare attr has values, complete attr-string
               attr_ := Merge_Attr_Strings(string_attr_, prepare_attr_);
            ELSE
               attr_ := string_attr_;
            END IF;
            IF ( Exec_Base_Method_( info_, objid_, objversion_, attr_, 'CHECK', 'INSERT', intf_base_method_error_, intf_insert_h_cur_, intf_update_h_cur_) ) THEN
               IF ( intf_file_is_on_client_ ) THEN
                  Intface_Job_Detail_API.Process_Job_Details(intface_name_,
                     line_no_ ,file_string_ , attr_ , null , line_objid_ );
               END IF;
               insert_count_ := insert_count_ + 1;
            ELSE
               Intface_Job_Detail_API.Process_Job_Details(intface_name_,
                  line_no_ ,file_string_ , attr_ , intf_base_method_error_ , line_objid_ );
               error_count_ := error_count_ + 1;
               IF ( NOT intf_ignorexeerror_ ) THEN
                  error_line_ := line_no_;
                  RAISE execute_error_;
               END IF;
            END IF;
         ELSE
            Intface_Job_Detail_API.Process_Job_Details(intface_name_,
               line_no_ ,file_string_ , attr_ , intf_format_error_ , line_objid_ );
            error_count_ := error_count_ + 1;
            IF ( NOT intf_ignoreaderror_ ) THEN
               error_line_ := line_no_;
               RAISE error_in_format_;
            END IF;
         END IF;
      END IF;
      IF ( nvl(App_Context_SYS.Find_Number_Value(Intface_Job_Detail_API.intf_commit_seq_cid_),commit_seq_+1) <= commit_seq_ ) THEN
         @ApproveTransactionStatement(2013-11-20,wawilk)
         COMMIT;
         Trace_SYS.Message(' TRACE>>>>>>> Commit ');
         commit_count_ := commit_count_ + commit_seq_;
         commit_seq_ := 0;
         @ApproveTransactionStatement(2013-11-20,wawilk)
         SAVEPOINT new_job_;
      END IF;
   END LOOP;
   info_ := Language_SYS.Translate_Constant (lu_name_, 'INSINTOK: Migration job :P1 completed ', Fnd_Session_API.Get_Language, intface_name_);
   info_ := info_||msg_sep_;
   IF ( insert_count_ > 0 ) THEN
      insert_text_ := Language_SYS.Translate_Constant (lu_name_, 'INSCHECK: :P1 new rows checked OK', Fnd_Session_API.Get_Language, to_char( insert_count_));
      info_ := info_||msg_sep_||insert_text_;
   END IF;
   IF ( error_count_ > 0 ) THEN
      error_text_ := Language_SYS.Translate_Constant (lu_name_, 'INSCHECKERR: :P1 rows checked with error', Fnd_Session_API.Get_Language, to_char( error_count_));
      info_ := info_||msg_sep_||error_text_;
   END IF;
   IF ( insert_count_ + error_count_ = 0 ) THEN
      error_text_ := Language_SYS.Translate_Constant (lu_name_, 'INSINTNOROWS: No rows processed', Fnd_Session_API.Get_Language );
      info_ := info_||msg_sep_||error_text_;
   END IF;
   IF ( dbms_sql.is_open(intf_insert_h_cur_)) THEN
      DBMS_SQL.Close_Cursor(intf_insert_h_cur_);
   END IF;
   App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_execution_ok_cid_,TRUE);
   -- Reset temporarilay changed value
   App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_in_info_cid_,old_intf_info_);
EXCEPTION
   WHEN execute_error_ THEN
      @ApproveTransactionStatement(2013-11-20,wawilk)
      ROLLBACK TO SAVEPOINT new_job_;
      IF ( dbms_sql.is_open(intf_insert_h_cur_)) THEN
         DBMS_SQL.Close_Cursor(intf_insert_h_cur_);
      END IF;
      Client_SYS.Add_Info(lu_name_, 'CHECKERROR: Check on :P1 failed - :P2 (Error caused by line: :P3)', view_name_||'_TAB', intf_base_method_error_, error_line_);
      IF ( commit_count_ > 0 ) THEN
         Client_SYS.Add_Info(lu_name_, 'COMMITCNT:  :P1 Number of rows commited : :P2', msg_sep_ , to_char(commit_count_));
      END IF;
      info_ := Client_Sys.Get_All_Info;
      -- Reset temporarilay changed value
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_in_info_cid_,old_intf_info_);
   WHEN error_in_format_ THEN
      @ApproveTransactionStatement(2013-11-20,wawilk)
      ROLLBACK TO SAVEPOINT new_job_;
      IF ( dbms_sql.is_open(intf_insert_h_cur_)) THEN
         DBMS_SQL.Close_Cursor(intf_insert_h_cur_);
      END IF;
      Client_SYS.Add_Info(lu_name_, 'CHECKERROR: Check on :P1 failed - :P2 (Error caused by line: :P3)', view_name_||'_TAB', intf_base_method_error_, error_line_);
      IF ( commit_count_ > 0 ) THEN
         Client_SYS.Add_Info(lu_name_, 'COMMITCNT:  :P1 Number of rows commited : :P2', msg_sep_ , to_char(commit_count_));
      END IF;
      info_ := Client_Sys.Get_All_Info;
      -- Reset temporarilay changed value
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_in_info_cid_,old_intf_info_);
   WHEN OTHERS THEN
      @ApproveTransactionStatement(2013-11-20,wawilk)
      ROLLBACK TO SAVEPOINT new_string_;
      IF ( dbms_sql.is_open(intf_insert_h_cur_)) THEN
         DBMS_SQL.Close_Cursor(intf_insert_h_cur_);
      END IF;
      info_ := SQLERRM;
      -- Reset temporarilay changed value
      App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_in_info_cid_,old_intf_info_);
END Check_By_Method_New;


PROCEDURE Insert_Or_Update (
   info_         IN OUT VARCHAR2,
   intface_name_ IN VARCHAR2 )
IS
   end_of_file_     BOOLEAN := FALSE;
   file_string_     VARCHAR2(32000);
   --
   string_attr_     VARCHAR2(32000);
   update_attr_     VARCHAR2(32000);
   prepare_attr_    VARCHAR2(32000);
   attr_            VARCHAR2(32000);
   objid_           VARCHAR2(2000);
   objversion_      VARCHAR2(2000);
   --
   view_name_       VARCHAR2(35) := Intface_Header_API.Get_View_Name(intface_name_);
   insert_pkg_name_ VARCHAR2(100) := view_name_||'_API.New__';
   update_pkg_name_ VARCHAR2(100) := view_name_||'_API.Modify__';
   stmt_            VARCHAR2(2000);
   base_stmt_       VARCHAR2(2000);
   where_clause_    VARCHAR2(2000);
   h_cur_           INTEGER;
   dummy_           NUMBER;
   ptr_             NUMBER;
   name_            VARCHAR2(30);
   value_           VARCHAR2(4000);
   line_no_         NUMBER := 0;
   error_in_new_    EXCEPTION;
   error_in_update_ EXCEPTION;
   error_in_check_  EXCEPTION;
   error_in_format_ EXCEPTION;
   line_objid_      VARCHAR2(2000);
   sqlerrm_         VARCHAR2(2000);
   status_          intface_job_detail_tab.status%TYPE;
   do_update_       BOOLEAN;
   do_insert_       BOOLEAN;
   insert_count_    NUMBER := 0;
   update_count_    NUMBER := 0;
   error_count_     NUMBER := 0;
   error_line_      NUMBER;
   insert_text_     VARCHAR2(200);
   update_text_     VARCHAR2(200);
   error_text_      VARCHAR2(200);
   msg_sep_         VARCHAR2(2) := chr(13)||chr(10);
   commit_seq_      NUMBER := 0;
   commit_count_    NUMBER := 0;
   intf_format_error_      VARCHAR2(2000);
   intf_base_method_error_ VARCHAR2(2000);
   intf_insupd_     VARCHAR2(2000);
   rule_string_     VARCHAR2(2000);
   upd_col_         VARCHAR2(30);
   
   --
   -- Find primary key columns
   CURSOR get_key_cols IS
      SELECT c.column_name col_name,
             DECODE(c.data_type,
                'DATE','TO_DATE('||'''',
                'VARCHAR2','''',null) prefix,
             DECODE(c.data_type,
                'DATE',''''||','||''''||Client_SYS.date_format_||''''||')',
                'VARCHAR2','''',null) suffix
      FROM   intface_detail_tab c
      WHERE  (c.flags LIKE '%P%' OR c.flags LIKE '%K%')
      AND    c.intface_name = intface_name_
      ORDER BY c.attr_seq;
   --
   -- Find updateable columns
   CURSOR get_upd_cols IS
      SELECT b.column_name col_name
      FROM   intface_detail_tab b
      WHERE  b.intface_name = intface_name_
      AND    b.flags LIKE '%U%'
      ORDER BY b.attr_seq;
   --
   -- Find unmodified _db columns
   CURSOR get_db_cols IS
      SELECT b.column_name col_name
      FROM   intface_detail_tab b
      WHERE  b.intface_name = intface_name_
      AND    b.flags IS NULL AND b.column_name LIKE '%_DB'
      ORDER BY b.attr_seq;
   --
   -- Get updatable client column
   CURSOR get_upd_c_cols(column_name_ VARCHAR2) IS
      SELECT d.column_name
      FROM   dictionary_sys_view_column_tab d
      WHERE  d.view_name = view_name_
      AND    d.column_name = column_name_
      AND    d.update_flag = 'U';
   --
   intf_insert_h_cur_ INTEGER;
   intf_update_h_cur_ INTEGER;
   
   intfsorted_cols_ Intface_Detail_Util_API.intfdet_col_tab_type;
   intfdet_rec_     Intface_Detail_Util_API.intfdet_tab_type;
   
   trunc_val_ BOOLEAN;
   test_      VARCHAR2(100);
   intf_file_is_on_client_ BOOLEAN := App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_file_is_on_client_cid_);
   intf_file_is_on_server_ BOOLEAN := App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_file_is_on_server_cid_);
   intf_ignoreaderror_     BOOLEAN := App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_ignoreaderror_cid_);
   intf_ignorexeerror_     BOOLEAN := App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_ignorexeerror_cid_);
BEGIN
   IF ( Intface_Rules_API.Rule_Is_Active(test_, 'TRUNCVAL', intface_name_) ) THEN
      trunc_val_ := TRUE;
   ELSE
      trunc_val_ := FALSE;
   END IF;
   intfsorted_cols_ := Intface_Detail_Util_API.Get_Sorted_Intface_Columns(intface_name_);
   intfdet_rec_ := Intface_Detail_Util_API.Get_Intface_Details(intface_name_);
   -- Declare statement, open cursor an parse before LOOP
   stmt_ := 'Begin '||insert_pkg_name_||'(:info,:objid,:objversion,:attr, :action ); End;';
   intf_insert_h_cur_ := DBMS_SQL.Open_Cursor;
   -- Safe due to stmt_ is fully derived
   @ApproveDynamicStatement(2009-11-24,nabalk)
   DBMS_SQL.Parse(intf_insert_h_cur_, stmt_, DBMS_SQL.native);
   stmt_ := 'Begin '||update_pkg_name_||'(:info,:objid,:objversion,:attr, :action ); End;';
   intf_update_h_cur_ := DBMS_SQL.Open_Cursor;
   -- Safe due to stmt_ is fully derived
   @ApproveDynamicStatement(2009-11-24,nabalk)
   DBMS_SQL.Parse(intf_update_h_cur_, stmt_, DBMS_SQL.native);
   -- Check rule INSUPD. Set BOOLEANS for insert and update
   IF Intface_Rules_API.Rule_Is_Active(rule_string_, 'INSUPD', intface_name_) THEN
      IF rule_string_ IN ( 'INSERT' , 'UPDATE') THEN
         intf_insupd_ := upper(rule_string_);
      ELSE
         intf_insupd_ := NULL;
      END IF;
   ELSE
      intf_insupd_ := NULL;
   END IF;
   
   IF ( nvl(intf_insupd_,'UPDATE') = 'UPDATE' ) THEN
      do_update_ := TRUE;
   ELSE
      do_update_ := FALSE;
   END IF;
   IF ( nvl(intf_insupd_,'INSERT') = 'INSERT' ) THEN
      do_insert_ := TRUE;
   ELSE
      do_insert_ := FALSE;
   END IF;
   info_ := NULL;
   --
   base_stmt_ := 'BEGIN SELECT objid, objversion INTO :objid, :objversion from '||view_name_ ;
   @ApproveTransactionStatement(2013-11-20,wawilk)
   SAVEPOINT new_job_;
   LOOP
      IF ( intf_file_is_on_client_ ) THEN
         FETCH Intface_Job_Detail_API.Get_String INTO line_no_, file_string_, status_, line_objid_;
         EXIT WHEN  Intface_Job_Detail_API.Get_String%NOTFOUND;
      ELSIF ( intf_file_is_on_server_ ) THEN
         Intface_Job_Detail_API.Get_Next_Line(line_no_, file_string_, end_of_file_);
         EXIT WHEN end_of_file_;
      END IF;
      Client_Sys.Clear_Attr(attr_);
      Client_Sys.Clear_Attr(update_attr_);
      Client_Sys.Clear_Attr(string_attr_);
      objid_      := NULL;
      objversion_ := NULL;
      commit_seq_ := commit_seq_ +1;
      @ApproveTransactionStatement(2013-11-20,wawilk)
      SAVEPOINT new_string_;
      IF ( String_To_Attr( string_attr_, file_string_, intf_format_error_, intface_name_, intfsorted_cols_, intfdet_rec_, trunc_val_) ) THEN
         FOR rec_ IN get_key_cols LOOP
            IF ( get_key_cols%ROWCOUNT = 1) THEN
               where_clause_ := NULL;
            END IF;
            ptr_ := NULL;
            WHILE (Client_SYS.Get_Next_From_Attr(string_attr_, ptr_, name_, value_)) LOOP
               IF ( name_ = rec_.col_name ) THEN
                  IF ( where_clause_ IS NULL ) THEN
                     where_clause_ := ' WHERE '||rec_.col_name||' = '||rec_.prefix||REPLACE(value_,CHR(39),CHR(39)||CHR(39))||rec_.suffix;
                  ELSE
                     where_clause_ := where_clause_||' AND '||rec_.col_name||' = '||rec_.prefix||REPLACE(value_,CHR(39),CHR(39)||CHR(39))||rec_.suffix;
                  END IF;
               END IF;
            END LOOP;
         END LOOP;
         stmt_ := base_stmt_||where_clause_||'; End;';
         --
         -- Build select to check if this record exists
         --
         h_cur_ := DBMS_SQL.Open_Cursor;
         -- Safe due to appending values are not directly exposed to user inputs
         @ApproveDynamicStatement(2009-11-24,nabalk)
         DBMS_SQL.Parse(h_cur_, stmt_, DBMS_SQL.native);
         DBMS_SQL.bind_variable(h_cur_,'objid', objid_, 2000);
         DBMS_SQL.bind_variable(h_cur_,'objversion', objversion_, 2000);
         -- Execute statement for check
         BEGIN
            dummy_ := DBMS_SQL.Execute(h_cur_);
         EXCEPTION
            WHEN no_data_found THEN -- Continue
               NULL;
            WHEN OTHERS THEN
               IF ( DBMS_SQL.Is_Open(h_cur_)) THEN
                  DBMS_SQL.Close_Cursor(h_cur_);
               END IF;
               sqlerrm_ := SQLERRM;
               @ApproveTransactionStatement(2013-11-20,wawilk)
               ROLLBACK TO SAVEPOINT new_string_;
               RAISE error_in_check_;
         END;
         DBMS_SQL.variable_value(h_cur_,'objid', objid_);
         DBMS_SQL.variable_value(h_cur_,'objversion', objversion_);
         DBMS_SQL.Close_Cursor(h_cur_);
         --
         IF ( objid_ IS NOT NULL ) THEN
            IF ( do_update_ ) THEN
               trace_sys.message('do_update_ = TRUE '||where_clause_);
               -- The record exists
               -- First build update-attr string
               FOR updrec_ IN get_upd_cols LOOP
                  ptr_ := NULL;
                  WHILE (Client_SYS.Get_Next_From_Attr(string_attr_, ptr_, name_, value_)) LOOP
                     IF ( name_ = updrec_.col_name ) THEN
                        From_Attr_To_Attr(update_attr_, string_attr_, updrec_.col_name);
                     END IF;
                  END LOOP;
               END LOOP;
               FOR upddbrec_ IN get_db_cols LOOP
                  ptr_ := NULL;
                  WHILE (Client_SYS.Get_Next_From_Attr(string_attr_, ptr_, name_, value_)) LOOP
                     IF(name_ = upddbrec_.col_name) THEN
                        upd_col_ := NULL;
                        OPEN  get_upd_c_cols(SUBSTR( name_, 0, LENGTH(name_)-3));
                        FETCH get_upd_c_cols INTO upd_col_;
                        CLOSE get_upd_c_cols;
                        IF(upd_col_ IS NOT NULL) THEN
                           From_Attr_To_Attr(update_attr_, string_attr_, name_);
                        END IF;
                     END IF;
                  END LOOP;
               END LOOP;
               --
               -- Execute Modify-method
               --
               IF ( NOT Exec_Base_Method_( info_, objid_, objversion_, update_attr_, 'DO' , 'UPDATE',intf_base_method_error_, intf_insert_h_cur_, intf_update_h_cur_) ) THEN
                  Intface_Job_Detail_API.Process_Job_Details(intface_name_,
                     line_no_ ,file_string_ , attr_ , intf_base_method_error_ , line_objid_ );
                  error_count_ := error_count_ + 1;
                  IF ( NOT intf_ignorexeerror_ ) THEN
                     error_line_ := line_no_;
                     RAISE error_in_update_;
                  END IF;
               ELSE
                  update_count_ := update_count_ + 1;
                  IF ( intf_file_is_on_client_ ) THEN
                     Intface_Job_Detail_API.Process_Job_Details(intface_name_,
                        line_no_ ,file_string_ , attr_ , null , line_objid_ );
                  END IF;
               END IF;
            ELSE
               trace_sys.message('do_update_ = FALSE ');
               IF ( intf_file_is_on_client_ ) THEN
                  Intface_Job_Detail_API.Process_Job_Details(intface_name_,
                     line_no_ ,file_string_ , attr_ , null , line_objid_ );
               END IF;
            END IF;
         ELSE
            IF ( do_insert_ ) THEN
               trace_sys.message('do_insert_ = TRUE ');
               --
               -- Execute Insert (method New__ with PREPARE and DO)
               --
               IF ( prepare_attr_ IS NULL ) THEN
                  -- Execute PREPARE once
                  IF ( Exec_Base_Method_( info_, objid_, objversion_, prepare_attr_, 'PREPARE' , 'INSERT', intf_base_method_error_, intf_insert_h_cur_, intf_update_h_cur_) ) THEN
                     IF ( prepare_attr_ IS NULL ) THEN
                        prepare_attr_ :=  'NOPREPARE' ;
                     ELSE
                        trace_sys.message(' PREPARE attr : ');
                        trace_sys.message(prepare_attr_);
                     END IF;
                  ELSE
                     Intface_Job_Detail_API.Process_Job_Details(intface_name_,
                        line_no_ ,file_string_ , attr_ , intf_base_method_error_ , line_objid_ );
                     IF ( NOT intf_ignorexeerror_ ) THEN
                        RAISE error_in_new_;
                     END IF;
                 END IF;
               END IF;
               IF ( prepare_attr_  != 'NOPREPARE' ) THEN
                  -- Prepare attr has values, complete attr-string
                  attr_ := Merge_Attr_Strings(string_attr_, prepare_attr_);
               ELSE
                  attr_ := string_attr_;
               END IF;
               IF ( Exec_Base_Method_( info_, objid_, objversion_, attr_, 'DO' , 'INSERT', intf_base_method_error_, intf_insert_h_cur_, intf_update_h_cur_) ) THEN
                  insert_count_ := insert_count_ + 1;
                  IF ( intf_file_is_on_client_ ) THEN
                     Intface_Job_Detail_API.Process_Job_Details(intface_name_,
                        line_no_ ,file_string_ , attr_ , null , line_objid_ );
                  END IF;
               ELSE
                  error_count_ := error_count_ + 1;
                  Intface_Job_Detail_API.Process_Job_Details(intface_name_,
                     line_no_ ,file_string_ , attr_ , intf_base_method_error_ , line_objid_ );
                  IF ( NOT intf_ignorexeerror_ ) THEN
                     error_line_ := line_no_;
                     RAISE error_in_new_;
                  END IF;
               END IF;
            --
            ELSE
               trace_sys.message('do_insert_ = FALSE ');
               IF ( intf_file_is_on_client_ ) THEN
                  Intface_Job_Detail_API.Process_Job_Details(intface_name_,
                     line_no_ ,file_string_ , attr_ , null , line_objid_ );
               END IF;
            END IF;
         END IF;
      ELSE
         error_count_ := error_count_ + 1;
         Intface_Job_Detail_API.Process_Job_Details(intface_name_,
            line_no_ ,file_string_ , attr_ , intf_format_error_ , line_objid_ );
         IF ( NOT intf_ignoreaderror_ ) THEN
            error_line_ := line_no_;
            RAISE error_in_format_;
         END IF;
      END IF;
      IF ( nvl(App_Context_SYS.Find_Number_Value(Intface_Job_Detail_API.intf_commit_seq_cid_),commit_seq_+1) <= commit_seq_ ) THEN
         @ApproveTransactionStatement(2013-11-20,wawilk)
         COMMIT;
         Trace_SYS.Message(' TRACE>>>>>>> Commit ');
         commit_count_ := commit_count_ + commit_seq_;
         commit_seq_ := 0;
         @ApproveTransactionStatement(2013-11-20,wawilk)
         SAVEPOINT new_job_;
      END IF;
   END LOOP;
   info_ := Language_SYS.Translate_Constant (lu_name_, 'UPDINTFACEOK: Migration job :P1 completed ', Fnd_Session_API.Get_Language, intface_name_);
   info_ := info_||msg_sep_;
   IF ( insert_count_ > 0 ) THEN
      insert_text_ := Language_SYS.Translate_Constant (lu_name_, 'UPDINTFINS: :P1 new rows inserted', Fnd_Session_API.Get_Language, to_char( insert_count_));
      info_ := info_||msg_sep_||insert_text_;
   END IF;
   IF ( update_count_ > 0 ) THEN
      update_text_ := Language_SYS.Translate_Constant (lu_name_, 'UPDINTFUPD: :P1 rows modified', Fnd_Session_API.Get_Language, to_char( update_count_));
      info_ := info_||msg_sep_||update_text_;
   END IF;
   IF ( error_count_ > 0 ) THEN
      error_text_ := Language_SYS.Translate_Constant (lu_name_, 'UPDINTFERR: :P1 rows failed', Fnd_Session_API.Get_Language, to_char( error_count_));
      info_ := info_||msg_sep_||error_text_;
   END IF;
   IF ( insert_count_ + update_count_ + error_count_ = 0 ) THEN
      error_text_ := Language_SYS.Translate_Constant (lu_name_, 'NOROWS: No rows processed', Fnd_Session_API.Get_Language );
      info_ := info_||msg_sep_||error_text_;
   END IF;
   App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_execution_ok_cid_,TRUE);
EXCEPTION
   WHEN error_in_format_ THEN
      @ApproveTransactionStatement(2013-11-20,wawilk)
      ROLLBACK TO SAVEPOINT new_job_;
      IF ( dbms_sql.is_open(intf_insert_h_cur_)) THEN
         DBMS_SQL.Close_Cursor(intf_insert_h_cur_);
      END IF;
      IF ( dbms_sql.is_open(intf_update_h_cur_)) THEN
         DBMS_SQL.Close_Cursor(intf_update_h_cur_);
      END IF;
      Client_SYS.Add_Info(lu_name_, 'FORMATERROR: Formatting failed - :P1. (Error caused by line: :P2)', intf_format_error_, error_line_);
      IF ( commit_count_ > 0 ) THEN
         Client_SYS.Add_Info(lu_name_, 'COMMITCNT:  :P1 Number of rows commited : :P2', msg_sep_ , to_char(commit_count_));
      END IF;
      info_ := Client_Sys.Get_All_Info;
   WHEN error_in_check_ THEN
      IF ( dbms_sql.is_open(intf_insert_h_cur_)) THEN
         DBMS_SQL.Close_Cursor(intf_insert_h_cur_);
      END IF;
      IF ( dbms_sql.is_open(intf_update_h_cur_)) THEN
         DBMS_SQL.Close_Cursor(intf_update_h_cur_);
      END IF;
      Trace_Long_Msg(stmt_);
      Client_SYS.Add_Info(lu_name_, 'UPDERRORCHK: Error :P1 when executing :P2  ', sqlerrm_, stmt_ );
      info_ :=  Client_Sys.Get_All_Info;
      Intface_Job_Detail_API.Process_Job_Details(intface_name_,
         line_no_ ,file_string_ , attr_ , info_ , line_objid_ );
   WHEN error_in_new_ THEN
      @ApproveTransactionStatement(2013-11-20,wawilk)
      ROLLBACK TO SAVEPOINT new_job_;
      IF ( dbms_sql.is_open(intf_insert_h_cur_)) THEN
         DBMS_SQL.Close_Cursor(intf_insert_h_cur_);
      END IF;
      IF ( dbms_sql.is_open(intf_update_h_cur_)) THEN
         DBMS_SQL.Close_Cursor(intf_update_h_cur_);
      END IF;
      Client_SYS.Add_Info(lu_name_, 'UPDERRORNEW: Insert into :P1 failed - :P2 (Error caused by line: :P3)', view_name_||'_TAB', intf_base_method_error_, error_line_) ;
      IF ( commit_count_ > 0 ) THEN
         Client_SYS.Add_Info(lu_name_, 'COMMITCNT:  :P1 Number of rows commited : :P2', msg_sep_ , to_char(commit_count_));
      END IF;
      info_ := Client_Sys.Get_All_Info;
   WHEN error_in_update_ THEN
      IF ( dbms_sql.is_open(intf_insert_h_cur_)) THEN
         DBMS_SQL.Close_Cursor(intf_insert_h_cur_);
      END IF;
      IF ( dbms_sql.is_open(intf_update_h_cur_)) THEN
         DBMS_SQL.Close_Cursor(intf_update_h_cur_);
      END IF;
      Client_SYS.Add_Info(lu_name_, 'UPDERRORUPD: Update of :P1 failed - :P2 (Error caused by line: :P3)', view_name_||'_TAB', intf_base_method_error_, error_line_);
      IF ( commit_count_ > 0 ) THEN
         Client_SYS.Add_Info(lu_name_, 'COMMITCNT:  :P1 Number of rows commited : :P2', msg_sep_ , to_char(commit_count_));
      END IF;
      info_ := Client_Sys.Get_All_Info;
   WHEN OTHERS THEN
      IF ( dbms_sql.is_open(intf_insert_h_cur_)) THEN
         DBMS_SQL.Close_Cursor(intf_insert_h_cur_);
      END IF;
      IF ( dbms_sql.is_open(intf_update_h_cur_)) THEN
         DBMS_SQL.Close_Cursor(intf_update_h_cur_);
      END IF;
      info_ := SQLERRM;
      Intface_Job_Detail_API.Process_Job_Details(intface_name_,
         line_no_ ,file_string_ , attr_ , info_ , line_objid_ );
END Insert_Or_Update;


PROCEDURE Load_Intface_Info (
   intface_name_ IN VARCHAR2 )
IS
   rec_nbr_            NUMBER;
   no_details_         EXCEPTION;
   separator_flag_     VARCHAR2(1);
   --
   intf_detail_ Intface_Detail_Util_API.intfdet_tab_type;
BEGIN
   
   -- Set session context values 
   --
   Set_Current_File_Path_(Intface_Header_API.Get_Intface_Path(intface_name_));
   Set_Current_File_Name_(Intface_Header_API.Get_Intface_File(intface_name_));
    
   -- Set global variables with info from headers
   --
   --intf_file_name_ := Intface_Header_API.Get_Intface_File(
   --                        intface_name_);
   --intf_file_path_ := Intface_Header_API.Get_Intface_Path(intface_name_);
   --intf_backup_path_    := NULL;
   --
   -- Is this a file with fixed format, or comma-separated?
   -- Used in ORDER BY in Cursor.
   --
   IF (Intface_Header_API.Get_Column_Separator(intface_name_) IS NULL ) THEN
      separator_flag_ := '0';
   ELSE
      separator_flag_ := '1';
   END IF;
   --
   -- Loads formatting information from intface header and detail
   -- into global table + variables
   --
   intf_detail_ := Intface_Detail_Util_API.Get_Intface_Details(intface_name_); 
   rec_nbr_ := intf_detail_.count;
   --
   --
   -- TODO: Add validation here
   IF ( rec_nbr_ = 0) THEN
      -- Server file or client file must have details specified
      IF ( Intface_File_Location_API.Encode(Intface_Header_API.Get_File_Location(intface_name_ )) != '3' ) THEN
         RAISE no_details_;
      END IF;
   END IF;
EXCEPTION
   WHEN no_details_ THEN
      Error_SYS.Record_General(lu_name_, 'NODET: No details found for  :P1', intface_name_ );
   WHEN OTHERS THEN
      Error_SYS.Record_General(lu_name_, 'LOADERR: Error loading migration job info :P1', SQLERRM );
END Load_Intface_Info;


PROCEDURE Open_File (
   intface_name_ IN VARCHAR2,
   file_action_  IN VARCHAR2 DEFAULT 'R' )
IS
   file_not_found_     EXCEPTION;
   character_set_      VARCHAR2(100) := Intface_Header_API.Get_File_Encoding(intface_name_);
   intf_procedure_name_ intface_header_tab.procedure_name%TYPE := Intface_Header_API.Get_Procedure_Name(intface_name_);
   file_name_          VARCHAR2(200);
   intf_file_path_ intface_header_tab.intface_path%TYPE := Get_Current_File_Path;
   intf_file_name_ intface_header_tab.intface_file%TYPE := Get_Current_File_Name;
   
   FUNCTION get_sys_guid RETURN VARCHAR2 IS
      a_ VARCHAR2(100);
   BEGIN
      @ApproveDynamicStatement(2009-11-24,nabalk)
      EXECUTE IMMEDIATE 'SELECT SYS_GUID() FROM dual' INTO a_;
      RETURN a_;
   EXCEPTION
      WHEN OTHERS THEN
         RETURN NULL;
   END get_sys_guid;
BEGIN
   --
   IF ( file_action_ != 'W' ) THEN
      IF (Intface_Header_API.File_Exist(intf_file_path_, intf_file_name_)) THEN
        intf_file_handle_ := UTL_FILE.FOPEN (intf_file_path_, intf_file_name_, file_action_, 32767 );
     ELSE
        raise file_not_found_;
      END IF;
   ELSIF ( (intf_file_name_ like '*.%') AND (intf_procedure_name_ LIKE 'FNDMIG_EXPORT%')) THEN
      -- Wildcard from FNDMIG_EXPORT
      NULL; -- Do nothing, will be handled in Intface_Header_API.Fndmig_Export
   ELSE
      file_name_ := Replace_Keywords___(intf_file_name_, intface_name_);
      intf_file_handle_ := UTL_FILE.FOPEN (intf_file_path_, file_name_, file_action_, 32767 );
      intf_file_name_ := file_name_ ;
      Set_Current_File_Name_(intf_file_name_);
   END IF;
   IF character_set_ IS NOT NULL THEN
      Database_SYS.Set_File_Encoding(character_set_);
   ELSE
      Database_SYS.Set_Default_File_Encoding;
   END IF;
EXCEPTION
   WHEN file_not_found_ THEN
      Error_SYS.Record_General(lu_name_, 'FILENOTFOUND: Cannot find file  :P1 on path :P2.', intf_file_name_, intf_file_path_);
END Open_File;


PROCEDURE Close_Normal
IS
BEGIN
   UTL_FILE.FCLOSE(intf_file_handle_);
   Database_SYS.Set_Default_File_Encoding;
END Close_Normal;


PROCEDURE Flush_File_Handle
IS
BEGIN
   UTL_FILE.FFLUSH(intf_file_handle_);
END Flush_File_Handle;


PROCEDURE Get_Next_Line (
   line_out_ IN OUT VARCHAR2,
   eof_out_  IN OUT BOOLEAN )
IS
   NO_DATA_FOUND EXCEPTION;
   INVALID_PATH EXCEPTION;
   INVALID_MODE EXCEPTION;
   INVALID_FILEHANDLE EXCEPTION;
   INVALID_OPERATION EXCEPTION;
   READ_ERROR EXCEPTION;
   WRITE_ERROR EXCEPTION;
   INTERNAL_ERROR EXCEPTION;
   line_ VARCHAR2(32000);
BEGIN
   UTL_FILE.GET_LINE (intf_file_handle_, line_);
   WHILE ( line_ IS NULL ) LOOP 
      UTL_FILE.GET_LINE (intf_file_handle_, line_);
   END LOOP;
   line_out_ := Database_SYS.File_To_Db_Encoding(line_);
   eof_out_ := FALSE;
EXCEPTION
   WHEN INVALID_PATH THEN
      eof_out_  := TRUE;
   WHEN INVALID_MODE THEN
      eof_out_  := TRUE;
   WHEN INVALID_FILEHANDLE THEN
      eof_out_  := TRUE;
   WHEN INVALID_OPERATION THEN
      eof_out_  := TRUE;
   WHEN READ_ERROR THEN
      eof_out_  := TRUE;
   WHEN WRITE_ERROR THEN
      eof_out_  := TRUE;
   WHEN INTERNAL_ERROR THEN
      eof_out_  := TRUE;
   WHEN NO_DATA_FOUND THEN
      line_out_ := NULL;
      eof_out_  := TRUE;
   WHEN OTHERS THEN
      eof_out_  := TRUE;
END Get_Next_Line;


@UncheckedAccess
FUNCTION Get_Column_Description (
   view_name_   IN VARCHAR2,
   column_name_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   description_ VARCHAR2(100);
   prompt_desc_ VARCHAR2(100);
   --
   CURSOR get_column_prompt IS
   SELECT Dictionary_SYS.Comment_Value_('PROMPT',comments)
   FROM user_col_comments
   WHERE table_name = view_name_
   AND column_name = column_name_;
BEGIN
   description_ :=  nvl(Language_SYS.Translate_Item_Prompt_(view_name_||'.'||column_name_,column_name_,1),column_name_);
   -- Get prompt on comments if no translation available
   IF ( description_ = column_name_ ) THEN
      OPEN  get_column_prompt;
      FETCH get_column_prompt INTO prompt_desc_;
         IF ( prompt_desc_ IS NOT NULL ) THEN
            description_ := prompt_desc_;
         END IF;
      CLOSE get_column_prompt;
   END IF;
   RETURN description_;
EXCEPTION
   WHEN OTHERS THEN
      RETURN column_name_;
END Get_Column_Description;


@UncheckedAccess
FUNCTION Get_Column_Flags (
   view_name_   IN VARCHAR2,
   column_name_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   novalue_ VARCHAR2(1) := '';
   temp_ VARCHAR2(5);
   CURSOR get_flags IS
      SELECT  replace(decode(substr(Dictionary_SYS.Comment_Value_('FLAGS',comments), 1, 1),'P','P',
              decode(substr(Dictionary_SYS.Comment_Value_('FLAGS',comments), 1, 1),'K','K',
              substr(Dictionary_SYS.Comment_Value_('FLAGS',comments), 2, 3))),'-','') flags
      FROM   user_tab_columns A, user_col_comments B
      WHERE  A.table_name  = B.table_name
      AND    A.column_name = B.column_name
      AND    A.table_name = view_name_
      AND    A.column_name = column_name_
      AND    (substr(Dictionary_SYS.Comment_Value_('FLAGS',comments), 1, 1) IN ('P','K') OR
              substr(Dictionary_SYS.Comment_Value_('FLAGS',comments), 4, 1) = 'U' OR
              substr(Dictionary_SYS.Comment_Value_('FLAGS',comments), 3, 1) = 'I')
      ORDER BY A.column_id;
BEGIN
   OPEN  get_flags ;
   FETCH get_flags INTO temp_ ;
   CLOSE get_flags ;
   RETURN temp_;
EXCEPTION
   WHEN OTHERS THEN
      RETURN novalue_;
END Get_Column_Flags;


PROCEDURE Backup_Server_File (
   intface_name_ IN VARCHAR2,
   backup_path_  IN VARCHAR2 )
IS
   end_of_file_     BOOLEAN := FALSE;
   file_string_     VARCHAR2(32000);
   backup_file_     intface_header.intface_file%TYPE;
   backup_handle_   UTL_FILE.FILE_TYPE;
   character_set_   VARCHAR2(100) := Intface_Header_API.Get_File_Encoding(intface_name_);
BEGIN
   Open_File(intface_name_, 'R');
   backup_file_ := Get_Backup_File_Name(intface_name_);
   backup_handle_ := UTL_FILE.FOPEN (backup_path_, backup_file_, 'W', 32767 );
   IF character_set_ IS NOT NULL THEN
      Database_SYS.Set_File_Encoding(character_set_);
   END IF;
   --
   Get_Next_Line(file_string_, end_of_file_);
   WHILE NOT end_of_file_ LOOP
      UTL_FILE.PUT_LINE (backup_handle_, Database_SYS.Db_To_File_Encoding(file_string_));
      intface_detail_api.Get_Next_Line(file_string_, end_of_file_);
   END LOOP;
   UTL_FILE.FCLOSE_ALL;
   Database_SYS.Set_Default_File_Encoding;
END Backup_Server_File;


@UncheckedAccess
FUNCTION Get_Backup_File_Name (
   intface_name_ IN VARCHAR2,
   file_name_    IN VARCHAR2 DEFAULT NULL ) RETURN VARCHAR2
IS
   org_file_    intface_header.intface_file%TYPE;
   backup_file_ intface_header.intface_file%TYPE;
   backup_no_   NUMBER;
BEGIN
   -- Build a filename that consists of originial file name (without ext.)
   -- + a 4 char sequence + suffix .bkp
   -- Use current file_name_ in context if defined, to support use of generic variables in filename (USER,TIME osv)
   org_file_ := nvl(file_name_,nvl(Get_Current_File_Name,
                Intface_Header_API.Get_Intface_File(intface_name_)));
   --
   SELECT intface_backup_file_seq.nextval
   INTO   backup_no_
   FROM dual;
   --
   backup_file_ := substr(org_file_,1,instr(org_file_,'.')-1 )||
                      to_char(backup_no_)||'.bkp';
   RETURN backup_file_;
END Get_Backup_File_Name;


FUNCTION Merge_Attr_Strings (
   string_attr_  IN VARCHAR2,
   prepare_attr_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   attr_ VARCHAR2(32000);
   ptr_   NUMBER;
   name_  VARCHAR2(2000);
   value_ VARCHAR2(2000);
BEGIN
   ptr_ := NULL;
   attr_ := string_attr_;
   -- Sets attr_ equal string_attr_, then add missing items from prepare_attr_
   WHILE (Client_SYS.Get_Next_From_Attr(prepare_attr_, ptr_, name_, value_)) LOOP
      IF ( Client_SYS.Get_Item_Value(name_ , attr_ ) IS NULL ) THEN
         Client_SYS.Set_Item_Value(name_, value_, attr_);
      END IF;
   END LOOP;
   RETURN attr_;
END Merge_Attr_Strings;


PROCEDURE Enum_Db_Client_Values (
   info_             IN OUT VARCHAR2,
   db_client_values_ IN OUT VARCHAR2,
   db_values_        IN OUT VARCHAR2,
   client_values_    IN OUT VARCHAR2,
   prefixed_column_  IN     VARCHAR2,
   in_lu_db_name_    IN     VARCHAR2 DEFAULT NULL,
   in_reference_     IN     VARCHAR2 DEFAULT NULL )
IS
   type varchar_tabtype IS
   TABLE OF VARCHAR2(2000)
   INDEX BY BINARY_INTEGER;
   type enumerate_record IS RECORD(
   client_val varchar_tabtype,
   db_val     varchar_tabtype);
   --
   enum_rec_ enumerate_record;
   --
   column_name_  VARCHAR2(200);
   view_name_    VARCHAR2(200);
   iid_lu_       VARCHAR2(2000);
   ref_          VARCHAR2(2000);
   lookup_ref_   VARCHAR2(2000);
   comments_     VARCHAR2(2000);
   db_value_     VARCHAR2(200);
   client_value_ VARCHAR2(200);
   count_        NUMBER := 0;
   stmt_client_  VARCHAR2(2000);
   stmt_db_      VARCHAR2(2000);
   client_cur_   INTEGER;
   db_cur_       INTEGER;
   dummy_        NUMBER;
   db_hdr_       VARCHAR2(20);
   client_hdr_   VARCHAR2(20);
   msg_sep_      VARCHAR2(2) := chr(13)||chr(10);
   no_iid_       EXCEPTION;
   CURSOR get_columns IS
      SELECT b.comments
      FROM user_col_comments B, intface_views_col_info a
      WHERE a.view_name = view_name_
      AND a.column_name = column_name_
      AND a.view_name  = b.table_name
      AND a.column_name = b.column_name;
   --
BEGIN
   --
   view_name_ := substr(prefixed_column_, 1, instr(prefixed_column_, '.')-1);
   column_name_ := substr(prefixed_column_, instr(prefixed_column_, '.')+1);
   --
   db_hdr_ := Language_SYS.Translate_Constant( lu_name_, ' DBVAL : DB-values', Fnd_Session_API.Get_Language);
   client_hdr_ := Language_SYS.Translate_Constant( lu_name_, ' CLIENTVAL : Client-values', Fnd_Session_API.Get_Language);
   --
   trace_sys.message('View name '||view_name_);
   trace_sys.message('Column name '||column_name_);
   IF ( in_lu_db_name_ IS NULL ) THEN
      -- Lookup references for view comments
      OPEN  get_columns;
      FETCH get_columns INTO comments_;
      CLOSE get_columns;
      ref_ := Dictionary_SYS.Comment_Value_('REF', comments_);
      
      IF ref_ IS NULL THEN
         ref_ := Dictionary_SYS.Comment_Value_('ENUMERATION', comments_);
      END IF;
         
      IF ( ref_ IS NOT NULL ) THEN
         -- Remove parentheses and slashes ( f.ex. '/CASCADE')
         -- to extract LU-name only
         IF ( instr(ref_, '(') != 0 ) THEN
            lookup_ref_ := substr(ref_, 1, instr(ref_, '(')-1);
         ELSE
            lookup_ref_ := ref_;
         END IF;
         IF ( instr(lookup_ref_, '/') != 0 ) THEN
            lookup_ref_ := substr(lookup_ref_, 1, instr(lookup_ref_, '/')-1);
         END IF;
         BEGIN
            iid_lu_ := dictionary_SYS.clientnametodbname_(lookup_ref_);
         EXCEPTION
            WHEN OTHERS THEN
               iid_lu_ := NULL;
         END;
      END IF;
      trace_sys.message('Found reference '||lookup_ref_);
      trace_sys.message('Found LU Db name '||iid_lu_);
   ELSE
      -- Lu-name and reference are already known
      -- (Call from IntfaceMethodList)
      iid_lu_ := in_lu_db_name_;
      lookup_ref_ := in_reference_;
      trace_sys.message('Input reference '||lookup_ref_);
      trace_sys.message('Input LU Db name '||iid_lu_);
   END IF;
   -- Check if this is an LU with DB/Client
   IF ( iid_lu_ IS NOT NULL ) THEN
      iid_lu_ := iid_lu_ || '_API';
      trace_sys.message('LU Db name '||iid_lu_);
      stmt_client_  := 'BEGIN :client_value := ' || iid_lu_ || '.Get_Client_Value(:count); End;';
      stmt_db_  := 'BEGIN :db_value := ' || iid_lu_ || '.Get_Db_Value(:count); End;';
      client_cur_ := DBMS_SQL.Open_Cursor;
      db_cur_ := DBMS_SQL.Open_Cursor;
      -- Safe due to appending values are not directly exposed to user inputs
      @ApproveDynamicStatement(2009-11-24,nabalk)
      DBMS_SQL.Parse(client_cur_, stmt_client_, DBMS_SQL.native);
      -- Safe due to appending values are not directly exposed to user inputs
      @ApproveDynamicStatement(2009-11-24,nabalk)
      DBMS_SQL.Parse(db_cur_, stmt_db_, DBMS_SQL.native);
      LOOP
         DBMS_SQL.bind_variable(client_cur_, 'count', count_, 2000);
         DBMS_SQL.bind_variable(client_cur_, 'client_value', client_value_, 2000);
         BEGIN
            dummy_ := DBMS_SQL.Execute(client_cur_);
         EXCEPTION
            WHEN OTHERS THEN
               RAISE no_iid_;
         END;
         --
         DBMS_SQL.variable_value(client_cur_, 'client_value', client_value_);
         --
         DBMS_SQL.bind_variable(db_cur_, 'count', count_, 2000);
         DBMS_SQL.bind_variable(db_cur_, 'db_value', db_value_, 2000);
         dummy_ := DBMS_SQL.Execute(db_cur_);
         DBMS_SQL.variable_value(db_cur_, 'db_value', db_value_);
         -- Keep track of maxlength
         --
         EXIT WHEN db_value_ IS NULL;
         enum_rec_.db_val(count_) := db_value_;
         enum_rec_.client_val(count_) := client_value_;
         count_ := count_ + 1;
         db_value_ := NULL;
         client_value_ := NULL;
      END LOOP;
      count_ := count_ - 1;
      db_client_values_ := lookup_ref_ || msg_sep_ || msg_sep_ ;
      db_client_values_ := db_client_values_ || db_hdr_|| ' <==> ' ||client_hdr_|| ' :' || msg_sep_|| msg_sep_;
      --
      db_values_ := lookup_ref_ || msg_sep_ || msg_sep_ || db_hdr_||' :' || msg_sep_|| msg_sep_;
      client_values_ := lookup_ref_ || msg_sep_ || msg_sep_ ||client_hdr_||' :' || msg_sep_|| msg_sep_;
      FOR i IN 0..count_ LOOP
         db_client_values_ := db_client_values_ || enum_rec_.db_val(i)|| ' <==> ' ||enum_rec_.client_val(i) || msg_sep_;
         db_values_ := db_values_ || enum_rec_.db_val(i) || msg_sep_;
         client_values_ := client_values_ || enum_rec_.client_val(i) || msg_sep_;
      END LOOP;
      info_ := Language_SYS.Translate_Constant( lu_name_, ' VALFOUND : DB/Client values found', Fnd_Session_API.Get_Language);
      DBMS_SQL.Close_Cursor(client_cur_);
      DBMS_SQL.Close_Cursor(db_cur_);
   END IF;
   trace_sys.message(info_);
EXCEPTION
   WHEN no_iid_ THEN
      IF ( DBMS_SQL.Is_Open(client_cur_) ) THEN
         DBMS_SQL.Close_Cursor(client_cur_);
      END IF;
      IF ( DBMS_SQL.Is_Open(db_cur_) ) THEN
         DBMS_SQL.Close_Cursor(db_cur_);
      END IF;
      info_ := Language_SYS.Translate_Constant( lu_name_, ' NOVAL : No DB/Client values for :P1', Fnd_Session_API.Get_Language, iid_lu_);
      trace_sys.message(info_);
   WHEN OTHERS THEN
      IF ( DBMS_SQL.Is_Open(client_cur_) ) THEN
         DBMS_SQL.Close_Cursor(client_cur_);
      END IF;
      IF ( DBMS_SQL.Is_Open(db_cur_) ) THEN
         DBMS_SQL.Close_Cursor(db_cur_);
      END IF;
      trace_sys.message(SQLERRM);
      info_ := SQLERRM;
END Enum_Db_Client_Values;


PROCEDURE Trace_Long_Msg (
   msg_ IN VARCHAR2 )
IS
   cnt_ NUMBER;
   ptr_ NUMBER;
BEGIN
   -- Display long statements, 250 char per line
   IF ( ltrim(msg_) IS NOT NULL ) THEN
      cnt_ := ceil(length(msg_)/250);
      ptr_ := 1;
      FOR i IN 1..cnt_ LOOP
         Trace_SYS.Message(substr(msg_,ptr_,250));
         ptr_ := ptr_ + 250;
      END LOOP;
   END IF;
END Trace_Long_Msg;





