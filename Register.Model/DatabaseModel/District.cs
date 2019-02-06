namespace Register.Model.DatabaseModel
{
    public class District : BaseModel
    {
        public string Name { get; set; }
        public virtual City City { get; set; }


    }
}