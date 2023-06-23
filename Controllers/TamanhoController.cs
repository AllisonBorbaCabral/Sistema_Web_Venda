using AspNetCore.Contexts;
using AspNetCore.Models;
using AspNetCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Controllers
{

    public class TamanhoController : Controller
    {
        private TamanhoContext _context = new TamanhoContext();

        public IActionResult Index()
        {
            var tamanhos = _context.GetTamanhos();
            var viewModel = new ListTamanhoViewModel { Tamanhos = tamanhos };
            ViewData["Title"] = "Lista de Tamanhos";
            return View(viewModel);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Cadastro de Tamanho";
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateTamanhoViewModel data)
        {
            var tamanho = new Tamanho(data.DsTamanho);
            _context.CreateTamanho(tamanho);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            ViewData["Title"] = "Editar Tamanho";
            var tamanho = _context.GetTamanho(id);
            if (tamanho is null)
            {
                return NotFound();
            }
            var viewModel = new ModalTamanhoViewModel
            {
                DsTamanho = tamanho.DsTamanho,
                DataCadastro = tamanho.DataCadastro,
                DataUltAlteracao = tamanho.DataUltAlteracao
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, ModalTamanhoViewModel data)
        {
            var tamanho = _context.GetTamanho(id);
            if (tamanho is null)
            {
                return NotFound();
            }

            if (data.DsTamanho.Equals(tamanho.DsTamanho))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                tamanho.DsTamanho = data.DsTamanho;
                _context.EditTamanho(tamanho);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            ViewData["Title"] = "Deletar Tamanho";
            var tamanho = _context.GetTamanho(id);
            if (tamanho is null)
            {
                return NotFound();
            }
            var viewModel = new ModalTamanhoViewModel
            {
                Id = tamanho.Id,
                DsTamanho = tamanho.DsTamanho,
                DataCadastro = tamanho.DataCadastro,
                DataUltAlteracao = tamanho.DataUltAlteracao
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id, ModalTamanhoViewModel data)
        {
            var tamanho = _context.GetTamanho(id);
            if (tamanho is null)
            {
                return NotFound();
            }

            _context.DeleteTamanho(tamanho.Id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var tamanho = _context.GetTamanho(id);
            var viewModel = new ModalTamanhoViewModel
            {
                Id = tamanho.Id,
                DsTamanho = tamanho.DsTamanho,
                DataCadastro = tamanho.DataCadastro,
                DataUltAlteracao = tamanho.DataUltAlteracao
            };
            return View(viewModel);
        }
    }


}