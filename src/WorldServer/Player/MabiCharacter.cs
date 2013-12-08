// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see licence.txt in the main folder

using System;
using Aura.Data;
using Aura.Shared.Util;

namespace Aura.World.Player
{
	/// <summary>
	/// Characters, Pets
	/// </summary>
	public class MabiCharacter : MabiPC
	{
		public MabiCharacter()
		{
			this.CreationTime = DateTime.Now;
			this.LevelingEnabled = true;
		}

		public override void CalculateBaseStats()
		{
			base.CalculateBaseStats();

			this.Height = (1.0f / 7.0f * (this.Age - 10.0f));
			if (this.Age > 17)
				this.Height = 1.0f;

			var ageInfo = MabiData.StatsBaseDb.Find(this.Race, this.Age);
			if (ageInfo == null)
			{
				Logger.Warning("Unable to find age info for race '{0}', age '{1}'. Trying default age (17)...", this.Race, this.Age);
				ageInfo = MabiData.StatsBaseDb.Find(this.Race, 17);
				if (ageInfo == null)
				{
					Logger.Warning("Default age info for race '{0}' could not be retreived. Aborting...", this.Race);
					return;
				}
			}

			this.LifeMaxBase = ageInfo.Life;
			this.Life = ageInfo.Life;

			this.ManaMaxBase = ageInfo.Mana;
			this.Mana = ageInfo.Mana;

			this.StaminaMaxBase = ageInfo.Stamina;
			this.Stamina = ageInfo.Stamina;

			this.StrBase = ageInfo.Str;
			this.IntBase = ageInfo.Int;
			this.DexBase = ageInfo.Dex;
			this.WillBase = ageInfo.Will;
			this.LuckBase = ageInfo.Luck;
		}
	}
}
