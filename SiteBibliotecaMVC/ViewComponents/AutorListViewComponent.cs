using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiteBibliotecaMVC.Models;

namespace SiteBibliotecaMVC.ViewComponents
{
    public class AutorListViewComponent : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public AutorListViewComponent(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync(int livroID)
        {
            var items = await GetItemsAsync(livroID);
            return View(items);
        }
        
        private async Task<List<AutorSelectListDto>> GetItemsAsync(int livroID)
        {
            var url = $"/Autores/listautoreslivro/{livroID}";
            return await _httpClient.GetFromJsonAsync<List<AutorSelectListDto>>(url);
        }
    }
}