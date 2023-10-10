using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform canvasBG;

    public Vector3 screenCenter;

    public Transform[] shakePoints;
    private Vector3 goTo;

    public float lerpSpeed;

    public float cooldownPerShake;
    private float storedCooldown;

    public float shakeDuration;
    private float storedDuration;

    public static bool isShaking;

    bool left;
    bool right;
    private void Awake()
    {
        goTo = screenCenter;
        storedCooldown = cooldownPerShake;
        storedDuration = shakeDuration;
        right = true;
    }
    private void FixedUpdate()
    {
        if (canvasBG.position != goTo)
        {
            canvasBG.position = Vector2.Lerp(canvasBG.position, goTo, lerpSpeed * Time.fixedDeltaTime);
        }
        
        if (isShaking)
        {
            if (shakeDuration > 0)
            {
                shakeDuration -= Time.fixedDeltaTime;
            }
            else
            {
                isShaking = false;
                shakeDuration = storedDuration;
            }

            if (cooldownPerShake > 0)
            {
                cooldownPerShake -= Time.fixedDeltaTime;
            }
            else
            {
                cooldownPerShake = storedCooldown;

                if (right)
                {
                    right = false;
                    left = true;
                    goTo = shakePoints[1].position;
                }
                else if (left)
                {
                    right = true;
                    left = false;
                    goTo = shakePoints[0].position;
                }

            }
        }
        else
        {
            if (goTo != screenCenter)
            {
                goTo = screenCenter;
            }
        }
    }
}
