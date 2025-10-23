using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
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
                reader = File.OpenText(filePath);
                var count = int.Parse(reader.ReadLine() ?? "0");
                var name = reader.ReadLine();

                for (var i = 0; i < count; i++)
                {
                    var line = reader.ReadLine();
                }
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

        private void LoadModernFile(string filePath)
        {
            var filename = Path.GetFileName(filePath);

            StreamReader reader = null;

            try
            {
                reader = File.OpenText(filePath);
                var json = reader.ReadToEnd();

                var document = serializer.DeserializeDocument(json);
                var macroForm = CreateMacroForm();

                macroForm.Text = !string.IsNullOrWhiteSpace(document.Name)
                    ? $"Macro Data - {document.Name}"
                    : "Macro Data";

                macroForm.LoadMacroDocument(document);

                macroForm.Show();
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