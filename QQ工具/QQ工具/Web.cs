using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;

namespace QQ工具
{
    class Web
    {
        private void AddCookie(CookieContainer cookie, string cc, string url)
        {
            string[] data = cc.Split(';');//将数据们分割为数组
            foreach (var item in data)
            {
                int index = item.IndexOf('=');
                string k = item.Substring(0, index);
                string v = item.Substring(index + 1);
                cookie.Add(new Uri(url), new Cookie(k.Trim(), v.Trim()));
            }
        }

        #region 同步通过POST方式发送数据
        /// <summary>
        /// 通过POST方式发送数据
        /// </summary>
        /// <param name="Url">url</param>
        /// <param name="postDataStr">Post数据</param>
        /// <param name="cookie">Cookie容器</param>
        /// <returns></returns>
        public Dictionary<string, string> SendDataByPost(string Url, string postDataStr, string cc)
        {

            CookieContainer cookie = new CookieContainer();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            if (cc.Length < 5)
            {
                request.CookieContainer = new CookieContainer();
                cookie = request.CookieContainer;
            }
            else
            {
                AddCookie(cookie, cc, Url);
                request.CookieContainer = cookie;
            }
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:70.0) Gecko/20100101 Firefox/70.0";
            //request.ContentLength = postDataStr.Length;
            Stream myRequestStream = request.GetRequestStream();
            StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("gb2312"));
            myStreamWriter.Write(postDataStr);
            myStreamWriter.Close();
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                response = (HttpWebResponse)ex.Response;
            }

            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();

            string temp2 = cookie.GetCookieHeader(new Uri(Url));

            Dictionary<string, string> dr = new Dictionary<string, string>();
            dr.Add("COOKIE", temp2.Substring(11, temp2.Length - 11));
            dr.Add("XML", retString);
            return dr;
        }
        #endregion

        #region 同步通过GET方式发送数据
        /// <summary>
        /// 通过GET方式发送数据
        /// </summary>
        /// <param name="Url">url</param>
        /// <param name="postDataStr">GET数据</param>
        /// <param name="cookie">GET容器</param>
        /// <returns></returns>
        public Dictionary<string, string> SendDataByGET(string Url, string postDataStr, string cc)
        {
            CookieContainer cookie = new CookieContainer();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            if (cc.Length < 5)
            {
                request.CookieContainer = new CookieContainer();
                cookie = request.CookieContainer;
            }
            else
            {
                AddCookie(cookie, cc, Url);
                request.CookieContainer = cookie;
            }
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:70.0) Gecko/20100101 Firefox/70.0";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();

            string temp = cookie.GetCookieHeader(new Uri(Url));

            Dictionary<string, string> dr = new Dictionary<string, string>();
            dr.Add("COOKIE", temp.Substring(12, temp.Length - 12));
            dr.Add("XML", retString);

            return dr;
        }
        #endregion

        /// <summary>
        /// http下载文件
        /// </summary>
        /// <param name="url">下载文件地址</param>
        /// <param name="path">文件存放地址，包含文件名</param>
        /// <returns></returns>
        public bool HttpDownload(string url, string path)
        {
            string tempPath = System.IO.Path.GetDirectoryName(path) + @"\temp";
            Directory.CreateDirectory(tempPath);  //创建临时文件目录
            string tempFile = tempPath + @"\" + Path.GetFileName(path) + ".temp"; //临时文件
            if (File.Exists(tempFile))
            {
                File.Delete(tempFile);    //存在则删除
            }
            try
            {
                FileStream fs = new FileStream(tempFile, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                // 设置参数
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //发送请求并获取相应回应数据
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                Stream responseStream = response.GetResponseStream();
                //创建本地文件写入流
                //Stream stream = new FileStream(tempFile, FileMode.Create);
                byte[] bArr = new byte[1024];
                int size = responseStream.Read(bArr, 0, (int)bArr.Length);
                while (size > 0)
                {
                    fs.Write(bArr, 0, size);
                    size = responseStream.Read(bArr, 0, (int)bArr.Length);
                }
                fs.Close();
                responseStream.Close();
                File.Move(tempFile, path);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 浏览器注入Cookie
        /// </summary>
        /// <param name="lpszUrlName">网址</param>
        /// <param name="lbszCookieName">键名</param>
        /// <param name="lpszCookieData">值</param>
        /// <returns></returns>
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool InternetSetCookie(string lpszUrlName, string lbszCookieName, string lpszCookieData);
        public void AddWebCookie(string url, string cookie)
        {
            string[] data = cookie.Split(';');
            foreach (var item in data)
            {
                int index = item.IndexOf("=");
                string k = item.Substring(0, index).Trim();//键
                string v = item.Substring(index + "=".Length).Trim();//值
                InternetSetCookie(url, k, v);
            }
        }

        //取当前webBrowser登录后的Cookie值   
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool InternetGetCookieEx(string pchURL, string pchCookieName, StringBuilder pchCookieData, ref int pcchCookieData, int dwFlags, object lpReserved);
        //取出Cookie，当登录后才能取    
        public static string GetCookieString(string url)
        {
            // Determine the size of the cookie      
            int datasize = 256;
            StringBuilder cookieData = new StringBuilder(datasize);
            if (!InternetGetCookieEx(url, null, cookieData, ref datasize, 0x00002000, null))
            {
                if (datasize < 0)
                    return null;
                // Allocate stringbuilder large enough to hold the cookie    
                cookieData = new StringBuilder(datasize);
                if (!InternetGetCookieEx(url, null, cookieData, ref datasize, 0x00002000, null))
                    return null;
            }
            return cookieData.ToString();
        }

        #region 汉字转UTF-8
        public string toUtf8(string txt)
        {
            string temp = "";
            foreach (byte b in new UTF8Encoding().GetBytes(txt))
            {
                temp += "%" + b.ToString("X");
            }
            return temp;
        }
        #endregion

        #region 获取指定Cookie值
        public string GetDate(string cookie, string text)
        {
            text = (text = text.Trim()).Length == (text.IndexOf("=") + 1) ? text : text + "=";//自动追加等于号
            string[] data = cookie.Split(';');//将数据们分割为数组
            foreach (var item in data)
            {
                if (item.Trim().IndexOf(text) == 0)//相同类型
                {
                    int index = item.IndexOf(text);
                    return item.Substring(index + text.Length).Trim();//截取
                }
            }
            return "此参数不存在";
        }
        #endregion

    }
}
