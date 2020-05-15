using System.Threading.Tasks;

namespace Vs.Did.OpenApi.Controllers
{
    public class EmptyTask
    {
        public static Task Start()
        {
            var taskSource = new TaskCompletionSource<AsyncVoid>();
            taskSource.SetResult(default);
            return taskSource.Task as Task;
        }

        private struct AsyncVoid
        {
        }
    }
}
