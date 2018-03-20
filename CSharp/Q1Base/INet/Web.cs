using System;
using System.Net;
using System.IO;
using Q1Base;
namespace Q1Base
{
    public class Web {
        
      public decimal getEuro() {
            String res = getUrl("https://api.fixer.io/latest?symbols=USD");
            int beg = res.LastIndexOf(":");
            String val = res.Substring(beg + 1, res.Length - 3 - beg);
         val = val.Replace(".", ",");
            return Decimal.Parse(val);
        }

        public String getUrl(String url)  {
         String data = null;
         try {
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            return data;
         } catch (Exception e) {
            LogMgr.err(e.Message);
         }
         return data;
        }
    }
}
