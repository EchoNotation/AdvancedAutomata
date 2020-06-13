using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beacon : MonoBehaviour
{

    Vector2 position;

    //Beacon Network Information
    LinkedListNode<GameObject> myHQEntry;
    LinkedList<GameObject> connectedBeacons = new LinkedList<GameObject>();


    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(LinkedList<GameObject> allBeacons)
    {
        position = this.transform.position;
        myHQEntry = allBeacons.Last;
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

}
