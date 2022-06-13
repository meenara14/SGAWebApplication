using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGAWebApplication.Models
{
    public class ServicesMstr
    {
        public int Id { get; set; }
        public string ImgName { get; set; }
        public string Extension { get; set; }
        public byte[] Data { get; set; }
        public string SrvTitle { get; set; }
    }
}
