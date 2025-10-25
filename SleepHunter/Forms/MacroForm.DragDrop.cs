using System;
using System.Collections.Generic;
using System.Drawing;
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
                e.Effect = e.AllowedEffect & DragDropEffects.Move;
                return;
            }

            if (e.Data.GetDataPresent(typeof(MacroCommandDefinition)))
            {
                e.Effect = e.AllowedEffect & DragDropEffects.Copy;
                return;
            }

            e.Effect = DragDropEffects.None;
        }

        private void macroListView_DragDrop(object sender, DragEventArgs e)
        {
            if (!(sender is ListView listView))
            {
                return;
            }

            try
            {
                var actualInsertionIndex =
                        listView.InsertionMark.AppearsAfterItem ?
                        listView.InsertionMark.Index + 1 :
                        listView.InsertionMark.Index;

                // Handle adding a command via drag and drop
                if (e.Data.GetDataPresent(typeof(MacroCommandDefinition)))
                {
                    if (IsRunning)
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

                    AddMacroCommand(definition, parameters, actualInsertionIndex);
                    return;
                }

                // Handle drag and drop of selected items to re-arrange
                if (e.Data.GetDataPresent(typeof(List<int>)))
                {
                    var selectedIndices = (List<int>)e.Data.GetData(typeof(List<int>));
                    MoveMacroCommands(selectedIndices, actualInsertionIndex);
                }
            }
            finally
            {
                listView.InsertionMark.Index = -1;
            }
        }

        private void macroListView_DragOver(object sender, DragEventArgs e)
        {
            if (!(sender is ListView listView))
            {
                return;
            }

            var isCommand = e.Data.GetDataPresent(typeof(MacroCommandDefinition));
            var isReorder = e.Data.GetDataPresent(typeof(List<int>));

            var firstSelectedIndex = -1;
            var lastSelectedIndex = -1;

            if (isCommand)
            {
                e.Effect = e.AllowedEffect & DragDropEffects.Copy;
            }
            else if (isReorder)
            {
                e.Effect = e.AllowedEffect & DragDropEffects.Move;
                var draggedIndices = (List<int>)e.Data.GetData(typeof(List<int>));
                firstSelectedIndex = draggedIndices.Min();
                lastSelectedIndex = draggedIndices.Max();
            }
            else
            {
                listView.InsertionMark.Index = -1;
                return;
            }

            var clientPoint = listView.PointToClient(new Point(e.X, e.Y));

            // Find insertion point
            var itemOver = listView.GetItemAt(clientPoint.X, clientPoint.Y);
            var insertionIndex = 0;
            var appearsAfter = false;

            if (itemOver == null)
            {
                // Dragging below the last item or empty space
                if (listView.Items.Count > 0)
                {
                    insertionIndex = listView.Items.Count - 1;
                    appearsAfter = true;
                }
                else
                {
                    insertionIndex = 0;
                    appearsAfter = false;
                }
            }
            else
            {
                var itemBounds = itemOver.Bounds;
                if (clientPoint.Y < itemBounds.Top + itemBounds.Height / 2)
                {
                    // Insert before this item
                    insertionIndex = itemOver.Index;
                    appearsAfter = false;
                }
                else
                {
                    // Insert after this item
                    insertionIndex = itemOver.Index - 1;
                    appearsAfter = true;
                }
            }

            // Calculate actual insertion index
            var actualInsertionIndex = appearsAfter ? insertionIndex + 1 : insertionIndex;

            if (isReorder)
            {
                // Do not allow dropping within or adjacent to the selection
                if (actualInsertionIndex >= firstSelectedIndex && actualInsertionIndex <= lastSelectedIndex)
                {
                    e.Effect = DragDropEffects.None;
                    listView.InsertionMark.Index = -1;
                    return;
                }

                e.Effect = e.AllowedEffect & DragDropEffects.Move;
            }
            else if (isCommand)
            {
                e.Effect = e.AllowedEffect & DragDropEffects.Copy;
            }

            // Set the insertion mark
            listView.InsertionMark.Index = actualInsertionIndex;
            listView.InsertionMark.AppearsAfterItem = appearsAfter;
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

            var selectedIndices = macroListView.SelectedIndices.Cast<int>().ToList();
            macroListView.DoDragDrop(selectedIndices, DragDropEffects.Move);
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