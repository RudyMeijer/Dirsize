using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Globalization;
using System.Diagnostics;

namespace DirSize
{
	/// <summary>
	///   2.0 4-Okt-2003 Add Delete command to context menu.
	///   2.1 6-Nov-2003 Add Open containing folder to context menu.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel Panel1;
		private System.Windows.Forms.StatusBarPanel Panel2;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader column1;
		private System.Windows.Forms.ColumnHeader column2;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem mnuDelete;
		private System.Windows.Forms.MenuItem mnuCopy;
		private System.Windows.Forms.MenuItem mnuOpenDirectory;
		private System.Windows.Forms.ColumnHeader column3;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.MenuItem mnuView;
		private System.Windows.Forms.MenuItem mnuMove;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.MainMenu mainMenu1;
		private Boolean DoNotComputeSize;
		private Boolean Initialising = true; //V106
		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			string[] arg = Environment.GetCommandLineArgs();
			if (arg.Length > 1)	// V105
			{
				DoNotComputeSize = true;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.Panel1 = new System.Windows.Forms.StatusBarPanel();
			this.Panel2 = new System.Windows.Forms.StatusBarPanel();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.listView1 = new System.Windows.Forms.ListView();
			this.column1 = new System.Windows.Forms.ColumnHeader();
			this.column2 = new System.Windows.Forms.ColumnHeader();
			this.column3 = new System.Windows.Forms.ColumnHeader();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mnuView = new System.Windows.Forms.MenuItem();
			this.mnuCopy = new System.Windows.Forms.MenuItem();
			this.mnuMove = new System.Windows.Forms.MenuItem();
			this.mnuOpenDirectory = new System.Windows.Forms.MenuItem();
			this.mnuDelete = new System.Windows.Forms.MenuItem();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			((System.ComponentModel.ISupportInitialize)(this.Panel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Panel2)).BeginInit();
			this.SuspendLayout();
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 294);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.Panel1,
																						  this.Panel2});
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(533, 24);
			this.statusBar1.TabIndex = 3;
			this.statusBar1.Text = "statusBar1";
			// 
			// Panel1
			// 
			this.Panel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.Panel1.Width = 417;
			// 
			// treeView1
			// 
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
			this.treeView1.HideSelection = false;
			this.treeView1.ImageIndex = -1;
			this.treeView1.Location = new System.Drawing.Point(0, 0);
			this.treeView1.Name = "treeView1";
			this.treeView1.SelectedImageIndex = -1;
			this.treeView1.Size = new System.Drawing.Size(104, 294);
			this.treeView1.TabIndex = 4;
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(104, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(8, 294);
			this.splitter1.TabIndex = 5;
			this.splitter1.TabStop = false;
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.column1,
																						this.column2,
																						this.column3});
			this.listView1.ContextMenu = this.contextMenu1;
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.listView1.FullRowSelect = true;
			this.listView1.Location = new System.Drawing.Point(112, 0);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(421, 294);
			this.listView1.SmallImageList = this.imageList1;
			this.listView1.TabIndex = 6;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
			this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
			// 
			// column1
			// 
			this.column1.Text = "Name";
			this.column1.Width = 140;
			// 
			// column2
			// 
			this.column2.Text = "Size";
			this.column2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.column2.Width = 80;
			// 
			// column3
			// 
			this.column3.Text = "Modified";
			this.column3.Width = 142;
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.mnuView,
																						 this.mnuCopy,
																						 this.mnuMove,
																						 this.mnuOpenDirectory,
																						 this.mnuDelete});
			// 
			// mnuView
			// 
			this.mnuView.Index = 0;
			this.mnuView.Text = "View";
			this.mnuView.Click += new System.EventHandler(this.mnuView_Click);
			// 
			// mnuCopy
			// 
			this.mnuCopy.Index = 1;
			this.mnuCopy.Text = "Copy";
			this.mnuCopy.Click += new System.EventHandler(this.mnuCopy_Click);
			// 
			// mnuMove
			// 
			this.mnuMove.Index = 2;
			this.mnuMove.Text = "Move";
			this.mnuMove.Click += new System.EventHandler(this.mnuMove_Click);
			// 
			// mnuOpenDirectory
			// 
			this.mnuOpenDirectory.Index = 3;
			this.mnuOpenDirectory.Text = "Open containing directory";
			this.mnuOpenDirectory.Click += new System.EventHandler(this.mnuOpenDirectory_Click);
			// 
			// mnuDelete
			// 
			this.mnuDelete.Index = 4;
			this.mnuDelete.Text = "Delete";
			this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(533, 318);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.statusBar1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Rudy Meijer\'s Directory Size Viewer";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.Panel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Panel2)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			setTitle();
			Panel2.Text = getVersion();

			foreach(string drive in Directory.GetLogicalDrives() )
			{
				treeView1.Nodes.Add (new TreeNode (drive));
				addFolders(treeView1.Nodes[treeView1.Nodes.Count-1]);
			}
		}
		private void setTitle()
		{
			this.Text = this.Text + getVersion(); 
		}
		private string getVersion()
		{
			int i = ProductVersion.LastIndexOf(".");// V101
			return " Version: " + ProductVersion.Substring(0,i);
		}
		private void treeView1_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			TreeNode tn = e.Node ;
			foreach (TreeNode child in tn.Nodes )
			{
				if (child.Tag ==null)
				{
					child.Tag =true;	//This folder has been expanded.
					addFolders (child );
				}
			}
		}
		private void addFolders(TreeNode tn)
		{
			DirectoryInfo di=new DirectoryInfo(tn.FullPath);
			if (di.Exists)
			{
				treeView1.BeginUpdate ();
				try
				{
					foreach(DirectoryInfo fi in di.GetDirectories ()) 
						tn.Nodes.Add (new TreeNode(fi.Name));
				}
				catch(Exception e)
				{
					Console.WriteLine ("{0} {1}",tn.FullPath,e.Message);
				}
				treeView1.EndUpdate(); 
			}
		}
		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			string path= e.Node.FullPath  ;
			long begin = Environment.TickCount ;
			if (Initialising) {Initialising = false; return;} //V106
			listFiles(path);

			long eind = Environment.TickCount ;
			Console .WriteLine ("Elapsed time: {0} ms {1}",eind-begin,path );
		}
		private void listFiles(string path)
		{
			long length=0,totalLength=0;
			int imageIdx;
			DirectoryInfo di = new DirectoryInfo (path);
			Folder folder = new Folder();
			listView1.BeginUpdate ();
			listView1.Items.Clear ();
			listView1.ListViewItemSorter=null;
			Panel1.Text = "Momento"; //V106
			Application.DoEvents();

			try
			{
				foreach (FileSystemInfo fsi in di.GetFileSystemInfos())
				{
					if ((fsi.Attributes & FileAttributes.Directory)==FileAttributes.Directory)
					{
						if (!DoNotComputeSize) 
						length = folder.Size (fsi.FullName);
						imageIdx =0;
					}
					else
					{
						length = ((FileInfo)fsi).Length;
						//V109 length = 1000000000L;
						if (length < 500) length = 1000; //V104
						imageIdx =1;
					}
					// Add file/directory name and size to listview.
					ListViewItem item = new ListViewItem (fsi.Name,imageIdx );
					item.SubItems.Add (length.ToString("#,#0, Kb"));
					item.SubItems.Add (fsi.LastWriteTime.ToString());// V100
					//V109 item.SubItems[1].BackColor = Color.Red;
					listView1.Items.Add(item );
					totalLength+=length;
				}
				listView1.ListViewItemSorter = new SortSize(1);
			} 
			catch(Exception e)
			{
				Console.WriteLine("{0}",e.Message);
			}
			listView1.EndUpdate (); //Always end update in case of exeption.
			Panel1.Text = "Total size occupied by " + path.Replace(@"\\",@"\") + " is "+totalLength.ToString ("#,#0,, Mb");   
		}

		private void listView1_ItemActivate(object sender, System.EventArgs e)
		{
			string myChild=((ListView) sender).FocusedItem.Text;
			 
			TreeNode sn = treeView1.SelectedNode;
			foreach(TreeNode tn in sn.Nodes )
				if (tn.Text == myChild )
				{
					foreach (TreeNode child in tn.Nodes )
					{
						if (child.Tag ==null)
						{
							child.Tag =true;	//This folder is expanded.
							addFolders (child );
						}
					}
					treeView1.SelectedNode = tn;
					treeView1.Focus();
					break;
				}
		}

		private void listView1_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			listView1.ListViewItemSorter = new SortSize (e.Column );  
		}

		private void mnuDelete_Click(object sender, System.EventArgs e)
		{
			string path = treeView1.SelectedNode.FullPath;
			foreach (ListViewItem item in listView1.Items)
			{
				if (item.Selected)
				{
					string fileName = path +"\\"+item.Text;
					if (Directory.Exists(fileName))
					{
						Directory.Delete(fileName,true);
					}
					else if (File.Exists (fileName))
					{
						File.Delete(fileName);
					}
				}
			}
			listFiles(path);
		}
		private void mnuOpenDirectory_Click(object sender, System.EventArgs e)
		{
			string path = treeView1.SelectedNode.FullPath;
			path = path.Remove(2,1);
			Process.Start("explorer",path);
		}
		private void mnuView_Click(object sender, System.EventArgs e)	// V105
		{
			string path = treeView1.SelectedNode.FullPath;
			string filename = "\\"+listView1.FocusedItem.Text;
			path = path.Remove(2,1);
			Process.Start("notepad",path+filename);
		}

		private void mnuMove_Click(object sender, System.EventArgs e)
		{
			mnuCopy_Click(sender,e);
		}

		private void mnuCopy_Click(object sender, System.EventArgs e)
		{
			string menu = ((MenuItem) sender).Text; // Copy or Move
			string src = treeView1.SelectedNode.FullPath;
			// Ask destination.
			folderBrowserDialog1.Description = menu + " to folder";
			if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
			{
				//copy the file(s).
				int cnt=0;
				string dst = folderBrowserDialog1.SelectedPath;
				Panel1.Text = "";
				foreach (ListViewItem item in listView1.SelectedItems)
				{
					string fileName = "\\"+item.Text;
					try
					{
						if (menu == "Move")
						{
							Directory.Move(src+fileName,dst+fileName);
							Panel1.Text = "File(s) moved to: " + dst+fileName;
						}
						else
						{
							File.Copy(src+fileName,dst+fileName,true);
							Panel1.Text = "File is copied to: " + dst+fileName;
						}
						++cnt;
					} 
					catch(Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
				}
				if (cnt!=1) Panel1.Text = String.Format("{0} file(s) {1}d to: {2}",cnt,menu,dst);//Format. cnt.ToString() + " files copied to: " + dst;
				listFiles(src);
			};

		}

	}
	public class SortSize : IComparer
	{
		private int sortOnColumn;
		public SortSize(int column)
		{
			sortOnColumn = column ;
		}
		public int Compare(object px,object py)
		{
			//			long x=Convert.ToInt64(((ListViewItem) px).SubItems[1].Text );
			//			long y=Convert.ToInt64(((ListViewItem) py).SubItems[1].Text );
			string sx=((ListViewItem) px).SubItems[sortOnColumn ].Text;
			string sy=((ListViewItem) py).SubItems[sortOnColumn ].Text;
			if (sortOnColumn==0) return (sx.CompareTo(sy));
			if (sortOnColumn==1)
			{
				long x=Int64.Parse(sx.Substring(0,sx.Length-2),NumberStyles.Any);
				long y=Int64.Parse(sy.Substring(0,sy.Length-2),NumberStyles.Any);
				return (int)(y-x);
			}
			else
			{
				DateTime x=DateTime.Parse(sx);// V102
				DateTime y=DateTime.Parse(sy);
				return y.CompareTo(x);
//				if (x.<y)
//					return 1;
//				else if (x==y)
//					return 0;
//				else
//					return -1;
			}
		}
	}
}
