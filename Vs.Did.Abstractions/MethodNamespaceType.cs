namespace Vs.Did.Abstractions
{
    public static class MethodNamespaceType
    {
        /// <summary>
        /// No method namespace
        /// </summary>
        public static MethodNamespace None { get { return new MethodNamespace(""); } }
        /// <summary>
        /// For groups that require majority voting principle and use a core set of voting procedures to reach that majority.
        /// </summary>
        public static MethodNamespace ConsensusVote { get { return new MethodNamespace("consensus:vote"); } }
        /// <summary>
        /// For groups that require unanimity and use a core set of procedures to reach unified consnesus through a blocking procedure.
        /// </summary>
        public static MethodNamespace ConsensusBlock { get { return new MethodNamespace("consensus:block"); } }
        /// <summary>
        /// For code generated for exascale computing (HPC) purposes using the actor model
        /// </summary>
        public static MethodNamespace GeneratedActor { get { return new MethodNamespace("gen:actor"); } }
    }
}
