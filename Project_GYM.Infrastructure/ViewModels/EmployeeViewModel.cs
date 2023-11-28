using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_GYM.Infrastructure.ViewModels
{
    public class EmployeeViewModel
    {
        public long EmployeeId { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string LengthOfService { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string JobTitle { get; set; }
    }
}
