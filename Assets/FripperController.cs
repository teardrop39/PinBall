using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {

    private HingeJoint myHingeJoint;

    private float defaultAngle = 20;

    private float flickAngle = -20;

    private int width;
    Vector2 point;

	// Use this for initialization
	void Start () {

        this.myHingeJoint = GetComponent<HingeJoint>();

        SetAngle(this.defaultAngle);


        //
        width = Screen.width;
        //Debug.Log(width);

		
	}
	
	// Update is called once per frame
	void Update () {
        
        //タッチ処理
        //Debug.LogFormat("タッチ数:{0}", Input.touchCount);

        for (int i = 0; i < Input.touchCount; i++)
        {
            var id = Input.touches[i].fingerId;
            //point = Input.touches[i].position;
            //Debug.LogFormat("{0} - x:{1}, y:{2}", id, point.x, point.y);
        }


        foreach (Touch t in Input.touches)
        {
            var id = t.fingerId;
            var pos = t.position.x;

            switch (t.phase)
            {
                case TouchPhase.Began:
                    Debug.LogFormat("{0}:いまタッチした", id);

                    if(pos < width / 2 && tag == "LeftFripperTag"){
                        SetAngle(this.flickAngle);
                    }
                    if(pos >= width / 2 && tag == "RightFripperTag"){
                        SetAngle(this.flickAngle);
                    }
                    break;

                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    Debug.LogFormat("{0}:タッチしている", id);
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    Debug.LogFormat("{0}:いま離された", id);

                    if(pos < width / 2 && tag == "LeftFripperTag"){
                        SetAngle(this.defaultAngle);
                    }
                    if(pos >= width / 2 && tag == "RightFripperTag"){
                        SetAngle(this.defaultAngle);
                    }

                    break;
            }
        }



        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

	}


    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }

}
