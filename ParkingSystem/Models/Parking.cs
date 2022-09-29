using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingSystem.Models
{
    public class Parking
    {
        private decimal initialPrice = 0;
        private decimal hourPrice = 0;
        private List<string> vehicle = new List<string>();

        public Parking(decimal initialPrice, decimal hourPrice)
        {
            this.initialPrice = initialPrice;
            this.hourPrice = hourPrice;
        }

        public void AddVeicle()
        {
            Console.WriteLine("Enter vehicle license plate: ");
            string? licensePlate = Console.ReadLine();
            if (String.IsNullOrEmpty(licensePlate))
            {
                Console.WriteLine("Invalid information, please enter a valid license plate");
                return;
            } 
            foreach (var item in vehicle)
            {
                if (item == licensePlate)
                {
                    Console.WriteLine($"Vehicle { item } is already parked");
                    return;
                }
            }
            vehicle.Add(licensePlate);
            Console.WriteLine("Vehicle added");
        }

        public void RemoveVehicle()
        {
            Console.Write("\nEnter the vehicle to be removed: ");
            string? licensePlate = Console.ReadLine();
            if (String.IsNullOrEmpty(licensePlate))
            {
                Console.WriteLine("Invalid information, please enter a valid license plate");
                return;
            }

            Console.Write("Enter the number of hours the vehicle was parked (-1 to exit): ");
            int amontHours = 0;
            while(!int.TryParse(Console.ReadLine(), out amontHours))
            {
                mainMenu();
                Console.Write($"Enter the vehicle to be removed: { licensePlate }\n");
                Console.WriteLine("Please, inform a valid number (number >= 0 or negative number to exit(e.g. -1))");
                Console.Write("Enter the number of hours the vehicle was parked: ");
            }
            if (amontHours < 0 )
            {
                Console.WriteLine("\nNo vehicles have been removed");
                return;
            }
            
            foreach (var item in vehicle)
            {
                if (item == licensePlate)
                {
                    Console.Write($"Amount payable: U$ { (initialPrice + hourPrice * amontHours).ToString("0.00") }\n\n");
                    vehicle.Remove(licensePlate);
                    Console.WriteLine($"Vehicle { licensePlate } removed");
                    return;
                }
            }

            Console.WriteLine($"Vehicle { licensePlate } not found in the system");
        }

        public void ListVehicle()
        {
            int count=0;
            foreach (var item in vehicle)
            {
                Console.WriteLine(item);
                count++;
            }
            Console.WriteLine($"{count} parked vehicle");
        }

        public void mainMenu()
        {
            Console.Clear();
            Console.WriteLine("Digite a sua opção:");
            Console.WriteLine("1 - Add vehicle");
            Console.WriteLine("2 - Remove vehicle");
            Console.WriteLine("3 - Show vehicles");
            Console.WriteLine("4 - Exit");
        }
    }
}