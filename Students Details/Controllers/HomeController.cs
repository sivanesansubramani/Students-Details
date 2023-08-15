using GenerateQRCode_Demo.Models;
using IronBarCode;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Students_Details.Models;
using Students_Details.Repository;

namespace GenerateQRCode_Demo.Controllers
{
    public class HomeController : Controller
    {


        StudentDetailsRepo ObjRepository;

        public HomeController()
        {
            ObjRepository = new StudentDetailsRepo();
        }


        private readonly IWebHostEnvironment _environment;
        public HomeController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public IActionResult CreateQRCode()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateQRCode(GenerateQRCodeModel generateQRCode)
        {
            try
            {
                GeneratedBarcode barcode = QRCodeWriter.CreateQrCode(generateQRCode.QRCodeText, 200);
                barcode.AddBarcodeValueTextBelowBarcode();
                // Styling a QR code and adding annotation text
                barcode.SetMargins(10);
                barcode.ChangeBarCodeColor(Color.BlueViolet);
                string path = Path.Combine(_environment.WebRootPath, "GeneratedQRCode");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string filePath = Path.Combine(_environment.WebRootPath, "GeneratedQRCode/qrcode.png");
                barcode.SaveAsPng(filePath);
                string fileName = Path.GetFileName(filePath);
                string imageUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}" + "/GeneratedQRCode/" + fileName;
                ViewBag.QrCodeUri = imageUrl;
            }
            catch (Exception)
            {
                throw;
            }
            return View();
        }




    }
}