using BL;
using ExDyslex.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using Common.Enums;

namespace ExDyslex.Admin.Controllers
{
    [Area("Admin")]
    public class TasksController : Controller
    {
        public IActionResult Index()
        {
            var tasks = new TasksBL().GetAllTasks();

            return View(tasks);
        }

        public IActionResult Task(int id)
        {
            var task = new TasksBL().GetTaskById(id);
            var selectList = (Enum.GetValues(typeof(TaskCategories)).Cast<int>().Select(e => new SelectListItem() { Text = Enum.GetName(typeof(TaskCategories), e), Value = e.ToString() })).ToList();

            ViewBag.selectList = selectList;
            return View(task);
        }

        public async Task<IActionResult> Update(Entities.Task task)
        {
            if (task == null || !ModelState.IsValid)
                return StatusCode(500);

            await new TasksBL().UpdateTask(task);

            return RedirectToAction("Index", "Tasks", new { Area = "Admin" });
        }

        public IActionResult NewTask()
        {
            var selectList = (Enum.GetValues(typeof(TaskCategories)).Cast<int>().Select(e => new SelectListItem() { Text = Enum.GetName(typeof(TaskCategories), e), Value = e.ToString() })).ToList();

            ViewBag.selectList = selectList;
            return View();
        }

        public async Task<IActionResult> CreateTask(Entities.Task task)
        {
            if (task == null || !ModelState.IsValid)
                return StatusCode(500);


            await new TasksBL().CreateTask(task);

            return RedirectToAction("Index", "Tasks", new { Area = "Admin" });
        }
    }
}
