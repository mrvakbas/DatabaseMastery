using DatabaseMastery.DinnerMenuPostgreSQL.Context;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseMastery.DinnerMenuPostgreSQL.ViewComponents.DashboardViewComponents
{
    public class _DashboardLastReviewsComponentPartial(AppDbContext _context) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var values = _context.Reviews.OrderByDescending(x => x.ReviewId).Take(5).ToList();
            return View(values);
        }
    }
}