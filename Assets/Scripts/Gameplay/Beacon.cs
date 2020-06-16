using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beacon : MonoBehaviour
{

    Vector2 position;
    public int health = 100;
    int armor = 0;

    //Beacon Network Information
    GameObject beaconNetwork;
    LinkedList<GameObject> connectedBeacons = new LinkedList<GameObject>();


    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            die();
        }
    }

    public void Initialize(GameObject network, LinkedList<GameObject> allBeacons)
    {
        beaconNetwork = network;
        position = this.transform.position;
        foreach(GameObject beacon in allBeacons)
        {
            Debug.Log("init");
            Vector2 target = beacon.transform.position;
            RaycastHit2D hit = Physics2D.Raycast(position, (target-position));
            Debug.Log(hit.collider.gameObject.tag);
            GameObject other = hit.collider.gameObject;
            if (other == beacon)
            {
                connectBeacon(other);
                other.GetComponent<Beacon>().connectBeacon(this.gameObject);
                Debug.Log("Connected");
            }
        }
    }

    public void connectBeacon(GameObject other)
    {
        connectedBeacons.AddLast(other);
    }

    public void loseBeacon(GameObject beacon)
    {
        connectedBeacons.Remove(beacon);
    }

    void die()
    {
        beaconNetwork.GetComponent<BeaconNetwork>().beaconLost(this.gameObject);
        Destroy(this.gameObject);
    }
}
