using BL;
using Entities;
using ExDyslex.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExDyslex.Admin.Controllers
{
    [Area("Admin")]
    public class TestsController : Controller
    {
        public IActionResult Index()
        {
            var tests = new TestsBL().GetAllTests();

            return View(tests);
        }

        public async Task<IActionResult> Test(int id)
        {
            var test = await new TestsBL().GetTestById(id);

            var tasks = new TasksBL().GetAllTasks();
            var existingTasksIds = new List<int>();

            if (test.Tasks != null && test.Tasks.Count > 0)
            {
                foreach (var task in test.Tasks)
                {
                    existingTasksIds.Add(task.Id);
                }
            }

            var tt = new TestTasksViewModel();
            tt.TestEntity = test;

            ViewBag.Tasks = tasks;
            ViewBag.ExistingTasksIds = existingTasksIds;
            return View(tt);
        }

        [HttpPost]
        public  void UpdateTasks([FromBody] List<string> tasksIDs)
        {
            
        }

        public async Task<IActionResult> Update(TestTasksViewModel test)
        {
            if (test == null || !ModelState.IsValid)
                return StatusCode(500);


            var ttt = new TasksToTestsBL().GetTaskToTestByTestId(test.TestEntity.Id);

            if (ttt != null && ttt.Count > 0)
            {
                foreach (var t in ttt)
                {
                    await new TasksToTestsBL().DeleteTaskToTest(t);
                }
            }

            var newTTT = new List<TasksToTest>();
            var tasksIdsString = test.TasksIds.Trim().Split(',');
            var tasksIds = new List<int>();

            foreach (var tstr in tasksIdsString)
            {
                tasksIds.Add(int.Parse(tstr));
            }

            foreach (var tt in tasksIds)
            {
                await new TasksToTestsBL().CreateTaskToTest(new TasksToTest(0, tt, test.TestEntity.Id));
            }

            await new TestsBL().UpdateTest(test.TestEntity);

            return RedirectToAction("Index", "Tests", new { Area = "Admin"});
        }
    }
}
