using Orleans;
using Orleans.Concurrency;
using System.Threading.Tasks;
using Vs.Did.Abstractions.Interfaces;
using Vs.Did.Integrations.Orleans.Interfaces;

namespace Vs.Did.Integrations.Orleans
{
    /// <summary></summary>
    /// <seealso cref="Orleans.Grain" />
    /// <seealso cref="Vs.Did.Integrations.Orleans.Interfaces.IDidGrain" />
    [StatelessWorker] [Reentrant]
    public class DidWorkerGrain : Grain, IDidGrain
    {
        public async Task<IDid> CreateDid(IMethodNamespace type)
        {
            return new Did(type.Namespace);
        }
    }
}
