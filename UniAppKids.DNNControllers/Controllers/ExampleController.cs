﻿namespace UniAppKids.DNNControllers.Services
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using DotNetNuke.Services.Exceptions;
    using DotNetNuke.Web.Api;

    using UniAppKids.DNNControllers.Repository;
    using UniAppKids.DNNControllers.Models;



    public class ExampleController : ControllerBase
    {
        private readonly DictionaryRepository aRepository = new DictionaryRepository();

        public List<PhraseDictionary> GetDictionary(string userName)
        {
            var dictionaries = aRepository.GetDictionaries();

            return dictionaries;
        }
        #region "Web Methods"
        [DnnAuthorize()]
        [HttpGet()]
        public HttpResponseMessage HelloWorld()
        {
            try
            {
                string helloWorld = "Hello World!";
                return Request.CreateResponse(HttpStatusCode.OK, helloWorld);
            }
            catch (System.Exception ex)
            {
                //Log to DotNetNuke and reply with Error
                Exceptions.LogException(ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [DnnAuthorize()]
        [AcceptVerbs("GET", "POST")]
        public HttpResponseMessage GoodbyeWorld(bool data)
        {
            try
            {
                string helloWorld = "Hello World!";
                if (data)
                {
                    helloWorld = "Good-bye World!";
                }
                return Request.CreateResponse(HttpStatusCode.OK, helloWorld);
            }
            catch (System.Exception ex)
            {
                //Log to DotNetNuke and reply with Error
                Exceptions.LogException(ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        #endregion

        #region "DTO Classes"
        public class DTOWorldDetails
        {
            public bool goodbye { get; set; }
        }
        #endregion
    }
}