namespace chatify
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            textBox1 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            mainNotifyIcon = new NotifyIcon(components);
            mainNotifyContextMenuStrip = new ContextMenuStrip(components);
            最ToolStripMenuItem = new ToolStripMenuItem();
            最大化ToolStripMenuItem = new ToolStripMenuItem();
            退出ToolStripMenuItem = new ToolStripMenuItem();
            label2 = new Label();
            bindingSource1 = new BindingSource(components);
            textBox2 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            button4 = new Button();
            mainNotifyContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(418, 148);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(236, 52);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 15F);
            label1.Location = new Point(217, 154);
            label1.Name = "label1";
            label1.Size = new Size(195, 46);
            label1.TabIndex = 1;
            label1.Text = "发送数据：";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(833, 148);
            button1.Name = "button1";
            button1.Size = new Size(140, 55);
            button1.TabIndex = 2;
            button1.Text = "发送";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // mainNotifyIcon
            // 
            mainNotifyIcon.ContextMenuStrip = mainNotifyContextMenuStrip;
            mainNotifyIcon.Icon = (Icon)resources.GetObject("mainNotifyIcon.Icon");
            mainNotifyIcon.Text = "chatify";
            mainNotifyIcon.Visible = true;
            mainNotifyIcon.MouseClick += mainNotifyIcon_MouseClick_1;
            mainNotifyIcon.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // mainNotifyContextMenuStrip
            // 
            mainNotifyContextMenuStrip.ImageScalingSize = new Size(28, 28);
            mainNotifyContextMenuStrip.Items.AddRange(new ToolStripItem[] { 最ToolStripMenuItem, 最大化ToolStripMenuItem, 退出ToolStripMenuItem });
            mainNotifyContextMenuStrip.Name = "mainNotifyContextMenuStrip";
            mainNotifyContextMenuStrip.Size = new Size(148, 106);
            // 
            // 最ToolStripMenuItem
            // 
            最ToolStripMenuItem.Name = "最ToolStripMenuItem";
            最ToolStripMenuItem.Size = new Size(147, 34);
            最ToolStripMenuItem.Text = "最小化";
            最ToolStripMenuItem.Click += 最ToolStripMenuItem_Click;
            // 
            // 最大化ToolStripMenuItem
            // 
            最大化ToolStripMenuItem.Name = "最大化ToolStripMenuItem";
            最大化ToolStripMenuItem.Size = new Size(147, 34);
            最大化ToolStripMenuItem.Text = "最大化";
            最大化ToolStripMenuItem.Click += 最大化ToolStripMenuItem_Click;
            // 
            // 退出ToolStripMenuItem
            // 
            退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            退出ToolStripMenuItem.Size = new Size(147, 34);
            退出ToolStripMenuItem.Text = "退出";
            退出ToolStripMenuItem.Click += 退出ToolStripMenuItem_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 15F);
            label2.Location = new Point(206, 306);
            label2.Name = "label2";
            label2.Size = new Size(195, 46);
            label2.TabIndex = 3;
            label2.Text = "获取数据：";
            label2.Click += label2_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(418, 306);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(236, 52);
            textBox2.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 15F);
            label3.Location = new Point(686, 312);
            label3.Name = "label3";
            label3.Size = new Size(35, 46);
            label3.TabIndex = 5;
            label3.Text = "-";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(752, 306);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(236, 52);
            textBox3.TabIndex = 6;
            // 
            // button4
            // 
            button4.Location = new Point(1111, 308);
            button4.Name = "button4";
            button4.Size = new Size(140, 55);
            button4.TabIndex = 9;
            button4.Text = "获取";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1727, 786);
            Controls.Add(button4);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "chatify";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            mainNotifyContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private NotifyIcon mainNotifyIcon;
        private ContextMenuStrip mainNotifyContextMenuStrip;
        private ToolStripMenuItem 最ToolStripMenuItem;
        private ToolStripMenuItem 最大化ToolStripMenuItem;
        private ToolStripMenuItem 退出ToolStripMenuItem;
        private Label label2;
        private BindingSource bindingSource1;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox3;
        private Button button4;
    }
}
