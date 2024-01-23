using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable CS8618

namespace MVC.Models.ViewModels
{
    public class BrandModelViewModel
    {
        public BrandViewModel BrandRecord { get; set; } 
        public ModelViewModel ModelRecord { get; set; }
        public SelectList MarcasAeronave { get;set; }
        public SelectList MarcasMotor { get;set; }
        public SelectList MarcasHelice   { get;set; }
    }
}
