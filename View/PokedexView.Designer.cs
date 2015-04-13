namespace PokeCiv.View
{
    partial class PokedexView
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
            this.components = new System.ComponentModel.Container();
            this.PokemonListBox = new System.Windows.Forms.ListBox();
            this.pokedexViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pokedexToMapButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pokedexViewBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PokemonListBox
            // 
            this.PokemonListBox.DataSource = this.pokedexViewBindingSource;
            this.PokemonListBox.DisplayMember = "Location";
            this.PokemonListBox.FormattingEnabled = true;
            this.PokemonListBox.Location = new System.Drawing.Point(12, 12);
            this.PokemonListBox.Name = "PokemonListBox";
            this.PokemonListBox.Size = new System.Drawing.Size(120, 381);
            this.PokemonListBox.TabIndex = 1;
            this.PokemonListBox.ValueMember = "BackColor";
            // 
            // pokedexToMapButton
            // 
            this.pokedexToMapButton.Location = new System.Drawing.Point(467, 370);
            this.pokedexToMapButton.Name = "pokedexToMapButton";
            this.pokedexToMapButton.Size = new System.Drawing.Size(75, 23);
            this.pokedexToMapButton.TabIndex = 2;
            this.pokedexToMapButton.Text = "To Map";
            this.pokedexToMapButton.UseVisualStyleBackColor = true;
            this.pokedexToMapButton.Click += new System.EventHandler(this.pokedexToMapButton_Click);
            // 
            // PokedexView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(554, 428);
            this.Controls.Add(this.pokedexToMapButton);
            this.Controls.Add(this.PokemonListBox);
            this.Name = "PokedexView";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.PokedexView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pokedexViewBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox PokemonListBox;
        private System.Windows.Forms.BindingSource pokedexViewBindingSource;
        private System.Windows.Forms.Button pokedexToMapButton;

    }
}