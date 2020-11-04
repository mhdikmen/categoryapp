using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryApp.Core.Entities;

namespace CategoryApp.Entities.Dtos
{
    public class LoginDtoForResponse : IDto
    {
        public string Username { get; set; }
        public string Code { get; set; }
    }
}
