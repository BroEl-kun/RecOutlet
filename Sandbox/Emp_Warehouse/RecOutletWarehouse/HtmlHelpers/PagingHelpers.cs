using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecOutletWarehouse.Models;
using RecOutletWarehouse.Utilities;
using System.Text;

namespace RecOutletWarehouse.HtmlHelpers {
    /// <summary>
    /// PagingHelpers is a static utility class that provides methods for list pagination.
    /// IMPORTANT: If you want to use any of these methods in your View, make sure you include
    /// a @using statement at the beginning of the .cshtml file (@using lines must come before
    /// you declare your model). See BrowseVendors.cshtml for a working implementation.
    /// </summary>
    public static class PagingHelpers {

        /// <summary>
        /// Allows you to split a list into numbered pages. This version limits the number of links displayed.
        /// </summary>
        /// <param name="html"></param>
        /// <param name="pagingInfo">A PagingInfo object defining your page attributes.</param>
        /// <param name="pageUrl">The URL of the list View to be paginated.</param>
        /// <returns>An HTML string that creates the page links.</returns>
        /// Changelog
        ///     Version 1.0 (T.M.)
        ///         - Initial creation
        public static MvcHtmlString PageLinks(this HtmlHelper html,
                                              PagingInfo pagingInfo, // PagingInfo is from the Utilities folder
                                              Func<int, string> pageUrl) {

            StringBuilder result = new StringBuilder();
            TagBuilder tag;
            if (pagingInfo.CurrentPage != 1) {
                tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(1));
                tag.InnerHtml = "<<< FIRST";
                result.Append(tag.ToString());
                tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(pagingInfo.CurrentPage - 1));
                tag.InnerHtml = "< PREVIOUS";
                result.Append(tag.ToString());
            }
            for (int i = pagingInfo.CurrentPage - 5; i <= pagingInfo.CurrentPage + 5; i++) {
                if (i < 1) {
                    continue;
                }
                if (i > pagingInfo.TotalPages) {
                    break;
                }
                tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == pagingInfo.CurrentPage)
                    tag.AddCssClass("selected");
                result.Append(tag.ToString());
            }
            if (pagingInfo.CurrentPage != pagingInfo.TotalPages) {
                tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(pagingInfo.CurrentPage + 1));
                tag.InnerHtml = "NEXT >";
                result.Append(tag.ToString());
                tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(pagingInfo.TotalPages));
                tag.InnerHtml = "LAST >>>";
                result.Append(tag.ToString());
            }
            //for (int i = 1; i <= pagingInfo.TotalPages; i++) {
            //    TagBuilder tag = new TagBuilder("a"); //this creates <a> elements
            //    tag.MergeAttribute("href", pageUrl(i));
            //    tag.InnerHtml = i.ToString();
            //    if (i == pagingInfo.CurrentPage)
            //        tag.AddCssClass("selected");
            //    result.Append(tag.ToString());
            //}

            return MvcHtmlString.Create(result.ToString());
        }

        /// <summary>
        /// Creates a list of HTML anchor elements corresponding to each letter of the alphabet.
        /// Assumes that the name of the "first letter" variable is firstLetter.
        /// </summary>
        /// <param name="html"></param>
        /// <param name="pageUrl">The URL of the list View to be paginated.</param>
        /// <returns>An HTML string containg A-Z anchor elements.</returns>
        /// <author>T.M.</author>
        public static MvcHtmlString RolodexLinks(this HtmlHelper html, Func<int, string> pageUrl) {
            StringBuilder rolodex = new StringBuilder();
            for (int i = 65; i <= 90; i++) { // Using ASCII decimal equivalents of all capital letters
                TagBuilder tag = new TagBuilder("a");
                tag.InnerHtml = Convert.ToChar(i).ToString();
                tag.MergeAttribute("href", pageUrl(i).ToString() + "?firstLetter=" + Convert.ToChar(i));
                rolodex.Append(tag.ToString());

            }

            return MvcHtmlString.Create(rolodex.ToString());
        }

        /// <summary>
        /// Creates a list of HTML anchor elements corresponding to each letter of the alphabet.
        /// Allows you to specify the name of the "first letter" variable.
        /// </summary>
        /// <param name="html"></param>
        /// <param name="varSpecifier">The name of the "first letter" variable of the Controller method</param>
        /// <param name="pageUrl">The URL of the list View to be paginated.</param>
        /// <returns>An HTML string containg A-Z anchor elements.</returns>
        /// <author>T.M.</author>
        public static MvcHtmlString RolodexLinks(this HtmlHelper html, string varSpecifier, Func<int, string> pageUrl) {
            StringBuilder rolodex = new StringBuilder();
            for (int i = 65; i <= 90; i++) { // Using ASCII decimal equivalents of all capital letters
                TagBuilder tag = new TagBuilder("a");
                tag.InnerHtml = Convert.ToChar(i).ToString();
                tag.MergeAttribute("href", pageUrl(i).ToString() + "?" + varSpecifier + "=" + Convert.ToChar(i));
                rolodex.Append(tag.ToString());

            }

            return MvcHtmlString.Create(rolodex.ToString());
        }
    }
}