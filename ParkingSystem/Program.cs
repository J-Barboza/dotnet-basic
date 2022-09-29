
using ParkingSystem.Models;

decimal initialPrice = 0;
decimal hourPrice = 0;

Console.Clear();
Console.WriteLine("*****************************************");
Console.WriteLine("***  Welcome to the parking system!!! ***");
Console.WriteLine("*****************************************\n\n");
Console.Write("Enter a initial value: ");
try 
{
    initialPrice = Convert.ToDecimal(Console.ReadLine());
    Console.Write("enter price per hour: ");
    hourPrice = Convert.ToDecimal(Console.ReadLine());
}
catch (Exception ex)
{
    Console.WriteLine("\nIncorrect value entered, please enter valid values\n");
    Console.WriteLine(ex.Message+"\n\n");
    return;
}


if (initialPrice <= 0 || hourPrice <= 0 )
{
    Console.WriteLine("\nIncorrect value entered, please enter valid values");
    Console.WriteLine("Press Enter to continue\n\n");
    Console.ReadKey();
    return;
}
    

Parking ps = new Parking(initialPrice, hourPrice);

string opcao = string.Empty;
bool exibirMenu = true;

// Loop of menu
while (exibirMenu)
{

    ps.mainMenu();

    switch (Console.ReadLine())
    {
        case "1":
            ps.AddVeicle();
            break;

        case "2":
            ps.RemoveVehicle();
            break;

        case "3":
            ps.ListVehicle();
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Invalild Option");
            break;
    }

    Console.WriteLine("\nPress Enter to continue");
    Console.ReadLine();
}

Console.WriteLine("The program ended");
