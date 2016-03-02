using UnityEngine;
using System.Collections;

public class PatrolState : IEnemyState {

    private readonly StatePatternEnemy enemy;
    private int nextWaypoint;

    public PatrolState(StatePatternEnemy statepatternenemy)
    {
        enemy = statepatternenemy;
    }

    public void UpdateState()
    {
        Look();
        Patrol();
    }

    private void Look()
    {
        RaycastHit hit;

        if (Physics.Raycast(enemy.eyes.transform.position, enemy.eyes.transform.forward, out hit, enemy.sightRange) && hit.collider.CompareTag("Player"))
        {
            enemy.chaseTarget = hit.transform;
            ToChaseState();
        }

    }

    void Patrol()
    {
        enemy.navMeshAgent.destination = enemy.waypoints[nextWaypoint].position;
        enemy.navMeshAgent.Resume();

        if (enemy.navMeshAgent.remainingDistance <= enemy.navMeshAgent.stoppingDistance && !enemy.navMeshAgent.pathPending)
        {
            nextWaypoint = (nextWaypoint + 1) % enemy.waypoints.Length;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ToAlertState();
        }   
    }

    public void ToPatrolState()
    {
        Debug.Log("Can't transition to same state");
    }

    public void ToAlertState()
    {
        enemy.currentState = (IEnemyState)enemy.alertState;
    }

    public void ToChaseState()
    {
        enemy.currentState = (IEnemyState)enemy.chaseState;

    }
}
