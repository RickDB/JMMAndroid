﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JMMAndroid.Events
{
	public class GotAnimeEventArgs : EventArgs
	{
		public readonly int AnimeID = 0;

		public GotAnimeEventArgs(int animeID)
		{
			this.AnimeID = animeID;
		}
	}
}
