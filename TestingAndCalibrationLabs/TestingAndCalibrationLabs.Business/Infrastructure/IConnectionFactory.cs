using System.Data;

namespace TestingAndCalibrationLabs.Business.Infrastructure
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}