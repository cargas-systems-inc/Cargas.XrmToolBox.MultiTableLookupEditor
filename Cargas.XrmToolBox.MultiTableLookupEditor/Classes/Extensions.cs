using System.Linq;
using System.Windows.Forms;

namespace Cargas.XrmToolBox.MultiTableLookupEditor.Classes
{
    public static partial class Extensions
    {
        /// <summary>
        /// Gets the local or default text.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <param name="defaultIfNull">The default if null.</param>
        /// <returns></returns>
        public static string GetLocalOrDefaultText(this Microsoft.Xrm.Sdk.Label label, string defaultIfNull = null)
        {
            var local = label.UserLocalizedLabel ?? label.LocalizedLabels.FirstOrDefault();

            if (local == null)
            {
                return defaultIfNull;
            }

            return local.Label ?? defaultIfNull;
        }

        /// <summary>
        /// Clears and loads a list of objects into a ComboBox
        /// </summary>
        /// <param name="comboBox">The ComboBox.</param>
        /// <param name="items">The array of objects to add to the ComboBox.</param>
        /// <returns></returns>
        public static void LoadItems(this ComboBox comboBox, object[] items)
        {
            comboBox.Enabled = false;
            comboBox.BeginUpdate();
            comboBox.Items.Clear();
            comboBox.Items.AddRange(items);
            comboBox.EndUpdate();
            comboBox.Enabled = true;
        }

        /// <summary>
        /// Clears and loads a list of objects into a ComboBox
        /// </summary>
        /// <param name="comboBox">The ComboBox.</param>
        /// <param name="items">The array of objects to add to the ComboBox.</param>
        /// <returns></returns>
        public static void LoadItems(this CheckedListBox checkedListBox, object[] items)
        {
            checkedListBox.DisplayMember = "DisplayName";
            checkedListBox.ValueMember = "Value";
            checkedListBox.Enabled = false;
            checkedListBox.BeginUpdate();
            checkedListBox.Items.Clear();
            checkedListBox.Items.AddRange(items);
            checkedListBox.EndUpdate();
            checkedListBox.Enabled = true;
        }
    }
}
