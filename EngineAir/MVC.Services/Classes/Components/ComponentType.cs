using EngineAir.Models;
using Microsoft.EntityFrameworkCore;
using MVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Services.Classes.Components
{
    public class ComponentType
    {
        private readonly Context _context;
        public ComponentType(Context context)
        {
            _context = context;
        }

        private readonly List<string> componentType = new()
        {
            "MAGNETOS",
            "ALTERNADOR",
            "MARCHA",
            "ELT BATERY",
            "BOTIQUIN",
            "EXTINTOR"
        };

        public async Task AddTypes()
        {
            foreach (var type in componentType)
            {
                var flag =
                    await _context.TipoComponente.FirstOrDefaultAsync(c => c.Componente == type);

                if (flag == null)
                {
                    TipoComponente tipoComponente = new()
                    {
                        Componente = type
                    };
                    _context.Add(tipoComponente);
                    await _context.SaveChangesAsync();
                }
            }
        }

    }
}
