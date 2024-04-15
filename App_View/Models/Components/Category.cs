using App_Data.DbContext;
using Microsoft.AspNetCore.Mvc;

namespace App_View.Models.Components
{
    public class Category : ViewComponent
    {
        private readonly AppDbContext bazaizaiContext;

        public Category(AppDbContext bazaizaiContext)
        {
            this.bazaizaiContext = bazaizaiContext;
        }

        public IViewComponentResult Invoke()
        {
            return View(bazaizaiContext.ThuongHieus.ToList());
        }
    }
}
