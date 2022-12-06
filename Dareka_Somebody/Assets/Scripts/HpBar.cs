using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public GameObject goPrefab = null;
    public List<GameObject> enemies = new List<GameObject>();
    public int score = 0;
    public int oniScore = 30;
    public Text scoreText;

    float scale;
    Slider slider;
    Oni oni;

    List<Transform> enemyList = new List<Transform>();
    List<GameObject> hpBarList = new List<GameObject>();

    Camera cam = null;

    // Use this for initialization
    void Start()
    {
        cam = Camera.main;

        for (int i = 0; i < enemies.Count; i++)
        {
            enemyList.Add(enemies[i].transform);
            GameObject hpbar = Instantiate(goPrefab, enemies[i].transform.position, Quaternion.identity, transform);

            slider = hpbar.GetComponent<Slider>();
            slider.value = 1f;
            oni = enemies[i].GetComponent<Oni>();
            oni.hpBar = slider;
            
            hpBarList.Add(hpbar);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            hpBarList[i].transform.position = cam.WorldToScreenPoint(enemyList[i].position + new Vector3(0, 1.3f, 0));
            scale = 2 / Vector3.Distance(cam.transform.position, enemies[i].transform.position);
            hpBarList[i].transform.localScale = new Vector3(scale, scale, scale);
        }
    }

    public void DestroyHpBar(GameObject oniObject)
    {
        score += oniScore;
        scoreText.text = string.Format("Score: {0:n0}", score);

        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            if (enemies[i] == oniObject)
            {
                enemies.Remove(enemies[i]);
                enemyList.Remove(enemyList[i]);
                GameObject hpBar = hpBarList[i];
                hpBarList.Remove(hpBarList[i]);
                Destroy(hpBar);
                break;
            }
        }
    }
}
