using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leguar.LowHealth;

public class BluePill : MonoBehaviour
{
	public LowHealthDirectAccess shaderAccessScript;
	public Transform cam;
    /*public float playerActivedistance;
    public bool active = false;*/
    public float beingDizzy;
	public float wakingUp1;
	public float wakingUp2;
    public PlayerMovement playerMovement;
	int pill;
    // Update is called once per frame
    public void Update()
    {
        /*RaycastHit hit;
        active = Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, playerActivedistance);*/

     /*   if (Input.GetKeyDown(KeyCode.E) && active == true)
        {
            ren = GetComponent<Renderer>();
            ren.enabled = false;
            bluePill++;
        }*/
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
	/*public float smoothCurve(float time)
	{
		if (time >= 1f)
		{
			return 0f;
		}
		float t;
		if (time < 0.1f)
		{
			t = time * 5f;
		}
		else
		{
			t = 0.5f + (time - 0.1f) / 0.9f * 0.5f;
		}
		float sin = Mathf.Sin(Mathf.PI * t);
		return sin;
	}*/
}