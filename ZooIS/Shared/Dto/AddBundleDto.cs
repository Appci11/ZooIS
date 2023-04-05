namespace ZooIS.Shared.Dto
{
    public class AddBundleDto
    {
        public int RegisteredUserId { get; set; }
        public List<AddBundleTicketDto> BundleTickets { get; set; } = new List<AddBundleTicketDto>();
    }
}
