/*
               File: Factura
        Description: Factura
             Author: GeneXus C# Generator version 15_0_6-116888
       Generated on: 9/21/2017 20:9:14.66
       Program type: Callable routine
          Main DBMS: SQL Server
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using System.Data.SqlClient;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using System.Runtime.Remoting;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class factura : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetNextPar( );
         gxfirstwebparm_bkp = gxfirstwebparm;
         gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            dyncall( GetNextPar( )) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_11") == 0 )
         {
            A4FacturaId = (short)(NumberUtil.Val( GetNextPar( ), "."));
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A4FacturaId", StringUtil.LTrim( StringUtil.Str( (decimal)(A4FacturaId), 4, 0)));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_11( A4FacturaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_10") == 0 )
         {
            A9ClienteId = (short)(NumberUtil.Val( GetNextPar( ), "."));
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9ClienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9ClienteId), 4, 0)));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_10( A9ClienteId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
         {
            A1ProductoId = (short)(NumberUtil.Val( GetNextPar( ), "."));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A1ProductoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
         {
            setAjaxEventMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridfactura_facturaproducto") == 0 )
         {
            nRC_GXsfl_58 = (short)(NumberUtil.Val( GetNextPar( ), "."));
            nGXsfl_58_idx = (short)(NumberUtil.Val( GetNextPar( ), "."));
            sGXsfl_58_idx = GetNextPar( );
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxnrGridfactura_facturaproducto_newrow( ) ;
            return  ;
         }
         else
         {
            if ( ! IsValidAjaxCall( false) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = gxfirstwebparm_bkp;
         }
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Crypto.Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
         }
         GXKey = Crypto.Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.isSpaRequest( ) )
         {
            Form.Meta.addItem("generator", "GeneXus C# 15_0_6-116888", 0) ;
            Form.Meta.addItem("description", "Factura", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         GX_FocusControl = edtFacturaId_Internalname;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public factura( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public factura( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( )
      {
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("rwdmasterpage", "GeneXus.Programs.rwdmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "max-age=0");
               }
               if ( ! context.WillRedirect( ) )
               {
                  context.GX_webresponse.AddString((String)(context.getJSONResponse( )));
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "WWAdvancedContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "TableTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Factura", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, "HLP_Factura.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "FormContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 ToolbarCellClass", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "BtnFirst";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Factura.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "BtnPrevious";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Factura.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
            ClassString = "BtnNext";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Factura.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
            ClassString = "BtnLast";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Factura.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            ClassString = "BtnSelect";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 4, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"FACTURAID"+"'), id:'"+"FACTURAID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Factura.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCellAdvanced", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtFacturaId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true);
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtFacturaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A4FacturaId), 4, 0, ".", "")), ((edtFacturaId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A4FacturaId), "ZZZ9")) : context.localUtil.Format( (decimal)(A4FacturaId), "ZZZ9")), TempTags+" onchange=\"gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFacturaId_Jsonclick, 0, "Attribute", "", "", "", edtFacturaId_Visible, edtFacturaId_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "HLP_Factura.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtFacturaFecha_Internalname, "Fecha", "col-sm-3 AttributeLabel", 1, true);
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtFacturaFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtFacturaFecha_Internalname, context.localUtil.Format(A5FacturaFecha, "99/99/99"), context.localUtil.Format( A5FacturaFecha, "99/99/99"), TempTags+" onchange=\"gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFacturaFecha_Jsonclick, 0, "Attribute", "", "", "", 1, edtFacturaFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "HLP_Factura.htm");
            GxWebStd.gx_bitmap( context, edtFacturaFecha_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtFacturaFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Factura.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtFacturaTotal_Internalname, "Total", "col-sm-3 AttributeLabel", 1, true);
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtFacturaTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A6FacturaTotal), 4, 0, ".", "")), ((edtFacturaTotal_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A6FacturaTotal), "ZZZ9")) : context.localUtil.Format( (decimal)(A6FacturaTotal), "ZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFacturaTotal_Jsonclick, 0, "Attribute", "", "", "", 1, edtFacturaTotal_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "HLP_Factura.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtClienteId_Internalname, "Cliente Id", "col-sm-3 AttributeLabel", 1, true);
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtClienteId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9ClienteId), 4, 0, ".", "")), ((edtClienteId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A9ClienteId), "ZZZ9")) : context.localUtil.Format( (decimal)(A9ClienteId), "ZZZ9")), TempTags+" onchange=\"gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteId_Jsonclick, 0, "Attribute", "", "", "", 1, edtClienteId_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "HLP_Factura.htm");
            /* Static images/pictures */
            ClassString = "gx-prompt Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgprompt_9_Internalname, sImgUrl, imgprompt_9_Link, "", "", context.GetTheme( ), imgprompt_9_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Factura.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtClienteNombre_Internalname, "Cliente Nombre", "col-sm-3 AttributeLabel", 1, true);
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtClienteNombre_Internalname, StringUtil.RTrim( A10ClienteNombre), StringUtil.RTrim( context.localUtil.Format( A10ClienteNombre, "")), TempTags+" onchange=\"gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteNombre_Jsonclick, 0, "Attribute", "", "", "", 1, edtClienteNombre_Enabled, 1, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "HLP_Factura.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 LevelTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFacturaproductotable_Internalname, 1, 0, "px", 0, "px", "LevelTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitlefacturaproducto_Internalname, "Factura Producto", "", "", lblTitlefacturaproducto_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, "HLP_Factura.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            gxdraw_Gridfactura_facturaproducto( ) ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group Confirm", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Factura.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Factura.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
            ClassString = "BtnDelete";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Factura.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void gxdraw_Gridfactura_facturaproducto( )
      {
         /*  Grid Control  */
         Gridfactura_facturaproductoContainer.AddObjectProperty("GridName", "Gridfactura_facturaproducto");
         Gridfactura_facturaproductoContainer.AddObjectProperty("Class", "Grid");
         Gridfactura_facturaproductoContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridfactura_facturaproductoContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridfactura_facturaproductoContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridfactura_facturaproducto_Backcolorstyle), 1, 0, ".", "")));
         Gridfactura_facturaproductoContainer.AddObjectProperty("CmpContext", "");
         Gridfactura_facturaproductoContainer.AddObjectProperty("InMasterPage", "false");
         Gridfactura_facturaproductoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridfactura_facturaproductoColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1ProductoId), 4, 0, ".", "")));
         Gridfactura_facturaproductoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoId_Enabled), 5, 0, ".", "")));
         Gridfactura_facturaproductoContainer.AddColumnProperties(Gridfactura_facturaproductoColumn);
         Gridfactura_facturaproductoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridfactura_facturaproductoContainer.AddColumnProperties(Gridfactura_facturaproductoColumn);
         Gridfactura_facturaproductoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridfactura_facturaproductoColumn.AddObjectProperty("Value", StringUtil.RTrim( A2ProductoNombre));
         Gridfactura_facturaproductoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoNombre_Enabled), 5, 0, ".", "")));
         Gridfactura_facturaproductoContainer.AddColumnProperties(Gridfactura_facturaproductoColumn);
         Gridfactura_facturaproductoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridfactura_facturaproductoColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A3ProductoPrecio), 4, 0, ".", "")));
         Gridfactura_facturaproductoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoPrecio_Enabled), 5, 0, ".", "")));
         Gridfactura_facturaproductoContainer.AddColumnProperties(Gridfactura_facturaproductoColumn);
         Gridfactura_facturaproductoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridfactura_facturaproductoColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7FacturaProductoCantidad), 4, 0, ".", "")));
         Gridfactura_facturaproductoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtFacturaProductoCantidad_Enabled), 5, 0, ".", "")));
         Gridfactura_facturaproductoContainer.AddColumnProperties(Gridfactura_facturaproductoColumn);
         Gridfactura_facturaproductoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridfactura_facturaproductoColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A8FacturaProductoTotal), 4, 0, ".", "")));
         Gridfactura_facturaproductoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtFacturaProductoTotal_Enabled), 5, 0, ".", "")));
         Gridfactura_facturaproductoContainer.AddColumnProperties(Gridfactura_facturaproductoColumn);
         Gridfactura_facturaproductoContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridfactura_facturaproducto_Allowselection), 1, 0, ".", "")));
         Gridfactura_facturaproductoContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridfactura_facturaproducto_Selectioncolor), 9, 0, ".", "")));
         Gridfactura_facturaproductoContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridfactura_facturaproducto_Allowhovering), 1, 0, ".", "")));
         Gridfactura_facturaproductoContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridfactura_facturaproducto_Hoveringcolor), 9, 0, ".", "")));
         Gridfactura_facturaproductoContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridfactura_facturaproducto_Allowcollapsing), 1, 0, ".", "")));
         Gridfactura_facturaproductoContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridfactura_facturaproducto_Collapsed), 1, 0, ".", "")));
         nGXsfl_58_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount3 = 5;
            if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
            {
               /* Display confirmed (stored) records */
               nRcdExists_3 = 1;
               ScanStart023( ) ;
               while ( RcdFound3 != 0 )
               {
                  init_level_properties3( ) ;
                  getByPrimaryKey023( ) ;
                  AddRow023( ) ;
                  ScanNext023( ) ;
               }
               ScanEnd023( ) ;
               nBlankRcdCount3 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B6FacturaTotal = A6FacturaTotal;
            n6FacturaTotal = false;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
            standaloneNotModal023( ) ;
            standaloneModal023( ) ;
            sMode3 = Gx_mode;
            while ( nGXsfl_58_idx < nRC_GXsfl_58 )
            {
               bGXsfl_58_Refreshing = true;
               ReadRow023( ) ;
               edtProductoId_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUCTOID_"+sGXsfl_58_idx+"Enabled"), ".", ","));
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtProductoId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtProductoId_Enabled), 5, 0)), !bGXsfl_58_Refreshing);
               edtProductoNombre_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUCTONOMBRE_"+sGXsfl_58_idx+"Enabled"), ".", ","));
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtProductoNombre_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtProductoNombre_Enabled), 5, 0)), !bGXsfl_58_Refreshing);
               edtProductoPrecio_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUCTOPRECIO_"+sGXsfl_58_idx+"Enabled"), ".", ","));
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtProductoPrecio_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtProductoPrecio_Enabled), 5, 0)), !bGXsfl_58_Refreshing);
               edtFacturaProductoCantidad_Enabled = (int)(context.localUtil.CToN( cgiGet( "FACTURAPRODUCTOCANTIDAD_"+sGXsfl_58_idx+"Enabled"), ".", ","));
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtFacturaProductoCantidad_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtFacturaProductoCantidad_Enabled), 5, 0)), !bGXsfl_58_Refreshing);
               edtFacturaProductoTotal_Enabled = (int)(context.localUtil.CToN( cgiGet( "FACTURAPRODUCTOTOTAL_"+sGXsfl_58_idx+"Enabled"), ".", ","));
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtFacturaProductoTotal_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtFacturaProductoTotal_Enabled), 5, 0)), !bGXsfl_58_Refreshing);
               imgprompt_9_Link = cgiGet( "PROMPT_1_"+sGXsfl_58_idx+"Link");
               if ( ( nRcdExists_3 == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) )
               {
                  Gx_mode = "INS";
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                  standaloneModal023( ) ;
               }
               SendRow023( ) ;
               bGXsfl_58_Refreshing = false;
            }
            Gx_mode = sMode3;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
            A6FacturaTotal = B6FacturaTotal;
            n6FacturaTotal = false;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount3 = 5;
            nRcdExists_3 = 1;
            if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
            {
               ScanStart023( ) ;
               while ( RcdFound3 != 0 )
               {
                  sGXsfl_58_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_58_idx+1), 4, 0)), 4, "0");
                  SubsflControlProps_583( ) ;
                  init_level_properties3( ) ;
                  standaloneNotModal023( ) ;
                  getByPrimaryKey023( ) ;
                  standaloneModal023( ) ;
                  AddRow023( ) ;
                  ScanNext023( ) ;
               }
               ScanEnd023( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         sMode3 = Gx_mode;
         Gx_mode = "INS";
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         sGXsfl_58_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_58_idx+1), 4, 0)), 4, "0");
         SubsflControlProps_583( ) ;
         InitAll023( ) ;
         init_level_properties3( ) ;
         B6FacturaTotal = A6FacturaTotal;
         n6FacturaTotal = false;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
         standaloneNotModal023( ) ;
         standaloneModal023( ) ;
         nRcdExists_3 = 0;
         nIsMod_3 = 0;
         nRcdDeleted_3 = 0;
         nBlankRcdCount3 = (short)(nBlankRcdUsr3+nBlankRcdCount3);
         fRowAdded = 0;
         while ( nBlankRcdCount3 > 0 )
         {
            AddRow023( ) ;
            if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
            {
               fRowAdded = 1;
               GX_FocusControl = edtProductoId_Internalname;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nBlankRcdCount3 = (short)(nBlankRcdCount3-1);
         }
         Gx_mode = sMode3;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         A6FacturaTotal = B6FacturaTotal;
         n6FacturaTotal = false;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridfactura_facturaproductoContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridfactura_facturaproducto", Gridfactura_facturaproductoContainer);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridfactura_facturaproductoContainerData", Gridfactura_facturaproductoContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridfactura_facturaproductoContainerData"+"V", Gridfactura_facturaproductoContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridfactura_facturaproductoContainerData"+"V"+"\" value='"+Gridfactura_facturaproductoContainer.GridValuesHidden()+"'/>") ;
         }
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read variables values. */
               if ( ( ( context.localUtil.CToN( cgiGet( edtFacturaId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFacturaId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FACTURAID");
                  AnyError = 1;
                  GX_FocusControl = edtFacturaId_Internalname;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A4FacturaId = 0;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A4FacturaId", StringUtil.LTrim( StringUtil.Str( (decimal)(A4FacturaId), 4, 0)));
               }
               else
               {
                  A4FacturaId = (short)(context.localUtil.CToN( cgiGet( edtFacturaId_Internalname), ".", ","));
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A4FacturaId", StringUtil.LTrim( StringUtil.Str( (decimal)(A4FacturaId), 4, 0)));
               }
               if ( context.localUtil.VCDate( cgiGet( edtFacturaFecha_Internalname), 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Factura Fecha"}), 1, "FACTURAFECHA");
                  AnyError = 1;
                  GX_FocusControl = edtFacturaFecha_Internalname;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A5FacturaFecha = DateTime.MinValue;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A5FacturaFecha", context.localUtil.Format(A5FacturaFecha, "99/99/99"));
               }
               else
               {
                  A5FacturaFecha = context.localUtil.CToD( cgiGet( edtFacturaFecha_Internalname), 1);
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A5FacturaFecha", context.localUtil.Format(A5FacturaFecha, "99/99/99"));
               }
               A6FacturaTotal = (short)(context.localUtil.CToN( cgiGet( edtFacturaTotal_Internalname), ".", ","));
               n6FacturaTotal = false;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
               if ( ( ( context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIENTEID");
                  AnyError = 1;
                  GX_FocusControl = edtClienteId_Internalname;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A9ClienteId = 0;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9ClienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9ClienteId), 4, 0)));
               }
               else
               {
                  A9ClienteId = (short)(context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ".", ","));
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9ClienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9ClienteId), 4, 0)));
               }
               A10ClienteNombre = cgiGet( edtClienteNombre_Internalname);
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A10ClienteNombre", A10ClienteNombre);
               /* Read saved values. */
               Z4FacturaId = (short)(context.localUtil.CToN( cgiGet( "Z4FacturaId"), ".", ","));
               Z5FacturaFecha = context.localUtil.CToD( cgiGet( "Z5FacturaFecha"), 0);
               Z9ClienteId = (short)(context.localUtil.CToN( cgiGet( "Z9ClienteId"), ".", ","));
               O6FacturaTotal = (short)(context.localUtil.CToN( cgiGet( "O6FacturaTotal"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_58 = (short)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_58"), ".", ","));
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","));
               Gx_date = context.localUtil.CToD( cgiGet( "vTODAY"), 0);
               Gx_mode = cgiGet( "vMODE");
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               /* Check if conditions changed and reset current page numbers */
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                  A4FacturaId = (short)(NumberUtil.Val( GetNextPar( ), "."));
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A4FacturaId", StringUtil.LTrim( StringUtil.Str( (decimal)(A4FacturaId), 4, 0)));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons_dsp( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  Gx_mode = "INS";
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                  standaloneModal( ) ;
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
            sEvt = cgiGet( "_EventName");
            EvtGridId = cgiGet( "_EventGridId");
            EvtRowId = cgiGet( "_EventRowId");
            if ( StringUtil.Len( sEvt) > 0 )
            {
               sEvtType = StringUtil.Left( sEvt, 1);
               sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
               if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
               {
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
                        }
                     }
                     else
                     {
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )  )
            {
               /* Clear variables for new insertion. */
               InitAll022( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
      }

      public override String ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(bttBtn_delete_Enabled), 5, 0)), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtn_delete_Visible = 0;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(bttBtn_delete_Visible), 5, 0)), true);
         bttBtn_first_Visible = 0;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(bttBtn_first_Visible), 5, 0)), true);
         bttBtn_previous_Visible = 0;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(bttBtn_previous_Visible), 5, 0)), true);
         bttBtn_next_Visible = 0;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(bttBtn_next_Visible), 5, 0)), true);
         bttBtn_last_Visible = 0;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(bttBtn_last_Visible), 5, 0)), true);
         bttBtn_select_Visible = 0;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(bttBtn_select_Visible), 5, 0)), true);
         bttBtn_delete_Visible = 0;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(bttBtn_delete_Visible), 5, 0)), true);
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Visible = 0;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(bttBtn_enter_Visible), 5, 0)), true);
         }
         DisableAttributes022( ) ;
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_023( )
      {
         s6FacturaTotal = O6FacturaTotal;
         n6FacturaTotal = false;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
         nGXsfl_58_idx = 0;
         while ( nGXsfl_58_idx < nRC_GXsfl_58 )
         {
            ReadRow023( ) ;
            if ( ( nRcdExists_3 != 0 ) || ( nIsMod_3 != 0 ) )
            {
               GetKey023( ) ;
               if ( ( nRcdExists_3 == 0 ) && ( nRcdDeleted_3 == 0 ) )
               {
                  if ( RcdFound3 == 0 )
                  {
                     Gx_mode = "INS";
                     context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate023( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable023( ) ;
                        CloseExtendedTableCursors023( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           context.httpAjaxContext.ajax_rsp_assign_attri("", false, "IsConfirmed", StringUtil.LTrim( StringUtil.Str( (decimal)(IsConfirmed), 4, 0)));
                        }
                        O6FacturaTotal = A6FacturaTotal;
                        n6FacturaTotal = false;
                        context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
                     }
                  }
                  else
                  {
                     GXCCtl = "PRODUCTOID_" + sGXsfl_58_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtProductoId_Internalname;
                     context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound3 != 0 )
                  {
                     if ( nRcdDeleted_3 != 0 )
                     {
                        Gx_mode = "DLT";
                        context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey023( ) ;
                        Load023( ) ;
                        BeforeValidate023( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls023( ) ;
                           O6FacturaTotal = A6FacturaTotal;
                           n6FacturaTotal = false;
                           context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
                        }
                     }
                     else
                     {
                        if ( nIsMod_3 != 0 )
                        {
                           Gx_mode = "UPD";
                           context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate023( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable023( ) ;
                              CloseExtendedTableCursors023( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 context.httpAjaxContext.ajax_rsp_assign_attri("", false, "IsConfirmed", StringUtil.LTrim( StringUtil.Str( (decimal)(IsConfirmed), 4, 0)));
                              }
                              O6FacturaTotal = A6FacturaTotal;
                              n6FacturaTotal = false;
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_3 == 0 )
                     {
                        GXCCtl = "PRODUCTOID_" + sGXsfl_58_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProductoId_Internalname;
                        context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtProductoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1ProductoId), 4, 0, ".", ""))) ;
            ChangePostValue( edtProductoNombre_Internalname, StringUtil.RTrim( A2ProductoNombre)) ;
            ChangePostValue( edtProductoPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A3ProductoPrecio), 4, 0, ".", ""))) ;
            ChangePostValue( edtFacturaProductoCantidad_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A7FacturaProductoCantidad), 4, 0, ".", ""))) ;
            ChangePostValue( edtFacturaProductoTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A8FacturaProductoTotal), 4, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z1ProductoId_"+sGXsfl_58_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1ProductoId), 4, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z7FacturaProductoCantidad_"+sGXsfl_58_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7FacturaProductoCantidad), 4, 0, ".", ""))) ;
            ChangePostValue( "T8FacturaProductoTotal_"+sGXsfl_58_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(O8FacturaProductoTotal), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_3_"+sGXsfl_58_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_3), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_3_"+sGXsfl_58_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_3), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_3_"+sGXsfl_58_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_3), 4, 0, ".", ""))) ;
            if ( nIsMod_3 != 0 )
            {
               ChangePostValue( "PRODUCTOID_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTONOMBRE_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTOPRECIO_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoPrecio_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "FACTURAPRODUCTOCANTIDAD_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtFacturaProductoCantidad_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "FACTURAPRODUCTOTOTAL_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtFacturaProductoTotal_Enabled), 5, 0, ".", ""))) ;
            }
         }
         O6FacturaTotal = s6FacturaTotal;
         n6FacturaTotal = false;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption020( )
      {
      }

      protected void ZM022( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
            {
               Z5FacturaFecha = T00026_A5FacturaFecha[0];
               Z9ClienteId = T00026_A9ClienteId[0];
            }
            else
            {
               Z5FacturaFecha = A5FacturaFecha;
               Z9ClienteId = A9ClienteId;
            }
         }
         if ( GX_JID == -9 )
         {
            Z4FacturaId = A4FacturaId;
            Z5FacturaFecha = A5FacturaFecha;
            Z9ClienteId = A9ClienteId;
            Z6FacturaTotal = A6FacturaTotal;
            Z10ClienteNombre = A10ClienteNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         edtFacturaId_Visible = 0;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtFacturaId_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(edtFacturaId_Visible), 5, 0)), true);
         edtClienteNombre_Enabled = 0;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtClienteNombre_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtClienteNombre_Enabled), 5, 0)), true);
         Gx_BScreen = 0;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         Gx_date = DateTimeUtil.Today( context);
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         imgprompt_9_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0040.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CLIENTEID"+"'), id:'"+"CLIENTEID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )  && (0==A9ClienteId) && ( Gx_BScreen == 0 ) )
         {
            A9ClienteId = 1;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9ClienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9ClienteId), 4, 0)));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )  && (DateTime.MinValue==A5FacturaFecha) && ( Gx_BScreen == 0 ) )
         {
            A5FacturaFecha = Gx_date;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A5FacturaFecha", context.localUtil.Format(A5FacturaFecha, "99/99/99"));
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(bttBtn_delete_Enabled), 5, 0)), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(bttBtn_delete_Enabled), 5, 0)), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(bttBtn_enter_Enabled), 5, 0)), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(bttBtn_enter_Enabled), 5, 0)), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00027 */
            pr_default.execute(5, new Object[] {A9ClienteId});
            A10ClienteNombre = T00027_A10ClienteNombre[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A10ClienteNombre", A10ClienteNombre);
            pr_default.close(5);
         }
      }

      protected void Load022( )
      {
         /* Using cursor T000211 */
         pr_default.execute(7, new Object[] {A4FacturaId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound2 = 1;
            A5FacturaFecha = T000211_A5FacturaFecha[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A5FacturaFecha", context.localUtil.Format(A5FacturaFecha, "99/99/99"));
            A10ClienteNombre = T000211_A10ClienteNombre[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A10ClienteNombre", A10ClienteNombre);
            A9ClienteId = T000211_A9ClienteId[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9ClienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9ClienteId), 4, 0)));
            A6FacturaTotal = T000211_A6FacturaTotal[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
            n6FacturaTotal = T000211_n6FacturaTotal[0];
            ZM022( -9) ;
         }
         pr_default.close(7);
         OnLoadActions022( ) ;
      }

      protected void OnLoadActions022( )
      {
         O6FacturaTotal = A6FacturaTotal;
         n6FacturaTotal = false;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
      }

      protected void CheckExtendedTable022( )
      {
         Gx_BScreen = 1;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T00029 */
         pr_default.execute(6, new Object[] {A4FacturaId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            A6FacturaTotal = T00029_A6FacturaTotal[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
            n6FacturaTotal = T00029_n6FacturaTotal[0];
         }
         else
         {
            A6FacturaTotal = 0;
            n6FacturaTotal = false;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
         }
         pr_default.close(6);
         if ( ! ( (DateTime.MinValue==A5FacturaFecha) || ( A5FacturaFecha >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Field Factura Fecha is out of range", "OutOfRange", 1, "FACTURAFECHA");
            AnyError = 1;
            GX_FocusControl = edtFacturaFecha_Internalname;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00027 */
         pr_default.execute(5, new Object[] {A9ClienteId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No matching 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
            AnyError = 1;
            GX_FocusControl = edtClienteId_Internalname;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A10ClienteNombre = T00027_A10ClienteNombre[0];
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A10ClienteNombre", A10ClienteNombre);
         pr_default.close(5);
         if ( A5FacturaFecha < Gx_date )
         {
            GX_msglist.addItem("Le fecha no puede ser menor al dia actual", 1, "FACTURAFECHA");
            AnyError = 1;
            GX_FocusControl = edtFacturaFecha_Internalname;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors022( )
      {
         pr_default.close(6);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_11( short A4FacturaId )
      {
         /* Using cursor T000213 */
         pr_default.execute(8, new Object[] {A4FacturaId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            A6FacturaTotal = T000213_A6FacturaTotal[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
            n6FacturaTotal = T000213_n6FacturaTotal[0];
         }
         else
         {
            A6FacturaTotal = 0;
            n6FacturaTotal = false;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         context.GX_webresponse.AddString("new Array( new Array(");
         context.GX_webresponse.AddString("\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A6FacturaTotal), 4, 0, ".", "")))+"\"");
         context.GX_webresponse.AddString(")");
         if ( (pr_default.getStatus(8) == 101) )
         {
            context.GX_webresponse.AddString(",");
            context.GX_webresponse.AddString("101");
         }
         context.GX_webresponse.AddString(")");
         pr_default.close(8);
      }

      protected void gxLoad_10( short A9ClienteId )
      {
         /* Using cursor T000214 */
         pr_default.execute(9, new Object[] {A9ClienteId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No matching 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
            AnyError = 1;
            GX_FocusControl = edtClienteId_Internalname;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A10ClienteNombre = T000214_A10ClienteNombre[0];
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A10ClienteNombre", A10ClienteNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         context.GX_webresponse.AddString("new Array( new Array(");
         context.GX_webresponse.AddString("\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A10ClienteNombre))+"\"");
         context.GX_webresponse.AddString(")");
         if ( (pr_default.getStatus(9) == 101) )
         {
            context.GX_webresponse.AddString(",");
            context.GX_webresponse.AddString("101");
         }
         context.GX_webresponse.AddString(")");
         pr_default.close(9);
      }

      protected void GetKey022( )
      {
         /* Using cursor T000215 */
         pr_default.execute(10, new Object[] {A4FacturaId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(10);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00026 */
         pr_default.execute(4, new Object[] {A4FacturaId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM022( 9) ;
            RcdFound2 = 1;
            A4FacturaId = T00026_A4FacturaId[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A4FacturaId", StringUtil.LTrim( StringUtil.Str( (decimal)(A4FacturaId), 4, 0)));
            A5FacturaFecha = T00026_A5FacturaFecha[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A5FacturaFecha", context.localUtil.Format(A5FacturaFecha, "99/99/99"));
            A9ClienteId = T00026_A9ClienteId[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9ClienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9ClienteId), 4, 0)));
            Z4FacturaId = A4FacturaId;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load022( ) ;
            if ( AnyError == 1 )
            {
               RcdFound2 = 0;
               InitializeNonKey022( ) ;
            }
            Gx_mode = sMode2;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey022( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode2;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey022( ) ;
         if ( RcdFound2 == 0 )
         {
            Gx_mode = "INS";
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound2 = 0;
         /* Using cursor T000216 */
         pr_default.execute(11, new Object[] {A4FacturaId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T000216_A4FacturaId[0] < A4FacturaId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T000216_A4FacturaId[0] > A4FacturaId ) ) )
            {
               A4FacturaId = T000216_A4FacturaId[0];
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A4FacturaId", StringUtil.LTrim( StringUtil.Str( (decimal)(A4FacturaId), 4, 0)));
               RcdFound2 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void move_previous( )
      {
         RcdFound2 = 0;
         /* Using cursor T000217 */
         pr_default.execute(12, new Object[] {A4FacturaId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( T000217_A4FacturaId[0] > A4FacturaId ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( T000217_A4FacturaId[0] < A4FacturaId ) ) )
            {
               A4FacturaId = T000217_A4FacturaId[0];
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A4FacturaId", StringUtil.LTrim( StringUtil.Str( (decimal)(A4FacturaId), 4, 0)));
               RcdFound2 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey022( ) ;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            /* Insert record */
            A6FacturaTotal = O6FacturaTotal;
            n6FacturaTotal = false;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
            GX_FocusControl = edtFacturaId_Internalname;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
            Insert022( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound2 == 1 )
            {
               if ( A4FacturaId != Z4FacturaId )
               {
                  A4FacturaId = Z4FacturaId;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A4FacturaId", StringUtil.LTrim( StringUtil.Str( (decimal)(A4FacturaId), 4, 0)));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "FACTURAID");
                  AnyError = 1;
                  GX_FocusControl = edtFacturaId_Internalname;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
               {
                  A6FacturaTotal = O6FacturaTotal;
                  n6FacturaTotal = false;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtFacturaId_Internalname;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  A6FacturaTotal = O6FacturaTotal;
                  n6FacturaTotal = false;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
                  Update022( ) ;
                  GX_FocusControl = edtFacturaId_Internalname;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A4FacturaId != Z4FacturaId )
               {
                  Gx_mode = "INS";
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  A6FacturaTotal = O6FacturaTotal;
                  n6FacturaTotal = false;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
                  GX_FocusControl = edtFacturaId_Internalname;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert022( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "FACTURAID");
                     AnyError = 1;
                     GX_FocusControl = edtFacturaId_Internalname;
                     context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     A6FacturaTotal = O6FacturaTotal;
                     n6FacturaTotal = false;
                     context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
                     GX_FocusControl = edtFacturaId_Internalname;
                     context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert022( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      protected void btn_delete( )
      {
         if ( A4FacturaId != Z4FacturaId )
         {
            A4FacturaId = Z4FacturaId;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A4FacturaId", StringUtil.LTrim( StringUtil.Str( (decimal)(A4FacturaId), 4, 0)));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "FACTURAID");
            AnyError = 1;
            GX_FocusControl = edtFacturaId_Internalname;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            A6FacturaTotal = O6FacturaTotal;
            n6FacturaTotal = false;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtFacturaId_Internalname;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseOpenCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "IsConfirmed", StringUtil.LTrim( StringUtil.Str( (decimal)(IsConfirmed), 4, 0)));
         getEqualNoModal( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "FACTURAID");
            AnyError = 1;
            GX_FocusControl = edtFacturaId_Internalname;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtFacturaFecha_Internalname;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "IsConfirmed", StringUtil.LTrim( StringUtil.Str( (decimal)(IsConfirmed), 4, 0)));
         ScanStart022( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFacturaFecha_Internalname;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd022( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "IsConfirmed", StringUtil.LTrim( StringUtil.Str( (decimal)(IsConfirmed), 4, 0)));
         move_previous( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFacturaFecha_Internalname;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "IsConfirmed", StringUtil.LTrim( StringUtil.Str( (decimal)(IsConfirmed), 4, 0)));
         move_next( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFacturaFecha_Internalname;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "IsConfirmed", StringUtil.LTrim( StringUtil.Str( (decimal)(IsConfirmed), 4, 0)));
         ScanStart022( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound2 != 0 )
            {
               ScanNext022( ) ;
            }
            Gx_mode = "UPD";
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFacturaFecha_Internalname;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd022( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency022( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            /* Using cursor T00025 */
            pr_default.execute(3, new Object[] {A4FacturaId});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Factura"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) || ( Z5FacturaFecha != T00025_A5FacturaFecha[0] ) || ( Z9ClienteId != T00025_A9ClienteId[0] ) )
            {
               if ( Z5FacturaFecha != T00025_A5FacturaFecha[0] )
               {
                  GXUtil.WriteLog("factura:[seudo value changed for attri]"+"FacturaFecha");
                  GXUtil.WriteLogRaw("Old: ",Z5FacturaFecha);
                  GXUtil.WriteLogRaw("Current: ",T00025_A5FacturaFecha[0]);
               }
               if ( Z9ClienteId != T00025_A9ClienteId[0] )
               {
                  GXUtil.WriteLog("factura:[seudo value changed for attri]"+"ClienteId");
                  GXUtil.WriteLogRaw("Old: ",Z9ClienteId);
                  GXUtil.WriteLogRaw("Current: ",T00025_A9ClienteId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Factura"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM022( 0) ;
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000218 */
                     pr_default.execute(13, new Object[] {A5FacturaFecha, A9ClienteId});
                     A4FacturaId = T000218_A4FacturaId[0];
                     context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A4FacturaId", StringUtil.LTrim( StringUtil.Str( (decimal)(A4FacturaId), 4, 0)));
                     pr_default.close(13);
                     dsDefault.SmartCacheProvider.SetUpdated("Factura") ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel022( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              GX_msglist.addItem(context.GetMessage( "GXM_sucadded", ""), "SuccessfullyAdded", 0, "", true);
                              ResetCaption020( ) ;
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load022( ) ;
            }
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void Update022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000219 */
                     pr_default.execute(14, new Object[] {A5FacturaFecha, A9ClienteId, A4FacturaId});
                     pr_default.close(14);
                     dsDefault.SmartCacheProvider.SetUpdated("Factura") ;
                     if ( (pr_default.getStatus(14) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Factura"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate022( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel022( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              GX_msglist.addItem(context.GetMessage( "GXM_sucupdated", ""), "SuccessfullyUpdated", 0, "", true);
                              ResetCaption020( ) ;
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void DeferredUpdate022( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls022( ) ;
            AfterConfirm022( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete022( ) ;
               if ( AnyError == 0 )
               {
                  A6FacturaTotal = O6FacturaTotal;
                  n6FacturaTotal = false;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
                  ScanStart023( ) ;
                  while ( RcdFound3 != 0 )
                  {
                     getByPrimaryKey023( ) ;
                     Delete023( ) ;
                     ScanNext023( ) ;
                     O6FacturaTotal = A6FacturaTotal;
                     n6FacturaTotal = false;
                     context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
                  }
                  ScanEnd023( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000220 */
                     pr_default.execute(15, new Object[] {A4FacturaId});
                     pr_default.close(15);
                     dsDefault.SmartCacheProvider.SetUpdated("Factura") ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           move_next( ) ;
                           if ( RcdFound2 == 0 )
                           {
                              InitAll022( ) ;
                              Gx_mode = "INS";
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                           }
                           else
                           {
                              getByPrimaryKey( ) ;
                              Gx_mode = "UPD";
                              context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                           }
                           GX_msglist.addItem(context.GetMessage( "GXM_sucdeleted", ""), "SuccessfullyDeleted", 0, "", true);
                           ResetCaption020( ) ;
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
         }
         sMode2 = Gx_mode;
         Gx_mode = "DLT";
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         EndLevel022( ) ;
         Gx_mode = sMode2;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls022( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000222 */
            pr_default.execute(16, new Object[] {A4FacturaId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               A6FacturaTotal = T000222_A6FacturaTotal[0];
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
               n6FacturaTotal = T000222_n6FacturaTotal[0];
            }
            else
            {
               A6FacturaTotal = 0;
               n6FacturaTotal = false;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
            }
            pr_default.close(16);
            /* Using cursor T000223 */
            pr_default.execute(17, new Object[] {A9ClienteId});
            A10ClienteNombre = T000223_A10ClienteNombre[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A10ClienteNombre", A10ClienteNombre);
            pr_default.close(17);
         }
      }

      protected void ProcessNestedLevel023( )
      {
         s6FacturaTotal = O6FacturaTotal;
         n6FacturaTotal = false;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
         nGXsfl_58_idx = 0;
         while ( nGXsfl_58_idx < nRC_GXsfl_58 )
         {
            ReadRow023( ) ;
            if ( ( nRcdExists_3 != 0 ) || ( nIsMod_3 != 0 ) )
            {
               standaloneNotModal023( ) ;
               GetKey023( ) ;
               if ( ( nRcdExists_3 == 0 ) && ( nRcdDeleted_3 == 0 ) )
               {
                  Gx_mode = "INS";
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                  Insert023( ) ;
               }
               else
               {
                  if ( RcdFound3 != 0 )
                  {
                     if ( ( nRcdDeleted_3 != 0 ) && ( nRcdExists_3 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                        Delete023( ) ;
                     }
                     else
                     {
                        if ( ( nIsMod_3 != 0 ) && ( nRcdExists_3 != 0 ) )
                        {
                           Gx_mode = "UPD";
                           context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                           Update023( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_3 == 0 )
                     {
                        GXCCtl = "PRODUCTOID_" + sGXsfl_58_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProductoId_Internalname;
                        context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
               O6FacturaTotal = A6FacturaTotal;
               n6FacturaTotal = false;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
            }
            ChangePostValue( edtProductoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1ProductoId), 4, 0, ".", ""))) ;
            ChangePostValue( edtProductoNombre_Internalname, StringUtil.RTrim( A2ProductoNombre)) ;
            ChangePostValue( edtProductoPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A3ProductoPrecio), 4, 0, ".", ""))) ;
            ChangePostValue( edtFacturaProductoCantidad_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A7FacturaProductoCantidad), 4, 0, ".", ""))) ;
            ChangePostValue( edtFacturaProductoTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A8FacturaProductoTotal), 4, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z1ProductoId_"+sGXsfl_58_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1ProductoId), 4, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z7FacturaProductoCantidad_"+sGXsfl_58_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7FacturaProductoCantidad), 4, 0, ".", ""))) ;
            ChangePostValue( "T8FacturaProductoTotal_"+sGXsfl_58_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(O8FacturaProductoTotal), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_3_"+sGXsfl_58_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_3), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_3_"+sGXsfl_58_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_3), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_3_"+sGXsfl_58_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_3), 4, 0, ".", ""))) ;
            if ( nIsMod_3 != 0 )
            {
               ChangePostValue( "PRODUCTOID_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTONOMBRE_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTOPRECIO_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoPrecio_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "FACTURAPRODUCTOCANTIDAD_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtFacturaProductoCantidad_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "FACTURAPRODUCTOTOTAL_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtFacturaProductoTotal_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll023( ) ;
         if ( AnyError != 0 )
         {
            O6FacturaTotal = s6FacturaTotal;
            n6FacturaTotal = false;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
         }
         nRcdExists_3 = 0;
         nIsMod_3 = 0;
         nRcdDeleted_3 = 0;
      }

      protected void ProcessLevel022( )
      {
         /* Save parent mode. */
         sMode2 = Gx_mode;
         ProcessNestedLevel023( ) ;
         if ( AnyError != 0 )
         {
            O6FacturaTotal = s6FacturaTotal;
            n6FacturaTotal = false;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
         }
         /* Restore parent mode. */
         Gx_mode = sMode2;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel022( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete022( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(17);
            pr_default.close(16);
            pr_default.close(2);
            pr_default.commit( "Factura");
            if ( AnyError == 0 )
            {
               ConfirmValues020( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(17);
            pr_default.close(16);
            pr_default.close(2);
            pr_default.rollback( "Factura");
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart022( )
      {
         /* Using cursor T000224 */
         pr_default.execute(18);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound2 = 1;
            A4FacturaId = T000224_A4FacturaId[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A4FacturaId", StringUtil.LTrim( StringUtil.Str( (decimal)(A4FacturaId), 4, 0)));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext022( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound2 = 1;
            A4FacturaId = T000224_A4FacturaId[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A4FacturaId", StringUtil.LTrim( StringUtil.Str( (decimal)(A4FacturaId), 4, 0)));
         }
      }

      protected void ScanEnd022( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm022( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert022( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate022( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete022( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete022( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate022( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes022( )
      {
         edtFacturaId_Enabled = 0;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtFacturaId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtFacturaId_Enabled), 5, 0)), true);
         edtFacturaFecha_Enabled = 0;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtFacturaFecha_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtFacturaFecha_Enabled), 5, 0)), true);
         edtFacturaTotal_Enabled = 0;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtFacturaTotal_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtFacturaTotal_Enabled), 5, 0)), true);
         edtClienteId_Enabled = 0;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtClienteId_Enabled), 5, 0)), true);
         edtClienteNombre_Enabled = 0;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtClienteNombre_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtClienteNombre_Enabled), 5, 0)), true);
      }

      protected void ZM023( short GX_JID )
      {
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
            {
               Z7FacturaProductoCantidad = T00023_A7FacturaProductoCantidad[0];
            }
            else
            {
               Z7FacturaProductoCantidad = A7FacturaProductoCantidad;
            }
         }
         if ( GX_JID == -12 )
         {
            Z4FacturaId = A4FacturaId;
            Z7FacturaProductoCantidad = A7FacturaProductoCantidad;
            Z1ProductoId = A1ProductoId;
            Z2ProductoNombre = A2ProductoNombre;
            Z3ProductoPrecio = A3ProductoPrecio;
         }
      }

      protected void standaloneNotModal023( )
      {
      }

      protected void standaloneModal023( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtProductoId_Enabled = 0;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtProductoId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtProductoId_Enabled), 5, 0)), !bGXsfl_58_Refreshing);
         }
         else
         {
            edtProductoId_Enabled = 1;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtProductoId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtProductoId_Enabled), 5, 0)), !bGXsfl_58_Refreshing);
         }
      }

      protected void Load023( )
      {
         /* Using cursor T000225 */
         pr_default.execute(19, new Object[] {A4FacturaId, A1ProductoId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound3 = 1;
            A2ProductoNombre = T000225_A2ProductoNombre[0];
            A3ProductoPrecio = T000225_A3ProductoPrecio[0];
            A7FacturaProductoCantidad = T000225_A7FacturaProductoCantidad[0];
            ZM023( -12) ;
         }
         pr_default.close(19);
         OnLoadActions023( ) ;
      }

      protected void OnLoadActions023( )
      {
         if ( A1ProductoId == 1 )
         {
            A8FacturaProductoTotal = (short)(A3ProductoPrecio*A7FacturaProductoCantidad*0.9m);
         }
         else
         {
            if ( A1ProductoId == 2 )
            {
               A8FacturaProductoTotal = (short)(A3ProductoPrecio*A7FacturaProductoCantidad*0.8m);
            }
            else
            {
               A8FacturaProductoTotal = (short)(A3ProductoPrecio*A7FacturaProductoCantidad);
            }
         }
         O8FacturaProductoTotal = A8FacturaProductoTotal;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )  )
         {
            A6FacturaTotal = (short)(O6FacturaTotal+A8FacturaProductoTotal);
            n6FacturaTotal = false;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
         }
         else
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )  )
            {
               A6FacturaTotal = (short)(O6FacturaTotal+A8FacturaProductoTotal-O8FacturaProductoTotal);
               n6FacturaTotal = false;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
            }
            else
            {
               if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )  )
               {
                  A6FacturaTotal = (short)(O6FacturaTotal-O8FacturaProductoTotal);
                  n6FacturaTotal = false;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
               }
            }
         }
      }

      protected void CheckExtendedTable023( )
      {
         Gx_BScreen = 1;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal023( ) ;
         /* Using cursor T00024 */
         pr_default.execute(2, new Object[] {A1ProductoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "PRODUCTOID_" + sGXsfl_58_idx;
            GX_msglist.addItem("No matching 'Producto'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductoId_Internalname;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2ProductoNombre = T00024_A2ProductoNombre[0];
         A3ProductoPrecio = T00024_A3ProductoPrecio[0];
         pr_default.close(2);
         if ( A1ProductoId == 1 )
         {
            A8FacturaProductoTotal = (short)(A3ProductoPrecio*A7FacturaProductoCantidad*0.9m);
         }
         else
         {
            if ( A1ProductoId == 2 )
            {
               A8FacturaProductoTotal = (short)(A3ProductoPrecio*A7FacturaProductoCantidad*0.8m);
            }
            else
            {
               A8FacturaProductoTotal = (short)(A3ProductoPrecio*A7FacturaProductoCantidad);
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )  )
         {
            A6FacturaTotal = (short)(O6FacturaTotal+A8FacturaProductoTotal);
            n6FacturaTotal = false;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
         }
         else
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )  )
            {
               A6FacturaTotal = (short)(O6FacturaTotal+A8FacturaProductoTotal-O8FacturaProductoTotal);
               n6FacturaTotal = false;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
            }
            else
            {
               if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )  )
               {
                  A6FacturaTotal = (short)(O6FacturaTotal-O8FacturaProductoTotal);
                  n6FacturaTotal = false;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
               }
            }
         }
      }

      protected void CloseExtendedTableCursors023( )
      {
         pr_default.close(2);
      }

      protected void enableDisable023( )
      {
      }

      protected void gxLoad_13( short A1ProductoId )
      {
         /* Using cursor T000226 */
         pr_default.execute(20, new Object[] {A1ProductoId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GXCCtl = "PRODUCTOID_" + sGXsfl_58_idx;
            GX_msglist.addItem("No matching 'Producto'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductoId_Internalname;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2ProductoNombre = T000226_A2ProductoNombre[0];
         A3ProductoPrecio = T000226_A3ProductoPrecio[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         context.GX_webresponse.AddString("new Array( new Array(");
         context.GX_webresponse.AddString("\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A2ProductoNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A3ProductoPrecio), 4, 0, ".", "")))+"\"");
         context.GX_webresponse.AddString(")");
         if ( (pr_default.getStatus(20) == 101) )
         {
            context.GX_webresponse.AddString(",");
            context.GX_webresponse.AddString("101");
         }
         context.GX_webresponse.AddString(")");
         pr_default.close(20);
      }

      protected void GetKey023( )
      {
         /* Using cursor T000227 */
         pr_default.execute(21, new Object[] {A4FacturaId, A1ProductoId});
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound3 = 1;
         }
         else
         {
            RcdFound3 = 0;
         }
         pr_default.close(21);
      }

      protected void getByPrimaryKey023( )
      {
         /* Using cursor T00023 */
         pr_default.execute(1, new Object[] {A4FacturaId, A1ProductoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM023( 12) ;
            RcdFound3 = 1;
            InitializeNonKey023( ) ;
            A7FacturaProductoCantidad = T00023_A7FacturaProductoCantidad[0];
            A1ProductoId = T00023_A1ProductoId[0];
            Z4FacturaId = A4FacturaId;
            Z1ProductoId = A1ProductoId;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
            standaloneModal023( ) ;
            Load023( ) ;
            Gx_mode = sMode3;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound3 = 0;
            InitializeNonKey023( ) ;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
            standaloneModal023( ) ;
            Gx_mode = sMode3;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            DisableAttributes023( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency023( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            /* Using cursor T00022 */
            pr_default.execute(0, new Object[] {A4FacturaId, A1ProductoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"FacturaFacturaProducto"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z7FacturaProductoCantidad != T00022_A7FacturaProductoCantidad[0] ) )
            {
               if ( Z7FacturaProductoCantidad != T00022_A7FacturaProductoCantidad[0] )
               {
                  GXUtil.WriteLog("factura:[seudo value changed for attri]"+"FacturaProductoCantidad");
                  GXUtil.WriteLogRaw("Old: ",Z7FacturaProductoCantidad);
                  GXUtil.WriteLogRaw("Current: ",T00022_A7FacturaProductoCantidad[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"FacturaFacturaProducto"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert023( )
      {
         BeforeValidate023( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable023( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM023( 0) ;
            CheckOptimisticConcurrency023( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm023( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert023( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000228 */
                     pr_default.execute(22, new Object[] {A4FacturaId, A7FacturaProductoCantidad, A1ProductoId});
                     pr_default.close(22);
                     dsDefault.SmartCacheProvider.SetUpdated("FacturaFacturaProducto") ;
                     if ( (pr_default.getStatus(22) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load023( ) ;
            }
            EndLevel023( ) ;
         }
         CloseExtendedTableCursors023( ) ;
      }

      protected void Update023( )
      {
         BeforeValidate023( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable023( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency023( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm023( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate023( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000229 */
                     pr_default.execute(23, new Object[] {A7FacturaProductoCantidad, A4FacturaId, A1ProductoId});
                     pr_default.close(23);
                     dsDefault.SmartCacheProvider.SetUpdated("FacturaFacturaProducto") ;
                     if ( (pr_default.getStatus(23) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"FacturaFacturaProducto"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate023( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey023( ) ;
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel023( ) ;
         }
         CloseExtendedTableCursors023( ) ;
      }

      protected void DeferredUpdate023( )
      {
      }

      protected void Delete023( )
      {
         Gx_mode = "DLT";
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         BeforeValidate023( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency023( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls023( ) ;
            AfterConfirm023( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete023( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000230 */
                  pr_default.execute(24, new Object[] {A4FacturaId, A1ProductoId});
                  pr_default.close(24);
                  dsDefault.SmartCacheProvider.SetUpdated("FacturaFacturaProducto") ;
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode3 = Gx_mode;
         Gx_mode = "DLT";
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         EndLevel023( ) ;
         Gx_mode = sMode3;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls023( )
      {
         standaloneModal023( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000231 */
            pr_default.execute(25, new Object[] {A1ProductoId});
            A2ProductoNombre = T000231_A2ProductoNombre[0];
            A3ProductoPrecio = T000231_A3ProductoPrecio[0];
            pr_default.close(25);
            if ( A1ProductoId == 1 )
            {
               A8FacturaProductoTotal = (short)(A3ProductoPrecio*A7FacturaProductoCantidad*0.9m);
            }
            else
            {
               if ( A1ProductoId == 2 )
               {
                  A8FacturaProductoTotal = (short)(A3ProductoPrecio*A7FacturaProductoCantidad*0.8m);
               }
               else
               {
                  A8FacturaProductoTotal = (short)(A3ProductoPrecio*A7FacturaProductoCantidad);
               }
            }
            if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )  )
            {
               A6FacturaTotal = (short)(O6FacturaTotal+A8FacturaProductoTotal);
               n6FacturaTotal = false;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
            }
            else
            {
               if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )  )
               {
                  A6FacturaTotal = (short)(O6FacturaTotal+A8FacturaProductoTotal-O8FacturaProductoTotal);
                  n6FacturaTotal = false;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )  )
                  {
                     A6FacturaTotal = (short)(O6FacturaTotal-O8FacturaProductoTotal);
                     n6FacturaTotal = false;
                     context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
                  }
               }
            }
         }
      }

      protected void EndLevel023( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart023( )
      {
         /* Scan By routine */
         /* Using cursor T000232 */
         pr_default.execute(26, new Object[] {A4FacturaId});
         RcdFound3 = 0;
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound3 = 1;
            A1ProductoId = T000232_A1ProductoId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext023( )
      {
         /* Scan next routine */
         pr_default.readNext(26);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound3 = 1;
            A1ProductoId = T000232_A1ProductoId[0];
         }
      }

      protected void ScanEnd023( )
      {
         pr_default.close(26);
      }

      protected void AfterConfirm023( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert023( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate023( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete023( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete023( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate023( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes023( )
      {
         edtProductoId_Enabled = 0;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtProductoId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtProductoId_Enabled), 5, 0)), !bGXsfl_58_Refreshing);
         edtProductoNombre_Enabled = 0;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtProductoNombre_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtProductoNombre_Enabled), 5, 0)), !bGXsfl_58_Refreshing);
         edtProductoPrecio_Enabled = 0;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtProductoPrecio_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtProductoPrecio_Enabled), 5, 0)), !bGXsfl_58_Refreshing);
         edtFacturaProductoCantidad_Enabled = 0;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtFacturaProductoCantidad_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtFacturaProductoCantidad_Enabled), 5, 0)), !bGXsfl_58_Refreshing);
         edtFacturaProductoTotal_Enabled = 0;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtFacturaProductoTotal_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtFacturaProductoTotal_Enabled), 5, 0)), !bGXsfl_58_Refreshing);
      }

      protected void SubsflControlProps_583( )
      {
         edtProductoId_Internalname = "PRODUCTOID_"+sGXsfl_58_idx;
         imgprompt_1_Internalname = "PROMPT_1_"+sGXsfl_58_idx;
         edtProductoNombre_Internalname = "PRODUCTONOMBRE_"+sGXsfl_58_idx;
         edtProductoPrecio_Internalname = "PRODUCTOPRECIO_"+sGXsfl_58_idx;
         edtFacturaProductoCantidad_Internalname = "FACTURAPRODUCTOCANTIDAD_"+sGXsfl_58_idx;
         edtFacturaProductoTotal_Internalname = "FACTURAPRODUCTOTOTAL_"+sGXsfl_58_idx;
      }

      protected void SubsflControlProps_fel_583( )
      {
         edtProductoId_Internalname = "PRODUCTOID_"+sGXsfl_58_fel_idx;
         imgprompt_1_Internalname = "PROMPT_1_"+sGXsfl_58_fel_idx;
         edtProductoNombre_Internalname = "PRODUCTONOMBRE_"+sGXsfl_58_fel_idx;
         edtProductoPrecio_Internalname = "PRODUCTOPRECIO_"+sGXsfl_58_fel_idx;
         edtFacturaProductoCantidad_Internalname = "FACTURAPRODUCTOCANTIDAD_"+sGXsfl_58_fel_idx;
         edtFacturaProductoTotal_Internalname = "FACTURAPRODUCTOTOTAL_"+sGXsfl_58_fel_idx;
      }

      protected void AddRow023( )
      {
         nGXsfl_58_idx = (short)(nGXsfl_58_idx+1);
         sGXsfl_58_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_58_idx), 4, 0)), 4, "0");
         SubsflControlProps_583( ) ;
         SendRow023( ) ;
      }

      protected void SendRow023( )
      {
         Gridfactura_facturaproductoRow = GXWebRow.GetNew(context);
         if ( subGridfactura_facturaproducto_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridfactura_facturaproducto_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridfactura_facturaproducto_Class, "") != 0 )
            {
               subGridfactura_facturaproducto_Linesclass = subGridfactura_facturaproducto_Class+"Odd";
            }
         }
         else if ( subGridfactura_facturaproducto_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridfactura_facturaproducto_Backstyle = 0;
            subGridfactura_facturaproducto_Backcolor = subGridfactura_facturaproducto_Allbackcolor;
            if ( StringUtil.StrCmp(subGridfactura_facturaproducto_Class, "") != 0 )
            {
               subGridfactura_facturaproducto_Linesclass = subGridfactura_facturaproducto_Class+"Uniform";
            }
         }
         else if ( subGridfactura_facturaproducto_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridfactura_facturaproducto_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridfactura_facturaproducto_Class, "") != 0 )
            {
               subGridfactura_facturaproducto_Linesclass = subGridfactura_facturaproducto_Class+"Odd";
            }
            subGridfactura_facturaproducto_Backcolor = (int)(0x0);
         }
         else if ( subGridfactura_facturaproducto_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridfactura_facturaproducto_Backstyle = 1;
            if ( ((int)((nGXsfl_58_idx) % (2))) == 0 )
            {
               subGridfactura_facturaproducto_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridfactura_facturaproducto_Class, "") != 0 )
               {
                  subGridfactura_facturaproducto_Linesclass = subGridfactura_facturaproducto_Class+"Even";
               }
            }
            else
            {
               subGridfactura_facturaproducto_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridfactura_facturaproducto_Class, "") != 0 )
               {
                  subGridfactura_facturaproducto_Linesclass = subGridfactura_facturaproducto_Class+"Odd";
               }
            }
         }
         imgprompt_1_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PRODUCTOID_"+sGXsfl_58_idx+"'), id:'"+"PRODUCTOID_"+sGXsfl_58_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_3_"+sGXsfl_58_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_3_" + sGXsfl_58_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 59,'',false,'" + sGXsfl_58_idx + "',58)\"";
         ROClassString = "Attribute";
         Gridfactura_facturaproductoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtProductoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1ProductoId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A1ProductoId), "ZZZ9")),TempTags+" onchange=\"gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,59);\"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtProductoId_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(short)-1,(int)edtProductoId_Enabled,(short)1,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)4,(short)0,(short)0,(short)58,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (String)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         Gridfactura_facturaproductoRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)imgprompt_1_Internalname,(String)sImgUrl,(String)imgprompt_1_Link,(String)"",(String)"",context.GetTheme( ),(int)imgprompt_1_Visible,(short)1,(String)"",(String)"",(short)0,(short)0,(short)0,(String)"",(short)0,(String)"",(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridfactura_facturaproductoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtProductoNombre_Internalname,StringUtil.RTrim( A2ProductoNombre),(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtProductoNombre_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(short)-1,(int)edtProductoNombre_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)20,(short)0,(short)0,(short)58,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridfactura_facturaproductoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtProductoPrecio_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A3ProductoPrecio), 4, 0, ".", "")),((edtProductoPrecio_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A3ProductoPrecio), "ZZZ9")) : context.localUtil.Format( (decimal)(A3ProductoPrecio), "ZZZ9")),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtProductoPrecio_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(short)-1,(int)edtProductoPrecio_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)4,(short)0,(short)0,(short)58,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_3_" + sGXsfl_58_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 62,'',false,'" + sGXsfl_58_idx + "',58)\"";
         ROClassString = "Attribute";
         Gridfactura_facturaproductoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtFacturaProductoCantidad_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A7FacturaProductoCantidad), 4, 0, ".", "")),((edtFacturaProductoCantidad_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A7FacturaProductoCantidad), "ZZZ9")) : context.localUtil.Format( (decimal)(A7FacturaProductoCantidad), "ZZZ9")),TempTags+" onchange=\"gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,62);\"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtFacturaProductoCantidad_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(short)-1,(int)edtFacturaProductoCantidad_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)4,(short)0,(short)0,(short)58,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridfactura_facturaproductoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtFacturaProductoTotal_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A8FacturaProductoTotal), 4, 0, ".", "")),((edtFacturaProductoTotal_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A8FacturaProductoTotal), "ZZZ9")) : context.localUtil.Format( (decimal)(A8FacturaProductoTotal), "ZZZ9")),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtFacturaProductoTotal_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(short)-1,(int)edtFacturaProductoTotal_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)4,(short)0,(short)0,(short)58,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false});
         context.httpAjaxContext.ajax_sending_grid_row(Gridfactura_facturaproductoRow);
         GXCCtl = "Z1ProductoId_" + sGXsfl_58_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1ProductoId), 4, 0, ".", "")));
         GXCCtl = "Z7FacturaProductoCantidad_" + sGXsfl_58_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7FacturaProductoCantidad), 4, 0, ".", "")));
         GXCCtl = "O8FacturaProductoTotal_" + sGXsfl_58_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(O8FacturaProductoTotal), 4, 0, ".", "")));
         GXCCtl = "nRcdDeleted_3_" + sGXsfl_58_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_3), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_3_" + sGXsfl_58_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_3), 4, 0, ".", "")));
         GXCCtl = "nIsMod_3_" + sGXsfl_58_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_3), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTOID_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTONOMBRE_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoNombre_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTOPRECIO_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoPrecio_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FACTURAPRODUCTOCANTIDAD_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtFacturaProductoCantidad_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FACTURAPRODUCTOTOTAL_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtFacturaProductoTotal_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_1_"+sGXsfl_58_idx+"Link", StringUtil.RTrim( imgprompt_1_Link));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridfactura_facturaproductoContainer.AddRow(Gridfactura_facturaproductoRow);
      }

      protected void ReadRow023( )
      {
         nGXsfl_58_idx = (short)(nGXsfl_58_idx+1);
         sGXsfl_58_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_58_idx), 4, 0)), 4, "0");
         SubsflControlProps_583( ) ;
         edtProductoId_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUCTOID_"+sGXsfl_58_idx+"Enabled"), ".", ","));
         edtProductoNombre_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUCTONOMBRE_"+sGXsfl_58_idx+"Enabled"), ".", ","));
         edtProductoPrecio_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUCTOPRECIO_"+sGXsfl_58_idx+"Enabled"), ".", ","));
         edtFacturaProductoCantidad_Enabled = (int)(context.localUtil.CToN( cgiGet( "FACTURAPRODUCTOCANTIDAD_"+sGXsfl_58_idx+"Enabled"), ".", ","));
         edtFacturaProductoTotal_Enabled = (int)(context.localUtil.CToN( cgiGet( "FACTURAPRODUCTOTOTAL_"+sGXsfl_58_idx+"Enabled"), ".", ","));
         imgprompt_9_Link = cgiGet( "PROMPT_1_"+sGXsfl_58_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtProductoId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductoId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "PRODUCTOID_" + sGXsfl_58_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductoId_Internalname;
            wbErr = true;
            A1ProductoId = 0;
         }
         else
         {
            A1ProductoId = (short)(context.localUtil.CToN( cgiGet( edtProductoId_Internalname), ".", ","));
         }
         A2ProductoNombre = cgiGet( edtProductoNombre_Internalname);
         A3ProductoPrecio = (short)(context.localUtil.CToN( cgiGet( edtProductoPrecio_Internalname), ".", ","));
         if ( ( ( context.localUtil.CToN( cgiGet( edtFacturaProductoCantidad_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFacturaProductoCantidad_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "FACTURAPRODUCTOCANTIDAD_" + sGXsfl_58_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtFacturaProductoCantidad_Internalname;
            wbErr = true;
            A7FacturaProductoCantidad = 0;
         }
         else
         {
            A7FacturaProductoCantidad = (short)(context.localUtil.CToN( cgiGet( edtFacturaProductoCantidad_Internalname), ".", ","));
         }
         A8FacturaProductoTotal = (short)(context.localUtil.CToN( cgiGet( edtFacturaProductoTotal_Internalname), ".", ","));
         GXCCtl = "Z1ProductoId_" + sGXsfl_58_idx;
         Z1ProductoId = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "Z7FacturaProductoCantidad_" + sGXsfl_58_idx;
         Z7FacturaProductoCantidad = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "O8FacturaProductoTotal_" + sGXsfl_58_idx;
         O8FacturaProductoTotal = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdDeleted_3_" + sGXsfl_58_idx;
         nRcdDeleted_3 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdExists_3_" + sGXsfl_58_idx;
         nRcdExists_3 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nIsMod_3_" + sGXsfl_58_idx;
         nIsMod_3 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
      }

      protected void assign_properties_default( )
      {
         defedtProductoId_Enabled = edtProductoId_Enabled;
      }

      protected void ConfirmValues020( )
      {
         nGXsfl_58_idx = 0;
         sGXsfl_58_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_58_idx), 4, 0)), 4, "0");
         SubsflControlProps_583( ) ;
         while ( nGXsfl_58_idx < nRC_GXsfl_58 )
         {
            nGXsfl_58_idx = (short)(nGXsfl_58_idx+1);
            sGXsfl_58_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_58_idx), 4, 0)), 4, "0");
            SubsflControlProps_583( ) ;
            ChangePostValue( "Z1ProductoId_"+sGXsfl_58_idx, cgiGet( "ZT_"+"Z1ProductoId_"+sGXsfl_58_idx)) ;
            DeletePostValue( "ZT_"+"Z1ProductoId_"+sGXsfl_58_idx) ;
            ChangePostValue( "Z7FacturaProductoCantidad_"+sGXsfl_58_idx, cgiGet( "ZT_"+"Z7FacturaProductoCantidad_"+sGXsfl_58_idx)) ;
            DeletePostValue( "ZT_"+"Z7FacturaProductoCantidad_"+sGXsfl_58_idx) ;
         }
         ChangePostValue( "O8FacturaProductoTotal", cgiGet( "T8FacturaProductoTotal")) ;
         DeletePostValue( "T8FacturaProductoTotal") ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         MasterPageObj.master_styles();
         if ( ( context.GetBrowserType( ) == 1 ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 116888), false);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 116888), false);
         context.AddJavascriptSource("gxtimezone.js", "?"+context.GetBuildNumber( 116888), false);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 116888), false);
         context.AddJavascriptSource("gxcfg.js", "?20179212091632", false);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 116888), false);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 116888), false);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 116888), false);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle = bodyStyle + ";-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle = bodyStyle + " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("factura.aspx") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" style=\"display:none\">") ;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         GxWebStd.gx_hidden_field( context, "Z4FacturaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z4FacturaId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z5FacturaFecha", context.localUtil.DToC( Z5FacturaFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z9ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9ClienteId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "O6FacturaTotal", StringUtil.LTrim( StringUtil.NToC( (decimal)(O6FacturaTotal), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_58", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_58_idx), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GXKey = Crypto.Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override String GetSelfLink( )
      {
         return formatLink("factura.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "Factura" ;
      }

      public override String GetPgmdesc( )
      {
         return "Factura" ;
      }

      protected void InitializeNonKey022( )
      {
         A6FacturaTotal = 0;
         n6FacturaTotal = false;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
         A10ClienteNombre = "";
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A10ClienteNombre", A10ClienteNombre);
         A5FacturaFecha = Gx_date;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A5FacturaFecha", context.localUtil.Format(A5FacturaFecha, "99/99/99"));
         A9ClienteId = 1;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9ClienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9ClienteId), 4, 0)));
         O6FacturaTotal = A6FacturaTotal;
         n6FacturaTotal = false;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6FacturaTotal", StringUtil.LTrim( StringUtil.Str( (decimal)(A6FacturaTotal), 4, 0)));
         Z5FacturaFecha = DateTime.MinValue;
         Z9ClienteId = 0;
      }

      protected void InitAll022( )
      {
         A4FacturaId = 0;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A4FacturaId", StringUtil.LTrim( StringUtil.Str( (decimal)(A4FacturaId), 4, 0)));
         InitializeNonKey022( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A9ClienteId = i9ClienteId;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9ClienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9ClienteId), 4, 0)));
         A5FacturaFecha = i5FacturaFecha;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A5FacturaFecha", context.localUtil.Format(A5FacturaFecha, "99/99/99"));
      }

      protected void InitializeNonKey023( )
      {
         A8FacturaProductoTotal = 0;
         A2ProductoNombre = "";
         A3ProductoPrecio = 0;
         A7FacturaProductoCantidad = 0;
         O8FacturaProductoTotal = A8FacturaProductoTotal;
         Z7FacturaProductoCantidad = 0;
      }

      protected void InitAll023( )
      {
         A1ProductoId = 0;
         InitializeNonKey023( ) ;
      }

      protected void StandaloneModalInsert023( )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( ) ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?20179212091637", true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.eng.js", "?"+context.GetBuildNumber( 116888), false);
         context.AddJavascriptSource("factura.js", "?20179212091637", false);
         /* End function include_jscripts */
      }

      protected void init_level_properties3( )
      {
         edtProductoId_Enabled = defedtProductoId_Enabled;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtProductoId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtProductoId_Enabled), 5, 0)), !bGXsfl_58_Refreshing);
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtFacturaId_Internalname = "FACTURAID";
         edtFacturaFecha_Internalname = "FACTURAFECHA";
         edtFacturaTotal_Internalname = "FACTURATOTAL";
         edtClienteId_Internalname = "CLIENTEID";
         edtClienteNombre_Internalname = "CLIENTENOMBRE";
         lblTitlefacturaproducto_Internalname = "TITLEFACTURAPRODUCTO";
         edtProductoId_Internalname = "PRODUCTOID";
         edtProductoNombre_Internalname = "PRODUCTONOMBRE";
         edtProductoPrecio_Internalname = "PRODUCTOPRECIO";
         edtFacturaProductoCantidad_Internalname = "FACTURAPRODUCTOCANTIDAD";
         edtFacturaProductoTotal_Internalname = "FACTURAPRODUCTOTOTAL";
         divFacturaproductotable_Internalname = "FACTURAPRODUCTOTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_9_Internalname = "PROMPT_9";
         imgprompt_1_Internalname = "PROMPT_1";
         subGridfactura_facturaproducto_Internalname = "GRIDFACTURA_FACTURAPRODUCTO";
      }

      public override void initialize_properties( )
      {
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Factura";
         edtFacturaProductoTotal_Jsonclick = "";
         edtFacturaProductoCantidad_Jsonclick = "";
         edtProductoPrecio_Jsonclick = "";
         edtProductoNombre_Jsonclick = "";
         imgprompt_1_Visible = 1;
         imgprompt_1_Link = "";
         imgprompt_9_Visible = 1;
         edtProductoId_Jsonclick = "";
         subGridfactura_facturaproducto_Class = "Grid";
         subGridfactura_facturaproducto_Backcolorstyle = 0;
         subGridfactura_facturaproducto_Allowcollapsing = 0;
         subGridfactura_facturaproducto_Allowselection = 0;
         edtFacturaProductoTotal_Enabled = 0;
         edtFacturaProductoCantidad_Enabled = 1;
         edtProductoPrecio_Enabled = 0;
         edtProductoNombre_Enabled = 0;
         edtProductoId_Enabled = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtClienteNombre_Jsonclick = "";
         edtClienteNombre_Enabled = 0;
         imgprompt_9_Visible = 1;
         imgprompt_9_Link = "";
         edtClienteId_Jsonclick = "";
         edtClienteId_Enabled = 1;
         edtFacturaTotal_Jsonclick = "";
         edtFacturaTotal_Enabled = 0;
         edtFacturaFecha_Jsonclick = "";
         edtFacturaFecha_Enabled = 1;
         edtFacturaId_Jsonclick = "";
         edtFacturaId_Enabled = 1;
         edtFacturaId_Visible = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridfactura_facturaproducto_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_583( ) ;
         while ( nGXsfl_58_idx <= nRC_GXsfl_58 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal023( ) ;
            standaloneModal023( ) ;
            dynload_actions( ) ;
            SendRow023( ) ;
            nGXsfl_58_idx = (short)(nGXsfl_58_idx+1);
            sGXsfl_58_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_58_idx), 4, 0)), 4, "0");
            SubsflControlProps_583( ) ;
         }
         context.GX_webresponse.AddString(Gridfactura_facturaproductoContainer.ToJavascriptSource());
         /* End function gxnrGridfactura_facturaproducto_newrow */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "IsConfirmed", StringUtil.LTrim( StringUtil.Str( (decimal)(IsConfirmed), 4, 0)));
         getEqualNoModal( ) ;
         GX_FocusControl = edtFacturaFecha_Internalname;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
      }

      public void Valid_Facturaid( short GX_Parm1 ,
                                   DateTime GX_Parm2 ,
                                   short GX_Parm3 ,
                                   short GX_Parm4 )
      {
         A4FacturaId = GX_Parm1;
         A5FacturaFecha = GX_Parm2;
         A9ClienteId = GX_Parm3;
         A6FacturaTotal = GX_Parm4;
         n6FacturaTotal = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
         /* Using cursor T000222 */
         pr_default.execute(16, new Object[] {A4FacturaId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            A6FacturaTotal = T000222_A6FacturaTotal[0];
            n6FacturaTotal = T000222_n6FacturaTotal[0];
         }
         else
         {
            A6FacturaTotal = 0;
            n6FacturaTotal = false;
         }
         pr_default.close(16);
         dynload_actions( ) ;
         if ( AnyError == 1 )
         {
            A6FacturaTotal = 0;
            n6FacturaTotal = false;
            A10ClienteNombre = "";
         }
         isValidOutput.Add(context.localUtil.Format(A5FacturaFecha, "99/99/99"));
         isValidOutput.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(A9ClienteId), 4, 0, ".", "")));
         isValidOutput.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(A6FacturaTotal), 4, 0, ".", "")));
         isValidOutput.Add(StringUtil.RTrim( A10ClienteNombre));
         isValidOutput.Add(StringUtil.RTrim( Gx_mode));
         isValidOutput.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(Z4FacturaId), 4, 0, ".", "")));
         isValidOutput.Add(context.localUtil.DToC( Z5FacturaFecha, 0, "/"));
         isValidOutput.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9ClienteId), 4, 0, ".", "")));
         isValidOutput.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(Z6FacturaTotal), 4, 0, ".", "")));
         isValidOutput.Add(StringUtil.RTrim( Z10ClienteNombre));
         isValidOutput.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(O6FacturaTotal), 4, 0, ".", "")));
         isValidOutput.Add(Gridfactura_facturaproductoContainer);
         isValidOutput.Add(bttBtn_delete_Enabled);
         isValidOutput.Add(bttBtn_enter_Enabled);
         isValidOutput.Add(context.GX_msglist.ToJavascriptSource());
         isValidOutput.Add(context.httpAjaxContext.ajax_rsp_get_hiddens( ));
         context.GX_webresponse.AddString(isValidOutput.ToJSonString());
         wbTemp = context.ResponseContentType( "application/json");
      }

      public void Valid_Clienteid( short GX_Parm1 ,
                                   String GX_Parm2 )
      {
         A9ClienteId = GX_Parm1;
         A10ClienteNombre = GX_Parm2;
         /* Using cursor T000223 */
         pr_default.execute(17, new Object[] {A9ClienteId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No matching 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
            AnyError = 1;
            GX_FocusControl = edtClienteId_Internalname;
         }
         A10ClienteNombre = T000223_A10ClienteNombre[0];
         pr_default.close(17);
         dynload_actions( ) ;
         if ( AnyError == 1 )
         {
            A10ClienteNombre = "";
         }
         isValidOutput.Add(StringUtil.RTrim( A10ClienteNombre));
         isValidOutput.Add(context.GX_msglist.ToJavascriptSource());
         isValidOutput.Add(context.httpAjaxContext.ajax_rsp_get_hiddens( ));
         context.GX_webresponse.AddString(isValidOutput.ToJSonString());
         wbTemp = context.ResponseContentType( "application/json");
      }

      public void Valid_Productoid( short GX_Parm1 ,
                                    String GX_Parm2 ,
                                    short GX_Parm3 )
      {
         A1ProductoId = GX_Parm1;
         A2ProductoNombre = GX_Parm2;
         A3ProductoPrecio = GX_Parm3;
         /* Using cursor T000231 */
         pr_default.execute(25, new Object[] {A1ProductoId});
         if ( (pr_default.getStatus(25) == 101) )
         {
            GX_msglist.addItem("No matching 'Producto'.", "ForeignKeyNotFound", 1, "PRODUCTOID");
            AnyError = 1;
            GX_FocusControl = edtProductoId_Internalname;
         }
         A2ProductoNombre = T000231_A2ProductoNombre[0];
         A3ProductoPrecio = T000231_A3ProductoPrecio[0];
         pr_default.close(25);
         dynload_actions( ) ;
         if ( AnyError == 1 )
         {
            A2ProductoNombre = "";
            A3ProductoPrecio = 0;
         }
         isValidOutput.Add(StringUtil.RTrim( A2ProductoNombre));
         isValidOutput.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(A3ProductoPrecio), 4, 0, ".", "")));
         isValidOutput.Add(context.GX_msglist.ToJavascriptSource());
         isValidOutput.Add(context.httpAjaxContext.ajax_rsp_get_hiddens( ));
         context.GX_webresponse.AddString(isValidOutput.ToJSonString());
         wbTemp = context.ResponseContentType( "application/json");
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true}],oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[],oparms:[]}");
         return  ;
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections() ;
         }
      }

      protected void CloseOpenCursors( )
      {
         pr_default.close(1);
         pr_default.close(25);
         pr_default.close(4);
         pr_default.close(17);
         pr_default.close(16);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z5FacturaFecha = DateTime.MinValue;
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A5FacturaFecha = DateTime.MinValue;
         sImgUrl = "";
         A10ClienteNombre = "";
         lblTitlefacturaproducto_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridfactura_facturaproductoContainer = new GXWebGrid( context);
         Gridfactura_facturaproductoColumn = new GXWebColumn();
         A2ProductoNombre = "";
         Gx_mode = "";
         sMode3 = "";
         sStyleString = "";
         Gx_date = DateTime.MinValue;
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXCCtl = "";
         Z10ClienteNombre = "";
         T00027_A10ClienteNombre = new String[] {""} ;
         T000211_A4FacturaId = new short[1] ;
         T000211_A5FacturaFecha = new DateTime[] {DateTime.MinValue} ;
         T000211_A10ClienteNombre = new String[] {""} ;
         T000211_A9ClienteId = new short[1] ;
         T000211_A6FacturaTotal = new short[1] ;
         T000211_n6FacturaTotal = new bool[] {false} ;
         T00029_A6FacturaTotal = new short[1] ;
         T00029_n6FacturaTotal = new bool[] {false} ;
         T000213_A6FacturaTotal = new short[1] ;
         T000213_n6FacturaTotal = new bool[] {false} ;
         T000214_A10ClienteNombre = new String[] {""} ;
         T000215_A4FacturaId = new short[1] ;
         T00026_A4FacturaId = new short[1] ;
         T00026_A5FacturaFecha = new DateTime[] {DateTime.MinValue} ;
         T00026_A9ClienteId = new short[1] ;
         sMode2 = "";
         T000216_A4FacturaId = new short[1] ;
         T000217_A4FacturaId = new short[1] ;
         T00025_A4FacturaId = new short[1] ;
         T00025_A5FacturaFecha = new DateTime[] {DateTime.MinValue} ;
         T00025_A9ClienteId = new short[1] ;
         T000218_A4FacturaId = new short[1] ;
         T000222_A6FacturaTotal = new short[1] ;
         T000222_n6FacturaTotal = new bool[] {false} ;
         T000223_A10ClienteNombre = new String[] {""} ;
         T000224_A4FacturaId = new short[1] ;
         Z2ProductoNombre = "";
         T000225_A4FacturaId = new short[1] ;
         T000225_A2ProductoNombre = new String[] {""} ;
         T000225_A3ProductoPrecio = new short[1] ;
         T000225_A7FacturaProductoCantidad = new short[1] ;
         T000225_A1ProductoId = new short[1] ;
         T00024_A2ProductoNombre = new String[] {""} ;
         T00024_A3ProductoPrecio = new short[1] ;
         T000226_A2ProductoNombre = new String[] {""} ;
         T000226_A3ProductoPrecio = new short[1] ;
         T000227_A4FacturaId = new short[1] ;
         T000227_A1ProductoId = new short[1] ;
         T00023_A4FacturaId = new short[1] ;
         T00023_A7FacturaProductoCantidad = new short[1] ;
         T00023_A1ProductoId = new short[1] ;
         T00022_A4FacturaId = new short[1] ;
         T00022_A7FacturaProductoCantidad = new short[1] ;
         T00022_A1ProductoId = new short[1] ;
         T000231_A2ProductoNombre = new String[] {""} ;
         T000231_A3ProductoPrecio = new short[1] ;
         T000232_A4FacturaId = new short[1] ;
         T000232_A1ProductoId = new short[1] ;
         Gridfactura_facturaproductoRow = new GXWebRow();
         subGridfactura_facturaproducto_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i5FacturaFecha = DateTime.MinValue;
         isValidOutput = new GxUnknownObjectCollection();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.factura__default(),
            new Object[][] {
                new Object[] {
               T00022_A4FacturaId, T00022_A7FacturaProductoCantidad, T00022_A1ProductoId
               }
               , new Object[] {
               T00023_A4FacturaId, T00023_A7FacturaProductoCantidad, T00023_A1ProductoId
               }
               , new Object[] {
               T00024_A2ProductoNombre, T00024_A3ProductoPrecio
               }
               , new Object[] {
               T00025_A4FacturaId, T00025_A5FacturaFecha, T00025_A9ClienteId
               }
               , new Object[] {
               T00026_A4FacturaId, T00026_A5FacturaFecha, T00026_A9ClienteId
               }
               , new Object[] {
               T00027_A10ClienteNombre
               }
               , new Object[] {
               T00029_A6FacturaTotal, T00029_n6FacturaTotal
               }
               , new Object[] {
               T000211_A4FacturaId, T000211_A5FacturaFecha, T000211_A10ClienteNombre, T000211_A9ClienteId, T000211_A6FacturaTotal, T000211_n6FacturaTotal
               }
               , new Object[] {
               T000213_A6FacturaTotal, T000213_n6FacturaTotal
               }
               , new Object[] {
               T000214_A10ClienteNombre
               }
               , new Object[] {
               T000215_A4FacturaId
               }
               , new Object[] {
               T000216_A4FacturaId
               }
               , new Object[] {
               T000217_A4FacturaId
               }
               , new Object[] {
               T000218_A4FacturaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000222_A6FacturaTotal, T000222_n6FacturaTotal
               }
               , new Object[] {
               T000223_A10ClienteNombre
               }
               , new Object[] {
               T000224_A4FacturaId
               }
               , new Object[] {
               T000225_A4FacturaId, T000225_A2ProductoNombre, T000225_A3ProductoPrecio, T000225_A7FacturaProductoCantidad, T000225_A1ProductoId
               }
               , new Object[] {
               T000226_A2ProductoNombre, T000226_A3ProductoPrecio
               }
               , new Object[] {
               T000227_A4FacturaId, T000227_A1ProductoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000231_A2ProductoNombre, T000231_A3ProductoPrecio
               }
               , new Object[] {
               T000232_A4FacturaId, T000232_A1ProductoId
               }
            }
         );
         Z9ClienteId = 1;
         i9ClienteId = 1;
         A9ClienteId = 1;
         Z5FacturaFecha = DateTime.MinValue;
         A5FacturaFecha = DateTime.MinValue;
         i5FacturaFecha = DateTime.MinValue;
         Gx_date = DateTimeUtil.Today( context);
      }

      private short nIsMod_3 ;
      private short Z4FacturaId ;
      private short Z9ClienteId ;
      private short O6FacturaTotal ;
      private short nRC_GXsfl_58 ;
      private short nGXsfl_58_idx=1 ;
      private short Z1ProductoId ;
      private short Z7FacturaProductoCantidad ;
      private short O8FacturaProductoTotal ;
      private short nRcdDeleted_3 ;
      private short nRcdExists_3 ;
      private short GxWebError ;
      private short A4FacturaId ;
      private short A9ClienteId ;
      private short A1ProductoId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A6FacturaTotal ;
      private short subGridfactura_facturaproducto_Backcolorstyle ;
      private short A3ProductoPrecio ;
      private short A7FacturaProductoCantidad ;
      private short A8FacturaProductoTotal ;
      private short subGridfactura_facturaproducto_Allowselection ;
      private short subGridfactura_facturaproducto_Allowhovering ;
      private short subGridfactura_facturaproducto_Allowcollapsing ;
      private short subGridfactura_facturaproducto_Collapsed ;
      private short nBlankRcdCount3 ;
      private short RcdFound3 ;
      private short B6FacturaTotal ;
      private short nBlankRcdUsr3 ;
      private short Gx_BScreen ;
      private short s6FacturaTotal ;
      private short T8FacturaProductoTotal ;
      private short GX_JID ;
      private short Z6FacturaTotal ;
      private short RcdFound2 ;
      private short Z3ProductoPrecio ;
      private short subGridfactura_facturaproducto_Backstyle ;
      private short gxajaxcallmode ;
      private short i9ClienteId ;
      private short wbTemp ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtFacturaId_Enabled ;
      private int edtFacturaId_Visible ;
      private int edtFacturaFecha_Enabled ;
      private int edtFacturaTotal_Enabled ;
      private int edtClienteId_Enabled ;
      private int imgprompt_9_Visible ;
      private int edtClienteNombre_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtProductoId_Enabled ;
      private int edtProductoNombre_Enabled ;
      private int edtProductoPrecio_Enabled ;
      private int edtFacturaProductoCantidad_Enabled ;
      private int edtFacturaProductoTotal_Enabled ;
      private int subGridfactura_facturaproducto_Selectioncolor ;
      private int subGridfactura_facturaproducto_Hoveringcolor ;
      private int fRowAdded ;
      private int subGridfactura_facturaproducto_Backcolor ;
      private int subGridfactura_facturaproducto_Allbackcolor ;
      private int imgprompt_1_Visible ;
      private int defedtProductoId_Enabled ;
      private int idxLst ;
      private long GRIDFACTURA_FACTURAPRODUCTO_nFirstRecordOnPage ;
      private String sPrefix ;
      private String sGXsfl_58_idx="0001" ;
      private String scmdbuf ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String GXKey ;
      private String PreviousTooltip ;
      private String PreviousCaption ;
      private String GX_FocusControl ;
      private String edtFacturaId_Internalname ;
      private String divMaintable_Internalname ;
      private String divTitlecontainer_Internalname ;
      private String lblTitle_Internalname ;
      private String lblTitle_Jsonclick ;
      private String ClassString ;
      private String StyleString ;
      private String divFormcontainer_Internalname ;
      private String divToolbarcell_Internalname ;
      private String TempTags ;
      private String bttBtn_first_Internalname ;
      private String bttBtn_first_Jsonclick ;
      private String bttBtn_previous_Internalname ;
      private String bttBtn_previous_Jsonclick ;
      private String bttBtn_next_Internalname ;
      private String bttBtn_next_Jsonclick ;
      private String bttBtn_last_Internalname ;
      private String bttBtn_last_Jsonclick ;
      private String bttBtn_select_Internalname ;
      private String bttBtn_select_Jsonclick ;
      private String edtFacturaId_Jsonclick ;
      private String edtFacturaFecha_Internalname ;
      private String edtFacturaFecha_Jsonclick ;
      private String edtFacturaTotal_Internalname ;
      private String edtFacturaTotal_Jsonclick ;
      private String edtClienteId_Internalname ;
      private String edtClienteId_Jsonclick ;
      private String sImgUrl ;
      private String imgprompt_9_Internalname ;
      private String imgprompt_9_Link ;
      private String edtClienteNombre_Internalname ;
      private String A10ClienteNombre ;
      private String edtClienteNombre_Jsonclick ;
      private String divFacturaproductotable_Internalname ;
      private String lblTitlefacturaproducto_Internalname ;
      private String lblTitlefacturaproducto_Jsonclick ;
      private String bttBtn_enter_Internalname ;
      private String bttBtn_enter_Jsonclick ;
      private String bttBtn_cancel_Internalname ;
      private String bttBtn_cancel_Jsonclick ;
      private String bttBtn_delete_Internalname ;
      private String bttBtn_delete_Jsonclick ;
      private String A2ProductoNombre ;
      private String Gx_mode ;
      private String sMode3 ;
      private String edtProductoId_Internalname ;
      private String edtProductoNombre_Internalname ;
      private String edtProductoPrecio_Internalname ;
      private String edtFacturaProductoCantidad_Internalname ;
      private String edtFacturaProductoTotal_Internalname ;
      private String sStyleString ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String GXCCtl ;
      private String Z10ClienteNombre ;
      private String sMode2 ;
      private String Z2ProductoNombre ;
      private String imgprompt_1_Internalname ;
      private String sGXsfl_58_fel_idx="0001" ;
      private String subGridfactura_facturaproducto_Class ;
      private String subGridfactura_facturaproducto_Linesclass ;
      private String imgprompt_1_Link ;
      private String ROClassString ;
      private String edtProductoId_Jsonclick ;
      private String edtProductoNombre_Jsonclick ;
      private String edtProductoPrecio_Jsonclick ;
      private String edtFacturaProductoCantidad_Jsonclick ;
      private String edtFacturaProductoTotal_Jsonclick ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String subGridfactura_facturaproducto_Internalname ;
      private DateTime Z5FacturaFecha ;
      private DateTime A5FacturaFecha ;
      private DateTime Gx_date ;
      private DateTime i5FacturaFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n6FacturaTotal ;
      private bool bGXsfl_58_Refreshing=false ;
      private GxUnknownObjectCollection isValidOutput ;
      private GXWebGrid Gridfactura_facturaproductoContainer ;
      private GXWebRow Gridfactura_facturaproductoRow ;
      private GXWebColumn Gridfactura_facturaproductoColumn ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private String[] T00027_A10ClienteNombre ;
      private short[] T000211_A4FacturaId ;
      private DateTime[] T000211_A5FacturaFecha ;
      private String[] T000211_A10ClienteNombre ;
      private short[] T000211_A9ClienteId ;
      private short[] T000211_A6FacturaTotal ;
      private bool[] T000211_n6FacturaTotal ;
      private short[] T00029_A6FacturaTotal ;
      private bool[] T00029_n6FacturaTotal ;
      private short[] T000213_A6FacturaTotal ;
      private bool[] T000213_n6FacturaTotal ;
      private String[] T000214_A10ClienteNombre ;
      private short[] T000215_A4FacturaId ;
      private short[] T00026_A4FacturaId ;
      private DateTime[] T00026_A5FacturaFecha ;
      private short[] T00026_A9ClienteId ;
      private short[] T000216_A4FacturaId ;
      private short[] T000217_A4FacturaId ;
      private short[] T00025_A4FacturaId ;
      private DateTime[] T00025_A5FacturaFecha ;
      private short[] T00025_A9ClienteId ;
      private short[] T000218_A4FacturaId ;
      private short[] T000222_A6FacturaTotal ;
      private bool[] T000222_n6FacturaTotal ;
      private String[] T000223_A10ClienteNombre ;
      private short[] T000224_A4FacturaId ;
      private short[] T000225_A4FacturaId ;
      private String[] T000225_A2ProductoNombre ;
      private short[] T000225_A3ProductoPrecio ;
      private short[] T000225_A7FacturaProductoCantidad ;
      private short[] T000225_A1ProductoId ;
      private String[] T00024_A2ProductoNombre ;
      private short[] T00024_A3ProductoPrecio ;
      private String[] T000226_A2ProductoNombre ;
      private short[] T000226_A3ProductoPrecio ;
      private short[] T000227_A4FacturaId ;
      private short[] T000227_A1ProductoId ;
      private short[] T00023_A4FacturaId ;
      private short[] T00023_A7FacturaProductoCantidad ;
      private short[] T00023_A1ProductoId ;
      private short[] T00022_A4FacturaId ;
      private short[] T00022_A7FacturaProductoCantidad ;
      private short[] T00022_A1ProductoId ;
      private String[] T000231_A2ProductoNombre ;
      private short[] T000231_A3ProductoPrecio ;
      private short[] T000232_A4FacturaId ;
      private short[] T000232_A1ProductoId ;
      private GXWebForm Form ;
   }

   public class factura__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new UpdateCursor(def[14])
         ,new UpdateCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new UpdateCursor(def[22])
         ,new UpdateCursor(def[23])
         ,new UpdateCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000211 ;
          prmT000211 = new Object[] {
          new Object[] {"@FacturaId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT00029 ;
          prmT00029 = new Object[] {
          new Object[] {"@FacturaId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT00027 ;
          prmT00027 = new Object[] {
          new Object[] {"@ClienteId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000213 ;
          prmT000213 = new Object[] {
          new Object[] {"@FacturaId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000214 ;
          prmT000214 = new Object[] {
          new Object[] {"@ClienteId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000215 ;
          prmT000215 = new Object[] {
          new Object[] {"@FacturaId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT00026 ;
          prmT00026 = new Object[] {
          new Object[] {"@FacturaId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000216 ;
          prmT000216 = new Object[] {
          new Object[] {"@FacturaId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000217 ;
          prmT000217 = new Object[] {
          new Object[] {"@FacturaId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT00025 ;
          prmT00025 = new Object[] {
          new Object[] {"@FacturaId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000218 ;
          prmT000218 = new Object[] {
          new Object[] {"@FacturaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@ClienteId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000219 ;
          prmT000219 = new Object[] {
          new Object[] {"@FacturaFecha",SqlDbType.DateTime,8,0} ,
          new Object[] {"@ClienteId",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@FacturaId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000220 ;
          prmT000220 = new Object[] {
          new Object[] {"@FacturaId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000224 ;
          prmT000224 = new Object[] {
          } ;
          Object[] prmT000225 ;
          prmT000225 = new Object[] {
          new Object[] {"@FacturaId",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@ProductoId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT00024 ;
          prmT00024 = new Object[] {
          new Object[] {"@ProductoId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000226 ;
          prmT000226 = new Object[] {
          new Object[] {"@ProductoId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000227 ;
          prmT000227 = new Object[] {
          new Object[] {"@FacturaId",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@ProductoId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT00023 ;
          prmT00023 = new Object[] {
          new Object[] {"@FacturaId",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@ProductoId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT00022 ;
          prmT00022 = new Object[] {
          new Object[] {"@FacturaId",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@ProductoId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000228 ;
          prmT000228 = new Object[] {
          new Object[] {"@FacturaId",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@FacturaProductoCantidad",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@ProductoId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000229 ;
          prmT000229 = new Object[] {
          new Object[] {"@FacturaProductoCantidad",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@FacturaId",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@ProductoId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000230 ;
          prmT000230 = new Object[] {
          new Object[] {"@FacturaId",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@ProductoId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000232 ;
          prmT000232 = new Object[] {
          new Object[] {"@FacturaId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000222 ;
          prmT000222 = new Object[] {
          new Object[] {"@FacturaId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000223 ;
          prmT000223 = new Object[] {
          new Object[] {"@ClienteId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000231 ;
          prmT000231 = new Object[] {
          new Object[] {"@ProductoId",SqlDbType.SmallInt,4,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("T00022", "SELECT [FacturaId], [FacturaProductoCantidad], [ProductoId] FROM [FacturaFacturaProducto] WITH (UPDLOCK) WHERE [FacturaId] = @FacturaId AND [ProductoId] = @ProductoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00022,1,0,true,false )
             ,new CursorDef("T00023", "SELECT [FacturaId], [FacturaProductoCantidad], [ProductoId] FROM [FacturaFacturaProducto] WITH (NOLOCK) WHERE [FacturaId] = @FacturaId AND [ProductoId] = @ProductoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00023,1,0,true,false )
             ,new CursorDef("T00024", "SELECT [ProductoNombre], [ProductoPrecio] FROM [Producto] WITH (NOLOCK) WHERE [ProductoId] = @ProductoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00024,1,0,true,false )
             ,new CursorDef("T00025", "SELECT [FacturaId], [FacturaFecha], [ClienteId] FROM [Factura] WITH (UPDLOCK) WHERE [FacturaId] = @FacturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00025,1,0,true,false )
             ,new CursorDef("T00026", "SELECT [FacturaId], [FacturaFecha], [ClienteId] FROM [Factura] WITH (NOLOCK) WHERE [FacturaId] = @FacturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00026,1,0,true,false )
             ,new CursorDef("T00027", "SELECT [ClienteNombre] FROM [Cliente] WITH (NOLOCK) WHERE [ClienteId] = @ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00027,1,0,true,false )
             ,new CursorDef("T00029", "SELECT COALESCE( T1.[FacturaTotal], 0) AS FacturaTotal FROM (SELECT SUM(CASE  WHEN T2.[ProductoId] = 1 THEN T3.[ProductoPrecio] * CAST(T2.[FacturaProductoCantidad] AS decimal( 14, 10)) * CAST(0.9 AS decimal( 14, 10)) WHEN T2.[ProductoId] = 2 THEN T3.[ProductoPrecio] * CAST(T2.[FacturaProductoCantidad] AS decimal( 14, 10)) * CAST(0.8 AS decimal( 14, 10)) ELSE T3.[ProductoPrecio] * CAST(T2.[FacturaProductoCantidad] AS decimal( 14, 10)) END) AS FacturaTotal, T2.[FacturaId] FROM ([FacturaFacturaProducto] T2 WITH (UPDLOCK) INNER JOIN [Producto] T3 WITH (NOLOCK) ON T3.[ProductoId] = T2.[ProductoId]) GROUP BY T2.[FacturaId] ) T1 WHERE T1.[FacturaId] = @FacturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00029,1,0,true,false )
             ,new CursorDef("T000211", "SELECT TM1.[FacturaId], TM1.[FacturaFecha], T3.[ClienteNombre], TM1.[ClienteId], COALESCE( T2.[FacturaTotal], 0) AS FacturaTotal FROM (([Factura] TM1 WITH (NOLOCK) LEFT JOIN (SELECT SUM(CASE  WHEN T4.[ProductoId] = 1 THEN T5.[ProductoPrecio] * CAST(T4.[FacturaProductoCantidad] AS decimal( 14, 10)) * CAST(0.9 AS decimal( 14, 10)) WHEN T4.[ProductoId] = 2 THEN T5.[ProductoPrecio] * CAST(T4.[FacturaProductoCantidad] AS decimal( 14, 10)) * CAST(0.8 AS decimal( 14, 10)) ELSE T5.[ProductoPrecio] * CAST(T4.[FacturaProductoCantidad] AS decimal( 14, 10)) END) AS FacturaTotal, T4.[FacturaId] FROM ([FacturaFacturaProducto] T4 WITH (NOLOCK) INNER JOIN [Producto] T5 WITH (NOLOCK) ON T5.[ProductoId] = T4.[ProductoId]) GROUP BY T4.[FacturaId] ) T2 ON T2.[FacturaId] = TM1.[FacturaId]) INNER JOIN [Cliente] T3 WITH (NOLOCK) ON T3.[ClienteId] = TM1.[ClienteId]) WHERE TM1.[FacturaId] = @FacturaId ORDER BY TM1.[FacturaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000211,100,0,true,false )
             ,new CursorDef("T000213", "SELECT COALESCE( T1.[FacturaTotal], 0) AS FacturaTotal FROM (SELECT SUM(CASE  WHEN T2.[ProductoId] = 1 THEN T3.[ProductoPrecio] * CAST(T2.[FacturaProductoCantidad] AS decimal( 14, 10)) * CAST(0.9 AS decimal( 14, 10)) WHEN T2.[ProductoId] = 2 THEN T3.[ProductoPrecio] * CAST(T2.[FacturaProductoCantidad] AS decimal( 14, 10)) * CAST(0.8 AS decimal( 14, 10)) ELSE T3.[ProductoPrecio] * CAST(T2.[FacturaProductoCantidad] AS decimal( 14, 10)) END) AS FacturaTotal, T2.[FacturaId] FROM ([FacturaFacturaProducto] T2 WITH (UPDLOCK) INNER JOIN [Producto] T3 WITH (NOLOCK) ON T3.[ProductoId] = T2.[ProductoId]) GROUP BY T2.[FacturaId] ) T1 WHERE T1.[FacturaId] = @FacturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000213,1,0,true,false )
             ,new CursorDef("T000214", "SELECT [ClienteNombre] FROM [Cliente] WITH (NOLOCK) WHERE [ClienteId] = @ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000214,1,0,true,false )
             ,new CursorDef("T000215", "SELECT [FacturaId] FROM [Factura] WITH (NOLOCK) WHERE [FacturaId] = @FacturaId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000215,1,0,true,false )
             ,new CursorDef("T000216", "SELECT TOP 1 [FacturaId] FROM [Factura] WITH (NOLOCK) WHERE ( [FacturaId] > @FacturaId) ORDER BY [FacturaId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000216,1,0,true,true )
             ,new CursorDef("T000217", "SELECT TOP 1 [FacturaId] FROM [Factura] WITH (NOLOCK) WHERE ( [FacturaId] < @FacturaId) ORDER BY [FacturaId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000217,1,0,true,true )
             ,new CursorDef("T000218", "INSERT INTO [Factura]([FacturaFecha], [ClienteId]) VALUES(@FacturaFecha, @ClienteId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000218)
             ,new CursorDef("T000219", "UPDATE [Factura] SET [FacturaFecha]=@FacturaFecha, [ClienteId]=@ClienteId  WHERE [FacturaId] = @FacturaId", GxErrorMask.GX_NOMASK,prmT000219)
             ,new CursorDef("T000220", "DELETE FROM [Factura]  WHERE [FacturaId] = @FacturaId", GxErrorMask.GX_NOMASK,prmT000220)
             ,new CursorDef("T000222", "SELECT COALESCE( T1.[FacturaTotal], 0) AS FacturaTotal FROM (SELECT SUM(CASE  WHEN T2.[ProductoId] = 1 THEN T3.[ProductoPrecio] * CAST(T2.[FacturaProductoCantidad] AS decimal( 14, 10)) * CAST(0.9 AS decimal( 14, 10)) WHEN T2.[ProductoId] = 2 THEN T3.[ProductoPrecio] * CAST(T2.[FacturaProductoCantidad] AS decimal( 14, 10)) * CAST(0.8 AS decimal( 14, 10)) ELSE T3.[ProductoPrecio] * CAST(T2.[FacturaProductoCantidad] AS decimal( 14, 10)) END) AS FacturaTotal, T2.[FacturaId] FROM ([FacturaFacturaProducto] T2 WITH (UPDLOCK) INNER JOIN [Producto] T3 WITH (NOLOCK) ON T3.[ProductoId] = T2.[ProductoId]) GROUP BY T2.[FacturaId] ) T1 WHERE T1.[FacturaId] = @FacturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000222,1,0,true,false )
             ,new CursorDef("T000223", "SELECT [ClienteNombre] FROM [Cliente] WITH (NOLOCK) WHERE [ClienteId] = @ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000223,1,0,true,false )
             ,new CursorDef("T000224", "SELECT [FacturaId] FROM [Factura] WITH (NOLOCK) ORDER BY [FacturaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000224,100,0,true,false )
             ,new CursorDef("T000225", "SELECT T1.[FacturaId], T2.[ProductoNombre], T2.[ProductoPrecio], T1.[FacturaProductoCantidad], T1.[ProductoId] FROM ([FacturaFacturaProducto] T1 WITH (NOLOCK) INNER JOIN [Producto] T2 WITH (NOLOCK) ON T2.[ProductoId] = T1.[ProductoId]) WHERE T1.[FacturaId] = @FacturaId and T1.[ProductoId] = @ProductoId ORDER BY T1.[FacturaId], T1.[ProductoId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000225,11,0,true,false )
             ,new CursorDef("T000226", "SELECT [ProductoNombre], [ProductoPrecio] FROM [Producto] WITH (NOLOCK) WHERE [ProductoId] = @ProductoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000226,1,0,true,false )
             ,new CursorDef("T000227", "SELECT [FacturaId], [ProductoId] FROM [FacturaFacturaProducto] WITH (NOLOCK) WHERE [FacturaId] = @FacturaId AND [ProductoId] = @ProductoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000227,1,0,true,false )
             ,new CursorDef("T000228", "INSERT INTO [FacturaFacturaProducto]([FacturaId], [FacturaProductoCantidad], [ProductoId]) VALUES(@FacturaId, @FacturaProductoCantidad, @ProductoId)", GxErrorMask.GX_NOMASK,prmT000228)
             ,new CursorDef("T000229", "UPDATE [FacturaFacturaProducto] SET [FacturaProductoCantidad]=@FacturaProductoCantidad  WHERE [FacturaId] = @FacturaId AND [ProductoId] = @ProductoId", GxErrorMask.GX_NOMASK,prmT000229)
             ,new CursorDef("T000230", "DELETE FROM [FacturaFacturaProducto]  WHERE [FacturaId] = @FacturaId AND [ProductoId] = @ProductoId", GxErrorMask.GX_NOMASK,prmT000230)
             ,new CursorDef("T000231", "SELECT [ProductoNombre], [ProductoPrecio] FROM [Producto] WITH (NOLOCK) WHERE [ProductoId] = @ProductoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000231,1,0,true,false )
             ,new CursorDef("T000232", "SELECT [FacturaId], [ProductoId] FROM [FacturaFacturaProducto] WITH (NOLOCK) WHERE [FacturaId] = @FacturaId ORDER BY [FacturaId], [ProductoId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000232,11,0,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
                return;
             case 2 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2) ;
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2) ;
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
                return;
             case 5 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2) ;
                ((String[]) buf[2])[0] = rslt.getString(3, 20) ;
                ((short[]) buf[3])[0] = rslt.getShort(4) ;
                ((short[]) buf[4])[0] = rslt.getShort(5) ;
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 9 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 17 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                return;
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                return;
             case 19 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
                ((short[]) buf[3])[0] = rslt.getShort(4) ;
                ((short[]) buf[4])[0] = rslt.getShort(5) ;
                return;
             case 20 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                return;
             case 21 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                return;
             case 25 :
                ((String[]) buf[0])[0] = rslt.getString(1, 20) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                return;
             case 26 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                return;
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       switch ( cursor )
       {
             case 0 :
                stmt.SetParameter(1, (short)parms[0]);
                stmt.SetParameter(2, (short)parms[1]);
                return;
             case 1 :
                stmt.SetParameter(1, (short)parms[0]);
                stmt.SetParameter(2, (short)parms[1]);
                return;
             case 2 :
                stmt.SetParameter(1, (short)parms[0]);
                return;
             case 3 :
                stmt.SetParameter(1, (short)parms[0]);
                return;
             case 4 :
                stmt.SetParameter(1, (short)parms[0]);
                return;
             case 5 :
                stmt.SetParameter(1, (short)parms[0]);
                return;
             case 6 :
                stmt.SetParameter(1, (short)parms[0]);
                return;
             case 7 :
                stmt.SetParameter(1, (short)parms[0]);
                return;
             case 8 :
                stmt.SetParameter(1, (short)parms[0]);
                return;
             case 9 :
                stmt.SetParameter(1, (short)parms[0]);
                return;
             case 10 :
                stmt.SetParameter(1, (short)parms[0]);
                return;
             case 11 :
                stmt.SetParameter(1, (short)parms[0]);
                return;
             case 12 :
                stmt.SetParameter(1, (short)parms[0]);
                return;
             case 13 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (short)parms[1]);
                return;
             case 14 :
                stmt.SetParameter(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (short)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                return;
             case 15 :
                stmt.SetParameter(1, (short)parms[0]);
                return;
             case 16 :
                stmt.SetParameter(1, (short)parms[0]);
                return;
             case 17 :
                stmt.SetParameter(1, (short)parms[0]);
                return;
             case 19 :
                stmt.SetParameter(1, (short)parms[0]);
                stmt.SetParameter(2, (short)parms[1]);
                return;
             case 20 :
                stmt.SetParameter(1, (short)parms[0]);
                return;
             case 21 :
                stmt.SetParameter(1, (short)parms[0]);
                stmt.SetParameter(2, (short)parms[1]);
                return;
             case 22 :
                stmt.SetParameter(1, (short)parms[0]);
                stmt.SetParameter(2, (short)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                return;
             case 23 :
                stmt.SetParameter(1, (short)parms[0]);
                stmt.SetParameter(2, (short)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                return;
             case 24 :
                stmt.SetParameter(1, (short)parms[0]);
                stmt.SetParameter(2, (short)parms[1]);
                return;
             case 25 :
                stmt.SetParameter(1, (short)parms[0]);
                return;
             case 26 :
                stmt.SetParameter(1, (short)parms[0]);
                return;
       }
    }

 }

}
