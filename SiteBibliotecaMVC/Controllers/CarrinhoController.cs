using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SiteBibliotecaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Web;

namespace SiteBibliotecaMVC.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly ILogger<CarrinhoController> _logger;
        private readonly HttpClient _httpClient;

        public CarrinhoController(ILogger<CarrinhoController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        // GET: Autores
        public async Task<IActionResult> Index()
        {
            string key = GetCarrinhoKey();

            var url = $"/Carrinho/{key}";
            var resposta = await _httpClient.GetFromJsonAsync<CarrinhoListViewModel>(url);

            return View("List", resposta.Items);
        }

        [HttpGet, ActionName("Adicionar")]
        public async Task<ActionResult> Adicionar(int id)
        {
            var carrinho = new CarrinhoViewModel()
            {
                LivroID = id,
                Quantidade = 1,
                SessionUserID = GetCarrinhoKey()
            };

            var url = $"/Carrinho";
            var resposta = await _httpClient.PostAsJsonAsync<CarrinhoViewModel>(url, carrinho);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet, ActionName("Excluir")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var url = $"/Carrinho/{id}";
            var resposta = await _httpClient.DeleteAsync(url);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet, ActionName("EmprestarLivros")]
        public async Task<IActionResult> EmprestarLivros()
        {
            var url = $"/Emprestimos";
            var emprestimo = new EmprestimoInputModel()
            {
                SessionUserId = GetCarrinhoKey()
            };

            var resposta = await _httpClient.PostAsJsonAsync(url, emprestimo);

            if (!resposta.IsSuccessStatusCode)
            {
                return BadRequest();
            }

            TempData.Remove("CarrinhoKey");
            
            return RedirectToAction("Index", "Emprestimos");
        }

        [HttpGet, ActionName("LimparCarrinho")]
        public IActionResult LimparCarrinho()
        {
            TempData.Remove("CarrinhoKey");
            return RedirectToAction(nameof(Index));
        }

        private string GetCarrinhoKey()
        {
            if (TempData["CarrinhoKey"] == null)
            {
                TempData["CarrinhoKey"] = Guid.NewGuid().ToString();
            }

            TempData.Keep("CarrinhoKey");

            return TempData["CarrinhoKey"].ToString();
        }
    }
}
