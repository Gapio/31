using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Material selectedMat;
    [SerializeField] AudioSource swapSound;
    [SerializeField] AudioSource selectSound;

    GameObject selectedPlayer;
    GameObject hoverPlayer;

    Material[] normalMats;

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
                    if (selectedPlayer == null)
                    {
                        selectedPlayer = hitInfo.transform.gameObject;
                        Debug.Log(selectedPlayer.name);

                        normalMats = hitInfo.transform.GetChild(0).GetComponent<MeshRenderer>().materials;
                        Material[] mats = hitInfo.transform.GetChild(0).GetComponent<MeshRenderer>().materials;
                        for (int i = 0; i < mats.Length; i++)
                        {
                            mats[i] = selectedMat;
                        }
                        hitInfo.transform.GetChild(0).GetComponent<MeshRenderer>().materials = mats;
                        Time.timeScale = .25f;
                        

                        //selectSound.Play();
                    }
                    else
                    {
                        swapSound.Play();

                        Vector3 selpos = selectedPlayer.transform.position;
                        Quaternion selrot = selectedPlayer.transform.rotation;


                        GameObject guideLines1 = selectedPlayer.transform.parent.GetChild(1).gameObject;
                        Transform guideLines1Parent = guideLines1.transform.parent;
                        GameObject guideLines2 = hitInfo.transform.parent.GetChild(1).gameObject;
                        Transform guideLines2Parent = guideLines2.transform.parent;
                        guideLines1.transform.parent = selectedPlayer.transform;
                        guideLines2.transform.parent = hitInfo.transform;

                        selectedPlayer.transform.position = hitInfo.transform.position;

                        hitInfo.transform.position = selpos;


                        Debug.Log(selectedPlayer.transform.GetChild(0).name);
                        selectedPlayer.transform.GetChild(0).GetComponent<MeshRenderer>().materials = normalMats;

                        Time.timeScale = 1;
                        selectedPlayer = null;

                        guideLines1.transform.parent = guideLines1Parent;
                        guideLines2.transform.parent = guideLines2Parent;
                    }
                    //GetComponent<Rigidbody>().AddForce(forceDirection * forceSize, ForceMode.Impulse);
                }
            }
        }

        //if (selectedPlayer != null)
        //{
        //    Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        //    if (Physics.Raycast(ray, out RaycastHit hitInfo))
        //    {
        //        if (hitInfo.collider.gameObject.tag == "Player" && hitInfo.transform.gameObject != selectedPlayer)
        //        {
        //            if (hoverPlayer == null)
        //            {
        //                hoverPlayer = hitInfo.transform.gameObject;

        //                normalMats = hitInfo.transform.GetChild(0).GetComponent<MeshRenderer>().materials;
        //                Material[] mats = hitInfo.transform.GetChild(0).GetComponent<MeshRenderer>().materials;
        //                for (int i = 0; i < mats.Length; i++)
        //                {
        //                    mats[i] = selectedMat;
        //                }
        //                hitInfo.transform.GetChild(0).GetComponent<MeshRenderer>().materials = mats;


        //                //selectSound.Play();
        //            }
        //            else
        //            {

        //                //GameObject guideLines1 = selectedPlayer.transform.parent.GetChild(1).gameObject;
        //                //Transform guideLines1Parent = guideLines1.transform.parent;
        //                //GameObject guideLines2 = hitInfo.transform.parent.GetChild(1).gameObject;
        //                //Transform guideLines2Parent = guideLines2.transform.parent;
        //                //guideLines1.transform.parent = selectedPlayer.transform;
        //                //guideLines2.transform.parent = hitInfo.transform;

        //                //selectedPlayer.transform.position = hitInfo.transform.position;

        //                //hitInfo.transform.position = selpos;


        //                Debug.Log(selectedPlayer.transform.GetChild(0).name);
        //                hoverPlayer.transform.GetChild(0).GetComponent<MeshRenderer>().materials = normalMats;

        //                hoverPlayer = null;

        //                //guideLines1.transform.parent = guideLines1Parent;
        //                //guideLines2.transform.parent = guideLines2Parent;
        //            }
        //            //GetComponent<Rigidbody>().AddForce(forceDirection * forceSize, ForceMode.Impulse);
        //        }
        //    }
        //    else selectedPlayer.transform.GetChild(0).GetComponent<MeshRenderer>().materials = normalMats;
        //}
    }
}
