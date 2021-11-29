using AutoMapper;
using BookApp.Entities.Concrete;
using BookApp.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.WebUI.Mapping
{
    public class ContactMapping : Profile
    {
        public ContactMapping()
        {
            CreateMap<Contact, ContactModel>().ReverseMap();
            //CreateMap<ContactModel, Contact>();
        }
    }
}
