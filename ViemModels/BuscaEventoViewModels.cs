using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExerciciosMVC.Models;

namespace Exercicios_MVC.ViemModels
{
    public class BuscaEventoViewModels
    {
        public string? NomeBusca { get; set; }
        public string? LocalBusca { get; set; }
        public DateTime? DataInicial { get; set; }
        public List<Evento> Resultados { get; set; } = new();
    }
}