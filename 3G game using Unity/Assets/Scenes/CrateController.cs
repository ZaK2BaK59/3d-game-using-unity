using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CrateController : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public float collisionDuration = 0.1f; 
    private Material crateMaterial;

    void Start()
    {
        crateMaterial = GetComponent<Renderer>().material;
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("test");
        if (collision.gameObject.tag == "SpawnedObject")
        {

           
            score++;
            UpdateScoreText();

            
            Destroy(collision.gameObject);
        }
    }

    void UpdateScoreText()
    {
        
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
