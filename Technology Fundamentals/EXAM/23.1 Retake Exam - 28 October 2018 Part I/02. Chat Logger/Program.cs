using System;
using System.Collections.Generic;
using System.Linq;
//Programming Fundamentals - Retake Exam - 28 October 2018 Part I
namespace _02._Chat_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> message = new List<string>();


            while (input != "end")
            {
                string[] command = input.Split();

                switch (command[0])
                {
                    //•	Chat { message } - add the message at last position in the chat
                    case "Chat":
                        message.Add(command[1]);
                        break;
                    //•	Delete {messageToDelete} - delete the message if it exists
                    case "Delete":
                        // string temp = message.Contains(command[1]);
                        if (message.Contains(command[1]))
                        {
                            message.Remove((command[1]));
                        }
                        break;
                    //•	Edit {messageToEdit} {editedVersion} -
                    //update the message with the edited version
                    case "Edit":

                        if (message.Contains(command[1]))
                        {
                            message.Insert(message.IndexOf(command[1]), command[2]);
                            message.RemoveAt(message.IndexOf(command[1]));
                        }
                        break;
                    //•	Pin {message} - find the given message and move it to the last index
                    case "Pin":
                        string temp = command[1];
                        if (message.Contains(command[1]))
                        {
                            message.RemoveAt(message.IndexOf(command[1]));
                            message.Add(temp);
                        }
                        break;
                    //•	Spam {message1} {message2} {messageN}
                    //- add all messages at the end of the chat
                    case "Spam":
                        //  string spamInsert = command.Length;
                        // string[] spamAdd = spamInsert.Split();
                        for (int i = 1; i < command.Length; i++)
                        {
                            message.Add(command[i]);
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            foreach (var messages in message)
            {
                Console.WriteLine(messages);
            }
        }
    }
}
