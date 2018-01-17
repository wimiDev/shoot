using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//新手教程
// Hi! This script presents the overlay info for our tutorial content, linking you back to the relevant page.
public class TutorialInfo : MonoBehaviour 
{

    // allow user to choose whether to show this menu 
    //允许用户选择是否显示此菜单
    public bool showAtStart = true;

    // location that Visit Tutorial button sends the user
    //访问教程按钮的位置发送用户
    public string url;

    // store the GameObject which renders the overlay info
    //存储渲染叠加信息的游戏对象
    public GameObject overlay;

    // store a reference to the audio listener in the scene, allowing for muting of the scene during the overlay
    //在场景中存储对音频侦听器的引用, 允许在叠加时对场景进行静音
    public AudioListener mainListener;

    // store a reference to the UI toggle which allows users to switch it off for future plays
    //存储对 UI 切换的引用, 允许用户在将来的重头戏中切换它
    public Toggle showAtStartToggle;

    // string to store Prefs Key with name of preference for showing the overlay info
    //用于显示覆盖信息的首选项的字符串存储偏好键
    public static string showAtStartPrefsKey = "showLaunchScreen";


	void Awake()
	{
        // Check player prefs for show at start preference
        //检查玩家偏好以显示起始首选项
        if (PlayerPrefs.HasKey(showAtStartPrefsKey))
		{
			showAtStart = PlayerPrefs.GetInt(showAtStartPrefsKey) == 1;
		}

        // set UI toggle to match the existing UI preference
        //设置 ui 切换以匹配现有的 ui 首选项
        showAtStartToggle.isOn = showAtStart;

        // show the overlay info or continue to play the game
        //显示覆盖信息或继续玩游戏
        if (showAtStart) 
		{
			ShowLaunchScreen();
		}
		else 
		{
			StartGame ();
		}

	}

	// show overlay info, pausing game time, disabling the audio listener 
	// and enabling the overlay info parent game object
	public void ShowLaunchScreen()
	{
		Time.timeScale = 0f;
		mainListener.enabled = false;
		overlay.SetActive (true);
	}

	// open the stored URL for this content in a web browser
	public void LaunchTutorial()
	{
		Application.OpenURL (url);
	}

	// continue to play, by ensuring the preference is set correctly, the overlay is not active, 
	// and that the audio listener is enabled, and time scale is 1 (normal)
	public void StartGame()
	{		
		overlay.SetActive (false);
		mainListener.enabled = true;
		Time.timeScale = 1f;
	}

    // set the boolean storing show at start status to equal the UI toggle's status
    //设置在开始状态下的布尔存储显示, 以等于 UI 切换的状态
    public void ToggleShowAtLaunch()
	{
		showAtStart = showAtStartToggle.isOn;
		PlayerPrefs.SetInt(showAtStartPrefsKey, showAtStart ? 1 : 0);
	}
}
