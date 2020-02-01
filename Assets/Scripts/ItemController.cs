using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField]
    private ItemType itemType;

    private GameController gameController;

    private List<Collider2D> colliderList = new List<Collider2D>();
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Col");
        colliderList.Add(collider);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        colliderList.Remove(collider);
    }

    public void Init(GameController controller)
    {
        gameController = controller;
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
        }
    }

    private void TriggerScrewDriver ()
    {
        foreach(Collider2D col in colliderList)
        {
            if (col.tag == "Bolt")
            {
                
                Debug.Log("Screw the bolt");
            }
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




    public enum ItemType
    {
        SCREWDRIVER,
        BOLT,
        NUT,
        GEAR,
        JACK
    }

}


