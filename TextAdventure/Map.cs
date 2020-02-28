
using System;
using System.Collections.Generic;

namespace Game {

class Map {

  public Room StartingRoom { get; private set; }

  public List<Room> Rooms { get; set; }

  public Map() {
    Rooms = new List<Room>();

    Room woods = new Room(this, "woods", "Extremely dark, must be nighttime. \" I can\'t see anything\".", "All you can really see is a distant village and a cave that looks like it could be filled with mosters, where would you like to go?");

    Room cave_entrance = new Room(this, "cave entrance", "As you approach the cave, a vast amaount of bats fly out of the cave leaving you spooked and unsure of the cave.");

    Room cave_1 = new Room(this, "cave", "As you enter the cave you see a tresure chest and open it. A sword glistens inside.");
    new IntroSword().Drop(cave_1);

    woods[Direction.North] = cave_entrance;

    cave_entrance[Direction.North] = cave_1;
    cave_entrance[Direction.South] = woods;

    cave_1[Direction.South] = cave_entrance;

    StartingRoom = woods;
  }

  public Room FindRoom(string name) {
    foreach (Room room in Rooms) {
      if (room.Name == name) {
        return room;
      }
    }

    return null;
  }

}

}
