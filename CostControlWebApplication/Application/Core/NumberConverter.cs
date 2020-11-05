using Newtonsoft.Json;
using System;

namespace CostControlWebApplication
{
    public class NumberConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Decimal) == objectType || typeof(long) == objectType || typeof(int) == objectType;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null) return existingValue;
            var typecode = Convert.GetTypeCode(reader.Value);
            if (typecode == TypeCode.DBNull) return existingValue;
            return Convert.ChangeType(reader.Value, objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var typecode = Convert.GetTypeCode(value);
            if (typecode == TypeCode.DBNull) return;
            if (Convert.ToInt32(value) == 0) writer.WriteValue("");
            else if (typecode == TypeCode.Decimal || typecode == TypeCode.Double) writer.WriteValue(string.Format("{0:n2}", value));
            else writer.WriteValue(value);
        }
    }
}
