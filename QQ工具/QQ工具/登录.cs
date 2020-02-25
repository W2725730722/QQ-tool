using System.Windows.Forms;
using MaterialSkin.Controls;

namespace QQ工具
{
    public partial class 登录 : MaterialForm
    {
        public 登录()
        {
            InitializeComponent();
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (webBrowser1.Url.ToString().IndexOf("https://qun.qq.com/") == 0)
            {
                账号.cookie = Web.GetCookieString("https://qun.qq.com/");
                Close();
            }
        }
    }
}
