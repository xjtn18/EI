using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    private int wave = 0;
    private int waveMax = 10;
    private int monstersAlive = 0;

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
    public void setWaveMAx(int val)
    {
        waveMax = val;
    }
    public int getWaveMax()
    {
        return waveMax;
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
    public int getMonstersAlive()
    {
        return monstersAlive;
    }
    public void decrMonstersAlive()
    {
        monstersAlive -= 1;
    }

    public void startWave()
    {
        monstersAlive = 2;
    }
}
