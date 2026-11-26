using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Exercicios_MVC.ViemModels;
using ExerciciosMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExerciciosMVC.Controllers
{
    public class EventosController : Controller
    {

        private static List<Evento> _Eventos = new()
        {
            new Evento {Id = 1, Nome = "ConectaPro", Descricao = "Evento para prestadores de serviços em nuvem", Local = "São Caetano do Sul", DataEvento = new DateTime(2026, 10, 12),QuantidadeVagas = 200, ValorIngresso = 300},

            new Evento {Id = 2, Nome = "ConectaPremium", Descricao = "Evento vip para prestadores de serviços em nuvem", Local = "São Bernardo do Campo", DataEvento = new DateTime(2026, 10, 12) ,QuantidadeVagas = 50, ValorIngresso = 700}
        };

        public IActionResult Index()
        {
            return View(_Eventos);
        }

        // GET
        public IActionResult Criar()
        {
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult Criar(Evento evento)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            evento.Id = _Eventos.Any() ? _Eventos.Max(e => e.Id) + 1 : 1;

            _Eventos.Add(evento);

            if (evento.DataEvento < DateTime.Now)
            {
                ModelState.AddModelError("DataEvento", "A data não pode ser anterior à data atual.");

                return View(evento);
            }
            return RedirectToAction("Index");

        }

        public IActionResult Detalhes(int id)
        {
            var evento = _Eventos.FirstOrDefault(e => e.Id == id);

            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        public IActionResult Buscar()
        {
            return View(new BuscaEventoViewModels());
        }

        [HttpPost]
        public IActionResult Buscar(BuscaEventoViewModels vm)
        {
            vm.Resultados = _Eventos;

            if (!string.IsNullOrEmpty(vm.NomeBusca))
            {
                vm.Resultados = _Eventos.Where(e => e.Nome.Contains(vm.NomeBusca, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(vm.LocalBusca))
            {
                vm.Resultados = _Eventos.Where(e => e.Local.Contains(vm.LocalBusca, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }

            return View(vm);
        }
      
    }
}