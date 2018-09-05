using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestAsync
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PutThreadSleep();
            MessageBox.Show("I am back");
        }


        void PutThreadSleep()
        {
            Thread.Sleep(5000);
        }

        async Task PutTaskDelay()
        {
            await Task.Delay(5000);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await PutTaskDelay();
            MessageBox.Show("I am back");
        }
    }
}
