using System;
using System.IO;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using ReactWinforms.Selfhosting;

namespace ReactWinforms
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      
      SelfhostingServer.Run();

      var settings = new CefSettings() {
        CachePath = Directory.CreateDirectory(
          Path.Combine(Environment.GetFolderPath(
            Environment.SpecialFolder.LocalApplicationData), "CefCache")).FullName
      };
      Cef.EnableHighDPISupport();
      Cef.Initialize(settings);

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainForm());

      SelfhostingServer.ShutDown();
      Cef.Shutdown();
    }
  }
}
