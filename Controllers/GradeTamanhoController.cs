using AspNetCore.Contexts;
using AspNetCore.Models;
using AspNetCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Controllers
{

    public class GradeTamanhoController : Controller
    {
        private GradeTamanhoContext _context = new GradeTamanhoContext();

        public IActionResult Index()
        {
            var gradeTamanhos = _context.GetGradeTamanhos();
            var viewModel = new ListGradeTamanhoViewModel { GradeTamanhos = gradeTamanhos };
            ViewData["Title"] = "Lista das grades de tamanhos";
            return View(viewModel);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Cadastro de grade de tamanho";
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateGradeTamanhoViewModel data)
        {
            var gradeTamanho = new GradeTamanho();
            _context.CreateGradeTamanho(gradeTamanho);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            ViewData["Title"] = "Editar Grade de tamanhos";
            var gradeTamanho = _context.GetGradeTamanho(id);
            if (gradeTamanho is null)
            {
                return NotFound();
            }
            var viewModel = new ModalGradeTamanhoViewModel
            {
                DataCadastro = gradeTamanho.DataCadastro,
                DataUltAlteracao = gradeTamanho.DataUltAlteracao
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, ModalGradeTamanhoViewModel data)
        {
            var gradeTamanho = _context.GetGradeTamanho(id);
            if (gradeTamanho is null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            ViewData["Title"] = "Deletar Grade de Tamanhos";
            var gradeTamanho = _context.GetGradeTamanho(id);
            if (gradeTamanho is null)
            {
                return NotFound();
            }
            var viewModel = new ModalGradeTamanhoViewModel
            {
                Id = gradeTamanho.Id,
                DataCadastro = gradeTamanho.DataCadastro,
                DataUltAlteracao = gradeTamanho.DataUltAlteracao
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id, ModalGradeTamanhoViewModel data)
        {
            var gradeTamanho = _context.GetGradeTamanho(id);
            if (gradeTamanho is null)
            {
                return NotFound();
            }

            _context.DeleteGradeTamanho(gradeTamanho.Id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var gradeTamanho = _context.GetGradeTamanho(id);
            var viewModel = new ModalGradeTamanhoViewModel
            {
                Id = gradeTamanho.Id,
                DataCadastro = gradeTamanho.DataCadastro,
                DataUltAlteracao = gradeTamanho.DataUltAlteracao
            };
            return View(viewModel);
        }
    }


}