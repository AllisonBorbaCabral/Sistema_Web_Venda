using AspNetCore.Contexts;
using AspNetCore.Models;
using AspNetCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Controllers
{

    public class TamanhoGradeController : Controller
    {
        private TamanhoGradeContext _context = new TamanhoGradeContext();

        public IActionResult Index()
        {
            var tamanhosGrade = _context.GetTamanhosGrade();
            var viewModel = new ListTamanhosGradeViewModel { TamanhosGrade = tamanhosGrade };
            ViewData["Title"] = "Lista de Grades/Tamanhos";
            return View(viewModel);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Cadastro de Tamanhos Grade";
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateTamanhosGradeViewModel data)
        {
            var tamanhoGrade = new TamanhoGrade(data.tamanho, data.gradeTamanho);
            _context.CreateTamanhoGrade(tamanhoGrade);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int idTamanho, int idGradeTamanho)
        {
            ViewData["Title"] = "Editar Tamanho Grade";
            var tamanhoGrade = _context.GetTamanhoGrade(idTamanho, idGradeTamanho);
            if (tamanhoGrade is null)
            {
                return NotFound();
            }
            var viewModel = new ModalTamanhosGradeViewModel
            {
                tamanho = tamanhoGrade.tamanho,
                gradeTamanho = tamanhoGrade.gradeTamanho
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(int idTamanho, int idGradeTamanho, ModalTamanhosGradeViewModel data)
        {
            var tamanhoGrade = _context.GetTamanhoGrade(idTamanho, idGradeTamanho);
            if (tamanhoGrade is null)
            {
                return NotFound();
            }

            if (data.tamanho.Id.Equals(tamanhoGrade.tamanho.Id) && data.gradeTamanho.Id.Equals(tamanhoGrade.gradeTamanho.Id))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                tamanhoGrade.tamanho.Id = data.tamanho.Id;
                tamanhoGrade.gradeTamanho.Id = data.gradeTamanho.Id;
                _context.EditTamanhoGrade(tamanhoGrade);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int idTamanho, int idGradeTamanho)
        {
            ViewData["Title"] = "Deletar Tamanho Grade";
            var tamanhoGrade = _context.GetTamanhoGrade(idTamanho, idGradeTamanho);
            if (tamanhoGrade is null)
            {
                return NotFound();
            }
            var viewModel = new ModalTamanhosGradeViewModel
            {
                tamanho = tamanhoGrade.tamanho,
                gradeTamanho = tamanhoGrade.gradeTamanho
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(int idTamanho, int idGradeTamanho, ModalTamanhosGradeViewModel data)
        {
            var tamanhoGrade = _context.GetTamanhoGrade(idTamanho, idGradeTamanho);
            if (tamanhoGrade is null)
            {
                return NotFound();
            }

            _context.DeleteTamanhoGrade(tamanhoGrade.tamanho.Id, tamanhoGrade.gradeTamanho.Id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int idTamanho, int idGradeTamanho)
        {
            var tamanhoGrade = _context.GetTamanhoGrade(idTamanho, idGradeTamanho);
            var viewModel = new ModalTamanhosGradeViewModel
            {
                tamanho = tamanhoGrade.tamanho,
                gradeTamanho = tamanhoGrade.gradeTamanho,
            };
            return View(viewModel);
        }
    }


}