using System;
using App.Domain.Models;
using App.Domain.Rows;
using Moq;
using Xunit;

namespace App.WebUI.Tests
{
    public class DataTypesTest
    {
        [Fact]
        public void SetsDate()
        {
            var date = "2014-11-5";
            var row = CreateRow(FieldType.DATETIME, date);

            Assert.Equal(DateTime.Parse(date), row.Get<DateTime?>("field"));
        }

        [Fact]
        public void SetsString()
        {
            var row = CreateRow(FieldType.STRING, "test");
            Assert.Equal("test", row.Get<string>("field"));
        }

        [Fact]
        public void SetsInteger()
        {
            var row = CreateRow(FieldType.INTEGER, "123");
            Assert.Equal(123, row.Get<int?>("field"));
        }

        private Row CreateRow(string type, string value)
        {
            var field = new Field { Type = type, Name = "field" };
            var module = new Module();
            module.AddField(field);

            var row = new Row { Module = field.Module };
            row.AddValue(field, value);

            return row;
        }
    }

    public class RowTest
    {
        [Fact]
        public void SetsAndGetsValueWithCustomType()
        {
            var date = "2014-11-5";
            var field = new Field { Type = "datetime", Name = "created_at" };
            var fieldType = new FieldType<DateTime?> { Name = "datetime" };

            var fieldTypesMock = new Mock<FieldTypeCollection>();
            fieldTypesMock.Setup(m => m.GetFieldType("datetime")).Returns(fieldType);

            var moduleMock = new Mock<Module>();
            moduleMock.SetupGet(m => m.FieldTypes).Returns(fieldTypesMock.Object);
            moduleMock.Setup(m => m.GetField("created_at")).Returns(field);
            field.Module = moduleMock.Object;

            fieldType.Converter = new Func<string, DateTime?>((val) =>
            {
                return DateTime.Parse(val);
            });

            var row = new Row { Module = field.Module };
            row.AddValue(field, date);

            Assert.Equal(DateTime.Parse(date), row.Get<DateTime?>("created_at"));
        }

        [Fact]
        public void SetsAndGetsValue()
        {
            var row = new Row();
            var field = new Field { Type = "datetime", Name = "created_at" };
            row.AddValue(field, "2014-11-5");

            Assert.Equal("2014-11-5", row.Get("created_at"));
        }

        [Fact]
        public void EnumeratesOverValues()
        {
            var row = new Row();
            row.AddValue(new Field { Type = "datetime", Name = "created_at" }, "2014-11-5");
            row.AddValue(new Field { Type = "string", Name = "title" }, "Test title");
            var enumerator = row.Values.GetEnumerator();

            enumerator.MoveNext();
            Assert.Equal("2014-11-5", enumerator.Current.Value);
            enumerator.MoveNext();
            Assert.Equal("Test title", enumerator.Current.Value);
        }

        [Fact]
        public void ExportsAllValues()
        {
            var row = new Row();
            row.AddValue(new Field { Type = "datetime", Name = "date" }, "2014-11-5");
            row.AddValue(new Field { Type = "string", Name = "title" }, "Test");

            var values = row.ExportValues();

            Assert.Equal(2, values.Count);
            Assert.Equal("2014-11-5", values["date"]);
            Assert.Equal("Test", values["title"]);
        }

        [Fact]
        public void GetUnknownTypeReturnsDefault()
        {
            var row = new Row();

            Assert.Equal(null, row.Get<DateTime?>("field"));
        }

        [Fact]
        public void GetUnknownFieldReturnsNull()
        {
            var row = new Row();
            Assert.Equal(null, row.Get("field"));
        }
    }
}