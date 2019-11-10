---@class 游戏管理类
GameManager = GameManager or {}
local _M = GameManager


GameManager.floorList = {}

function _M.__init__()
    local floors = UnityEngine.GameObject.Find("Grid/floor").transform
    print_t(floors.childCount, "floors")

    for i = 1, floors.childCount, 1 do
        local child = floors:GetChild(i - 1)
        local floor = child.transform:GetComponent(typeof(CS.Shuai.Floor))
        GameManager.floorList[i] = floor
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
function GameManager.Click(gameObject)
    local element = gameObject.transform:GetComponent("Element")

    -- print_t(element, "element")
    -- print_t(element.id, "id")
    -- print_t(element.type, "type")


    -- 出口
    if element.type == CS.Shuai.Element.ElementType.Exit then
        GameManager.Click_exit(element)
    -- 门
    elseif element.type == CS.Shuai.Element.ElementType.Door then
        GameManager.Click_door(element)
    -- 道具
    elseif element.type == CS.Shuai.Element.ElementType.Item then
        GameManager.Click_item(element)
    -- 敌人
    elseif element.type == CS.Shuai.Element.ElementType.Enemy then
        GameManager.Click_enemy(element)
    end


    GameManager.RefreshFloor(SB.floor)
    HudPanel:Refresh()
end

-- 出口
function GameManager.Click_exit(element)
    if element.id == 1 then
        SB.floor = SB.floor + 1
        TipManager.Show("上一层")
    elseif element.id == 2 then
        SB.floor = SB.floor - 1
        TipManager.Show("下一层")
    end
end

-- 门
function GameManager.Click_door(element)
    if element.id == 1 then
        if SB.key1 >= 1 then
            SB.key1 = SB.key1 - 1
            UnityEngine.Object.DestroyImmediate(element.gameObject)
        else
            TipManager.Show("钥匙1不足")
        end
    elseif element.id == 2 then
        if SB.key2 >= 1 then
            SB.key2 = SB.key2 - 1
            UnityEngine.Object.DestroyImmediate(element.gameObject)
        else
            TipManager.Show("钥匙2不足")
        end
    elseif element.id == 3 then
        if SB.key3 >= 1 then
            SB.key3 = SB.key3 - 1
            UnityEngine.Object.DestroyImmediate(element.gameObject)
        else
            TipManager.Show("钥匙3不足")
        end
    elseif element.id == 4 then
        if SB.key4 >= 1 then
            SB.key4 = SB.key4 - 1
            UnityEngine.Object.DestroyImmediate(element.gameObject)
        else
            TipManager.Show("钥匙4不足")
        end
    end
end

-- 道具
function GameManager.Click_item(element)
    -- 宝石
    if element.id == 1 then -- 红宝石
        SB.atk = SB.atk + 3
    elseif element.id == 2 then -- 紫宝石
        SB.def = SB.def + 3
    elseif element.id == 3 then -- 绿宝石
        SB.def = SB.def + 1
    elseif element.id == 4 then -- 黄宝石
        SB.def = SB.def + 1
    
    -- 血瓶
    elseif element.id == 5 then -- 红血瓶
        SB.hp = SB.hp + 100
    elseif element.id == 6 then -- 紫血瓶
        SB.hp = SB.hp + 200
    elseif element.id == 7 then -- 绿血瓶
        SB.hp = SB.hp + 300
    elseif element.id == 8 then -- 黄血瓶
        SB.hp = SB.hp + 400

    -- 钥匙
    elseif element.id == 15 then -- 黄钥匙
        SB.key1 = SB.key1 + 1
    elseif element.id == 16 then -- 紫钥匙
        SB.key2 = SB.key2 + 1
    elseif element.id == 17 then -- 红钥匙
        SB.key3 = SB.key3 + 1
    elseif element.id == 18 then -- 绿钥匙 暂时没有
        -- SB.key4 = SB.key4 + 1

    else
        return
    end

    UnityEngine.Object.DestroyImmediate(element.gameObject)
end

-- 敌人
function GameManager.Click_enemy(element)
    local enemyList = array.filter(
        data_enemy,
        function(item)
            return element.id == item.id
        end
    )

    print_t(enemyList, "enemyList")
    
    local enemy = enemyList[1]

    SB.hp = SB.hp - enemy.atk
    SB.gold = SB.gold + enemy.gold


    UnityEngine.Object.DestroyImmediate(element.gameObject)
end


GameManager.__init__()