using Archery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Archery.Helpers
{
    public static class ArcheryHelpers
    {
        public static MvcHtmlString PictureTournament(this HtmlHelper helper, TournamentPicture picture, string cssClass = "")
        {
            var image = new TagBuilder("img");

            var base64 = Convert.ToBase64String(picture.Content);
            var src = $"data:{picture.ContentType};base64,{base64}";

            image.Attributes.Add("src", src);
            image.Attributes.Add("alt", picture.Name);
            if(! string.IsNullOrWhiteSpace(cssClass))
                image.Attributes.Add("class", cssClass);

            return MvcHtmlString.Create(image.ToString());
        }
    }
}