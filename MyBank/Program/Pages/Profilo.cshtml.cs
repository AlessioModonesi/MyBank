using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyBank.Pages
{
    public class ProfiloModel : PageModel
    {
        public void OnGet()
        {
        }

        public void OnPostNome(string utente)
        {
            Program.CambiaNome(ref utente);
        }

        public void OnPostPasswd(string passwd)
        {
            Program.CambiaPasswd(ref passwd);
        }
    }
}
