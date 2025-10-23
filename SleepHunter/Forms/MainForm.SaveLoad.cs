using System;
using System.IO;
using System.Windows.Forms;
using SleepHunter.Macro.Serialization;

namespace SleepHunter.Forms
{
    public partial class MainForm
    {
        private void SaveMacroDocument(SerializableMacroDocument document, string filePath)
        {
            StreamWriter writer = null;

            try
            {
                var filename = Path.GetFileName(filePath);
                SetStatusText($"Saving {filename}...");
                
                var json = serializer.SerializeDocument(document);
                writer = File.CreateText(filePath);
                writer.Write(json);
                writer.Flush();
                writer.Close();

                SetStatusText($"Saved {filename} successfully.");
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

        private void LoadMacroFile(string filePath)
        {
            var isLegacyFormat = Path.GetExtension(filePath).Equals(".sh3", StringComparison.OrdinalIgnoreCase);

            if (isLegacyFormat)
            {
                LoadLegacyFile(filePath);
            }
            else
            {
                LoadModernFile(filePath);
            }
        }

        private void LoadLegacyFile(string filePath)
        {
            var filename = Path.GetFileName(filePath);

            StreamReader reader = null;

            try
            {
                SetStatusText($"Loading {filename}...");
                
                reader = File.OpenText(filePath);
                var content = reader.ReadToEnd();

                var document = legacySerializer.DeserializeDocument(content);
                var macroForm = CreateMacroForm();

                macroForm.LoadMacroDocument(document);
                macroForm.Show();
                
                SetStatusText($"Loaded {filename} successfully.");
            }
            catch (Exception ex)
            {
                SetStatusText($"Failed to load legacy macro {filename}: " + ex.Message);
            }
            finally
            {
                reader?.Dispose();
            }
        }

        private void LoadModernFile(string filePath)
        {
            var filename = Path.GetFileName(filePath);

            StreamReader reader = null;

            try
            {
                SetStatusText($"Loading {filename}...");
                
                reader = File.OpenText(filePath);
                var json = reader.ReadToEnd();

                var document = serializer.DeserializeDocument(json);
                var macroForm = CreateMacroForm();
                
                macroForm.LoadMacroDocument(document);
                macroForm.Show();
                
                SetStatusText($"Loaded {filename} successfully.");
            }
            catch (Exception ex)
            {
                SetStatusText($"Failed to load macro {filename}: " + ex.Message);
            }
            finally
            {
                reader?.Dispose();
            }
        }
    }
}