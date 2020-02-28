
using System;

namespace Game {

abstract class Character {

  private Room _Room;

  public Room Room {
    get { return _Room; }
    set {
      if (_Room != null) {
        _Room.Characters.Remove(this);
      }

      _Room = value;

      if (_Room != null) {
        _Room.Characters.Add(this);
      }
    }
  }

}

}
