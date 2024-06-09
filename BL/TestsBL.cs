using DAL;
using DAL.DbModels;
using Entities;
using Test = Entities.Test;
using Task = System.Threading.Tasks.Task;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace BL
{
    public class TestsBL
    {
        public async Task<int> CreateTest(Test test)
        {
           return await new TestsDAL().CreateTest(test);
        }

        public async Task UpdateTest(Test test)
        {
            await new TestsDAL().UpdateTest(test);
        }

        public async Task DeleteTest(Test test)
        {
            await new TestsDAL().DeleteTest(test);
        }

        public List<Test> GetAllTests()
        {
            var tests = new TestsDAL().GetAllTests();

            return tests;
        }

        public async Task<Test?> GetTestById(int testId)
        {
            return await new TestsDAL().GetTesttById(testId);
        }
    }
}
