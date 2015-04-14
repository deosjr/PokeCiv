using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PokeCiv.Model.World.Tiles;

namespace PokeCiv.View
{
    public partial class IView : Form
    {
        public IView()
        {
            InitializeComponent();
        }

        public void hideView()
        {
            this.Close();
        }

        public void showView()
        {
            this.Show();
        }

        public void closeView()
        {
            this.Close();
        }

        public virtual void message(string msg) { }

        //TODO: place as mutch GENERIC keyboard and mouse events here
        private void IView_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("iView keyhandler");
        }

        private void IView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q)
            {
                //Control.switchFromMapToPokeDex();
            }
        }
    }
}
