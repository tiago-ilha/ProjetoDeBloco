using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoDeBloco.UI.Helpers
{
    public static class HtmlHelpers
    {
        private class ScriptBlock : IDisposable
        {
            private const string scriptKey = "scripts";

            public static List<string> pageScripts
            {
                get
                {
                    if (HttpContext.Current.Items[scriptKey] == null)
                        HttpContext.Current.Items[scriptKey] = new List<string>();
                    return (List<string>)HttpContext.Current.Items[scriptKey];
                }
            }

            WebViewPage webPageBase;

            public ScriptBlock(WebViewPage webPageBase)
            {
                this.webPageBase = webPageBase;
                this.webPageBase.OutputStack.Push(new StringWriter());
            }

            public void Dispose()
            {
                pageScripts.Add(((StringWriter)this.webPageBase.OutputStack.Pop()).ToString());
            }
        }

        public static IDisposable BeginScripts(this HtmlHelper helper)
        {
            return new ScriptBlock((WebViewPage)helper.ViewDataContainer);
        }

        public static MvcHtmlString PageScripts(this HtmlHelper helper)
        {
            return MvcHtmlString.Create(string.Join(Environment.NewLine, ScriptBlock.pageScripts.Select(s => s.ToString())));
        }
    }
}