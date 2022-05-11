namespace DatingApp.DTO
{
    public class EntityDto<T> : IEntityDto<T>
    {
        public T Id { get; set; }
    }
}
