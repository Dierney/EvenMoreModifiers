﻿using System;
using Loot.System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader.IO;

namespace Loot.Modifiers.WeaponModifiers
{
	public class DamagePlusDaytime : WeaponModifier
	{
		public override ModifierTooltipLine[] Description => new[]
			{
				new ModifierTooltipLine { Text = $"+{Properties.RoundedPower}% damage during the {(_duringDay ? "day" : "night")}", Color = Color.Lime}
			};

		public override ModifierProperties GetModifierProperties(Item item)
		{
			return base.GetModifierProperties(item).Set(maxMagnitude: 15f, rollChance: 2f);
		}

		private bool _duringDay;

		public override void Apply(Item item)
		{
			base.Apply(item);
			_duringDay = Main.rand.NextBool();
		}

		// Here we showcase custom loading and saving for a modifier

		public override void Load(TagCompound tag)
		{
			base.Load(tag);
			_duringDay = tag.GetBool("duringDay");
		}

		public override void Save(TagCompound tag)
		{
			base.Save(tag);
			tag.Add("duringDay", _duringDay);
		}

		public override void GetWeaponDamage(Item item, Player player, ref int damage)
		{
			base.GetWeaponDamage(item, player, ref damage);
			if (_duringDay && Main.dayTime || !_duringDay && !Main.dayTime)
				damage = (int)Math.Ceiling(damage * (1 + Properties.RoundedPower / 100));
		}
	}
}