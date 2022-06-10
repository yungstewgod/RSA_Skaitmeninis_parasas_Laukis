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

namespace GavejoPrograma
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

        private void confirmButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (RSA.ValidateSignature(package.S, package.E, package.N, package.X))
                {
                    confirmButton.Text = "Valid";
                    confirmButton.Enabled = false;
                    throw new Exception("Password is valid");
                }
                else
                {
                    confirmButton.Text = "Invalid";
                    confirmButton.Enabled = false;
                    throw new Exception("Password is invalid");
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}

