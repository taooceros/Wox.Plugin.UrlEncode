using System.Collections.Generic;
using System.Web;
using System.Windows;
using Flow.Launcher.Plugin;

namespace Flow.Plugin.UrlEncode
{
    public class Main : IPlugin
    {
        public List<Result> Query(Query query)
        {
            var list = new List<Result>();
            if (query.Search.Length == 0)
            {
                list.Add(new Result()
                {
                    IcoPath = "Images\\app.png",
                    Title = "Please input a string"
                });
                return list;
            }

            var str = query.Search;
            list.Add(new Result()
            {
                IcoPath = "Images\\encode.png",
                Title = HttpUtility.UrlEncode(str),
                SubTitle = "Copy to clipboard",
                Action = (c) =>
                {
                    Clipboard.SetDataObject(HttpUtility.UrlEncode(str));
                    return true;
                }
            });
            list.Add(new Result()
            {
                IcoPath = "Images\\decode.png",
                Title = HttpUtility.UrlDecode(str),
                SubTitle = "Copy to clipboard",
                Action = (c) =>
                {
                    Clipboard.SetDataObject(HttpUtility.UrlDecode(str));
                    return true;
                }
            });

            if (str.Contains("%"))
            {
                // may be a encode string, change order
                list.Reverse();
            }


            return list;
        }

        public void Init(PluginInitContext context)
        {
        }
    }
}