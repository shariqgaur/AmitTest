using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.interfaces;

namespace Models
{
    public class LoginMangementModel : IMDKModel
    { 
            public String LoginName { get; set; }
            public String Password { get; set; }
        
        
    }


    public class sai {
        IMDKModel m;
        public void test(IMDKModel model) { 
       
        }


        public void first() { 
        test(new LoginMangementModel());
        }

    }
}