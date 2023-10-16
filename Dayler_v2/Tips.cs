namespace Dayler_v2
{
    internal class Tips
    {
        string naz;
        DateTime dt;
        string sod;

        public static void Getter(Tips tp)
        { 
            Console.Write(tp.dt.ToString("t") + "|");
            Console.WriteLine(" " + tp.naz);
            Console.WriteLine("---------------------");
            Console.WriteLine(tp.sod);
        }

        public void Getter_name(Tips tp)
        {
            Console.Write("  " + tp.naz);
            Console.WriteLine(" " + tp.dt.ToString("t"));
        }

        public static Tips Setter(string naz, string sod)
        {
            Tips n = new Tips();
            n.naz = naz;
            n.dt = DateTime.Now;
            n.sod = sod;
            return n;
        }
    }


}