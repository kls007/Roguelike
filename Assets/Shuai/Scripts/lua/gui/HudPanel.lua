---@class HudPanel
-- HudPanel = PanelClass:new() or {}
HudPanel = HudPanel or {}
local _M = HudPanel

-- _M.prefabName = "HudPanel"
local gameObject
local transform

function _M:__init__()
    _M:InitView()
    _M:Main()
end

function _M:InitView()
    gameObject = UnityEngine.GameObject.Find("Canvas/Root_Panel/HudPanel").gameObject
    transform = gameObject.transform

    self.Image_bg = transform:Find("$bg"):GetComponent("Image");
    self.Text_floor_value = transform:Find("$bg/floor/$floor_value"):GetComponent("Text");
    self.Text_hp_value = transform:Find("$bg/attribute/hp/$hp_value"):GetComponent("Text");
    self.Text_atk_value = transform:Find("$bg/attribute/atk/$atk_value"):GetComponent("Text");
    self.Text_def_value = transform:Find("$bg/attribute/def/$def_value"):GetComponent("Text");
    self.Text_money_value = transform:Find("$bg/attribute/money/$money_value"):GetComponent("Text");
    self.Text_key1_value = transform:Find("$bg/item/key1/$key1_value"):GetComponent("Text");
    self.Text_key2_value = transform:Find("$bg/item/key2/$key2_value"):GetComponent("Text");
    self.Text_key3_value = transform:Find("$bg/item/key3/$key3_value"):GetComponent("Text");
end

function _M:Main()
    self:Refresh()

    -- UnityEngine.EventTriggerListener.Get(self.view.Button_close.gameObject, nil).onClick = function()
    --     _M:Destroy()
    -- end

    -- UnityEngine.EventTriggerListener.Get(self.view.Button_cancel.gameObject, nil).onClick = function()
    --     _M:Destroy()
    -- end
end

function _M:Refresh()
    self.Text_floor_value.text = SB.floor

    self.Text_hp_value.text = SB.hp
    self.Text_atk_value.text = SB.atk
    self.Text_def_value.text = SB.def
    self.Text_money_value.text = SB.money

    self.Text_key1_value.text = SB.key1
    self.Text_key2_value.text = SB.key2
    self.Text_key3_value.text = SB.key3
end

_M:__init__()