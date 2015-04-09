namespace PokeCiv.View
{
    partial class MapRenderer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapRenderer));
            this.pb_player = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.mapBackgroundCanvas = new System.Windows.Forms.PictureBox();
            this.pb_playerFloor = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapBackgroundCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_playerFloor)).BeginInit();
            this.SuspendLayout();
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(121, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "show_Worldmap";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.test_btn_show_Worldmap);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Battle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.test_btn_switch2Battle);
            // 
            // mapBackgroundCanvas
            // 
            this.mapBackgroundCanvas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.mapBackgroundCanvas.Location = new System.Drawing.Point(0, 0);
            this.mapBackgroundCanvas.Name = "mapBackgroundCanvas";
            this.mapBackgroundCanvas.Size = new System.Drawing.Size(441, 278);
            this.mapBackgroundCanvas.TabIndex = 0;
            this.mapBackgroundCanvas.TabStop = false;
            // 
            // pb_playerFloor
            // 
            this.pb_playerFloor.Image = ((System.Drawing.Image)(resources.GetObject("pb_playerFloor.Image")));
            this.pb_playerFloor.Location = new System.Drawing.Point(108, 110);
            this.pb_playerFloor.Margin = new System.Windows.Forms.Padding(0);
            this.pb_playerFloor.Name = "pb_playerFloor";
            this.pb_playerFloor.Size = new System.Drawing.Size(50, 50);
            this.pb_playerFloor.TabIndex = 4;
            this.pb_playerFloor.TabStop = false;
            // 
            // MapRenderer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 466);
            this.Controls.Add(this.pb_playerFloor);
            this.Controls.Add(this.pb_player);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mapBackgroundCanvas);
            this.Name = "MapRenderer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PokeCiv";
            this.Load += new System.EventHandler(this.MapRenderer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapBackgroundCanvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_playerFloor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox mapBackgroundCanvas;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pb_player;
        private System.Windows.Forms.PictureBox pb_playerFloor;
    }
}