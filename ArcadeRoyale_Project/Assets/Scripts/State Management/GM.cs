﻿using UnityEngine;
using System.Collections;

public class GM : Singleton<GM> {

	public enum WorldState{Intro, Launcher, Attract, Idle};

	public static WorldState worldState = WorldState.Intro;
	private WorldState prevWorldState = WorldState.Launcher;

	public StateManager intro;
	public StateManager launcher;
	public StateManager attract;
	public StateManager idle;

	public float idleTime = 0;
	public float timeBeforeIdle = 5;
	
	new void Awake() {
		Cursor.visible = false;
		//worldState = WorldState.Launcher;
	}

	//Ideally these wouldn't be called every frame, probably not optimized
	void Update () {

        if (GM.Instance == null) { GM.Instance = this; }

        //Things to do in Attract Mode
        if (worldState == WorldState.Attract) {
            //Relaunch launcher if any key is pressed
            if (Input.anyKey) worldState = WorldState.Launcher;
        }

		//DEBUG KEYS
		//Switch states for testing.  These keys aren't used on Winnitrons yet
		if (Input.GetKey (KeyCode.Alpha1)) worldState = WorldState.Intro;
		if (Input.GetKey (KeyCode.Alpha2)) worldState = WorldState.Launcher;
		if (Input.GetKey (KeyCode.Alpha3)) worldState = WorldState.Attract;
		if (Input.GetKey (KeyCode.Alpha4)) worldState = WorldState.Idle;

		//Things to do in Launcher Mode
		if (worldState == WorldState.Launcher) {
			//Increase idle time
			idleTime += Time.deltaTime;

			//Reset idle time if a key is pressed
			if(Input.anyKey) idleTime = 0;

			//Go into Attract mode is key isn't pressed for a while
			if(idleTime > timeBeforeIdle) worldState = WorldState.Attract;
		} else {
			//Reset idleTime if not in Launcher
			idleTime = 0;
		}

		//STATE SWITCHING!
		//Only switch if the last state isn't this state
		if(worldState != prevWorldState)
		{
			switch(worldState)
			{
				case WorldState.Intro:
					intro.Activate();
					idle.Deactivate();
					launcher.Deactivate();
					attract.Deactivate();
					Debug.Log ("Intro State");
				break;

				case WorldState.Launcher:
					intro.Deactivate();
					idle.Deactivate();
					launcher.Activate();
					attract.Deactivate();
					Debug.Log ("Launcher State");
				break;

				case WorldState.Idle:
					intro.Deactivate();
					idle.Activate();
					launcher.Deactivate();
					attract.Deactivate();
					Debug.Log ("Idle State");
				break;

				case WorldState.Attract:
					intro.Deactivate();
					idle.Deactivate();
					launcher.Deactivate();
					attract.Activate();
					Debug.Log ("Attract State");
				break;

			}
		}

		prevWorldState = worldState;
	}

	static public void ChangeState(WorldState ws) {
		worldState = ws;
	}
}
