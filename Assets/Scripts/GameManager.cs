using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay;
using UI;

public enum State
{
    preGame,
    playing,
    levelFinished,
    lookForLevelFinish,
    playerDead
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
        UIManager.instance.SetScore(level);

        Invoke("InitializeGameplay", 3);

        enabled = false;
    }

    public void SetState(State state)
    {
        if (this.state == State.playerDead)
            return;

        this.state = state;

        switch(state)
        {
            case State.playerDead:
                enabled = true;
                break;
        }
    }

    void InitializeGameplay()
    {
        state = State.playing;

        AbstractDesigner designer = new InfiniteDesign();
        CommandsManager commandsManager = new CommandsManager(designer);
        commandsManager.NextCommand();
    }

    public void OnLevelFinished()
    {
        state = State.levelFinished;

        level++;

        UIManager.instance.ShowText("Level " + level);
        UIManager.instance.SetScore(level);

        Invoke("BeginNextLevel", 3);
    }

    void BeginNextLevel()
    {
        state = State.playing;

        onBeginLevel?.Invoke();
    }

    public void CheckForLevelEnd()
    {
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
        if (state != State.lookForLevelFinish)
            return false;

        for (int i = levelObjects.Count - 1; i >= 0; i--)
        {
            if (levelObjects[i] == null)
                levelObjects.RemoveAt(i);
        }

        print(levelObjects.Count);

        return levelObjects.Count == 0;
    }

    private void Update()
    {
        if(Input.anyKeyDown)
        {
            Application.LoadLevel(0);
        }
    }

}
