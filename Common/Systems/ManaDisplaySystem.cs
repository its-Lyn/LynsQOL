using System.Collections.Generic;
using LynsQOL.Common.Config;
using LynsQOL.Common.UI.ManaDisplay;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace LynsQOL.Common.Systems;

public class ManaDisplaySystem : ModSystem
{
    internal ManaDisplay mDisplay;
    private UserInterface userInterface;

    public override void Load()
    {
        mDisplay = new ManaDisplay();
        mDisplay.Activate();

        userInterface = new UserInterface();
        userInterface.SetState(mDisplay);
    }

    public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
    {
        if (LynQOLConfig.Instance.ManaIndicatorToggle)
        {
            int UiTextIdx = layers.FindIndex(l => l.Name.Equals("Vanilla: Resource Bars"));
            if (UiTextIdx != -1)
            {
                layers.Insert(UiTextIdx, new LegacyGameInterfaceLayer(
                    "LynsQOL: ManaLayer",
                    delegate
                    {
                        userInterface.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI
                ));
            }
        }
    }

    public override void UpdateUI(GameTime gameTime)
    {
        userInterface?.Update(gameTime);
    }
}