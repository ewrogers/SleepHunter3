using System;
using System.IO;
using System.Windows.Forms;
using SleepHunter.Macro.Serialization;

namespace SleepHunter.Forms
{
    public partial class MainForm
    {
        private void SaveMacroDocument(SerializableMacroDocument document)
        {
            StreamWriter writer = null;

            try
            {
                var safeFilename = string.Join("_", document.Name.Trim().Split(Path.GetInvalidFileNameChars()));

                saveFileDialog.FileName = $"{safeFilename}.sh3x";
                var result = saveFileDialog.ShowDialog(this);

                if (result != DialogResult.OK)
                {
                    return;
                }

                SetStatusText("Saving macro...");

                var json = serializer.SerializeDocument(document);
                writer = File.CreateText(saveFileDialog.FileName);
                writer.Write(json);
                writer.Flush();
                writer.Close();

                SetStatusText("Macro saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Failed to save macro.", "Save Macro Failed", MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
                SetStatusText($"Failed to save macro: {ex.Message}");
            }
            finally
            {
                writer?.Dispose();
            }
        }
    }
}