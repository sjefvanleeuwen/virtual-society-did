using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualSociety.VirtualSocietyDidApi.Controllers
{
    public class EmptyTask
    {
        public static Task Start()
        {
            var taskSource = new TaskCompletionSource<AsyncVoid>();
            taskSource.SetResult(default(AsyncVoid));
            return taskSource.Task as Task;
        }

        private struct AsyncVoid
        {
        }
    }
}
