﻿using System;
using Loot.Core;
using Microsoft.Xna.Framework;
using Terraria;

namespace Loot.Modifiers.EquipModifiers
{
	public class CritDamagePlus : EquipModifier
	{
		public override ModifierTooltipLine[] TooltipLines => new[]
		{
			new ModifierTooltipLine {Text = $"+{Properties.RoundedPower}% crit multiplier", Color = Color.LimeGreen},
		};

		public override ModifierProperties GetModifierProperties(Item item)
		{
			return base.GetModifierProperties(item).Set(maxMagnitude: 15f);
		}

		public override void UpdateEquip(Item item, Player player)
		{
			ModifierPlayer.Player(player).CritMultiplier += Properties.RoundedPower / 100f;
		}
		
		[AutoDelegation("OnResetEffects")]
		private void ResetEffects(Player player)
		{
			ModifierPlayer.Player(player).CritMultiplier -= Properties.RoundedPower / 100f;
		}

		[AutoDelegation("OnModifyHitNPC")]
		private void CritBonusNPC(Player player, Item item, NPC target, ref int damage, ref float knockBack, ref bool crit)
		{
			CritBonus(player, ref damage, crit);
		}
		
		[AutoDelegation("OnModifyHitPvp")]
		private void CritBonusPvp(Player player, Item item, Player target, ref int damage, ref bool crit)
		{
			CritBonus(player, ref damage, crit);
		}

		private void CritBonus(Player player, ref int damage, bool crit)
		{
			if (crit)
				damage = (int) Math.Ceiling(damage * player.GetModPlayer<ModifierPlayer>().CritMultiplier);
		}
	}
}