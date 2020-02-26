
using System;
using System.Collections.Generic;

namespace Game {

class Room {

  public string Name { get; set; }
  public string Description { get; set; }

  public List<Room> Pathways { get; set; }

  public Room(string name, string description = "") {
    Name = name;
    Description = description;
    Pathways = new List<Room>();
  }

}

}
