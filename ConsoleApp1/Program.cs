using ConsoleApp1.NewFolder;


namespace ConsoleApp1
{
    class Program
    {
        private const string V = "sassasasasas";

        static void Main(string[] args)
        {
            //MessageConatainer s = new MessageConatainer("s");
            

            Player player = new Player(new List<string> { "DASD WESG HILOP","KRQ Bzxp yw{}"});
            player.Play();
            //player.Play();
            Thread.Sleep(3000);
            player.Stop();

            Thread.Sleep(3000);
            player.Play();

            Thread.Sleep(3000);
            player.Next();

            Thread.Sleep(3000);
            player.Play();
            Thread.Sleep(3000);
            player.Next();

            Thread.Sleep(3000);
            player.Play();

            Thread.Sleep(10000);
        }
    }
}