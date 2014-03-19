using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace RecOutletWarehouse.HtmlHelpers {
    public static class GeneralHelpers {

        /// <summary>
        /// Creates a general-purpose anchor tag that can be filled with model fields that are external URLs
        /// </summary>
        /// <param name="html"></param>
        /// <param name="url">The URL of the page to open</param>
        /// <param name="text">The text to be displayed</param>
        /// <param name="targetNewTab">Boolean indicating whether we're targeting a new tab or not</param>
        /// <returns></returns>
        public static MvcHtmlString SimpleExternalLink(this HtmlHelper html, string url, string text, Boolean targetNewTab) {
            StringBuilder result = new StringBuilder();
            TagBuilder tag = new TagBuilder("a");
            tag.MergeAttribute("href", "http://" + url); // Note: you must add the "http://" part in order to link to an external URL
            if (targetNewTab == true) {
                tag.MergeAttribute("target", "_blank");
            }
            tag.InnerHtml = url;

            result.Append(tag.ToString());

            return MvcHtmlString.Create(result.ToString());
        }
    }
}