using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace oradotnet.api.Areas.ERP.System.Models
{
    public class CM_SYSTEM_USERS
    {
            //[Key]
            [Display(Name = "USER ID")]
            public int SYS_USR_ID { get; set; }

            [Required]
            [Display(Name = "UserName")]
            public string UserName { get; set; }
            
            [Display(Name = "Password")]
            [DataType(DataType.Password)]
            public string SYS_USR_PASS { get; set; }

            public string SYS_USR_DNAME { get; set; }
            public string SYS_USR_EMAIL { get; set; }


    }
}
