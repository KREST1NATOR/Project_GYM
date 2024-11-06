using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_GYM.Infrastructure.ViewModels
{
    public class ClientViewModel
    {
        public long ClientId { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public long IdGym { get; set; }
        public long DiscountId { get; set; }
    }
}
