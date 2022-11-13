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

    private void Update()
    {
        if (hp <= 0)
        {
            hpBar.value = 0f;

            HpBar hpBarUI = canvas.GetComponent<HpBar>();
            hpBarUI.DestroyHpBar(gameObject);
            Destroy(gameObject);
        }

        HandleHp();
    }

    private void HandleHp()
    {
        hpBar.value = Mathf.Lerp(hpBar.value, hp / maxHp, Time.deltaTime * 10);
    }
}
