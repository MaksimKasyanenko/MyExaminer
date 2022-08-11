using System.Threading.Tasks;
using System.Collections.Generic;
using RemTestSys.Domain.ViewModels;
using RemTestSys.Domain.ViewModels.QuestionsWithAnswers;

namespace RemTestSys.Domain.Interfaces
{
    public interface IQuestionService
    {
        Task<IEnumerable<QuestionViewModel>> GetQuestionsFromExamAsync(int examId);
        Task<QuestionWithAnswerViewModel> FindQuestionWithAnswerAsync(int id);
        Task AddQuestionWithAnswerAsync(QuestionWithAnswerViewModel questionViewModel);
        Task UpdateQuestionWithAnswerAsync(QuestionWithAnswerViewModel questionViewModel);
        Task DeleteAsync(int id);
    }
}