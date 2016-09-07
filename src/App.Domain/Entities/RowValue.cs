namespace App.Domain.Entities
{
    public class RowValue
    {
        public int Id { get; set; }

        public int? RowId { get; set; }

        public virtual Row Row { get; set; }

        public int? FieldId { get; set; }

        public virtual Field Field { get; set; }
        public string Value { get; set; }
    }
}
