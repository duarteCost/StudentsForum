/* 
*  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license. 
*  See LICENSE in the source repository root for complete license information. 
*/

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.Graph;
using MSALConnect.App_GlobalResources;
using MSALConnect.Models;
using MSALConnect.Services;
using System.Data;
using System.Data.SqlClient;

namespace MSALConnect.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View("Graph");
        }

        // Controller actions

        public ActionResult About()
        {
            return View();
        }

        //------------------------------------------------------------------------------//
        [Authorize]
        // Get the current user's email address from their profile.
        public ActionResult Degrees()
        {
            DB_DIS db = new DB_DIS();


            ViewBag.Degrees = db.Degrees;
            return View();
        }


        public ActionResult Courses(int id)
        {
            DB_DIS db = new DB_DIS();

            var degree = db.Degrees.Find(id);
            if (degree != null)
            {
                ViewBag.Courses = degree.courses;
            }

            return View();
        }

        ////------------------------------------------------------------------------------//

//        public ActionResult insereBaseDeDados()
//        {
//            string strcon = "Data Source= (LocalDb)\MSSQLLocalDB; AttachDbFilename=C:| DataDirectory |\DB_DIS.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
//            SqlConnection conexao = new SqlConnection(strcon);
//            SqlCommand cmd = new SqlCommand("INSERT INTO tabela(nome,numero) VALUES('" + textBox1.Text + "'," + textBox2.Text.Replace(",", ".") + ")", conexao); /* Insere no banco dentro de tabela nos campos nome e número os valores de textBox1 e 4, é necessário colocar o replace no texBox4, pois se o numero tiver "," não irá inserir no banco de dados, a "," representa o próximo campo nessa sintaxe, experimente deixar sem o replace para ver o que acontece
//Obs. quando estamos inserindo, deletando, ou alterando um valor no banco de dados, é importante notar que o textbox1 está entre ‘””’ pois essa é sintaxe que usamos quando o valor é uma string, note também que o texbox2 está entre ”” apenas, pois o valor é numérico, nesse caso do tipo float            */
//            try
//            {
//                conexao.Open();
//                cmd.ExecuteNonQuery();
//                /* chama o evento do click do button2 (na verdade é como se o button2 tivesse sido clicado, ou botão select do form2)sempre que quiser fazer com que ocorra um evento sem que o usuário tenha feito, é só passar o comando acima (se tiver duvida dê com copiar no "private void button2_Click(object sender, EventArgs e)" e deixe do jeito que eu modifiquei) o evento que ocorre quando clicamos no button2 é aquele que busca as informações no banco de dados e depois preenche o DataGridView com elas, ao usar button2_Click(sender, e); estamos fazendo com que aconteça exatamente isso, ao clicarmos no botão Insert ou Delete vai parecer q o campo inserido ou deletado no datagridview foi inserido ou deletado na mesma hora. Experimente comentar a linha button2_Click(sender, e); para ver a diferença. */
//            }
//            catch (Exception ex)
//            {
//                throw;
//            }
//            finally
//            {
//                conexao.Close();
//            }
//        }


        [Authorize]
        // Get the current user's email address from their profile.
        public async Task<ActionResult> GetMyEmailAddress()
        {
            try
            {
                // Get the current user's email address. 
                ViewBag.Email = await GraphService.Instance.GetMyEmailAddress();
                var studentNumber = ViewBag.Email.Split('@');
                ViewBag.studentNumber = studentNumber[0];

                return View("Graph");
            }
            catch ( ServiceException se )
            {
                if (se.Error.Message == Resource.Error_AuthChallengeNeeded) return new EmptyResult();
                return RedirectToAction("Index", "Error", new { message = Resource.Error_Message + Request.RawUrl + ": " + se.Error.Message });
            }
        }

        [Authorize]
        // Send mail on behalf of the current user.
        public async Task<ActionResult> SendEmail()
        {
            if ( string.IsNullOrEmpty( Request.Form["email-address"] ) )
            {
                ViewBag.Message = Resource.Graph_SendMail_Message_GetEmailFirst;
                return View("Graph");
            }

            try
            {
                // Build the email message.
                var message = EmailMessageBuilder.Build( 
                    Request.Form["recipients"], Request.Form["subject"], Resource.Graph_SendMail_Body_Content );

                // Send the email.
                await GraphService.Instance.SendEmail( message );

                // Reset the current user's email address and the status to display when the page reloads.
                ViewBag.Email = Request.Form["email-address"];
                ViewBag.Message = Resource.Graph_SendMail_Success_Result;

                return View("Graph");
            }
            catch (ServiceException se)
            {
                if (se.Error.Message == Resource.Error_AuthChallengeNeeded) return new EmptyResult();
                return RedirectToAction("Index", "Error", new { message = Resource.Error_Message + Request.RawUrl + ": " + se.Error.Message });
           }
        }
    }
}