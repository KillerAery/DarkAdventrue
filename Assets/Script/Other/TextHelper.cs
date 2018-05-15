using UnityEngine;
using System.Collections;

public class TextHelper : MonoBehaviour
{

    // Use this for initialization
    private int max;//To determine number of characters
    private int total_max;//To determine number of  all characters
    private int current_index;//To determine the current messege
    public float SlowTheSpeed;//This to define the speed of the characters animation

    public int No_Lines;//To determine the number of lines per view 
    private int No_Cur_Lines;//To determine the current number of line 
    private bool DoneAnimation;//To determine when the all messege finish 
    private string tempMes;//Current messege
    public Vector2 pos;//Pos of the messege
    public string[] Message;//All Messages
    public GUIStyle style;//Our Style of the messege


    void Start()
    {
        No_Cur_Lines = 0;
        tempMes = Message[0];
        DoneAnimation = false;
        current_index = 0;
        max = 0;
        total_max = 0;
        StartCoroutine("UpdateAnimation");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (DoneAnimation)
            {
                DoneAnimation = false;
                max = 0;
                total_max = 0;
                tempMes = "";
            }
        }

    }
    //To get the next messege from the array and determain if we finish all the messeges
    void NextMes()
    {
        DoneAnimation = false;

        if (current_index < Message.Length - 1)
        {
            max = 0;
            current_index++;
            tempMes += "\n" + Message[current_index];
            No_Cur_Lines++;
            if (No_Lines < No_Cur_Lines + 1)
            {
                tempMes = Message[current_index];
                max = 0;
                total_max = 0;
                No_Cur_Lines = 0;
            }
        }
        else
        {
            DoneAnimation = true;
        }
       
    }
    void OnGUI()
    {
        GUI.TextArea(new Rect(pos.x, pos.y, Screen.width, Screen.height), tempMes, total_max, style);
    }

    //This to help to call the next character and go to the next messege when the characters of the current messege finish
    IEnumerator UpdateAnimation()
    {
        yield return new WaitForSeconds(SlowTheSpeed);
        max++;
        total_max++;

        if (max > Message[current_index].Length)
        {
            NextMes();

        }
        StartCoroutine("UpdateAnimation");
    }
}
