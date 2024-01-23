using EngineAir.Models;
using MVC.Models.ViewModels;
using MVC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Services.Classes.AbstractClasses
{
    public abstract class CrudModels : ICrud
    {
        protected readonly Context _context;
        protected ModelViewModel viewModel = new();
        public CrudModels(Context context)
        {
            _context = context;
        }
        public abstract bool Insert(object myObject);
    }
}
