using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyBank.Pages
{
    public class LoginModel : PageModel
    {
        public int pnt;
        public void OnGet()
        {
        }

        public void OnPostLogin(string email, string passwd)
        {
            Program.Search(ref email, ref passwd);
            if (email == Program.readerEmail[Program.pnt] && passwd == Program.readerPass[Program.pnt])
            {
                Startup.adminSetup = true;
                Program.LeggiUtente();
            }
            else if (email != Program.readerEmail[Program.pnt])
            {
                Startup.adminSetup = false;
                Program.error = "email";
            }   
            else
            {
                Startup.adminSetup = false;
                Program.error = "passwd";
            }
        }

        public void OnPostExit()
        {
            Startup.adminSetup = false;
        }
    }
}
