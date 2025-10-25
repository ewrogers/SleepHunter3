using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SleepHunter.Macro.Commands;
using SleepHunter.Models;

namespace SleepHunter.Forms
{
    public partial class MacroForm
    {
        private void processPanel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(typeof(GameClientWindow))
                ? DragDropEffects.Copy
                : DragDropEffects.None;
        }

        private void processPanel_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(GameClientWindow)) || IsRunning)
            {
                return;
            }

            try
            {
                var gameWindow = (GameClientWindow)e.Data.GetData(typeof(GameClientWindow));
                AttachToClient(gameWindow);
            }
            catch
            {
                MessageBox.Show(this, "Unable to attach to the selected client.", "Quick Attach Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void macroListView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<int>)))
            {
                e.Effect = DragDropEffects.Move;
                return;
            }

            e.Effect = e.Data.GetDataPresent(typeof(MacroCommandDefinition)) && !IsRunning
                ? DragDropEffects.Copy
                : DragDropEffects.None;
        }

        private void macroListView_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(MacroCommandDefinition)))
            {
                return;
            }

            var definition = (MacroCommandDefinition)e.Data.GetData(typeof(MacroCommandDefinition));
            var parameters = ShowArgumentsForm(definition);

            // Ignore if not enough parameters provided
            if (parameters == null)
            {
                return;
            }

            AddMacroCommand(definition, parameters);
        }

        private void macroListView_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(MacroCommandDefinition)))
            {
                e.Effect = DragDropEffects.Copy;
                return;
            }
            
            if (!e.Data.GetDataPresent(typeof(List<int>)))
            {
                e.Effect = DragDropEffects.None;
                macroListView.InsertionMark.Index = -1;
                return;
            }
        }

        private void macroListView_DragLeave(object sender, EventArgs e)
        {
            macroListView.InsertionMark.Index = -1;
        }

        private void macroListView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (!IsSelectionContiguous())
            {
                return;
            }

            var selectedItems = macroListView.SelectedItems.Cast<ListViewItem>().ToList();
            macroListView.DoDragDrop(selectedItems, DragDropEffects.Move);
        }

        private bool IsSelectionContiguous()
        {
            switch (macroListView.SelectedItems.Count)
            {
                case 0:
                    return false;
                case 1:
                    return true;
            }

            var selectedIndices = GetSelectedIndices().ToList();

            for (var i = 1; i < selectedIndices.Count; i++)
            {
                if (selectedIndices[i] != selectedIndices[i - 1] + 1)
                {
                    return false;
                }
            }

            return true;
        }

    }
}