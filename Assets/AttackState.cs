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
    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            AttackEmily();
    }
    private void AttackEmily()
    {
        controlled.Disparar();


        controlled.MakeTransition(BearState.Chase);
    }
    private void ToPatrol()
    {
        controlled.MakeTransition(BearState.Patrol);
    }

}

