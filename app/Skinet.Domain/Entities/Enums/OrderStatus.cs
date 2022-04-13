using System.Runtime.Serialization;

namespace Core.Entities.Enums
{
    public enum OrderStatus
    {
        [EnumMember(Value = "Pending")]
        Pending,
        [EnumMember(Value = "PaymentReceived")]
        PaymentReceived,
        [EnumMember(Value = "PaymentFailed")]
        PaymentFailed
    }
}