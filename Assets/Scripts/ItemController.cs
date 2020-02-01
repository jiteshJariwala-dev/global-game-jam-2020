using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{

    private GameController gameController;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Init(GameController controller)
    {
        gameController = controller;
    }


}


