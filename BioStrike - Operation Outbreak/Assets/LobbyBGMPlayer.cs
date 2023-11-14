using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyBGMPlayer : MonoBehaviour
{

    private void OnEnable()
    {
        AudioManagerLobby.instance.PlayBGM("Lobby");
    }
}
