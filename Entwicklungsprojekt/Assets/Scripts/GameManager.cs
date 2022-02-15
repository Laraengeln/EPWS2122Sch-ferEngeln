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
    public GameObject speechBubbleCorrectAnswer;
    public GameObject speechBubbleWrongAnswer;
    public GameObject[] speechBubbleCorrectAnswers = new GameObject[8];
    public GameObject[] speechBubbleWrongAnswers = new GameObject[8];
    public int questionCounter;

    // Initialisierung der privaten Variablen
    GameObject[] correctFields = new GameObject[8];
    GameObject[] wrongFields = new GameObject[8];
    TextMeshPro correctAnswerText;
    TextMeshPro wrongAnswerText;
    float[] spawnPositions = new float[8];
    float firstSpawnPos = -330f;
    float distanceBetweenFields = 95f;
    float ySpawnPos = 55f;
    float ySpawnPosBubble = 150f;
    float xSpawnPosBubbleOffset = 300;

    // Start is called before the first frame update
    void Start()
    {        
        // Um das aktuelle Level zu speichern, wird der Progress-PlayerPref auf 1 gesetzt
        PlayerPrefs.SetInt("Progress", 1);

        // Mit RandomOrder() wird zu Beginn des Spiels eine Reihenfolge der Felder festgelegt
        order = RandomOrder();

        // Erste Frage der Reihenfolge anzeigen
        questionText.text = questions[order[0]];

        // Spawnpositionen der Felder werden berechnet
        CalculateSpawnPositions();
        // Felder werden in der definierten Reihenfolge gespawnt
        SpawnFields(order);

        speechBubbleCorrectAnswers[0].SetActive(true);
        speechBubbleWrongAnswers[0].SetActive(true);
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
        System.Boolean bubbleToLeft = false;
        Quaternion noRotation = new Quaternion(0, 0, 0, 0);
        Quaternion xRotation = new Quaternion(180, 0, 0, 0);
        Quaternion yRotation = new Quaternion(0, 180, 0, 0);
        Quaternion zRotation = new Quaternion(0, 0, 180, 0);

        for(int i=0; i<spawnPositions.Length; i++)
        {
            // Text für richtiges Feld entsprechend der zu Beginn festgelegten Reihenfolge setzen und Feld in Array speichern
            correctAnswerText = speechBubbleCorrectAnswer.transform.GetChild(0).GetComponent<TextMeshPro>();
            correctAnswerText.text = correctAnswers[order[i]];
            //correctFields[i] = correctField;

            // Text für falsches Feld entsprechend der zu Beginn festgelegten Reihenfolge setzen und Feld in Array speichern
            wrongAnswerText = speechBubbleWrongAnswer.transform.GetChild(0).GetComponent<TextMeshPro>();
            wrongAnswerText.text = wrongAnswers[order[i]];
            //wrongFields[i] = wrongField;

            upperCorrect = Random.Range(0, 2);

            if (i >= 4) bubbleToLeft = true;

            if (upperCorrect == 1)
            {
                if (bubbleToLeft)
                {
                    InstantiateFieldsWithAnswer(i, ySpawnPos, -ySpawnPos, ySpawnPosBubble, -ySpawnPosBubble, -xSpawnPosBubbleOffset, yRotation, zRotation, yRotation, zRotation);
                }
                else {
                    InstantiateFieldsWithAnswer(i, ySpawnPos, -ySpawnPos, ySpawnPosBubble, -ySpawnPosBubble, xSpawnPosBubbleOffset, noRotation, xRotation, noRotation, xRotation);
                }
            }
            else
            {
                if (bubbleToLeft)
                {
                    InstantiateFieldsWithAnswer(i, -ySpawnPos, ySpawnPos, -ySpawnPosBubble, ySpawnPosBubble, -xSpawnPosBubbleOffset, zRotation, yRotation, zRotation, yRotation);
                } else
                {
                    InstantiateFieldsWithAnswer(i, -ySpawnPos, ySpawnPos, -ySpawnPosBubble, ySpawnPosBubble, xSpawnPosBubbleOffset, xRotation, noRotation, xRotation, noRotation);
                }
            }
        }
    }

    void InstantiateFieldsWithAnswer(int pos, float yPosCorrect, float yPosWrong, float yPosCorrectBubble, float yPosWrongBubble, float xPosBubbleOffset, Quaternion rotationCorrectBubble, Quaternion rotationWrongBubble, Quaternion rotationCorrectAnswer, Quaternion rotationWrongAnswer)
    {
        Instantiate(correctField, new Vector3(spawnPositions[pos], yPosCorrect, 80), correctField.transform.rotation);
        speechBubbleCorrectAnswer.transform.GetChild(0).transform.rotation = rotationCorrectAnswer;
        speechBubbleCorrectAnswers[pos] = Instantiate(speechBubbleCorrectAnswer, new Vector3(spawnPositions[pos] + xPosBubbleOffset, yPosCorrectBubble, 80), rotationCorrectBubble) as GameObject;
        speechBubbleCorrectAnswers[pos].SetActive(false);

        // falsches Feld unten spawnen
        Instantiate(wrongField, new Vector3(spawnPositions[pos], yPosWrong, 80), wrongField.transform.rotation);
        speechBubbleWrongAnswer.transform.GetChild(0).transform.rotation = rotationWrongAnswer;
        speechBubbleWrongAnswers[pos] = Instantiate(speechBubbleWrongAnswer, new Vector3(spawnPositions[pos] + xPosBubbleOffset, yPosWrongBubble, 80), rotationWrongBubble) as GameObject;
        speechBubbleWrongAnswers[pos].SetActive(false);
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
}
