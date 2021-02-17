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
    ///The SeleccionNroIdentificacion recording.
    /// </summary>
    [TestModule("38d33879-e406-4dd6-b6fa-65d670cf1c52", ModuleType.Recording, 1)]
    public partial class SeleccionNroIdentificacion : ITestModule
    {
        /// <summary>
        /// Holds an instance of the CuentasMedicas_SanitasRepository repository.
        /// </summary>
        public static CuentasMedicas_SanitasRepository repo = CuentasMedicas_SanitasRepository.Instance;

        static SeleccionNroIdentificacion instance = new SeleccionNroIdentificacion();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SeleccionNroIdentificacion()
        {
            IdAnexoOriginal = "1";
            IdAnexo = "1";
            NroIdentificacion = "51876614";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static SeleccionNroIdentificacion Instance
        {
            get { return instance; }
        }

#region Variables

        string _IdAnexoOriginal;

        /// <summary>
        /// Gets or sets the value of variable IdAnexoOriginal.
        /// </summary>
        [TestVariable("8eb7f9ea-f153-4df1-8868-f44f2387af49")]
        public string IdAnexoOriginal
        {
            get { return _IdAnexoOriginal; }
            set { _IdAnexoOriginal = value; }
        }

        string _IdAnexo;

        /// <summary>
        /// Gets or sets the value of variable IdAnexo.
        /// </summary>
        [TestVariable("82731afd-f83b-45a8-bf3b-4c3533e5400c")]
        public string IdAnexo
        {
            get { return _IdAnexo; }
            set { _IdAnexo = value; }
        }

        /// <summary>
        /// Gets or sets the value of variable NroIdentificacion.
        /// </summary>
        [TestVariable("71b6b9bd-8304-4ebb-87de-a2a74fb9dd53")]
        public string NroIdentificacion
        {
            get { return repo.NroIdentificacion; }
            set { repo.NroIdentificacion = value; }
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

            SeleccionIdentificacion();
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}