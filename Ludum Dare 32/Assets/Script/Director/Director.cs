using UnityEngine;
using System.Collections;
public enum StateGame { Stop, Play, End }
public class Director : MonoBehaviour {

    public GameObject menu;

	public StateGame stateGame;

    public void setState(StateGame state)
    {
        Debug.Log(stateGame);
        stateGame = state;
        Debug.Log(stateGame);
        switch (stateGame)
        {

            case StateGame.Play:
                {

                    Time.timeScale = 1.0f;

                    break;
                }

            case StateGame.Stop:
                {

                    Time.timeScale = 0.0f;

                    break;
                }

            case StateGame.End:
                {
                    menu.SetActive(true);
                    break;
                }
        }
    }

    public void end()
    {
        StartCoroutine(coroutineEnd());
    }

    IEnumerator coroutineEnd()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log(GameObject.Find("Baby"));
        if(GameObject.Find("Baby") == null)
            setState(StateGame.End);
    }
	public static Director checkDirector () {
		return GameObject.Find("Diretor").GetComponent<Director>();
	}

}
