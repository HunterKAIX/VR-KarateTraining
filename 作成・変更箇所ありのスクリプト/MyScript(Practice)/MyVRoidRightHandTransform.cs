using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyVRoidRightHandTransform : MonoBehaviour
{
    public GameObject headObject;
    public GameObject headTeacherObject;
    public GameObject rightHandTeacherObject;
    public GameObject leftHandTeacherObject;

    public GameObject rightSpeaker;
    public GameObject animObject;

    public bool HeadSpeaker;
    public bool HandQuad;

    [SerializeField] GameObject rightHandQuad;

    // Start is called before the first frame update
    void Start()
    {
        headObject = GameObject.Find("MyVRoid/Root/J_Bip_C_Hips/J_Bip_C_Spine/J_Bip_C_Chest/J_Bip_C_UpperChest/J_Bip_C_Neck/J_Bip_C_Head");

        headTeacherObject = GameObject.Find("TeacherVRoid/Root/J_Bip_C_Hips/J_Bip_C_Spine/J_Bip_C_Chest/J_Bip_C_UpperChest/J_Bip_C_Neck/J_Bip_C_Head");
        rightHandTeacherObject = GameObject.Find("TeacherVRoid/Root/J_Bip_C_Hips/J_Bip_C_Spine/J_Bip_C_Chest/J_Bip_C_UpperChest/J_Bip_R_Shoulder/J_Bip_R_UpperArm/J_Bip_R_LowerArm/J_Bip_R_Hand");
        leftHandTeacherObject = GameObject.Find("TeacherVRoid/Root/J_Bip_C_Hips/J_Bip_C_Spine/J_Bip_C_Chest/J_Bip_C_UpperChest/J_Bip_L_Shoulder/J_Bip_L_UpperArm/J_Bip_L_LowerArm/J_Bip_L_Hand");

        rightSpeaker = GameObject.Find("MyVRoid/Root/J_Bip_C_Hips/J_Bip_C_Spine/J_Bip_C_Chest/J_Bip_C_UpperChest/J_Bip_C_Neck/J_Bip_C_Head/R_Speaker");
        animObject = GameObject.Find("TeacherVRoid");

    }

    // Update is called once per frame
    void Update()
    {
        Animator anim = animObject.GetComponent<Animator>();

        Vector3 rightHandPos = transform.position;

        Transform headTransform = headObject.transform;
        Vector3 headPos = headTransform.position;

        Vector3 PlayerComparison = rightHandPos - headPos;
        //Debug.Log(PlayerComparison); 

        Transform headTeacherTransform = headTeacherObject.transform;
        Vector3 headTeacherPos = headTeacherTransform.position;

        Transform rightHandTeacherTransform = rightHandTeacherObject.transform;
        Vector3 rightHandTeacherPos = rightHandTeacherTransform.position;

        Transform leftHandTeacherTransform = leftHandTeacherObject.transform;
        Vector3 leftHandTeacherPos = leftHandTeacherTransform.position;

        Vector3 TeacherComparison = rightHandTeacherPos - headTeacherPos;
        //↓向かい合わせでの練習時用
        Vector3 v1 = new Vector3(1, 1, -1);
        Vector3 v2 = leftHandTeacherPos - headTeacherPos;
        Vector3 MirrorTeacherComparison = new Vector3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);

        if (Input.GetKey(KeyCode.Keypad1) || Input.GetKey(KeyCode.Alpha1))
        {
            HeadSpeaker = true;
        }
        else if (Input.GetKey(KeyCode.Keypad2) || Input.GetKey(KeyCode.Alpha2))
        {
            HeadSpeaker = false;
        }

        if (Input.GetKey(KeyCode.Keypad3) || Input.GetKey(KeyCode.Alpha3))
        {
            HandQuad = true;
        }
        else if (Input.GetKey(KeyCode.Keypad4) || Input.GetKey(KeyCode.Alpha4))
        {
            HandQuad = false;
        }

        //↓PlayerComparisonとTeacherComparisonを比較する
        if (anim.GetBool("MirrorSwitch") == true)
        {
            if ((MirrorTeacherComparison - PlayerComparison).magnitude > 0.15)
            {
                if (HeadSpeaker)
                {
                    rightSpeaker.GetComponent<Speaker>().ComparisonSpeaker();
                }

                if (HandQuad)
                {
                    rightHandQuad.SetActive(true);
                }
                else
                {
                    rightHandQuad.SetActive(false);
                }
            }
            else
            {
                rightHandQuad.SetActive(false);
            }
        }
        else
        {
            if ((TeacherComparison - PlayerComparison).magnitude > 0.15)
            {
                if (HeadSpeaker)
                {
                    rightSpeaker.GetComponent<Speaker>().ComparisonSpeaker();
                }

                if (HandQuad)
                {
                    rightHandQuad.SetActive(true);
                }
                else
                {
                    rightHandQuad.SetActive(false);
                }
            }
            else
            {
                rightHandQuad.SetActive(false);
            }
        }

        //↓のコードで音が鳴るのは確認
        //よって↑の条件を整えれば音はなる。
        /*if (Input.GetKey(KeyCode.RightArrow))
        {
           rightSpeaker.GetComponent<Speaker>().ComparisonSpeaker();
        }*/
    }
}
