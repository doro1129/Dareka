using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class SaveData
{
    public List<bool> collections = new List<bool>();
    public List<int> oshogatsuCollections = new List<int>();
    public List<int> setsubunCollections = new List<int>();

    public List<string> collectionsProps = new List<string>();
    public List<string> collectionsDescriptions = new List<string>();
}

public class CollectionManager : MonoBehaviour
{
    public int commonNum = 7;
    public int collectionNum = 13;
    int diff;

    int tempStageIndex = 0;
    public GameObject vocabulary;
    VocabularyList vocabularyList;

    string path;
    int randomNum;

    void Start()
    {
        diff = (collectionNum - commonNum) / 2;
        path = Path.Combine(Application.dataPath, "database.json");
        JsonLoad();

        vocabularyList = vocabulary.GetComponent<VocabularyList>();
    }

    public void JsonLoad()
    {
        Debug.Log("로드");
        SaveData saveData = new SaveData();

        if (!File.Exists(path))
        {
            for (int i = 0; i < collectionNum; i++)
            {
                GameManager.instance.collections.Add(false);
            }

            for (int i = 0; i < commonNum; i++)
            {
                GameManager.instance.oshogatsuCollections.Add(i);
                GameManager.instance.setsubunCollections.Add(i);
            }

            for (int i = 0; i < diff; i++)
            {
                GameManager.instance.oshogatsuCollections.Add(i + commonNum);
                GameManager.instance.setsubunCollections.Add(i + commonNum + diff);
            }

            for (int i = 0; i < collectionNum; i++)
            {
                GameManager.instance.collectionsProps.Add("다이어리");
                GameManager.instance.collectionsDescriptions.Add("췌장암이라도 희망이 있을거야." + System.Environment.NewLine + "하루가 한 달도 안 남았다니…");
            }

            JsonSave();
        }
        else
        {
            string loadJson = File.ReadAllText(path);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);

            if (saveData != null)
            {
                for (int i = 0; i < saveData.collections.Count; i++)
                {
                    GameManager.instance.collections.Add(saveData.collections[i]);
                }
                for (int i = 0; i < saveData.oshogatsuCollections.Count; i++)
                {
                    GameManager.instance.oshogatsuCollections.Add(saveData.oshogatsuCollections[i]);
                }
                for (int i = 0; i < saveData.setsubunCollections.Count; i++)
                {
                    GameManager.instance.setsubunCollections.Add(saveData.setsubunCollections[i]);
                }
                for (int i = 0; i < collectionNum; i++)
                {
                    GameManager.instance.collectionsProps.Add(saveData.collectionsProps[i]);
                    GameManager.instance.collectionsDescriptions.Add(saveData.collectionsDescriptions[i]);
                }
            }
        }
    }

    public void JsonSave()
    {
        Debug.Log("세이브");
        SaveData saveData = new SaveData();

        for (int i = 0; i < collectionNum; i++)
        {
            saveData.collections.Add(GameManager.instance.collections[i]);
        }
        
        for (int i = 0; i < GameManager.instance.oshogatsuCollections.Count; i++)
        {
            saveData.oshogatsuCollections.Add(GameManager.instance.oshogatsuCollections[i]);
        }

        for (int i = 0; i < GameManager.instance.setsubunCollections.Count; i++)
        {
            saveData.setsubunCollections.Add(GameManager.instance.setsubunCollections[i]);
        }

        //If finishing adding descriptions, this code will not be used. 
        for (int i = 0; i < collectionNum; i++)
        {
            saveData.collectionsProps.Add(GameManager.instance.collectionsProps[i]);
            saveData.collectionsDescriptions.Add(GameManager.instance.collectionsDescriptions[i]);
        }

        string json = JsonUtility.ToJson(saveData, true);

        File.WriteAllText(path, json);
    }

    public void AcquireCollection(string stage, int num)
    {
        int collectionIndex = -1;

        if (stage == "정월")
        {
            collectionIndex = GameManager.instance.oshogatsuCollections[num];
        }
        else
        {
            collectionIndex = GameManager.instance.setsubunCollections[num];
        }

        for (int i = 0; i < GameManager.instance.oshogatsuCollections.Count; i++)
        {
            if (GameManager.instance.oshogatsuCollections[i] == collectionIndex)
            {
                GameManager.instance.oshogatsuCollections.RemoveAt(i);
            }
        }

        for (int i = 0; i < GameManager.instance.setsubunCollections.Count; i++)
        {
            if (GameManager.instance.setsubunCollections[i] == collectionIndex)
            {
                GameManager.instance.setsubunCollections.RemoveAt(i);
            }
        }

        GameManager.instance.collections[collectionIndex] = true;
        JsonSave();

        Debug.Log(collectionIndex);

        vocabularyList.UpdateCollection();
    }

    public void RandomCollectionNum(string stage)
    {
        if (stage == "정월")
        {
            if (GameManager.instance.oshogatsuCollections.Count != 0)
            {
                randomNum = Random.Range(0, GameManager.instance.oshogatsuCollections.Count - 1);
            }
        }
        else
        {
            if (GameManager.instance.setsubunCollections.Count != 0)
            {
                randomNum = Random.Range(0, GameManager.instance.setsubunCollections.Count - 1);
            }
        }
    }

    public void TempPlusCollectionIndex()
    {
        if (tempStageIndex == 0)
        {
            tempStageIndex = 1;
            RandomCollectionNum("정월");
            AcquireCollection("정월", randomNum);
        }
        else
        {
            tempStageIndex = 0;
            RandomCollectionNum("세쓰분");
            AcquireCollection("세쓰분", randomNum);
        }
    }
}
