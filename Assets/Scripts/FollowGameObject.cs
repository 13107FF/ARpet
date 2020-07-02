using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FollowGameObject : MonoBehaviour
{
    public string gameObjectTag = "Player";
    private GameObject objectToFollow;
    public float speed = 0.1f;
    public float stoppingDistance = 1f;
    private Animator petAnim;
    public bool followAllowed = true;
    // Start is called before the first frame update
    void Start()
    {
        objectToFollow = GameObject.Find("First Person Camera");
        petAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (followAllowed == true)
        {
            if (objectToFollow != null)
            {
                Vector3 tempPos = objectToFollow.transform.position;


                //Text text1 = GameObject.Find("debugText1").GetComponent<Text>();
                //string s1 = "CatPosition: " + "x=" + transform.position.x.ToString() + ",y=" + transform.position.y.ToString() + ",z=" + transform.position.z.ToString();
                //text1.text = s1;
                //Text text2 = GameObject.Find("debugText2").GetComponent<Text>();
                //string s2 = "CameraPosition: " + "x=" + tempPos.x.ToString() + ",y=" + tempPos.y.ToString() + ",z=" + tempPos.z.ToString();
                //text2.text = s2;




                tempPos.y = transform.position.y;
                if (Vector3.Distance(transform.position, tempPos) > stoppingDistance)
                {
                    petAnim.SetBool("is_following", true);

                    tempPos.y = 0f;
                    Vector3 Pos = Vector3.MoveTowards(transform.position, tempPos, speed * Time.deltaTime);
                    transform.position = Pos;

                    var lookPos = objectToFollow.transform.position - transform.position;
                    lookPos.y = 0;
                    var rotation = Quaternion.LookRotation(lookPos);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10f);
                }
                else
                {
                    petAnim.SetBool("is_following", false);
                }
            }
        }
        else{
            petAnim.SetBool("is_following", false);
        }
        
    }
}
