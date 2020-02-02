using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField]
    private ItemType itemType;

    [SerializeField]
    private bool isConsumable = false;

    [SerializeField]
    private bool isInteractable = true;

    [SerializeField]
    private bool hasSwapItem = false;

    [SerializeField]
    private GameObject swapItem;

    private GameController gameController;
    private PlayerType playerType;

    private List<Collider2D> colliderList = new List<Collider2D>();
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        colliderList.Add(collider);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        colliderList.Remove(collider);
    }

    public void Init(GameController controller, PlayerType type)
    {
        gameController = controller;
        playerType = type;
    }

    public void TriggerItemInteration ()
    {
        Debug.LogWarning("Triggring item " + itemType);
        switch(itemType)
        {
            case ItemType.SCREWDRIVER:
                TriggerScrewDriver();
                break;
            case ItemType.BOLT:
                TriggerBolt();
                break;
            case ItemType.NUT:
                TriggerNut();
                break;
            case ItemType.GEAR:
                TriggerGear();
                break;
            case ItemType.JACK:
                TriggerJack();
                break;
            case ItemType.CUTTER:
                TriggerCutter();
                break;
            case ItemType.WIRE_VERTICAL:
                TriggerWireVertical();
                break;
        }
    }

    private void TriggerScrewDriver ()
    {
        if (CheckForCollider("Bolt"))
        {
            Debug.Log("Screw the bolt");
        }
    }

    private void TriggerBolt()
    {

    }

    private void TriggerNut()
    {

    }

    private void TriggerGear()
    {

    }

    private void TriggerJack()
    {

    }

    private void TriggerCutter()
    {
        if (CheckForCollider("Cuttable"))
        {
            Collider2D col = GetCollider("Cuttable");
            if (col != null)
            {
                col.gameObject.SetActive(false);
            }
            gameController.OnActionDone();
            Debug.Log("Cut the Wire");
        }
        else
        {
            gameController.OnInvalidTrigger(playerType);
        }
    }

    private void TriggerWireVertical()
    {
        Debug.Log("Fixing wire");
        if (CheckForCollider("Wire_Vertical"))
        {
            Debug.Log("Wire is vertical");

            if (isConsumable)
            {
                Debug.Log("Consuming wire");

                Collider2D col = GetCollider("Wire_Vertical");
                col.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                gameController.OnConsumableItem(playerType);
                gameController.OnActionDone();
            }
            else
            {
                gameController.OnInvalidTrigger(playerType);
            }
            Debug.Log("Add the Wire");
        }
        else
        {
            gameController.OnInvalidTrigger(playerType);
        }
    }

    private bool CheckForCollider(string targetTag)
    {
        foreach (Collider2D col in colliderList)
        {
            if (col.tag == targetTag)
            {
                return true;
            }
        }
        return false;
    }

    private Collider2D GetCollider(string targetTag)
    {
        foreach (Collider2D col in colliderList)
        {
            if (col.tag == targetTag)
            {
                return col;
            }
        }
        return null;
    }




    public enum ItemType
    {
        SCREWDRIVER,
        BOLT,
        NUT,
        GEAR,
        JACK,
        WIRE_VERTICAL,
        CUTTER
    }

}


