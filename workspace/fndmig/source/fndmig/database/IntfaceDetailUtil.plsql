-----------------------------------------------------------------------------
--
--  Logical unit: IntfaceDetailUtil
--  Component:    FNDMIG
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------

TYPE intfdet_col_tab_type IS
   TABLE OF VARCHAR2(30) INDEX BY BINARY_INTEGER;
TYPE intfdet_tab_type IS
   TABLE OF intface_detail_tab%ROWTYPE INDEX BY BINARY_INTEGER;

-------------------- PRIVATE DECLARATIONS -----------------------------------


-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------

-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------

-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------

@UncheckedAccess
FUNCTION Get_Sorted_Intface_Columns (
   intface_name_ IN VARCHAR2) RETURN intfdet_col_tab_type
IS
   CURSOR get_columns_sorted(intface_name_ IN VARCHAR2) IS
      SELECT column_name
        FROM intface_detail_tab
       WHERE intface_name = intface_name_
         AND (pos > 0 OR default_value IS NOT NULL)
    ORDER BY attr_seq;   
   columns_ intfdet_col_tab_type;
BEGIN
   OPEN get_columns_sorted(intface_name_);
   FETCH get_columns_sorted BULK COLLECT INTO columns_; 
   CLOSE get_columns_sorted;
   
   RETURN columns_;
END Get_Sorted_Intface_Columns;


@UncheckedAccess
FUNCTION Get_Intface_Details (
   intface_name_ IN VARCHAR2) RETURN intfdet_tab_type
IS
   separator_flag_ VARCHAR2(1);
   CURSOR get_details IS
      SELECT intface_name, column_name, data_type, pos, length,
             decimal_length, amount_factor, default_value,
             default_where, pad_char_left, pad_char_right, change_defaults,
             flags, conv_list_id
      FROM   intface_detail_tab
      WHERE intface_name    = intface_name_
      AND   (pos > 0 OR default_value IS NOT NULL)
      ORDER BY decode(separator_flag_,
                      '0', attr_seq,
                      '1', decode(pos,'0',999,pos), decode(default_value,null,2,1), column_name);
   
   intfdet_rec_ intfdet_tab_type;
   rec_nbr_ NUMBER := 0;
BEGIN
   
   IF (Intface_Header_API.Get_Column_Separator(intface_name_) IS NULL ) THEN
      separator_flag_ := '0';
   ELSE
      separator_flag_ := '1';
   END IF;
   
   FOR intface_detail_rec_ IN get_details LOOP
      rec_nbr_ := rec_nbr_ + 1;
      intfdet_rec_(rec_nbr_).intface_name := intface_detail_rec_.intface_name;
      intfdet_rec_(rec_nbr_).column_name := intface_detail_rec_.column_name;
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
   END LOOP;
   RETURN intfdet_rec_;
END Get_Intface_Details;


