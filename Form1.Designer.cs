namespace AnhkController
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
                IpAddressTextBox.TextChanged -= IpAddressTextBox_TextChanged;
                PortTextBox.TextChanged -= PortTextBox_TextChanged;
                components.Dispose();
            }
            else if(disposing)
            {
                IpAddressTextBox.TextChanged -= IpAddressTextBox_TextChanged;
                PortTextBox.TextChanged -= PortTextBox_TextChanged;
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            groupBox3 = new GroupBox();
            ClientsLabel = new Label();
            ServerStatusIndicatorLabal = new Label();
            label3 = new Label();
            groupBox2 = new GroupBox();
            ConsoleTextBox = new TextBox();
            groupBox1 = new GroupBox();
            IpAddressTextBox = new TextBox();
            PortTextBox = new TextBox();
            StartServerButton = new Button();
            label2 = new Label();
            label1 = new Label();
            tabPage2 = new TabPage();
            groupBox4 = new GroupBox();
            listView1 = new ListView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            systemToolStripMenuItem = new ToolStripMenuItem();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox4.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(357, 238);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(groupBox3);
            tabPage1.Controls.Add(groupBox2);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(349, 210);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Console";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(ClientsLabel);
            groupBox3.Controls.Add(ServerStatusIndicatorLabal);
            groupBox3.Controls.Add(label3);
            groupBox3.Location = new Point(3, 166);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(343, 41);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Stats";
            // 
            // ClientsLabel
            // 
            ClientsLabel.AutoSize = true;
            ClientsLabel.Location = new Point(129, 19);
            ClientsLabel.Name = "ClientsLabel";
            ClientsLabel.Size = new Size(55, 15);
            ClientsLabel.TabIndex = 2;
            ClientsLabel.Text = "Clients: 0";
            // 
            // ServerStatusIndicatorLabal
            // 
            ServerStatusIndicatorLabal.AutoSize = true;
            ServerStatusIndicatorLabal.ForeColor = Color.Red;
            ServerStatusIndicatorLabal.Location = new Point(80, 19);
            ServerStatusIndicatorLabal.Name = "ServerStatusIndicatorLabal";
            ServerStatusIndicatorLabal.Size = new Size(43, 15);
            ServerStatusIndicatorLabal.TabIndex = 1;
            ServerStatusIndicatorLabal.Text = "Offline";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 19);
            label3.Name = "label3";
            label3.Size = new Size(77, 15);
            label3.TabIndex = 0;
            label3.Text = "Server Status:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(ConsoleTextBox);
            groupBox2.Location = new Point(3, 56);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(343, 104);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Console";
            // 
            // ConsoleTextBox
            // 
            ConsoleTextBox.Location = new Point(5, 22);
            ConsoleTextBox.Multiline = true;
            ConsoleTextBox.Name = "ConsoleTextBox";
            ConsoleTextBox.ScrollBars = ScrollBars.Both;
            ConsoleTextBox.Size = new Size(332, 76);
            ConsoleTextBox.TabIndex = 0;
            ConsoleTextBox.Text = "Ready to start...";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(IpAddressTextBox);
            groupBox1.Controls.Add(PortTextBox);
            groupBox1.Controls.Add(StartServerButton);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(343, 47);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Controls";
            // 
            // IpAddressTextBox
            // 
            IpAddressTextBox.Location = new Point(70, 16);
            IpAddressTextBox.Name = "IpAddressTextBox";
            IpAddressTextBox.Size = new Size(100, 23);
            IpAddressTextBox.TabIndex = 4;
            IpAddressTextBox.Text = "127.0.0.1";
            // 
            // PortTextBox
            // 
            PortTextBox.Location = new Point(214, 16);
            PortTextBox.Name = "PortTextBox";
            PortTextBox.Size = new Size(42, 23);
            PortTextBox.TabIndex = 3;
            PortTextBox.Text = "65535";
            // 
            // StartServerButton
            // 
            StartServerButton.Location = new Point(262, 16);
            StartServerButton.Name = "StartServerButton";
            StartServerButton.Size = new Size(75, 23);
            StartServerButton.TabIndex = 2;
            StartServerButton.Text = "Start Server";
            StartServerButton.UseVisualStyleBackColor = true;
            StartServerButton.Click += StartServerButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(176, 19);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 1;
            label2.Text = "Port:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 19);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 0;
            label1.Text = "IP Address:";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(groupBox4);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(349, 210);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Clients";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(listView1);
            groupBox4.Location = new Point(3, 3);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(343, 207);
            groupBox4.TabIndex = 0;
            groupBox4.TabStop = false;
            groupBox4.Text = "Clients";
            // 
            // listView1
            // 
            listView1.ContextMenuStrip = contextMenuStrip1;
            listView1.Location = new Point(6, 22);
            listView1.Name = "listView1";
            listView1.Size = new Size(331, 179);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { systemToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(113, 26);
            // 
            // systemToolStripMenuItem
            // 
            systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            systemToolStripMenuItem.Size = new Size(112, 22);
            systemToolStripMenuItem.Text = "System";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(357, 238);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Anhk Controller";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabPage2.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private GroupBox groupBox3;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private TextBox IpAddressTextBox;
        private TextBox PortTextBox;
        private Button StartServerButton;
        private Label label2;
        private Label label1;
        private TabPage tabPage2;
        private Label ClientsLabel;
        private Label ServerStatusIndicatorLabal;
        private Label label3;
        private TextBox ConsoleTextBox;
        private GroupBox groupBox4;
        private ListView listView1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem systemToolStripMenuItem;
    }
}
