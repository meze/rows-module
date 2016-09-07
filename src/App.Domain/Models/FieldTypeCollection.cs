using System;
using System.Collections.Generic;

namespace App.Domain.Models
{
    public class FieldTypeCollection
    {
        public virtual FieldType GetFieldType(string typeName)
        {
            var types = new Dictionary<string, FieldType>();

            types.Add(FieldType.DATETIME,
                new FieldType<DateTime?>
                {
                    Converter = new Func<string, DateTime?>((val) =>
                    {
                        return DateTime.Parse(val);
                    })
                })
            ;

            types.Add(FieldType.STRING,
                new FieldType<string>
                {
                    Converter = new Func<string, string>((val) => val)
                })
            ;

            types.Add(FieldType.INTEGER,
                new FieldType<int?>
                {
                    Converter = new Func<string, int?>((val) =>
                    {
                        int result;

                        if (int.TryParse(val, out result))
                        {
                            return result;
                        }
                        else
                        {
                            return null;
                        }
                    })
                })
            ;

            if (!types.ContainsKey(typeName))
            {
                throw new ArgumentException("No type is registered with this name", nameof(typeName));
            }

            return types[typeName];
        }
    }
}
