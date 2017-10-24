-----------------------------------------------------------------------------
--
--  Logical unit: IntfaceReplTriggersUtil
--  Component:    FNDMIG
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  040507  TRLY  Created
--                Bug #44483 - Replication of Object structures
--  100809  ChMu  Certified the assert safe for dynamic SQLs (Bug#84970)
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------

lf_      CONSTANT VARCHAR2(1)  := chr(10);
TYPE global_rec IS RECORD (
   repl_id_       intface_header_tab.intface_name%TYPE,
   repl_mode_     intface_header_tab.replication_mode%TYPE,
   struct_seq_    intface_repl_structure_tab.structure_seq%TYPE,
   pos_           intface_repl_structure_tab.pos%TYPE);
TYPE trigger_rec IS RECORD (
   trigger_table_  intface_repl_structure_tab.trigger_table%TYPE,
   trigger_when_   intface_repl_structure_tab.trigger_when%TYPE,
   trigger_insert_ intface_repl_structure_tab.on_insert%TYPE,
   trigger_update_ intface_repl_structure_tab.on_update%TYPE,
   master_seq_     intface_repl_structure_tab.structure_seq%TYPE);

-------------------- PRIVATE DECLARATIONS -----------------------------------


-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------

-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------

PROCEDURE Build_Trigger_Action__ (
   action_      IN OUT VARCHAR2,
   trigger_rec_ IN trigger_rec )
IS
   event_ VARCHAR2(2000);
BEGIN
   IF trigger_rec_.trigger_insert_ = 'TRUE' THEN
      event_ := 'INSERT';
   END IF;
   IF trigger_rec_.trigger_update_ = 'TRUE' THEN
      IF event_ IS NULL THEN
         event_ := 'UPDATE';
      ELSE
         event_ := 'INSERT OR UPDATE';
      END IF;
   END IF;
   action_ := 'AFTER '||event_||' ON '||trigger_rec_.trigger_table_||
              ' FOR EACH ROW '||lf_;
END Build_Trigger_Action__;


PROCEDURE Build_Trigger_When__ (
   when_        IN OUT VARCHAR2,
   trigger_rec_ IN trigger_rec )
IS
BEGIN
   IF ( trigger_rec_.trigger_when_ IS NOT NULL ) THEN
      when_ := 'WHEN ('||trigger_rec_.trigger_when_||')'||lf_;
   END IF;
END Build_Trigger_When__;


PROCEDURE Build_Trigger_Variables__ (
   variables_   IN OUT VARCHAR2)
IS
BEGIN
   variables_ :=  'DECLARE'||lf_||
                  '   log_seq_ intface_repl_out_log_tab.log_seq%TYPE;'||lf_||
                  '   trigger_type_ intface_repl_out_log_tab.trigger_type%TYPE;'||lf_||
                  '   key_attr_ intface_repl_out_log_tab.key_attr%TYPE;'||lf_;
END Build_Trigger_Variables__;


PROCEDURE Build_Trigger_Begin__ (
   begin_body_  IN OUT VARCHAR2 )
IS
   insert_ VARCHAR2(1) := 'I';
   update_ VARCHAR2(1) := 'U';
BEGIN
   begin_body_ := 'BEGIN '||lf_||
                  'SELECT Repl_log_Seq.NEXTVAL INTO log_seq_ FROM DUAL;'||lf_||
                  '   IF INSERTING THEN '||lf_||
                  '      trigger_type_ := '''||insert_||''';'||lf_||
                  '   ELSIF UPDATING THEN '||lf_||
                  '      trigger_type_ := '''||update_||''';'||lf_||
                  '   END IF;'||lf_;
END Build_Trigger_Begin__;


PROCEDURE Build_Trigger_Attr__ (
   build_attr_  IN OUT VARCHAR2,
   trigger_rec_ IN trigger_rec,
   global_rec_  IN global_rec )
IS
   CURSOR get_data IS
      SELECT a.column_name, a.parent_key_name
      FROM intface_repl_struct_cols_tab a,
           intface_repl_struct_cols_tab b
      WHERE a.intface_name = global_rec_.repl_id_
      AND a.structure_seq = global_rec_.struct_seq_
      AND b.intface_name = a.intface_name
      AND b.structure_seq = trigger_rec_.master_seq_
      AND b.column_name = a.parent_key_name
      AND b.parent_key_name IS NOT NULL ;
BEGIN
   build_attr_ := '   Client_SYS.Clear_Attr(key_attr_);'||lf_;
   FOR rec_ IN get_data LOOP
      build_attr_ := build_attr_||
         '   Client_SYS.Add_To_Attr('||''''||rec_.parent_key_name||''''||','||
         ' :new.'||rec_.column_name||','||'key_attr_);'||lf_;
   END LOOP;
END Build_Trigger_Attr__;


PROCEDURE Build_Trigger_End__ (
   end_body_    IN OUT VARCHAR2,
   global_rec_  IN global_rec )
IS
   start_pos_ VARCHAR2(10) := nvl(to_char(Intface_Repl_Structure_API.Show_Start_Point(global_rec_.repl_id_)),'NULL');
   local_body_ VARCHAR2(32000);
BEGIN
   IF( global_rec_.repl_mode_ = '2' ) THEN -- Automatic, execute procedure at once
      local_body_ := '   Client_SYS.Add_To_Attr('||''''||'REPL_ID'||''''||','||
                     ''''||global_rec_.repl_id_||''''||',key_attr_);'||lf_||
                     '   Client_SYS.Add_To_Attr('||''''||'TRIGGER_TYPE'||''''||','||
                     ' trigger_type_'||','||'key_attr_);'||lf_||
                     '   Transaction_SYS.Deferred_Call('||
                     ''''||'Intface_Repl_Maint_Util_API.Replic_Automatic_Batch'||''''||',key_attr_, '||
                     ' Intface_Header_API.Get_Description('||''''||global_rec_.repl_id_||''''||'));'||lf_;
   ELSE
      local_body_ := '   INSERT INTO intface_repl_out_log_tab ('||lf_||
                     '       log_seq, intface_name, structure_seq, '||lf_||
                     '       pos, start_pos, key_attr, '||lf_||
                     '       trigger_type, log_date, rowversion )'||lf_||
                     '   VALUES (log_seq_,'||''''|| global_rec_.repl_id_||''''||','|| global_rec_.struct_seq_||','||lf_||
                     '       '||global_rec_.pos_||','||start_pos_||', key_attr_,'||lf_||
                     '       trigger_type_, sysdate, sysdate );'||lf_;
   END IF;
   end_body_ := local_body_||end_body_;

END Build_Trigger_End__;


-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------

FUNCTION Trigger_Exists (
   trigger_name_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   status_ VARCHAR2(5) := 'FALSE';
   --
   CURSOR get_trigger IS
      SELECT 'TRUE' status
      FROM user_triggers
      WHERE trigger_name = trigger_name_;
BEGIN
   FOR rec_ IN get_trigger LOOP
      status_ := rec_.status;
   END LOOP;
   RETURN status_;
END Trigger_Exists;


PROCEDURE Drop_Trigger (
   trigger_name_ IN VARCHAR2 )
IS
   err_msg_ VARCHAR2(2000);
   stmt_    VARCHAR2(2000);
BEGIN
   stmt_ := 'DROP TRIGGER '||trigger_name_;
   Assert_Sys.Assert_Is_Trigger(trigger_name_);
   BEGIN
      --safe due to check Assert_Sys.Assert_Is_Trigger 
      @ApproveDynamicStatement(2010-08-09,chmulk)
      EXECUTE IMMEDIATE stmt_;
   EXCEPTION
      WHEN OTHERS THEN
         err_msg_ := replace(SQLERRM,'ORA-','');
         Error_SYS.Record_General( lu_name_ , 'DROPERR: Error dropping trigger :P1 - :P2 ', trigger_name_,  err_msg_ );
   END ;
END Drop_Trigger;


FUNCTION Build_Trigger (
   intface_name_  IN VARCHAR2,
   structure_seq_ IN NUMBER ) RETURN VARCHAR2
IS
   trig_name_  VARCHAR2(200) := Get_Trigger_Name(intface_name_, structure_seq_);
   stmt_       VARCHAR2(32000) := 'CREATE OR REPLACE TRIGGER '||trig_name_||lf_;
   action_     VARCHAR2(32000);
   when_       VARCHAR2(32000);
   variables_  VARCHAR2(32000);
   begin_body_ VARCHAR2(32000);
   build_attr_ VARCHAR2(32000);
   end_body_   VARCHAR2(32000) := 'END '||trig_name_||';'||lf_;

   CURSOR get_data IS
      SELECT pos, trigger_table, trigger_when , on_insert, on_update
      FROM intface_repl_structure_tab
      WHERE intface_name = intface_name_
      AND structure_seq = structure_seq_
      AND trigger_table IS NOT NULL
      AND INSTR(on_insert||on_update,'TRUE') != 0; -- One of them must be checked
      
   global_rec_  global_rec;
   trigger_rec_ trigger_rec;
BEGIN
   FOR rec_ IN get_data LOOP
      global_rec_.repl_id_    := intface_name_;
      global_rec_.repl_mode_  := Intface_Mode_API.Encode(
                                 Intface_Header_API.Get_Replication_mode(intface_name_));
      global_rec_.struct_seq_ := structure_seq_;
      global_rec_.pos_        := rec_.pos;
      
      trigger_rec_.trigger_table_  := rec_.trigger_table;
      trigger_rec_.trigger_when_   := rec_.trigger_when;
      trigger_rec_.trigger_insert_ := rec_.on_insert;
      trigger_rec_.trigger_update_ := rec_.on_update;
      trigger_rec_.master_seq_     := Intface_Repl_Structure_API.Get_Master_Seq(intface_name_);
      --
      Build_Trigger_Action__(action_, trigger_rec_);
      Build_Trigger_When__(when_, trigger_rec_);
      Build_Trigger_Variables__(variables_);
      Build_Trigger_Begin__(begin_body_);
      Build_Trigger_Attr__(build_attr_ , trigger_rec_, global_rec_);
      Build_Trigger_End__(end_body_, global_rec_);
   END LOOP;
   stmt_ := stmt_||action_||
                   when_||
                   variables_||
                   begin_body_||
                   build_attr_||
                   end_body_;
   RETURN stmt_;
END Build_Trigger;


PROCEDURE Switch_Trigger (
   trigger_name_ IN VARCHAR2,
   switch_       IN VARCHAR2 )
IS
   stmt_    VARCHAR2(2000);
   status_  VARCHAR2(10);
   err_msg_ VARCHAR2(2000);
BEGIN
   IF ( switch_ = 'ON' ) THEN
      status_ := 'ENABLE';
   ELSE
      status_ := 'DISABLE';
   END IF;
   Assert_Sys.Assert_Is_Trigger(trigger_name_);
   stmt_ := 'ALTER TRIGGER '||trigger_name_||' '||status_;
   BEGIN
      --safe due to check Assert_Sys.Assert_Is_Trigger 
      @ApproveDynamicStatement(2010-08-09,chmulk)
      EXECUTE IMMEDIATE stmt_;
   EXCEPTION
      WHEN OTHERS THEN
         err_msg_ := replace(SQLERRM,'ORA-','');
         Error_SYS.Record_General( lu_name_ , 'ALTERR: Error altering trigger :P1 - :P2 ', trigger_name_,  err_msg_ );
   END ;
END Switch_Trigger;


PROCEDURE Switch_All_Triggers (
   intface_name_ IN VARCHAR2,
   switch_       IN VARCHAR2 )
IS
   CURSOR get_triggers IS
      SELECT trigger_name
      FROM user_triggers
      WHERE trigger_name like 'RPL_'||intface_name_||'_T%';
BEGIN
   FOR rec_ IN get_triggers LOOP
      Switch_Trigger(rec_.trigger_name, switch_);
   END LOOP;
END Switch_All_Triggers;


FUNCTION Trigger_Is_Enabled (
   intface_name_  IN VARCHAR2,
   structure_seq_ IN NUMBER ) RETURN VARCHAR2
IS
   status_ VARCHAR2(5) := 'FALSE';
   trigger_name_ VARCHAR2(100);
   --
   CURSOR get_triggers IS
      SELECT 'TRUE' status
      FROM user_triggers
      WHERE trigger_name = trigger_name_
      AND status = 'ENABLED';
BEGIN
   trigger_name_ := Get_Trigger_Name(intface_name_,structure_seq_);
   FOR rec_ IN get_triggers LOOP
      status_ := rec_.status;
   END LOOP;
   RETURN status_;
END Trigger_Is_Enabled;


PROCEDURE Compile_Triggers (
   intface_name_ IN VARCHAR2 )
IS
   err_msg_       VARCHAR2(2000);
   trigger_name_  VARCHAR2(50);
   stmt_          VARCHAR2(32000);
   structure_seq_ NUMBER;
   CURSOR get_data IS
      SELECT structure_seq, trigger_table,
             Get_Trigger_Name(intface_name_,structure_seq) trigger_name,
             decode(INSTR(on_insert||on_update,'TRUE'),'0','FALSE','TRUE') make_trigger
      FROM intface_repl_structure_tab
      WHERE intface_name = intface_name_;
BEGIN
   FOR rec_ IN get_data LOOP
      structure_seq_ := rec_.structure_seq;
      trigger_name_ := rec_.trigger_name;
      -- Drop
      IF ( Trigger_Exists(trigger_name_) = 'TRUE'  ) THEN
         Drop_Trigger(trigger_name_);
      END IF;
      IF ( rec_.make_trigger = 'TRUE' AND rec_.trigger_table IS NOT NULL ) THEN
         stmt_ := Build_Trigger(intface_name_, structure_seq_);
         BEGIN
            -- Safe since executed using stored data
            @ApproveDynamicStatement(2010-08-09,chmulk)
            EXECUTE IMMEDIATE stmt_;
         EXCEPTION
            WHEN OTHERS THEN
               err_msg_ := replace(SQLERRM,'ORA-','ORA');
               Error_SYS.Record_General( lu_name_ , 'COMPERR: Error occured for trigger :P1 ' , trigger_name_||' - '||err_msg_ );
         END ;
         Switch_Trigger(rec_.trigger_name , 'OFF');
      END IF;
   END LOOP;
   IF ( stmt_ IS NULL ) THEN
      Error_SYS.Record_General( lu_name_, 'NODEF: You must enter a TableName and check OnInsert or OnUpdate of at least one structure item');
   END IF;
END Compile_Triggers;


PROCEDURE Disable_Triggers (
   intface_name_ IN VARCHAR2 )
IS
BEGIN
   Switch_All_Triggers(intface_name_,'OFF');
END Disable_Triggers;


PROCEDURE Enable_Triggers (
   intface_name_ IN VARCHAR2 )
IS
BEGIN
   Switch_All_Triggers(intface_name_,'ON');
END Enable_Triggers;

@UncheckedAccess
FUNCTION Get_Status (
   trigger_name_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   status_ user_triggers.status%TYPE;
   --
   CURSOR get_trigger IS
      SELECT status
      FROM user_triggers
      WHERE trigger_name = trigger_name_;
BEGIN
   FOR rec_ IN get_trigger LOOP
      status_ := rec_.status;
   END LOOP;
   RETURN status_;
END Get_Status;

@UncheckedAccess   
FUNCTION Get_Table_Name (
   trigger_name_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   table_name_ user_triggers.table_name%TYPE;
   --
   CURSOR get_table_name IS
      SELECT table_name
      FROM user_triggers
      WHERE trigger_name = trigger_name_;
BEGIN
   FOR rec_ IN get_table_name LOOP
      table_name_ := rec_.table_name;
   END LOOP;
   RETURN table_name_;
END Get_Table_Name;


FUNCTION Get_Trigger_Name (
   intface_name_  IN VARCHAR2,
   structure_seq_ IN VARCHAR2 ) RETURN VARCHAR2
IS
   trigger_name_ VARCHAR2(100);
BEGIN
   trigger_name_ := 'RPL_'||intface_name_||'_T'||structure_seq_;
   RETURN trigger_name_;
END Get_Trigger_Name;



