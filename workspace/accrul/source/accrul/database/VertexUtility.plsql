-----------------------------------------------------------------------------
--
--  Logical unit: VertexUtility
--  Component:    ACCRUL
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
--  020127  BmEk    IID 10220. Created
--  050923  Iswalk  Added Get_Enterp_Jurisdiction_Code which does not rais an error when there is no matching code.
--  120614  Hecolk  Bug 102054, Modified methods Get_Jurisdiction_Code and Get_Enterp_Jurisdiction_Cod
--  140818  THPELK  PRFI-1294 LCS Merge(Bug 116065).
--  150430  THPELK  Bug 122338 - Corrected in Get_Jurisdiction_Code(). 
-----------------------------------------------------------------------------

layer Core;

-------------------- PUBLIC DECLARATIONS ------------------------------------


-------------------- PRIVATE DECLARATIONS -----------------------------------


-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------

-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------

-------------------- LU SPECIFIC PROTECTED METHODS --------------------------

-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------

PROCEDURE Calculate_Tax (
   attr_ IN OUT VARCHAR2 )
IS
   city_                 VARCHAR2(100);
   state_                VARCHAR2(100);
   zip_code_             VARCHAR2(100);
   county_               VARCHAR2(100);
   jurisdiction_code_    VARCHAR2(20);
   in_city_              VARCHAR2(5);
   identity_             VARCHAR2(20);
   company_              VARCHAR2(20);
   part_no_              VARCHAR2(25);
   taxable_amount_       NUMBER;
   stmt_                 VARCHAR2(32000);
   state_tax_amount_     NUMBER;
   county_tax_amount_    NUMBER;
   city_tax_amount_      NUMBER;
   district_tax_amount_  NUMBER;
   state_tax_percent_    NUMBER;
   county_tax_percent_   NUMBER;
   city_tax_percent_     NUMBER;
   district_tax_percent_ NUMBER;
