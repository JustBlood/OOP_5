namespace EatThis.Bll
{
    public class Diet : IDiet
    {
        public string Name { get; set; }

        public string Description { get; set; }
        public IEnumerable<IDish> Dishes { get; set; }
        public IEnumerable<string>? Tags { get; set; }

        public IEnumerable<IDish> GetDishes()
        {
            return Dishes.ToList();
        }
        public void AddTag(string tag)
        {
            Tags.Append(tag);
        }

        public void AddTags(IEnumerable<string> tags)
        {
            var enumerator = tags.GetEnumerator();
            while (enumerator.MoveNext())
            {
                AddTag(enumerator.Current);
            }
        }
    }
}
