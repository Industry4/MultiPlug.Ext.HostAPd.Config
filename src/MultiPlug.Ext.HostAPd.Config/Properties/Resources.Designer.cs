﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MultiPlug.Ext.HostAPd.Config.Properties {
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
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MultiPlug.Ext.HostAPd.Config.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to @model MultiPlug.Base.Http.EdgeApp
        ///
        ///&lt;section class=&quot;row-fluid&quot;&gt;
        ///
        ///    &lt;div class=&quot;row-fluid&quot;&gt;
        ///        &lt;div class=&quot;box&quot;&gt;
        ///            &lt;div class=&quot;span3&quot;&gt;
        ///                &lt;a style=&quot;line-height: 52px;&quot; href=&quot;#&quot;&gt;&lt;img alt=&quot;Raspberry Pi Logo&quot; src=&quot;@Raw(Model.Context.Paths.Assets)images/raspberry-pi.png&quot;&gt;&lt;/a&gt;
        ///            &lt;/div&gt;
        ///            &lt;div class=&quot;span6&quot;&gt;
        ///                &lt;p style=&quot;font-size:26px; line-height: 54px; text-align: center; margin: 0px;&quot;&gt;Raspberry Pi Configuration&lt;/p&gt;
        ///            &lt;/div&gt;
        ///   [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SettingsAbout {
            get {
                return ResourceManager.GetString("SettingsAbout", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to @model MultiPlug.Base.Http.EdgeApp
        ///
        ///&lt;section class=&quot;row-fluid&quot;&gt;
        ///
        ///    &lt;div class=&quot;row-fluid&quot;&gt;
        ///        &lt;div class=&quot;box&quot;&gt;
        ///            &lt;div class=&quot;span3&quot;&gt;
        ///                &lt;a style=&quot;line-height: 52px;&quot; href=&quot;#&quot;&gt;&lt;img alt=&quot;Raspberry Pi Logo&quot; src=&quot;@Raw(Model.Context.Paths.Assets)images/raspberry-pi.png&quot;&gt;&lt;/a&gt;
        ///            &lt;/div&gt;
        ///            &lt;div class=&quot;span6&quot;&gt;
        ///                &lt;p style=&quot;font-size:26px; line-height: 54px; text-align: center; margin: 0px;&quot;&gt;Raspberry Pi Configuration&lt;/p&gt;
        ///            &lt;/div&gt;
        ///   [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SettingsHome {
            get {
                return ResourceManager.GetString("SettingsHome", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to @model MultiPlug.Base.Http.EdgeApp
        ///@functions {
        ///    public string NavLocationIsHome()
        ///    {
        ///        return Model.Context.Paths.Current == Model.Context.Paths.Home ? &quot;active&quot; : string.Empty;
        ///    }
        ///
        ///    public string NavLocationIsAbout()
        ///    {
        ///        return Model.Context.Paths.Current == Model.Context.Paths.Home + &quot;about/&quot; ? &quot;active&quot; : string.Empty;
        ///    }
        ///}
        ///&lt;div class=&quot;row-fluid&quot;&gt;
        ///    &lt;ul class=&quot;nav nav-tabs&quot;&gt;
        ///        &lt;li class=&quot;@NavLocationIsHome()&quot;&gt;&lt;a href=&quot;@Raw(Model.Context.Paths.Home)&quot;&gt;Hom [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SettingsNavigation {
            get {
                return ResourceManager.GetString("SettingsNavigation", resourceCulture);
            }
        }
    }
}
