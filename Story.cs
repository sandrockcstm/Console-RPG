using System;
using System.Collections;
using BattleSpace;
using Bestiary;
using PlayerStats;

namespace StorySpace
{
    class Story
    {
        private string playerName;
        
        public void NextLine(string text)
        {
            Console.Write(text);
            Console.ReadLine();
        }
        public bool Act1(string playerName)
        {
            this.playerName = playerName;
            NextLine("You awake in a dark corridor... how did you get here?");
            NextLine("It smells like darkness in here.  Nothing but mold and mildew and... is that rotten flesh you smell?");
            NextLine("You try not to think about it.");
            Console.WriteLine("You should try to find your way out of here.  Who knows if anyone will ever find you, or why you were brought here in the first place.  You can CALL for help, SEARCH the area for supplies, EXPLORE the room, or WAIT.");
            string c = "Default";
            Combat combat = new Combat();
            bool torch = false;
            bool flint = false;
            int waitTimer = 0;
            bool i = true;
            Slime slime = new Slime();
            slime.makeSlime();
            
            while(i)
            {
                c = Console.ReadLine();
                c = c.ToUpper();
                switch(c)
                {
                    case "INVENTORY":
                        if(torch && flint)
                        {
                            Console.WriteLine("You are carrying an unlit torch, and a flint with which to light it...");
                            break;
                        }
                        else if(torch)
                        {
                            Console.WriteLine("You are carrying an unlit torch.");
                            break;
                        }
                        else if (flint)
                        {
                            Console.WriteLine("You found a piece of flint, which could light something for you.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Your pockets are empty.");
                            break;
                        }
                        
                    case "CALL":
                        Console.WriteLine("You let out a boisterous call, which echoes through the room. Your ears ring with your own call. You wait a minute or two but hear no response.");
                        break;
                    case "SEARCH":
                        Console.WriteLine("You move around on your hands and knees, looking for something to help you.  You find a TORCH.  If you can figure out how to light it, you might be able to see a way out.");
                            torch = true;
                            break;
                    case "EXPLORE":
                        Console.WriteLine("You search along the walls of the room for something, anything, to aid you.  You find the DOOR, but it will neither budge nor open.  You search around on the floor and find some FLINT.  If you can find a TORCH, you may be able to see more detail in the room and find a way out.");
                            flint = true;
                            break;
                    case "WAIT":
                        
                        if(waitTimer >= 2)
                        {
                            Console.Clear();
                            Console.WriteLine("Something drips on you from the ceiling!");
                            if(combat.runCombat(playerName, slime.Name, slime.Hp, slime.Atk, slime.Def))
                            {
                                Console.Clear();
                                Console.WriteLine("The Slime is gone.  Probably best to get out of here quick.");
                                break;
                            }
                            else
                            {
                                return false;
                                //break;
                            }
                        }
                        else if(waitTimer < 3)
                        {
                            Console.WriteLine("You wait for a long time, but nothing happens.");
                            waitTimer++;
                        }
                        else
                        {
                            throw new Exception("waitTimer value invalid");
                            /*break;
                            waitTimer += waitTimer;*/
                        }
                        break;
                    case "TORCH":
                        {
                            if (flint)
                            {
                                Console.WriteLine("You manage to light a flame to illuminate the room.  To call it a dungeon would be generous.  It's a small room with stone walls and an uneven stone floor.  More of a cave-closet if anything.  You see an uneven section of the wall and realize that there is a hidden SWITCH built into the wall.  Perhaps you should push it?");
                                break;
                            }
                            else if (torch)
                            {
                                Console.WriteLine("Without some way to light this it's just a useless stick.");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("I don't understand what you're saying.  Your options are CALL, SEARCH, EXPLORE, or WAIT.");
                                break;
                            }
                        }
                        case "SWITCH":
                        {
                            if(flint && torch)
                            {
                                Console.WriteLine("You push the hidden switch, the door opens!");
                                return true;
                            }
                            else
                            {
                                Console.WriteLine("I don't understand what you're saying.  Your options are CALL, SEARCH, EXPLORE, OR WAIT.");
                                break;
                            }
                        }
                    
                    default:
                        {
                            Console.WriteLine("I don't understand what you're saying.  Your options are CALL, SEARCH, EXPLORE, or WAIT.");
                            break;
                        }
                    }
                }
            return true;
           
        }
    }
}