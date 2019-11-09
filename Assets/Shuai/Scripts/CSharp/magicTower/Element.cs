using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

[LuaCallCSharp]
public class Element : MonoBehaviour
{
    public int id = 1;
    public int type = 1;
    public string name = ""; //名称
    public string info = ""; //描述
}
