using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace oradotnet.api.Areas.ERP.System.Models
{
    public class CM_SYSTEM_USERS
    {
            [Display(Name = "USER ID")]
            public string SYS_USR_ID { get; set; }

            [Display(Name = "USER NAME")]
            public string SYS_USR_DNAME { get; set; }

            [Display(Name = "UserName")]
            public string UserName { get; set; }

            [Display(Name = "Password")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [DataType(DataType.EmailAddress)]
            public string SYS_USR_EMAIL { get; set; }

        //[Display(Name = "USER GROUP")]
        //public string SYS_USR_GRP_ID { get; set; }
        //public string CMP_BRANCH_ID { get; set; }
        //[NotMapped]
        //public string CMP_BRANCH_NAME { get; set; }

        public string taskName { get; set; }

        public string taskImage { get; set; }

        //public string LOCKED_STATUS { get; set; }

        //public DateTime PASSWORD_EXPIRED_DATE { get; set; }

        //public string CLICK_FAILURE { get; set; }

        //public string SYS_USR_PASS_PREVIOUS { get; set; }

        //public string USER_TYPE { get; set; }

        //public string USER_NATURE { get; set; }

        //public string COMPANY_ID { get; set; }

        //public string USER_MOBILE { get; set; }

        //public string DPT_ID { get; set; }
        //[NotMapped]
        //public string DPT_NAME { get; set; }

        //public string INV_DEALER_ID { get; set; }

        //public string SYS_ADDRESS { get; set; }

        //public string SYS_IMAGE { get; set; }

        //public string IS_ADMIN { get; set; }

        //public string PHONE_NUMBER { get; set; }

        //public bool IsRememberMe { get; set; }

        //public string DPTDSWISE_ID { get; set; }

    }
}
