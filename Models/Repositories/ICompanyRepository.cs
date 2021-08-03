namespace learnAspDotNetCore.Models.Repositories
{
    public interface ICompanyRepository<TEntity>
    {
        TEntity Get(int id); 
    }
}
