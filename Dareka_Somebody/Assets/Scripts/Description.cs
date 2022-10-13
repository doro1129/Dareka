using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Description : MonoBehaviour
{
    public string NameofObject;

    public string describe(string obj_name)
    {
        if (obj_name == "SakuraTree")
        {
            return "Japanese term for cherry blossom trees. It has beautiful pink flowers in spring.";
        }
        else if(obj_name == "Cylinder")
        {
            return "A cylinder is a three-dimensional shape consisting of two parallel circular bases";
        }
        else if(obj_name == "Cube")
        {
            return "A cube is a solid shape with six square faces.";
        }
        else
        {
            return "something is going wrong.";
        }
    }
}
