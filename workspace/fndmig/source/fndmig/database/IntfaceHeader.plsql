-----------------------------------------------------------------------------
--
--  Logical unit: IntfaceHeader
--  Component:    FNDMIG
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  140818  ChMuLK Bug #118357 - (TEBASE-515) Truncating Status information in Start_Job_Batch_
--  140309  UsRaLK Bug #115101 - (TEBASE-83) Modified [Start_Job] to remove incorrect initialization of next_execution_date_.
--  130206  UsRaLK Bug #107799 - Modified [Start_Job] to refer scheduled task instead of the server process.
--  130102  ChMuLK Bug #103540 - Increase size of last_info.
--  120228  HAARSE Deadlock when logging in Batch Schedule Chain (RDTERUNTIME-1997).
--  120215  UsRaLK Limited the Job ID length for MIGRATE_SOURCE_DATA to 22 (RDTERUNTIME-2027).
--  101007  JHMASE Bug #93452 - Default Where not reset after multifile export
--  100930  JHMASE Bug #93329 - Added info to Set_Last_Info and changes in Build_Deploy_Code__
--  100929  JHMASE Bug #93302 - Problem with procedure MIGRATE_SOURCE_DATA
--  100629  JHMASE Bug #90886 - Users with NoUpdateAllowed privilege can create job
--  100505  HAYALK Replaced call to Batch_Sys.New_Job with Batch_SYS.New_Batch_Schedule.
--  100126  JHMASE Bug #88651 - Import fails with ORA-6505: character string buffer to small
--  091124  NABALK Bug #84218 - Certified the assert safe for dynamic SQLs
--  081128  JHMASE Bug #78954 - Removal of obsolete remarks.
--  081020  DUWILK Bug #76252 - Increase the varible length in Fndmig_Export__.
--  080924  JHMASE Bug #76776 - Validate INTFACE_NAME length for certain job types
--  080923  JHMASE Bug #76644 - Drop IC table when CREATE_TABLE_FROM_FILE job is removed
--  070918  TRLYNO Bug #70434 - Adding 'Start time' and 'End time' to info for file-jobs
--                              Add recent file-rules to last_info
--  071107  SUMALK Bug #67561 - Data Migration Job for INSERT_OR_UPDATE skips State column
--  070803  JHMASE Bug #67012 - Internal corrections and added functinality
--  070606  TRLYNO G428770    - Making separate procedure for REPLICATION
--  061101  JHMASE Bug #61569 - Attribute descriptions longer then 50 characters
--  061029  TRLYNO Bug #61381 - EXT_ATTR missing in Copy_Intface
--  061101  JHMASE Bug #61256 - Export file fails to import
--  060808  TRLYNO Bug #59318 - FNDMIG bugfixes
--  060630  JHMASE Bug #58176 - Replaced USER with Fnd_Session_API.Get_Fnd_User
--  060329  TRLYNO Bug #56862 - FNDMIG added functionality
--  060209  TRLYNO Bug #55643 - Change view-definitions from user_ to dba_
--                              Added view for character set
--                              Improved feedback message from Export
--                              Bugfixed starting of background processes
--  060105  TRLYNO Bug #55479 - Added functionality in Data Migration
--  050920  TRLYNO Bug #53504 - Max open cursors reached when loading data
--  050920  JHMASE Bug #53464 - Cannot create migration job when view name
--                              longer then 26 characters.
--  050306  TRLY   Bug #50034 - Allowed wildcard in filename on export.
--                              New procedure for starting jobs from server,
--                              with return-parameter for execution status.
--  050203  JHMASE Bug #49452 - Export format Deploy files fail to install
--  041222  JHMASE Bug #48786 - Make it work with double byte
--  041116  JHMASE Bug #48018 - Create INTFACE_REPL_EXPORT_INFO view here
--  041021  JHMASE Bug #47524 - A user can not access a copied job
--  040507  TRLY   Bug #44483 - Replication of Object structures
--  040503  TRLY   ReplicationOut: Added columns message_type and message name.
--                 Message_Type : handle client value according to old templates.
--  040427  JHMASE Bug #44290 - Fail with IntfacePrefixOption does not exist
--  040325  JHMASE Bug #43733 - Fail to compile on fresh install
--  040210  JHMASE Bug #42618 - Corrections
--  030708  TRLY   Prepared for new module FNDMI
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------

TYPE varchar_longtype IS
   TABLE OF VARCHAR2(32000)
   INDEX BY BINARY_INTEGER;

TYPE varchar_tabtype IS
   TABLE OF VARCHAR2(2000)
   INDEX BY BINARY_INTEGER;

TYPE insert_record IS RECORD (
   attr          varchar_longtype,
   table_name    varchar_tabtype,
   master_table  varchar_tabtype,
   key_value     varchar_tabtype,
   rowtyp        varchar_tabtype);   

TYPE Selection_Info IS RECORD (
selected_jobs_       VARCHAR2(32767),
selected_groups_     VARCHAR2(32767),
selected_lists_      VARCHAR2(32767),
selected_trig_       VARCHAR2(32767),
selected_pack_       VARCHAR2(32767));

repl_recsep_   CONSTANT VARCHAR2(7) := '#CHR30#';

repl_fieldsep_ CONSTANT VARCHAR2(7) := '#CHR31#';


-------------------- PRIVATE DECLARATIONS -----------------------------------

crlf_                CONSTANT VARCHAR2(2) := CHR(13)||CHR(10);

cr_                  CONSTANT VARCHAR2(1) := CHR(13);

lf_                  CONSTANT VARCHAR2(1) := CHR(10);

quot_                CONSTANT VARCHAR2(1) := CHR(39);

amp_                 CONSTANT VARCHAR2(1) := CHR(38);

record_separator_    CONSTANT VARCHAR2(1) := Client_SYS.Record_Separator_;

field_separator_     CONSTANT VARCHAR2(1) := Client_SYS.Field_Separator_;

replace_lf_          CONSTANT VARCHAR2(7) := '#CHR10#';

replace_cr_          CONSTANT VARCHAR2(7) := '#CHR13#';

replace_amp_         CONSTANT VARCHAR2(7) := '#CHR38#';

replace_quot_        CONSTANT VARCHAR2(7) := '#CHR39#';

repl_dummy_recsep_   CONSTANT VARCHAR2(8) := '#CHR130#';

repl_dummy_fieldsep_ CONSTANT VARCHAR2(8) := '#CHR131#';


-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------

FUNCTION Add_To_Info___ (
   info_     IN VARCHAR2,
   text_1_   IN VARCHAR2,
   text_2_   IN VARCHAR2 DEFAULT NULL,
   text_3_   IN VARCHAR2 DEFAULT NULL,
   text_4_   IN VARCHAR2 DEFAULT NULL ) RETURN VARCHAR2
IS
   text_ VARCHAR2(32000);
BEGIN
   IF ( text_1_ IS NULL ) THEN
      RETURN info_;
   END IF;
   IF ( info_ IS NOT NULL ) THEN
      text_ := info_ || crlf_ || text_1_;
   ELSE
      text_ := text_1_;
   END IF;
   IF ( text_2_ IS NOT NULL ) THEN
      text_ := text_ || crlf_ || text_2_;
   END IF;
   IF ( text_3_ IS NOT NULL ) THEN
      text_ := text_ || crlf_ || text_3_;
   END IF;
   IF ( text_4_ IS NOT NULL ) THEN
      text_ := text_ || crlf_ || text_4_;
   END IF;
   RETURN text_;
EXCEPTION
   WHEN OTHERS THEN RETURN text_;
END Add_To_Info___;


PROCEDURE Validate_Name___ (
   intface_name_   IN VARCHAR2,
   procedure_name_ IN VARCHAR2 )
IS
   name_to_long_ EXCEPTION;
   max_length_   NUMBER;
BEGIN
   IF ( procedure_name_ = 'REPLICATION' AND LENGTH(intface_name_) > 26 ) THEN
      max_length_ := 26;
      RAISE name_to_long_;
   END IF;
   IF ( procedure_name_ = 'REPLIC_DATA_OUT' AND LENGTH(intface_name_) > 22 ) THEN
      max_length_ := 22;
      RAISE name_to_long_;
   END IF;
   IF ( procedure_name_ = 'CREATE_TABLE_FROM_FILE' AND LENGTH(intface_name_) > 23 ) THEN
      max_length_ := 23;
      RAISE name_to_long_;
   END IF;
   IF ( procedure_name_ = 'MIGRATE_SOURCE_DATA' AND LENGTH(intface_name_) > 22 ) THEN
      max_length_ := 22;
      RAISE name_to_long_;
   END IF;
EXCEPTION
   WHEN name_to_long_ THEN
      Error_SYS.Appl_General(lu_name_, 'NAMEERR: When type = :P1, name may not be longer then :P2 characters (:P3)',
                             procedure_name_, TO_CHAR(max_length_), SUBSTR(intface_name_,1,max_length_));
END Validate_Name___;


@Override
PROCEDURE Prepare_Insert___ (
   attr_ IN OUT VARCHAR2 )
IS
BEGIN
   super(attr_);
   Client_SYS.Add_To_Attr('FILE_LOCATION',Intface_File_Location_API.Decode('3'), attr_);
   Client_SYS.Add_To_Attr('REPLICATION_MODE',Intface_Mode_API.Decode('1'), attr_);
   Client_SYS.Add_To_Attr('ENABLED','FALSE', attr_);
   Client_SYS.Add_To_Attr('ON_INSERT','FALSE', attr_);
   Client_SYS.Add_To_Attr('ON_UPDATE','FALSE', attr_);
END Prepare_Insert___;


@Override
PROCEDURE Insert___ (
   objid_      OUT    VARCHAR2,
   objversion_ OUT    VARCHAR2,
   newrec_     IN OUT INTFACE_HEADER_TAB%ROWTYPE,
   attr_       IN OUT VARCHAR2 )
IS
   user_attr_   VARCHAR2(2000);
   user_objid_  VARCHAR2(2000);
   user_objver_ VARCHAR2(2000);
   user_info_   VARCHAR2(2000);
BEGIN
   super(objid_, objversion_, newrec_, attr_);
   IF (newrec_.procedure_name = 'QUICK_REPORT_OUT') THEN
      Error_SYS.Appl_General(lu_name_, 'DEPREC: Data Migration Quick Report Export Functionality is Deprecated. Use the built in Import/Export functionality in Quick Reports instead.');
   END IF;
   IF (newrec_.procedure_name = 'EXCEL_MIGRATION') THEN
      Basic_Data_Translation_API.Insert_Basic_Data_Translation('FNDMIG', 'IntfaceHeader', newrec_.intface_name||'^'||'DESCRIPTION',NULL, newrec_.description);
      Basic_Data_Translation_API.Insert_Basic_Data_Translation('FNDMIG', 'IntfaceHeader', newrec_.intface_name ||'^'||'NOTE_TEXT', NULL, newrec_.note_text);
   END IF;
   SELECT OBJID, OBJVERSION
      INTO  objid_, objversion_
      FROM  INTFACE_HEADER
      WHERE intface_name = newrec_.intface_name;
   --
   -- Inserting corresponding data into Intface_Detail and Intface_Rules:
   --
   Intface_Rules_API.Insert_Default_Rules( newrec_.intface_name,
                                           newrec_.procedure_name );
   --
   -- Prepare data if this is conversion
   IF ( Intface_Direction_API.Encode(
           Intface_Procedures_API.Get_Direction(
              Intface_Header_API.Get_Procedure_name(newrec_.intface_name))) = '4' ) THEN
      Prepare_Convert_Data__(newrec_.intface_name,
                             newrec_.view_name,
                             newrec_.source_name,
                             newrec_.source_owner);
   ELSIF (newrec_.procedure_name IN ( 'FNDMIG_EXPORT','FNDMIG_IMPORT') ) THEN
      Insert_Default_Details__(newrec_.intface_name, newrec_.procedure_name );
   ELSIF (newrec_.view_name IS NOT NULL ) THEN
      Insert_Default_Details__(newrec_.intface_name, newrec_.view_name);
   END IF;
   BEGIN
      -- Make this intface available from 'Start intface' for this user
      Client_SYS.Clear_Attr(user_attr_);
      Client_SYS.Add_To_Attr('IDENTITY', Fnd_Session_API.Get_Fnd_User, user_attr_);
      Client_SYS.Add_To_Attr('INTFACE_NAME',newrec_.intface_name , user_attr_);
      Intface_Pr_User_API.New__(user_info_, user_objid_, user_objver_, user_attr_,'DO');
   EXCEPTION
      WHEN OTHERS THEN NULL;
   END;
   -- Generate Trigger if procedure is REPLICATION
   IF newrec_.procedure_name = 'REPLICATION' THEN
      Intface_Util_API.Generate_Trigger_(newrec_.intface_name,newrec_.table_name,newrec_.enabled,
           newrec_.on_insert,newrec_.on_update,newrec_.replication_mode);
   END IF;
EXCEPTION
   WHEN dup_val_on_index THEN
      Error_SYS.Record_Exist(lu_name_);
END Insert___;


@Override
PROCEDURE Update___ (
   objid_      IN     VARCHAR2,
   oldrec_     IN     INTFACE_HEADER_TAB%ROWTYPE,
   newrec_     IN OUT INTFACE_HEADER_TAB%ROWTYPE,
   attr_       IN OUT VARCHAR2,
   objversion_ IN OUT VARCHAR2,
   by_keys_    IN     BOOLEAN DEFAULT FALSE )
IS
   direction_   VARCHAR2(20);
BEGIN
   super(objid_, oldrec_, newrec_, attr_, objversion_, by_keys_);
   IF newrec_.procedure_name = 'EXCEL_MIGRATION' THEN
      Basic_Data_Translation_API.Insert_Basic_Data_Translation('FNDMIG', 'IntfaceHeader', newrec_.intface_name||'^'||'DESCRIPTION', NULL,
                                                               newrec_.description, oldrec_.description);
      Basic_Data_Translation_API.Insert_Basic_Data_Translation('FNDMIG', 'IntfaceHeader', newrec_.intface_name ||'^'||'NOTE_TEXT', NULL, 
                                                               newrec_.note_text, oldrec_.note_text);
   END IF;
   -- To be used at end of Update__
   direction_ := Intface_Direction_API.Encode(
                    Intface_Procedures_API.Get_Direction( newrec_.procedure_name));
   --
   -- Generate Trigger if procedure is REPLICATION
   IF newrec_.procedure_name = 'REPLICATION' THEN
      Intface_Util_API.Generate_Trigger_(newrec_.intface_name,newrec_.table_name,
           newrec_.enabled,newrec_.on_insert,newrec_.on_update,
           newrec_.replication_mode);
   END IF;
   -- Add columns if view-name for file-jobs changes
   IF ( ( NVL(oldrec_.view_name,'**') != newrec_.view_name) AND direction_ IN ('1','2') ) THEN
      Insert_Default_Details__(newrec_.intface_name, newrec_.view_name);
   END IF;
   IF ( oldrec_.procedure_name != newrec_.procedure_name ) THEN
      Intface_Rules_API.Cleanup_Default_Rules( newrec_.intface_name,
                                               oldrec_.procedure_name,
                                               newrec_.procedure_name );
   END IF;

EXCEPTION
   WHEN dup_val_on_index THEN
      Error_SYS.Record_Exist(lu_name_);
END Update___;


@Override
PROCEDURE Check_Delete___ (
   remrec_ IN INTFACE_HEADER_TAB%ROWTYPE )
IS
BEGIN
   IF ( Intface_Repl_Maint_Util_API.Are_Objects_Generated(remrec_.intface_name, 'TRIGGER') = 'TRUE' ) THEN
      Error_SYS.Record_General(lu_name_, 'TRIGDEL: Triggers must be dropped before you can delete this job');
   END IF;
   -- Automatc delete from this table because there was an
   -- automatic insert when executing procedure Insert___
   DELETE FROM intface_pr_user_tab
   WHERE intface_name = remrec_.intface_name
   AND identity = Fnd_Session_API.Get_Fnd_User;
   --
   super(remrec_);
END Check_Delete___;


@Override
PROCEDURE Delete___ (
   objid_  IN VARCHAR2,
   remrec_ IN INTFACE_HEADER_TAB%ROWTYPE )
IS
BEGIN
   super(objid_, remrec_);
   -- Remove basic data translations
   IF remrec_.procedure_name = 'EXCEL_MIGRATION' THEN
      Basic_Data_Translation_API.Remove_Basic_Data_Translation('FNDMIG', 'IntfaceHeader', remrec_.intface_name ||'^'||'DESCRIPTION');
      Basic_Data_Translation_API.Remove_Basic_Data_Translation('FNDMIG', 'IntfaceHeader', remrec_.intface_name ||'^'||'NOTE_TEXT');
   END IF;
   -- Drop Trigger if procedure is REPLICATION
   IF remrec_.procedure_name = 'REPLICATION' THEN
      Intface_Util_API.Generate_Trigger_(remrec_.intface_name,remrec_.table_name,
           'FALSE','FALSE','FALSE',remrec_.replication_mode);
   END IF;
   -- Drop Table if procedure is CREATE_TABLE_FROM_FILE
   IF remrec_.procedure_name = 'CREATE_TABLE_FROM_FILE' THEN
      Intface_Util_API.Drop_IC_Table_(remrec_.intface_name);
   END IF;
   -- Drop Packages and Triggers if procedure is REPLIC_DATA_OUT
   IF remrec_.procedure_name = 'REPLIC_DATA_OUT' THEN
      Intface_Util_API.Drop_Trg_And_Pkg_(remrec_.intface_name);
   END IF;
END Delete___;


