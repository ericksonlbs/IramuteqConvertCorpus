using System.Collections.Generic;

namespace IramuteqConvertCorpus.Lib.Models
{
    public class SearchModel
    {
        public SearchModel()
        {
            Questions = new List<QuestionModel>();
        }
        public List<QuestionModel> Questions { get; set; }
    }
}