using System;
using System.Windows.Forms;
using ReactWinforms.Selfhosting;

namespace ReactWinforms.JsBridges
{
  public class PropertyBridge
  {
    private readonly TextBox m_TextBox;

    public PropertyBridge(TextBox textBox)
    {
      m_TextBox = textBox;
      m_TextBox.TextChanged += ExecuteTextChanged;
    }

    public event Action<PropertyBridgeEventArg> TextChanged;

    private async void ExecuteTextChanged(object sender, EventArgs e)
    {
      await ThreadService.MainThread;
      TextChanged(new PropertyBridgeEventArg() { Text = m_TextBox.Text });
    }
  }

  public class PropertyBridgeEventArg
  {
    public string Text { get; set; }
  }
}
