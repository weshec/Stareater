﻿using System;

namespace Stareater.Galaxy
{
	public class BodyTraitType
	{
		public string NameCode { get; private set; }
		public string DescriptionCode{ get; private set; }
		
		public string ImagePath { get; private set; }
		public string IdCode { get; private set; }

		internal ITraitEffect Effect { get; private set; }

		internal BodyTraitType(string nameCode, string descriptionCode, string imagePath, string idCode, ITraitEffect effect)
		{
			this.NameCode = nameCode;
			this.DescriptionCode = descriptionCode;
			this.ImagePath = imagePath;
			this.IdCode = idCode;
			this.Effect = effect;
		}

		internal BodyTrait Instantiate(StarData location)
		{
			return new BodyTrait(this, location);
		}

		internal BodyTrait Instantiate(Planet location)
		{
			return new BodyTrait(this, location);
		}
	}
}
