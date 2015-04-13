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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PokedexView));
            this.PokemonListBox = new System.Windows.Forms.ListBox();
            this.pokedexViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pokedexToMapButton = new System.Windows.Forms.Button();
            this.pokedexPokemonImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pokedexViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pokedexPokemonImage)).BeginInit();
            this.SuspendLayout();
            // 
            // PokemonListBox
            // 
            this.PokemonListBox.DataSource = this.pokedexViewBindingSource;
            this.PokemonListBox.DisplayMember = "Location";
            this.PokemonListBox.FormattingEnabled = true;
            this.PokemonListBox.Location = new System.Drawing.Point(178, 246);
            this.PokemonListBox.Name = "PokemonListBox";
            this.PokemonListBox.Size = new System.Drawing.Size(191, 160);
            this.PokemonListBox.TabIndex = 1;
            this.PokemonListBox.ValueMember = "BackColor";
            this.PokemonListBox.SelectedIndexChanged += new System.EventHandler(this.PokemonListBox_SelectedIndexChanged);
            // 
            // pokedexToMapButton
            // 
            this.pokedexToMapButton.Location = new System.Drawing.Point(467, 383);
            this.pokedexToMapButton.Name = "pokedexToMapButton";
            this.pokedexToMapButton.Size = new System.Drawing.Size(75, 23);
            this.pokedexToMapButton.TabIndex = 2;
            this.pokedexToMapButton.Text = "To Map";
            this.pokedexToMapButton.UseVisualStyleBackColor = true;
            this.pokedexToMapButton.Click += new System.EventHandler(this.pokedexToMapButton_Click);
            // 
            // pokedexPokemonImage
            // 
            this.pokedexPokemonImage.BackColor = System.Drawing.Color.Transparent;
            this.pokedexPokemonImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pokedexPokemonImage.Image = ((System.Drawing.Image)(resources.GetObject("pokedexPokemonImage.Image")));
            this.pokedexPokemonImage.Location = new System.Drawing.Point(178, 27);
            this.pokedexPokemonImage.Name = "pokedexPokemonImage";
            this.pokedexPokemonImage.Size = new System.Drawing.Size(191, 151);
            this.pokedexPokemonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pokedexPokemonImage.TabIndex = 3;
            this.pokedexPokemonImage.TabStop = false;
            // 
            // PokedexView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(554, 428);
            this.Controls.Add(this.pokedexPokemonImage);
            this.Controls.Add(this.pokedexToMapButton);
            this.Controls.Add(this.PokemonListBox);
            this.DoubleBuffered = true;
            this.Name = "PokedexView";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.PokedexView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pokedexViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pokedexPokemonImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox PokemonListBox;
        private System.Windows.Forms.BindingSource pokedexViewBindingSource;
        private System.Windows.Forms.Button pokedexToMapButton;
        private System.Windows.Forms.PictureBox pokedexPokemonImage;

    }
}