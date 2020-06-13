using UnityEngine;
using System.Collections;

public class follower : MonoBehaviour {

GameObject finder,finderanother,followchess;
    public int followmode = 0;
void following()
	{
	finder=GameObject.Find("redlineleft");
	//print("line "+finder.transform.position);
	Vector3 camera = Camera.main.WorldToScreenPoint(finder.transform.position);// 相机是世界的，世界到屏幕  
	//print("coline in screen "+camera);
    Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.z);  
	//print("pos of mouse "+pos);
	pos = Camera.main.ScreenToWorldPoint(pos);
	//print("pos of mouse in world "+pos);

	followchess=GameObject.FindGameObjectWithTag("Player");
	if(followchess!=null)
	followchess.transform.position=new Vector3(pos.x,pos.y,pos.z);
	
	}
	// Use this for initialization
	void Start () {
        followchess = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if(followmode==0)
	following();
	}

    private void OnGUI()
    {
        if(Input.GetKey(KeyCode.W))
        {
            float pos_y = followchess.transform.localPosition.y + 0.2f;
            followchess.transform.position = new Vector3(followchess.transform.position.x, pos_y, followchess.transform.position.z);
        }
        if (Input.GetKey(KeyCode.S))
        {
            float pos_y = followchess.transform.localPosition.y - 0.2f;
            followchess.transform.position = new Vector3(followchess.transform.position.x, pos_y, followchess.transform.position.z);
        }
        if (Input.GetKey(KeyCode.A))
        {
            float pos_x = followchess.transform.localPosition.x - 0.2f;
            followchess.transform.position = new Vector3(pos_x, followchess.transform.position.y, followchess.transform.position.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            float pos_x = followchess.transform.localPosition.x + 0.2f;
            followchess.transform.position = new Vector3(pos_x, followchess.transform.position.y, followchess.transform.position.z);
        }
    }
}
