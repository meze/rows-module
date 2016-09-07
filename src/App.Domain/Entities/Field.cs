using App.Domain.Models;

namespace App.Domain.Entities
{
    public class Field
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }

        public int ModuleId { get; set; }

        public virtual Module Module { get; set; }

        public FieldType GetFieldType()
        {
            return Module.FieldTypes.GetFieldType(Type);
        }
    }
}