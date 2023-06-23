using AspNetCore.Contexts;
using AspNetCore.Models;
using AspNetCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Controllers
{

    public class EstadoController : Controller
    {
        private EstadoContext _context = new EstadoContext();

        public IActionResult Index()
        {
            var estados = _context.GetEstados();
            var viewModel = new ListEstadoViewModel { Estados = estados };
            ViewData["Title"] = "Lista de Estados";
            return View(viewModel);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Cadastro de Estado";
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateEstadoViewModel data)
        {
            var estado = new Estado(data.NmEstado, data.Uf, data.pais);
            _context.CreateEstado(estado);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            ViewData["Title"] = "Editar Estado";
            var estado = _context.GetEstado(id);
            if (estado is null)
            {
                return NotFound();
            }
            var viewModel = new ModalEstadoViewModel
            {
                NmEstado = estado.NmEstado,
                Uf = estado.Uf,
                pais = estado.pais,
                DataCadastro = estado.DataCadastro,
                DataUltAlteracao = estado.DataUltAlteracao
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, ModalEstadoViewModel data)
        {
            var estado = _context.GetEstado(id);
            if (estado is null)
            {
                return NotFound();
            }

            if (data.NmEstado.Equals(estado.NmEstado) && data.Uf.Equals(estado.Uf) && data.pais.Id.Equals(estado.pais.Id))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                estado.NmEstado = data.NmEstado;
                estado.Uf = data.Uf;
                estado.pais.Id = data.pais.Id;
                _context.EditEstado(estado);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            ViewData["Title"] = "Deletar Estado";
            var estado = _context.GetEstado(id);
            if (estado is null)
            {
                return NotFound();
            }
            var viewModel = new ModalEstadoViewModel
            {
                Id = estado.Id,
                NmEstado = estado.NmEstado,
                Uf = estado.Uf,
                pais = estado.pais,
                DataCadastro = estado.DataCadastro,
                DataUltAlteracao = estado.DataUltAlteracao
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id, ModalEstadoViewModel data)
        {
            var estado = _context.GetEstado(id);
            if (estado is null)
            {
                return NotFound();
            }

            _context.DeleteEstado(estado.Id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var estado = _context.GetEstado(id);
            var viewModel = new ModalEstadoViewModel
            {
                Id = estado.Id,
                NmEstado = estado.NmEstado,
                Uf = estado.Uf,
                pais = estado.pais,
                DataCadastro = estado.DataCadastro,
                DataUltAlteracao = estado.DataUltAlteracao
            };
            return View(viewModel);
        }
    }


}