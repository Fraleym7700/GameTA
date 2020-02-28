
using System;

namespace Game {

abstract class Potion : Item {

  public Potion(string name) : base(name) {}

}

class HealingPotion : Potion {

  public int HealingAmount { get; private set; }

  public HealingPotion(string name, int amount) : base(name) {
    HealingAmount = amount;
  }

  public override bool Use(Player player) {
    player.Health += HealingAmount;
    player.Items.Remove(this);
    Console.WriteLine($"You healed {HealingAmount} points.\nYou now have {player.Health} life.");
    return true;
  }

}

class AttackingPotion : Potion {

  public int Damage { get; private set; }

  public AttackingPotion(string name, int damage) : base(name) {
    Damage = damage;
  }

  public override bool Use(Player player) {
    player.Items.Remove(this);
    return true;
  }

}

}
