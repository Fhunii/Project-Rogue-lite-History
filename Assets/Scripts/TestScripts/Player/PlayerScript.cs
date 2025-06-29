using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerScript : MonoBehaviour
{
int speed=2;//移動スピード
Vector3 worldAngle;//角度を代入する
 
void Start(){}
 
 void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) {//矢印上が押されている時に実行される
            if (this.transform.position.y < 5)
            {
                transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            }
        }
        if (Input.GetKey(KeyCode.DownArrow)){//矢印下が押されている時に実行される
            if (this.transform.position.y > -5) { 
                transform.position += new Vector3(0, -1* speed * Time.deltaTime, 0);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {//矢印左が押されている時に実行される
            if (this.transform.position.x > -3) { 
                worldAngle.y = 0f;//通常の向き
                this.transform.localEulerAngles = worldAngle;//自分の角度に代入する
                transform.position += new Vector3(-1 * speed * Time.deltaTime, 0, 0);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow)) {//矢印右が押されている時に実行される
            if (this.transform.position.x < 3) { 
                worldAngle.y = -180f;//右向きの角度
                this.transform.localEulerAngles = worldAngle;//自分の角度に代入
                transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            }
  }
}
}