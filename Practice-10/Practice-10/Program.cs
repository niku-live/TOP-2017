using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Practice_10
{
    class Program
    { 

        //=======>01 - for Lazy demo 
        static List<int> CreateNewList()
        {
            //Image that very big List (with 1 mln. entries) is created
            return new List<int>() { 1, 2, 4, 5, 6 };
        }

        static Lazy<List<int>> _list = new Lazy<List<int>>(CreateNewList);
        //do not forget - you can always use anonymous methods and lambdas in place of actual method
        //for example:
        //static Lazy<List<int>> _list = new Lazy<List<int>>(() => new List<int>() { 1, 2, 4, 5, 6 });

        static void Main(string[] args)
        {
            //>>useless example
            Lazy<List<int>> _list2 = new Lazy<List<int>>(() => new List<int>() { 1, 2, 4, 5, 6 });
            var actValue2 = _list2.Value;
            //<<useless example
            //why it is useless? Because you gain nothing in fact you lose performance, as now two objects must be created
            //so in this case you should just use "var actValue2 = new List<int>() { 1, 2, 4, 5, 6 };"

            //>>kinda useful example
            var userInput = Console.ReadLine();
            if (userInput == "CreateList")
            {
                var actValue = _list.Value;
                //do something with actValue
            }
            //<<kinda useful example
            //why it is more useful than previous example? Because actual object (and it takes lot of memory and time to create) is
            //created only when user enters "CreateList" so it is high possibility that object will never be created (and we will save some memory and time)

            //<=======01 - for Lazy demo

            //=======>02 - Conditional compilation demo

            //example code snippet 1:
            Console.WriteLine("Normal");
            //example code snippet 2:
#if DEBUG
            Console.WriteLine("Debug on");
#endif
            //example code snippet 3:
#if SPEC
            Console.WriteLine("Spec. ON");
#endif
            //example code snippet 4:
#if SPEC2
            Console.WriteLine("Spec. ON");
#endif
            //example code snippet 5:
            bool debug = true;
            if (debug)
            {
                Console.WriteLine("Debug on");
            }

            //For comditional compilation example we have 4 configurations: Release, Debug, Debug SPEC and DEBUG SPEC2
            //Look at project properties window to see every configuration detailed info
            //Release configuration has no compilations symbols defined
            //Debug configuration has default DEBUG and TRACE symbols defined
            //Debug SPEC configuration is copied from Debug config and then additonal symbol SPEC is defined
            //Debug SPEC2 configuration is copied from Debug SPEC config and then additonal symbol SPEC2 is defined. 
            //It demonstrates how to define more than one symbol

            //So code snippet 1 is always compiled and executed
            //Code snippet 2 is compiled and executed if Debug, Debug SPEC or Debug SPEC2 configuration is used
            //Code snippet 3 is compiled and executed if Debug SPEC or Debug SPEC2 configuration is used
            //Code snippet 4 is compiled and executed only if Debug SPEC2 configuration is used

            //Conditional compilation is useful for implementing debug messages
            //You can argue that you can also do it in a different way, for example like code snippet 5 is done.
            //The main difference between snippet 5 and snippet 2 is that when release configuration is used 
            //code snippet 2 is removed from final binary, so final binary is smaller and that code 
            //will never apper and will never take any processor time
            //code snippet 5 is different - code will be in final binary and "if" sentence check will be executed
            //so in this case you increase binary size and use processor time for nothing to gain

            //<=======02 - Conditional compilation demo

            //>=======03 - Config files demo

            //Method 1: Using ConfigurationManager
            //See file App.config to see how default configuration value is defined
            
            //Method 1a: Get current value of setting named "setting1"
            Console.WriteLine(ConfigurationManager.AppSettings["setting1"]);

            //Method 1b: Set and save new value

            //Select scope
            //ConfigurationUserLevel.None - setting valid for whole application
            //ConfigurationUserLevel.PerUserRoaming - for current users
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
             //make changes
             config.AppSettings.Settings["setting1"].Value = "test";
             //save to apply changes
             config.Save(ConfigurationSaveMode.Modified);
            //refresh current data in ConfigurationManager
             ConfigurationManager.RefreshSection("appSettings");

            //Method 2: Using Properties defined using Project Properties window (do not forget to rebuild project before using properties) 
            //Method 2a: Get current value of application level setting named "SettingM2App".
            Console.WriteLine(Properties.Settings.Default.SettingM2App);
            //Method 2a: Get current value of user level setting named "SettingM2User"
            Console.WriteLine(Properties.Settings.Default.SettingM2User);

            //Method 2b: Change user level setting "SettingM2User"
            Properties.Settings.Default.SettingM2User = "test2";
            Properties.Settings.Default.Save();
            //<=======03 - Config files demo

            //>=======04 - Web services demo

            //Using existing web services (https://old.lb.lt/webservices/ExchangeRates/ExchangeRates.asmx)
            //Select "Add service reference..." and enter given webservice url
            //Special proxy classes will be created, use them to communicate with WS 

            //Create WS client
            LB.ExchangeRatesSoapClient client = new LB.ExchangeRatesSoapClient("ExchangeRatesSoap");

            //Get rate for currency "EUR" for today date
            Console.WriteLine(client.getExchangeRate("EUR", DateTime.Now.ToString("yyyy-MM-dd")));
            //Get list of all currencies
            Console.WriteLine(client.getListOfCurrencies().OuterXml);           

            //Creating new WS. See Lecture-10-WS project for server side code, this is only client side code 
            //Create client
            HelloWS.OurFirstWebServiceClient helloClient = new HelloWS.OurFirstWebServiceClient();
            //Call out custom operation
            Console.WriteLine(helloClient.GetHelloMessage("Darth Wilder"));
            //<=======04 - Web services demo
            Console.ReadLine();
        }
    }
}
