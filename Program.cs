using System;
using System.IO;
using System.Text;

namespace DotNetAssemblyToTSql
{
    class Program
    {
        static void Main(string[] args)
        {
            // This App converts .NET .dll files to a hexadecimal SQL Server appropriate variant
            //  to allow install it without using of files in a file system of DB server.

            // ITretyakov (it3xl.com): Simple converter utility with according to
            // http://stackoverflow.com/questions/10583862/create-sql-server-create-assembly-script-automatically/10584202#10584202
            // http://stackoverflow.com/questions/4737686/how-to-generate-sql-clr-stored-procedure-installation-script-w-o-visual-studio/4740325#4740325

            var assemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            try
            {
                if (args.Length == 0)
                {
                    Console.Write("<{0}: Error - no input data>", assemblyName);
                    return;
                }
                var pathTo = args[0];
                string absPath;
                if (Path.IsPathRooted(pathTo))
                {
                    absPath = pathTo;
                }
                else
                {
                    absPath = Path.Combine(Environment.CurrentDirectory, pathTo);
                }
                if (!File.Exists(absPath))
                {
                    Console.Write("<{0}: There'is no such a file {1}>", assemblyName, absPath);
                    return;
                }

                var hexadecimal = new StringBuilder();
                using (var fileStream = File.OpenRead(pathTo))
                {
                    int @byte;
                    while (0 <= (@byte = fileStream.ReadByte()))
                    {
                        hexadecimal.AppendFormat("{0:X2}", @byte);
                    }
                }

                var hexadecimalForSql = "0x" + hexadecimal;

                Console.Write(hexadecimalForSql);
            }
            catch (Exception ex)
            {
                Console.Write("<{0}: Exception {1}>", assemblyName, ex.Message);
                return;
            }
        }
    }
}
