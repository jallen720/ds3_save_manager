using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DS3_Save_Manager
{
    public partial class Main : Form
    {
        private const string REGISTRY_KEY_NAME = "ds3_save_manager";
        private const string TEMP_BACKUP_NAME = "ds3_save_manager_temp_backup";
        private readonly string DS3_SAVE_DIRECTORY_PATH;
        private readonly RegistryKey registry_key;

        public Main()
        {
            InitializeComponent();
            update_backup_button();
            update_revert_button();
            DS3_SAVE_DIRECTORY_PATH = Path.Combine(Environment.GetEnvironmentVariable("appdata"), "DarkSoulsIII");


            // Retrieve registry key for application, or create it if it hasn't already been created.
            RegistryKey software_key = Registry
                .CurrentUser
                .OpenSubKey("Software", true);

            if ((registry_key = software_key.OpenSubKey(REGISTRY_KEY_NAME, true)) == null)
            {
                software_key.CreateSubKey(REGISTRY_KEY_NAME);
                registry_key = software_key.OpenSubKey(REGISTRY_KEY_NAME, true);
            }


            // Load config from registry.
            backup_directory_textbox.Text = (string)registry_key.GetValue("backup_directory");
            create_temp_backup_toggle.Checked = bool.Parse((string)registry_key.GetValue("create_temp_backup") ?? "true");
        }


        #region Events
        private void backup_directory_browse_button_Click(object sender, EventArgs e)
        {
            if (backup_directory_browser.ShowDialog() == DialogResult.OK)
            {
                backup_directory_textbox.Text = backup_directory_browser.SelectedPath;
            }
        }

        private void backup_button_Click(object sender, EventArgs e)
        {
            copy_directory(DS3_SAVE_DIRECTORY_PATH, get_new_backup_path());
            backup_name_textbox.Text = "";
            update_backup_name_dropdown();
        }

        private void backup_directory_textbox_TextChanged(object sender, EventArgs e)
        {
            update_backup_name_dropdown();


            // Update backup and revert buttons to reflect changes to backup directory.
            update_backup_button();
            update_revert_button();


            // Update config with new backup directory.
            registry_key.SetValue("backup_directory", backup_directory_textbox.Text);
        }

        private void backup_name_textbox_TextChanged(object sender, EventArgs e)
        {
            update_backup_button();
        }

        private void create_temp_backup_toggle_Click(object sender, EventArgs e)
        {
            // Update config with new create temp backup flag.
            registry_key.SetValue("create_temp_backup", create_temp_backup_toggle.Checked);
        }

        private void revert_button_Click(object sender, EventArgs e)
        {
            if (create_temp_backup_toggle.Checked)
            {
                string temp_backup_path = get_temp_backup_path();

                if (Directory.Exists(temp_backup_path))
                {
                    Directory.Delete(temp_backup_path, true);
                }

                copy_directory(DS3_SAVE_DIRECTORY_PATH, temp_backup_path);
            }

            Directory.Delete(DS3_SAVE_DIRECTORY_PATH, true);
            copy_directory(get_selected_backup_path(), DS3_SAVE_DIRECTORY_PATH);

            MessageBox.Show(
                "Successfully reverted current save to backup: " + (string)backup_name_dropdown.SelectedItem,
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            if (create_temp_backup_toggle.Checked)
            {
                update_backup_name_dropdown();
            }
        }

        private void backup_name_dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            var backup_name = (string)backup_name_dropdown.SelectedItem;
            revert_button.Text = "Revert current save to backup: " + backup_name;
            delete_button.Text = "Delete backup: " + backup_name;
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to permanently delete backup: " + (string)backup_name_dropdown.SelectedItem,
                "Warning",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Directory.Delete(get_selected_backup_path(), true);
                update_backup_name_dropdown();
            }
        }
        #endregion Events


        #region Utilities
        private bool is_ds3_backup_directory(string directory)
        {
            // Best way I can think of to verify a backup directory actually contains DS3 save data.
            return Directory.GetFiles(directory).Contains(Path.Combine(directory, "GraphicsConfig.xml"));
        }

        private void update_backup_button()
        {
            backup_button.Enabled =
                backup_directory_textbox.Text != "" &&    // Backup directory must exist
                backup_name_textbox.Text != "" &&         // Backup name must exist
                !Directory.Exists(get_new_backup_path()); // Backup must not already exist

            backup_button.Text = "Backup current save as: " + backup_name_textbox.Text;
        }

        private void update_revert_button()
        {
            revert_button.Enabled = backup_directory_textbox.Text != "" && is_backup_selected();
        }

        private bool is_backup_selected()
        {
            return backup_name_dropdown.Items.Count > 0;
        }

        private void copy_directory(string source_directory_name, string destination_directory_name)
        {
            // Get the subdirectories for the specified directory.
            var source_directory = new DirectoryInfo(source_directory_name);

            if (!source_directory.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + source_directory_name);
            }

            DirectoryInfo[] dirs = source_directory.GetDirectories();

            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destination_directory_name))
            {
                Directory.CreateDirectory(destination_directory_name);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = source_directory.GetFiles();

            foreach (FileInfo file in files)
            {
                file.CopyTo(Path.Combine(destination_directory_name, file.Name), false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            foreach (DirectoryInfo subdir in dirs)
            {
                copy_directory(subdir.FullName, Path.Combine(destination_directory_name, subdir.Name));
            }
        }

        private string get_new_backup_path()
        {
            return Path.Combine(backup_directory_textbox.Text, backup_name_textbox.Text);
        }

        private string get_temp_backup_path()
        {
            return Path.Combine(backup_directory_textbox.Text, TEMP_BACKUP_NAME);
        }

        private string get_selected_backup_path()
        {
            return Path.Combine(backup_directory_textbox.Text, (string)backup_name_dropdown.SelectedItem);
        }

        private void update_backup_name_dropdown()
        {
            backup_name_dropdown.Items.Clear();

            IEnumerable<string> backup_directories = Directory
                .GetDirectories(backup_directory_textbox.Text)
                .Where(is_ds3_backup_directory)
                .Select(backup_directory => backup_directory.Replace(backup_directory_textbox.Text + "\\", ""));

            foreach (string backup_directory in backup_directories)
            {
                backup_name_dropdown.Items.Add(backup_directory);
            }

            if (is_backup_selected())
            {
                backup_name_dropdown.SelectedIndex = 0;
            }
        }
        #endregion Utilities
    }
}
