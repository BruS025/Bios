/*!   GeneXus C# 15_0_6-116888 on 9/21/2017 19:41:12.17
*/
gx.evt.autoSkip=!1;gx.define("rwdpromptmasterpage",!1,function(){this.ServerClass="rwdpromptmasterpage";this.PackageName="GeneXus.Programs";this.setObjectType("web");this.IsMasterPage=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.e14062_client=function(){return this.executeServerEvent("ENTER_MPAGE",!0,null,!1,!1)};this.e15062_client=function(){return this.executeServerEvent("CANCEL_MPAGE",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5];this.GXLastCtrlId=5;n[2]={fld:"",grid:0};n[3]={fld:"MAINTABLE",grid:0};n[4]={fld:"",grid:0};n[5]={fld:"",grid:0};this.Events={e14062_client:["ENTER_MPAGE",!0],e15062_client:["CANCEL_MPAGE",!0]};this.EvtParms.REFRESH_MPAGE=[[],[]];this.EvtParms.START_MPAGE=[[],[]];this.Initialize()});gx.createMasterPage(rwdpromptmasterpage)