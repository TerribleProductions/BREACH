using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	public Text timerText;
	public Text roundStartTimeText;

	public RawImage playerOneSkills;
	public RawImage playerTwoSkills;

	private float maxRoundTime = 3f * 60f; // Minutes x seconds
	private float roundStartTime = 16f; // Seconds to start round

	private bool started = false;
	
	void OnGUI () {

		float roundTime = Time.timeSinceLevelLoad;

		if (hasRoundTimeStarted ()) {

			if(!started){
				startRound ();
			}

			roundTime = Mathf.Clamp (roundTime - roundStartTime, 0, maxRoundTime);

			int minutes = ((int)(maxRoundTime - roundTime)) / 60;
			int seconds = ((int)(maxRoundTime - roundTime)) % 60;

			string minStr = minutes.ToString ();
			string secStr = seconds.ToString ();
		
			if (minStr.Length == 1) {
				minStr = "0" + minStr;
			}
		
			if (secStr.Length == 1) {
				secStr = "0" + secStr;
			}
		
			timerText.text = minStr + ":" + secStr;
		} else {

			int seconds = ((int) (roundStartTime - roundTime));
			roundStartTimeText.text = seconds.ToString();
		}
	}

	private void startRound() {

		roundStartTimeText.enabled = false;
		playerOneSkills.enabled = false;
		playerTwoSkills.enabled = false;

		started = true;
	}

	public bool hasRoundTimeStarted() {
		return Time.timeSinceLevelLoad + 1f >= roundStartTime;
	}

	public bool hasRoundTimeEnded() {
		return Time.timeSinceLevelLoad > maxRoundTime;
	}
}
