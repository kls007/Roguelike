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
        -- _M.view[i].backgroundList = 
        -- {
        --     transform:Find("background/background1"),
        --     transform:Find("background/background2"),
        --     transform:Find("background/background3"),
        --     transform:Find("background/background4"),
        -- }
        -- local random = math.random(1, 4)
        -- for index, value in ipairs(_M.view[i].backgroundList) do
        --     value.gameObject:SetActive(index == random)
        -- end
        
        
        self.cell1= {
        gameObject = transform:Find("ground/-$cell1").gameObject,
        self.cell1 = transform:Find("ground/-$cell1");
        Image_background = transform:Find("ground/-$cell1/$background"):GetComponent("Image"),
        self.monster = transform:Find("ground/-$cell1/$monster");
        Image_headicon = transform:Find("ground/-$cell1/$monster/$headicon"):GetComponent("Image"),
        Image_frame = transform:Find("ground/-$cell1/$monster/$frame"):GetComponent("Image"),
        Image_atk = transform:Find("ground/-$cell1/$monster/$atk"):GetComponent("Image"),
        Text_atk_value = transform:Find("ground/-$cell1/$monster/$atk/$atk_value"):GetComponent("Text"),
        Image_hp = transform:Find("ground/-$cell1/$monster/$hp"):GetComponent("Image"),
        Text_hp_value = transform:Find("ground/-$cell1/$monster/$hp/$hp_value"):GetComponent("Text"),
        Image_def = transform:Find("ground/-$cell1/$monster/$def"):GetComponent("Image"),
        Text_def_value = transform:Find("ground/-$cell1/$monster/$def/$def_value"):GetComponent("Text"),
        }
        self.cell2= {
        gameObject = transform:Find("ground/-$cell2").gameObject,
        self.cell2 = transform:Find("ground/-$cell2");
        Image_background = transform:Find("ground/-$cell2/$background"):GetComponent("Image"),
        self.monster = transform:Find("ground/-$cell2/$monster");
        Image_headicon = transform:Find("ground/-$cell2/$monster/$headicon"):GetComponent("Image"),
        Image_frame = transform:Find("ground/-$cell2/$monster/$frame"):GetComponent("Image"),
        Image_atk = transform:Find("ground/-$cell2/$monster/$atk"):GetComponent("Image"),
        Text_atk_value = transform:Find("ground/-$cell2/$monster/$atk/$atk_value"):GetComponent("Text"),
        Image_hp = transform:Find("ground/-$cell2/$monster/$hp"):GetComponent("Image"),
        Text_hp_value = transform:Find("ground/-$cell2/$monster/$hp/$hp_value"):GetComponent("Text"),
        Image_def = transform:Find("ground/-$cell2/$monster/$def"):GetComponent("Image"),
        Text_def_value = transform:Find("ground/-$cell2/$monster/$def/$def_value"):GetComponent("Text"),
        }
        self.cell3= {
        gameObject = transform:Find("ground/-$cell3").gameObject,
        self.cell3 = transform:Find("ground/-$cell3");
        Image_background = transform:Find("ground/-$cell3/$background"):GetComponent("Image"),
        self.monster = transform:Find("ground/-$cell3/$monster");
        Image_headicon = transform:Find("ground/-$cell3/$monster/$headicon"):GetComponent("Image"),
        Image_frame = transform:Find("ground/-$cell3/$monster/$frame"):GetComponent("Image"),
        Image_atk = transform:Find("ground/-$cell3/$monster/$atk"):GetComponent("Image"),
        Text_atk_value = transform:Find("ground/-$cell3/$monster/$atk/$atk_value"):GetComponent("Text"),
        Image_hp = transform:Find("ground/-$cell3/$monster/$hp"):GetComponent("Image"),
        Text_hp_value = transform:Find("ground/-$cell3/$monster/$hp/$hp_value"):GetComponent("Text"),
        Image_def = transform:Find("ground/-$cell3/$monster/$def"):GetComponent("Image"),
        Text_def_value = transform:Find("ground/-$cell3/$monster/$def/$def_value"):GetComponent("Text"),
        }
        self.cell4= {
        gameObject = transform:Find("ground/-$cell4").gameObject,
        self.cell4 = transform:Find("ground/-$cell4");
        Image_background = transform:Find("ground/-$cell4/$background"):GetComponent("Image"),
        self.monster = transform:Find("ground/-$cell4/$monster");
        Image_headicon = transform:Find("ground/-$cell4/$monster/$headicon"):GetComponent("Image"),
        Image_frame = transform:Find("ground/-$cell4/$monster/$frame"):GetComponent("Image"),
        Image_atk = transform:Find("ground/-$cell4/$monster/$atk"):GetComponent("Image"),
        Text_atk_value = transform:Find("ground/-$cell4/$monster/$atk/$atk_value"):GetComponent("Text"),
        Image_hp = transform:Find("ground/-$cell4/$monster/$hp"):GetComponent("Image"),
        Text_hp_value = transform:Find("ground/-$cell4/$monster/$hp/$hp_value"):GetComponent("Text"),
        Image_def = transform:Find("ground/-$cell4/$monster/$def"):GetComponent("Image"),
        Text_def_value = transform:Find("ground/-$cell4/$monster/$def/$def_value"):GetComponent("Text"),
        }






        _M.view[i].monster = {}
        _M.view[i].monster.gameObject = transform:Find("monster").gameObject
        _M.view[i].monster.headicon = transform:Find("monster/headicon").gameObject
        _M.view[i].monster.frame = transform:Find("monster/frame"):GetComponent(typeof(UnityEngine.UI.Image))

        
        _M.view[i].monster.frame_SpriteRes = transform:Find("monster/frame"):GetComponent(typeof(CS.Shuai.SpriteRes))
        local random = math.random(1, 3)
        print_t(_M.view[i].monster.frame_SpriteRes.spriteList, "_M.view[i].monster.frame_spriteList")
        -- print_t(_M.view[i].monster.frame_spriteList.spriteList[1], "_M.view[i].monster.frame_spriteList")

        _M.view[i].monster.frame.sprite = _M.view[i].monster.frame_SpriteRes.spriteList[random - 1]
        
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