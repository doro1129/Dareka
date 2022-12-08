using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

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
    public List<Sprite> collectionsProps = new List<Sprite>();

    public GameObject vocabulary;
    VocabularyList vocabularyList;

    string path;
    int diff;

    void Start()
    {
        path = Path.Combine(Application.dataPath, "database.json");
        diff = (collectionNum - commonNum) / 2;

        JsonLoad();

        if (vocabulary != null)
        {
            vocabularyList = vocabulary.GetComponent<VocabularyList>();
            vocabularyList.UpdateCollection();
        }
    }

    private void JsonLoad()
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

            GameManager.instance.collectionsProps.Add("다이어리");
            GameManager.instance.collectionsDescriptions.Add("잠겨있다. 열려면 비밀번호가 필요할 것 같다. 아래에 뭐하고 있어(なにしてる)?라 적혀있다."
                + System.Environment.NewLine
                + "이게 비밀번호일까?");

            GameManager.instance.collectionsProps.Add("달력");
            GameManager.instance.collectionsDescriptions.Add("12월 21일에 동그라미가 쳐져있고, '코하루(小春)'라고 적혀있다."
                + System.Environment.NewLine
                + "‘무슨 날짜지? 우리 엄마 이름이 코하루인데…’");

            GameManager.instance.collectionsProps.Add("지도");
            GameManager.instance.collectionsDescriptions.Add("좌표 번호가 있다."
                + System.Environment.NewLine
                + "[35, 89]: 후지병원 [58, 93]: 시카공원"
                + System.Environment.NewLine
                + "[93, 85]: 히츠키절 [39, 85]: 사토시청");

            GameManager.instance.collectionsProps.Add("풍경(風鈴)");
            GameManager.instance.collectionsDescriptions.Add("바람이 불 때마다 청량한 소리가 들린다."
                + System.Environment.NewLine
                + "여름철에 처마끝이나 창문에 매단다."
                + System.Environment.NewLine
                + "엄마가 모으던 풍경 중 하나다.");

            GameManager.instance.collectionsProps.Add("마네키네코");
            GameManager.instance.collectionsDescriptions.Add("한 손을 들어 사람을 부르는 듯한 모습을 하고 있는 고양이 장식품이다."
                + System.Environment.NewLine
                + "어느 손을 들고 있는지, 무엇을 가지고 있는지에 따라 그 복의 종류가 달라진다."
                + System.Environment.NewLine
                + "예를 들어, 금화나 도미 등의 물고기를 들고 있으면 부와 번영의 상징으로 여겨지며, 부채 또는 북을 가지고 있으면 장사 번성을 상징한다고 알려져있다.");

            GameManager.instance.collectionsProps.Add("테루테루보즈(てるてる坊主)");
            GameManager.instance.collectionsDescriptions.Add("맑은 날씨를 불러온다는 일본의 인형이다."
                + System.Environment.NewLine
                + "처마 밑에 걸어두면 날씨가 맑아지지만, 거꾸로 매달아 놓으면 비가 내린다고 한다.");

            GameManager.instance.collectionsProps.Add("다루마");
            GameManager.instance.collectionsDescriptions.Add("인도에서 중국에 불교를 전한 승려인 달마의 좌선 모습을 모방하여 만든 일본의 장식물이다."
                + System.Environment.NewLine
                + "넘어져도 다시 일어나는 모습에서 인내와 노력의 상징으로 삼기도 한다.");

            GameManager.instance.collectionsProps.Add("하고이타/하고");
            GameManager.instance.collectionsDescriptions.Add("하고이타(羽子板)로 하네(羽根)를 주고받는 하네츠키라 불리는 놀이에서 사용되는 판자와 공이다."
                + System.Environment.NewLine
                + "하고이타는 오시에(押絵)라 불리는 전통적인 수예로 장식하기도 한다.");

            GameManager.instance.collectionsProps.Add("오세치");
            GameManager.instance.collectionsDescriptions.Add("다양한 음식을 찬합에 담아, 새해 아침에 떡국인 오조니(お雑煮)와 가족, 손님들과 함께 먹는 음식이다. 보통 연말에 미리 만들어두고 1월 1일에 새해를 축하하며 먹는다."
                + System.Environment.NewLine
                + "재료로 사용되는 식재료에 각각의 의미가 부여되어 있는 것이 특징이다."
                + System.Environment.NewLine
                + "검은 콩은 건강, 말린 청어알은 번영, 다시마는 좋은 일, 밤은 풍요로움, 도미는 경사, 새우는 장수, 연근은 지혜를 의미한다.");

            GameManager.instance.collectionsProps.Add("카가미모치");
            GameManager.instance.collectionsDescriptions.Add("크고 작은 2개의 떡을 겹쳐서 만들어진 장식품이다."
                + System.Environment.NewLine
                + "매년 1월 1일에 방문한다고 여겨지는 도시가미라는 신을 맞이하기 위해 장식한다."
                + System.Environment.NewLine
                + "생긴 모습이 보름달과 같아 가정 평화의 상징이라고 여겨지기도 한다."
                + System.Environment.NewLine
                + "1월 11일에는 가가미비라키라는 이 떡을 칼로 자르지 않고 손이나 망치로 찢고 먹는 행위를 통해 도시가미에게 장수를 기원하기도 한다.");

            GameManager.instance.collectionsProps.Add("켄다마");
            GameManager.instance.collectionsDescriptions.Add("십자 모양의 손잡이와 공이 실로 연결되어 있는 장난감이다."
                + System.Environment.NewLine
                + "다마(玉)라고 부르는 공을 꼬챙이에 끼우거나 그릇 모양 판(사라)에 올리는 등 다양한 기술이 있다.");

            GameManager.instance.collectionsProps.Add("오니가면");
            GameManager.instance.collectionsDescriptions.Add("일본의 전설 속에 존재하는 오니라는 요괴의 가면이다."
                + System.Environment.NewLine
                + "곱슬거리는 머리카락에 뿔이 한 개 또는 두 개가 있으며 파란색, 빨간색 등 다양한 피부색을 가진 것이 특징이다."
                + System.Environment.NewLine
                + "세쓰분에는 오니를 향해 콩을 던지며 '오니는 밖으로, 복은 안으로(鬼は外、福は内)'를 외친다."
                + System.Environment.NewLine
                + "아빠가 이 무서운 가면을 쓰고 나와 놀아줬다.");

            GameManager.instance.collectionsProps.Add("에호마키(恵方巻)");
            GameManager.instance.collectionsDescriptions.Add("세쓰분에 먹는 일본식 김밥이다. 7가지의 복을 부른다는 의미로 7가지의 재료가 들어간다."
                + System.Environment.NewLine
                + "붕장어(집중력), 박고지(집중력), 생선가루(애정운), 계란(금전운), 새우(일운), 오이(건강운), 게맛살(일운) 등 각자 의미를 가진 재료를 취향에 따라 넣는다."
                + System.Environment.NewLine
                + "매해 바뀌는 복(恵)이 오는 방향(方)을 향해서 먹음으로써 복을 내 안으로 끌어들이고자 하는 의미를 가진다.");

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

    private void JsonSave()
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

    private int AcquireCollection(int num)
    {
        int collectionIndex;

        if (SceneManager.GetActiveScene().buildIndex == 3 && GameManager.instance.oshogatsuCollections.Count > 0 && num >= 0)
        {
            collectionIndex = GameManager.instance.oshogatsuCollections[num];
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4 && GameManager.instance.setsubunCollections.Count > 0 && num >= 0)
        {
            collectionIndex = GameManager.instance.setsubunCollections[num];
        }
        else
        {
            Debug.Log("Finished Collection");
            return -1;
        }

        Debug.Log(collectionIndex);

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

        return collectionIndex;
    }

    private int RandomCollectionNum()
    {
        int randomNum = -1;
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (GameManager.instance.oshogatsuCollections.Count != 0)
            {
                randomNum = Random.Range(0, GameManager.instance.oshogatsuCollections.Count);
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            if (GameManager.instance.setsubunCollections.Count != 0)
            {
                randomNum = Random.Range(0, GameManager.instance.setsubunCollections.Count);
            }
        }

        return randomNum;
    }

    public int Collect()
    {
        return AcquireCollection(RandomCollectionNum());
    }
}
