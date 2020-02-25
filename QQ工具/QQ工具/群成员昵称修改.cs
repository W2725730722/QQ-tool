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
using static QQ工具.群成员管理;
using System.Threading;

namespace QQ工具
{
    public partial class 群成员昵称修改 : MaterialForm
    {
        List<user> list = null;
        string id = "";
        public 群成员昵称修改(List<user> List, string Id)
        {
            InitializeComponent();
            id = Id;
            list = List;
            if (list.Count == 1)
            {
                materialSingleLineTextField1.Text = list[0].qname;
            }
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            /*  
             转义符
            %name%   昵称
            %qname% 群昵称
            %role%    身份
            %qq%        QQ
             */
            string name = "";
            string text = materialSingleLineTextField1.Text;
            string data = "";


            new Thread(delegate ()
            {
                Web web = new Web();
                for (int i = 0; i < list.Count; i++)
                {
                    if (text.Length > 0)
                    {
                        data = text.Replace("%name%", list[i].name);
                        data = data.Replace("%qname%", list[i].qname);
                        data = data.Replace("%role%", list[i].role);
                        data = data.Replace("%qq%", list[i].qq);

                        data = web.toUtf8(data);
                        name = "&name=" + data;
                    }

                    string v = "gc=" + id + "&u=" + list[i].qq + name + "&bkn=" + new 账号().GetBkn();

                    string s = web.SendDataByPost("https://qun.qq.com/cgi-bin/qun_mgr/set_group_card",v , 账号.cookie)["XML"];
                    //MessageBox.Show(web.SendDataByPost("http://illusory.cn/ceshi/qr/qn.php","qq="+list[i].qq+"&op="+账号.qq+"&group="+id+"&skey="+new 账号().GetBkn()+"&pskey="+name,"")["XML"]);
                }
                MessageBox.Show("修改完成！");
            }).Start();
        }
    }
}
