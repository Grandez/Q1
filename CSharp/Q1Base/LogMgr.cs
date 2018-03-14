using System;
using System.Diagnostics;

namespace Q1Base {
   public class LogMgr {
      private static String src  = "Q1 Quant";
      private static String tipo = "Application";

      public static void err(String data) {
         if (!EventLog.SourceExists(src))
             EventLog.CreateEventSource(src, tipo);

         EventLog.WriteEntry(src, data, EventLogEntryType.Error);
      }
      public static void info(String data) {
         if (!EventLog.SourceExists(src)) EventLog.CreateEventSource(src, tipo);
         EventLog.WriteEntry(src, data, EventLogEntryType.Information);
      }

   }
}