BEGIN

   city_           := Client_SYS.Get_Item_Value('CITY', attr_);
   state_          := Client_SYS.Get_Item_Value('STATE', attr_);
   zip_code_       := Client_SYS.Get_Item_Value('ZIP_CODE', attr_);
   county_         := Client_SYS.Get_Item_Value('COUNTY', attr_);

   -- To ensure to get the latest jurisdiction code information
   Get_Jurisdiction_Code(jurisdiction_code_, city_, state_, zip_code_, county_);
   -- Bug 122338 - Removed code

   in_city_        := Client_SYS.Get_Item_Value('IN_CITY', attr_);
   identity_       := Client_SYS.Get_Item_Value('IDENTITY', attr_);
   company_        := Client_SYS.Get_Item_Value('COMPANY', attr_);
   part_no_        := Client_SYS.Get_Item_Value('PART_NO', attr_);
   taxable_amount_ := Client_SYS.Get_Item_Value_To_Number('TAXABLE_AMOUNT', attr_, lu_name_);

   IF (Database_SYS.Package_Exist('QSU')) THEN
      stmt_ := '
      DECLARE
         context_record_       QSU.tQSUContextRecord;
         invoice_record_in_    QSU.tQSUInvoiceRecord;
         invoice_record_out_   QSU.tQSUInvoiceRecord;
         line_item_record_     QSU.tQSULineItemRecord;
         line_item_table_in_   QSU.tQSULineItemTable;
         line_item_table_out_  QSU.tQSULineItemTable;
      BEGIN
         QSU.QSUInitializeInvoice(context_record_, invoice_record_in_, line_item_table_in_);
         invoice_record_in_.fJurisSTGeoCd      := to_number(:jurisdiction_code_);
         invoice_record_in_.fJurisSTInCi       := (:in_city_ = ''TRUE'');
         invoice_record_in_.fTDMCustCd         := :identity_;
         invoice_record_in_.fTDMCompCd         := :company_;
      
         line_item_record_.fTransType          := QSU.cQSUTransTypeSale;
         line_item_record_.fTDMProdCd          := :part_no_;
         line_item_record_.fTransExtendedAmt   := :taxable_amount_;
         line_item_record_.fTransQuantity      := 1;
         
         line_item_table_in_(1) := line_item_record_;
         QSU.QSUCalculateTaxes(context_record_, invoice_record_in_, line_item_table_in_,
            invoice_record_out_, line_item_table_out_, FALSE);

         :state_tax_amount_     := line_item_table_out_(1).fPriStTaxAmt;
         :county_tax_amount_    := line_item_table_out_(1).fPriCoTaxAmt + line_item_table_out_(1).fAddCoTaxAmt;
         :city_tax_amount_      := line_item_table_out_(1).fPriCiTaxAmt + line_item_table_out_(1).fAddCiTaxAmt;
         :district_tax_amount_  := line_item_table_out_(1).fPriDiTaxAmt + line_item_table_out_(1).fAddDiTaxAmt;

         :state_tax_percent_    := line_item_table_out_(1).fPriStRate;
         :county_tax_percent_   := line_item_table_out_(1).fPriCoRate + line_item_table_out_(1).fAddCoRate;
         :city_tax_percent_     := line_item_table_out_(1).fPriCiRate + line_item_table_out_(1).fAddCiRate;
         :district_tax_percent_ := line_item_table_out_(1).fPriDiRate + line_item_table_out_(1).fAddDiRate;
      END;
      ';
      @ApproveDynamicStatement(2005-11-11,shsalk)
      EXECUTE IMMEDIATE stmt_ USING IN  jurisdiction_code_,
                                    IN  in_city_,
                                    IN  identity_,
                                    IN  company_,
                                    IN  part_no_,
                                    IN  taxable_amount_,
                                    OUT state_tax_amount_,
                                    OUT county_tax_amount_,
                                    OUT city_tax_amount_,
                                    OUT district_tax_amount_,
                                    OUT state_tax_percent_,
                                    OUT county_tax_percent_,
                                    OUT city_tax_percent_,
                                    OUT district_tax_percent_; 
   END IF;

   Client_SYS.Clear_Attr(attr_);
   Client_SYS.Add_To_Attr('JURISDICTION_CODE', jurisdiction_code_, attr_);
   Client_SYS.Add_To_Attr('STATE_TAX_AMOUNT', state_tax_amount_, attr_);
   Client_SYS.Add_To_Attr('COUNTY_TAX_AMOUNT', county_tax_amount_, attr_);
   Client_SYS.Add_To_Attr('CITY_TAX_AMOUNT', city_tax_amount_, attr_);
   Client_SYS.Add_To_Attr('DISTRICT_TAX_AMOUNT', district_tax_amount_, attr_);
   Client_SYS.Add_To_Attr('STATE_TAX_PERCENT', state_tax_percent_, attr_);
   Client_SYS.Add_To_Attr('COUNTY_TAX_PERCENT', county_tax_percent_, attr_);
   Client_SYS.Add_To_Attr('CITY_TAX_PERCENT', city_tax_percent_, attr_);
   Client_SYS.Add_To_Attr('DISTRICT_TAX_PERCENT', district_tax_percent_, attr_);
EXCEPTION
   WHEN OTHERS THEN
      RAISE;
END Calculate_Tax;


PROCEDURE Get_Jurisdiction_Code (
   jurisdiction_code_ OUT VARCHAR2,
   city_              IN  VARCHAR2,
   state_             IN  VARCHAR2,
   zip_code_          IN  VARCHAR2,
   county_            IN  VARCHAR2 )
IS
   stmt_              VARCHAR2(5000);
   -- Bug 102054, Begin, Changed initial value from 0 to 1
   exist_             NUMBER := 1;
   -- Bug 102054, End
   next_              NUMBER := 0;
   pos_               NUMBER := 0;
   zip_code_tmp_      COMPANY_ADDRESS_TAB.zip_code%TYPE;
