using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health h = collision.GetComponent<Health>();
        if (h != null)
        {
            h.Damage(damage);
        }
    }
}
