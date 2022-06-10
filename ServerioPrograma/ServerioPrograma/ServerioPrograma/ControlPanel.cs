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

namespace ServerioPrograma
{
    public partial class ControlPanel : UserControl
    {
        protected Package package;
        public delegate void RemoveControl(ControlPanel userControl1);
        RemoveControl removeControl;

        public ControlPanel()
        {
            InitializeComponent();
        }

        public ControlPanel(Package package, RemoveControl removeControl)
        {
            InitializeComponent();

            this.package = package;
            nTextBox.Text = package.N.ToString();
            eTextBox.Text = package.E.ToString();
            xTextBox.Text = package.X.ToString();
            sTextBox.Text = package.S.ToString();
            messageTextBox.Text = package.Message.ToString();
            this.removeControl = removeControl;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                package.X = BigInteger.Parse(xTextBox.Text);
                package.S = BigInteger.Parse(sTextBox.Text);

                Siuntimas senderBetKitoks = new Siuntimas("127.0.0.1", 2022);
                senderBetKitoks.Send(package.ToString());

                removeControl(this);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
