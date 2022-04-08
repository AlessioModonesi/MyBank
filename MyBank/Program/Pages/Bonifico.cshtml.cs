using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyBank.Pages
{
    public class BonificoModel : PageModel
    {
        public void OnGet()
        {
        }

        public void OnPostBonifico(string beneficiario, string IBAN, double importo, string data, string causale)
        {
            Program.utente = beneficiario;
            Program.IBAN = IBAN;
            Program.importo = importo;
            Program.data = data;
            Program.text = causale;
            Program.EffettuaBonifico();
        }
    }
}
