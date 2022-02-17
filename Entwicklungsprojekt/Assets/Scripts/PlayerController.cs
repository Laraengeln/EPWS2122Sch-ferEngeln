using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Initialisierung der oeffentlichen Variablen
    public float startScale = 45f;
    public Animator animator;           //Damit Skript auf Animation zugreifen kann

    // Initialisierung der privaten Variablen
    float horizontalInput;
    float verticalInput;
    float speed = 150f;
    float yRange = 70f;
    float jumpScale = 60f;
    float jumpDuration = 0.75f;
    float jumpingTimeTimer = 0f;
    float jumpTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Timer runterlaufen lassen
        jumpingTimeTimer -= Time.deltaTime;
        jumpTimer -= Time.deltaTime;

        // nach jedem Sprung wieder auf Startgroe�e zur�ck
        if (jumpingTimeTimer <= 0f)
        {
            transform.localScale = new Vector3(startScale, startScale, startScale);
        }

        // Aufruf der Methoden
        MovePlayer();
        KeepPlayerInBounds(yRange);
    }

    // Methode um Spieler zu bewegen und zu springen
    void MovePlayer()
    {
        // Input f�r Bewegung speichern
        horizontalInput = Input.GetAxis("Horizontal");


        verticalInput = Input.GetAxis("Vertical");

        // Bewegung nach rechts/links abh�ngig von horizontalInput und Bewegung nach oben/unten abh�ngig von verticalInput
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * speed);

        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        // Bei Dr�cken der Leertaste Skalierung erhoehen, da Player n�her an Kamera erscheinen soll wegen Sprung
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Nur Ausf�hren, wenn jumpTimer unter 0 ist -> Spam der Leertaste verhindern
            // Nach Sprung Timer erneut setzen
            if (jumpTimer <= 0)
            {
                transform.localScale = new Vector3(jumpScale, jumpScale, jumpScale);
                jumpingTimeTimer = jumpDuration;
                jumpTimer = 1.25f;
            }
        }
    }

   public void OnLanding() 
    {
        animator.SetBool("isJumping", false);
    }

    // Methode um den Spieler im Spielfeld zu behalten
    void KeepPlayerInBounds(float range)
    {
        if (transform.position.y < -range)
        {
            transform.position = new Vector3(transform.position.x, -range, transform.position.z);
        }

        if (transform.position.y > range)
        {
            transform.position = new Vector3(transform.position.x, range, transform.position.z);
        }


    }
}