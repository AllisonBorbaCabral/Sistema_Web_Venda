using AspNetCore.Contexts;
using AspNetCore.Models;
using AspNetCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Controllers
{
    public class FuncionarioController : Controller
    {
        private FuncionarioContext _context = new FuncionarioContext();

        public IActionResult Index()
        {
            var funcionarios = _context.GetFuncionarios();
            var viewModel = new ListFuncionarioViewModel { Funcionarios = funcionarios };
            ViewData["Title"] = "Lista de Funcionarios";
            return View(viewModel);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Cadastro de Funcionario";
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateFuncionarioViewModel data)
        {
            var funcionario = new Funcionario(data.NmPessoa, data.Sexo, data.DsLogradouro, data.Numero, data.Complemento, data.Bairro, data.TelFixo, data.Celular, data.Email, data.cidade, data.Cep, data.Cpf, data.Rg, data.DataNascimento, data.DataAdmissao, data.DataDemissao, data.Salario);
            _context.CreateFuncionario(funcionario);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            ViewData["Title"] = "Editar Funcionario";
            var funcionario = _context.GetFuncionario(id);
            if (funcionario is null)
            {
                return NotFound();
            }
            var viewModel = new ModalFuncionarioViewModel
            {
                NmPessoa = funcionario.NmPessoa,
                Sexo = funcionario.Sexo,
                DsLogradouro = funcionario.DsLogradouro,
                Numero = funcionario.Numero,
                Complemento = funcionario.Complemento,
                Bairro = funcionario.Bairro,
                TelFixo = funcionario.TelFixo,
                Celular = funcionario.Celular,
                Email = funcionario.Email,
                cidade = funcionario.cidade,
                Cep = funcionario.Cep,
                Cpf = funcionario.Cpf,
                Rg = funcionario.Rg,
                DataNascimento = funcionario.DataNascimento,
                DataAdmissao = funcionario.DataAdmissao,
                DataDemissao = funcionario.DataDemissao,
                Salario = funcionario.Salario,
                DataCadastro = funcionario.DataCadastro,
                DataUltAlteracao = funcionario.DataUltAlteracao
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, ModalFuncionarioViewModel data)
        {
            var funcionario = _context.GetFuncionario(id);
            if (funcionario is null)
            {
                return NotFound();
            }

            if (data.NmPessoa.Equals(funcionario.NmPessoa) && data.Sexo.Equals(funcionario.Sexo) 
            && data.DsLogradouro.Equals(funcionario.DsLogradouro) && data.Numero.Equals(funcionario.Numero)
            && data.Complemento.Equals(funcionario.Complemento) && data.Bairro.Equals(funcionario.Bairro)
            && data.TelFixo.Equals(funcionario.TelFixo) && data.Celular.Equals(funcionario.Celular) && 
            data.Email.Equals(funcionario.Email) && data.cidade.Id.Equals(funcionario.cidade.Id) && 
            data.Cep.Equals(funcionario.Cep) && data.Cpf.Equals(funcionario.Cpf) && data.Rg.Equals(funcionario.Rg)
            && data.DataNascimento.Equals(funcionario.DataNascimento) && data.DataAdmissao.Equals(funcionario.DataAdmissao)
            && data.DataDemissao.Equals(funcionario.DataDemissao) && data.Salario.Equals(funcionario.Salario))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                funcionario.NmPessoa = data.NmPessoa;
                funcionario.Sexo = data.Sexo;
                funcionario.DsLogradouro = data.DsLogradouro;
                funcionario.Numero = data.Numero;
                funcionario.Complemento = data.Complemento;
                funcionario.Bairro = data.Bairro;
                funcionario.TelFixo = data.TelFixo;
                funcionario.Celular = data.Celular;
                funcionario.Email = data.Email;
                funcionario.cidade = data.cidade;
                funcionario.Cep = data.Cep;
                funcionario.Cpf = data.Cpf;
                funcionario.Rg = data.Rg;
                funcionario.DataNascimento = data.DataNascimento;
                funcionario.DataAdmissao = data.DataAdmissao;
                funcionario.DataDemissao = data.DataDemissao;
                funcionario.Salario = data.Salario;
                _context.EditFuncionario(funcionario);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            ViewData["Title"] = "Deletar Funcionario";
            var funcionario = _context.GetFuncionario(id);
            if (funcionario is null)
            {
                return NotFound();
            }
            var viewModel = new ModalFuncionarioViewModel
            {
                Id = funcionario.Id,
                NmPessoa = funcionario.NmPessoa,
                Sexo = funcionario.Sexo,
                DsLogradouro = funcionario.DsLogradouro,
                Numero = funcionario.Numero,
                Complemento = funcionario.Complemento,
                Bairro = funcionario.Bairro,
                TelFixo = funcionario.TelFixo,
                Celular = funcionario.Celular,
                Email = funcionario.Email,
                cidade = funcionario.cidade,
                Cep = funcionario.Cep,
                Cpf = funcionario.Cpf,
                Rg = funcionario.Rg,
                DataNascimento = funcionario.DataNascimento,
                DataAdmissao = funcionario.DataAdmissao,
                DataDemissao = funcionario.DataDemissao,
                Salario = funcionario.Salario,
                DataCadastro = funcionario.DataCadastro,
                DataUltAlteracao = funcionario.DataUltAlteracao
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id, ModalFuncionarioViewModel data)
        {
            var funcionario = _context.GetFuncionario(id);
            if (funcionario is null)
            {
                return NotFound();
            }

            _context.DeleteFuncionario(funcionario.Id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var funcionario = _context.GetFuncionario(id);
            var viewModel = new ModalFuncionarioViewModel
            {
                Id = funcionario.Id,
                NmPessoa = funcionario.NmPessoa,
                Sexo = funcionario.Sexo,
                DsLogradouro = funcionario.DsLogradouro,
                Numero = funcionario.Numero,
                Complemento = funcionario.Complemento,
                Bairro = funcionario.Bairro,
                TelFixo = funcionario.TelFixo,
                Celular = funcionario.Celular,
                Email = funcionario.Email,
                cidade = funcionario.cidade,
                Cep = funcionario.Cep,
                Cpf = funcionario.Cpf,
                Rg = funcionario.Rg,
                DataNascimento = funcionario.DataNascimento,
                DataAdmissao = funcionario.DataAdmissao,
                DataDemissao = funcionario.DataDemissao,
                Salario = funcionario.Salario,
                DataCadastro = funcionario.DataCadastro,
                DataUltAlteracao = funcionario.DataUltAlteracao
            };
            return View(viewModel);
        }
    }
}