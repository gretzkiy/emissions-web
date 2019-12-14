﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Web.Services;
using EmissionsLibrary;

namespace EmissionsWeb
{
    public class MeasurementsController : ApiController
    {
        public IEnumerable<string> GetIds()
        {
            var currentData = (HashSet<TransferData>)HttpContext.Current.Application["Measurements"];
            var ids = new List<string>();

            currentData.ToList().ForEach(value =>
            {
                ids.Add(value.valueUuid);
            });

            return ids;
        }

        public TransferData Get(string id)
        {
            var currentData = (HashSet<TransferData>)HttpContext.Current.Application["Measurements"];

            return currentData.ToList().Where(value => value.valueUuid == id).SingleOrDefault();
        }
    }
}