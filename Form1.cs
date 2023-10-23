using System.Net;
using System.Net.Sockets;
using System.Text;

namespace clientsocket
{
    public partial class Form1 : Form
    {
        Socket socketworker = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        public void mssg()
        {
            try
            {
                while (true)
                {
                    byte[] buffer = new byte[1024];
                    int count = socketworker.Receive(buffer);
                    if (count > 0)
                    {
                        string msg = Encoding.Unicode.GetString(buffer, 0, count);
                        listBox1.Items.Add(msg);
                    }
                }
            }
            catch
            {

                ;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("192.168.41.1"), 5050);
            socketworker.Connect(iPEndPoint);

            MessageBox.Show("??? ???");
            Thread thread = new Thread(new ThreadStart(mssg));
            thread.Start();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] barray = new byte[1024];
            barray = Encoding.Unicode.GetBytes(textBox1.Text);
            socketworker.Send(barray);
        }
    }
}