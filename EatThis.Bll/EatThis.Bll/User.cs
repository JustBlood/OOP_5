namespace EatThis.Bll
{
    public class User : IUser
    {
        public byte? Age { get; set; }
        public float? Height { get; set; }
        public float? Weight { get; set; }

        public List<IDiet>? Diets { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }

        public void AddDiet(IDiet diet)
        {
            Diets.Add(diet);
        }

        public void RemoveDiet(IDiet diet)
        {
            Diets.Remove(diet);
        }

        public IDiet GetDiet(string name)
        {
            return Diets?.First(x => x.Name.Equals(name)) ?? throw new NullReferenceException("Диета не добавлена к пользователю");
        }

        public void RenameMe(string newName)
        {
            Name = newName;
        }

        public void ResetPassword(string newPassword)
        {
            Password = newPassword;
        }

        IEnumerable<IDiet> IUser.GetDiets()
        {
            return Diets?.ToList() ?? throw new NullReferenceException("Диета не добавлена к пользователю");
        }
    }
}
