using System.ComponentModel.DataAnnotations;

namespace IEMS.Core.Entities
{
    public class SystemSetting
    {
        [Key]
        public string Key { get; set; } = string.Empty;

        public string Value { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public string DataType { get; set; } = "String";

        public string? DefaultValue { get; set; }

        public bool IsReadOnly { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? ModifiedAt { get; set; }
    }
}