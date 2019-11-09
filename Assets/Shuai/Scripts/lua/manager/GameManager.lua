---@class 游戏管理类
GameManager = GameManager or {}
local _M = GameManager


GameManager.floorList = {}

function _M.__init__()
    local floors = UnityEngine.GameObject.Find("Grid/floor").transform:GetComponentsInChildren(typeof(CS.Floor))

    for i = 1, floors.Length, 1 do
        GameManager.floorList[i] = floors[i - 1]
    end

    print_t(GameManager.floorList, "GameManager.floorList")
    GameManager.RefreshFloor(SB.floor)
end

-- 刷新第几层内容
function GameManager.RefreshFloor(floor)
    for index, value in ipairs(GameManager.floorList) do
        value.gameObject:SetActive(false)
    end
    GameManager.floorList[floor].gameObject:SetActive(true)
end

-- 主函数
function GameManager.Main(gameObject)

    local item = gameObject.transform:GetComponent("Element")
    local exit = gameObject.transform:GetComponent("Exit")
    print_t(exit, "exit")
    print_t(item, "item")
    print_t(item.id, "id")
    print_t(item.type, "type")

    if item.id == 1 then
        SB.floor = SB.floor + 1
        TipManager.Show("上一层")
    elseif item.id == 2 then
        SB.floor = SB.floor - 1
        TipManager.Show("下一层")
    end

    GameManager.RefreshFloor(SB.floor)
    HudPanel:Refresh()

do return end


    -- 门
    if item.id == 1 then
        if SB.key1 >= 1 then
            SB.key1 = SB.key1 - 1
        else
            TipManager.Show("钥匙1不足")
            return
        end
    elseif item.id == 2 then
        if SB.key2 >= 1 then
            SB.key2 = SB.key2 - 1
        else
            TipManager.Show("钥匙2不足")
            return
        end
    end

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
    end
    

    UnityEngine.Object.DestroyImmediate(gameObject)
    HudPanel:Refresh()


    -- Event.Dispatch("KeyboardEvent", {keyCode = keyCode})
    -- tools.trycatch(ShuaiTest.Refresh, {params = {keyCode = keyCode}, errorMode = true})
end

GameManager.__init__()