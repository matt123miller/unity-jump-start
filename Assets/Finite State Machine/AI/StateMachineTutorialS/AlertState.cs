using UnityEngine;
using System.Collections;

public class AlertState : MonoBehaviour
{


    private readonly StatePatternEnemy enemy;
    public float searchTimer = 0f;

    public AlertState(StatePatternEnemy statepatternenemy)
    {
        enemy = statepatternenemy;
    }


    public void UpdateState()
    {
        Look();
        Search();
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

    private void Search()
    {
        // do some searching

        //if not in sight ? {
        //    searchTimer += Time.deltaTime;
        //    
        //    if searchTimer >= enemy.searchingDuration {
        //        ToPatrolState();
        //    }
        //}
    }


    public void OnTriggerEnter(Collider other)
    {

    }

    public void ToPatrolState()
    {
        enemy.currentState = (IEnemyState)enemy.patrolState;
        searchTimer = 0f;
    }

    public void ToAlertState()
    {
        Debug.Log("Can't transition to same state");

    }

    public void ToChaseState()
    {
        enemy.currentState = (IEnemyState)enemy.chaseState;
        searchTimer = 0f;
    }
}
