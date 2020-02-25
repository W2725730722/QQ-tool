using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QQ工具
{
    public class 群成员
    {
        public List<MemsItem> GetQunUserList(string qunID)
        {
            List<MemsItem> list = new List<MemsItem>();
            int max = 0;
            //qq群最多 2000人 所以 2000/20 = 200 填201保险
            for (int i = 0; i < 201; i = i + 21)
            {
                string data = "gc=" + qunID + "&st=" + i + "&end=" + (i == 0 || (i + 20) <= max ? i + 20 : max) + "&sort=0&bkn=" + new 账号().GetBkn();
                string json = new Web().SendDataByPost("https://qun.qq.com/cgi-bin/qun_mgr/search_group_members", data, 账号.cookie)["XML"];
                if (json.Length > 28 && json.IndexOf("{") == 0)
                {
                    Root root = JsonConvert.DeserializeObject<Root>(json);
                    max = max == 0 ? root.count : max;
                    list.AddRange(root.mems);
                }
                else
                {
                    break;
                }
            }

            return list;
        }

        #region 实体类
        public class Lv
        {
            /// <summary>
            /// 经验
            /// </summary>
            public int point { get; set; }
            /// <summary>
            /// 等级
            /// </summary>
            public int level { get; set; }
        }

        public class MemsItem
        {

            /// <summary>
            /// 身份 0.群主 1.管理 2.群成员
            /// </summary>
            public int role { get; set; }
            /// <summary>
            /// QQ
            /// </summary>
            public string uin { get; set; }
            /// <summary>
            /// 等级
            /// </summary>
            public Lv lv { get; set; }
            /// <summary>
            /// 昵称
            /// </summary>
            public string nick { get; set; }
            /// <summary>
            /// 群昵称
            /// </summary>
            public string card { get; set; }
        }

        public class Root
        {
            /// <summary>
            /// 成员列表
            /// </summary>
            public List<MemsItem> mems { get; set; }

            /// <summary>
            /// 总人数
            /// </summary>
            public int count { get; set; }
        }
        #endregion

    }
}
