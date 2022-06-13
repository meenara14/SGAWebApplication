using SGAWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGAWebApplication.IServices
{
    interface ISliderImageSrv
    {
        SliderImages SaveImages(SliderImages mdl);
    }
}
