﻿///////////////////////////////////////////////////////////////////////////////
//
// This file was automatically generated by RANOREX.
// DO NOT MODIFY THIS FILE! It is regenerated by the designer.
// All your modifications will be lost!
// http://www.ranorex.com
//
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using Ranorex.Core.Repository;

namespace CuentasMedicas_Sanitas
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The PrubeaJmeter recording.
    /// </summary>
    [TestModule("e56e0385-e984-4d88-885e-d7765a632e99", ModuleType.Recording, 1)]
    public partial class PrubeaJmeter : ITestModule
    {
        /// <summary>
        /// Holds an instance of the CuentasMedicas_SanitasRepository repository.
        /// </summary>
        public static CuentasMedicas_SanitasRepository repo = CuentasMedicas_SanitasRepository.Instance;

        static PrubeaJmeter instance = new PrubeaJmeter();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public PrubeaJmeter()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static PrubeaJmeter Instance
        {
            get { return instance; }
        }

#region Variables

#endregion

        /// <summary>
        /// Starts the replay of the static recording <see cref="Instance"/>.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("Ranorex", global::Ranorex.Core.Constants.CodeGenVersion)]
        public static void Start()
        {
            TestModuleRunner.Run(Instance);
        }

        /// <summary>
        /// Performs the playback of actions in this recording.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        [System.CodeDom.Compiler.GeneratedCode("Ranorex", global::Ranorex.Core.Constants.CodeGenVersion)]
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 20;
            Delay.SpeedFactor = 1.00;

            Init();

            JmeterRanorexPlugin.JmeterPluginC.RunJmeterProject("C:\\A2M_Sanitas.jmx");
            Delay.Milliseconds(0);
            
            JmeterRanorexPlugin.JmeterPluginC.AddReportResult_Full();
            Delay.Milliseconds(0);
            
            JmeterRanorexPlugin.JmeterPluginC.AddReportResult_ThreadsStateOverTime();
            Delay.Milliseconds(0);
            
            JmeterRanorexPlugin.JmeterPluginC.RestartReportRecord();
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}