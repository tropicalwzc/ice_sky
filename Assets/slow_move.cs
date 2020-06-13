using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slow_move : MonoBehaviour {

    // Use this for initialization
    public float speed = 0.1f;
    public float borader = 500f;
	void Start () {
		
	}
    float now_y;
    // Update is called once per frame
    void Update () {

            now_y = this.transform.localPosition.y - speed;
            this.transform.localPosition = new Vector3(this.transform.localPosition.x, now_y, this.transform.localPosition.z);
      
        if(now_y<-borader||now_y>borader)
        {
            this.transform.localPosition = new Vector3(this.transform.localPosition.x, borader, this.transform.localPosition.z);
            Vector3 fromrotate = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), Random.Range(-180f, 180f));
            this.transform.localEulerAngles = fromrotate;
        }


    }
}
