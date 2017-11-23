using UnityEngine;

public class GiveDamageToTarget : MonoBehaviour
{
    public int DamageToGive = 10;
    public bool damageAll = false;


    public void OnTriggerEnter(Collider other)
    {
        //seperated damage targets in case it's later useful;
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Health>().TakeDamage(DamageToGive, gameObject);

        }
        else if (other.CompareTag("Enemy") && damageAll)
        {
            other.GetComponent<Health>().TakeDamage(DamageToGive, gameObject);
        }
        else // if neither of the above are true then the method exits before running the rest of the code.
        {
            return;
        }

        GiveDamageBehaviour();
    }

    public virtual void GiveDamageBehaviour()
    {
        // Currently nothing.
    }
}

