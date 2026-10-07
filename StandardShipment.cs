namespace c__oop_ass4;

public class StandardShipment : Shipment
{
    public StandardShipment(
        string trackingCode,
        string description,
        decimal weight,
        decimal deliveryFee,
        DeliveryAddress destination)
        : base(trackingCode, description, weight, deliveryFee, destination)  //  chaining
    {
    }

    public override void PrintShipment()
    {
        Console.WriteLine("Tracking Code: " + TrackingCode);
        Console.WriteLine("Description: " + Description);
        Console.WriteLine("Weight: " + Weight);
        Console.WriteLine("Delivery Fee: " + DeliveryFee);
        Console.WriteLine("Estimated Cost: " + EstimatedCost);
    }
}
