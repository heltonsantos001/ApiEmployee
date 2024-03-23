using System.Text.Json.Serialization;

namespace WebApiVideo.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DepartamentoEnum
    {
        RH,
        FINANCEIRO,
        COMPRAS,
        ATENDIMNENTOS,
        ZELADORIA
    }
}
