/*
               File: Cliente
        Description: Cliente
             Author: GeneXus C# Generator version 15_0_6-116888
       Generated on: 9/21/2017 20:9:13.71
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
   public class cliente : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A9ClienteId = (short)(NumberUtil.Val( GetNextPar( ), "."));
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9ClienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9ClienteId), 4, 0)));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A9ClienteId) ;
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
            Form.Meta.addItem("description", "Cliente", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         GX_FocusControl = edtClienteId_Internalname;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cliente( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public cliente( IGxContext context )
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
            GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Cliente", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, "HLP_Cliente.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Cliente.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "BtnPrevious";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Cliente.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
            ClassString = "BtnNext";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Cliente.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
            ClassString = "BtnLast";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Cliente.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            ClassString = "BtnSelect";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 4, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0040.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CLIENTEID"+"'), id:'"+"CLIENTEID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Cliente.htm");
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
            GxWebStd.gx_label_element( context, edtClienteId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true);
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtClienteId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9ClienteId), 4, 0, ".", "")), ((edtClienteId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A9ClienteId), "ZZZ9")) : context.localUtil.Format( (decimal)(A9ClienteId), "ZZZ9")), TempTags+" onchange=\"gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteId_Jsonclick, 0, "Attribute", "", "", "", edtClienteId_Visible, edtClienteId_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "HLP_Cliente.htm");
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
            GxWebStd.gx_label_element( context, edtClienteNombre_Internalname, "Nombre", "col-sm-3 AttributeLabel", 1, true);
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtClienteNombre_Internalname, StringUtil.RTrim( A10ClienteNombre), StringUtil.RTrim( context.localUtil.Format( A10ClienteNombre, "")), TempTags+" onchange=\"gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteNombre_Jsonclick, 0, "Attribute", "", "", "", 1, edtClienteNombre_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "HLP_Cliente.htm");
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
            GxWebStd.gx_label_element( context, edtClienteTotalFacturado_Internalname, "Total Facturado", "col-sm-3 AttributeLabel", 1, true);
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtClienteTotalFacturado_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A11ClienteTotalFacturado), 4, 0, ".", "")), ((edtClienteTotalFacturado_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A11ClienteTotalFacturado), "ZZZ9")) : context.localUtil.Format( (decimal)(A11ClienteTotalFacturado), "ZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteTotalFacturado_Jsonclick, 0, "Attribute", "", "", "", 1, edtClienteTotalFacturado_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "HLP_Cliente.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Cliente.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Cliente.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
            ClassString = "BtnDelete";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Cliente.htm");
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
               A11ClienteTotalFacturado = (short)(context.localUtil.CToN( cgiGet( edtClienteTotalFacturado_Internalname), ".", ","));
               n11ClienteTotalFacturado = false;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A11ClienteTotalFacturado", StringUtil.LTrim( StringUtil.Str( (decimal)(A11ClienteTotalFacturado), 4, 0)));
               /* Read saved values. */
               Z9ClienteId = (short)(context.localUtil.CToN( cgiGet( "Z9ClienteId"), ".", ","));
               Z10ClienteNombre = cgiGet( "Z10ClienteNombre");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","));
               Gx_date = context.localUtil.CToD( cgiGet( "vTODAY"), 0);
               Gx_mode = cgiGet( "vMODE");
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                  A9ClienteId = (short)(NumberUtil.Val( GetNextPar( ), "."));
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9ClienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9ClienteId), 4, 0)));
                  getEqualNoModal( ) ;
                  if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )  && (0==A9ClienteId) && ( Gx_BScreen == 0 ) )
                  {
                     A9ClienteId = 1;
                     context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9ClienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9ClienteId), 4, 0)));
                  }
                  Gx_mode = "DSP";
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons_dsp( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  getEqualNoModal( ) ;
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
               InitAll034( ) ;
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
         DisableAttributes034( ) ;
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

      protected void ResetCaption030( )
      {
      }

      protected void ZM034( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
            {
               Z10ClienteNombre = T00033_A10ClienteNombre[0];
            }
            else
            {
               Z10ClienteNombre = A10ClienteNombre;
            }
         }
         if ( GX_JID == -4 )
         {
            Z9ClienteId = A9ClienteId;
            Z10ClienteNombre = A10ClienteNombre;
            Z11ClienteTotalFacturado = A11ClienteTotalFacturado;
         }
      }

      protected void standaloneNotModal( )
      {
         edtClienteId_Visible = 0;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtClienteId_Internalname, "Visible", StringUtil.LTrim( StringUtil.Str( (decimal)(edtClienteId_Visible), 5, 0)), true);
         Gx_date = DateTimeUtil.Today( context);
         Gx_BScreen = 0;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )  && (0==A9ClienteId) && ( Gx_BScreen == 0 ) )
         {
            A9ClienteId = 1;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9ClienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9ClienteId), 4, 0)));
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
            /* Using cursor T00036 */
            pr_default.execute(2, new Object[] {A9ClienteId});
            if ( (pr_default.getStatus(2) != 101) )
            {
               A11ClienteTotalFacturado = T00036_A11ClienteTotalFacturado[0];
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A11ClienteTotalFacturado", StringUtil.LTrim( StringUtil.Str( (decimal)(A11ClienteTotalFacturado), 4, 0)));
               n11ClienteTotalFacturado = T00036_n11ClienteTotalFacturado[0];
            }
            else
            {
               A11ClienteTotalFacturado = 0;
               n11ClienteTotalFacturado = false;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A11ClienteTotalFacturado", StringUtil.LTrim( StringUtil.Str( (decimal)(A11ClienteTotalFacturado), 4, 0)));
            }
            pr_default.close(2);
         }
      }

      protected void Load034( )
      {
         /* Using cursor T00039 */
         pr_default.execute(3, new Object[] {A9ClienteId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound4 = 1;
            A10ClienteNombre = T00039_A10ClienteNombre[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A10ClienteNombre", A10ClienteNombre);
            A11ClienteTotalFacturado = T00039_A11ClienteTotalFacturado[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A11ClienteTotalFacturado", StringUtil.LTrim( StringUtil.Str( (decimal)(A11ClienteTotalFacturado), 4, 0)));
            n11ClienteTotalFacturado = T00039_n11ClienteTotalFacturado[0];
            ZM034( -4) ;
         }
         pr_default.close(3);
         OnLoadActions034( ) ;
      }

      protected void OnLoadActions034( )
      {
      }

      protected void CheckExtendedTable034( )
      {
         Gx_BScreen = 1;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T00036 */
         pr_default.execute(2, new Object[] {A9ClienteId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A11ClienteTotalFacturado = T00036_A11ClienteTotalFacturado[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A11ClienteTotalFacturado", StringUtil.LTrim( StringUtil.Str( (decimal)(A11ClienteTotalFacturado), 4, 0)));
            n11ClienteTotalFacturado = T00036_n11ClienteTotalFacturado[0];
         }
         else
         {
            A11ClienteTotalFacturado = 0;
            n11ClienteTotalFacturado = false;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A11ClienteTotalFacturado", StringUtil.LTrim( StringUtil.Str( (decimal)(A11ClienteTotalFacturado), 4, 0)));
         }
         pr_default.close(2);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A10ClienteNombre)) )
         {
            GX_msglist.addItem("El nombre del cliente no puede estar vacio mi pari", 1, "CLIENTENOMBRE");
            AnyError = 1;
            GX_FocusControl = edtClienteNombre_Internalname;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors034( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_5( short A9ClienteId )
      {
         /* Using cursor T000312 */
         pr_default.execute(4, new Object[] {A9ClienteId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            A11ClienteTotalFacturado = T000312_A11ClienteTotalFacturado[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A11ClienteTotalFacturado", StringUtil.LTrim( StringUtil.Str( (decimal)(A11ClienteTotalFacturado), 4, 0)));
            n11ClienteTotalFacturado = T000312_n11ClienteTotalFacturado[0];
         }
         else
         {
            A11ClienteTotalFacturado = 0;
            n11ClienteTotalFacturado = false;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A11ClienteTotalFacturado", StringUtil.LTrim( StringUtil.Str( (decimal)(A11ClienteTotalFacturado), 4, 0)));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         context.GX_webresponse.AddString("new Array( new Array(");
         context.GX_webresponse.AddString("\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A11ClienteTotalFacturado), 4, 0, ".", "")))+"\"");
         context.GX_webresponse.AddString(")");
         if ( (pr_default.getStatus(4) == 101) )
         {
            context.GX_webresponse.AddString(",");
            context.GX_webresponse.AddString("101");
         }
         context.GX_webresponse.AddString(")");
         pr_default.close(4);
      }

      protected void GetKey034( )
      {
         /* Using cursor T000313 */
         pr_default.execute(5, new Object[] {A9ClienteId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound4 = 1;
         }
         else
         {
            RcdFound4 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00033 */
         pr_default.execute(1, new Object[] {A9ClienteId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM034( 4) ;
            RcdFound4 = 1;
            A9ClienteId = T00033_A9ClienteId[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9ClienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9ClienteId), 4, 0)));
            A10ClienteNombre = T00033_A10ClienteNombre[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A10ClienteNombre", A10ClienteNombre);
            Z9ClienteId = A9ClienteId;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load034( ) ;
            if ( AnyError == 1 )
            {
               RcdFound4 = 0;
               InitializeNonKey034( ) ;
            }
            Gx_mode = sMode4;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound4 = 0;
            InitializeNonKey034( ) ;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode4;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey034( ) ;
         if ( RcdFound4 == 0 )
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
         RcdFound4 = 0;
         /* Using cursor T000314 */
         pr_default.execute(6, new Object[] {A9ClienteId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000314_A9ClienteId[0] < A9ClienteId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000314_A9ClienteId[0] > A9ClienteId ) ) )
            {
               A9ClienteId = T000314_A9ClienteId[0];
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9ClienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9ClienteId), 4, 0)));
               RcdFound4 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound4 = 0;
         /* Using cursor T000315 */
         pr_default.execute(7, new Object[] {A9ClienteId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000315_A9ClienteId[0] > A9ClienteId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000315_A9ClienteId[0] < A9ClienteId ) ) )
            {
               A9ClienteId = T000315_A9ClienteId[0];
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9ClienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9ClienteId), 4, 0)));
               RcdFound4 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey034( ) ;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            /* Insert record */
            GX_FocusControl = edtClienteId_Internalname;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
            Insert034( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound4 == 1 )
            {
               if ( A9ClienteId != Z9ClienteId )
               {
                  A9ClienteId = Z9ClienteId;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9ClienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9ClienteId), 4, 0)));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CLIENTEID");
                  AnyError = 1;
                  GX_FocusControl = edtClienteId_Internalname;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtClienteId_Internalname;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update034( ) ;
                  GX_FocusControl = edtClienteId_Internalname;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A9ClienteId != Z9ClienteId )
               {
                  Gx_mode = "INS";
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtClienteId_Internalname;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert034( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CLIENTEID");
                     AnyError = 1;
                     GX_FocusControl = edtClienteId_Internalname;
                     context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtClienteId_Internalname;
                     context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert034( ) ;
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
         if ( A9ClienteId != Z9ClienteId )
         {
            A9ClienteId = Z9ClienteId;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9ClienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9ClienteId), 4, 0)));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CLIENTEID");
            AnyError = 1;
            GX_FocusControl = edtClienteId_Internalname;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtClienteId_Internalname;
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
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CLIENTEID");
            AnyError = 1;
            GX_FocusControl = edtClienteId_Internalname;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtClienteNombre_Internalname;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "IsConfirmed", StringUtil.LTrim( StringUtil.Str( (decimal)(IsConfirmed), 4, 0)));
         ScanStart034( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtClienteNombre_Internalname;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd034( ) ;
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
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtClienteNombre_Internalname;
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
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtClienteNombre_Internalname;
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
         ScanStart034( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound4 != 0 )
            {
               ScanNext034( ) ;
            }
            Gx_mode = "UPD";
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtClienteNombre_Internalname;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd034( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency034( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            /* Using cursor T00032 */
            pr_default.execute(0, new Object[] {A9ClienteId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Cliente"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z10ClienteNombre, T00032_A10ClienteNombre[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z10ClienteNombre, T00032_A10ClienteNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ClienteNombre");
                  GXUtil.WriteLogRaw("Old: ",Z10ClienteNombre);
                  GXUtil.WriteLogRaw("Current: ",T00032_A10ClienteNombre[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Cliente"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert034( )
      {
         BeforeValidate034( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable034( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM034( 0) ;
            CheckOptimisticConcurrency034( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm034( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert034( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000316 */
                     pr_default.execute(8, new Object[] {A10ClienteNombre});
                     A9ClienteId = T000316_A9ClienteId[0];
                     context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9ClienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9ClienteId), 4, 0)));
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("Cliente") ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           GX_msglist.addItem(context.GetMessage( "GXM_sucadded", ""), "SuccessfullyAdded", 0, "", true);
                           ResetCaption030( ) ;
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
               Load034( ) ;
            }
            EndLevel034( ) ;
         }
         CloseExtendedTableCursors034( ) ;
      }

      protected void Update034( )
      {
         BeforeValidate034( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable034( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency034( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm034( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate034( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000317 */
                     pr_default.execute(9, new Object[] {A10ClienteNombre, A9ClienteId});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("Cliente") ;
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Cliente"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate034( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           GX_msglist.addItem(context.GetMessage( "GXM_sucupdated", ""), "SuccessfullyUpdated", 0, "", true);
                           ResetCaption030( ) ;
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
            EndLevel034( ) ;
         }
         CloseExtendedTableCursors034( ) ;
      }

      protected void DeferredUpdate034( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         BeforeValidate034( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency034( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls034( ) ;
            AfterConfirm034( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete034( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000318 */
                  pr_default.execute(10, new Object[] {A9ClienteId});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("Cliente") ;
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound4 == 0 )
                        {
                           InitAll034( ) ;
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
                        ResetCaption030( ) ;
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
         sMode4 = Gx_mode;
         Gx_mode = "DLT";
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         EndLevel034( ) ;
         Gx_mode = sMode4;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls034( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000321 */
            pr_default.execute(11, new Object[] {A9ClienteId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               A11ClienteTotalFacturado = T000321_A11ClienteTotalFacturado[0];
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A11ClienteTotalFacturado", StringUtil.LTrim( StringUtil.Str( (decimal)(A11ClienteTotalFacturado), 4, 0)));
               n11ClienteTotalFacturado = T000321_n11ClienteTotalFacturado[0];
            }
            else
            {
               A11ClienteTotalFacturado = 0;
               n11ClienteTotalFacturado = false;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A11ClienteTotalFacturado", StringUtil.LTrim( StringUtil.Str( (decimal)(A11ClienteTotalFacturado), 4, 0)));
            }
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000322 */
            pr_default.execute(12, new Object[] {A9ClienteId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Factura"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel034( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete034( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            pr_default.commit( "Cliente");
            if ( AnyError == 0 )
            {
               ConfirmValues030( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            pr_default.rollback( "Cliente");
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart034( )
      {
         /* Using cursor T000323 */
         pr_default.execute(13);
         RcdFound4 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound4 = 1;
            A9ClienteId = T000323_A9ClienteId[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9ClienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9ClienteId), 4, 0)));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext034( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound4 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound4 = 1;
            A9ClienteId = T000323_A9ClienteId[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9ClienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9ClienteId), 4, 0)));
         }
      }

      protected void ScanEnd034( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm034( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert034( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate034( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete034( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete034( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate034( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes034( )
      {
         edtClienteId_Enabled = 0;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtClienteId_Enabled), 5, 0)), true);
         edtClienteNombre_Enabled = 0;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtClienteNombre_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtClienteNombre_Enabled), 5, 0)), true);
         edtClienteTotalFacturado_Enabled = 0;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtClienteTotalFacturado_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtClienteTotalFacturado_Enabled), 5, 0)), true);
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues030( )
      {
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
         context.AddJavascriptSource("gxcfg.js", "?20179212091438", false);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("cliente.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z9ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9ClienteId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z10ClienteNombre", StringUtil.RTrim( Z10ClienteNombre));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
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
         return formatLink("cliente.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "Cliente" ;
      }

      public override String GetPgmdesc( )
      {
         return "Cliente" ;
      }

      protected void InitializeNonKey034( )
      {
         A10ClienteNombre = "";
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A10ClienteNombre", A10ClienteNombre);
         A11ClienteTotalFacturado = 0;
         n11ClienteTotalFacturado = false;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A11ClienteTotalFacturado", StringUtil.LTrim( StringUtil.Str( (decimal)(A11ClienteTotalFacturado), 4, 0)));
         Z10ClienteNombre = "";
      }

      protected void InitAll034( )
      {
         A9ClienteId = 1;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9ClienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9ClienteId), 4, 0)));
         InitializeNonKey034( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( ) ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?20179212091442", true);
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
         context.AddJavascriptSource("cliente.js", "?20179212091442", false);
         /* End function include_jscripts */
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
         edtClienteId_Internalname = "CLIENTEID";
         edtClienteNombre_Internalname = "CLIENTENOMBRE";
         edtClienteTotalFacturado_Internalname = "CLIENTETOTALFACTURADO";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
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
         Form.Caption = "Cliente";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtClienteTotalFacturado_Jsonclick = "";
         edtClienteTotalFacturado_Enabled = 0;
         edtClienteNombre_Jsonclick = "";
         edtClienteNombre_Enabled = 1;
         edtClienteId_Jsonclick = "";
         edtClienteId_Enabled = 1;
         edtClienteId_Visible = 1;
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

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "IsConfirmed", StringUtil.LTrim( StringUtil.Str( (decimal)(IsConfirmed), 4, 0)));
         getEqualNoModal( ) ;
         GX_FocusControl = edtClienteNombre_Internalname;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
      }

      public void Valid_Clienteid( short GX_Parm1 ,
                                   String GX_Parm2 ,
                                   short GX_Parm3 )
      {
         A9ClienteId = GX_Parm1;
         A10ClienteNombre = GX_Parm2;
         A11ClienteTotalFacturado = GX_Parm3;
         n11ClienteTotalFacturado = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
         /* Using cursor T000321 */
         pr_default.execute(11, new Object[] {A9ClienteId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            A11ClienteTotalFacturado = T000321_A11ClienteTotalFacturado[0];
            n11ClienteTotalFacturado = T000321_n11ClienteTotalFacturado[0];
         }
         else
         {
            A11ClienteTotalFacturado = 0;
            n11ClienteTotalFacturado = false;
         }
         pr_default.close(11);
         dynload_actions( ) ;
         if ( AnyError == 1 )
         {
            A11ClienteTotalFacturado = 0;
            n11ClienteTotalFacturado = false;
         }
         isValidOutput.Add(StringUtil.RTrim( A10ClienteNombre));
         isValidOutput.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(A11ClienteTotalFacturado), 4, 0, ".", "")));
         isValidOutput.Add(StringUtil.RTrim( Gx_mode));
         isValidOutput.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9ClienteId), 4, 0, ".", "")));
         isValidOutput.Add(StringUtil.RTrim( Z10ClienteNombre));
         isValidOutput.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(Z11ClienteTotalFacturado), 4, 0, ".", "")));
         isValidOutput.Add(bttBtn_delete_Enabled);
         isValidOutput.Add(bttBtn_enter_Enabled);
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
         pr_default.close(11);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z10ClienteNombre = "";
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
         A10ClienteNombre = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         Gx_date = DateTime.MinValue;
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         T00036_A11ClienteTotalFacturado = new short[1] ;
         T00036_n11ClienteTotalFacturado = new bool[] {false} ;
         T00039_A9ClienteId = new short[1] ;
         T00039_A10ClienteNombre = new String[] {""} ;
         T00039_A11ClienteTotalFacturado = new short[1] ;
         T00039_n11ClienteTotalFacturado = new bool[] {false} ;
         T000312_A11ClienteTotalFacturado = new short[1] ;
         T000312_n11ClienteTotalFacturado = new bool[] {false} ;
         T000313_A9ClienteId = new short[1] ;
         T00033_A9ClienteId = new short[1] ;
         T00033_A10ClienteNombre = new String[] {""} ;
         sMode4 = "";
         T000314_A9ClienteId = new short[1] ;
         T000315_A9ClienteId = new short[1] ;
         T00032_A9ClienteId = new short[1] ;
         T00032_A10ClienteNombre = new String[] {""} ;
         T000316_A9ClienteId = new short[1] ;
         T000321_A11ClienteTotalFacturado = new short[1] ;
         T000321_n11ClienteTotalFacturado = new bool[] {false} ;
         T000322_A4FacturaId = new short[1] ;
         T000323_A9ClienteId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         isValidOutput = new GxUnknownObjectCollection();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cliente__default(),
            new Object[][] {
                new Object[] {
               T00032_A9ClienteId, T00032_A10ClienteNombre
               }
               , new Object[] {
               T00033_A9ClienteId, T00033_A10ClienteNombre
               }
               , new Object[] {
               T00036_A11ClienteTotalFacturado, T00036_n11ClienteTotalFacturado
               }
               , new Object[] {
               T00039_A9ClienteId, T00039_A10ClienteNombre, T00039_A11ClienteTotalFacturado, T00039_n11ClienteTotalFacturado
               }
               , new Object[] {
               T000312_A11ClienteTotalFacturado, T000312_n11ClienteTotalFacturado
               }
               , new Object[] {
               T000313_A9ClienteId
               }
               , new Object[] {
               T000314_A9ClienteId
               }
               , new Object[] {
               T000315_A9ClienteId
               }
               , new Object[] {
               T000316_A9ClienteId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000321_A11ClienteTotalFacturado, T000321_n11ClienteTotalFacturado
               }
               , new Object[] {
               T000322_A4FacturaId
               }
               , new Object[] {
               T000323_A9ClienteId
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         Z9ClienteId = 1;
         A9ClienteId = 1;
      }

      private short Z9ClienteId ;
      private short GxWebError ;
      private short A9ClienteId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A11ClienteTotalFacturado ;
      private short Gx_BScreen ;
      private short GX_JID ;
      private short Z11ClienteTotalFacturado ;
      private short RcdFound4 ;
      private short gxajaxcallmode ;
      private short wbTemp ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtClienteId_Enabled ;
      private int edtClienteId_Visible ;
      private int edtClienteNombre_Enabled ;
      private int edtClienteTotalFacturado_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private String sPrefix ;
      private String Z10ClienteNombre ;
      private String scmdbuf ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String GXKey ;
      private String PreviousTooltip ;
      private String PreviousCaption ;
      private String GX_FocusControl ;
      private String edtClienteId_Internalname ;
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
      private String edtClienteId_Jsonclick ;
      private String edtClienteNombre_Internalname ;
      private String A10ClienteNombre ;
      private String edtClienteNombre_Jsonclick ;
      private String edtClienteTotalFacturado_Internalname ;
      private String edtClienteTotalFacturado_Jsonclick ;
      private String bttBtn_enter_Internalname ;
      private String bttBtn_enter_Jsonclick ;
      private String bttBtn_cancel_Internalname ;
      private String bttBtn_cancel_Jsonclick ;
      private String bttBtn_delete_Internalname ;
      private String bttBtn_delete_Jsonclick ;
      private String Gx_mode ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String sMode4 ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n11ClienteTotalFacturado ;
      private GxUnknownObjectCollection isValidOutput ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T00036_A11ClienteTotalFacturado ;
      private bool[] T00036_n11ClienteTotalFacturado ;
      private short[] T00039_A9ClienteId ;
      private String[] T00039_A10ClienteNombre ;
      private short[] T00039_A11ClienteTotalFacturado ;
      private bool[] T00039_n11ClienteTotalFacturado ;
      private short[] T000312_A11ClienteTotalFacturado ;
      private bool[] T000312_n11ClienteTotalFacturado ;
      private short[] T000313_A9ClienteId ;
      private short[] T00033_A9ClienteId ;
      private String[] T00033_A10ClienteNombre ;
      private short[] T000314_A9ClienteId ;
      private short[] T000315_A9ClienteId ;
      private short[] T00032_A9ClienteId ;
      private String[] T00032_A10ClienteNombre ;
      private short[] T000316_A9ClienteId ;
      private short[] T000321_A11ClienteTotalFacturado ;
      private bool[] T000321_n11ClienteTotalFacturado ;
      private short[] T000322_A4FacturaId ;
      private short[] T000323_A9ClienteId ;
      private GXWebForm Form ;
   }

   public class cliente__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00039 ;
          prmT00039 = new Object[] {
          new Object[] {"@ClienteId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT00036 ;
          prmT00036 = new Object[] {
          new Object[] {"@ClienteId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000312 ;
          prmT000312 = new Object[] {
          new Object[] {"@ClienteId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000313 ;
          prmT000313 = new Object[] {
          new Object[] {"@ClienteId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT00033 ;
          prmT00033 = new Object[] {
          new Object[] {"@ClienteId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000314 ;
          prmT000314 = new Object[] {
          new Object[] {"@ClienteId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000315 ;
          prmT000315 = new Object[] {
          new Object[] {"@ClienteId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT00032 ;
          prmT00032 = new Object[] {
          new Object[] {"@ClienteId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000316 ;
          prmT000316 = new Object[] {
          new Object[] {"@ClienteNombre",SqlDbType.Char,20,0}
          } ;
          Object[] prmT000317 ;
          prmT000317 = new Object[] {
          new Object[] {"@ClienteNombre",SqlDbType.Char,20,0} ,
          new Object[] {"@ClienteId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000318 ;
          prmT000318 = new Object[] {
          new Object[] {"@ClienteId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000322 ;
          prmT000322 = new Object[] {
          new Object[] {"@ClienteId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000323 ;
          prmT000323 = new Object[] {
          } ;
          Object[] prmT000321 ;
          prmT000321 = new Object[] {
          new Object[] {"@ClienteId",SqlDbType.SmallInt,4,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("T00032", "SELECT [ClienteId], [ClienteNombre] FROM [Cliente] WITH (UPDLOCK) WHERE [ClienteId] = @ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00032,1,0,true,false )
             ,new CursorDef("T00033", "SELECT [ClienteId], [ClienteNombre] FROM [Cliente] WITH (NOLOCK) WHERE [ClienteId] = @ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00033,1,0,true,false )
             ,new CursorDef("T00036", "SELECT COALESCE( T1.[ClienteTotalFacturado], 0) AS ClienteTotalFacturado FROM (SELECT SUM(COALESCE( T3.[FacturaTotal], 0)) AS ClienteTotalFacturado, T2.[ClienteId] FROM ([Factura] T2 WITH (NOLOCK) LEFT JOIN (SELECT SUM(CASE  WHEN T4.[ProductoId] = 1 THEN T5.[ProductoPrecio] * CAST(T4.[FacturaProductoCantidad] AS decimal( 14, 10)) * CAST(0.9 AS decimal( 14, 10)) WHEN T4.[ProductoId] = 2 THEN T5.[ProductoPrecio] * CAST(T4.[FacturaProductoCantidad] AS decimal( 14, 10)) * CAST(0.8 AS decimal( 14, 10)) ELSE T5.[ProductoPrecio] * CAST(T4.[FacturaProductoCantidad] AS decimal( 14, 10)) END) AS FacturaTotal, T4.[FacturaId] FROM ([FacturaFacturaProducto] T4 WITH (NOLOCK) INNER JOIN [Producto] T5 WITH (NOLOCK) ON T5.[ProductoId] = T4.[ProductoId]) GROUP BY T4.[FacturaId] ) T3 ON T3.[FacturaId] = T2.[FacturaId]) GROUP BY T2.[ClienteId] ) T1 WHERE T1.[ClienteId] = @ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00036,1,0,true,false )
             ,new CursorDef("T00039", "SELECT TM1.[ClienteId], TM1.[ClienteNombre], COALESCE( T2.[ClienteTotalFacturado], 0) AS ClienteTotalFacturado FROM ([Cliente] TM1 WITH (NOLOCK) LEFT JOIN (SELECT SUM(COALESCE( T4.[FacturaTotal], 0)) AS ClienteTotalFacturado, T3.[ClienteId] FROM ([Factura] T3 WITH (NOLOCK) LEFT JOIN (SELECT SUM(CASE  WHEN T5.[ProductoId] = 1 THEN T6.[ProductoPrecio] * CAST(T5.[FacturaProductoCantidad] AS decimal( 14, 10)) * CAST(0.9 AS decimal( 14, 10)) WHEN T5.[ProductoId] = 2 THEN T6.[ProductoPrecio] * CAST(T5.[FacturaProductoCantidad] AS decimal( 14, 10)) * CAST(0.8 AS decimal( 14, 10)) ELSE T6.[ProductoPrecio] * CAST(T5.[FacturaProductoCantidad] AS decimal( 14, 10)) END) AS FacturaTotal, T5.[FacturaId] FROM ([FacturaFacturaProducto] T5 WITH (NOLOCK) INNER JOIN [Producto] T6 WITH (NOLOCK) ON T6.[ProductoId] = T5.[ProductoId]) GROUP BY T5.[FacturaId] ) T4 ON T4.[FacturaId] = T3.[FacturaId]) GROUP BY T3.[ClienteId] ) T2 ON T2.[ClienteId] = TM1.[ClienteId]) WHERE TM1.[ClienteId] = @ClienteId ORDER BY TM1.[ClienteId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00039,100,0,true,false )
             ,new CursorDef("T000312", "SELECT COALESCE( T1.[ClienteTotalFacturado], 0) AS ClienteTotalFacturado FROM (SELECT SUM(COALESCE( T3.[FacturaTotal], 0)) AS ClienteTotalFacturado, T2.[ClienteId] FROM ([Factura] T2 WITH (NOLOCK) LEFT JOIN (SELECT SUM(CASE  WHEN T4.[ProductoId] = 1 THEN T5.[ProductoPrecio] * CAST(T4.[FacturaProductoCantidad] AS decimal( 14, 10)) * CAST(0.9 AS decimal( 14, 10)) WHEN T4.[ProductoId] = 2 THEN T5.[ProductoPrecio] * CAST(T4.[FacturaProductoCantidad] AS decimal( 14, 10)) * CAST(0.8 AS decimal( 14, 10)) ELSE T5.[ProductoPrecio] * CAST(T4.[FacturaProductoCantidad] AS decimal( 14, 10)) END) AS FacturaTotal, T4.[FacturaId] FROM ([FacturaFacturaProducto] T4 WITH (NOLOCK) INNER JOIN [Producto] T5 WITH (NOLOCK) ON T5.[ProductoId] = T4.[ProductoId]) GROUP BY T4.[FacturaId] ) T3 ON T3.[FacturaId] = T2.[FacturaId]) GROUP BY T2.[ClienteId] ) T1 WHERE T1.[ClienteId] = @ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000312,1,0,true,false )
             ,new CursorDef("T000313", "SELECT [ClienteId] FROM [Cliente] WITH (NOLOCK) WHERE [ClienteId] = @ClienteId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000313,1,0,true,false )
             ,new CursorDef("T000314", "SELECT TOP 1 [ClienteId] FROM [Cliente] WITH (NOLOCK) WHERE ( [ClienteId] > @ClienteId) ORDER BY [ClienteId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000314,1,0,true,true )
             ,new CursorDef("T000315", "SELECT TOP 1 [ClienteId] FROM [Cliente] WITH (NOLOCK) WHERE ( [ClienteId] < @ClienteId) ORDER BY [ClienteId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000315,1,0,true,true )
             ,new CursorDef("T000316", "INSERT INTO [Cliente]([ClienteNombre]) VALUES(@ClienteNombre); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000316)
             ,new CursorDef("T000317", "UPDATE [Cliente] SET [ClienteNombre]=@ClienteNombre  WHERE [ClienteId] = @ClienteId", GxErrorMask.GX_NOMASK,prmT000317)
             ,new CursorDef("T000318", "DELETE FROM [Cliente]  WHERE [ClienteId] = @ClienteId", GxErrorMask.GX_NOMASK,prmT000318)
             ,new CursorDef("T000321", "SELECT COALESCE( T1.[ClienteTotalFacturado], 0) AS ClienteTotalFacturado FROM (SELECT SUM(COALESCE( T3.[FacturaTotal], 0)) AS ClienteTotalFacturado, T2.[ClienteId] FROM ([Factura] T2 WITH (NOLOCK) LEFT JOIN (SELECT SUM(CASE  WHEN T4.[ProductoId] = 1 THEN T5.[ProductoPrecio] * CAST(T4.[FacturaProductoCantidad] AS decimal( 14, 10)) * CAST(0.9 AS decimal( 14, 10)) WHEN T4.[ProductoId] = 2 THEN T5.[ProductoPrecio] * CAST(T4.[FacturaProductoCantidad] AS decimal( 14, 10)) * CAST(0.8 AS decimal( 14, 10)) ELSE T5.[ProductoPrecio] * CAST(T4.[FacturaProductoCantidad] AS decimal( 14, 10)) END) AS FacturaTotal, T4.[FacturaId] FROM ([FacturaFacturaProducto] T4 WITH (NOLOCK) INNER JOIN [Producto] T5 WITH (NOLOCK) ON T5.[ProductoId] = T4.[ProductoId]) GROUP BY T4.[FacturaId] ) T3 ON T3.[FacturaId] = T2.[FacturaId]) GROUP BY T2.[ClienteId] ) T1 WHERE T1.[ClienteId] = @ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000321,1,0,true,false )
             ,new CursorDef("T000322", "SELECT TOP 1 [FacturaId] FROM [Factura] WITH (NOLOCK) WHERE [ClienteId] = @ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000322,1,0,true,true )
             ,new CursorDef("T000323", "SELECT [ClienteId] FROM [Cliente] WITH (NOLOCK) ORDER BY [ClienteId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000323,100,0,true,false )
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
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 20) ;
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
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
                return;
             case 1 :
                stmt.SetParameter(1, (short)parms[0]);
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
                stmt.SetParameter(1, (String)parms[0]);
                return;
             case 9 :
                stmt.SetParameter(1, (String)parms[0]);
                stmt.SetParameter(2, (short)parms[1]);
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
       }
    }

 }

}
