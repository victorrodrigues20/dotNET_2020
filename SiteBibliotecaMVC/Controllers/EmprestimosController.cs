using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.FileProviders;

namespace SiteBibliotecaMVC.Controllers
{
    public class EmprestimosController : Controller
    {
        // private readonly BibliotecaDbContext _context;

        // private IServicoLogin _servicoLogin;

        // public EmprestimosController(BibliotecaDbContext context, IServicoLogin servicoLogin)
        // {
        //     _context = context;
        //     _servicoLogin = servicoLogin;
        // }

        // // GET: Emprestimos
        // public async Task<IActionResult> Index()
        // {
        //     List<Emprestimo> listaEmprestimos = new List<Emprestimo>();

        //     // Verificamos se o usuário está logado
        //     if (_servicoLogin.UsuarioLogado())
        //     {
        //         // Pegar ID do Usuário
        //         var usuario = _servicoLogin.RecuperarUsuario();

        //         listaEmprestimos = await _context.Emprestimo.Include(e => e.Usuario)
        //                             .Where(c => c.UsuarioID == usuario.UsuarioID)
        //                             .ToListAsync();
        //     }

        //     return View("Index", listaEmprestimos);
        // }

        // // GET: Emprestimos/Details/5
        // public async Task<IActionResult> Details(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var emprestimo = await _context.Emprestimo
        //         .Include(e => e.Usuario)
        //         .Include(e => e.LivEmprestimo)
        //         .ThenInclude(le => le.Livro)
        //         .ThenInclude(li => li.LivAutor)
        //         .ThenInclude(la => la.Autor)
        //         .SingleOrDefaultAsync(m => m.EmprestimoID == id);

        //     if (emprestimo == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(emprestimo);
        // }

        // public async Task<IActionResult> DevolverLivros(int? id)
        // {
        //     if (id != null)
        //     {
        //         Emprestimo emprestimo = _context.Emprestimo.FirstOrDefault(e => e.EmprestimoID == id);

        //         emprestimo.DataDevolucao = DateTime.Now.ToString("dd/MM/yyyy");

        //         _context.Update(emprestimo);
        //         _context.SaveChanges();
        //     }

        //     return await Index();
        // }


        // // GET: Emprestimos/Create
        // public IActionResult Create()
        // {
        //     ViewData["UsuarioID"] = new SelectList(_context.Usuario, "UsuarioID", "UsuarioID");
        //     return View();
        // }

        // // POST: Emprestimos/Create
        // // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("EmprestimoID,UsuarioID,DataInicio,DataFim,DataDevolucao")] Emprestimo emprestimo)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _context.Add(emprestimo);
        //         await _context.SaveChangesAsync();
        //         return RedirectToAction(nameof(Index));
        //     }
        //     ViewData["UsuarioID"] = new SelectList(_context.Usuario, "UsuarioID", "UsuarioID", emprestimo.UsuarioID);
        //     return View(emprestimo);
        // }

        // // GET: Emprestimos/Edit/5
        // public async Task<IActionResult> Edit(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var emprestimo = await _context.Emprestimo.FindAsync(id);
        //     if (emprestimo == null)
        //     {
        //         return NotFound();
        //     }
        //     ViewData["UsuarioID"] = new SelectList(_context.Usuario, "UsuarioID", "UsuarioID", emprestimo.UsuarioID);
        //     return View(emprestimo);
        // }

        // // POST: Emprestimos/Edit/5
        // // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(int id, [Bind("EmprestimoID,UsuarioID,DataInicio,DataFim,DataDevolucao")] Emprestimo emprestimo)
        // {
        //     if (id != emprestimo.EmprestimoID)
        //     {
        //         return NotFound();
        //     }

        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             _context.Update(emprestimo);
        //             await _context.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!EmprestimoExists(emprestimo.EmprestimoID))
        //             {
        //                 return NotFound();
        //             }
        //             else
        //             {
        //                 throw;
        //             }
        //         }
        //         return RedirectToAction(nameof(Index));
        //     }
        //     ViewData["UsuarioID"] = new SelectList(_context.Usuario, "UsuarioID", "UsuarioID", emprestimo.UsuarioID);
        //     return View(emprestimo);
        // }

        // // GET: Emprestimos/Delete/5
        // public async Task<IActionResult> Delete(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var emprestimo = await _context.Emprestimo
        //         .Include(e => e.Usuario)
        //         .FirstOrDefaultAsync(m => m.EmprestimoID == id);
        //     if (emprestimo == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(emprestimo);
        // }

        // // POST: Emprestimos/Delete/5
        // [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> DeleteConfirmed(int id)
        // {
        //     var emprestimo = await _context.Emprestimo.FindAsync(id);
        //     _context.Emprestimo.Remove(emprestimo);
        //     await _context.SaveChangesAsync();
        //     return RedirectToAction(nameof(Index));
        // }

        // private bool EmprestimoExists(int id)
        // {
        //     return _context.Emprestimo.Any(e => e.EmprestimoID == id);
        // }

        // public async Task<FileResult> Imprimir() {

        //     string templatePath =  @"./templates/relatorio1/template.html";
        //     string outputPath =  @"./out/";
        //     bool force =  true;

        //     // Cria instância do Gerador
        //     PDFGenerator.PDFGenerator pdfGenerator =  new  PDFGenerator.PDFGenerator();

        //     // Configura o gerador com os caminhos
        //     bool retorno = pdfGenerator.Configure(templatePath, outputPath, force);

        //     List<Emprestimo> listaEmprestimos = new List<Emprestimo>();

        //     // Verificamos se o usuário está logado
        //     if (_servicoLogin.UsuarioLogado())
        //     {
        //         // Pegar ID do Usuário
        //         var usuario = _servicoLogin.RecuperarUsuario();

        //         listaEmprestimos = await _context.Emprestimo.Include(e => e.Usuario)
        //                             .Where(c => c.UsuarioID == usuario.UsuarioID)
        //                             .ToListAsync();
        //     }

        //     // Chama a geração do arquivo PDF
        //     string pathFile = await pdfGenerator.Build("relatorio.pdf", listaEmprestimos);

        //     return new PhysicalFileResult(pathFile, "application/pdf");
        // }
    }
}
