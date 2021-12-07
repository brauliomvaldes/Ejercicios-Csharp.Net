using ConsoleEF.Models;
using System;
using System.Linq;

namespace ConsoleEF
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new BlogContext())
            {
                var nuevoRegistroPost = new Post();
                nuevoRegistroPost.Title = "Primer Post";
                nuevoRegistroPost.Body = "Cuerpo del Post";

                // insert into
                context.Posts.Add(nuevoRegistroPost);
                context.SaveChanges();

                var modificaRegistroPost = context.Posts.Find(1);
                modificaRegistroPost.Title = "Nuevo Título Post";
                modificaRegistroPost.Body = "Cambio Cuerpo del Post 1";
                context.Entry(modificaRegistroPost).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();

                var eliminarRegistroPost = context.Posts.Find(2);
                context.Remove(eliminarRegistroPost);
                context.SaveChanges();





                foreach (var post in context.Posts.ToList())
                {
                    Console.WriteLine("Título:"+post.Title+" Body:"+post.Body);
                }

            }
        }
    }
}
