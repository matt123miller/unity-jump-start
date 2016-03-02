using UnityEngine;

public class GiveHealth : MonoBehaviour
{
    // effect should be a child GameObject that has a particle or something attached. When the particle is over destroy the object I guess.
    public GameObject effect;
    public int healthToGive;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            var playerHealth = other.GetComponent<Health>();

            playerHealth.GiveHealth(healthToGive, gameObject);
            Instantiate(effect, transform.position, transform.rotation);

            gameObject.SetActive(false);
        }
    }


}