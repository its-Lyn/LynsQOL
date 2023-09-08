using LynsQOL.Common.Config;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace LynsQOL.Common.UI.ManaDisplay;

public class ManaDisplay : UIState
{
    private UIText mana;

    public override void OnInitialize()
    {
        mana = new UIText("");

        Color textColorWithAlpha = new Color(200, 200, 200, 100);
        mana.TextColor = textColorWithAlpha;

        Append(mana);
        mana.Recalculate();
    }

    public override void Update(GameTime gameTime)
    {
        if (LynQOLConfig.Instance.ManaIndicatorToggle)
        {
            Player tPlayer = Main.LocalPlayer;
            if (tPlayer.statMana < tPlayer.statManaMax2)
            {
                mana.SetText($"{tPlayer.statMana}/{tPlayer.statManaMax2} MP");

                Vector2 tScreenPos = (tPlayer.Top - Vector2.UnitY * 23).ToScreenPosition();
                float manaY = tScreenPos.Y;
                float manaX = tScreenPos.X;

                mana.Top.Set(manaY - mana.MinHeight.Pixels / 2, 0);
                mana.Left.Set(manaX - mana.MinWidth.Pixels / 2, 0);

                mana.Update(gameTime);
            }
            else
            {
                mana.SetText("");
            }
        }

        base.Update(gameTime);
    }
}