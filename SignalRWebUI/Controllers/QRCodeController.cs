﻿using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace SignalRWebUI.Controllers
{
    public class QRCodeController : Controller
    {
        public IActionResult Index(string value)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                QRCodeGenerator createQRCode = new QRCodeGenerator();
                QRCodeGenerator.QRCode squareCode = createQRCode.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
                //Bitmap QRCOde image oluşturur
                using (Bitmap image = squareCode.GetGraphic(10))
                {
                    image.Save(memoryStream, ImageFormat.Png);
                    ViewBag.QRCodeImage = "data:Image/png;base64" + Convert.ToBase64String(memoryStream.ToArray());
                }
            }
            return View();
        }
    }
}
