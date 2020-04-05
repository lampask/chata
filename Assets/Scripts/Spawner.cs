using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float initial_delay = 10000f;

    [Header("Waves")]
    public float delay = 500f;
    public int delay_rate = 1;


    [Header("Spawning")]
    public float spawn_delay = 2f;
    public int spawn_delay_rate = 1;

    public int amout = 1;
    public int amout_rate = 1;
    public Polyline trajectory;

    private void Awake() {
        trajectory = GetComponent<Polyline>();
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn() {
        yield return new WaitForSeconds(initial_delay);
        while(!GameManager._instance.IsGameOver) {
            for (int i = 0; i < amout; i++) {
                GameObject.Instantiate(Imports.DINO_OBJ, transform.position+trajectory.nodes[0]-Vector3.up*(transform.position.y-1), Quaternion.LookRotation((transform.TransformPoint(transform.position+trajectory.nodes[0])-transform.TransformPoint(transform.position+trajectory.nodes[1])).normalized)).GetComponent<Dino>().trajectory = trajectory;
                yield return new WaitForSeconds(spawn_delay);
            }
            yield return new WaitForSeconds(delay);
        }
    }
}
