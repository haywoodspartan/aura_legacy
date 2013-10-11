// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see licence.txt in the main folder
// Skill by Fuhhue

using Aura.Shared.Const;
using Aura.World.Network;
using Aura.World.World;

namespace Aura.World.Skills
{
    [SkillAttr(SkillConst.Hide)]
	public class HideHandler : StartStopSkillHandler
	{
		public override SkillResults Start(MabiCreature creature, MabiSkill skill)
		{
            creature.Activate(CreatureConditionB.Transparent);

            Send.StatusEffectUpdate(creature);

			return SkillResults.Okay;
		}

		public override SkillResults Stop(MabiCreature creature, MabiSkill skill)
		{
            creature.Deactivate(CreatureConditionB.Transparent);

            Send.StatusEffectUpdate(creature);

			return SkillResults.Okay;
		}
	}
}
