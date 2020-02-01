using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBorderCreator : MonoBehaviour
{
    public GameObject borderGO;
    // Start is called before the first frame update
    void Start()
    {
		float height = Camera.main.orthographicSize;
		float width = Camera.main.aspect * Camera.main.orthographicSize;

		GameObject left = Instantiate(borderGO, transform);
        left.transform.position = new Vector3(-width, 0f, 0f);
        left.transform.localScale = new Vector3(0.1f, height * 2, 1f);


        GameObject right = Instantiate(borderGO, transform);
        right.transform.position = new Vector3(width, 0f, 0f);
        right.transform.localScale = new Vector3(0.1f, height * 2f, 1f);

        GameObject top = Instantiate(borderGO, transform);
        top.transform.position = new Vector3(0f, height, 0f);
        top.transform.localScale = new Vector3(width * 2, 0.1f, 1f);

        GameObject bot = Instantiate(borderGO, transform);
        bot.transform.position = new Vector3(0f, -height, 0f);
        bot.transform.localScale = new Vector3(width * 2, 0.1f, 1f);
    }


}
