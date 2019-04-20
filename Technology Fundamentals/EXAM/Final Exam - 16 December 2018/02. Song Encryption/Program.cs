using System;
using System.Linq;
using System.Text;

namespace _02._Song_Encryption
{
    class Program
    {
        static void Main()
        {
            //Eminem:VENOM
            string inputLine = Console.ReadLine();

            while (inputLine != "end")
            {
                string[] command = inputLine.Split(":");
                string artist = command[0];
                string song = command[1];
                bool artistChek = false;
                bool songChek = false;

                if (char.IsUpper(artist[0]))
                {
                    for (int i = 1; i < artist.Length; i++)
                    {
                        if (!char.IsLower(artist[i]) && !char.IsWhiteSpace(artist[i]) && artist[i] != '\'')
                        {
                            artistChek = false;
                            break;
                        }
                        else
                        {
                            artistChek = true;
                        }
                    }
                    
                }

                if (char.IsUpper(song[0]))
                {
                    for (int i = 1; i < song.Length; i++)
                    {
                        if (!char.IsUpper(song[i]) && !char.IsWhiteSpace(song[i]))
                        {
                            songChek = false;
                            break;
                        }
                        else
                        {
                            songChek = true;
                        }
                    }
                    
                }
                StringBuilder artisAndSong = new StringBuilder();
                if (!artistChek || !songChek)
                {
                    Console.WriteLine("Invalid input!");
                }
                else if(artistChek && songChek)
                {

                    for (int i = 0; i < inputLine.Length; i++)
                    {
                        int len = 0;
                        int diff = 0;
                        if (inputLine[i] >= 'A' && inputLine[i] <='Z')
                        {
                            len = inputLine[i] + artist.Length;
                            diff = len - 90;
                            if (len>90)
                            {
                                artisAndSong.Append((char)(64 + diff));
                            }
                            else
                            {
                                artisAndSong.Append((char)(inputLine[i] + artist.Length));
                            }
                        }
                        else if (inputLine[i] >= 'a' && inputLine[i] <= 'z')
                        {
                            len = inputLine[i] + artist.Length;
                            diff = len - 122;
                            if (len > 122)
                            {
                                artisAndSong.Append((char)(96 + diff));
                            }
                            else
                            {
                                artisAndSong.Append((char)(inputLine[i] + artist.Length));
                            }
                        }
                        else if (inputLine[i] == ':')
                        {
                            artisAndSong.Append('@');
                        }
                        else
                        {
                            artisAndSong.Append((char)inputLine[i]);
                        }
                        
                    }

                    Console.WriteLine($"Successful encryption: {artisAndSong}");
                }
                    inputLine = Console.ReadLine();
            }
        }
    }
}
