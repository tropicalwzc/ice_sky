using UnityEngine;
using System.Collections;

public class hidding : MonoBehaviour {

    GameObject mission;
	GameObject obj,controler;
	Vector3 futureposition;
	public float speed;
    public int changedirection_sand = 100;
    public int specific_location = 0;
    public float specific_x = 0;
    public float specific_y = 0;
    public float rotater = 0;
    public int allow_flee = 1;
    float toangle = 0;
    int sander = 0;
    int speedup = 0;
    float step = 0;
    // Use this for initialization
    void Start () {
        if(specific_location==0)
		futureposition = new Vector3(transform.localPosition.x+Random.Range(-400f,400f),transform.localPosition.y-400f,transform.localPosition.z);
        else
        {
            futureposition = new Vector3(specific_x, specific_y, transform.localPosition.z);
        }
        step = speed * Time.deltaTime;
    }
    
    // Update is called once per frame
    void Update () {
        int lifenow= this.GetComponent<catchbullet>().lifeall;
        if(lifenow<30&&speedup==0&&allow_flee==1)
        {
            speed *= 3;
            speedup = 1;
            step = speed * Time.deltaTime;
        }
        sander++;
        if(rotater!=0)
        {
            float rotatechange = (rotater / 1.6f + 1f) * 90f;
            toangle += rotatechange;

            this.transform.localEulerAngles = new Vector3(0f,  toangle, 180f);
        }
        if (sander>changedirection_sand)
        {
            sander = 0;
            speed *= 1.8f;
            step = speed * Time.deltaTime;
            if (specific_location==0)
            futureposition = new Vector3(transform.localPosition.x + Random.Range(-400f, 400f), transform.localPosition.y - 400f, transform.localPosition.z);
            else
            {
            futureposition = new Vector3(specific_x, specific_y, transform.localPosition.z);

            }
        }


    transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, futureposition, step);
	if(this.transform.localPosition.y<=-30f||this.transform.localPosition.x>=50f||this.transform.localPosition.x<=-50f)
	{
		Destroy(this.gameObject);
		
	}

	}
}
