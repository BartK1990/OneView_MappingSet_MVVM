using System;
using System.Diagnostics.CodeAnalysis;

namespace OneView_MappingSet_MVVM.Model
{
    public class Iec6140025Tag : IEquatable<Iec6140025Tag>
    {
        public string Tagname { get; set; }
        public string PresentationName { get; set; }
        public string Description { get; set; }
        public string OvSiType { get; set; }
        public string SiUnit { get; set; }
        public string Type { get; set; }
        public string DataType { get; set; }
        public string CollectorType { get; set; }

        public bool Equals([AllowNull] Iec6140025Tag other)
        {
            if (other == null)
                return false;
            if (this.Tagname == other.Tagname
                && this.PresentationName == other.PresentationName
                && this.Description == other.Description
                && this.OvSiType == other.OvSiType
                && this.SiUnit == other.SiUnit
                && this.Type == other.Type
                && this.DataType == other.DataType
                && this.CollectorType == other.CollectorType
                )
                return true;
            return false;
        }
    }
}
