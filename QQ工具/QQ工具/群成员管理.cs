using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using static QQ工具.群成员;
using System.Threading;

namespace QQ工具
{
    public partial class 群成员管理 : MaterialForm
    {

        SynchronizationContext m_SyncContext = null;//ui线程
        string id = "";

        public 群成员管理(string ids)
        {
            InitializeComponent();
            id = ids;
            m_SyncContext = SynchronizationContext.Current;
        }


        private void 群成员管理_Load(object sender, EventArgs e)
        {
            new Thread(delegate ()
            {
                List<MemsItem> m = new 群成员().GetQunUserList(id);
                m_SyncContext.Post(LoadList, m);
            }).Start();
        }

        private void LoadList(object state)
        {
            foreach (MemsItem item in (List<MemsItem>)state)
            {
                ListViewItem items = new ListViewItem(item.nick.Replace("&nbsp;", " "));
                string sf = "";
                switch (item.role)
                {
                    case 0:
                        sf = "群主";
                        break;
                    case 1:
                        sf = "管理员";
                        break;
                    default:
                        sf = "群成员";
                        break;
                }
                Thread.Sleep(3);
                materialProgressBar1.Value = materialProgressBar1.Value < 100 ? materialProgressBar1.Value + 1 : 100;
                items.SubItems.Add(sf);
                items.SubItems.Add(item.lv.level + "");
                items.SubItems.Add(item.uin);
                items.SubItems.Add(item.card);
                if (item.role < 2)
                {
                    items.Group = materialListView1.Groups[0];
                }
                else
                {

                    items.Group = materialListView1.Groups[1];
                }
                materialListView1.Items.Add(items);
            }
            materialProgressBar1.Visible = false;
        }

        private void 修改昵称ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<user> list = new List<user>();
            for (int i = 0; i < materialListView1.SelectedItems.Count; i++)
            {
                user s = new user();
                s.name  = materialListView1.SelectedItems[i].SubItems[0].Text;
                s.qname = materialListView1.SelectedItems[i].SubItems[4].Text;
                s.role = materialListView1.SelectedItems[i].SubItems[1].Text;
                s.qq = materialListView1.SelectedItems[i].SubItems[3].Text;
                list.Add(s);
            }
            群成员昵称修改 q = new 群成员昵称修改(list,id);
            q.ShowDialog();
        }

        public class user{
            public string name = "";
            public string qname = "";
            public string role = "";
            public string qq = "";
        }

        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < materialListView1.Items.Count; i++)
            {
                materialListView1.Items[i].Selected = true;
            }
        }

        private void 全不选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < materialListView1.Items.Count; i++)
            {
                materialListView1.Items[i].Selected = false;
            }
        }

        private void 反选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < materialListView1.Items.Count; i++)
            {
                materialListView1.Items[i].Selected = !materialListView1.Items[i].Selected;
            }
        }
    }
}
