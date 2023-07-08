using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Material NormalMat;
    [SerializeField] Material SelectedMat;
    [SerializeField] AudioSource swapSound;
    [SerializeField] AudioSource selectSound;

    GameObject selectedPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject.tag == "Player")
                {
                    Vector3 distanceToTarget = hitInfo.point - transform.position;
                    Vector3 forceDirection = distanceToTarget.normalized;
                    
                    if (selectedPlayer == null)
                    {
                        hitInfo.transform.gameObject.GetComponent<MeshRenderer>().material = SelectedMat;
                        Time.timeScale = .25f;
                        selectedPlayer = hitInfo.transform.gameObject;

                        selectSound.Play();
                    }
                    else
                    {
                        swapSound.Play();

                        Vector3 selpos = selectedPlayer.transform.position;
                        Quaternion selrot = selectedPlayer.transform.rotation;

                        selectedPlayer.transform.position = hitInfo.transform.position;
                        selectedPlayer.transform.rotation = hitInfo.transform.rotation;

                        hitInfo.transform.position = selpos;
                        hitInfo.transform.rotation = selrot;

                        selectedPlayer.GetComponent<MeshRenderer>().material = NormalMat;
                        Time.timeScale = 1;
                        selectedPlayer = null;
                    }
                    //GetComponent<Rigidbody>().AddForce(forceDirection * forceSize, ForceMode.Impulse);
                }
            }
        }
    }
}
