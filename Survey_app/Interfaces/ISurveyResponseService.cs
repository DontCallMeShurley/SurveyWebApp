using Azure;
using Microsoft.AspNetCore.Mvc;
using Survey_app.ViewModels;

namespace Survey_app.Interfaces
{
    public interface ISurveyResponseService
    {
        Task<SurveyResponseVM> GetResponse(int id);
        Task<UserViewSurveyResponseVM> GetResponsesBySurveyId(int surveyId, string searchString, int? pageNumber);
        Task<CreateSurveyResponseVM> GetSurveyWithCreateResponse(int id);
        Task<Response<int>> CreateSurveyResponse(CreateResponseVM createResponse);
    }
}