@Override
PROCEDURE Check_Insert___ (
   newrec_ IN OUT intface_header_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS
   check_where_ BOOLEAN := FALSE;
   direction_   VARCHAR2(20);
BEGIN
   IF (newrec_.view_name IS NOT NULL) THEN
      Intface_Views_API.Exist(newrec_.view_name);
   END IF;
   IF ( newrec_.where_clause IS NOT NULL ) THEN
      check_where_ := TRUE;
   END IF;
   IF ( SUBSTR(newrec_.value_list,1,1) = ';') THEN
      Error_SYS.Record_General(lu_name_, 'LISTERR: Value list should not start with semicolon' );
   END IF;
   Validate_Name___(newrec_.intface_name, newrec_.procedure_name);
   IF ( newrec_.from_value IS NOT NULL ) THEN
      IF ( INSTR(';'||newrec_.value_list||';',';'||newrec_.from_value||';') != 0 ) THEN
         Error_SYS.Record_General(lu_name_, 'VALUEERR: From value :P1 cannot be a part of value list', newrec_.from_value);
      END IF;
   END IF;
   IF newrec_.procedure_name = 'REPLICATION' THEN
      Error_SYS.Check_Not_Null(lu_name_, 'VALUE_LIST', newrec_.value_list);
      IF ( newrec_.replication_mode != '1' ) THEN
         Error_SYS.Check_Not_Null(lu_name_, 'FROM_VALUE', newrec_.from_value);
      ELSIF ( newrec_.where_clause IS NULL ) THEN
         Error_SYS.Record_General(lu_name_, 'NOWHERE: Where Clause must be entered for replication-jobs with mode=Manual ');
      END IF;
      IF ( INSTR(UPPER(newrec_.where_clause),'NEW.') != 0 OR
           INSTR(UPPER(newrec_.where_clause),'OLD.') != 0 ) THEN
         Error_SYS.Record_General(lu_name_, 'WHENERR: When-statement for trigger should be moved from column :P1 to :P2',
                                   Intface_Detail_API.Get_Column_Description('INTFACE_HEADER', 'WHERE_CLAUSE'),
                                   Intface_Detail_API.Get_Column_Description('INTFACE_HEADER', 'TRIGGER_WHEN'));
      END IF;
   END IF;
   --
   direction_ := Intface_Direction_API.Encode(
                    Intface_Procedures_API.Get_Direction( newrec_.procedure_name));
   --
   Check_Intface_No_File(newrec_.file_location, direction_);
   IF ( check_where_ ) THEN
      IF ( direction_ = '1' ) THEN
         Error_SYS.Item_Update(lu_name_, 'WHERE_CLAUSE', ' ERRWHERE : Default-where not in use for direction = :P1 ', Intface_Direction_API.Decode('1') );
      END IF;
   END IF;
   --
   IF ( newrec_.source_name IS NOT NULL AND newrec_.source_owner IS NULL ) THEN
      newrec_.source_owner := fnd_session_api.get_app_owner;
   END IF;
   --
   IF ( direction_ = '5' ) THEN
      Intface_Repl_Maint_Util_API.Check_Update_Allowed(newrec_.intface_name);
      IF( newrec_.replication_mode = '1' ) THEN
         IF ( Intface_Repl_Maint_Util_API.Are_Objects_Generated(newrec_.intface_name, 'TRIGGER') = 'TRUE' ) THEN
            Error_SYS.Record_General(lu_name_, 'NOTRIG: Triggers are generated. You cannot change mode to :P1 ', newrec_.replication_mode );
         END IF;
      END IF;
      IF ( LENGTH(newrec_.intface_name) > 24 ) THEN
         Error_SYS.Record_General(lu_name_, 'LONGNAME: Job ID :P1 too long. Must not exceed 24 characters ', newrec_.intface_name );
      END IF;
   END IF;
   IF ( newrec_.intface_file LIKE '*.%' ) THEN
      IF ( (newrec_.procedure_name LIKE 'FNDMIG_EXPORT%') AND newrec_.file_location = '1' ) THEN
         NULL;
      ELSE
         Error_SYS.Record_General(lu_name_, 'WILDERR: Wildcards in filename can only be used when exporting data to server files ');
      END IF;
   END IF;
   IF ( newrec_.procedure_name = 'MIGRATE_SOURCE_DATA' ) THEN
      newrec_.file_location := '3';
      newrec_.intface_path := NULL;
      newrec_.intface_file := NULL;
      newrec_.char_set := NULL;
      newrec_.date_format := NULL;
      newrec_.minus_pos := NULL;
      newrec_.column_separator := NULL;
      newrec_.thousand_separator := NULL;
      newrec_.decimal_point := NULL;
      newrec_.column_embrace := NULL;
   END IF;
   IF newrec_.char_set IS NOT NULL THEN
      Database_SYS.Validate_File_Encoding(newrec_.char_set);
   END IF;
   super(newrec_, indrec_, attr_);
END Check_Insert___;


@Override
PROCEDURE Check_Update___ (
   oldrec_ IN     intface_header_tab%ROWTYPE,
   newrec_ IN OUT intface_header_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS
   check_where_ BOOLEAN := FALSE;
   direction_   VARCHAR2(20);
BEGIN
   IF ( newrec_.where_clause IS NOT NULL ) THEN
      check_where_ := TRUE;
   END IF;
   IF (newrec_.view_name IS NOT NULL) THEN
      Intface_Views_API.Exist(newrec_.view_name);
   END IF;
   IF ( SUBSTR(newrec_.value_list,1,1) = ';') THEN
      Error_SYS.Record_General(lu_name_, 'LISTERR: Value list should not start with semicolon' );
   END IF;
   Validate_Name___(newrec_.intface_name, newrec_.procedure_name);
   direction_ := Intface_Direction_API.Encode(
                    Intface_Procedures_API.Get_Direction( newrec_.procedure_name));
   Check_Intface_No_File(newrec_.file_location, direction_);
   IF ( check_where_ ) THEN
      IF ( direction_ = '1' ) THEN
         Error_SYS.Item_Update(lu_name_, 'WHERE_CLAUSE', ' ERRWHERE : Default-where not in use for direction = :P1 ', Intface_Direction_API.Decode('1') );
      END IF;
   END IF;
   --
   IF ( newrec_.from_value IS NOT NULL ) THEN
      IF ( INSTR(';'||newrec_.value_list||';',';'||newrec_.from_value||';') != 0 ) THEN
         Error_SYS.Record_General(lu_name_, 'VALUEERR: From value :P1 cannot be a part of value list', newrec_.from_value);
      END IF;
   END IF;
   
   IF (indrec_.procedure_name AND newrec_.procedure_name = 'EXCEL_MIGRATION') THEN
      Intface_Execution_Util_API.Validate_Job_Lines_For_Header(newrec_.intface_name);
   END IF;
      
   IF newrec_.procedure_name = 'REPLICATION' THEN
      Error_SYS.Check_Not_Null(lu_name_, 'VALUE_LIST', newrec_.value_list);
      IF ( newrec_.replication_mode != '1' ) THEN
         Error_SYS.Check_Not_Null(lu_name_, 'FROM_VALUE', newrec_.from_value);
      ELSIF ( newrec_.where_clause IS NULL ) THEN
         Error_SYS.Record_General(lu_name_, 'NOWHERE: Where Clause must be entered for replication-jobs with mode=Manual ');
      END IF;
      IF ( INSTR(UPPER(newrec_.where_clause),'NEW.') != 0 OR
           INSTR(UPPER(newrec_.where_clause),'OLD.') != 0 ) THEN
         Error_SYS.Record_General(lu_name_, 'WHENERR: When-statement for trigger should be moved from column :P1 to :P2',
                                   Intface_Detail_API.Get_Column_Description('INTFACE_HEADER', 'WHERE_CLAUSE'),
                                   Intface_Detail_API.Get_Column_Description('INTFACE_HEADER', 'TRIGGER_WHEN'));
      END IF;
   END IF;
   --
   IF ( direction_ = '5' ) THEN
      Intface_Repl_Maint_Util_API.Check_Update_Allowed(newrec_.intface_name);
      IF( newrec_.replication_mode = '1' ) THEN
         IF ( Intface_Repl_Maint_Util_API.Are_Objects_Generated(newrec_.intface_name, 'TRIGGER') = 'TRUE' ) THEN
            Error_SYS.Record_General(lu_name_, 'NOTRIG: Triggers are generated. You cannot change mode to :P1 ', newrec_.replication_mode );
         END IF;
      END IF;
   END IF;
   IF ( newrec_.intface_file LIKE '*.%' ) THEN
      IF ( (newrec_.procedure_name LIKE 'FNDMIG_EXPORT%') AND newrec_.file_location = '1' ) THEN
         NULL;
      ELSE
         Error_SYS.Record_General(lu_name_, 'WILDERR: Wildcards in filename can only be used when exporting data to server files ');
      END IF;
   END IF;
   IF newrec_.char_set IS NOT NULL THEN
      Database_SYS.Validate_File_Encoding(newrec_.char_set);
   END IF;
   super(oldrec_, newrec_, indrec_, attr_);
END Check_Update___;


-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------

@Override
PROCEDURE New__ (
   info_       OUT    VARCHAR2,
   objid_      OUT    VARCHAR2,
   objversion_ OUT    VARCHAR2,
   attr_       IN OUT VARCHAR2,
   action_     IN     VARCHAR2 )
IS
BEGIN
   IF (Intface_User_API.Has_Update_Privilege = 'FALSE') THEN
      Error_SYS.Appl_General(lu_name_, 'NOPRIV: You (:P1) do not have the privilege to create new Data Migration jobs',Fnd_Session_API.Get_Fnd_User);
   END IF;
   super(info_, objid_, objversion_, attr_, action_);
END New__;


PROCEDURE Insert_Default_Details__ (
   intface_name_ IN VARCHAR2,
   view_name_    IN VARCHAR2 )
IS
   CURSOR get_cols IS
      SELECT column_name,
             data_type,
             DECODE(data_type,'NUMBER',NVL(data_precision,20),data_length) length,
             data_scale,
             column_id * 10 attr_seq,
             Intface_Detail_API.Get_Column_Description(view_name, column_name) description,
             Intface_Detail_API.Get_Column_Flags(view_name, column_name) flags
      FROM intface_views_col_info
      WHERE view_name = view_name_
      AND column_name NOT IN ('OBJID', 'OBJVERSION', 'OBJSTATE', 'OBJEVENTS')
      AND (column_name LIKE '%DB'
       OR Intface_Detail_API.Get_Column_Flags(view_name, column_name) IS NOT NULL)
      ORDER BY column_id;
   --
   CURSOR check_objstate IS
      SELECT 1
      FROM   intface_views_col_info
         WHERE   column_name ='OBJSTATE'
         AND     view_name  = view_name_;


   CURSOR get_max_seq IS
      SELECT NVL(MAX(attr_seq),0) max_seq
      FROM intface_detail_tab
      WHERE intface_name = intface_name_;
   --
   max_seq_        NUMBER;
   column_name_    VARCHAR2(30);
   data_type_      VARCHAR2(9);
   length_         NUMBER;
   decimal_length_ NUMBER;
   description_    VARCHAR2(100);
   flags_          VARCHAR2(10);
   attr_seq_       NUMBER;
   date_format_    VARCHAR2(30) := Client_SYS.Date_Format_;
   is_real_data_   BOOLEAN;
   check_objstate_ NUMBER;

   --
BEGIN
   IF ( view_name_ = 'FNDMIG_EXPORT' ) THEN
      INSERT INTO Intface_Detail_Tab(
         INTFACE_NAME, COLUMN_NAME, DATA_TYPE, POS,LENGTH, DECIMAL_LENGTH,
         CHANGE_DEFAULTS, DESCRIPTION, FLAGS,  ATTR_SEQ, NOTE_TEXT, ROWVERSION)
       VALUES(intface_name_, 'INTFACE_NAME', 'VARCHAR2' , 1, 30, null,
          '1',  'Migration name', 'IU', 1, 'Help column for entering DefaultWhere from Start window',sysdate);
      INSERT INTO intface_detail_tab
         (INTFACE_NAME, COLUMN_NAME, DESCRIPTION, DATA_TYPE, POS, LENGTH,
          DECIMAL_LENGTH, AMOUNT_FACTOR, DEFAULT_VALUE, DEFAULT_WHERE, FLAGS, ATTR_SEQ, PAD_CHAR_RIGHT, PAD_CHAR_LEFT, CHANGE_DEFAULTS, SOURCE_COLUMN, CONV_LIST_ID,
          NOTE_TEXT,
          DB_CLIENT_VALUES, ROWVERSION)
      VALUES (intface_name_, 'EXP_LIST_FLAG', 'Export existing conversion lists (Y/N) ',  'VARCHAR2', 2, 1,
         null, null, 'Y', null, 'IU', 1, null, null, '1', null, null,
         'If default_value is set to'||''''||'N'||''''||' , Conversion Lists will NOT be exported.'|| cr_ || '' || lf_ ||
         'Default is '||''''||'Y'||'''', null, sysdate);
   ELSIF ( view_name_ = 'FNDMIG_IMPORT' ) THEN
      INSERT INTO intface_detail_tab
         (INTFACE_NAME, COLUMN_NAME, DESCRIPTION, DATA_TYPE, POS, LENGTH,
          DECIMAL_LENGTH, AMOUNT_FACTOR, DEFAULT_VALUE, DEFAULT_WHERE, FLAGS, ATTR_SEQ, PAD_CHAR_RIGHT, PAD_CHAR_LEFT, CHANGE_DEFAULTS, SOURCE_COLUMN, CONV_LIST_ID,
          NOTE_TEXT,
          DB_CLIENT_VALUES, ROWVERSION)
      VALUES (intface_name_, 'DEL_JOB_FLAG', 'Overwrite existing job (Y/N) ',  'VARCHAR2', 1, 1,
         null, null, 'N', null, 'IU', 1, null, null, '1', null, null,
         'If default_value is set to'||''''||'Y'||''''||' , Migration Jobs basic data that already exists will be replaced by IMPORT.'|| cr_ || '' || lf_ ||
         'Default is '||''''||'N'||'''', null, sysdate);
      INSERT INTO intface_detail_tab
         (INTFACE_NAME, COLUMN_NAME, DESCRIPTION, DATA_TYPE, POS, LENGTH,
          DECIMAL_LENGTH, AMOUNT_FACTOR, DEFAULT_VALUE, DEFAULT_WHERE, FLAGS, ATTR_SEQ, PAD_CHAR_RIGHT, PAD_CHAR_LEFT, CHANGE_DEFAULTS, SOURCE_COLUMN, CONV_LIST_ID,
          NOTE_TEXT,
          DB_CLIENT_VALUES, ROWVERSION)
      VALUES (intface_name_, 'DEL_LIST_FLAG', 'Overwrite existing conversion lists (Y/N) ',  'VARCHAR2', 2, 1,
         null, null, 'N', null, 'IU', 1, null, null, '1', null, null,
         'If default_value is set to'||''''||'Y'||''''||' , Conversion Lists that already exists will be replaced by IMPORT.'|| cr_ || '' || lf_ ||
         'Default is '||''''||'N'||'''', null, sysdate);
   ELSE
      -- Find max-value, in case columns are inserted
      -- multiple times
      OPEN  get_max_seq;
      FETCH get_max_seq INTO max_seq_;
      CLOSE get_max_seq;
      --
      FOR rec_ IN get_cols LOOP
         is_real_data_   :=TRUE;
         column_name_    := rec_.column_name;
         data_type_      := rec_.data_type;
         length_         := rec_.length;
         decimal_length_ := rec_.data_scale;
         description_    := rec_.description;
         flags_          := rec_.flags;
         attr_seq_       := rec_.attr_seq + max_seq_;
         --
         -- if state is found check to see if objstate is also present
         -- ie: if so state refers to objstate if not state is a real data column(as states in USA)
         IF column_name_ ='STATE' THEN
           OPEN check_objstate;
           FETCH check_objstate INTO check_objstate_;
           IF check_objstate%FOUND THEN
              is_real_data_ :=FALSE;
           END IF;
           CLOSE check_objstate;
         END IF;

         IF ( data_type_ = 'DATE' ) THEN
            length_ := LENGTH(Get_Date_Format(intface_name_));
            IF ( NVL(length_,0) = 0 ) THEN
                  length_ := LENGTH(date_format_) ; -- make sure length != 0
            END IF;
         END IF;
         BEGIN
            IF is_real_data_  THEN
               INSERT INTO Intface_Detail_Tab(
                        INTFACE_NAME, COLUMN_NAME, DATA_TYPE, POS,LENGTH, DECIMAL_LENGTH,
                        CHANGE_DEFAULTS, DESCRIPTION, FLAGS,  ATTR_SEQ, ROWVERSION)
                  VALUES(intface_name_, column_name_, data_type_, 0, length_, decimal_length_,
                         '2',  description_, flags_, attr_seq_, sysdate);
            END  IF;
         EXCEPTION
            WHEN OTHERS THEN -- Do nothing if insert failes ; columns may already exist
               NULL;
         END;
         decimal_length_ := NULL;
      END LOOP;
   END IF;
EXCEPTION
   WHEN OTHERS THEN -- Do nothing if insert failes ; columns may already exist
      NULL;
END Insert_Default_Details__;


PROCEDURE Prepare_Convert_Data__ (
   intface_name_ IN VARCHAR2,
   view_name_    IN VARCHAR2,
   source_name_  IN VARCHAR2,
   source_owner_ IN VARCHAR2 )
IS
   dummy_         VARCHAR2(1);
   insert_method_ BOOLEAN;
   info_          VARCHAR2(2000);
   objid_         VARCHAR2(2000);
   objversion_    VARCHAR2(2000);
   attr_          VARCHAR2(2000) := NULL;
   pref_option_   VARCHAR2(2000);
   procedure_name_ VARCHAR2(100);
   --
   CURSOR check_method IS
      SELECT 'x'
      FROM intface_method_list_tab
      WHERE intface_name = intface_name_;
   CURSOR get_option(proc_name_ IN VARCHAR2) IS
      SELECT rule_value
      FROM intface_default_rules
      WHERE proc_name_ LIKE procedure_name
      AND rule_id = 'CREATEDET';
   --
BEGIN
   OPEN  check_method;
   FETCH check_method INTO dummy_;
      insert_method_ := check_method%NOTFOUND;
   CLOSE check_method;
   --
   procedure_name_ := Intface_Header_API.Get_Procedure_Name(intface_name_);
   OPEN  get_option(procedure_name_);
   FETCH get_option INTO pref_option_;
   CLOSE get_option;
   --
   -- Add one row to method list
   IF ( insert_method_ AND view_name_ IS NOT NULL ) THEN
      Intface_Method_List_API.New__(info_, objid_, objversion_, attr_, 'PREPARE');
      Client_SYS.Add_To_Attr('INTFACE_NAME', intface_name_, attr_);
      Client_SYS.Add_To_Attr('EXECUTE_SEQ', 10, attr_);
      Client_SYS.Add_To_Attr('VIEW_NAME', view_name_, attr_);
      Client_SYS.Add_To_Attr('PREFIX_OPTION', Intface_Prefix_Option_API.Decode(pref_option_) , attr_);
      Intface_Method_List_API.New__(info_, objid_, objversion_, attr_, 'DO');
   END IF;
END Prepare_Convert_Data__;


FUNCTION Check_Exist_Table__ (
   table_name_ IN VARCHAR2 ) RETURN BOOLEAN
IS
   dummy_ NUMBER;
   CURSOR exist_control IS
      SELECT 1
      FROM   INTFACE_TABLE_NAME_LOV
      WHERE  table_name = table_name_;
BEGIN
   OPEN exist_control;
   FETCH exist_control INTO dummy_;
   IF (exist_control%FOUND) THEN
      CLOSE exist_control;
      RETURN(TRUE);
   END IF;
   CLOSE exist_control;
   RETURN(FALSE);
END Check_Exist_Table__;


FUNCTION Build_Deploy_Code__ (
   option_ IN VARCHAR2 ) RETURN varchar_tabtype
IS
   text_ Intface_Header_API.varchar_tabtype;
   i_ BINARY_INTEGER := 0;

   FUNCTION Next RETURN BINARY_INTEGER IS
   BEGIN
      i_ := i_ + 1;
      RETURN i_;
   END Next;

BEGIN
   -- Build code for start/end of
   -- script to be deployed in Admin
   i_ := 0;
   IF ( option_ = 'START' ) THEN
      text_(Next) := '-- ----------------------------------------------------';
      text_(Next) := '-- Export of Data Migration jobs in deploy file format.';
      text_(Next) := '-- ----------------------------------------------------';
      text_(Next) := 'DECLARE';
      text_(Next) := '   job_      VARCHAR2(30) := ''FNDMIG_IMPORT'';';
      text_(Next) := '   line_no_  NUMBER       := Intface_Job_Detail_API.Get_Max_Line_No(job_);';
      text_(Next) := '   --';
      text_(Next) := '   del_list_flag_    Intface_Detail.Default_Value%TYPE := ''N'';';
      text_(Next) := '   del_job_flag_     Intface_Detail.Default_Value%TYPE := ''N'';';
      text_(Next) := '   --';
      text_(Next) := '   file_location_db_ Intface_Header.File_Location_DB%TYPE;';
      text_(Next) := '   intface_path_     Intface_Header.Intface_Path%TYPE;';
      text_(Next) := '   intface_file_     Intface_Header.Intface_File%TYPE;';
      text_(Next) := '   char_set_         Intface_Header.Char_Set%TYPE;';
      text_(Next) := '   do_reset_         BOOLEAN := FALSE;';
      text_(Next) := '   --';
      text_(Next) := '   PROCEDURE SetDefault IS';
      text_(Next) := '   PRAGMA AUTONOMOUS_TRANSACTION;';
      text_(Next) := '   BEGIN';
      text_(Next) := '      BEGIN';
      text_(Next) := '         SELECT default_value';
      text_(Next) := '         INTO   del_list_flag_';
      text_(Next) := '         FROM   intface_detail';
      text_(Next) := '         WHERE  intface_name = job_';
      text_(Next) := '         AND    column_name  = ''DEL_LIST_FLAG'';';
      text_(Next) := '         SELECT default_value';
      text_(Next) := '         INTO   del_job_flag_';
      text_(Next) := '         FROM   intface_detail';
      text_(Next) := '         WHERE  intface_name = job_';
      text_(Next) := '         AND    column_name  = ''DEL_JOB_FLAG'';';
      text_(Next) := '      EXCEPTION';
      text_(Next) := '         WHEN others THEN null;';
      text_(Next) := '      END;';
      text_(Next) := '      BEGIN';
      text_(Next) := '         SELECT file_location_db,';
      text_(Next) := '                intface_path,';
      text_(Next) := '                intface_file,';
      text_(Next) := '                char_set';
      text_(Next) := '         INTO   file_location_db_,';
      text_(Next) := '                intface_path_,';
      text_(Next) := '                intface_file_,';
      text_(Next) := '                char_set_';
      text_(Next) := '         FROM   intface_header';
      text_(Next) := '         WHERE  intface_name = job_;';
      text_(Next) := '         UPDATE intface_header_tab';
      text_(Next) := '         SET    file_location = ''2'',';
      text_(Next) := '                intface_path  = NULL,';
      text_(Next) := '                intface_file  = NULL,';
      text_(Next) := '                char_set      = NULL';
      text_(Next) := '         WHERE  intface_name  = job_;';
      text_(Next) := '      EXCEPTION';
      text_(Next) := '         WHEN others THEN null;';
      text_(Next) := '      END;';
      text_(Next) := '      UPDATE intface_detail_tab SET default_value = ''Y''';
      text_(Next) := '      WHERE intface_name = job_;';
      text_(Next) := '      COMMIT;';
      text_(Next) := '      do_reset_ := TRUE;';
      text_(Next) := '   EXCEPTION';
      text_(Next) := '      WHEN others THEN';
      text_(Next) := '         dbms_output.put_line(SQLERRM);';
      text_(Next) := '         ROLLBACK;';
      text_(Next) := '   END SetDefault;';
      text_(Next) := '   --';
      text_(Next) := '   PROCEDURE ResetDefault IS';
      text_(Next) := '   BEGIN';
      text_(Next) := '      BEGIN';
      text_(Next) := '         UPDATE intface_detail_tab';
      text_(Next) := '         SET    default_value = del_job_flag_';
      text_(Next) := '         WHERE  intface_name  = job_';
      text_(Next) := '         AND    column_name   = ''DEL_JOB_FLAG'';';
      text_(Next) := '         UPDATE intface_detail_tab';
      text_(Next) := '         SET    default_value = del_list_flag_';
      text_(Next) := '         WHERE  intface_name  = job_';
      text_(Next) := '         AND    column_name   = ''DEL_LIST_FLAG'';';
      text_(Next) := '      EXCEPTION';
      text_(Next) := '         WHEN others THEN';
      text_(Next) := '            dbms_output.put_line(SQLERRM);';
      text_(Next) := '      END;';
      text_(Next) := '      IF ( do_reset_ ) THEN';
      text_(Next) := '         BEGIN';
      text_(Next) := '            UPDATE intface_header_tab';
      text_(Next) := '            SET    file_location = file_location_db_,';
      text_(Next) := '                   intface_path  = intface_path_,';
      text_(Next) := '                   intface_file  = intface_file_,';
      text_(Next) := '                   char_set      = char_set_';
      text_(Next) := '            WHERE  intface_name  = job_;';
      text_(Next) := '         EXCEPTION';
      text_(Next) := '            WHEN others THEN';
      text_(Next) := '               dbms_output.put_line(SQLERRM);';
      text_(Next) := '         END;';
      text_(Next) := '      END IF;';
      text_(Next) := '   END ResetDefault;';
      text_(Next) := '   --';
      text_(Next) := '   PROCEDURE LoadData (data_ IN VARCHAR2) IS';
      text_(Next) := '      info_       VARCHAR2(2000);';
      text_(Next) := '      objid_      VARCHAR2(2000);';
      text_(Next) := '      objversion_ VARCHAR2(2000);';
      text_(Next) := '      attr_       VARCHAR2(32000);';
      text_(Next) := '   BEGIN';
      text_(Next) := '      line_no_ := line_no_ + 1;';
      text_(Next) := '      Client_SYS.Clear_Attr(attr_);';
      text_(Next) := '      Client_SYS.Add_To_Attr(''INTFACE_NAME'', job_, attr_);';
      text_(Next) := '      Client_SYS.Add_To_Attr(''LINE_NO'', line_no_, attr_);';
      text_(Next) := '      Client_SYS.Add_To_Attr(''FILE_STRING'', data_, attr_);';
      text_(Next) := '      Client_SYS.Add_To_Attr(''EXECUTION_NO'', 0, attr_);';
      text_(Next) := '      Client_SYS.Add_To_Attr(''STATUS'', Intface_Job_Status_API.Decode(''2''), attr_);';
      text_(Next) := '      Intface_Job_Detail_API.New__(info_, objid_, objversion_, attr_, ''DO'');';
      text_(Next) := '   EXCEPTION';
      text_(Next) := '      WHEN others THEN';
      text_(Next) := '         dbms_output.put_line(SQLERRM);';
      text_(Next) := '   END LoadData;';
      text_(Next) := '   PROCEDURE EndData IS';
      text_(Next) := '      info_       VARCHAR2(32000);';
      text_(Next) := '   BEGIN';
      text_(Next) := '      Intface_Header_API.Start_Job(info_, ''ONLINE'', job_);';
      text_(Next) := '      dbms_output.put_line(info_);';
      text_(Next) := '   EXCEPTION';
      text_(Next) := '      WHEN others THEN';
      text_(Next) := '         dbms_output.put_line(SQLERRM);';
      text_(Next) := '   END EndData;';
      text_(Next) := 'BEGIN';
      text_(Next) := '   -- ---------------------------------';
      text_(Next) := '   -- Allow overwrite of existing jobs.';
      text_(Next) := '   -- ---------------------------------';
      text_(Next) := '   SetDefault;';
   ELSIF ( option_ = 'END' ) THEN
      text_(Next) := 'END;';
      text_(Next) := '/';
      text_(Next) := '--';
   ELSIF ( option_ = 'STOP' ) THEN
      text_(Next) := '   EndData;';
      text_(Next) := '   -- ----------------------------------------';
      text_(Next) := '   -- Reset overwrite flags to original value.';
      text_(Next) := '   -- ----------------------------------------';
      text_(Next) := '   ResetDefault;';
      text_(Next) := '   COMMIT;';
      text_(Next) := 'END;';
      text_(Next) := '/';
   END IF;
   RETURN text_;
END Build_Deploy_Code__;


PROCEDURE Fndmig_Export__ (
   info_         IN OUT VARCHAR2,
   intface_name_ IN     VARCHAR2,
   selection_info_ IN OUT NOCOPY Selection_Info)
IS
   --
   TYPE varchar_tabtype IS
      TABLE OF VARCHAR2(4000)
      INDEX BY BINARY_INTEGER;
   TYPE repl_jobs IS RECORD(
      intface_name varchar_tabtype);
   TYPE repl_source IS RECORD(
      text varchar_tabtype);
   TYPE repl_triggers IS RECORD(
      name varchar_tabtype);
   TYPE out_file IS RECORD(
      file_string varchar_tabtype);
   --
   TYPE intfdet_tab_type IS
      TABLE OF intface_detail_tab%ROWTYPE INDEX BY BINARY_INTEGER;
   --
   intfdet_rec_        intfdet_tab_type;
   out_rec_            out_file;
   job_rec_            repl_jobs;
   source_rec_         repl_source;
   trigger_rec_        repl_triggers;
   stack_              Intface_Detail_API.varchar_tabtype;
   count_              NUMBER;
   file_seq_           NUMBER := 0;

   -- Define column list. Remember to have comma behind last column because of INSTR below
   header_cols_        VARCHAR2(2000)   := 'INTFACE_NAME, DESCRIPTION, INTFACE_PATH, INTFACE_FILE, DATE_FORMAT, MINUS_POS, WHERE_CLAUSE, VIEW_NAME, COLUMN_SEPARATOR, THOUSAND_SEPARATOR, DECIMAL_POINT, COLUMN_EMBRACE, FILE_LOCATION, PROCEDURE_NAME, SOURCE_NAME, SOURCE_OWNER, NOTE_TEXT, ORDER_BY_CLAUSE, REPLICATION_MODE, REPL_CRITERIA, GROUP_ID, OBJECT_SEQ, VALUE_LIST, TABLE_NAME, ON_INSERT, ON_UPDATE, FROM_VALUE, MESSAGE_NAME, MESSAGE_TYPE, MESSAGE_SENDER, MESSAGE_RECEIVER, GROUP_BY_CLAUSE, TRIGGER_WHEN, CHAR_SET,';
   detail_cols_        VARCHAR2(2000)   := 'INTFACE_NAME, COLUMN_NAME, DESCRIPTION, DATA_TYPE, POS, LENGTH, DECIMAL_LENGTH, AMOUNT_FACTOR, DEFAULT_VALUE, DEFAULT_WHERE, FLAGS, PAD_CHAR_RIGHT, PAD_CHAR_LEFT, CHANGE_DEFAULTS, ATTR_SEQ, SOURCE_COLUMN, NOTE_TEXT, CONV_LIST_ID, DB_CLIENT_VALUES, EXT_ATTR,';
   method_cols_        VARCHAR2(2000)   := 'INTFACE_NAME, EXECUTE_SEQ, VIEW_NAME, METHOD_NAME, COLUMN_NAME, COLUMN_VALUE, CONVERT_ATTR, NOTE_TEXT, REFERENCES, SOURCE_NAME, ACTION, ON_NEW, ON_MODIFY, PREFIX_OPTION, ON_NEW_MASTER, ON_FIRST_ROW,';
   method_attrib_cols_ VARCHAR2(2000)   := 'INTFACE_NAME, EXECUTE_SEQ, COLUMN_NAME, DESCRIPTION, COLUMN_SEQUENCE, FIXED_VALUE, ON_NEW,ON_MODIFY, FLAGS,LU_REFERENCE, IID_VALUES,';
   repl_struct_cols_   VARCHAR2(2000)   := 'INTFACE_NAME, STRUCTURE_SEQ, POS, VIEW_NAME, PARENT_SEQ, ON_INSERT, ON_UPDATE, TRIGGER_TABLE, TRIGGER_WHEN, RECORD_NAME, ELEMENT_NAME, START_POINT, SELECT_WHERE, NOTE_TEXT, ELEMENT_TYPE,';
   repl_str_cols_cols_ VARCHAR2(2000)   := 'INTFACE_NAME, STRUCTURE_SEQ, COLUMN_SEQ, COLUMN_NAME, DESCRIPTION, DATA_TYPE, FLAGS, COLUMN_ALIAS, PARENT_KEY_NAME, ON_INSERT, ON_UPDATE,';
   rules_cols_         VARCHAR2(2000)   := 'INTFACE_NAME, RULE_ID, RULE_VALUE, RULE_FLAG,';
   group_cols_         VARCHAR2(2000)   := 'GROUP_ID, DESCRIPTION, NOTE_TEXT,HIDE_FLAG,';
   clist_cols_         VARCHAR2(2000)   := 'CONV_LIST_ID, DESCRIPTION,';
   ccols_cols_         VARCHAR2(2000)   := 'CONV_LIST_ID, OLD_VALUE, NEW_VALUE,';
   attr_               VARCHAR2(32000);
   stmt_               VARCHAR2(32000)   := NULL;
   where_              VARCHAR2(2010)   := NULL;
   order_by_           VARCHAR2(2000);
   h_cur_              INTEGER;
   row_                VARCHAR2(32000);
   dummy_              NUMBER;
   table_name_         VARCHAR2(30);
   view_name_          VARCHAR2(30);
   export_item_        VARCHAR2(100);
   cols_               VARCHAR2(2000);
   select_cols_        VARCHAR2(2000);
   header_table_       VARCHAR2(30)     := 'INTFACE_HEADER_TAB';
   group_table_        VARCHAR2(30)     := 'INTFACE_GROUP_TAB';
   detail_table_       VARCHAR2(30)     := 'INTFACE_DETAIL_TAB';
   method_table_       VARCHAR2(30)     := 'INTFACE_METHOD_LIST_TAB';
   method_attrib_table_ VARCHAR2(30)    := 'INTFACE_METHOD_LIST_ATTRIB_TAB';
   repl_struct_table_  VARCHAR2(30)     := 'INTFACE_REPL_STRUCTURE_TAB';
   repl_str_cols_table_ VARCHAR2(30)    := 'INTFACE_REPL_STRUCT_COLS_TAB';
   rules_table_        VARCHAR2(30)     := 'INTFACE_RULES_TAB';
   conv_list_table_    VARCHAR2(30)     := 'INTFACE_CONV_LIST_TAB';
   conv_cols_table_    VARCHAR2(30)     := 'INTFACE_CONV_LIST_COLS_TAB';
   header_pref_        VARCHAR2(5)      := 'INTFH';
   group_pref_         VARCHAR2(5)      := 'INTFG';
   detail_pref_        VARCHAR2(5)      := 'INTFD';
   method_pref_        VARCHAR2(5)      := 'INTFM';
   method_attrib_pref_ VARCHAR2(5)      := 'INTFA';
   repl_struct_pref_   VARCHAR2(5)      := 'INTFS';
   repl_str_cols_pref_ VARCHAR2(5)      := 'INTFT';
   rules_pref_         VARCHAR2(5)      := 'INTFR';
   clist_pref_         VARCHAR2(5)      := 'INTFL';
   ccols_pref_         VARCHAR2(5)      := 'INTFC';
   attr_pref_          VARCHAR2(5);
   conv_sub_select_    VARCHAR2(2000)   := NULL;
   --
   rest_text_          VARCHAR2(32000);
   print_text_         VARCHAR2(2000);
   text_restlength_    NUMBER;
   text_column_length_ NUMBER;
   --
   repl_count_         NUMBER :=0;
   source_count_       NUMBER :=0;
   trigger_count_      NUMBER :=0;
   trigger_text_       VARCHAR2(2000);
   old_type_           VARCHAR2(50);
   job_id_              Intface_Header_TAB.intface_name%TYPE;
   error_message_      VARCHAR2(2000);
   comment_            VARCHAR2(2);
   do_write_           BOOLEAN;
   export_pos_         NUMBER := 0;
   deploy_start_       Intface_Header_API.varchar_tabtype;
   deploy_suffix_      VARCHAR2(2000);
   deploy_prefix_      VARCHAR2(2000);
   deploy_end_         Intface_Header_API.varchar_tabtype;
   deploy_null_        Intface_Header_API.varchar_tabtype;
   rule_string_        VARCHAR2(2000);
   text_length_        NUMBER := 0;
   item_value_         VARCHAR2(100);
   exp_list_flag_      VARCHAR2(100);
   write_out_rec_      BOOLEAN;
   
   intf_file_is_on_client_ BOOLEAN := App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_file_is_on_client_cid_);
   intf_in_info_    VARCHAR2(2000) := App_Context_SYS.Find_Value(Intface_Job_Detail_API.intf_in_info_cid_);
   --
   CURSOR get_cols IS
      SELECT column_name, data_type,
             DECODE(data_type,'NUMBER',NVL(data_precision,20),data_length) length,
             data_scale, column_id * 10 attr_seq,
             Intface_Detail_API.Get_Column_Description(view_name, column_name) description,
             Intface_Detail_API.Get_Column_Flags(view_name, column_name) flags
      FROM intface_views_col_info
      WHERE view_name = view_name_
      AND column_name NOT IN ('OBJID', 'OBJVERSION', 'OBJSTATE', 'OBJEVENTS','STATE' )
      AND column_name NOT LIKE '%DB'
      AND Intface_Detail_API.Get_Column_Flags(view_name, column_name) IS NOT NULL
      ORDER BY column_id;
   --
   CURSOR get_objects (job_id_ IN VARCHAR2) IS
      SELECT object_name, text, object_type
      FROM intface_repl_export_info
      WHERE  NVL(intface_name,job_id_) = job_id_;
   --
   CURSOR get_source (object_name_ IN VARCHAR2,
                      object_type_ IN VARCHAR2 ) IS
      SELECT line, REPLACE(text,lf_,'') text, type
      FROM user_source
      WHERE name = object_name_
      AND type = object_type_
      ORDER BY type, line ;
BEGIN
   exp_list_flag_ := NVL(UPPER(Intface_Detail_API.Get_Default_Value(intface_name_, 'EXP_LIST_FLAG')),'Y');
   --
   -- Set text variables to be used
   -- if deployfile should be made
   IF ( Intface_Rules_API.Rule_Is_Active(rule_string_, 'DEPLOYFILE', intface_name_) ) THEN
      deploy_start_       := Build_Deploy_Code__('START');
      deploy_prefix_      := '   LoadData('||'''';
      deploy_suffix_      := ''''||');';
      deploy_end_         := Build_Deploy_Code__('STOP');
      text_column_length_ := 100;
      comment_            := NULL;
      source_rec_.text(0) := crlf_;
      file_seq_ := 0;
      -- Add start of procedure to file array
      FOR deploy_start_index_ IN 1..deploy_start_.COUNT LOOP
         file_seq_ := file_seq_ + 1;
         out_rec_.file_string(file_seq_) := deploy_start_(deploy_start_index_);
      END LOOP;
   ELSE
      deploy_start_       := deploy_null_;
      deploy_prefix_      := NULL;
      deploy_suffix_      := NULL;
      deploy_end_(1)      := '--INTFENDIMPORT'||crlf_;
      text_column_length_ := 1000;
      comment_            := '--';
      source_rec_.text(0) := crlf_;
   END IF;
   IF ( intf_in_info_ IS NOT NULL ) THEN
      export_pos_ := INSTR(intf_in_info_, 'INTFACE_NAME=');
      IF ( export_pos_ != 0 ) THEN
         -- Single job export to client
         export_item_ := SUBSTR(intf_in_info_,export_pos_+13);
         UPDATE intface_detail_tab
         SET default_where = '= '||''''||export_item_||''''
         WHERE intface_name = intface_name_
         AND column_name = 'INTFACE_NAME';
      ELSE
         export_pos_ := INSTR(intf_in_info_, 'GROUP_ID=');
         IF ( export_pos_ != 0 ) THEN
            export_item_ := SUBSTR(intf_in_info_,export_pos_+9);
            UPDATE intface_detail_tab
            SET default_where = 'IN ( SELECT intface_name FROM intface_header '||
                                'WHERE group_id =  '||''''||export_item_||''''||')'
            WHERE intface_name = intface_name_
            AND column_name = 'INTFACE_NAME';
         END IF;
      END IF;
   END IF;
   where_ := Intface_Header_API.Get_Complete_Where(intface_name_);
   FOR i IN 1..10 LOOP
      Trace_SYS.Field('LOOP count', i);
      intfdet_rec_.DELETE;
      write_out_rec_ := TRUE;
      IF ( i = 1 ) THEN
         table_name_ := method_table_;
         cols_      := method_cols_;
         attr_pref_ := method_pref_;
         count_     := 0;
      ELSIF ( i = 2 ) THEN
         table_name_ := detail_table_;
         cols_      := detail_cols_;
         attr_pref_ := detail_pref_;
         count_     := 0;
      ELSIF ( i = 3 ) THEN
         table_name_ := rules_table_;
         cols_      := rules_cols_;
         attr_pref_ := rules_pref_;
         count_     := 0;
      ELSIF ( i = 4 ) THEN
         table_name_ := method_attrib_table_;
         cols_      := method_attrib_cols_;
         attr_pref_ := method_attrib_pref_;
         count_     := 0;
      ELSIF ( i = 5 ) THEN
         table_name_ := repl_struct_table_;
         cols_      := repl_struct_cols_;
         attr_pref_ := repl_struct_pref_;
         count_     := 0;
      ELSIF ( i = 6 ) THEN
         table_name_ := repl_str_cols_table_;
         cols_      := repl_str_cols_cols_;
         attr_pref_ := repl_str_cols_pref_;
         count_     := 0;
      ELSIF ( i = 7 ) THEN
         table_name_ := header_table_;
         cols_      := header_cols_;
         attr_pref_ := header_pref_;
         count_     := 0;
      ELSIF ( i = 8 ) THEN
         table_name_ := conv_cols_table_;
         cols_      := ccols_cols_;
         attr_pref_ := ccols_pref_;
         count_     := 0;
         conv_sub_select_ := ' WHERE conv_list_id IN (SELECT distinct conv_list_id '||
                                                     'FROM intface_detail ';
         IF ( NVL(exp_list_flag_,'Y') != 'Y' ) THEN
            write_out_rec_ := FALSE;
         END IF;
      ELSIF ( i = 9 ) THEN
         table_name_ := conv_list_table_;
         cols_      := clist_cols_;
         attr_pref_ := clist_pref_;
         count_     := 0;
         IF ( NVL(exp_list_flag_,'Y') != 'Y' ) THEN
            write_out_rec_ := FALSE;
         END IF;
      ELSIF ( i = 10 ) THEN
         table_name_ := group_table_;
         cols_      := group_cols_;
         attr_pref_ := group_pref_;
         count_     := 0;
         conv_sub_select_ := ' WHERE group_id IN (SELECT distinct group_id '||
                                                     'FROM intface_header ';
      END IF;
      view_name_ := SUBSTR(table_name_,1,LENGTH(table_name_)-4);
      stmt_ := NULL;
      select_cols_ := NULL;
      FOR rec_ IN get_cols LOOP
         IF ((Instr(cols_,rec_.column_name||',')) != '0' ) THEN
            count_ := count_ + 1;
            intfdet_rec_(count_).intface_name := intface_name_;
            intfdet_rec_(count_).column_name := rec_.column_name;
            intfdet_rec_(count_).data_type := rec_.data_type;
            intfdet_rec_(count_).length := rec_.length;
            select_cols_ := select_cols_||rec_.column_name||',';
         END IF;
      END LOOP;
      select_cols_ := RTRIM(select_cols_,',');
      stmt_ := 'SELECT ' || select_cols_ || ' FROM ' || table_name_;
      IF ( conv_sub_select_ IS NULL ) THEN
         stmt_ := stmt_||where_;
         order_by_ := Intface_Header_API.Get_Order_By_Clause(intface_name_);
         IF ( order_by_ IS NOT NULL) THEN
            stmt_ := stmt_||' ORDER BY '||order_by_;
         END IF;
      ELSE
         stmt_ := stmt_||conv_sub_select_||where_||')';
      END IF;
      Trace_SYS.Field('LOOP stmt', stmt_);
      h_cur_ := DBMS_SQL.Open_Cursor;
      BEGIN
         @ApproveDynamicStatement(2011-05-19,jhmase)
         DBMS_SQL.Parse(h_cur_, stmt_, DBMS_SQL.native);
      EXCEPTION
         WHEN OTHERS THEN
         Trace_SYS.Message(SQLERRM);
      END;
      FOR j IN 1..count_ LOOP
         stack_(j) := NULL;
         DBMS_SQL.Define_Column(h_cur_, j, stack_(j), 2000);
      END LOOP;
      dummy_ := DBMS_SQL.Execute(h_cur_);
      LOOP
         IF (DBMS_SQL.Fetch_Rows(h_cur_) = 0) THEN
            EXIT;
         END IF;
         row_ := NULL;
         Client_SYS.Clear_Attr(attr_);
         FOR k IN 1..count_ LOOP
            DBMS_SQL.Column_Value(h_cur_, k, stack_(k));
            client_sys.add_to_attr(intfdet_rec_(k).column_name, stack_(k), attr_);
            row_ := row_ || stack_(k) || ',';
         END LOOP;
         IF (  table_name_ = header_table_ ) THEN
            job_id_ := Client_SYS.Get_Item_Value('INTFACE_NAME',attr_);
            selection_info_.selected_jobs_ := selection_info_.selected_jobs_||'   '||job_id_||crlf_;
           -- Save jobs that are of type replication
            IF ( Intface_Direction_API.Encode(
                    Intface_Procedures_API.Get_Direction(
                        Intface_Header_API.Get_Procedure_Name(job_id_))) = '5' ) THEN
               repl_count_ := repl_count_ +1;
               job_rec_.intface_name(repl_count_) := job_id_;
            END IF;
         ELSIF (  table_name_ = group_table_ ) THEN
            item_value_ := Client_SYS.Get_Item_Value('GROUP_ID', attr_);
            IF ( INSTR(NVL(selection_info_.selected_groups_,'*'),'   '||item_value_||crlf_) = 0 ) THEN
               selection_info_.selected_groups_ := selection_info_.selected_groups_||'   '||item_value_||crlf_;
            END IF;
         ELSIF (  table_name_ = conv_list_table_ ) THEN
            item_value_ := Client_SYS.Get_Item_Value('CONV_LIST_ID', attr_);
            IF ( INSTR(NVL(selection_info_.selected_lists_,'*'),'   '||item_value_||crlf_) = 0 ) THEN
               selection_info_.selected_lists_ := selection_info_.selected_lists_||'   '||item_value_||crlf_;
            END IF;
         END IF;
         -- Save attr in table
         rest_text_ := attr_pref_||attr_;
         -- Replace Quotation mark
         rest_text_ := REPLACE(rest_text_,quot_,replace_quot_);
         -- Replace Ampersand
         rest_text_ := REPLACE(rest_text_,amp_,replace_amp_);
         -- Replace newlines
         rest_text_ := REPLACE(REPLACE(rest_text_,lf_,replace_lf_),cr_,replace_cr_);
         -- Replace standard record- and field-separators
         rest_text_ := REPLACE(REPLACE( rest_text_, record_separator_, repl_recsep_), field_separator_, repl_fieldsep_);
         --
         IF (write_out_rec_ ) THEN
            text_restlength_ := LENGTH(rest_text_);
            IF ( (text_length_ + LENGTH(rest_text_)) > 30000 AND deploy_prefix_ IS NOT NULL ) THEN
               -- Make suitable PL/SQL-blocks to avoid error message
               -- 'Program too large' in Admin.exe
               deploy_end_ := Build_Deploy_Code__('END');
               FOR deploy_end_index_ IN 1..deploy_end_.COUNT LOOP
                  file_seq_ := file_seq_ + 1;
                  out_rec_.file_string(file_seq_) := deploy_end_(deploy_end_index_);
               END LOOP;
               FOR deploy_start_index_ IN 1..deploy_start_.COUNT LOOP
                  file_seq_ := file_seq_ + 1;
                  out_rec_.file_string(file_seq_) := deploy_start_(deploy_start_index_);
               END LOOP;
               deploy_end_ := Build_Deploy_Code__('STOP');
               text_length_ := 0;
            END IF;
            -- Loop to write text in suitable lengths
            WHILE text_restlength_ > text_column_length_ LOOP
               file_seq_ := file_seq_ + 1;
               print_text_ := SUBSTR(rest_text_,1,text_column_length_);
               rest_text_ := SUBSTR(rest_text_,text_column_length_+1);
               text_restlength_ := LENGTH(rest_text_);
               -- Add comments for replication jobs
               print_text_ := comment_||print_text_;
               IF ( deploy_start_ IS NOT NULL ) THEN
                  -- Add deploy-variables
                  print_text_ := deploy_prefix_||print_text_||deploy_suffix_;
               END IF;
               out_rec_.file_string(file_seq_) := print_text_;
            END LOOP;
            IF (text_restlength_ > 0 ) THEN
               file_seq_ := file_seq_ + 1;
               print_text_ := SUBSTR(rest_text_,1,text_column_length_);
               -- Add comments for replication jobs
               print_text_ := comment_||print_text_;
               IF ( deploy_start_ IS NOT NULL ) THEN
                  -- Add deploy-variables
                  print_text_ := deploy_prefix_||print_text_||deploy_suffix_;
               END IF;
               out_rec_.file_string(file_seq_) := print_text_;
            END IF;
            text_length_ := text_length_ + LENGTH(print_text_);
            --
         END IF;
      END LOOP;
      IF ( DBMS_SQL.Is_Open(h_cur_)) THEN
          DBMS_SQL.Close_Cursor(h_cur_);
      END IF;
   END LOOP;
   FOR deploy_end_index_ IN 1..deploy_end_.COUNT LOOP
      file_seq_ := file_seq_ + 1;
      out_rec_.file_string(file_seq_) := deploy_end_(deploy_end_index_);
   END LOOP;
   FOR i IN 1..file_seq_ LOOP
      print_text_ := out_rec_.file_string(i);
      IF ( intf_file_is_on_client_ ) THEN
         Intface_Job_Detail_API.Process_Job_Details(intface_name_,
            i , print_text_ , null , 'OUTPUT_TO_CLIENT' , null );
      ELSE
         UTL_FILE.PUT_LINE (Intface_Detail_API.intf_file_handle_, Database_SYS.Db_To_File_Encoding(print_text_));
      END IF;
   END LOOP;
   IF ( repl_count_ != 0) THEN
      comment_ := '--';
      -- Get info and source code for Db Objects
      FOR i IN 1..repl_count_ LOOP
         FOR rec_ IN get_objects(job_rec_.intface_name(i)) LOOP
            -- Save triggers
            IF ( rec_.object_type = 'TRIGGER') THEN
               IF ( INSTR(NVL(selection_info_.selected_trig_,'*'),'   '||rec_.object_name||crlf_) = 0 ) THEN
                  selection_info_.selected_trig_ := selection_info_.selected_trig_||'   '||rec_.object_name||crlf_;
               END IF;
               trigger_count_ := trigger_count_ +1;
               trigger_rec_.name(trigger_count_) := rec_.object_name;
            ELSIF ( rec_.object_type = 'PACKAGE BODY') THEN
               IF ( INSTR(NVL(selection_info_.selected_pack_,'*'),'   '||rec_.object_name||crlf_) = 0 ) THEN
                  selection_info_.selected_pack_ := selection_info_.selected_pack_||'   '||rec_.object_name||crlf_;
               END IF;
            END IF;
            source_count_ := source_count_ + 1;
            source_rec_.text(source_count_) := comment_||LPAD('=',118,'=');
            source_count_ := source_count_ + 1;
            source_rec_.text(source_count_) := comment_||rec_.text;
            error_message_ := SUBSTR(Intface_Repl_Maint_Util_API.Get_Source_Error(rec_.object_name),1,2000);
            IF ( error_message_ IS NOT NULL ) THEN
               source_count_ := source_count_ + 1;
               source_rec_.text(source_count_) := error_message_;
            END IF;
            FOR srec_ IN get_source(rec_.object_name, rec_.object_type ) LOOP
               old_type_ := srec_.type;
               IF ( srec_.line = 1 ) THEN
                  source_count_ := source_count_ + 1;
                  source_rec_.text(source_count_) := 'CREATE OR REPLACE '||srec_.text;
                  do_write_ := TRUE;
               ELSIF ( srec_.text = 'END '||rec_.object_name||';' ) THEN
                  source_count_ := source_count_ + 1;
                  source_rec_.text(source_count_) := srec_.text;
                  do_write_ := FALSE;
               ELSE
                  IF ( do_write_) THEN
                     source_count_ := source_count_ + 1;
                     source_rec_.text(source_count_) := srec_.text;
                  END IF;
               END IF;
            END LOOP;
            IF ( source_count_ != 2  ) THEN
               -- No slash in heading
               source_count_ := source_count_ + 1;
               source_rec_.text(source_count_) := '/';
            END IF;
         END LOOP;
      END LOOP;
   END IF;
   IF ( source_count_ != 0) THEN
      FOR i1 IN 0..source_count_ LOOP
         file_seq_ := file_seq_ + 1;
         IF ( intf_file_is_on_client_ ) THEN
            Intface_Job_Detail_API.Process_Job_Details(intface_name_,
               file_seq_ ,source_rec_.text(i1) , null , 'OUTPUT_TO_CLIENT' , null );
         ELSE
            UTL_FILE.PUT_LINE (Intface_Detail_API.intf_file_handle_, Database_SYS.Db_To_File_Encoding(source_rec_.text(i1)));
         END IF;
      END LOOP;
   END IF;
   IF ( trigger_count_ != 0) THEN
      FOR i2 IN 1..trigger_count_ LOOP
         file_seq_ := file_seq_ + 1;
         -- Always disable triggers
         trigger_text_ := 'ALTER TRIGGER '||trigger_rec_.name(i2)||' DISABLE';
         IF ( intf_file_is_on_client_ ) THEN
            Intface_Job_Detail_API.Process_Job_Details(intface_name_,
               file_seq_ ,trigger_text_ , null , 'OUTPUT_TO_CLIENT' , null );
         ELSE
            UTL_FILE.PUT_LINE (Intface_Detail_API.intf_file_handle_, Database_SYS.Db_To_File_Encoding(trigger_text_));
         END IF;
         file_seq_ := file_seq_ + 1;
         trigger_text_ := '/ ';
         IF ( intf_file_is_on_client_ ) THEN
            Intface_Job_Detail_API.Process_Job_Details(intface_name_,
               file_seq_ ,trigger_text_ , null , 'OUTPUT_TO_CLIENT' , null );
         ELSE
            UTL_FILE.PUT_LINE (Intface_Detail_API.intf_file_handle_, Database_SYS.Db_To_File_Encoding(trigger_text_));
         END IF;
      END LOOP;
   END IF;
   App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_execution_ok_cid_,TRUE);
EXCEPTION
   WHEN OTHERS THEN
      Trace_SYS.Message(SQLERRM);
      info_ := SQLERRM;
      Error_SYS.Record_General(lu_name_, 'EXPERR: Error exporting :P1 - :P2 ', intface_name_, SQLERRM );
END Fndmig_Export__;


-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

PROCEDURE Start_Batch_ (
   attr_ IN VARCHAR2 )
IS
   proc_name_      intface_header.procedure_name%TYPE;
   intface_name_   intface_header.intface_name%TYPE;
   direction_      intface_procedures_tab.direction%TYPE;
BEGIN

   intface_name_ := Client_SYS.Get_Item_Value('INTFACE_NAME',attr_);
   proc_name_ := Client_SYS.Get_Item_Value('PROCEDURE_NAME',attr_);
   direction_ := Client_SYS.Get_Item_Value('DIRECTION',attr_);
   -- Call different procedures in order to be able to execute jobs in different batch queues
   IF ( direction_ = '5' ) THEN
      Transaction_SYS.Deferred_Call('Intface_Header_API.Start_Replication_Out_Batch_',attr_, Intface_Header_API.Get_Description(intface_name_));
   ELSIF ( direction_ = '4' ) THEN
      IF (proc_name_ = 'REPLICATION') THEN
         Transaction_SYS.Deferred_Call('Intface_Header_API.Start_Replication_Batch_',attr_, Intface_Header_API.Get_Description(intface_name_));
      ELSE
         Transaction_SYS.Deferred_Call('Intface_Header_API.Start_Migration_Batch_',attr_, Intface_Header_API.Get_Description(intface_name_));
      END IF;
   ELSE
      Transaction_SYS.Deferred_Call('Intface_Header_API.Start_Job_Batch_',attr_, Intface_Header_API.Get_Description(intface_name_));
   END IF;
EXCEPTION
   WHEN OTHERS THEN
      Error_SYS.Record_General(lu_name_, 'STARTBATERR: Unable to start :P1  - :P2 ', intface_name_, SQLERRM);
END Start_Batch_;


PROCEDURE Start_Job_Batch_ (
   attr_ IN VARCHAR2 )
IS
   info_         VARCHAR2(32000);
   intface_name_ VARCHAR2(30);
   inf_exec_ok_  BOOLEAN;
   type_         VARCHAR2(10) := 'INFO';
BEGIN
   --
   info_ := Client_SYS.Get_Item_Value('INFO',attr_);
   intface_name_ := Client_SYS.Get_Item_Value('INTFACE_NAME',attr_);
   --
   Intface_Job_Detail_API.Just_Do_It( info_, intface_name_);
   
   inf_exec_ok_ := App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_execution_ok_cid_);
   IF ( inf_exec_ok_ ) THEN
      Transaction_SYS.Log_Progress_Info(Language_SYS.Translate_Constant(lu_name_, 'BATCHJOBCOMP: Migration Job :P1 execution completed.', Fnd_Session_API.Get_Language, intface_name_));
   ELSE
      type_ := 'WARNING';
      Transaction_SYS.Log_Progress_Info(Language_SYS.Translate_Constant(lu_name_, 'BATCHJOBERROR: Migration Job :P1 execution ended with error(s). See Migration Job History window for more information.', Fnd_Session_API.Get_Language, intface_name_));
   END IF;
   IF (length(info_) < 2000) THEN
      Transaction_SYS.Log_Status_Info(info_, type_);
   ELSE
      Transaction_SYS.Log_Status_Info(SUBSTR(info_, 1, 2000), type_);
      Transaction_SYS.Log_Status_Info(SUBSTR(info_, 2001, 2000), type_);
   END IF;
   --
