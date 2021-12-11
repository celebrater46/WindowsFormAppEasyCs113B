using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppEasyCs113B
{
    public partial class Form1 : Form
    {
        public static string HOST = "localhost";
        public static int PORT = 10000;
        private TextBox tb;
        private Button bt;
        
        public Form1()
        {
            InitializeComponent();
            this.Text = "Connect to the server";
            this.Width = 300;
            this.Height = 300;

            tb = new TextBox();

            tb.Multiline = true;
            tb.ScrollBars = ScrollBars.Vertical;
            tb.Height = 150;
            tb.Dock = DockStyle.Top;

            bt = new Button();
            bt.Text = "Connect";
            bt.Dock = DockStyle.Bottom;

            tb.Parent = this;
            bt.Parent = this;

            bt.Click += new EventHandler(BtClick);
        }

        public void BtClick(Object sender, EventArgs e)
        {
            TcpClient tc = new TcpClient(HOST, PORT);

            StreamReader sr = new StreamReader(tc.GetStream());
            String str = sr.ReadLine();
            tb.Text = str;

            sr.Close();
            tc.Close();
        }
    }
}