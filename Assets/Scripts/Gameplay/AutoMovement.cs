using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMovement : MonoBehaviour
{
    public Vector2 target = new Vector2(0, 0);
    public float speed = 1;
    Vector2 position;
    LinkedList<Vector2> targetList = new LinkedList<Vector2>();

    // Start is called before the first frame update
    void Start()
    {
        position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        position = new Vector2(this.transform.position.x, this.transform.position.y);

        if (Vector2.Distance(position, target) > .1)
        {
            transform.position = Vector2.MoveTowards(position, target, (speed * Time.deltaTime));
        }
        else if(targetList.First != null)
        {
            nextTarget();
        }
    }

    public void nextTarget()
    {
        target = targetList.First.Value;
        targetList.RemoveFirst();
    }

    public void setTarget(float x,float y)
    {
        this.targetList.Clear();
        this.targetList.AddLast(new Vector2(x, y));
    }

    public void addTarget(float x, float y)
    {
        this.targetList.AddLast(new Vector2(x, y));
    }

    public void editTarget(Vector2 t)
    {
        this.targetList.AddFirst(t);
    }

}
