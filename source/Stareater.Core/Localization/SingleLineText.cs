﻿using Ikadn;
using System;

namespace Stareater.Localization
{
	class SingleLineText : IkadnBaseObject, IText
	{
		private string text;

		internal SingleLineText(string line)
		{
			this.text = line;
		}

		protected override void DoCompose(IkadnWriter writer)
		{
			throw new InvalidOperationException(Tag + " is not meant to be serialized.");
		}

		public override object Tag
		{
			get { return "Localization.SingleLineText"; }
		}

		public override T To<T>()
		{
			Type target = typeof(T);

			if (target.IsAssignableFrom(this.GetType()))
				return (T)(object)this;
			else
				throw new InvalidOperationException("Cast to " + target.Name + " is not supported for " + Tag);
		}


		public System.Collections.Generic.IEnumerable<string> VariableNames()
		{
			return new string[] { };
		}

		public string Text()
		{
			return text;
		}

		public string Text(double trivialVariable)
		{
			return text;
		}

		public string Text(System.Collections.Generic.IDictionary<string, double> variables)
		{
			return text;
		}
	}
}
