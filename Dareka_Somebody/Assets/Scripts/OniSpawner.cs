using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OniSpawner : MonoBehaviour
{
    public GameObject hpPrefab = null;
    public GameObject oniPrefab;
    public List<GameObject> enemies = new List<GameObject>();

    public int curIndex = 0;
    public int score = 0;
    public int oniScore = 30;
    public Text scoreText;

    float scale;
    Oni oni;

    Transform enemyTransform;
    GameObject hpBar;

    //List<Transform> enemyList = new List<Transform>();
    //List<GameObject> hpBarList = new List<GameObject>();

    Camera cam = null;

    // Use this for initialization
    void Start()
    {
        cam = Camera.main;

        SpawnOni();
    }

    // Update is called once per frame
    void Update()
    {
        if (hpBar != null)
        {
            hpBar.transform.position = cam.WorldToScreenPoint(enemyTransform.position + new Vector3(0, 1.3f, 0));
            scale = 2 / Vector3.Distance(cam.transform.position, enemies[curIndex].transform.position);
            hpBar.transform.localScale = new Vector3(scale, scale, scale);
        }
    }

    public void DestroyHpBar(GameObject oniObject)
    {
        score += oniScore;
        scoreText.text = string.Format("Score: {0:n0}", score);

        enemyTransform = null;
        GameObject tempBar = hpBar;
        hpBar = null;
        Destroy(tempBar);

        curIndex += 1;

        if (curIndex < enemies.Count)
        {
            SpawnOni();
        }
    }

    private void SpawnOni()
    {
        GameObject Oni = Instantiate(oniPrefab, enemies[curIndex].transform.position, Quaternion.identity);
        oni = Oni.GetComponent<Oni>();

        enemyTransform = enemies[curIndex].transform;
        hpBar = Instantiate(hpPrefab, enemyTransform.position, Quaternion.identity, transform);
        Slider slider = hpBar.GetComponent<Slider>();
        slider.value = 1f;

        oni.hpBar = slider;
        oni.canvas = gameObject;
    }
}
