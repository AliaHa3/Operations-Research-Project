namespace ORproject
{
    partial class NetworkEntry
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
            this.Add = new System.Windows.Forms.Button();
            this.numberVerticsText = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.matrix_Panel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(182, 3);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 23);
            this.Add.TabIndex = 0;
            this.Add.Text = "button1";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // numberVerticsText
            // 
            this.numberVerticsText.Location = new System.Drawing.Point(44, 6);
            this.numberVerticsText.Name = "numberVerticsText";
            this.numberVerticsText.Size = new System.Drawing.Size(48, 20);
            this.numberVerticsText.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numberVerticsText);
            this.panel1.Controls.Add(this.Add);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 43);
            this.panel1.TabIndex = 3;
            // 
            // matrix_Panel
            // 
            this.matrix_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.matrix_Panel.Location = new System.Drawing.Point(0, 43);
            this.matrix_Panel.Name = "matrix_Panel";
            this.matrix_Panel.Size = new System.Drawing.Size(284, 219);
            this.matrix_Panel.TabIndex = 4;
            // 
            // NetworkEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.matrix_Panel);
            this.Controls.Add(this.panel1);
            this.Name = "NetworkEntry";
            this.Text = "NetworkEntry";
            this.Load += new System.EventHandler(this.NetworkEntry_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.TextBox numberVerticsText;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel matrix_Panel;
    }
}