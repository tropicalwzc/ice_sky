using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
// menu ui
public class menuser : MonoBehaviour
{
    public GameObject prefab;
    GameObject playerpl;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerpl = GameObject.FindGameObjectWithTag("Player");
        if (playerpl == null)
        {
            playerpl = Instantiate(prefab) as GameObject;
            playerpl.transform.localPosition = new Vector3(Random.Range(0, 50f) - 25f, 0f, -10f);
        }

        GameObject finder = GameObject.FindGameObjectWithTag("start");
        GameObject gooder = GameObject.FindGameObjectWithTag("tutorial");
        if (finder == null)
        {
            SceneManager.LoadScene("planes");
        }
        if (gooder == null)
        {
            SceneManager.LoadScene("tutorial");
        }

    }
    void OnGUI()
    {
        GUI.skin.label.normal.textColor = new Vector4(0.95f, 0.95f, 1.0f, 1.0f);
        GUI.Label(new Rect(320f, 750f, 820f, 300f), "鼠标控制飞机的移动左键射击\n打开始或教程牌子来选择");
    }
}
