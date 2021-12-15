using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public string[] correctAnswers;
    public string[] wrongAnswers;
    public string[] questions;
    public int[] order;
    public TextMeshProUGUI questionText;
    public GameObject correctField;
    public GameObject wrongField;

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
        order = RandomOrder();
        CalculateSpawnPositions();
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

            // Text für richtiges Feld setzen und Feld in Array speichern
            correctAnswerText = correctField.transform.GetChild(0).GetComponent<TextMeshPro>();
            correctAnswerText.text = correctAnswers[order[i]];
            correctFields[i] = correctField;

            // Text für falsches Feld setzen und Feld in Array speichern
            wrongAnswerText = wrongField.transform.GetChild(0).GetComponent<TextMeshPro>();
            wrongAnswerText.text = wrongAnswers[order[i]];
            wrongFields[i] = wrongField;
        }
    }

    int[] RandomOrder()
    {
        int[] order = new int[questions.Length];
        int arrayPos = 0;

        for (int i = 0; i < spawnPositions.Length; i++)
        {
            while (order.Contains(arrayPos))
            {
                arrayPos = Random.Range(0, questions.Length);
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
            order[i] = arrayPos;
        }
        return order;
    }

    void SetQuestion(int index)
    {
        questionText.text = questions[index];
    }
}
