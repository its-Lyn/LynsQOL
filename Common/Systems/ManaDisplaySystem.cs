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
    internal ManaDisplay MDisplay;
    private UserInterface _userInterface;

    public override void Load()
    {
        MDisplay = new ManaDisplay();
        MDisplay.Activate();

        _userInterface = new UserInterface();
        _userInterface.SetState(MDisplay);
    }

    public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
    {
        if (LynQOLConfig.Instance.ManaIndicatorToggle)
        {
            int uiTextIdx = layers.FindIndex(l => l.Name == "Vanilla: Resource Bars");
            if (uiTextIdx != -1)
            {
                layers.Insert(uiTextIdx, new LegacyGameInterfaceLayer(
                    "LynsQOL: ManaLayer",
                    delegate
                    {
                        _userInterface.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    }, 
                    InterfaceScaleType.UI
                ));
            }
        }
    }

    public override void UpdateUI(GameTime gameTime)
    {
        _userInterface?.Update(gameTime);
    }
}