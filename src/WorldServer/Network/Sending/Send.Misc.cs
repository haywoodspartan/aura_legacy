﻿// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see licence.txt in the main folder

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aura.Shared.Network;
using Aura.World.World;
using Aura.Shared.Const;
using Aura.Shared.Util;
using Aura.World.Player;

namespace Aura.World.Network
{
	public static partial class Send
	{
		/// <summary>
		/// Sends positive login response.
		/// </summary>
		/// <param name="client"></param>
		/// <param name="creature"></param>
		public static void LoginResponse(Client client, MabiCreature creature)
		{
			var packet = new MabiPacket(Op.WorldLoginR, Id.World);
			packet.PutByte(true);
			packet.PutLong(creature.Id);
			packet.PutLong(MabiTime.Now.DateTime);
			packet.PutInt(1);
			packet.PutString("");

			client.Send(packet);
		}

		/// <summary>
		/// Character is logged in to a client only region, with one NPC.
		/// Used for Soul Stream, with Nao ([...]FFF) or Tin ([...]FFE).
		/// </summary>
		/// <param name="client"></param>
		/// <param name="character"></param>
		public static void SpecialLogin(Client client, MabiPC character, uint region, uint x, uint y, ulong npcId)
		{
			var packet = new MabiPacket(Op.SpecialLogin, Id.World);
			packet.PutByte(true);
			packet.PutInt(region);
			packet.PutInt(x);
			packet.PutInt(y);
			packet.PutLong(npcId);
			packet.AddCreatureInfo(character, CreaturePacketType.Private);

			client.Send(packet);
		}

		/// <summary>
		/// Sends disconnect info response.
		/// </summary>
		/// <param name="client"></param>
		public static void DisconnectResponse(Client client)
		{
			var packet = new MabiPacket(Op.WorldDisconnectR, Id.World);
			packet.PutByte(0);

			client.Send(packet);
		}

		/// <summary>
		/// Broadcasts Effect packet in range. Parameters can be added,
		/// but you have to watch the types.
		/// </summary>
		public static void Effect(uint effect, MabiEntity source, params object[] args)
		{
			var packet = new MabiPacket(Op.Effect, source.Id);
			packet.PutInt(effect);
			foreach (var arg in args)
			{
				if (!(arg is bool))
					packet.Put(arg);
				else
					packet.PutByte((bool)arg);
			}

			WorldManager.Instance.Broadcast(packet, SendTargets.Range, source);
		}

		/// <summary>
		/// Broadcasts Effect packet in range. Parameters can be added,
		/// but you have to watch the types.
		/// </summary>
		/// <param name="delay">Delay in milliseconds</param>
		public static void EffectDelayed(uint effect, uint delay, MabiEntity source, params object[] args)
		{
			var packet = new MabiPacket(Op.EffectDelayed, source.Id);
			packet.PutInt(delay);
			packet.PutInt(effect);
			foreach (var arg in args)
			{
				if (!(arg is bool))
					packet.Put(arg);
				else
					packet.PutByte((bool)arg);
			}

			WorldManager.Instance.Broadcast(packet, SendTargets.Range, source);
		}
	}
}
