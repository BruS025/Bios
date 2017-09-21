/*
               File: Visitas
        Description: Visitas
             Author: GeneXus C# Generator version 15_0_6-116888
       Generated on: 9/14/2017 20:10:41.60
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
   public class visitas : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A3PropiedadId = (short)(NumberUtil.Val( GetNextPar( ), "."));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A3PropiedadId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridvisitas_visitapro") == 0 )
         {
            nRC_GXsfl_46 = (short)(NumberUtil.Val( GetNextPar( ), "."));
            nGXsfl_46_idx = (short)(NumberUtil.Val( GetNextPar( ), "."));
            sGXsfl_46_idx = GetNextPar( );
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxnrGridvisitas_visitapro_newrow( ) ;
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
            Form.Meta.addItem("description", "Visitas", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         GX_FocusControl = edtVisitasId_Internalname;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public visitas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public visitas( IGxContext context )
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
            GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Visitas", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, "HLP_Visitas.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Visitas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "BtnPrevious";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Visitas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
            ClassString = "BtnNext";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Visitas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
            ClassString = "BtnLast";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Visitas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            ClassString = "BtnSelect";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 4, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0040.aspx"+"',["+"{Ctrl:gx.dom.el('"+"VISITASID"+"'), id:'"+"VISITASID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Visitas.htm");
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
            GxWebStd.gx_label_element( context, edtVisitasId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true);
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtVisitasId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9VisitasId), 4, 0, ".", "")), ((edtVisitasId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A9VisitasId), "ZZZ9")) : context.localUtil.Format( (decimal)(A9VisitasId), "ZZZ9")), TempTags+" onchange=\"gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVisitasId_Jsonclick, 0, "Attribute", "", "", "", 1, edtVisitasId_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "HLP_Visitas.htm");
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
            GxWebStd.gx_label_element( context, edtVisitasFecha_Internalname, "Fecha", "col-sm-3 AttributeLabel", 1, true);
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtVisitasFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtVisitasFecha_Internalname, context.localUtil.TToC( A10VisitasFecha, 10, 8, 1, 2, "/", ":", " "), context.localUtil.Format( A10VisitasFecha, "99/99/99 99:99"), TempTags+" onchange=\"gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',5,12,'eng',false,0);"+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVisitasFecha_Jsonclick, 0, "Attribute", "", "", "", 1, edtVisitasFecha_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "", "right", false, "HLP_Visitas.htm");
            GxWebStd.gx_bitmap( context, edtVisitasFecha_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtVisitasFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Visitas.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 LevelTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divVisitaprotable_Internalname, 1, 0, "px", 0, "px", "LevelTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitlevisitapro_Internalname, "Visita Pro", "", "", lblTitlevisitapro_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, "HLP_Visitas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            gxdraw_Gridvisitas_visitapro( ) ;
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Visitas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Visitas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
            ClassString = "BtnDelete";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Visitas.htm");
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

      protected void gxdraw_Gridvisitas_visitapro( )
      {
         /*  Grid Control  */
         Gridvisitas_visitaproContainer.AddObjectProperty("GridName", "Gridvisitas_visitapro");
         Gridvisitas_visitaproContainer.AddObjectProperty("Class", "Grid");
         Gridvisitas_visitaproContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridvisitas_visitaproContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridvisitas_visitaproContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridvisitas_visitapro_Backcolorstyle), 1, 0, ".", "")));
         Gridvisitas_visitaproContainer.AddObjectProperty("CmpContext", "");
         Gridvisitas_visitaproContainer.AddObjectProperty("InMasterPage", "false");
         Gridvisitas_visitaproColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridvisitas_visitaproColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A3PropiedadId), 4, 0, ".", "")));
         Gridvisitas_visitaproColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPropiedadId_Enabled), 5, 0, ".", "")));
         Gridvisitas_visitaproContainer.AddColumnProperties(Gridvisitas_visitaproColumn);
         Gridvisitas_visitaproColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridvisitas_visitaproContainer.AddColumnProperties(Gridvisitas_visitaproColumn);
         Gridvisitas_visitaproColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridvisitas_visitaproColumn.AddObjectProperty("Value", StringUtil.RTrim( A6PropiedadDireccion));
         Gridvisitas_visitaproColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPropiedadDireccion_Enabled), 5, 0, ".", "")));
         Gridvisitas_visitaproContainer.AddColumnProperties(Gridvisitas_visitaproColumn);
         Gridvisitas_visitaproContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridvisitas_visitapro_Allowselection), 1, 0, ".", "")));
         Gridvisitas_visitaproContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridvisitas_visitapro_Selectioncolor), 9, 0, ".", "")));
         Gridvisitas_visitaproContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridvisitas_visitapro_Allowhovering), 1, 0, ".", "")));
         Gridvisitas_visitaproContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridvisitas_visitapro_Hoveringcolor), 9, 0, ".", "")));
         Gridvisitas_visitaproContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridvisitas_visitapro_Allowcollapsing), 1, 0, ".", "")));
         Gridvisitas_visitaproContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridvisitas_visitapro_Collapsed), 1, 0, ".", "")));
         nGXsfl_46_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount5 = 5;
            if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
            {
               /* Display confirmed (stored) records */
               nRcdExists_5 = 1;
               ScanStart045( ) ;
               while ( RcdFound5 != 0 )
               {
                  init_level_properties5( ) ;
                  getByPrimaryKey045( ) ;
                  AddRow045( ) ;
                  ScanNext045( ) ;
               }
               ScanEnd045( ) ;
               nBlankRcdCount5 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal045( ) ;
            standaloneModal045( ) ;
            sMode5 = Gx_mode;
            while ( nGXsfl_46_idx < nRC_GXsfl_46 )
            {
               bGXsfl_46_Refreshing = true;
               ReadRow045( ) ;
               edtPropiedadId_Enabled = (int)(context.localUtil.CToN( cgiGet( "PROPIEDADID_"+sGXsfl_46_idx+"Enabled"), ".", ","));
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtPropiedadId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtPropiedadId_Enabled), 5, 0)), !bGXsfl_46_Refreshing);
               edtPropiedadDireccion_Enabled = (int)(context.localUtil.CToN( cgiGet( "PROPIEDADDIRECCION_"+sGXsfl_46_idx+"Enabled"), ".", ","));
               context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtPropiedadDireccion_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtPropiedadDireccion_Enabled), 5, 0)), !bGXsfl_46_Refreshing);
               imgprompt_3_Link = cgiGet( "PROMPT_3_"+sGXsfl_46_idx+"Link");
               if ( ( nRcdExists_5 == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) )
               {
                  Gx_mode = "INS";
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                  standaloneModal045( ) ;
               }
               SendRow045( ) ;
               bGXsfl_46_Refreshing = false;
            }
            Gx_mode = sMode5;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount5 = 5;
            nRcdExists_5 = 1;
            if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
            {
               ScanStart045( ) ;
               while ( RcdFound5 != 0 )
               {
                  sGXsfl_46_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_46_idx+1), 4, 0)), 4, "0");
                  SubsflControlProps_465( ) ;
                  init_level_properties5( ) ;
                  standaloneNotModal045( ) ;
                  getByPrimaryKey045( ) ;
                  standaloneModal045( ) ;
                  AddRow045( ) ;
                  ScanNext045( ) ;
               }
               ScanEnd045( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         sMode5 = Gx_mode;
         Gx_mode = "INS";
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         sGXsfl_46_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_46_idx+1), 4, 0)), 4, "0");
         SubsflControlProps_465( ) ;
         InitAll045( ) ;
         init_level_properties5( ) ;
         standaloneNotModal045( ) ;
         standaloneModal045( ) ;
         nRcdExists_5 = 0;
         nIsMod_5 = 0;
         nRcdDeleted_5 = 0;
         nBlankRcdCount5 = (short)(nBlankRcdUsr5+nBlankRcdCount5);
         fRowAdded = 0;
         while ( nBlankRcdCount5 > 0 )
         {
            AddRow045( ) ;
            if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
            {
               fRowAdded = 1;
               GX_FocusControl = edtPropiedadId_Internalname;
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nBlankRcdCount5 = (short)(nBlankRcdCount5-1);
         }
         Gx_mode = sMode5;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridvisitas_visitaproContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridvisitas_visitapro", Gridvisitas_visitaproContainer);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridvisitas_visitaproContainerData", Gridvisitas_visitaproContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridvisitas_visitaproContainerData"+"V", Gridvisitas_visitaproContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridvisitas_visitaproContainerData"+"V"+"\" value='"+Gridvisitas_visitaproContainer.GridValuesHidden()+"'/>") ;
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
               if ( ( ( context.localUtil.CToN( cgiGet( edtVisitasId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtVisitasId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VISITASID");
                  AnyError = 1;
                  GX_FocusControl = edtVisitasId_Internalname;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A9VisitasId = 0;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9VisitasId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9VisitasId), 4, 0)));
               }
               else
               {
                  A9VisitasId = (short)(context.localUtil.CToN( cgiGet( edtVisitasId_Internalname), ".", ","));
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9VisitasId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9VisitasId), 4, 0)));
               }
               if ( context.localUtil.VCDateTime( cgiGet( edtVisitasFecha_Internalname), 1, 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Visitas Fecha"}), 1, "VISITASFECHA");
                  AnyError = 1;
                  GX_FocusControl = edtVisitasFecha_Internalname;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A10VisitasFecha = (DateTime)(DateTime.MinValue);
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A10VisitasFecha", context.localUtil.TToC( A10VisitasFecha, 8, 5, 1, 2, "/", ":", " "));
               }
               else
               {
                  A10VisitasFecha = context.localUtil.CToT( cgiGet( edtVisitasFecha_Internalname));
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A10VisitasFecha", context.localUtil.TToC( A10VisitasFecha, 8, 5, 1, 2, "/", ":", " "));
               }
               /* Read saved values. */
               Z9VisitasId = (short)(context.localUtil.CToN( cgiGet( "Z9VisitasId"), ".", ","));
               Z10VisitasFecha = context.localUtil.CToT( cgiGet( "Z10VisitasFecha"), 0);
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_46 = (short)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_46"), ".", ","));
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
                  A9VisitasId = (short)(NumberUtil.Val( GetNextPar( ), "."));
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9VisitasId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9VisitasId), 4, 0)));
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
               InitAll044( ) ;
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
         DisableAttributes044( ) ;
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

      protected void CONFIRM_045( )
      {
         nGXsfl_46_idx = 0;
         while ( nGXsfl_46_idx < nRC_GXsfl_46 )
         {
            ReadRow045( ) ;
            if ( ( nRcdExists_5 != 0 ) || ( nIsMod_5 != 0 ) )
            {
               GetKey045( ) ;
               if ( ( nRcdExists_5 == 0 ) && ( nRcdDeleted_5 == 0 ) )
               {
                  if ( RcdFound5 == 0 )
                  {
                     Gx_mode = "INS";
                     context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate045( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable045( ) ;
                        CloseExtendedTableCursors045( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           context.httpAjaxContext.ajax_rsp_assign_attri("", false, "IsConfirmed", StringUtil.LTrim( StringUtil.Str( (decimal)(IsConfirmed), 4, 0)));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "PROPIEDADID_" + sGXsfl_46_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtPropiedadId_Internalname;
                     context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound5 != 0 )
                  {
                     if ( nRcdDeleted_5 != 0 )
                     {
                        Gx_mode = "DLT";
                        context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey045( ) ;
                        Load045( ) ;
                        BeforeValidate045( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls045( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_5 != 0 )
                        {
                           Gx_mode = "UPD";
                           context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate045( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable045( ) ;
                              CloseExtendedTableCursors045( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 context.httpAjaxContext.ajax_rsp_assign_attri("", false, "IsConfirmed", StringUtil.LTrim( StringUtil.Str( (decimal)(IsConfirmed), 4, 0)));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_5 == 0 )
                     {
                        GXCCtl = "PROPIEDADID_" + sGXsfl_46_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtPropiedadId_Internalname;
                        context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtPropiedadId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A3PropiedadId), 4, 0, ".", ""))) ;
            ChangePostValue( edtPropiedadDireccion_Internalname, StringUtil.RTrim( A6PropiedadDireccion)) ;
            ChangePostValue( "ZT_"+"Z3PropiedadId_"+sGXsfl_46_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z3PropiedadId), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_5_"+sGXsfl_46_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_5), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_5_"+sGXsfl_46_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_5), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_5_"+sGXsfl_46_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_5), 4, 0, ".", ""))) ;
            if ( nIsMod_5 != 0 )
            {
               ChangePostValue( "PROPIEDADID_"+sGXsfl_46_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPropiedadId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROPIEDADDIRECCION_"+sGXsfl_46_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPropiedadDireccion_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption040( )
      {
      }

      protected void ZM044( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
            {
               Z10VisitasFecha = T00046_A10VisitasFecha[0];
            }
            else
            {
               Z10VisitasFecha = A10VisitasFecha;
            }
         }
         if ( GX_JID == -2 )
         {
            Z9VisitasId = A9VisitasId;
            Z10VisitasFecha = A10VisitasFecha;
         }
      }

      protected void standaloneNotModal( )
      {
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

      protected void Load044( )
      {
         /* Using cursor T00047 */
         pr_default.execute(5, new Object[] {A9VisitasId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound4 = 1;
            A10VisitasFecha = T00047_A10VisitasFecha[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A10VisitasFecha", context.localUtil.TToC( A10VisitasFecha, 8, 5, 1, 2, "/", ":", " "));
            ZM044( -2) ;
         }
         pr_default.close(5);
         OnLoadActions044( ) ;
      }

      protected void OnLoadActions044( )
      {
      }

      protected void CheckExtendedTable044( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A10VisitasFecha) || ( A10VisitasFecha >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Field Visitas Fecha is out of range", "OutOfRange", 1, "VISITASFECHA");
            AnyError = 1;
            GX_FocusControl = edtVisitasFecha_Internalname;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors044( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey044( )
      {
         /* Using cursor T00048 */
         pr_default.execute(6, new Object[] {A9VisitasId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound4 = 1;
         }
         else
         {
            RcdFound4 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00046 */
         pr_default.execute(4, new Object[] {A9VisitasId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM044( 2) ;
            RcdFound4 = 1;
            A9VisitasId = T00046_A9VisitasId[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9VisitasId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9VisitasId), 4, 0)));
            A10VisitasFecha = T00046_A10VisitasFecha[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A10VisitasFecha", context.localUtil.TToC( A10VisitasFecha, 8, 5, 1, 2, "/", ":", " "));
            Z9VisitasId = A9VisitasId;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load044( ) ;
            if ( AnyError == 1 )
            {
               RcdFound4 = 0;
               InitializeNonKey044( ) ;
            }
            Gx_mode = sMode4;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound4 = 0;
            InitializeNonKey044( ) ;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode4;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey044( ) ;
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
         /* Using cursor T00049 */
         pr_default.execute(7, new Object[] {A9VisitasId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00049_A9VisitasId[0] < A9VisitasId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00049_A9VisitasId[0] > A9VisitasId ) ) )
            {
               A9VisitasId = T00049_A9VisitasId[0];
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9VisitasId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9VisitasId), 4, 0)));
               RcdFound4 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void move_previous( )
      {
         RcdFound4 = 0;
         /* Using cursor T000410 */
         pr_default.execute(8, new Object[] {A9VisitasId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000410_A9VisitasId[0] > A9VisitasId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000410_A9VisitasId[0] < A9VisitasId ) ) )
            {
               A9VisitasId = T000410_A9VisitasId[0];
               context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9VisitasId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9VisitasId), 4, 0)));
               RcdFound4 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey044( ) ;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            /* Insert record */
            GX_FocusControl = edtVisitasId_Internalname;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
            Insert044( ) ;
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
               if ( A9VisitasId != Z9VisitasId )
               {
                  A9VisitasId = Z9VisitasId;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9VisitasId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9VisitasId), 4, 0)));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "VISITASID");
                  AnyError = 1;
                  GX_FocusControl = edtVisitasId_Internalname;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtVisitasId_Internalname;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update044( ) ;
                  GX_FocusControl = edtVisitasId_Internalname;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A9VisitasId != Z9VisitasId )
               {
                  Gx_mode = "INS";
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtVisitasId_Internalname;
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert044( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "VISITASID");
                     AnyError = 1;
                     GX_FocusControl = edtVisitasId_Internalname;
                     context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtVisitasId_Internalname;
                     context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert044( ) ;
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
         if ( A9VisitasId != Z9VisitasId )
         {
            A9VisitasId = Z9VisitasId;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9VisitasId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9VisitasId), 4, 0)));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "VISITASID");
            AnyError = 1;
            GX_FocusControl = edtVisitasId_Internalname;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtVisitasId_Internalname;
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
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "VISITASID");
            AnyError = 1;
            GX_FocusControl = edtVisitasId_Internalname;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtVisitasFecha_Internalname;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "IsConfirmed", StringUtil.LTrim( StringUtil.Str( (decimal)(IsConfirmed), 4, 0)));
         ScanStart044( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtVisitasFecha_Internalname;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd044( ) ;
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
         GX_FocusControl = edtVisitasFecha_Internalname;
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
         GX_FocusControl = edtVisitasFecha_Internalname;
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
         ScanStart044( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound4 != 0 )
            {
               ScanNext044( ) ;
            }
            Gx_mode = "UPD";
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtVisitasFecha_Internalname;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd044( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency044( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            /* Using cursor T00045 */
            pr_default.execute(3, new Object[] {A9VisitasId});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Visitas"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) || ( Z10VisitasFecha != T00045_A10VisitasFecha[0] ) )
            {
               if ( Z10VisitasFecha != T00045_A10VisitasFecha[0] )
               {
                  GXUtil.WriteLog("visitas:[seudo value changed for attri]"+"VisitasFecha");
                  GXUtil.WriteLogRaw("Old: ",Z10VisitasFecha);
                  GXUtil.WriteLogRaw("Current: ",T00045_A10VisitasFecha[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Visitas"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert044( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM044( 0) ;
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000411 */
                     pr_default.execute(9, new Object[] {A9VisitasId, A10VisitasFecha});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("Visitas") ;
                     if ( (pr_default.getStatus(9) == 1) )
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
                           ProcessLevel044( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              GX_msglist.addItem(context.GetMessage( "GXM_sucadded", ""), "SuccessfullyAdded", 0, "", true);
                              ResetCaption040( ) ;
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
               Load044( ) ;
            }
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void Update044( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000412 */
                     pr_default.execute(10, new Object[] {A10VisitasFecha, A9VisitasId});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("Visitas") ;
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Visitas"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate044( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel044( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              GX_msglist.addItem(context.GetMessage( "GXM_sucupdated", ""), "SuccessfullyUpdated", 0, "", true);
                              ResetCaption040( ) ;
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
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void DeferredUpdate044( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls044( ) ;
            AfterConfirm044( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete044( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart045( ) ;
                  while ( RcdFound5 != 0 )
                  {
                     getByPrimaryKey045( ) ;
                     Delete045( ) ;
                     ScanNext045( ) ;
                  }
                  ScanEnd045( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000413 */
                     pr_default.execute(11, new Object[] {A9VisitasId});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("Visitas") ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           move_next( ) ;
                           if ( RcdFound4 == 0 )
                           {
                              InitAll044( ) ;
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
                           ResetCaption040( ) ;
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
         sMode4 = Gx_mode;
         Gx_mode = "DLT";
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         EndLevel044( ) ;
         Gx_mode = sMode4;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls044( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void ProcessNestedLevel045( )
      {
         nGXsfl_46_idx = 0;
         while ( nGXsfl_46_idx < nRC_GXsfl_46 )
         {
            ReadRow045( ) ;
            if ( ( nRcdExists_5 != 0 ) || ( nIsMod_5 != 0 ) )
            {
               standaloneNotModal045( ) ;
               GetKey045( ) ;
               if ( ( nRcdExists_5 == 0 ) && ( nRcdDeleted_5 == 0 ) )
               {
                  Gx_mode = "INS";
                  context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                  Insert045( ) ;
               }
               else
               {
                  if ( RcdFound5 != 0 )
                  {
                     if ( ( nRcdDeleted_5 != 0 ) && ( nRcdExists_5 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                        Delete045( ) ;
                     }
                     else
                     {
                        if ( ( nIsMod_5 != 0 ) && ( nRcdExists_5 != 0 ) )
                        {
                           Gx_mode = "UPD";
                           context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
                           Update045( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_5 == 0 )
                     {
                        GXCCtl = "PROPIEDADID_" + sGXsfl_46_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtPropiedadId_Internalname;
                        context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtPropiedadId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A3PropiedadId), 4, 0, ".", ""))) ;
            ChangePostValue( edtPropiedadDireccion_Internalname, StringUtil.RTrim( A6PropiedadDireccion)) ;
            ChangePostValue( "ZT_"+"Z3PropiedadId_"+sGXsfl_46_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z3PropiedadId), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_5_"+sGXsfl_46_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_5), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_5_"+sGXsfl_46_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_5), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_5_"+sGXsfl_46_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_5), 4, 0, ".", ""))) ;
            if ( nIsMod_5 != 0 )
            {
               ChangePostValue( "PROPIEDADID_"+sGXsfl_46_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPropiedadId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROPIEDADDIRECCION_"+sGXsfl_46_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPropiedadDireccion_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll045( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_5 = 0;
         nIsMod_5 = 0;
         nRcdDeleted_5 = 0;
      }

      protected void ProcessLevel044( )
      {
         /* Save parent mode. */
         sMode4 = Gx_mode;
         ProcessNestedLevel045( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode4;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel044( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete044( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            pr_default.commit( "Visitas");
            if ( AnyError == 0 )
            {
               ConfirmValues040( ) ;
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
            pr_default.close(2);
            pr_default.rollback( "Visitas");
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart044( )
      {
         /* Using cursor T000414 */
         pr_default.execute(12);
         RcdFound4 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound4 = 1;
            A9VisitasId = T000414_A9VisitasId[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9VisitasId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9VisitasId), 4, 0)));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext044( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound4 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound4 = 1;
            A9VisitasId = T000414_A9VisitasId[0];
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9VisitasId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9VisitasId), 4, 0)));
         }
      }

      protected void ScanEnd044( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm044( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert044( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate044( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete044( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete044( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate044( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes044( )
      {
         edtVisitasId_Enabled = 0;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtVisitasId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtVisitasId_Enabled), 5, 0)), true);
         edtVisitasFecha_Enabled = 0;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtVisitasFecha_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtVisitasFecha_Enabled), 5, 0)), true);
      }

      protected void ZM045( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -3 )
         {
            Z9VisitasId = A9VisitasId;
            Z3PropiedadId = A3PropiedadId;
            Z6PropiedadDireccion = A6PropiedadDireccion;
         }
      }

      protected void standaloneNotModal045( )
      {
      }

      protected void standaloneModal045( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtPropiedadId_Enabled = 0;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtPropiedadId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtPropiedadId_Enabled), 5, 0)), !bGXsfl_46_Refreshing);
         }
         else
         {
            edtPropiedadId_Enabled = 1;
            context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtPropiedadId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtPropiedadId_Enabled), 5, 0)), !bGXsfl_46_Refreshing);
         }
      }

      protected void Load045( )
      {
         /* Using cursor T000415 */
         pr_default.execute(13, new Object[] {A9VisitasId, A3PropiedadId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound5 = 1;
            A6PropiedadDireccion = T000415_A6PropiedadDireccion[0];
            ZM045( -3) ;
         }
         pr_default.close(13);
         OnLoadActions045( ) ;
      }

      protected void OnLoadActions045( )
      {
      }

      protected void CheckExtendedTable045( )
      {
         Gx_BScreen = 1;
         standaloneModal045( ) ;
         /* Using cursor T00044 */
         pr_default.execute(2, new Object[] {A3PropiedadId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "PROPIEDADID_" + sGXsfl_46_idx;
            GX_msglist.addItem("No matching 'Propiedad'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtPropiedadId_Internalname;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A6PropiedadDireccion = T00044_A6PropiedadDireccion[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors045( )
      {
         pr_default.close(2);
      }

      protected void enableDisable045( )
      {
      }

      protected void gxLoad_4( short A3PropiedadId )
      {
         /* Using cursor T000416 */
         pr_default.execute(14, new Object[] {A3PropiedadId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GXCCtl = "PROPIEDADID_" + sGXsfl_46_idx;
            GX_msglist.addItem("No matching 'Propiedad'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtPropiedadId_Internalname;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A6PropiedadDireccion = T000416_A6PropiedadDireccion[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         context.GX_webresponse.AddString("new Array( new Array(");
         context.GX_webresponse.AddString("\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A6PropiedadDireccion))+"\"");
         context.GX_webresponse.AddString(")");
         if ( (pr_default.getStatus(14) == 101) )
         {
            context.GX_webresponse.AddString(",");
            context.GX_webresponse.AddString("101");
         }
         context.GX_webresponse.AddString(")");
         pr_default.close(14);
      }

      protected void GetKey045( )
      {
         /* Using cursor T000417 */
         pr_default.execute(15, new Object[] {A9VisitasId, A3PropiedadId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound5 = 1;
         }
         else
         {
            RcdFound5 = 0;
         }
         pr_default.close(15);
      }

      protected void getByPrimaryKey045( )
      {
         /* Using cursor T00043 */
         pr_default.execute(1, new Object[] {A9VisitasId, A3PropiedadId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM045( 3) ;
            RcdFound5 = 1;
            InitializeNonKey045( ) ;
            A3PropiedadId = T00043_A3PropiedadId[0];
            Z9VisitasId = A9VisitasId;
            Z3PropiedadId = A3PropiedadId;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
            standaloneModal045( ) ;
            Load045( ) ;
            Gx_mode = sMode5;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound5 = 0;
            InitializeNonKey045( ) ;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
            standaloneModal045( ) ;
            Gx_mode = sMode5;
            context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            DisableAttributes045( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency045( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            /* Using cursor T00042 */
            pr_default.execute(0, new Object[] {A9VisitasId, A3PropiedadId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"VisitasVisitaPro"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"VisitasVisitaPro"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert045( )
      {
         BeforeValidate045( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable045( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM045( 0) ;
            CheckOptimisticConcurrency045( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm045( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert045( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000418 */
                     pr_default.execute(16, new Object[] {A9VisitasId, A3PropiedadId});
                     pr_default.close(16);
                     dsDefault.SmartCacheProvider.SetUpdated("VisitasVisitaPro") ;
                     if ( (pr_default.getStatus(16) == 1) )
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
               Load045( ) ;
            }
            EndLevel045( ) ;
         }
         CloseExtendedTableCursors045( ) ;
      }

      protected void Update045( )
      {
         BeforeValidate045( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable045( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency045( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm045( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate045( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table [VisitasVisitaPro] */
                     DeferredUpdate045( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey045( ) ;
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
            EndLevel045( ) ;
         }
         CloseExtendedTableCursors045( ) ;
      }

      protected void DeferredUpdate045( )
      {
      }

      protected void Delete045( )
      {
         Gx_mode = "DLT";
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         BeforeValidate045( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency045( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls045( ) ;
            AfterConfirm045( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete045( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000419 */
                  pr_default.execute(17, new Object[] {A9VisitasId, A3PropiedadId});
                  pr_default.close(17);
                  dsDefault.SmartCacheProvider.SetUpdated("VisitasVisitaPro") ;
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
         sMode5 = Gx_mode;
         Gx_mode = "DLT";
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         EndLevel045( ) ;
         Gx_mode = sMode5;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls045( )
      {
         standaloneModal045( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000420 */
            pr_default.execute(18, new Object[] {A3PropiedadId});
            A6PropiedadDireccion = T000420_A6PropiedadDireccion[0];
            pr_default.close(18);
         }
      }

      protected void EndLevel045( )
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

      public void ScanStart045( )
      {
         /* Scan By routine */
         /* Using cursor T000421 */
         pr_default.execute(19, new Object[] {A9VisitasId});
         RcdFound5 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound5 = 1;
            A3PropiedadId = T000421_A3PropiedadId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext045( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound5 = 1;
            A3PropiedadId = T000421_A3PropiedadId[0];
         }
      }

      protected void ScanEnd045( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm045( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert045( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate045( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete045( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete045( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate045( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes045( )
      {
         edtPropiedadId_Enabled = 0;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtPropiedadId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtPropiedadId_Enabled), 5, 0)), !bGXsfl_46_Refreshing);
         edtPropiedadDireccion_Enabled = 0;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtPropiedadDireccion_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtPropiedadDireccion_Enabled), 5, 0)), !bGXsfl_46_Refreshing);
      }

      protected void SubsflControlProps_465( )
      {
         edtPropiedadId_Internalname = "PROPIEDADID_"+sGXsfl_46_idx;
         imgprompt_3_Internalname = "PROMPT_3_"+sGXsfl_46_idx;
         edtPropiedadDireccion_Internalname = "PROPIEDADDIRECCION_"+sGXsfl_46_idx;
      }

      protected void SubsflControlProps_fel_465( )
      {
         edtPropiedadId_Internalname = "PROPIEDADID_"+sGXsfl_46_fel_idx;
         imgprompt_3_Internalname = "PROMPT_3_"+sGXsfl_46_fel_idx;
         edtPropiedadDireccion_Internalname = "PROPIEDADDIRECCION_"+sGXsfl_46_fel_idx;
      }

      protected void AddRow045( )
      {
         nGXsfl_46_idx = (short)(nGXsfl_46_idx+1);
         sGXsfl_46_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_46_idx), 4, 0)), 4, "0");
         SubsflControlProps_465( ) ;
         SendRow045( ) ;
      }

      protected void SendRow045( )
      {
         Gridvisitas_visitaproRow = GXWebRow.GetNew(context);
         if ( subGridvisitas_visitapro_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridvisitas_visitapro_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridvisitas_visitapro_Class, "") != 0 )
            {
               subGridvisitas_visitapro_Linesclass = subGridvisitas_visitapro_Class+"Odd";
            }
         }
         else if ( subGridvisitas_visitapro_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridvisitas_visitapro_Backstyle = 0;
            subGridvisitas_visitapro_Backcolor = subGridvisitas_visitapro_Allbackcolor;
            if ( StringUtil.StrCmp(subGridvisitas_visitapro_Class, "") != 0 )
            {
               subGridvisitas_visitapro_Linesclass = subGridvisitas_visitapro_Class+"Uniform";
            }
         }
         else if ( subGridvisitas_visitapro_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridvisitas_visitapro_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridvisitas_visitapro_Class, "") != 0 )
            {
               subGridvisitas_visitapro_Linesclass = subGridvisitas_visitapro_Class+"Odd";
            }
            subGridvisitas_visitapro_Backcolor = (int)(0x0);
         }
         else if ( subGridvisitas_visitapro_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridvisitas_visitapro_Backstyle = 1;
            if ( ((int)((nGXsfl_46_idx) % (2))) == 0 )
            {
               subGridvisitas_visitapro_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridvisitas_visitapro_Class, "") != 0 )
               {
                  subGridvisitas_visitapro_Linesclass = subGridvisitas_visitapro_Class+"Even";
               }
            }
            else
            {
               subGridvisitas_visitapro_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridvisitas_visitapro_Class, "") != 0 )
               {
                  subGridvisitas_visitapro_Linesclass = subGridvisitas_visitapro_Class+"Odd";
               }
            }
         }
         imgprompt_3_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PROPIEDADID_"+sGXsfl_46_idx+"'), id:'"+"PROPIEDADID_"+sGXsfl_46_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_5_"+sGXsfl_46_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_5_" + sGXsfl_46_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 47,'',false,'" + sGXsfl_46_idx + "',46)\"";
         ROClassString = "Attribute";
         Gridvisitas_visitaproRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtPropiedadId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A3PropiedadId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A3PropiedadId), "ZZZ9")),TempTags+" onchange=\"gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,47);\"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtPropiedadId_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(short)-1,(int)edtPropiedadId_Enabled,(short)1,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)4,(short)0,(short)0,(short)46,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (String)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         Gridvisitas_visitaproRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)imgprompt_3_Internalname,(String)sImgUrl,(String)imgprompt_3_Link,(String)"",(String)"",context.GetTheme( ),(int)imgprompt_3_Visible,(short)1,(String)"",(String)"",(short)0,(short)0,(short)0,(String)"",(short)0,(String)"",(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridvisitas_visitaproRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtPropiedadDireccion_Internalname,StringUtil.RTrim( A6PropiedadDireccion),(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtPropiedadDireccion_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(short)-1,(int)edtPropiedadDireccion_Enabled,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)50,(short)0,(short)0,(short)46,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true});
         context.httpAjaxContext.ajax_sending_grid_row(Gridvisitas_visitaproRow);
         GXCCtl = "Z3PropiedadId_" + sGXsfl_46_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z3PropiedadId), 4, 0, ".", "")));
         GXCCtl = "nRcdDeleted_5_" + sGXsfl_46_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_5), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_5_" + sGXsfl_46_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_5), 4, 0, ".", "")));
         GXCCtl = "nIsMod_5_" + sGXsfl_46_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_5), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROPIEDADID_"+sGXsfl_46_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPropiedadId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROPIEDADDIRECCION_"+sGXsfl_46_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPropiedadDireccion_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_3_"+sGXsfl_46_idx+"Link", StringUtil.RTrim( imgprompt_3_Link));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridvisitas_visitaproContainer.AddRow(Gridvisitas_visitaproRow);
      }

      protected void ReadRow045( )
      {
         nGXsfl_46_idx = (short)(nGXsfl_46_idx+1);
         sGXsfl_46_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_46_idx), 4, 0)), 4, "0");
         SubsflControlProps_465( ) ;
         edtPropiedadId_Enabled = (int)(context.localUtil.CToN( cgiGet( "PROPIEDADID_"+sGXsfl_46_idx+"Enabled"), ".", ","));
         edtPropiedadDireccion_Enabled = (int)(context.localUtil.CToN( cgiGet( "PROPIEDADDIRECCION_"+sGXsfl_46_idx+"Enabled"), ".", ","));
         imgprompt_3_Link = cgiGet( "PROMPT_3_"+sGXsfl_46_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtPropiedadId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPropiedadId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "PROPIEDADID_" + sGXsfl_46_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtPropiedadId_Internalname;
            wbErr = true;
            A3PropiedadId = 0;
         }
         else
         {
            A3PropiedadId = (short)(context.localUtil.CToN( cgiGet( edtPropiedadId_Internalname), ".", ","));
         }
         A6PropiedadDireccion = cgiGet( edtPropiedadDireccion_Internalname);
         GXCCtl = "Z3PropiedadId_" + sGXsfl_46_idx;
         Z3PropiedadId = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdDeleted_5_" + sGXsfl_46_idx;
         nRcdDeleted_5 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdExists_5_" + sGXsfl_46_idx;
         nRcdExists_5 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nIsMod_5_" + sGXsfl_46_idx;
         nIsMod_5 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
      }

      protected void assign_properties_default( )
      {
         defedtPropiedadId_Enabled = edtPropiedadId_Enabled;
      }

      protected void ConfirmValues040( )
      {
         nGXsfl_46_idx = 0;
         sGXsfl_46_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_46_idx), 4, 0)), 4, "0");
         SubsflControlProps_465( ) ;
         while ( nGXsfl_46_idx < nRC_GXsfl_46 )
         {
            nGXsfl_46_idx = (short)(nGXsfl_46_idx+1);
            sGXsfl_46_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_46_idx), 4, 0)), 4, "0");
            SubsflControlProps_465( ) ;
            ChangePostValue( "Z3PropiedadId_"+sGXsfl_46_idx, cgiGet( "ZT_"+"Z3PropiedadId_"+sGXsfl_46_idx)) ;
            DeletePostValue( "ZT_"+"Z3PropiedadId_"+sGXsfl_46_idx) ;
         }
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
         context.AddJavascriptSource("gxcfg.js", "?201791420104272", false);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("visitas.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z9VisitasId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9VisitasId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z10VisitasFecha", context.localUtil.TToC( Z10VisitasFecha, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_46", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_46_idx), 4, 0, ".", "")));
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
         return formatLink("visitas.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "Visitas" ;
      }

      public override String GetPgmdesc( )
      {
         return "Visitas" ;
      }

      protected void InitializeNonKey044( )
      {
         A10VisitasFecha = (DateTime)(DateTime.MinValue);
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A10VisitasFecha", context.localUtil.TToC( A10VisitasFecha, 8, 5, 1, 2, "/", ":", " "));
         Z10VisitasFecha = (DateTime)(DateTime.MinValue);
      }

      protected void InitAll044( )
      {
         A9VisitasId = 0;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "A9VisitasId", StringUtil.LTrim( StringUtil.Str( (decimal)(A9VisitasId), 4, 0)));
         InitializeNonKey044( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey045( )
      {
         A6PropiedadDireccion = "";
      }

      protected void InitAll045( )
      {
         A3PropiedadId = 0;
         InitializeNonKey045( ) ;
      }

      protected void StandaloneModalInsert045( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?201791420104275", true);
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
         context.AddJavascriptSource("visitas.js", "?201791420104276", false);
         /* End function include_jscripts */
      }

      protected void init_level_properties5( )
      {
         edtPropiedadId_Enabled = defedtPropiedadId_Enabled;
         context.httpAjaxContext.ajax_rsp_assign_prop("", false, edtPropiedadId_Internalname, "Enabled", StringUtil.LTrim( StringUtil.Str( (decimal)(edtPropiedadId_Enabled), 5, 0)), !bGXsfl_46_Refreshing);
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
         edtVisitasId_Internalname = "VISITASID";
         edtVisitasFecha_Internalname = "VISITASFECHA";
         lblTitlevisitapro_Internalname = "TITLEVISITAPRO";
         edtPropiedadId_Internalname = "PROPIEDADID";
         edtPropiedadDireccion_Internalname = "PROPIEDADDIRECCION";
         divVisitaprotable_Internalname = "VISITAPROTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_3_Internalname = "PROMPT_3";
         subGridvisitas_visitapro_Internalname = "GRIDVISITAS_VISITAPRO";
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
         Form.Caption = "Visitas";
         edtPropiedadDireccion_Jsonclick = "";
         imgprompt_3_Visible = 1;
         imgprompt_3_Link = "";
         imgprompt_3_Visible = 1;
         edtPropiedadId_Jsonclick = "";
         subGridvisitas_visitapro_Class = "Grid";
         subGridvisitas_visitapro_Backcolorstyle = 0;
         subGridvisitas_visitapro_Allowcollapsing = 0;
         subGridvisitas_visitapro_Allowselection = 0;
         edtPropiedadDireccion_Enabled = 0;
         edtPropiedadId_Enabled = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtVisitasFecha_Jsonclick = "";
         edtVisitasFecha_Enabled = 1;
         edtVisitasId_Jsonclick = "";
         edtVisitasId_Enabled = 1;
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

      protected void gxnrGridvisitas_visitapro_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_465( ) ;
         while ( nGXsfl_46_idx <= nRC_GXsfl_46 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal045( ) ;
            standaloneModal045( ) ;
            dynload_actions( ) ;
            SendRow045( ) ;
            nGXsfl_46_idx = (short)(nGXsfl_46_idx+1);
            sGXsfl_46_idx = StringUtil.PadL( StringUtil.LTrim( StringUtil.Str( (decimal)(nGXsfl_46_idx), 4, 0)), 4, "0");
            SubsflControlProps_465( ) ;
         }
         context.GX_webresponse.AddString(Gridvisitas_visitaproContainer.ToJavascriptSource());
         /* End function gxnrGridvisitas_visitapro_newrow */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "IsConfirmed", StringUtil.LTrim( StringUtil.Str( (decimal)(IsConfirmed), 4, 0)));
         getEqualNoModal( ) ;
         GX_FocusControl = edtVisitasFecha_Internalname;
         context.httpAjaxContext.ajax_rsp_assign_attri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
      }

      public void Valid_Visitasid( short GX_Parm1 ,
                                   DateTime GX_Parm2 )
      {
         A9VisitasId = GX_Parm1;
         A10VisitasFecha = GX_Parm2;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
         dynload_actions( ) ;
         if ( AnyError == 1 )
         {
         }
         isValidOutput.Add(context.localUtil.TToC( A10VisitasFecha, 10, 8, 1, 2, "/", ":", " "));
         isValidOutput.Add(StringUtil.RTrim( Gx_mode));
         isValidOutput.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9VisitasId), 4, 0, ".", "")));
         isValidOutput.Add(context.localUtil.TToC( Z10VisitasFecha, 10, 8, 0, 0, "/", ":", " "));
         isValidOutput.Add(Gridvisitas_visitaproContainer);
         isValidOutput.Add(bttBtn_delete_Enabled);
         isValidOutput.Add(bttBtn_enter_Enabled);
         isValidOutput.Add(context.GX_msglist.ToJavascriptSource());
         isValidOutput.Add(context.httpAjaxContext.ajax_rsp_get_hiddens( ));
         context.GX_webresponse.AddString(isValidOutput.ToJSonString());
         wbTemp = context.ResponseContentType( "application/json");
      }

      public void Valid_Propiedadid( short GX_Parm1 ,
                                     String GX_Parm2 )
      {
         A3PropiedadId = GX_Parm1;
         A6PropiedadDireccion = GX_Parm2;
         /* Using cursor T000420 */
         pr_default.execute(18, new Object[] {A3PropiedadId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No matching 'Propiedad'.", "ForeignKeyNotFound", 1, "PROPIEDADID");
            AnyError = 1;
            GX_FocusControl = edtPropiedadId_Internalname;
         }
         A6PropiedadDireccion = T000420_A6PropiedadDireccion[0];
         pr_default.close(18);
         dynload_actions( ) ;
         if ( AnyError == 1 )
         {
            A6PropiedadDireccion = "";
         }
         isValidOutput.Add(StringUtil.RTrim( A6PropiedadDireccion));
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
         pr_default.close(18);
         pr_default.close(4);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z10VisitasFecha = (DateTime)(DateTime.MinValue);
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
         A10VisitasFecha = (DateTime)(DateTime.MinValue);
         lblTitlevisitapro_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridvisitas_visitaproContainer = new GXWebGrid( context);
         Gridvisitas_visitaproColumn = new GXWebColumn();
         A6PropiedadDireccion = "";
         Gx_mode = "";
         sMode5 = "";
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXCCtl = "";
         T00047_A9VisitasId = new short[1] ;
         T00047_A10VisitasFecha = new DateTime[] {DateTime.MinValue} ;
         T00048_A9VisitasId = new short[1] ;
         T00046_A9VisitasId = new short[1] ;
         T00046_A10VisitasFecha = new DateTime[] {DateTime.MinValue} ;
         sMode4 = "";
         T00049_A9VisitasId = new short[1] ;
         T000410_A9VisitasId = new short[1] ;
         T00045_A9VisitasId = new short[1] ;
         T00045_A10VisitasFecha = new DateTime[] {DateTime.MinValue} ;
         T000414_A9VisitasId = new short[1] ;
         Z6PropiedadDireccion = "";
         T000415_A9VisitasId = new short[1] ;
         T000415_A6PropiedadDireccion = new String[] {""} ;
         T000415_A3PropiedadId = new short[1] ;
         T00044_A6PropiedadDireccion = new String[] {""} ;
         T000416_A6PropiedadDireccion = new String[] {""} ;
         T000417_A9VisitasId = new short[1] ;
         T000417_A3PropiedadId = new short[1] ;
         T00043_A9VisitasId = new short[1] ;
         T00043_A3PropiedadId = new short[1] ;
         T00042_A9VisitasId = new short[1] ;
         T00042_A3PropiedadId = new short[1] ;
         T000420_A6PropiedadDireccion = new String[] {""} ;
         T000421_A9VisitasId = new short[1] ;
         T000421_A3PropiedadId = new short[1] ;
         Gridvisitas_visitaproRow = new GXWebRow();
         subGridvisitas_visitapro_Linesclass = "";
         ROClassString = "";
         sImgUrl = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         isValidOutput = new GxUnknownObjectCollection();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.visitas__default(),
            new Object[][] {
                new Object[] {
               T00042_A9VisitasId, T00042_A3PropiedadId
               }
               , new Object[] {
               T00043_A9VisitasId, T00043_A3PropiedadId
               }
               , new Object[] {
               T00044_A6PropiedadDireccion
               }
               , new Object[] {
               T00045_A9VisitasId, T00045_A10VisitasFecha
               }
               , new Object[] {
               T00046_A9VisitasId, T00046_A10VisitasFecha
               }
               , new Object[] {
               T00047_A9VisitasId, T00047_A10VisitasFecha
               }
               , new Object[] {
               T00048_A9VisitasId
               }
               , new Object[] {
               T00049_A9VisitasId
               }
               , new Object[] {
               T000410_A9VisitasId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000414_A9VisitasId
               }
               , new Object[] {
               T000415_A9VisitasId, T000415_A6PropiedadDireccion, T000415_A3PropiedadId
               }
               , new Object[] {
               T000416_A6PropiedadDireccion
               }
               , new Object[] {
               T000417_A9VisitasId, T000417_A3PropiedadId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000420_A6PropiedadDireccion
               }
               , new Object[] {
               T000421_A9VisitasId, T000421_A3PropiedadId
               }
            }
         );
      }

      private short nIsMod_5 ;
      private short Z9VisitasId ;
      private short nRC_GXsfl_46 ;
      private short nGXsfl_46_idx=1 ;
      private short Z3PropiedadId ;
      private short nRcdDeleted_5 ;
      private short nRcdExists_5 ;
      private short GxWebError ;
      private short A3PropiedadId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A9VisitasId ;
      private short subGridvisitas_visitapro_Backcolorstyle ;
      private short subGridvisitas_visitapro_Allowselection ;
      private short subGridvisitas_visitapro_Allowhovering ;
      private short subGridvisitas_visitapro_Allowcollapsing ;
      private short subGridvisitas_visitapro_Collapsed ;
      private short nBlankRcdCount5 ;
      private short RcdFound5 ;
      private short nBlankRcdUsr5 ;
      private short GX_JID ;
      private short RcdFound4 ;
      private short Gx_BScreen ;
      private short subGridvisitas_visitapro_Backstyle ;
      private short gxajaxcallmode ;
      private short wbTemp ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtVisitasId_Enabled ;
      private int edtVisitasFecha_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtPropiedadId_Enabled ;
      private int edtPropiedadDireccion_Enabled ;
      private int subGridvisitas_visitapro_Selectioncolor ;
      private int subGridvisitas_visitapro_Hoveringcolor ;
      private int fRowAdded ;
      private int subGridvisitas_visitapro_Backcolor ;
      private int subGridvisitas_visitapro_Allbackcolor ;
      private int imgprompt_3_Visible ;
      private int defedtPropiedadId_Enabled ;
      private int idxLst ;
      private long GRIDVISITAS_VISITAPRO_nFirstRecordOnPage ;
      private String sPrefix ;
      private String sGXsfl_46_idx="0001" ;
      private String scmdbuf ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String GXKey ;
      private String PreviousTooltip ;
      private String PreviousCaption ;
      private String GX_FocusControl ;
      private String edtVisitasId_Internalname ;
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
      private String edtVisitasId_Jsonclick ;
      private String edtVisitasFecha_Internalname ;
      private String edtVisitasFecha_Jsonclick ;
      private String divVisitaprotable_Internalname ;
      private String lblTitlevisitapro_Internalname ;
      private String lblTitlevisitapro_Jsonclick ;
      private String bttBtn_enter_Internalname ;
      private String bttBtn_enter_Jsonclick ;
      private String bttBtn_cancel_Internalname ;
      private String bttBtn_cancel_Jsonclick ;
      private String bttBtn_delete_Internalname ;
      private String bttBtn_delete_Jsonclick ;
      private String A6PropiedadDireccion ;
      private String Gx_mode ;
      private String sMode5 ;
      private String edtPropiedadId_Internalname ;
      private String edtPropiedadDireccion_Internalname ;
      private String imgprompt_3_Link ;
      private String sStyleString ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String GXCCtl ;
      private String sMode4 ;
      private String Z6PropiedadDireccion ;
      private String imgprompt_3_Internalname ;
      private String sGXsfl_46_fel_idx="0001" ;
      private String subGridvisitas_visitapro_Class ;
      private String subGridvisitas_visitapro_Linesclass ;
      private String ROClassString ;
      private String edtPropiedadId_Jsonclick ;
      private String sImgUrl ;
      private String edtPropiedadDireccion_Jsonclick ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String subGridvisitas_visitapro_Internalname ;
      private DateTime Z10VisitasFecha ;
      private DateTime A10VisitasFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool bGXsfl_46_Refreshing=false ;
      private GxUnknownObjectCollection isValidOutput ;
      private GXWebGrid Gridvisitas_visitaproContainer ;
      private GXWebRow Gridvisitas_visitaproRow ;
      private GXWebColumn Gridvisitas_visitaproColumn ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T00047_A9VisitasId ;
      private DateTime[] T00047_A10VisitasFecha ;
      private short[] T00048_A9VisitasId ;
      private short[] T00046_A9VisitasId ;
      private DateTime[] T00046_A10VisitasFecha ;
      private short[] T00049_A9VisitasId ;
      private short[] T000410_A9VisitasId ;
      private short[] T00045_A9VisitasId ;
      private DateTime[] T00045_A10VisitasFecha ;
      private short[] T000414_A9VisitasId ;
      private short[] T000415_A9VisitasId ;
      private String[] T000415_A6PropiedadDireccion ;
      private short[] T000415_A3PropiedadId ;
      private String[] T00044_A6PropiedadDireccion ;
      private String[] T000416_A6PropiedadDireccion ;
      private short[] T000417_A9VisitasId ;
      private short[] T000417_A3PropiedadId ;
      private short[] T00043_A9VisitasId ;
      private short[] T00043_A3PropiedadId ;
      private short[] T00042_A9VisitasId ;
      private short[] T00042_A3PropiedadId ;
      private String[] T000420_A6PropiedadDireccion ;
      private short[] T000421_A9VisitasId ;
      private short[] T000421_A3PropiedadId ;
      private GXWebForm Form ;
   }

   public class visitas__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new UpdateCursor(def[16])
         ,new UpdateCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00047 ;
          prmT00047 = new Object[] {
          new Object[] {"@VisitasId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT00048 ;
          prmT00048 = new Object[] {
          new Object[] {"@VisitasId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT00046 ;
          prmT00046 = new Object[] {
          new Object[] {"@VisitasId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT00049 ;
          prmT00049 = new Object[] {
          new Object[] {"@VisitasId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000410 ;
          prmT000410 = new Object[] {
          new Object[] {"@VisitasId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT00045 ;
          prmT00045 = new Object[] {
          new Object[] {"@VisitasId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000411 ;
          prmT000411 = new Object[] {
          new Object[] {"@VisitasId",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@VisitasFecha",SqlDbType.DateTime,8,5}
          } ;
          Object[] prmT000412 ;
          prmT000412 = new Object[] {
          new Object[] {"@VisitasFecha",SqlDbType.DateTime,8,5} ,
          new Object[] {"@VisitasId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000413 ;
          prmT000413 = new Object[] {
          new Object[] {"@VisitasId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000414 ;
          prmT000414 = new Object[] {
          } ;
          Object[] prmT000415 ;
          prmT000415 = new Object[] {
          new Object[] {"@VisitasId",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@PropiedadId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT00044 ;
          prmT00044 = new Object[] {
          new Object[] {"@PropiedadId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000416 ;
          prmT000416 = new Object[] {
          new Object[] {"@PropiedadId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000417 ;
          prmT000417 = new Object[] {
          new Object[] {"@VisitasId",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@PropiedadId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT00043 ;
          prmT00043 = new Object[] {
          new Object[] {"@VisitasId",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@PropiedadId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT00042 ;
          prmT00042 = new Object[] {
          new Object[] {"@VisitasId",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@PropiedadId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000418 ;
          prmT000418 = new Object[] {
          new Object[] {"@VisitasId",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@PropiedadId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000419 ;
          prmT000419 = new Object[] {
          new Object[] {"@VisitasId",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@PropiedadId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000421 ;
          prmT000421 = new Object[] {
          new Object[] {"@VisitasId",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT000420 ;
          prmT000420 = new Object[] {
          new Object[] {"@PropiedadId",SqlDbType.SmallInt,4,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("T00042", "SELECT [VisitasId], [PropiedadId] FROM [VisitasVisitaPro] WITH (UPDLOCK) WHERE [VisitasId] = @VisitasId AND [PropiedadId] = @PropiedadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00042,1,0,true,false )
             ,new CursorDef("T00043", "SELECT [VisitasId], [PropiedadId] FROM [VisitasVisitaPro] WITH (NOLOCK) WHERE [VisitasId] = @VisitasId AND [PropiedadId] = @PropiedadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00043,1,0,true,false )
             ,new CursorDef("T00044", "SELECT [PropiedadDireccion] FROM [Propiedad] WITH (NOLOCK) WHERE [PropiedadId] = @PropiedadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00044,1,0,true,false )
             ,new CursorDef("T00045", "SELECT [VisitasId], [VisitasFecha] FROM [Visitas] WITH (UPDLOCK) WHERE [VisitasId] = @VisitasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00045,1,0,true,false )
             ,new CursorDef("T00046", "SELECT [VisitasId], [VisitasFecha] FROM [Visitas] WITH (NOLOCK) WHERE [VisitasId] = @VisitasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00046,1,0,true,false )
             ,new CursorDef("T00047", "SELECT TM1.[VisitasId], TM1.[VisitasFecha] FROM [Visitas] TM1 WITH (NOLOCK) WHERE TM1.[VisitasId] = @VisitasId ORDER BY TM1.[VisitasId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00047,100,0,true,false )
             ,new CursorDef("T00048", "SELECT [VisitasId] FROM [Visitas] WITH (NOLOCK) WHERE [VisitasId] = @VisitasId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00048,1,0,true,false )
             ,new CursorDef("T00049", "SELECT TOP 1 [VisitasId] FROM [Visitas] WITH (NOLOCK) WHERE ( [VisitasId] > @VisitasId) ORDER BY [VisitasId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00049,1,0,true,true )
             ,new CursorDef("T000410", "SELECT TOP 1 [VisitasId] FROM [Visitas] WITH (NOLOCK) WHERE ( [VisitasId] < @VisitasId) ORDER BY [VisitasId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000410,1,0,true,true )
             ,new CursorDef("T000411", "INSERT INTO [Visitas]([VisitasId], [VisitasFecha]) VALUES(@VisitasId, @VisitasFecha)", GxErrorMask.GX_NOMASK,prmT000411)
             ,new CursorDef("T000412", "UPDATE [Visitas] SET [VisitasFecha]=@VisitasFecha  WHERE [VisitasId] = @VisitasId", GxErrorMask.GX_NOMASK,prmT000412)
             ,new CursorDef("T000413", "DELETE FROM [Visitas]  WHERE [VisitasId] = @VisitasId", GxErrorMask.GX_NOMASK,prmT000413)
             ,new CursorDef("T000414", "SELECT [VisitasId] FROM [Visitas] WITH (NOLOCK) ORDER BY [VisitasId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000414,100,0,true,false )
             ,new CursorDef("T000415", "SELECT T1.[VisitasId], T2.[PropiedadDireccion], T1.[PropiedadId] FROM ([VisitasVisitaPro] T1 WITH (NOLOCK) INNER JOIN [Propiedad] T2 WITH (NOLOCK) ON T2.[PropiedadId] = T1.[PropiedadId]) WHERE T1.[VisitasId] = @VisitasId and T1.[PropiedadId] = @PropiedadId ORDER BY T1.[VisitasId], T1.[PropiedadId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000415,11,0,true,false )
             ,new CursorDef("T000416", "SELECT [PropiedadDireccion] FROM [Propiedad] WITH (NOLOCK) WHERE [PropiedadId] = @PropiedadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000416,1,0,true,false )
             ,new CursorDef("T000417", "SELECT [VisitasId], [PropiedadId] FROM [VisitasVisitaPro] WITH (NOLOCK) WHERE [VisitasId] = @VisitasId AND [PropiedadId] = @PropiedadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000417,1,0,true,false )
             ,new CursorDef("T000418", "INSERT INTO [VisitasVisitaPro]([VisitasId], [PropiedadId]) VALUES(@VisitasId, @PropiedadId)", GxErrorMask.GX_NOMASK,prmT000418)
             ,new CursorDef("T000419", "DELETE FROM [VisitasVisitaPro]  WHERE [VisitasId] = @VisitasId AND [PropiedadId] = @PropiedadId", GxErrorMask.GX_NOMASK,prmT000419)
             ,new CursorDef("T000420", "SELECT [PropiedadDireccion] FROM [Propiedad] WITH (NOLOCK) WHERE [PropiedadId] = @PropiedadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000420,1,0,true,false )
             ,new CursorDef("T000421", "SELECT [VisitasId], [PropiedadId] FROM [VisitasVisitaPro] WITH (NOLOCK) WHERE [VisitasId] = @VisitasId ORDER BY [VisitasId], [PropiedadId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000421,11,0,true,false )
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
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                return;
             case 2 :
                ((String[]) buf[0])[0] = rslt.getString(1, 50) ;
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2) ;
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2) ;
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2) ;
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
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 50) ;
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
                return;
             case 14 :
                ((String[]) buf[0])[0] = rslt.getString(1, 50) ;
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                return;
             case 18 :
                ((String[]) buf[0])[0] = rslt.getString(1, 50) ;
                return;
             case 19 :
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
                stmt.SetParameterDatetime(2, (DateTime)parms[1]);
                return;
             case 10 :
                stmt.SetParameterDatetime(1, (DateTime)parms[0]);
                stmt.SetParameter(2, (short)parms[1]);
                return;
             case 11 :
                stmt.SetParameter(1, (short)parms[0]);
                return;
             case 13 :
                stmt.SetParameter(1, (short)parms[0]);
                stmt.SetParameter(2, (short)parms[1]);
                return;
             case 14 :
                stmt.SetParameter(1, (short)parms[0]);
                return;
             case 15 :
                stmt.SetParameter(1, (short)parms[0]);
                stmt.SetParameter(2, (short)parms[1]);
                return;
             case 16 :
                stmt.SetParameter(1, (short)parms[0]);
                stmt.SetParameter(2, (short)parms[1]);
                return;
             case 17 :
                stmt.SetParameter(1, (short)parms[0]);
                stmt.SetParameter(2, (short)parms[1]);
                return;
             case 18 :
                stmt.SetParameter(1, (short)parms[0]);
                return;
             case 19 :
                stmt.SetParameter(1, (short)parms[0]);
                return;
       }
    }

 }

}
