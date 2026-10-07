using c__oop_ass4;

namespace c__oop_ass4;

internal class Program
{
    static void Main(string[] args)
    {




        /*
               Q1) 
                  
                   a- Abstraction is concept that hide unnecessary implementation details
                      and shows only the essential features
           
                   b- reduces complexity, hides unnecessary implementation details



               Q2) 
                  
                   a-  (abstract) : class is a base class can contain abstract members,fields,properties

                       (interface) : defines a contract that specifies what a class must do and 
                       one class can implement multiple interfaces
           


                   b- choose an interface when different classes need to share the same behavior 

                  

                   c- No  class cannot inherit from multiple abstract classes 
                      because C# does not support multiple class inheritance. 
        
                      but a class can implement multiple interfaces.








        */







        DeliveryCenter center = new DeliveryCenter();  // object 

        Console.Write("Enter Center Name: ");
        center.CenterName = Console.ReadLine();


        Console.WriteLine("\nEnter Standard Shipment Data:");
        //------------------------------------------------
        Console.Write("Tracking Code: ");
        string trackingCode = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        Console.Write("Weight: ");
        decimal weight = decimal.Parse(Console.ReadLine());

        Console.Write("Delivery Fee: ");
        decimal deliveryFee = decimal.Parse(Console.ReadLine());

        Console.Write("City: ");
        string city = Console.ReadLine();

        Console.Write("Street: ");
        string street = Console.ReadLine();

        Console.Write("Building Number: ");
        int buildingNumber = int.Parse(Console.ReadLine());
        // ----------------------------------------------------

        DeliveryAddress destination =
            new DeliveryAddress(city, street, buildingNumber);

        StandardShipment standard = new StandardShipment(
            trackingCode,
            description,
            weight,
            deliveryFee,
            destination
        );


        Console.WriteLine("\nEnter Express Shipment Data:");
        //-------------------------------------------------------
        Console.Write("Tracking Code: ");
        string expressTrackingCode = Console.ReadLine();

        Console.Write("Description: ");
        string expressDescription = Console.ReadLine();

        Console.Write("Weight: ");
        decimal expressWeight = decimal.Parse(Console.ReadLine());

        Console.Write("Delivery Fee: ");
        decimal expressDeliveryFee = decimal.Parse(Console.ReadLine());

        Console.Write("City: ");
        string expressCity = Console.ReadLine();

        Console.Write("Street: ");
        string expressStreet = Console.ReadLine();

        Console.Write("Building Number: ");
        int expressBuildingNumber = int.Parse(Console.ReadLine());

        Console.Write("Extra Fee: ");
        decimal extraFee = decimal.Parse(Console.ReadLine());
        //------------------------------------------------------------

        DeliveryAddress expressDestination =
            new DeliveryAddress(
                expressCity,
                expressStreet,
                expressBuildingNumber
            );

        ExpressShipment express = new ExpressShipment(
            expressTrackingCode,
            expressDescription,
            expressWeight,
            expressDeliveryFee,
            expressDestination,
            extraFee
        );




        Console.WriteLine("\nEnter International Shipment Data:");

        //--------------------------------------------------------
        Console.Write("Tracking Code: ");
        string internationalTrackingCode = Console.ReadLine();

        Console.Write("Description: ");
        string internationalDescription = Console.ReadLine();

        Console.Write("Weight: ");
        decimal internationalWeight = decimal.Parse(Console.ReadLine());

        Console.Write("Delivery Fee: ");
        decimal internationalDeliveryFee = decimal.Parse(Console.ReadLine());

        Console.Write("City: ");
        string internationalCity = Console.ReadLine();

        Console.Write("Street: ");
        string internationalStreet = Console.ReadLine();

        Console.Write("Building Number: ");
        int internationalBuildingNumber = int.Parse(Console.ReadLine());

        Console.Write("Destination Country: ");
        string destinationCountry = Console.ReadLine();

        Console.Write("Customs Fee: ");
        decimal customsFee = decimal.Parse(Console.ReadLine());
        //--------------------------------------------------------------------------

        DeliveryAddress internationalDestination =
            new DeliveryAddress(
                internationalCity,
                internationalStreet,
                internationalBuildingNumber
            );

        InternationalShipment international = new InternationalShipment(
                internationalTrackingCode,
                internationalDescription,
                internationalWeight,
                internationalDeliveryFee,
                internationalDestination,
                destinationCountry,
                customsFee
            );


        //----------------------------------------------------------------------------
        //----------------------------------------------------------------------------

        //  for add shipments

        center.AddShipment(standard);
        center.AddShipment(express);
        center.AddShipment(international);


        // i. 
        //  for printshipments

        DeliveryHelper.PrintShipmentDetails(standard);
        DeliveryHelper.PrintShipmentDetails(express);
        DeliveryHelper.PrintShipmentDetails(international);


        // j. 
        // to demonstrate overloading

        standard.UpdateWeight(10);
        express.UpdateWeight(10, 2);


        // k. 

        Shipment[] shipments = { standard, express, international }; // array object from Shipment

        Console.WriteLine("\nMixed Shipments:");

        foreach (Shipment shipment in shipments)
        {
            shipment.PrintShipment();
        }


        // l. 

        CompletedShipment completed = new CompletedShipment(
            "C001",
            "Completed Shipment",
            10,
            100,
            destination
        );

        PriorityInternationalShipment priority = new PriorityInternationalShipment(
            "P001",
            "Priority Shipment",
            10,
            100,
            destination,
            "Egypt",
            50
        );

        priority.GenerateCustomsReport();



        // another type of printing not depend on polymorphism 

        Console.WriteLine("\nAll Shipments:");
        center.PrintAllShipments();

        //----------------------------------------------------------------------

        Console.Write("\nEnter Tracking Code to search: ");
        string searchCode = Console.ReadLine();

        Shipment found = center[searchCode];

        if (found != null)
        {
            found.PrintShipment();
        }
        else
        {
            Console.WriteLine("Shipment not found.");
        }

        //----------------------------------------------------------------------

        Console.Write("\nEnter Tracking Code to remove: ");
        string removeCode = Console.ReadLine();

        bool removed = center.RemoveShipment(removeCode);

        if (removed)
        {
            Console.WriteLine("Shipment removed successfully.");
        }
        else
        {
            Console.WriteLine("Shipment not found.");
        }




        Console.WriteLine("\nRemaining Shipments now:");
        center.PrintAllShipments();


        //--------------------------------------------------------------

        Console.WriteLine("\nTracking Status:");

        DeliveryReport report = new DeliveryReport();

        report.PrintShipment(standard);
        report.PrintShipment(express);
        report.PrintShipment(international);





        Console.WriteLine("\nInsurance:");

        report.PrintInsurance(standard);
        report.PrintInsurance(express);
        report.PrintInsurance(international);


      //--------------------------------------------------------------------------------------------
        

        Console.WriteLine("\nTracking Status Using ITrackable Array:");

        // prove that Interface can gather different objects must but apply same Interface
        ITrackable[] trackableShipments =
        {
            standard,
            express,
            international
        };

        foreach (ITrackable shipment in trackableShipments)
        {
            Console.WriteLine(shipment.GetTrackingStatus());
        }





        Console.WriteLine("\nInsurance Using IInsurable Array:");

        IInsurable[] insurableShipments =
        {
            standard,
            express,
            international
        };

        foreach (IInsurable shipment in insurableShipments)
        {
            Console.WriteLine(shipment.CalculateInsurance());
        }







    }



}
