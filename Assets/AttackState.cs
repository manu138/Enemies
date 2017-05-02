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
        ToPatrol();
    }

    private void AttackEmily()
    {
        controlled.Disparar();


        controlled.MakeTransition(BearState.Alert);
    }
    private void ToPatrol()
    {
        controlled.MakeTransition(BearState.Patrol);
    }

}

