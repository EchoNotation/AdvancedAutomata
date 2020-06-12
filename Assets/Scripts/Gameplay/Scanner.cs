using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{

    ArrayList Enemies = new ArrayList();
    ArrayList Allies = new ArrayList();
    List<Collider2D> Terrain = new List<Collider2D>();


    public void EnterRange(GameObject obj)
    {
        //PolygonCollider2D collider = other.TryGetComponent(PolygonCollider2D, PolygonCollider2D);
        switch (obj.tag)
        {
            case "Wall":
                PolygonCollider2D collider = obj.GetComponent<PolygonCollider2D>();
                Debug.Log("Its a wall!");
                Vector2 wallPos = collider.ClosestPoint(this.transform.position);
                Vector2 targetPos = this.transform.parent.GetComponent<AutoMovement>().target;
                Vector2 position = this.transform.parent.position;
                int nearIndex = 0;
                int farIndex = 0;
                if (Mathf.Abs(Vector2.Angle(wallPos, targetPos)) < 10)
                {
                    float nDistance = Mathf.Infinity;
                    float fDistance = Mathf.Infinity;
                    PolygonCollider2D poly = (PolygonCollider2D)collider;

                    for (int i = 0; i < poly.points.Length; i++)
                    {
                        float dn = Vector2.Distance(poly.points[i], position);
                        float df = Vector2.Distance(poly.points[i], targetPos);
                        if (dn < nDistance)
                        {
                            nDistance = dn;
                            nearIndex = i;
                        }

                        if (df < fDistance)
                        {
                            fDistance = df;
                            farIndex = i;
                        }
                    }
                    this.transform.parent.GetComponent<AutoMovement>().editTarget(targetPos);
                    for (int i = farIndex; i >= nearIndex; i--)
                    {
                        this.transform.parent.GetComponent<AutoMovement>().editTarget(poly.points[i]);
                    }
                }

                Terrain.Add(collider);
                return;
            case "Coal":
                Debug.Log("Found coal deposit!");
                break;
            case "Iron":
                Debug.Log("Found iron deposit!");
                break;
            case "Electrum":
                Debug.Log("Found electrum deposit!");
                break;
            default:
                Debug.Log("Unknown tag detected by a scanner! Tag: " + obj.tag);
                return;
        }   
    }
    public void ExitRange(Collider2D collider)
    {
        switch (collider.gameObject.tag)
        {
            case "Wall":
                Terrain.Remove(collider);
                return;
        }
    }
}
