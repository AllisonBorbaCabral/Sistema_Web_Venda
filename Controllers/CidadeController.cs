using AspNetCore.Contexts;
using AspNetCore.Models;
using AspNetCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Controllers
{

    public class CidadeController : Controller
    {
        private CidadeContext _context = new CidadeContext();

        public IActionResult Index()
        {
            var cidades = _context.GetCidades();
            var viewModel = new ListCidadeViewModel { Cidades = cidades };
            ViewData["Title"] = "Lista de Cidades";
            return View(viewModel);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Cadastro de Cidade";
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCidadeViewModel data)
        {
            var cidade = new Cidade(data.NmCidade, data.Ddd, data.estado);
            _context.CreateCidade(cidade);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            ViewData["Title"] = "Editar Cidade";
            var cidade = _context.GetCidade(id);
            if (cidade is null)
            {
                return NotFound();
            }
            var viewModel = new ModalCidadeViewModel
            {
                NmCidade = cidade.NmCidade,
                Ddd = cidade.Ddd,
                estado = cidade.estado,
                DataCadastro = cidade.DataCadastro,
                DataUltAlteracao = cidade.DataUltAlteracao
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, ModalCidadeViewModel data)
        {
            var cidade = _context.GetCidade(id);
            if (cidade is null)
            {
                return NotFound();
            }

            if (data.NmCidade.Equals(cidade.NmCidade) && data.Ddd.Equals(cidade.Ddd) && data.estado.Id.Equals(cidade.estado.Id))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                cidade.NmCidade = data.NmCidade;
                cidade.Ddd = data.Ddd;
                cidade.estado.Id = data.estado.Id;
                _context.EditCidade(cidade);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            ViewData["Title"] = "Deletar Cidade";
            var cidade = _context.GetCidade(id);
            if (cidade is null)
            {
                return NotFound();
            }
            var viewModel = new ModalCidadeViewModel
            {
                Id = cidade.Id,
                NmCidade = cidade.NmCidade,
                Ddd = cidade.Ddd,
                estado = cidade.estado,
                DataCadastro = cidade.DataCadastro,
                DataUltAlteracao = cidade.DataUltAlteracao
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id, ModalCidadeViewModel data)
        {
            var cidade = _context.GetCidade(id);
            if (cidade is null)
            {
                return NotFound();
            }

            _context.DeleteCidade(cidade.Id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var cidade = _context.GetCidade(id);
            var viewModel = new ModalCidadeViewModel
            {
                Id = cidade.Id,
                NmCidade = cidade.NmCidade,
                Ddd = cidade.Ddd,
                estado = cidade.estado,
                DataCadastro = cidade.DataCadastro,
                DataUltAlteracao = cidade.DataUltAlteracao
            };
            return View(viewModel);
        }
    }


}