BEGIN
   
   Client_SYS.Clear_Info;
   IF (Database_SYS.Package_Exist('GEO')) THEN
      zip_code_tmp_ := zip_code_;
      pos_ := INSTR(zip_code_, '-');
      IF ( pos_ >0 ) THEN
         zip_code_tmp_ := substr(zip_code_, 0, pos_-1);
      END IF;
      -- Bug 102054, Begin, Modified stmt_
      stmt_ := '
      DECLARE
         geo_search_record_     Geo.tGeoSearchRecord;
         geo_results_record_    Geo.tGeoResultsRecord;
      BEGIN
         IF (length(:state_) > 2) THEN
            Geo.GeoSetNameCriteria(geo_search_record_, Geo.cGeoCodeLevelCity, NULL, FALSE,
               :state_, FALSE, :county_, FALSE, FALSE, :city_, FALSE, :zip_code_, NULL);
         ELSE
            Geo.GeoSetNameCriteria(geo_search_record_, Geo.cGeoCodeLevelCity, :state_, FALSE,
               NULL, FALSE, :county_, FALSE, FALSE, :city_, FALSE, :zip_code_, NULL);
         END IF;
         IF NOT Geo.GeoRetrieveFirst(geo_search_record_, geo_results_record_) THEN
            :exist_ := 0;
            Geo.GeoCloseSearch(geo_search_record_);
         ELSE
            :exist_ := 1;
            :jurisdiction_code_ := to_char(Geo.GeoPackGeoCode(geo_results_record_.fResGeoState, 
                                   geo_results_record_.fResGeoCounty, geo_results_record_.fResGeoCity));
            IF Geo.GeoRetrieveNext(geo_search_record_, geo_results_record_) THEN
               :next_ := 1;
            ELSE
               :next_ := 0;
            END IF;
            Geo.GeoCloseSearch(geo_search_record_);
         END IF;
      END;
      ';
      -- Bug 102054, End
      @ApproveDynamicStatement(2005-11-11,shsalk)
      EXECUTE IMMEDIATE stmt_ USING IN     state_, 
                                    IN     county_, 
                                    IN     city_, 
                                    IN     zip_code_tmp_, 
                                    IN OUT exist_, 
                                    OUT    jurisdiction_code_, 
                                    IN OUT next_;
      -- Bug 102054, Begin, Removed Exception section and moved code here
      IF exist_ = 0 THEN
         jurisdiction_code_ := NULL;
         Error_SYS.Item_General(lu_name_, 'JURISDICTION_CODE',
            'GEONOTFOUND: No Jurisdiction Code was found based on the City, State, Zip Code and County information');
      END IF;
      IF next_ = 1 THEN
         -- Bug 122338, Begin
         Client_Sys.Add_Info(lu_name_, 'MULTIJURISDICTION_CODE: Entered information for City, State, Zip Code and County found more than one Jurisdiction Code. First one returned.');            
		 -- Bug 122338, End
      END IF;
      -- Bug 102054, End
   END IF;
END Get_Jurisdiction_Code;


PROCEDURE Get_Enterp_Jurisdiction_Code(
   jurisdiction_code_ OUT VARCHAR2,
   city_              IN  VARCHAR2,
   state_             IN  VARCHAR2,
   zip_code_          IN  VARCHAR2,
   county_            IN  VARCHAR2 )
IS
   stmt_              VARCHAR2(5000);
   -- Bug 102054, Removed variables exist_ and next_
BEGIN
   Client_SYS.Clear_Info;
   IF (Database_SYS.Package_Exist('GEO')) THEN
      -- Bug 102054, Begin, Modified stmt_
      stmt_ := '
      DECLARE
         geo_search_record_     Geo.tGeoSearchRecord;
         geo_results_record_    Geo.tGeoResultsRecord;
      BEGIN
         IF (length(:state_) > 2) THEN
            Geo.GeoSetNameCriteria(geo_search_record_, Geo.cGeoCodeLevelCity, NULL, FALSE,
               :state_, FALSE, :county_, FALSE, FALSE, :city_, FALSE, :zip_code_, NULL);
         ELSE
            Geo.GeoSetNameCriteria(geo_search_record_, Geo.cGeoCodeLevelCity, :state_, FALSE,
               NULL, FALSE, :county_, FALSE, FALSE, :city_, FALSE, :zip_code_, NULL);
         END IF;

         IF Geo.GeoRetrieveFirst(geo_search_record_, geo_results_record_) THEN
            :jurisdiction_code_ := to_char(Geo.GeoPackGeoCode(geo_results_record_.fResGeoState, 
                                   geo_results_record_.fResGeoCounty, geo_results_record_.fResGeoCity));
         END IF;
         Geo.GeoCloseSearch(geo_search_record_);
      END;
      ';
      -- Bug 102054, End
      -- Bug 102054, Begin, Removed Parameters exist_ and next_
      @ApproveDynamicStatement(2005-11-11,shsalk)
      EXECUTE IMMEDIATE stmt_ USING IN     state_, 
                                    IN     county_, 
                                    IN     city_, 
                                    IN     zip_code_, 
                                    OUT    jurisdiction_code_;
      -- Bug 102054, End
   END IF;
EXCEPTION
   WHEN OTHERS THEN
      jurisdiction_code_ := NULL;
END Get_Enterp_Jurisdiction_Code;


