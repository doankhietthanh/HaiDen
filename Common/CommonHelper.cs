using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;

namespace Common
{
    public class CommonHelper
    {
        // Fields
        private static readonly string[] VietnameseSigns;
        private static Random random;

        // Methods
        static CommonHelper()
        {
            string[] textArray1 = new string[15];
            textArray1[0] = "aAeEoOuUiIdDyY";
            textArray1[1] = "\x00e1\x00e0ạả\x00e3\x00e2ấầậẩẫăắằặẳẵầấ";
            textArray1[2] = "\x00c1\x00c0ẠẢ\x00c3\x00c2ẤẦẬẨẪĂẮẰẶẲẴ";
            textArray1[3] = "\x00e9\x00e8ẹẻẽ\x00eaếềệểễ";
            textArray1[4] = "\x00c9\x00c8ẸẺẼ\x00caẾỀỆỂỄ";
            textArray1[5] = "\x00f3\x00f2ọỏ\x00f5\x00f4ốồộổỗơớờợởỡ";
            textArray1[6] = "\x00d3\x00d2ỌỎ\x00d5\x00d4ỐỒỘỔỖƠỚỜỢỞỠ";
            textArray1[7] = "\x00fa\x00f9ụủũưứừựửữ";
            textArray1[8] = "\x00da\x00d9ỤỦŨƯỨỪỰỬỮ";
            textArray1[9] = "\x00ed\x00ecịỉĩ";
            textArray1[10] = "\x00cd\x00ccỊỈĨ";
            textArray1[11] = "đ";
            textArray1[12] = "Đ";
            textArray1[13] = "\x00fdỳỵỷỹ";
            textArray1[14] = "\x00ddỲỴỶỸ";
            VietnameseSigns = textArray1;
            random = new Random();
        }

        public static string Convert_Currency(double value) =>
            $"{value:#,##0.##}đ";

        public static string Convert_CurrencyEn(double value) =>
            $"${value:#,##0.##}";

        public static List<T> ConvertToList<T>(DataTable dt)
        {
            List<string> columnNames = (from c in dt.Columns.Cast<DataColumn>() select c.ColumnName).ToList<string>();
            PropertyInfo[] properties = typeof(T).GetProperties();
            return dt.AsEnumerable().Select<DataRow, T>(delegate (DataRow row)
            {
                T local = Activator.CreateInstance<T>();
                foreach (PropertyInfo info in properties)
                {
                    if (columnNames.Contains(info.Name))
                    {
                        PropertyInfo property = local.GetType().GetProperty(info.Name);
                        info.SetValue(local, (row[info.Name] == DBNull.Value) ? null : Convert.ChangeType(row[info.Name], property.PropertyType));
                    }
                }
                return local;
            }).ToList<T>();
        }

        public static T CreateItemFromRow<T>(DataRow row) where T : new()
        {
            T item = Activator.CreateInstance<T>();
            SetItemFromRow<T>(item, row);
            return item;
        }

        public static string getLanguage()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["cookieLang"];
            if (cookie == null)
            {
                cookie = new HttpCookie("cookieLang", "vi-VN")
                {
                    Expires = DateTime.Now.AddDays(7.0)
                };
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            return Convert.ToString(cookie.Value);
        }

        public static string getResource(string key)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["cookieLang"];
            if (cookie == null)
            {
                cookie = new HttpCookie("cookieLang", "vi-VN")
                {
                    Expires = DateTime.Now.AddDays(7.0)
                };
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            string name = Convert.ToString(cookie.Value);
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(name);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(name);
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            return new ResourceManager("Resources.Lang", Assembly.Load("App_GlobalResources")).GetString(key, currentCulture);
        }

        public static string GetUser()
        {
            string str = "";
            HttpCookie cookie = HttpContext.Current.Request.Cookies["CookieUsersName"];
            if (cookie != null)
            {
                str = cookie.Value;
            }
            else
            {
                HttpCookie cookie2 = HttpContext.Current.Request.Cookies["SUsersName"];
                str = (cookie2 == null) ? "-1" : cookie2.Value;
            }
            return str;
        }

        public static string locDau(string str)
        {
            int index = 1;
            while (index < VietnameseSigns.Length)
            {
                int num2 = 0;
                while (true)
                {
                    if (num2 >= VietnameseSigns[index].Length)
                    {
                        str = str.Replace("“", "").Replace("”", "").Replace(":", "").Replace("/", "").Replace("?", "").Replace("\"", "").Replace("'", "");
                        str = str.Replace(" ", "-").ToLower();
                        index++;
                        break;
                    }
                    str = str.Replace(VietnameseSigns[index][num2], VietnameseSigns[0][index - 1]);
                    num2++;
                }
            }
            return str;
        }

        public static string locDau_v2(string str)
        {
            int index = 1;
            while (index < VietnameseSigns.Length)
            {
                int num2 = 0;
                while (true)
                {
                    if (num2 >= VietnameseSigns[index].Length)
                    {
                        str = str.Replace("“", "").Replace("”", " ").Replace(":", " ").Replace("/", " ").Replace("?", " ").Replace("-", " ");
                        str = str.Trim().Replace(" ", "-").Replace("&", "").ToLower();
                        index++;
                        break;
                    }
                    str = str.Replace(VietnameseSigns[index][num2], VietnameseSigns[0][index - 1]);
                    num2++;
                }
            }
            return str;
        }

        public static string Meta_For_Seo(baseMeta bm)
        {
            string[] textArray1 = new string[0x11];
            textArray1[0] = "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" /><link href=\"favicon.ico\" rel=\"shortcut icon\" type=\"image/x-icon\" /><meta http-equiv=\"content-language\" content=\"vi\" /><title>";
            textArray1[1] = bm.Title;
            textArray1[2] = "</title><meta name=\"description\" content=\"";
            textArray1[3] = bm.Des;
            textArray1[4] = "\" /><meta name=\"keywords\" content=\"";
            textArray1[5] = bm.Key;
            textArray1[6] = "\" /><meta name=\"robots\" content=\"";
            textArray1[7] = bm.Robot;
            textArray1[8] = "\" /><meta name='revisit-after' content='1 days' /><meta property=\"og:title\" itemprop=\"url\" content=\"";
            textArray1[9] = bm.Title;
            textArray1[10] = "\"/><meta property=\"og:url\" itemprop=\"url\" content=\"";
            textArray1[11] = bm.Url;
            textArray1[12] = "\"/><meta property=\"og:image\" itemprop=\"thumbnailUrl\" content=\"";
            textArray1[13] = bm.Image;
            textArray1[14] = "\"/><meta content=\"";
            textArray1[15] = bm.Des;
            textArray1[0x10] = "\" itemprop=\"description\" property=\"og:description\"/><meta property=\"og:type\" content=\"website\" />";
            return string.Concat(textArray1);
        }

        public static string RandomString(int length) =>
            new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", length) select s[random.Next(s.Length)]).ToArray<char>());

        public static void SetItemFromRow<T>(T item, DataRow row) where T : new()
        {
            foreach (DataColumn column in row.Table.Columns)
            {
                PropertyInfo property = item.GetType().GetProperty(column.ColumnName);
                if ((property != null) && (row[column] != DBNull.Value))
                {
                    property.SetValue(item, row[column], null);
                }
            }
        }

        public static string ToMD5_v2(string str)
        {
            StringBuilder builder = new StringBuilder();
            foreach (byte num2 in new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(str)))
            {
                builder.Append($"{num2:x2}");
            }
            return builder.ToString();
        }

    }



}