﻿using System.Linq;

namespace Loot.Core
{
	public sealed class AllModifiersPool : ModifierPool
	{
		public override float RollChance => 0f;

		public AllModifiersPool()
		{
			Modifiers = EMMLoader.Modifiers.Select(x => x.Value).ToArray();
		}

		public override bool CanRoll(ModifierContext ctx)
		{
			return IsValidFor(ctx.Item);
		}
	}
}
