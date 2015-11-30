using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	public Text timerText;
	private float maxRoundTime = 3f * 60f; // Minutes x seconds
	
	void OnGUI () {
		float roundTime = Time.timeSinceLevelLoad;
		roundTime = Mathf.Clamp (roundTime, 0, maxRoundTime);

		int minutes = ((int) (maxRoundTime - roundTime)) / 60;
		int seconds = ((int) (maxRoundTime - roundTime)) % 60;

		string minStr = minutes.ToString();
		string secStr = seconds.ToString();
		
		if (minStr.Length == 1 ){
			minStr = "0" + minStr;
		}
		
		if (secStr.Length == 1) {
			secStr = "0" + secStr;
		}
		
		timerText.text = minStr + ":" + secStr;
	}
}
