namespace PokeCiv.View
{
    partial class TeamView
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
            this.team_listbox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.team_listbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.team_listbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.team_listbox.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.team_listbox.FormattingEnabled = true;
            this.team_listbox.ItemHeight = 34;
            this.team_listbox.Items.AddRange(new object[] {
            "You",
            "Know",
            "Nottin",
            "John",
            "Snow",
            "Charizard"});
            this.team_listbox.Location = new System.Drawing.Point(35, 47);
            this.team_listbox.Name = "listBox1";
            this.team_listbox.Size = new System.Drawing.Size(174, 204);
            this.team_listbox.TabIndex = 0;
            this.team_listbox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Your Team";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(252, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 36);
            this.button1.TabIndex = 2;
            this.button1.Text = "Send Out!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.sendOut_btn);
            // 
            // TeamView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(600, 440);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.team_listbox);
            this.Name = "TeamView";
            this.Text = "TeamView";
            this.Load += new System.EventHandler(this.TeamView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox team_listbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}