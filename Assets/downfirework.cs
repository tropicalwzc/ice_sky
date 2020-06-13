using UnityEngine;
using System.Collections;

public class downfirework : MonoBehaviour {

    GameObject mission;
	GameObject obj,controler;
	Vector3 futureposition;
	public float speed;
    float step=0;
    // Use this for initialization
    void Start () {
	this.name="smallbullet";
	futureposition = new Vector3(transform.localPosition.x,transform.localPosition.y-400f,transform.localPosition.z);
    }
    private void Awake()
    {
        step = speed * Time.deltaTime;
    }
    // Update is called once per frame
    void FixedUpdate() {

    transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, futureposition, step);
	if(this.transform.localPosition.y<-30f)
	{
		Destroy(this.gameObject);
	}

	}
}
