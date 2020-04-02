using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

/// <summary>
/// Main class containing game data
/// </summary>

public static class Game
{
    public enum EntityType {
        PLAYER,
        PLANT,
        ENEMY,
        ENVIROMENT,
        UNMODIFIABLE
    }
    
    public static UnityEvent game_over_event;
    public static GameObject tilemap_object;
    public static GameObject selector_tilemap_object;
    public static Dictionary<Material, Material> tiles = new Dictionary<Material, Material>();
    public static Dictionary<int, Dictionary<int, Dictionary<int, WorldObject>>> map;
    public static List<Vector3Int> restricted_blocks;
    public static List<IEntity> entities;
    public static InputSetting controls = new InputSetting(); 
    private static GameObject p_obj = GameObject.Instantiate(Imports.PLAYER_OBJ, (Vector3)Constants.PLAYER_STARTING_POSITION+Vector3.up, Quaternion.identity);
    public static Player player = p_obj.AddComponent<Player>();
    public static GameTimer main_time;
    public static Quaternion cam_angle;
    public static int health = Constants.CHATA_HEALTH;
    public static int essence = Constants.STARTING_ESSENCE;
    public static bool IsGameOver = false;
}
