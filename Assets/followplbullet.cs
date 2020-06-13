using UnityEngine;
using System.Collections;

public class followplbullet : MonoBehaviour {

	GameObject mission;
	GameObject obj,controler;
	public AudioClip AC;
	Vector3 futureposition=new Vector3(0,0,0);
	public float speed=30f;
	public float followrange=150f;
	public float extradamage=0;
    public int good_fight_back = 0;
    public int fight_back_rate = 0;
    public int returnmode = 0;
    public int returnx = 0;
    public int returny = 0;
    public int random_return_top = 0;
    public int rotater = 0;
    
    int innow=0;
    int not_reach = 0;
    int return_actived = 0;
	public int crashmode=1;
	public int antiarmour=1;
	// Use this for initialization
	void Start () {
	this.name="playerbullet";
	controler=GameObject.FindWithTag("Player");
    if(controler!=null)
    {
	futureposition = controler.transform.localPosition;
    futureposition.x *= 100;
    futureposition.y *= 100;
    change_angle(controler.transform.localPosition.x, controler.transform.localPosition.y);
    }

	}

    // Update is called once per frame
    float going_to_x;
    float going_to_y;
    float toangle = 0;
    float last_distance = 10000;
    float life_radio = 1;
    void angle_move_to(float going_to_x, float going_to_y)
    {
        change_angle(going_to_x, going_to_y);
        futureposition = new Vector3(going_to_x, going_to_y, this.transform.localPosition.z);
        float step = speed * Time.deltaTime;
        transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, futureposition, step);
    }
    void change_angle(float going_to_x,float going_to_y)
    {
        float angle = Mathf.Atan2(this.transform.localPosition.y - going_to_y, this.transform.localPosition.x - going_to_x);
        float rotatechange = (angle / 1.6f + 1f) * 90f;
        this.transform.localEulerAngles = new Vector3(this.transform.localRotation.x, this.transform.localRotation.y, this.transform.localRotation.z + rotatechange);
    }
    float calculate_distance(float going_to_x,float going_to_y)
    {
        float totaldistancex = going_to_x - this.transform.localPosition.x;
        float totaldistancey = going_to_y - this.transform.localPosition.y;
        return totaldistancex* totaldistancex+totaldistancey * totaldistancey;
    }
    void FixedUpdate() {
        if(controler==null)
            controler = GameObject.FindWithTag("Player");
        if (rotater!=0)
        {
            float rotatechange = (rotater / 1.6f + 1f) * 90f;
            toangle += rotatechange;
            this.transform.localEulerAngles = new Vector3(0f, toangle, 180f);
        }
    if(random_return_top==1)
    {
            life_radio = (float)this.GetComponent<catchbullet>().lifeall / (float)this.GetComponent<catchbullet>().maxlife;
            if(life_radio<0.25f&&returnmode!=0)
            {
                return_actived = 1;
            }
    }

       if(controler!=null&&not_reach==0&&return_actived==0)
       {
          futureposition = controler.transform.localPosition;
          angle_move_to(futureposition.x, futureposition.y);
       }

    if((returnmode==0|| life_radio > 0.25f) &&controler!=null)
    {
    going_to_x = controler.transform.localPosition.x;
    going_to_y = controler.transform.localPosition.y;
    }
      else
      {
            if(random_return_top==0)
            {
             going_to_x = returnx;
             going_to_y = returny;
                
            }
            else
            {
                if(random_return_top==1)
                {
                    going_to_x = Random.Range(-200, 200);
                    going_to_y = Random.Range(-200, 200);
                    while(going_to_y>-30f&&going_to_y<50f)
                        going_to_y = Random.Range(-200, 200);

                    random_return_top = 2;
                    if (good_fight_back == 1)
                    {
                        this.GetComponent<enemyfiring>().firerate = fight_back_rate;
                    }
                    // print("return to " + going_to_x);
                }
                
            }
            
            return_actived = 1;
      }
      if(return_actived!=0)
      {
            angle_move_to(going_to_x, going_to_y);
            speed = 50f;
      }

    if (this.transform.localPosition==futureposition&&crashmode==1&&return_actived==0)
	{
	    this.SendMessage("receivehp",0f,SendMessageOptions.DontRequireReceiver);
		Destroy(this.gameObject);
	}
	if(controler!=null&&return_actived==0)
	{
        last_distance = calculate_distance(going_to_x,going_to_y);

		if(last_distance<followrange)
		{
		innow=1;
        not_reach = 0;
        angle_move_to(going_to_x, going_to_y);
        futureposition = controler.transform.localPosition;
		}
		else{	 
		if(innow==1){//if beyond follow range
                    
                    if(not_reach==0)
                    {
                    float newx = Random.Range(0,500)-250;
                    float newy = Random.Range(0,500)-250;
                    while(newx>-50f&&newx<50f)
                        newx = Random.Range(0, 500) - 250;

                    futureposition = new Vector3(newx, newy, futureposition.z);
                    not_reach = 1;
                    }

                    angle_move_to(futureposition.x, futureposition.y);
       // this.SendMessage("receivehp",0f,SendMessageOptions.DontRequireReceiver);
		//Destroy(this.gameObject);   
		}
		
		}
	}

	if(controler!=null&&return_actived==0) // control collision
	{

        float total = calculate_distance(controler.transform.localPosition.x, controler.transform.localPosition.y);

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

	if(this.transform.localPosition.y<-30f|| this.transform.localPosition.y > 30f ||this.transform.localPosition.x>50f|| this.transform.localPosition.x < -50f)
	{
		Destroy(this.gameObject);
	}

	}
}
