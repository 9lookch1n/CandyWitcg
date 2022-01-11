using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GestureRecognizer;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
	public bool addHp = false;
	public bool canDraws = false;
	public bool boltDraw = true;
	public bool loopDraw = true;

	public GameManager gameManager;
	public PlayerCtrl playerCtrl;

    public void OnRecognize(RecognitionResult result)
	{
		//Scene Level 1
		if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game"))
		{
			if (result.gesture.id == "DiagRight")
			{
				gameManager.Miss();
			}
			if (result.gesture.id == "DiagLeft")
			{
				gameManager.Miss();
			}

			if (result.gesture.id == "horizontal")
			{
				if (canDraws)
				{
					return;
				}
				else
				{
					playerCtrl.id = 1;
                    if (GameObject.FindGameObjectWithTag("Monster_Horizontal").gameObject.GetComponent<DestoryMonsterHorizontal>() == null)
                    {
						gameManager.Miss();
						return;
					}
                    else
                    {
						GameObject.FindGameObjectWithTag("Monster_Horizontal").gameObject.GetComponent<DestoryMonsterHorizontal>().PlayAnimHorizontal();
					}

				}

			}

			if (result.gesture.id == "vertical")
			{
				if (canDraws)
				{
					return;
				}
				else
				{
					playerCtrl.id = 2;
					if (GameObject.FindGameObjectWithTag("Monster_Vertical").gameObject.GetComponent<DestoryMonsterVertical>() == null)
					{
						gameManager.Miss();
						return;
					}
					else
					{
						GameObject.FindGameObjectWithTag("Monster_Vertical").gameObject.GetComponent<DestoryMonsterVertical>().PlayAnimVertical();
					}

				}

			}
			//HEART <3
			if (result.gesture.id == "heart" && playerCtrl.hps == true)
			{

				addHp = true;
				playerCtrl.addHpPlayer = true;
				playerCtrl.hp += 1;

				playerCtrl.id = 5;
				if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
				{
					SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Heal, 1f);
				}

				playerCtrl.heartUI.SetActive(false);


			}

			if (result == RecognitionResult.Empty)
			{
				gameManager.Miss();
			}
		}

		//Scene Level 2
		if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game_Level2"))
		{
			if (result.gesture.id == "horizontal")
			{
				gameManager.Miss();
			}
			if (result.gesture.id == "vertical")
			{
				gameManager.Miss();
			}
			if (result.gesture.id == "DiagRight")
			{
				gameManager.Miss();
			}
			if (result.gesture.id == "DiagLeft")
			{
				gameManager.Miss();
			}
			if (result.gesture.id == "L")
			{
				gameManager.Miss();
			}

			if (result.gesture.id == "left")
			{
				if (canDraws)
				{
					return;
				}
				else
				{
					playerCtrl.id = 3;
					if (GameObject.FindGameObjectWithTag("Monster_Left").gameObject.GetComponent<DestoryMonsterLeft>() == null)
					{
						gameManager.Miss();
						return;
					}
					else
					{
						GameObject.FindGameObjectWithTag("Monster_Left").gameObject.GetComponent<DestoryMonsterLeft>().PlayAnimLeft();
					}

				}
			}

			if (result.gesture.id == "right")
			{
				if (canDraws)
				{
					return;
				}
				else
				{
					playerCtrl.id = 4;
					if (GameObject.FindGameObjectWithTag("Monster_Right").gameObject.GetComponent<DestoryMonsterRight>() == null)
					{
						gameManager.Miss();
						return;
					}
					else
					{
						GameObject.FindGameObjectWithTag("Monster_Right").gameObject.GetComponent<DestoryMonsterRight>().PlayAnimRight();
					}

				}
			}
			if (result.gesture.id == "bolt")
			{
				if (boltDraw)
				{
					return;
				}
				else
				{
					playerCtrl.id = 6;

					boltDraw = true;

					if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
					{
						SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Bolt,1f);
					}

					foreach (GameObject obj in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
                    {
                        if (obj.tag == "Monster_Left")
                        {
							obj.GetComponentInChildren<DestoryMonsterLeft>().PlayAnimDeadBolt();
							gameManager.Hit();
						}
                        else if (obj.tag == "Monster_Right")
                        {
							obj.GetComponentInChildren<DestoryMonsterRight>().PlayAnimDeadBolt();
							gameManager.Hit();
						}
                    }


				}

			}

			//HEART <3
			if (result.gesture.id == "heart" && playerCtrl.hps == true)
			{
				addHp = true;
				playerCtrl.addHpPlayer = true;
				playerCtrl.hp += 1;
				boltDraw = true;
				playerCtrl.id = 5;

				if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
				{
					SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Heal, 1f);
				}

				playerCtrl.heartUI.SetActive(false);
			}

			if (result == RecognitionResult.Empty)
			{
				gameManager.Miss();
			}
		}

		//Scene Level 3
		if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game_Level3"))
		{
			if (result.gesture.id == "DiagRight")
			{
				gameManager.Miss();
			}
			if (result.gesture.id == "DiagLeft")
			{
				gameManager.Miss();
			}
			if (result.gesture.id == "L")
			{
				gameManager.Miss();
			}
			if (result.gesture.id == "star")
			{
				gameManager.Miss();
			}
            if (result.gesture.id == "?")
			{
				gameManager.Miss();
			}

			if (result.gesture.id == "horizontal")
			{
				playerCtrl.id = 1;
				GameObject.FindGameObjectWithTag("Monster_3_1").gameObject.GetComponentInChildren<MonsterCtrl_Level_3>().PlayAnimMon01();
			}

			if (result.gesture.id == "vertical")
			{
				playerCtrl.id = 2;
				GameObject.FindGameObjectWithTag("Monster_3_1").gameObject.GetComponentInChildren<MonsterCtrl_Level_3>().PlayAnimMon02();
			}
			// >
			if (result.gesture.id == "right")
			{
				playerCtrl.id = 4;
				GameObject.FindGameObjectWithTag("Monster_3_1").gameObject.GetComponentInChildren<MonsterCtrl_Level_3>().PlayAnimMon03();
			}

			// <
			if (result.gesture.id == "left")
			{
				playerCtrl.id = 3;
				GameObject.FindGameObjectWithTag("Monster_3_1").gameObject.GetComponentInChildren<MonsterCtrl_Level_3>().PlayAnimMon04();
			}

			if (result.gesture.id == "loop")
            {
				if (loopDraw)
				{
					return;
				}
                else
                {
					playerCtrl.id = 7;

					if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
					{
						SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Loop, 4f);
					}

					loopDraw = true;
					GameObject.FindGameObjectWithTag("Monster_3_1").gameObject.GetComponentInChildren<MonsterCtrl_Level_3>().PlayAnimLoop();
				}
			}
			//Bolt
			if (result.gesture.id == "bolt")
			{
				if (boltDraw)
				{
					return;
				}
				else
				{
					playerCtrl.id = 6;

					if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
					{
						SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Bolt, 1f);
						SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Boss_Attack);
					}

					boltDraw = true;
					GameObject.FindGameObjectWithTag("Monster_3_1").gameObject.GetComponentInChildren<MonsterCtrl_Level_3>().PlayAnimMonBolt();
				}
			}
			//HEART <3
			if (result.gesture.id == "heart" && playerCtrl.hps == true)
			{
				addHp = true;
				playerCtrl.addHpPlayer = true;
				playerCtrl.hp += 1;

				playerCtrl.id = 5;

				if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
				{
					SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Heal, 1f);
				}

				playerCtrl.heartUI.SetActive(false);
			}
			
			if (result == RecognitionResult.Empty)
			{
				gameManager.Miss();
			}
		}
	}
}
