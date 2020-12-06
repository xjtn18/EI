using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    private int wave = -1;
    private float monstersAlive = 0;

    private bool gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        monstersAlive = GameObject.FindGameObjectsWithTag("Monster").Length;
    }

    public void incrementWave()
    {
        wave++;
    }
    public int getWave()
    {
        return wave;
    }
    public void resetWave()
    {
        wave = 0;
    }
    public void setGame(bool val)
    {
        gameStarted = val;
    }
    public bool hasGameStarted()
    {
        return gameStarted;
    }
    public void setMonstersAlive(int val)
    {
        monstersAlive = val;
    }
    public float getMonstersAlive()
    {
        
        return Mathf.Ceil(monstersAlive);
    }
    public void decrMonstersAlive()
    {
        monstersAlive -= 1;
    }

    public void startWave()
    {
        wave++;
        monstersAlive = Mathf.Pow(8 * Mathf.Log(wave + 1), 3) + 2;
    }
}