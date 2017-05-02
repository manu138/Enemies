using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertState : BearStateBase
{
    private float searchTimer;

    public AlertState(BearAIController controlled) : base(controlled)
    {
    }

    public override void UpdateState()
    {
        Search();
        LookAround();
    }

    private void Search()
    {
        Transform player = LookForPlayer();
        if (player != null)
            ToChase(player);
    }

    private void ToChase(Transform player)
    {
        controlled.chaseTarget = player;
        controlled.MakeTransition(BearState.Chase);
    }

    private void LookAround()
    {
        ToAttackState();
    }

    private void ToPatrolState()
    {
        searchTimer = 0f;
        controlled.MakeTransition(BearState.Patrol);
    }
    private void ToAttackState()
    {
        controlled.MakeTransition(BearState.Attack);
    }
}
