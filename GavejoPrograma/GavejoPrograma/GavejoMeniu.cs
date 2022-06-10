using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GavejoPrograma
{
    public partial class GavejoMeniu : Form
    {
        public GavejoMeniu()
        {
            InitializeComponent();
            Gavejas receiver = new Gavejas(AddPackages, ShowMessages, "127.0.0.1", 2022);
            Task task = Task.Run(() => receiver.Start());

        }

        public void AddPackages(Package package)
        {
            Invoke((MethodInvoker)(() =>
            {
                flowLayoutPanel1.Controls.Add(new ControlPanel(package, RemovePackage));
            }));
        }

        public void ShowMessages(string message)
        {
            Invoke((MethodInvoker)(() =>
            {
                MessageBox.Show(message);
            }));
        }

        public void RemovePackage(ControlPanel userControl1)
        {
            Invoke((MethodInvoker)(() =>
            {
                flowLayoutPanel1.Controls.Remove(userControl1);
            }));
        }
    }
}
