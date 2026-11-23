using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ExerciciosMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExerciciosMVC.Controllers
{
    public class EventosController : Controller
    {
    
        private static List<Evento> _Eventos = new()
        {
            new Evento {Id = 1, Nome = "ConectaPro", Descricao = "Evento para prestadores de serviços em nuvem", Local = "São Caetano do Sul", QuantidadeVagas = 200, ValorIngresso = 300},
            new Evento {Id = 2, Nome = "ConectaPremium", Descricao = "Evento vip para prestadores de serviços em nuvem", Local = "São Bernardo do Campo", QuantidadeVagas = 50, ValorIngresso = 700}
        };

        public IActionResult Index()
        {
            return View();
        }

        // GET
        public IActionResult Criar()
        {
            return View();
        }

        //POST
        public IActionResult Criar(Evento evento)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            evento.Id = _Eventos.Any() ? _Eventos.Max(e => e.Id) + 1 : 1;

            _Eventos.Add(evento);

            return RedirectToAction("Index");
        }
    }
}