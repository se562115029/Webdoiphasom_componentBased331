using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication3.Models.EF;
using WebApplication3.Models.Entities;

namespace WebApplication3.Models.Repository
{
    public class PostRepository : IPostRepository
    {
        EfDbContext _context = new EfDbContext();

        public void AddPost(Post Post)
        {
            _context.Posts.Add(Post);
            SavePost();
        }

        public void DeletePost(string id)
        {
            Post post = _context.Posts.Find(id);
            _context.Posts.Remove(post);
            SavePost();
        }

        public void EditPost(Post Post)
        {
            _context.Entry(Post).State = EntityState.Modified;
            SavePost();
        }

        public List<Post> GetAllPost()
        {
            return _context.Posts.ToList();
        }

        public Post GetPostByID(string id)
        {
            return _context.Posts.Find(id);
        }

        public void SavePost()
        {
            _context.SaveChanges();
        }
    }
}