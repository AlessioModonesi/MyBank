using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyBank.Pages.Shared
{
    public class AiutoModel : PageModel
    {
        public void OnGet()
        {
        }

        public void OnPost(string email, string prob)
        {
            //Console.Writeline(prob);
        }
    }
}
