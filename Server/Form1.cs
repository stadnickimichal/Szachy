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

namespace Server
{
    public partial class Form1 : Form
    {
        Listener listenet;
        Thread ListeningThread;

        public Form1()
        {
            InitializeComponent();
            FormClosing += Form1_FormClosing;
            listenet = new Listener();
            ListeningThread = new Thread(listenet.StartListening);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "Form1";
            this.Width = 450;
            this.Height = 450;

            Button BtnListen = new Button();
            BtnListen.Location = new Point(300, 350);
            BtnListen.Text = "Server Start";
            BtnListen.Click += BtnListen_Click;

            Controls.Add(BtnListen);
        }
        #region Eventy
        private void BtnListen_Click(object sender, System.EventArgs e)
        {
            ListeningThread.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            listenet.ListiningSocket.Close();
            MessageBox.Show("Connection End.");
        }
#endregion
    }
}
