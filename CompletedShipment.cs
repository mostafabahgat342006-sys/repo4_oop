namespace c__oop_ass4;

public sealed class CompletedShipment : Shipment //   CompletedShipment ممنوع  اي كلاس اخر يورث من 
{
    public CompletedShipment(
        string trackingCode,
        string description,
        decimal weight,
        decimal deliveryFee,
        DeliveryAddress destination
    ) : base(
        trackingCode,
        description,
        weight,
        deliveryFee,
        destination)
    {
    }
}
