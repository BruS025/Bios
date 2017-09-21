/*
               File: Propiedad
        Description: Propiedad
             Author: GeneXus C# Generator version 15_0_6-116888
       Generated on: 9/14/2017 20:18:29.91
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
   public class propiedad : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A1BarrioId = (short)(NumberUtil.Val( GetNextPar( ), "."));
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A1BarrioId", StringUtil.LTrim( StringUtil.Str( (decimal)(A1BarrioId), 4, 0)));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A1BarrioId) ;
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
            Form.Meta.addItem("description", "Propiedad", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         GX_FocusControl = edtPropiedadId_Internalname;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public propiedad( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public propiedad( IGxContext context )
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
            GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Propiedad", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, "HLP_Propiedad.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Propiedad.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "BtnPrevious";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Propiedad.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
            ClassString = "BtnNext";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Propiedad.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
            ClassString = "BtnLast";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Propiedad.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            ClassString = "BtnSelect";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 4, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PROPIEDADID"+"'), id:'"+"PROPIEDADID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Propiedad.htm");
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
            GxWebStd.gx_label_element( context, edtPropiedadId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true);
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtPropiedadId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A3PropiedadId), 4, 0, ".", "")), ((edtPropiedadId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A3PropiedadId), "ZZZ9")) : context.localUtil.Format( (decimal)(A3PropiedadId), "ZZZ9")), TempTags+" onchange=\"gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropiedadId_Jsonclick, 0, "Attribute", "", "", "", 1, edtPropiedadId_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "HLP_Propiedad.htm");
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
            GxWebStd.gx_label_element( context, edtPropiedadDescripcion_Internalname, "Descripcion", "col-sm-3 AttributeLabel", 1, true);
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtPropiedadDescripcion_Internalname, StringUtil.RTrim( A4PropiedadDescripcion), StringUtil.RTrim( context.localUtil.Format( A4PropiedadDescripcion, "")), TempTags+" onchange=\"gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropiedadDescripcion_Jsonclick, 0, "Attribute", "", "", "", 1, edtPropiedadDescripcion_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "HLP_Propiedad.htm");
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
            GxWebStd.gx_label_element( context, imgPropiedadFoto_Internalname, "Foto", "col-sm-3 AttributeLabel", 1, true);
            /* Static Bitmap Variable */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            A5PropiedadFoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A5PropiedadFoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000PropiedadFoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A5PropiedadFoto)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A5PropiedadFoto)) ? A40000PropiedadFoto_GXI : context.PathToRelativeUrl( A5PropiedadFoto));
            GxWebStd.gx_bitmap( context, imgPropiedadFoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgPropiedadFoto_Enabled, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", TempTags+" onchange=\"gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", "", "", 0, A5PropiedadFoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Propiedad.htm");
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgPropiedadFoto_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A5PropiedadFoto)) ? A40000PropiedadFoto_GXI : context.PathToRelativeUrl( A5PropiedadFoto)), true);
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgPropiedadFoto_Internalname, "IsBlob", StringUtil.BoolToStr( A5PropiedadFoto_IsBlob), true);
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
            GxWebStd.gx_label_element( context, edtPropiedadDireccion_Internalname, "Direccion", "col-sm-3 AttributeLabel", 1, true);
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtPropiedadDireccion_Internalname, StringUtil.RTrim( A6PropiedadDireccion), StringUtil.RTrim( context.localUtil.Format( A6PropiedadDireccion, "")), TempTags+" onchange=\"gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropiedadDireccion_Jsonclick, 0, "Attribute", "", "", "", 1, edtPropiedadDireccion_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "HLP_Propiedad.htm");
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
            GxWebStd.gx_label_element( context, edtBarrioId_Internalname, "Barrio Id", "col-sm-3 AttributeLabel", 1, true);
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtBarrioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1BarrioId), 4, 0, ".", "")), ((edtBarrioId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A1BarrioId), "ZZZ9")) : context.localUtil.Format( (decimal)(A1BarrioId), "ZZZ9")), TempTags+" onchange=\"gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBarrioId_Jsonclick, 0, "Attribute", "", "", "", 1, edtBarrioId_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "HLP_Propiedad.htm");
            /* Static images/pictures */
            ClassString = "gx-prompt Image";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgprompt_1_Internalname, sImgUrl, imgprompt_1_Link, "", "", context.GetTheme( ), imgprompt_1_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Propiedad.htm");
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
            GxWebStd.gx_label_element( context, edtBarrioNombre_Internalname, "Barrio Nombre", "col-sm-3 AttributeLabel", 1, true);
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtBarrioNombre_Internalname, StringUtil.RTrim( A2BarrioNombre), StringUtil.RTrim( context.localUtil.Format( A2BarrioNombre, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBarrioNombre_Jsonclick, 0, "Attribute", "", "", "", 1, edtBarrioNombre_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "HLP_Propiedad.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Propiedad.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Propiedad.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
            ClassString = "BtnDelete";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Propiedad.htm");
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
               if ( ( ( context.localUtil.CToN( cgiGet( edtPropiedadId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPropiedadId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROPIEDADID");
                  AnyError = 1;
                  GX_FocusControl = edtPropiedadId_Internalname;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A3PropiedadId = 0;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A3PropiedadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A3PropiedadId), 4, 0)));
               }
               else
               {
                  A3PropiedadId = (short)(context.localUtil.CToN( cgiGet( edtPropiedadId_Internalname), ".", ","));
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A3PropiedadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A3PropiedadId), 4, 0)));
               }
               A4PropiedadDescripcion = cgiGet( edtPropiedadDescripcion_Internalname);
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A4PropiedadDescripcion", A4PropiedadDescripcion);
               A5PropiedadFoto = cgiGet( imgPropiedadFoto_Internalname);
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A5PropiedadFoto", A5PropiedadFoto);
               A6PropiedadDireccion = cgiGet( edtPropiedadDireccion_Internalname);
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6PropiedadDireccion", A6PropiedadDireccion);
               if ( ( ( context.localUtil.CToN( cgiGet( edtBarrioId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtBarrioId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "BARRIOID");
                  AnyError = 1;
                  GX_FocusControl = edtBarrioId_Internalname;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1BarrioId = 0;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A1BarrioId", StringUtil.LTrim( StringUtil.Str( (decimal)(A1BarrioId), 4, 0)));
               }
               else
               {
                  A1BarrioId = (short)(context.localUtil.CToN( cgiGet( edtBarrioId_Internalname), ".", ","));
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A1BarrioId", StringUtil.LTrim( StringUtil.Str( (decimal)(A1BarrioId), 4, 0)));
               }
               A2BarrioNombre = cgiGet( edtBarrioNombre_Internalname);
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A2BarrioNombre", A2BarrioNombre);
               /* Read saved values. */
               Z3PropiedadId = (short)(context.localUtil.CToN( cgiGet( "Z3PropiedadId"), ".", ","));
               Z4PropiedadDescripcion = cgiGet( "Z4PropiedadDescripcion");
               Z6PropiedadDireccion = cgiGet( "Z6PropiedadDireccion");
               Z1BarrioId = (short)(context.localUtil.CToN( cgiGet( "Z1BarrioId"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               A40000PropiedadFoto_GXI = cgiGet( "PROPIEDADFOTO_GXI");
               Gx_mode = cgiGet( "vMODE");
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgPropiedadFoto_Internalname, ref  A5PropiedadFoto, ref  A40000PropiedadFoto_GXI);
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
                  A3PropiedadId = (short)(NumberUtil.Val( GetNextPar( ), "."));
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A3PropiedadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A3PropiedadId), 4, 0)));
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

      protected void ResetCaption020( )
      {
      }

      protected void ZM022( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
            {
               Z4PropiedadDescripcion = T00023_A4PropiedadDescripcion[0];
               Z6PropiedadDireccion = T00023_A6PropiedadDireccion[0];
               Z1BarrioId = T00023_A1BarrioId[0];
            }
            else
            {
               Z4PropiedadDescripcion = A4PropiedadDescripcion;
               Z6PropiedadDireccion = A6PropiedadDireccion;
               Z1BarrioId = A1BarrioId;
            }
         }
         if ( GX_JID == -2 )
         {
            Z3PropiedadId = A3PropiedadId;
            Z4PropiedadDescripcion = A4PropiedadDescripcion;
            Z5PropiedadFoto = A5PropiedadFoto;
            Z40000PropiedadFoto_GXI = A40000PropiedadFoto_GXI;
            Z6PropiedadDireccion = A6PropiedadDireccion;
            Z1BarrioId = A1BarrioId;
            Z2BarrioNombre = A2BarrioNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_1_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"BARRIOID"+"'), id:'"+"BARRIOID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
      }

      protected void standaloneModal( )
      {
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
      }

      protected void Load022( )
      {
         /* Using cursor T00025 */
         pr_default.execute(3, new Object[] {A3PropiedadId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound2 = 1;
            A4PropiedadDescripcion = T00025_A4PropiedadDescripcion[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A4PropiedadDescripcion", A4PropiedadDescripcion);
            A40000PropiedadFoto_GXI = T00025_A40000PropiedadFoto_GXI[0];
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgPropiedadFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A5PropiedadFoto)) ? A40000PropiedadFoto_GXI : context.convertURL( context.PathToRelativeUrl( A5PropiedadFoto))), true);
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgPropiedadFoto_Internalname, "SrcSet", context.GetImageSrcSet( A5PropiedadFoto), true);
            A6PropiedadDireccion = T00025_A6PropiedadDireccion[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6PropiedadDireccion", A6PropiedadDireccion);
            A2BarrioNombre = T00025_A2BarrioNombre[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A2BarrioNombre", A2BarrioNombre);
            A1BarrioId = T00025_A1BarrioId[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A1BarrioId", StringUtil.LTrim( StringUtil.Str( (decimal)(A1BarrioId), 4, 0)));
            A5PropiedadFoto = T00025_A5PropiedadFoto[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A5PropiedadFoto", A5PropiedadFoto);
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgPropiedadFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A5PropiedadFoto)) ? A40000PropiedadFoto_GXI : context.convertURL( context.PathToRelativeUrl( A5PropiedadFoto))), true);
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgPropiedadFoto_Internalname, "SrcSet", context.GetImageSrcSet( A5PropiedadFoto), true);
            ZM022( -2) ;
         }
         pr_default.close(3);
         OnLoadActions022( ) ;
      }

      protected void OnLoadActions022( )
      {
      }

      protected void CheckExtendedTable022( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A6PropiedadDireccion)) )
         {
            GX_msglist.addItem("No ingreso la direccion", 0, "PROPIEDADDIRECCION");
         }
         /* Using cursor T00024 */
         pr_default.execute(2, new Object[] {A1BarrioId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Barrio'.", "ForeignKeyNotFound", 1, "BARRIOID");
            AnyError = 1;
            GX_FocusControl = edtBarrioId_Internalname;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2BarrioNombre = T00024_A2BarrioNombre[0];
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A2BarrioNombre", A2BarrioNombre);
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors022( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( short A1BarrioId )
      {
         /* Using cursor T00026 */
         pr_default.execute(4, new Object[] {A1BarrioId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'Barrio'.", "ForeignKeyNotFound", 1, "BARRIOID");
            AnyError = 1;
            GX_FocusControl = edtBarrioId_Internalname;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2BarrioNombre = T00026_A2BarrioNombre[0];
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A2BarrioNombre", A2BarrioNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         context.GX_webresponse.AddString("new Array( new Array(");
         context.GX_webresponse.AddString("\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A2BarrioNombre))+"\"");
         context.GX_webresponse.AddString(")");
         if ( (pr_default.getStatus(4) == 101) )
         {
            context.GX_webresponse.AddString(",");
            context.GX_webresponse.AddString("101");
         }
         context.GX_webresponse.AddString(")");
         pr_default.close(4);
      }

      protected void GetKey022( )
      {
         /* Using cursor T00027 */
         pr_default.execute(5, new Object[] {A3PropiedadId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00023 */
         pr_default.execute(1, new Object[] {A3PropiedadId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM022( 2) ;
            RcdFound2 = 1;
            A3PropiedadId = T00023_A3PropiedadId[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A3PropiedadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A3PropiedadId), 4, 0)));
            A4PropiedadDescripcion = T00023_A4PropiedadDescripcion[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A4PropiedadDescripcion", A4PropiedadDescripcion);
            A40000PropiedadFoto_GXI = T00023_A40000PropiedadFoto_GXI[0];
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgPropiedadFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A5PropiedadFoto)) ? A40000PropiedadFoto_GXI : context.convertURL( context.PathToRelativeUrl( A5PropiedadFoto))), true);
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgPropiedadFoto_Internalname, "SrcSet", context.GetImageSrcSet( A5PropiedadFoto), true);
            A6PropiedadDireccion = T00023_A6PropiedadDireccion[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6PropiedadDireccion", A6PropiedadDireccion);
            A1BarrioId = T00023_A1BarrioId[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A1BarrioId", StringUtil.LTrim( StringUtil.Str( (decimal)(A1BarrioId), 4, 0)));
            A5PropiedadFoto = T00023_A5PropiedadFoto[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A5PropiedadFoto", A5PropiedadFoto);
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgPropiedadFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A5PropiedadFoto)) ? A40000PropiedadFoto_GXI : context.convertURL( context.PathToRelativeUrl( A5PropiedadFoto))), true);
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgPropiedadFoto_Internalname, "SrcSet", context.GetImageSrcSet( A5PropiedadFoto), true);
            Z3PropiedadId = A3PropiedadId;
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
         pr_default.close(1);
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
         /* Using cursor T00028 */
         pr_default.execute(6, new Object[] {A3PropiedadId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00028_A3PropiedadId[0] < A3PropiedadId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00028_A3PropiedadId[0] > A3PropiedadId ) ) )
            {
               A3PropiedadId = T00028_A3PropiedadId[0];
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A3PropiedadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A3PropiedadId), 4, 0)));
               RcdFound2 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound2 = 0;
         /* Using cursor T00029 */
         pr_default.execute(7, new Object[] {A3PropiedadId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00029_A3PropiedadId[0] > A3PropiedadId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00029_A3PropiedadId[0] < A3PropiedadId ) ) )
            {
               A3PropiedadId = T00029_A3PropiedadId[0];
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A3PropiedadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A3PropiedadId), 4, 0)));
               RcdFound2 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey022( ) ;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            /* Insert record */
            GX_FocusControl = edtPropiedadId_Internalname;
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
               if ( A3PropiedadId != Z3PropiedadId )
               {
                  A3PropiedadId = Z3PropiedadId;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A3PropiedadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A3PropiedadId), 4, 0)));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PROPIEDADID");
                  AnyError = 1;
                  GX_FocusControl = edtPropiedadId_Internalname;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPropiedadId_Internalname;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update022( ) ;
                  GX_FocusControl = edtPropiedadId_Internalname;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A3PropiedadId != Z3PropiedadId )
               {
                  Gx_mode = "INS";
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtPropiedadId_Internalname;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PROPIEDADID");
                     AnyError = 1;
                     GX_FocusControl = edtPropiedadId_Internalname;
                     context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtPropiedadId_Internalname;
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
         if ( A3PropiedadId != Z3PropiedadId )
         {
            A3PropiedadId = Z3PropiedadId;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A3PropiedadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A3PropiedadId), 4, 0)));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PROPIEDADID");
            AnyError = 1;
            GX_FocusControl = edtPropiedadId_Internalname;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPropiedadId_Internalname;
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
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PROPIEDADID");
            AnyError = 1;
            GX_FocusControl = edtPropiedadId_Internalname;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtPropiedadDescripcion_Internalname;
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
         GX_FocusControl = edtPropiedadDescripcion_Internalname;
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
         GX_FocusControl = edtPropiedadDescripcion_Internalname;
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
         GX_FocusControl = edtPropiedadDescripcion_Internalname;
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
         GX_FocusControl = edtPropiedadDescripcion_Internalname;
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
            /* Using cursor T00022 */
            pr_default.execute(0, new Object[] {A3PropiedadId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Propiedad"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z4PropiedadDescripcion, T00022_A4PropiedadDescripcion[0]) != 0 ) || ( StringUtil.StrCmp(Z6PropiedadDireccion, T00022_A6PropiedadDireccion[0]) != 0 ) || ( Z1BarrioId != T00022_A1BarrioId[0] ) )
            {
               if ( StringUtil.StrCmp(Z4PropiedadDescripcion, T00022_A4PropiedadDescripcion[0]) != 0 )
               {
                  GXUtil.WriteLog("propiedad:[seudo value changed for attri]"+"PropiedadDescripcion");
                  GXUtil.WriteLogRaw("Old: ",Z4PropiedadDescripcion);
                  GXUtil.WriteLogRaw("Current: ",T00022_A4PropiedadDescripcion[0]);
               }
               if ( StringUtil.StrCmp(Z6PropiedadDireccion, T00022_A6PropiedadDireccion[0]) != 0 )
               {
                  GXUtil.WriteLog("propiedad:[seudo value changed for attri]"+"PropiedadDireccion");
                  GXUtil.WriteLogRaw("Old: ",Z6PropiedadDireccion);
                  GXUtil.WriteLogRaw("Current: ",T00022_A6PropiedadDireccion[0]);
               }
               if ( Z1BarrioId != T00022_A1BarrioId[0] )
               {
                  GXUtil.WriteLog("propiedad:[seudo value changed for attri]"+"BarrioId");
                  GXUtil.WriteLogRaw("Old: ",Z1BarrioId);
                  GXUtil.WriteLogRaw("Current: ",T00022_A1BarrioId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Propiedad"}), "RecordWasChanged", 1, "");
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
                     /* Using cursor T000210 */
                     pr_default.execute(8, new Object[] {A3PropiedadId, A4PropiedadDescripcion, A5PropiedadFoto, A40000PropiedadFoto_GXI, A6PropiedadDireccion, A1BarrioId});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("Propiedad") ;
                     if ( (pr_default.getStatus(8) == 1) )
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
                           GX_msglist.addItem(context.GetMessage( "GXM_sucadded", ""), "SuccessfullyAdded", 0, "", true);
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
                     /* Using cursor T000211 */
                     pr_default.execute(9, new Object[] {A4PropiedadDescripcion, A6PropiedadDireccion, A1BarrioId, A3PropiedadId});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("Propiedad") ;
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Propiedad"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate022( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           GX_msglist.addItem(context.GetMessage( "GXM_sucupdated", ""), "SuccessfullyUpdated", 0, "", true);
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
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void DeferredUpdate022( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000212 */
            pr_default.execute(10, new Object[] {A5PropiedadFoto, A40000PropiedadFoto_GXI, A3PropiedadId});
            pr_default.close(10);
            dsDefault.SmartCacheProvider.SetUpdated("Propiedad") ;
         }
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
                  /* No cascading delete specified. */
                  /* Using cursor T000213 */
                  pr_default.execute(11, new Object[] {A3PropiedadId});
                  pr_default.close(11);
                  dsDefault.SmartCacheProvider.SetUpdated("Propiedad") ;
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
            /* Using cursor T000214 */
            pr_default.execute(12, new Object[] {A1BarrioId});
            A2BarrioNombre = T000214_A2BarrioNombre[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A2BarrioNombre", A2BarrioNombre);
            pr_default.close(12);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000215 */
            pr_default.execute(13, new Object[] {A3PropiedadId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Alquiler"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T000216 */
            pr_default.execute(14, new Object[] {A3PropiedadId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Visita Pro"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void EndLevel022( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete022( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(12);
            pr_default.commit( "Propiedad");
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
            pr_default.close(1);
            pr_default.close(12);
            pr_default.rollback( "Propiedad");
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
         /* Using cursor T000217 */
         pr_default.execute(15);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound2 = 1;
            A3PropiedadId = T000217_A3PropiedadId[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A3PropiedadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A3PropiedadId), 4, 0)));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext022( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound2 = 1;
            A3PropiedadId = T000217_A3PropiedadId[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A3PropiedadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A3PropiedadId), 4, 0)));
         }
      }

      protected void ScanEnd022( )
      {
         pr_default.close(15);
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
         edtPropiedadId_Enabled = 0;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtPropiedadId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtPropiedadId_Enabled), 5, 0)), true);
         edtPropiedadDescripcion_Enabled = 0;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtPropiedadDescripcion_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtPropiedadDescripcion_Enabled), 5, 0)), true);
         imgPropiedadFoto_Enabled = 0;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgPropiedadFoto_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(imgPropiedadFoto_Enabled), 5, 0)), true);
         edtPropiedadDireccion_Enabled = 0;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtPropiedadDireccion_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtPropiedadDireccion_Enabled), 5, 0)), true);
         edtBarrioId_Enabled = 0;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtBarrioId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtBarrioId_Enabled), 5, 0)), true);
         edtBarrioNombre_Enabled = 0;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtBarrioNombre_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtBarrioNombre_Enabled), 5, 0)), true);
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues020( )
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
         context.AddJavascriptSource("gxcfg.js", "?201791420183074", false);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("propiedad.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z3PropiedadId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z3PropiedadId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z4PropiedadDescripcion", StringUtil.RTrim( Z4PropiedadDescripcion));
         GxWebStd.gx_hidden_field( context, "Z6PropiedadDireccion", StringUtil.RTrim( Z6PropiedadDireccion));
         GxWebStd.gx_hidden_field( context, "Z1BarrioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1BarrioId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "PROPIEDADFOTO_GXI", A40000PropiedadFoto_GXI);
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GXCCtlgxBlob = "PROPIEDADFOTO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A5PropiedadFoto);
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
         return formatLink("propiedad.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "Propiedad" ;
      }

      public override String GetPgmdesc( )
      {
         return "Propiedad" ;
      }

      protected void InitializeNonKey022( )
      {
         A4PropiedadDescripcion = "";
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A4PropiedadDescripcion", A4PropiedadDescripcion);
         A5PropiedadFoto = "";
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A5PropiedadFoto", A5PropiedadFoto);
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgPropiedadFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A5PropiedadFoto)) ? A40000PropiedadFoto_GXI : context.convertURL( context.PathToRelativeUrl( A5PropiedadFoto))), true);
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgPropiedadFoto_Internalname, "SrcSet", context.GetImageSrcSet( A5PropiedadFoto), true);
         A40000PropiedadFoto_GXI = "";
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgPropiedadFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A5PropiedadFoto)) ? A40000PropiedadFoto_GXI : context.convertURL( context.PathToRelativeUrl( A5PropiedadFoto))), true);
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, imgPropiedadFoto_Internalname, "SrcSet", context.GetImageSrcSet( A5PropiedadFoto), true);
         A6PropiedadDireccion = "";
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A6PropiedadDireccion", A6PropiedadDireccion);
         A1BarrioId = 0;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A1BarrioId", StringUtil.LTrim( StringUtil.Str( (decimal)(A1BarrioId), 4, 0)));
         A2BarrioNombre = "";
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A2BarrioNombre", A2BarrioNombre);
         Z4PropiedadDescripcion = "";
         Z6PropiedadDireccion = "";
         Z1BarrioId = 0;
      }

      protected void InitAll022( )
      {
         A3PropiedadId = 0;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A3PropiedadId", StringUtil.LTrim( StringUtil.Str( (decimal)(A3PropiedadId), 4, 0)));
         InitializeNonKey022( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?201791420183079", true);
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
         context.AddJavascriptSource("propiedad.js", "?201791420183079", false);
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
         edtPropiedadId_Internalname = "PROPIEDADID";
         edtPropiedadDescripcion_Internalname = "PROPIEDADDESCRIPCION";
         imgPropiedadFoto_Internalname = "PROPIEDADFOTO";
         edtPropiedadDireccion_Internalname = "PROPIEDADDIRECCION";
         edtBarrioId_Internalname = "BARRIOID";
         edtBarrioNombre_Internalname = "BARRIONOMBRE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_1_Internalname = "PROMPT_1";
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
         Form.Caption = "Propiedad";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtBarrioNombre_Jsonclick = "";
         edtBarrioNombre_Enabled = 0;
         imgprompt_1_Visible = 1;
         imgprompt_1_Link = "";
         edtBarrioId_Jsonclick = "";
         edtBarrioId_Enabled = 1;
         edtPropiedadDireccion_Jsonclick = "";
         edtPropiedadDireccion_Enabled = 1;
         imgPropiedadFoto_Enabled = 1;
         edtPropiedadDescripcion_Jsonclick = "";
         edtPropiedadDescripcion_Enabled = 1;
         edtPropiedadId_Jsonclick = "";
         edtPropiedadId_Enabled = 1;
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
         GX_FocusControl = edtPropiedadDescripcion_Internalname;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
      }

      public void Valid_Propiedadid( short GX_Parm1 ,
                                     String GX_Parm2 ,
                                     String GX_Parm3 ,
                                     String GX_Parm4 ,
                                     String GX_Parm5 ,
                                     short GX_Parm6 )
      {
         A3PropiedadId = GX_Parm1;
         A4PropiedadDescripcion = GX_Parm2;
         A5PropiedadFoto = GX_Parm3;
         A40000PropiedadFoto_GXI = GX_Parm4;
         A6PropiedadDireccion = GX_Parm5;
         A1BarrioId = GX_Parm6;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
         dynload_actions( ) ;
         if ( AnyError == 1 )
         {
            A2BarrioNombre = "";
         }
         isValidOutput.Add(StringUtil.RTrim( A4PropiedadDescripcion));
         isValidOutput.Add(context.PathToRelativeUrl( A5PropiedadFoto));
         isValidOutput.Add(A5PropiedadFoto);
         isValidOutput.Add(A40000PropiedadFoto_GXI);
         isValidOutput.Add(StringUtil.RTrim( A6PropiedadDireccion));
         isValidOutput.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1BarrioId), 4, 0, ".", "")));
         isValidOutput.Add(StringUtil.RTrim( A2BarrioNombre));
         isValidOutput.Add(StringUtil.RTrim( Gx_mode));
         isValidOutput.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(Z3PropiedadId), 4, 0, ".", "")));
         isValidOutput.Add(StringUtil.RTrim( Z4PropiedadDescripcion));
         isValidOutput.Add(context.PathToRelativeUrl( Z5PropiedadFoto));
         isValidOutput.Add(Z40000PropiedadFoto_GXI);
         isValidOutput.Add(StringUtil.RTrim( Z6PropiedadDireccion));
         isValidOutput.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1BarrioId), 4, 0, ".", "")));
         isValidOutput.Add(StringUtil.RTrim( Z2BarrioNombre));
         isValidOutput.Add(bttBtn_delete_Enabled);
         isValidOutput.Add(bttBtn_enter_Enabled);
         isValidOutput.Add(context.GX_msglist.ToJavascriptSource());
         isValidOutput.Add(context.httpAjaxContext.ajax_rsp_get_hiddens( ));
         context.GX_webresponse.AddString(isValidOutput.ToJSonString());
         wbTemp = context.ResponseContentType( "application/json");
      }

      public void Valid_Barrioid( short GX_Parm1 ,
                                  String GX_Parm2 )
      {
         A1BarrioId = GX_Parm1;
         A2BarrioNombre = GX_Parm2;
         /* Using cursor T000214 */
         pr_default.execute(12, new Object[] {A1BarrioId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No matching 'Barrio'.", "ForeignKeyNotFound", 1, "BARRIOID");
            AnyError = 1;
            GX_FocusControl = edtBarrioId_Internalname;
         }
         A2BarrioNombre = T000214_A2BarrioNombre[0];
         pr_default.close(12);
         dynload_actions( ) ;
         if ( AnyError == 1 )
         {
            A2BarrioNombre = "";
         }
         isValidOutput.Add(StringUtil.RTrim( A2BarrioNombre));
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
         pr_default.close(12);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z4PropiedadDescripcion = "";
         Z6PropiedadDireccion = "";
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
         A4PropiedadDescripcion = "";
         A5PropiedadFoto = "";
         A40000PropiedadFoto_GXI = "";
         sImgUrl = "";
         A6PropiedadDireccion = "";
         A2BarrioNombre = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         Z5PropiedadFoto = "";
         Z40000PropiedadFoto_GXI = "";
         Z2BarrioNombre = "";
         T00025_A3PropiedadId = new short[1] ;
         T00025_A4PropiedadDescripcion = new String[] {""} ;
         T00025_A40000PropiedadFoto_GXI = new String[] {""} ;
         T00025_A6PropiedadDireccion = new String[] {""} ;
         T00025_A2BarrioNombre = new String[] {""} ;
         T00025_A1BarrioId = new short[1] ;
         T00025_A5PropiedadFoto = new String[] {""} ;
         T00024_A2BarrioNombre = new String[] {""} ;
         T00026_A2BarrioNombre = new String[] {""} ;
         T00027_A3PropiedadId = new short[1] ;
         T00023_A3PropiedadId = new short[1] ;
         T00023_A4PropiedadDescripcion = new String[] {""} ;
         T00023_A40000PropiedadFoto_GXI = new String[] {""} ;
         T00023_A6PropiedadDireccion = new String[] {""} ;
         T00023_A1BarrioId = new short[1] ;
         T00023_A5PropiedadFoto = new String[] {""} ;
         sMode2 = "";
         T00028_A3PropiedadId = new short[1] ;
         T00029_A3PropiedadId = new short[1] ;
         T00022_A3PropiedadId = new short[1] ;
         T00022_A4PropiedadDescripcion = new String[] {""} ;
         T00022_A40000PropiedadFoto_GXI = new String[] {""} ;
         T00022_A6PropiedadDireccion = new String[] {""} ;
         T00022_A1BarrioId = new short[1] ;
         T00022_A5PropiedadFoto = new String[] {""} ;
         T000214_A2BarrioNombre = new String[] {""} ;
         T000215_A7AlquilerId = new short[1] ;
         T000216_A9VisitasId = new short[1] ;
         T000216_A3PropiedadId = new short[1] ;
         T000217_A3PropiedadId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         isValidOutput = new GxUnknownObjectCollection();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.propiedad__default(),
            new Object[][] {
                new Object[] {
               T00022_A3PropiedadId, T00022_A4PropiedadDescripcion, T00022_A40000PropiedadFoto_GXI, T00022_A6PropiedadDireccion, T00022_A1BarrioId, T00022_A5PropiedadFoto
               }
               , new Object[] {
               T00023_A3PropiedadId, T00023_A4PropiedadDescripcion, T00023_A40000PropiedadFoto_GXI, T00023_A6PropiedadDireccion, T00023_A1BarrioId, T00023_A5PropiedadFoto
               }
               , new Object[] {
               T00024_A2BarrioNombre
               }
               , new Object[] {
               T00025_A3PropiedadId, T00025_A4PropiedadDescripcion, T00025_A40000PropiedadFoto_GXI, T00025_A6PropiedadDireccion, T00025_A2BarrioNombre, T00025_A1BarrioId, T00025_A5PropiedadFoto
               }
               , new Object[] {
               T00026_A2BarrioNombre
               }
               , new Object[] {
               T00027_A3PropiedadId
               }
               , new Object[] {
               T00028_A3PropiedadId
               }
               , new Object[] {
               T00029_A3PropiedadId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000214_A2BarrioNombre
               }
               , new Object[] {
               T000215_A7AlquilerId
               }
               , new Object[] {
               T000216_A9VisitasId, T000216_A3PropiedadId
               }
               , new Object[] {
               T000217_A3PropiedadId
               }
            }
         );
      }

      private short Z3PropiedadId ;
      private short Z1BarrioId ;
      private short GxWebError ;
      private short A1BarrioId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A3PropiedadId ;
      private short GX_JID ;
      private short RcdFound2 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short wbTemp ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtPropiedadId_Enabled ;
      private int edtPropiedadDescripcion_Enabled ;
      private int imgPropiedadFoto_Enabled ;
      private int edtPropiedadDireccion_Enabled ;
      private int edtBarrioId_Enabled ;
      private int imgprompt_1_Visible ;
      private int edtBarrioNombre_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private String sPrefix ;
      private String Z4PropiedadDescripcion ;
      private String Z6PropiedadDireccion ;
      private String scmdbuf ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String GXKey ;
      private String PreviousTooltip ;
      private String PreviousCaption ;
      private String GX_FocusControl ;
      private String edtPropiedadId_Internalname ;
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
      private String edtPropiedadId_Jsonclick ;
      private String edtPropiedadDescripcion_Internalname ;
      private String A4PropiedadDescripcion ;
      private String edtPropiedadDescripcion_Jsonclick ;
      private String imgPropiedadFoto_Internalname ;
      private String sImgUrl ;
      private String edtPropiedadDireccion_Internalname ;
      private String A6PropiedadDireccion ;
      private String edtPropiedadDireccion_Jsonclick ;
      private String edtBarrioId_Internalname ;
      private String edtBarrioId_Jsonclick ;
      private String imgprompt_1_Internalname ;
      private String imgprompt_1_Link ;
      private String edtBarrioNombre_Internalname ;
      private String A2BarrioNombre ;
      private String edtBarrioNombre_Jsonclick ;
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
      private String Z2BarrioNombre ;
      private String sMode2 ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXCCtlgxBlob ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A5PropiedadFoto_IsBlob ;
      private String A40000PropiedadFoto_GXI ;
      private String Z40000PropiedadFoto_GXI ;
      private String A5PropiedadFoto ;
      private String Z5PropiedadFoto ;
      private GxUnknownObjectCollection isValidOutput ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T00025_A3PropiedadId ;
      private String[] T00025_A4PropiedadDescripcion ;
      private String[] T00025_A40000PropiedadFoto_GXI ;
      private String[] T00025_A6PropiedadDireccion ;
      private String[] T00025_A2BarrioNombre ;
      private short[] T00025_A1BarrioId ;
      private String[] T00025_A5PropiedadFoto ;
      private String[] T00024_A2BarrioNombre ;
      private String[] T00026_A2BarrioNombre ;
      private short[] T00027_A3PropiedadId ;
      private short[] T00023_A3PropiedadId ;
      private String[] T00023_A4PropiedadDescripcion ;
      private String[] T00023_A40000PropiedadFoto_GXI ;
      private String[] T00023_A6PropiedadDireccion ;
      private short[] T00023_A1BarrioId ;
      private String[] T00023_A5PropiedadFoto ;
      private short[] T00028_A3PropiedadId ;
      private short[] T00029_A3PropiedadId ;
      private short[] T00022_A3PropiedadId ;
      private String[] T00022_A4PropiedadDescripcion ;
      private String[] T00022_A40000PropiedadFoto_GXI ;
      private String[] T00022_A6PropiedadDireccion ;
      private short[] T00022_A1BarrioId ;
      private String[] T00022_A5PropiedadFoto ;
      private String[] T000214_A2BarrioNombre ;
      private short[] T000215_A7AlquilerId ;
      private short[] T000216_A9VisitasId ;
      private short[] T000216_A3PropiedadId ;
      private short[] T000217_A3PropiedadId ;
      private GXWebForm Form ;
   }

   public class propiedad__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00025 ;
          prmT00025 = new Object[] {
          new Object[] {"@PropiedadId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT00024 ;
          prmT00024 = new Object[] {
          new Object[] {"@BarrioId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT00026 ;
          prmT00026 = new Object[] {
          new Object[] {"@BarrioId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT00027 ;
          prmT00027 = new Object[] {
          new Object[] {"@PropiedadId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT00023 ;
          prmT00023 = new Object[] {
          new Object[] {"@PropiedadId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT00028 ;
          prmT00028 = new Object[] {
          new Object[] {"@PropiedadId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT00029 ;
          prmT00029 = new Object[] {
          new Object[] {"@PropiedadId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT00022 ;
          prmT00022 = new Object[] {
          new Object[] {"@PropiedadId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000210 ;
          prmT000210 = new Object[] {
          new Object[] {"@PropiedadId",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@PropiedadDescripcion",SqlDbType.Char,50,0} ,
          new Object[] {"@PropiedadFoto",SqlDbType.VarBinary,1024,0} ,
          new Object[] {"@PropiedadFoto_GXI",SqlDbType.VarChar,2048,0} ,
          new Object[] {"@PropiedadDireccion",SqlDbType.Char,50,0} ,
          new Object[] {"@BarrioId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000211 ;
          prmT000211 = new Object[] {
          new Object[] {"@PropiedadDescripcion",SqlDbType.Char,50,0} ,
          new Object[] {"@PropiedadDireccion",SqlDbType.Char,50,0} ,
          new Object[] {"@BarrioId",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@PropiedadId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000212 ;
          prmT000212 = new Object[] {
          new Object[] {"@PropiedadFoto",SqlDbType.VarBinary,1024,0} ,
          new Object[] {"@PropiedadFoto_GXI",SqlDbType.VarChar,2048,0} ,
          new Object[] {"@PropiedadId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000213 ;
          prmT000213 = new Object[] {
          new Object[] {"@PropiedadId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000215 ;
          prmT000215 = new Object[] {
          new Object[] {"@PropiedadId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000216 ;
          prmT000216 = new Object[] {
          new Object[] {"@PropiedadId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000217 ;
          prmT000217 = new Object[] {
          } ;
          Object[] prmT000214 ;
          prmT000214 = new Object[] {
          new Object[] {"@BarrioId",SqlDbType.SmallInt,4,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("T00022", "SELECT [PropiedadId], [PropiedadDescripcion], [PropiedadFoto_GXI], [PropiedadDireccion], [BarrioId], [PropiedadFoto] FROM [Propiedad] WITH (UPDLOCK) WHERE [PropiedadId] = @PropiedadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00022,1,0,true,false )
             ,new CursorDef("T00023", "SELECT [PropiedadId], [PropiedadDescripcion], [PropiedadFoto_GXI], [PropiedadDireccion], [BarrioId], [PropiedadFoto] FROM [Propiedad] WITH (NOLOCK) WHERE [PropiedadId] = @PropiedadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00023,1,0,true,false )
             ,new CursorDef("T00024", "SELECT [BarrioNombre] FROM [Barrio] WITH (NOLOCK) WHERE [BarrioId] = @BarrioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00024,1,0,true,false )
             ,new CursorDef("T00025", "SELECT TM1.[PropiedadId], TM1.[PropiedadDescripcion], TM1.[PropiedadFoto_GXI], TM1.[PropiedadDireccion], T2.[BarrioNombre], TM1.[BarrioId], TM1.[PropiedadFoto] FROM ([Propiedad] TM1 WITH (NOLOCK) INNER JOIN [Barrio] T2 WITH (NOLOCK) ON T2.[BarrioId] = TM1.[BarrioId]) WHERE TM1.[PropiedadId] = @PropiedadId ORDER BY TM1.[PropiedadId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00025,100,0,true,false )
             ,new CursorDef("T00026", "SELECT [BarrioNombre] FROM [Barrio] WITH (NOLOCK) WHERE [BarrioId] = @BarrioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00026,1,0,true,false )
             ,new CursorDef("T00027", "SELECT [PropiedadId] FROM [Propiedad] WITH (NOLOCK) WHERE [PropiedadId] = @PropiedadId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00027,1,0,true,false )
             ,new CursorDef("T00028", "SELECT TOP 1 [PropiedadId] FROM [Propiedad] WITH (NOLOCK) WHERE ( [PropiedadId] > @PropiedadId) ORDER BY [PropiedadId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00028,1,0,true,true )
             ,new CursorDef("T00029", "SELECT TOP 1 [PropiedadId] FROM [Propiedad] WITH (NOLOCK) WHERE ( [PropiedadId] < @PropiedadId) ORDER BY [PropiedadId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00029,1,0,true,true )
             ,new CursorDef("T000210", "INSERT INTO [Propiedad]([PropiedadId], [PropiedadDescripcion], [PropiedadFoto], [PropiedadFoto_GXI], [PropiedadDireccion], [BarrioId]) VALUES(@PropiedadId, @PropiedadDescripcion, @PropiedadFoto, @PropiedadFoto_GXI, @PropiedadDireccion, @BarrioId)", GxErrorMask.GX_NOMASK,prmT000210)
             ,new CursorDef("T000211", "UPDATE [Propiedad] SET [PropiedadDescripcion]=@PropiedadDescripcion, [PropiedadDireccion]=@PropiedadDireccion, [BarrioId]=@BarrioId  WHERE [PropiedadId] = @PropiedadId", GxErrorMask.GX_NOMASK,prmT000211)
             ,new CursorDef("T000212", "UPDATE [Propiedad] SET [PropiedadFoto]=@PropiedadFoto, [PropiedadFoto_GXI]=@PropiedadFoto_GXI  WHERE [PropiedadId] = @PropiedadId", GxErrorMask.GX_NOMASK,prmT000212)
             ,new CursorDef("T000213", "DELETE FROM [Propiedad]  WHERE [PropiedadId] = @PropiedadId", GxErrorMask.GX_NOMASK,prmT000213)
             ,new CursorDef("T000214", "SELECT [BarrioNombre] FROM [Barrio] WITH (NOLOCK) WHERE [BarrioId] = @BarrioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000214,1,0,true,false )
             ,new CursorDef("T000215", "SELECT TOP 1 [AlquilerId] FROM [Alquiler] WITH (NOLOCK) WHERE [PropiedadId] = @PropiedadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000215,1,0,true,true )
             ,new CursorDef("T000216", "SELECT TOP 1 [VisitasId], [PropiedadId] FROM [VisitasVisitaPro] WITH (NOLOCK) WHERE [PropiedadId] = @PropiedadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000216,1,0,true,true )
             ,new CursorDef("T000217", "SELECT [PropiedadId] FROM [Propiedad] WITH (NOLOCK) ORDER BY [PropiedadId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000217,100,0,true,false )
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
                ((String[]) buf[1])[0] = rslt.getString(2, 50) ;
                ((String[]) buf[2])[0] = rslt.getMultimediaUri(3) ;
                ((String[]) buf[3])[0] = rslt.getString(4, 50) ;
                ((short[]) buf[4])[0] = rslt.getShort(5) ;
                ((String[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3)) ;
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 50) ;
                ((String[]) buf[2])[0] = rslt.getMultimediaUri(3) ;
                ((String[]) buf[3])[0] = rslt.getString(4, 50) ;
                ((short[]) buf[4])[0] = rslt.getShort(5) ;
                ((String[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3)) ;
                return;
             case 2 :
                ((String[]) buf[0])[0] = rslt.getString(1, 50) ;
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 50) ;
                ((String[]) buf[2])[0] = rslt.getMultimediaUri(3) ;
                ((String[]) buf[3])[0] = rslt.getString(4, 50) ;
                ((String[]) buf[4])[0] = rslt.getString(5, 50) ;
                ((short[]) buf[5])[0] = rslt.getShort(6) ;
                ((String[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(3)) ;
                return;
             case 4 :
                ((String[]) buf[0])[0] = rslt.getString(1, 50) ;
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
             case 12 :
                ((String[]) buf[0])[0] = rslt.getString(1, 50) ;
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                return;
             case 15 :
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
                stmt.SetParameter(1, (short)parms[0]);
                stmt.SetParameter(2, (String)parms[1]);
                stmt.SetParameterBlob(3, (String)parms[2], false);
                stmt.SetParameterMultimedia(4, (String)parms[3], (String)parms[2], "Propiedad", "PropiedadFoto");
                stmt.SetParameter(5, (String)parms[4]);
                stmt.SetParameter(6, (short)parms[5]);
                return;
             case 9 :
                stmt.SetParameter(1, (String)parms[0]);
                stmt.SetParameter(2, (String)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                stmt.SetParameter(4, (short)parms[3]);
                return;
             case 10 :
                stmt.SetParameterBlob(1, (String)parms[0], false);
                stmt.SetParameterMultimedia(2, (String)parms[1], (String)parms[0], "Propiedad", "PropiedadFoto");
                stmt.SetParameter(3, (short)parms[2]);
                return;
             case 11 :
                stmt.SetParameter(1, (short)parms[0]);
                return;
             case 12 :
                stmt.SetParameter(1, (short)parms[0]);
                return;
             case 13 :
                stmt.SetParameter(1, (short)parms[0]);
                return;
             case 14 :
                stmt.SetParameter(1, (short)parms[0]);
                return;
       }
    }

 }

}
