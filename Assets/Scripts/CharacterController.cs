using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private GameController gameController;

    [SerializeField]
    private PlayerType playerType;

    [SerializeField]
    private Rigidbody2D playerRigidbody;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private KeyBindingScriptableObject keyBindingObj;

    bool isOnPlatform = true;

    private KeyBinding keyBinding;
    private string walkingTrigger = "IsWalking";

    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void Init(GameController controller, PlayerType type)
    {
        gameController = controller;
        playerType = type;
        if (playerType == PlayerType.PLAYER_ONE)
        {
            keyBinding = keyBindingObj.playerOneKeyBinding;
        }
        else if (playerType == PlayerType.PLAYER_TWO)
        {
            keyBinding = keyBindingObj.playerTwoKeyBinding;
        }
        animator.SetBool(walkingTrigger, false);
        this.GetComponent<ItemController>().Init(controller, playerType);
    }

    // Update is called once per frame
    void Update()
    {

        if (isOnPlatform)
        {
            if (Input.GetKeyDown(keyBinding.moveUp))
            {
                MovePlayer(MoveDirection.UP);
            }
        }
        
        if (Input.GetKey(keyBinding.moveDown))
        {
            MovePlayer(MoveDirection.DOWN);
        }
        if (Input.GetKey(keyBinding.moveLeft))
        {
            animator.SetBool(walkingTrigger, true);
            MovePlayer(MoveDirection.LEFT);
        }
        if (Input.GetKey(keyBinding.moveRight))
        {
            animator.SetBool(walkingTrigger, true);
            MovePlayer(MoveDirection.RIGHT);
        }

        if (Input.GetKeyDown(keyBinding.actionOne))
        {
            Debug.Log("Action 1 triggered");
            gameController.OnPlayerAction(playerType, PlayerAction.ACTION_01);
        }
        if(Input.GetKeyDown(keyBinding.actionTwo))
        {
            gameController.OnPlayerAction(playerType, PlayerAction.ACTION_02);
            Debug.Log("Action 2 triggered");
        }

        if (Input.GetKeyUp(keyBinding.moveLeft) || Input.GetKeyUp(keyBinding.moveRight))
        {
            animator.SetBool(walkingTrigger, false);
            //animator.gameObject.transform.localPosition = Vector3.zero;
        }
    }

    private void MovePlayer (MoveDirection direction)
    {
        switch(direction)
        {
            case MoveDirection.UP:
                playerRigidbody.AddForce(new Vector2(0, 1), ForceMode2D.Impulse);
                Debug.Log("Going Up");
                break;
            case MoveDirection.DOWN:
                playerRigidbody.AddForce(new Vector2(0, -1));
                break;
            case MoveDirection.LEFT:
                playerRigidbody.AddForce(new Vector2(-1, 0));
                break;
            case MoveDirection.RIGHT:
                playerRigidbody.AddForce(new Vector2(1, 0));
                break;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isOnPlatform = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isOnPlatform = false;
        }
    }


}

public enum MoveDirection
{
    UP,
    DOWN,
    LEFT,
    RIGHT
}

public enum PlayerAction
{
    ACTION_01,
    ACTION_02
}

public enum PlayerType
{
    PLAYER_ONE,
    PLAYER_TWO
}