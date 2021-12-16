using AutoMapper;
using BookApp.Business.Abstract;
using BookApp.Entities.Concrete;
using BookApp.WebUI.Mapping;
using BookApp.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.WebUI.Controllers
{

    public class ContactController : Controller
    {
        private IContactService _contactService;
        private readonly IMapper _mapper;
        public ContactController(IContactService contactService, IMapper mapper)
        {
            _mapper = mapper;
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(ContactModel contact)
        {
            //Contact contact1 = new Contact()
            //{
            //    ContactDate = contact.ContactDate,
            //    Mail = contact.Mail,
            //    Message = contact.Message,
            //    Subject = contact.Subject,
            //    UserName = contact.UserName
            //};
            var values = _mapper.Map<Contact>(contact);
            _contactService.Add(values);
            return RedirectToAction("Index","Home");
        }
    }
}
