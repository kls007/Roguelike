using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace Shuai
{
    [LuaCallCSharp]
    public class Element : MonoBehaviour
    {
        public enum ElementType
        {
            Exit,
            Door,
            Item,
            Enemy,
        };

        public int id = 1;
        public ElementType type;
        public string name = ""; //名称
        public string info = ""; //描述
    }
}
