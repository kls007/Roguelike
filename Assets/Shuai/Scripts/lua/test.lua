test = test or {}
local _M = test

_M.view = {}

local row = 13 -- 7
local col = 13 -- 8
local count = row * col

local player =
{
    id = 1,
    name = "玩家",
    level = 1,
    atk_value = 1,
    hp_value = 1,
    def_value = 1,
}

function _M.__init__()
    _M.view.gameObject = UnityEngine.GameObject.Find("Canvas/Root_Panel/GamePanel").gameObject
    _M.view.transform = _M.view.gameObject.transform
    local parent = _M.view.transform:Find("$ground");
    local prefab = parent.transform:GetChild(0).gameObject
    functions.SetActiveAllChildren(parent, false)
    for index = 1, count, 1 do
        local gameObject = UnityEngine.GameObject.Instantiate(prefab)
        local transform = gameObject.transform
        gameObject:SetActive(true)
        gameObject.name = "cell_" .. index
        transform.parent = parent.transform

        local cell = _M.GetCell(gameObject.transform)

        cell.headicon = math.random(1, cell.SpriteRes_headicon.spriteList.Count)
        cell.level = math.random(1, cell.SpriteRes_frame.spriteList.Count)
        
        cell.atk_value = math.random(1, 10)
        cell.hp_value = math.random(1, 10)
        cell.ef_value = math.random(1, 10)

        _M.InitCell(cell)

        UnityEngine.EventTriggerListener.Get(cell.Image_background.gameObject, index).onClick = function()
            -- TipManager.Show(index)

            if cell.hp_value <= 0 then
                TipManager.Show("该怪物已死亡")
                return
            end

            cell.hp_value = cell.hp_value - player.atk_value
            if cell.hp_value <= 0 then
                cell.hp_value = 0
                _M.DeadCell(cell)
            end
            _M.RefreshEnergy(cell)

            cell.Animator_hurt:Play("Attack_Animation")
        end
    end
end

function _M.InitCell(cell)
    cell.Image_dead.gameObject:SetActive(false)

    local bg = math.random(1, cell.SpriteRes_background.spriteList.Count)
    cell.Image_background.sprite = cell.SpriteRes_background.spriteList[bg - 1]

    cell.Image_headicon.sprite = cell.SpriteRes_headicon.spriteList[cell.headicon - 1]
    cell.Image_frame.sprite = cell.SpriteRes_frame.spriteList[cell.level - 1]
    
    _M.RefreshEnergy(cell)
end

function _M.RefreshEnergy(cell)
    cell.Text_atk_value.text = cell.atk_value
    cell.Text_hp_value.text = cell.hp_value
    cell.Text_def_value.text = cell.def_value
end

function _M.DeadCell(cell)
    cell.Image_dead.gameObject:SetActive(true)
end

function _M.GetCell(transform)
    local self = {}

    self.id = 1
    self.name = "椎命由奈"
    self.level = 1
    self.atk_value = 1
    self.hp_value = 1
    self.def_value = 1

    -- self.ground = transform:Find("$ground");
    -- self.cell = transform:Find("$ground/$cell");
    self.Image_background = transform:Find("$background"):GetComponent("Image");
    self.SpriteRes_background = transform:Find("$background"):GetComponent("SpriteRes");
    self.monster = transform:Find("$monster");
    self.Image_headicon = transform:Find("$monster/$headicon"):GetComponent("Image");
    self.SpriteRes_headicon = transform:Find("$monster/$headicon"):GetComponent("SpriteRes");
    self.Image_frame = transform:Find("$monster/$frame"):GetComponent("Image");
    self.SpriteRes_frame = transform:Find("$monster/$frame"):GetComponent("SpriteRes");
    self.Image_atk = transform:Find("$monster/$atk"):GetComponent("Image");
    self.Text_atk_value = transform:Find("$monster/$atk/$atk_value"):GetComponent("Text");
    self.Image_hp = transform:Find("$monster/$hp"):GetComponent("Image");
    self.Text_hp_value = transform:Find("$monster/$hp/$hp_value"):GetComponent("Text");
    self.Image_def = transform:Find("$monster/$def"):GetComponent("Image");
    self.Text_def_value = transform:Find("$monster/$def/$def_value"):GetComponent("Text");
    self.Image_hurt = transform:Find("$hurt"):GetComponent("Image");
    self.Animator_hurt = transform:Find("$hurt"):GetComponent("Animator");
    self.Image_dead = transform:Find("$dead"):GetComponent("Image");


    return self
end

_M.__init__()