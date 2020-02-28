
using System;

namespace Game {

abstract class Item {

  public string Name { get; private set; }
  public Player Player { get; set; }
  public Room Room { get; private set; }

  public Item(string name) {
    Name = name;
  }

  public virtual void Drop(Room room) {
    if (Room != room) {
      if (Room != null) {
        Room.Items.Remove(this);
      }

      Room = room;

      if (Room != null) {
        Room.Items.Add(this);
      }
    }

    if (Player != null) {
      Player.Items.Remove(this);
      Player = null;
    }
  }

  public virtual void Take(Player player) {
    if (!player.Items.Contains(this)) {
      Drop(null);
      player.Items.Add(this);
    }
  }

  public abstract bool Use(Player player);

}

class MapToVillageKey : Item {

  private bool Taken { get; set; }

  public MapToVillageKey() : base("map") {}

  public override void Take(Player player) {
    base.Take(player);

    if (!Taken) {
      Console.WriteLine("The maps appears to be in a completely different language, but is appears to be of your surroundings. You looks futher and can make out where you are. There seems to be a waterfall up ahead through the cave that has an X on it.");
      Taken = true;
    }
  }

  public override bool Use(Player player) {
    return true;
  }

}

}
