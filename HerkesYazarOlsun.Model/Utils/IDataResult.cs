
namespace HerkesYazarOlsun.Model.Utils;

public interface IDataResult<out T> : IResult
{
    T Result { get; }
}

