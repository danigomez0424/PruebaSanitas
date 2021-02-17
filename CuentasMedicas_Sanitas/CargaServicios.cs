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
    ///The CargaServicios recording.
    /// </summary>
    [TestModule("f85044a8-b820-44bd-890e-dcd5efe1804e", ModuleType.Recording, 1)]
    public partial class CargaServicios : ITestModule
    {
        /// <summary>
        /// Holds an instance of the CuentasMedicas_SanitasRepository repository.
        /// </summary>
        public static CuentasMedicas_SanitasRepository repo = CuentasMedicas_SanitasRepository.Instance;

        static CargaServicios instance = new CargaServicios();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CargaServicios()
        {
            VlrUnitario = "800000";
            CodServicio = "890701";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static CargaServicios Instance
        {
            get { return instance; }
        }

#region Variables

        string _VlrUnitario;

        /// <summary>
        /// Gets or sets the value of variable VlrUnitario.
        /// </summary>
        [TestVariable("77de4261-125c-4ad2-abc6-d5aa30528a31")]
        public string VlrUnitario
        {
            get { return _VlrUnitario; }
            set { _VlrUnitario = value; }
        }

        /// <summary>
        /// Gets or sets the value of variable CodServicio.
        /// </summary>
        [TestVariable("ed10afa6-5826-4062-826a-52f55a8a1898")]
        public string CodServicio
        {
            get { return repo.CodServicio; }
            set { repo.CodServicio = value; }
        }

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

            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'MDIPrincipal.CodigoServicioTemplate' at Center.", repo.MDIPrincipal.CodigoServicioTemplateInfo, new RecordItemIndex(0));
            repo.MDIPrincipal.CodigoServicioTemplate.Click();
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence from variable '$CodServicio'.", new RecordItemIndex(1));
            Keyboard.Press(CodServicio);
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence '{Tab}'.", new RecordItemIndex(2));
            Keyboard.Press("{Tab}");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'MDIPrincipal.VlrUnitario' at Center.", repo.MDIPrincipal.VlrUnitarioInfo, new RecordItemIndex(3));
            repo.MDIPrincipal.VlrUnitario.Click();
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence from variable '$VlrUnitario'.", new RecordItemIndex(4));
            Keyboard.Press(VlrUnitario);
            Delay.Milliseconds(20);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
