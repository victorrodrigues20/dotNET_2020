using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteBibliotecaMVC.Controllers
{
    public class CarrinhoController : Controller
    {
        // private readonly BibliotecaDbContext _context;

        // private IServicoLogin _servicoLogin;

        // public CarrinhoController(BibliotecaDbContext context,
        //     IServicoLogin servicoLogin)

        // {
        //     _context = context;
        //     _servicoLogin = servicoLogin;
        // }

        // // GET: Carrinho
        // public ActionResult Index()
        // {
        //     if (GetCarrinho() == null)
        //         SetCarrinho(new List<Livro>());

        //     return View(GetCarrinho());
        // }

        // // GET: Carrinho
        // public ActionResult Adicionar(int? id)
        // {
        //     List<Livro> listaLivros = GetCarrinho();

        //     var livro = _context.Livro.FirstOrDefault(x => x.LivroID == id);

        //     listaLivros.Add(livro);
        //     SetCarrinho(listaLivros);

        //     return View("Index", GetCarrinho());
        // }

        // private List<Livro> GetCarrinho()
        // {
        //     string carrinhoStr = HttpContext.Session.GetString("Carrinho");

        //     if (carrinhoStr == null)
        //         return new List<Livro>();

        //     return JsonConvert.DeserializeObject<List<Livro>>(carrinhoStr);
        // }

        // private void SetCarrinho(List<Livro> carrinho)
        // {
        //     string carrinhoStr = JsonConvert.SerializeObject(carrinho);
        //     HttpContext.Session.SetString("Carrinho", carrinhoStr);
        // }

        // // POST: EmprestarLivros
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> EmprestarLivros()
        // {
        //     // Verificamos se o usuário está logado
        //     if (_servicoLogin.UsuarioLogado())
        //     {
        //         // Pegar ID do Usuário (utilizando o serviço que criamos)
        //         var usuario = _servicoLogin.RecuperarUsuario();

        //         // Criar empréstimo
        //         Emprestimo emprestimo = new Emprestimo()
        //         {
        //             DataInicio = DateTime.Now.ToString("dd/MM/yyyy"),
        //             DataFim = DateTime.Now.AddDays(7).ToString("dd/MM/yyyy"),
        //             Usuario = usuario,
        //             LivEmprestimo = new List<LivroEmprestimo>()
        //         };

        //         // Resgatar lista de livros no carrinho
        //         List<Livro> listaLivros = GetCarrinho();

        //         // Inserir a lista de livros na tabela LivroEmprestimo
        //         foreach (var item in listaLivros)
        //         {
        //             LivroEmprestimo livroEmprestimo = new LivroEmprestimo();
        //             livroEmprestimo.LivroID = item.LivroID;
        //             livroEmprestimo.Emprestimo = emprestimo;

        //             emprestimo.LivEmprestimo.Add(livroEmprestimo);
        //         }

        //         // Inserir o novo empréstimo na tabela
        //         _context.Add(emprestimo);
        //         await _context.SaveChangesAsync();

        //         // Alertas do site (utilizando TempData)
        //         TempData["MsgAlert"] = "Empréstimo realizado com sucesso!";
        //         TempData["MsgEstilo"] = "alert-success";
        //     }
        //     else
        //     {
        //         // Alerta do site (utilizando TempData)
        //         TempData["MsgAlert"] = "Faça Login de sua aplicação!";
        //         TempData["MsgEstilo"] = "alert-danger";
        //     }

        //     return View("Index", GetCarrinho());
        // }
    }
}
