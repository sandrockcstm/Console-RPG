using System;
using System.Collections;
using BattleSpace;
using PlayerStats;
using StorySpace;


  static class Program
  {
    
    static void Main(string[] args)
    {
      Player p = new Player();
      Console.WriteLine("What is your name?");
      p.PlayerName = Console.ReadLine(); //Sets the player character's name
      Story s = new Story(); //Instantiates the story class so that it can //be called.
      if(s.Act1(p.PlayerName))
      {
          Console.WriteLine("You are victorious!");
      }
      else
      {
          Console.WriteLine("Game Over!");
      }
    }
    
  }