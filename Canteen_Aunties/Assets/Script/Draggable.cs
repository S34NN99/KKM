using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Draggable : MonoBehaviour
{

    public abstract void OnMouseDown();
    public abstract void OnMouseUp();
    public virtual void OnMouseExit() { }

    public virtual void OnMouseDrag() { }

    protected void CollisionSwitch(Collider2D collider, bool power)
    {
        collider.enabled = power;
    }
}
