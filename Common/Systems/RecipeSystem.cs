using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LynsQOL.Common.Systems;

public class RecipeSystem : ModSystem
{
    public override void AddRecipes()
    {
        // I hate vile mushrooms
        // Seriously c'mon
        Recipe.Create(ItemID.VileMushroom)
            .AddIngredient(ItemID.Mushroom, 1)
            .AddIngredient(ItemID.RottenChunk, 1)
            .AddTile(TileID.DemonAltar)
            .Register();
        
        // I forgot about you...
        // Why was this biome even created?
        Recipe.Create(ItemID.ViciousMushroom)
            .AddIngredient(ItemID.Mushroom, 1)
            .AddIngredient(ItemID.Vertebrae, 1)
            .AddTile(TileID.DemonAltar)
            .Register();
        
        // Bad biome lmao
        Recipe.Create(ItemID.Leather)
            .AddIngredient(ItemID.Vertebrae, 5)
            .AddTile(TileID.Loom)
            .Register();
        
        Recipe.Create(ItemID.TatteredCloth, 2)
            .AddIngredient(ItemID.Leather, 1)
            .AddTile(TileID.Loom)
            .Register();
    }
}