using AspNetCore.Contexts;
using AspNetCore.Models;
using AspNetCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Controllers
{

    public class PaisController : Controller
    {
        private PaisContext _context = new PaisContext();

        public IActionResult Index()
        {
            var paises = _context.GetPaises();
            var viewModel = new ListPaisViewModel { Paises = paises };
            ViewData["Title"] = "Lista de Países";
            return View(viewModel);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Cadastro de País";
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatePaisViewModel data)
        {
            var pais = new Pais(data.NmPais, data.SiglaPais, data.DdiPais);
            _context.CreatePais(pais);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            ViewData["Title"] = "Editar País";
            var pais = _context.GetPais(id);
            if (pais is null)
            {
                return NotFound();
            }
            var viewModel = new ModalPaisViewModel
            {
                NmPais = pais.NmPais,
                SiglaPais = pais.SiglaPais,
                DdiPais = pais.DdiPais,
                DataCadastro = pais.DataCadastro,
                DataUltAlteracao = pais.DataUltAlteracao
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, ModalPaisViewModel data)
        {
            var pais = _context.GetPais(id);
            if (pais is null)
            {
                return NotFound();
            }

            if (data.NmPais.Equals(pais.NmPais) && data.SiglaPais.Equals(pais.SiglaPais) && data.DdiPais.Equals(pais.DdiPais))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                pais.NmPais = data.NmPais;
                pais.SiglaPais = data.SiglaPais;
                pais.DdiPais = data.DdiPais;
                _context.EditPais(pais);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            ViewData["Title"] = "Deletar País";
            var pais = _context.GetPais(id);
            if (pais is null)
            {
                return NotFound();
            }
            var viewModel = new ModalPaisViewModel
            {
                Id = pais.Id,
                NmPais = pais.NmPais,
                SiglaPais = pais.SiglaPais,
                DdiPais = pais.DdiPais,
                DataCadastro = pais.DataCadastro,
                DataUltAlteracao = pais.DataUltAlteracao
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id, ModalPaisViewModel data)
        {
            var pais = _context.GetPais(id);
            if (pais is null)
            {
                return NotFound();
            }

            _context.DeletePais(pais.Id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var pais = _context.GetPais(id);
            var viewModel = new ModalPaisViewModel
            {
                Id = pais.Id,
                NmPais = pais.NmPais,
                SiglaPais = pais.SiglaPais,
                DdiPais = pais.DdiPais,
                DataCadastro = pais.DataCadastro,
                DataUltAlteracao = pais.DataUltAlteracao
            };
            return View(viewModel);
        }
    }


}