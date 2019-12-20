using System;
using Microsoft.AspNetCore.Mvc;

namespace PDFServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PDFController : ControllerBase
    {
        [HttpGet]
        public object Get()
        {
            return "Welcome to the test";
        }
        // GET api/values
        [HttpGet]
        [Route("getpdf")]
        public object GetPDF()
        {
            var pdfdata = System.IO.File.ReadAllBytes("sample.pdf");
            var bytesdata= Convert.ToBase64String(pdfdata, 0, pdfdata.Length);
          
            return bytesdata;
        }     
    }
}
