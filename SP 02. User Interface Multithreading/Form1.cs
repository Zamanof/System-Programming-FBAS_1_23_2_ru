namespace SP_02._User_Interface_Multithreading
{
    public partial class Form1 : Form
    {
        static int  i = 0;
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    label2.Text = i.ToString();
                    Thread.Sleep(1000);
                }
            }).Start();


        }
    }
}
