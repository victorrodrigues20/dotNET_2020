using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using SiteBibliotecaMVC.Models;

namespace SiteBibliotecaMVC.Controllers
{
    public class EmprestimosController : Controller
    {
        private readonly ILogger<EmprestimosController> _logger;
        private readonly HttpClient _httpClient;

        public EmprestimosController(ILogger<EmprestimosController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        // // GET: Emprestimos
        public async Task<IActionResult> Index()
        {
            var usuarioId = 1; // Fixo por enquanto

            var url = $"/Emprestimos/{usuarioId}";

            var resposta = await _httpClient.GetFromJsonAsync<EmprestimoListViewModel>(url);

            return View("List", resposta.Emprestimos);
        }

        // // GET: Emprestimos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var url = $"/Emprestimos/Details/{id}";
            var emprestimo = await _httpClient.GetFromJsonAsync<EmprestimoViewModel>(url);

            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        public async Task<IActionResult> DevolverLivros(int? id)
        {
            if (id == null)
                return NotFound();

            var emprestimo = new EmprestimoInputModel()
            {
                Id = id.Value
            };
            
            var url = $"/Emprestimos/DevolverLivros/{id}";
            var result = await _httpClient.PostAsJsonAsync(url, emprestimo);

            if (!result.IsSuccessStatusCode)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
