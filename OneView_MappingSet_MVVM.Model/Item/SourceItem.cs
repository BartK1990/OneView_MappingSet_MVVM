using System;
using System.Diagnostics.CodeAnalysis;

namespace OneView_MappingSet_MVVM.Model
{
    public class SourceItem : IEquatable<SourceItem>
    {
        public string SourceItemIdentifier { get; set; }

        public bool Equals([AllowNull] SourceItem other)
        {
            if (other == null)
                return false;

            return this.SourceItemIdentifier == other.SourceItemIdentifier;
        }
    }
}
