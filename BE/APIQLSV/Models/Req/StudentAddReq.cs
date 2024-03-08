namespace APIQLSV.Models.Req
{
    public class StudentAddReq
    {
        public int Id { get; set; }
        public string StudentName { get; set; } = null!;

        public DateTime? DateOfBirth { get; set; }

        public string? Town { get; set; }
        public string Nameclass { get; set; } = null!;
    }
}
