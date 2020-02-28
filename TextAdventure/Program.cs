
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game {

class Program {

  static void Main(string[] args) {
    Console.WriteLine();

    Map map = new Map();
    Menu menu = new Menu();
    Player player = new Player();

    menu.Choices.Add("move", (argument) => {
      if (argument == null) {
        return;
      }

      if (player.Battling) {
        Console.WriteLine("You cannot run away from battle.");
        return;
      }

      if (Enum.TryParse(argument, true, out Direction direction)) {
        Room room = player.Room[direction];

        if (room != null) {
          room.TryEnter(player, direction);
        }
      }
    });

    menu.Choices.Add("look", (argument) => {
      if (player.Battling) {
        // ...
      } else {
        Console.WriteLine(player.Room.Description);

        foreach (Item item in player.Room.Items) {
          Console.WriteLine($"You see a(n) {item.Name} on the ground.");
        }

        foreach (var direction in (Direction[])Enum.GetValues(typeof(Direction))) {
          Room room = player.Room[direction];

          if (room != null) {
            string name = direction.ToString().ToLowerInvariant();
            Console.WriteLine($"{name}) {room.Name}");
          }
        }
      }
    });

    menu.Choices.Add("take", (argument) => {
      if (argument == null) {
        return;
      }

      Item found = player.Room.Items.FirstOrDefault((item) => (
        item.Name.ToLowerInvariant() == argument.ToLowerInvariant()
      ));

      if (found != null) {
        Console.WriteLine($"You pick up the {found.Name}");
        found.Take(player);
      }
    });

    menu.Choices.Add("drop", (argument) => {
      if (argument == null) {
        return;
      }

      Item found = player.Items.FirstOrDefault((item) => (
        item.Name.ToLowerInvariant() == argument.ToLowerInvariant()
      ));

      if (found != null) {
        found.Drop(player.Room);
        Console.WriteLine($"You dropped the {found.Name}");
      }
    });

    menu.Choices.Add("use", (argument) => {
      if (argument == null) {
        return;
      }

      Item found = player.Items.FirstOrDefault((item) => (
        item.Name.ToLowerInvariant() == argument.ToLowerInvariant()
      ));

      if (found != null) {
        Console.WriteLine($"You use the {found.Name}");
        found.Use(player);
      }
    });

    menu.Choices.Add("status", (argument) => {
      Console.WriteLine($"HP: {player.Health}");

      if (player.Weapon != null) {
        Console.WriteLine($"Weapon: {player.Weapon.Name} (attack: {player.Weapon.Attack})");
      } else {
        Console.WriteLine($"Weapon: none");
      }

      Console.WriteLine($"You have {player.Items.Count} item(s):");

      foreach (Item item in player.Items) {
        Console.WriteLine($" > {item.Name}");
      }
    });

    menu.Choices.Add("attack", (argument) => {
      var mobs = player.Room.Characters.OfType<Mob>();

      if (argument == null) {
        if (mobs.Count() == 1) {
          argument = mobs.ElementAt(0).Name;
        }
      }

      Mob target = mobs.FirstOrDefault((mob) => (
        mob.Name.ToLowerInvariant() == argument.ToLowerInvariant()
      ));

      if (target != null) {
        Console.WriteLine($"You attack the {target.Name}.");

        if (player.Weapon != null) {
          target.Health -= player.Weapon.Attack;
          Console.WriteLine($"You do {player.Weapon.Attack} damage.");

          if (target.Health <= 0) {
            Console.WriteLine($"You kill the {target.Name}.");
            target.Kill();
            target.Room = null;

            if (player.Room.Characters.OfType<Mob>().Count() == 0) {
              player.Battling = false;
            }

            return;
          }
        }

        target.Attack(player);

        if (player.Health <= 0) {
          Console.WriteLine("You died.");
        }

        Console.WriteLine($"Your HP: {player.Health}");

        foreach (Mob mob in mobs) {
          Console.WriteLine($"{mob.Name} HP: {mob.Health}");
        }
      }
    });

    map.StartingRoom.TryEnter(player, Direction.North);
    menu.Process();

    //loop condition
    // string[] rooms = new string[] { "1)Woods", "2)Cave", "3)Village Far Away", "4)Towards the Waterfall" };//Rooms
    // string[] weapons = new string[] { "Sword", "Shuriken", "Dagger", "JuJitsu" };//Rooms
    // string[] potion = new string[] { "Healing", "Mana", };
    // List<string> items = new List<string>() { "HP candy", "Chopstix", "Letter from your father", "Picture of your family" };//Items
    // List<string> mobs = new List<string>() { "Wandering Trader", "Fox", "Pig", "Salmon" };//Monsters

    for (;;) {
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
