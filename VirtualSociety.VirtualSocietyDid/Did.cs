using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace VirtualSociety.VirtualSocietyDid
{
    /// </summary>
    public static class DidUriExtension
    {
        /// <summary>
        /// Extends the Microsoft .NET Uri specification with the did url specification format.
        /// NOTE: (partially implemented).
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns></returns>
        public static Did Did(this Uri uri)
        {
            var did = new Did();
            var segments = uri.AbsolutePath.Split(':');
            did.Method = segments[0];
            did.MethodNameSpace = string.Join(':', segments.Skip(1).Take(segments.Length - 2));
            did.MethodIdentifier = segments.Last();
            return did;
        }
    }

    public class Did
    {
        public string Scheme => "did";
        public string Method {get;set;}
        public string MethodIdentifier { get; set; }
        public string MethodNameSpace { get; set; }

        /// <summary>Generates the method identifier.</summary>
        /// <returns>base64 guid</returns>
        public static string GenerateMethodIdentifier()
        {
            return Regex.Replace(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "[/+=]", "");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Did"/> class.
        /// </summary>
        public Did()
        {
            Method = "vsoc";
            MethodNameSpace = string.Empty;
            MethodIdentifier = GenerateMethodIdentifier();
        }

        /// <summary>Initializes a new instance of the <see cref="Did"/> class.</summary>
        /// <param name="methodNameSpace"></param>
        /// <param name="method">The method (defaults to vsoc).</param>
        public Did(string methodNameSpace, string method = "vsoc")
        {
            Method = method.ToLower();
            MethodNameSpace = methodNameSpace.ToLower();
            MethodIdentifier = GenerateMethodIdentifier();
        }

        public string ToString()
        {
            return string.Join(":",
                (new []{Scheme,Method,MethodNameSpace,MethodIdentifier})
                .Where(s => !string.IsNullOrEmpty(s)));
        }
    }
}
