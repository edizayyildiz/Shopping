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
        private ICommandHandler<SearchAdvertisements> searchAdvertisementsService;
        private  ICommandHandler<SearchCountrys> searchCountrysService;
        private ICommandHandler<SearchSlides> searchSlidesService;
        private ICommandHandler<SearchProducts> searchProductsService;
        private ICommandHandler<SearchNewsletter> newsletterService;
        public HomeController(ICommandHandler<SearchNewsletter> newsletterService, ICommandHandler<SearchProducts> searchProductsService, ICommandHandler<SearchAdvertisements> searchAdvertisementsService, ICommandHandler<SearchSlides> searchSlidesService,ICommandHandler<SearchCountrys> searchCountrysService,ICommandHandler<SearchProductCategories> SearchProductCategoriesService) : base(SearchProductCategoriesService)
        
        
        {
            this.searchCountrysService = searchCountrysService;
            this.searchSlidesService = searchSlidesService;
            this.searchAdvertisementsService = searchAdvertisementsService;
            this.searchProductsService = searchProductsService;
            this.newsletterService = newsletterService;
        }
        public async Task<IActionResult> Index()
        {
            //    var searchCountrys = new SearchCountrys();
            //    searchCountrys.Name = "G";
            //    Result result = await searchCountrysService.HandleAsync(searchCountrys);
            var searchSlides = new SearchSlides();
            Result result = await searchSlidesService.HandleAsync(searchSlides);
            ViewBag.Slides = result.Value;

            var searchAdvertisements = new SearchAdvertisements();
            Result result1 = await searchAdvertisementsService.HandleAsync(searchAdvertisements);
            ViewBag.Banners = result1.Value;

            var searchProducts = new SearchProducts();
            searchProducts.IsFeatured = true;
            Result result2 = await searchProductsService.HandleAsync(searchProducts);
            ViewBag.Products = result2.Value;
            return View();
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
        public async Task<IActionResult> NewsletterSubscribtion(string email)
        {
            var addNews = new AddNewsletter();
            var news = new SearchNewsletter();
            if (ModelState.IsValid)
            {
                var getEmails = await newsletterService.HandleAsync(news);
                if (((IEnumerable<Newsletter>)getEmails.Value).FirstOrDefault(f => f.Email == email)==null) 
                {
                   await newsletterService.HandleAsync(addNews);
                    
                }
                TempData["Message"] = "Bu E-Posta adresi sisteme kayıtlıdır.";
            }
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.From = new System.Net.Mail.MailAddress("tanerakyil@gmail.com", "tano");
            
            mailMessage.To.Add("tanerakyil@gmail.com,tanerakyil@gmail.com");
            
           string body = "E-posta: " + email + "<br />";

            mailMessage.IsBodyHtml = true;
            mailMessage.Body = body;


            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new System.Net.NetworkCredential("mail", "sifre");
            smtp.EnableSsl = true;
            smtp.Send(mailMessage);

            ViewBag.Message = "Mesajınız gönderildi. Teşekkür ederiz.";
            return  RedirectToAction("AddSubscribe");
        }
        public async Task<IActionResult> NewsletterUnsubscribtion(string email)
        {
            var deleteNews = new DeleteNewsletter();
            var news = new SearchNewsletter();
            if (ModelState.IsValid)
            {
                var getEmails = await newsletterService.HandleAsync(news);
                if (((IEnumerable<Newsletter>)getEmails.Value).FirstOrDefault(f => f.Email == email) != null)
                {
                    await newsletterService.HandleAsync(deleteNews);

                }
                TempData["Message"] = "Bu E-Posta adresi sisteme kayıtlıdır.";
            }
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.From = new System.Net.Mail.MailAddress("tanerakyil@gmail.com", "tano");

            mailMessage.To.Add("tanerakyil@gmail.com,tanerakyil@gmail.com");

            string body = "E-posta: " + email + "<br />";

            mailMessage.IsBodyHtml = true;
            mailMessage.Body = body;


            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new System.Net.NetworkCredential("mail", "sifre");
            smtp.EnableSsl = true;
            smtp.Send(mailMessage);

            ViewBag.Message = "Mesajınız gönderildi. Teşekkür ederiz.";
            return RedirectToAction("AddSubscribe");

        }
        public async Task<IActionResult> ConfirmNewsletter(string confirmationCode)
        {

            return View();
        }
       
      
        }

    }

