using System;
using System.Security.Cryptography.X509Certificates;

namespace iDOLLUSION_alpha_v1
{
#if WINDOWS || XBOX
    static class Launcher
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Main game = new Main())
            {
                game.Run();
                
            }
        }
    }
#endif
}

