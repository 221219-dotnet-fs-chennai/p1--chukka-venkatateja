using System;
using System.Xml.Linq;
using Serilog;
namespace datahandle
{

    public class Logging
    {
        public Logging()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File(@"C:\Users\Chukka Venkata Teja\Desktop\fetch_trainee_p0\venkat\Logging_file.txt").CreateLogger();
        }



        public void InformationWriter(string q)
        {
            Log.Information(q);
        }

        public void ErrorWriter(Exception q)
        {
            Log.Information("ERROR");
            Log.Information("");
            Log.Error(Convert.ToString(q));
            Log.Information("");
            Log.Information("-----------------------------------------------------------");

        }
    }
}

