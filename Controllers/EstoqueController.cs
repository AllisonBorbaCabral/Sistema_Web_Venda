using AspNetCore.Contexts;
using AspNetCore.Models;
using AspNetCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Controllers
{

    public class EstoqueController : Controller
    {
        private EstoqueContext _context = new EstoqueContext();

        public IActionResult Index()
        {
            var estoques = _context.GetEstoques();
            var viewModel = new ListEstoqueViewModel { Estoques = estoques };
            ViewData["Title"] = "Lista de Estoques";
            return View(viewModel);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Cadastro de Estoque";
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateEstoqueViewModel data)
        {
            var estoque = new Estoque(data.Referencia, data.produto, data.cor, data.tamanho, data.Qtd, data.VlrCompra, data.VlrVenda, data.PercVenda);
            _context.CreateEstoque(estoque);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            ViewData["Title"] = "Editar Estoque";
            var estoque = _context.GetEstoque(id);
            if (estoque is null)
            {
                return NotFound();
            }
            var viewModel = new ModalEstoqueViewModel
            {
                Referencia = estoque.Referencia,
                produto = estoque.produto,
                cor = estoque.cor,
                tamanho = estoque.tamanho,
                Qtd = estoque.Qtd,
                VlrCompra = estoque.VlrCompra,
                VlrVenda = estoque.VlrVenda,
                PercVenda = estoque.PercVenda,
                DataCadastro = estoque.DataCadastro,
                DataUltAlteracao = estoque.DataUltAlteracao
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, ModalEstoqueViewModel data)
        {
            var estoque = _context.GetEstoque(id);
            if (estoque is null)
            {
                return NotFound();
            }

            if (data.Referencia.Equals(estoque.Referencia) && data.produto.Id.Equals(estoque.produto.Id) && data.cor.Id.Equals(estoque.cor.Id)
            && data.tamanho.Id.Equals(estoque.tamanho.Id) && data.Qtd.Equals(estoque.Qtd) && data.VlrCompra.Equals(estoque.VlrCompra)
            && data.VlrVenda.Equals(estoque.VlrVenda) && data.PercVenda.Equals(estoque.PercVenda))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                estoque.Referencia = data.Referencia;
                estoque.produto = data.produto;
                estoque.cor = data.cor;
                estoque.tamanho = data.tamanho;
                estoque.Qtd = data.Qtd;
                estoque.VlrCompra = data.VlrCompra;
                estoque.VlrVenda = data.VlrVenda;
                estoque.PercVenda = data.PercVenda;
                _context.EditEstoque(estoque);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            ViewData["Title"] = "Deletar Estoque";
            var estoque = _context.GetEstoque(id);
            if (estoque is null)
            {
                return NotFound();
            }
            var viewModel = new ModalEstoqueViewModel
            {
                Referencia = estoque.Referencia,
                produto = estoque.produto,
                cor = estoque.cor,
                tamanho = estoque.tamanho,
                Qtd = estoque.Qtd,
                VlrCompra = estoque.VlrCompra,
                VlrVenda = estoque.VlrVenda,
                PercVenda = estoque.PercVenda,
                DataCadastro = estoque.DataCadastro,
                DataUltAlteracao = estoque.DataUltAlteracao
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id, ModalEstoqueViewModel data)
        {
            var estoque = _context.GetEstoque(id);
            if (estoque is null)
            {
                return NotFound();
            }

            _context.DeleteEstoque(estoque.Referencia);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var estoque = _context.GetEstoque(id);
            var viewModel = new ModalEstoqueViewModel
            {
                Referencia = estoque.Referencia,
                produto = estoque.produto,
                cor = estoque.cor,
                tamanho = estoque.tamanho,
                Qtd = estoque.Qtd,
                VlrCompra = estoque.VlrCompra,
                VlrVenda = estoque.VlrVenda,
                PercVenda = estoque.PercVenda,
                DataCadastro = estoque.DataCadastro,
                DataUltAlteracao = estoque.DataUltAlteracao
            };
            return View(viewModel);
        }
    }


}