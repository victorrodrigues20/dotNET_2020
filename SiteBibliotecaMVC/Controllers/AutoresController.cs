using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using SiteBibliotecaMVC.Models;

namespace SiteBibliotecaMVC.Controllers
{
    public class AutoresController : Controller
    {
        private readonly ILogger<AutoresController> _logger;
        private readonly HttpClient _httpClient;

        public AutoresController(ILogger<AutoresController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        // GET: Autores
        public async Task<IActionResult> Index()
        {
            var url = $"/Autores";
            var resposta = await _httpClient.GetFromJsonAsync<AutorListViewModel>(url);

            return View("List", resposta.Autores);
        }

        // GET: Autores/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var url = $"/Autores/{id}";
            var resposta = await _httpClient.GetFromJsonAsync<AutorViewModel>(url);

            if (resposta == null)
            {
                return NotFound();
            }

            return View(resposta);
        }

        // GET: Autores/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] AutorViewModel autor)
        {
            var url = $"/Autores";
            var resposta = await _httpClient.PostAsJsonAsync<AutorViewModel>(url, autor);

            if (resposta.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            var mensagens = await resposta.Content.ReadFromJsonAsync<BadRequestResponse>();

            foreach (var atrError in mensagens.Errors)
            {
                foreach(var erro in atrError.Value)
                    ModelState.AddModelError(atrError.Key, erro);
            }
                
            return View(autor);
        }

        // GET: Autores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var url = $"/Autores/{id}";
            var resposta = await _httpClient.GetFromJsonAsync<AutorViewModel>(url);
            return View(resposta);
        }

        // POST: Autores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] AutorViewModel autor)
        {
            if (id != autor.Id)
            {
                return NotFound();
            }

            var url = $"/Autores/{id}";
            var resposta = await _httpClient.PutAsJsonAsync<AutorViewModel>(url, autor);

            if (resposta.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.ErrorMessage = resposta;
                
            return View(resposta);
        }

        // GET: Autores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var url = $"/Autores/{id}";
            var resposta = await _httpClient.GetFromJsonAsync<AutorViewModel>(url);

            if (resposta == null)
            {
                return NotFound();
            }

            return View(resposta);
        }

        // POST: Autores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var url = $"/Autores/{id}";
            var resposta = await _httpClient.DeleteAsync(url);

            return RedirectToAction(nameof(Index));
        }
    }
}
