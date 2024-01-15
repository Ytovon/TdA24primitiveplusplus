namespace tda_proj.Service
{
    public interface ILectorServiceApi
    {
        
        Task<List<Lector>> GetAllLectorsapi();

        Task<Lector> GetLectorByUUIDapi(Guid UUID);

        Task<List<Lector>> AddLectorapi(Lector lector);

        Task<Lector> UpdateLectorByUUIDapi(Guid UUID, Lector request);

        Task<Lector> DeleteLectorByUUIDapi(Guid UUID, Lector request);
    }
}
