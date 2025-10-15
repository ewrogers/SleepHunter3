// Decompiled with JetBrains decompiler
// Type: SleepHunterv3.MacroWriter
// Assembly: SleepHunterv3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DFF5A8C7-0B65-4F11-B7C9-8CFDED4A0FFA

using System.IO;

#nullable disable
namespace SleepHunterv3;

public class MacroWriter
{
  public bool SaveData(string[] CommandList, string[] ArgList, string FileTitle, string FileName)
  {
    StreamWriter streamWriter = new StreamWriter(FileName);
    streamWriter.WriteLine(CommandList.Length);
    streamWriter.WriteLine(FileTitle);
    ulong index = 0;
    foreach (string command in CommandList)
    {
      streamWriter.WriteLine($"{command}|{ArgList[index]}");
      ++index;
    }
    streamWriter.Close();
    return true;
  }
}
