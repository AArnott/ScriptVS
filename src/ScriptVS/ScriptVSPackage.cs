﻿using System;
using System.IO;
using System.Runtime.InteropServices;
using Clide;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using ScriptVS.Project;

namespace ScriptVS
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [ProvideAutoLoad(UIContextGuids.NoSolution)]
    [ProvideAutoLoad(UIContextGuids.SolutionExists)]
    [InstalledProductRegistration("ScriptVS", "ScriptCS tools for Visual Studio", "1.0")]
    [Guid(Constants.PackageGuid)]
    public sealed class ScriptVSPackage : Package
    {
        static ScriptVSPackage()
        {
            LocalResolver.Initialize(Path.GetDirectoryName(typeof(ScriptVSPackage).Assembly.Location));
        }

        protected override void Initialize()
        {
            base.Initialize();
            Host.Initialize(this);
        }
    }
}
