using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using ReactWinforms.JsBridges;

namespace ReactWinforms.WinformControlls
{
  public partial class ReactHost : UserControl
  {
    private ChromiumWebBrowser m_Browser;
    private bool m_ShowDeveloperConsole;
    private readonly Control parentControl;

    public ReactHost(string url, bool showDeveloperConsole, IEnumerable<object> bridges, Control parentControl)
    {
      InitializeComponent();

      m_ShowDeveloperConsole = showDeveloperConsole;
      this.parentControl = parentControl;
      m_Browser = new ChromiumWebBrowser("") {
        Dock = DockStyle.Fill
      };

 

      m_Browser.JavascriptObjectRepository.Settings.LegacyBindingEnabled = true;
      m_Browser.JavascriptObjectRepository.Register("bridgeMediator", new BridgeMediator(m_Browser, bridges), true, BindingOptions.DefaultBinder);

      //m_Browser.IsBrowserInitializedChanged += IsBrowserInitializedChanged;


      this.Load += ReactHost_Load;
      this.Controls.Add(m_Browser);

      m_Browser.Load(url);
    }

    private void IsBrowserInitializedChanged(object sender, EventArgs e)
    {
      if (m_ShowDeveloperConsole) {
        m_Browser.ShowDevToolsDocked(parentControl);
      }
    }



    private void ReactHost_Load(object sender, EventArgs e)
    {

    }
  }
}
