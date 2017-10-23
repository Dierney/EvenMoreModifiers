﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loot.Modifiers;
using Microsoft.Xna.Framework;

namespace Loot.Rarities
{
	public class RareRarity : ModifierRarity
	{
		public override string Name => "Rare";
		public override Color Color => Color.Yellow;
		public override float RequiredStrength => 2f;
	}
}