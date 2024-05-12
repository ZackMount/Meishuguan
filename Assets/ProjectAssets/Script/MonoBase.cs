using UnityEngine;
using System.Collections;

public class MonoBase : MonoBehaviour {

    public bool isLock = false;

    public virtual void Lock()
    {
        isLock = true;
    }

    public virtual void Unlock()
    {
        isLock = false;
    }

    protected Transform m_transform;

    protected virtual void Init()
    {

    }

}
