using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shopping.Model.Entities;
using Shopping.Service;
using Shopping.Service.Commands;
using Shopping.Web.Models;

namespace Shopping.Web.Controllers
{
    public class HomeController : BaseController
    {
        private  ICommandHandler<SearchCountrys> searchCountrysService;
        private ICommandHandler<AddFeedback> feedbackService;
        public HomeController(ICommandHandler<SearchCountrys> searchCountrysService,ICommandHandler<SearchProductCategories> SearchProductCategoriesService, ICommandHandler<AddFeedback> feedbackService) : base(SearchProductCategoriesService)
        {
            this.searchCountrysService = searchCountrysService;
            this.feedbackService = feedbackService;
        }
        public async Task<IActionResult> Index()
        {
            var searchCountrys = new SearchCountrys();
            searchCountrys.Name = "G";
            Result result = await searchCountrysService.HandleAsync(searchCountrys);
            return View(result.Value);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Contact(ICommandHandler<AddFeedback> feedbackService, string firstName,  string email,  string subject, string message) {
           
           
            
            //var fed = new Feedback();
           
            var addFeedback = new AddFeedback();
            addFeedback.Name = firstName;
            addFeedback.Email = email;
            addFeedback.Subject = subject;
            addFeedback.Message = message;
            Result result = await feedbackService.HandleAsync(addFeedback);

            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.From = new System.Net.Mail.MailAddress("tanerakyil@gmail.com", "tano");
            mailMessage.Subject = "İletişim Formu: " + firstName ;
            mailMessage.To.Add("tanerakyil@gmail.com,tanerakyil@gmail.com");
            string body;
            body = "Ad: " + firstName + "<br />";
           
            body += "E-posta: " + email + "<br />";
            body += "Depart: " + subject + "<br />";
            body += "Mesaj: " + message + "<br />";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = body;


            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new System.Net.NetworkCredential("mail", "sifre");
            smtp.EnableSsl = true;
            smtp.Send(mailMessage);

            ViewBag.Message = "Mesajınız gönderildi. Teşekkür ederiz.";
            //TODO: Mail Gönderme işlemi yapılacak.
            ViewBag.Message = "Form başarıyla iletildi,en kısa zamanda dönüş yapacağız.";


            return RedirectToAction("Contact");
        }
    }
}
