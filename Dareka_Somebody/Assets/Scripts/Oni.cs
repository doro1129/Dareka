using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oni : MonoBehaviour
{
    public Slider hpBar;
    public GameObject canvas;
    
    private float maxHp = 100f;
    public float hp = 100f;

    public float speed;

    public GameObject target;
    Rigidbody rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (hp <= 0)
        {
            hpBar.value = 0f;

            OniSpawner hpBarUI = canvas.GetComponent<OniSpawner>();
            hpBarUI.DestroyHpBar(gameObject);
            Destroy(gameObject);
        }
        else
        {
            Move();
            if (hpBar != null)
            {
                HandleHp();
            }
        }
    }

    private void HandleHp()
    {
        hpBar.value = Mathf.Lerp(hpBar.value, hp / maxHp, Time.deltaTime * 10);
    }

    private void Move()
    {
        //move toward target
    }

    private void OnCollisionEnter(Collision collision)
    {
        FPSPlayer player = collision.collider.gameObject.GetComponent<FPSPlayer>();

        if (player != null)
        {
            Debug.Log("Game Over");
            //GameOver;
        }
    }
}
