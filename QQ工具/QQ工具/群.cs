using Newtonsoft.Json;
using System.Collections.Generic;

namespace QQ工具
{
    public class 群
    {
        public object[] GetQunList()
        {
            账号 zh = new 账号();
            string json = new Web().SendDataByPost("https://qun.qq.com/cgi-bin/qun_mgr/get_group_list", "bkn=" + new 账号().GetBkn(), 账号.cookie)["XML"];

            Root root = JsonConvert.DeserializeObject<Root>(json);

            object[] quns = { root.join, root.create };

            return quns;
        }
        
        #region 实体类
        public class Join
        {
            /// <summary>
            /// 群号
            /// </summary>
            public string gc { get; set; }
            /// <summary>
            /// 群名
            /// </summary>
            public string gn { get; set; }
            /// <summary>
            /// 群主qq
            /// </summary>
            public string owner { get; set; }
        }

        public class Create
        {
            /// <summary>
            /// 群号
            /// </summary>
            public string gc { get; set; }
            /// <summary>
            /// 群名
            /// </summary>
            public string gn { get; set; }
            /// <summary>
            /// 群主qq
            /// </summary>
            public string owner { get; set; }
        }

        public class Root
        {
            /// <summary>
            /// 加入的群
            /// </summary>
            public List<Join> join { get; set; }
            /// <summary>
            /// 创建的群
            /// </summary>
            public List<Create> create { get; set; }
        }

        #endregion

    }
}
