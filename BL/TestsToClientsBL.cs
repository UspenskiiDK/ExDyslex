using DAL;
using DAL.DbModels;
using Entities;
using TestsToClient = Entities.TestsToClient;
using Task = System.Threading.Tasks.Task;

namespace BL
{
    public class TestsToClientsBL
    {
        public async Task CreateClient(TestsToClient testsToClient)
        {
            await new TestsToClientsDAL().CreateTestsToClient(testsToClient);
        }

        public async Task UpdateClient(TestsToClient testsToClient)
        {
            await new TestsToClientsDAL().UpdateTestsToClient(testsToClient);
        }

        public async Task DeleteClient(TestsToClient testsToClient)
        {
            await new TestsToClientsDAL().DeleteTestsToClient(testsToClient);
        }
    }
}
