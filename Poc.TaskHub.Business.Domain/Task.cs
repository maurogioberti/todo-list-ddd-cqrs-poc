namespace Poc.TaskHub.Business.Domain
{
    public class Task
    {
        public int Id { get; set; } = default;
        public string Description { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }
}