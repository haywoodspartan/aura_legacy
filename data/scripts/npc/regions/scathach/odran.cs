using Aura.Shared.Const;
using System;
using Aura.World.Network;
using Aura.World.Scripting;
using Aura.World.World;

public class OdranScript : NPCScript
{
	public override void OnLoad()
	{
		base.OnLoad();
		SetName("_odran");
		SetRace(10002);
		SetBody(height: 1.2f, fat: 1f, upper: 1.2f, lower: 1f);
		SetFace(skin: 17, eye: 9, eyeColor: 176, lip: 0);

		SetColor(0x808080, 0x808080, 0x808080);

		EquipItem(Pocket.Face, 0x1344, 0xF99F45, 0xFFF10B, 0x437628);
		EquipItem(Pocket.Hair, 0x1033, 0x412B26, 0x412B26, 0x412B26);
		EquipItem(Pocket.Armor, 0x3E2E, 0xA69D8B, 0x2B2626, 0x6E724E);
		EquipItem(Pocket.RightHand2, 0x9E22, 0x808080, 0x959595, 0x3C4155);

		SetLocation(region: 4014, x: 34024, y: 42860);

		SetDirection(54);
		SetStand("elf/male/anim/elf_npc_hagel_stand_friendly");

		Phrases.Add("...");
		Phrases.Add("Damn it.");
		Phrases.Add("Damn.");
		Phrases.Add("Shut up.");
		Phrases.Add("Time to send a patrol out.");
	}
}
