using System;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Vs.Did.OpenApi.Controllers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    public sealed class NakedBodyAttribute : ParameterBindingAttribute
    {
        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter)
        {
            if (parameter == null)
                throw new ArgumentException("Invalid parameter");

            return new NakedBodyParameterBinding(parameter);
        }
    }
}
