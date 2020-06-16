using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaconNetwork : MonoBehaviour
{

    public GameObject beacon;
    public bool readyBeacon = false; //set true to instantiate a beacon on next click
    public Vector2 placementPosition;
    LinkedList<GameObject> allBeacons = new LinkedList<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (readyBeacon)
        {
            readyBeacon = false;
            createBeacon(placementPosition);
        }
    }

    public void createBeacon(Vector2 position)
    {
        GameObject newBeacon = Instantiate(beacon, position, Quaternion.identity);
        newBeacon.GetComponent<Beacon>().Initialize(this.gameObject, allBeacons);
        allBeacons.AddLast(newBeacon);
    }

    public void beaconLost(GameObject lostBeacon)
    {
        Debug.Log("a Beacon is Lost");
        foreach (GameObject beacon in allBeacons)
        {
            beacon.GetComponent<Beacon>().loseBeacon(lostBeacon);
        }
    }
}
