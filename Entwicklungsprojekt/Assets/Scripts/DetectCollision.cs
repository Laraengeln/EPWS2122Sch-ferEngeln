using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{

    PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Wenn der Player vom Sprung aufkommt und auf einem Feld landet, wird dieses geloescht
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.transform.localScale.x == player.startScale)
        {
            Destroy(gameObject);
        }
    }
}
