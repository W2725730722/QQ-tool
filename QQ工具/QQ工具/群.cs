using Newtonsoft.Json;
using System.Collections.Generic;

namespace QQ工具
{
    public class 群
    {
        public List<Group> GetQunList()
        {
            账号 zh = new 账号();
            string json = new Web().SendDataByPost("http://qun.qzone.qq.com/cgi-bin/get_group_list", "uin=" + zh.qq + "&g_tk=" + zh.GetBkn(), 账号.cookie)["XML"];
            json = json.Replace("_Callback(", "");
            json = json.Replace(");", "");
            
            Root root = JsonConvert.DeserializeObject<Root>(json);
            return root.data.group;
        }

        public class Group
        {
            /// <summary>
            /// 群号
            /// </summary>
            public int groupid { get; set; }
            /// <summary>
            /// 群名
            /// </summary>
            public string groupname { get; set; }
        }

        public class Data
        {
            /// <summary>
            /// 群列表
            /// </summary>
            public List<Group> group { get; set; }
        }

        public class Root
        {
            /// <summary>
            /// 数据
            /// </summary>
            public Data data { get; set; }
        }
    }
}
