using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
//Objects and Classes - Exercise
namespace _03._Articles_2._0
{
    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;

        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int articleCount = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();

            for (int i = 0; i < articleCount; i++)
            {
                string[] splitInput = Console.ReadLine()
                    .Split(", ");
                string title = splitInput[0];
                string content = splitInput[1];
                string author = splitInput[2];

                Article article = new Article(title, content, author);

                articles.Add(article);
            }

            string orderBy = Console.ReadLine();
            if (orderBy == "title")
            {
                articles = articles.OrderBy(x => x.Title).ToList();
            }
            else if (orderBy == "content")
            {
                articles = articles.OrderBy(x => x.Content).ToList();
            }
            else if (orderBy == "author")
            {
                articles = articles.OrderBy(x => x.Author).ToList();
            }

            Console.WriteLine(string.Join(Environment.NewLine, articles));
        }

    }
}
