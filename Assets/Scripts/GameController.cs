using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public ItemsScriptableObject items;

    public GameObject canvas;

    [SerializeField]
    private int levelIndex = 0;

    private List<GameObject> playerOneItems = new List<GameObject>();
    private List<GameObject> playerTwoItems = new List<GameObject>();

    private GameObject playerOneGO;
    private GameObject playerTwoGO;

    private int actionToWin;
    private int playerOneItemIndex = 0;
    private int playerTwoItemIndex = 0;
    private int actionDone = 0;

    private GameObject currentActionGO;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    private void Init()
    {
        playerOneItems = new List<GameObject>(items.items[levelIndex].playerOneItems);
        playerTwoItems = new List<GameObject>(items.items[levelIndex].playerTwoItems);

        actionDone = 0;
        currentActionGO = Instantiate(items.items[levelIndex].actionPrefabs[actionDone]);

        playerOneGO = Instantiate(playerOneItems[playerOneItemIndex]);
        playerTwoGO = Instantiate(playerTwoItems[playerTwoItemIndex]);
        playerOneGO.transform.position = items.items[levelIndex].playerOnePos;
        playerTwoGO.transform.position = items.items[levelIndex].playerTwoPos;
        
        playerOneGO.GetComponent<CharacterController>().Init(this, PlayerType.PLAYER_ONE);
        playerTwoGO.GetComponent<CharacterController>().Init(this, PlayerType.PLAYER_TWO);

        actionToWin = items.items[levelIndex].actionToWin;
        Debug.Log("Level Loaded");
    }

    private void SwitchItems(PlayerType playerType)
    {
        switch (playerType)
        {
            case PlayerType.PLAYER_ONE:
                Debug.Log("Checking player items");
                if (playerOneItems.Count > 1)
                {
                    Debug.Log("Changing items");
                    Vector3 pos = playerOneGO.transform.position;
                    playerOneItemIndex++;
                    if (playerOneItemIndex >= playerOneItems.Count)
                    {
                        playerOneItemIndex = 0;
                    }
                    Destroy(playerOneGO);
                    playerOneGO = Instantiate(playerOneItems[playerOneItemIndex]);
                    playerOneGO.GetComponent<CharacterController>().Init(this, PlayerType.PLAYER_ONE);
                    playerOneGO.transform.position = pos;
                }
                else
                {
                    playerOneGO.GetComponent<CharacterController>().InvalidMove();
                    Debug.Log("Player one has only 1 item left");
                }
                break;

            case PlayerType.PLAYER_TWO:
                if (playerTwoItems.Count > 1)
                {
                    Vector3 pos = playerTwoGO.transform.position;
                    playerTwoItemIndex++;
                    if (playerTwoItemIndex >= playerTwoItems.Count)
                    {
                        playerTwoItemIndex = 0;
                    }
                    Destroy(playerTwoGO);
                    playerTwoGO = Instantiate(playerTwoItems[playerTwoItemIndex]);
                    playerTwoGO.GetComponent<CharacterController>().Init(this, PlayerType.PLAYER_TWO);
                    playerTwoGO.transform.position = pos;
                }
                else
                {
                    playerTwoGO.GetComponent<CharacterController>().InvalidMove();
                    Debug.Log("Player two has only 1 item left");
                }
                break;
        }
    }

    private void TriggerItemEvent(PlayerType playerType)
    {
        switch(playerType)
        {
            case PlayerType.PLAYER_ONE:
                playerOneGO.GetComponent<ItemController>().TriggerItemInteration();
                break;
            case PlayerType.PLAYER_TWO:
                playerTwoGO.GetComponent<ItemController>().TriggerItemInteration();
                break;
        }
    }

    public void OnInvalidTrigger(PlayerType playerType)
    {
        switch (playerType)
        {
            case PlayerType.PLAYER_ONE:
                playerOneGO.GetComponent<CharacterController>().InvalidMove();
                break;
            case PlayerType.PLAYER_TWO:
                playerTwoGO.GetComponent<CharacterController>().InvalidMove();
                break;
        }
    }



    public void OnPlayerAction (PlayerType playerType, PlayerAction playerAction)
    {
        switch (playerAction)
        {
            case PlayerAction.ACTION_01:
                SwitchItems(playerType); 
                break;
            case PlayerAction.ACTION_02:
                TriggerItemEvent(playerType);
                break;
        }
    }

    public void OnConsumableItem(PlayerType type)
    {
        switch (type)
        {
            case PlayerType.PLAYER_ONE:
                Destroy(playerOneGO);
                playerOneGO.SetActive(false);
                playerOneItems.RemoveAt(playerOneItemIndex);
                playerOneItemIndex--;
                if (playerOneItemIndex < 0)
                {
                    playerOneItemIndex = 0;
                }
                Debug.Log("Checking player items");
                if (playerOneItems.Count > 0)
                {
                    Debug.Log("Changing items");
                    playerOneGO = Instantiate(playerOneItems[playerOneItemIndex]);
                    playerOneGO.GetComponent<CharacterController>().Init(this, PlayerType.PLAYER_ONE);
                    playerOneGO.transform.position = items.items[levelIndex].playerOnePos;
                }
                else
                {
                    Debug.Log("Player one has only 1 item left");
                }
                break;

            case PlayerType.PLAYER_TWO:
                Destroy(playerTwoGO);
                playerTwoGO.SetActive(false);
                playerTwoItems.RemoveAt(playerTwoItemIndex);
                playerTwoItemIndex--;
                if (playerTwoItemIndex < 0)
                {
                    playerTwoItemIndex = 0;
                }

                Debug.Log("Checking player items");
                if (playerTwoItems.Count > 0)
                {
                    Debug.Log("Changing items");
                    playerTwoGO = Instantiate(playerTwoItems[playerTwoItemIndex]);
                    playerTwoGO.GetComponent<CharacterController>().Init(this, PlayerType.PLAYER_TWO);
                    playerTwoGO.transform.position = items.items[levelIndex].playerTwoPos;
                }
                else
                {
                    Debug.Log("Player two has only 1 item left");
                }
                break;
        }
    }

    public void OnActionDone()
    {
        // Destroy(currentActionGO);
        actionDone++;
       
        if (actionDone >= actionToWin)
        {
            playerOneGO.GetComponent<CharacterController>().canMove = false;
            playerTwoGO.GetComponent<CharacterController>().canMove = false;
            StartCoroutine(ShowWinScreen());
        }
        else
        {
            currentActionGO.SetActive(false);
            currentActionGO = Instantiate(items.items[levelIndex].actionPrefabs[actionDone]);
        }
    }

    IEnumerator ShowWinScreen()
    {
        yield return new WaitForSeconds(3f);
        canvas.SetActive(true);
    }

    
}
