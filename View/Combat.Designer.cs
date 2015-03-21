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
            this.backPokemonName = new System.Windows.Forms.Label();
            this.fontPokemonName = new System.Windows.Forms.Label();
            this.frontPokemonLevel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BackPokemonHPBar = new System.Windows.Forms.ProgressBar();
            this.FrontPokemonHPBar = new System.Windows.Forms.ProgressBar();
            this.BackPokemonXPBar = new System.Windows.Forms.ProgressBar();
            this.FrontPokemonXPBar = new System.Windows.Forms.ProgressBar();
            this.backPokemonLevel = new System.Windows.Forms.Label();
            this.BackPokemonHPLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.backImageBattlePokemon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontImageBattlePokemon)).BeginInit();
            this.SuspendLayout();
            // 
            // backImageBattlePokemon
            // 
            this.backImageBattlePokemon.Image = ((System.Drawing.Image)(resources.GetObject("backImageBattlePokemon.Image")));
            this.backImageBattlePokemon.Location = new System.Drawing.Point(5, 145);
            this.backImageBattlePokemon.Name = "backImageBattlePokemon";
            this.backImageBattlePokemon.Size = new System.Drawing.Size(179, 121);
            this.backImageBattlePokemon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.backImageBattlePokemon.TabIndex = 0;
            this.backImageBattlePokemon.TabStop = false;
            // 
            // frontImageBattlePokemon
            // 
            this.frontImageBattlePokemon.Image = ((System.Drawing.Image)(resources.GetObject("frontImageBattlePokemon.Image")));
            this.frontImageBattlePokemon.Location = new System.Drawing.Point(407, 12);
            this.frontImageBattlePokemon.Name = "frontImageBattlePokemon";
            this.frontImageBattlePokemon.Size = new System.Drawing.Size(157, 124);
            this.frontImageBattlePokemon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.frontImageBattlePokemon.TabIndex = 1;
            this.frontImageBattlePokemon.TabStop = false;
            // 
            // backPokemonName
            // 
            this.backPokemonName.AutoSize = true;
            this.backPokemonName.Location = new System.Drawing.Point(2, 113);
            this.backPokemonName.Name = "backPokemonName";
            this.backPokemonName.Size = new System.Drawing.Size(54, 13);
            this.backPokemonName.TabIndex = 2;
            this.backPokemonName.Text = "Bulbasaur";
            // 
            // fontPokemonName
            // 
            this.fontPokemonName.AutoSize = true;
            this.fontPokemonName.Location = new System.Drawing.Point(213, 23);
            this.fontPokemonName.Name = "fontPokemonName";
            this.fontPokemonName.Size = new System.Drawing.Size(46, 13);
            this.fontPokemonName.TabIndex = 3;
            this.fontPokemonName.Text = "Ursaring";
            // 
            // frontPokemonLevel
            // 
            this.frontPokemonLevel.AutoSize = true;
            this.frontPokemonLevel.Location = new System.Drawing.Point(367, 23);
            this.frontPokemonLevel.Name = "frontPokemonLevel";
            this.frontPokemonLevel.Size = new System.Drawing.Size(36, 13);
            this.frontPokemonLevel.TabIndex = 5;
            this.frontPokemonLevel.Text = "Lvl 28";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(253, 280);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 61);
            this.button1.TabIndex = 6;
            this.button1.Text = "Kill";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(407, 280);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 61);
            this.button2.TabIndex = 7;
            this.button2.Text = "Rape";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(253, 347);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(148, 61);
            this.button3.TabIndex = 8;
            this.button3.Text = "murder";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(407, 347);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(148, 61);
            this.button4.TabIndex = 9;
            this.button4.Text = "maim";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 290);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 32);
            this.label1.TabIndex = 10;
            this.label1.Text = "What will";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 347);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 32);
            this.label2.TabIndex = 11;
            this.label2.Text = "BULBASAUR do?";
            // 
            // BackPokemonHPBar
            // 
            this.BackPokemonHPBar.Location = new System.Drawing.Point(5, 129);
            this.BackPokemonHPBar.Name = "BackPokemonHPBar";
            this.BackPokemonHPBar.Size = new System.Drawing.Size(187, 10);
            this.BackPokemonHPBar.TabIndex = 12;
            this.BackPokemonHPBar.Value = 100;
            // 
            // FrontPokemonHPBar
            // 
            this.FrontPokemonHPBar.Location = new System.Drawing.Point(216, 39);
            this.FrontPokemonHPBar.Name = "FrontPokemonHPBar";
            this.FrontPokemonHPBar.Size = new System.Drawing.Size(187, 10);
            this.FrontPokemonHPBar.TabIndex = 13;
            this.FrontPokemonHPBar.Value = 100;
            // 
            // BackPokemonXPBar
            // 
            this.BackPokemonXPBar.BackColor = System.Drawing.SystemColors.MenuText;
            this.BackPokemonXPBar.Location = new System.Drawing.Point(5, 272);
            this.BackPokemonXPBar.Name = "BackPokemonXPBar";
            this.BackPokemonXPBar.Size = new System.Drawing.Size(180, 10);
            this.BackPokemonXPBar.TabIndex = 14;
            this.BackPokemonXPBar.Value = 14;
            // 
            // FrontPokemonXPBar
            // 
            this.FrontPokemonXPBar.Location = new System.Drawing.Point(407, 129);
            this.FrontPokemonXPBar.Name = "FrontPokemonXPBar";
            this.FrontPokemonXPBar.Size = new System.Drawing.Size(157, 10);
            this.FrontPokemonXPBar.TabIndex = 15;
            this.FrontPokemonXPBar.Value = 45;
            // 
            // backPokemonLevel
            // 
            this.backPokemonLevel.AutoSize = true;
            this.backPokemonLevel.Location = new System.Drawing.Point(162, 113);
            this.backPokemonLevel.Name = "backPokemonLevel";
            this.backPokemonLevel.Size = new System.Drawing.Size(30, 13);
            this.backPokemonLevel.TabIndex = 4;
            this.backPokemonLevel.Text = "Lvl 5";
            // 
            // BackPokemonHPLabel
            // 
            this.BackPokemonHPLabel.AutoSize = true;
            this.BackPokemonHPLabel.Location = new System.Drawing.Point(135, 145);
            this.BackPokemonHPLabel.Name = "BackPokemonHPLabel";
            this.BackPokemonHPLabel.Size = new System.Drawing.Size(57, 13);
            this.BackPokemonHPLabel.TabIndex = 16;
            this.BackPokemonHPLabel.Text = "HP: 20/20";
            // 
            // Combat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 421);
            this.Controls.Add(this.BackPokemonHPLabel);
            this.Controls.Add(this.FrontPokemonXPBar);
            this.Controls.Add(this.BackPokemonXPBar);
            this.Controls.Add(this.FrontPokemonHPBar);
            this.Controls.Add(this.BackPokemonHPBar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.frontPokemonLevel);
            this.Controls.Add(this.backPokemonLevel);
            this.Controls.Add(this.fontPokemonName);
            this.Controls.Add(this.backPokemonName);
            this.Controls.Add(this.frontImageBattlePokemon);
            this.Controls.Add(this.backImageBattlePokemon);
            this.Name = "Combat";
            this.Text = "Combat";
            ((System.ComponentModel.ISupportInitialize)(this.backImageBattlePokemon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontImageBattlePokemon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox backImageBattlePokemon;
        private System.Windows.Forms.PictureBox frontImageBattlePokemon;
        private System.Windows.Forms.Label backPokemonName;
        private System.Windows.Forms.Label fontPokemonName;
        private System.Windows.Forms.Label frontPokemonLevel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar BackPokemonHPBar;
        private System.Windows.Forms.ProgressBar FrontPokemonHPBar;
        private System.Windows.Forms.ProgressBar BackPokemonXPBar;
        private System.Windows.Forms.ProgressBar FrontPokemonXPBar;
        private System.Windows.Forms.Label backPokemonLevel;
        private System.Windows.Forms.Label BackPokemonHPLabel;
    }
}