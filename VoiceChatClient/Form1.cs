using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using System.Net.Sockets;
using System.IO;
using System.Net;



namespace VoiceChatClient
{
    public partial class Form1 : Form
    {
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string command, StringBuilder retstrign, int Returnlength, IntPtr callback);
        
        string recordingPath = "C:\\Users\\mncmilan\\Desktop\\test.wav";
        string tempPath = "C:\\Users\\mncmilan\\Desktop\\temp.wav";

        private const int bufSize = 100000000;
        private State state = new State();
        private EndPoint epFrom = new IPEndPoint(IPAddress.Any, 0);
        private AsyncCallback recv = null;
        
        Socket socket;
        public class State
        {
            public byte[] buffer = new byte[bufSize];
        }

        public Form1()
        {
            InitializeComponent();
            mciSendString("open new Type waveaudio alias recsound", null, 0, IntPtr.Zero);
            recordButton.Click += new EventHandler(this.recordButton_Click);

            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, 9050);

            //Creamos el socket 
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            try
            {
                socket.Connect(ipep);//Intentamos conectar el socket
            }
            catch (SocketException)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }
            
        }

        private void recordButton_Click(object sender, EventArgs e)
        {
            mciSendString("record recsound", null, 0, IntPtr.Zero);
            this.BackColor = Color.Green;
            stopRecordButton.Click += new EventHandler(this.stopRecordButton_Click); 

        }

        private void stopRecordButton_Click(object sender, EventArgs e)
        {
            mciSendString("save recsound " + recordingPath, null, 0, IntPtr.Zero);
            mciSendString("close recsound", null, 0, IntPtr.Zero);
            this.BackColor = Color.Empty;
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            (new Microsoft.VisualBasic.Devices.Audio()).Play(recordingPath);
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            byte[] voiceMessage = File.ReadAllBytes(recordingPath);
            socket.Send(voiceMessage);
            socket.BeginSend(voiceMessage, 0, voiceMessage.Length, SocketFlags.None, (ar) =>
            {
                State so = (State)ar.AsyncState;
                int bytes = socket.EndSend(ar);
                MessageBox.Show("sent");
            }, state);
                
        }

        private void receiveButton_Click(object sender, EventArgs e)
        {
            socket.BeginReceiveFrom(state.buffer, 0, bufSize, SocketFlags.None, ref epFrom, recv = (ar) =>
            {
                State so = (State)ar.AsyncState;
                int bytes = socket.EndReceiveFrom(ar, ref epFrom);
                socket.BeginReceiveFrom(so.buffer, 0, bufSize, SocketFlags.None, ref epFrom, recv, so);
            }, state);
            System.IO.File.WriteAllBytes(tempPath, state.buffer);
            (new Microsoft.VisualBasic.Devices.Audio()).Play(tempPath);  
                
        }
        
    }
}
