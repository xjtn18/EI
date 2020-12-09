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
    //public Monster monsterReversed;
    public WaveController waveController;
	private float waveSpawnChance = 0.8f;
	private List<string> monsterSounds = new List<string>() {"skelly", "slime", "goblin"};
	
	

    // Start is called before the first frame update
    void Start()
    {
        
        monsterSprite = monster.GetComponent<SpriteRenderer>();        
        waveController = waveController.GetComponent<WaveController>();
		Random.seed = System.DateTime.Now.Millisecond;
    }       

    // Update is called once per frame
    //Determines whether or not to spawn monsters
    //Selects a random sprite from monsterSpriteArray, chooses that sprite to dioplay
    void Update()
    {   
        if (waveController.getMonstersAlive() <= 1 && GameObject.FindGameObjectsWithTag("Player").Length == 1)
        {
			float randomNumber = Random.Range(0, 1.0f);
			if (randomNumber >= waveSpawnChance)
				waveController.startWave();
                int randomNum = Random.Range(0, monsterSpriteArray.Length);
                monster.GetComponent<SpriteRenderer>().sprite = monsterSpriteArray[randomNum];
				monster.type = randomNum;
				monster.GetComponent<AudioSource>().clip = AudioManager.GetSound(monsterSounds[randomNum]);
                spawnMonsters(waveController.getMonstersAlive());
        }
    }


    void spawnMonsters(float numMonsters)
    {

        for (int i = 0; i < numMonsters; i++)
        {
            GameObject tmp = GameObject.FindGameObjectsWithTag("Player")[0];
            Vector2 pos = new Vector2(tmp.transform.position.x, -2.5f);

            float screenRatio = (float)Screen.width / (float)Screen.height;
            float trueXWidth = Camera.main.orthographicSize * screenRatio;

            if (i % 2 == 0)
            {
                pos.x -= trueXWidth + i * 2;
                monsterSprite.flipX = false;
                var monsterInstance = Instantiate(monster, pos, new Quaternion(0, 0, 0, 1));
                //monsterInstance.GetComponent<MonsterMovement>().monsterSpeed = Random.Range(minMonsterSpeed, maxMonsterSpeed);
            }
            else
            {
                pos.x += trueXWidth + i * 2;
                monsterSprite.flipX = true;
                var monsterInstance = Instantiate(monster, pos, new Quaternion(0, 0, 0, 1));
                //monsterInstance.GetComponent<MonsterMovement>().monsterSpeed = Random.Range(minMonsterSpeed, maxMonsterSpeed);
            }
       

        }
    }


}

