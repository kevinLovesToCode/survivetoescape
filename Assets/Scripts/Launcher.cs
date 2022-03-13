using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using TMPro;
public class Launcher : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    [SerializeField] TMP_InputField roomNameIn;
    [SerializeField] TMP_InputField joinRom;




    public GameObject main;
    public GameObject create;
    public GameObject room;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {

        Debug.Log("Connected");
        PhotonNetwork.JoinLobby();
        SceneManager.LoadScene("MainMenu");
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined lobby");
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateRoom()
    {
        if(roomNameIn.text != null)
        {
            PhotonNetwork.CreateRoom(roomNameIn.text);

        }
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("SampleScene");
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        room.SetActive(false);
        main.SetActive(true);
        create.SetActive(false);
    }
    public void LoadCreateMenu()
    {
        room.SetActive(false);
        main.SetActive(false);
        create.SetActive(true);
    }

    public void loadjoin()
    {
        room.SetActive(true);
        main.SetActive(false);
        create.SetActive(false);
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinRom.text);
    }
 
}
