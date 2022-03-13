using UnityEngine;
using Photon.Pun;
public class MoveCamera : MonoBehaviour {

    public Transform player;
    public GameObject camera;
    public PhotonView view;

    void Update() {
        if (view.IsMine)
        {
            camera.SetActive(true);

        }
        else
        {
            camera.SetActive(false);

        }
        transform.position = player.transform.position;
    }
}
