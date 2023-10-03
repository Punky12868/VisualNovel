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

            public int spr_one;

            public float spr_one_opacityValue;
            public float spr_one_colorValue;

            public int spr_one_position;

            public int spr_two;

            public float spr_two_opacityValue;
            public float spr_two_colorValue;

            public int spr_two_position;

            public string npcName;
        }
        public override string RecordData()
        {
            var playerStats = GetComponent<VariableHolder>();

            var data = new Data();

            data.npcName = playerStats.gameAssets.currentNpcName;

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
            if (string.IsNullOrEmpty(s)) return; // If we didn't receive any save data, exit immediately.
            var data = SaveSystem.Deserialize<Data>(s);
            if (data == null) return; // If save data is invalid, exit immediately.

            var playerStats = GetComponent<VariableHolder>();

            //------------------------------------------------------------------------------------------- BG

            playerStats.bg.sprite = playerStats.gameAssets.backgrounds[data.bg];

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
        }
    }
}

/**/
