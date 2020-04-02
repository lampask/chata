using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using System.Linq;
using System;

[RequireComponent(typeof(NavMeshAgent))]
public class Player : MonoBehaviour, IEntity, ICanDealDamage
{
    [HideInInspector] public SkinnedMeshRenderer mesh;
    [HideInInspector] public NavMeshAgent nava;

    public float force = 1f;

    [Utils.ReadOnly] public Vector2 direction;
    private Vector2 dir_temp;
    [HideInInspector] public Vector3 angeled_cords; 

    public Game.EntityType type { get { return Game.EntityType.PLAYER; } }
    public int Damage { get; set; }

    Tilemap selector_map;
    Tilemap game_map;
    public Vector3Int selectedCell;
    TileBase selector;

    public Vector3 p_pos;
    Vector3 dir;

    public float selector_speed = 18f;

    public float interaction_speed = 3f;

    float time_saved = -1;

    Image progress;
    
    [Utils.ReadOnly] [SerializeField] IStage interaction_stage;
    public enum IStage {
        INACTIVE,
        REMOVE,
        DIG,
        PLANT
    };
    [Utils.ReadOnly] public ISelection selection;
    public enum ISelection {
        TOOL = 0,
        DELFI = 1,
        BROKOL = 2,
        KARF = 3,
        PUMPKIN = 4
    }

    private void OnEnable() {
        Game.controls.Gameplay.Movement.Enable();
        Game.controls.Gameplay.Interaction.Enable();
    }

    private void Awake() {
        mesh = GetComponentInChildren<SkinnedMeshRenderer>();
        nava = GetComponent<NavMeshAgent>();
        progress = GameObject.FindGameObjectWithTag("progress").GetComponent<Image>();

        mesh.gameObject.layer = LayerMask.NameToLayer("Characters");
    }

    private void Start() {
        selector = Imports.SELECTOR_TILE;
        selector_map = Game.selector_tilemap_object.GetComponent<Tilemap>();
        game_map = Game.tilemap_object.GetComponent<Tilemap>();
        p_pos = transform.position+Vector3.down;
        ChangeSelector(selector);   
    }

    void Update() { 
        if (direction != Vector2.zero) {
            Vector3 holder = p_pos + (new Vector3(direction.x, 0, direction.y) * Time.deltaTime * selector_speed);
            // Get and check the movement vector 
            if (Utils.GetMapObj(game_map.LocalToCell(holder)) != null && !Game.restricted_blocks.Contains(game_map.LocalToCell(holder))){
                p_pos = holder;
            }
            // Move selector
            Vector3Int pos = selector_map.LocalToCell(p_pos);
            if (selectedCell != pos) {
                selector_map.SetTile(selectedCell, null);
                selectedCell = pos;
                ChangeSelector(selector);
                //Reset interaction
                ResetInteraction();
                // Move player
                nava.SetDestination(new Vector3(pos.x+0.5f, 0, pos.y+0.5f));
            }
            // Rotate player
            if (nava.stoppingDistance != 0) {
                dir = (new Vector3(pos.x+0.5f, transform.position.y, pos.y+0.5f)-transform.position).normalized;
                Debug.DrawLine(transform.position, new Vector3(pos.x+0.5f, transform.position.y, pos.y+0.5f), Color.green);
            } else {
                Debug.LogWarning("The stopping distance of player is zero. This will lead to rotation issues please change it. (x > 0)");
            }
            transform.rotation = Quaternion.LookRotation(dir);
            //Game.player.GetComponentInChildren<Light>().gameObject.transform.parent.parent.transform.position = new Vector3(pos.x, 7, pos.y);
        }
        if (time_saved != -1) {
            progress.color = Color.white;
            if (Time.time < time_saved+interaction_speed) {
                progress.fillAmount = Mathf.Clamp((Time.time-time_saved)/interaction_speed, 0f, 1f);
                // readybar
            } else {
                switch(interaction_stage) {
                    case IStage.REMOVE:
                        Remove(Utils.GetMapObj(game_map.LocalToCell(p_pos+Vector3.up)));
                        break;
                    case IStage.DIG:
                        Dig((TileIdentification) Utils.GetMapObj(game_map.LocalToCell(p_pos)));
                        break;
                    case IStage.PLANT:
                        Plant();
                        break;
                }
                ResetInteraction();
            }
        }
    }

    private void ResetInteraction() {
        time_saved = -1;
        interaction_stage = IStage.INACTIVE;
        progress.fillAmount = 0;
    }

    private void Pickup(Item pickedUp) {

    }
    private void Remove(WorldObject target) {
        Utils.RemoveMapObj(target);
        Destroy(target.gameObject);
    }
    private void Dig(TileIdentification target) {
        target.ready = true;
        var mr = target.gameObject.GetComponent<MeshRenderer>();
        mr.sharedMaterial = Game.tiles[mr.sharedMaterial];
    }

    private void Plant() {
        Debug.Log("Plant");
        switch(selection) {
            case ISelection.DELFI:
                Utils.AddMapObj(GameObject.Instantiate(Imports.DELFI_OBJ, game_map.CellToLocal(game_map.LocalToCell(p_pos))+Vector3.up, Game.cam_angle).GetComponent<Delfi>());
                break;
            case ISelection.PUMPKIN:
                Utils.AddMapObj(GameObject.Instantiate(Imports.TEKVICA_OBJ, game_map.CellToLocal(game_map.LocalToCell(p_pos))+Vector3.up, Game.cam_angle).GetComponent<Tekvica>());
                break;
        }
    }

    public void DoDamage<T>(T target) where T : IDamagable {
        // TODO
    }

    private void OnDisable() {
        Game.controls.Gameplay.Movement.Disable();
        Game.controls.Gameplay.Interaction.Disable();
    }

    void OnMovement(InputValue _) {
        direction = _.Get<Vector2>();
    }

    void OnSelect(InputValue _) {
        if (_.Get<Vector2>() == Vector2.up) {
            selection = Utils.Previous(selection);
        } else if (_.Get<Vector2>() == Vector2.down) {
            selection = Utils.Next(selection);
        }
        ResetInteraction();
    }

    void OnInteraction(InputValue _) {
        var target = (TileIdentification) Utils.GetMapObj(game_map.LocalToCell(p_pos));
        WorldObject above = target.GetObjectAbove();
        if (selection == ISelection.TOOL) {
            if (above != null && above.GetType() == typeof(TileIdentification)) {
                interaction_stage = IStage.REMOVE;
            } else if (!target.ready) {
                interaction_stage = IStage.DIG;
            } else {
                // Cannot use
                 StartCoroutine(Flash(2));
                return;
            }
        } else {
            if (above == null && target.ready) {
                interaction_stage = IStage.PLANT;
            } else {
                // Cannot plant
                 StartCoroutine(Flash(2));
                return;
            }
        }
        time_saved = Time.time;
    }

    void ChangeSelector(TileBase tile) {
        selector_map.SetTile(selectedCell, tile);
    }

    IEnumerator Flash(int times) {
        progress.color = Color.red;
        for(int i = 0; i < times; i++) {
            progress.fillAmount = 1;
            yield return new WaitForSeconds(.1f);
            progress.fillAmount = 0;
            yield return new WaitForSeconds(.1f);
        }
    }

}
