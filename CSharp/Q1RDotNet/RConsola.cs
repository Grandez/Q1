using RDotNet.Devices;
using System.Text;

namespace Q1RDotNet {
   public class RConsola : ConsoleDevice, ICharacterDevice { 
         public StringBuilder sb = new StringBuilder();

         new public void WriteConsole(string output, int length, RDotNet.Internals.ConsoleOutputType outputType) {
            sb.Append(output);
         }
   }
}
