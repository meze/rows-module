using System.Collections.Generic;
using System.Linq;
using App.Domain.Entities.Structure;
using App.Domain.Models;

namespace App.Domain.Entities
{
    public class Module
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Field> Fields { get; set; }

        private List<Row> _rows = new List<Row>();

        public int SiteId { get; set; }

        public Site Site { get; set; }

        private static FieldTypeCollection _fieldTypes = new FieldTypeCollection();

        public Module()
        {
            Fields = new List<Field>();
        }

        public virtual FieldTypeCollection FieldTypes
        {
            get
            {
                return _fieldTypes;
            }

            set
            {
                _fieldTypes = value;
            }
        }

        public void AddField(Field field)
        {
            field.Module = this;

            if (Fields.Contains(field))
            {
                return;
            }

            Fields.Add(field);
        }

        public ICollection<Field> GetFields()
        {
            return Fields;
        }

        public virtual Field GetField(string name)
        {
            return Fields.FirstOrDefault(f => f.Name == name);
        }
    }
}