EXCEPTION
   WHEN OTHERS THEN
      Error_SYS.Record_General(lu_name_, 'JOBBATERR: Deffered call failed for :P1  - :P2 ', intface_name_, SQLERRM);
END Start_Job_Batch_;


PROCEDURE Start_Replication_Batch_ (
   attr_ IN VARCHAR2 )
IS
BEGIN
   Start_Job_Batch_(attr_);
END Start_Replication_Batch_;


PROCEDURE Start_Replication_Out_Batch_ (
   attr_ IN VARCHAR2 )
IS
   info_         VARCHAR2(2000);
   intface_name_ intface_header.intface_name%TYPE;
BEGIN
   intface_name_ := Client_SYS.Get_Item_Value('INTFACE_NAME',attr_);
   info_ := attr_;
   Intface_Util_API.Replic_Data_Out( info_, intface_name_);
   info_ := Client_SYS.Get_Item_Value('INFO',attr_);
   Transaction_SYS.Log_Progress_Info(SUBSTR(info_,1,100)); -- Only 100 characters visible on client
END Start_Replication_Out_Batch_;


PROCEDURE Start_Migration_Batch_ (
   attr_ IN VARCHAR2 )
IS
BEGIN
   Start_Job_Batch_(attr_);
END Start_Migration_Batch_;


