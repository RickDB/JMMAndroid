using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JMMAndroid.Events
{
	public class GotCharacterCreatorImagesEventArgs : EventArgs
	{
		public readonly int AnimeID = 0;

		public GotCharacterCreatorImagesEventArgs(int animeID)
		{
			this.AnimeID = animeID;
		}
	}
}
