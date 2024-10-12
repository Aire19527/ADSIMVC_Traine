﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC.Common.Resources {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class GeneralMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal GeneralMessages() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MVC.Common.Resources.GeneralMessages", typeof(GeneralMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Credenciales Incorrectas..
        /// </summary>
        public static string BadCredentials {
            get {
                return ResourceManager.GetString("BadCredentials", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Factura cancelada exitosamente !.
        /// </summary>
        public static string CancelInvoice {
            get {
                return ResourceManager.GetString("CancelInvoice", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Archivo [&lt;strong&gt;{0}&lt;/strong&gt;]  no permitido..
        /// </summary>
        public static string DenegadeFile {
            get {
                return ResourceManager.GetString("DenegadeFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a La contraseña actual, es igual a la nueva contraseña. Por favor asignar contraseñas diferentes..
        /// </summary>
        public static string EqualCredentials {
            get {
                return ResourceManager.GetString("EqualCredentials", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Usuario no autenticado correctamente.
        /// </summary>
        public static string Error401 {
            get {
                return ResourceManager.GetString("Error401", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Ha ocurrido un error interno, por favor vuelva a intentarlo..
        /// </summary>
        public static string Error500 {
            get {
                return ResourceManager.GetString("Error500", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Ha ocurrido un error interno..
        /// </summary>
        public static string Error5001 {
            get {
                return ResourceManager.GetString("Error5001", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Hubo un problema {0}, por favor intentarlo de nuevo.
        /// </summary>
        public static string ErrorProcess {
            get {
                return ResourceManager.GetString("ErrorProcess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El nombre de usuario ya existe, por favor asignar otro.
        /// </summary>
        public static string ExistingName {
            get {
                return ResourceManager.GetString("ExistingName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El campo [{0}] es obligatorio..
        /// </summary>
        public static string FieldMandatory {
            get {
                return ResourceManager.GetString("FieldMandatory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Código generado exitosamente..
        /// </summary>
        public static string GeneratedCode {
            get {
                return ResourceManager.GetString("GeneratedCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El archivo seleccionado debe ser una imagen con formato [jpg,jpeg,png,gif,bmp].
        /// </summary>
        public static string ImgExtension {
            get {
                return ResourceManager.GetString("ImgExtension", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Registro eliminado satisfactoriamente..
        /// </summary>
        public static string ItemDeleted {
            get {
                return ResourceManager.GetString("ItemDeleted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a [{0}] ya se encuentra registrado..
        /// </summary>
        public static string ItemDuplicate {
            get {
                return ResourceManager.GetString("ItemDuplicate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a [{0}] ya existe en otro registro..
        /// </summary>
        public static string ItemExistingInARegister {
            get {
                return ResourceManager.GetString("ItemExistingInARegister", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Registro guardado satisfactoriamente..
        /// </summary>
        public static string ItemInserted {
            get {
                return ResourceManager.GetString("ItemInserted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a No fue posible eliminar el registro, por favor intentalo de nuevo..
        /// </summary>
        public static string ItemNoDeleted {
            get {
                return ResourceManager.GetString("ItemNoDeleted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a [{0}] no encontrado, por favor verificar los registros enviados..
        /// </summary>
        public static string ItemNoFound {
            get {
                return ResourceManager.GetString("ItemNoFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a No fue posible guardar el registro, por favor intentalo de nuevo..
        /// </summary>
        public static string ItemNoInserted {
            get {
                return ResourceManager.GetString("ItemNoInserted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a No fue posible actualizar el registro, por favor intentalo de nuevo..
        /// </summary>
        public static string ItemNoUpdated {
            get {
                return ResourceManager.GetString("ItemNoUpdated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Registro actualizado satisfactoriamente..
        /// </summary>
        public static string ItemUpdated {
            get {
                return ResourceManager.GetString("ItemUpdated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El porcentaje de descuento no puede ser mayor al {0}%.
        /// </summary>
        public static string MaxDiscount {
            get {
                return ResourceManager.GetString("MaxDiscount", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Mensaje Enviado al correo suministrado..
        /// </summary>
        public static string MessageSend {
            get {
                return ResourceManager.GetString("MessageSend", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El stock mínimo es de 1 producto.
        /// </summary>
        public static string MinimumProduct {
            get {
                return ResourceManager.GetString("MinimumProduct", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Hubo un error al realizar la operación, por favor vuelta a intentarlo..
        /// </summary>
        public static string OperationError {
            get {
                return ResourceManager.GetString("OperationError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a La cantidad de [{0}] es mayor a la que hay en stock [{1}].
        /// </summary>
        public static string OutOfStock {
            get {
                return ResourceManager.GetString("OutOfStock", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El Correo ya se encentra registrado en nuestro sistema, por favor usar otro..
        /// </summary>
        public static string RegisteredEmail {
            get {
                return ResourceManager.GetString("RegisteredEmail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Factura registrada correctamente !.
        /// </summary>
        public static string SuccesInvoice {
            get {
                return ResourceManager.GetString("SuccesInvoice", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a No hay un usuario especificado para este Email.
        /// </summary>
        public static string UserNotFoundByEmail {
            get {
                return ResourceManager.GetString("UserNotFoundByEmail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Estimado usuario, no posees los suficientes privilegios para realizar esta acción. Por favor contacta con un administrador..
        /// </summary>
        public static string WithoutPermission {
            get {
                return ResourceManager.GetString("WithoutPermission", resourceCulture);
            }
        }
    }
}