-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------

PROCEDURE Exist_Table (
   table_name_ IN VARCHAR2 )
IS
BEGIN
   IF (NOT Check_Exist_Table__(table_name_)) THEN
      Error_SYS.Record_Not_Exist(table_name_);
   END IF;
END Exist_Table;


@UncheckedAccess
FUNCTION Get_Column_Separator (
   intface_name_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   temp_ INTFACE_HEADER_TAB.column_separator%TYPE; -- Return db-value
   CURSOR get_attr IS
      SELECT column_separator
      FROM INTFACE_HEADER_TAB
      WHERE intface_name = intface_name_;
BEGIN
   OPEN get_attr;
   FETCH get_attr INTO temp_;
   CLOSE get_attr;
   RETURN temp_;
END Get_Column_Separator;


@UncheckedAccess
FUNCTION Get_Thousand_Separator (
   intface_name_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   temp_ INTFACE_HEADER_TAB.thousand_separator%TYPE; -- Return db-value
   CURSOR get_attr IS
      SELECT thousand_separator
      FROM INTFACE_HEADER_TAB
      WHERE intface_name = intface_name_;
BEGIN
   OPEN get_attr;
   FETCH get_attr INTO temp_;
   CLOSE get_attr;
   RETURN temp_;
END Get_Thousand_Separator;


@UncheckedAccess
FUNCTION Get_Decimal_Point (
   intface_name_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   temp_ INTFACE_HEADER_TAB.decimal_point%TYPE; -- Return db-value
   CURSOR get_attr IS
      SELECT decimal_point
      FROM INTFACE_HEADER_TAB
      WHERE intface_name = intface_name_;
BEGIN
   OPEN get_attr;
   FETCH get_attr INTO temp_;
   CLOSE get_attr;
   RETURN temp_;
END Get_Decimal_Point;


@UncheckedAccess
FUNCTION Get_Column_Embrace (
   intface_name_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   temp_ INTFACE_HEADER_TAB.column_embrace%TYPE; -- Return db-value
   CURSOR get_attr IS
      SELECT column_embrace
      FROM INTFACE_HEADER_TAB
      WHERE intface_name = intface_name_;
BEGIN
   OPEN get_attr;
   FETCH get_attr INTO temp_;
   CLOSE get_attr;
   RETURN temp_;
END Get_Column_Embrace;


@UncheckedAccess
FUNCTION Get_File_Encoding (
   intface_name_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   character_set_      VARCHAR2(100);
BEGIN
   character_set_ := Get_Char_Set(intface_name_);
   RETURN character_set_;
EXCEPTION
   WHEN OTHERS THEN
      RETURN NULL;
END Get_File_Encoding;


PROCEDURE Set_Last_Info (
   intface_name_  IN VARCHAR2,
   info_          IN VARCHAR2 ,
   last_executed_ IN DATE DEFAULT NULL,
   server_file_info_ IN VARCHAR2 DEFAULT NULL )
IS
   last_info_       intface_header_tab.last_info%TYPE;
   file_info_       VARCHAR2(2000);
   message_start_   VARCHAR2(2000);
   message_end_     VARCHAR2(2000);
   path_            VARCHAR2(2000);
   end_time_        VARCHAR2(30);
   elapsed_time_    NUMBER;
   elapsed_hours_   NUMBER;
   elapsed_minutes_ NUMBER;
   intf_start_time_ VARCHAR2(30) := App_Context_SYS.Find_Value('INTFACE_JOB_DETAIL_API.INTF_START_TIME_');
   intf_exec_no_    NUMBER := App_Context_SYS.Find_Number_Value(Intface_Job_Detail_API.intf_execution_no_cid_, NULL);
   --
   CURSOR get_data IS
      SELECT ROWID,
             Intface_Detail_API.Get_Column_Description('INTFACE_HEADER','INTFACE_FILE') file_prompt,
             Intface_Detail_API.Get_Column_Description('INTFACE_HEADER','INTFACE_PATH') path_prompt,
             Intface_Detail_API.Get_Column_Description('INTFACE_HEADER','FILE_LOCATION') loc_prompt,
             Intface_Detail_API.Get_Column_Description('INTFACE_HEADER','CHAR_SET') chr_prompt,
             file_location,file_location_db,intface_file,char_set,
             Intface_Direction_API.Encode(
               Intface_Procedures_API.get_direction(procedure_name)) direction , to_char(sysdate,'DD-MON-YYYY HH24:MI:SS') end_time
      FROM   intface_header
      WHERE  intface_name = intface_name_;
   CURSOR get_path (dir_ VARCHAR2) IS
      SELECT a.path
      FROM   intface_server_dir_lov a
      WHERE  a.name = dir_;
BEGIN
   FOR rec_ IN get_data LOOP
      IF ( rec_.direction IN ('1','2') AND server_file_info_ IS NULL ) THEN
         IF ( Intface_Detail_API.Get_Current_File_Path  IS NOT NULL) THEN
            OPEN get_path (Intface_Detail_API.Get_Current_File_Path);
            FETCH get_path INTO path_;
            CLOSE get_path;
            IF ( path_ IS NOT NULL ) THEN
               IF ( path_ = Intface_Detail_API.Get_Current_File_Path ) THEN
                  path_ := NULL;
               ELSE
                  path_ := ' (' || path_ || ')';
               END IF;
            END IF;
         END IF;
         message_start_ := Language_SYS.Translate_Constant(lu_name_, ' TIMESTAMP1 : Start time - :P1   :P2', Fnd_Session_API.Get_Language, intf_start_time_, intface_name_);
         IF intf_exec_no_ IS NOT NULL THEN
            message_start_ := message_start_ || ' - ' || Language_SYS.Translate_Constant(lu_name_, ' EXECNO : Execution No :P1 ', Fnd_Session_API.Get_Language, intf_exec_no_);
         END IF;
         message_start_ := message_start_ || crlf_||crlf_;
         end_time_ := rec_.end_time;
         IF ( SUBSTR(rec_.intface_file,1,1) = '*' ) THEN
            file_info_ := crlf_||rec_.path_prompt||': '||Intface_Detail_API.Get_Current_File_Path||path_||
                          crlf_||rec_.loc_prompt||': '||rec_.file_location;
         ELSE
            file_info_ := crlf_||rec_.path_prompt||': '||Intface_Detail_API.Get_Current_File_Path||path_||
                          crlf_||rec_.file_prompt||': '||Intface_Detail_API.Get_Current_File_Name||
                          crlf_||rec_.loc_prompt||': '||rec_.file_location;
            IF ( rec_.file_location_db = '1') THEN
               file_info_ := file_info_||crlf_ || rec_.chr_prompt||': ';
               IF ( rec_.char_set IS NOT NULL ) THEN
                  file_info_ := file_info_||rec_.char_set;
               ELSE
                  file_info_ := file_info_||Database_SYS.Get_Database_Charset;
               END IF;
            END IF;
         END IF;
         IF App_Context_SYS.Find_Value(Intface_Job_Detail_API.intf_backup_file_context_id_) IS NOT NULL THEN
               file_info_ := file_info_|| crlf_||Language_SYS.Translate_Constant( lu_name_, ' BCKPATH : Backup File Path : :P1 ', Fnd_Session_API.Get_Language, App_Context_SYS.Find_Value(Intface_Job_Detail_API.intf_backup_path_context_id_));
               file_info_ := file_info_|| crlf_||Language_SYS.Translate_Constant( lu_name_, ' BCKFILE : Backup File Name : :P1 ', Fnd_Session_API.Get_Language, App_Context_SYS.Find_Value(Intface_Job_Detail_API.intf_backup_file_context_id_));
         END IF;
         IF App_Context_SYS.Find_Value(Intface_Job_Detail_API.intf_rename_file_context_id_) IS NOT NULL THEN
               file_info_ := file_info_|| crlf_||Language_SYS.Translate_Constant( lu_name_, ' RENPATH : Rename File Path : :P1 ', Fnd_Session_API.Get_Language, App_Context_SYS.Find_Value(Intface_Job_Detail_API.intf_rename_path_context_id_));
               file_info_ := file_info_|| crlf_||Language_SYS.Translate_Constant( lu_name_, ' RANFILE : Rename File Name : :P1 ', Fnd_Session_API.Get_Language, App_Context_SYS.Find_Value(Intface_Job_Detail_API.intf_rename_file_context_id_));
         ELSIF App_Context_SYS.Find_Value(Intface_Job_Detail_API.intf_move_path_context_id_) IS NOT NULL THEN
               file_info_ := file_info_|| crlf_||Language_SYS.Translate_Constant( lu_name_, ' MOVPATH : Move File Path : :P1 ', Fnd_Session_API.Get_Language, App_Context_SYS.Find_Value(Intface_Job_Detail_API.intf_move_path_context_id_));
         ELSIF App_Context_SYS.Find_Value(Intface_Job_Detail_API.intf_delete_file_context_id_) IS NOT NULL THEN
               file_info_ := file_info_|| crlf_||Language_SYS.Translate_Constant( lu_name_, ' DELFILE : File :P1 has been deleted ', Fnd_Session_API.Get_Language, App_Context_SYS.Find_Value(Intface_Job_Detail_API.intf_delete_file_context_id_));
         END IF;
         --
         elapsed_time_ := to_date(end_time_, 'DD-MON-YYYY HH24:MI:SS') - to_date(intf_start_time_, 'DD-MON-YYYY HH24:MI:SS');
         elapsed_hours_ := trunc(elapsed_time_ * 24);
         elapsed_minutes_ := round((elapsed_time_ * 24*60) - (trunc(elapsed_time_*24)*60),1);
         file_info_ := file_info_|| crlf_|| crlf_||Language_SYS.Translate_Constant(lu_name_, ' MSGLAPSE : Used :P1 hours and :P2 minutes ', Fnd_Session_API.Get_Language, to_char(elapsed_hours_),to_char(elapsed_minutes_) );
         --
         message_end_ := crlf_||crlf_||Language_SYS.Translate_Constant(lu_name_, ' TIMESTAMP1 : End time - :P1   :P2', Fnd_Session_API.Get_Language, end_time_, intface_name_);
      END IF;
      last_info_ := SUBSTR(message_start_||info_||crlf_||file_info_||message_end_,1,4000);
      Intface_Job_Detail_API.Set_Ctx_Val_Intf_Last_Info_(last_info_);
      UPDATE intface_header_tab
         SET last_info = last_info_,
             last_executed = NVL(last_executed_, last_executed)
         WHERE ROWID = rec_.ROWID;
   END LOOP;
END Set_Last_Info;


FUNCTION File_Exist (
   file_path_ IN VARCHAR2,
   file_name_ IN VARCHAR2 ) RETURN BOOLEAN
IS
   file_handle_ UTL_FILE.FILE_TYPE;
   file_exist_ BOOLEAN := FALSE;
BEGIN
   file_handle_ := UTL_FILE.FOPEN (file_path_, file_name_, 'R');
   IF UTL_FILE.IS_OPEN (file_handle_) THEN
      file_exist_ := TRUE;
      UTL_FILE.FCLOSE(file_handle_);
   END IF;
   --
   RETURN file_exist_;
EXCEPTION
   WHEN OTHERS THEN
      UTL_FILE.FCLOSE_ALL;
      RETURN file_exist_;
END File_Exist;


PROCEDURE Get_Next_Line (
   line_out_    IN OUT VARCHAR2,
   eof_out_     IN OUT BOOLEAN,
   file_handle_ IN UTL_FILE.FILE_TYPE )
IS
   line_ VARCHAR2(32000);
BEGIN
   UTL_FILE.GET_LINE (file_handle_, line_);
   WHILE ( line_ IS NULL ) LOOP
      UTL_FILE.GET_LINE (file_handle_, line_);
   END LOOP;
   line_out_ := Database_SYS.File_To_Db_Encoding(line_);
   eof_out_ := FALSE;
EXCEPTION
   WHEN NO_DATA_FOUND THEN
      line_out_ := NULL;
      eof_out_  := TRUE;
END Get_Next_Line;


PROCEDURE Start_Job_From_Server (
   info_         IN OUT VARCHAR2,
   attr_         IN OUT VARCHAR2,
   exec_plan_    IN     VARCHAR2,
   intface_name_ IN     VARCHAR2 )
IS
BEGIN
   Trace_SYS.Message('Starting job '||intface_name_||' from server');
   Intface_Header_API.Start_Job (info_, exec_plan_, intface_name_);
   -- Set return-flag according to how the job terminated
   IF ( exec_plan_ = 'ONLINE' ) THEN
      IF ( App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_execution_ok_cid_) ) THEN
         Client_SYS.Add_To_Attr('EXEC_FLAG','TRUE',attr_);
      ELSE
         Client_SYS.Add_To_Attr('EXEC_FLAG','FALSE',attr_);
      END IF;
   ELSE
      Client_SYS.Add_To_Attr('EXEC_FLAG','TRUE',attr_);
   END IF;
END Start_Job_From_Server;


PROCEDURE Start_Job (
   info_         IN OUT VARCHAR2,
   exec_plan_    IN     VARCHAR2,
   intface_name_ IN     VARCHAR2 )
IS
   attr_       VARCHAR2(2000);
   direction_  intface_procedures_tab.direction%TYPE;
   mode_       intface_header.replication_mode%TYPE;
   procedure_  intface_header.procedure_name%TYPE;
   err_msg_    VARCHAR2(2000);
   repl_error_ EXCEPTION;
   man_error_  EXCEPTION;
   schedule_id_ NUMBER;
BEGIN
   Intface_Header_API.Exist(intface_name_);
   procedure_  := Intface_Header_API.Get_Procedure_Name(intface_name_);
   direction_  := Intface_Direction_API.Encode(
                    Intface_Procedures_API.Get_Direction(
                       Intface_Header_API.Get_Procedure_Name(intface_name_)));
   mode_       := Intface_Mode_API.Encode(
                     Intface_Header_API.Get_Replication_Mode(intface_name_));
   Client_SYS.Add_To_Attr('INFO', info_, attr_);
   Client_SYS.Add_To_Attr('INTFACE_NAME', intface_name_, attr_);
   Client_SYS.Add_To_Attr('DIRECTION', direction_, attr_);
   Client_SYS.Add_To_Attr('PROCEDURE_NAME', procedure_, attr_);
   -- Check Structure replication
   IF ( direction_ = '5' ) THEN
      IF (mode_ = '3' AND
        Intface_Repl_Maint_Util_API.Are_Triggers_Enabled(intface_name_) = 'FALSE' ) THEN
         RAISE repl_error_;
      END IF;
      IF (mode_ = '1' AND
        Intface_Repl_Maint_Util_API.Where_Exists(intface_name_) = 'FALSE' ) THEN
         RAISE man_error_;
      END IF;
      Client_SYS.Add_To_Attr('MODE', mode_, attr_);
   END IF;
   --
   IF exec_plan_ = 'ONLINE' THEN
      IF ( direction_ = '5' ) THEN -- Structure replication
         info_ := attr_;
         Intface_Util_API.Replic_Data_Out( info_, intface_name_);
      ELSE
         Intface_Job_Detail_API.Just_Do_It( info_, intface_name_);
      END IF;
   ELSIF exec_plan_ IN ('NOW' , 'ASAP') THEN
      Intface_Header_API.Start_Batch_( attr_);
      Client_SYS.Add_Info(lu_name_, 'STARTOK: Migration job :P1 started in background ', intface_name_);
      info_ := Client_Sys.Get_All_Info;
   ELSE
      DECLARE
         schedule_name_       VARCHAR2(200) := 'Execute Data Migration job: ' || intface_name_ ||
                                               ' (' || Fnd_Session_API.Get_Fnd_User || ')';
         method_              VARCHAR2(200) := 'Intface_Header_API.Start_Batch_';
         active_db_           VARCHAR2(5)   := 'TRUE';
         seq_no_              NUMBER;
         next_execution_date_ DATE := NULL;
         start_date_          DATE := SYSDATE;
         stop_date_           DATE;
      BEGIN
         -- Send NULL in next_execution_date_ to use the default next execution date selection logic.
         Batch_SYS.New_Batch_Schedule(schedule_id_,next_execution_date_,start_date_,stop_date_,schedule_name_,method_,active_db_,exec_plan_);
         Batch_SYS.New_Batch_Schedule_Param(seq_no_, schedule_id_, 'ATTR_', attr_);
      END;
      Client_SYS.Add_Info(lu_name_, 'SERVOK: The database task :P1 is scheduled for migration job :P2.', TO_CHAR(schedule_id_), intface_name_);
      info_ := Client_Sys.Get_All_Info;
   END IF;
   Intface_Job_Detail_API.Format_Info(info_);
EXCEPTION
   WHEN man_error_ THEN
      Client_SYS.Add_Info(lu_name_, 'NOMAN: When starting in mode Manual, you must specify a WHERE-clause for main view in the structure ');
      info_ := Client_Sys.Get_All_Info;
      Intface_Job_Detail_API.Format_Info(info_);
   WHEN repl_error_ THEN
      Client_SYS.Add_Info(lu_name_, 'NOREPL: Cannot start :P1 in batch. Triggers are not enabled ', intface_name_);
      info_ := Client_Sys.Get_All_Info;
      Intface_Job_Detail_API.Format_Info(info_);
   WHEN OTHERS THEN
      err_msg_ := REPLACE(SQLERRM,'ORA-','ORA');
      Error_SYS.Record_General(lu_name_, 'STARTBATERR: Unable to start :P1  - :P2 ', intface_name_, err_msg_);
END Start_Job;


PROCEDURE Build_Select_Stmt (
   parse_stmt_   IN OUT VARCHAR2,
   exec_stmt_    IN OUT VARCHAR2,
   intface_name_ IN     VARCHAR2 )
IS
   count_              NUMBER := 0;
   cols_               VARCHAR2(32000);
   cols_value_         VARCHAR2(2000);
   stmt1_              VARCHAR2(32000);
   where_              VARCHAR2(32000);
   order_by_           VARCHAR2(2000);
   group_by_           VARCHAR2(2000);
   date_format_start_  VARCHAR2(30) := 'to_char(';
   date_format_end_    VARCHAR2(100) := ','||''''||'YYYY-MM-DD-HH24.MI.SS'||''''||')';
   source_name_        VARCHAR2(2000);
   source_owner_       VARCHAR2(2000);
   --
   CURSOR Get_Columns IS
      SELECT *
      FROM Intface_detail_tab
      WHERE intface_name = intface_name_
      AND ( source_column IS NOT NULL OR default_value IS NOT NULL)
      ORDER BY pos,attr_seq;
   --
   rec_   Intface_Detail_API.intdet_record;
BEGIN
   exec_stmt_ := NULL;
   parse_stmt_ := NULL;
   --
   source_name_   := Intface_Header_API.Get_Source_Name(intface_name_);
   source_owner_  := Intface_Header_API.Get_Source_Owner(intface_name_);
   IF ( source_owner_ IS NOT NULL ) THEN
      source_name_ := source_owner_||CHR(46)||source_name_;
   END IF;
   --
   -- Now we start to build the main selection,
   -- and first we make a column-list based on Intface_Details SOURCE_COLUMN and DEFAULT_VALUE
   -- We also save COLUMN_NAME in a PL/SQL-table (rec_)
   -- for use later when we build the main attr-string
   FOR x IN Get_Columns LOOP
      cols_value_ := NULL;
      IF ( x.source_column IS NULL ) THEN
         cols_value_ := x.default_value;
      ELSIF ( x.default_value IS NOT NULL ) THEN
         cols_value_ := 'NVL('||x.source_column||','||x.default_value||')';
      ELSE
         cols_value_ := x.source_column;
      END IF;
      --
      IF ( x.data_type = 'DATE') THEN
         -- Format dates to char values
         cols_value_ := date_format_start_||cols_value_||date_format_end_;
      END IF;
      cols_  := cols_ || cols_value_|| ', ';
      count_ := count_ + 1;
      rec_.cols_(count_)      := x.column_name;
   END LOOP;
   cols_ := RTRIM(RTRIM(cols_,' '),',');
   stmt1_ := 'SELECT ' || cols_ || ' FROM ' || source_name_ ;
   --
   -- Add where-clause to main select.
   --
   where_ := Intface_Header_API.Get_Complete_Where(intface_name_);
   --
   -- Finally, add order-by clause to statement
   --
   group_by_ := Intface_Header_API.Get_group_By_Clause(intface_name_);
   IF ( group_by_ IS NOT NULL) THEN
      group_by_ := ' GROUP BY '||group_by_;
   END IF;
   order_by_ := Intface_Header_API.Get_Order_By_Clause(intface_name_);
   IF ( order_by_ IS NOT NULL) THEN
      order_by_ := ' ORDER BY '||order_by_;
   END IF;
   exec_stmt_ := stmt1_||where_||group_by_||order_by_;
   -- Make extra statement that selects 1 row, for test purpose
   IF ( where_ IS NOT NULL ) THEN
      where_ := where_||' AND rownum = 1';
   ELSE
      where_ := ' WHERE rownum = 1';
   END IF;
   parse_stmt_ := stmt1_||where_||group_by_||order_by_;
END Build_Select_Stmt;


PROCEDURE Show_Select_Stmt (
   info_         IN OUT VARCHAR2,
   intface_name_ IN     VARCHAR2 )
IS
   stmt1_              VARCHAR2(32000);
   stmt2_              VARCHAR2(32000);
   no_start_           EXCEPTION;
   stmt_length_        NUMBER;
   message_select_     VARCHAR2(2000) := NULL;
BEGIN
   Build_Select_Stmt(stmt1_, stmt2_, intface_name_);
   stmt_length_ := LENGTH(stmt2_);
   BEGIN
      -- Safe due to stmt1_ is fully derived
      @ApproveDynamicStatement(2009-11-24,nabalk)
      EXECUTE IMMEDIATE stmt1_;
      -- Make OK message. IF anything fails, it will be replaced by error-message
      message_select_ := Language_SYS.Translate_Constant(lu_name_, ' SELECTOK: Select statement OK, parsed and executed for 1 row ', Fnd_Session_API.Get_Language);
      message_select_ := message_select_ ||crlf_|| Language_SYS.Translate_Constant(lu_name_, ' SELLENGTH: Length of statement : :P1 characters', Fnd_Session_API.Get_Language, to_char(stmt_length_));
   EXCEPTION
      WHEN OTHERS THEN
         Trace_SYS.Message(SQLERRM);
         message_select_ :=  SQLERRM;
         message_select_ := message_select_ ||crlf_|| Language_SYS.Translate_Constant(lu_name_, ' SELLENGTH: Length of statement : :P1 characters', Fnd_Session_API.Get_Language, to_char(stmt_length_));
         Intface_Detail_API.Trace_Long_Msg(stmt2_);
         RAISE no_start_;
   END;
   info_ := stmt2_||crlf_||crlf_||message_select_;
EXCEPTION
   WHEN no_start_ THEN
      info_ := stmt2_||crlf_||crlf_||message_select_;
   WHEN OTHERS THEN
      Trace_SYS.Message(SQLERRM);
      info_ := stmt2_||crlf_||crlf_||SQLERRM;
END Show_Select_Stmt;


FUNCTION Validate_Select_Stmt_Ok (
   intface_name_ IN VARCHAR2) RETURN BOOLEAN
IS
   parse_stmt_ VARCHAR2(32000);
   exec_stmt_  VARCHAR2(32000);
   stmt_ok_    BOOLEAN := TRUE;
BEGIN
   Build_Select_Stmt(parse_stmt_, exec_stmt_, intface_name_);
   BEGIN
      -- Safe due to parse_stmt1_ is fully derived
      @ApproveDynamicStatement(2009-11-24,nabalk)
      EXECUTE IMMEDIATE parse_stmt_;
   EXCEPTION WHEN OTHERS THEN
      stmt_ok_ := FALSE;
   END;
   RETURN stmt_ok_;
END Validate_Select_Stmt_Ok;


PROCEDURE Copy_Intface (
   info_         IN OUT VARCHAR2,
   intface_name_ IN     VARCHAR2 )
IS
   to_intface_ intface_header_tab.intface_name%TYPE;
   userid_     VARCHAR2(30);
   --
   CURSOR get_header IS
      SELECT *
      FROM intface_header_tab
      WHERE intface_name = intface_name_;
   --
   CURSOR get_detail IS
      SELECT *
      FROM intface_detail_tab
      WHERE intface_name = intface_name_;
   --
   CURSOR get_method_list IS
      SELECT *
      FROM intface_method_list_tab
      WHERE intface_name = intface_name_;
   --
   CURSOR get_rules IS
      SELECT *
      FROM intface_rules_tab
      WHERE intface_name = intface_name_;
   --
   CURSOR get_pr_user IS
      SELECT *
      FROM intface_pr_user_tab
      WHERE intface_name = intface_name_
      AND identity = userid_;
   --
   CURSOR get_method_list_attrib IS
      SELECT *
      FROM intface_method_list_attrib_tab
      WHERE intface_name = intface_name_;
   --
   CURSOR get_repl_structure IS
      SELECT *
      FROM intface_repl_structure_tab
      WHERE intface_name = intface_name_;
   --
   CURSOR get_repl_struct_cols IS
      SELECT *
      FROM intface_repl_struct_cols_tab
      WHERE intface_name = intface_name_;
   --
BEGIN
   userid_     := Fnd_Session_API.Get_Fnd_User;
   to_intface_ := UPPER(info_);
   info_ := NULL;
   FOR hrec_ IN get_header LOOP
      Validate_Name___(to_intface_, hrec_.procedure_name);
      INSERT INTO intface_header_tab (
         INTFACE_NAME, DESCRIPTION, INTFACE_PATH, INTFACE_FILE, DATE_FORMAT, MINUS_POS,
         WHERE_CLAUSE, COLUMN_SEPARATOR, THOUSAND_SEPARATOR, DECIMAL_POINT, COLUMN_EMBRACE,
         FILE_LOCATION, PROCEDURE_NAME, VIEW_NAME, SOURCE_NAME, SOURCE_OWNER, NOTE_TEXT,
         ORDER_BY_CLAUSE, GROUP_ID, ENABLED, OBJECT_SEQ, VALUE_LIST, TABLE_NAME, ON_INSERT,
         ON_UPDATE, FROM_VALUE, REPLICATION_MODE, REPL_CRITERIA, MESSAGE_TYPE, MESSAGE_NAME,
         MESSAGE_SENDER, MESSAGE_RECEIVER, GROUP_BY_CLAUSE, TRIGGER_WHEN, CHAR_SET,
         ROWVERSION)
      VALUES (
         to_intface_, hrec_.description, hrec_.intface_path, hrec_.intface_file, hrec_.date_format, hrec_.minus_pos,
         hrec_.where_clause, hrec_.column_separator, hrec_.thousand_separator, hrec_.decimal_point, hrec_.column_embrace,
         hrec_.file_location, hrec_.procedure_name, hrec_.view_name, hrec_.source_name, hrec_.source_owner, hrec_.note_text,
         hrec_.order_by_clause, hrec_.group_id, hrec_.enabled, hrec_.object_seq, hrec_.value_list, hrec_.table_name, hrec_.on_insert,
         hrec_.on_update, hrec_.from_value, hrec_.replication_mode, hrec_.repl_criteria, hrec_.message_type, hrec_.message_name,
         hrec_.message_sender, hrec_.message_receiver, hrec_.group_by_clause, hrec_.trigger_when, hrec_.char_set,
         SYSDATE);
   END LOOP;
   FOR drec_ IN get_detail LOOP
      INSERT INTO intface_detail_tab (
         INTFACE_NAME, COLUMN_NAME, DESCRIPTION, DATA_TYPE, POS, LENGTH,
         DECIMAL_LENGTH, AMOUNT_FACTOR, DEFAULT_VALUE, DEFAULT_WHERE, FLAGS,
         ATTR_SEQ, PAD_CHAR_RIGHT, PAD_CHAR_LEFT, CHANGE_DEFAULTS, ROWVERSION,
         SOURCE_COLUMN, CONV_LIST_ID, DB_CLIENT_VALUES, NOTE_TEXT, EXT_ATTR )
      VALUES (
         to_intface_, drec_.column_name, drec_.description, drec_.data_type, drec_.pos, drec_.length,
         drec_.decimal_length, drec_.amount_factor, drec_.default_value, drec_.default_where, drec_.flags,
         drec_.attr_seq, drec_.pad_char_right, drec_.pad_char_left, drec_.change_defaults, sysdate,
         drec_.source_column,  drec_.conv_list_id, drec_.db_client_values, drec_.note_text, drec_.ext_attr );
   END LOOP;
   FOR mrec_ IN get_method_list LOOP
      INSERT INTO intface_method_list_tab (
         INTFACE_NAME, EXECUTE_SEQ, VIEW_NAME, METHOD_NAME, COLUMN_NAME,
         COLUMN_VALUE, CONVERT_ATTR, ROWVERSION, NOTE_TEXT, REFERENCES,
         SOURCE_NAME, PREFIX_OPTION, ACTION ,ON_NEW, ON_MODIFY,
         ON_NEW_MASTER, ON_FIRST_ROW  )
      VALUES (
         to_intface_ , mrec_.execute_seq, mrec_.view_name, mrec_.method_name, mrec_.column_name,
         mrec_.column_value, mrec_.convert_attr, sysdate , mrec_.note_text, mrec_.references,
         mrec_.source_name, mrec_.prefix_option , mrec_.action, mrec_.on_new, mrec_.on_modify,
         mrec_.on_new_master, mrec_.on_first_row );
   END LOOP;
   FOR mrec_ IN get_method_list_attrib LOOP
      INSERT INTO intface_method_list_attrib_tab (
         INTFACE_NAME, EXECUTE_SEQ, COLUMN_NAME, COLUMN_SEQUENCE, DESCRIPTION, FIXED_VALUE,
         ON_NEW, ON_MODIFY, FLAGS, LU_REFERENCE, IID_VALUES, ROWVERSION )
      VALUES (
         to_intface_, mrec_.execute_seq, mrec_.column_name, mrec_.column_sequence, mrec_.description, mrec_.fixed_value,
         mrec_.on_new, mrec_.on_modify, mrec_.flags, mrec_.lu_reference, mrec_.iid_values, sysdate);
   END LOOP;
   FOR srec_ IN get_repl_structure LOOP
      INSERT INTO intface_repl_structure_tab (
         intface_name, structure_seq, pos, view_name, parent_seq, on_insert, on_update,
         start_point, select_where, trigger_table, trigger_when, record_name,
         element_name, element_type, note_text, rowversion)
      VALUES (
         to_intface_, srec_.structure_seq, srec_.pos, srec_.view_name, srec_.parent_seq, srec_.on_insert, srec_.on_update,
         srec_.start_point, srec_.select_where, srec_.trigger_table, srec_.trigger_when, srec_.record_name,
         srec_.element_name, srec_.element_type, srec_.note_text, sysdate);
   END LOOP;
   FOR trec_ IN get_repl_struct_cols LOOP
      INSERT INTO intface_repl_struct_cols_tab (
         intface_name, structure_seq, column_name, column_seq, description, on_insert,
         on_update, data_type, flags, column_alias, parent_key_name, rowversion)
      VALUES (
         to_intface_, trec_.structure_seq, trec_.column_name, trec_.column_seq, trec_.description, trec_.on_insert,
         trec_.on_update, trec_.data_type, trec_.flags, trec_.column_alias, trec_.parent_key_name, sysdate);
   END LOOP;
   FOR rrec_ IN get_rules LOOP
      INSERT INTO intface_rules_tab (
         INTFACE_NAME, RULE_ID, RULE_VALUE, RULE_FLAG, ROWVERSION)
      VALUES (
         to_intface_, rrec_.rule_id, rrec_.rule_value, rrec_.rule_flag, sysdate );
   END LOOP;
   FOR urec_ IN get_pr_user LOOP
      INSERT INTO intface_pr_user_tab (
         IDENTITY, INTFACE_NAME, ROWVERSION )
      VALUES (
         userid_, to_intface_, sysdate );
   END LOOP;
   info_ := Language_SYS.Translate_Constant(lu_name_, 'COPYOK: Migration Job :P1 created ', Fnd_Session_API.Get_Language, to_intface_);
EXCEPTION
   WHEN OTHERS THEN
      info_ := Language_SYS.Translate_Constant(lu_name_, 'COPYERR: Error creating :P1 - :P2 ', Fnd_Session_API.Get_Language, to_intface_, SQLERRM );
END Copy_Intface;


PROCEDURE Create_Template_Header (
   info_         IN OUT VARCHAR2,
   intface_name_ IN VARCHAR2,
   description_  IN VARCHAR2,
   procedure_    IN VARCHAR2,
   source_name_  IN VARCHAR2,
   source_owner_ IN VARCHAR2 )
IS
   objid_      VARCHAR2(2000);
   objversion_ VARCHAR2(2000);
   attr_       VARCHAR2(2000);
BEGIN
   Client_SYS.Clear_Attr(attr_);
   Intface_Header_API.New__( info_, objid_, objversion_, attr_, 'PREPARE');
   Client_SYS.Add_To_Attr('INTFACE_NAME', intface_name_, attr_);
   Client_SYS.Add_To_Attr('DESCRIPTION', description_, attr_);
   Client_SYS.Add_To_Attr('PROCEDURE_NAME', procedure_, attr_);
   Client_SYS.Add_To_Attr('SOURCE_NAME', source_name_, attr_);
   Client_SYS.Add_To_Attr('SOURCE_OWNER', source_owner_, attr_);
   Intface_Header_API.New__( info_, objid_, objversion_, attr_, 'DO');
END Create_Template_Header;


PROCEDURE Create_Template_Methodlist (
   info_         IN OUT VARCHAR2,
   intface_name_ IN VARCHAR2,
   execute_seq_  IN NUMBER,
   view_name_    IN VARCHAR2,
   source_name_  IN VARCHAR2,
   method_       IN VARCHAR2,
   prefix_       IN VARCHAR2,
   action_       IN VARCHAR2 )
IS
   objid_      VARCHAR2(2000);
   objversion_ VARCHAR2(2000);
   attr_       VARCHAR2(2000);
   view_       INTFACE_HEADER.view_name%TYPE;
   exec_seq_   VARCHAR2(10);

BEGIN
   exec_seq_ := to_char(execute_seq_);
   view_ := view_name_;
   IF Intface_Prefix_Option_API.Encode(prefix_) = '2' THEN
      IF SUBSTR(view_name_, LENGTH(view_name_) - LENGTH(exec_seq_) + 1, LENGTH(exec_seq_)) = exec_seq_ THEN
         view_ := SUBSTR(view_name_,1, LENGTH(view_name_) - LENGTH(exec_seq_));
      END IF;
   END IF;
   Client_SYS.Clear_Attr(attr_);
   Intface_Method_List_API.New__( info_, objid_, objversion_, attr_, 'PREPARE');
   Client_SYS.Add_To_Attr('INTFACE_NAME', intface_name_, attr_);
   Client_SYS.Set_Item_Value('EXECUTE_SEQ', execute_seq_, attr_);
   Client_SYS.Add_To_Attr('VIEW_NAME', view_, attr_);
   Client_SYS.Add_To_Attr('SOURCE_NAME', source_name_, attr_);
   Client_SYS.Add_To_Attr('METHOD_NAME', method_, attr_);
   Client_SYS.Set_Item_Value('PREFIX_OPTION', prefix_, attr_);
   Client_SYS.Set_Item_Value('ACTION', action_, attr_);
   Intface_Method_List_API.New__( info_, objid_, objversion_, attr_, 'DO');
END Create_Template_Methodlist;


@UncheckedAccess
FUNCTION Get_Complete_Where (
   intface_name_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   where_              VARCHAR2(32000);
   direction_          intface_procedures_tab.direction%TYPE;
   --
   CURSOR Get_Default_Where (dir_ IN VARCHAR2)  IS
      SELECT DECODE(dir_,'4',source_column,column_name) column_name,
             default_where
      FROM Intface_detail_tab
      WHERE intface_name = intface_name_
      AND default_where IS NOT NULL
      ORDER BY pos,attr_seq;
BEGIN
   direction_ := Intface_Direction_API.Encode(
                    Intface_Procedures_API.Get_Direction(
                       Intface_Header_API.Get_Procedure_Name(intface_name_)));
   --
   where_ := Get_Where_Clause(intface_name_);
   --
   IF ( where_ IS NOT NULL) THEN
      where_ := ' WHERE '||where_;
   END IF;
   --
   FOR x IN Get_Default_Where ( direction_) LOOP
      IF ( where_ IS NULL) THEN
         where_ := ' WHERE ' || x.column_name || ' ' || x.default_where;
      ELSE
         where_ := where_ || ' AND ' || x.column_name || ' ' || x.default_where;
      END IF;
   END LOOP;
   RETURN where_;
END Get_Complete_Where;


@UncheckedAccess
FUNCTION Find_Last_Characters (
   in_string_   IN VARCHAR2,
   no_of_chars_ IN NUMBER ) RETURN VARCHAR2
IS
   length_ NUMBER;
   return_string_ VARCHAR2(32000);
BEGIN
   return_string_ := in_string_;
   length_ := LENGTH(in_string_);
   IF ( length_ > no_of_chars_  ) THEN
      return_string_ := SUBSTR(in_string_,(length_-no_of_chars_)+1);
   END IF;
   RETURN return_string_;
END Find_Last_Characters;


PROCEDURE Fndmig_Export (
   info_         IN OUT VARCHAR2,
   intface_name_ IN     VARCHAR2 )
IS
   file_location_ intface_header.file_location_db%TYPE;
   file_name_     intface_header.intface_file %TYPE;
   export_pos_    NUMBER;
   where_         VARCHAR2(32000);
   default_where_ VARCHAR2(32000);
   old_default_   VARCHAR2(32000);
   export_item_   VARCHAR2(32000);
   select_cur_    VARCHAR2(32000);
   exp_job_       intface_header.intface_name%TYPE;
   exp_count_     NUMBER;
   file_format_   VARCHAR2(200);
   in_info_       VARCHAR2(32000);
   cre_file_      VARCHAR2(100);
   export_info_   VARCHAR2(32000);
   export_text1_  VARCHAR2(2000);
   export_text2_  VARCHAR2(2000);
   export_text3_  VARCHAR2(2000);
   export_text4_  VARCHAR2(2000);
   export_text5_  VARCHAR2(2000);
   export_text6_  VARCHAR2(2000);
   created_files_ VARCHAR2(32000);
   export_finished_ VARCHAR2(5);
   --
   TYPE exp_job IS REF CURSOR;
   exp_cur_     exp_job;
   
   selection_info_ Selection_Info;
   intf_in_info_    VARCHAR2(2000) := App_Context_SYS.Find_Value(Intface_Job_Detail_API.intf_in_info_cid_);
   
BEGIN
   IF ( export_finished_ IS NULL ) THEN
      export_finished_ := 'FALSE';
      selection_info_.selected_jobs_   := NULL;
      selection_info_.selected_groups_ := NULL;
      selection_info_.selected_lists_  := NULL;
      selection_info_.selected_trig_   := NULL;
      selection_info_.selected_pack_   := NULL;
      created_files_   := NULL;
   END IF;
   --
   file_location_ := Intface_Header_API.Get_File_Location(intface_name_);
   file_name_ := Intface_Header_API.Get_Intface_File (intface_name_);
   IF ( Intface_File_Location_API.Encode(file_location_) = '1' AND file_name_ like '*.%' ) THEN
      IF ( Intface_Rules_API.Rule_Is_Active(
           file_format_, 'DEPLOYFILE', intface_name_) ) THEN
           NULL; -- make IF-test to catch file_format_
      END IF;
      -- OnServer is specified, but no file_name given; export 1 file per Job_ID
      IF ( intf_in_info_ IS NOT NULL ) THEN
         export_pos_ := INSTR(intf_in_info_, 'INTFACE_NAME=');
         IF ( export_pos_ != 0 ) THEN
            -- Single job export
            export_item_ := SUBSTR(intf_in_info_,export_pos_+13);
            default_where_ := 'intface_name = '||''''||export_item_||'''';
         ELSE
            export_pos_ := INSTR(intf_in_info_, 'GROUP_ID=');
            IF ( export_pos_ != 0 ) THEN
               -- Single group export
               export_item_ := SUBSTR(intf_in_info_,export_pos_+9);
               default_where_ := 'INTFACE_NAME IN ( SELECT intface_name FROM intface_header '||
                                   'WHERE group_id =  '||''''||export_item_||''''||')';
            END IF;
         END IF;
      END IF;
      where_ := Intface_Header_API.Get_Where_Clause(intface_name_);
      -- Save old default_where
      old_default_ := Intface_Detail_API.Get_Default_Where(intface_name_, 'INTFACE_NAME');
      --
      IF ( default_where_ IS NOT NULL ) THEN
         UPDATE intface_detail_tab
         SET default_where = NULL
         WHERE intface_name = intface_name_;
         --
         IF ( where_ IS NOT NULL ) THEN
            where_ := ' WHERE '||where_||' AND '||default_where_;
         ELSE
            where_ := ' WHERE '||default_where_;
         END IF;
      ELSE
            where_ := Intface_Header_API.Get_Complete_Where(intface_name_);
      END IF;
      --
      select_cur_ := 'SELECT intface_name '||
                     'FROM intface_header '||where_;
      Intface_Detail_API.Trace_Long_Msg(select_cur_);
      @ApproveDynamicStatement(2011-05-19,jhmase)
      OPEN exp_cur_ FOR select_cur_;
      LOOP
         FETCH exp_cur_ INTO exp_job_;
         EXIT WHEN exp_cur_%NOTFOUND;
         exp_count_ := exp_cur_%ROWCOUNT;
         in_info_ := 'INTFACE_NAME='||exp_job_;
         -- Update intface_file, export one and one job.
         -- Filename will be in mixed upper/lowercase , with same file extension as saved on Header
         IF ( file_format_ IS NOT NULL ) THEN
            cre_file_ := REPLACE(INITCAP(exp_job_),'_','')||SUBSTR(file_name_,INSTR(file_name_,'*.')+1);
         ELSE
            cre_file_ := exp_job_||SUBSTR(file_name_,INSTR(file_name_,'*.')+1);
         END IF;
         --
         UPDATE intface_header_tab
         SET intface_file = cre_file_
         WHERE intface_name = intface_name_;
         --
         @ApproveTransactionStatement(2013-11-20,wawilk)
         COMMIT;
         export_finished_ := 'WORK';
         Intface_Header_API.Start_Job(in_info_, 'ONLINE', intface_name_);
         IF ( INSTR(NVL(created_files_,'*'),'   '||cre_file_||crlf_) = 0 ) THEN
            created_files_ := created_files_||'   '||cre_file_||crlf_;
         END IF;
      END LOOP;
      export_finished_ := 'FALSE';
      CLOSE exp_cur_;
      -- Reset intface_file back to original value
      UPDATE intface_header_tab
      SET intface_file = file_name_
      WHERE intface_name = intface_name_;
      IF ( old_default_ IS NOT NULL ) THEN
         -- Reset default_where back to original value
         UPDATE intface_detail_tab
         SET default_where = old_default_
         WHERE intface_name = intface_name_
         AND column_name = 'INTFACE_NAME';
      END IF;
   ELSE
      -- Standard export-job
      Fndmig_Export__(info_, intface_name_,selection_info_);
   END IF;
   IF ( NVL(export_finished_,'TRUE') = 'FALSE') THEN
      export_info_  := NULL;
      export_text1_ :=  Language_SYS.Translate_Constant(lu_name_, 'EXPTXT1: Exported migration jobs : ', Fnd_Session_API.Get_Language);
      export_text2_ :=  Language_SYS.Translate_Constant(lu_name_, 'EXPTXT2: Exported migration groups : ', Fnd_Session_API.Get_Language);
      export_text4_ :=  Language_SYS.Translate_Constant(lu_name_, 'EXPTXT4: Exported triggers : ', Fnd_Session_API.Get_Language);
      export_text5_ :=  Language_SYS.Translate_Constant(lu_name_, 'EXPTXT5: Exported packages : ', Fnd_Session_API.Get_Language);
      export_text6_ :=  Language_SYS.Translate_Constant(lu_name_, 'EXPTXT6: Created files : ', Fnd_Session_API.Get_Language);
      IF ( selection_info_.selected_jobs_ IS NOT NULL ) THEN
         export_info_ := Add_To_Info___(export_info_,export_text1_,selection_info_.selected_jobs_);
      END IF;
      IF ( selection_info_.selected_groups_ IS NOT NULL ) THEN
         export_info_ := Add_To_Info___(export_info_,export_text2_,selection_info_.selected_groups_);
      END IF;
      IF ( selection_info_.selected_lists_ IS NOT NULL ) THEN
         IF ( NVL(UPPER(Intface_Detail_API.Get_Default_Value(intface_name_, 'EXP_LIST_FLAG')),'Y') = 'Y') THEN
            export_text3_ :=  Language_SYS.Translate_Constant(lu_name_, 'EXPTXT3: Exported conversion lists : ', Fnd_Session_API.Get_Language);
         ELSE
            export_text3_ :=  Language_SYS.Translate_Constant(lu_name_, 'EXPTXT7: Conversion lists NOT exported : ', Fnd_Session_API.Get_Language);
         END IF;
         export_info_ := Add_To_Info___(export_info_,export_text3_,selection_info_.selected_lists_);
      END IF;
      IF ( selection_info_.selected_trig_ IS NOT NULL ) THEN
         export_info_ := Add_To_Info___(export_info_,export_text4_,selection_info_.selected_trig_);
      END IF;
      IF ( selection_info_.selected_pack_ IS NOT NULL ) THEN
         export_info_ := Add_To_Info___(export_info_,export_text5_,selection_info_.selected_pack_);
      END IF;
      IF ( created_files_ IS NOT NULL ) THEN
         export_info_ := Add_To_Info___(export_info_,export_text6_,created_files_);
      END IF;
      --
      info_ := RTRIM(SUBSTR(export_info_,1,2000),crlf_);
      export_finished_ := NULL;
   END IF;
EXCEPTION
   WHEN OTHERS THEN
      Trace_SYS.Message(SQLERRM);
      info_ := SQLERRM;
      Error_SYS.Record_General(lu_name_, 'EXPERR: Error exporting :P1 - :P2 ', intface_name_, SQLERRM );
END Fndmig_Export;


PROCEDURE Fndmig_Import (
   info_         IN OUT VARCHAR2,
   intface_name_ IN     VARCHAR2 )
IS
   --
   attr_         VARCHAR2(32000);
   insert_info_  VARCHAR2(32000);
   reject_info_  VARCHAR2(32000);
   end_of_file_  BOOLEAN := FALSE;
   file_string_  VARCHAR2(2000);
   status_       intface_job_detail_tab.status%TYPE;
   line_no_      intface_job_detail_tab.line_no%TYPE;
   line_objid_   rowid;
   --
   h_cur_        INTEGER;
   h_stmt_       VARCHAR2(32000);
   d_cur_        INTEGER;
   d_stmt_       VARCHAR2(32000);
   r_cur_        INTEGER;
   r_stmt_       VARCHAR2(32000);
   s_cur_        INTEGER;
   s_stmt_       VARCHAR2(32000);
   t_cur_        INTEGER;
   t_stmt_       VARCHAR2(32000);
   m_cur_        INTEGER;
   m_stmt_       VARCHAR2(32000);
   a_cur_        INTEGER;
   a_stmt_       VARCHAR2(32000);
   c_cur_        INTEGER;
   c_stmt_       VARCHAR2(32000);
   l_cur_        INTEGER;
   l_stmt_       VARCHAR2(32000);
   g_cur_        INTEGER;
   g_stmt_       VARCHAR2(32000);
   dummy_        NUMBER;
   --
   rowtype_      VARCHAR2(10);
   old_rowtype_  VARCHAR2(10);
   --
   header_table_       VARCHAR2(30)     := 'INTFACE_HEADER_TAB';
   group_table_        VARCHAR2(30)     := 'INTFACE_GROUP_TAB';
   detail_table_       VARCHAR2(30)     := 'INTFACE_DETAIL_TAB';
   method_table_       VARCHAR2(30)     := 'INTFACE_METHOD_LIST_TAB';
   method_attr_table_  VARCHAR2(30)     := 'INTFACE_METHOD_LIST_ATTRIB_TAB';
   repl_struct_table_  VARCHAR2(30)     := 'INTFACE_REPL_STRUCTURE_TAB';
   repl_str_cols_table_ VARCHAR2(30)    := 'INTFACE_REPL_STRUCT_COLS_TAB';
   rules_table_        VARCHAR2(30)     := 'INTFACE_RULES_TAB';
   conv_list_table_    VARCHAR2(30)     := 'INTFACE_CONV_LIST_TAB';
   conv_cols_table_    VARCHAR2(30)     := 'INTFACE_CONV_LIST_COLS_TAB';
   table_name_         VARCHAR2(30);
   old_key_value_      VARCHAR2(100);
   key_value_          VARCHAR2(100);
   key_column_         VARCHAR2(100);
   master_table_       VARCHAR2(100);
   inserted_intfaces_  VARCHAR2(32000);
   replaced_intfaces_  VARCHAR2(32000);
   keep_intfaces_      VARCHAR2(32000);
   rejected_intfaces_  VARCHAR2(32000);
   inserted_lists_     VARCHAR2(32000);
   replaced_lists_     VARCHAR2(32000);
   rejected_lists_     VARCHAR2(32000);
   keep_lists_         VARCHAR2(32000);
   inserted_groups_    VARCHAR2(32000);
   rejected_groups_    VARCHAR2(32000);
   replaced_groups_    VARCHAR2(32000);
   repl_jobs_restart_  VARCHAR2(32000);
   keep_groups_        VARCHAR2(32000);
   import_text1_       VARCHAR2(2000);
   import_text2_       VARCHAR2(2000);
   import_text3_       VARCHAR2(2000);
   import_text4_       VARCHAR2(2000);
   import_text5_       VARCHAR2(2000);
   import_text6_       VARCHAR2(2000);
   import_text7_       VARCHAR2(2000);
   import_text8_       VARCHAR2(2000);
   import_text9_       VARCHAR2(2000);
   import_text10_      VARCHAR2(2000);
   intface_count_      NUMBER           :=0;
   list_count_         NUMBER           :=0;
   group_count_        NUMBER           :=0;
   attr_count_         NUMBER           :=0;
   userid_             VARCHAR2(30) := Fnd_Session_API.Get_Fnd_User;
   user_intface_       VARCHAR2(2000);
   del_flag_           VARCHAR2(100);
   del_job_flag_       VARCHAR2(100);
   del_list_flag_      VARCHAR2(100);
   import_rec_         insert_record;
   --
   column_embrace_     intface_header_tab.column_embrace%TYPE;
   intf_file_is_on_client_ BOOLEAN := App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_file_is_on_client_cid_);
   intf_file_is_on_server_ BOOLEAN := App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_file_is_on_server_cid_);

   PROCEDURE Local_Execute (
      x_stmt_     IN OUT VARCHAR2,
      x_cur_      IN OUT INTEGER,
      table_name_ IN VARCHAR2,
      attr_       IN VARCHAR2 )
   IS
      ptr_          NUMBER;
      name_         VARCHAR2(100);
      value_        VARCHAR2(32000);
   BEGIN
      IF ( x_stmt_ IS NULL ) THEN
         -- Build statement and parse it
         x_stmt_ := 'INSERT INTO '||table_name_||' (';
         ptr_ := NULL;
         -- Loop on attr to make insert_list
         WHILE (Client_SYS.Get_Next_From_Attr(attr_, ptr_, name_, value_)) LOOP
            x_stmt_ := x_stmt_||name_||',';
         END LOOP;
         x_stmt_ := x_stmt_||'ROWVERSION ) VALUES (';
         ptr_ := NULL;
         -- Loop on attr to make variable_list
         WHILE (Client_SYS.Get_Next_From_Attr(attr_, ptr_, name_, value_)) LOOP
            x_stmt_ := x_stmt_||':'||name_||',';
         END LOOP;
         x_stmt_ := x_stmt_||':ROWVERSION )';
         --
         -- Safe due to appending values are not directly exposed to user inputs
         @ApproveDynamicStatement(2009-11-24,nabalk)
         DBMS_SQL.Parse(x_cur_, x_stmt_, DBMS_SQL.native);
      END IF;
      ptr_ := NULL;
      -- Loop on attr once more to send variable-values to parsed statement
      WHILE (Client_SYS.Get_Next_From_Attr(attr_, ptr_, name_, value_)) LOOP
         DBMS_SQL.bind_variable(x_cur_,name_, value_, 32000);
      END LOOP;
      DBMS_SQL.bind_variable(x_cur_,'ROWVERSION', sysdate, 32000);
      dummy_ := DBMS_SQL.Execute(x_cur_);
   END Local_Execute;
   --
   PROCEDURE Local_Close (
      x_cur_      IN OUT INTEGER)
   IS
   BEGIN
      IF ( DBMS_SQL.Is_Open(x_cur_)) THEN
         DBMS_SQL.Close_Cursor(x_cur_);
      END IF;
   END Local_Close;
   --
BEGIN
   column_embrace_ := Intface_Format_Char_API.Get_Char(Intface_Header_API.Get_Column_Embrace(intface_name_));
   @ApproveTransactionStatement(2013-11-20,wawilk)
   SAVEPOINT new_job_;
   -- Get default value for DEL_FLAG
   -- Decides if we are going to overwrite data or not
   del_flag_ := UPPER(Intface_Detail_API.Get_Default_Value(intface_name_, 'DEL_FLAG'));
   -- New flags for delete. We differ between deletion of basic data and conversion lists
   -- Keep old del_flag to support existing import jobs
   del_job_flag_ := NVL(UPPER(Intface_Detail_API.Get_Default_Value(intface_name_, 'DEL_JOB_FLAG')),del_flag_);
   del_list_flag_ := NVL(UPPER(Intface_Detail_API.Get_Default_Value(intface_name_, 'DEL_LIST_FLAG')),del_flag_);
   Trace_SYS.Message('Column Embrace '||column_embrace_);
   -- Open cursors before loop
   h_cur_ := DBMS_SQL.Open_Cursor;
   m_cur_ := DBMS_SQL.Open_Cursor;
   a_cur_ := DBMS_SQL.Open_Cursor;
   r_cur_ := DBMS_SQL.Open_Cursor;
   s_cur_ := DBMS_SQL.Open_Cursor;
   t_cur_ := DBMS_SQL.Open_Cursor;
   d_cur_ := DBMS_SQL.Open_Cursor;
   c_cur_ := DBMS_SQL.Open_Cursor;
   l_cur_ := DBMS_SQL.Open_Cursor;
   g_cur_ := DBMS_SQL.Open_Cursor;
   LOOP
      -- First LOOP on the file, and load it all
      -- into PL/SQL-table ins_rec_.
      IF ( intf_file_is_on_client_ ) THEN
         FETCH Intface_Job_Detail_API.Get_String INTO line_no_, file_string_, status_, line_objid_;
         EXIT WHEN  Intface_Job_Detail_API.Get_String%NOTFOUND;
      ELSIF ( intf_file_is_on_server_ ) THEN
         Intface_Job_Detail_API.Get_Next_Line(line_no_, file_string_, end_of_file_);
         EXIT WHEN end_of_file_;
      END IF;
      -- Check if column embrace exists
      IF ( SUBSTR(file_string_,1,1) = NVL(column_embrace_,'x$x$') ) THEN
         file_string_ := RTRIM(LTRIM(file_string_, column_embrace_),column_embrace_);
      END IF;
      -- Remove leading comments for Replication jobs
      IF ( SUBSTR(file_string_,1,2) = '--') THEN
        file_string_ := SUBSTR(file_string_,3,LENGTH(file_string_)-2);
      END IF;
      --
      EXIT WHEN SUBSTR(file_string_,1,13) = 'INTFENDIMPORT';
      IF ( SUBSTR(file_string_,1,9) IN ('INTFHINTF','INTFDINTF','INTFMINTF','INTFAINTF','INTFRINTF',
                                        'INTFSINTF','INTFTINTF','INTFCCONV','INTFLCONV','INTFGGROU') ) THEN
         -- New attr-string
         rowtype_ := SUBSTR(file_string_,1,5);
         IF ( attr_ IS NOT NULL ) THEN
            attr_count_ := attr_count_ + 1;
            -- Execute insert for previous row before starting on this
            --
            import_rec_.attr(attr_count_)         := attr_;
            import_rec_.table_name(attr_count_)   := table_name_;
            import_rec_.key_value(attr_count_)    := old_key_value_;
            import_rec_.master_table(attr_count_) := master_table_;
            import_rec_.rowtyp(attr_count_)       := old_rowtype_;
            Client_SYS.Clear_Attr(attr_);
         END IF;
         attr_    := SUBSTR(file_string_,6,LENGTH(file_string_)-5);
         IF ( NVL(old_rowtype_,'**') != rowtype_ ) THEN
            -- Find table to insert into
            IF ( rowtype_ = 'INTFH' ) THEN
               table_name_ := header_table_;
               key_column_ := 'INTFACE_NAME';
               master_table_ := 'INTFACE_HEADER_TAB';
            ELSIF ( rowtype_ = 'INTFD' ) THEN
               table_name_ := detail_table_;
               key_column_ := 'INTFACE_NAME';
               master_table_ := 'INTFACE_HEADER_TAB';
            ELSIF ( rowtype_ = 'INTFM' ) THEN
               table_name_ := method_table_;
               key_column_ := 'INTFACE_NAME';
               master_table_ := 'INTFACE_HEADER_TAB';
            ELSIF ( rowtype_ = 'INTFA' ) THEN
               table_name_ := method_attr_table_;
               key_column_ := 'INTFACE_NAME';
               master_table_ := 'INTFACE_HEADER_TAB';
            ELSIF ( rowtype_ = 'INTFS' ) THEN
               table_name_ := repl_struct_table_;
               key_column_ := 'INTFACE_NAME';
               master_table_ := 'INTFACE_HEADER_TAB';
            ELSIF ( rowtype_ = 'INTFT' ) THEN
               table_name_ := repl_str_cols_table_;
               key_column_ := 'INTFACE_NAME';
               master_table_ := 'INTFACE_HEADER_TAB';
            ELSIF ( rowtype_ = 'INTFR' ) THEN
               table_name_ := rules_table_;
               key_column_ := 'INTFACE_NAME';
               master_table_ := 'INTFACE_HEADER_TAB';
            ELSIF ( rowtype_ = 'INTFC' ) THEN
               table_name_ := conv_cols_table_;
               key_column_ := 'CONV_LIST_ID';
               master_table_ := 'INTFACE_CONV_LIST_TAB';
            ELSIF ( rowtype_ = 'INTFL' ) THEN
               table_name_ := conv_list_table_;
               key_column_ := 'CONV_LIST_ID';
               master_table_ := 'INTFACE_CONV_LIST_TAB';
            ELSIF ( rowtype_ = 'INTFG' ) THEN
               table_name_ := group_table_;
               key_column_ := 'GROUP_ID';
               master_table_ := 'INTFACE_GROUP_TAB';
            END IF;
         END IF;
         old_rowtype_ := rowtype_;
         old_key_value_ := key_value_;
      ELSE
         attr_ := attr_||file_string_;
      END IF;
   END LOOP;
   IF ( attr_ IS NOT NULL ) THEN
      -- IF last record exeeds one line on input file,
      -- insert it in PL-table now
      attr_count_ := attr_count_ + 1;
      import_rec_.attr(attr_count_)         := attr_;
      import_rec_.table_name(attr_count_)   := table_name_;
      import_rec_.key_value(attr_count_)    := old_key_value_;
      import_rec_.master_table(attr_count_) := master_table_;
      import_rec_.rowtyp(attr_count_)       := old_rowtype_;
      Client_SYS.Clear_Attr(attr_);
   END IF;
   rowtype_ :=  NULL;
   -- First loop on pl/table to restore special characters
   FOR i IN 1..attr_count_ LOOP
      -- Restore Quotation mark
      import_rec_.attr(i) := REPLACE(import_rec_.attr(i),replace_quot_,quot_);
      -- Restore Ampersand
      import_rec_.attr(i) := REPLACE(import_rec_.attr(i),replace_amp_,amp_);
      -- Restore newlines
      import_rec_.attr(i) := REPLACE(REPLACE(import_rec_.attr(i),replace_lf_,lf_),replace_cr_,cr_);
      -- Restore standard record- and field-separators
      import_rec_.attr(i) := REPLACE(REPLACE( import_rec_.attr(i), repl_recsep_, record_separator_), repl_fieldsep_, field_separator_);
      -- Restore dummy record- and field-separators
      import_rec_.attr(i) := REPLACE(REPLACE( import_rec_.attr(i), repl_dummy_recsep_, Intface_Method_List_API.replace_recsep_), repl_dummy_fieldsep_, Intface_Method_List_API.replace_fieldsep_);
      -- Restore dummy record- and field-separators
      -- v301 Comment: We keep this REPLACE to make it possible
      -- to import files from v300 of Intface
      import_rec_.attr(i) := REPLACE(REPLACE( import_rec_.attr(i), repl_dummy_recsep_, Intface_Method_List_API.replace_recsep_), repl_dummy_fieldsep_, Intface_Method_List_API.replace_fieldsep_);
   END LOOP;
   -- Second loop on pl/table to delete
   FOR i IN 1..attr_count_ LOOP
      rowtype_ := import_rec_.rowtyp(i);
      attr_ := import_rec_.attr(i);
      -- Delete relevant data, build info-strings
      IF ( rowtype_ = 'INTFH' ) THEN
         key_value_ := Client_SYS.Get_Item_Value('INTFACE_NAME', attr_);
         intface_count_ := intface_count_ + 1;
         BEGIN
            Intface_Header_API.Exist(key_value_);
            IF ( del_job_flag_ = 'Y' ) THEN
               DELETE FROM intface_header_tab where intface_name = key_value_;
               DELETE FROM intface_detail_tab where intface_name = key_value_;
               DELETE FROM intface_rules_tab where intface_name = key_value_;
               DELETE FROM intface_method_list_tab where intface_name = key_value_;
               DELETE FROM intface_method_list_attrib_tab where intface_name = key_value_;
               DELETE FROM intface_repl_structure_tab where intface_name = key_value_;
               DELETE FROM intface_repl_struct_cols_tab where intface_name = key_value_;
               replaced_intfaces_ := replaced_intfaces_||'   '||key_value_||crlf_;
               Intface_Method_List_API.Drop_All_Dynamic_Proc(key_value_);
            ELSE
               keep_intfaces_ := keep_intfaces_||'   '||key_value_||crlf_;
            END IF;
         EXCEPTION
            WHEN OTHERS THEN
               inserted_intfaces_ := inserted_intfaces_||'   '||key_value_||crlf_;
         END;
      ELSIF ( rowtype_ = 'INTFL' ) THEN
         key_value_ := Client_SYS.Get_Item_Value('CONV_LIST_ID', attr_);
         list_count_ := list_count_ + 1;
         BEGIN
            Intface_Conv_List_API.Exist(key_value_);
            IF ( del_list_flag_ = 'Y' ) THEN
               DELETE FROM intface_conv_list_cols_tab where conv_list_id = key_value_;
               DELETE FROM intface_conv_list_tab where conv_list_id = key_value_;
               replaced_lists_ := replaced_lists_||'   '||key_value_||crlf_;
            ELSE
               keep_lists_ := keep_lists_||'   '||key_value_||crlf_;
            END IF;
         EXCEPTION
            WHEN OTHERS THEN
               inserted_lists_ := inserted_lists_||'   '||key_value_||crlf_;
         END;
      ELSIF ( rowtype_ = 'INTFG' ) THEN
         key_value_ := Client_SYS.Get_Item_Value('GROUP_ID', attr_);
         group_count_ := group_count_ + 1;
         BEGIN
            Intface_Group_API.Exist(key_value_);
            IF ( del_job_flag_ = 'Y' ) THEN
               DELETE FROM intface_group_tab where group_id = key_value_;
               replaced_groups_ := replaced_groups_||'   '||key_value_||crlf_;
            ELSE
               keep_groups_ := keep_groups_||'   '||key_value_||crlf_;
            END IF;
         EXCEPTION
            WHEN OTHERS THEN
               inserted_groups_ := inserted_groups_||'   '||key_value_||crlf_;
         END;
      END IF;
   END LOOP;
   -- Third loop on pl/table to mark rows that
   -- should not be inserted (Exist-check OK but DEL_FLAG=N)
   key_value_ := NULL;
   FOR i IN 1..attr_count_ LOOP
      attr_ := import_rec_.attr(i);
      rowtype_ := import_rec_.rowtyp(i);
      key_value_ := import_rec_.key_value(i);
      IF (  rowtype_ IN ( 'INTFM', 'INTFA', 'INTFD', 'INTFR', 'INTFS', 'INTFT','INTFH' ) ) THEN
         key_value_ := Client_SYS.Get_Item_Value('INTFACE_NAME', attr_);
         IF ( INSTR(keep_intfaces_,'   '||key_value_) != 0 ) THEN
            import_rec_.rowtyp(i) := 'IGNORE'; -- Will not be processed in next LOOP
         END IF;
      ELSIF (  rowtype_ IN( 'INTFC', 'INTFL' ) ) THEN
         key_value_ := Client_SYS.Get_Item_Value('CONV_LIST_ID', attr_);
         IF ( INSTR(keep_lists_,'   '||key_value_) != 0 ) THEN
            import_rec_.rowtyp(i) := 'IGNORE'; -- Will not be processed in next LOOP
         END IF;
      ELSIF (  rowtype_ = 'INTFG'  ) THEN
         key_value_ := Client_SYS.Get_Item_Value('GROUP_ID', attr_);
         IF ( INSTR(keep_groups_,'   '||key_value_) != 0 ) THEN
            import_rec_.rowtyp(i) := 'IGNORE'; -- Will not be processed in next LOOP
         END IF;
      END IF;
   END LOOP;
   -- Fourth loop on pl/table to do insert
   -- Build and parse statements for insert
   FOR i IN 1..attr_count_ LOOP
      rowtype_ := 'xx';
      rowtype_ := import_rec_.rowtyp(i);
      table_name_ := import_rec_.table_name(i);
      attr_ := import_rec_.attr(i);

      IF (  rowtype_ = 'INTFM' ) THEN
         BEGIN
            Local_Execute(m_stmt_, m_cur_, table_name_, attr_);
         EXCEPTION WHEN OTHERS THEN NULL;
         END;
      ELSIF (  rowtype_ = 'INTFA' ) THEN
         BEGIN
            Local_Execute(a_stmt_, a_cur_, table_name_, attr_);
         EXCEPTION WHEN OTHERS THEN NULL;
         END;
      ELSIF ( rowtype_ = 'INTFD' ) THEN
         BEGIN
            Local_Execute(d_stmt_, d_cur_, table_name_, attr_);
         EXCEPTION WHEN OTHERS THEN NULL;
         END;
      ELSIF ( rowtype_ = 'INTFR' ) THEN
         BEGIN
            Local_Execute(r_stmt_, r_cur_, table_name_, attr_);
         EXCEPTION WHEN OTHERS THEN NULL;
         END;
      ELSIF ( rowtype_ = 'INTFS' ) THEN
         BEGIN
            Local_Execute(s_stmt_, s_cur_, table_name_, attr_);
         EXCEPTION WHEN OTHERS THEN NULL;
         END;
      ELSIF ( rowtype_ = 'INTFT' ) THEN
         BEGIN
            Local_Execute(t_stmt_, t_cur_, table_name_, attr_);
         EXCEPTION WHEN OTHERS THEN NULL;
         END;
      ELSIF ( rowtype_ = 'INTFH' ) THEN
         BEGIN
            Local_Execute(h_stmt_, h_cur_, table_name_, attr_);
            user_intface_ := Client_SYS.Get_Item_Value('INTFACE_NAME', attr_);
            -- Make the job available for current user
            BEGIN
               INSERT INTO intface_pr_user_tab (identity, intface_name, rowversion )
               VALUES (userid_, user_intface_, sysdate);
            EXCEPTION WHEN OTHERS
               THEN NULL; -- May already exist
            END;
         EXCEPTION WHEN OTHERS THEN
            rejected_intfaces_ := rejected_intfaces_||'   '||Client_SYS.Get_Item_Value('INTFACE_NAME', attr_)||crlf_;
         END;
      ELSIF ( rowtype_ = 'INTFC' ) THEN
         BEGIN
            Local_Execute(c_stmt_, c_cur_, table_name_, attr_);
         EXCEPTION WHEN OTHERS THEN NULL;
         END;
      ELSIF ( rowtype_ = 'INTFL' ) THEN
         BEGIN
            Local_Execute(l_stmt_, l_cur_, table_name_, attr_);
         EXCEPTION WHEN OTHERS THEN
            rejected_lists_ := rejected_lists_||'   '||Client_SYS.Get_Item_Value('CONV_LIST_ID', attr_)||crlf_;
         END;
      ELSIF ( rowtype_ = 'INTFG' ) THEN
         BEGIN
            Local_Execute(g_stmt_, g_cur_, table_name_, attr_);
         EXCEPTION WHEN OTHERS THEN
            rejected_groups_ := rejected_groups_||'   '||Client_SYS.Get_Item_Value('GROUP_ID', attr_)||crlf_;
         END;
      END IF;
   END LOOP;
   Trace_SYS.Message('h_stmt_ '||h_stmt_);
   Trace_SYS.Message('m_stmt_ '||m_stmt_);
   Trace_SYS.Message('a_stmt_ '||a_stmt_);
   Trace_SYS.Message('r_stmt_ '||r_stmt_);
   Trace_SYS.Message('s_stmt_ '||s_stmt_);
   Trace_SYS.Message('t_stmt_ '||t_stmt_);
   Trace_SYS.Message('d_stmt_ '||d_stmt_);
   Trace_SYS.Message('c_stmt_ '||c_stmt_);
   Trace_SYS.Message('l_stmt_ '||l_stmt_);
   Trace_SYS.Message('g_stmt_ '||g_stmt_);
   -- Fifth loop on pl/table to do insert  of 'old' jobs
   -- into Intface_Method_List_Attrib
   FOR i IN 1..attr_count_ LOOP
      rowtype_ := 'xx';
      rowtype_ := import_rec_.rowtyp(i);
      attr_ := import_rec_.attr(i);
      IF (  rowtype_ = 'INTFH' ) THEN
         key_value_ := Client_SYS.Get_Item_Value('INTFACE_NAME', attr_);
         Build_Attrib_List(key_value_);
         IF ( Client_SYS.Get_Item_Value('PROCEDURE_NAME', attr_) = 'REPLICATION' ) THEN
            BEGIN
               Intface_Util_API.Generate_Trigger_(
               key_value_,
               Client_SYS.Get_Item_Value('TABLE_NAME', attr_),
               'FALSE', -- Enabled
               Client_SYS.Get_Item_Value('ON_INSERT', attr_),
               Client_SYS.Get_Item_Value('ON_UPDATE', attr_),
               Intface_Mode_API.Encode(Client_SYS.Get_Item_Value('REPLICATION_MODE',attr_)));
            EXCEPTION WHEN OTHERS THEN
               Trace_SYS.Message('Compile Trigger Error '||SQLERRM);
            END;
            IF ( import_text10_ IS NULL ) THEN
               import_text10_ :=  Language_SYS.Translate_Constant(lu_name_, 'IMPTXT10: Replications jobs that must be restarted :' , Fnd_Session_API.Get_Language);
            END IF;
            repl_jobs_restart_ := repl_jobs_restart_||'   '||key_value_||crlf_;
         END IF;
      END IF;
   END LOOP;
   -- Build info variables
   import_text1_ :=  Language_SYS.Translate_Constant(lu_name_, 'IMPTXT1: Imported new migration jobs : ', Fnd_Session_API.Get_Language);
   import_text7_ :=  Language_SYS.Translate_Constant(lu_name_, 'IMPTXT7: Imported and replaced migration jobs :' , Fnd_Session_API.Get_Language);
   import_text2_ :=  Language_SYS.Translate_Constant(lu_name_, 'IMPTXT2: Imported new groups : ', Fnd_Session_API.Get_Language);
   import_text8_ :=  Language_SYS.Translate_Constant(lu_name_, 'IMPTXT8: Imported and replaced groups :' , Fnd_Session_API.Get_Language);
   import_text3_ :=  Language_SYS.Translate_Constant(lu_name_, 'IMPTXT3: Imported conversion lists :' , Fnd_Session_API.Get_Language);
   import_text9_ :=  Language_SYS.Translate_Constant(lu_name_, 'IMPTXT9: Imported and replaced conv.lists :' , Fnd_Session_API.Get_Language);

   insert_info_  := Add_To_Info___(insert_info_, import_text1_, inserted_intfaces_);
   IF ( replaced_intfaces_ IS NOT NULL ) THEN
      insert_info_ := Add_To_Info___(insert_info_, import_text7_, replaced_intfaces_);
   END IF;
   IF ( inserted_groups_ IS NOT NULL ) THEN
      insert_info_ := Add_To_Info___(insert_info_, import_text2_, inserted_groups_);
   END IF;
   IF ( replaced_groups_ IS NOT NULL ) THEN
      insert_info_ := Add_To_Info___(insert_info_, import_text8_, replaced_groups_);
   END IF;
   IF ( inserted_lists_ IS NOT NULL ) THEN
      insert_info_ := Add_To_Info___(insert_info_, import_text3_, inserted_lists_);
   END IF;
   IF ( replaced_lists_ IS NOT NULL ) THEN
      insert_info_ := Add_To_Info___(insert_info_, import_text9_, replaced_lists_);
   END IF;
   insert_info_ := Add_To_Info___(insert_info_, import_text10_, LTRIM(repl_jobs_restart_,','));

   IF ( rejected_intfaces_ IS NOT NULL OR keep_intfaces_ IS NOT NULL ) THEN
      import_text4_ :=  Language_SYS.Translate_Constant(lu_name_, 'IMPTXT4: Migration Jobs NOT inserted :' , Fnd_Session_API.Get_Language);
      reject_info_  := Add_To_Info___(reject_info_, import_text4_, rejected_intfaces_||keep_intfaces_);
   END IF;
   IF ( rejected_groups_ IS NOT NULL OR keep_groups_ IS NOT NULL ) THEN
      import_text5_ :=  Language_SYS.Translate_Constant(lu_name_, 'IMPTXT5: Groups NOT inserted :' , Fnd_Session_API.Get_Language);
      reject_info_  := Add_To_Info___(reject_info_, import_text5_, rejected_groups_||keep_groups_);
   END IF;
   IF ( rejected_lists_ IS NOT NULL OR keep_lists_ IS NOT NULL ) THEN
      import_text6_ :=  Language_SYS.Translate_Constant(lu_name_, 'IMPTXT6: Conversion lists NOT inserted :' , Fnd_Session_API.Get_Language);
      reject_info_  := Add_To_Info___(reject_info_, import_text6_, rejected_lists_||keep_lists_);
   END IF;
   --
   IF ( LENGTH(insert_info_) + LENGTH(reject_info_) < 31999 ) THEN
      intface_detail_api.trace_long_msg(Add_To_Info___(insert_info_, reject_info_));
   ELSIF ( LENGTH(reject_info_) < 32000 ) THEN
      intface_detail_api.trace_long_msg ( reject_info_);
   END IF;
   --
   IF ( LENGTH(insert_info_) + LENGTH(reject_info_) < 1999 ) THEN
      info_ := Add_To_Info___(insert_info_, reject_info_);
   ELSIF ( reject_info_ IS NULL ) THEN
      info_ := SUBSTR(insert_info_,1,2000);
   ELSE
      info_ := SUBSTR(reject_info_,1,2000);
   END IF;
   --
   Local_Close(h_cur_);
   Local_Close(m_cur_);
   Local_Close(a_cur_);
   Local_Close(r_cur_);
   Local_Close(s_cur_);
   Local_Close(t_cur_);
   Local_Close(d_cur_);
   Local_Close(c_cur_);
   Local_Close(l_cur_);
   Local_Close(g_cur_);
   -- Update status in job detail
   IF ( intf_file_is_on_client_ ) THEN
      UPDATE intface_job_detail_tab
         SET status = '4', -- OK
             date_executed = sysdate,
             executed_by = Fnd_Session_API.Get_Fnd_User
      WHERE intface_name = intface_name_;
   END IF;
   App_Context_SYS.Set_Value(Intface_Job_Detail_API.intf_execution_ok_cid_,TRUE);
EXCEPTION
   WHEN OTHERS THEN
      Intface_Detail_API.Trace_Long_Msg (SQLERRM);
      Local_Close(h_cur_);
      Local_Close(m_cur_);
      Local_Close(a_cur_);
      Local_Close(r_cur_);
      Local_Close(s_cur_);
      Local_Close(t_cur_);
      Local_Close(d_cur_);
      Local_Close(c_cur_);
      Local_Close(l_cur_);
      Local_Close(g_cur_);
      Error_SYS.Record_General(lu_name_, 'IMPERR: Error importing :P1 - :P2 ', intface_name_, SQLERRM );
END Fndmig_Import;


PROCEDURE Build_Attrib_List (
   intface_name_ IN VARCHAR2 )
IS
   count_              NUMBER;
   flags_              VARCHAR2(4);
   on_new_             VARCHAR2(5);
   on_modify_          VARCHAR2(5);
   attr_seq_           NUMBER;
   ref_                VARCHAR2(2000);
   lookup_ref_         VARCHAR2(2000);
   lov_view_           VARCHAR2(2000);
   lu_prompt_          VARCHAR2(2000);
   iid_lu_             VARCHAR2(2000);
   prefixed_column_    VARCHAR2(2000);
   db_client_values_   VARCHAR2(2000);
   db_values_          VARCHAR2(2000);
   client_values_      VARCHAR2(2000);
   description_        VARCHAR2(2000);
   info_               VARCHAR2(2000);
   attr_               VARCHAR2(2000);
   ref_attr_           VARCHAR2(2000);
   fixed_value_        VARCHAR2(2000);
   source_owner_       VARCHAR2(30);
   view_name_          VARCHAR2(30);

   ptr_                NUMBER;
   name_               intface_detail_tab.column_name%TYPE;
   value_              VARCHAR2(2000);
   procedure_namne_    VARCHAR2(100);
   appowner_           VARCHAR2(30) := Fnd_Session_API.Get_App_Owner;

   CURSOR exist_attrib (intface_name_ VARCHAR2) IS
      SELECT COUNT(*)
      FROM   intface_method_list_attrib_tab
      WHERE  intface_name = intface_name_;

   CURSOR convert_attr (intface_name_ VARCHAR2) IS
      SELECT intface_name, execute_seq, view_name, convert_attr,
             DECODE(INSTR(UPPER(method_name),'MODIFY__'),'0', null, references) reference,
             DECODE(greatest(INSTR(UPPER(method_name),'NEW__'),1),
               INSTR(UPPER(method_name),'NEW__'),SUBSTR(method_name,1,INSTR(method_name,'.')-1),
                 DECODE(greatest(INSTR(UPPER(method_name),'MODIFY__'),1),
                   INSTR(UPPER(method_name),'MODIFY__'),SUBSTR(method_name,1,INSTR(method_name,'.')-1),
             method_name)) method_name,
             source_name, prefix_option, action
      FROM   intface_method_list_tab
      WHERE  intface_name = intface_name_
      ORDER BY execute_seq;

   CURSOR get_columns (view_name_    VARCHAR2,
                       source_name_  VARCHAR2,
                       source_owner_ VARCHAR2,
                       proc_namne_   VARCHAR2) IS
      SELECT c.column_name source_column, a.column_name column_name, b.comments
      FROM all_tab_columns c, user_col_comments b, intface_views_col_info a
      WHERE a.view_name = view_name_
      AND a.view_name  = b.table_name
      AND a.column_name = b.column_name
      -- Allow DB-columns,
      -- except for DataMigration LU
      -- This because we use an old FND template.
      -- Also exclude DB-columns for Replication
      AND    ((NVL(SUBSTR(Dictionary_SYS.Comment_Value_('FLAGS', b.comments), 1, 4),'A---') != 'A---')
           OR ( a.column_name like '%_DB' and SUBSTR(a.view_name,1,7) != 'INTFACE')
           OR ( a.column_name like '%_DB' and proc_namne_ != 'REPLICATION') )
      AND c.table_name (+) = source_name_
      AND c.owner (+) = source_owner_
      AND c.column_name (+) = a.column_name
      ORDER BY a.column_id;

BEGIN
   OPEN exist_attrib(intface_name_);
   FETCH exist_attrib INTO count_;
   CLOSE exist_attrib;
   IF ( count_ > 0 ) THEN
      RETURN;
   END IF;
   --
   BEGIN
      SELECT NVL(source_owner, appowner_)
      INTO   source_owner_
      FROM   intface_header_tab
      WHERE  intface_name = intface_name_;
   EXCEPTION
      WHEN no_data_found THEN
         RETURN;
   END;
   --
   procedure_namne_ := Intface_Header_API.Get_Procedure_Name(intface_name_);
   FOR method_rec IN convert_attr(intface_name_) LOOP
      attr_seq_ := 10;
      attr_ := method_rec.convert_attr;
      attr_ := REPLACE(REPLACE(attr_, Intface_Method_List_API.replace_recsep_, record_separator_), Intface_Method_List_API.replace_fieldsep_, field_separator_);
      ref_attr_ := method_rec.reference;
      ref_attr_ := REPLACE(REPLACE(ref_attr_, Intface_Method_List_API.replace_recsep_, record_separator_), Intface_Method_List_API.replace_fieldsep_, field_separator_);
      IF ( method_rec.prefix_option = '2' ) THEN
         view_name_ := RTRIM(method_rec.view_name,TO_CHAR(method_rec.execute_seq));
      ELSE
         view_name_ := method_rec.view_name;
      END IF;

      IF ( INSTR(method_rec.method_name,'.') = 0 ) THEN
         FOR attr_rec IN get_columns(view_name_,
                                     method_rec.source_name,
                                     source_owner_,
                                     procedure_namne_) LOOP

            ref_ := NULL;
            lookup_ref_ := NULL;
            lov_view_ := NULL;
            lu_prompt_ := NULL;
            iid_lu_ := NULL;
            prefixed_column_ := NULL;
            db_client_values_ := NULL;
            db_values_ := NULL;
            client_values_ := NULL;
            description_ := NULL;
            flags_ := NULL;

            flags_ := SUBSTR(Dictionary_SYS.Comment_Value_('FLAGS', attr_rec.comments), 1, 4);
            IF ( SUBSTR(flags_, 1, 1) IN ('P', 'K') ) THEN
               flags_ := SUBSTR(flags_, 1, 1);
               fixed_value_ := NVL(Client_SYS.Get_Item_Value(attr_rec.column_name, attr_),
                                   Client_SYS.Get_Item_Value(attr_rec.column_name, ref_attr_));
            ELSE
               flags_ := REPLACE(SUBSTR(flags_, 2, 3), '-', '');
               fixed_value_ := Client_SYS.Get_Item_Value(attr_rec.column_name, attr_);
            END IF;

            on_new_ := 'FALSE';
            on_modify_ := 'FALSE';
            IF flags_ IN ('P','K') OR flags_ LIKE '%I%' THEN
               on_new_ := 'TRUE';
            END IF;
            IF flags_ IN ('P','K') THEN
               on_modify_ := 'FALSE';
            ELSIF flags_ LIKE '%U%' THEN
               on_modify_ := 'TRUE';
            END IF;

            ref_ := Dictionary_SYS.Comment_Value_('REF', attr_rec.comments);
            
            IF ref_ IS NULL THEN
               ref_ := Dictionary_SYS.Comment_Value_('ENUMERATION', attr_rec.comments);
            END IF;
               
            IF ( ref_ IS NOT NULL ) THEN
               -- Remove parentheses and slashes ( f.ex. '/CASCADE')
               -- to extract LU-name only
               IF ( INSTR(ref_, '(') != 0 ) THEN
                  lookup_ref_ := SUBSTR(ref_, 1, INSTR(ref_, '(')-1);
               ELSE
                  lookup_ref_ := ref_;
               END IF;
               IF ( INSTR(lookup_ref_, '/') != 0 ) THEN
                  lookup_ref_ := SUBSTR(lookup_ref_, 1, INSTR(lookup_ref_, '/')-1);
               END IF;
               lov_view_ := dictionary_SYS.Get_Base_View(lookup_ref_);
               IF ( lov_view_ IS NOT NULL ) THEN
                  lu_prompt_ := NVL(Language_SYS.Translate_Lu_Prompt_(lookup_ref_), lookup_ref_);
               END IF;
            END IF;            
            BEGIN
               iid_lu_ := dictionary_SYS.clientnametodbname_(lookup_ref_);
            EXCEPTION
               WHEN OTHERS THEN
                  iid_lu_ := NULL;
            END;   
            IF ( iid_lu_ IS NOT NULL ) THEN
               -- Get Db/Client-values for this LU
               prefixed_column_ := view_name_ || '.' || attr_rec.column_name;
               Intface_Detail_API.Enum_Db_Client_Values(
                  info_,
                  db_client_values_,
                  db_values_,
                  client_values_,
                  prefixed_column_,
                  iid_lu_,
                  lookup_ref_);
            ELSIF ( attr_rec.column_name like '%_DB' ) THEN
               -- Get Db/Client-values also for DB-columns
               prefixed_column_ := view_name_ || '.' || SUBSTR(attr_rec.column_name,1,LENGTH(attr_rec.column_name)-3);
               Intface_Detail_API.Enum_Db_Client_Values(
                  info_,
                  db_client_values_,
                  db_values_,
                  client_values_,
                  prefixed_column_);
               on_new_ := 'TRUE';
               on_modify_ := 'TRUE';
               flags_ := '-';
            END IF;
            description_ := Dictionary_SYS.Comment_Value_('PROMPT', attr_rec.comments);

            INSERT INTO Intface_Method_List_Attrib_Tab (
               INTFACE_NAME,EXECUTE_SEQ,COLUMN_SEQUENCE, COLUMN_NAME,
               FLAGS,ON_NEW,ON_MODIFY,FIXED_VALUE,LU_REFERENCE,
               IID_VALUES, DESCRIPTION, ROWVERSION)
            VALUES (intface_name_, method_rec.execute_seq, attr_seq_, attr_rec.column_name,
               flags_, on_new_, on_modify_, fixed_value_, lookup_ref_,
               db_client_values_, NVL(description_, attr_rec.column_name), SYSDATE);

            attr_seq_ := attr_seq_ + 10;
         END LOOP;
      ELSIF ( attr_ IS NOT NULL ) THEN
         ptr_ := NULL;
         WHILE (Client_SYS.Get_Next_From_Attr(attr_, ptr_, name_, value_)) LOOP
            INSERT INTO Intface_Method_List_Attrib_Tab (
                   INTFACE_NAME,EXECUTE_SEQ,COLUMN_SEQUENCE,COLUMN_NAME, FLAGS,
                       DESCRIPTION, ON_NEW, ON_MODIFY, FIXED_VALUE, ROWVERSION)
            VALUES (intface_name_,method_rec.execute_seq, attr_seq_ , name_ , 'IU',
                       name_ ,'TRUE','TRUE' , value_, SYSDATE);
            attr_seq_ := attr_seq_ + 10;
         END LOOP;
      END IF;
   END LOOP;
END Build_Attrib_List;


PROCEDURE Sync_Details (
   info_         IN OUT VARCHAR2,
   intface_name_ IN     VARCHAR2 )
IS
   TYPE varchar_tabtype IS
      TABLE OF VARCHAR2(2000)
      INDEX BY BINARY_INTEGER;
   TYPE head_columns IS RECORD (
      column_name    varchar_tabtype,
      description    varchar_tabtype);
   h_rec_         head_columns;
   --
   file_head_     VARCHAR2(32000);
   col_name_      intface_detail_tab.column_name%TYPE;
   pos_           NUMBER := 0;
   end_of_file_   BOOLEAN := FALSE;
   status_        intface_job_detail_tab.status%TYPE;
   line_no_       intface_job_detail_tab.line_no%TYPE;
   line_objid_    rowid;
   rule_value_    intface_rules.rule_value%TYPE;
   ok_columns_    BOOLEAN := FALSE;
   col_pos_       NUMBER;
   col_sep_       intface_header_tab.column_separator%TYPE;

   -- Get first line; this must be column header
   CURSOR get_string IS
      SELECT line_no, file_string, status,  rowid
      FROM intface_job_detail_tab
      WHERE intface_name = intface_name_
      ORDER BY line_no;
BEGIN
   rule_value_ := info_;
   info_ := null;
   col_sep_ := Intface_Format_Char_API.Get_Char(Intface_Header_API.Get_Column_Separator(intface_name_));
   IF ( Intface_Direction_API.Encode(Intface_Procedures_API.Get_Direction(Intface_Header_API.Get_Procedure_Name(intface_name_))) = '1' ) THEN
      IF ( App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_file_is_on_server_cid_) ) THEN
         Intface_Detail_API.Open_File(intface_name_, 'R');
         Intface_Detail_API.Get_Next_Line( file_head_, end_of_file_);
         Intface_Detail_API.Close_Normal;
      ELSIF ( App_Context_SYS.Find_Boolean_Value(Intface_Job_Detail_API.intf_file_is_on_client_cid_) ) THEN
         OPEN  Get_String;
         FETCH Get_String INTO line_no_, file_head_, status_, line_objid_;
         CLOSE Get_String;
      END IF;
   ELSE
      info_ := Language_SYS.Translate_Constant(lu_name_,' WRONGDIR : Rule SYNCDETAILS can only be used when reading files ', Fnd_Session_API.Get_Language);
      RETURN;
   END IF;
   Trace_SYS.Message('SYNC>>>>>    File_head '||file_head_ );
   file_head_ := UPPER(file_head_)||col_sep_; -- Make sure we fetch last column
   LOOP
      IF pos_ = 0 THEN
         col_name_:= SUBSTR(file_head_,0,INSTR(file_head_,col_sep_,1,pos_+1)-1);
      ELSE
         col_name_:= SUBSTR(file_head_,INSTR(file_head_,col_sep_,1,pos_)+1,INSTR(file_head_,col_sep_,1,pos_+1) -
                 INSTR(file_head_,col_sep_,1,pos_)-1);
      END IF;
      EXIT WHEN col_name_ IS NULL;
      pos_ := pos_ + 1;
      Trace_SYS.Message('SYNC>>>>>    pos/col_name_ '||pos_||col_name_ );
      BEGIN
         Intface_Detail_API.Exist(intface_name_, col_name_);
         h_rec_.column_name(pos_) := col_name_;
         h_rec_.description(pos_) := col_name_;
         ok_columns_              := TRUE;
      EXCEPTION
         WHEN OTHERS THEN
            IF ( rule_value_ = 'MATCH' ) THEN
               info_ := Language_SYS.Translate_Constant(lu_name_,' WRONGCOL : Column :P1 does no exist in Job :P2 ', Fnd_Session_API.Get_Language, col_name_, intface_name_);
               RETURN;
            ELSE
               h_rec_.column_name(pos_) := 'DUMMY'||to_char(pos_);
               h_rec_.description(pos_) := SUBSTR(col_name_,1,100);
            END IF;
      END;
      Trace_SYS.Message(to_char(pos_)||' '||h_rec_.column_name(pos_)||' '||h_rec_.description(pos_));
   END LOOP;
   IF ( ok_columns_ ) THEN
      -- All columns are valid,
      -- first set pos equal zero.....
      Trace_SYS.Message('SYNC>>>>>    Update details' );
      UPDATE intface_detail_tab
      SET pos = 0
      WHERE intface_name = intface_name_;
      -- Delete dummies
      Trace_SYS.Message('SYNC>>>>>    Delete details' );
      BEGIN
         DELETE
         FROM intface_detail_tab
         WHERE intface_name = intface_name_
         AND column_name LIKE 'DUMMY%'
         AND length = 0 ;
      EXCEPTION
         WHEN OTHERS THEN NULL;
      END;
      --
      FOR i IN 1..pos_ LOOP
         Trace_SYS.Message('SYNC>>>>>    loop pos_'||i );
         col_pos_ := i * 10;
         IF ( h_rec_.column_name(i) = h_rec_.description(i) ) THEN
            -- ....then synchronize matching columns
            Trace_SYS.Message('SYNC>>>>>    UPDATE pos '||h_rec_.column_name(i) );
            UPDATE intface_detail_tab
            SET pos = col_pos_
            WHERE intface_name = intface_name_
            AND column_name = h_rec_.column_name(i);
         ELSE
            Trace_SYS.Message('SYNC>>>>>    INSERT pos '||h_rec_.column_name(i) );
            INSERT INTO intface_detail_tab (
               intface_name , column_name , description , data_type,
               pos , length, change_defaults, rowversion )
            VALUES (
               intface_name_ , h_rec_.column_name(i) , h_rec_.description(i) , 'VARCHAR2',
               col_pos_ , 0, '2', sysdate );
         END IF;
      END LOOP;
   ELSE
      info_ := Language_SYS.Translate_Constant(lu_name_,' NOCOLUMN : No columns from file exists in Job ', Fnd_Session_API.Get_Language );
   END IF;
      Trace_SYS.Message('SYNC>>>>>    Info '||info_ );
