using AspNetCore.Contexts;
using AspNetCore.Models;
using AspNetCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Controllers
{

    public class CondicaoPagtoController : Controller
    {
        private CondicaoPagtoContext _context = new CondicaoPagtoContext();

        public IActionResult Index()
        {
            var condicoesPagto = _context.GetCondicoesPagto();
            var viewModel = new ListCondicaoPagtoViewModel { CondicoesPagto = condicoesPagto };
            ViewData["Title"] = "Lista de Condições de Pagto";
            return View(viewModel);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Cadastro de Condição de Pagto";
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCondicaoPagtoViewModel data)
        {
            var condicaoPagto = new CondicaoPagto(data.DsCondicaoPagto, data.Multa, data.Juros, data.DescFinanceiro);
            _context.CreateCondicaoPagto(condicaoPagto);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            ViewData["Title"] = "Editar Condição de Pagto";
            var condicaoPagto = _context.GetCondicaoPagto(id);
            if (condicaoPagto is null)
            {
                return NotFound();
            }
            var viewModel = new ModalCondicaoPagtoViewModel
            {
                DsCondicaoPagto = condicaoPagto.DsCondicaoPagto,
                Multa = condicaoPagto.Multa,
                Juros = condicaoPagto.Juros,
                DescFinanceiro = condicaoPagto.DescFinanceiro,
                DataCadastro = condicaoPagto.DataCadastro,
                DataUltAlteracao = condicaoPagto.DataUltAlteracao
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, ModalCondicaoPagtoViewModel data)
        {
            var condicaoPagto = _context.GetCondicaoPagto(id);
            if (condicaoPagto is null)
            {
                return NotFound();
            }

            if (data.DsCondicaoPagto.Equals(condicaoPagto.DsCondicaoPagto) && data.Multa.Equals(condicaoPagto.Multa)
            && data.Juros.Equals(condicaoPagto.Juros) && data.DescFinanceiro.Equals(condicaoPagto.DescFinanceiro))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                condicaoPagto.DsCondicaoPagto = data.DsCondicaoPagto;
                condicaoPagto.Multa = data.Multa;
                condicaoPagto.Juros = data.Juros;
                condicaoPagto.DescFinanceiro = data.DescFinanceiro;
                _context.EditCondicaoPagto(condicaoPagto);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            ViewData["Title"] = "Deletar Condição de Pagto";
            var condicaoPagto = _context.GetCondicaoPagto(id);
            if (condicaoPagto is null)
            {
                return NotFound();
            }
            var viewModel = new ModalCondicaoPagtoViewModel
            {
                Id = condicaoPagto.Id,
                DsCondicaoPagto = condicaoPagto.DsCondicaoPagto,
                Multa = condicaoPagto.Multa,
                Juros = condicaoPagto.Juros,
                DescFinanceiro = condicaoPagto.DescFinanceiro,
                DataCadastro = condicaoPagto.DataCadastro,
                DataUltAlteracao = condicaoPagto.DataUltAlteracao
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id, ModalCondicaoPagtoViewModel data)
        {
            var condicaoPagto = _context.GetCondicaoPagto(id);
            if (condicaoPagto is null)
            {
                return NotFound();
            }

            _context.DeleteCondicaoPagto(condicaoPagto.Id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var condicaoPagto = _context.GetCondicaoPagto(id);
            var viewModel = new ModalCondicaoPagtoViewModel
            {
                Id = condicaoPagto.Id,
                DsCondicaoPagto = condicaoPagto.DsCondicaoPagto,
                Multa = condicaoPagto.Multa,
                Juros = condicaoPagto.Juros,
                DescFinanceiro = condicaoPagto.DescFinanceiro,
                DataCadastro = condicaoPagto.DataCadastro,
                DataUltAlteracao = condicaoPagto.DataUltAlteracao
            };
            return View(viewModel);
        }
    }


}