﻿using System;
using System.Collections.Generic;
using System.Data.Services.Common;
using System.Linq;

namespace AppMetrics.DataModel
{
	[DataServiceKey("Time")]
	public class Record
	{
		public string SessionId { get; set; }

		public DateTime Time { get; set; }
		public string Name { get; set; }
		public string Value { get; set; }

		public override string ToString()
		{
			var res = string.Format("{0} {1} {2}", Time, Name, Value);
			return res;
		}
	}
}