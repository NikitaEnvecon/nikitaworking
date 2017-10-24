-----------------------------------------------------------------------------
--
--  Logical unit: IntfaceReplStructure
--  Component:    FNDMIG
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  080924  JHMASE Bug #76776 - Validate INTFACE_NAME length for certain job types
--  061102  JHMASE Bug #61592 - Remove unnecessary references
--  060209  TRLYNO Bug #55643 - Change view-definitions from user_ to dba_
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
   Client_SYS.Add_to_Attr('START_POINT','FALSE',attr_);
   Client_SYS.Add_to_Attr('ELEMENT_TYPE', Intface_Repl_Elem_Type_API.Decode('ARRAY'), attr_);
END Prepare_Insert___;


@Override
PROCEDURE Insert___ (
   objid_      OUT    VARCHAR2,
   objversion_ OUT    VARCHAR2,
   newrec_     IN OUT INTFACE_REPL_STRUCTURE_TAB%ROWTYPE,
   attr_       IN OUT VARCHAR2 )
IS
   dummy_ NUMBER;
BEGIN
   super(objid_, objversion_, newrec_, attr_);
   -- Check for multiple start-points
   dummy_ := Show_Start_Point(newrec_.intface_name);
   --
   SELECT rowid
      INTO  objid_
      FROM  INTFACE_REPL_STRUCTURE_TAB
      WHERE intface_name = newrec_.intface_name
      AND   structure_seq = newrec_.structure_seq;
   IF ( newrec_.parent_seq IS NOT NULL ) THEN
      Re_Generate_Pos(newrec_.intface_name);
   END IF;
EXCEPTION
   WHEN dup_val_on_index THEN
      Error_SYS.Record_Exist(lu_name_);
END Insert___;


@Override
PROCEDURE Update___ (
   objid_      IN     VARCHAR2,
   oldrec_     IN     INTFACE_REPL_STRUCTURE_TAB%ROWTYPE,
   newrec_     IN OUT INTFACE_REPL_STRUCTURE_TAB%ROWTYPE,
   attr_       IN OUT VARCHAR2,
   objversion_ IN OUT VARCHAR2,
   by_keys_    IN     BOOLEAN DEFAULT FALSE )
IS
   dummy_ NUMBER;
BEGIN
   super(objid_, oldrec_, newrec_, attr_, objversion_, by_keys_);
   -- Check for multiple start-points
   dummy_ := Show_Start_Point(newrec_.intface_name);
   --
   IF ( nvl(newrec_.parent_seq,-100) != nvl(oldrec_.parent_seq,-200) ) THEN
      Re_Generate_Pos(newrec_.intface_name);
   END IF;
EXCEPTION
   WHEN dup_val_on_index THEN
      Error_SYS.Record_Exist(lu_name_);
END Update___;


@Override
PROCEDURE Delete___ (
   objid_  IN VARCHAR2,
   remrec_ IN INTFACE_REPL_STRUCTURE_TAB%ROWTYPE )
IS
   trigger_name_ VARCHAR2(100);
BEGIN
   super(objid_, remrec_);
   trigger_name_ := Intface_Repl_Triggers_Util_API.Get_Trigger_Name(remrec_.intface_name ,remrec_.structure_seq );
   IF ( Intface_Repl_Triggers_Util_API.Trigger_Exists( trigger_name_ ) = 'TRUE' ) THEN
      Intface_Repl_Triggers_Util_API.Drop_Trigger( trigger_name_);
   END IF;
END Delete___;


