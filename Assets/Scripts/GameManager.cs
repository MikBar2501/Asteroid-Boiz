using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay;
using UI;

public enum State
{
    preGame,
    playing,
    levelFinished
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public delegate void GameManagerEvent();
    public GameManagerEvent onBeginLevel;

    int level = 0;

    List<GameObject> levelObjects;

    State state;

    // wartosci delay after levele betweeen, takei tam do ustawienia

    private void Awake()
    {
        instance = this;
        level = 1;

        levelObjects = new List<GameObject>();

        state = State.preGame;
    }

    private void Start()
    {
        UIManager.instance.ShowText("Level " + level);

        Invoke("InitializeGameplay", 3);
    }

    void InitializeGameplay()
    {
        state = State.playing;

        AbstractDesigner designer = new BasicDesigner();
        CommandsManager commandsManager = new CommandsManager(designer);
        commandsManager.NextCommand();
    }

    public void OnLevelFinished()
    {
        state = State.levelFinished;

        level++;

        UIManager.instance.ShowText("Level " + level);

        Invoke("BeginNextLevel", 3);
    }

    void BeginNextLevel()
    {
        state = State.playing;

        onBeginLevel?.Invoke();
    }

    public void CheckForLevelEnd()
    {
        if (state != State.playing)
            return;

        if(IsLevelComplited())
        {
            OnLevelFinished();
        }
    }

    public void AddLevelObject(GameObject obj)
    {
        levelObjects.Add(obj);
    }

    protected virtual bool IsLevelComplited()
    {
        for (int i = levelObjects.Count - 1; i >= 0; i--)
        {
            if (levelObjects[i] == null)
                levelObjects.RemoveAt(i);
        }

        print(levelObjects.Count);

        return levelObjects.Count == 0;
    }

#if UNITY_EDITOR
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            foreach (LevelObject levelObject in FindObjectsOfType<LevelObject>())
                Destroy(levelObject.gameObject);
        }
    }
#endif

}
