using System;
using System.Reflection;
using System.Runtime.Serialization;
using Innoactive.Creator.Core.Utils;
using NUnit.Framework.Constraints;

namespace Innoactive.Creator.Core.Attributes
{
    /// <summary>
    /// Declares that children of this list have metadata attributes and can be reordered.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class ReorderableListOfAttribute : ListOfAttribute
    {
        /// <inheritdoc />
        public ReorderableListOfAttribute(params Type[] childAttributes) : base(childAttributes) { }
    }
}
