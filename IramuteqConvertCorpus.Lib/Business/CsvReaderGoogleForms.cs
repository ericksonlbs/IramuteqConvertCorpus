using System.Collections.Generic;
using System.IO;
using System.Linq;
using IramuteqConvertCorpus.Lib.Models;

namespace IramuteqConvertCorpus.Lib.Business
{
    public class CsvReaderGoogleForms
    {
        private const string SEPARATOR = "\",\"";
        private readonly string file;

        public CsvReaderGoogleForms(string file)
        {
            this.file = file;
        }

        public SearchModel Read()
        {

            string[] lines = File.ReadAllLines(file);

            SearchModel search = new SearchModel();

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                //read header
                if (i == 0)
                {
                    string[] questions = line.Split(SEPARATOR);

                    for (int q = 0; q < questions.Length; q++)
                    {
                        QuestionModel question = new QuestionModel();
                        question.Description = questions[q];

                        if (q == 0 && question.Description.StartsWith("\""))
                            question.Description = question.Description.Substring(1, question.Description.Length - 1);
                        if (q == (questions.Length - 1) && question.Description.EndsWith("\""))
                            question.Description = question.Description.Substring(0, question.Description.Length - 1);



                        search.Questions.Add(question);
                    }
                }
                else
                {                    
                    string[] responses = line.Split(SEPARATOR);
                    
                    for (int q = 0; q < responses.Length; q++)
                    {
                        ResponseModel response = new ResponseModel();
                        response.Text = responses[q];

                        if (q == 0 && response.Text.StartsWith("\""))
                            response.Text = response.Text.Substring(1, response.Text.Length - 1);
                        if (q == (responses.Length - 1) && response.Text.EndsWith("\""))
                            response.Text = response.Text.Substring(0, response.Text.Length - 1);

                        search.Questions[q].Responses.Add(response);
                    }
                }
            }

            return search;
        }
    }
}