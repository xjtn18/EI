using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Monster : MonoBehaviour
{
    public int health = 1;
    public float yPos;
    public float attackDelay;
	public int type; // 0 is skeleton, 1 is slime, 2 is goblin
    private Animator monsterAnimator;
    private float timer = 99;

    [Header("UI Elements")]
    public Image keyBackground;
    public Text keyText;
    public GameObject[] targetArray;
	private string attackSound;
    List<string> keyTextList = new List<string> {"Q","W","E","R","T","Y","U","I","O","P", 
                                                "F", "G", "H", "J", "K", "L",
                                                "Z", "X", "C", "V", "B", "N", "M"};


    // Start is called before the first frame update
    //Chooses a random string to assign to each monster. This string will be what the player needs to press
    //to deal damage to them.
    void Start()
    {
        keyBackground.enabled = false;
        keyText.enabled = false;
        int index = Random.Range(0, keyTextList.Count);
        keyText.text = keyTextList[index];      
        targetArray = GameObject.FindGameObjectsWithTag("Player");
        monsterAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInfo.health <= 0)
        {
            Destroy(gameObject);
            return;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
            AddScore();
        }

        else{
            foreach (GameObject player in targetArray)
            {
                //Calculated initially when enemy is first spawned to assign them the Player as a target.
                //Determines when overhead keys are shown
                float comp_dist =player.transform.position.x - transform.position.x;
                if (Mathf.Abs(comp_dist) <= 5)
                {
                    keyBackground.enabled = true;
                    keyText.enabled = true;
                    //If enemy is close enough to the player, and has never attacked, we start the coroutine
                    //and reset the timer to 0. The enemy doesn't attack again until timer is > attackDelay.
                    //We can set these variables on the monster prefab.
                    if (Mathf.Abs(comp_dist) <= 1.5)
                    {
                        if (timer > attackDelay)
                        {
                            StartCoroutine(DoAttack());
                            timer = 0;
                        }
                        else
                        {
                            timer += Time.deltaTime;
                        }
                    }
                }
            }
        }
    }
    
    //Subtracts monster's health by 1
    public void TakeDamage()
    {
        health -= 1;

		switch (type) {
			case 0: // skeleton
				AudioManager.PlaySound("bones", 0.3f);
				break;
			case 1: // slime
				AudioManager.PlaySound("splat", 0.8f);
				break;
			case 2: // goblin
				AudioManager.PlaySound("slash", 0.8f);
				AudioManager.PlayRandom("goblin", 5, 0.5f);
				break;
            case 3: // mushroom
				AudioManager.PlayRandom("punch", 3, 0.25f);
                break;
		}

		GameObject.Find("WaveController").GetComponent<WaveController>().updateTotal();
    }

    //Returns a string of the monster's Key in lowercase string form
    public string GetKey()
    {
        return keyText.text.ToLower();
    }

    public void AddScore()
    {
        PlayerInfo.score += 100;
    }

    //Part of the coroutine. Waits for the number of seconds in the WaitForSeconds method. Then, if
    //the unit still exists, subtraccts player health by 1.
    private IEnumerator DoAttack()
    {
        yield return new WaitForSeconds(1.5f);
        if (type == 0) // skeleton
        {
            monsterAnimator.SetTrigger("Attack0");
			attackSound = "knife";
        }
        else if(type == 1) // slime
        {
            monsterAnimator.SetTrigger("Attack1");
			attackSound = "plop";
        }
        else if (type == 2) // goblin
        {
            monsterAnimator.SetTrigger("Attack2");
			attackSound = "knife";
        }
        else if (type == 3) // mushroom
        {
            monsterAnimator.SetTrigger("Attack3");
			attackSound = "swipe";
        }

        yield return new WaitForSeconds(0.7f); // wait for animation

		AudioManager.PlaySound(attackSound);
		AudioManager.PlaySound("heart_lost", 0.3f);
        monsterAnimator.SetTrigger("IdleFromAttack");
        PlayerInfo.health--;

        
    }

}

