using System.Windows.Forms;
using ReactWinforms.JsBridges;
using ReactWinforms.Selfhosting;
using ReactWinforms.WinformControlls;

namespace ReactWinforms
{
  public partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();
      ThreadService.Initialize();

      Text = "React Windows App";

      string url = "file:///index.html";
#if DEBUG
      url = "http://localhost:3000";
#endif
      var tabelLayout = Controls.Find("tableLayoutPanel", true)[0];
      var inputControl = tabelLayout.Controls.Find("inputControl1", true)[0];
      var inputTextBox = inputControl.Controls.Find("inputTextBox", true)[0] as TextBox;
      var outputControl = tabelLayout.Controls.Find("outputControl1", true)[0];
      var outputTextBox = outputControl.Controls.Find("outputTextBox", true)[0] as TextBox;
      var bridges = new object[] { new CallbackBridge(outputTextBox), new PropertyBridge(inputTextBox) };
      if (tabelLayout is TableLayoutPanel tableLayout) {
        tableLayout.Controls.Add(new ReactHost(url, true, bridges, this) {
          Dock = DockStyle.Fill
        });

      }

    }
  }
}
