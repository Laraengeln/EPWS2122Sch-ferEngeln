using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundToScreenResolution : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(Screen.width, Screen.height, transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
