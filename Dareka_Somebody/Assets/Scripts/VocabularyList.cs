using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VocabularyList : MonoBehaviour
{
    public GameObject collection;
    public GameObject[] hideImages;

    public Text[] itemDescriptions;

    public void UpdateCollection()
    {
        for (int i = 0; i < GameManager.instance.collections.Count; i++)
        {
            if (GameManager.instance.collections[i] == true)
            {
                hideImages[i].SetActive(false);
            }
            else
            {
                hideImages[i].SetActive(true);
            }

            itemDescriptions[i].text = string.Format("{0}\n\n{1}", GameManager.instance.collectionsProps[i], GameManager.instance.collectionsDescriptions[i]);
        }
    }
}
