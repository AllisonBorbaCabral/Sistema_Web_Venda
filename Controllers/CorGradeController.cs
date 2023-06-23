using AspNetCore.Contexts;
using AspNetCore.Models;
using AspNetCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Controllers
{

    public class CorGradeController : Controller
    {
        private CorGradeContext _context = new CorGradeContext();

        public IActionResult Index()
        {
            var coresGrade = _context.GetCoresGrade();
            var viewModel = new ListCoresGradeViewModel { CoresGrade = coresGrade };
            ViewData["Title"] = "Lista de Grades/Cores";
            return View(viewModel);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Cadastro de Cores Grade";
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCoresGradeViewModel data)
        {
            var corGrade = new CorGrade(data.cor, data.gradeCor);
            _context.CreateCorGrade(corGrade);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int idCor, int idGradeCor)
        {
            ViewData["Title"] = "Editar Cor Grade";
            var corGrade = _context.GetCorGrade(idCor, idGradeCor);
            if (corGrade is null)
            {
                return NotFound();
            }
            var viewModel = new ModalCoresGradeViewModel
            {
                cor = corGrade.cor,
                gradeCor = corGrade.gradeCor
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(int idCor, int idGradeCor, ModalCoresGradeViewModel data)
        {
            var corGrade = _context.GetCorGrade(idCor, idGradeCor);
            if (corGrade is null)
            {
                return NotFound();
            }

            if (data.cor.Id.Equals(corGrade.cor.Id) && data.gradeCor.Id.Equals(corGrade.gradeCor.Id))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                corGrade.cor.Id = data.cor.Id;
                corGrade.gradeCor.Id = data.gradeCor.Id;
                _context.EditCorGrade(corGrade);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int idCor, int idGradeCor)
        {
            ViewData["Title"] = "Deletar Cor Grade";
            var corGrade = _context.GetCorGrade(idCor, idGradeCor);
            if (corGrade is null)
            {
                return NotFound();
            }
            var viewModel = new ModalCoresGradeViewModel
            {
                cor = corGrade.cor,
                gradeCor = corGrade.gradeCor
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(int idCor, int idGradeCor, ModalCoresGradeViewModel data)
        {
            var corGrade = _context.GetCorGrade(idCor, idGradeCor);
            if (corGrade is null)
            {
                return NotFound();
            }

            _context.DeleteCorGrade(corGrade.cor.Id, corGrade.gradeCor.Id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int idCor, int idGradeCor)
        {
            var corGrade = _context.GetCorGrade(idCor, idGradeCor);
            var viewModel = new ModalCoresGradeViewModel
            {
                cor = corGrade.cor,
                gradeCor = corGrade.gradeCor,
            };
            return View(viewModel);
        }
    }


}