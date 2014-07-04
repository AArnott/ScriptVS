using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Microsoft.VisualStudio.ProjectSystem.Debuggers;
using Microsoft.VisualStudio.ProjectSystem.Utilities;
using Microsoft.VisualStudio.ProjectSystem.Utilities.DebuggerProviders;
using Microsoft.VisualStudio.ProjectSystem.VS.Debuggers;

namespace ScriptVS.Project
{
    [ExportDebugger("ConsoleDebugger")]
    [PartMetadata(ProjectCapabilities.Requires, Constants.ScriptCS)]
    internal class ConsoleDebugLaunchProvider : DebugLaunchProviderBase
    {
        public override async Task<bool> CanLaunchAsync(DebugLaunchOptions launchOptions)
        {
            return true;

            //var properties = await DebuggerProperties.GetVendorNameCoolDebuggerPropertiesAsync();
            //string commandValue = await properties.LocalDebuggerCommand.GetEvaluatedValueAtEndAsync();
            //return !string.IsNullOrEmpty(commandValue);

            return true;
        }

        public override async Task<IReadOnlyList<IDebugLaunchSettings>> QueryDebugTargetsAsync(DebugLaunchOptions launchOptions)
        {
            var settings = new DebugLaunchSettings(launchOptions);

            // The properties that are available via DebuggerProperties are determined by the property XAML files in your project.
            settings.Executable = @"C:\Users\Igal\AppData\Roaming\scriptcs\scriptcs.exe";

            settings.Arguments = @"D:\code\ScriptCSApp5\ScriptCSApp5\app.csx";
            settings.LaunchOperation = DebugLaunchOperation.CreateProcess;

            return new IDebugLaunchSettings[] { settings };
        }
    }
}