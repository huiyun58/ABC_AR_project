using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if !UNITY_EDITOR && UNITY_METRO
using Windows.Networking.Sockets;
using Windows.Networking.Connectivity;
using Windows.Networking;
#else
using System.Net;
using System.Net.Sockets;
using System.Threading;
#endif

public class UDPClient : MonoBehaviour
{

    public int port = 25001;
    private Queue<string> receivedUDPPacketQueue = new Queue<string>();

    public string GetLatestUDPPacket()
    {
        string message = "";
        while (receivedUDPPacketQueue.Count > 0)
        {
            message = receivedUDPPacketQueue.Dequeue();
            //UnityEngine.Debug.Log(message);
        }
        return message;
        //return "0,0,0,0,0,0,0";
    }


    // Update is called once per frame
    void Update()
    {

    }

    //public void SetText(string mytext)
    //{
    //    Text txt = transform.Find("Text").GetComponent<Text>();
    //    txt.text = mytext;
    //}


    // when not having the unity editor
#if !UNITY_EDITOR && UNITY_METRO
 
    DatagramSocket socket;
   
    async void Start() {
        socket = new DatagramSocket();
        socket.MessageReceived += Socket_MessageReceived;
        HostName IP = null;
        try
        {
            var icp = NetworkInformation.GetInternetConnectionProfile();
 
            IP = Windows.Networking.Connectivity.NetworkInformation.GetHostNames()
            .SingleOrDefault(
                hn =>
                    hn.IPInformation?.NetworkAdapter != null && hn.IPInformation.NetworkAdapter.NetworkAdapterId
                    == icp.NetworkAdapter.NetworkAdapterId);
 
            await socket.BindEndpointAsync(IP, port.ToString());
        }
        catch (Exception e)
        {  
            //Debug.Log(e.ToString());
            //Debug.Log(SocketError.GetStatus(e.HResult).ToString());
            return;
        }
 
        //Debug.Log(objectName + ": DatagramSocket setup done...");
 
        //Below line to show that the code in this section is being compiled and NOT  ran in Unity editor  (being ran on the HL2 device)
 
        //SetText("Not in Unity Editor");
    }
 
    private async void Socket_MessageReceived(Windows.Networking.Sockets.DatagramSocket sender,
        Windows.Networking.Sockets.DatagramSocketMessageReceivedEventArgs args)
    {
        //Debug.Log("Received message: ");
        //Read the message that was received from the UDP echo client

        //  Comment all this out to change to fixed buffer sizes

        //Stream streamIn = args.GetDataStream().AsStreamForRead();
        //StreamReader reader = new StreamReader(streamIn);
        //string message = await reader.ReadLineAsync();

        // Debug.Log("Message: " + message);

        // receivedUDPPacketQueue.Enqueue(message);

        using (var reader = args.GetDataReader())
        {
            var buf = new byte[reader.UnconsumedBufferLength];
            reader.ReadBytes(buf);
            string message = System.Text.Encoding.UTF8.GetString(buf);
            receivedUDPPacketQueue.Enqueue(message);
            // debug.log("message: " + message);

        }
    }

    private void OnDestroy() {
        if (socket != null) {
            socket.MessageReceived -= Socket_MessageReceived;
            socket.Dispose();
        }
    }
 
#else

    Thread receiveThread;
    UdpClient client;

    private bool shouldTerminate = true;

    public void Start()
    {
        //Debug.Log(objectName + ": Starting UDP");
        shouldTerminate = false;
        receiveThread = new Thread(new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();


        //Below line to show that the code in this section is being compiled and ran in Unity editor
        //SetText("Running in Unity Editor");
    }


    void OnDestroy()
    {
        shouldTerminate = true;
        client.Close(); // trigger the exception in thread
        receiveThread.Abort();

        while (receiveThread.IsAlive)
        {
            // Debug.Log(objectName + ": Still alive");
        }
        //Debug.Log(objectName + ": Receive thread stopped");
    }



    // receive thread
    private void ReceiveData()
    {
        client = new UdpClient(port);
        //Debug.Log(objectName + ": Receive thread starts");
        while (!shouldTerminate)
        {
            try
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = client.Receive(ref anyIP);

                string text = System.Text.Encoding.UTF8.GetString(data);

                // Debug.Log("EditorUDPClient: Packet >> " + text);

                receivedUDPPacketQueue.Enqueue(text);

            }
            catch (Exception err)
            {
                Debug.Log(err.ToString());
            }
        }
    }

#endif

}

