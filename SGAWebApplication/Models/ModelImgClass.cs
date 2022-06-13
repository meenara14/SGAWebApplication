using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGAWebApplication.Models
{
    public class ModelImgClass
    {
        public SliderImages simg { get; set; }
        public List<SliderImages> simgList { get; set; }
        public ServicesMstr srvobj { get; set; }
        public List<ServicesMstr> srvobjlist { get; set; }
        public ServicesHeaderContent srvhdrcontent { get; set; }
    }
}
