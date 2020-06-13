using UnityEngine;
using System.Collections;

public class supplys : MonoBehaviour {
    
	GameObject finder;
	float totaldistancex,totaldistancey;
	Vector3 futureposition;
	public int type;

    float speed = 4f;
    // Use this for initialization
    void Start () {
	this.name="Supply"+type;
	futureposition = new Vector3(transform.localPosition.x+Random.Range(-400f,400f),transform.localPosition.y-400f,transform.localPosition.z);
	}

    // Update is called once per frame
    void Update() {

        if (finder != null) {

            totaldistancex = finder.transform.localPosition.x - this.transform.localPosition.x;
            totaldistancey = finder.transform.localPosition.y - this.transform.localPosition.y;
            float total = totaldistancex * totaldistancex + totaldistancey * totaldistancey;


            if (total < 7f)
            {
                if (type != 404 && type != 505 && type != 606) {
                    finder.SendMessage("Supply", type, SendMessageOptions.DontRequireReceiver);
                }

                if (type == 404) {
                    finder.SendMessage("Supplyhp", 20, SendMessageOptions.DontRequireReceiver);
                }
                if (type == 505) {
                    finder.SendMessage("Supplyarmour", 5, SendMessageOptions.DontRequireReceiver);
                }
                if (type == 606)
                {
                    finder.SendMessage("Supplyhp", 100, SendMessageOptions.DontRequireReceiver);
                }
                Destroy(this.gameObject);
            }

        }
        else
        {
            finder = GameObject.FindGameObjectWithTag("Player");
        }

    float step = speed * Time.deltaTime;  
    transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, futureposition, step);
	if(this.transform.localPosition.y<=-40f)
	{
		Destroy(this.gameObject);
	}

	}
}
