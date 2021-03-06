using Loot.Core.Cubes;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.UI;

namespace Loot.UI
{
	public class UICubeItemPanel : UIInteractableItemPanel
	{
		public UICubeItemPanel(int netID = 0, int stack = 0, Texture2D hintTexture = null, string hintText = null) :
			base(netID, stack, hintTexture, hintText)
		{
			this.RightClickFunctionalityEnabled = false;
			this.TakeUserItemOnClick = false;
			this.HintOnHover = " (click to unslot)";
		}

		public override bool CanTakeItem(Item item) => item.modItem is MagicalCube;

		public override void PostOnClick(UIMouseEvent evt, UIElement e)
		{
			if (!this.item.IsAir)
			{
				RecalculateStack();
			}
		}

		internal void RecalculateStack()
		{
			// @todo track cube tier as well
			// after cube is slotted, count total number

			int stack = 0;

			foreach (Item item in Main.LocalPlayer.inventory)
			{
				if (item.type == this.item.type)
					stack += item.stack;
			}

			if (stack > 999)
				stack = 999;

			this.item.stack = stack;
		}
	}
}