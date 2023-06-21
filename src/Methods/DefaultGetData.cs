using UsersApiStudy.src.DTOs;
namespace UsersApi.src.Interfaces;
public class DefaultGetData
{
    public IEnumerable<ReadUserDto> Data { get; set; }
    public int Page { get; set; }
    public int Size { get; set; }
}
