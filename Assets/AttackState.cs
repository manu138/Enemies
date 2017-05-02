using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BearStateBase

{
    public AttackState(BearAIController controlled) : base(controlled)
    {
    }

    public override void UpdateState()
    {
        AttackEmily();
    }

    private void AttackEmily()
    {
        Debug.Log("atacar");
        controlled.MakeTransition(BearState.Alert);
    }
}
