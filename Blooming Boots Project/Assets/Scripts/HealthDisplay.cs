using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthDisplay : MonoBehaviour
{
    // This will contain the slider component attached to this object
    // Slider = variable is in the form of a Slider component
    Slider healthSlider;

    // This will be the PlayerHealth component that we can ask for information about the player's health
    // PlayerHealth = variable is in the form of a PlayerHealth component (your script)
    PlayerHealth player;

    // Built in Unity function
    // Start is called before the first frame update
    void Start()
    {
        // Get a Slider component from the game object this script is attached to
        // Store the Slider component in our healthSlider variable
        healthSlider = GetComponent<Slider>();

        // Search the scene for the object with PlayerHealth script attached
        // Store the PlayerHealth component from that object in our player variable
        player = FindObjectOfType<PlayerHealth>();
    }

    // Built in Unity function
    // Update is called once per frame
    void Update()
    {
        // Get the current and max health values from the player
        // Store these values in float variables
        // We use float because we need decimal points for the slider 
        // (not whole numbers aka integers)
        float currentHealth = player.GetHealth();
        float maxHealth = player.startingHealth;

        // The slider value should be something between 0 and 1, with 1 being full
        // We want the fraction of fill for the slider
        // So we divide the current health by the max health
        healthSlider.value = currentHealth / maxHealth;
    }
}