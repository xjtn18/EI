using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MonsterSpawner : MonoBehaviour
{
    //May want to implement using Corountine method
    public Monster monster;
    public SpriteRenderer monsterSprite;
    public Sprite[] monsterSpriteArray;
    public WaveController waveController;

    private float waveSpawnChance = 0.8f;
    private readonly string[] monsterSounds = new string[] { "skelly", "slime", "footsteps", "footsteps"};

    // Start is called before the first frame update
    void Start()
    {
        monsterSprite = monster.GetComponent<SpriteRenderer>();
        waveController = waveController.GetComponent<WaveController>();
     
    }
    // Update is called once per frame
    //Determines whether or not to spawn monsters
    //Selects a random sprite from monsterSpriteArray, chooses that sprite to display
    void Update()
    {
        if (PlayerInfo.health <= 0)
        {
            return;
        }
        {
            if (waveController.getMonstersAlive() <= 1 && GameObject.FindGameObjectsWithTag("Player").Length == 1)
            {
                float randomNumber = Random.Range(0, 1.0f);
                if (randomNumber >= waveSpawnChance)
                {
                    waveController.startWave();
                    StartCoroutine(spawnMonsters(waveController.getMonstersAlive()));
                }
            }
        }
    }


    IEnumerator spawnMonsters(float numMonsters)
    {

        for (int i = 0; i < numMonsters; i++)
        {
            DetermineMonster();
            // wait random short amount of time to prevent monsters from being in perfect sync
            float randomWaitTime = Random.Range(0f, 1f);
            yield return new WaitForSeconds(randomWaitTime);

            GameObject tmp = GameObject.FindGameObjectsWithTag("Player")[0];
            Vector2 pos = new Vector2(tmp.transform.position.x, monster.yPos);
            float screenRatio = (float)Screen.width / (float)Screen.height;
            float trueXWidth = Camera.main.orthographicSize * screenRatio;

            if (i % 2 == 0)
            {
                //pos.x -= trueXWidth + i * 2;
                pos.x -= Random.Range(17, 25); 
                    //18 + (i * 2);
                monsterSprite.flipX = false;
                var monsterInstance = Instantiate(monster, pos, new Quaternion(0, 0, 0, 1));
            }
            else
            {
                //pos.x += trueXWidth + i * 2;
                pos.x += Random.Range(17, 25);
                //18 + (i * 2);
                monsterSprite.flipX = true;
                var monsterInstance = Instantiate(monster, pos, new Quaternion(0, 0, 0, 1));
            }
        }
    }

    public float DetermineYPosition(int monsterType)
    {
        if (monsterType == 0)
        {
            return -1.4f;
        }

        else if (monsterType == 1)
        {
            return -1.3f;
        }

        else if (monsterType == 2)
        {
            return -1.1f;
        }

        else if (monsterType == 3)
        {
            return -0.8f;
        }

        else
        {
            return -1.5f;
        }
    }

    private void DetermineMonster()
    {
        int randomNum = Random.Range(0, monsterSpriteArray.Length);
        monster.GetComponent<SpriteRenderer>().sprite = monsterSpriteArray[randomNum];
        monster.type = randomNum;
        monster.yPos = DetermineYPosition(randomNum);
        monster.GetComponent<AudioSource>().clip = AudioManager.GetSound(monsterSounds[randomNum]);
    }
}


