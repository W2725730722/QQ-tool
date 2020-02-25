using System.IO;

namespace QQ工具
{
    public class 账号
    {
        public static string cookie = "";
        public static string qq = "10001";
        public static string name = "李四";

        Web web = new Web();

        public void Initialization_Data()
        {
            qq = web.GetDate(cookie, "ptui_loginuin");
            name = GetName();
            GetPic();
        }

        public string GetName()
        {
            string[] data = new Web().SendDataByPost("https://users.qzone.qq.com/fcg-bin/cgi_get_portrait.fcg", "uins=" + qq, "")["XML"].Split(',');
            return data[6].Trim().Replace("\"", "");
        }

        public void GetPic()
        {
            if (!File.Exists("pic/" + qq + ".jpg"))
            {
                bool b = new Web().HttpDownload("http://q2.qlogo.cn/headimg_dl?bs=qq&dst_uin=" + qq + "&spec=5", "pic/" + qq + ".jpg");
                if (!b)
                {
                    System.Windows.Forms.MessageBox.Show("头像获取失败!");
                }
            }
        }
        
        public string GetBkn()
        {
            string sKey = web.GetDate(cookie, "skey");
            var hash = 5381;
            for (int i = 0, len = sKey.Length; i < len; ++i)
                hash += (hash << 5) + (int)sKey[i];
            return (hash & 2147483647) + "";
        }

    }
}
