using System.Threading;

namespace ReactWinforms
{
  public class ThreadService
  {
    /// <summary>
    /// Bei Start der Winform-Anwendung registrierter UI-Thread
    /// </summary>
    public static SynchronizationContext MainThread { get; private set; }
    public static void Initialize()
    {
      //MainThread = WindowsFormsSynchronizationContext.Current;
      MainThread = SynchronizationContext.Current;
    }
  }
}
