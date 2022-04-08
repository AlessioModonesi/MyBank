using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyBank.Pages
{
    public class BollettinoModel : PageModel
    {
        public void OnGet()
        {
        }
        public void OnPostBollettino(string tipologia, string codice, string cc, double importo)
        {
            Program.tipologia = tipologia;
            Program.codice = codice;
            Program.cc = cc;
            Program.importo = importo;
            Program.EffettuaBollettino();
        }
    }
}
