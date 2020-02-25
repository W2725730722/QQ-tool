namespace QQ工具
{
    partial class 群成员管理
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("群主与管理员", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("群成员", System.Windows.Forms.HorizontalAlignment.Left);
            this.materialListView1 = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.materialContextMenuStrip1 = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.修改昵称ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materialProgressBar1 = new MaterialSkin.Controls.MaterialProgressBar();
            this.选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全选ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全不选ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.反选ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materialContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialListView1
            // 
            this.materialListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialListView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.materialListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.materialListView1.ContextMenuStrip = this.materialContextMenuStrip1;
            this.materialListView1.Depth = 0;
            this.materialListView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.materialListView1.FullRowSelect = true;
            listViewGroup1.Header = "群主与管理员";
            listViewGroup1.Name = "a";
            listViewGroup2.Header = "群成员";
            listViewGroup2.Name = "b";
            this.materialListView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.materialListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.materialListView1.LabelWrap = false;
            this.materialListView1.Location = new System.Drawing.Point(0, 65);
            this.materialListView1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialListView1.MouseState = MaterialSkin.MouseState.OUT;
            this.materialListView1.Name = "materialListView1";
            this.materialListView1.OwnerDraw = true;
            this.materialListView1.Size = new System.Drawing.Size(700, 535);
            this.materialListView1.TabIndex = 0;
            this.materialListView1.UseCompatibleStateImageBehavior = false;
            this.materialListView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "昵称";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "身份";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.DisplayIndex = 3;
            this.columnHeader3.Text = "活跃等级";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.DisplayIndex = 4;
            this.columnHeader4.Text = "QQ";
            this.columnHeader4.Width = 2000;
            // 
            // columnHeader5
            // 
            this.columnHeader5.DisplayIndex = 2;
            this.columnHeader5.Text = "群昵称";
            this.columnHeader5.Width = 150;
            // 
            // materialContextMenuStrip1
            // 
            this.materialContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialContextMenuStrip1.Depth = 0;
            this.materialContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.修改昵称ToolStripMenuItem,
            this.选择ToolStripMenuItem});
            this.materialContextMenuStrip1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialContextMenuStrip1.Name = "materialContextMenuStrip1";
            this.materialContextMenuStrip1.Size = new System.Drawing.Size(153, 70);
            // 
            // 修改昵称ToolStripMenuItem
            // 
            this.修改昵称ToolStripMenuItem.Name = "修改昵称ToolStripMenuItem";
            this.修改昵称ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.修改昵称ToolStripMenuItem.Text = "修改昵称";
            this.修改昵称ToolStripMenuItem.Click += new System.EventHandler(this.修改昵称ToolStripMenuItem_Click);
            // 
            // materialProgressBar1
            // 
            this.materialProgressBar1.Depth = 0;
            this.materialProgressBar1.Location = new System.Drawing.Point(290, 300);
            this.materialProgressBar1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialProgressBar1.Name = "materialProgressBar1";
            this.materialProgressBar1.Size = new System.Drawing.Size(100, 5);
            this.materialProgressBar1.TabIndex = 1;
            this.materialProgressBar1.Value = 25;
            // 
            // 选择ToolStripMenuItem
            // 
            this.选择ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.全选ToolStripMenuItem,
            this.全不选ToolStripMenuItem,
            this.反选ToolStripMenuItem});
            this.选择ToolStripMenuItem.Name = "选择ToolStripMenuItem";
            this.选择ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.选择ToolStripMenuItem.Text = "选择";
            // 
            // 全选ToolStripMenuItem
            // 
            this.全选ToolStripMenuItem.Name = "全选ToolStripMenuItem";
            this.全选ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.全选ToolStripMenuItem.Text = "全选";
            this.全选ToolStripMenuItem.Click += new System.EventHandler(this.全选ToolStripMenuItem_Click);
            // 
            // 全不选ToolStripMenuItem
            // 
            this.全不选ToolStripMenuItem.Name = "全不选ToolStripMenuItem";
            this.全不选ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.全不选ToolStripMenuItem.Text = "全不选";
            this.全不选ToolStripMenuItem.Click += new System.EventHandler(this.全不选ToolStripMenuItem_Click);
            // 
            // 反选ToolStripMenuItem
            // 
            this.反选ToolStripMenuItem.Name = "反选ToolStripMenuItem";
            this.反选ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.反选ToolStripMenuItem.Text = "反选";
            this.反选ToolStripMenuItem.Click += new System.EventHandler(this.反选ToolStripMenuItem_Click);
            // 
            // 群成员管理
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 600);
            this.Controls.Add(this.materialProgressBar1);
            this.Controls.Add(this.materialListView1);
            this.Name = "群成员管理";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "群成员管理";
            this.Load += new System.EventHandler(this.群成员管理_Load);
            this.materialContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialListView materialListView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private MaterialSkin.Controls.MaterialProgressBar materialProgressBar1;
        private MaterialSkin.Controls.MaterialContextMenuStrip materialContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 修改昵称ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选择ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全选ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全不选ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 反选ToolStripMenuItem;
    }
}