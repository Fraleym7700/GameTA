
using System;

namespace Game {

abstract class Mob : Character {

  public string Name { get; set; }
  public int Health { get; set; }

  protected Mob(string name, int health) {
    Name = name;
    Health = health;
  }

  public abstract void Attack(Player player);
  public abstract void Kill();

}

class DemonMob : Mob {

  public DemonMob() : base("demon", 1000) {}

  public override void Attack(Player player) {
    Console.WriteLine("Demon Attacks you.");
    player.Health -= 300;
  }

  public override void Kill() {
    Console.WriteLine("The demon shivels up and dissapears into a black smoke, as the smoke disappears and item drop to the ground.");
    new MapToVillageKey().Drop(Room);
  }

}

}
