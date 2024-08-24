using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using send;

namespace chatify
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UdpClient udpClient = new UdpClient();
            Send.chat(8888, "127.0.0.1", udpClient, textBox1.Text, "123");
            //get.GetData(0, 30, 8888, "127.0.0.1");
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.Visible)
            {
                this.WindowState = FormWindowState.Minimized;
                this.mainNotifyIcon.Visible = true;
                this.Hide();
            }
            else
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
                this.Activate();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //ȡ��"�رմ���"�¼�
                e.Cancel = true; // ȡ���رմ��� 

                //ʹ�ر�ʱ���������½���С��Ч��
                this.WindowState = FormWindowState.Minimized;
                this.mainNotifyIcon.Visible = true;
                //this.m_cartoonForm.CartoonClose();
                this.Hide();
                return;
            }
        }

        private void ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.mainNotifyIcon.Visible = true;
            this.Hide();
        }

        private void ���ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.mainNotifyIcon.Visible = true;
            this.Show();
        }

        private void �˳�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("��ȷ��Ҫ�˳���", "ϵͳ��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {

                this.mainNotifyIcon.Visible = false;
                this.Close();
                this.Dispose();
                System.Environment.Exit(System.Environment.ExitCode);

            }
        }




        private void mainNotifyIcon_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // �л������ڵ���ʾ״̬
                if (this.Visible)
                {
                    this.Hide();
                }
                else
                {
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    this.Activate();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            UdpClient udpClient = new UdpClient();
            int mx = get.GetLength(8888, "127.0.0.1", udpClient);
            int num1,num2;
            num1 = int.Parse(textBox2.Text);
            num2 = int.Parse(textBox3.Text);
            if (num2 < num1)
            {
                MessageBox.Show("��һ�������ܴ��ڵڶ�����");
            }
            else if (num1 == num2)
            {
                MessageBox.Show("�������������");
            } 
            else if(num2 > mx)
            {
                MessageBox.Show("�����������");
            }
            else if(num1 < 0 || num2 < 0)
            {
                MessageBox.Show("������С��0");
            }
            else
            {
                get.GetData(num1, num2, 8888, "127.0.0.1");
                MessageBox.Show("��ȡ�ɹ�\n������data.txt�ļ���");
            }
        }
    }
}
