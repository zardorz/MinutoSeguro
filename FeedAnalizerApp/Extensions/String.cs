using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace System
{
    public static class StringExtension
    {
        public static string CleanString(this string value )
        {

            var decoded = ExtractHtmlInnerText(WebUtility.HtmlDecode(value));
            var cleanText = Regex.Replace(decoded, @"[^\w\d\s]", " ");

            return cleanText.ToLower();
             
        }

        //https://www.codeproject.com/Tips/477066/Extract-inner-text-from-HTML-using-Regex
        static string ExtractHtmlInnerText(string htmlText)
        { 
            var regex = new Regex("(<.*?>\\s*)+", RegexOptions.Singleline);
             
            string resultText = regex.Replace(htmlText, " ").Trim();

            return resultText;
        }
    }
}
