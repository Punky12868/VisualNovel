using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritePosition : MonoBehaviour
{
    public Transform[] sprites;

    public int spriteOnePosIndex = 1;
    public int spriteTwoPosIndex = 1;
    public Transform[] spritePos;

    [SerializeField] float lerpSpeed;
    [SerializeField] float lerpMargen;
    private void Update()
    {
        if (sprites[0].position.x > spritePos[spriteOnePosIndex].position.x - lerpMargen && sprites[0].position.x < spritePos[spriteOnePosIndex].position.x + lerpMargen)
        {
            sprites[0].position = spritePos[spriteOnePosIndex].position;
        }
        else
        {
            sprites[0].position = Vector3.Lerp(sprites[0].position, spritePos[spriteOnePosIndex].position, lerpSpeed * Time.deltaTime);
        }

        if (sprites[1].position.x > spritePos[spriteTwoPosIndex].position.x - lerpMargen && sprites[1].position.x < spritePos[spriteTwoPosIndex].position.x + lerpMargen)
        {
            sprites[1].position = spritePos[spriteTwoPosIndex].position;
        }
        else
        {
            sprites[1].position = Vector3.Lerp(sprites[1].position, spritePos[spriteTwoPosIndex].position, lerpSpeed * Time.deltaTime);
        }
    }
}
