using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class LuaHuiDiao : MonoBehaviour
{
    [CSharpCallLua] //可以不加
    public delegate void CsCallLua(string keyCode);
    [CSharpCallLua] //可以不加
    public delegate void CsCallLua_MouseClick(GameObject go);

    void OnGUI()
    {
        KeyBoardEventCallBack();
    }

    void Update()
    {
        GameManager.luaenv.DoString("GameUpdate.Update()");


        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("鼠标单击");
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider)
            {
                CsCallLua_MouseClick mouseClick = GameManager.luaenv.Global.GetInPath<CsCallLua_MouseClick>("AgentManager.MouseClick");
                mouseClick(hit.collider.gameObject);
            }
        }
    }

    //键盘监听回调
    public void KeyBoardEventCallBack()
    {
        if (Event.current.rawType == EventType.KeyDown)
        {
            Event e = Event.current;
            e.Use(); // 防止执行多次
            //if (KeyCode.A <= e.keyCode && e.keyCode <= KeyCode.Z)
            if (KeyCode.Backspace <= e.keyCode && e.keyCode <= KeyCode.Joystick8Button19)
            {
                //Debug.Log(e.keyCode);
                CsCallLua csCallLua = GameManager.luaenv.Global.GetInPath<CsCallLua>("AgentManager.CsCallLua");
                csCallLua((e.keyCode).ToString());
            }
        }
    }

}
