namespace ZooIS.Shared.Dto
{
    public class UpdateWorkTaskDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }
}
