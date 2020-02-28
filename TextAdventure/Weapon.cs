
using System;

namespace Game {

class Weapon : Item {

  public int Attack { get; set; }

  public Weapon(string name, int attack) : base(name) {
    Attack = attack;
  }

  public override void Drop(Room room) {
    if (Player != null && Player.Weapon == this) {
      Player.Weapon = null;
    }

    base.Drop(room);
  }

  public override void Take(Player player) {
    base.Take(player);

    if (player.Weapon != null) {
      player.Weapon.Drop(player.Room);
    }

    player.Weapon = this;
  }

  public override bool Use(Player player) {
    return true;
  }

}

class IntroSword : Weapon {

  private bool Taken { get; set; }

  public IntroSword() : base("sword", 200) {
    Taken = false;
  }

  public override void Take(Player player) {
    base.Take(player);

    if (!Taken) {
      Console.WriteLine("A snake crawl from under a rock and bites you ankle. -50 HP. and crawls away. type Status to check your health.");
      player.Health -= 50;
      Console.WriteLine("As you look up you see a figure of a man with a devilish face. He is staring at you with a grim look. He says Im going to eat your soul and lunges at you");
      new DemonMob().Room = player.Room;
      player.Battling = true;
      Taken = true;
    }
  }

}

}
