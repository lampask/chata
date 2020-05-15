using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Utils.ReadOnly] public int wave = 0;
    public float initial_delay = 10000f;

    [Header("Waves")]
    public float delay = 500f;
    public int delay_rate = 1;


    [Header("Spawning")]
    public float spawn_delay = 2f;
    public int spawn_delay_rate = 1;

    public GameObject[] enemy_array;

    public enum Enemies {
        TERMIT = 0,
        DINO = 1
    }
    
    [System.Serializable]
    public class Wave {
        public List<Unit> units;
    }

    [System.Serializable]
    public class Unit {
        public Enemies type;
        public int amout;
    }

    public List<Wave> waves;

    public Polyline trajectory;

    private void Awake() {
        trajectory = GetComponent<Polyline>();
        enemy_array = new GameObject[]{Imports.TERMIT_OBJ, Imports.DINO_OBJ};
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn() {
        yield return new WaitForSeconds(initial_delay);
        while(!GameManager._instance.IsGameOver) {
            foreach(Wave w in waves) {
                foreach(Unit u in w.units) {
                    GameObject.Instantiate(enemy_array[(int)u.type], transform.position+trajectory.nodes[0]-Vector3.up*(transform.position.y-1), Quaternion.LookRotation((transform.TransformPoint(transform.position+trajectory.nodes[0])-transform.TransformPoint(transform.position+trajectory.nodes[1])).normalized)).GetComponent<Enemy>().trajectory = trajectory;
                    yield return new WaitForSeconds(spawn_delay);
                }
                wave++;
                yield return new WaitForSeconds(delay);
            }
        }
    }
}
