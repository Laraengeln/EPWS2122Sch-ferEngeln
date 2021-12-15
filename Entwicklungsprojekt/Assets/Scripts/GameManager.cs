using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Initialisierung der oeffentlichen Variablen
    public string[] correctAnswers;
    public string[] wrongAnswers;
    public string[] questions;
    public int[] order;
    public TextMeshProUGUI questionText;
    public GameObject correctField;
    public GameObject wrongField;

    // Initialisierung der privaten Variablen
    GameObject[] correctFields = new GameObject[8];
    GameObject[] wrongFields = new GameObject[8];
    TextMeshPro correctAnswerText;
    TextMeshPro wrongAnswerText;
    float[] spawnPositions = new float[8];
    float firstSpawnPos = -330f;
    float distanceBetweenFields = 95f;
    float ySpawnPos = 55f;

    // Start is called before the first frame update
    void Start()
    {
        // Mit RandomOrder() wird zu Beginn des Spiels eine Reihenfolge der Felder festgelegt
        order = RandomOrder();
        // Spawnpositionen der Felder werden berechnet
        CalculateSpawnPositions();
        // Felder werden in der definierten Reihenfolge gespawnt
        SpawnFields(order);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    // Methode um Spawnpositionen der Felder ausgehend von der Position des ersten Feldes zu berechnen
    void CalculateSpawnPositions()
    {
        spawnPositions[0] = firstSpawnPos;

        for(int i = 0; i < spawnPositions.Length; i++)
        {
            spawnPositions[i] = firstSpawnPos + distanceBetweenFields * i;
        }
    }

    // Methode um Felder zu spawnen -> richtige und falsche Felder immer gegenüber
    void SpawnFields(int[] order)
    {
        int upperCorrect;

        for(int i=0; i<spawnPositions.Length; i++)
        {
            upperCorrect = Random.Range(0, 2);

            if (upperCorrect == 1)
            {
                // richtiges Feld oben spawnen
                Instantiate(correctField, new Vector3(spawnPositions[i], ySpawnPos, 80), correctField.transform.rotation);

                // falsches Feld unten spawnen
                Instantiate(wrongField, new Vector3(spawnPositions[i], -ySpawnPos, 80), wrongField.transform.rotation);
            } else
            {
                // richtiges Feld unten spawnen
                Instantiate(correctField, new Vector3(spawnPositions[i], -ySpawnPos, 80), correctField.transform.rotation);

                // falsches Feld oben spawnen
                Instantiate(wrongField, new Vector3(spawnPositions[i], ySpawnPos, 80), wrongField.transform.rotation);

            }

            // Text für richtiges Feld entsprechend der zu Beginn festgelegten Reihenfolge setzen und Feld in Array speichern
            correctAnswerText = correctField.transform.GetChild(0).GetComponent<TextMeshPro>();
            correctAnswerText.text = correctAnswers[order[i]];
            correctFields[i] = correctField;

            // Text für falsches Feld entsprechend der zu Beginn festgelegten Reihenfolge setzen und Feld in Array speichern
            wrongAnswerText = wrongField.transform.GetChild(0).GetComponent<TextMeshPro>();
            wrongAnswerText.text = wrongAnswers[order[i]];
            wrongFields[i] = wrongField;
        }
    }

    // Methode um zufällige Reihenfolge der Felder festzulegen, wobei jedes Feld nur einmal vorkommen darf
    int[] RandomOrder()
    {
        int[] order = new int[questions.Length];
        int arrayPos = 0;

        for (int i = 0; i < spawnPositions.Length; i++)
        {
            // Solange order-Array arrayPos enthält, wird arrayPos ein neuer Random-Wert zugewiesen
            while (order.Contains(arrayPos))
            {
                arrayPos = Random.Range(0, questions.Length);
                // Wenn man an dem letzten Wert angekommen ist, wird der letzte übrige Random-Wert arrayPos zugewiesen
                if (i == questions.Length - 1)
                {
                    for (int x = 0; x < questions.Length; x++)
                    {
                        if (order.Contains(x))
                        {
                            arrayPos = x;
                            break;
                        }
                    }
                    break;
                }
            }
            // in dem order-Array werden die jeweiligen zufälligen und voneinander unterschiedlichen Werte gespeichert
            order[i] = arrayPos;
        }
        return order;
    }

    /*
    void SetQuestion(int index)
    {
        questionText.text = questions[index];
    }
    */
}