END Sync_Details;


PROCEDURE Make_Trigger_When (
   when_clause_ IN OUT VARCHAR2,
   criteria_    IN     VARCHAR2,
   value_       IN     VARCHAR2 )
IS
BEGIN
   when_clause_ := NULL;
   IF ( value_ IS NOT NULL ) THEN
      IF ( Intface_Replic_Criteria_API.Encode(criteria_) = '1' ) THEN
         when_clause_ := 'new.contract = ';
      ELSIF ( Intface_Replic_Criteria_API.Encode(criteria_) = '2' ) THEN
         when_clause_ := 'new.company = ';
      END IF;
      when_clause_ := when_clause_||quot_||value_||quot_;
   END IF;
END Make_Trigger_When;


PROCEDURE Get_Repl_Defaults (
   view_name_        IN  VARCHAR2,
   app_owner_        OUT VARCHAR2,
   table_name_       OUT VARCHAR2,
   repl_criteria_    OUT VARCHAR2,
   repl_criteria_db_ OUT VARCHAR2 )
IS
   company_exists_  BOOLEAN := FALSE;
   contract_exists_ BOOLEAN := FALSE;
   dummy_           NUMBER;

   CURSOR column_exist (table_name_ VARCHAR2, column_name_ VARCHAR2 ) IS
      SELECT 1
      FROM   user_tab_columns
      WHERE  table_name  = UPPER(table_name_)
      AND    column_name = UPPER(column_name_);
