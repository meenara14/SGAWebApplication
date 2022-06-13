using SGAWebApplication.IServices;
using SGAWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGAWebApplication.Services
{
    public class SliderImagesSrv: ISliderImageSrv
    {
        private readonly DataContext _context;
        public SliderImagesSrv(DataContext context)
        {
            _context = context;
        }
        public SliderImages SaveImages(SliderImages mdl)
        {
            _context.sliderimages.Add(mdl);
            _context.SaveChanges();
            return mdl;
        }
    }
}
