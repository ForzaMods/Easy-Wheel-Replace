namespace Easy_Wheel_Replace
{
    partial class SwappedWheelReplacer
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
            LST_BackedUpList = new System.Windows.Forms.ComboBox();
            BTN_ReplaceWheels = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // LST_BackedUpList
            // 
            LST_BackedUpList.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            LST_BackedUpList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            LST_BackedUpList.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            LST_BackedUpList.ForeColor = System.Drawing.Color.White;
            LST_BackedUpList.FormattingEnabled = true;
            LST_BackedUpList.Location = new System.Drawing.Point(22, 19);
            LST_BackedUpList.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            LST_BackedUpList.Name = "LST_BackedUpList";
            LST_BackedUpList.Size = new System.Drawing.Size(291, 28);
            LST_BackedUpList.TabIndex = 3;
            LST_BackedUpList.Text = "Backedup wheels list";
            LST_BackedUpList.SelectedIndexChanged += LST_BackedUpList_SelectedIndexChanged;
            // 
            // BTN_ReplaceWheels
            // 
            BTN_ReplaceWheels.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            BTN_ReplaceWheels.FlatAppearance.BorderSize = 0;
            BTN_ReplaceWheels.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            BTN_ReplaceWheels.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            BTN_ReplaceWheels.ForeColor = System.Drawing.SystemColors.Control;
            BTN_ReplaceWheels.Location = new System.Drawing.Point(22, 67);
            BTN_ReplaceWheels.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            BTN_ReplaceWheels.Name = "BTN_ReplaceWheels";
            BTN_ReplaceWheels.Size = new System.Drawing.Size(291, 67);
            BTN_ReplaceWheels.TabIndex = 5;
            BTN_ReplaceWheels.Text = "Revert wheel";
            BTN_ReplaceWheels.UseVisualStyleBackColor = false;
            BTN_ReplaceWheels.Click += BTN_RevetWheels_Click;
            // 
            // OriginalWheelReplacer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(30, 30, 33);
            ClientSize = new System.Drawing.Size(334, 156);
            Controls.Add(BTN_ReplaceWheels);
            Controls.Add(LST_BackedUpList);
            Name = "Swapped Wheel Replacer";
            Text = "Swapped Wheel Replacer";
            FormClosing += OriginalWheelReplacer_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ComboBox LST_BackedUpList;
        private System.Windows.Forms.Button BTN_ReplaceWheels;
    }
}