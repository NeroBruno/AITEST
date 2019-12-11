using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ChaseState", menuName = "UnityFSM/States/Chase")]
public class ChaseState : AbstractFSMState
{
    private Transform _chaseTransform;
    public override void OnEnable()
    {
        base.OnEnable();
        StateType = FSMStateType.CHASE;
    }

    public override bool EnterState()
    {
        return base.EnterState();
    }

    public override void UpdateState()
    {
        throw new System.NotImplementedException();
    }

    public override bool ExitState()
    {
        return base.ExitState();
    }

}
