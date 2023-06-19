
namespace Easy_Wheel_Replace
{
    partial class EasyWheelReplace
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BTN_GameFolder = new System.Windows.Forms.Button();
            TXT_Gamepath = new System.Windows.Forms.TextBox();
            LST_WantedWheels = new System.Windows.Forms.ComboBox();
            LST_TargetWheels = new System.Windows.Forms.ComboBox();
            BTN_ReplaceWheels = new System.Windows.Forms.Button();
            RevertWheels = new System.Windows.Forms.Button();
            StatusBar = new System.Windows.Forms.ProgressBar();
            SuspendLayout();
            // 
            // BTN_GameFolder
            // 
            BTN_GameFolder.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            BTN_GameFolder.FlatAppearance.BorderSize = 0;
            BTN_GameFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            BTN_GameFolder.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            BTN_GameFolder.Location = new System.Drawing.Point(12, 13);
            BTN_GameFolder.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            BTN_GameFolder.Name = "BTN_GameFolder";
            BTN_GameFolder.Size = new System.Drawing.Size(175, 67);
            BTN_GameFolder.TabIndex = 0;
            BTN_GameFolder.Text = "Select Game Location";
            BTN_GameFolder.UseVisualStyleBackColor = false;
            BTN_GameFolder.Click += button1_Click;
            // 
            // TXT_Gamepath
            // 
            TXT_Gamepath.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            TXT_Gamepath.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            TXT_Gamepath.ForeColor = System.Drawing.Color.White;
            TXT_Gamepath.Location = new System.Drawing.Point(12, 100);
            TXT_Gamepath.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            TXT_Gamepath.Name = "TXT_Gamepath";
            TXT_Gamepath.ReadOnly = true;
            TXT_Gamepath.Size = new System.Drawing.Size(310, 27);
            TXT_Gamepath.TabIndex = 1;
            // 
            // LST_WantedWheels
            // 
            LST_WantedWheels.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            LST_WantedWheels.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            LST_WantedWheels.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            LST_WantedWheels.ForeColor = System.Drawing.Color.White;
            LST_WantedWheels.FormattingEnabled = true;
            LST_WantedWheels.Location = new System.Drawing.Point(12, 147);
            LST_WantedWheels.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            LST_WantedWheels.Name = "LST_WantedWheels";
            LST_WantedWheels.Size = new System.Drawing.Size(310, 28);
            LST_WantedWheels.TabIndex = 2;
            LST_WantedWheels.Text = "Wanted Wheels";
            LST_WantedWheels.SelectedIndexChanged += LST_WantedWheels_SelectedIndexChanged;
            // 
            // LST_TargetWheels
            // 
            LST_TargetWheels.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            LST_TargetWheels.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            LST_TargetWheels.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            LST_TargetWheels.ForeColor = System.Drawing.Color.White;
            LST_TargetWheels.FormattingEnabled = true;
            LST_TargetWheels.Location = new System.Drawing.Point(12, 195);
            LST_TargetWheels.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            LST_TargetWheels.Name = "LST_TargetWheels";
            LST_TargetWheels.Size = new System.Drawing.Size(310, 28);
            LST_TargetWheels.TabIndex = 3;
            LST_TargetWheels.Text = "Target Wheels";
            LST_TargetWheels.SelectedIndexChanged += LST_TargetWheels_SelectedIndexChanged;
            // 
            // BTN_ReplaceWheels
            // 
            BTN_ReplaceWheels.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            BTN_ReplaceWheels.FlatAppearance.BorderSize = 0;
            BTN_ReplaceWheels.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            BTN_ReplaceWheels.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            BTN_ReplaceWheels.Location = new System.Drawing.Point(12, 240);
            BTN_ReplaceWheels.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            BTN_ReplaceWheels.Name = "BTN_ReplaceWheels";
            BTN_ReplaceWheels.Size = new System.Drawing.Size(310, 67);
            BTN_ReplaceWheels.TabIndex = 4;
            BTN_ReplaceWheels.Text = "Replace Wheels";
            BTN_ReplaceWheels.UseVisualStyleBackColor = false;
            BTN_ReplaceWheels.Click += BTN_ReplaceWheels_Click;
            // 
            // RevertWheels
            // 
            RevertWheels.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            RevertWheels.FlatAppearance.BorderSize = 0;
            RevertWheels.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            RevertWheels.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            RevertWheels.Location = new System.Drawing.Point(193, 13);
            RevertWheels.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            RevertWheels.Name = "RevertWheels";
            RevertWheels.Size = new System.Drawing.Size(129, 67);
            RevertWheels.TabIndex = 6;
            RevertWheels.Text = "Revert Swapped Wheels";
            RevertWheels.UseVisualStyleBackColor = false;
            RevertWheels.Click += RevertWheels_Click;
            // 
            // StatusBar
            // 
            StatusBar.Enabled = false;
            StatusBar.Location = new System.Drawing.Point(12, 320);
            StatusBar.Name = "StatusBar";
            StatusBar.Size = new System.Drawing.Size(310, 23);
            StatusBar.TabIndex = 7;
            // 
            // EasyWheelReplace
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(30, 30, 33);
            ClientSize = new System.Drawing.Size(334, 353);
            Controls.Add(StatusBar);
            Controls.Add(RevertWheels);
            Controls.Add(BTN_ReplaceWheels);
            Controls.Add(LST_TargetWheels);
            Controls.Add(LST_WantedWheels);
            Controls.Add(TXT_Gamepath);
            Controls.Add(BTN_GameFolder);
            ForeColor = System.Drawing.Color.White;
            Name = "EasyWheelReplace";
            Text = "Easy Wheel Swap";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button BTN_GameFolder;
        private System.Windows.Forms.TextBox TXT_Gamepath;
        private System.Windows.Forms.ComboBox LST_WantedWheels;
        private System.Windows.Forms.ComboBox LST_TargetWheels;
        private System.Windows.Forms.Button BTN_ReplaceWheels;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button RevertWheels;
        private System.Windows.Forms.ProgressBar StatusBar;
    }
}

