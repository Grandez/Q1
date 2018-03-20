using System;
using System.Diagnostics;

namespace Q1Base {
   public class LogMgr {
      private static String src  = "Q1 Quant";
      private static String tipo = "Application";

      public static void err(String data) {
         if ((CFG.log & 1) != 0) {
            if (!EventLog.SourceExists(src))
               EventLog.CreateEventSource(src, tipo);

            EventLog.WriteEntry(src, data, EventLogEntryType.Error);
         }
         if ((CFG.log & 2) != 0) console(data);
      }
      public static void info(String data) {
         if (!EventLog.SourceExists(src)) EventLog.CreateEventSource(src, tipo);
         EventLog.WriteEntry(src, data, EventLogEntryType.Information);
      }

      public static void console(String data) {
         Console.WriteLine(DateTime.Now.ToLongTimeString() + " - " + data);
      }
      public static void log(String data) {
         if ((CFG.log & 1) != 0) info(data);
         if ((CFG.log & 2) != 0) console(data);
      }
      public static void debug(String data) {
         if ((CFG.log & 4) != 0) console(data);
      }

   }
}
