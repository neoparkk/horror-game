using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leguar.LowHealth;

public class ns : MonoBehaviour
{
	public Transform cam;
	public float playerActivedistance;
	public bool active = false;

	Renderer ren;

	private int bluePill = 0;
	public Text bluePillText;

	public bool destroy = false;
	public PlayerMovement playerMovement;

	// Update is called once per frame
	public void Update()
	{
		RaycastHit hit;
		active = Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, playerActivedistance);

		bluePillText.text = "Pills: " + bluePill;

		if (Input.GetKeyDown(KeyCode.E) && active == true)
		{
			bluePill++;
			bluePillText.text = "Pills: " + bluePill;
			ren = GetComponent<Renderer>();
			ren.enabled = false;
			destroy = true;
		}
		/*if (destroy)
        {
			Destroy(gameObject);
        }*/
	}
}