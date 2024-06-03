using DAL;
using DAL.DbModels;
using Entities;
using Test = Entities.Test;
using Task = System.Threading.Tasks.Task;

namespace BL
{
    public class TestsBL
    {
        public async Task CreateClient(Test test)
        {
            await new TestsDAL().CreateTest(test);
        }

        public async Task UpdateClient(Test test)
        {
            await new TestsDAL().UpdateTest(test);
        }

        public async Task DeleteClient(Test test)
        {
            await new TestsDAL().DeleteTest(test);
        }
    }
}
