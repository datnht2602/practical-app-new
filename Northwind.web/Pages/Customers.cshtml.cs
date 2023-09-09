using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Packt.Shared;

namespace Northwind.web.Pages
{
    public class CustomersModel : PageModel
    {
        private NorthwindContext db;
        public ILookup<string?, Customer>? CustomersByCountry;
        public CustomersModel(NorthwindContext injecteddb)
        {
            db = injecteddb;
        }
        public void OnGet()
        {
            ViewData["Title"] = "Northwind B2B - Customers";
            CustomersByCountry = db.Customers.ToLookup( c => c.Country);
        }
    }
}
