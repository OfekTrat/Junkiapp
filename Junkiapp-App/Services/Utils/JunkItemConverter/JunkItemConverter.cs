using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Models.BasicModels;
using Models.JunkItem;

namespace Services.Utils.JunkItemConverter
{
    public class JunkItemConverter : JsonConverter<IJunkItem>
    {
        public override IJunkItem? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var document = JsonDocument.ParseValue(ref reader);
            var root = document.RootElement;
            JunkItemType junkItemType = getJunkItemType(root);

            IJunkItem item = junkItemType switch
            {
                JunkItemType.FaceBook => JsonSerializer.Deserialize<FacebookJunkItem>(root.GetRawText(), options),
                _ => JsonSerializer.Deserialize<JunkItem>(root.GetRawText(), options),
            };

            return item;
        }

        private JunkItemType getJunkItemType(JsonElement root) 
        {
            if (!root.TryGetProperty("type", out var typeFromJson))
            { 
                return JunkItemType.Standard;
            }

            if (!Enum.TryParse(typeFromJson.ToString(), out JunkItemType junkItemType))
            {
                throw new JsonException($"Unsupported Junk Item Type: {typeFromJson.ToString()}");
            }
            return junkItemType;
        }

        public override void Write(Utf8JsonWriter writer, IJunkItem value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
