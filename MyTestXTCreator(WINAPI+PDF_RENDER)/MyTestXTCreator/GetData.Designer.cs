
namespace MyTestXTCreator
{
    partial class GetData
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
            this.ok = new System.Windows.Forms.Button();
            this.text = new System.Windows.Forms.Label();
            this.data = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(98, 90);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 0;
            this.ok.TabStop = false;
            this.ok.Text = "Ok";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // text
            // 
            this.text.AutoSize = true;
            this.text.Location = new System.Drawing.Point(62, 20);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(0, 13);
            this.text.TabIndex = 1;
            // 
            // data
            // 
            this.data.Location = new System.Drawing.Point(57, 46);
            this.data.Name = "data";
            this.data.Size = new System.Drawing.Size(157, 20);
            this.data.TabIndex = 2;
            this.data.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.data_KeyPress);
            // 
            // GetData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(275, 125);
            this.Controls.Add(this.data);
            this.Controls.Add(this.text);
            this.Controls.Add(this.ok);
            this.DoubleBuffered = true;
            this.Name = "GetData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GetData";
            this.Load += new System.EventHandler(this.GetData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Label text;
        public System.Windows.Forms.TextBox data;
    }
}