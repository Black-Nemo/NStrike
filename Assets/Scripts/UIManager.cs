using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject gamePanel;
    public GameObject deathPanel;
    public GameObject selectTeamPanel;

    public enum Panels
    {
        gamePanel,
        deathPanel,
        selectTeamPanel,
    }
    public Panels panel;
    private void LateUpdate()
    {
        TakimSecimiUIOpen();
        if (panel == Panels.gamePanel)
        {
            gamePanel.SetActive(true);
            deathPanel.SetActive(false);
            selectTeamPanel.SetActive(false);
        }
        else if (panel == Panels.deathPanel)
        {
            gamePanel.SetActive(false);
            deathPanel.SetActive(true);
            selectTeamPanel.SetActive(false);
        }
        else if (panel == Panels.selectTeamPanel)
        {
            gamePanel.SetActive(false);
            deathPanel.SetActive(false);
            selectTeamPanel.SetActive(true);
        }
    }

    void TakimSecimiUIOpen()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if(panel == Panels.selectTeamPanel){
                panel = Panels.gamePanel;
            }else{
                panel = Panels.selectTeamPanel;
            }
        }
    }
}
