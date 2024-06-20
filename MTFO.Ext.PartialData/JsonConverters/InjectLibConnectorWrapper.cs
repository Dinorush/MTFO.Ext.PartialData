using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using InjectLib.JsonNETInjection.Supports;
using GameData;

namespace MTFO.Ext.PartialData.JsonConverters
{
    internal class InjectLibConnectorWrapper : JsonConverterFactory

    {
        private static readonly InjectLibConnector _connector = new();

        public override bool CanConvert(Type typeToConvert)
        {
            Type baseType = typeToConvert.BaseType;

            // For some reason, grouping the inheritance check with the GetGeneric... runs the latter when it shouldn't
            if (!baseType.IsGenericType)
                return _connector.CanConvert(typeToConvert);

            // Cannot let datablocks be taken to InjectLib land, lest the converters fail to apply.
            if (baseType.GetGenericTypeDefinition() == typeof(GameDataBlockBase<>))
                return false;

            return _connector.CanConvert(typeToConvert);
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            return _connector.CreateConverter(typeToConvert, options);
        }
    }
}
