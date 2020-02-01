using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private PlayerType playerType;

    [SerializeField]
    private Rigidbody2D playerRigidbody;

    [SerializeField]
    private KeyBinding keyBinding;

    bool isOnPlatform = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isOnPlatform)
        {
            if (Input.GetKey(keyBinding.moveUp))
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
            MovePlayer(MoveDirection.LEFT);
        }
        if (Input.GetKey(keyBinding.moveRight))
        {
            MovePlayer(MoveDirection.RIGHT);
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

[System.Serializable]
public class KeyBinding
{
    public string moveUp;
    public string moveDown;
    public string moveLeft;
    public string moveRight;
}

public enum MoveDirection
{
    UP,
    DOWN,
    LEFT,
    RIGHT
}

public enum PlayerType
{
    PLAYER_ONE,
    PLAYER_TWO
}