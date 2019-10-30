test = test or {}
local _M = test

function _M.__init__()
    -- print("test.__init__()")



    local transform = UnityEngine.GameObject.Find("Canvas/Root_Panel/GamePanel").transform


    local cells = UnityEngine.GameObject.FindGameObjectsWithTag("Cell")
    print_t(cells.Length, "cells")

    _M.view = {}
    for i = 1, cells.Length, 1 do
        local gameObject = cells[i - 1]
        local transform = gameObject.transform
        _M.view[i] = {}
        _M.view[i].gameObject = gameObject
        _M.view[i].transform = transform

        _M.view[i].background = transform:Find("background")
        _M.view[i].backgroundList = 
        {
            transform:Find("background/background1"),
            transform:Find("background/background2"),
            transform:Find("background/background3"),
            transform:Find("background/background4"),
        }
        local random = math.random(1, 4)
        for index, value in ipairs(_M.view[i].backgroundList) do
            value.gameObject:SetActive(index == random)
        end
        

        _M.view[i].monster = {}
        _M.view[i].monster.gameObject = transform:Find("monster").gameObject
        _M.view[i].monster.headicon = transform:Find("monster/headicon").gameObject
        _M.view[i].monster.frame = transform:Find("monster/frame"):GetComponent(typeof(UnityEngine.UI.Image))

        print_t(_M.view[i].monster.frame, "_M.view[i].monster.frame")
        
        -- _M.view[i].monster.frame_spriteList = transform:Find("monster/frame"):GetComponent(UnityEngine.SpriteList)
        -- local random = math.random(1, 3)

        
    end


    -- print_t(_M.view, "_M.view")

    -- local buttons_c = _M.view.enemy.transform:GetComponentsInChildren(typeof(UnityEngine.UI.Button))
    -- _M.view.buttons_lua = {}
    -- for i = 1, buttons_c.Length, 1 do
    --     _M.view.buttons_lua[i] = buttons_c[i - 1]
    -- end

    -- for index, value in ipairs(_M.view.buttons_lua) do
    --     UnityEngine.EventTriggerListener.Get(value.gameObject, index).onClick = function()
    --         TipManager.Show(index)
    --     end
    -- end
    

end


_M.__init__()