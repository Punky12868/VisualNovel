using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine;

public class VariableHolder : MonoBehaviour
{
    public Image bg;
    public Image txtbox;
    public Image spr_one;
    public Image spr_two;

    public Image[] slotImage_holder;

    public GameAssets gameAssets;
    public sprOne_Fade spr_one_values;
    public sprTwo_Fade spr_two_values;
    public TextBoxOpacity txtBox_value;
    public SpritePosition spr_pos_values;

    public TMPro.TMP_Text dialogHistory;

    public AudioSource currentBGM;
    public AudioSource currentSPRTrack;

    public Slider masterValue;
    public Slider bgmValue;
    public Slider sfxValue;
    public AudioMixer audioMixerValues;

}
