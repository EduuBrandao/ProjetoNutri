namespace Infra.Data
{
    public class BaseRepository<T>
    {
        protected NutriContext Context { get; set; }

        public BaseRepository(NutriContext context)
        {
            this.Context = context;
        }
    }
}
