﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PresentacionWin.WSArticulos {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Articulo", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class Articulo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int CodigoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreField;
        
        private decimal PrecioField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int Codigo {
            get {
                return this.CodigoField;
            }
            set {
                if ((this.CodigoField.Equals(value) != true)) {
                    this.CodigoField = value;
                    this.RaisePropertyChanged("Codigo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Nombre {
            get {
                return this.NombreField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreField, value) != true)) {
                    this.NombreField = value;
                    this.RaisePropertyChanged("Nombre");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public decimal Precio {
            get {
                return this.PrecioField;
            }
            set {
                if ((this.PrecioField.Equals(value) != true)) {
                    this.PrecioField = value;
                    this.RaisePropertyChanged("Precio");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WSArticulos.ServicioArticulosSoap")]
    public interface ServicioArticulosSoap {
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento BuscarArticuloResult del espacio de nombres http://tempuri.org/ no está marcado para aceptar valores nil.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/BuscarArticulo", ReplyAction="*")]
        PresentacionWin.WSArticulos.BuscarArticuloResponse BuscarArticulo(PresentacionWin.WSArticulos.BuscarArticuloRequest request);
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento A del espacio de nombres http://tempuri.org/ no está marcado para aceptar valores nil.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AgregarArticulo", ReplyAction="*")]
        PresentacionWin.WSArticulos.AgregarArticuloResponse AgregarArticulo(PresentacionWin.WSArticulos.AgregarArticuloRequest request);
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento ListarArticuloResult del espacio de nombres http://tempuri.org/ no está marcado para aceptar valores nil.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ListarArticulo", ReplyAction="*")]
        PresentacionWin.WSArticulos.ListarArticuloResponse ListarArticulo(PresentacionWin.WSArticulos.ListarArticuloRequest request);
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento A del espacio de nombres http://tempuri.org/ no está marcado para aceptar valores nil.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/EliminarArticulo", ReplyAction="*")]
        PresentacionWin.WSArticulos.EliminarArticuloResponse EliminarArticulo(PresentacionWin.WSArticulos.EliminarArticuloRequest request);
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento A del espacio de nombres http://tempuri.org/ no está marcado para aceptar valores nil.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ModificarArticulo", ReplyAction="*")]
        PresentacionWin.WSArticulos.ModificarArticuloResponse ModificarArticulo(PresentacionWin.WSArticulos.ModificarArticuloRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class BuscarArticuloRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="BuscarArticulo", Namespace="http://tempuri.org/", Order=0)]
        public PresentacionWin.WSArticulos.BuscarArticuloRequestBody Body;
        
        public BuscarArticuloRequest() {
        }
        
        public BuscarArticuloRequest(PresentacionWin.WSArticulos.BuscarArticuloRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class BuscarArticuloRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int pCodigo;
        
        public BuscarArticuloRequestBody() {
        }
        
        public BuscarArticuloRequestBody(int pCodigo) {
            this.pCodigo = pCodigo;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class BuscarArticuloResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="BuscarArticuloResponse", Namespace="http://tempuri.org/", Order=0)]
        public PresentacionWin.WSArticulos.BuscarArticuloResponseBody Body;
        
        public BuscarArticuloResponse() {
        }
        
        public BuscarArticuloResponse(PresentacionWin.WSArticulos.BuscarArticuloResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class BuscarArticuloResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public PresentacionWin.WSArticulos.Articulo BuscarArticuloResult;
        
        public BuscarArticuloResponseBody() {
        }
        
        public BuscarArticuloResponseBody(PresentacionWin.WSArticulos.Articulo BuscarArticuloResult) {
            this.BuscarArticuloResult = BuscarArticuloResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AgregarArticuloRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="AgregarArticulo", Namespace="http://tempuri.org/", Order=0)]
        public PresentacionWin.WSArticulos.AgregarArticuloRequestBody Body;
        
        public AgregarArticuloRequest() {
        }
        
        public AgregarArticuloRequest(PresentacionWin.WSArticulos.AgregarArticuloRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class AgregarArticuloRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public PresentacionWin.WSArticulos.Articulo A;
        
        public AgregarArticuloRequestBody() {
        }
        
        public AgregarArticuloRequestBody(PresentacionWin.WSArticulos.Articulo A) {
            this.A = A;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AgregarArticuloResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="AgregarArticuloResponse", Namespace="http://tempuri.org/", Order=0)]
        public PresentacionWin.WSArticulos.AgregarArticuloResponseBody Body;
        
        public AgregarArticuloResponse() {
        }
        
        public AgregarArticuloResponse(PresentacionWin.WSArticulos.AgregarArticuloResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class AgregarArticuloResponseBody {
        
        public AgregarArticuloResponseBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ListarArticuloRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ListarArticulo", Namespace="http://tempuri.org/", Order=0)]
        public PresentacionWin.WSArticulos.ListarArticuloRequestBody Body;
        
        public ListarArticuloRequest() {
        }
        
        public ListarArticuloRequest(PresentacionWin.WSArticulos.ListarArticuloRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class ListarArticuloRequestBody {
        
        public ListarArticuloRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ListarArticuloResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ListarArticuloResponse", Namespace="http://tempuri.org/", Order=0)]
        public PresentacionWin.WSArticulos.ListarArticuloResponseBody Body;
        
        public ListarArticuloResponse() {
        }
        
        public ListarArticuloResponse(PresentacionWin.WSArticulos.ListarArticuloResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ListarArticuloResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public PresentacionWin.WSArticulos.Articulo[] ListarArticuloResult;
        
        public ListarArticuloResponseBody() {
        }
        
        public ListarArticuloResponseBody(PresentacionWin.WSArticulos.Articulo[] ListarArticuloResult) {
            this.ListarArticuloResult = ListarArticuloResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class EliminarArticuloRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="EliminarArticulo", Namespace="http://tempuri.org/", Order=0)]
        public PresentacionWin.WSArticulos.EliminarArticuloRequestBody Body;
        
        public EliminarArticuloRequest() {
        }
        
        public EliminarArticuloRequest(PresentacionWin.WSArticulos.EliminarArticuloRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class EliminarArticuloRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public PresentacionWin.WSArticulos.Articulo A;
        
        public EliminarArticuloRequestBody() {
        }
        
        public EliminarArticuloRequestBody(PresentacionWin.WSArticulos.Articulo A) {
            this.A = A;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class EliminarArticuloResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="EliminarArticuloResponse", Namespace="http://tempuri.org/", Order=0)]
        public PresentacionWin.WSArticulos.EliminarArticuloResponseBody Body;
        
        public EliminarArticuloResponse() {
        }
        
        public EliminarArticuloResponse(PresentacionWin.WSArticulos.EliminarArticuloResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class EliminarArticuloResponseBody {
        
        public EliminarArticuloResponseBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ModificarArticuloRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ModificarArticulo", Namespace="http://tempuri.org/", Order=0)]
        public PresentacionWin.WSArticulos.ModificarArticuloRequestBody Body;
        
        public ModificarArticuloRequest() {
        }
        
        public ModificarArticuloRequest(PresentacionWin.WSArticulos.ModificarArticuloRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ModificarArticuloRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public PresentacionWin.WSArticulos.Articulo A;
        
        public ModificarArticuloRequestBody() {
        }
        
        public ModificarArticuloRequestBody(PresentacionWin.WSArticulos.Articulo A) {
            this.A = A;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ModificarArticuloResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ModificarArticuloResponse", Namespace="http://tempuri.org/", Order=0)]
        public PresentacionWin.WSArticulos.ModificarArticuloResponseBody Body;
        
        public ModificarArticuloResponse() {
        }
        
        public ModificarArticuloResponse(PresentacionWin.WSArticulos.ModificarArticuloResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class ModificarArticuloResponseBody {
        
        public ModificarArticuloResponseBody() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ServicioArticulosSoapChannel : PresentacionWin.WSArticulos.ServicioArticulosSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServicioArticulosSoapClient : System.ServiceModel.ClientBase<PresentacionWin.WSArticulos.ServicioArticulosSoap>, PresentacionWin.WSArticulos.ServicioArticulosSoap {
        
        public ServicioArticulosSoapClient() {
        }
        
        public ServicioArticulosSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServicioArticulosSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioArticulosSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioArticulosSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PresentacionWin.WSArticulos.BuscarArticuloResponse PresentacionWin.WSArticulos.ServicioArticulosSoap.BuscarArticulo(PresentacionWin.WSArticulos.BuscarArticuloRequest request) {
            return base.Channel.BuscarArticulo(request);
        }
        
        public PresentacionWin.WSArticulos.Articulo BuscarArticulo(int pCodigo) {
            PresentacionWin.WSArticulos.BuscarArticuloRequest inValue = new PresentacionWin.WSArticulos.BuscarArticuloRequest();
            inValue.Body = new PresentacionWin.WSArticulos.BuscarArticuloRequestBody();
            inValue.Body.pCodigo = pCodigo;
            PresentacionWin.WSArticulos.BuscarArticuloResponse retVal = ((PresentacionWin.WSArticulos.ServicioArticulosSoap)(this)).BuscarArticulo(inValue);
            return retVal.Body.BuscarArticuloResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PresentacionWin.WSArticulos.AgregarArticuloResponse PresentacionWin.WSArticulos.ServicioArticulosSoap.AgregarArticulo(PresentacionWin.WSArticulos.AgregarArticuloRequest request) {
            return base.Channel.AgregarArticulo(request);
        }
        
        public void AgregarArticulo(PresentacionWin.WSArticulos.Articulo A) {
            PresentacionWin.WSArticulos.AgregarArticuloRequest inValue = new PresentacionWin.WSArticulos.AgregarArticuloRequest();
            inValue.Body = new PresentacionWin.WSArticulos.AgregarArticuloRequestBody();
            inValue.Body.A = A;
            PresentacionWin.WSArticulos.AgregarArticuloResponse retVal = ((PresentacionWin.WSArticulos.ServicioArticulosSoap)(this)).AgregarArticulo(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PresentacionWin.WSArticulos.ListarArticuloResponse PresentacionWin.WSArticulos.ServicioArticulosSoap.ListarArticulo(PresentacionWin.WSArticulos.ListarArticuloRequest request) {
            return base.Channel.ListarArticulo(request);
        }
        
        public PresentacionWin.WSArticulos.Articulo[] ListarArticulo() {
            PresentacionWin.WSArticulos.ListarArticuloRequest inValue = new PresentacionWin.WSArticulos.ListarArticuloRequest();
            inValue.Body = new PresentacionWin.WSArticulos.ListarArticuloRequestBody();
            PresentacionWin.WSArticulos.ListarArticuloResponse retVal = ((PresentacionWin.WSArticulos.ServicioArticulosSoap)(this)).ListarArticulo(inValue);
            return retVal.Body.ListarArticuloResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PresentacionWin.WSArticulos.EliminarArticuloResponse PresentacionWin.WSArticulos.ServicioArticulosSoap.EliminarArticulo(PresentacionWin.WSArticulos.EliminarArticuloRequest request) {
            return base.Channel.EliminarArticulo(request);
        }
        
        public void EliminarArticulo(PresentacionWin.WSArticulos.Articulo A) {
            PresentacionWin.WSArticulos.EliminarArticuloRequest inValue = new PresentacionWin.WSArticulos.EliminarArticuloRequest();
            inValue.Body = new PresentacionWin.WSArticulos.EliminarArticuloRequestBody();
            inValue.Body.A = A;
            PresentacionWin.WSArticulos.EliminarArticuloResponse retVal = ((PresentacionWin.WSArticulos.ServicioArticulosSoap)(this)).EliminarArticulo(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PresentacionWin.WSArticulos.ModificarArticuloResponse PresentacionWin.WSArticulos.ServicioArticulosSoap.ModificarArticulo(PresentacionWin.WSArticulos.ModificarArticuloRequest request) {
            return base.Channel.ModificarArticulo(request);
        }
        
        public void ModificarArticulo(PresentacionWin.WSArticulos.Articulo A) {
            PresentacionWin.WSArticulos.ModificarArticuloRequest inValue = new PresentacionWin.WSArticulos.ModificarArticuloRequest();
            inValue.Body = new PresentacionWin.WSArticulos.ModificarArticuloRequestBody();
            inValue.Body.A = A;
            PresentacionWin.WSArticulos.ModificarArticuloResponse retVal = ((PresentacionWin.WSArticulos.ServicioArticulosSoap)(this)).ModificarArticulo(inValue);
        }
    }
}
