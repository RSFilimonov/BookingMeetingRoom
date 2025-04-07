﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApi.CQRS.Common.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ErrorMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ErrorMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("WebApi.CQRS.Common.Resources.ErrorMessages", typeof(ErrorMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
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
        ///   Looks up a localized string similar to Booking with id: \&quot;{0}\&quot; is cancelled or expired.
        /// </summary>
        public static string BookingIsCancelledOrExpired {
            get {
                return ResourceManager.GetString("BookingIsCancelledOrExpired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Booking with id: \&quot;{0}\&quot; is not active or not expired.
        /// </summary>
        public static string BookingIsNoActiveOrNoExpired {
            get {
                return ResourceManager.GetString("BookingIsNoActiveOrNoExpired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Booking with id: \&quot;{0}\&quot; was not found.
        /// </summary>
        public static string BookingNotFound {
            get {
                return ResourceManager.GetString("BookingNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Entity with id: \&quot;{0}\&quot; was not found.
        /// </summary>
        public static string EntityNotFound {
            get {
                return ResourceManager.GetString("EntityNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Internal server error.
        /// </summary>
        public static string InternalServerError {
            get {
                return ResourceManager.GetString("InternalServerError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unknown property: {0}.
        /// </summary>
        public static string UnknownProperty {
            get {
                return ResourceManager.GetString("UnknownProperty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The field \&quot;{0}\&quot; was not validated.
        /// </summary>
        public static string ValidationFailed {
            get {
                return ResourceManager.GetString("ValidationFailed", resourceCulture);
            }
        }
    }
}
