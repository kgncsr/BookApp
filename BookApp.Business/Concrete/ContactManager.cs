using BookApp.Business.Abstract;
using BookApp.DataAccess.Abstract;
using BookApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Business.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactManager(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public void Add(Contact contact)
        {
           _contactRepository.Add(contact);
        }

        public List<Contact> GetAll()
        {
            return _contactRepository.GetAll();
        }
    }
}
