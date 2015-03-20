namespace PokeCiv.View
{
    partial class Combat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Combat));
            this.backImageBattlePokemon = new System.Windows.Forms.PictureBox();
            this.frontImageBattlePokemon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.backImageBattlePokemon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontImageBattlePokemon)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.backImageBattlePokemon.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.backImageBattlePokemon.Location = new System.Drawing.Point(-15, 144);
            this.backImageBattlePokemon.Name = "pictureBox1";
            this.backImageBattlePokemon.Size = new System.Drawing.Size(179, 121);
            this.backImageBattlePokemon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.backImageBattlePokemon.TabIndex = 0;
            this.backImageBattlePokemon.TabStop = false;
            // 
            // pictureBox2
            // 
            this.frontImageBattlePokemon.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.frontImageBattlePokemon.Location = new System.Drawing.Point(131, 2);
            this.frontImageBattlePokemon.Name = "pictureBox2";
            this.frontImageBattlePokemon.Size = new System.Drawing.Size(157, 124);
            this.frontImageBattlePokemon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.frontImageBattlePokemon.TabIndex = 1;
            this.frontImageBattlePokemon.TabStop = false;
            // 
            // Combat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.frontImageBattlePokemon);
            this.Controls.Add(this.backImageBattlePokemon);
            this.Name = "Combat";
            this.Text = "Combat";
            ((System.ComponentModel.ISupportInitialize)(this.backImageBattlePokemon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontImageBattlePokemon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox backImageBattlePokemon;
        private System.Windows.Forms.PictureBox frontImageBattlePokemon;
    }
}