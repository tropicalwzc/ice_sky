using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class tutorialing : MonoBehaviour {

     public GameObject[] prefab=new GameObject[30];
	 public GUIStyle goodt;
	 int showorder=0;
	 GameObject bulletpack;
	 GameObject enemynow;
	 GameObject playerpl;
	 int score=0;
	 int sander=0;
	 int mothernum=0;
     int defeat_num = 0;
     int proper_fontsize;
     int one = 0;
	// Use this for initialization
	void Start () {
        playerpl = GameObject.FindGameObjectWithTag("Player");
        if (playerpl == null)
        {
            playerpl = Instantiate(prefab[20]) as GameObject;
            playerpl.transform.localPosition = new Vector3(Random.Range(0, 50f) - 25f, 0f, -10f);
        }
        else
        {
            playerpl.GetComponent<planefiring>().allow_color_change = 0;
            playerpl.GetComponent<planefiring>().allow_angle_change = 0;
            playerpl.GetComponent<planefiring>().allow_light_change = 0;
        }
    }
	void destroysmall(int news)
	{
		score+=news;
	}
	// Update is called once per frame
	void Update () {
        if(one==0)
        {
            one = 1;
            proper_fontsize = this.GetComponent<proper_ui>().proper_font_size;
        }
	playerpl=GameObject.FindGameObjectWithTag("Player");
	if(playerpl==null)
	{
	playerpl=Instantiate(prefab[20]) as GameObject;
	playerpl.transform.localPosition=new Vector3(Random.Range(0,50f)-25f,0f,-10f);
    playerpl.GetComponent<planefiring>().allow_color_change = 0;
    playerpl.GetComponent<planefiring>().allow_angle_change = 0;
    playerpl.GetComponent<planefiring>().allow_light_change = 0;
	}
	sander++;

	if(showorder<8)
	if(sander>200){
	sander=0;

		switch(showorder)
	    {
		case 0:
		enemynow=Instantiate(prefab[8]) as GameObject;
		enemynow.transform.localPosition=new Vector3(Random.Range(0,50f)-25f,24f,-10f);
		bulletpack=Instantiate(prefab[14]) as GameObject;
		bulletpack.transform.position=new Vector3(Random.Range(0,50f)-25f,0f,-10f);
		if(score>=1499)
		{
			showorder++;
		}
		break;
		case 1:
		enemynow=Instantiate(prefab[5]) as GameObject;
		enemynow.transform.localPosition=new Vector3(Random.Range(0,50f)-25f,24f,-10f);
		bulletpack=Instantiate(prefab[17]) as GameObject;
		bulletpack.transform.localPosition=new Vector3(Random.Range(0,50f)-25f,0f,-10f);
		if(score>=4000)
		{
			showorder++;
		}
		break;
		case 2:
		if(mothernum<=2)
		{
		enemynow=Instantiate(prefab[4]) as GameObject;
		enemynow.transform.localPosition=new Vector3(Random.Range(0,50f)-25f,24f,-10f);
		mothernum++;
		}
                        for(int p=0;p<4;p++)
                        {
                            enemynow = Instantiate(prefab[1]) as GameObject;
                            enemynow.transform.localPosition = new Vector3(Random.Range(0, 50f) - 25f, 24f, -10f);
                        }


		bulletpack=Instantiate(prefab[16]) as GameObject;
		bulletpack.transform.localPosition=new Vector3(Random.Range(0,50f)-25f,0f,-10f);
		if(score>=8000)
		{
			showorder++;
		}
		break;
		case 3:
		enemynow=Instantiate(prefab[2]) as GameObject;
		enemynow.transform.localPosition=new Vector3(Random.Range(0,50f)-25f,24f,-10f);
                        for(int p=0;p<3;p++)
                        {
                            enemynow = Instantiate(prefab[7]) as GameObject;
                            enemynow.transform.localPosition = new Vector3(Random.Range(0, 50f) - 25f, 24f, -10f);
                        }
		bulletpack=Instantiate(prefab[15]) as GameObject;
		bulletpack.transform.localPosition=new Vector3(Random.Range(0,50f)-25f,0f,-10f);
		if(score>=13000)
		{
			showorder++;
		}
		break;
		case 4:
                        for(int l=0;l<3;l++)
                        {
                            enemynow = Instantiate(prefab[7]) as GameObject;
                            enemynow.transform.localPosition = new Vector3(Random.Range(0, 50f) - 25f, 24f, -10f);
                            enemynow = Instantiate(prefab[8]) as GameObject;
                            enemynow.transform.localPosition = new Vector3(Random.Range(0, 50f) - 25f, 24f, -10f);
                        }


		bulletpack=Instantiate(prefab[15]) as GameObject;
		bulletpack.transform.localPosition=new Vector3(Random.Range(0,50f)-25f,0f,-10f);
		bulletpack=Instantiate(prefab[18]) as GameObject;
		bulletpack.transform.localPosition=new Vector3(Random.Range(0,50f)-25f,0f,-10f);
		if(score>=18000)
		{
			showorder++;
		}
		break;
		case 5:
		enemynow=Instantiate(prefab[9]) as GameObject;
		enemynow.transform.localPosition=new Vector3(Random.Range(0,50f)-25f,24f,-10f);
		bulletpack=Instantiate(prefab[14+showorder]) as GameObject;
		bulletpack.transform.localPosition=new Vector3(Random.Range(0,50f)-25f,0f,-10f);
		bulletpack=Instantiate(prefab[16]) as GameObject;
		bulletpack.transform.localPosition=new Vector3(Random.Range(0,50f)-25f,0f,-10f);
		bulletpack=Instantiate(prefab[18]) as GameObject;
		bulletpack.transform.localPosition=new Vector3(Random.Range(0,50f)-25f,0f,-10f);
		if(score>=25000)
		{
		    GameObject[]des=GameObject.FindGameObjectsWithTag("enemy");
			foreach(GameObject fid in des)
			{
			    fid.SendMessage("receivehp",0f,SendMessageOptions.DontRequireReceiver);
				Destroy(fid.gameObject);
			}
			showorder++;
		}
		break;
		            case 6:
                        enemynow = Instantiate(prefab[13]) as GameObject;
                        enemynow.transform.localPosition = new Vector3(Random.Range(0, 50f) - 25f, 24f, -10f);
                        bulletpack = Instantiate(prefab[22]) as GameObject;
                        bulletpack.transform.localPosition = new Vector3(Random.Range(0, 50f) - 25f, 0f, -10f);

                        defeat_num++;
                        if (defeat_num>3)
                        {
                            GameObject[] des = GameObject.FindGameObjectsWithTag("enemy");
                            foreach (GameObject fid in des)
                            {
                                fid.SendMessage("receivehp", 0f, SendMessageOptions.DontRequireReceiver);
                                Destroy(fid.gameObject);
                            }
                            showorder++;
                        }
                        break;
                    case 7:
                        enemynow = Instantiate(prefab[6]) as GameObject;
                        enemynow.transform.localPosition = new Vector3(Random.Range(0, 50f) - 25f, 24f, -10f);
                        bulletpack = Instantiate(prefab[23]) as GameObject;
                        bulletpack.transform.localPosition = new Vector3(Random.Range(0, 50f) - 25f, 0f, -10f);

                        bulletpack = Instantiate(prefab[16]) as GameObject;
                        bulletpack.transform.localPosition = new Vector3(Random.Range(0, 50f) - 25f, 0f, -10f);
                        
                        defeat_num++;
                        if (defeat_num>7)
                        {
                            GameObject[] des = GameObject.FindGameObjectsWithTag("enemy");
                            foreach (GameObject fid in des)
                            {
                                fid.SendMessage("receivehp", 0f, SendMessageOptions.DontRequireReceiver);
                                Destroy(fid.gameObject);
                            }
                            showorder++;
                        }
                        break;
                    case 8: break;
                }
	    if(sander>1500)
	      if(showorder==8)
	      {
          SceneManager.LoadScene("planes");
          }

	}

	}
	void OnGUI()
	{
        GUI.skin.label.fontSize = proper_fontsize;  
	    GUI.skin.label.normal.textColor = new Vector4( 0.45f, 0.45f, 1.0f, 1.0f );

        switch (showorder)
	{

        case 0:GUI.Label(new Rect(Screen.width/2,Screen.height/2, Screen.width / 2, Screen.height / 2), "试试分散弹,对付直线攻击型的敌机十分舒服\n用分散弹击落3架敌机吧\n所有敌机上方都有生命条\n教程中会无限重生,随便浪\n但是游戏中你只有一条生命");break;
		case 1:GUI.Label(new Rect(Screen.width/ 2,Screen.height / 2, Screen.width / 2, Screen.height / 2), "试试追踪弹,你可以躲在安全的地方就能干掉敌机\n干掉敌方的橘色分散弹飞机吧\n比较强的敌机有较大概率掉补给包");break;
		case 2:GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, Screen.width / 2, Screen.height / 2), "试试疾速弹,最强的直线攻击\n随着得分的升高你的武器也会自动升级\n母舰要优先干掉,否则满屏小飞机朝着你发射跟踪弹");break;
		case 3:GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, Screen.width / 2, Screen.height / 2), "试试随机弹,对付大量乱飞的敌机十分有效");break;
		case 4:GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, Screen.width / 2, Screen.height / 2), "医疗包,回复20%生命值\n被导弹揍的时候尽可能及时补充生命值");break;
		case 5:GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, Screen.width / 2, Screen.height / 2), "护盾能力,全面提升防护能力\n(最高可达护甲200,生命值500)\n注意:护盾无法防御导弹以及飞机的撞击\n(所以我放了很多导弹敌机)\n但是你可以通过逃到导弹无法识别你的距离来规避导弹攻击");break;
        case 6: GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, Screen.width / 2, Screen.height / 2), "鼠标右键发射导弹,直接摧毁击中的敌机\n被导弹击落的飞机不得分并且没有补给\n只有大师级飞机才有几率掉落导弹补给\n"); break;
        case 7: GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, Screen.width / 2, Screen.height / 2), "鼠标中键发射脉冲弹,可以瘫痪所有敌机武器系统\n只有大师级飞机才有几率掉落脉冲弹补给\n"); break;
        case 8:GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, Screen.width / 2, Screen.height / 2), "你已经顺利完成教程,开始游戏吧\n你可以去 特殊关卡--大师空战 观摩一下大师级飞机\n");

		if(GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 200f,100f),"Start",goodt)||Input.GetKeyDown(KeyCode.R))
		{
        SceneManager.LoadScene("planes");
		}
		
		break;
	}
	
	}
}
