using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Utils.ReadOnly] public static GameManager _instance;
    [SerializeField] List<TileIdentification> restricted_blocks = new List<TileIdentification>();
    [SerializeField] List<Material> materials = new List<Material>();
    [SerializeField] List<Material> materials_o = new List<Material>();

    public GameObject game_over;
    public GameObject pause;

    void Awake()
    {
        if (!_instance)
            _instance = this;
        else
            Destroy(this);

        // Init Game over condition event
        if (Game.game_over_event == null)
            Game.game_over_event = new UnityEvent();

        Game.game_over_event.AddListener(() => {
            Game.IsGameOver = true;

            //Show UI
            game_over.SetActive(true);
            game_over.GetComponentInChildren<TextMeshProUGUI>().text = Game.main_time.GetComponent<TextMeshProUGUI>().text;
            game_over.GetComponentInChildren<Button>().onClick.AddListener(() => {
                ScreenManager.instance.LoadToMenu(ScreenManager.SceneIndexs.GAME);
            });
            // Freeze time
            Time.timeScale = 0;
        });

        Button[] btns = pause.GetComponentsInChildren<Button>();
        btns[0].onClick.AddListener(() => {
            Time.timeScale = 1;
            pause.SetActive(false);
        });
        btns[1].onClick.AddListener(() => {
            ScreenManager.instance.LoadToMenu(ScreenManager.SceneIndexs.GAME);
        });

        // SET GAME PROPERIES
        if (!Game.tilemap_object)
            Game.tilemap_object = GameObject.FindGameObjectWithTag("map");
        if (Game.map == null)
            Game.map = Utils.InitializeMap(Game.tilemap_object);
        if (!Game.selector_tilemap_object)
            Game.selector_tilemap_object = GameObject.FindGameObjectWithTag("sel_map");
        if (!Game.main_time) {
            Game.main_time = GameObject.FindGameObjectWithTag("timer").GetComponent<GameTimer>();
        }

        Game.restricted_blocks = restricted_blocks.Select(x => x.position).ToList();
        
        for(int i = 0; i < materials.Count; i++) {
            Game.tiles.Add(materials[i], materials_o[i]);
        }
        //Game.i_selector = GameObject.Find("sgfsg").GetComponent<InteractionSelector>();
        
        Debug.Log("All loaded!");
    }

    void Start() {

    }
}