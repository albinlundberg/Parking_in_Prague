using System;
using System.Linq;
using System.Security.Claims;

namespace ConsoleApp3
{
    class Program
    {
        static string[] regPlate = new string[100];
        static string[] vechicleType = new string[2]; // Antalet fordonstyper (Bil och MC)
        static string[] parkingSpace = new string[100]; // Antalet p-platser
        static int tempVechicleCounter = 100;



        static void Main(string[] args)
        {

            // app info
            string appName = "Prague Parking";
            string appVersion = "1.0.0";
            string appDeveloper = "Albin Lundberg";
            bool running = true;
            Console.WriteLine($"{appName}: Version {appVersion} by {appDeveloper}");



            while (running)
            {
                Console.WriteLine("Welcome to Prague Parking");
                Console.WriteLine("What would you like to do do?: ");
                Console.WriteLine("1. Park Vehicle ");
                Console.WriteLine("2. Move a Vehicle");
                Console.WriteLine("3. Remove Vehicle");
                Console.WriteLine("4. Search for vehicle");
                Console.WriteLine("5. Quit");
                int option = Int32.Parse(Console.ReadLine());

                if (option != 1 && option != 2 && option != 3 && option != 4 && option != 5)
                {
                    Console.WriteLine("Wrong input...");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        ParkVehicle();
                        break;
                    case 2:
                        MoveVehicle();
                        break;
                    case 3:
                        RemoveVehicle();
                        break;
                    case 4:
                        SearchVehicle();
                        break;
                    case 5:
                        Console.WriteLine("Thank you and have a good day");
                        running = false;
                        Console.WriteLine("");
                        break;
                }
                Console.WriteLine(" ");
            }

        }

        private static void SearchVehicle()
        {


            Console.WriteLine("Please enter the registration number for the vehicle you want to find.");
            string currentRegPlate = Console.ReadLine();
            //regPlate = Console.ReadLine();

            for (int i = 0; i < parkingSpace.Length; i++)
            {
                if (parkingSpace[i] != null && parkingSpace[i].Contains(currentRegPlate) == true)
                {
                    Console.WriteLine("Your vechicle is located at the following parking spot: " + (i + 1));
                    break;
                }

                if (i == parkingSpace.Length - 1)
                {
                    Console.WriteLine("Couldn´t find any registstered vechicle with that license plate");
                    return;
                }
            }


        }

        private static void RemoveVehicle()
        {


            Console.WriteLine("Enter registration number to remove vehicle: ");
            string registrationNumberOfVehicleToBeRemoved = Console.ReadLine();

            for (int i = 0; i < regPlate.Length; i++)
            {
                if (regPlate[i] != null)
                {
                    if (regPlate[i].Contains(registrationNumberOfVehicleToBeRemoved))
                    {
                        regPlate[i] = null;
                        Console.WriteLine("Your vehicle was removed");
                    }

                }

            }


        }



        private static void MoveVehicle()
        {

            Console.Clear();
            //int optionVehicle = Int32.Parse(Console.ReadLine());
            // Användaren matar in fordonets reg-nummer
            // Lagra registreringsnummer i listan parkingSpace

            Console.WriteLine("What type of vehicle do you want to move?");
            Console.WriteLine("1. Car");
            Console.WriteLine("2. Motorbike");
            int vehicleType = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the registration number for the vehicle you want to move. ");
            string currentRegPlate = Console.ReadLine();
            string temp1 = currentRegPlate + "," + vehicleType;

            if (parkingSpace.Contains(temp1) == true)//Kollar ifall något fordon med numret finns registerad.
            {
                if (vehicleType == 1)
                { // bil
                    Console.WriteLine("Please enter the number you would like to move to \n\t first:" + (100 - tempVechicleCounter) + " parking lots are occupied");
                    int newParkingLot = Convert.ToInt32(Console.ReadLine());

                    for (int i = 0; i < regPlate.Length; i++) //tar bort från orginal platsen
                    {
                        if (regPlate[i] != null)
                        {
                            if (regPlate[i].Contains(currentRegPlate))
                            {
                                regPlate[i] = null;
                                Console.WriteLine("Your vehicle was removed");
                            }

                        }

                    }

                    parkingSpace[newParkingLot] = temp1; //flyttar 

                    Console.WriteLine(parkingSpace[newParkingLot] + " moved to lot: " + newParkingLot);

                }
                if (vehicleType == 2) // motorcyckel
                {
                    Console.WriteLine("Please enter the number you would like to move to \n\t first:" + (100 - tempVechicleCounter) + " parking lots are occupied");
                    int newParkingLot = Convert.ToInt32(Console.ReadLine());

                    for (int i = 0; i < regPlate.Length; i++) //tar bort från orginal platsen
                    {
                        if (regPlate[i] != null)
                        {
                            if (regPlate[i].Contains(currentRegPlate))
                            {
                                regPlate[i] = null;
                                Console.WriteLine("Your vehicle was removed");
                            }

                        }

                    }
                    string[] info = (parkingSpace[newParkingLot]).Split(',');
                    if (info[1] == "2")
                    {
                        string[] temparray = new string[2];
                        temparray[0] = currentRegPlate + "," + vehicleType;
                        temparray[1] = parkingSpace[newParkingLot];

                        string twoMotorbikes = string.Join("|", temparray);
                        parkingSpace[newParkingLot] = twoMotorbikes;
                        Console.WriteLine(" the lot consists of:  " + parkingSpace[newParkingLot]);
                    }





                }


            }
            else
            {
                Console.WriteLine("that car is not parked");
                return;
            }






        }

        public static void ParkVehicle()
        {
            Console.Clear();
            if (parkingSpace.Length == 0)
            {
                Console.WriteLine("Parking lot is full! \npress enter to return");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("What kind of vehicle do you want to park?");
            Console.WriteLine("1. Car");
            Console.WriteLine("2. Motorbike");

            string optionVehicle = Console.ReadLine();

            Console.WriteLine("Enter the registration number for the vehicle you want to park. ");
            string regPlate = Console.ReadLine();
            string temp = regPlate + "," + optionVehicle;

            if (regPlate.Length > 10)
            {
                Console.WriteLine("Please enter a valid registration number, e.g: ABC123");
                Console.ReadLine();
                Console.Clear();
                return;
            }
            if (parkingSpace.Contains(temp) == true) //fordonet finns redan parkerat?
            {
                Console.WriteLine("The vechicle has already been parked");
                return;
            }


            switch (optionVehicle)
            {
                case "1":
                    int parkingLotSapce = parkingSpace.Length - tempVechicleCounter;
                    tempVechicleCounter--;
                    if (parkingSpace[parkingLotSapce] != "")
                    {
                        tempVechicleCounter--;
                    }
                    parkingSpace[parkingLotSapce] = regPlate + "," + optionVehicle;
                    Console.WriteLine("Your car is parked at number: " + parkingLotSapce + "     (" + parkingSpace[parkingLotSapce] + ")");
                    break;

                case "2":
                    parkingLotSapce = parkingSpace.Length - tempVechicleCounter;
                    tempVechicleCounter--;
                    parkingSpace[parkingLotSapce] = regPlate + "," + optionVehicle;
                    Console.WriteLine("Your Motorbike is parked at number: " + parkingLotSapce + "     (" + parkingSpace[parkingLotSapce] + ")");
                    break;



                default:
                    Console.WriteLine("enter a valid input");
                    break;
            }



        }
    }
}