@Override
PROCEDURE Check_Insert___ (
   newrec_ IN OUT intface_repl_structure_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS
BEGIN
   IF (newrec_.structure_seq > 99) THEN
      Error_SYS.Item_Format(lu_name_, 'STRUCTURE_SEQ', newrec_.structure_seq, 'VALUEERR: :P1 = :P2, value may not be larger then 99','STRUCTURE_SEQ', newrec_.structure_seq);
   END IF; 
   IF ( newrec_.parent_seq IS NOT NULL ) THEN 
      IF ( newrec_.parent_seq = newrec_.structure_seq ) THEN
         Error_SYS.Record_General(lu_name_,'ERRSEQ: Parent Sequence cannot equal Seq ');
      ELSIF ( Intface_Repl_Structure_API.Get_View_Name( newrec_.intface_name, newrec_.parent_seq) IS NULL  ) THEN 
         Error_SYS.Record_General(lu_name_,'NOSEQ: Cannot use this Parent Sequence. No lines with Seq :P1 ',newrec_.parent_seq );
      END IF;
   END IF;
   IF ( newrec_.pos IS NULL ) THEN
      newrec_.pos := newrec_.structure_seq;
   END IF;
   IF ( newrec_.element_type IS NULL ) THEN
      newrec_.element_type := Intface_Repl_Elem_Type_API.Decode('ARRAY');
   END IF;
   --
   Intface_Repl_Maint_Util_API.Check_Update_Allowed(newrec_.intface_name);
   --
   super(newrec_, indrec_, attr_);
   --
   -- Insert columns in child table
   Intface_Repl_Struct_Cols_API.Insert_Default_Cols(newrec_.intface_name,newrec_.structure_seq,newrec_.view_name);
   --
END Check_Insert___;


@Override
PROCEDURE Check_Update___ (
   oldrec_ IN     intface_repl_structure_tab%ROWTYPE,
   newrec_ IN OUT intface_repl_structure_tab%ROWTYPE,
   indrec_ IN OUT Indicator_Rec,
   attr_   IN OUT VARCHAR2 )
IS
BEGIN
   --
   IF ( newrec_.parent_seq IS NOT NULL ) THEN 
      IF ( newrec_.parent_seq = newrec_.structure_seq ) THEN
         Error_SYS.Record_General(lu_name_,'ERRSEQ: Parent Sequence cannot equal Seq ');
      ELSIF ( Intface_Repl_Structure_API.Get_View_Name( newrec_.intface_name, newrec_.parent_seq) IS NULL  ) THEN 
         Error_SYS.Record_General(lu_name_,'NOSEQ: Cannot use this Parent Sequence. No lines with Seq :P1 ',newrec_.parent_seq );
      END IF;
   END IF;
   --
   Intface_Repl_Maint_Util_API.Check_Update_Allowed(newrec_.intface_name);
   --
   super(oldrec_, newrec_, indrec_, attr_);
END Check_Update___;


-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------

PROCEDURE Validate_Start_Point__ (
   intface_name_  IN VARCHAR2,
   structure_seq_ IN NUMBER )
IS
   CURSOR get_data IS
      SELECT structure_seq, on_insert, trigger_table
      FROM   intface_repl_structure a
      WHERE intface_name = intface_name_
      AND  INSTR(on_insert||on_update,'TRUE') != 0 -- One of them must be checked
      CONNECT BY PRIOR structure_seq = parent_seq
         AND intface_name = intface_name_
      START WITH parent_seq IS NULL
         AND intface_name = intface_name_;
BEGIN
   FOR rec_ IN get_data LOOP
trace_sys.field('Structure_Seq IN ', structure_seq_);
trace_sys.field('Structure_Seq LOOP ', rec_.structure_seq);
trace_sys.field('rec_.on_insert ', rec_.on_insert);
trace_sys.field('rec_.trigger_table ', rec_.trigger_table);
      EXIT WHEN rec_.structure_seq > structure_seq_;
      IF (rec_.on_insert = 'FALSE' OR rec_.trigger_table IS NULL ) THEN
         Error_SYS.Record_General(lu_name_, 'INSERR: All rows from Start Point and upwards must have column OnInsert checked and column TriggerTable defined ');
      END IF;      
   END LOOP;
END Validate_Start_Point__;


-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------

FUNCTION Get_Master_Seq (
   intface_name_ IN VARCHAR2 ) RETURN NUMBER
IS
   master_seq_ NUMBER;
   count_      NUMBER;
   --
   CURSOR get_data IS
      SELECT max(structure_seq),count(1)
      FROM intface_repl_structure_tab
      WHERE intface_name = intface_name_
      AND parent_seq IS NULL;
   --
   nonunique_master_ EXCEPTION;
BEGIN
   OPEN  get_data;
   FETCH get_data INTO master_seq_, count_;
   CLOSE get_data;
   IF ( nvl(count_,0) != 1 ) THEN
      RAISE nonunique_master_;
   END IF;
   RETURN master_seq_;
EXCEPTION
   WHEN nonunique_master_ THEN
      Error_SYS.Record_General(lu_name_, 'NONUNIQUE: No unique master defined for :P1. Only one item should have ParentSeq equal NULL ', intface_name_);
END Get_Master_Seq;


PROCEDURE Re_Generate_Pos (
   intface_name_ IN VARCHAR2 )
IS
   CURSOR get_data IS
      SELECT rownum * 10 pos, rowid
      FROM   intface_repl_structure a
      WHERE intface_name = intface_name_
      AND  INSTR(on_insert||on_update,'TRUE') != 0 -- One of them must be checked
      CONNECT BY PRIOR structure_seq = parent_seq
         AND intface_name = intface_name_
      START WITH parent_seq IS NULL
         AND intface_name = intface_name_;
BEGIN
   FOR rec_ IN get_data LOOP
      UPDATE intface_repl_structure_tab
      SET pos = rec_.pos
      WHERE rowid = rec_.rowid;
   END LOOP;
END Re_Generate_Pos;


FUNCTION Show_Start_Point (
   intface_name_ IN VARCHAR2 ) RETURN NUMBER
IS
   start_point_ NUMBER;
   count_       NUMBER;
   struct_seq_  NUMBER;
   --
   CURSOR get_data IS
      SELECT max(pos),count(1), max(structure_seq)
      FROM intface_repl_structure_tab
      WHERE intface_name = intface_name_
      AND start_point = 'TRUE';
   multiple_start_ EXCEPTION;
BEGIN
   OPEN  get_data;
   FETCH get_data INTO start_point_, count_, struct_seq_;
   CLOSE get_data;
   IF ( nvl(count_,0) > 1 ) THEN
      RAISE multiple_start_;
   ELSIF ( nvl(count_,0) = 1 ) THEN
      Validate_Start_Point__(intface_name_, struct_seq_);
   END IF;
   RETURN start_point_;
EXCEPTION
   WHEN multiple_start_ THEN
      Error_SYS.Record_General(lu_name_, 'MULTIPLESTART: You can only define one Start Point for a job ');
END Show_Start_Point;



