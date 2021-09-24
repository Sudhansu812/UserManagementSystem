using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementSystemApi.Models.Dto
{
    public class UserCreateDto
    {
        [Required]
        public string UserFirstName { get; set; }

        [Required]
        public string UserLastName { get; set; }

        [Required]
        public string UserContactNumber { get; set; }

        [Required]
        public string UserAddress { get; set; }
    }
}
