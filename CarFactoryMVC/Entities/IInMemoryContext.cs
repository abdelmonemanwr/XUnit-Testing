namespace CarFactoryMVC.Entities
{
    public interface IInMemoryContext
    {
        List<Car> Cars { get; set; }
        List<Owner> Owners { get; set; }

        void SeedData();
    }
}