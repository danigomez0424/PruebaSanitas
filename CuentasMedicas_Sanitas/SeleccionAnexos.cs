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
    ///The SeleccionAnexos recording.
    /// </summary>
    [TestModule("68ef6be1-8d39-410d-a419-d3059b92fda5", ModuleType.Recording, 1)]
    public partial class SeleccionAnexos : ITestModule
    {
        /// <summary>
        /// Holds an instance of the CuentasMedicas_SanitasRepository repository.
        /// </summary>
        public static CuentasMedicas_SanitasRepository repo = CuentasMedicas_SanitasRepository.Instance;

        static SeleccionAnexos instance = new SeleccionAnexos();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SeleccionAnexos()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static SeleccionAnexos Instance
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

            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence '{Next}'.", new RecordItemIndex(0));
            Keyboard.Press("{Next}");
            Delay.Milliseconds(0);
            
            try {
                Report.Log(ReportLevel.Info, "Mouse", "(Optional Action)\r\nMouse Left Click item 'Advertencia_COF.Aceptar' at Center.", repo.Advertencia_COF.AceptarInfo, new RecordItemIndex(1));
                repo.Advertencia_COF.Aceptar.Click();
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(1)); }
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
