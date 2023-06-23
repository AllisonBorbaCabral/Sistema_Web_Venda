using AspNetCore.Contexts;
using AspNetCore.Models;
using AspNetCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Controllers
{

    public class FormaPagtoController : Controller
    {
        private FormaPagtoContext _context = new FormaPagtoContext();

        public IActionResult Index()
        {
            var formasPagto = _context.GetFormasPagto();
            var viewModel = new ListFormaPagtoViewModel { FormasPagto = formasPagto };
            ViewData["Title"] = "Lista de Formas de Pagto";
            return View(viewModel);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Cadastro de Forma de Pagto";
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateFormaPagtoViewModel data)
        {
            var formaPagto = new FormaPagto(data.DsFormaPagto);
            _context.CreateFormaPagto(formaPagto);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            ViewData["Title"] = "Editar Forma de Pagto";
            var formaPagto = _context.GetFormaPagto(id);
            if (formaPagto is null)
            {
                return NotFound();
            }
            var viewModel = new ModalFormaPagtoViewModel
            {
                DsFormaPagto = formaPagto.DsFormaPagto,
                DataCadastro = formaPagto.DataCadastro,
                DataUltAlteracao = formaPagto.DataUltAlteracao
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, ModalFormaPagtoViewModel data)
        {
            var formaPagto = _context.GetFormaPagto(id);
            if (formaPagto is null)
            {
                return NotFound();
            }

            if (data.DsFormaPagto.Equals(formaPagto.DsFormaPagto))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                formaPagto.DsFormaPagto = data.DsFormaPagto;
                _context.EditFormaPagto(formaPagto);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            ViewData["Title"] = "Deletar Forma de Pagto";
            var formaPagto = _context.GetFormaPagto(id);
            if (formaPagto is null)
            {
                return NotFound();
            }
            var viewModel = new ModalFormaPagtoViewModel
            {
                Id = formaPagto.Id,
                DsFormaPagto = formaPagto.DsFormaPagto,
                DataCadastro = formaPagto.DataCadastro,
                DataUltAlteracao = formaPagto.DataUltAlteracao
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id, ModalFormaPagtoViewModel data)
        {
            var formaPagto = _context.GetFormaPagto(id);
            if (formaPagto is null)
            {
                return NotFound();
            }

            _context.DeleteFormaPagto(formaPagto.Id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var formaPagto = _context.GetFormaPagto(id);
            var viewModel = new ModalFormaPagtoViewModel
            {
                Id = formaPagto.Id,
                DsFormaPagto = formaPagto.DsFormaPagto,
                DataCadastro = formaPagto.DataCadastro,
                DataUltAlteracao = formaPagto.DataUltAlteracao
            };
            return View(viewModel);
        }
    }


}