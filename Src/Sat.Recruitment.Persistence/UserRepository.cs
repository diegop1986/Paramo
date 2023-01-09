using System.IO;
using Sat.Recruitment.Domain.Entity;
using Sat.Recruitment.Domain.Extensions;
using Sat.Recruitment.Service.Repository;

namespace Sat.Recruitment.Persistence
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public override void FillSource()
        {
            var reader = ReadUsersFromFile();

            while (reader.Peek() >= 0)
            {
                var line = reader.ReadLineAsync().Result;
                var user = new User
                {
                    Name = line.Split(',')[0].ToString(),
                    Email = line.Split(',')[1].ToString(),
                    Phone = line.Split(',')[2].ToString(),
                    Address = line.Split(',')[3].ToString(),
                    UserType = line.Split(',')[4].ToString().ToUserType(),
                    Money = decimal.Parse(line.Split(',')[5].ToString()),
                };
                Source.Add(user);
            }
            reader.Close();
        }

        private StreamReader ReadUsersFromFile()
        {
            var path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Files\Users.txt";

            FileStream fileStream = new FileStream(path, FileMode.Open);

            StreamReader reader = new StreamReader(fileStream);
            return reader;
        }
    }
}
