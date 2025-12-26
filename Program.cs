using parcel_sending;
using System.Xml;

class Program
{
    static List<Parcel> parcels = new List<Parcel>();
    static Dictionary<int, Parcel> findParcels = new Dictionary<int, Parcel>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nChoose Option:");
            Console.WriteLine("1. send parcel");
            Console.WriteLine("2. process pending");
            Console.WriteLine("3. deliver");
            Console.WriteLine("4. track");
            Console.WriteLine("5. print sender");
            Console.WriteLine("6. exit");

            string answer = Console.ReadLine();

            switch(answer)
            {
                case "1":
                    SendParcel();
                    break;
                case "2":
                    ProcessPending();
                    break;
                case "3":
                    Deliver();
                    break;
                case "4":
                    Track();
                    break;
                case "5":
                    PrintSender();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Enter Correct Option");
                    break;
            }
        }
    }
    static void Deliver()
    {
        Console.WriteLine("Enter Parcel ID");
        int id = (int)Convert.ToInt32(Console.ReadLine());

        bool contain = false;
        if (findParcels.ContainsKey(id) && findParcels[id].Status == "in-transit")
        {
            findParcels[id].Status = "delivered";
            Console.WriteLine($"{findParcels[id].Id} has been delivered to {findParcels[id].ReceiverName}.");
        }
        else
        {
            Console.WriteLine("Parcel Not found");
        }

    }
    static void ProcessPending()
    {
        Random random = new Random();
        foreach (var parcel in parcels)
        {
            if (parcel.Status == "pending")
            {

                int number = random.Next(1, 4);

                string town = "";

                if (number == 1)
                {
                    town = "Tbilisi";
                }
                else if (number == 2)
                {
                    town = "Kutaisi";
                }
                else if (number == 3)
                {
                    town = "Batumi";
                }

                parcel.Status = "in-transit";
                parcel.Location = town;
                findParcels[parcel.Id].Status = "in-transit";
                findParcels[parcel.Id].Location = town;
                Console.WriteLine($"{parcel.Id} is now in-transit via {town}");
            }

        }
    }
    static void SendParcel()
    {
        int count = parcels.Count;

        Console.WriteLine("Enter Sender Name: ");
        string senderName = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(senderName))
        {
            Console.WriteLine("Enter Correct Name: ");
            senderName = Console.ReadLine();
        }


        Console.WriteLine("Enter Reciever Name: ");
        string recieverName = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(recieverName))
        {
            Console.WriteLine("Enter Correct Name: ");
            recieverName = Console.ReadLine();
        }

        int uniqueId = count + 1;

        Console.WriteLine("ID: " + uniqueId);

        Parcel parcel = new Parcel();
        parcel.Id = uniqueId;
        parcel.SenderName = senderName;
        parcel.ReceiverName = recieverName;
        parcel.Status = "pending";

        findParcels.Add(uniqueId, parcel);
        parcels.Add(parcel);

        Console.WriteLine("Parcel Send Successfully");

    }
    static void Track()
    {
        Console.WriteLine("Enter Parcel ID");
        int id = (int)Convert.ToInt32(Console.ReadLine());

        bool contain = false;
        Parcel parcel = null;
        if (findParcels.ContainsKey(id)) {
            parcel = findParcels[id];
            contain = true;
        }

        if (contain == true && parcel != null)
        {
            Console.WriteLine($"Status: {parcel.Status}");
            if (parcel.Status == "pending")
            {
                Console.WriteLine("Location: UnChanged");
            }
            else
            {
                Console.WriteLine($"Parcel {parcel.Id} is currently {parcel.Status} (Location: {parcel.Location})");
            }
        }
        else
        {
            Console.WriteLine("Parcel not found");
        }
    }
    static void PrintSender()
    {
        Console.WriteLine("Sender Name: ");
        string name = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Enter Correct Name: "); 
            name = Console.ReadLine();
        }

        bool contain = false;

        foreach (var item in findParcels.Values)
        {
            if (item.SenderName == name)
            {
                contain = true;
                Console.WriteLine($"- {item.Id}: {item.Status}");
            }
        }

        if (contain == false)
        {
            Console.WriteLine("Sender Not found");
        }

    }

}