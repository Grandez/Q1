using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1Base {
    public static class CFG {
      private static decimal euro = 1.0m;
      public static Boolean Loading = false;
      public static int Interval = 300000;
      public static int mode = 0x01;
      public static int log = 0x01;

      public static String getDataBase() {
         return getKeyString("Database");
        }
        public static void setDatabase(String valor) {
         setKeyString("Database", valor);
        }
        public static String getProvider() {
          return getKeyString("Provider");
        }
        public static void setProvider(String valor) {
           setKeyString("Provider", valor);
        }
        public static String getMasterSheet() {
           return getKeyString("Hoja");
        }
        public static void setMasterSheet(String valor) {
           setKeyString("Hoja", valor);
        }

      public static decimal getEuro() {
           return euro;
        }
        public static void setEuro(decimal valor) {
           euro = valor;
        }

      private static String getKeyString(String clave) {
         String res = null;
         RegistryKey key = getRoot();

         if (key != null) {
              res = (String) key.GetValue(clave, "");
              key.Close();
           }
           return res;
        }

      private static void setKeyString(String name, String value) {
         RegistryKey root = getRoot();
         Registry.SetValue(name, value, RegistryValueKind.String);
      }

      private static RegistryKey getRoot() {
         RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Q1", true);
         if (key == null) {
            Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Q1");
            key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Q1", true);
         }
         return key;
      }
    }
}
