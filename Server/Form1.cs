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
        Dictionary<string, Player> PlayersList;

        Button BtnListen;
        Button BtnSend;
        TextBox TextBoxSend;
        RichTextBox UserMesageLog;
        ListBox UsersList;

        public Form1()
        {
            InitializeComponent();
            FormClosing += Form1_FormClosing;
            PlayersList = new Dictionary<string, Player>();
            listenet = new Listener();
            ListeningThread = new Thread(listenet.StartListening);
            listenet.onPlayerAccepted += AddNewPlayer;
            FormClosing += Form1_FormClosing1;
        }

        private void SendData(Player player)
        {
            string dataToSend = TextBoxSend.Text;

            if (!string.IsNullOrWhiteSpace(dataToSend))
            {
                player.SendDataToPlayer(dataToSend);
            }
        }

        #region Events
        private void AddNewPlayer(Player player)
        {
            PlayersList.Add(player.Name, player);
            Invoke((MethodInvoker)delegate
            {
                UsersList.Items.Add(player);
            });

            player.onRecivedData += WriteText;
            player.onDisconected += DisconectWithUser;
        }

        private void DisconectWithUser(Player player)
        {
            Invoke((MethodInvoker)delegate{
                UsersList.Items.Remove(player);
            });
            PlayersList.Remove(player.Name);
            player.Dispose();
        }

        private void WriteText(Player player, string data)
        {
            Invoke((MethodInvoker) delegate {
                UserMesageLog.Text += $"\n{player.Name}: {data}";
            });
        }
        #endregion

        #region Components
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "Form1";
            this.Width = 650;
            this.Height = 550;

            BtnListen = new Button();
            BtnListen.Location = new Point(500, 450);
            BtnListen.Text = "Server Start";
            BtnListen.Click += BtnListen_Click;
            Controls.Add(BtnListen);

            BtnSend = new Button();
            BtnSend.Location = new Point(400, 450);
            BtnSend.Text = "Send data";
            BtnSend.Click += BtnSend_Click;
            Controls.Add(BtnSend);

            UserMesageLog = new RichTextBox();
            UserMesageLog.Location = new Point(20, 20);
            UserMesageLog.Width = 300;
            UserMesageLog.Height = 300;
            UserMesageLog.Enabled = false;
            Controls.Add(UserMesageLog);

            UsersList = new ListBox();
            UsersList.Location = new Point(350, 20);
            UsersList.Width = 200;
            UsersList.Height = 300;
            Controls.Add(UsersList);

            TextBoxSend = new TextBox();
            TextBoxSend.Location = new Point(20, 350);
            TextBoxSend.Width = 300;
            Controls.Add(TextBoxSend);

        }
        #endregion

        #region Basic Events
        private void BtnListen_Click(object sender, System.EventArgs e)
        {
            if(!ListeningThread.IsAlive)
                ListeningThread.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            listenet.ListiningSocket.Close();
            MessageBox.Show("Connection End.");
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            string selectedUser = UsersList.SelectedItem.ToString();
            SendData(PlayersList[selectedUser]);
        }

        private void Form1_FormClosing1(object sender, FormClosingEventArgs e)
        {
            listenet.Dispose();

            foreach(var plyers in PlayersList)
            {
                plyers.Value.Dispose();
            }
        }
        #endregion
    }
}
