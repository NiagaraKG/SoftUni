using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;

namespace WarCroft.Entities.Items
{
    public class HealthPotion : Item
    {
        public HealthPotion() : base(5) { }
        public override void AffectCharacter(Characters.Contracts.Character character)
        {
            if (!character.IsAlive) { throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead); }
            character.Health += 20;
        }
    }
}
