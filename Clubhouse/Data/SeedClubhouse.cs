using Clubhouse.Models;

namespace Clubhouse.Data
{
    public class SeedClubhouse
    {
        public static void Initialize(ClubhouseContext context)
        {
            if (context.User.Any())
                return;

            var users = new User[]
            {
                new User{UserName="pedrasa1",Password="1234567890",Email="m@gma4.com"},
                new User{UserName="pedrasa2",Password="1234567890",Email="m@gma3.com"},
                new User{UserName="pedrasa3",Password="1234567890",Email="m@gma2.com"},
                new User{UserName="pedrasa4",Password="1234567890",Email="m@gma1.com"}
            };

            foreach (User user in users)
            {
                context.User.Add(user);
            }
            context.SaveChanges();

            var posts = new Post[]
            {
                new Post{Title="Example Post by user1",Body="Lorem ipsum",UserId = users.Single(u => u.UserName=="pedrasa1").UserId},
                new Post{Title="Example Post by user2",Body="Lorem ipsum",UserId = users.Single(u => u.UserName=="pedrasa2").UserId},
                new Post{Title="Another Post by user1",Body="Lorem ipsum",UserId = users.Single(u => u.UserName=="pedrasa1").UserId},
            };
        }
    }
}
