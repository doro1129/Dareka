using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionManager : MonoBehaviour
{
    public Dictionary<int, bool> collections;
    private List<int> oshogatsuCollections;
    private List<int> setsubunCollections;

    public int commonNum;
    public int collectionNum = 13;

    int tempStageIndex = 0;
    public GameObject vocabulary;
    VocabularyList vocabularyList;

    // Start is called before the first frame update
    void Start()
    {
        collections = new Dictionary<int, bool>();
        oshogatsuCollections = new List<int>();
        setsubunCollections = new List<int>();

        for (int i = 0; i < collectionNum; i++)
        {
            collections.Add(i, false);
        }

        for (int i = 0; i < commonNum; i++)
        {
            oshogatsuCollections.Add(i);
            setsubunCollections.Add(i);
        }

        for (int i = 0; i < 3; i++)
        {
            oshogatsuCollections.Add(i + commonNum);
            setsubunCollections.Add(i + commonNum + 3);
        }

        vocabularyList = vocabulary.GetComponent<VocabularyList>();
        vocabularyList.UpdateCollection();
    }

    public void AcquireCollection(string stage, int num)
    {
        int collectionIndex = -1;

        if (stage == "정월")
        {
            collectionIndex = oshogatsuCollections[num];
        }
        else
        {
            collectionIndex = setsubunCollections[num];
        }

        for (int i = 0; i < oshogatsuCollections.Count; i++)
        {
            if (oshogatsuCollections[i] == collectionIndex)
            {
                oshogatsuCollections.RemoveAt(i);
            }
        }

        for (int i = 0; i < setsubunCollections.Count; i++)
        {
            if (setsubunCollections[i] == collectionIndex)
            {
                setsubunCollections.RemoveAt(i);
            }
        }

        collections[collectionIndex] = true;
        Debug.Log(collectionIndex);

        vocabularyList.UpdateCollection();
    }

    public int RandomCollectionNum(string stage)
    {
        int randomNum;
        if (stage == "정월")
        {
            randomNum = Random.Range(0, oshogatsuCollections.Count - 1);
        }
        else
        {
            randomNum = Random.Range(0, setsubunCollections.Count - 1);
        }

        return randomNum;
    }

    public void TempPlusCollectionIndex()
    {
        if (tempStageIndex == 0)
        {
            tempStageIndex = 1;
            int num = RandomCollectionNum("정월");
            AcquireCollection("정월", num);
        }
        else
        {
            tempStageIndex = 0;
            int num = RandomCollectionNum("세쓰분");
            AcquireCollection("세쓰분", num);
        }
    }
}
