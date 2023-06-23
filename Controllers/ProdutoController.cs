using AspNetCore.Contexts;
using AspNetCore.Models;
using AspNetCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Controllers
{

    public class ProdutoController : Controller
    {
        private ProdutoContext _context = new ProdutoContext();

        public IActionResult Index()
        {
            var produtos = _context.GetProdutos();
            var viewModel = new ListProdutoViewModel { Produtos = produtos };
            ViewData["Title"] = "Lista de Produtos";
            return View(viewModel);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Cadastro de Produto";
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateProdutoViewModel data)
        {
            var produto = new Produto(data.DsProduto, data.Ncm, data.Und, data.gradeCor, data.gradeTamanho);
            _context.CreateProduto(produto);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            ViewData["Title"] = "Editar Produto";
            var produto = _context.GetProduto(id);
            if (produto is null)
            {
                return NotFound();
            }
            var viewModel = new ModalProdutoViewModel
            {
                DsProduto = produto.DsProduto,
                Ncm = produto.Ncm,
                Und = produto.Und,
                gradeCor = produto.gradeCor,
                gradeTamanho = produto.gradeTamanho,
                DataCadastro = produto.DataCadastro,
                DataUltAlteracao = produto.DataUltAlteracao
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, ModalProdutoViewModel data)
        {
            var produto = _context.GetProduto(id);
            if (produto is null)
            {
                return NotFound();
            }

            if (data.DsProduto.Equals(produto.DsProduto) && data.Ncm.Equals(produto.Ncm) && data.Und.Equals(produto.Und) && data.gradeCor.Id.Equals(produto.gradeCor.Id) && data.gradeTamanho.Id.Equals(produto.gradeTamanho.Id))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                produto.DsProduto = data.DsProduto;
                produto.Ncm = data.Ncm;
                produto.Und = data.Und;
                produto.gradeCor = data.gradeCor;
                produto.gradeTamanho = data.gradeTamanho;
                _context.EditProduto(produto);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            ViewData["Title"] = "Deletar Produto";
            var produto = _context.GetProduto(id);
            if (produto is null)
            {
                return NotFound();
            }
            var viewModel = new ModalProdutoViewModel
            {
                Id = produto.Id,
                DsProduto = produto.DsProduto,
                Ncm = produto.Ncm,
                Und = produto.Und,
                gradeCor = produto.gradeCor,
                gradeTamanho = produto.gradeTamanho,
                DataCadastro = produto.DataCadastro,
                DataUltAlteracao = produto.DataUltAlteracao
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id, ModalProdutoViewModel data)
        {
            var produto = _context.GetProduto(id);
            if (produto is null)
            {
                return NotFound();
            }

            _context.DeleteProduto(produto.Id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var produto = _context.GetProduto(id);
            var viewModel = new ModalProdutoViewModel
            {
                Id = produto.Id,
                DsProduto = produto.DsProduto,
                Ncm = produto.Ncm,
                Und = produto.Und,
                gradeCor = produto.gradeCor,
                gradeTamanho = produto.gradeTamanho,
                DataCadastro = produto.DataCadastro,
                DataUltAlteracao = produto.DataUltAlteracao
            };
            return View(viewModel);
        }
    }


}