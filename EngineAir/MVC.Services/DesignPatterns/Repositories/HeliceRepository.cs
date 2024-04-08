using EngineAir.Models;
using Microsoft.EntityFrameworkCore;
using MVC.Models.Classes;
using MVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Services.DesignPatterns.Repositories
{
    public class HeliceRepository
    {
        private readonly Context _context;
        public HeliceRepository(Context context)
        {
            _context = context;
        }

        //public ResponseJS Insert(MotorViewModel MotorViewModel)
        //{

        //}
    }
}
