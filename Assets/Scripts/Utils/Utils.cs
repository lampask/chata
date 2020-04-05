using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using UnityEngine.Tilemaps;
using System.IO;

public static class Utils
{
    [AttributeUsage(AttributeTargets.Field, Inherited = true)]
    public class ReadOnlyAttribute : PropertyAttribute { }
    #if UNITY_EDITOR
        [UnityEditor.CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
        public class ReadOnlyAttributeDrawer : UnityEditor.PropertyDrawer
        {
            public override void OnGUI(Rect rect, UnityEditor.SerializedProperty prop, GUIContent label)
            {
                bool wasEnabled = GUI.enabled;
                GUI.enabled = false;
                UnityEditor.EditorGUI.PropertyField(rect, prop);
                GUI.enabled = wasEnabled;
            }
        }
    #endif

    
    public static Dictionary<int, Dictionary<int, Dictionary<int, WorldObject>>> InitializeMap(GameObject map_container) {
        var map = new Dictionary<int, Dictionary<int, Dictionary<int, WorldObject>>>();
        foreach(TileIdentification tile in map_container.GetComponentsInChildren<TileIdentification>()) {
            if (!map.ContainsKey(tile.position.z))
                map[tile.position.z] = new Dictionary<int, Dictionary<int, WorldObject>>();
            if (!map[tile.position.z].ContainsKey(tile.position.x))
                map[tile.position.z][tile.position.x] = new Dictionary<int, WorldObject>();
            map[tile.position.z][tile.position.x][tile.position.y] = tile;
        }
        return map;
    }

    public static WorldObject GetMapObj(Vector3 pos) { return GetMapObj((int)pos.x, (int)pos.y, (int)pos.z); }
    public static WorldObject GetMapObj(Vector3Int pos) { return GetMapObj(pos.x, pos.y, pos.z); }
    public static WorldObject GetMapObj(int x, int y) { return GetMapObj(x, y, 0); }
    public static WorldObject GetMapObj(Vector2 pos) { return GetMapObj((int)pos.x, (int)pos.y, 0); }
    public static WorldObject GetMapObj(Vector2Int pos) { return GetMapObj(pos.x, pos.y, 0); }
    public static WorldObject GetMapObj(int x, int y, int z) {
        if (GameManager._instance.map == null)
            InitializeMap(GameManager._instance.tilemap_object);
        try {
            return GameManager._instance.map[z][x][y];
        } catch {
            return null;
        }
    }
    
    public static void AddMapObj(WorldObject obj) { 
        if (!GameManager._instance.map.ContainsKey((int) obj.gameObject.transform.position.z))
            GameManager._instance.map[(int) obj.gameObject.transform.position.z] = new Dictionary<int, Dictionary<int, WorldObject>>();
        if (!GameManager._instance.map[(int) obj.gameObject.transform.position.z].ContainsKey((int) obj.gameObject.transform.position.x))
            GameManager._instance.map[(int) obj.gameObject.transform.position.z][(int) obj.gameObject.transform.position.x] = new Dictionary<int, WorldObject>();
        GameManager._instance.map[(int) obj.gameObject.transform.position.z][(int) obj.gameObject.transform.position.x][(int) obj.gameObject.transform.position.y] = obj; 
    }

    public static void RemoveMapObj(WorldObject obj) {
        GameManager._instance.map[obj.position.z][obj.position.x].Remove(obj.position.y);
    }

    public static T Next<T>(this T src) where T : struct
    {
        if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Argument {0} is not an Enum", typeof(T).FullName));

        T[] Arr = (T[])Enum.GetValues(src.GetType());
        int j = Array.IndexOf<T>(Arr, src) + 1;
        return (Arr.Length==j) ? Arr[0] : Arr[j];            
    }

    public static T Previous<T>(this T src) where T : struct
    {
        if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Argument {0} is not an Enum", typeof(T).FullName));

        T[] Arr = (T[])Enum.GetValues(src.GetType());
        int j = Array.IndexOf<T>(Arr, src) - 1;
        return (j==-1) ? Arr[Arr.Length-1] : Arr[j];            
    }

    public static void Drop<T>(T source, int amout) where T : WorldObject, IEntity {
        Drop(source.transform.position, amout);
    }
    public static void Drop(Vector3 pos, int amout) {
        if (!GameManager._instance.IsGameOver) {
            // TODO Droppping essence
            GameObject.Instantiate(Imports.ESSENCE, pos, Quaternion.identity).GetComponent<Item>().amout = amout;
        }
    }
}