namespace CostControlWebApplication.Application.Services.Dtos
{
    public class BasicDataDto : Dto
    {
        public string GroupCode { get; set; }
        public long ParentID { get; set; }
        public string Name { get; set; }
        public string DataValue { get; set; }
        public string Remark { get; set; }
        public int IndexNo { get; set; }
        public string State { get; set; }

        public BasicDataDto[] Childs { get; set; }

        public bool HasChildren { get { return true; } }
    }
}
