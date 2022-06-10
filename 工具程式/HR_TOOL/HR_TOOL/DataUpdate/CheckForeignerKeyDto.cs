namespace HR_TOOL.DataUpdate
{
    internal class CheckForeignerKeyDto
    {
        public string SourceTable { get; set; }
        public string SourceColumn { get; set; }
        public string SourceValue { get; set; }
        public string TargetTable { get; set; }
        public string TargetColumn { get; set; }
        public string TargetValue { get; set; }
    }
}