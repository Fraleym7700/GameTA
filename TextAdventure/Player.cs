
using System;

namespace Game {

class Player {

  public int Health { get; set; }
  public Room Room { get; set; }

  public Player(Room room) {
    Health = 100;
    Room = room;
  }

}

}
