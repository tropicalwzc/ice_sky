using UnityEngine;
using System.Collections;

public class pointbullet : MonoBehaviour {

	GameObject mission;
	GameObject obj,controler;
	public AudioClip AC;
	Vector3 futureposition=new Vector3(0,0,0);
	public float speed=30f;
	public float followrange=150f;
	public float extradamage=0;
	public int crashmode=1;
	public int antiarmour=1;
	int livtwo;
	// Use this for initialization
	void Start () {
	livtwo=0;
	this.name="playerbullet";
    
	    controler=GameObject.FindGameObjectWithTag("Player");
        if (controler!=null)
        {
            futureposition = controler.transform.localPosition;
            float angle = Mathf.Atan2(this.transform.localPosition.y - controler.transform.localPosition.y, this.transform.localPosition.x - controler.transform.localPosition.x);
            float rotatechange = (angle / 1.6f + 1f) * 90f;
            this.transform.localEulerAngles = new Vector3(this.transform.localRotation.x, this.transform.localRotation.y, this.transform.localRotation.z + rotatechange);
        }
	
	}
	
	// Update is called once per frame
	void Update () {
	controler=GameObject.FindWithTag("Player");
	if(this.transform.localPosition==futureposition&&crashmode==1&&controler!=null)
	{
	    if(livtwo==0)
		{
		controler=GameObject.FindWithTag("Player");
	    futureposition = controler.transform.localPosition;
	    float angle = Mathf.Atan2(this.transform.localPosition.y-controler.transform.localPosition.y,this.transform.localPosition.x-controler.transform.localPosition.x);
	    float rotatechange=(angle/1.6f+1f)*90f;
	    this.transform.localEulerAngles=new Vector3(this.transform.localRotation.x,this.transform.localRotation.y,this.transform.localRotation.z+rotatechange);
		livtwo=1;
		}
	    else{
	    this.SendMessage("receivehp",0f,SendMessageOptions.DontRequireReceiver);
		Destroy(this.gameObject);
		}

	}

	if(controler!=null)
	{
	    float step = speed * Time.deltaTime;  
        transform.localPosition = Vector3.MoveTowards(this.transform.localPosition,futureposition, step);
	    
		float totaldistancex=controler.transform.localPosition.x-this.transform.localPosition.x;
		float totaldistancey=controler.transform.localPosition.y-this.transform.localPosition.y;
		float total=totaldistancex*totaldistancex+totaldistancey*totaldistancey;
		if(total<7f&&crashmode==1)
		{		

		if(extradamage>6f)
		AudioSource.PlayClipAtPoint(AC,transform.localPosition);

		if(antiarmour==1)
		controler.SendMessage("hitbyotherplane",extradamage,SendMessageOptions.DontRequireReceiver);
		else{
		controler.SendMessage("hitbybullet",1,SendMessageOptions.DontRequireReceiver);
		}

		this.SendMessage("receivehp",0f,SendMessageOptions.DontRequireReceiver);
		Destroy(this.gameObject);

		}

		
	}

	


	if(this.transform.localPosition.y<-30f|| this.transform.localPosition.y > 30f || this.transform.localPosition.x > 50f || this.transform.localPosition.x < -50f)
	{
		Destroy(this.gameObject);
	}

	}
}
