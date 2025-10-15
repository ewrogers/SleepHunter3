using System.IO;

namespace SleepHunter
{
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
}