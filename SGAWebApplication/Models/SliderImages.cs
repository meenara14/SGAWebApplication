using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGAWebApplication.Models
{
    public class SliderImages
    {
        public int Id { get; set; }
        public string ImgName { get; set; }
        public string Extension { get; set; }
        public byte[] Data { get; set; }       
        public string ImgContent { get; set; }
        public string ImgTitle { get; set; }
    }
}
