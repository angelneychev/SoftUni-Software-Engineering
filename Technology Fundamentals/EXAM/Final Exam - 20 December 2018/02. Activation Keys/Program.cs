using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02._Activation_Keys
{
    class Program
    {
        static void Main()
        {
            string inputLine = Console.ReadLine();
            string[] command = inputLine.Split("&");

            string serialNumber = string.Empty;
            bool verifyString = true;
            for (int i = 0; i < command.Length; i++)
            {
                //T8KJZ-U235Z-IME3D-L0RYD-9G8U1, RG06-BXGK-MILW-811M, KROG-F8PR-UDXD-A5LN, U6WH-0KXP-Y9SN-CCFS
                //t1kjZU764zIME6Dl9ryD0g1U8&-P4*(`Q>:x8\yE1{({X/Hoq!gR.&rg93bXgkmILW188m&KroGf1prUdxdA4ln&U3WH9kXPY0SncCfs
                string lenOfString = command[i].ToUpper();
                char[] ii = lenOfString.ToCharArray();
                int lenght = ii.Length;
                for (int j = 0; j < ii.Length; j++)
                {
                    if (!char.IsLetterOrDigit(ii[j]))
                    {
                        verifyString = false;
                        break;
                    }

                    verifyString = true;
                }
                if (verifyString)
                {
                    if (lenght ==16)
                    {
                        int count = 0;
                        for (int j = 0; j < ii.Length; j++)
                        {
                            count++;
                            if (char.IsLetter(ii[j]))
                            {
                                serialNumber += ii[j];
                            }
                            else if (char.IsDigit(ii[j]))
                            {
                                int newNumber = ii[j];
                                newNumber = 57 - newNumber;
                                serialNumber += newNumber;
                            }

                            if (count % 4 == 0 && count <ii.Length)
                            {
                                serialNumber += "-";
                            }

                            if (count == ii.Length && (i < command.Length-1))
                            {
                                serialNumber += ", ";
                            }
                        }
                    }
                   

                    if (lenght == 25)
                    {
                        int count = 0;
                        for (int j = 0; j < ii.Length; j++)
                        {
                            count++;
                            if (char.IsLetter(ii[j]))
                            {
                                serialNumber += ii[j];
                            }
                            else if (char.IsDigit(ii[j]))
                            {
                                int newNumber = ii[j];
                                newNumber = 57 - newNumber;
                                serialNumber += newNumber;

                            }

                            if (count % 5 == 0 && count < ii.Length)
                            {
                                serialNumber += "-";
                            }
                            if (count == ii.Length && (i < command.Length - 1))
                            {
                                serialNumber += ", ";
                            }
                        }
                    }
                }
            }

            Console.WriteLine(serialNumber);
        }
    }
}
