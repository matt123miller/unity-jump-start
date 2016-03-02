using UnityEngine;
using System.Collections;
using System;

public class ChaseState : MonoBehaviour {


    private readonly StatePatternEnemy enemy;
    

    public ChaseState(StatePatternEnemy statepatternenemy)
    {
        enemy = statepatternenemy;
    }


    public void UpdateState()
    {
        Look();
        Chase();
    }

    private void Look()
    {
        RaycastHit hit;
        // Used to look directly at target insteazd of forward
        Vector3 enemyToTarget = (enemy.chaseTarget.position + enemy.offset) - enemy.eyes.transform.position;

        if (Physics.Raycast(enemy.eyes.transform.position, enemyToTarget, out hit, enemy.sightRange) && hit.collider.CompareTag("Player"))
        {
            enemy.chaseTarget = hit.transform;
            ToChaseState();
        }
        else
        {
            // Maybe then wrap in a timer or some condition
            ToAlertState();
        }
    }

    private void Chase()
    {
        enemy.navMeshAgent.destination = enemy.chaseTarget.position;
        enemy.navMeshAgent.Resume();
    }

    public void OnTriggerEnter(Collider other)
    {

    }

    public void ToPatrolState()
    {
        enemy.currentState = (IEnemyState)enemy.patrolState;

    }

    public void ToAlertState()
    {
        enemy.currentState = (IEnemyState)enemy.chaseState;

    }

    public void ToChaseState()
    {
        Debug.Log("Can't transition to same state");

    }

    public static implicit operator Transform(ChaseState v)
    {
        throw new NotImplementedException();
    }
}
