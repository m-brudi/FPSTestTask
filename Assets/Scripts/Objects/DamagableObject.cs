using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagableObject : MonoBehaviour
{
    [SerializeField] int myType;

    public int MyType {
        get { return myType; }
    }
    public virtual void Hit() {}
    public virtual void Hit(Vector3 pos) {}
}
