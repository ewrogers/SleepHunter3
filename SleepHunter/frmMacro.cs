using ProcessMemory;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SleepHunter
{

    public partial class frmMacro : Form
    {
        public LogicStructure.LogicItem[] LogicData;
        public LogicStructure.LoopData[] LoopData;
        public MemoryReader memRead;
        public int LinePointer;
        public Hotkey hotkey;
        public static ClipboardData m_ClipboardData;
        public static Point SavedCursorPos;
        public EndMacroReason MacroEndReason;
        public bool MacroRunning;
        public bool MacroPaused;

        public frmMacro() => InitializeComponent();

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
                Text = "Macro Data";
            else
                Text = txtName.Text + " - Macro Data";
            frmMain mdiParent = (frmMain)MdiParent;
        }

        public void AddCommand(string cmdData)
        {
            string str1 = cmdData;
            if (str1 == null)
                return;
            string[] strArray = str1.Split('|');
            string ArgCode = strArray[1];
            CommandLibrary commandLibrary = new CommandLibrary();
            string argumentHelp = commandLibrary.GetArgumentHelp(ArgCode);
            frmArgs frmArgs = new frmArgs(strArray[0], argumentHelp);
            frmArgs.MinArgCount = commandLibrary.GetArgumentCount(ArgCode);
            if (argumentHelp != null)
            {
                int num = (int)frmArgs.ShowDialog(this);
            }

            if (!frmArgs.CancelSelected)
            {
                string str2 = null;
                if (frmArgs.ArgInput != null)
                    str2 = ArrayToString(frmArgs.ArgInput);
                if (lvwMacro.SelectedIndices.Count < 1)
                {
                    int count = lvwMacro.Items.Count;
                    lvwMacro.Items.Add("");
                    lvwMacro.Items[count].SubItems.Add(commandLibrary.GetFormattedString(ArgCode, frmArgs.ArgInput));
                    lvwMacro.Items[count].Tag = $"{ArgCode}|{str2}";
                }
                else
                {
                    int index = lvwMacro.SelectedIndices[lvwMacro.SelectedIndices.Count - 1] + 1;
                    lvwMacro.Items.Insert(index, "");
                    lvwMacro.Items[index].SubItems.Add(commandLibrary.GetFormattedString(ArgCode, frmArgs.ArgInput));
                    lvwMacro.Items[index].Tag = $"{ArgCode}|{str2}";
                }
            }

            ClearNullEntries();
            ReNumberLines();
            IndentLines();
        }

        private void lvwMacro_DragDrop(object sender, DragEventArgs e)
        {
            string data = (string)e.Data.GetData(DataFormats.Text, true);
            AddCommand(data);
            uint result = 0;
            if (!uint.TryParse(data, out result))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void lvwMacro_DragEnter(object sender, DragEventArgs e)
        {
            uint result = 0;
            if (!uint.TryParse((string)e.Data.GetData(DataFormats.Text, true), out result))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void splHeader_Panel1_DragEnter(object sender, DragEventArgs e)
        {
            uint result = 0;
            if (!uint.TryParse((string)e.Data.GetData(DataFormats.Text), out result))
                e.Effect = DragDropEffects.None;
            else
                e.Effect = DragDropEffects.Copy;
        }

        private void splHeader_Panel1_DragDrop(object sender, DragEventArgs e)
        {
            uint result = 0;
            if (!uint.TryParse((string)e.Data.GetData(DataFormats.Text), out result))
            {
                e.Effect = DragDropEffects.None;
            }
            else
            {
                memRead = new MemoryReader(result);
                lblProcessName.Text = "Process Name: " + memRead.ProcessName;
                lblProcessID.Text = "Process ID: " + memRead.ProcessID;
                lblWindowHandle.Text = "Window Handle: " + memRead.WindowHandle;
                lblCharName.Text = "Character Name: " + memRead.ReadString((IntPtr)6585504);
            }
        }

        private void splMacroData_Panel2_Paint(object sender, PaintEventArgs e)
        {
            Rectangle clientRectangle = splMacroData.Panel2.ClientRectangle;
            clientRectangle.Inflate(-4, -4);
            clientRectangle.Height += 4;
            clientRectangle.Offset(0, -4);
            e.Graphics.DrawRectangle(new Pen(SystemColors.ControlDark), clientRectangle);
        }

        private void mnuLogic_Click(object sender, EventArgs e)
        {
            try
            {
                LogicStructure logicStructure = new LogicStructure();
                string[] CommandList = new string[lvwMacro.Items.Count];
                string[] Args = new string[lvwMacro.Items.Count];
                int index = 0;
                foreach (ListViewItem listViewItem in lvwMacro.Items)
                {
                    string[] strArray = listViewItem.Tag.ToString().Split(new char[1]
                    {
                        '|'
                    }, 2);
                    CommandList[index] = strArray[0];
                    Args[index] = strArray[1];
                    ++index;
                }

                frmLogicSkel frmLogicSkel = new frmLogicSkel();
                frmLogicSkel.MdiParent = MdiParent;
                LogicData = logicStructure.CreateLogicStructure(CommandList, Args);
                if (LogicData == null)
                {
                    int num1 = (int)MessageBox.Show(this,
                        "No logic commands present, cannot generate skeleton structure.", "Invalid Parameters",
                        MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    int num2 = 0;
                    foreach (LogicStructure.LogicItem logicItem in LogicData)
                    {
                        RichTextBox rtbStruct1 = frmLogicSkel.rtbStruct;
                        string[] strArray1 = new string[6]
                        {
                            rtbStruct1.Text,
                            "[Logic Structure ",
                            null,
                            null,
                            null,
                            null
                        };
                        string[] strArray2 = strArray1;
                        int num3 = num2 + 1;
                        string str1 = num3.ToString();
                        strArray2[2] = str1;
                        strArray1[3] = " of ";
                        string[] strArray3 = strArray1;
                        num3 = LogicData.Length;
                        string str2 = num3.ToString();
                        strArray3[4] = str2;
                        strArray1[5] = "]";
                        rtbStruct1.Text = string.Concat(strArray1);
                        RichTextBox rtbStruct2 = frmLogicSkel.rtbStruct;
                        rtbStruct2.Text =
                            $"{rtbStruct2.Text}{Environment.NewLine}---------------------------{Environment.NewLine}";
                        RichTextBox rtbStruct3 = frmLogicSkel.rtbStruct;
                        rtbStruct3.Text =
                            $"{rtbStruct3.Text}TYPE:\t\t{logicItem.CommandType.ToString()}{Environment.NewLine}";
                        RichTextBox rtbStruct4 = frmLogicSkel.rtbStruct;
                        rtbStruct4.Text =
                            $"{rtbStruct4.Text}COMPARE:\t{logicItem.CompareType.ToString()}{Environment.NewLine}";
                        RichTextBox rtbStruct5 = frmLogicSkel.rtbStruct;
                        rtbStruct5.Text =
                            $"{rtbStruct5.Text}CRITERIA:\t{logicItem.CriteriaType.ToString()}{Environment.NewLine}";
                        RichTextBox rtbStruct6 = frmLogicSkel.rtbStruct;
                        rtbStruct6.Text =
                            $"{rtbStruct6.Text}VALUE:\t\t{logicItem.Value.ToString()}{Environment.NewLine}";
                        RichTextBox rtbStruct7 = frmLogicSkel.rtbStruct;
                        string text1 = rtbStruct7.Text;
                        num3 = logicItem.StartLine;
                        string str3 = num3.ToString();
                        string newLine1 = Environment.NewLine;
                        rtbStruct7.Text = $"{text1}START:\t\tLine {str3}{newLine1}";
                        RichTextBox rtbStruct8 = frmLogicSkel.rtbStruct;
                        string text2 = rtbStruct8.Text;
                        num3 = logicItem.ElseLine;
                        string str4 = num3.ToString();
                        string newLine2 = Environment.NewLine;
                        rtbStruct8.Text = $"{text2}ELSE:\t\tLine {str4}{newLine2}";
                        RichTextBox rtbStruct9 = frmLogicSkel.rtbStruct;
                        string text3 = rtbStruct9.Text;
                        num3 = logicItem.EndLine;
                        string str5 = num3.ToString();
                        string newLine3 = Environment.NewLine;
                        rtbStruct9.Text = $"{text3}END:\t\tLine {str5}{newLine3}";
                        RichTextBox rtbStruct10 = frmLogicSkel.rtbStruct;
                        rtbStruct10.Text =
                            $"{rtbStruct10.Text}Has Else:\t{logicItem.HasElse.ToString()}{Environment.NewLine}";
                        RichTextBox rtbStruct11 = frmLogicSkel.rtbStruct;
                        rtbStruct11.Text =
                            $"{rtbStruct11.Text}Was Handled:\t{logicItem.Handled.ToString()}{Environment.NewLine}{Environment.NewLine}";
                        ++num2;
                    }

                    frmLogicSkel.Show();
                }
            }
            catch (IndexOutOfRangeException)
            {
                int num = (int)MessageBox.Show(this,
                    "No logic commands present or malformed macro detected, cannot generate skeleton structure.",
                    "Invalid Parameters", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private string ArrayToString(Array baseArray)
        {
            string str = "";
            for (int index = 0; index < baseArray.Length; ++index)
            {
                if (index != 0)
                    str += ",";
                str += baseArray.GetValue(index).ToString();
            }

            return str;
        }

        public int ReNumberLines()
        {
            int num = 1;
            foreach (ListViewItem listViewItem in lvwMacro.Items)
            {
                listViewItem.SubItems[0].Text = num.ToString().PadLeft(4, '0');
                ++num;
            }

            return num;
        }

        public int ClearNullEntries()
        {
            int num = 0;
            foreach (ListViewItem listViewItem in lvwMacro.Items)
            {
                if (listViewItem.Tag == null | listViewItem.SubItems.Count < 2)
                {
                    listViewItem.Remove();
                    ++num;
                }
            }

            return num;
        }

        public void IndentLines()
        {
            LogicStructure logicStructure = new LogicStructure();
            int num1 = 0;
            foreach (ListViewItem listViewItem in lvwMacro.Items)
            {
                if (listViewItem.SubItems.Count > 1)
                    listViewItem.SubItems[1].Text = listViewItem.SubItems[1].Text.Trim();
            }

            foreach (ListViewItem listViewItem in lvwMacro.Items)
            {
                string ArgCode = "";
                if (listViewItem.Tag != null)
                    ArgCode = listViewItem.Tag.ToString().Split('|')[0];
                if (logicStructure.IsAnEndCommand(ArgCode))
                {
                    --num1;
                    if (num1 < 0)
                        num1 = 0;
                }

                string str;
                if (logicStructure.IsAnElseCommand(ArgCode))
                {
                    int num2 = num1 - 1;
                    if (num2 < 0)
                        num2 = 0;
                    str = new string(' ', num2 * 4);
                    num1 = num2 + 1;
                }
                else
                    str = new string(' ', num1 * 4);

                if (logicStructure.IsAStartLogicCommand(ArgCode))
                    ++num1;
                if (listViewItem.SubItems.Count > 1)
                    listViewItem.SubItems[1].Text = str + listViewItem.SubItems[1].Text;
            }
        }

        private int GetSingleSel(ListView lvwList, bool First)
        {
            if (lvwList.MultiSelect)
            {
                ListView.SelectedIndexCollection selectedIndices = lvwList.SelectedIndices;
                if (selectedIndices.Count <= 0)
                    return -1;
                return First ? selectedIndices[0] : selectedIndices[selectedIndices.Count - 1];
            }

            ListView.SelectedIndexCollection selectedIndices1 = lvwList.SelectedIndices;
            return selectedIndices1.Count > 0 ? selectedIndices1[0] : -1;
        }

        private string GetTagData(object Tag, bool GetCommand)
        {
            string[] strArray = Tag.ToString().Split('|');
            return GetCommand ? strArray[0] : strArray[1];
        }

        public int MakeDWord(short LoWord, short HiWord)
        {
            return HiWord * 65536 /*0x010000*/ | LoWord & ushort.MaxValue;
        }

        private void CopyToClipboard(bool EraseData)
        {
            ListView.SelectedListViewItemCollection selectedItems = lvwMacro.SelectedItems;
            int num = -1;
            bool flag = true;
            foreach (ListViewItem listViewItem in selectedItems)
            {
                if (num < 0)
                    num = listViewItem.Index;
                if (Math.Abs(listViewItem.Index - num) > 1)
                    flag = false;
                num = listViewItem.Index;
            }

            if (!flag)
                ((frmMain)MdiParent).nidIcon.ShowBalloonTip(2500, "Clipboard Data Warning",
                    $"The macro command lines you have copied to the clipboard are not in immediate succession.{Environment.NewLine}{Environment.NewLine}Please note that when you paste these lines from the clipboard, they will be placed in immediate succession based on the order of the selected items.",
                    ToolTipIcon.Warning);
            string[] strArray1 = new string[selectedItems.Count];
            string[] strArray2 = new string[selectedItems.Count];
            int index = 0;
            foreach (ListViewItem listViewItem in selectedItems)
            {
                string[] strArray3 = listViewItem.Tag.ToString().Split('|');
                strArray1[index] = strArray3[0];
                strArray2[index] = strArray3[1];
                ++index;
            }

            m_ClipboardData.CommandData = strArray1;
            m_ClipboardData.ArgData = strArray2;
            if (EraseData)
            {
                foreach (ListViewItem listViewItem in selectedItems)
                {
                    listViewItem.Selected = false;
                    listViewItem.Remove();
                }
            }

            ClearNullEntries();
            ReNumberLines();
            IndentLines();
        }

        private void SwapLines(int LineA, int LineB)
        {
            string str1 = lvwMacro.Items[LineA].Tag.ToString();
            string str2 = lvwMacro.Items[LineB].Tag.ToString();
            string str3 = str1;
            string str4 = str2;
            string str5 = str3;
            lvwMacro.Items[LineA].Tag = str4;
            lvwMacro.Items[LineB].Tag = str5;
            ClearNullEntries();
            ReNumberLines();
            IndentLines();
        }

        public string GetLineCommand(int LineNo)
        {
            if (LineNo - 1 > lvwMacro.Items.Count - 1)
                return null;
            return lvwMacro.Items[LineNo - 1].Tag.ToString().Split('|')[0];
        }

        public string GetLineArgs(int LineNo)
        {
            if (LineNo - 1 > lvwMacro.Items.Count - 1)
                return null;
            return lvwMacro.Items[LineNo - 1].Tag.ToString().Split('|')[1];
        }

        private void frmMacro_Activated(object sender, EventArgs e)
        {
            ((frmMain)MdiParent).ActiveMacro = this;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (MacroRunning)
                ((frmMain)MdiParent).nidIcon.ShowBalloonTip(2500, "Edit at Runtime Warning",
                    $"You have attempted to edit a command at runtime.{Environment.NewLine}{Environment.NewLine}While this is allowed, it is suggested you stop the macro before editing to prevent any undesired actions.",
                    ToolTipIcon.Warning);
            int singleSel = GetSingleSel(lvwMacro, true);
            if (singleSel < 0)
                return;
            string tagData = GetTagData(lvwMacro.Items[singleSel].Tag, true);
            CommandLibrary commandLibrary = new CommandLibrary();
            string argumentHelp = commandLibrary.GetArgumentHelp(tagData);
            frmArgs frmArgs = new frmArgs(commandLibrary.GetCommandName(tagData), argumentHelp);
            frmArgs.MinArgCount = commandLibrary.GetArgumentCount(tagData);
            if (argumentHelp != null)
            {
                frmArgs.cmdAdd.Text = "Edit Command";
                int num = (int)frmArgs.ShowDialog(this);
            }

            if (!frmArgs.CancelSelected & argumentHelp != null)
            {
                string str = null;
                if (frmArgs.ArgInput != null)
                    str = ArrayToString(frmArgs.ArgInput);
                lvwMacro.Items[singleSel].Tag = $"{tagData}|{str}";
                lvwMacro.Items[singleSel].SubItems[1].Text = commandLibrary.GetFormattedString(tagData, str.Split(','));
            }

            ClearNullEntries();
            ReNumberLines();
            IndentLines();
        }

        public void PlayButton()
        {
            if (MacroPaused)
            {
                MacroPaused = false;
                btnPlay.Enabled = false;
            }
            else
            {
                btnPlay.Enabled = false;
                MacroRunning = true;
                MacroPaused = false;
                if (lvwMacro.Items.Count < 1)
                {
                    int num = (int)MessageBox.Show("No commands found to execute, macro will not run.", "Empty Macro",
                        MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    btnPlay.Enabled = true;
                    MacroRunning = false;
                }
                else if (memRead == null)
                {
                    int num = (int)MessageBox.Show("No process attached, macro will not run.", "No Target Process",
                        MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    btnPlay.Enabled = true;
                    MacroRunning = false;
                }
                else if (memRead.ProcessID <= 0U)
                {
                    int num = (int)MessageBox.Show("No process attached, macro will not run.", "No Target Process",
                        MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    btnPlay.Enabled = true;
                }
                else if (!memRead.IsRunning)
                {
                    int num = (int)MessageBox.Show("The target process could not be located, please re-attach.",
                        "Invalid Target Process", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    btnPlay.Enabled = true;
                }
                else
                {
                    int map1 = (int)GetMAP(memRead);
                    if (map1 == 509 | map1 == 5335)
                    {
                        int num = (int)MessageBox.Show(
                            "In order to keep the arena fair for everyone, macros cannot be activated in the arena.",
                            "Arena Macros Disabled", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        LogicStructure logicStructure = new LogicStructure();
                        lblStatus.Text = "Generating Logic Structure...";
                        lblStatus.Image = ilsStatusIcons.Images[3];
                        string[] CommandList = new string[lvwMacro.Items.Count];
                        string[] Args = new string[lvwMacro.Items.Count];
                        int index1 = 0;
                        foreach (ListViewItem listViewItem in lvwMacro.Items)
                        {
                            string[] strArray = listViewItem.Tag.ToString().Split(new char[1]
                            {
                                '|'
                            }, 2);
                            CommandList[index1] = strArray[0];
                            Args[index1] = strArray[1];
                            ++index1;
                        }

                        LogicData = logicStructure.CreateLogicStructure(CommandList, Args);
                        LinePointer = 1;
                        int length = 0;
                        if (LogicData != null)
                        {
                            foreach (LogicStructure.LogicItem logicItem in LogicData)
                            {
                                if (logicItem.CommandType == LogicStructure.LogicCommandType.LoopStatement)
                                    ++length;
                            }
                        }

                        LoopData = null;
                        int index2 = 0;
                        if (length > 0)
                        {
                            LoopData = new LogicStructure.LoopData[length];
                            for (int LineNo = 1; LineNo <= lvwMacro.Items.Count; ++LineNo)
                            {
                                string lineCommand = GetLineCommand(LineNo);
                                string lineArgs = GetLineArgs(LineNo);
                                if (logicStructure.GetLogicType(lineCommand) ==
                                    LogicStructure.LogicCommandType.LoopStatement &
                                    logicStructure.IsAStartLogicCommand(lineCommand))
                                {
                                    LoopData[index2].LineNo = LineNo;
                                    LoopData[index2].LoopCounter = 0UL;
                                    ulong result;
                                    ulong.TryParse(lineArgs.Split(',')[0], out result);
                                    LoopData[index2].LoopMax = result;
                                    ++index2;
                                }
                            }
                        }

                        while (MacroRunning & !IsDisposed)
                        {
                            if (!MacroPaused & MacroRunning)
                            {
                                lblStatus.Text = "Macro is running...";
                                lblStatus.Image = ilsStatusIcons.Images[0];
                                btnPause.Enabled = true;
                                btnStop.Enabled = true;
                                string lineCommand = GetLineCommand(LinePointer);
                                string lineArgs = GetLineArgs(LinePointer);
                                if (memRead != null)
                                {
                                    if (memRead.ProcessID == 0U | memRead.WindowHandle == 0UL)
                                    {
                                        MacroEndReason = EndMacroReason.BadProcessInfo;
                                        break;
                                    }

                                    int map2 = (int)GetMAP(memRead);
                                    if (map2 == 509 | map2 == 5235)
                                    {
                                        MacroEndReason = EndMacroReason.ArenaMap;
                                        break;
                                    }

                                    LinePointer = ExecuteCommand(lineCommand, lineArgs, LinePointer);
                                    if (LinePointer > lvwMacro.Items.Count)
                                    {
                                        MacroEndReason = EndMacroReason.EndOfMacroReached;
                                        break;
                                    }
                                }
                                else
                                {
                                    MacroEndReason = EndMacroReason.NotAttached;
                                    break;
                                }
                            }
                            else
                            {
                                lblStatus.Text = "Macro is paused!";
                                lblStatus.Image = ilsStatusIcons.Images[1];
                                btnPause.Enabled = false;
                                btnPlay.Enabled = true;
                            }

                            Application.DoEvents();
                        }

                        if (MacroEndReason == EndMacroReason.ArenaMap)
                            ((frmMain)MdiParent).nidIcon.ShowBalloonTip(5000, "Entering an Arena Map",
                                $"You have entered an arena map while your macro was running.{Environment.NewLine}{Environment.NewLine}The macro will be stopped in order to ensure the fairness of the arena gameplay.",
                                ToolTipIcon.Warning);
                        if (IsDisposed)
                            return;
                        btnPause.Enabled = false;
                        btnStop.Enabled = false;
                        btnPlay.Enabled = true;
                        MacroRunning = false;
                        lblStatus.Text = "Macro is not running.";
                        lblStatus.Image = ilsStatusIcons.Images[2];
                    }
                }
            }
        }

        public void StopButton()
        {
            btnPause.Enabled = false;
            btnStop.Enabled = false;
            lblStatus.Text = "Macro is stopping...Please Wait.";
            lblStatus.Image = ilsStatusIcons.Images[3];
            MacroRunning = false;
            MacroPaused = false;
        }

        public void PauseButton() => MacroPaused = true;

        private void btnPlay_Click(object sender, EventArgs e) => PlayButton();

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = lvwMacro.SelectedItems;
            if (selectedItems.Count < 1)
                return;
            foreach (ListViewItem listViewItem in selectedItems)
            {
                listViewItem.Selected = false;
                lvwMacro.Items.Remove(listViewItem);
            }

            ClearNullEntries();
            ReNumberLines();
            IndentLines();
        }

        private void btnCut_Click(object sender, EventArgs e) => CopyToClipboard(true);

        private void btnCopy_Click(object sender, EventArgs e) => CopyToClipboard(false);

        private void btnPaste_Click(object sender, EventArgs e)
        {
            ClipboardData clipboardData = m_ClipboardData;
            if (clipboardData.CommandData == null | clipboardData.ArgData == null)
                return;
            int index1 = GetSingleSel(lvwMacro, false) + 1;
            int index2 = 0;
            bool flag = false;
            if (index1 > lvwMacro.Items.Count - 1)
                flag = true;
            if (index1 < 0)
                flag = true;
            CommandLibrary commandLibrary = new CommandLibrary();
            foreach (string str in clipboardData.CommandData)
            {
                if (flag)
                {
                    lvwMacro.Items.Add("");
                    index1 = lvwMacro.Items.Count - 1;
                }
                else
                    lvwMacro.Items.Insert(index1, "");

                lvwMacro.Items[index1].Tag = $"{clipboardData.CommandData[index2]}|{clipboardData.ArgData[index2]}";
                lvwMacro.Items[index1].SubItems.Add(commandLibrary.GetFormattedString(clipboardData.CommandData[index2],
                    clipboardData.ArgData[index2].Split(',')));
                ++index2;
                ++index1;
            }

            ClearNullEntries();
            ReNumberLines();
            IndentLines();
        }

        private void frmMacro_Shown(object sender, EventArgs e) => txtName.Focus();

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection selectedIndices = lvwMacro.SelectedIndices;
            if (selectedIndices.Count < 1)
                return;
            CommandLibrary commandLibrary = new CommandLibrary();
            foreach (int num in selectedIndices)
            {
                if (num >= 1)
                {
                    SwapLines(num, num - 1);
                    lvwMacro.Items[num].SubItems[1].Text = commandLibrary.GetFormattedString(
                        lvwMacro.Items[num].Tag.ToString().Split('|')[0],
                        lvwMacro.Items[num].Tag.ToString().Split('|')[1].Split(','));
                    lvwMacro.Items[num - 1].SubItems[1].Text = commandLibrary.GetFormattedString(
                        lvwMacro.Items[num - 1].Tag.ToString().Split('|')[0],
                        lvwMacro.Items[num - 1].Tag.ToString().Split('|')[1].Split(','));
                    lvwMacro.Items[num].Selected = false;
                    lvwMacro.Items[num - 1].Selected = true;
                }
                else
                    break;
            }

            ClearNullEntries();
            ReNumberLines();
            IndentLines();
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection selectedIndices = lvwMacro.SelectedIndices;
            Array array = new int[selectedIndices.Count];
            selectedIndices.CopyTo(array, 0);
            Array.Reverse(array);
            if (selectedIndices.Count < 1)
                return;
            CommandLibrary commandLibrary = new CommandLibrary();
            foreach (int num in array)
            {
                if (num + 1 <= lvwMacro.Items.Count - 1)
                {
                    SwapLines(num, num + 1);
                    lvwMacro.Items[num].SubItems[1].Text = commandLibrary.GetFormattedString(
                        lvwMacro.Items[num].Tag.ToString().Split('|')[0],
                        lvwMacro.Items[num].Tag.ToString().Split('|')[1].Split(','));
                    lvwMacro.Items[num + 1].SubItems[1].Text = commandLibrary.GetFormattedString(
                        lvwMacro.Items[num + 1].Tag.ToString().Split('|')[0],
                        lvwMacro.Items[num + 1].Tag.ToString().Split('|')[1].Split(','));
                    lvwMacro.Items[num].Selected = false;
                    lvwMacro.Items[num + 1].Selected = true;
                }
                else
                    break;
            }

            ClearNullEntries();
            ReNumberLines();
            IndentLines();
        }

        private void tmrProcess_Tick(object sender, EventArgs e)
        {
            if (memRead == null || memRead.IsRunning)
                return;
            frmMain mdiParent = (frmMain)MdiParent;
            mdiParent.nidIcon.ShowBalloonTip(2500, "Invalid Process Reference",
                $"The process, {lblProcessName.Text}, is either no longer running or could not be found running.{Environment.NewLine}{Environment.NewLine}All macros attached to this process will be detached and their macros stopped, if running.",
                ToolTipIcon.Error);
            mdiParent.DetachByPID(memRead.ProcessID);
        }

        private int ExecuteCommand(string Command, string Args, int LineNo)
        {
            LogicStructure logicStructure = new LogicStructure();
            if (Command.StartsWith("LO_IF"))
            {
                int logicStartRef = logicStructure.GetLogicStartRef(LogicData, LineNo);
                if (logicStartRef < 0 || EvaluateCriteria(LogicData, LineNo, true))
                    return LineNo + 1;
                return LogicData[logicStartRef].HasElse
                    ? LogicData[logicStartRef].ElseLine + 1
                    : LogicData[logicStartRef].EndLine + 1;
            }

            if (Command.StartsWith("LO_WHILE"))
            {
                int logicStartRef = logicStructure.GetLogicStartRef(LogicData, LineNo);
                if (logicStartRef >= 0)
                    return EvaluateCriteria(LogicData, LineNo, true)
                        ? LineNo + 1
                        : LogicData[logicStartRef].EndLine + 1;
            }

            switch (Command.ToUpper())
            {
                case "GS_STATUS":
                    User32.PostMessage((IntPtr)(long)memRead.WindowHandle, 256U /*0x0100*/, (UIntPtr)71U,
                        (UIntPtr)2228225U);
                    return LineNo + 1;
                case "GS_CHAT":
                    User32.PostMessage((IntPtr)(long)memRead.WindowHandle, 256U /*0x0100*/, (UIntPtr)70U,
                        (UIntPtr)2162689U);
                    return LineNo + 1;
                case "GS_INVENTORY":
                    User32.PostMessage((IntPtr)(long)memRead.WindowHandle, 256U /*0x0100*/, (UIntPtr)65U,
                        (UIntPtr)1966081U);
                    return LineNo + 1;
                case "GS_MEDSKILL":
                    ShiftMessage(true);
                    User32.PostMessage((IntPtr)(long)memRead.WindowHandle, 256U /*0x0100*/, (UIntPtr)83U,
                        (UIntPtr)2031617U);
                    ShiftMessage(false);
                    return LineNo + 1;
                case "GS_MEDSPELL":
                    ShiftMessage(true);
                    User32.PostMessage((IntPtr)(long)memRead.WindowHandle, 256U /*0x0100*/, (UIntPtr)68U,
                        (UIntPtr)2097153U /*0x200001*/);
                    ShiftMessage(false);
                    return LineNo + 1;
                case "GS_TEMSKILL":
                    User32.PostMessage((IntPtr)(long)memRead.WindowHandle, 256U /*0x0100*/, (UIntPtr)83U,
                        (UIntPtr)2031617U);
                    return LineNo + 1;
                case "GS_TEMSPELL":
                    User32.PostMessage((IntPtr)(long)memRead.WindowHandle, 256U /*0x0100*/, (UIntPtr)68U,
                        (UIntPtr)2097153U /*0x200001*/);
                    return LineNo + 1;
                case "KB_SENDKEYS":
                    string str1 = Args.Split(',')[0];
                    if (str1.Trim() != "")
                    {
                        string str2 = str1;
                        int length = 0;
                        while (str2.Length > 0)
                        {
                            char ch = str2[0];
                            if (ch != '<' & ch != '>')
                            {
                                ++length;
                                str2 = str2.Remove(0, 1);
                            }
                            else if (ch == '<')
                            {
                                int num = str2.IndexOf('>');
                                if (num > 0)
                                {
                                    ++length;
                                    str2 = str2.Remove(0, num + 1);
                                }
                            }
                        }

                        KeystrokeItem[] keystrokeItemArray = new KeystrokeItem[length];
                        string str3 = str1;
                        int index = 0;
                        while (str3.Length > 0)
                        {
                            char ch = str3[0];
                            if (ch != '<' & ch != '>')
                            {
                                keystrokeItemArray[index].Keystroke = str3.Substring(0, 1);
                                keystrokeItemArray[index].IsSpecialChar = false;
                                ++index;
                                str3 = str3.Remove(0, 1);
                            }
                            else if (ch == '<')
                            {
                                int num = str3.IndexOf('>');
                                if (num > 1)
                                {
                                    keystrokeItemArray[index].Keystroke = str3.Substring(1, num - 1);
                                    keystrokeItemArray[index].IsSpecialChar = true;
                                    ++index;
                                    str3 = str3.Remove(0, num + 1);
                                }
                            }
                        }

                        uint num1 = 0;
                        foreach (KeystrokeItem keystrokeItem in keystrokeItemArray)
                        {
                            if (!keystrokeItem.IsSpecialChar)
                            {
                                short num2 = Encoding.ASCII.GetBytes(keystrokeItem.Keystroke.ToUpper())[0];
                                User32.PostMessage((IntPtr)(long)memRead.WindowHandle, 256U /*0x0100*/,
                                    (UIntPtr)(ulong)num2,
                                    (UIntPtr)(ulong)MakeDWord(0,
                                        (short)User32.MapVirtualKey((uint)num2, 0U)));
                            }
                            else
                            {
                                short num3;
                                switch (keystrokeItem.Keystroke.ToUpper())
                                {
                                    case "UP":
                                        num3 = (short)38;
                                        num1 = 16777217U /*0x01000001*/;
                                        break;
                                    case "DOWN":
                                        num3 = (short)40;
                                        num1 = 16777217U /*0x01000001*/;
                                        break;
                                    case "LEFT":
                                        num3 = (short)37;
                                        num1 = 16777217U /*0x01000001*/;
                                        break;
                                    case "RIGHT":
                                        num3 = (short)39;
                                        num1 = 16777217U /*0x01000001*/;
                                        break;
                                    case "ENTER":
                                        num3 = (short)13;
                                        break;
                                    case "ESC":
                                        num3 = (short)27;
                                        break;
                                    case "F5":
                                        num3 = (short)116;
                                        break;
                                    case "SPACE":
                                        num3 = (short)32 /*0x20*/;
                                        break;
                                    default:
                                        num3 = short.MaxValue;
                                        break;
                                }

                                if (num3 != -1 & num3 != short.MaxValue)
                                {
                                    var lParam =
                                        (UIntPtr)((ulong)MakeDWord(0, (short)User32.MapVirtualKey((uint)num3, 0U)) |
                                                  num1);
                                    User32.PostMessage((IntPtr)(long)memRead.WindowHandle, 256U /*0x0100*/,
                                        (UIntPtr)(ulong)num3, lParam);
                                }
                            }
                        }
                    }

                    return LineNo + 1;
                case "LO_BREAK":
                    int withinRef = logicStructure.GetWithinRef(lvwMacro.Items.Count, LogicData, LineNo);
                    return withinRef >= 0 ? LogicData[withinRef].EndLine + 1 : LineNo + 1;
                case "LO_ELSE":
                    int logicElseRef = logicStructure.GetLogicElseRef(LogicData, LineNo);
                    return logicElseRef >= 0 ? LogicData[logicElseRef].EndLine : LineNo + 1;
                case "LO_ENDIF":
                    return LineNo + 1;
                case "LO_ENDWHILE":
                    int logicEndRef = logicStructure.GetLogicEndRef(LogicData, LineNo);
                    return logicEndRef >= 0 && EvaluateCriteria(LogicData, LineNo, false)
                        ? LogicData[logicEndRef].StartLine + 1
                        : LineNo + 1;
                case "LP_BREAK":
                    int withinLoopRef1 = logicStructure.GetWithinLoopRef(lvwMacro.Items.Count, LogicData, LineNo);
                    return withinLoopRef1 >= 0 ? LogicData[withinLoopRef1].EndLine + 1 : LineNo + 1;
                case "LP_GOTO":
                    int result1;
                    return int.TryParse(Args.Split(',')[0], out result1) ? result1 : LineNo + 1;
                case "LP_END":
                    int loopRefByEnd = logicStructure.GetLoopRefByEnd(LogicData, LineNo);
                    if (loopRefByEnd < 0)
                        return LineNo + 1;
                    int startLine1 = LogicData[loopRefByEnd].StartLine;
                    int loopDataRef1 = logicStructure.GetLoopDataRef(LoopData, startLine1);
                    if (loopDataRef1 < 0)
                        return LineNo + 1;
                    ++LoopData[loopDataRef1].LoopCounter;
                    return LoopData[loopDataRef1].LoopCounter >= LoopData[loopDataRef1].LoopMax &
                           LoopData[loopDataRef1].LoopMax != 0UL
                        ? LogicData[loopRefByEnd].EndLine + 1
                        : LogicData[loopRefByEnd].StartLine;
                case "LP_RESET":
                    int withinLoopRef2 = logicStructure.GetWithinLoopRef(lvwMacro.Items.Count, LogicData, LineNo);
                    if (withinLoopRef2 < 0)
                        return LineNo + 1;
                    int startLine2 = LogicData[withinLoopRef2].StartLine;
                    int loopDataRef2 = logicStructure.GetLoopDataRef(LoopData, startLine2);
                    if (loopDataRef2 < 0)
                        return LineNo + 1;
                    LoopData[loopDataRef2].LoopCounter = 0UL;
                    return LineNo + 1;
                case "LP_RESTART":
                    int withinLoopRef3 = logicStructure.GetWithinLoopRef(lvwMacro.Items.Count, LogicData, LineNo);
                    if (withinLoopRef3 < 0)
                        return LineNo + 1;
                    int startLine3 = LogicData[withinLoopRef3].StartLine;
                    int loopDataRef3 = logicStructure.GetLoopDataRef(LoopData, startLine3);
                    return loopDataRef3 >= 0 ? LoopData[loopDataRef3].LineNo + 1 : LineNo + 1;
                case "LP_START":
                    return LineNo + 1;
                case "MO_LEFTCLICK":
                    int lParam1 = MakeDWord(0, 0);
                    User32.PostMessage((IntPtr)(long)memRead.WindowHandle, 513U, (UIntPtr)1UL, (UIntPtr)(ulong)lParam1);
                    User32.PostMessage((IntPtr)(long)memRead.WindowHandle, 514U, (UIntPtr)0U, (UIntPtr)(ulong)lParam1);
                    return LineNo + 1;
                case "MO_MOVE":
                    short result2 = 0;
                    short result3 = 0;
                    short.TryParse(Args.Split(',')[0], out result2);
                    short.TryParse(Args.Split(',')[1], out result3);
                    User32.PostMessage((IntPtr)(long)memRead.WindowHandle, 512U /*0x0200*/, (UIntPtr)0U,
                        (UIntPtr)(ulong)MakeDWord(result2, result3));
                    return LineNo + 1;
                case "MO_RECALL":
                    Point savedCursorPos = SavedCursorPos;
                    User32.PostMessage((IntPtr)(long)memRead.WindowHandle, 512U /*0x0200*/, (UIntPtr)0U,
                        (UIntPtr)(ulong)MakeDWord((short)SavedCursorPos.X, (short)SavedCursorPos.Y));
                    return LineNo + 1;
                case "MO_RIGHTCLICK":
                    int lParam2 = MakeDWord(0, 0);
                    User32.PostMessage((IntPtr)(long)memRead.WindowHandle, 516U, (UIntPtr)2UL, (UIntPtr)(ulong)lParam2);
                    User32.PostMessage((IntPtr)(long)memRead.WindowHandle, 517U, (UIntPtr)0U, (UIntPtr)(ulong)lParam2);
                    return LineNo + 1;
                case "MO_SAVE":
                    SavedCursorPos = Cursor.Position;
                    return LineNo + 1;
                case "TI_WAIT":
                    int result4 = 0;
                    int.TryParse(Args.Split(',')[0], out result4);
                    Thread.Sleep(result4);
                    return LineNo + 1;
                default:
                    return -1;
            }
        }

        public void ShiftMessage(bool ShiftDown)
        {
            if (ShiftDown)
                User32.PostMessage((IntPtr)(long)memRead.WindowHandle, 256U /*0x0100*/, (UIntPtr)16UL /*0x10*/,
                    (UIntPtr)2752512U /*0x2A0000*/);
            else
                User32.PostMessage((IntPtr)(long)memRead.WindowHandle, 257U, (UIntPtr)16UL /*0x10*/,
                    (UIntPtr)3223978176U);
        }

        public long GetHP(MemoryReader memRead)
        {
            return memRead == null || !memRead.IsAttached | !memRead.IsRunning
                ? long.MinValue
                : memRead.ReadInt32((IntPtr)(memRead.ReadUInt32((IntPtr)6190784) + 412U));
        }

        public long GetMP(MemoryReader memRead)
        {
            return memRead == null || !memRead.IsAttached | !memRead.IsRunning
                ? long.MinValue
                : memRead.ReadInt32((IntPtr)((memRead.ReadUInt32((IntPtr)6190784) + 412U) + 4L));
        }

        public long GetMAP(MemoryReader memRead)
        {
            return memRead == null || !memRead.IsAttached | !memRead.IsRunning
                ? long.MinValue
                : memRead.ReadInt32((IntPtr)6787760);
        }

        public long GetXCoord(MemoryReader memRead)
        {
            return memRead == null || !memRead.IsAttached | !memRead.IsRunning
                ? long.MinValue
                : memRead.ReadInt32((IntPtr)6787732);
        }

        public long GetYCoord(MemoryReader memRead)
        {
            return memRead == null || !memRead.IsAttached | !memRead.IsRunning
                ? long.MinValue
                : memRead.ReadInt32((IntPtr)6787728);
        }

        public bool EvaluateCriteria(LogicStructure.LogicItem[] LogicData, int LineNo, bool StartLine)
        {
            LogicStructure logicStructure = new LogicStructure();
            long num1 = 0;
            int index = !StartLine
                ? logicStructure.GetLogicEndRef(LogicData, LineNo)
                : logicStructure.GetLogicStartRef(LogicData, LineNo);
            if (index < 0)
                return false;
            long num2 = LogicData[index].Value;
            switch (LogicData[index].CriteriaType)
            {
                case LogicStructure.CompareCriteriaType.HP:
                    num1 = GetHP(memRead);
                    break;
                case LogicStructure.CompareCriteriaType.MP:
                    num1 = GetMP(memRead);
                    break;
                case LogicStructure.CompareCriteriaType.MAP:
                    num1 = GetMAP(memRead);
                    break;
                case LogicStructure.CompareCriteriaType.XLOC:
                    num1 = GetXCoord(memRead);
                    break;
                case LogicStructure.CompareCriteriaType.YLOC:
                    num1 = GetYCoord(memRead);
                    break;
            }

            bool criteria = false;
            switch (LogicData[index].CompareType)
            {
                case LogicStructure.CompareOpType.GreaterThan:
                    if (num1 > num2)
                    {
                        criteria = true;
                        break;
                    }

                    break;
                case LogicStructure.CompareOpType.LessThan:
                    if (num1 < num2)
                    {
                        criteria = true;
                        break;
                    }

                    break;
                case LogicStructure.CompareOpType.EqualTo:
                    if (num1 == num2)
                    {
                        criteria = true;
                        break;
                    }

                    break;
                case LogicStructure.CompareOpType.NotEqualTo:
                    if (num1 != num2)
                    {
                        criteria = true;
                        break;
                    }

                    break;
            }

            return criteria;
        }

        private void btnStop_Click(object sender, EventArgs e) => StopButton();

        private void QuickSelect(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
            uint result;
            uint.TryParse(toolStripMenuItem.Tag.ToString(), out result);
            memRead = new MemoryReader(result);
            lblProcessName.Text = "Process Name: " + memRead.ProcessName;
            lblProcessID.Text = "Process ID: " + memRead.ProcessID;
            lblWindowHandle.Text = "Window Handle: " + memRead.WindowHandle;
            lblCharName.Text = "Character Name: " + memRead.ReadString((IntPtr)6585504);
        }

        private void btnQuickProc_DropDownOpening(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcesses();
            btnQuickProc.DropDownItems.Clear();
            foreach (Process process in processes)
            {
                if (process.ProcessName.ToUpper() == "DARKAGES")
                {
                    string str = new MemoryReader((uint)process.Id).ReadString((IntPtr)6585504);
                    if (str.Trim() == "")
                        btnQuickProc.DropDownItems.Add("Darkages.exe", null, QuickSelect);
                    else
                        btnQuickProc.DropDownItems.Add($"Darkages.exe ({str})", null, QuickSelect);
                    btnQuickProc.DropDownItems[btnQuickProc.DropDownItems.Count - 1].Tag = process.Id;
                }
            }

            if (btnQuickProc.DropDownItems.Count >= 1)
                return;
            btnQuickProc.DropDownItems.Add("No DA Processes Running.");
            btnQuickProc.DropDownItems[btnQuickProc.DropDownItems.Count - 1].Enabled = false;
        }

        private void btnPause_Click(object sender, EventArgs e) => PauseButton();

        private void txtHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            int modifiers = 0;
            txtHotkey.Text = string.Empty;
            if (e.Control & e.KeyCode != Keys.ControlKey)
            {
                modifiers |= 2;
                txtHotkey.Text += "CTRL + ";
            }

            if (e.Alt & e.KeyCode != Keys.Alt)
            {
                modifiers |= 1;
                txtHotkey.Text += "ALT + ";
            }

            if (e.Shift & e.KeyCode != Keys.ShiftKey)
            {
                modifiers |= 4;
                txtHotkey.Text += "SHIFT + ";
            }

            Keys keyCode = e.KeyCode;
            txtHotkey.Text += (string)(object)e.KeyCode;
            hotkey.SetHotkey(keyCode, modifiers);
            hotkey.ReRegisterGlobalHotKey();
        }

        private void chkHotkey_CheckedChanged(object sender, EventArgs e)
        {
            txtHotkey.Enabled = chkHotkey.Checked;
            hotkey.Enabled = chkHotkey.Checked;
        }

        private void frmMacro_Load(object sender, EventArgs e)
        {
            hotkey = new Hotkey(MdiParent.Handle, Keys.None, 0);
        }

        private void frmMacro_FormClosing(object sender, FormClosingEventArgs e) => hotkey.Dispose();

        private void lvwMacro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete && e.KeyCode != Keys.Back)
                return;
            ListView.SelectedListViewItemCollection selectedItems = lvwMacro.SelectedItems;
            if (selectedItems.Count < 1)
                return;
            foreach (ListViewItem listViewItem in selectedItems)
            {
                listViewItem.Selected = false;
                lvwMacro.Items.Remove(listViewItem);
            }

            ClearNullEntries();
            ReNumberLines();
            IndentLines();
        }


        public class User32
        {
            public const short WM_ACTIVATE = 6;
            public const short WM_ACTIVATEAPP = 28;
            public const short WM_CHAR = 258;
            public const short WM_CLOSE = 16 /*0x10*/;
            public const short WM_KEYDOWN = 256 /*0x0100*/;
            public const short WM_KEYUP = 257;
            public const short WM_LBUTTONDBLCLK = 515;
            public const short WM_LBUTTONDOWN = 513;
            public const short WM_LBUTTONUP = 514;
            public const short WM_MBUTTONDBLCLK = 521;
            public const short WM_MBUTTONDOWN = 519;
            public const short WM_MBUTTONUP = 520;
            public const short WM_RBUTTONDBLCLK = 518;
            public const short WM_RBUTTONDOWN = 516;
            public const short WM_RBUTTONUP = 517;
            public const short WM_SETCURSOR = 32 /*0x20*/;
            public const short WM_MOUSEACTIVATE = 33;
            public const short WM_MOUSEMOVE = 512 /*0x0200*/;
            public const short WM_MOUSELAST = 521;
            public const short WM_MOUSEFIRST = 512 /*0x0200*/;
            public const short WM_MOVE = 3;
            public const short WM_SYSKEYDOWN = 260;
            public const short WM_SYSKEYUP = 261;
            public const short WM_SYSCHAR = 262;
            public const short MK_LBUTTON = 1;
            public const short MK_MBUTTON = 16 /*0x10*/;
            public const short MK_RBUTTON = 2;
            public const short VK_UP = 38;
            public const short VK_DOWN = 40;
            public const short VK_LEFT = 37;
            public const short VK_RIGHT = 39;
            public const short VK_ESCAPE = 27;
            public const short VK_F5 = 116;
            public const short VK_SHIFT = 16 /*0x10*/;

            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool PostMessage(IntPtr hWnd, uint Msg, UIntPtr wParam, UIntPtr lParam);

            [DllImport("user32.dll")]
            public static extern uint MapVirtualKey(uint uCode, uint uMapType);

            [DllImport("user32.dll")]
            public static extern short VkKeyScan(char ch);

            [DllImport("user32.dll")]
            public static extern bool TranslateMessage([In] ref Message lpMsg);
        }

        public struct ClipboardData
        {
            public string[] CommandData;
            public string[] ArgData;
        }

        public struct KeystrokeItem
        {
            public string Keystroke;
            public bool IsSpecialChar;
            public object Tag;
        }

        public enum EndMacroReason
        {
            OutsideFunctionCancelled,
            EndOfMacroReached,
            BadProcessInfo,
            NotAttached,
            ArenaMap
        }
    }
}