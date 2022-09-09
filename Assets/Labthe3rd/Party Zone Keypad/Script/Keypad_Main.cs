
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;
using TMPro;

namespace Labthe3rd.Keypad.Keypad_Main
{
    // bugfixed and improved by n8bits
    
    [UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
    public class Keypad_Main : UdonSharpBehaviour
    {
        [Header("Passwords")]
        public string adminPassword;
        public string staffPassword;
        public string dJPassword;
        public string vIPPassword;

        [Header("Objects to show/hide")]
        public GameObject[] adminObjects;
        public GameObject[] staffObjects;
        public GameObject[] dJObjects;
        public GameObject[] vIPObjects;

        [Header("Internal UI Stuff")]
        public TextMeshProUGUI InputScreen;

        private VRCPlayerApi player;
        private string inputString;
        private bool loggedIn = false;

        [HideInInspector] public string Key;




        public void KeyPressed()
        {
            if (loggedIn == false)
            {
                inputString = string.Concat(inputString, Key);
                InputScreen.text = inputString;
            }


        }

        public void Enter()
        {
            if (loggedIn == false)
            {
                if (!string.IsNullOrEmpty(inputString))
                {
                    if (inputString.Equals(adminPassword))
                    {
                        Debug.Log("Correct Admin Password Entered");

                        for (int i = 0; i < adminObjects.Length; i++)
                        {
                            if (Utilities.IsValid(adminObjects[i]))
                            {
                                adminObjects[i].SetActive(!adminObjects[i].activeSelf);
                            }
                        }
                        Debug.Log("Enabling Staff Objects");
                        for (int i = 0; i < staffObjects.Length; i++)
                        {
                            if (Utilities.IsValid(staffObjects[i]))
                            {
                                staffObjects[i].SetActive(!staffObjects[i].activeSelf);
                            }
                        }
                        Debug.Log("Enabling DJ Objects");
                        for (int i = 0; i < dJObjects.Length; i++)
                        {
                            if (Utilities.IsValid(dJObjects[i]))
                            {
                                dJObjects[i].SetActive(!dJObjects[i].activeSelf);
                            }
                        }
                        Debug.Log("Enabling VIP Objects");
                        for (int i = 0; i < vIPObjects.Length; i++)
                        {
                            if (Utilities.IsValid(vIPObjects[i]))
                            {
                                vIPObjects[i].SetActive(!vIPObjects[i].activeSelf);
                            }
                        }
                        loggedIn = true;
                        InputScreen.text = "ADMIN LOGGED IN";
                        Networking.LocalPlayer.SetPlayerTag("Position", "Admin");
                        inputString = "";
                    }

                    else if (inputString == staffPassword)
                    {
                        Debug.Log("Correct Staff Password Entered");
                        for (int i = 0; i < staffObjects.Length; i++)
                        {
                            if (Utilities.IsValid(staffObjects[i]))
                            {
                                staffObjects[i].SetActive(!staffObjects[i].activeSelf);
                            }
                        }
                        Debug.Log("Enabling DJ Objects");
                        for (int i = 0; i < dJObjects.Length; i++)
                        {
                            if (Utilities.IsValid(dJObjects[i]))
                            {
                                dJObjects[i].SetActive(!dJObjects[i].activeSelf);
                            }
                        }
                        Debug.Log("Enabling VIP Objects");
                        for (int i = 0; i < vIPObjects.Length; i++)
                        {
                            if (Utilities.IsValid(vIPObjects[i]))
                            {
                                vIPObjects[i].SetActive(!vIPObjects[i].activeSelf);
                            }
                        }
                        loggedIn = true;
                        Networking.LocalPlayer.SetPlayerTag("Position", "Staff");
                        InputScreen.text = "STAFF LOGGED IN";
                        inputString = "";
                    }

                    else if (inputString == dJPassword)
                    {
                        Debug.Log("Correct dJ Password Entered");
                        for (int i = 0; i < dJObjects.Length; i++)
                        {
                            if (Utilities.IsValid(dJObjects[i]))
                            {
                                dJObjects[i].SetActive(!dJObjects[i].activeSelf);
                            }
                        }

                        Debug.Log("Enabling VIP Objects");
                        for (int i = 0; i < vIPObjects.Length; i++)
                        {
                            if (Utilities.IsValid(vIPObjects[i]))
                            {
                                vIPObjects[i].SetActive(vIPObjects[i].activeSelf);
                            }
                        }
                        loggedIn = true;
                        Networking.LocalPlayer.SetPlayerTag("Position", "DJ");
                        InputScreen.text = "DJ LOGGED IN";
                        inputString = "";
                    }

                    else if (inputString == vIPPassword)
                    {
                        Debug.Log("Correct VIP Password Entered");
                        for (int i = 0; i < vIPObjects.Length; i++)
                        {
                            if (Utilities.IsValid(vIPObjects[i]))
                            {
                                vIPObjects[i].SetActive(!vIPObjects[i].activeSelf);
                            }
                        }
                        loggedIn = true;
                        Networking.LocalPlayer.SetPlayerTag("Position", "VIP");
                        InputScreen.text = "VIP LOGGED IN";
                        inputString = "";
                    }

                    else
                    {
                        InputScreen.text = "INVALID";
                        inputString = "";
                    }
                }
            }

        }

        public void AdminLogin()
        {

            if (loggedIn == false)
            {
                Debug.Log("Admin Auto Login");
                for (int i = 0; i < adminObjects.Length; i++)
                {
                    if (Utilities.IsValid(adminObjects[i]))
                    {
                        adminObjects[i].SetActive(!adminObjects[i].activeSelf);
                    }
                }
                Debug.Log("Enabling Staff Objects For Admin");
                for (int i = 0; i < staffObjects.Length; i++)
                {
                    if (Utilities.IsValid(staffObjects[i]))
                    {
                        staffObjects[i].SetActive(!staffObjects[i].activeSelf) ;
                    }
                }
                Debug.Log("Enabling dJ Objects For Staff Member");
                for (int i = 0; i < dJObjects.Length; i++)
                {
                    if (Utilities.IsValid(dJObjects[i]))
                    {
                        dJObjects[i].SetActive(!dJObjects[i].activeSelf);
                    }
                }
                Debug.Log("Enabling VIP Objects");
                for (int i = 0; i < vIPObjects.Length; i++)
                {
                    if (Utilities.IsValid(vIPObjects[i]))
                    {
                        vIPObjects[i].SetActive(vIPObjects[i].activeSelf);
                    }
                }

                loggedIn = true;
                InputScreen.text = "ADMIN LOGGED IN";
            }


        }

        public void StaffLogin()
        {

            if (loggedIn == false)
            {
                Debug.Log("Staff Auto Login");
                for (int i = 0; i < staffObjects.Length; i++)
                {
                    if (Utilities.IsValid(staffObjects[i]))
                    {
                        staffObjects[i].SetActive(!staffObjects[i].activeSelf);
                    }
                }
                Debug.Log("Enabling dJ Objects For Staff Member");
                for (int i = 0; i < dJObjects.Length; i++)
                {
                    if (Utilities.IsValid(dJObjects[i]))
                    {
                        dJObjects[i].SetActive(!dJObjects[i].activeSelf);
                    }
                }
                Debug.Log("Enabling VIP Objects");
                for (int i = 0; i < vIPObjects.Length; i++)
                {
                    if (Utilities.IsValid(vIPObjects[i]))
                    {
                        vIPObjects[i].SetActive(!vIPObjects[i].activeSelf);
                    }
                }

                loggedIn = true;
                InputScreen.text = "STAFF LOGGED IN";
            }


        }

        public void dJLogin()
        {

            if (loggedIn == false)
            {
                Debug.Log("dJ Auto Login");
                for (int i = 0; i < dJObjects.Length; i++)
                {
                    if (Utilities.IsValid(dJObjects[i]))
                    {
                        dJObjects[i].SetActive(true);
                    }
                }
                Debug.Log("Enabling VIP Objects");
                for (int i = 0; i < vIPObjects.Length; i++)
                {
                    if (Utilities.IsValid(vIPObjects[i]))
                    {
                        vIPObjects[i].SetActive(!vIPObjects[i].activeSelf);
                    }
                }
                loggedIn = true;
                InputScreen.text = "dJ LOGGED IN";
            }


        }

        public void VIPLogin()
        {

            if (loggedIn == false)
            {
                Debug.Log("VIP Auto Login");
                for (int i = 0; i < vIPObjects.Length; i++)
                {
                    if (Utilities.IsValid(vIPObjects[i]))
                    {
                        vIPObjects[i].SetActive(!vIPObjects[i].activeSelf);
                    }
                }

                loggedIn = true;
                InputScreen.text = "VIP LOGGED IN";
            }


        }


        public void Clear()
        {

            inputString = "";
            InputScreen.text = inputString;
            loggedIn = false;


        }


    }
}

