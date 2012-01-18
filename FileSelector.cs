using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace RegExHelper
{

	/// <summary>
	/// Summary description for FileSelector.
	/// </summary>
	public class FileSelector : System.Windows.Forms.Form
	{
		private int filedirdepth;
		private int filetotal;
		private System.Text.StringBuilder strBuffer;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox recurse;
		private System.Windows.Forms.Button button2;
		public System.Windows.Forms.CheckBox chkRename;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FileSelector()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		public FileSelector(string xdirectory, string xfile, bool flaggy)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.directory = xdirectory;
			this.fileregex = xfile;
			this.recurseme = flaggy;
			textBox1.Text = directory;
			textBox2.Text = fileregex;
		}
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
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
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.recurse = new System.Windows.Forms.CheckBox();
			this.button2 = new System.Windows.Forms.Button();
			this.chkRename = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Directory:";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(96, 0);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(120, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(0, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "File Regex:";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(96, 24);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(120, 20);
			this.textBox2.TabIndex = 3;
			this.textBox2.Text = "";
			this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(216, 0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 20);
			this.button1.TabIndex = 4;
			this.button1.Text = "Browse...";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(0, 64);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox3.Size = new System.Drawing.Size(288, 136);
			this.textBox3.TabIndex = 5;
			this.textBox3.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(0, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(128, 16);
			this.label3.TabIndex = 6;
			this.label3.Text = "Affected Files";
			// 
			// recurse
			// 
			this.recurse.Location = new System.Drawing.Point(96, 48);
			this.recurse.Name = "recurse";
			this.recurse.Size = new System.Drawing.Size(80, 16);
			this.recurse.TabIndex = 7;
			this.recurse.Text = "Recursive";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(216, 24);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 20);
			this.button2.TabIndex = 8;
			this.button2.Text = "OK!";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// chkRename
			// 
			this.chkRename.Location = new System.Drawing.Point(176, 48);
			this.chkRename.Name = "chkRename";
			this.chkRename.Size = new System.Drawing.Size(96, 16);
			this.chkRename.TabIndex = 9;
			this.chkRename.Text = "Rename Only";
			// 
			// FileSelector
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 202);
			this.Controls.Add(this.chkRename);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.recurse);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FileSelector";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "FileSelector";
			this.SizeChanged += new System.EventHandler(this.FileSelector_SizeChanged);
			this.Activated += new System.EventHandler(this.FileSelector_Activated);
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			System.Windows.Forms.OpenFileDialog fd;
			fd = new System.Windows.Forms.OpenFileDialog();
			fd.CheckFileExists = false;
			fd.CheckPathExists = true;
			fd.Multiselect = false;
			fd.ValidateNames = false;
			System.Windows.Forms.FolderBrowserDialog fx;
			fx = new FolderBrowserDialog();
			
			if( textBox1.Text.Length > 0 && System.IO.Directory.Exists(textBox1.Text) ) 
				fx.SelectedPath = textBox1.Text;
			
			fx.Disposed += new EventHandler(fd_FileDisposed);
			//fd.FileOk += new CancelEventHandler(fd_FileOk);
			//fd.Disposed += new EventHandler(fd_FileDisposed);
			if( directory != null && directory != "") 
				fx.SelectedPath = directory;

			fx.ShowDialog(this);
			fx.Dispose();
		}
		public void fd_FileDisposed(object sender, EventArgs e) 
		{
			textBox1.Text = ((System.Windows.Forms.FolderBrowserDialog)sender).SelectedPath;
		}
		public string fileregex;
		public string directory;
		public bool recurseme;
		private void textBox2_TextChanged(object sender, System.EventArgs e)
		{
			strBuffer = new System.Text.StringBuilder();
			if( !System.IO.Directory.Exists(textBox1.Text) && textBox2.Text.Length > 0)
				return;
			textBox3.Text = "";
			try {
				System.Text.RegularExpressions.Regex regexfiles = new System.Text.RegularExpressions.Regex(textBox2.Text, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
				System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(textBox1.Text);
				//System.IO.FileInfo fi[] = di.GetFiles();
				filetotal = 0;
				filedirdepth = 0;
				if( recurse.Checked ) {
					recursedirs(di, regexfiles);
					addfilesfromdirectory(di, regexfiles);
				}else{
						addfilesfromdirectory( new System.IO.DirectoryInfo(textBox1.Text), regexfiles);
					}
				textBox3.Text = strBuffer.ToString();
			} catch(System.Exception ex) {
				textBox3.Text = "Invalid Regular Expression " + ex.Message;
			}
		}

		private void recursedirs(System.IO.DirectoryInfo di, System.Text.RegularExpressions.Regex regexfiles) {
			foreach( System.IO.DirectoryInfo xi in di.GetDirectories()) {
				filedirdepth += 1;
				recursedirs(xi, regexfiles);
				addfilesfromdirectory(xi,regexfiles);
			}
		}
		private void addfilesfromdirectory( System.IO.DirectoryInfo di,  System.Text.RegularExpressions.Regex regexfiles ) {
			System.IO.FileInfo fi;
			System.IO.FileInfo[] fis;
			
			fis = di.GetFiles();
			//foreach( System.IO.FileInfo fi in di.GetFiles()) {
			for(int i = 0; i < fis.Length; i++) {
				fi = fis[i];
				if(regexfiles.Match(fi.Name).Success ) {
					filetotal += 1;
					strBuffer.Append(fi.Name + "\r\n");
				}
				//if( filetotal > 1024)
				//	break;
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			directory = textBox1.Text;
			fileregex = textBox2.Text;
			recurseme = recurse.Checked;
			this.Close();
		}

		private void FileSelector_SizeChanged(object sender, System.EventArgs e)
		{
			
			if( FileSelector.ActiveForm != null) 
			{
				Size mysize = textBox3.Size;
				mysize.Width = FileSelector.ActiveForm.Width - 10;
				mysize.Height = FileSelector.ActiveForm.Height - 88;
				textBox3.Size = mysize;
			}
		}

		private void FileSelector_Activated(object sender, System.EventArgs e)
		{
						// Create the ToolTip and associate with the Form container.
			ToolTip toolTip1 = new ToolTip();

			// Set up the delays for the ToolTip.
			toolTip1.AutoPopDelay = 5000;
			toolTip1.InitialDelay = 500;
			toolTip1.ReshowDelay = 250;
			// Force the ToolTip text to be displayed whether or not the form is active.
			toolTip1.ShowAlways = true;
      
			// Set up the ToolTip text for the Button and Checkbox.
			toolTip1.SetToolTip(this.chkRename, "Renames files by applying Match and Replace regular expressions\r\nto the filename only and not the path.");
			toolTip1.SetToolTip(this.textBox1, "Directory to read files from");
			toolTip1.SetToolTip(this.textBox2, "Regular expression to filter files");
			toolTip1.SetToolTip(this.recurse, "Recurse into all child directories?");


		}
	}
}


