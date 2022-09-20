using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Implementation For List Sorter
    /// </summary>
    public class ListSorterService : IListSorterService 
    {
        public string jsonData;
        /// <summary>
        /// To Sort List To Json Object For Using ComboTree jquery Plugin
        /// </summary>
        /// <param name="listOfModels"></param>
        /// <returns></returns>
        public string SortListToJson(List<ListSorterModel>  listOfModels)
        {
            jsonData = "[";
            for (var i = 0; i < listOfModels.ToArray().Length; i++)
            {
                if (listOfModels[i].ParentId == 0)
                {
                    if (jsonData != "[") jsonData += ",";
                    jsonData += "{id:" + listOfModels[i].Id + ",title:'" + listOfModels[i].Name + "'";
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
                                    jsonData += "{id:" + listOfModels[j].Id + ",title:'" + listOfModels[j].Name + "'";
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
        /// <summary>
        /// Creating Child For Sorted List
        /// </summary>
        /// <param name="id"></param>
        /// <param name="index"></param>
        /// <param name="tests"></param>
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
        /// <summary>
        /// Create A Json Object For Selected List
        /// </summary>
        /// <param name="tests"></param>
        /// <returns></returns>
        public string SelectedOptionSort(List<ListSorterModel> tests)
        {
            string jsonData = "[";
            foreach(var item in tests)
            {
                if (tests.First() == item)
                {
                    jsonData += item.Id;
                }
                else
                {
                    jsonData += ","+item.Id;
                }
            }

            jsonData += "]";
            return jsonData;
        }
    }
}
