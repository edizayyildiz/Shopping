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
        private ICommandHandler<SearchNewsletter> newsletterService;
        public HomeController(ICommandHandler<SearchCountrys> searchCountrysService,ICommandHandler<SearchProductCategories> SearchProductCategoriesService, ICommandHandler<SearchNewsletter> newsletterService) : base(SearchProductCategoriesService)
        {
            this.searchCountrysService = searchCountrysService;
            this.newsletterService = newsletterService;
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
        [HttpPost]
        public async Task<IActionResult> NewsletterSubscribtion(Newsletter newsletter, string controllerName, string actionName, string firstName, string lastName, string email, string phone, string department, string message)
        {
            var addNews = new AddNewsletter();
            var news = new SearchNewsletter();
            if (ModelState.IsValid)
            {
                var getEmails = await newsletterService.HandleAsync(news);
                if (((IEnumerable<Newsletter>)getEmails.Value).FirstOrDefault(f => f.Email == newsletter.Email)==null) 
                {
                   await newsletterService.HandleAsync(addNews);
                    return RedirectToAction(actionName, controllerName);
                }
                TempData["Message"] = "Bu E-Posta adresi sisteme kayıtlıdır.";
            }
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.From = new System.Net.Mail.MailAddress("tanerakyil@gmail.com", "tano");
            mailMessage.Subject = "İletişim Formu: " + firstName + " " + lastName;
            mailMessage.To.Add("tanerakyil@gmail.com,tanerakyil@gmail.com");
            string body;
            body = "Ad: " + firstName + "<br />";
            body = "Soyad: " + lastName + "<br />";
            body += "Telefon: " + phone + "<br />";
            body += "E-posta: " + email + "<br />";
            body += "Depart: " + department + "<br />";
            body += "Mesaj: " + message + "<br />";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = body;


            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new System.Net.NetworkCredential("mail", "sifre");
            smtp.EnableSsl = true;
            smtp.Send(mailMessage);

            ViewBag.Message = "Mesajınız gönderildi. Teşekkür ederiz.";
            return  Redirect("/" + controllerName + "/" + actionName + "/#mc_embed_signup");
        }
        public async Task<IActionResult> NewsletterUnsubscribtion(Newsletter newsletter, string controllerName, string actionName, string firstName, string lastName, string email, string phone, string department, string message)
        {
            var deleteNews = new DeleteNewsletter();
            var news = new SearchNewsletter();
            if (ModelState.IsValid)
            {
                var getEmails = await newsletterService.HandleAsync(news);
                if (((IEnumerable<Newsletter>)getEmails.Value).FirstOrDefault(f => f.Email == newsletter.Email) != null)
                {
                    await newsletterService.HandleAsync(deleteNews);
                    return RedirectToAction(actionName, controllerName);
                }
                TempData["Message"] = "Bu E-Posta adresi silindi.";
            }
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.From = new System.Net.Mail.MailAddress("tanerakyil@gmail.com", "tano");
            mailMessage.Subject = "İletişim Formu: " + firstName + " " + lastName;
            mailMessage.To.Add("tanerakyil@gmail.com,tanerakyil@gmail.com");
            string body;
            body = "Ad: " + firstName + "<br />";
            body = "Soyad: " + lastName + "<br />";
            body += "Telefon: " + phone + "<br />";
            body += "E-posta: " + email + "<br />";
            body += "Depart: " + department + "<br />";
            body += "Mesaj: " + message + "<br />";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = body;


            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new System.Net.NetworkCredential("mail", "sifre");
            smtp.EnableSsl = true;
            smtp.Send(mailMessage);

            ViewBag.Message = "Mesajınız gönderildi. Teşekkür ederiz.";
            return Redirect("/" + controllerName + "/" + actionName + "/#mc_embed_signup");

        
        }
      
        }

    }

