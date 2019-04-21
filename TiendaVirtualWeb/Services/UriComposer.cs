using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaVirtualWeb.Services
{
    public class UriComposer
    {
        public static string ComposeUri(string pictureFilename)
        {
            return "~/Content/images/" + pictureFilename;
        }
    }
}