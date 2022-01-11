using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleShipLite2._5Library.LogicalComponents;
using BattleShipLite2._5Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BattleShipLite2._5.Pages
{
    public class BattleShipLite2Model : PageModel
    {
        public void OnGet()
        {


        }

        public IActionResult OnPost()
        {

            return Page();
        }
    }
}
