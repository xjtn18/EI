using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public int wave = -1;
    public Monster monster;
    private MonsterMovement monsterMovement;
    private float monstersAlive = 0;
    private float monstersToSpawn = 2;
    private float increaseDiffTime = 10.0f;
    public float period = 10.0f;
    private bool gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        monsterMovement = monster.GetComponent<MonsterMovement>();
    }


    // Update is called once per frame
	void Update(){

	}

    public void updateTotal()
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
        monstersAlive = monstersToSpawn;
        IncreaseDifficulty();
    }

    public void IncreaseDifficulty()
    {
        if (Time.time > increaseDiffTime)
        {
            monstersToSpawn++;
            monsterMovement.updateSpeed();
            increaseDiffTime = Time.time + period;
        }
    }
}
