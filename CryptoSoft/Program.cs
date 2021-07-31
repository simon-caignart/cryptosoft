using CryptoSoft;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace CryptoSoft2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            // String containing the source path of the file
            string sourceFilePath = "";

            // String containing the destination path of the file
            string destFilePath = "";

            // Crypto Key
            string key;

            //Char array of the crypto key
            byte[] keyInBytes = new byte[0];

            // Creating new instance of the stopwatch, used to get the encryption time
            Stopwatch timer = new Stopwatch();

            // Path of the cryptoKey folder and text file
            string configFolderPath = Path.GetFullPath(@"Config");
            string cryptoKeyPath = Path.GetFullPath(@"Config\cryptoKey.txt");

            // Path of the json configFile of EasySave
            string configFilePath = Path.GetFullPath(@"Config\config.json");
            ConfigFileJson configFileJson;
            string Data;

            configFileJson = new ConfigFileJson();

            // Read the file containing the crypto key, if it does not exist, generate a random key and create the file
            try
            {
                if (File.Exists(configFilePath))
                {
                    Data = File.ReadAllText(configFilePath);

                    configFileJson = JsonConvert.DeserializeObject<ConfigFileJson>(Data);

                    key = configFileJson.cryptoKey;
                }
                else
                {
                    key = File.ReadAllText(cryptoKeyPath);
                }
            }
            catch (Exception)
            {
                // Generate a random string of 64 bit 
                StringBuilder strbuilder = new StringBuilder();
                Random random = new Random();

                for (int i = 0; i < 64; i++)
                {
                    // Generate floating point numbers
                    double myFloat = random.NextDouble();
                    // Generate the char using below logic
                    var myChar = Convert.ToChar(Convert.ToInt32(Math.Floor(25 * myFloat) + 65));
                    strbuilder.Append(myChar);
                }

                key = strbuilder.ToString();

                //Create the directory if it does not exist
                Directory.CreateDirectory(configFolderPath);

                //Create the file in the directory with the key
                File.WriteAllText(cryptoKeyPath, key);
            }

            if (args[0] == "source")
            {
                sourceFilePath = args[1];
            }
            else
            {
                Environment.Exit(-1);
            }

            if (args[2] == "destination")
            {
                destFilePath = args[3];
            }
            else
            {
                Environment.Exit(-2);
            }

            // Starting the timer to get the encryption time
            timer.Start();

            // fills the char array of the crypto key
            try
            {
                keyInBytes = Encoding.ASCII.GetBytes(key);

                if (keyInBytes.Length < 64)
                {
                    Environment.Exit(-1);
                }
            }
            catch (Exception)
            {
                Environment.Exit(-3);
            }

            try
            {
                // Encrypt or decrypt the file with XOR operation
                using (FileStream fsOut = new FileStream(destFilePath, FileMode.Create))
                {
                    using (FileStream fsIn = new FileStream(sourceFilePath, FileMode.Open))
                    {
                        int data;
                        int i = 0;

                        while ((data = fsIn.ReadByte()) != -1)
                        {
                            if (i >= key.Length)
                            {
                                i = 0;
                            }

                            byte b = (byte)((byte)data ^ (byte)keyInBytes[i]);

                            fsOut.WriteByte(b);
                        }
                    }
                }
            }
            catch (Exception)
            {
                Environment.Exit(-4);
            }


            // File succesfully encrypted and created, return the encryption time
            timer.Stop();
            Environment.Exit((int)timer.ElapsedMilliseconds);
        }
    }
}