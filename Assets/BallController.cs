using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {


    private float visiblePosZ = -6.5f;

    private GameObject gameoverText;
    private GameObject scoreText;
    private int score = 0;
    string tag_enter;


	// Use this for initialization
	void Start () {
        this.gameoverText = GameObject.Find("GameOverText");
        this.scoreText = GameObject.Find("ScoreText");
        SetScore();

	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over!!";
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        tag_enter = collision.gameObject.tag;


        if(tag_enter == "SmallStarTag"){
            score += 1;
        }else if(tag_enter == "LargeStarTag"){
            score += 10;
        }else if(tag_enter == "SmallCloudTag"){
            score += 5;
        }else if(tag_enter == "LargeCloudTag"){
            score += 10;
        }

        SetScore();
    }

    void SetScore(){
        //ScoreText.text = score.ToString();
        this.scoreText.GetComponent<Text>().text = score.ToString();
    }


}
