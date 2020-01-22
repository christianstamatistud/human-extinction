using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CS
{
    public class SwitchManager : MonoBehaviour
    {
        public delegate void OnResetTerminal();
        public event OnResetTerminal resetTerminal;

        public static SwitchManager Instance;
        public string worldToGuess = "fire";
        public string currentWord = "";

        public Transform[] lights;

        private void Awake()
        {
            Instance = this;
            //inputHandler = FindObjectOfType<InputHandler>();
        }

        private void OnEnable()
        {
            //inputHandler.playerInteract += GuessWord;
        }

        private void OnDisable()
        {
            //inputHandler.playerInteract -= GuessWord;

        }

        private void Update()
        {

        }

        public void AddLetter(string letter)
        {
            currentWord += letter;

        }

        public void GuessWord()
        {
            if(worldToGuess == currentWord)
            {
                Debug.Log("world guess");
                //all buttons should be green
            }

            //first letter
            if(currentWord.Contains("f"))
            {
                Debug.Log("contains f");
                Debug.Log(currentWord.IndexOf("f"));


                if(currentWord.IndexOf("f") == 0)
                {
                    Renderer r;
                    r = lights[currentWord.IndexOf("f")].GetComponent<Renderer>();
                    r.material.SetColor("_BaseColor", Color.green);

                }
                else
                {
                    Renderer r;
                    r = lights[currentWord.IndexOf("f")].GetComponent<Renderer>();
                    r.material.SetColor("_BaseColor", Color.red);
                }
             
            }

            //second letter
            if (currentWord.Contains("i"))
            {
                Debug.Log("contains i");
                Debug.Log(currentWord.IndexOf("i"));


                if (currentWord.IndexOf("i") == 1)
                {
                    Renderer r;
                    r = lights[currentWord.IndexOf("i")].GetComponent<Renderer>();
                    r.material.SetColor("_BaseColor", Color.green);

                }
                else
                {
                    Renderer r;
                    r = lights[currentWord.IndexOf("i")].GetComponent<Renderer>();
                    r.material.SetColor("_BaseColor", Color.red);
                }

            }

            //third letter
            if (currentWord.Contains("r"))
            {
                Debug.Log("contains r");
                Debug.Log(currentWord.IndexOf("r"));


                if (currentWord.IndexOf("r") == 2)
                {
                    Renderer r;
                    r = lights[currentWord.IndexOf("r")].GetComponent<Renderer>();
                    r.material.SetColor("_BaseColor", Color.green);

                }
                else
                {
                    Renderer r;
                    r = lights[currentWord.IndexOf("r")].GetComponent<Renderer>();
                    r.material.SetColor("_BaseColor", Color.red);
                }

            }

            //fourth letter
            if (currentWord.Contains("e"))
            {
                Debug.Log("contains e");
                Debug.Log(currentWord.IndexOf("e"));


                if (currentWord.IndexOf("e") == 3)
                {
                    Renderer r;
                    r = lights[currentWord.IndexOf("e")].GetComponent<Renderer>();
                    r.material.SetColor("_BaseColor", Color.green);

                }
                else
                {
                    Renderer r;
                    r = lights[currentWord.IndexOf("e")].GetComponent<Renderer>();
                    r.material.SetColor("_BaseColor", Color.red);
                }

            }


            StartCoroutine(ClearObjects());




        }

        IEnumerator ClearObjects()
        {
            yield return new WaitForSeconds(3);

            foreach (Transform t in lights)
            {
                Renderer r;
                r = t.GetComponent<Renderer>();
                r.material.SetColor("_BaseColor", Color.white);
                currentWord = "";
                resetTerminal();
            }

        }
    }

}

