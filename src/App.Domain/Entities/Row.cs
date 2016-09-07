using System;
using System.Collections.Generic;
using System.Linq;
using App.Domain.Models;

namespace App.Domain.Entities
{
    public class Row
    {
        public Row()
        {
            CreatedAt = DateTimeOffset.Now;
            UpdatedAt = CreatedAt;
            Values = new List<RowValue>();
        }

        public DateTimeOffset CreatedAt { get; set; }
        public int Id { get; set; }
        public virtual Module Module { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public virtual ICollection<RowValue> Values { get; set; }

        public void AddValue(Field field, string value)
        {
            Values.Add(new RowValue
            {
                Value = value,
                Field = field,
                Row = this
            });
        }

        public IDictionary<string, string> ExportValues()
        {
            return Values.Select(v => new { Name = v.Field.Name, Value = v.Value }).ToDictionary(p => p.Name, p => p.Value);
        }

        public T Get<T>(string name)
        {
            if (Module != null)
            {
                var field = Module.GetField(name);
                if (field != null)
                {
                    var converterFunc = ((FieldType<T>)field.GetFieldType()).Converter;

                    return converterFunc(Get(field.Name));
                }
            }

            return default(T);
        }

        public string Get(string name)
        {
            var value = Values.FirstOrDefault(v => v.Field.Name == name);

            return value?.Value;
        }
    }
}