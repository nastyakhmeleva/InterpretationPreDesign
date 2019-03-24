using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterpretationPreDesign
{
    public class ResponseRepository
    {
        private static ResponseRepository repository=new ResponseRepository();
        private List<Response> responses=new List<Response>();

        public static ResponseRepository GetRepository()
        {
            return repository;
        }

        public IEnumerable<Response> GetAllResponses()
        {
            return responses;
        }

        public void AddResponse(Response response)
        {
            responses.Add(response);
        }
    }
}