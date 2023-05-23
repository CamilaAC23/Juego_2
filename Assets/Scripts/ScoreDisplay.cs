using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    private Text scoreText;
    private int objectsDestroyed = 0;

    void Start()
    {
        scoreText = GetComponent<Text>();
        UpdateScoreText();
    }

    public void IncrementDestroyedObjects()
    {
        objectsDestroyed++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Objetos destruidos: " + objectsDestroyed;
    }
}


