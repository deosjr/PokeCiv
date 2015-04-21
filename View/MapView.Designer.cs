namespace PokeCiv.View
{
    partial class MapView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapView));
            this.start_menu_panel = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pb_playerFloor = new System.Windows.Forms.PictureBox();
            this.pb_player = new System.Windows.Forms.PictureBox();
            this.mapBackgroundCanvas = new System.Windows.Forms.PictureBox();
            this.start_menu_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_playerFloor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapBackgroundCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // start_menu_panel
            // 
            this.start_menu_panel.BackColor = System.Drawing.Color.DarkTurquoise;
            this.start_menu_panel.Controls.Add(this.button8);
            this.start_menu_panel.Controls.Add(this.button6);
            this.start_menu_panel.Controls.Add(this.button5);
            this.start_menu_panel.Controls.Add(this.button4);
            this.start_menu_panel.Controls.Add(this.button3);
            this.start_menu_panel.Controls.Add(this.button2);
            this.start_menu_panel.Controls.Add(this.button1);
            this.start_menu_panel.Location = new System.Drawing.Point(410, 12);
            this.start_menu_panel.Name = "start_menu_panel";
            this.start_menu_panel.Size = new System.Drawing.Size(178, 337);
            this.start_menu_panel.TabIndex = 5;
            this.start_menu_panel.TabStop = true;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.White;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(4, 293);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(169, 39);
            this.button8.TabIndex = 7;
            this.button8.Text = "Exit";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.close_menu_button);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.White;
            this.button6.Enabled = false;
            this.button6.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(3, 245);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(170, 42);
            this.button6.TabIndex = 5;
            this.button6.Text = "Options";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.White;
            this.button5.Enabled = false;
            this.button5.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(3, 197);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(170, 42);
            this.button5.TabIndex = 4;
            this.button5.Text = "Save";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.Enabled = false;
            this.button4.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(3, 149);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(170, 42);
            this.button4.TabIndex = 3;
            this.button4.Text = "Name";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.Enabled = false;
            this.button3.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(3, 101);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(170, 42);
            this.button3.TabIndex = 2;
            this.button3.Text = "Bag";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(3, 53);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(170, 42);
            this.button2.TabIndex = 1;
            this.button2.Text = "Pokemon";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 42);
            this.button1.TabIndex = 0;
            this.button1.Text = "Pokedex";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.startmenu_pokedex_btn);
            // 
            // pb_playerFloor
            // 
            this.pb_playerFloor.BackColor = System.Drawing.Color.LightGreen;
            this.pb_playerFloor.Location = new System.Drawing.Point(108, 110);
            this.pb_playerFloor.Margin = new System.Windows.Forms.Padding(0);
            this.pb_playerFloor.Name = "pb_playerFloor";
            this.pb_playerFloor.Size = new System.Drawing.Size(50, 50);
            this.pb_playerFloor.TabIndex = 4;
            this.pb_playerFloor.TabStop = false;
            // 
            // pb_player
            // 
            this.pb_player.BackColor = System.Drawing.Color.Transparent;
            this.pb_player.Image = ((System.Drawing.Image)(resources.GetObject("pb_player.Image")));
            this.pb_player.Location = new System.Drawing.Point(179, 110);
            this.pb_player.Margin = new System.Windows.Forms.Padding(0);
            this.pb_player.Name = "pb_player";
            this.pb_player.Size = new System.Drawing.Size(50, 50);
            this.pb_player.TabIndex = 3;
            this.pb_player.TabStop = false;
            // 
            // mapBackgroundCanvas
            // 
            this.mapBackgroundCanvas.BackColor = System.Drawing.Color.LightGreen;
            this.mapBackgroundCanvas.Location = new System.Drawing.Point(0, 0);
            this.mapBackgroundCanvas.Name = "mapBackgroundCanvas";
            this.mapBackgroundCanvas.Size = new System.Drawing.Size(349, 278);
            this.mapBackgroundCanvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.mapBackgroundCanvas.TabIndex = 0;
            this.mapBackgroundCanvas.TabStop = false;
            // 
            // MapView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(600, 440);
            this.Controls.Add(this.start_menu_panel);
            this.Controls.Add(this.pb_playerFloor);
            this.Controls.Add(this.pb_player);
            this.Controls.Add(this.mapBackgroundCanvas);
            this.Name = "MapView";
            this.Text = "PokeCiv";
            this.Load += new System.EventHandler(this.MapView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MapView_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MapView_KeyUp);
            this.start_menu_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_playerFloor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapBackgroundCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox mapBackgroundCanvas;
        private System.Windows.Forms.PictureBox pb_player;
        private System.Windows.Forms.PictureBox pb_playerFloor;
        private System.Windows.Forms.Panel start_menu_panel;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button8;
    }
}