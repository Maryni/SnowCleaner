using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinLooseChecker : MonoBehaviour
{
    [SerializeField] private bool forLoose;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject textLose;
    [SerializeField] private GameObject textWin;
    [SerializeField] private GameObject textCongr;
    [SerializeField] private float timer = 10f;
    [SerializeField] private bool isTriggered;
    [SerializeField] private Movement movement;
    private int choose;

    private void FixedUpdate()
    {
        if (isTriggered) timer -= 0.1f;
        if(timer<0f && isTriggered)
        {
            if(choose==1)
            {
                textLose.SetActive(false); SceneManager.LoadSceneAsync("Game");
            }
            if (choose == 2)
            {
                textWin.SetActive(false); textCongr.SetActive(true);
            }
        }
    }
    private void Checker()
    {
        if(forLoose)
        {
            panel.SetActive(true);
            textLose.SetActive(true);
            choose = 1; 
            isTriggered = true;
            movement.StopMoving();
        }
        else 
        {
            panel.SetActive(true);
            textWin.SetActive(true);
            choose = 2; 
            isTriggered = true;
            movement.StopMoving();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "CAR")
        {
            Checker();
        }
        
    }
}
