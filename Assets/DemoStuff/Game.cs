using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    public float speed;
    public TextMeshProUGUI score;
    private int scoreNum = 0;
    private GameObject[] enemies;
    int enemyCount = 0;
    public GameObject shop;

    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        float xPos = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        float zPos = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        transform.position += Vector3.right * xPos + Vector3.up * zPos;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(enemies[enemyCount].gameObject);
            enemyCount++;

            if (enemyCount == enemies.Length)
            {
                shop.SetActive(true);
            }

            scoreNum += 125;
            score.text = "SCORE: " + scoreNum;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            speed += 4;
        }
    }

    public void BuyItem()
    {
        scoreNum -= 500;
        score.text = "SCORE: " + scoreNum;
    }
}
