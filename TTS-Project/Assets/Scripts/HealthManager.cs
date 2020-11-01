using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour{

    public int currentHealth;
    public int maxHealth;
    public int minHealth;
    public Text hpText;
 

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        minHealth = -1;
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = "HP: " + currentHealth;
    }

    public void HurtPlayer(int damage)
    {
        currentHealth -= damage;
    }

    public void HealPlayer(int healAmount)
    {
        currentHealth += healAmount;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        else if(currentHealth < minHealth)
        {
            currentHealth = 0;
        }
    }
}
