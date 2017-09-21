/*
               File: reorg
        Description: Table Manager
             Author: GeneXus C# Generator version 15_0_6-116888
       Generated on: 9/14/2017 20:18:10.10
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
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using GeneXus.Data;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class reorg : GXReorganization
   {
      public reorg( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public reorg( IGxContext context )
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
         initialize();
         executePrivate();
      }

      void executePrivate( )
      {
         if ( PreviousCheck() )
         {
            ExecuteReorganization( ) ;
         }
      }

      private void FirstActions( )
      {
         /* Load data into tables. */
      }

      public void ReorganizePropiedad( )
      {
         String cmdBuffer = "" ;
         /* Indices for table Propiedad */
         try
         {
            cmdBuffer=" CREATE TABLE [GXA0002] ([PropiedadId]  smallint NOT NULL , [PropiedadDescripcion]  char(50) NOT NULL , [PropiedadFoto]  VARBINARY(MAX) NOT NULL , [PropiedadFoto_GXI]  varchar(2048) NOT NULL , [PropiedadDireccion]  char(50) NOT NULL , [BarrioId]  smallint NOT NULL )  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch ( Exception ex )
         {
            try
            {
               DropTableConstraints( "[GXA0002]") ;
               cmdBuffer=" DROP TABLE [GXA0002] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch ( Exception sqlex1 )
            {
               try
               {
                  DropTableConstraints( "[GXA0002]") ;
                  cmdBuffer=" DROP VIEW [GXA0002] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch ( Exception sqlex2 )
               {
                  try
                  {
                     DropTableConstraints( "[GXA0002]") ;
                     cmdBuffer=" DROP FUNCTION [GXA0002] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch ( Exception sqlex3 )
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [GXA0002] ([PropiedadId]  smallint NOT NULL , [PropiedadDescripcion]  char(50) NOT NULL , [PropiedadFoto]  VARBINARY(MAX) NOT NULL , [PropiedadFoto_GXI]  varchar(2048) NOT NULL , [PropiedadDireccion]  char(50) NOT NULL , [BarrioId]  smallint NOT NULL )  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         new propiedadconversion(context ).execute( ) ;
         try
         {
            DropTableConstraints( "[Propiedad]") ;
            cmdBuffer=" DROP TABLE [Propiedad] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch ( Exception sqlex1 )
         {
            try
            {
               DropTableConstraints( "[Propiedad]") ;
               cmdBuffer=" DROP VIEW [Propiedad] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch ( Exception sqlex2 )
            {
               try
               {
                  DropTableConstraints( "[Propiedad]") ;
                  cmdBuffer=" DROP FUNCTION [Propiedad] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch ( Exception sqlex3 )
               {
               }
            }
         }
         RGZ = new GxCommand(dsDefault.Db, "sp_rename", dsDefault,0,true,false,null);
         RGZ.CommandType = CommandType.StoredProcedure;
         RGZ.AddParameter("@objname","[GXA0002]");
         RGZ.AddParameter("@newname","Propiedad");
         RGZ.ExecuteStmt();
         cmdBuffer=" ALTER TABLE [Propiedad] ADD PRIMARY KEY([PropiedadId]) "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPROPIEDAD1] ON [Propiedad] ([BarrioId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch ( Exception ex )
         {
            cmdBuffer=" DROP INDEX [IPROPIEDAD1] ON [Propiedad] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPROPIEDAD1] ON [Propiedad] ([BarrioId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIAlquilerPropiedad( )
      {
         String cmdBuffer ;
         try
         {
            cmdBuffer=" ALTER TABLE [Alquiler] ADD CONSTRAINT [IALQUILER1] FOREIGN KEY ([PropiedadId]) REFERENCES [Propiedad] ([PropiedadId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch ( Exception ex )
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Alquiler] DROP CONSTRAINT [IALQUILER1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch ( Exception sqlex1 )
            {
            }
            cmdBuffer=" ALTER TABLE [Alquiler] ADD CONSTRAINT [IALQUILER1] FOREIGN KEY ([PropiedadId]) REFERENCES [Propiedad] ([PropiedadId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIVisitasVisitaProVisitas( )
      {
         String cmdBuffer ;
         try
         {
            cmdBuffer=" ALTER TABLE [VisitasVisitaPro] ADD CONSTRAINT [IVISITASVISITAPRO2] FOREIGN KEY ([VisitasId]) REFERENCES [Visitas] ([VisitasId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch ( Exception ex )
         {
            try
            {
               cmdBuffer=" ALTER TABLE [VisitasVisitaPro] DROP CONSTRAINT [IVISITASVISITAPRO2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch ( Exception sqlex1 )
            {
            }
            cmdBuffer=" ALTER TABLE [VisitasVisitaPro] ADD CONSTRAINT [IVISITASVISITAPRO2] FOREIGN KEY ([VisitasId]) REFERENCES [Visitas] ([VisitasId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIVisitasVisitaProPropiedad( )
      {
         String cmdBuffer ;
         try
         {
            cmdBuffer=" ALTER TABLE [VisitasVisitaPro] ADD CONSTRAINT [IVISITASVISITAPRO1] FOREIGN KEY ([PropiedadId]) REFERENCES [Propiedad] ([PropiedadId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch ( Exception ex )
         {
            try
            {
               cmdBuffer=" ALTER TABLE [VisitasVisitaPro] DROP CONSTRAINT [IVISITASVISITAPRO1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch ( Exception sqlex1 )
            {
            }
            cmdBuffer=" ALTER TABLE [VisitasVisitaPro] ADD CONSTRAINT [IVISITASVISITAPRO1] FOREIGN KEY ([PropiedadId]) REFERENCES [Propiedad] ([PropiedadId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIPropiedadBarrio( )
      {
         String cmdBuffer ;
         try
         {
            cmdBuffer=" ALTER TABLE [Propiedad] ADD CONSTRAINT [IPROPIEDAD1] FOREIGN KEY ([BarrioId]) REFERENCES [Barrio] ([BarrioId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch ( Exception ex )
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Propiedad] DROP CONSTRAINT [IPROPIEDAD1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch ( Exception sqlex1 )
            {
            }
            cmdBuffer=" ALTER TABLE [Propiedad] ADD CONSTRAINT [IPROPIEDAD1] FOREIGN KEY ([BarrioId]) REFERENCES [Barrio] ([BarrioId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      private void TablesCount( )
      {
         if ( ! IsResumeMode( ) )
         {
            /* Using cursor P00012 */
            pr_default.execute(0);
            PropiedadCount = P00012_APropiedadCount[0];
            pr_default.close(0);
            PrintRecordCount ( "Propiedad" ,  PropiedadCount );
         }
      }

      private bool PreviousCheck( )
      {
         if ( ! IsResumeMode( ) )
         {
            if ( GXUtil.DbmsVersion( context, "DEFAULT") < 10 )
            {
               SetCheckError ( GXResourceManager.GetMessage("GXM_bad_DBMS_version", new   object[]  {"2012"}) ) ;
               return false ;
            }
         }
         if ( ! MustRunCheck( ) )
         {
            return true ;
         }
         if ( GXUtil.IsSQLSERVER2005( context, "DEFAULT") )
         {
            /* Using cursor P00023 */
            pr_default.execute(1);
            while ( (pr_default.getStatus(1) != 101) )
            {
               sSchemaVar = P00023_AsSchemaVar[0];
               nsSchemaVar = P00023_nsSchemaVar[0];
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
         else
         {
            /* Using cursor P00034 */
            pr_default.execute(2);
            while ( (pr_default.getStatus(2) != 101) )
            {
               sSchemaVar = P00034_AsSchemaVar[0];
               nsSchemaVar = P00034_nsSchemaVar[0];
               pr_default.readNext(2);
            }
            pr_default.close(2);
         }
         if ( ! tableexist("Propiedad",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_not_exist", new   object[]  {"Propiedad"}) ) ;
            return false ;
         }
         return true ;
      }

      private bool tableexist( String sTableName ,
                               String sMySchemaName )
      {
         bool result ;
         result = false;
         /* Using cursor P00045 */
         pr_default.execute(3, new Object[] {sTableName, sMySchemaName});
         while ( (pr_default.getStatus(3) != 101) )
         {
            tablename = P00045_Atablename[0];
            ntablename = P00045_ntablename[0];
            schemaname = P00045_Aschemaname[0];
            nschemaname = P00045_nschemaname[0];
            result = true;
            pr_default.readNext(3);
         }
         pr_default.close(3);
         return result ;
      }

      private bool ColumnExist( String sTableName ,
                                String sMySchemaName ,
                                String sMyColumnName )
      {
         bool result ;
         result = false;
         /* Using cursor P00056 */
         pr_default.execute(4, new Object[] {sTableName, sMySchemaName, sMyColumnName});
         while ( (pr_default.getStatus(4) != 101) )
         {
            tablename = P00056_Atablename[0];
            ntablename = P00056_ntablename[0];
            schemaname = P00056_Aschemaname[0];
            nschemaname = P00056_nschemaname[0];
            columnname = P00056_Acolumnname[0];
            ncolumnname = P00056_ncolumnname[0];
            result = true;
            pr_default.readNext(4);
         }
         pr_default.close(4);
         return result ;
      }

      private void ExecuteOnlyTablesReorganization( )
      {
         ReorgExecute.RegisterBlockForSubmit( 1 ,  "ReorganizePropiedad" , new Object[]{ });
      }

      private void ExecuteOnlyRisReorganization( )
      {
         ReorgExecute.RegisterBlockForSubmit( 2 ,  "RIAlquilerPropiedad" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 3 ,  "RIVisitasVisitaProVisitas" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 4 ,  "RIVisitasVisitaProPropiedad" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 5 ,  "RIPropiedadBarrio" , new Object[]{ });
      }

      private void ExecuteTablesReorganization( )
      {
         ExecuteOnlyTablesReorganization( ) ;
         ExecuteOnlyRisReorganization( ) ;
         ReorgExecute.SubmitAll() ;
      }

      private void SetPrecedence( )
      {
         SetPrecedencetables( ) ;
         SetPrecedenceris( ) ;
      }

      private void SetPrecedencetables( )
      {
         GXReorganization.SetMsg( 1 ,  GXResourceManager.GetMessage("GXM_fileupdate", new   object[]  {"Propiedad", ""}) );
      }

      private void SetPrecedenceris( )
      {
         GXReorganization.SetMsg( 2 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IALQUILER1]"}) );
         ReorgExecute.RegisterPrecedence( "RIAlquilerPropiedad" ,  "ReorganizePropiedad" );
         GXReorganization.SetMsg( 3 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IVISITASVISITAPRO2]"}) );
         GXReorganization.SetMsg( 4 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IVISITASVISITAPRO1]"}) );
         ReorgExecute.RegisterPrecedence( "RIVisitasVisitaProPropiedad" ,  "ReorganizePropiedad" );
         GXReorganization.SetMsg( 5 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IPROPIEDAD1]"}) );
         ReorgExecute.RegisterPrecedence( "RIPropiedadBarrio" ,  "ReorganizePropiedad" );
      }

      private void ExecuteReorganization( )
      {
         if ( ErrCode == 0 )
         {
            TablesCount( ) ;
            if ( ! PrintOnlyRecordCount( ) )
            {
               FirstActions( ) ;
               SetPrecedence( ) ;
               ExecuteTablesReorganization( ) ;
            }
         }
      }

      [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
      public void DropTableConstraints( String sTableName )
      {
         String cmdBuffer ;
         /* Using cursor P00067 */
         pr_default.execute(5, new Object[] {sTableName});
         while ( (pr_default.getStatus(5) != 101) )
         {
            constid = P00067_Aconstid[0];
            nconstid = P00067_nconstid[0];
            fkeyid = P00067_Afkeyid[0];
            nfkeyid = P00067_nfkeyid[0];
            rkeyid = P00067_Arkeyid[0];
            nrkeyid = P00067_nrkeyid[0];
            cmdBuffer = "ALTER TABLE " + "[" + fkeyid + "] DROP CONSTRAINT " + constid;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            pr_default.readNext(5);
         }
         pr_default.close(5);
      }

      public void UtilsCleanup( )
      {
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         scmdbuf = "";
         P00012_APropiedadCount = new int[1] ;
         sSchemaVar = "";
         nsSchemaVar = false;
         P00023_AsSchemaVar = new String[] {""} ;
         P00023_nsSchemaVar = new bool[] {false} ;
         P00034_AsSchemaVar = new String[] {""} ;
         P00034_nsSchemaVar = new bool[] {false} ;
         sTableName = "";
         sMySchemaName = "";
         tablename = "";
         ntablename = false;
         schemaname = "";
         nschemaname = false;
         P00045_Atablename = new String[] {""} ;
         P00045_ntablename = new bool[] {false} ;
         P00045_Aschemaname = new String[] {""} ;
         P00045_nschemaname = new bool[] {false} ;
         sMyColumnName = "";
         columnname = "";
         ncolumnname = false;
         P00056_Atablename = new String[] {""} ;
         P00056_ntablename = new bool[] {false} ;
         P00056_Aschemaname = new String[] {""} ;
         P00056_nschemaname = new bool[] {false} ;
         P00056_Acolumnname = new String[] {""} ;
         P00056_ncolumnname = new bool[] {false} ;
         constid = "";
         nconstid = false;
         fkeyid = "";
         nfkeyid = false;
         P00067_Aconstid = new String[] {""} ;
         P00067_nconstid = new bool[] {false} ;
         P00067_Afkeyid = new String[] {""} ;
         P00067_nfkeyid = new bool[] {false} ;
         P00067_Arkeyid = new int[1] ;
         P00067_nrkeyid = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reorg__default(),
            new Object[][] {
                new Object[] {
               P00012_APropiedadCount
               }
               , new Object[] {
               P00023_AsSchemaVar
               }
               , new Object[] {
               P00034_AsSchemaVar
               }
               , new Object[] {
               P00045_Atablename, P00045_Aschemaname
               }
               , new Object[] {
               P00056_Atablename, P00056_Aschemaname, P00056_Acolumnname
               }
               , new Object[] {
               P00067_Aconstid, P00067_Afkeyid, P00067_Arkeyid
               }
            }
         );
         /* GeneXus formulas. */
      }

      protected short ErrCode ;
      protected int PropiedadCount ;
      protected int rkeyid ;
      protected String scmdbuf ;
      protected String sSchemaVar ;
      protected String sTableName ;
      protected String sMySchemaName ;
      protected String sMyColumnName ;
      protected bool nsSchemaVar ;
      protected bool ntablename ;
      protected bool nschemaname ;
      protected bool ncolumnname ;
      protected bool nconstid ;
      protected bool nfkeyid ;
      protected bool nrkeyid ;
      protected String tablename ;
      protected String schemaname ;
      protected String columnname ;
      protected String constid ;
      protected String fkeyid ;
      protected IGxDataStore dsDefault ;
      protected GxCommand RGZ ;
      protected IDataStoreProvider pr_default ;
      protected int[] P00012_APropiedadCount ;
      protected String[] P00023_AsSchemaVar ;
      protected bool[] P00023_nsSchemaVar ;
      protected String[] P00034_AsSchemaVar ;
      protected bool[] P00034_nsSchemaVar ;
      protected String[] P00045_Atablename ;
      protected bool[] P00045_ntablename ;
      protected String[] P00045_Aschemaname ;
      protected bool[] P00045_nschemaname ;
      protected String[] P00056_Atablename ;
      protected bool[] P00056_ntablename ;
      protected String[] P00056_Aschemaname ;
      protected bool[] P00056_nschemaname ;
      protected String[] P00056_Acolumnname ;
      protected bool[] P00056_ncolumnname ;
      protected String[] P00067_Aconstid ;
      protected bool[] P00067_nconstid ;
      protected String[] P00067_Afkeyid ;
      protected bool[] P00067_nfkeyid ;
      protected int[] P00067_Arkeyid ;
      protected bool[] P00067_nrkeyid ;
   }

   public class reorg__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00012 ;
          prmP00012 = new Object[] {
          } ;
          Object[] prmP00023 ;
          prmP00023 = new Object[] {
          } ;
          Object[] prmP00034 ;
          prmP00034 = new Object[] {
          } ;
          Object[] prmP00045 ;
          prmP00045 = new Object[] {
          new Object[] {"@sTableName",SqlDbType.Char,255,0} ,
          new Object[] {"@sMySchemaName",SqlDbType.Char,255,0}
          } ;
          Object[] prmP00056 ;
          prmP00056 = new Object[] {
          new Object[] {"@sTableName",SqlDbType.Char,255,0} ,
          new Object[] {"@sMySchemaName",SqlDbType.Char,255,0} ,
          new Object[] {"@sMyColumnName",SqlDbType.Char,255,0}
          } ;
          Object[] prmP00067 ;
          prmP00067 = new Object[] {
          new Object[] {"@sTableName",SqlDbType.Char,255,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P00012", "SELECT COUNT(*) FROM [Propiedad] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00012,100,0,true,false )
             ,new CursorDef("P00023", "SELECT SCHEMA_NAME() ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00023,100,0,true,false )
             ,new CursorDef("P00034", "SELECT USER_NAME() ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00034,100,0,true,false )
             ,new CursorDef("P00045", "SELECT [TABLE_NAME], [TABLE_SCHEMA] FROM INFORMATION_SCHEMA.TABLES WHERE ([TABLE_NAME] = @sTableName) AND ([TABLE_SCHEMA] = @sMySchemaName) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00045,100,0,true,false )
             ,new CursorDef("P00056", "SELECT [TABLE_NAME], [TABLE_SCHEMA], [COLUMN_NAME] FROM INFORMATION_SCHEMA.COLUMNS WHERE ([TABLE_NAME] = @sTableName) AND ([TABLE_SCHEMA] = @sMySchemaName) AND ([COLUMN_NAME] = @sMyColumnName) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00056,100,0,true,false )
             ,new CursorDef("P00067", "SELECT OBJECT_NAME(object_id), OBJECT_NAME(parent_object_id), [referenced_object_id] FROM sys.foreign_keys WHERE [referenced_object_id] = OBJECT_ID(RTRIM(LTRIM(@sTableName))) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00067,100,0,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                return;
             case 1 :
                ((String[]) buf[0])[0] = rslt.getString(1, 255) ;
                return;
             case 2 :
                ((String[]) buf[0])[0] = rslt.getString(1, 255) ;
                return;
             case 3 :
                ((String[]) buf[0])[0] = rslt.getVarchar(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                return;
             case 4 :
                ((String[]) buf[0])[0] = rslt.getVarchar(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
                return;
             case 5 :
                ((String[]) buf[0])[0] = rslt.getVarchar(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((int[]) buf[2])[0] = rslt.getInt(3) ;
                return;
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       switch ( cursor )
       {
             case 3 :
                stmt.SetParameter(1, (String)parms[0]);
                stmt.SetParameter(2, (String)parms[1]);
                return;
             case 4 :
                stmt.SetParameter(1, (String)parms[0]);
                stmt.SetParameter(2, (String)parms[1]);
                stmt.SetParameter(3, (String)parms[2]);
                return;
             case 5 :
                stmt.SetParameter(1, (String)parms[0]);
                return;
       }
    }

 }

}
