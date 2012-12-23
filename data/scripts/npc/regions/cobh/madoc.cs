using Common.Constants;
using Common.World;
using System;
using World.Network;
using World.Scripting;
using World.World;

public class MadocScript : NPCScript
{
	public override void OnLoad()
	{
		SetName("_madoc");
		SetRace(10002);
		SetBody(height: 1.1f, fat: 1.5f, upper: 1f, lower: 1.5f);
		SetFace(skin: 18, eye: 14, eyeColor: 0, lip: 16);

		NPC.ColorA = 0x808080;
		NPC.ColorB = 0x808080;
		NPC.ColorC = 0x808080;		

		EquipItem(Pocket.Face, 0x1324, 0xFA9D50, 0x4B6570, 0xF78E8B);
		EquipItem(Pocket.Hair, 0x1027, 0xC8A81A, 0xC8A81A, 0xC8A81A);
		EquipItem(Pocket.Armor, 0x3C15, 0x4E89, 0x646E8F, 0x3F5786);
		EquipItem(Pocket.Shoe, 0x4303, 0x3366, 0xE285B, 0x202020);
		EquipItem(Pocket.Head, 0x479A, 0x3497C, 0x888C00, 0x53003E);

		SetLocation(region: 23, x: 26960, y: 37796);

		SetDirection(193);
		SetStand("");
	}
}