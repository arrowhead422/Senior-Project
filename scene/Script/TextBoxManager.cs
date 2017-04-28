﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class TextBoxManager : MonoBehaviour
    {

        public GameObject textBox;

        public Text theText;

        public TextAsset textFile;
        public string[] textLines;

        public int currentLine;
        public int endAtLine;

        public ThirdPersonCharacter player;


        public bool isActive;

        public bool stopPlayerMovement;

        private bool isTyping = false;
        private bool cancelTyping = false;

        public float typeSpeed;

        // Use this for initialization
        void Start()
        {

            player = FindObjectOfType<ThirdPersonCharacter>();

            if (textFile != null)
            {
                textLines = (textFile.text.Split('\n'));
            }

            if (endAtLine == 0)
            {
                endAtLine = textLines.Length - 1;
            }
            if (isActive)
            {
                EnableTextBox();
            }
            else
            {
                DisableTextBox();
            }
        }

        void Update()
        {
            if (!isActive)
            {
                return;
            }

            //theText.text = textLines[currentLine];

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (!isTyping)
                {

                    currentLine += 1;

                    if (currentLine > endAtLine)
                    {
                        DisableTextBox(); //the universal class :)
                    }
                    else
                    {
                        StartCoroutine(TextScroll(textLines[currentLine]));
                    }
                }
                else if (isTyping && !cancelTyping)
                {
                    cancelTyping = true;
                }
            }
         
        }

        private IEnumerator TextScroll (string lineOfText)
        {
            int letter = 0;
            theText.text = "";
            isTyping = true;
            cancelTyping = false;
            while (isTyping && !cancelTyping && (letter < lineOfText.Length - 1))
            {
                theText.text += lineOfText[letter];
                letter += 1;
                    yield return new WaitForSeconds(typeSpeed);
            }
            theText.text = lineOfText;
            isTyping = false;
            cancelTyping = false;
       }

        public void EnableTextBox()
        {
            textBox.SetActive(true);
            isActive = true;

            if (stopPlayerMovement)
            {
                player.canMove = false;
            }

            StartCoroutine(TextScroll(textLines[currentLine]));
        }

        public void DisableTextBox()
        {
            textBox.SetActive(false);
            isActive = false;
            player.canMove = true;
        }

        public void ReloadScript(TextAsset theText)
        {
            if(theText != null)
            {
                textLines = new string[1];
                textLines = (theText.text.Split('\n'));
            }
        }


    }
}