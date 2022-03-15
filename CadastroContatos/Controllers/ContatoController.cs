using CadastroContatos.Models;
using CadastroContatos.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CadastroContatos.Controllers
{
    public class ContatoController : Controller
    {
        /*
         *  Constructor 
         */
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        /*
         * Controller Index GET
         * Busca todos os contatos
         */
        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }


        /*
         * Controller Criar GET
         * Retorna View
         */
        public IActionResult Criar()
        {
            return View();
        }


        /*
         * Controller Criar POST
         * Salva o objeto de contato 
         */
        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            /*
             * Só deixa tentar salvar no banco
             * caso a model state esteja válida
             */
            try
            {
                if (ModelState.IsValid)
                {
                    // chama metodo Adiconar criado no Repositorio
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Erro ao cadastrar! erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }


        /*
         * Controller Editar GET
         * Retorna a view
         */
        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);    
            return View(contato);

        }

        /*
         * Controller Editar POST
         * Salva o objeto de contato 
         */
        [HttpPost]
        public IActionResult Editar(ContatoModel contato)
        {
            /*
              * Só deixa tentar atyalizar no banco
              * caso a model state esteja válida
              */
            try
            {
                if (ModelState.IsValid)
                {
                    // chama metodo Adiconar criado no Repositorio
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato atualizado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Erro ao atualizar! erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        /*
         * Controller Confirmação de apagar GET
         * Retorna a view
         */
        public IActionResult ApagarConfirm(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        /*
         * Controller apagar GET
         * Retorna a view
         */
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _contatoRepositorio.Apagar(id);
                if (apagado) {
                    TempData["MensagemSucesso"] = "Contato apagado!";
                }
                else
                {
                    TempData["MensagemErro"] = "Erro ao apagar!";
                }

                return RedirectToAction("Index");
            }
            catch(System.Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao apagar! erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
