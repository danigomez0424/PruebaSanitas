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
    public partial class CargaServiciosMasiva
    {
        /// <summary>
        /// This method gets called right after the recording has been started.
        /// It can be used to execute recording specific initialization code.
        /// </summary>
        private void Init()
        {
            // Your recording specific initialization code goes here.
        }

        public void CargaServicios()
        {
            // TODO: Replace the following line with your code implementation.
            //throw new NotImplementedException();
            
            if (NroIdentificacionOriginal==NroIdentificacion){
            
            
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
            
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence '{Tab}'.", new RecordItemIndex(2));
            Keyboard.Press("{Tab}");
            Delay.Milliseconds(0);
            
            }
            
            
        }

    }
}
