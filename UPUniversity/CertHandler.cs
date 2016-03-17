using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace UPUniversity
{
    public class CertHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            StudentLibrary studentLibrary = new StudentLibrary();
            Bitmap image = studentLibrary.GetCertificate(context.Request.Url.ToString());
            if (image != null)
            {
                context.Response.ContentType = "image/bmp";
                image.Save(context.Response.OutputStream, ImageFormat.Bmp);
            }
            else
                context.Response.Write("Invalid Student ID");
        }
    }
}