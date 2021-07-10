using System;
using System.IO;

namespace ReactWinforms.JsBridges
{
  public class FileBridge
  {
    public string[] GetDesktopFiles()
    {
      string path = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

      var files = Directory.GetFiles(path);

      return files;
    }
  }
}
