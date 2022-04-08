using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyBank.Pages
{
    public class RegistratiModel : PageModel
    {
        public void OnGet()
        {
            
        }
        public void OnPostSignup(string name, string email, string passwd)
        {
            Program.Search(ref email, ref passwd);
            if (Program.exist == false) //se mail e password non compaiono nei file
            {
                Program.utente = name;
                Program.email = email;
                Program.passwd = passwd;
                Program.row++;
                Program.WriteFile();
                Program.ReadFile();
            }
            else
                Program.error = "exist";
        }
    }
}
