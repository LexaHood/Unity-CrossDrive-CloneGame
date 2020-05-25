using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Houston : MonoBehaviour
{
    private int Score = 0;
    bool UiActive = false;

    [SerializeField] GameObject losePanel = null;
    [SerializeField] GameObject ScoreTextPanel = null;
    
    public void incrementScore() {
        Score++;
    }

    public int getScore() {
        return Score;
    }

   public void loseUiActivate() {
       if (!UiActive) {
           UiActive = true;
           losePanel.SetActive(UiActive);
           ScoreTextPanel.GetComponent<Text>().text = "Score: " + Score.ToString();
       }
   }
}
