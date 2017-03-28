using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Text;

public class MyClient : MonoBehaviour {
    IPHostEntry ipHost ;
    IPAddress ipAddr ;
    IPEndPoint ipEndPoint;
    Socket senderSock;

    byte[] msg ;
    int bytesSend;
    byte[] receiveBuffer = new byte[256];
    byte[] buffer = new byte[256];

    float readCycle = 1.0f;

    // Use this for initialization
    void Start () {
        setupSocket();
    }


    void setupSocket()
    {
         ipHost = Dns.GetHostEntry("127.0.0.1");
         ipAddr = ipHost.AddressList[0];
         ipEndPoint = new IPEndPoint(ipAddr, 1111);

        // Create one Socket object to setup Tcp connection 
         senderSock = new Socket(
            ipAddr.AddressFamily,// Specifies the addressing scheme 
            SocketType.Stream,   // The type of socket  
            ProtocolType.Tcp     // Specifies the protocols  
            );

        senderSock.Connect(ipEndPoint);
    }

    // Update is called once per frame
    void Update () {
        //while (senderSock.Available > 0)
        //{
        //    bytesSend = senderSock.Receive(receiveBuffer);

        //    Console.WriteLine("Server: Read {0} bytes", bytesSend);
        //}
        if (readCycle < 0)
        {
            //bytesSend = senderSock.Receive(receiveBuffer);

            //string str = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
            //print(str);
            //readCycle = 1.0f;
           // print(ReceiveData());

            Receive(senderSock, buffer, 0, buffer.Length, 100);
            string str = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
            print(str);

        }
        readCycle = readCycle - Time.deltaTime;
    }

    public string ReceiveData()
    {
        System.Net.Sockets.Socket receiveSocket;
        byte[] buffer = new byte[256];

       // receiveSocket = senderSock.Accept();

       // var bytesrecd = receiveSocket.Receive(buffer);

        //receiveSocket.Close();

        //System.Text.Encoding encoding = System.Text.Encoding.UTF8;

        return "";// encoding.GetString(buffer);
    }

    public void Receive(Socket socket, byte[] buffer, int offset, int size, int timeout)
    {
        int startTickCount = Environment.TickCount;
        int received = 0;  // how many bytes is already received
        do
        {
            if (Environment.TickCount > startTickCount + timeout)
                throw new Exception("Timeout.");
            try
            {
                received += socket.Receive(buffer, offset + received, size - received, SocketFlags.None);
            }
            catch (SocketException ex)
            {
                if (ex.SocketErrorCode == SocketError.WouldBlock ||
                    ex.SocketErrorCode == SocketError.IOPending ||
                    ex.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
                {
                    // socket buffer is probably empty, wait and try again
                    //this.Sleep(30);
                }
                else
                    throw ex;  // any serious error occurr
            }
        } while (received < size);
    }
}
