using System.ComponentModel;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace LynsQOL.Common.Config;

public class LynQOLConfig : ModConfig
{
    public static LynQOLConfig Instance => ModContent.GetInstance<LynQOLConfig>();

    public override ConfigScope Mode => ConfigScope.ClientSide;

    [Header("UIElements")]
    [DefaultValue(true)]
    public bool ManaIndicatorToggle;
}