using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyVRoidLeftHandTransform : MonoBehaviour
{
    public GameObject headObject;
    public GameObject headTeacherObject;
    public GameObject leftHandTeacherObject;
    public GameObject rightHandTeacherObject;

    public GameObject leftSpeaker;
    public GameObject animObject;

    public bool HeadSpeaker;
    public bool HandQuad;

    [SerializeField] GameObject leftHandQuad;

    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーの頭のオブジェクトの取得
        headObject = GameObject.Find("MyVRoid/Root/J_Bip_C_Hips/J_Bip_C_Spine/J_Bip_C_Chest/J_Bip_C_UpperChest/J_Bip_C_Neck/J_Bip_C_Head");

        //ズレ比較をする手本のVRoidの頭・左手・右手(鏡なし練習での手本用VRoidのモーション反転時用)のオブジェクト取得
        headTeacherObject = GameObject.Find("TeacherVRoid/Root/J_Bip_C_Hips/J_Bip_C_Spine/J_Bip_C_Chest/J_Bip_C_UpperChest/J_Bip_C_Neck/J_Bip_C_Head");
        leftHandTeacherObject = GameObject.Find("TeacherVRoid/Root/J_Bip_C_Hips/J_Bip_C_Spine/J_Bip_C_Chest/J_Bip_C_UpperChest/J_Bip_L_Shoulder/J_Bip_L_UpperArm/J_Bip_L_LowerArm/J_Bip_L_Hand");
        rightHandTeacherObject = GameObject.Find("TeacherVRoid/Root/J_Bip_C_Hips/J_Bip_C_Spine/J_Bip_C_Chest/J_Bip_C_UpperChest/J_Bip_R_Shoulder/J_Bip_R_UpperArm/J_Bip_R_LowerArm/J_Bip_R_Hand");

        //左手が手本とズレた際に音を鳴らすためのゲームオブジェクトを取得
        leftSpeaker = GameObject.Find("MyVRoid/Root/J_Bip_C_Hips/J_Bip_C_Spine/J_Bip_C_Chest/J_Bip_C_UpperChest/J_Bip_C_Neck/J_Bip_C_Head/L_Speaker");

        //"TeacherVRoid"(手本用VRoid)を"取得
        animObject = GameObject.Find("TeacherVRoid");

    }

    // Update is called once per frame
    void Update()
    {
        //"animObject"(TeacherVRoid)のAnimatorを取得
        Animator anim = animObject.GetComponent<Animator>();

        //適用しているオブジェクト(プレイヤー用VRoidの左手)の座標を取得
        Vector3 leftHandPos = transform.position;

        //プレイヤー用VRoidの頭の座標を取得
        Transform headTransform = headObject.transform;
        Vector3 headPos = headTransform.position;

        //プレイヤー用VRoidの頭から左手までのベクトルを"PlayerComparison"に格納
        Vector3 PlayerComparison = leftHandPos - headPos;

        //↓計算した座標が出るかの確認用
        //Debug.Log(PlayerComparison); 

        //手本用VRoidの頭の座標を取得
        Transform headTeacherTransform = headTeacherObject.transform;
        Vector3 headTeacherPos = headTeacherTransform.position;

        //手本用VRoidの左手の座標
        Transform leftHandTeacherTransform = leftHandTeacherObject.transform;
        Vector3 leftHandTeacherPos = leftHandTeacherTransform.position;

        //手本用VRoidの右手の座標(鏡なし練習での手本用VRoidのモーション反転時用)
        Transform rightHandTeacherTransform = rightHandTeacherObject.transform;
        Vector3 rightHandTeacherPos = rightHandTeacherTransform.position;

        //手本用VRoidの頭から左手までのベクトルを"TeacherComparison"に格納
        Vector3 TeacherComparison = leftHandTeacherPos - headTeacherPos;

        //↓向かい合わせ(鏡なし練習での手本用VRoidのモーション反転)での練習時用
        //手本用VRoidの頭から右手までのベクトルを"MirrorTeacherComparison"に格納
        //※向かい合わせ時は比較する手と、取得する座標のZ軸方向が逆となるため、その処理。
        Vector3 v1 = new Vector3(1, 1, -1);
        Vector3 v2 = rightHandTeacherPos - headTeacherPos;
        Vector3 MirrorTeacherComparison = new Vector3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);

        if (Input.GetKey(KeyCode.Keypad1) || Input.GetKey(KeyCode.Alpha1))
        {
            //フルキーor数字キーの1を押すと、ズレ検出時の音声通知をONにする。
            HeadSpeaker = true;
        }
        else if (Input.GetKey(KeyCode.Keypad2) || Input.GetKey(KeyCode.Alpha2))
        {
            //フルキーor数字キーの2を押すと、ズレ検出時の音声通知をOFFにする。
            HeadSpeaker = false;
        }

        if (Input.GetKey(KeyCode.Keypad3) || Input.GetKey(KeyCode.Alpha3))
        {
            //フルキーor数字キーの3を押すと、ズレ検出時の画像通知をONにする。
            HandQuad = true;
        }
        else if (Input.GetKey(KeyCode.Keypad4) || Input.GetKey(KeyCode.Alpha4))
        {
            //フルキーor数字キーの4を押すと、ズレ検出時の画像通知をOFFにする。
            HandQuad = false;
        }

        //アニメーターの"MirrorSwitch"がON(鏡なし練習での手本用VRoidのモーション反転)の時の処理
        if (anim.GetBool("MirrorSwitch") == true)
        {
            //↓MirrorTeacherComparisonとPlayerComparisonのベクトル長さを比較する
            if ((MirrorTeacherComparison - PlayerComparison).magnitude > 0.15)
            {
                //↓ベクトルの差が0.15mを超えた場合の処理
                //HeadSpeakerがONの場合、別スクリプトのComparisonSpeakerメソッドを呼び出し、
                //左手がズレていることを音声で通知。
                if (HeadSpeaker)
                {
                    leftSpeaker.GetComponent<Speaker>().ComparisonSpeaker();
                }

                //HandQuadがONの場合、左手がズレていることを設定してある画像の表示で通知。
                if (HandQuad)
                {
                    leftHandQuad.SetActive(true);
                }
                else
                {
                    //HandQuadがOFFの場合、画像は非表示にしておく。
                    leftHandQuad.SetActive(false);
                }
            }
            else
            {
                //ベクトルの差が0.15m以下の場合は画像での通知は非表示にしておく
                leftHandQuad.SetActive(false);
            }
        }
        else
        {
            //アニメーターの"MirrorSwitch"がOFF(鏡あり練習)の時の処理
            //↓TeacherComparisonとPlayerComparisonのベクトル長さを比較する
            if ((TeacherComparison - PlayerComparison).magnitude > 0.15)
            {
                //"MirrorSwitch"がONの時と処理自体は同じため、説明省略。
                if (HeadSpeaker)
                {
                    leftSpeaker.GetComponent<Speaker>().ComparisonSpeaker();
                }

                if(HandQuad)
                {
                    leftHandQuad.SetActive(true);
                }
                else
                {
                    leftHandQuad.SetActive(false);
                }
            }
            else
            {
                leftHandQuad.SetActive(false);
            }
        }        

        //↓のコードで音が鳴るか確認
        //下矢印キーを押すと、別スクリプトのComparisonSpeakerメソッドを呼び出して、
        //ズレ検出時用の音を鳴らす。
        /*if (Input.GetKey(KeyCode.LeftArrow))
        {
           leftSpeaker.GetComponent<Speaker>().ComparisonSpeaker();
        }*/
    }
}
