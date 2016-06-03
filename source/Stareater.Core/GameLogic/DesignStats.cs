﻿using System.Collections.Generic;
using Stareater.GameData.Ships;
using Stareater.Utils;

namespace Stareater.GameLogic 
{
	class DesignStats 
	{
		public double GalaxySpeed;
		public double GalaxyPower;
		public double CombatSpeed;
		public double CombatPower;
		public List<AbilityStats> Abilities;
		public double ColonizerPopulation;
		public Dictionary<string, double> ColonizerBuildings;
		public double HitPoints;
		public double ShieldPoints;
		public double Evasion;
		public double ArmorReduction;
		public double ShieldReduction;
		public double ShieldRegeneration;
		public double ShieldThickness;

		public DesignStats(double galaxySpeed, double galaxyPower, double combatSpeed, double combatPower, List<AbilityStats> abilities, double colonizerPopulation, Dictionary<string, double> colonizerBuildings, double hitPoints, double shieldPoints, double evasion, double armorReduction, double shieldReduction, double shieldRegeneration, double shieldThickness) 
		{
			this.GalaxySpeed = galaxySpeed;
			this.GalaxyPower = galaxyPower;
			this.CombatSpeed = combatSpeed;
			this.CombatPower = combatPower;
			this.Abilities = abilities;
			this.ColonizerPopulation = colonizerPopulation;
			this.ColonizerBuildings = colonizerBuildings;
			this.HitPoints = hitPoints;
			this.ShieldPoints = shieldPoints;
			this.Evasion = evasion;
			this.ArmorReduction = armorReduction;
			this.ShieldReduction = shieldReduction;
			this.ShieldRegeneration = shieldRegeneration;
			this.ShieldThickness = shieldThickness;
		}
	}
}
