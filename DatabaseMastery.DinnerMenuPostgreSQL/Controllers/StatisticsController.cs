using DatabaseMastery.DinnerMenuPostgreSQL.Context;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseMastery.DinnerMenuPostgreSQL.Controllers
{
    public class StatisticsController(AppDbContext _context) : Controller
    {
        public IActionResult Index()
        {
            var bugun = DateTime.Today;
            var yarin = bugun.AddDays(1);

            ViewBag.todayReservationCount = _context.Reservations.Count(r => r.ReservationDate >= bugun && r.ReservationDate < yarin).ToString();

            int fark = (int)bugun.DayOfWeek == 0 ? 6 : (int)bugun.DayOfWeek - 1;
            var haftaninBaslangici = bugun.AddDays(-fark);

            ViewBag.weeklyReservationCount = _context.Reservations.Count(r => r.ReservationDate >= haftaninBaslangici && r.ReservationDate < yarin).ToString();

            ViewBag.monthlyReservationCount = _context.Reservations.Count(r => r.ReservationDate.Month == bugun.Month && r.ReservationDate.Year == bugun.Year).ToString();

            ViewBag.activeReviewCount = _context.Reviews.Count(r => r.Status).ToString();
            ViewBag.passiveReviewCount = _context.Reviews.Count(r => !r.Status).ToString();
            ViewBag.activeProductCount = _context.Products.Count(p => p.Status).ToString();
            ViewBag.activeCategoryCount = _context.Categories.Count(c => c.CategoryStatus).ToString();

            ViewBag.totalCustomerCount = _context.Reservations.Sum(r => r.GuestCount).ToString();

            return View();
        }
    }
}