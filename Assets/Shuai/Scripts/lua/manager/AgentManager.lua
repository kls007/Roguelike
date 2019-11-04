---@class CStoLua中间件
AgentManager = AgentManager or {}
local _M = AgentManager

function _M.__init__()
    Event.AddListener("KeyboardEvent", function(params)
        -- print_t(params, "params")

        local keyCode = params.keyCode

        local move = 1
        if keyCode == "UpArrow" then
            -- TipManager.Show("上")
            local pos = GameManager.player.transform.position
            GameManager.player.transform.position = UnityEngine.Vector3(pos.x, pos.y + move, pos.z)
        
        elseif keyCode == "DownArrow" then
            -- TipManager.Show("下")
            local pos = GameManager.player.transform.position
            GameManager.player.transform.position = UnityEngine.Vector3(pos.x, pos.y - move, pos.z)
        
        elseif keyCode == "LeftArrow" then
            -- TipManager.Show("左")
            local pos = GameManager.player.transform.position
            GameManager.player.transform.position = UnityEngine.Vector3(pos.x - move, pos.y, pos.z)
        
        elseif keyCode == "RightArrow" then
            -- TipManager.Show("右")
            local pos = GameManager.player.transform.position
            GameManager.player.transform.position = UnityEngine.Vector3(pos.x + move, pos.y, pos.z)
        end

    end)
end

function _M.CsCallLua(keyCode)
    -- print(params)
    -- TipManager.Show(keyCode)

    Event.Dispatch("KeyboardEvent", {keyCode = keyCode})

    tools.trycatch(ShuaiTest.Refresh, {params = {keyCode = keyCode}, errorMode = true})
end


function _M.MouseClick(gameObject)
    -- print_t(gameObject, "gameObject")
    -- print_t(gameObject.tag, "tag")

    local item = gameObject.transform:GetComponent("Item")
    print_t(item, "item")
    print_t(item.id, "id")
    print_t(item.type, "type")

    -- 钥匙
    if item.id == 101 then
        SB.key1 = SB.key1 + 1
    elseif item.id == 102 then
        SB.key2 = SB.key2 + 1
    elseif item.id == 102 then
        SB.key3 = SB.key3 + 1

    -- 攻防
    elseif item.id == 201 then
        SB.atk = SB.atk + 1
    elseif item.id == 202 then
        SB.def = SB.def + 1

    -- hp血瓶
    elseif item.id == 301 then
        SB.hp = SB.hp + 100
    elseif item.id == 302 then
        SB.hp = SB.hp + 200

    -- 门
    elseif item.id == 3 then
        if SB.key1 >= 1 then
            SB.key1 = SB.key1 - 1
        else
            TipManager.Show("钥匙1不足")
            return
        end
    elseif item.id == 4 then
        if SB.key2 >= 1 then
            SB.key2 = SB.key2 - 1
        else
            TipManager.Show("钥匙2不足")
            return
        end
    end

    UnityEngine.Object.DestroyImmediate(gameObject)
    HudPanel:Refresh()


    -- Event.Dispatch("KeyboardEvent", {keyCode = keyCode})
    -- tools.trycatch(ShuaiTest.Refresh, {params = {keyCode = keyCode}, errorMode = true})
end

_M.__init__()