using System;

namespace ReactWinforms
{
  public class StringService
  {
    public static string ConvertToTitleCase(string name)
    {
      return Char.ToUpperInvariant(name[0]) + name.Substring(1);
    }

    public static string ConvertToCamelCase(string name)
    {
      return Char.ToLowerInvariant(name[0]) + name.Substring(1);
    }
  }
}
