using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SSActionEventType : int { Started, Completed }

public interface ISSActionCallback
{
    void SSActonEvent(SSAction source, SSActionEventType events = SSActionEventType.Completed,
        int intParam = 0, string strPam = null, Object objectParam = null);
}

public class SSAction : ScriptableObject {
    public bool enable = true;
    public bool destroy = false;

    public GameObject gameObject { get; set; }
    public Transform transform { get; set; }
    public ISSActionCallback callback { get; set; }

    protected SSAction(){}

    public virtual void gameAction()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Start()
    {
        throw new System.NotImplementedException();
    }
}
