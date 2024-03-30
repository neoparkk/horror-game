using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leguar.LowHealth;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text pillText;

    public int pill = 0;


    public LowHealthDirectAccess shaderAccessScript;
    public Transform cam;
    /*public float playerActivedistance;
    public bool active = false;*/
    public float beingDizzy;
    public float wakingUp1;
    public float wakingUp2;
    public PlayerMovement playerMovement;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pillText.text = pill.ToString() + " Blue Pills";
    }

    public void addPoint()
    {
        pill += 1;
        pillText.text = pill.ToString() + " Blue Pills";
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && pill > 0)
        {
            pill = pill - 1;
            playerMovement.speed = 24f;
            beingDizzy = 0.4f;
            wakingUp1 = 0.4f;
            wakingUp2 = 0.4f;
            pillText.text = pill.ToString() + " Blue Pills";

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
