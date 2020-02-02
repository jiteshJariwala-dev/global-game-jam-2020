using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Animator MainMenuPanel;
    public Animator CreditMenuPanel;
    public Animator HelpMenuPanel;
    public Animator StoreMenuPanel;
    public GameObject PausePanel;
    public GameObject PurchaseItemPanel;
    public GameObject FirstPurchaseItem;

    // Start is called before the first frame update
    void Start()
    {
        
        //MainMenuPanel.SetBool("ismain", true);

        PausePanel.SetActive(false);
        PurchaseItemPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void StartButton()
    {
        Application.LoadLevel(1);
    }
    public void PauseButton()
    {
        Time.timeScale = 0.0f;
        PausePanel.SetActive(true);
    }
    public void ResumeButton()
    {
        Time.timeScale = 1.0f;
        PausePanel.SetActive(false);
    }
    public void RetryButton()
    {
        Application.LoadLevel(1);
    }
    public void HomeButton()
    {
        Time.timeScale = 1.0f;
        Application.LoadLevel(0);
    }
    public void OpenOption()
    {
        CreditMenuPanel.SetBool("isoption", true);
       // MainMenuPanel.SetBool("ismain", false);
    }
    public void CloseOption()
    {
        CreditMenuPanel.SetBool("isoption", false);
       // MainMenuPanel.SetBool("ismain", true);
    }
    public void OpenHelp()
    {
        HelpMenuPanel.SetBool("ishelp", true);
       // MainMenuPanel.SetBool("ismain", false);
    }
    public void CloseHelp()
    {
        HelpMenuPanel.SetBool("ishelp", false);
       // MainMenuPanel.SetBool("ismain", true);
    }
    public void OpenStore()
    {
        StoreMenuPanel.SetBool("isstore", true);
       // MainMenuPanel.SetBool("ismain", false);
    }
    public void CloseStore()
    {
        StoreMenuPanel.SetBool("isstore", false);
        //MainMenuPanel.SetBool("ismain", true);
    }
    public void OpenPurchaseItem()
    {
        PurchaseItemPanel.SetActive(true);
        //FirstPurchaseItem.SetActive(false);
    }
    public void ClosePurchaseItem()
    {
        
        PurchaseItemPanel.SetActive(false);
        
    }
    public void OKPurchaseItem()
    {
        FirstPurchaseItem.SetActive(false);
        PurchaseItemPanel.SetActive(false);

    }
}
