
using System;

namespace Game {

class Map {

  public Room StartingRoom { get; private set; }

  public Map() {
    Room woods = new Room("woods");
    Room waterfall = new Room("waterfall");
    Room cave = new Room("cave");
    Room village = new Room("village");

    woods.Pathways.Add(waterfall);
    woods.Pathways.Add(village);

    waterfall.Pathways.Add(cave);
    waterfall.Pathways.Add(woods);

    cave.Pathways.Add(waterfall);

    village.Pathways.Add(woods);

    StartingRoom = woods;
  }

}

}
