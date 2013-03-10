﻿// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see licence.txt in the main folder

namespace Aura.Shared.Const
{
	public static class ExpTable
	{
		private static uint[] _list = new uint[]
		{
			/*   1 -  20 */  100,      500,      900,      1300,     1700,     2000,     2300,     2600,     3000,     3400,     3800,     4400,     5000,     6000,     7000,     8000,     9500,     11000,    12500,    14500,    
			/*  21 -  40 */  16500,    19200,    22100,    25400,    29000,    33000,    37300,    42100,    47200,    52800,    58800,    65300,    72300,    79800,    87900,    96400,    105500,   115200,   125500,   136400,   
			/*  41 -  60 */  147700,   154400,   161300,   168500,   176000,   183600,   191600,   199800,   208300,   217000,   226000,   235400,   245000,   254900,   265100,   275600,   286500,   297700,   309200,   321000,   
			/*  61 -  80 */  333200,   345700,   358600,   371800,   385500,   399400,   413800,   428500,   443700,   459200,   475100,   491500,   508200,   525400,   543000,   561000,   579500,   598400,   617800,   637600,   
			/*  81 - 100 */  657900,   678600,   699900,   721600,   743800,   766400,   789600,   813300,   837500,   862200,   887400,   913200,   939500,   966300,   993700,   1021600,  1050100,  1079200,  1108800,  1139000,  
			/* 101 - 120 */  1169800,  1201200,  1233100,  1265700,  1298900,  1332600,  1367000,  1402100,  1437700,  1474000,  1510900,  1548500,  1586700,  1625600,  1665200,  1705400,  1746300,  1787900,  1830200,  1873200,  
			/* 121 - 140 */  1916900,  1961300,  2006400,  2052200,  2098800,  2146000,  2194100,  2242800,  2292300,  2342600,  2393600,  2445400,  2498000,  2551400,  2605500,  2660400,  2716200,  2772700,  2830000,  2888200,  
			/* 141 - 160 */  2947200,  3007000,  3067600,  3129100,  3191500,  3254600,  3318700,  3383600,  3449400,  3516000,  3583500,  3652000,  3721300,  3791500,  3862600,  3934600,  4007600,  4081500,  4156300,  4232000,  
			/* 161 - 180 */  4308700,  4386300,  4464900,  4544400,  4625000,  4706400,  4788900,  4872300,  4956800,  5042200,  5128600,  5216100,  5304500,  5394000,  5484500,  5576000,  5668600,  5762200,  5856900,  5952600,  
			/* 181 - 200 */  6049400,  6147200,  6246200,  6346200,  6447300,  6549400,  6652700,  6757100,  6862600,  6969200,  7076900,  7185800,  7295800,  7406900,  7519200,  7632600,  7747200,  7863000,  7979900,  8098000
		};

		public static uint GetTotalForNextLevel(uint currentLv)
		{
			uint result = 0;

			if (currentLv >= _list.Length)
				currentLv = (uint)_list.Length;

			for (int i = 0; i < currentLv; ++i)
			{
				result += _list[i];
			}

			return result;
		}

		public static uint GetForLevel(uint currentLv)
		{
			if (currentLv < 1)
				return 0;
			if (currentLv > GetMaxLevel())
				currentLv = (uint)_list.Length;

			return _list[currentLv - 1];
		}

		public static ulong CalculateRemaining(uint currentLv, ulong totalExp)
		{
			return GetForLevel(currentLv) - (GetTotalForNextLevel(currentLv) - totalExp) + GetForLevel(currentLv - 1);
		}

		public static ushort GetMaxLevel()
		{
			return (ushort)_list.Length;
		}
	}
}