using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillCollector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Pill")
        {
            ScoreManager.instance.addPoint();
            Debug.Log("pill");
            Destroy(other.gameObject);
        }
    }
}
