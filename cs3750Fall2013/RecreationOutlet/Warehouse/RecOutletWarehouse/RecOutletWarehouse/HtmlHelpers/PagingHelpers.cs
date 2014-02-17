using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecOutletWarehouse.Models;
using RecOutletWarehouse.Controllers;
using System.Text;

namespace RecOutletWarehouse.HtmlHelpers {
    public static class PagingHelpers {

        public static MvcHtmlString PageLinks(this HtmlHelper html,
                                              RecOutletWarehouse.Controllers.VendorController.PagingInfo pagingInfo,
                                              Func<int, string> pageUrl) {

            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages; i++) {
                TagBuilder tag = new TagBuilder("a"); //this creates <a> elements
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == pagingInfo.CurrentPage)
                    tag.AddCssClass("selected");
                result.Append(tag.ToString());
            }

            return MvcHtmlString.Create(result.ToString());
        }

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
    }
}