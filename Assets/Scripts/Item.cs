using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Item : MonoBehaviour, IPickable
{
    public int amout;
    public float pickup_range = 2f;
    public float pickup_speed = 2f;
    private void Update() {
        Collider[] collector = Physics.OverlapSphere(transform.position, pickup_range, 1 << 10);
        if (collector.Length > 0) {
            transform.position = Vector3.Lerp(transform.position, collector.First().transform.position, Time.deltaTime*pickup_speed);
        }

        // Movement
        transform.position = new Vector3(transform.position.x, 0.1f*Mathf.Sin(Time.time), transform.position.z);
        transform.rotation = Quaternion.Euler(transform.rotation.x, (transform.rotation.y+5f)%360, transform.rotation.z);
    }

    public void Picked(Player picker, Item item) { 
        Game.essence += amout;
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == 10) {
            Picked(other.gameObject.GetComponent<Player>(), this);
        }
    }
}
