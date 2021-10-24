using System.Windows.Forms;

namespace ReactWinforms
{
  public class CallbackBridge
  {
    private readonly TextBox m_TextBox;

    public CallbackBridge(TextBox textBox)
    {
      m_TextBox = textBox;
    }

    public async void SetText(string text)
    {
      await ThreadService.MainThread;
      if (m_TextBox != null) {
        m_TextBox.Text = text;
      }
    }
  }
}
