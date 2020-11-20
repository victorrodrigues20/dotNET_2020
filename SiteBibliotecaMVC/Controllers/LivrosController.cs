using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
//using Newtonsoft.Json;
using SiteBibliotecaMVC.Models;

namespace SiteBibliotecaMVC.Controllers
{
    public class LivrosController : Controller
    {
        private readonly ILogger<LivrosController> _logger;
        private readonly HttpClient _httpClient;

        public LivrosController(ILogger<LivrosController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        // GET: Livros
        public async Task<IActionResult> Index()
        {
            var url = $"/Livros";
            var resposta = await _httpClient.GetFromJsonAsync<LivroListViewModel>(url);

            return View("List", resposta.Livros);
        }

        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var url = $"/Livros/{id}";
            var resposta = await _httpClient.GetFromJsonAsync<LivroViewModel>(url);

            if (resposta == null)
            {
                return NotFound();
            }

            return View(resposta);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Quantidade,Foto")] LivroViewModel livro,
            string[] selectedAutores)
        {
            if (selectedAutores != null)
            {
                livro.Autores = new List<AutorSelectListDto>();

                foreach (var idAutor in selectedAutores)
                    livro.Autores.Add(new AutorSelectListDto() { AutorID = int.Parse(idAutor), Selecionado = true });
            }

            var url = $"/Livros";
            var resposta = await _httpClient.PostAsJsonAsync<LivroViewModel>(url, livro);

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
                
            return View(livro);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var url = $"/Livros/{id}";
            var resposta = await _httpClient.GetFromJsonAsync<LivroViewModel>(url);
            return View(resposta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Quantidade,Foto")] LivroViewModel livro,
            string[] selectedAutores)
        {
            if (id != livro.Id)
            {
                return NotFound();
            }

            if (selectedAutores != null)
            {
                livro.Autores = new List<AutorSelectListDto>();

                foreach (var idAutor in selectedAutores)
                    livro.Autores.Add(new AutorSelectListDto() { AutorID = int.Parse(idAutor), Selecionado = true });
            }

            var url = $"/Livros/{id}";
            var resposta = await _httpClient.PutAsJsonAsync<LivroViewModel>(url, livro);

            if (resposta.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.ErrorMessage = resposta;
                
            return View(resposta);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var url = $"/Livros/{id}";
            var resposta = await _httpClient.GetFromJsonAsync<LivroViewModel>(url);

            if (resposta == null)
            {
                return NotFound();
            }

            return View(resposta);
        }

        // POST: Livros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var url = $"/Livros/{id}";
            var resposta = await _httpClient.DeleteAsync(url);

            return RedirectToAction(nameof(Index));
        }        
    }
}