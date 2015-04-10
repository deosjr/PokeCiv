using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public virtual void UpdatePlayer() { }

        public virtual int selectMove() { return 0; }
    }
}
