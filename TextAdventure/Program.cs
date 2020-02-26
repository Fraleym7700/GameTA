
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game {

class Program {

  static void Main(string[] args) {
    Map map = new Map();
    Player player = new Player(map.StartingRoom);

    //loop condition
    bool exit = false;
    // string[] rooms = new string[] { "1)Woods", "2)Cave", "3)Village Far Away", "4)Towards the Waterfall" };//Rooms
    // string[] weapons = new string[] { "Sword", "Shuriken", "Dagger", "JuJitsu" };//Rooms
    // string[] potion = new string[] { "Healing", "Mana", };
    // List<string> items = new List<string>() { "HP candy", "Chopstix", "Letter from your father", "Picture of your family" };//Items
    // List<string> mobs = new List<string>() { "Wandering Trader", "Fox", "Pig", "Salmon" };//Monsters

    for (;;) {
      Console.WriteLine($"You are in {player.Room.Name}. {player.Room.Description}");
      Console.WriteLine("Where do you want to go?");
      int index = 1;

      foreach (Room room in player.Room.Pathways) {
        Console.WriteLine($"{index}) {room.Name}");
        ++index;
      }

      int number = Int32.Parse(Console.ReadLine());

      if (number >= 1 && number <= player.Room.Pathways.Count) {
        player.Room = player.Room.Pathways[number - 1];
      }

      //Display main menu for the users choices
      // Console.WriteLine("1.) Display Rooms");
      // Console.WriteLine("2.) Display Weapons");
      // Console.WriteLine("3.) Display potion");
      // Console.WriteLine("4.) Display Items");
      // Console.WriteLine("5,) Display Mob");
      // Console.WriteLine("6.) Play Game");
      // Console.WriteLine("7.) Exit");
      // Console.WriteLine();
      // Console.WriteLine("Enter Choice: ");

      // int choice = Convert.ToInt32(Console.In.ReadLine());

      // switch (choice)
      // {
      //   case 1:
      //     displayRooms(rooms);//Refer to the Display Room Function
      //     break;
      //   case 2:
      //     displayWeapons(weapons);//Refer to the Display Weapon Function
      //     break;
      //   case 3:
      //     displayPotions(potion); //Refer to the display potion function
      //     break;
      //   case 4:
      //       displayItem(items); // Refer to the Display item function
      //       break;
      //   case 5:
      //       displayMob(mobs);// Refer to the display mob funtion
      //       break;
      //   case 6:
      //       playGame(rooms);
      //       break;
      //   case 7:
      //       Console.WriteLine("Exiting the program"); //Allow user to exit
      //       break;
      //   default:
      //       {
      //           Console.WriteLine("Invalid entry. Please reenter choice: ");
      //           Console.Clear();
      //           break;
      //       } //end default
      //end switch
    }
}// ends public static void






        public static void displayRooms(List<Room> rooms)
        {

            for (int i = 0; i < rooms.Count; i++)
            {
                Console.WriteLine(rooms[i].Name + " ");
            }
        }



        public static void displayWeapons(string[] weapons)
        {

            for (int i = 0; i < weapons.Length; i++)
            {
                Console.WriteLine(weapons[i] + " ");
            }
        }

        public static void displayPotions(string[] potion)
        {

            for (int i = 0; i < potion.Length; i++)
            {
                Console.WriteLine(potion[i] + " ");
            }
        }

        public static void displayItem(List<string> items)
        {

            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"Items{items[i]}");
            }
        }

        public static void displayMob(List<string> mobs)
        {

            for (int i = 0; i < mobs.Count; i++)
            {
                Console.WriteLine($"Mobs{mobs[i]}");
            }
        }

        public static void playGame(List<Room> rooms)
        {
            bool exit = false;
            int roomNum = 0;
            do
            {
                //Display main menu for the users choices
              
                Console.WriteLine("1.) Move North");
                Console.WriteLine("2.) Move South");
                Console.WriteLine("3.) Attack");
                Console.WriteLine("5.) Exit");
                Console.WriteLine("");
                Console.WriteLine($"You are in {rooms[roomNum]}");

                int choice = Convert.ToInt32(Console.In.ReadLine());

                switch (choice)
                {
                    case 1:
                        moveNorth(rooms, ref roomNum);//Refer to the Display Room Function
                        break;
                    case 2:
                        moveSouth(rooms, roomNum);//Refer to the Display Weapon Function
                        break;
                    case 3:
                        Attack(20); //Refer to the display potion function
                        break; 
                    case 7:
                        Console.WriteLine("Exiting the program"); //Allow user to exit
                        break;
                    default:
                        {
                            Console.WriteLine("Invalid entry. Please reenter choice: ");
                            Console.Clear();
                            playGame(rooms);
                            break;
                        } //end default
                }//end switch
            } while (exit == false);//end while
        }// ends public static void

        public static void moveNorth(List<Room> rooms, ref int roomNum)
        {

            if (roomNum != 3)
            {
                roomNum++;
                Console.WriteLine(rooms[roomNum].Name);
            }
            else
            {
                Console.WriteLine("You went to far");
                Console.ReadLine();
            }

        }

        public static void moveSouth(List<Room> rooms, int roomNum)
        {
            if (roomNum != -1)
            {
                roomNum--;
                Console.WriteLine(rooms[roomNum].Name);
            }
            else
            {
                Console.WriteLine("You went to far");
                Console.ReadLine();
            }
        }
        public static void Attack(int number)
        {
            if (number >= 20)
                Console.WriteLine("Attack did large damagae");
            else if (number >= 10)
                Console.WriteLine("Attack landed with minimal damage");
            else
                Console.WriteLine("Attack Missed");

        }




    }// ends class
}// ends namespace
