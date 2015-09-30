using System;

namespace CuocChienVuTru
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (CuocChienVuTru game = new CuocChienVuTru())
            {
                game.Run();
            }
        }
    }
#endif
}

