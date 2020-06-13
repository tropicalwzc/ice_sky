using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour {

private GameObject finder;

    public Texture btnchahao;
	public Texture btnretry;
	public Texture backtomenu;
	public GUIStyle gooder;
	private int sander=0;
    public string restart_scene="planes";
    int one = 0;
	// Use this for initialization
	void Start () {
	
	}
    int proper_big_button_size;
    int proper_font_size;
    int proper_bar_height;
    // Update is called once per frame
    void Update()
    {
        sander++;
        if (one == 0)
        {
            proper_font_size = this.GetComponent<proper_ui>().proper_font_size;
            proper_big_button_size = this.GetComponent<proper_ui>().proper_big_button;
            proper_bar_height = this.GetComponent<proper_ui>().proper_bar_height;
            one = 1;
        }

	}
    public void Quit (){
  
    #if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
    #else
    Application.Quit();
    #endif
    }

	float oldx,oldy;


	void OnGUI()
	{
	    GUI.skin.label.fontSize = 30;  
	    GUI.skin.button.fontSize = 30;  

        if(GUI.Button(new Rect(5, Screen.height - proper_big_button_size, proper_big_button_size, proper_big_button_size),btnchahao,gooder)||Input.GetKeyDown(KeyCode.Escape)&&sander>10)
		{
		    sander=0;
			Quit();
	    }

        if(GUI.Button(new Rect(5+proper_big_button_size, Screen.height - proper_big_button_size, proper_big_button_size,proper_big_button_size),btnretry,gooder)||Input.GetKeyDown(KeyCode.R)&&sander>10)
		{
		 sander=0;
         SceneManager.LoadScene(restart_scene);
		}

	    if(GUI.Button(new Rect(5+proper_big_button_size*2,Screen.height - proper_big_button_size,proper_big_button_size,proper_big_button_size),backtomenu,gooder)||Input.GetKeyDown(KeyCode.R)&&sander>10)
		{
		 sander=0;
         SceneManager.LoadScene("starter");
        }
        GUI.skin.label.fontSize = proper_font_size;
		GUI.skin.label.normal.textColor = new Vector4( 0.95f, 0.95f, 1.0f, 1.0f ); 
        GUI.Label(new Rect(Screen.width-proper_big_button_size*4,Screen.height-proper_bar_height,Screen.width,proper_bar_height)," "+System.DateTime.Now.ToString("HH : mm   MMMM  dd "));
  }
}