BEGIN
   IF ( view_name_ IS NOT NULL ) THEN
      table_name_ := UPPER(view_name_) || '_TAB';
      --app_owner_  := Fnd_Session_API.Get_App_Owner;
      OPEN column_exist (view_name_, 'COMPANY');
      FETCH column_exist INTO dummy_;
      IF column_exist%FOUND THEN
         company_exists_ := TRUE;
      END IF;
      CLOSE column_exist;
      OPEN column_exist (view_name_, 'CONTRACT');
      FETCH column_exist INTO dummy_;
      IF column_exist%FOUND THEN
         contract_exists_ := TRUE;
      END IF;
      CLOSE column_exist;
      IF    ( company_exists_ AND NOT contract_exists_ ) THEN
         repl_criteria_db_ := '2';
      ELSIF ( contract_exists_ AND NOT company_exists_ ) THEN
         repl_criteria_db_ := '1';
      END IF;
      repl_criteria_ := Intface_Replic_Criteria_API.Decode(repl_criteria_db_);
   END IF;
EXCEPTION
   WHEN others THEN
      dbms_output.put_line(sqlerrm);
END Get_Repl_Defaults;


@UncheckedAccess
FUNCTION Get_Intface_Source (
   intface_name_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   temp_ VARCHAR2(2000);
   CURSOR get_attr IS
      SELECT decode(file_location,'3', source_name, -- SourceMigration job
         -- File Migration
         decode(Intface_Direction_API.Encode(Intface_Procedures_API.Get_Direction(procedure_name)),
             -- File in
             '1', intface_path||
             -- Use backslash, slash or space ??
             decode(instr(intface_path,'/'),'0',
             decode(instr(intface_path,'\'),'0',' ','\'),'/')
             ||intface_file,
             -- File out
             '2', view_name, NULL ))  source_name
      FROM INTFACE_HEADER
      WHERE intface_name = intface_name_;
BEGIN
   OPEN get_attr;
   FETCH get_attr INTO temp_;
   CLOSE get_attr;
   RETURN temp_;
END Get_Intface_Source;   

PROCEDURE Check_Intface_No_File(
   file_location_  IN     VARCHAR2,
   direction_      IN     VARCHAR2 )
IS
BEGIN
   IF direction_ IN ('1', '2') THEN
     IF file_location_ NOT IN ('1', '2') THEN
        Error_Sys.Appl_General(lu_name_, 'NOFILE_ERROR: File Location ":P1" cannot be used for migration jobs with Direction set to ":P2" or ":P3".'
                                       , Intface_File_Location_API.Decode(Intface_File_Location_API.DB_NO_FILE)
                                       , Intface_Direction_API.Decode(Intface_Direction_API.DB_FILE_IN)
                                       , Intface_Direction_API.Decode(Intface_Direction_API.DB_FILE_OUT));
     END IF;
   END IF;
END Check_Intface_No_File;

