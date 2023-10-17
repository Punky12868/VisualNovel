using System;
using UnityEngine;
using UnityEngine.UI;

namespace PixelCrushers
{

    /// This is a starter template for Save System savers. To use it,
    /// make a copy, rename it, and remove the line marked above.
    /// Then fill in your code where indicated below.
    public class VariableSaver : Saver // Rename this class.
    {

        [Serializable]
        public class Data
        {
            public int bg;

            public int txtbox;
            public float txtbox_opacityValue;

            public int spr_one;

            public float spr_one_opacityValue;
            public float spr_one_colorValue;

            public int spr_one_position;

            public int spr_two;

            public float spr_two_opacityValue;
            public float spr_two_colorValue;

            public int spr_two_position;

            public string npcName;
            public string catName;

            public Image[] slotImage_holder;
        }
        public override string RecordData()
        {
            var playerStats = GetComponent<VariableHolder>();

            var data = new Data();

            data.npcName = playerStats.gameAssets.currentNpcName;
            data.catName = playerStats.gameAssets.catName;

            data.slotImage_holder = playerStats.slotImage_holder;

            for (int i = 0; i < data.slotImage_holder.Length; i++)
            {
                data.slotImage_holder[i].sprite = playerStats.slotImage_holder[i].sprite;
            }
            foreach (var bg in playerStats.gameAssets.backgrounds)
            {
                if (playerStats.gameAssets.currentBG.sprite.name == bg.name)
                {
                    data.bg = Array.IndexOf(playerStats.gameAssets.backgrounds, bg);
                    break;
                }
            }
            foreach (var sprite in playerStats.gameAssets.npcSrites)
            {
                if (playerStats.gameAssets.currentSpriteOne.sprite.name == sprite.name)
                {
                    data.spr_one = Array.IndexOf(playerStats.gameAssets.npcSrites, sprite);
                    break;
                }
            }
            foreach (var sprite in playerStats.gameAssets.npcSrites)
            {
                if (playerStats.gameAssets.currentSpriteTwo.sprite.name == sprite.name)
                {
                    data.spr_two = Array.IndexOf(playerStats.gameAssets.npcSrites, sprite);
                    break;
                }
            }
            foreach (var textbox in playerStats.gameAssets.textboxSprites)
            {
                if (playerStats.gameAssets.currentTextbox.sprite.name == textbox.name)
                {
                    data.txtbox = Array.IndexOf(playerStats.gameAssets.textboxSprites, textbox);
                    break;
                }
            }

            data.txtbox_opacityValue = playerStats.txtBox_value.fadeTxtBoxValue;

            data.spr_one_opacityValue = playerStats.spr_one_values.fadeSPRValue;
            data.spr_one_colorValue = playerStats.spr_one_values.colorSPRValue;
            data.spr_one_position = playerStats.spr_pos_values.spriteOnePosIndex;

            data.spr_two_opacityValue = playerStats.spr_two_values.fadeSPRValue;
            data.spr_two_colorValue = playerStats.spr_two_values.colorSPRValue;
            data.spr_two_position = playerStats.spr_pos_values.spriteTwoPosIndex;
            return SaveSystem.Serialize(data);
        }

        public override void ApplyData(string s)
        {
            Debug.Log("AP¨PLYDATAAAAAAAAAAA BLYAAAAAAAAAAAAAAD");
            if (string.IsNullOrEmpty(s)) return; // If we didn't receive any save data, exit immediately.
            var data = SaveSystem.Deserialize<Data>(s);
            if (data == null) return; // If save data is invalid, exit immediately.

            var playerStats = GetComponent<VariableHolder>();

            //------------------------------------------------------------------------------------------- BG

            playerStats.bg.sprite = playerStats.gameAssets.backgrounds[data.bg];

            //------------------------------------------------------------------------------------------- TXTBOX

            playerStats.txtbox.sprite = playerStats.gameAssets.textboxSprites[data.txtbox];

            playerStats.txtBox_value.fadeTxtBoxValue = data.txtbox_opacityValue;
            playerStats.txtBox_value.fade = data.txtbox_opacityValue;

            //------------------------------------------------------------------------------------------- SPR ONE

            playerStats.spr_one.sprite = playerStats.gameAssets.npcSrites[data.spr_one];

            playerStats.spr_one_values.fadeSPRValue = data.spr_one_opacityValue;
            playerStats.spr_one_values.fade = data.spr_one_opacityValue;

            playerStats.spr_one_values.colorSPRValue = data.spr_one_colorValue;
            playerStats.spr_one_values.color = data.spr_one_colorValue;

            playerStats.spr_pos_values.spriteOnePosIndex = data.spr_one_position;
            playerStats.spr_pos_values.sprites[0].position = playerStats.spr_pos_values.spritePos[data.spr_one_position].position;

            //------------------------------------------------------------------------------------------- SPR TWO
            
            playerStats.spr_two.sprite = playerStats.gameAssets.npcSrites[data.spr_two];
            
            playerStats.spr_two_values.fadeSPRValue = data.spr_two_opacityValue;
            playerStats.spr_two_values.fade = data.spr_two_opacityValue;

            playerStats.spr_two_values.colorSPRValue = data.spr_two_colorValue;
            playerStats.spr_two_values.color = data.spr_two_colorValue;

            playerStats.spr_pos_values.spriteTwoPosIndex = data.spr_two_position;
            playerStats.spr_pos_values.sprites[1].position = playerStats.spr_pos_values.spritePos[data.spr_two_position].position;

            //------------------------------------------------------------------------------------------- Name

            FindObjectOfType<Commands>().nameOutput = data.npcName;
            FindObjectOfType<GameAssets>().catName = data.catName;

            //------------------------------------------------------------------------------------------- Slot Images

            for (int i = 0; i < playerStats.slotImage_holder.Length; i++)
            {
                playerStats.slotImage_holder[i].sprite = data.slotImage_holder[i].sprite;
            }
        }
    }
}

/**/
