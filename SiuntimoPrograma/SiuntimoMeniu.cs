using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiuntimoPrograma
{
    public partial class SiuntimoMeniu : Form
    {
        public SiuntimoMeniu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Text = "Sender - Creating package";
                Package package = new Package(textBox1.Text);
                this.Text = "Sender - Sending package";
                Siuntimas senderBetKitoks = new Siuntimas();
                senderBetKitoks.Send(package.ToString());
                this.Text = "Sender - Package sent";
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
