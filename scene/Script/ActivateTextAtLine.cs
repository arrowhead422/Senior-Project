using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace UnityStandardAssets.Characters.ThirdPerson
{
    
    public class ActivateTextAtLine : MonoBehaviour
    {
        public TextAsset theText;

        public int starLine;
        public int endLine;

        public TextBoxManager theTextBox;

        public bool requireButtonPress;
        private bool waitforPress;

        public bool destroyWhenActivated;

        // Use this for initialization
        void Start()
        {
            theTextBox = FindObjectOfType<TextBoxManager>();

        }

        // Update is called once per frame
        void Update()
        {
            if(waitforPress && Input.GetKeyDown(KeyCode.J))
            {
                theTextBox.ReloadScript(theText);
                theTextBox.currentLine = starLine;
                theTextBox.endAtLine = endLine;
                theTextBox.EnableTextBox();

                if (destroyWhenActivated)
                {
                    Destroy(gameObject);
                }
            }
        }

        void OnTriggerEner3D(Collider other)
        {
            if(other.name == "player")
            {
                if (requireButtonPress)
                {
                    waitforPress = true;
                    return;
                }
                theTextBox.ReloadScript(theText);
                theTextBox.currentLine = starLine;
                theTextBox.endAtLine = endLine;
                theTextBox.EnableTextBox();

                if (destroyWhenActivated)
                {
                    Destroy(gameObject);
                }

            }
        }

        void OnTriggerExit(Collider other)
        {
            if(other.name == "player")
            {
                waitforPress = false;
            }
        }
    }
}
