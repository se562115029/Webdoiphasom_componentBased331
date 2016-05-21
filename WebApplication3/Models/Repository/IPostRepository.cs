using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Models.Entities;

namespace WebApplication3.Models.Repository
{
   public interface IPostRepository
    {
        void AddPost(Post Post);
        void DeletePost(string id);
        void EditPost(Post Post);
        List<Post> GetAllPost();
        Post GetPostByID(string id);
        void SavePost();
    }
}
