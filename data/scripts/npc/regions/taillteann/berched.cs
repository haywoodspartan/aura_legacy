using Common.Constants;
using Common.World;
using System;
using World.Network;
using World.Scripting;
using World.World;

public class BerchedScript : NPCScript
{
	public override void OnLoad()
	{
		SetName("_berched");
		SetRace(10002);
		SetBody(height: 0.9999999f, fat: 1f, upper: 1f, lower: 1.1f);
		SetFace(skin: 20, eye: 0, eyeColor: 27, lip: 0);

		NPC.ColorA = 0x808080;
		NPC.ColorB = 0x808080;
		NPC.ColorC = 0x808080;		

		EquipItem(Pocket.Face, 0x1334, 0xD8CC8, 0x290AC, 0xF65233);
		EquipItem(Pocket.Hair, 0x1004, 0x887B66, 0x887B66, 0x887B66);
		EquipItem(Pocket.Armor, 0x3BE1, 0x808080, 0x808080, 0x808080);
		EquipItem(Pocket.Shoe, 0x42CB, 0x1D1818, 0x686868, 0xD6D6D6);

		SetLocation(region: 300, x: 191470, y: 223608);

		SetDirection(188);
		SetStand("chapter3/human/male/anim/male_c3_npc_berched");
	}
}