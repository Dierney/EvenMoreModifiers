﻿using Loot.System;
using Microsoft.Xna.Framework;
using Terraria;

namespace Loot.Modifiers.AccessoryModifiers
{
	public class GodlyDefense : AccessoryModifier
	{
		public override ModifierEffectTooltipLine[] Description => new[]
		{
			new ModifierEffectTooltipLine { Text = "Player has godly defense", Color =  Color.SlateGray},
		};

		public override float RarityLevel => 5f;

		public override void UpdateAccessory(Item item, Player player, bool hideVisual)
		{
			player.statDefense = 9999;
		}
	}
}
