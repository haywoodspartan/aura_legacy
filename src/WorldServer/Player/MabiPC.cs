﻿// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see licence.txt in the main folder

using System;
using System.Collections.Generic;
using System.Linq;
using Aura.Data;
using Aura.Shared.Network;
using Aura.Shared.Util;
using Aura.Shared.Const;
using Aura.World.Events;
using Aura.World.World;
using Aura.World.Network;

namespace Aura.World.Player
{
	public class MabiPC : MabiCreature
	{
		public string Server;

		public ushort RebirthCount;
		public string SpouseName;
		public ulong SpouseId;
		public uint MarriageTime;
		public ushort MarriageCount;

		public DateTime CreationTime = DateTime.Now;
		public DateTime LastRebirth = DateTime.Now;
		public DateTime LoginTime = DateTime.Now;

		private TimeSpan _timePlayed;	//Total time played on the account

		public bool Save = false;

		public List<ushort> Keywords = new List<ushort>();
		public Dictionary<ushort, bool> Titles = new Dictionary<ushort, bool>();
		public List<ShamalaTransformation> Shamalas = new List<ShamalaTransformation>();

		public Dictionary<uint, MabiQuest> Quests = new Dictionary<uint, MabiQuest>();

		public override EntityType EntityType
		{
			get { return EntityType.Character; }
		}

		public override float CombatPower
		{
			get
			{
				float result = 0;

				result += this.LifeMaxBase;
				result += this.ManaMaxBase * 0.5f;
				result += this.StaminaMaxBase * 0.5f;
				result += this.StrBase;
				result += this.IntBase * 0.2f;
				result += this.DexBase * 0.1f;
				result += this.WillBase * 0.5f;
				result += this.LuckBase * 0.1f;

				return result;
			}
		}

		public override bool IsAttackableBy(MabiCreature other)
		{
			if (other is MabiNPC)
				return (other.State & CreatureStates.GoodNpc) == 0;
			else
			{
				var res = false;

				if (this.EvGEnabled && other.EvGEnabled)
					if (this.EvGSupportRace != 0 && other.EvGSupportRace != 0 && other.EvGSupportRace != this.EvGSupportRace)
						res = true;

				if (this.ArenaPvPManager != null && this.ArenaPvPManager == other.ArenaPvPManager)
					if (this.ArenaPvPManager.IsAttackableBy(this, other))
						res = true;

				return res; // For now... add more PvP later and other stuff
			}
		}

		public void GiveTitle(ushort title, bool usable = false)
		{
			if (this.Titles.ContainsKey(title))
				this.Titles[title] = usable;
			else
				this.Titles.Add(title, usable);

			if (usable)
			{
				this.Client.Send(new MabiPacket(Op.AddTitle, this.Id).PutShort(title).PutInt(0));
			}
			else
			{
				this.Client.Send(new MabiPacket(Op.AddTitleKnowledge, this.Id).PutShort(title).PutInt(0));
			}
		}

		public MabiQuest GetQuestOrNull(uint cls)
		{
			MabiQuest result = null;
			this.Quests.TryGetValue(cls, out result);
			return result;
		}

		public MabiQuest GetQuestOrNull(ulong id)
		{
			return this.Quests.Values.FirstOrDefault(a => a.Id == id);
		}

		public void GiveKeyword(ushort keywordId)
		{
			this.Keywords.Add(keywordId);
			Send.NewKeyword((this.Client as WorldClient), keywordId);
		}

		/// <summary>
		/// Returns the total time played on the character
		/// </summary>
		/// <returns></returns>
		public TimeSpan GetTimePlayed()
		{
			_timePlayed = _timePlayed.Add(DateTime.Now - LoginTime); //Recalculate...
			return _timePlayed;
		}

		/// <summary>
		/// Converts the amount of Time played in seconds to a TimeSpan
		/// </summary>
		/// <param name="secondsPlayed">Total seconds played on the character</param>
		public void SetTimePlayed(double secondsPlayed)
		{
			_timePlayed = TimeSpan.FromSeconds(secondsPlayed);
		}
	}
}
