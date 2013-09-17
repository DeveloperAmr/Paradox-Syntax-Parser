namespace SyntaxParser
{
    partial class mainform
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
            this.bt_select = new System.Windows.Forms.Button();
            this.cmb_first = new System.Windows.Forms.ComboBox();
            this.cmb_second = new System.Windows.Forms.ComboBox();
            this.lbl_first = new System.Windows.Forms.Label();
            this.lbl_second = new System.Windows.Forms.Label();
            this.bt_load_1 = new System.Windows.Forms.Button();
            this.bt_load_2 = new System.Windows.Forms.Button();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bt_select
            // 
            this.bt_select.Location = new System.Drawing.Point(444, 1);
            this.bt_select.Name = "bt_select";
            this.bt_select.Size = new System.Drawing.Size(119, 60);
            this.bt_select.TabIndex = 0;
            this.bt_select.Text = "Select File";
            this.bt_select.UseVisualStyleBackColor = true;
            this.bt_select.Click += new System.EventHandler(this.bt_select_Click);
            // 
            // cmb_first
            // 
            this.cmb_first.FormattingEnabled = true;
            this.cmb_first.Location = new System.Drawing.Point(78, 12);
            this.cmb_first.Name = "cmb_first";
            this.cmb_first.Size = new System.Drawing.Size(161, 21);
            this.cmb_first.TabIndex = 1;
            this.cmb_first.SelectedIndexChanged += new System.EventHandler(this.cmb_first_SelectedIndexChanged);
            // 
            // cmb_second
            // 
            this.cmb_second.FormattingEnabled = true;
            this.cmb_second.Location = new System.Drawing.Point(78, 39);
            this.cmb_second.Name = "cmb_second";
            this.cmb_second.Size = new System.Drawing.Size(161, 21);
            this.cmb_second.TabIndex = 2;
            // 
            // lbl_first
            // 
            this.lbl_first.AutoSize = true;
            this.lbl_first.Location = new System.Drawing.Point(18, 15);
            this.lbl_first.Name = "lbl_first";
            this.lbl_first.Size = new System.Drawing.Size(54, 13);
            this.lbl_first.TabIndex = 3;
            this.lbl_first.Text = "First level:";
            // 
            // lbl_second
            // 
            this.lbl_second.AutoSize = true;
            this.lbl_second.Location = new System.Drawing.Point(0, 42);
            this.lbl_second.Name = "lbl_second";
            this.lbl_second.Size = new System.Drawing.Size(72, 13);
            this.lbl_second.TabIndex = 4;
            this.lbl_second.Text = "Second level:";
            // 
            // bt_load_1
            // 
            this.bt_load_1.Enabled = false;
            this.bt_load_1.Location = new System.Drawing.Point(363, 9);
            this.bt_load_1.Name = "bt_load_1";
            this.bt_load_1.Size = new System.Drawing.Size(75, 23);
            this.bt_load_1.TabIndex = 5;
            this.bt_load_1.Text = "Search";
            this.bt_load_1.UseVisualStyleBackColor = true;
            this.bt_load_1.Click += new System.EventHandler(this.bt_load_1_Click);
            // 
            // bt_load_2
            // 
            this.bt_load_2.Enabled = false;
            this.bt_load_2.Location = new System.Drawing.Point(363, 38);
            this.bt_load_2.Name = "bt_load_2";
            this.bt_load_2.Size = new System.Drawing.Size(75, 23);
            this.bt_load_2.TabIndex = 6;
            this.bt_load_2.Text = "Load all";
            this.bt_load_2.UseVisualStyleBackColor = true;
            this.bt_load_2.Click += new System.EventHandler(this.bt_load_2_Click);
            // 
            // txt_search
            // 
            this.txt_search.Enabled = false;
            this.txt_search.Location = new System.Drawing.Point(257, 12);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(100, 20);
            this.txt_search.TabIndex = 7;
            // 
            // mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 81);
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.bt_load_2);
            this.Controls.Add(this.bt_load_1);
            this.Controls.Add(this.lbl_second);
            this.Controls.Add(this.lbl_first);
            this.Controls.Add(this.cmb_second);
            this.Controls.Add(this.cmb_first);
            this.Controls.Add(this.bt_select);
            this.Name = "mainform";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_select;
        private System.Windows.Forms.ComboBox cmb_first;
        private System.Windows.Forms.ComboBox cmb_second;
        private System.Windows.Forms.Label lbl_first;
        private System.Windows.Forms.Label lbl_second;
        private System.Windows.Forms.Button bt_load_1;
        private System.Windows.Forms.Button bt_load_2;
        private System.Windows.Forms.TextBox txt_search;
    }
}

