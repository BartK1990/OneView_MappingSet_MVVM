using System;
using System.Diagnostics.CodeAnalysis;

namespace OneView_MappingSet_MVVM.Model
{
    public class DictionaryItem : IEquatable<DictionaryItem>
    {
        public string TurbineType { get; set; }
        public string Tagname { get; set; }
        public string SourceItemIdentifier { get; set; }
        public string SourceItemType { get; set; }
        public string SiType { get; set; }
        public string CollectorType { get; set; }
        public string ScaleFactor { get; set; }
        public string ScaleOffset { get; set; }
        public string Operation { get; set; }
        public string IsStatusTag { get; set; }
        public string ConsiderConditions { get; set; }
        public string QualityCondition { get; set; }
        public string ConsiderValue { get; set; }
        public string ValueCondition { get; set; }
        public string ExpressionModel { get; set; }
        public string ReadExpressionType { get; set; }
        public string ReadExpressionMappingSetTagValueId { get; set; }
        public string ReadExpression { get; set; }
        public string WriteExpressionType { get; set; }
        public string WriteExpressionMappingSetTagValueId { get; set; }
        public string WriteExpression { get; set; }
        public string TagMapping { get; set; }

        public bool Equals([AllowNull] DictionaryItem other)
        {
            if (other == null)
                return false;
            if (this.TurbineType == other.TurbineType
                && this.Tagname == other.Tagname
                && this.SourceItemIdentifier == other.SourceItemIdentifier
                && this.SourceItemType == other.SourceItemType
                && this.SiType == other.SiType
                && this.CollectorType == other.CollectorType
                && this.ScaleFactor == other.ScaleFactor
                && this.ScaleOffset == other.ScaleOffset
                && this.Operation == other.Operation
                && this.IsStatusTag == other.IsStatusTag
                && this.ConsiderConditions == other.ConsiderConditions
                && this.QualityCondition == other.QualityCondition
                && this.ConsiderValue == other.ConsiderValue
                && this.ValueCondition == other.ValueCondition
                && this.ExpressionModel == other.ExpressionModel
                && this.ReadExpressionType == other.ReadExpressionType
                && this.ReadExpressionMappingSetTagValueId == other.ReadExpressionMappingSetTagValueId
                && this.ReadExpression == other.ReadExpression
                && this.WriteExpressionType == other.WriteExpressionType
                && this.WriteExpressionMappingSetTagValueId == other.WriteExpressionMappingSetTagValueId
                && this.WriteExpression == other.WriteExpression
                && this.TagMapping == other.TagMapping
                )                                                            
                return true;
            return false;
        }
    }
}
