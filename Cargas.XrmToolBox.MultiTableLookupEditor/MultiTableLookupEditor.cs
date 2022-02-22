using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace Cargas.XrmToolBox.MultiTableLookupEditor
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "Multi-Table Lookup Editor"),
        ExportMetadata("Description", "Plugin to help create and manage multi-table lookups in D365"),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAMAAABEpIrGAAAABGdBTUEAALGPC / xhBQAAAAFzUkdCAK7OHOkAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAAlhQTFRFAAAABi5tBi5uBi9uBClmBCpoKLVwJ7VwKLRwKLRvBi9tJrZwIrRrBS5tBzBvWVN7BS9uAihuK8FwBi1uBzFwBSxsAAxuBzBwRbHJBzJwBC1uBjBuBS5uBC1sACdyBC5tCjJwBC5sCDBwBC1vAyotBS9lBy1sBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBS5tBi5uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBjFuKLRwKLVwBi5uBi9uBi9uBi5uFGdvKLdwKLVwBi5uBi9uBi9uBi9uJ7BwKLVwJ7VvBi9uBi9uBi1uFm5vKbdwKLVwBSxrBi9uBi9uBjBuJ7JwKLVwKLVwBi9uBi9uBi1uF3RvKLdwKLVwBi9uBi9uBi9uBi9uBi9uBzJuJ7NwKLVwKLVwBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBSxuGXxvKLdwKLVwBi9uBi9uBi9uKLVwJ7VwBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi5uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBS5tBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi5tBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBi9uBS5sBi9uBi9uBi9uBi9uBS5tBCpqBi1uBixsBi9u////AnwLJwAAAMZ0Uk5TAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABFEBtiZSThmg8FgIGQ5LK8/7xzp9mHjmk7odNJwlv4e542V0Qj/adm8IWC/zqd9xhAXb5mJ+9E0Ll5njfXAir68jclKW4EEjdeDQTDx9KeW7hVpHHNyIPwjst6ID4Plr91hlZ0RX35ivnXw7DvxxOlqbjS1LGcDM4tfXauezv0/TLMAicHbwRvqwjovoOZNLeIm690IMvAX6XhUwBAQIBC2fH/wAAAAFiS0dEx40FSlsAAAAJcEhZcwAAAEgAAABIAEbJaz4AAAG5SURBVDjLY2AgATCqqWtoamnr6OrpGxgyYUgzGxmbmJqZHwMCcwtLK2sbFkYU3ay2dvbHkIC5g6MTGztcnsnZxfUYCnBz9/Bk44DLe3n7oMof8/XzD2CDWx+oE4QmHxwSGsbGCZXnCo+IRJM/FhUdE4swIC4eXT4hMSmZjRsmn5KK5Pg0y/QMn2OZWdk5CANyLeDyefkFhUXFJaVl5RVsPFB5Xr5KuHxVNb8AUEhQqCa5Fh4GzEV1MHnXemZhzBhgbmiEKWgSYWTAoqCkGSpv0cKMLQ6ZW9ugCto7sCvohCno6mbCqiC3B6qgtw+7CX39UAVtE5hFoYJiQABXMHESzBeTp0CNYBQvmSrBC0sqktPg4Tx9CrMUOHatXWfMlJaBGTELnhbMZ8+ZO6V43pz5C44dWxjHLAuzYxEistoWL8xbAvHWUltmSLjJMXcuO4YNLF8BthDoipWrsCo4Nnk11NHMxWuwKrBbywwPi3VY5NevRgQc84aN6Mly06opyAHLtHnLVnNk+W0uRagBL6+wfcdOWNpr3rV7z16MiFFUKmqx3rd/46oDmgc7DmGNWCBQPnzkqIoqkgAAnh5i6QgpDbAAAAAldEVYdGRhdGU6Y3JlYXRlADIwMTgtMTEtMTRUMDM6NDI6NTErMDA6MDDFWY+0AAAAJXRFWHRkYXRlOm1vZGlmeQAyMDE4LTExLTE0VDAzOjQyOjUxKzAwOjAwtAQ3CAAAAEZ0RVh0c29mdHdhcmUASW1hZ2VNYWdpY2sgNi43LjgtOSAyMDE0LTA1LTEyIFExNiBodHRwOi8vd3d3LmltYWdlbWFnaWNrLm9yZ9yG7QAAAAAYdEVYdFRodW1iOjpEb2N1bWVudDo6UGFnZXMAMaf/uy8AAAAYdEVYdFRodW1iOjpJbWFnZTo6aGVpZ2h0ADE5Mg8AcoUAAAAXdEVYdFRodW1iOjpJbWFnZTo6V2lkdGgAMTky06whCAAAABl0RVh0VGh1bWI6Ok1pbWV0eXBlAGltYWdlL3BuZz+yVk4AAAAXdEVYdFRodW1iOjpNVGltZQAxNTQyMTY2OTcxfre4cgAAAA90RVh0VGh1bWI6OlNpemUAMEJClKI+7AAAAFZ0RVh0VGh1bWI6OlVSSQBmaWxlOi8vL21udGxvZy9mYXZpY29ucy8yMDE4LTExLTE0LzE2Y2RkYmZiOGFlZDUzNzFiN2NhYzQwNzg3N2QyYTdkLmljby5wbmemY5OCAAAAAElFTkSuQmCC"),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", null),
        ExportMetadata("BackgroundColor", "White"),
        ExportMetadata("PrimaryFontColor", "#052f6e"),
        ExportMetadata("SecondaryFontColor", "Gray")]
    public class MultiTableLookupEditor : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new MultiTableLookupEditorControl();
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public MultiTableLookupEditor()
        {
            // If you have external assemblies that you need to load, uncomment the following to 
            // hook into the event that will fire when an Assembly fails to resolve
            // AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null)
            {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);

                var assmbPath = Path.Combine(dir, $"{argName}.dll");

                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}