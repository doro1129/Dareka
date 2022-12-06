using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanPellet : MonoBehaviour
{
    public float damage;

    private void OnCollisionEnter(Collision collision)
    {
        Oni oni = collision.collider.gameObject.GetComponent<Oni>();
        if (oni != null)
        {
            oni.hp -= damage;
        }
    }
}
