namespace ItsRandomLife.Domain.Interfaces;

public interface IRandomNumberService
{
    int GetRandomNumberInRange(int min, int max);
}