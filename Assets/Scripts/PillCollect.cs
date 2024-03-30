using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leguar.LowHealth;

public class PillCollect : MonoBehaviour
{
    private int bluePill = 0;
    Renderer ren;
    public bool active = false;
    public Transform cam;
    public float playerActivedistance;
    public Text bluePillText;

    public ScoreManager script;

    public LowHealthDirectAccess shaderAccessScript;
    /*public float playerActivedistance;
    public bool active = false;*/
    public float beingDizzy;
    public float wakingUp1;
    public float wakingUp2;
    public PlayerMovement playerMovement;
    int pill;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && pill > 0)
        {
            pill--;
            playerMovement.speed = 24f;
            beingDizzy = 0.4f;
            wakingUp1 = 0.4f;
            wakingUp2 = 0.4f;
        }
        if (beingDizzy > 0f)
        {
            /*beingDizzy -= Time.deltaTime * 0.15f;*/
            float sin = Mathf.Sin(beingDizzy * Mathf.PI * 10f);
            float dv = /*smoothCurve(1f - beingDizzy) * 0.8f + sin * 0.2f * */beingDizzy;
            shaderAccessScript.SetDoubleVisionEffect(dv);
        }
        if (wakingUp1 > 0f)
        {
            /*wakingUp1 -= Time.deltaTime * 0.1f;*/
            shaderAccessScript.SetVisionLossEffect(wakingUp1);
        }

        if (wakingUp2 > 0f)
        {
            /*wakingUp2 -= Time.deltaTime * 0.1f;*/
            float sin = Mathf.Sin(Mathf.PI * 0.5f + (1f - wakingUp2) * Mathf.PI * 3f);
            float dl = (sin + 1f) * 0.5f * wakingUp2;
            shaderAccessScript.SetDetailLossEffect(dl);
        }
    }
    }
