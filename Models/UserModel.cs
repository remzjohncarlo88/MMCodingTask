namespace MetaMindsCodingTask.Models
{
    public class UserModel
    {
        public int Page { get; set; }
        public int PerPage { get; set; }
        public int Total { get; set; }
        public int TotalPages { get; set; }
        public List<DataModel>? Data { get; set; }
        public SupportModel? Support { get; set; }
    }
}
