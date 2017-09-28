using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace App1
{
    public class HtmlRemoval
    {
        HtmlDocument _htmlDocument;
        public HtmlRemoval()
        {
            _htmlDocument = new HtmlDocument();
            _htmlDocument.ToString();
        }
        public string ConvertHtmlToPlainText(string htmlFragment)
        {
            _htmlDocument.DocumentNode.InnerHtml = htmlFragment;
            return HtmlEntity.DeEntitize(_htmlDocument.DocumentNode.InnerText);
        }

        
        public string ConvertHtmltoText(string text)
        {
            text = Regex.Replace(text, "(<br />|<[^<]+>|<img [^>]+>|<[^>]+>|\\&lt;|\\&gt;|\\&nbsp;|\\&quot;)", rg =>
            {
                switch (rg.Groups[0].Value)
                {
                    case "&quot;": return "\"";

                    case "&lt;": return "<";
                    case "&gt;": return ">";

                    case "</p>":
                    case "</li>":
                    case "</code>":
                    case "<hr>":
                    case "<br>":
                    case "<br />": return "\n";
                }

                if (Regex.IsMatch(rg.Groups[0].Value, "</h[0-9]+>"))
                    return "\n";

                if (rg.Groups[0].Value.Contains("src="))
                {
                    return new Regex("src=\"([^\"]+)\"").Match(rg.Groups[0].Value).Groups[1].Value;
                }

                return "";
            });

            return text;
        }
        
    }
}
