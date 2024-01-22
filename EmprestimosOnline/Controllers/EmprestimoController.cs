using EmprestimosOnline.Data;
using EmprestimosOnline.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimosOnline.Controllers;

public class EmprestimoController : Controller
{
    private readonly AppDbContext _context;
    public EmprestimoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        IEnumerable<EmprestimosModel> emprestimos = _context.Emprestimos;
        return View(emprestimos);
    }

    //essa função é apenas para ir para a tela onde estão os dados para cadastrar
    [HttpGet]
    public IActionResult Cadastrar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Cadastrar(EmprestimosModel emprestimo)
    {
        if(ModelState.IsValid) 
        {
            _context.Emprestimos.Add(emprestimo);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpGet]
    public IActionResult Editar(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        EmprestimosModel emprestimo = _context.Emprestimos.FirstOrDefault(x => x.Id == id);

        if (emprestimo == null)
        {
            return NotFound();
        }
        return View(emprestimo);
    }

    [HttpPost]
    public IActionResult Editar(EmprestimosModel emprestimo)
    {
        //ModelState.IsValid verifica se o banco não está vazio
        if(ModelState.IsValid)
        {
            _context.Emprestimos.Update(emprestimo);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        return View(emprestimo);
    }

    [HttpGet]
    public IActionResult Excluir(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        EmprestimosModel emprestimo = _context.Emprestimos.FirstOrDefault(x => x.Id == id);

        if (emprestimo == null)
        {
            return NotFound();
        }
        return View(emprestimo);
    }


    [HttpPost]
    public IActionResult Excluir(EmprestimosModel emprestimo)
    {
        if (emprestimo == null)
        {
            return NotFound();
        }

        _context.Emprestimos.Remove(emprestimo);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
 
    
}