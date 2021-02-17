﻿///////////////////////////////////////////////////////////////////////////////
//
// This file was automatically generated by RANOREX.
// Your custom recording code should go in this file.
// The designer will only add methods to this file, so your custom code won't be overwritten.
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
using Ranorex.Core.Repository;
using Ranorex.Core.Testing;

namespace CuentasMedicas_Sanitas
{
	public partial class SeleccionNroIdentificacion
	{
		/// <summary>
		/// This method gets called right after the recording has been started.
		/// It can be used to execute recording specific initialization code.
		/// </summary>
		private void Init()
		{
			// Your recording specific initialization code goes here.
		}

		public void SeleccionIdentificacion()
		{
			// TODO: Replace the following line with your code implementation.
			// throw new NotImplementedException();
			Report.Info("info","seleccionando nroidentificacion");
			//CuentasMedicas_SanitasRepository repo=CuentasMedicas_SanitasRepository.Instance;
			//CuentasMedicas_SanitasRepository.Instance.NroIdentificacion=NroIdentificacion;
			
			if(IdAnexoOriginal==IdAnexo) {
				repo.MDIPrincipal.NroIdentificacion.Click();
				Keyboard.Press(" ");
				Report.Info("info","Seleccion identificacion: "+NroIdentificacion);
				
			}else{
				Report.Info("info","No se seleccionaron identificaciones");
			}
			
		}
		
		

	}
}
