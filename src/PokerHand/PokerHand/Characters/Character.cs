using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHand.Characters
{
    public abstract class Character
    {
        public string Name { get; set; }
        public Character(string name)
        {
            Name = name;
        }
    }
}
