using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JMMAndroid.ImageManagement
{
	public class QueueUpdateEventArgs
	{
		public readonly int queueCount;

		public QueueUpdateEventArgs(int queueCount)
		{
			this.queueCount = queueCount;
		}
	}
}
