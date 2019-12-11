using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(FiniteStateMachine))]
public class NPC : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private FiniteStateMachine _finiteStateMachine;

    [SerializeField]
    private ConnectedWaypoint[] _patrolPoints;
    
    public void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _finiteStateMachine = GetComponent<FiniteStateMachine>();
    }

    public void Start()
    {
        
    }

    public void Update()
    {
        
    }

    public ConnectedWaypoint[] PatrolPoints
    {
        get => _patrolPoints;
    }
}
