using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	public Text timerText;
	private float roundTime = 5f * 60f;
	
	void OnGUI () {
		int minutes = ((int) (roundTime - Time.timeSinceLevelLoad)) / 60;
		int seconds = ((int) (roundTime - Time.timeSinceLevelLoad)) % 60;

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
