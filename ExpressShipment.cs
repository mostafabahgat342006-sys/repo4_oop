namespace c__oop_ass4;

public class ExpressShipment : Shipment
{
    private decimal extraFee;  //new property

    public decimal ExtraFee
    {
        get
        {
            return extraFee;
        }

        set
        {
            if (value >= 0)
            {
                extraFee = value;
            }
        }
    }

    public override decimal EstimatedCost    // override
    {
        get
        {
            return DeliveryFee + (Weight * 5) + ExtraFee;
        }
    }

    public ExpressShipment(
        string trackingCode,
        string description,
        decimal weight,
        decimal deliveryFee,
        DeliveryAddress destination,
        decimal extraFee  // new 
        ) : base(trackingCode, description, weight, deliveryFee, destination) //  chaining
    {
        ExtraFee = extraFee;
    }


    public override void PrintShipment()
    {
        Console.WriteLine("Tracking Code: " + TrackingCode);
        Console.WriteLine("Description: " + Description);
        Console.WriteLine("Weight: " + Weight);
        Console.WriteLine("Delivery Fee: " + DeliveryFee);
        Console.WriteLine("Estimated Cost: " + EstimatedCost);
        Console.WriteLine("Extra Fee: " + ExtraFee);
    }
}
