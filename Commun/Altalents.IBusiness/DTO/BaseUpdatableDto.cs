namespace Altalents.IBusiness.DTO
{
    public class BaseUpdatableDto
    {
        [Required]
        public bool IsSupprimable { get; set; }
        [Required]
        public bool IsModifiable { get; set; }
    }
}