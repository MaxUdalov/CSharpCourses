using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        public void MyMeth1(object sender, EventArgs args)
        {
            TextBox txtBox = (TextBox)sender;
            CancelEventArgs cancelArgs = (CancelEventArgs)args;
        }
    }
}
