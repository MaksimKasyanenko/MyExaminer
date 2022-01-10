using System.Collections.Generic;
using System.Threading.Tasks;

namespace RemTestSys.Domain.Interfaces{
    public interface IExamService{
        Task<IEnumerable<ExamViewModel>> GetAvailableExamsForAsync(int studentId);
        Task<IEnumerable<double>> GetResultsForAsync(int studentId, int testId);
    }
}