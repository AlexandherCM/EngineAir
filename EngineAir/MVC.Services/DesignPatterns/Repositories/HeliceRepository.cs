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

        public HeliceRepository(Context context) { _context = context; }

        public async Task<List<HeliceDTO>> GetHelicesDisp()
        {
            var helicesFuncionales = await _context.Helice.Include(c=>c.Modelo)
                                                                                 .Include(c => c.Modelo.Marca)
                                                                                 .Where(c => c.Funcional == true)
                                                                                 .ToListAsync();

            var helicesSinHistorial = await _context.Helice
                                                                                .Include(c => c.Modelo)
                                                                                .Include(c => c.Modelo.Marca)
                                                                                .Where(c => _context.HistorialMotorHelice.All(h => h.HeliceID != c.ID))
                                                                                .ToListAsync();

            var helices =  helicesFuncionales.Intersect(helicesSinHistorial).ToList();

            List<HeliceDTO> helicesDTO = new();
            helices.ForEach(h =>
            {
                HeliceDTO newPropeller = new()
                {
                    ID = h.ID,
                    Nombre = $"Serie: {h.NumSerie} - Modelo: {h.Modelo.Nombre} - Marca: {h.Modelo.Marca.Nombre}" 
                    + $" - T.T: {h.TiempoTotal.ToString("0.##")} hrs - TURM: {h.TURM.ToString("0.##")} hrs"
                };

                helicesDTO.Add(newPropeller);
            });

            return helicesDTO;
        }

    }
}
