
using System;
using System.Collections.Generic;

namespace Game {

class Player : Character {

  public int Health { get; set; }
  public Weapon Weapon { get; set; }
  public List<Item> Items { get; set; }
  public bool Battling { get; set; }

  public Player() {
    Health = 2000;
    Items = new List<Item>();
  }

}

}
