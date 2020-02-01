using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public ItemsScriptableObject items;

    private int levelIndex = 0;

    private List<GameObject> playerOneItems;
    private List<GameObject> playerTwoItems;

    private GameObject playerOneGO;
    private GameObject playerTwoGO;

    private int playerOneItemIndex = 0;
    private int playerTwoItemIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    private void Init()
    {
        playerOneItems = items.items[levelIndex].playerOneItems;
        playerTwoItems = items.items[levelIndex].playerTwoItems;

        playerOneGO = Instantiate(playerOneItems[playerOneItemIndex]);
        playerTwoGO = Instantiate(playerTwoItems[playerTwoItemIndex]);
        playerOneGO.GetComponent<CharacterController>().Init(this, PlayerType.PLAYER_ONE);
        playerTwoGO.GetComponent<CharacterController>().Init(this, PlayerType.PLAYER_TWO);
    }

    private void SwitchItems(PlayerType playerType)
    {
        switch (playerType)
        {
            case PlayerType.PLAYER_ONE:
                Debug.Log("Checking player items");
                if (playerOneItems.Count >= 2)
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
                    Debug.Log("Player one has only 1 item left");
                }
                break;

            case PlayerType.PLAYER_TWO:
                if (playerTwoItems.Count >= 2)
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

    //public void 

    
}
