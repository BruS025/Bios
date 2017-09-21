/*
               File: PropiedadConversion
        Description: Conversion for table Propiedad
             Author: GeneXus C# Generator version 15_0_6-116888
       Generated on: 9/14/2017 20:18:10.22
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
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using System.Runtime.Remoting;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class propiedadconversion : GXProcedure
   {
      public propiedadconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public propiedadconversion( IGxContext context )
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

      public void executeSubmit( )
      {
         propiedadconversion objpropiedadconversion;
         objpropiedadconversion = new propiedadconversion();
         objpropiedadconversion.context.SetSubmitInitialConfig(context);
         objpropiedadconversion.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpropiedadconversion);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((propiedadconversion)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw e ;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Optimized copy (Insert w/Subselect). */
         /* Using cursor PROPIEDADC2 */
         pr_default.execute(0);
         pr_default.close(0);
         dsDefault.SmartCacheProvider.SetUpdated("Propiedad") ;
         /* End optimized group. */
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections() ;
         }
         exitApplication();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.propiedadconversion__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
   }

   public class propiedadconversion__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new UpdateCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmPROPIEDADC2 ;
          prmPROPIEDADC2 = new Object[] {
          } ;
          def= new CursorDef[] {
              new CursorDef("PROPIEDADC2", "INSERT INTO [GXA0002]([PropiedadId], [PropiedadDescripcion], [PropiedadFoto], [PropiedadFoto_GXI], [PropiedadDireccion], [BarrioId]) SELECT [PropiedadId], CONVERT( char(4), CAST([PropiedadDescripcion] AS decimal(4,0))) AS GXC2, CONVERT(varbinary(1), '') AS PropiedadFoto, ' ' AS PropiedadFoto_GXI, [PropiedadDireccion], [BarrioId]  FROM [Propiedad]", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmPROPIEDADC2)
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       switch ( cursor )
       {
       }
    }

 }

}
