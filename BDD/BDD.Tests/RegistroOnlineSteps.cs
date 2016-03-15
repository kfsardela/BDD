using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace BDD.Tests
{
    [Binding]
    public class RegistroOnlineSteps
    {
        IWebDriver Browser;

        [BeforeScenario]
        public void CreateWebDriver()
        {
            //Cria a instancia do browser antes de executar os cenarios
            this.Browser = new ChromeDriver();
        }

        [AfterScenario]
        public void CloseWebDriver()
        {
            //Fecha o browser depois que termina os cenarios
            this.Browser.Close();
            this.Browser.Dispose();
        }


        [Given(@"que sou um novo usuário")]
        public void DadoQueSouUmNovoUsuario()
        {
            //Faz Nada
        }
        
        [When(@"o eu navegar para a página de cadastro")]
        public void QuandoOEuNavegarParaAPaginaDeCadastro()
        {
            //Navega para a URL da pagina de Cadastro
            this.Browser.Navigate().GoToUrl("http://localhost:23324/Account/Create");
        }
        
        [When(@"inseri todas as informações do formulário corretas")]
        public void QuandoInseriTodasAsInformacoesDoFormularioCorretas()
        {
            //Pegando os elementos e gerando valores de testes
            var txtNome = this.Browser.FindElement(By.Id("Nome"));
            var txtEmail = this.Browser.FindElement(By.Id("Email"));
            var txtPassword = this.Browser.FindElement(By.Id("Password"));

            //Envia os dados para o formulário
            txtNome.SendKeys("Rafael Cruz");
            txtEmail.SendKeys("teste@teste.com.br");
            txtPassword.SendKeys("123Mudar");
        }
        
        [When(@"clicar no botão de criar conta")]
        public void QuandoClicarNoBotaoDeCriarConta()
        {
            var btnCriarConta = this.Browser.FindElement(By.Id("btnSubmit"));

            //Faz o submit no formulario
            btnCriarConta.Submit();

        }
        
        [When(@"não inseri as informações de email")]
        public void QuandoNaoInseriAsInformacoesDeEmail()
        {
            //Pegando os elementos e gerando valores de testes
            var txtNome = this.Browser.FindElement(By.Id("Nome"));
            var txtPassword = this.Browser.FindElement(By.Id("Password"));

            //Envia os dados para o formulário
            txtNome.SendKeys("Rafael Cruz");
            txtPassword.SendKeys("123Mudar");
        }
        
        [Then(@"o usuário deve ser redirecionado para a Home Page")]
        public void EntaoOUsuarioDeveSerRedirecionadoParaAHomePage()
        {
            Assert.IsTrue(this.Browser.Title == "Home Page - My ASP.NET MVC Application");
        }
        
        [Then(@"a pagina de cadastro deve exibir uma mensagem de erro")]
        public void EntaoAPaginaDeCadastroDeveExibirUmaMensagemDeErro()
        {
            Assert.IsTrue(this.Browser.FindElement(By.XPath("//span[@data-valmsg-for='Email']")).Text == "Email é obrigatório");
        }
    }
}
