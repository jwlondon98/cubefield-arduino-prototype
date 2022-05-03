using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class SerialConn : MonoBehaviour
{
    #region Declarations

    public float startDelay;

    SerialPort stream = new SerialPort("COM6", 19200);
    public string dataString;
    public GameObject obj;
    private Rigidbody rb;

    public float vel;
    public float maxVel;
    public float sideSpeed;
    public float fwdSpeed;
    public Vector3 pos;
    public bool pressed;

    public bool streamOpen;
    public bool canMove;

    #endregion  

    #region Unity Methods

    private void Awake()
    {
        rb = obj.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        OpenStream();
    }

    private void Update()
    {
        if (streamOpen && canMove)
        {
            ReadStream();
        }
    }

    #endregion  

    #region Custom Methods

    [ContextMenu("Open Stream")]
    public void OpenStream()
    {
        stream.Open();
        stream.ReadTimeout = 5000;
        Debug.Log("stream open: " + stream.IsOpen);

        streamOpen = stream.IsOpen;

        StartCoroutine(StartMovement());
    }

    private IEnumerator StartMovement()
    {
        yield return new WaitForSeconds(startDelay);

        canMove = true;
    }

    private void ReadStream()
    {
        try
        {
            var line = stream.ReadLine();
            Debug.Log(line);
            
            var data = line.Split(',');
            var x = float.Parse(data[0]);
            var y = float.Parse(data[1]);
            //pos = new Vector3(-y, 0, x) * speed;
            pos = new Vector3(x * sideSpeed, 0, fwdSpeed);
            //obj.transform.Translate(pos);

            vel = rb.velocity.magnitude;
            if (vel <= maxVel)
                rb.AddForce(pos);
            
            var btnPress = int.Parse(data[2]);
            pressed = btnPress == 1 ? true : false;
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }

    private void OnApplicationQuit()
    {
        stream.Close();
    }

    #endregion  
}
