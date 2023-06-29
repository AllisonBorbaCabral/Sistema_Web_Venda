using AspNetCore.Contexts;
using AspNetCore.Models;
using AspNetCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Controllers
{

    public class GradeCorController : Controller
    {
        private GradeCorContext _context = new GradeCorContext();

        private CorContext _contextCor = new CorContext();

        public IActionResult Index()
        {
            var gradeCores = _context.GetGradeCores();
            var viewModel = new ListGradeCorViewModel { GradeCores = gradeCores };
            ViewData["Title"] = "Lista das grades de cores";
            return View(viewModel);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Cadastro de grade de cor";
            ViewBag.Cores = _contextCor.GetCores();
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateGradeCorViewModel data)
        {
            var gradeCor = new GradeCor(data.Descricao, data.Cores);
            _context.CreateGradeCor(gradeCor);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            ViewData["Title"] = "Editar Grade de cores";
            var gradeCor = _context.GetGradeCor(id);
            if (gradeCor is null)
            {
                return NotFound();
            }
            var viewModel = new ModalGradeCorViewModel
            {
                DataCadastro = gradeCor.DataCadastro,
                DataUltAlteracao = gradeCor.DataUltAlteracao
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, ModalGradeCorViewModel data)
        {
            var gradeCor = _context.GetGradeCor(id);
            if (gradeCor is null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            ViewData["Title"] = "Deletar Grade de Cores";
            var gradeCor = _context.GetGradeCor(id);
            if (gradeCor is null)
            {
                return NotFound();
            }
            var viewModel = new ModalGradeCorViewModel
            {
                Id = gradeCor.Id,
                DataCadastro = gradeCor.DataCadastro,
                DataUltAlteracao = gradeCor.DataUltAlteracao
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id, ModalGradeCorViewModel data)
        {
            var gradeCor = _context.GetGradeCor(id);
            if (gradeCor is null)
            {
                return NotFound();
            }

            _context.DeleteGradeCor(gradeCor.Id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var gradeCor = _context.GetGradeCor(id);
            var viewModel = new ModalGradeCorViewModel
            {
                Id = gradeCor.Id,
                DataCadastro = gradeCor.DataCadastro,
                DataUltAlteracao = gradeCor.DataUltAlteracao
            };
            return View(viewModel);
        }
    }


}