namespace DS3_Save_Manager
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.backup_directory_textbox = new System.Windows.Forms.TextBox();
            this.backup_directory_label = new System.Windows.Forms.Label();
            this.backup_directory_browse_button = new System.Windows.Forms.Button();
            this.backup_button = new System.Windows.Forms.Button();
            this.revert_button = new System.Windows.Forms.Button();
            this.backup_name_textbox = new System.Windows.Forms.TextBox();
            this.backup_name_label = new System.Windows.Forms.Label();
            this.backup_name_dropdown = new System.Windows.Forms.ComboBox();
            this.revert_name_label = new System.Windows.Forms.Label();
            this.create_temp_backup_toggle = new System.Windows.Forms.CheckBox();
            this.backup_directory_browser = new System.Windows.Forms.FolderBrowserDialog();
            this.delete_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // backup_directory_textbox
            // 
            this.backup_directory_textbox.Location = new System.Drawing.Point(139, 16);
            this.backup_directory_textbox.Name = "backup_directory_textbox";
            this.backup_directory_textbox.ReadOnly = true;
            this.backup_directory_textbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.backup_directory_textbox.Size = new System.Drawing.Size(576, 22);
            this.backup_directory_textbox.TabIndex = 1;
            this.backup_directory_textbox.TextChanged += new System.EventHandler(this.backup_directory_textbox_TextChanged);
            // 
            // backup_directory_label
            // 
            this.backup_directory_label.AutoSize = true;
            this.backup_directory_label.Location = new System.Drawing.Point(17, 19);
            this.backup_directory_label.Name = "backup_directory_label";
            this.backup_directory_label.Size = new System.Drawing.Size(116, 17);
            this.backup_directory_label.TabIndex = 2;
            this.backup_directory_label.Text = "Backup Directory";
            // 
            // backup_directory_browse_button
            // 
            this.backup_directory_browse_button.Location = new System.Drawing.Point(721, 12);
            this.backup_directory_browse_button.Name = "backup_directory_browse_button";
            this.backup_directory_browse_button.Size = new System.Drawing.Size(91, 30);
            this.backup_directory_browse_button.TabIndex = 3;
            this.backup_directory_browse_button.Text = "Browse";
            this.backup_directory_browse_button.UseVisualStyleBackColor = true;
            this.backup_directory_browse_button.Click += new System.EventHandler(this.backup_directory_browse_button_Click);
            // 
            // backup_button
            // 
            this.backup_button.Location = new System.Drawing.Point(20, 131);
            this.backup_button.Name = "backup_button";
            this.backup_button.Size = new System.Drawing.Size(792, 30);
            this.backup_button.TabIndex = 5;
            this.backup_button.Text = "Backup current save as:";
            this.backup_button.UseVisualStyleBackColor = true;
            this.backup_button.Click += new System.EventHandler(this.backup_button_Click);
            // 
            // revert_button
            // 
            this.revert_button.Location = new System.Drawing.Point(20, 271);
            this.revert_button.Name = "revert_button";
            this.revert_button.Size = new System.Drawing.Size(792, 30);
            this.revert_button.TabIndex = 6;
            this.revert_button.Text = "Revert current save to backup:";
            this.revert_button.UseVisualStyleBackColor = true;
            this.revert_button.Click += new System.EventHandler(this.revert_button_Click);
            // 
            // backup_name_textbox
            // 
            this.backup_name_textbox.Location = new System.Drawing.Point(119, 103);
            this.backup_name_textbox.Name = "backup_name_textbox";
            this.backup_name_textbox.Size = new System.Drawing.Size(693, 22);
            this.backup_name_textbox.TabIndex = 0;
            this.backup_name_textbox.TextChanged += new System.EventHandler(this.backup_name_textbox_TextChanged);
            // 
            // backup_name_label
            // 
            this.backup_name_label.AutoSize = true;
            this.backup_name_label.Location = new System.Drawing.Point(17, 106);
            this.backup_name_label.Name = "backup_name_label";
            this.backup_name_label.Size = new System.Drawing.Size(96, 17);
            this.backup_name_label.TabIndex = 8;
            this.backup_name_label.Text = "Backup Name";
            // 
            // backup_name_dropdown
            // 
            this.backup_name_dropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.backup_name_dropdown.FormattingEnabled = true;
            this.backup_name_dropdown.Location = new System.Drawing.Point(119, 214);
            this.backup_name_dropdown.Name = "backup_name_dropdown";
            this.backup_name_dropdown.Size = new System.Drawing.Size(693, 24);
            this.backup_name_dropdown.TabIndex = 9;
            this.backup_name_dropdown.SelectedIndexChanged += new System.EventHandler(this.backup_name_dropdown_SelectedIndexChanged);
            // 
            // revert_name_label
            // 
            this.revert_name_label.AutoSize = true;
            this.revert_name_label.Location = new System.Drawing.Point(17, 217);
            this.revert_name_label.Name = "revert_name_label";
            this.revert_name_label.Size = new System.Drawing.Size(96, 17);
            this.revert_name_label.TabIndex = 10;
            this.revert_name_label.Text = "Backup Name";
            // 
            // create_temp_backup_toggle
            // 
            this.create_temp_backup_toggle.AutoSize = true;
            this.create_temp_backup_toggle.Checked = true;
            this.create_temp_backup_toggle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.create_temp_backup_toggle.Location = new System.Drawing.Point(23, 244);
            this.create_temp_backup_toggle.Name = "create_temp_backup_toggle";
            this.create_temp_backup_toggle.Size = new System.Drawing.Size(289, 21);
            this.create_temp_backup_toggle.TabIndex = 12;
            this.create_temp_backup_toggle.Text = "Create temporary backup of current save\r\n";
            this.create_temp_backup_toggle.UseVisualStyleBackColor = true;
            this.create_temp_backup_toggle.Click += new System.EventHandler(this.create_temp_backup_toggle_Click);
            // 
            // delete_button
            // 
            this.delete_button.Location = new System.Drawing.Point(20, 307);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(792, 30);
            this.delete_button.TabIndex = 13;
            this.delete_button.Text = "Delete backup:";
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 356);
            this.Controls.Add(this.delete_button);
            this.Controls.Add(this.create_temp_backup_toggle);
            this.Controls.Add(this.revert_name_label);
            this.Controls.Add(this.backup_name_dropdown);
            this.Controls.Add(this.backup_name_label);
            this.Controls.Add(this.backup_name_textbox);
            this.Controls.Add(this.revert_button);
            this.Controls.Add(this.backup_button);
            this.Controls.Add(this.backup_directory_browse_button);
            this.Controls.Add(this.backup_directory_label);
            this.Controls.Add(this.backup_directory_textbox);
            this.Name = "Main";
            this.Text = "Dark Souls 3 Save Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox backup_directory_textbox;
        private System.Windows.Forms.Label backup_directory_label;
        private System.Windows.Forms.Button backup_directory_browse_button;
        private System.Windows.Forms.Button backup_button;
        private System.Windows.Forms.Button revert_button;
        private System.Windows.Forms.TextBox backup_name_textbox;
        private System.Windows.Forms.Label backup_name_label;
        private System.Windows.Forms.ComboBox backup_name_dropdown;
        private System.Windows.Forms.Label revert_name_label;
        private System.Windows.Forms.CheckBox create_temp_backup_toggle;
        private System.Windows.Forms.FolderBrowserDialog backup_directory_browser;
        private System.Windows.Forms.Button delete_button;
    }
}

