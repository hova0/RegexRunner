/*
 * 
 * This software is licensed under the LGPL.  Please see LICENSE.TXT for more information
 * 
 * -Jared McManus
 * 
 */
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text.RegularExpressions;
namespace RegExHelper
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox input_textbox;
		private System.Windows.Forms.TextBox output_textbox;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Splitter splitter_main;
		private System.Windows.Forms.Panel pane2;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.ComboBox regex_replace;
		private System.Windows.Forms.Label label_message;
		private System.Windows.Forms.CheckBox checkbox_multiLine;
		private System.Windows.Forms.CheckBox checkBox_singleline;
		private System.Windows.Forms.ComboBox presets_box;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox regex_match;
		/*private bool renameonly = false;
		private string recursedirectory;
		private string recursefile;
		private bool recurseflag = false;*/
		
		//private NotifyIcon m_myTray;
		private ContextMenu m_menu;  
		protected class regex_option 
		{
			public string regex_match;
			public string regex_replace;
			public string regex_display;
		}
		protected System.Collections.Generic.List<regex_option> regexes;
		private System.Windows.Forms.CheckBox match_mode;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private CheckBox casecheckbox;
        private CheckBox IgnoreDups;
        private ToolTip toolTip1;
        private Button button6;
        private Button button8;
        private Button button7;
        private Panel panel9;
        private Panel panel10;
        private IContainer components;
		
		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//

			InitializeComponent();
			try {
            //m_myTray = new NotifyIcon();
            //m_myTray.Text = "Regex Runner";
            //m_myTray.Visible = true;
            //m_myTray.Icon = new Icon(GetType(), "regex_small.ico");
			m_menu = new ContextMenu(); 
			m_menu.MenuItems.Add(0, 
				new MenuItem("Show",new System.EventHandler(Show_Click))); 
			m_menu.MenuItems.Add(1, 
				new MenuItem("Hide",new System.EventHandler(Hide_Click))); 
			m_menu.MenuItems.Add(2, 
				new MenuItem("Exit",new System.EventHandler(Exit_Click)));
            //m_myTray.ContextMenu = m_menu;
            //this.m_myTray.Click += new EventHandler(m_myTray_Click);

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			presets_box.Items.Add("No Preset");
			regexes = new System.Collections.Generic.List<regex_option>(256);
			if( System.IO.File.Exists("presets.txt") ) {
                using (System.IO.StreamReader commonregexes = new System.IO.StreamReader("presets.txt"))
                {


                    string line = "";
                    int i = 1;
                    while ((line = commonregexes.ReadLine()) != null)
                    {
                        presets_box.Items.Add(line.Replace("Preset:", ""));
                        regex_option z = new regex_option();
                        z.regex_display = line.Substring(7);
                        if ((line = commonregexes.ReadLine()) != null)
                        {
                            if (line.IndexOf("Match:") == 0) { line = line.Substring("Match:".Length); }
                            z.regex_match = line;
                        }
                        else
                        {
                            break;
                        }
                        if ((line = commonregexes.ReadLine()) != null)
                        {
                            if (line.IndexOf("Replace:") == 0) { line = line.Substring("Replace:".Length); }
                            z.regex_replace = line;
                        }
                        else
                        {
                            break;
                        }
                        if(!regexes.Contains(z))
                            regexes.Add(z);
                        i++;
                        //if( i > 255 ) { break; }
                    }
                    commonregexes.Close();
                }
			}

            } catch( System.Security.SecurityException e) {
				//oh well
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			if( disposing ) 
			{ 
                //if( this.m_myTray != null)
                //    this.m_myTray.Dispose(); //we dispose our tray icon here
				
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.input_textbox = new System.Windows.Forms.TextBox();
            this.output_textbox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pane2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.presets_box = new System.Windows.Forms.ComboBox();
            this.regex_replace = new System.Windows.Forms.ComboBox();
            this.regex_match = new System.Windows.Forms.ComboBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label_message = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.IgnoreDups = new System.Windows.Forms.CheckBox();
            this.checkBox_singleline = new System.Windows.Forms.CheckBox();
            this.checkbox_multiLine = new System.Windows.Forms.CheckBox();
            this.casecheckbox = new System.Windows.Forms.CheckBox();
            this.match_mode = new System.Windows.Forms.CheckBox();
            this.splitter_main = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel3.SuspendLayout();
            this.pane2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // input_textbox
            // 
            this.input_textbox.AcceptsTab = true;
            this.input_textbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.input_textbox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_textbox.Location = new System.Drawing.Point(0, 0);
            this.input_textbox.MaxLength = 0;
            this.input_textbox.Multiline = true;
            this.input_textbox.Name = "input_textbox";
            this.input_textbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.input_textbox.Size = new System.Drawing.Size(780, 187);
            this.input_textbox.TabIndex = 0;
            this.toolTip1.SetToolTip(this.input_textbox, "This contains the source text to \r\nhave the Regular Expression applied to.");
            this.input_textbox.WordWrap = false;
            this.input_textbox.DoubleClick += new System.EventHandler(this.input_textbox_DoubleClick);
            this.input_textbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.input_textbox_KeyDown);
            // 
            // output_textbox
            // 
            this.output_textbox.AcceptsTab = true;
            this.output_textbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.output_textbox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.output_textbox.Location = new System.Drawing.Point(0, 0);
            this.output_textbox.MaxLength = 0;
            this.output_textbox.Multiline = true;
            this.output_textbox.Name = "output_textbox";
            this.output_textbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.output_textbox.Size = new System.Drawing.Size(776, 98);
            this.output_textbox.TabIndex = 0;
            this.toolTip1.SetToolTip(this.output_textbox, "This contains the output after \r\nprocessing of the source with the Regular Expres" +
        "sion.");
            this.output_textbox.WordWrap = false;
            this.output_textbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.output_textbox_KeyDown);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "&Run";
            this.toolTip1.SetToolTip(this.button1, "Run the current Regular Expression.");
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.output_textbox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 306);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(780, 102);
            this.panel3.TabIndex = 99;
            // 
            // pane2
            // 
            this.pane2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pane2.Controls.Add(this.panel5);
            this.pane2.Controls.Add(this.panel4);
            this.pane2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pane2.Location = new System.Drawing.Point(0, 187);
            this.pane2.Name = "pane2";
            this.pane2.Size = new System.Drawing.Size(780, 107);
            this.pane2.TabIndex = 99;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel9);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(665, 103);
            this.panel5.TabIndex = 99;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.presets_box);
            this.panel9.Controls.Add(this.regex_replace);
            this.panel9.Controls.Add(this.regex_match);
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(665, 75);
            this.panel9.TabIndex = 0;
            // 
            // presets_box
            // 
            this.presets_box.Dock = System.Windows.Forms.DockStyle.Top;
            this.presets_box.Location = new System.Drawing.Point(64, 50);
            this.presets_box.Name = "presets_box";
            this.presets_box.Size = new System.Drawing.Size(601, 24);
            this.presets_box.TabIndex = 2;
            this.toolTip1.SetToolTip(this.presets_box, "This contains Presets which are read\r\nfrom the presets.txt file.\r\nThe format is 3" +
        " lines for each Preset\r\n1. Text to display in Preset box\r\n2. Match Expression\r\n3" +
        ". Replace Expression");
            this.presets_box.SelectedIndexChanged += new System.EventHandler(this.presets_box_SelectedIndexChanged);
            this.presets_box.TextUpdate += new System.EventHandler(this.presets_box_TextUpdate);
            // 
            // regex_replace
            // 
            this.regex_replace.Dock = System.Windows.Forms.DockStyle.Top;
            this.regex_replace.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regex_replace.Location = new System.Drawing.Point(64, 25);
            this.regex_replace.Name = "regex_replace";
            this.regex_replace.Size = new System.Drawing.Size(601, 25);
            this.regex_replace.TabIndex = 1;
            // 
            // regex_match
            // 
            this.regex_match.Dock = System.Windows.Forms.DockStyle.Top;
            this.regex_match.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regex_match.Location = new System.Drawing.Point(64, 0);
            this.regex_match.Name = "regex_match";
            this.regex_match.Size = new System.Drawing.Size(601, 25);
            this.regex_match.TabIndex = 0;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.label1);
            this.panel10.Controls.Add(this.label2);
            this.panel10.Controls.Add(this.label3);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(64, 75);
            this.panel10.TabIndex = 100;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 25);
            this.label1.TabIndex = 99;
            this.label1.Text = "Presets";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 25);
            this.label3.TabIndex = 99;
            this.label3.Text = "Match";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 25);
            this.label2.TabIndex = 99;
            this.label2.Text = "Replace";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 75);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(665, 28);
            this.panel6.TabIndex = 99;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label_message);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(556, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(109, 28);
            this.panel7.TabIndex = 99;
            // 
            // label_message
            // 
            this.label_message.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_message.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_message.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_message.Location = new System.Drawing.Point(0, 0);
            this.label_message.Name = "label_message";
            this.label_message.Size = new System.Drawing.Size(109, 28);
            this.label_message.TabIndex = 99;
            this.label_message.Text = "Status";
            this.toolTip1.SetToolTip(this.label_message, "Status Message - Will print \"No occurances\" when the \r\nexpression failed to match" +
        ".");
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.button8);
            this.panel8.Controls.Add(this.button7);
            this.panel8.Controls.Add(this.button6);
            this.panel8.Controls.Add(this.button5);
            this.panel8.Controls.Add(this.button4);
            this.panel8.Controls.Add(this.button2);
            this.panel8.Controls.Add(this.button3);
            this.panel8.Controls.Add(this.button1);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(556, 28);
            this.panel8.TabIndex = 99;
            // 
            // button8
            // 
            this.button8.Dock = System.Windows.Forms.DockStyle.Left;
            this.button8.Location = new System.Drawing.Point(496, 0);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(60, 28);
            this.button8.TabIndex = 7;
            this.button8.Text = "Unique";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Dock = System.Windows.Forms.DockStyle.Left;
            this.button7.Location = new System.Drawing.Point(445, 0);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(51, 28);
            this.button7.TabIndex = 6;
            this.button7.Text = "Sort";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Left;
            this.button6.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(355, 0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(90, 28);
            this.button6.TabIndex = 5;
            this.button6.Text = "&Save Presets";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Left;
            this.button5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(288, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(67, 28);
            this.button5.TabIndex = 4;
            this.button5.Text = "CLEAR";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Left;
            this.button4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(221, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(67, 28);
            this.button4.TabIndex = 3;
            this.button4.Text = "CLEAR";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Left;
            this.button2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(144, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(77, 28);
            this.button2.TabIndex = 2;
            this.button2.Text = "&Move Up";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Left;
            this.button3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(77, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(67, 28);
            this.button3.TabIndex = 1;
            this.button3.Text = "&COPY";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.IgnoreDups);
            this.panel4.Controls.Add(this.checkBox_singleline);
            this.panel4.Controls.Add(this.checkbox_multiLine);
            this.panel4.Controls.Add(this.casecheckbox);
            this.panel4.Controls.Add(this.match_mode);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(665, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(111, 103);
            this.panel4.TabIndex = 99;
            // 
            // IgnoreDups
            // 
            this.IgnoreDups.AutoSize = true;
            this.IgnoreDups.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IgnoreDups.Location = new System.Drawing.Point(0, 84);
            this.IgnoreDups.Name = "IgnoreDups";
            this.IgnoreDups.Size = new System.Drawing.Size(106, 21);
            this.IgnoreDups.TabIndex = 4;
            this.IgnoreDups.Text = "Ignore Dups";
            this.toolTip1.SetToolTip(this.IgnoreDups, "With \"Match Mode\" enabled, will prevent duplicate output.");
            this.IgnoreDups.UseVisualStyleBackColor = true;
            this.IgnoreDups.CheckedChanged += new System.EventHandler(this.IgnoreDups_CheckedChanged);
            // 
            // checkBox_singleline
            // 
            this.checkBox_singleline.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_singleline.Location = new System.Drawing.Point(0, 63);
            this.checkBox_singleline.Name = "checkBox_singleline";
            this.checkBox_singleline.Size = new System.Drawing.Size(96, 19);
            this.checkBox_singleline.TabIndex = 3;
            this.checkBox_singleline.Text = "Single-Line";
            this.toolTip1.SetToolTip(this.checkBox_singleline, "Specifies single-line mode.\r\n Changes the meaning of the period character (.) \r\ns" +
        "o that it matches every character (instead of every \r\ncharacter except \\n).");
            // 
            // checkbox_multiLine
            // 
            this.checkbox_multiLine.Checked = true;
            this.checkbox_multiLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkbox_multiLine.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkbox_multiLine.Location = new System.Drawing.Point(0, 21);
            this.checkbox_multiLine.Name = "checkbox_multiLine";
            this.checkbox_multiLine.Size = new System.Drawing.Size(85, 21);
            this.checkbox_multiLine.TabIndex = 1;
            this.checkbox_multiLine.Text = "Multi-Line";
            this.toolTip1.SetToolTip(this.checkbox_multiLine, resources.GetString("checkbox_multiLine.ToolTip"));
            // 
            // casecheckbox
            // 
            this.casecheckbox.AutoSize = true;
            this.casecheckbox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.casecheckbox.Location = new System.Drawing.Point(0, 0);
            this.casecheckbox.Name = "casecheckbox";
            this.casecheckbox.Size = new System.Drawing.Size(59, 21);
            this.casecheckbox.TabIndex = 0;
            this.casecheckbox.Text = "Case";
            this.toolTip1.SetToolTip(this.casecheckbox, "Enable case-sensitive regular expressions");
            this.casecheckbox.UseVisualStyleBackColor = true;
            // 
            // match_mode
            // 
            this.match_mode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.match_mode.Location = new System.Drawing.Point(0, 42);
            this.match_mode.Name = "match_mode";
            this.match_mode.Size = new System.Drawing.Size(108, 18);
            this.match_mode.TabIndex = 2;
            this.match_mode.Text = "Match Mode";
            this.toolTip1.SetToolTip(this.match_mode, "The contents of the Replace box are ignored and only text\r\n matching the Match Re" +
        "gular Expression is displayed in output");
            // 
            // splitter_main
            // 
            this.splitter_main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter_main.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter_main.Location = new System.Drawing.Point(0, 294);
            this.splitter_main.Name = "splitter_main";
            this.splitter_main.Size = new System.Drawing.Size(780, 12);
            this.splitter_main.TabIndex = 20;
            this.splitter_main.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pane2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(780, 294);
            this.panel1.TabIndex = 99;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.input_textbox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(780, 187);
            this.panel2.TabIndex = 99;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 250;
            this.toolTip1.ShowAlways = true;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(780, 408);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter_main);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Regular Expression Runner v1.02";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pane2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
            Application.EnableVisualStyles();
            Application.Run(new Form1());

		}


		private void Form1_Resize(object sender, System.EventArgs e)
		{
            //try{

            //if( this.WindowState == FormWindowState.Minimized ) 
            //{
            //    Hide();
            //}
            //}catch( System.Security.SecurityException ex) {
            //    //Do nothing
            //}
		}
		public string outputbox_change(string text)
		{
			this.output_textbox.Text = text;
			return text;
		}

		public string label_change(string text)
		{
			this.label_message.Text = text;
			return text;
		}



		/// <summary>
		/// Runs the regular expressions as input in the textboxes and outputs the result in the results textbox
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		//System.Threading.Thread runregex;
		private void button1_Click(object sender, System.EventArgs e)
		{
			button1.Enabled = false;

			
			RegexRun o = new RegexRun();
			o.OnMessage += new RegexRun.MessageHandler(o_OnMessage);
			o.RegexFinished += new RegexRun.RunRegexCompletedHandler(o_RegexFinished);
			o.regex_checkbox_multiLine = checkbox_multiLine.Checked;
			o.regex_checkBox_singleline = checkBox_singleline.Checked;
			o.regex_match = regex_match.Text;
			o.regex_replace = regex_replace.Text;
			o.regex_match_mode = match_mode.Checked;
			o.input_text = input_textbox.Text;
            o.ignoreduplicates = IgnoreDups.Checked;
            o.casesensitive = casecheckbox.Checked;
			o.RunRegexAsync();

			//Test to see if the match/replace are already in their drop down lists.  It then adds them if not.
			if(!regex_match.Items.Contains(regex_match.Text))
			{
				regex_match.Items.Insert(0, regex_match.Text);
			}
			if(!regex_replace.Items.Contains(regex_replace.Text))
			{
				regex_replace.Items.Insert(0, regex_replace.Text);
			}
            if ((presets_box.SelectedIndex == 0 || presets_box.SelectedIndex == -1) && String.IsNullOrEmpty(presets_box.Text))
            {
                regex_option z = new regex_option();
                z.regex_match = regex_match.Text;
                z.regex_replace = regex_replace.Text;
                z.regex_display = "Last used Expressions";
                int g = regexes.FindIndex(x => x.regex_display == "Last used Expressions") ;
                if (g != -1)
                    regexes[g] = z;
                else
                {
                    regexes.Add(z);
                    presets_box.Items.Add(z.regex_display);
                }
                
                presets_box.Text = z.regex_display;
            }

            int i = regexes.FindIndex(x => x.regex_display == presets_box.Text);
            if (! String.IsNullOrEmpty(presets_box.Text) && i != -1 )
            {
                regex_option z = regexes.Find(x => x.regex_display == presets_box.Text);
                z.regex_match = regex_match.Text;
                z.regex_replace = regex_replace.Text;

            }

			//button1.Enabled = true;
		}

		void o_RegexFinished(object sender, EventArgs e)
		{
			//button1.Enabled = true;
			ButtonChangeEventArgs be = new ButtonChangeEventArgs();
			be.Enabled = true;
			button1_setenabled(button1, be);
		}

		void o_OnMessage(object sender, RegexRun.MessageEventArgs e)
		{
			if(e.messagetype == "output")
			{
				//output_textbox.Text = e.message;
				TextChangeEventArgs te = new TextChangeEventArgs(); te.Text = e.message;
				output_textbox_settext(output_textbox, te);
			}
			if(e.messagetype == "label")
			{
				TextChangeEventArgs te = new TextChangeEventArgs(); te.Text = e.message;
				//label_message.Text = e.message;
				label_message_settext(label_message, te);
			}
			return;
		}

		void output_textbox_settext(object sender,TextChangeEventArgs  e)
		{
			TextBox c = sender as TextBox;
			if(c != null)
			{
				if(c.InvokeRequired)
				{
					c.Invoke(new TextChangeEventHandler(output_textbox_settext),sender,  e);
				} else
				{
					c.Text = e.Text;
				}

			}
		}
		void label_message_settext(object sender, TextChangeEventArgs e)
		{
			Label c = sender as Label;
			if(c != null)
			{
				if(c.InvokeRequired)
				{
					c.Invoke(new TextChangeEventHandler(label_message_settext), sender, e);
				} else
				{
					c.Text = e.Text;
				}

			}
		}
		void button1_setenabled(object sender, ButtonChangeEventArgs e) 
		{
			Button c = sender as Button;
			if(c != null)
			{
				if(c.InvokeRequired)
				{
					c.Invoke(new ButtonChangeEventhandler(button1_setenabled), sender, e);
				} else
				{
					c.Enabled = e.Enabled;
				}

			}
		}
		
		public delegate void TextChangeEventHandler (object sender, TextChangeEventArgs e);
		public class TextChangeEventArgs : System.EventArgs {
			public string Text;
		}
		public delegate void ButtonChangeEventhandler(object sender, ButtonChangeEventArgs e);
		public class ButtonChangeEventArgs : System.EventArgs
		{
			public bool Enabled;
		}

		
		private void button2_Click(object sender, System.EventArgs e)
		{
			input_textbox.Text = output_textbox.Text;
			output_textbox.Text = "";

		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			System.Windows.Forms.Clipboard.SetDataObject(output_textbox.Text, true);
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			output_textbox.Text = "";
		}


		private void button5_Click(object sender, System.EventArgs e)
		{
			input_textbox.Text = "";
		}

		private void presets_box_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            regex_option z;
            z = regexes.Find(x => x.regex_display == presets_box.Text);
            if(z != null ) {
			    regex_match.Text = z.regex_match;
			    regex_replace.Text = z.regex_replace;
            }
            if (presets_box.Text == "No Preset")
            {
                regex_match.Text = "";
                regex_replace.Text = "";
            }
		}
		/// <summary>
		/// Called when the form loads and will readjust the controls.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_Activated(object sender, System.EventArgs e)
		{
		}

		private void input_textbox_DoubleClick(object sender, System.EventArgs e)
		{
			//Doesn't work as well as it should.!
			return;
			

			/*
			try {
			FileSelector myFiles;
			if( this.recursedirectory != null && this.recursedirectory.Length > 0) {
				myFiles = new FileSelector(this.recursedirectory, this.recursefile, this.recurseflag);
			} else {
				 myFiles = new FileSelector();
			}
			myFiles.ShowDialog(this);
			this.recursedirectory = myFiles.directory;
			this.recursefile = myFiles.fileregex;
			this.recurseflag = myFiles.recurseme;
			this.renameonly = myFiles.chkRename.Checked;
			myFiles.Dispose();

			if( this.recursedirectory == "" || this.recursedirectory == null) {
				input_textbox.ReadOnly = false;
			} else {
				regex_match.Focus();
				input_textbox.ReadOnly = true;
				input_textbox.Text = "Double click again and leave fields blank to re-enable";
			}
			}catch(System.Security.SecurityException ex) {
				input_textbox.ReadOnly = false;
			}
			*/
		}
		
		/*public void fd_FileOk(object sender, CancelEventArgs e)
		{
			
			input_textbox.Text = "FILE REGEX: " + ((System.Windows.Forms.OpenFileDialog)sender).FileName;
			
		
		}*/

		

		protected void Exit_Click(Object sender, System.EventArgs e) 
		{
            //SavePresets();
			Close();
		}
		protected void Hide_Click(Object sender, System.EventArgs e) 
		{
			Hide();
		}
		protected void Show_Click(Object sender, System.EventArgs e) 
		{
			Show();
			SetTopLevel(true);
		}

		private void m_myTray_Click(object sender, EventArgs e)
		{
			if( this.Visible == false ) 
			{
				Show();
				this.WindowState = FormWindowState.Normal;
				//Size_Changed();
				//this.pane1.Height = this.Height / 2;
				//this.pane2.Top = (this.Height / 2) - (this.pane2.Height / 2);
				//this.panel3.Height = (this.Height / 2) - (this.pane2.Height / 2);
				//this.panel3.Top = this.Height / 2;
			}
		}

        private void button6_Click(object sender, EventArgs e)
        {
            bool bfoundexistingregex = false;
            for (int i = 0; i < this.regexes.Count; i++)
            {
                if (regexes[i].regex_display == this.presets_box.Text)
                {
                    regex_option z = regexes[i];
                    z.regex_match = this.regex_match.Text;
                    z.regex_replace = this.regex_replace.Text;
                    regexes[i] = z;
                    bfoundexistingregex = true;
                } 
            }
            if (!bfoundexistingregex && ! String.IsNullOrEmpty(this.presets_box.Text))
            {
                regex_option z = new regex_option();
                z.regex_replace = this.regex_replace.Text;
                z.regex_match = this.regex_match.Text;
                z.regex_display = this.presets_box.Text;
                
            }
            SavePresets();
        }

        private void SavePresets()
        {
            // Update file!
            try
            {
                System.IO.StreamWriter ws = new System.IO.StreamWriter("presets.txt");
                for (int i = 0; i < regexes.Count; i++)
                {
                    ws.WriteLine("Preset:" + regexes[i].regex_display.Replace("\n", ""));
                    ws.WriteLine("Match:" + regexes[i].regex_match.Replace("\n", ""));
                    ws.WriteLine("Replace:" + regexes[i].regex_replace.Replace("\n", ""));
                }
                ws.Close();
            }
            catch 
            {
                //
            }
        }

        private void presets_box_TextUpdate(object sender, EventArgs e)
        {
            regex_option z;
            z = regexes.Find(x => x.regex_match == regex_match.Text && x.regex_replace == regex_replace.Text);
            if (z != null && !String.IsNullOrEmpty(presets_box.Text))
            {
                //Old listitem
                if (presets_box.Items.IndexOf(z.regex_display) != -1)
                {
                    //Selection hack to prevent cursor from moving while updating a listitem
                    int i = presets_box.SelectionStart;
                    
                    presets_box.Items[presets_box.Items.IndexOf(z.regex_display)] = presets_box.Text;
                    presets_box.SelectionStart = i;

                }

                z.regex_display = presets_box.Text;
            }
            else if(! String.IsNullOrEmpty(presets_box.Text))
            {
                z = new regex_option();
                z.regex_display = presets_box.Text;
                z.regex_match = regex_match.Text;
                z.regex_replace = regex_replace.Text;
                regexes.Add(z);
                presets_box.Items.Add(z.regex_display);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SavePresets();
        }

        private void IgnoreDups_CheckedChanged(object sender, EventArgs e)
        {
            if (!match_mode.Checked)
                match_mode.Checked = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string[] lines = input_textbox.Text.Split(new string[] {  Environment.NewLine }, StringSplitOptions.None);
            Array.Sort(lines);
            output_textbox.Text = String.Join(Environment.NewLine, lines);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string[] lines = input_textbox.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            string templine = null;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == templine)
                {
                    lines[i] = null;
                }
                else
                {
                    templine = lines[i];
                }
            }
            System.Collections.Generic.List<string> sc = new System.Collections.Generic.List<string>(lines);
            sc.RemoveAll( x => x == null );

            output_textbox.Text = String.Join(Environment.NewLine, sc);
        }

        private void input_textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                input_textbox.SelectionStart = 0;
                input_textbox.SelectionLength = input_textbox.Text.Length;
            }
        }

        private void output_textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                //Select all
                output_textbox.SelectionStart = 0;
                output_textbox.SelectionLength = output_textbox.Text.Length;
            }
        }
    }

}
