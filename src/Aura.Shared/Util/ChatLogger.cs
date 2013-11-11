// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see licence.txt in the main folder

using System;
using System.IO;
using Aura.Shared.Database;

namespace Aura.Shared.Util
{
	public enum ChatType { Chat, Whisper, Party, Guild, Command }

	public static class ChatLogger
	{
		/// <summary>
		/// Logs standard chat messages to the SQL database.
		/// </summary>
		/// <param name="from">Sender</param>
		/// <param name="message">Message</param>
		public static void Chat(string from, string message)
		{
			if (message == null || from == null)
				return;

			MabiDb.Instance.LogChat(ChatType.Chat, from, "", "", message);
		}
		/// <summary>
		/// Logs whisper chat messages to the SQL database.
		/// </summary>
		/// <param name="from">Sender(start)</param>
		/// <param name="to">Receiver</param>
		/// <param name="message">Message</param>
		public static void Whisper(string from, string to, string message)
		{
			if (message == null || from == null || to == null)
				return;

			MabiDb.Instance.LogChat(ChatType.Whisper, from, to, "", message);
		}

		/// <summary>
		/// Logs successful commands to the SQL database
		/// </summary>
		/// <param name="from"></param>
		/// <param name="command"></param>
		/// <param name="message"></param>
		public static void Command(string from, string command, string message)
		{
			if (from == null || command == null || message == null)
				return;

			MabiDb.Instance.LogChat(ChatType.Command, from, "", command, message);
		}
		//public static void Party(string user, string party, string msg)
		//{
		//}

		//public static void Guild(string user, string guild, string msg)
		//{
		//}
	}
}
