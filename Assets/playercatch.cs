using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class playercatch : MonoBehaviour {

	public int lifeall;
	public Texture btnretry;
	public GUIStyle gooder;
	public int sheld=0;
	public int maxsheld=5;
	public int maxlife=110;
    public float catchrange = 7f;
	int sander=0;
	int sheldrecovertime=100;
    int proper_big_button_size;
    int proper_font_size;
    int proper_bar_height;
    int one = 0;
    // Use this for initialization
    void Start () {
        maxsheld = 5;
        lifeall = maxlife;
        sheld = maxsheld;
    }
	float totaldistancex;
	float totaldistancey;
	void Supplyhp(int news)
	{
		lifeall+=(int)((float)maxlife*((float)news/100f));
		if(lifeall>maxlife)
		lifeall=maxlife;

		this.SendMessage("receivehp",(float)lifeall/(float)maxlife,SendMessageOptions.DontRequireReceiver);
	}
	void hitbyotherplane(int news)
	{
		lifeall-=news;
		this.SendMessage("receivehp",(float)lifeall/(float)maxlife,SendMessageOptions.DontRequireReceiver);
	}
	void hitbybullet(int news)
	{

		  if(sheld<0.01f)
		  lifeall-=news;
		  else{
		  	  sheld-=news;
		  }
		  this.SendMessage("receivehp",(float)lifeall/(float)maxlife,SendMessageOptions.DontRequireReceiver);

	}
	void Supplyarmour(int news)
	{

        if (maxsheld<200){
		maxsheld+=news;
		maxlife+=news*2;
		sheldrecovertime-=4;
		if(maxsheld>=100)
		sheldrecovertime=12;
		}
		
		this.SendMessage("receivehp",(float)lifeall/(float)maxlife,SendMessageOptions.DontRequireReceiver);
		sheld=maxsheld;
	
	}
	// Update is called once per frame
	void Update () {
	    if (one == 0)
        {
            proper_font_size = this.GetComponent<proper_ui>().proper_font_size;
            proper_big_button_size = this.GetComponent<proper_ui>().proper_big_button;
            proper_bar_height = this.GetComponent<proper_ui>().proper_bar_height;
            one = 1;
        }

	sander++;
	if(sander>=sheldrecovertime)
	{
	    sander=0;
	    if(sheld<maxsheld)
		sheld++;
	}
	GameObject []allbullet=GameObject.FindGameObjectsWithTag("enemybullet");

	foreach(GameObject finder in allbullet)
	{
	    totaldistancex=finder.transform.localPosition.x-this.transform.localPosition.x;
		totaldistancey=finder.transform.localPosition.y-this.transform.localPosition.y;
		float total=totaldistancex*totaldistancex+totaldistancey*totaldistancey;
		if(total< catchrange)
		{
			Destroy(finder.gameObject);
			if(sheld<=0){
			lifeall--;
			this.SendMessage("receivehp",(float)lifeall/(float)maxlife,SendMessageOptions.DontRequireReceiver);
			}
			
			else{
				sheld--;
			}
		}
		if(lifeall<1){

		GameObject coller=GameObject.FindGameObjectWithTag("MainCamera");
		coller.SendMessage("gameover",1,SendMessageOptions.DontRequireReceiver);

			Destroy(this.gameObject);
		}
	}

	}

	void OnGUI()
	{
        GUI.skin.label.fontSize = proper_font_size;
    if (lifeall<1)
	{
		if(GUI.Button(new Rect(600,400,200,200),btnretry,gooder)||Input.GetKeyDown(KeyCode.R))
		{
        SceneManager.LoadScene("planes");
		}
	}
	if((float)lifeall/(float)maxlife>0.5f)
	GUI.skin.label.normal.textColor = new Vector4( 86f/255f,140f/255f,59f/255f,1f ); 
	if((float)lifeall/(float)maxlife<=0.5f&&(float)lifeall/(float)maxlife>0.25f)
	GUI.skin.label.normal.textColor = new Vector4( 243f/255f,232f/255f,78f/255f,1f); 
	if((float)lifeall/(float)maxlife<=0.25f)
	GUI.skin.label.normal.textColor = new Vector4( 221f/255f,21f/255f,50f/255f,1f);

        int being_robbed = this.GetComponent<planefiring>().weaponlevel;
        Rect healthtext_pos = new Rect(5, Screen.height - proper_bar_height * 3 - proper_big_button_size, Screen.width / 4, proper_bar_height);
        Rect armourtext_pos = new Rect(5, Screen.height - proper_bar_height * 4 - proper_big_button_size, Screen.width / 4, proper_bar_height);
        if (being_robbed!=-1)
        {

            GUI.Label(healthtext_pos, "" + maxsheld / 5 + "#" + " 生命值   " + 100 * lifeall / maxlife + "%");
            GUI.skin.label.normal.textColor = new Vector4(0.4f, 0.5f, 0.9f, 1.0f);
            if (maxsheld <= 20 && maxsheld >= 0)
                GUI.Label(armourtext_pos, "迷你铁甲   " + 100 * sheld / maxsheld + "%");
            if (maxsheld >= 25 && maxsheld <= 60)
                GUI.Label(armourtext_pos, "钛合金甲   " + 100 * sheld / maxsheld + "%");
            if (maxsheld >= 65 && maxsheld <= 95)
                GUI.Label(armourtext_pos, "寒带护甲   " + 100 * sheld / maxsheld + "%");
            if (maxsheld >= 100 && maxsheld <= 150)
                GUI.Label(armourtext_pos, "热带护甲   " + 100 * sheld / maxsheld + "%");
            if (maxsheld > 150)
                GUI.Label(armourtext_pos, "Grox护甲   " + 100 * sheld / maxsheld + "%");
        }
        else
        {
            GUI.skin.label.normal.textColor = new Vector4(0.8f, 0.4f, 0.3f, 1.0f);
            GUI.Label(healthtext_pos, "生命值监测不可用");
            GUI.Label(armourtext_pos, "护盾发生未知错误");
            sheld = 0;
        }


    }
}
