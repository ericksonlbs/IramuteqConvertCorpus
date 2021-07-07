using System.Collections.Generic;

namespace IramuteqConvertCorpus.Lib.Models
{
    public class QuestionModel
    {
        public QuestionModel()
        {
            Responses = new List<ResponseModel>();
        }
        public TypeQuestionEnum TypeQuestion { get; set; }
        public string Description { get; set; }
        public List<ResponseModel> Responses { get; set; }
    }
}