using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine()
                        .Split(", ")
                        .ToList();
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "course start")
                {
                    break;
                }
                string[] tokens = input.Split(":");

                string command = tokens[0];
                //Add:{lessonTitle} – add the lesson to the end of the schedule, if it does not exist.
                if (command == "Add")
                {
                    string lesson = tokens[1];
                    if (lessons.Contains(lesson) == false)
                    {
                        lessons.Add(lesson);
                    }
                }
                //Insert:{lessonTitle}:{index} – insert the lesson to the given index, if it does not exist.
                else if (command == "Insert")
                {
                    string lesson = tokens[1];
                    int index = int.Parse(tokens[2]);
                    if (lessons.Contains(lesson) == false)
                    {
                        lessons.Insert(index, lesson);
                    }
                }
                //Remove:{lessonTitle} – remove the lesson, if it exists.
                else if (command == "Remove")
                {
                    string lesson = tokens[1];
                    if (lessons.Contains(lesson))
                    {
                        int index = lessons.IndexOf(lesson);
                        if (lessons.Contains($"{lesson}-Exercise"))
                        {
                            lessons.RemoveAt(index + 1);
                        }
                        lessons.Remove(lesson);

                    }
                }
                //  Swap: { lessonTitle}:{ lessonTitle} – change the place of the two lessons, if they exist.
                else if (command == "Swap")
                {
                    string firstlesson = tokens[1];
                    string secondLesson = tokens[2];
                    int firstIndex = lessons.IndexOf(firstlesson);
                    int secondIndex = lessons.IndexOf(secondLesson);

                    if (firstIndex == -1 || secondIndex == -1)
                    {
                        continue;
                    }
                    else
                    {
                        lessons[firstIndex] = secondLesson;
                        lessons[secondIndex] = firstlesson;

                        if (lessons.Contains($"{firstlesson}-Exercise"))
                        {
                            string lessonFirstExercite = $"{firstlesson}-Exercise";
                            lessons.RemoveAt(firstIndex + 1);
                            lessons.Insert(secondIndex + 1, lessonFirstExercite);
                        }
                        if (lessons.Contains($"{secondLesson}-Exercise"))
                        {
                            string lessonSecondExercite = $"{secondLesson}-Exercise";
                            lessons.RemoveAt(secondIndex + 1);
                            lessons.Insert(firstIndex + 1, lessonSecondExercite);
                        }
                    }
                }
                //Exercise:{lessonTitle} – add Exercise in the schedule right after the lesson index,
                //if the lesson exists and there is no exercise already
                else if (command == "Exercise")
                {
                    string lesson = tokens[1];
                    string exercite = $"{lesson}-Exercise";

                    if (lessons.Contains(lesson) == false)
                    {
                        lessons.Add(lesson);
                        lessons.Add(exercite);
                    }
                    if (lesson.Contains(lesson) && lessons.Contains(exercite) == false)
                    {
                        int index = lessons.IndexOf(lesson);
                        lesson.Insert(index + 1, exercite);
                    }
                }

            }

            for (int i = 0; i < lessons.Count; i++)
            {
                string lesson = lessons[i];
                Console.WriteLine($"{i + 1}.{lesson}");
            }
        }
    }
}
