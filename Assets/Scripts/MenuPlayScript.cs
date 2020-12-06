using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlayScript : MonoBehaviour
{
    //method that changes the scene
    public void changeMenuScene( string sceneName)
    {
        Application.LoadLevel(sceneName);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
