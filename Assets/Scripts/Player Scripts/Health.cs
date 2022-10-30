using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int MAX_HEALTH = 100;
    [SerializeField] private int health = 100;

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Can't have negative dmg");
        }

        // Visuals
        StartCoroutine(VisualIndicator(Color.red));

        // Does Damage
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Heal(10);
        }
        /*

            if (Input.GetKeyDown(KeyCode.D))
            {
                Damage(10);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                health -= 20;
                if (health <= 0)
                {
                    Debug.Log("Lol u diedd");
                }
            }
            if (health <= 0 && Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Respect");
            }*/
    }

    private IEnumerator VisualIndicator(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Can't negative heal");
        }
        bool wouldBeOverMaxHealth = health + amount > MAX_HEALTH;
        if (wouldBeOverMaxHealth)
        {
            health = MAX_HEALTH;
        } else
        {
            health += amount;
            StartCoroutine(VisualIndicator(Color.green));
        }
    }

    private void Die()
    {
        Debug.Log("Ded!");
        Destroy(gameObject);
    }

    public void SetHealth(int maxHealth,int health)
    {
        MAX_HEALTH = maxHealth;
        this.health = health;
    }
}
