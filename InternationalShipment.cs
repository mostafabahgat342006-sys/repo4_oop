namespace c__oop_ass4;

public class InternationalShipment : Shipment
{
    private string destinationCountry;
    private decimal customsFee;

    public string DestinationCountry
    {
        get
        {
            return destinationCountry;
        }

        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                destinationCountry = value;
            }
        }
    }

    public decimal CustomsFee
    {
        get
        {
            return customsFee;
        }

        set
        {
            if (value >= 0)
            {
                customsFee = value;
            }
        }
    }

    public override decimal EstimatedCost    // override
    {
        get
        {
            return DeliveryFee + (Weight * 5) + CustomsFee;
        }
    }

    public virtual void GenerateCustomsReport()
    {
        Console.WriteLine("Customs Report");
    }




    public InternationalShipment(
        string trackingCode,
        string description,
        decimal weight,
        decimal deliveryFee,
        DeliveryAddress destination,
        string destinationCountry, // new 
        decimal customsFee   // new
        ) : base(trackingCode, description, weight, deliveryFee, destination)  //  chaining
    {
        DestinationCountry = destinationCountry;
        CustomsFee = customsFee;
    }



    public override void PrintShipment()
    {
        Console.WriteLine("Tracking Code: " + TrackingCode);
        Console.WriteLine("Description: " + Description);
        Console.WriteLine("Weight: " + Weight);
        Console.WriteLine("Delivery Fee: " + DeliveryFee);
        Console.WriteLine("Estimated Cost: " + EstimatedCost);
        Console.WriteLine("Destination Country: " + DestinationCountry);
        Console.WriteLine("Customs Fee: " + CustomsFee);
    }
}
