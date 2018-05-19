using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Hextech.LeagueClient.JsonConverters
{
    public class RgbaConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(Color);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Example data: rgba(250, 190, 10, 0.8)

            if (reader.Value == null) return null;

            string regex = @"rgba\((\d*\.?\d*),\s?(\d*\.?\d*),\s?(\d*\.?\d*),\s?(\d*\.?\d*)\)";
            GroupCollection gc = Regex.Match(reader.Value.ToString(), regex).Groups;

            if (gc.Count < 5) return null;

            int.TryParse(gc[1].Value, out int r);
            int.TryParse(gc[2].Value, out int g);
            int.TryParse(gc[3].Value, out int b);
            float.TryParse(gc[4].Value, NumberStyles.Any, CultureInfo.InvariantCulture, out float a);

            a = a * 0xFF; // a is in range 0-1 and FromArgb() expects it to be in range 0-255;
            
            return Color.FromArgb((int)a, r, g, b);
        }
    }
}
