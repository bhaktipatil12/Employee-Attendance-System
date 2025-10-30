using Microsoft.AspNetCore.Mvc;
using EmployeeAttendanceSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAttendanceSystem.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttendanceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var records = await _context.Attendances
                .Include(a => a.Employee)
                .OrderByDescending(a => a.Date)
                .ToListAsync();
            return View(records);
        }

        public async Task<IActionResult> MarkAttendance()
        {
            ViewBag.Employees = await _context.Employees.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MarkAttendance(int employeeId, string status)
        {
            var attendance = new Attendance
            {
                EmployeeId = employeeId,
                Date = DateTime.Today,
                Status = status
            };

            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Report()
        {
            var records = await _context.Attendances
                .Include(a => a.Employee)
                .ToListAsync();
            return View(records);
        }
    }
}
