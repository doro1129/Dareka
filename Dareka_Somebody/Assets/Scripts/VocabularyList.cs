using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VocabularyList : MonoBehaviour
{
    public GameObject collection;
    public GameObject[] hideImages;
    CollectionManager collectionManager;

    void Start()
    {
        collectionManager = collection.GetComponent<CollectionManager>();
    }

    public void UpdateCollection()
    {
        for (int i = 0; i < collectionManager.collectionNum; i++)
        {
            if (collectionManager.collections[i] == true)
            {
                hideImages[i].SetActive(false);
            }
        }
    }
}
