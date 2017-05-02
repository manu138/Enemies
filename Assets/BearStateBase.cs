﻿using UnityEngine;

public abstract class BearStateBase
{
    protected BearAIController controlled;

    public BearStateBase (BearAIController controlled)
    {
        this.controlled = controlled;
    }

    public virtual void StartState ()
    {
    }

    public virtual void OnTriggerEnter(Collider other)
    {
    }

    public abstract void UpdateState ();

    protected Transform LookForPlayer ()
    {
        RaycastHit hit;
        Vector3 end = controlled.eyes.transform.position + controlled.eyes.transform.forward * controlled.sightRange;
        Debug.DrawLine (controlled.eyes.transform.position, end);
        if (Physics.SphereCast (controlled.eyes.transform.position, 2f, controlled.eyes.transform.forward, out hit, controlled.sightRange) && hit.collider.CompareTag ("Player")) 
            return hit.transform;
        else
            return null;
    }
}
