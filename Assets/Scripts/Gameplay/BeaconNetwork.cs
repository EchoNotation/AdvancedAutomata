using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaconNetwork : MonoBehaviour
{

    public GameObject beacon;
    public bool readyBeacon = false; //set true to instantiate a beacon on next click
    public Vector2 placementPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createBeacon(Vector2 position)
    {
        GameObject newBeacon = Instantiate(beacon, position, Quaternion.identity);
        //newBeacon.getComponent<>().initialize();
    }
}
