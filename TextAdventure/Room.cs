
using System;
using System.Collections.Generic;

namespace Game {

enum Direction {

  North,
  NorthEast,
  East,
  SouthEast,
  South,
  SouthWest,
  West,
  NorthWest,

}

class Room {

  public string Name { get; protected set; }
  public string Prologue { get; protected set; }
  public string Description { get; protected set; }
  private bool Entered { get; set; }

  public List<Character> Characters { get; private set; }
  public List<Item> Items { get; private set; }

  private Room[] Paths { get; set; }

  public Room this[Direction direction] {
    get { return Paths[(int)direction]; }
    set { Paths[(int)direction] = value; }
  }

  public Room(Map map, string name, string prologue = "", string description = "") {
    Name = name;
    Prologue = prologue;
    Description = description;
    Characters = new List<Character>();
    Items = new List<Item>();
    Paths = new Room[8];
    Entered = false;

    if (map != null) {
      map.Rooms.Add(this);
    }
  }

  public virtual bool TryEnter(Player player, Direction direction) {
    player.Room = this;

    if (!Entered) {
      Console.WriteLine(Prologue);
      Entered = true;
    }

    return true;
  }

}

}
