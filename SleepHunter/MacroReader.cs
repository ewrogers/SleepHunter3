using System;
using System.IO;
using System.Windows.Forms;

namespace SleepHunter
{
    public class MacroReader
    {
        public string[] GetCommands(string FileName)
        {
            StreamReader streamReader = new StreamReader(FileName);
            ulong result = 0;
            if (!ulong.TryParse(streamReader.ReadLine(), out result))
                return (string[])null;
            streamReader.ReadLine();
            string[] commands = new string[result];
            for (ulong index = 0; index < result; ++index)
                commands[(int)index] = streamReader.ReadLine().Split('|')[0];
            streamReader.Close();
            return commands;
        }

        public string[] GetArguments(string FileName)
        {
            StreamReader streamReader = new StreamReader(FileName);
            ulong result = 0;
            if (!ulong.TryParse(streamReader.ReadLine(), out result))
                return (string[])null;
            streamReader.ReadLine();
            string[] arguments = new string[result];
            for (ulong index = 0; index < result; ++index)
                arguments[(int)index] = streamReader.ReadLine().Split('|')[1];
            streamReader.Close();
            return arguments;
        }

        public string GetFileTitle(string FileName)
        {
            StreamReader streamReader = new StreamReader(FileName);
            ulong result = 0;
            if (!ulong.TryParse(streamReader.ReadLine(), out result))
                return (string)null;
            string fileTitle = streamReader.ReadLine();
            streamReader.Close();
            return fileTitle;
        }

        public int AddCommandsToList(ListView lvwList, string[] CommandList, string[] ArgList)
        {
            CommandLibrary commandLibrary = new CommandLibrary();
            int index = 0;
            foreach (string command in CommandList)
            {
                lvwList.Items.Add("");
                lvwList.Items[index].SubItems.Add(commandLibrary.GetFormattedString(command, ArgList[index].Split(',')));
                lvwList.Items[index].Tag = (object)$"{command}|{ArgList[index]}";
                ++index;
            }
            return index + 1;
        }
    }
}