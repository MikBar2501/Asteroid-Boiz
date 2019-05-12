using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Gameplay;

public class GameInit : MonoBehaviour
{
    private void Start()
    {
        AbstractDesigner designer = new BasicDesigner();
        CommandsManager commandsManager = new CommandsManager(designer);
        commandsManager.NextCommand();
    }
}
