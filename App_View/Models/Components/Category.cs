using App_Data.DbContext;
using Microsoft.AspNetCore.Mvc;

namespace App_View.Models.Components
{
    public class Category : ViewComponent
    {
        private readonly AppDbContext behindthesceneContext;

        public Category(AppDbContext behindthesceneContext)
        {
            this.behindthesceneContext = behindthesceneContext;
        }

        public IViewComponentResult Invoke()
        {
            return View(behindthesceneContext.Hangs.ToList());
        }
    }
}
