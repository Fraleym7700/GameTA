
using System;
using System.Collections.Generic;
using System.Linq;

namespace Game {

class Menu {

  public delegate void ChoiceAction(string command, string[] arguments);

  public Dictionary<string, ChoiceAction> Choices { get; set; }

  public Menu() {
    Choices = new Dictionary<string, ChoiceAction>();
  }

  public void Process() {
    for (;;) {
      string[] input = Console.ReadLine().ToLowerInvariant().Split(' ');

      if (input.Length == 0) {
        continue;
      }

      ChoiceAction action;
      string command = input[0];

      if (!Choices.TryGetValue(command, out action)) {
        continue;
      }

      action(command, input.Skip(1).ToArray());
    }
  }

}

}
