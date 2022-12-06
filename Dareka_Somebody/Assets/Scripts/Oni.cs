using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oni : MonoBehaviour
{
    public Slider hpBar;
    public GameObject canvas;
    public GameObject target;
    private float OniPositionY;

    private float maxHp = 100f;
    public float hp = 100f;

    public float speed;

    float damage = 10f;

    private void Start()
    {
        OniPositionY = transform.position.y;
    }

    private void Update()
    {
        LookAtSlowlyY(target.transform);

        Vector3 targetPostion = target.transform.position;
        targetPostion.y = OniPositionY;
        transform.position = Vector3.Slerp(transform.position, targetPostion, Time.deltaTime * speed);

        if (hp <= 0)
        {
            hpBar.value = 0f;

            OniSpawner hpBarUI = canvas.GetComponent<OniSpawner>();
            hpBarUI.DestroyHpBar(gameObject);
            Destroy(gameObject);
        }
        else
        {
            if (hpBar != null)
            {
                HandleHp();
            }
        }
    }

    private void LookAtSlowlyY(Transform targetTransform, float lookSpeed = 2f)
    {
        if (targetTransform == null) return;

        Vector3 dir = targetTransform.position - transform.position;
        dir.y = 0f; // 방향 벡터 Y 성분 제거

        var nextRot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, nextRot, Time.deltaTime * lookSpeed);
    }

    private void HandleHp()
    {
        hpBar.value = Mathf.Lerp(hpBar.value, hp / maxHp, Time.deltaTime * 10);
    }

    private void OnCollisionEnter(Collision collision)
    {
        FPSPlayer player = collision.collider.gameObject.GetComponent<FPSPlayer>();

        if (player != null)
        {
            player.hp -= damage;
        }
    }
}
