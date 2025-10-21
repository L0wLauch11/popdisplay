namespace windows_forms
{
    partial class ModeSelectForm
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
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModeSelectForm));
            ModeList = new ListBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // ModeList
            // 
            ModeList.BackColor = Color.FromArgb(25, 25, 25);
            ModeList.BorderStyle = BorderStyle.FixedSingle;
            ModeList.Font = new Font("Consolas", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModeList.ForeColor = Color.White;
            ModeList.FormattingEnabled = true;
            ModeList.ItemHeight = 22;
            ModeList.Items.AddRange(new object[] { ": keep current" });
            ModeList.Location = new Point(12, 48);
            ModeList.Name = "ModeList";
            ModeList.Size = new Size(635, 332);
            ModeList.TabIndex = 0;
            ModeList.SelectedIndexChanged += ModeList_SelectedIndexChanged;
            ModeList.KeyDown += ModeList_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DimGray;
            label1.Location = new Point(11, 9);
            label1.Name = "label1";
            label1.Size = new Size(243, 20);
            label1.TabIndex = 1;
            label1.Text = "up/down: select entry | right: confirm\r\n";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DimGray;
            label2.Location = new Point(-6, 20);
            label2.Name = "label2";
            label2.Size = new Size(3657, 20);
            label2.TabIndex = 2;
            label2.Text = resources.GetString("label2.Text");
            // 
            // ModeSelectForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(659, 392);
            ControlBox = false;
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(ModeList);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "ModeSelectForm";
            Opacity = 0.9D;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Select Monitor Mode";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox ModeList;
        private Label label1;
        private Label label2;
    }
}
