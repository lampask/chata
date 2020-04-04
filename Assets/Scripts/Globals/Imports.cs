using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Acces to all imported resources and objects
/// </summary>
public static class Imports
{
    private enum ConversionType {
        Obj,
        Tile,
        Settings,
    }

    private static string PointConvert(string name, ConversionType type) {
        return string.Format($"{type}/{name}");
    }

    /// LIST OF OBJECTS ///
    public static readonly GameObject PLAYER_OBJ = Resources.Load(PointConvert("Player", ConversionType.Obj)) as GameObject;
    public static readonly TileBase SELECTOR_TILE = Resources.Load(PointConvert("Selector", ConversionType.Tile)) as TileBase;

    // Plants
    public static readonly GameObject DELFI_OBJ = Resources.Load(PointConvert("DELFI", ConversionType.Obj)) as GameObject;
    public static readonly GameObject KARF_OBJ = Resources.Load(PointConvert("Karfiol", ConversionType.Obj)) as GameObject;
    public static readonly GameObject BROKOL_OBJ = Resources.Load(PointConvert("Brokolica", ConversionType.Obj)) as GameObject;
    public static readonly GameObject TEKVICA_OBJ = Resources.Load(PointConvert("TEKVICA", ConversionType.Obj)) as GameObject;

    //Enemies
    public static readonly GameObject DINO_OBJ = Resources.Load(PointConvert("DINO", ConversionType.Obj)) as GameObject;
    public static readonly GameObject TERMIT_OBJ = Resources.Load(PointConvert("TERMIT", ConversionType.Obj)) as GameObject;
}
