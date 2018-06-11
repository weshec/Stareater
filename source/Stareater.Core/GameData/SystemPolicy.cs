﻿using Stareater.Utils.StateEngine;
using System.Collections.Generic;

namespace Stareater.GameData
{
	class SystemPolicy
	{
		[StateProperty]
		public string Id { get; private set; }

		public override bool Equals(object obj)
		{
			var other = obj as SystemPolicy;
			return other != null &&
				   this.Id == other.Id;
		}

		public override int GetHashCode()
		{
			return 2108858624 + EqualityComparer<string>.Default.GetHashCode(this.Id);
		}
	}
}
