using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Description : MonoBehaviour
{
    public string NameofObject;

    public string describe(string obj_name)
    {
        if (obj_name == "다루마")
        {
            //https://ja.wikipedia.org/wiki/%E3%81%A0%E3%82%8B%E3%81%BE
            return "인도에서 중국에 불교를 전한 승려인 달마의 좌선 모습을 모방하여 만든 일본의 장식물.";
        }
        else if(obj_name == "하고이타")
        {
            //http://iroha-japan.net/iroha/B04_play/05_hane.html
            return "하네(羽根)를 주고받는 하네츠키(羽根つき)라 불리는 놀이에서 사용되는 라켓 모양의 판자." +
                " 오시에(押?)라 불리는 전통적인 수예로 장식하기도 한다.";
        }
        else if(obj_name == "가가미모치")
        {
            //https://ja.wikipedia.org/wiki/%E9%8F%A1%E9%A4%85
            return "찹쌀로 만든 전통 떡을 신불에 바치는 정월 장식이다. 곡물신인 도시가미에게 바치며 도시가미가 깃드는 매개체이기도 하다. ";
        }
        else
        {
            return "something is going wrong.";
        }
    }
}
