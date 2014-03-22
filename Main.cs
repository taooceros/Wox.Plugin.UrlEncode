using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Windows.Forms;

namespace Wox.Plugin.UrlEncode
{
    public class Main : IPlugin
    {
        

        public List<Result> Query(Query query)
        {
            var list = new List<Result>();
            if (query.ActionParameters.Count == 0)
            {
                list.Add(new Result() {
                  IcoPath ="Images\\app.png",
                   Title = "Please input a string"
                });
                return list;
            }

            if (query.ActionParameters.Count > 0)
            {
                var str = query.ActionParameters[0];
                list.Add(new Result()
                {
                    IcoPath = "Images\\encode.png",
                    Title = HttpUtility.UrlEncode(str),
                    SubTitle = "Copy to clipboard",
                    Action = (c) =>
                    {
                        Clipboard.SetText(HttpUtility.UrlEncode(str));
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
                        Clipboard.SetText(HttpUtility.UrlDecode(str));
                        return true;
                    }
                });

                if (str.Contains("%"))
                {
                    // may be a encode string, change order
                    list.Reverse();
                }
            }

            return list;
        }

        public void Init(PluginInitContext context)
        {

        }
    }
}
