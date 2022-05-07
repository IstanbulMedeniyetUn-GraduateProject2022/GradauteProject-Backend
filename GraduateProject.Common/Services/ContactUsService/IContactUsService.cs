using GraduateProject.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Common.Services.ContactUsService
{
    public interface IContactUsService
    {
        public Task<bool> AddWant(ContactUs model);
        public Task<bool> UpdateWant(ContactUs model);
        public Task<bool> DeleteWant(int id);
        public Task<List<ContactUs>> GetWants();
        public Task<ContactUs> GetWantById(int id);
    }
}
