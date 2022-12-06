using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OniSpawner : MonoBehaviour
{
    public GameObject hpPrefab = null;
    public GameObject oniPrefab;
    public GameObject player;
    public List<GameObject> enemies = new List<GameObject>();

    float scale;
    int curIndex;
    Oni oni;

    Transform enemyTransform;
    GameObject hpBar;
    GameObject Oni;

    Camera cam = null;

    // Use this for initialization
    void Start()
    {
        cam = Camera.main;

        Invoke("SpawnOni", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (hpBar != null)
        {
            hpBar.transform.position = cam.WorldToScreenPoint(Oni.transform.position + new Vector3(0, 3.5f, 0));
            scale = 2 / Vector3.Distance(cam.transform.position, Oni.transform.position);
            hpBar.transform.localScale = new Vector3(scale, scale, scale);
        }
    }

    public void DestroyHpBar(GameObject oniObject)
    {
        enemyTransform = null;
        GameObject tempBar = hpBar;
        hpBar = null;
        Destroy(tempBar);

        enemies.RemoveAt(curIndex);
        if (!IsMamemakiOver())
        {
            SpawnOni();
        }
    }

    private void SpawnOni()
    {
        int index = Random.Range(0, enemies.Count - 1);
        Oni = Instantiate(oniPrefab, enemies[index].transform.position, Quaternion.identity);
        oni = Oni.GetComponent<Oni>();
        enemyTransform = enemies[index].transform;

        curIndex = index;

        hpBar = Instantiate(hpPrefab, enemyTransform.position, Quaternion.identity, transform);
        Slider slider = hpBar.GetComponent<Slider>();
        slider.value = 1f;

        oni.hpBar = slider;
        oni.canvas = gameObject;
        oni.target = player;
    }

    public bool IsMamemakiOver()
    {
        if (enemies.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
