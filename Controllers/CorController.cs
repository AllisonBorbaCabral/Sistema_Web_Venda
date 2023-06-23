using AspNetCore.Contexts;
using AspNetCore.Models;
using AspNetCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Controllers
{

    public class CorController : Controller
    {
        private CorContext _context = new CorContext();

        public IActionResult Index()
        {
            var cores = _context.GetCores();
            var viewModel = new ListCorViewModel { Cores = cores };
            ViewData["Title"] = "Lista de Cores";
            return View(viewModel);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Cadastro de Cor";
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCorViewModel data)
        {
            var cor = new Cor(data.DsCor);
            _context.CreateCor(cor);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            ViewData["Title"] = "Editar Cor";
            var cor = _context.GetCor(id);
            if (cor is null)
            {
                return NotFound();
            }
            var viewModel = new ModalCorViewModel
            {
                DsCor = cor.DsCor,
                DataCadastro = cor.DataCadastro,
                DataUltAlteracao = cor.DataUltAlteracao
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, ModalCorViewModel data)
        {
            var cor = _context.GetCor(id);
            if (cor is null)
            {
                return NotFound();
            }

            if (data.DsCor.Equals(cor.DsCor))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                cor.DsCor = data.DsCor;
                _context.EditCor(cor);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            ViewData["Title"] = "Deletar Cor";
            var cor = _context.GetCor(id);
            if (cor is null)
            {
                return NotFound();
            }
            var viewModel = new ModalCorViewModel
            {
                Id = cor.Id,
                DsCor = cor.DsCor,
                DataCadastro = cor.DataCadastro,
                DataUltAlteracao = cor.DataUltAlteracao
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id, ModalCorViewModel data)
        {
            var cor = _context.GetCor(id);
            if (cor is null)
            {
                return NotFound();
            }

            _context.DeleteCor(cor.Id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var cor = _context.GetCor(id);
            var viewModel = new ModalCorViewModel
            {
                Id = cor.Id,
                DsCor = cor.DsCor,
                DataCadastro = cor.DataCadastro,
                DataUltAlteracao = cor.DataUltAlteracao
            };
            return View(viewModel);
        }
    }


}