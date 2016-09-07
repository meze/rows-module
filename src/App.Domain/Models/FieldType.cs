using System;

namespace App.Domain.Models
{
    public class FieldType
    {
        public const string DATETIME = "datetime";
        public const string STRING = "string";
        public const string INTEGER = "integer";
    }
    public class FieldType<T> : FieldType
    {
        public Func<string, T> Converter { get; set; }

        public string Name { get; set; }
    }
}