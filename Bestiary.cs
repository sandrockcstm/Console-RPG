using System;
using System.Collections;

namespace Bestiary
{
    
    public class Monster
    {
        public string Name { get; set; } 
        public double Hp { get; set; }
        public double Atk { get; set; }
        public double Def { get; set; }
        
        public Monster()
        {
            Name = "Default";
            Hp = 0;
            Atk = 0;
            Def = 0;
            
        }
    }
        
    public class Slime : Monster
    {
        public void makeSlime()
        {
            Name = "Slime";
            Hp = 15;
            Atk = 1;
            Def = 10;
        }
        
    }
            
    public class Revenant : Monster
    {
        public void makeRevenant()
        {
            Name = "Revenant";
            Hp = 15;
            Atk = 10;
            Def = 20;
        }
    }
}