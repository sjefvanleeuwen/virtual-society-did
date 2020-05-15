using Orleans;
using System.Threading.Tasks;
using Vs.Did.Abstractions.Interfaces;

namespace Vs.Did.Integrations.Orleans.Interfaces
{
    public interface IDidGrain : IGrainWithGuidKey
    {
        Task<IDid> CreateDid(IMethodNamespace type);
    }
}
