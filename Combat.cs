using System;
using System.Collections;
using Bestiary;
using PlayerStats;

//Battle system is contained in this namespace.
namespace BattleSpace
{
    class Combat
    {
      public string playerName;
      public double playerHp;
      public double playerAtk;
      public double playerDef;
      public string monsterName;
      public double monsterHp;
      public double monsterAtk;
      public double monsterDef;
      public double dmgDealt;
      //public int miss;
      //public int def;
      
      public double dmgReduct (double atk, double def, string attacker)
      {
          int miss;
          
          if(def > 50)
          {
              miss = (int)def - 50;
              def = 50;
          }
          else
          {
              def = def;
              miss = 0;
          }
          //Console.WriteLine("def is " + def);
          def = def / 100;
          //Console.WriteLine("def is " + def);
          def = 1 - def;
          //Console.WriteLine("atk is " + atk + " def is " + def);
          double workingDmg = atk * def;
          workingDmg = Math.Ceiling(workingDmg);
          //Console.WriteLine("workingDmg after Math.Ceiling is " + workingDmg);
          Random rnd = new Random();
          int seed = rnd.Next(1, 100);
          //Console.WriteLine("Seed is " + seed);
          
          if(seed <= miss)
          {
              Console.WriteLine("Miss!");
              return 0;
          }
          else
          {
                //Console.WriteLine("workingDmg is " + workingDmg);
                Console.WriteLine(attacker + " deals " + workingDmg + " damage!");
                return workingDmg;
          }
          
      }
      public bool runCombat (string playerName, string monsterName, double monsterHp, double monsterAtk, double monsterDef) //Begins combat.
      {
        Player p = new Player();
        this.playerName = playerName;
        playerDef = p.PlayerDef;
        playerHp = p.PlayerHp;
        playerAtk = p.PlayerAtk;
        
        Console.WriteLine("You encountered a " + monsterName + "!");
        //Console.WriteLine("monsterDef is " + monsterDef);
        while(playerHp > 0 && monsterHp > 0)
        {
            Console.WriteLine(playerName + " has " + playerHp + " HP");
            Console.WriteLine(monsterName + " has " + monsterHp + " HP");
            Console.WriteLine("What will you do?  ATTACK or RUN?");
        
            string c = Console.ReadLine();
            c = c.ToUpper();
            switch(c)
            {
                case "ATTACK": 
                    dmgDealt = dmgReduct(playerAtk, monsterDef, playerName);
                    monsterHp -= dmgDealt;
                    this.dmgDealt = dmgReduct(monsterAtk, playerDef, monsterName);
                    playerHp -= dmgDealt;
                    break;
                
                case "RUN":
                    playerHp -= monsterAtk;
                    Console.WriteLine(monsterName + " does " + monsterAtk + " damage!  There's no escape!");
                    break;
                default:
                    Console.WriteLine("Not a valid entry");
                    break;
                
            }
        }
        
        if (playerHp > 0)
        {
            return true;
        }
        else if (playerHp <= 0)
        {
            return false;
        }
        else
        {
            throw new System.Exception("Value of playerStats is not valid");
        }
        
        
      }
    }
}