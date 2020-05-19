namespace Pandemic.Web.Resources {
    using System;
    

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        

        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Pandemic.Web.Resources.Resource", typeof(Resource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        

        public static string ChangePasswordSuccess {
            get {
                return ResourceManager.GetString("ChangePasswordSuccess", resourceCulture);
            }
        }
        

        public static string Confirm {
            get {
                return ResourceManager.GetString("Confirm", resourceCulture);
            }
        }
        

        public static string ConfirmEmail {
            get {
                return ResourceManager.GetString("ConfirmEmail", resourceCulture);
            }
        }
        

        public static string EmailConfirmationBody {
            get {
                return ResourceManager.GetString("EmailConfirmationBody", resourceCulture);
            }
        }
        

        public static string EmailConfirmationSent {
            get {
                return ResourceManager.GetString("EmailConfirmationSent", resourceCulture);
            }
        }

        public static string EmailConfirmationSubject {
            get {
                return ResourceManager.GetString("EmailConfirmationSubject", resourceCulture);
            }
        }
        

        public static string RecoverPasswordBody {
            get {
                return ResourceManager.GetString("RecoverPasswordBody", resourceCulture);
            }
        }
        

        public static string RecoverPasswordEmailSent {
            get {
                return ResourceManager.GetString("RecoverPasswordEmailSent", resourceCulture);
            }
        }
        

        public static string RecoverPasswordSubject {
            get {
                return ResourceManager.GetString("RecoverPasswordSubject", resourceCulture);
            }
        }
        

        public static string Reject {
            get {
                return ResourceManager.GetString("Reject", resourceCulture);
            }
        }
        

        public static string ReportNotFoundError {
            get {
                return ResourceManager.GetString("ReportNotFoundError", resourceCulture);
            }
        }

        public static string RequestJoinGroupEmailSent {
            get {
                return ResourceManager.GetString("RequestJoinGroupEmailSent", resourceCulture);
            }
        }
        

        public static string TheUser {
            get {
                return ResourceManager.GetString("TheUser", resourceCulture);
            }
        }
        

        public static string UserAlreadyExists {
            get {
                return ResourceManager.GetString("UserAlreadyExists", resourceCulture);
            }
        }
        

        public static string UserNotFoundError {
            get {
                return ResourceManager.GetString("UserNotFoundError", resourceCulture);
            }
        }
    }
}
