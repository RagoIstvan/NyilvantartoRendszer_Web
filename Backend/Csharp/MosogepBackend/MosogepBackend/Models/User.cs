namespace MosogepBackend.Models
{
    public class User : ICloneable
    {

        Random rnd = new Random();
        public User()
        {
            Key = GenerateKey;

        }

        public int Id { get; set; }



        public User(string username, string password, string email)
        {
            Name = username;
            Password = password;
            Email = email;
            Key = GenerateKey;

        }

      

        public string Name { get; set; }


        public string Email { get; set; }

        public string Password { get; set; }


        public bool IsAdmin
        {
            get
            {
                if (Id > 0) return true;
                else return false;

            }
        }


        public string GenerateKey
        {
            get
            {
                char[] keys = new char[12];

                for (int i = 0; i < keys.Length; i++)
                {
                    keys[i] = (char)rnd.Next('0', '9' + 1);

                }
                return new string(keys);

            }
        }

        public string Key { get; }

        public string UserKey() { return $"User-{Key}"; }

        public string UserData
        {
            get 
            {
                return $"Név: {Name}\n" +
                       $"Email: {Email}\n" +
                       $"jelszó: {Password}\n" +
                       $"Kulcs: {Key}\n"+
                       $"Admin:{(IsAdmin ? "igen" : "nem")}\n";

            }
        
        }


        public override string ToString()
        {
            return $"{Name} - {($"{(IsAdmin ? "Root" : UserKey())}")}";
        }




        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
