﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BCL_Samples.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class LogMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal LogMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BCL_Samples.Resources.LogMessages", typeof(LogMessages).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Founded File: {0} created at: {1}.
        /// </summary>
        internal static string FileInfoMessage {
            get {
                return ResourceManager.GetString("FileInfoMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to File mode failed from {0} to {1}.
        /// </summary>
        internal static string FileMovedFailureMessage {
            get {
                return ResourceManager.GetString("FileMovedFailureMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to File moved successfully from {0} to {1} folder .
        /// </summary>
        internal static string FileMovedSuccessMessage {
            get {
                return ResourceManager.GetString("FileMovedSuccessMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Rule {0} matches for {1}.
        /// </summary>
        internal static string RuleMatches {
            get {
                return ResourceManager.GetString("RuleMatches", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Rule {0} doesn&apos;t matches for {1}.
        /// </summary>
        internal static string RuleNotMatches {
            get {
                return ResourceManager.GetString("RuleNotMatches", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Press Ctrl+C or Ctrl+Break in order to stop execution.
        /// </summary>
        internal static string StopExecution {
            get {
                return ResourceManager.GetString("StopExecution", resourceCulture);
            }
        }
    }
}
