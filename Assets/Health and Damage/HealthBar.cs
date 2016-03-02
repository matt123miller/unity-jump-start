/*
 * Written by Luke, refactored by Matt
 * 
 * This is Matt's version of HealthBar that uses the separated health system.
 * Luke's code is still present at the bottom, commented out, in case it's necessary
 */

using UnityEngine;
using System.Collections;


public class HealthBar : MonoBehaviour
{
    private float _healthPercent = 0.0f;


    public GameObject healthObjHolder;
    public Health healthInstance;
    public int healthValue;
    public Transform foregroundSprite;
    public SpriteRenderer ForegroundRenderer;
    public Color MaxHealthColour = new Color(255 / 255, 63 / 255f, 63 / 255f);
    public Color MinHealthColour = new Color(64 / 255f, 137 / 255f, 255 / 255f);

    private void Start()
    {
        healthInstance = healthObjHolder.GetComponent<Health>();
        healthValue = healthInstance.HealthValue;

    }


    //Consider refactoring into 1 method to call when damage is taken.
    public void Update()
    {

        _healthPercent = (float)healthInstance.HealthValue / (float)healthInstance.maxHealth;
        foregroundSprite.localScale = new Vector3(_healthPercent, 1, 1);
        ForegroundRenderer.color = Color.Lerp(MaxHealthColour, MinHealthColour, _healthPercent);
    }
}