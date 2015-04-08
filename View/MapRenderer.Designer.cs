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
            this.mapBackgroundCanvas = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.mapBackgroundCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // mapBackgroundCanvas
            // 
            this.mapBackgroundCanvas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.mapBackgroundCanvas.Location = new System.Drawing.Point(0, 0);
            this.mapBackgroundCanvas.Name = "mapBackgroundCanvas";
            this.mapBackgroundCanvas.Size = new System.Drawing.Size(126, 112);
            this.mapBackgroundCanvas.TabIndex = 0;
            this.mapBackgroundCanvas.TabStop = false;
            // 
            // MapRenderer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 449);
            this.Controls.Add(this.mapBackgroundCanvas);
            this.Name = "MapRenderer";
            this.Text = "Route101";
            this.Load += new System.EventHandler(this.MapRenderer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mapBackgroundCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox mapBackgroundCanvas;
    }
}