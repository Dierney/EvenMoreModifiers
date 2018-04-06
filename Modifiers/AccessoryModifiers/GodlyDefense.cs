﻿using Loot.System;
using Microsoft.Xna.Framework;
using Terraria;

namespace Loot.Modifiers.AccessoryModifiers
{
	public class GodlyDefense : AccessoryModifier
	{
		public override ModifierTooltipLine[] Description => new[]
		{
			new ModifierTooltipLine { Text = "Player has godly defense", Color =  Color.SlateGray},
		};

		public override ModifierProperties GetModifierProperties(Item item)
		{
			return base.GetModifierProperties(item).Set(rarityLevel: 5f);
		}

		public override void UpdateAccessory(Item item, Player player, bool hideVisual)
		{
			player.statDefense = 9999;
		}
	}
}