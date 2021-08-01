using CoreHtmlToImage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MiMailIdentity.Helper.TempLateHelper
{
    public static class TeampLateHelper
    {
        public static void ConvertHtmlToImage(string collection)
        {
            var converter = new HtmlConverter();
            var html = "<div><strong>Hello</strong> World!</div>";
            var bytes = converter.FromHtmlString(html);
            File.WriteAllBytes("image.jpg", bytes);
            using (MemoryStream stream = new MemoryStream())
            {
                Thread thr = new Thread(delegate() {
                   

                });
                thr.SetApartmentState(ApartmentState.STA);
                thr.Join();
            }
        }
    }
}
