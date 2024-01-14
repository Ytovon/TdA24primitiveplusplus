namespace tda_proj.Service
{
    public interface ILectorService
    {
        
        Task<List<Lector>> GetAllLectors();

        Task<Lector> GetLectorByUUIDapi(Guid UUID);

        Task<List<Lector>> AddLector(Lector lector);

        Task<Lector> UpdateLectorByUUID(Guid UUID, Lector request);

        Task<Lector> DeleteLectorByUUID(Guid UUID, Lector request);
    }
}
