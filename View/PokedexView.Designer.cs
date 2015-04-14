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
            this.pokedexViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pokedexPokemonImage = new System.Windows.Forms.PictureBox();
            this.PokemonListBox = new System.Windows.Forms.ListBox();
            this.pokedex_back_toMap_btn = new System.Windows.Forms.Button();
            this.pokedex_info = new System.Windows.Forms.TextBox();
            this.type2 = new System.Windows.Forms.PictureBox();
            this.type1 = new System.Windows.Forms.PictureBox();
            this.pokedex_info_btn = new System.Windows.Forms.Button();
            this.pokemon_kind_lbl = new System.Windows.Forms.Label();
            this.pokedex_height_lbl = new System.Windows.Forms.Label();
            this.pokedex_weight_lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pokedexViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pokedexPokemonImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.type2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.type1)).BeginInit();
            this.SuspendLayout();
            // 
            // pokedexPokemonImage
            // 
            this.pokedexPokemonImage.BackColor = System.Drawing.Color.Transparent;
            this.pokedexPokemonImage.Image = ((System.Drawing.Image)(resources.GetObject("pokedexPokemonImage.Image")));
            this.pokedexPokemonImage.Location = new System.Drawing.Point(178, 27);
            this.pokedexPokemonImage.Name = "pokedexPokemonImage";
            this.pokedexPokemonImage.Size = new System.Drawing.Size(191, 151);
            this.pokedexPokemonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pokedexPokemonImage.TabIndex = 3;
            this.pokedexPokemonImage.TabStop = false;
            // 
            // PokemonListBox
            // 
            this.PokemonListBox.BackColor = System.Drawing.Color.PeachPuff;
            this.PokemonListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PokemonListBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PokemonListBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.PokemonListBox.FormattingEnabled = true;
            this.PokemonListBox.ItemHeight = 19;
            this.PokemonListBox.Location = new System.Drawing.Point(181, 257);
            this.PokemonListBox.Name = "PokemonListBox";
            this.PokemonListBox.Size = new System.Drawing.Size(183, 133);
            this.PokemonListBox.TabIndex = 1;
            this.PokemonListBox.SelectedIndexChanged += new System.EventHandler(this.PokemonListBox_SelectedIndexChanged);
            // 
            // pokedex_back_toMap_btn
            // 
            this.pokedex_back_toMap_btn.BackColor = System.Drawing.Color.Transparent;
            this.pokedex_back_toMap_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.pokedex_back_toMap_btn.Location = new System.Drawing.Point(131, 202);
            this.pokedex_back_toMap_btn.Name = "pokedex_back_toMap_btn";
            this.pokedex_back_toMap_btn.Size = new System.Drawing.Size(75, 23);
            this.pokedex_back_toMap_btn.TabIndex = 4;
            this.pokedex_back_toMap_btn.Text = "Close";
            this.pokedex_back_toMap_btn.UseVisualStyleBackColor = false;
            this.pokedex_back_toMap_btn.Click += new System.EventHandler(this.pokedex_back_toMap_btn_Click);
            // 
            // pokedex_info
            // 
            this.pokedex_info.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pokedex_info.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pokedex_info.Location = new System.Drawing.Point(427, 12);
            this.pokedex_info.Multiline = true;
            this.pokedex_info.Name = "pokedex_info";
            this.pokedex_info.Size = new System.Drawing.Size(115, 172);
            this.pokedex_info.TabIndex = 6;
            this.pokedex_info.Text = "Bulbasaur can be seen napping in bright sunlight.\r\nThere is a seed on its back. \r" +
    "\nBy soaking up the sun\'s rays, the seed grows progressively larger.";
            // 
            // type2
            // 
            this.type2.BackColor = System.Drawing.Color.Transparent;
            this.type2.Image = ((System.Drawing.Image)(resources.GetObject("type2.Image")));
            this.type2.Location = new System.Drawing.Point(297, 149);
            this.type2.Name = "type2";
            this.type2.Size = new System.Drawing.Size(76, 35);
            this.type2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.type2.TabIndex = 7;
            this.type2.TabStop = false;
            // 
            // type1
            // 
            this.type1.BackColor = System.Drawing.Color.Transparent;
            this.type1.Image = ((System.Drawing.Image)(resources.GetObject("type1.Image")));
            this.type1.Location = new System.Drawing.Point(173, 150);
            this.type1.Name = "type1";
            this.type1.Size = new System.Drawing.Size(73, 35);
            this.type1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.type1.TabIndex = 8;
            this.type1.TabStop = false;
            // 
            // pokedex_info_btn
            // 
            this.pokedex_info_btn.BackColor = System.Drawing.Color.Transparent;
            this.pokedex_info_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.pokedex_info_btn.Location = new System.Drawing.Point(329, 202);
            this.pokedex_info_btn.Name = "pokedex_info_btn";
            this.pokedex_info_btn.Size = new System.Drawing.Size(75, 23);
            this.pokedex_info_btn.TabIndex = 9;
            this.pokedex_info_btn.Text = "Info";
            this.pokedex_info_btn.UseVisualStyleBackColor = false;
            this.pokedex_info_btn.Click += new System.EventHandler(this.pokedex_info_btn_Click);
            // 
            // pokemon_kind_lbl
            // 
            this.pokemon_kind_lbl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pokemon_kind_lbl.AutoSize = true;
            this.pokemon_kind_lbl.BackColor = System.Drawing.Color.Transparent;
            this.pokemon_kind_lbl.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pokemon_kind_lbl.ForeColor = System.Drawing.Color.White;
            this.pokemon_kind_lbl.Location = new System.Drawing.Point(180, 31);
            this.pokemon_kind_lbl.Name = "pokemon_kind_lbl";
            this.pokemon_kind_lbl.Size = new System.Drawing.Size(168, 15);
            this.pokemon_kind_lbl.TabIndex = 10;
            this.pokemon_kind_lbl.Text = "The tiny turtle Pokemon";
            this.pokemon_kind_lbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pokedex_height_lbl
            // 
            this.pokedex_height_lbl.AutoSize = true;
            this.pokedex_height_lbl.BackColor = System.Drawing.Color.Transparent;
            this.pokedex_height_lbl.ForeColor = System.Drawing.Color.White;
            this.pokedex_height_lbl.Location = new System.Drawing.Point(326, 120);
            this.pokedex_height_lbl.Name = "pokedex_height_lbl";
            this.pokedex_height_lbl.Size = new System.Drawing.Size(33, 13);
            this.pokedex_height_lbl.TabIndex = 11;
            this.pokedex_height_lbl.Text = "0.7 m";
            // 
            // pokedex_weight_lbl
            // 
            this.pokedex_weight_lbl.AutoSize = true;
            this.pokedex_weight_lbl.BackColor = System.Drawing.Color.Transparent;
            this.pokedex_weight_lbl.ForeColor = System.Drawing.Color.White;
            this.pokedex_weight_lbl.Location = new System.Drawing.Point(326, 133);
            this.pokedex_weight_lbl.Name = "pokedex_weight_lbl";
            this.pokedex_weight_lbl.Size = new System.Drawing.Size(34, 13);
            this.pokedex_weight_lbl.TabIndex = 12;
            this.pokedex_weight_lbl.Text = "10 kg";
            // 
            // PokedexView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(554, 428);
            this.Controls.Add(this.pokedex_weight_lbl);
            this.Controls.Add(this.pokedex_height_lbl);
            this.Controls.Add(this.pokemon_kind_lbl);
            this.Controls.Add(this.pokedex_info_btn);
            this.Controls.Add(this.type1);
            this.Controls.Add(this.type2);
            this.Controls.Add(this.pokedex_info);
            this.Controls.Add(this.pokedex_back_toMap_btn);
            this.Controls.Add(this.pokedexPokemonImage);
            this.Controls.Add(this.PokemonListBox);
            this.DoubleBuffered = true;
            this.Name = "PokedexView";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.PokedexView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pokedexViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pokedexPokemonImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.type2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.type1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox PokemonListBox;
        private System.Windows.Forms.BindingSource pokedexViewBindingSource;
        private System.Windows.Forms.PictureBox pokedexPokemonImage;
        private System.Windows.Forms.Button pokedex_back_toMap_btn;
        private System.Windows.Forms.TextBox pokedex_info;
        private System.Windows.Forms.PictureBox type2;
        private System.Windows.Forms.PictureBox type1;
        private System.Windows.Forms.Button pokedex_info_btn;
        private System.Windows.Forms.Label pokemon_kind_lbl;
        private System.Windows.Forms.Label pokedex_height_lbl;
        private System.Windows.Forms.Label pokedex_weight_lbl;

    }
}