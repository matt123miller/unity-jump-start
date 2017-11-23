/*
 * Written by Matt
 * 
 * This contains all of the functionality for having, losing and gaining health.
 * Currently used by:
 *  - GiveDamageToTarget
 *  - GiveHealth
 *  - The Projectile classes
 * 
 * Any future classes that need to interact with this can do so using the HealthValue property
 * or by caching GetComponent<Health>() and then calling the methods TakeDamage() and/or GiveHealth() .
 * 
 */

using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour, IGiveHealth, ITakeDamage
{
    //private HealthBar healthBar; //Maybe needed later.
    [SerializeField]
    private int _healthValue;
    private bool _isDead = false;

    //public Player player;
    public int maxHealth = 100;
    public AudioClip healthGainSound;
    public AudioClip healthLossSound;

    public int HealthValue
    {
        get { return _healthValue; }
        set { _healthValue = value; }
    }

    public bool IsDead
    {
        get { return _isDead; }
        private set { _isDead = value; }
    }



    // Use this for initialization
    private void Awake()
    {
        IsDead = _isDead;
        HealthValue = maxHealth;
    }


    public void GiveHealth(int healthtogive, GameObject instigator)
    {
        AudioSource.PlayClipAtPoint(healthGainSound, transform.position);

        _healthValue = Mathf.Min(_healthValue + healthtogive, maxHealth); // returns the smallest of the 2 arguments
    }



    public void TakeDamage(int damage, GameObject instigator)
    {
        AudioSource.PlayClipAtPoint(healthLossSound, transform.position);

        _healthValue -= damage;

        Debug.Log("I have been hit and have " + _healthValue + " health remaining");

        if (_healthValue <= 0)
        {

            Kill();
        }
    }

    //should only be used internally. There is public void InstantKill() below if necessary
    private void Kill()
    {
        if (gameObject.CompareTag("Player"))
        {
            IsDead = true;
            Debug.Log("I am dead :(");
            return;
        }

        _healthValue = 0;
    }

    //currently untested
    public void InstantKill()
    {
        //For killing players
        //if (gameObject.CompareTag("Player"))
        //{
        //    something cool
        //}

        //For killing non player objects who have health.
        Kill();
    }
}

