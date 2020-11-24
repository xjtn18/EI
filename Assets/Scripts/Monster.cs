using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Monster : MonoBehaviour
{

    public Image keyBackground;
    public Text keyText;
    public GameObject[] targetArray;
    List<string> keyTextList = new List<string> { "J", "K", "L" };

    // Start is called before the first frame update
    void Start()
    { 
        int index = Random.Range(0, keyTextList.Count);
        Debug.Log(index);

        keyText.text = keyTextList[index];

        keyBackground.enabled = false;
        keyText.enabled = false;
        targetArray = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame

    void Update()
    {
        foreach (GameObject player in targetArray)
        {
            //Calculated initially when enemy is first spawned to assign them the Player as a target.
            float comp_dist = player.transform.position.x - transform.position.x;

            if (comp_dist <= 5)
            {
                keyBackground.enabled = true;
                keyText.enabled = true;
            }
            else
            {
                keyBackground.enabled = false;
                keyText.enabled = false;
            }
        }
    }
}
