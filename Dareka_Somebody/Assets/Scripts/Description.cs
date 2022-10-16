using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Description : MonoBehaviour
{
    public string NameofObject;

    public string describe(string obj_name)
    {
        if (obj_name == "�ٷ縶")
        {
            //https://ja.wikipedia.org/wiki/%E3%81%A0%E3%82%8B%E3%81%BE
            return "�ε����� �߱��� �ұ��� ���� �·��� �޸��� �¼� ����� ����Ͽ� ���� �Ϻ��� ��Ĺ�.";
        }
        else if(obj_name == "�ϰ���Ÿ")
        {
            //http://iroha-japan.net/iroha/B04_play/05_hane.html
            return "�ϳ�(����)�� �ְ�޴� �ϳ���Ű(���ƪĪ�)�� �Ҹ��� ���̿��� ���Ǵ� ���� ����� ����." +
                " ���ÿ�(��?)�� �Ҹ��� �������� ������ ����ϱ⵵ �Ѵ�.";
        }
        else if(obj_name == "�����̸�ġ")
        {
            //https://ja.wikipedia.org/wiki/%E9%8F%A1%E9%A4%85
            return "���ҷ� ���� ���� ���� �źҿ� ��ġ�� ���� ����̴�. ����� ���ð��̿��� ��ġ�� ���ð��̰� ���� �Ű�ü�̱⵵ �ϴ�. ";
        }
        else
        {
            return "something is going wrong.";
        }
    }
}
