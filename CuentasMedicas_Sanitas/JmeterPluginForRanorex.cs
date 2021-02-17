/*
 * Created by Ranorex
 * User: PC
 * Date: 6/8/2020
 * Time: 19:35
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;
using System.Diagnostics;
using System.IO;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;


namespace JmeterRanorexPlugin
{
    /// <summary>
    /// Creates a Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    ///     		

    [UserCodeCollection]
    public static class JmeterPluginC
    {	    	
            public static double prom_cpuUsage = 0;
            public static int time_cpuUsage = 0;
            public static double prom_ramUsage = 0;
            [UserCodeMethod]
    		public static void RunJmeterProject(String projectFile){

            	Ranorex.Core.Reporting.TestReport.EnableTracingScreenshots=false;
            	Report.Info("The execution starts");
           
            	Thread t = new Thread(() => ThreadProc());
            	t.Start();
				string strCmdText= "/C cd /d \"%RANOREX_JMETER%\" & " +
					"jmeter -n -t \""+projectFile+"\" -l \""+Ranorex.Core.Testing.TestSuite.WorkingDirectory+"\\jmeterReport\\file.jtl\"";
				var ProcessStart = new ProcessStartInfo("cmd.exe", strCmdText) 
					{
					    CreateNoWindow = false,
					    WorkingDirectory = @"C:\Windows\System32\",
					    UseShellExecute = false
					};
				Process p = Process.Start(ProcessStart);
				p.WaitForExit();
				t.Abort();
				Report.Info("Execution ends");
				strCmdText= "/C cd /d \"%RANOREX_JMETER%\" & " +
					"JMeterPluginsCMD.bat --generate-png \""+Ranorex.Core.Testing.TestSuite.WorkingDirectory+"\\jmeterReport\\ResponseTimesOverTime.png\" --input-jtl \""+Ranorex.Core.Testing.TestSuite.WorkingDirectory+"\\jmeterReport\\file.jtl\" --plugin-type ResponseTimesOverTime --width 800 --height 600 &" +
					"JMeterPluginsCMD.bat --generate-png \""+Ranorex.Core.Testing.TestSuite.WorkingDirectory+"\\jmeterReport\\ResponseCodesPerSecond.png\" --input-jtl \""+Ranorex.Core.Testing.TestSuite.WorkingDirectory+"\\jmeterReport\\file.jtl\" --plugin-type ResponseCodesPerSecond --width 800 --height 600 &" +
					"JMeterPluginsCMD.bat --generate-png \""+Ranorex.Core.Testing.TestSuite.WorkingDirectory+"\\jmeterReport\\ThreadsStateOverTime.png\" --input-jtl \""+Ranorex.Core.Testing.TestSuite.WorkingDirectory+"\\jmeterReport\\file.jtl\" --plugin-type ThreadsStateOverTime  --width 800 --height 600 &" +
					"JMeterPluginsCMD.bat --generate-csv \""+Ranorex.Core.Testing.TestSuite.WorkingDirectory+"\\jmeterReport\\ThreadsStateOverTime.csv\" --input-jtl \""+Ranorex.Core.Testing.TestSuite.WorkingDirectory+"\\jmeterReport\\file.jtl\" --plugin-type ThreadsStateOverTime &" +
					"JMeterPluginsCMD.bat --generate-png \""+Ranorex.Core.Testing.TestSuite.WorkingDirectory+"\\jmeterReport\\ResponseTimesDistribution.png\" --input-jtl \""+Ranorex.Core.Testing.TestSuite.WorkingDirectory+"\\jmeterReport\\file.jtl\" --plugin-type ResponseTimesDistribution --width 800 --height 600 &" +
					"";
				ProcessStart = new ProcessStartInfo("cmd.exe", strCmdText) 
					{
					    CreateNoWindow = false,
					    WorkingDirectory = @"C:\Windows\System32\",
					    UseShellExecute = false
					};
				p = Process.Start(ProcessStart);
				p.WaitForExit();
				Ranorex.Core.Reporting.TestReport.EnableTracingScreenshots=true;
			}
            [UserCodeMethod]
    		public static void AddReportResult_ResponseTimesOverTime(){
             	Report.LogData(ReportLevel.Info,"ResponseTimesOverTime", Ranorex.Imaging.Load(Ranorex.Core.Testing.TestSuite.WorkingDirectory+"\\jmeterReport\\ResponseTimesOverTime.png"));
            }
            [UserCodeMethod]
    		public static void AddReportResult_ResponseCodesPerSecond(){
             	Report.LogData(ReportLevel.Info,"ResponseCodesPerSecond", Ranorex.Imaging.Load(Ranorex.Core.Testing.TestSuite.WorkingDirectory+"\\jmeterReport\\ResponseCodesPerSecond.png"));
            }
            [UserCodeMethod]
    		public static void AddReportResult_ThreadsStateOverTime(){
             	Report.LogData(ReportLevel.Info,"TimesVsThreads", Ranorex.Imaging.Load(Ranorex.Core.Testing.TestSuite.WorkingDirectory+"\\jmeterReport\\ThreadsStateOverTime.png"));
            }
            [UserCodeMethod]
    		public static void AddReportResult_ResponseTimesDistribution(){
             	Report.LogData(ReportLevel.Info,"ResponseTimesDistribution", Ranorex.Imaging.Load(Ranorex.Core.Testing.TestSuite.WorkingDirectory+"\\jmeterReport\\ResponseTimesDistribution.png"));
            }
            [UserCodeMethod]
    		public static void RestartReportRecord(){
            	try{
             		File.Delete(Ranorex.Core.Testing.TestSuite.WorkingDirectory+"\\jmeterReport\\file.jtl");
            	}
            	catch(Exception e){
            		
            	}
            }
            [UserCodeMethod]
    		public static void AddReportResult_SaveErrorsInCSV(){
             	string filePath =  Ranorex.Core.Testing.TestSuite.WorkingDirectory+"\\jmeterReport\\file.jtl";
             	string currentWorkingDirectory = Ranorex.Core.Reporting.TestReport.ReportEnvironment.ReportFileDirectory;  
	            Boolean error=false;
             	//Add timestamp
	            string timestamp = System.DateTime.Now.ToString("yyyyMMdd_HHmmss");                    
            	string destination = currentWorkingDirectory + @"\" + timestamp +  "fileError.csv";  
            	byte[] newline = Encoding.ASCII.GetBytes(Environment.NewLine);
             	FileStream fs = File.Create(destination);
			    using (StreamReader sr = new StreamReader(filePath))
			        {
			            String line;
			            while ((line = sr.ReadLine()) != null)
			            {
							if(!line.Contains("timeStamp,")){
								if(!line.Contains(",OK,")){
									fs.Write(new UTF8Encoding(true).GetBytes(line),0, line.Length);
									fs.Write(newline,0, newline.Length);
									error=true;
								   }
							}
							else{
								fs.Write(new UTF8Encoding(true).GetBytes(line),0, line.Length);
									fs.Write(newline,0, newline.Length);
							}
			            }
			        }
			    fs.Close();
			    Ranorex.Core.Reporting.TestReport.EnableTracingScreenshots=false;
			    if(!error){
            		Report.Info("The execution finished without errors");
			    }
			    else{
			    	Report.LogHtml(Ranorex.ReportLevel.Error, "Execution has failures", "<a href='"+destination+"'>"+destination+"</a>");  	
			    }			    	
            }
            [UserCodeMethod]
    		public static void AddReportResult_Full(){
            	//datos
            	string name = "";

            	int maxUsers = 0;
            	int total_test = 0;
            	double test_Second = 0;
            	int test_fails = 0;
            	double prom_test_time = 0;
            	double pages_Second= 0;
            	double solit_second = 0;
            	double solit_fails = 0;
            	double prom_request = 0;
            	double prom_long = 0;
            	double duration = 0;
            	long firstTime = 0;
            	long lastTime = 0;
            	int auxPromTime = 0;
            	int[][] grupThreads= null;
           		//
             	string filePath =  Ranorex.Core.Testing.TestSuite.WorkingDirectory+"\\jmeterReport\\file.jtl";
             	string currentWorkingDirectory = Ranorex.Core.Reporting.TestReport.ReportEnvironment.ReportFileDirectory;  
	            Boolean error=false;
             	//Add timestamp
	            string timestamp = System.DateTime.Now.ToString("yyyyMMdd_HHmmss");                    
            	string destination = currentWorkingDirectory + @"\" + timestamp +  "ReportFull.csv";  
            	byte[] newline = Encoding.ASCII.GetBytes(Environment.NewLine);
             	FileStream fs = File.Create(destination);
             	string[] headers = null;
             	string[] actualstream = null;
             	int auxThreads = 0;
             	
			    using (StreamReader sr = new StreamReader(filePath))
			        {
			            String line;
			            
			            while ((line = sr.ReadLine()) != null)
			            {
							if(!line.Contains("timeStamp,")){
			            		total_test = total_test + 1;
			            		actualstream = line.Split(char.Parse(","));
			            		for(int x=0;x < actualstream.Length;x++){
			            			Console.WriteLine("header: " + headers[x] + "_content: "+actualstream[x]);
			            			try{
				            			switch(headers[x]){
				            				case "elapsed":
			            						//Report.Info(auxPromTime + "__"+actualstream[x]);
			            						auxPromTime = auxPromTime + int.Parse(actualstream[x]);
				            					break;
				            				case "success":
				            					if(!actualstream[x].Contains("true")){
				            						test_fails = test_fails + 1;
				            					}
				            					break;

				            				case "grpThreads":
					            				try {
				            						auxThreads = int.Parse(actualstream[x].Substring(actualstream[x].LastIndexOf("-")-1));
					            				} catch (Exception e1) {
					            					
					            				}
				            					break;
				            			}
			            			}
			            			catch(Exception e){
			            				Console.WriteLine(e.StackTrace);}
			            		}
							}
							else{
			            		headers = line.Split(char.Parse(","));
							}
			            }
			        }
			    //WRITE
			    //PROMS
			    prom_test_time = auxPromTime / total_test;
			    
			    //	
			    string aux = "Duracion prueba";
			    duration = auxPromTime/1000;
			    string aux2 = duration + " Segundos";
			    fs.Write(new UTF8Encoding(true).GetBytes(aux+","+aux2),0, aux.Length + aux2.Length+1);
				fs.Write(newline,0, newline.Length);
				Report.Info(aux,aux2);
			    aux = "Cantidad de solicitudes";
			    aux2 = total_test.ToString();
			    fs.Write(new UTF8Encoding(true).GetBytes(aux+","+aux2),0, aux.Length+aux2.Length+1);
				fs.Write(newline,0, newline.Length);
				Report.Info(aux,aux2);
			    aux = "Tiempo promedio de respuesta";
			    aux2 = prom_test_time.ToString() + " milisegundos";
			    fs.Write(new UTF8Encoding(true).GetBytes(aux+","+aux2),0, aux.Length+aux2.Length+1);
				fs.Write(newline,0, newline.Length);
				Report.Info(aux,aux2);
				aux ="Pruebas fallidas" ;
				aux2 = test_fails.ToString();
				fs.Write(new UTF8Encoding(true).GetBytes(aux+","+aux2),0, aux.Length+aux2.Length+1);
				fs.Write(newline,0, newline.Length);
				Report.Info(aux,aux2);
				aux ="Nombre del equipo" ;
				aux2 = Environment.MachineName;
				fs.Write(new UTF8Encoding(true).GetBytes(aux+","+aux2),0, aux.Length+aux2.Length+1);
				fs.Write(newline,0, newline.Length);
				Report.Info(aux,aux2);
				aux ="Promedio uso CPU" ;
				aux2 = Math.Ceiling(prom_cpuUsage/time_cpuUsage).ToString() + "%";
				fs.Write(new UTF8Encoding(true).GetBytes(aux+","+aux2),0, aux.Length+aux2.Length+1);
				fs.Write(newline,0, newline.Length);
				Report.Info(aux,aux2);
				aux ="Promedio uso Memoria" ;
				double ramaux = prom_ramUsage/time_cpuUsage;
				aux2 = Math.Ceiling((double)Convert.ToInt32(ramaux) / (int)(1024)/1024).ToString() + "MB";
				fs.Write(new UTF8Encoding(true).GetBytes(aux+","+aux2),0, aux.Length+aux2.Length+1);
				fs.Write(newline,0, newline.Length);
				Report.Info(aux,aux2);
				if(test_fails>0){
					Report.Failure("La prueba tuvo casos fallidos");
				}
				//
			    fs.Close();
			    Ranorex.Core.Reporting.TestReport.EnableTracingScreenshots=false;
			    			    	Report.LogHtml(Ranorex.ReportLevel.Info, "Resultado de la ejecucion", "<a href='"+destination+"'>"+destination+"</a>");  				    	
            }
            [UserCodeMethod]
    		public static void AddReportResult_SaveIfTimeGreaterThan_InCSV(int milliseconds){
             	string filePath =  Ranorex.Core.Testing.TestSuite.WorkingDirectory+"\\jmeterReport\\file.jtl";
             	string currentWorkingDirectory = Ranorex.Core.Reporting.TestReport.ReportEnvironment.ReportFileDirectory;  
	            Boolean error=false;
             	//Add timestamp
	            string timestamp = System.DateTime.Now.ToString("yyyyMMdd_HHmmss");                    
            	string destination = currentWorkingDirectory + @"\" + timestamp +  "fileElapsedTimes.csv";  
            	byte[] newline = Encoding.ASCII.GetBytes(Environment.NewLine);
             	FileStream fs = File.Create(destination);
             	String[] list = null;

			    using (StreamReader sr = new StreamReader(filePath))
			        {
			            String line;
			            while ((line = sr.ReadLine()) != null)
			            {
			            	list = line.Split(char.Parse(","));
			            	try{
								if(!line.Contains("timeStamp,")){
									if(int.Parse(list[1])>milliseconds){
									fs.Write(new UTF8Encoding(true).GetBytes(line),0, line.Length);
									fs.Write(newline,0, newline.Length);
									error=true;
								   }
								}
								else{
									fs.Write(new UTF8Encoding(true).GetBytes(line),0, line.Length);
									fs.Write(newline,0, newline.Length);
								}
			            	}
			            	catch(Exception e){
			            		fs.Write(new UTF8Encoding(true).GetBytes(line),0, line.Length);
			            		fs.Write(newline,0, newline.Length);
			            	}
			            	
			            }
			        }
			    fs.Close();
			    Ranorex.Core.Reporting.TestReport.EnableTracingScreenshots=false;
			    if(!error){
            		Report.Info("The Execution finished without elapsed milliseconds greater than "+milliseconds);
			    }
			    else{
			    	Report.LogHtml(Ranorex.ReportLevel.Error, "Execution has greater elapsed times than "+milliseconds+" milliseconds", "<a href='"+destination+"'>"+destination+"</a>");  	
			    }			    	
            }
            
        public static void ThreadProc() {
	        PerformanceCounter myAppCpu = new PerformanceCounter("Process", "% Processor Time", "java", true);
        	PerformanceCounter ramCounter = new PerformanceCounter();
        	ramCounter.CategoryName = "Process";
			ramCounter.CounterName = "Working Set - Private";
			ramCounter.InstanceName = "java";
	        double pc = 0;
	        double ram = 0;
			int time=0;        	
	        while (true)
            {
				time = time +1;
            	pc = pc+myAppCpu.NextValue();
            	ram = ram + ramCounter.NextValue();
                Thread.Sleep(250);
                prom_cpuUsage = pc;
                prom_ramUsage = ram;
	        	time_cpuUsage = time;
            }

    	}
    }

}
 