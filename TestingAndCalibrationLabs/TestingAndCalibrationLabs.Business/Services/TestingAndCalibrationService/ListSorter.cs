﻿using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Services
{
    public class ListSorter : IListSorter 
    {
        public string jsonData;
        public string MethodName(List<ListSorterModel>  listOfModels)
        {

            //var hierarchy = listOfModels.Hierarchize(
            // 0, // The "root level" key. We're using -1 to indicate root level.
            // f => f.Id, // The ID property on your object
            // f => f.ParentId,// The property on your object that points to its parent
            //f => f.Position // The property on your object that specifies the order within its parent
            // );
            jsonData = "[";
            for (var i = 0; i < listOfModels.ToArray().Length; i++)
            {
                if (listOfModels[i].ParentId == 0)
                {
                    if (jsonData != "[") jsonData += ",";
                    jsonData += "{id:" + listOfModels[i].Id + ",title:`" + listOfModels[i].Name + "`";
                    for (var j = i + 1; j < listOfModels.ToArray().Length; j++)
                    {
                        if (listOfModels[i].Id == listOfModels[j].ParentId)
                        {
                            jsonData += ",subs:[";
                            while (j < listOfModels.ToArray().Length)
                            {
                                if (listOfModels[i].Id == listOfModels[j].ParentId)
                                {
                                    if (jsonData.Substring(jsonData.Length - 6) != "subs:[") jsonData += ",";
                                    jsonData += "{id:" + listOfModels[j].Id + ",title:`" + listOfModels[j].Name + "`";
                                    //Check for child
                                    returnChildern(listOfModels[j].Id, j,listOfModels);
                                    jsonData += "}";
                                }
                                j++;
                            }
                            jsonData += "]";
                        }
                    }
                    jsonData += "}";
                }

            }
            jsonData += "]";


            return jsonData ;
        }
        public void returnChildern(int id, int index,List<ListSorterModel> tests)
        {
            for (var i = index + 1; i < tests.ToArray().Length; i++)
            {
                if (id == tests[i].ParentId)
                {
                    jsonData += ",subs:[";
                    while (i < tests.ToArray().Length)
                    {
                        if (tests[i].ParentId == id)
                        {
                            if (jsonData.Substring(jsonData.Length - 6) != "subs:[") jsonData += ",";
                            jsonData += "{id:" + tests[i].Id + ",title:`" + tests[i].Name + "`";
                            //Check for child
                            returnChildern(tests[i].Id, index + 1,tests);
                            jsonData += "}";
                        }
                        i++;
                    }
                    jsonData += "]";
                }
            }
        }


    }
}
