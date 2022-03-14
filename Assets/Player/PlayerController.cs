using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;


    public class PlayerController : NetworkBehaviour
    {


    //==== blocks
    public GameObject stone;
        public GameObject dirt;
        public GameObject grass;
        public GameObject gravel;
        public GameObject screen;
        public GameObject glass;
        public GameObject oak;
    public GameObject conveyor;


    //==== visualizer
    public Material Mscreen;
        public Material Mstone;
        public Material Mdirt;
        public Material Mgrass;
        public Material Mgravel;
        public Material Mglass;
        public Material Moak;
        public Material Mvisu;


        public GameObject visualizer;
        public Transform stoneSpawn;
        public GameObject viseur;
        public Canvas UIb;
        public Camera cam;
        public GameObject Playercam;
    public GameObject Playercam1;
    public GameObject PlayerHead;
        public float sensitivity = 7f;
        public float maxYAngle = 90f;
    public Vector3 jump;
    public float jumpForce = 2.1f;

    public bool isGrounded;
    Rigidbody rb;
    private Vector2 currentRotation;
        // public float selector;
        private float selector = 0;
        private float activeVisu = 1;
        private float choixVisu = 0;
        private float chat = 0;
    private float t = 0;
    private float v = 0;
    int rotation = 0;
    int rotationY = 0;
    int rotationZ = 0;
    private GameObject menucam;
    void Start()
        {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        if (isLocalPlayer)
        {
            menucam = GameObject.Find("menucam");
            menucam.SetActive(false);
            return; }


            cam.enabled = false;
            //GetComponent<PlayerControls>().enabled = false;
            //GetComponent<PlayerMovement>().enabled = false;


        }

    void OnCollisionStay()
    {
        if (!isGrounded && rb.velocity.y == 0 || !isGrounded && rb.velocity.y == 0.1 || !isGrounded && rb.velocity.y < 0.1)
        {
            isGrounded = true;  }
                               //isGrounded = true;
        }


    void Update()
        {

            if (!isLocalPlayer) { return; };

            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 140.0f;

        var z = Input.GetAxis("Vertical") * Time.deltaTime * 6.0f;
        if (t == 0)
        {
            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, z);
        }

            if (Input.GetKey("space") && isGrounded)
            {
            if (t == 0)
            {
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
            //transform.Translate(0, 0.13f, 0);

            }

            if (Input.GetKey("q"))
            {
            if (t == 0) { transform.Translate(-0.06f, 0, 0); }

            }
            if (Input.GetKey("d"))
            {
            if (t == 0) { transform.Translate(0.06f, 0, 0); }

            }
        if (t == 0)
        {
            currentRotation.x += Input.GetAxis("Mouse X") * sensitivity;
            currentRotation.y -= Input.GetAxis("Mouse Y") * sensitivity;
            currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
            currentRotation.y = Mathf.Clamp(currentRotation.y, -maxYAngle, maxYAngle);
            Playercam.transform.rotation = Quaternion.Euler(0, currentRotation.x, 0);
            Playercam1.transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);
        }



        if (isClient)
            {

            stoneSpawn.transform.Translate(Vector3.forward * Input.GetAxis("Mouse ScrollWheel"));
            if (Input.GetMouseButtonDown(0))
                {

                if (t == 0)
                {
                    RaycastHit hit;
                    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                    if (Cursor.visible = true)
                    {
                        Cursor.lockState = CursorLockMode.Locked;
                        Cursor.visible = false;
                    }
                    if (Physics.Raycast(ray, out hit))
                    {

                        BoxCollider bc = hit.collider as BoxCollider;
                        if (bc != stoneSpawn)
                        {
                            GameObject eb = bc.gameObject;
                            CmdRemoveCube(eb);

                        }


                    }
                    
                }
                else if (t == 1) {
                    t = 0;
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }
            }
                if (Input.GetKey("escape"))
                {
                if (t == 0) {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    t = 1;
                }

            }
            if (t == 0)
            {
                if (Input.GetKeyDown("w"))//ROTATION X
                {
                    if (rotation == 0)
                    {

                        rotation = 30;
                        
                    }
                    else if (rotation == 30)
                    {
                        rotation = 60;
                        
                    }
                    else if (rotation == 60)
                    {
                        rotation = 90;
                        
                    }
                    else if (rotation == 90)
                    {
                        rotation = 120;
                        
                    }
                    else if (rotation == 120)
                    {
                        rotation = 150;
                        
                    }
                    else if (rotation == 150)
                    {
                        rotation = 180;
                        
                    }
                    else if (rotation == 180)
                    {
                        rotation = 210;

                    }
                    else if (rotation == 210)
                    {
                        rotation = 240;

                    }
                    else if (rotation == 240)
                    {
                        rotation = 270;

                    }
                    else if (rotation == 270)
                    {
                        rotation = 300;

                    }
                    else if (rotation == 300)
                    {
                        rotation = 330;

                    }
                    else if (rotation == 330)
                    {
                        rotation = 0;

                    }
                }

                if (Input.GetKeyDown("x"))//ROTATION Z
                {
                    if (rotationZ == 0)
                    {

                        rotationZ = 30;

                    }
                    else if (rotationZ == 30)
                    {
                        rotationZ = 60;

                    }
                    else if (rotationZ == 60)
                    {
                        rotationZ = 90;

                    }
                    else if (rotationZ == 90)
                    {
                        rotationZ = 120;

                    }
                    else if (rotationZ == 120)
                    {
                        rotationZ = 150;

                    }
                    else if (rotationZ == 150)
                    {
                        rotationZ = 180;

                    }
                    else if (rotationZ == 180)
                    {
                        rotationZ = 210;

                    }
                    else if (rotationZ == 210)
                    {
                        rotationZ = 240;

                    }
                    else if (rotationZ == 240)
                    {
                        rotationZ = 270;

                    }
                    else if (rotationZ == 270)
                    {
                        rotationZ = 300;

                    }
                    else if (rotationZ == 300)
                    {
                        rotationZ = 330;

                    }
                    else if (rotationZ == 330)
                    {
                        rotationZ = 0;

                    }
                }

                if (Input.GetKeyDown("c"))//ROTATION Y
                {
                    if (rotationY == 0)
                    {

                        rotationY = 30;

                    }
                    else if (rotationY == 30)
                    {
                        rotationY = 60;

                    }
                    else if (rotationY == 60)
                    {
                        rotationY = 90;

                    }
                    else if (rotationY == 90)
                    {
                        rotationY = 120;

                    }
                    else if (rotationY == 120)
                    {
                        rotationY = 150;

                    }
                    else if (rotationY == 150)
                    {
                        rotationY = 180;

                    }
                    else if (rotationY == 180)
                    {
                        rotationY = 210;

                    }
                    else if (rotationY == 210)
                    {
                        rotationY = 240;

                    }
                    else if (rotationY == 240)
                    {
                        rotationY = 270;

                    }
                    else if (rotationY == 270)
                    {
                        rotationY = 300;

                    }
                    else if (rotationY == 300)
                    {
                        rotationY = 330;

                    }
                    else if (rotationY == 330)
                    {
                        rotationY = 0;

                    }
                }
            }

            if (Input.GetMouseButtonDown(1)) //==== A CHANGER UNE FOIS INVENTAIRE FAIT
                {
                if (t == 0) { CmdAddCube(selector, rotation, rotationZ, rotationY); }
                    else if(t == 1) { t = 0; }

                }

                if (Input.GetKey("1"))//stone
                {
                    selector = 0;
                    if (choixVisu == 0) { visualizer.GetComponent<MeshRenderer>().material = Mstone; }

                }
                if (Input.GetKey("2"))//dirt
                {
                    selector = 1;
                    if (choixVisu == 0) { visualizer.GetComponent<MeshRenderer>().material = Mdirt; }

                }
                if (Input.GetKey("3"))//grass
                {
                    selector = 2;
                    if (choixVisu == 0) { visualizer.GetComponent<MeshRenderer>().material = Mgrass; }

                }
                if (Input.GetKey("4"))//gravel
                {
                    selector = 3;
                    if (choixVisu == 0) { visualizer.GetComponent<MeshRenderer>().material = Mgravel; }

                }
                if (Input.GetKey("5"))//screen
                {
                    selector = 4;
                    if (choixVisu == 0) { visualizer.GetComponent<MeshRenderer>().material = Mscreen; }

                }
                if (Input.GetKey("6"))//screen
                {
                    selector = 5;
                    if (choixVisu == 0) { visualizer.GetComponent<MeshRenderer>().material = Mglass; }

                }
                if (Input.GetKey("7"))//screen
                {
                    selector = 6;
                    if (choixVisu == 0) { visualizer.GetComponent<MeshRenderer>().material = Moak; }

                }
            if (Input.GetKey("8"))//screen
            {
                selector = 7;
                if (choixVisu == 0) { visualizer.GetComponent<MeshRenderer>().material = Moak; }

            }
            if (Input.GetKeyDown("v"))//Visualizer
                {
                //Visualizer();
                if (activeVisu == 0)
                {
                    visualizer.SetActive(false);
                    activeVisu = 1;

                }
                else if (activeVisu == 1) { visualizer.SetActive(true); activeVisu = 0; }


            }

                if (Input.GetKey("r"))//Choix type visualizer
                {
                    if (choixVisu == 0)
                    {
                        choixVisu = 1;

                    }


                    if (choixVisu == 1) { choixVisu = 0; visualizer.GetComponent<MeshRenderer>().material = Mvisu; }
                }
            if (Input.GetKey("t"))//Visualizer
            {
                t = 1;
            }
        }

        }


    [Command]
        void CmdAddCube(float selector, int rotation, int rotationZ, int rotationY) //==== A CHANGER UNE FOIS INVENTAIRE FAIT
        {
        int rx = rotation;
        int rz = rotationZ;
        int ry = rotationY;
        //Debug.Log(rr);
        var rotationEuler = Quaternion.Euler(rx, ry, rz);
            var x1 = Mathf.RoundToInt(stoneSpawn.position.x);
            var z1 = Mathf.RoundToInt(stoneSpawn.position.z);
            var y1 = Mathf.RoundToInt(stoneSpawn.position.y);
            if (selector == 0) {
                var Stone = (GameObject)Instantiate(stone, new Vector3(x1, y1, z1), rotationEuler);
                NetworkServer.Spawn(Stone);
            }

            if (selector == 1)
            {
                var Dirt = (GameObject)Instantiate(dirt, new Vector3(x1, y1, z1), rotationEuler);
                NetworkServer.Spawn(Dirt);
            }

            if (selector == 2)
            {
                var Grass = (GameObject)Instantiate(grass, new Vector3(x1, y1, z1), rotationEuler);
                NetworkServer.Spawn(Grass);
            }

            if (selector == 3)
            {
                var Gravel = (GameObject)Instantiate(gravel, new Vector3(x1, y1, z1), rotationEuler);
                NetworkServer.Spawn(Gravel);
            }
            if (selector == 4)
            {
                var Screen = (GameObject)Instantiate(screen, new Vector3(x1, y1, z1), rotationEuler);
                NetworkServer.Spawn(Screen);
            }
            if (selector == 5)
            {
                var Glass = (GameObject)Instantiate(glass, new Vector3(x1, y1, z1), rotationEuler);
                NetworkServer.Spawn(Glass);
            }
            if (selector == 6)
            {
                var Oak = (GameObject)Instantiate(oak, new Vector3(x1, y1, z1), rotationEuler);
                NetworkServer.Spawn(Oak);
            }
        if (selector == 7)
        {
            var Conveyor = (GameObject)Instantiate(conveyor, new Vector3(x1, y1, z1), rotationEuler);
            NetworkServer.Spawn(Conveyor);
        }
    }
        [Command]
        void CmdRemoveCube(GameObject eb) //A CHANGER UNE FOIS INVENTAIRE FAIT (A GARDER SI EQUIVALENT MODE CREATIF)
        {
        Destroy(eb);
        NetworkServer.UnSpawn(eb);

        }
    }
