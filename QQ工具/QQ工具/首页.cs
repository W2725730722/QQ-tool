using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin.Controls;
using System.Threading;
using static QQ工具.群;

namespace QQ工具
{
    public partial class 首页 : MaterialForm
    {
        public 首页()
        {
            InitializeComponent();
        }

        群 qun = new 群();
        Web web = new Web();
        账号 账号 = new 账号();

        private void 首页_Load(object sender, EventArgs e)
        {

            new 登录().ShowDialog();
            if (账号.cookie.Length > 5)
            {
                账号.Initialization_Data();
                materialLabel1.Text = 账号.name;
                materialLabel2.Text = 账号.qq;
                pictureBox1.Image = Image.FromFile("pic/" + 账号.qq + ".jpg");

                List<Group> group = qun.GetQunList();
                foreach (Group item in group)
                {
                    ListViewItem items = new ListViewItem(item.groupname);
                    items.SubItems.Add(item.groupid + "");
                    materialListView1.Items.Add(items);
                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void 签到ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < materialListView1.SelectedItems.Count; i++)
            {
                list.Add(materialListView1.SelectedItems[i].SubItems[1].Text);
            }
            new Thread(delegate ()
            {
                foreach (string id in list)
                {
                    string data = "bkn=" + 账号.GetBkn() + "&template_data=&gallery_info={\"category_id\":9,\"page\":0,\"pic_id\":1}&template_id=2&gc=" + id + "&client=2&lgt=0&lat=0&poi="+web.toUtf8("火星")+"&pic_id=&text="+web.toUtf8("签到");
                    string xml = web.SendDataByPost("http://qun.qq.com/cgi-bin/qiandao/sign/publish", data, 账号.cookie)["XML"];
                }
                list.Clear();
                MessageBox.Show("签到完成");
            }).Start();
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
