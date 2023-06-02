using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using static System.Net.Mime.MediaTypeNames;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Implementation For List Sorter
    /// </summary>
    public class ListSorterService : IListSorterService 
    {
        public string jsonData;
        //public string MethodName(List<ListSorterModel> listOfModels);
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
                                    if (jsonData.Substring(jsonData.Length - 6) != "subs:[") jsonData += "," ;
                                    jsonData += "{id:" + listOfModels[j].Id + ",title:`" + listOfModels[j].Name + "`" ;
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
        /// <param name="listSorterModels"></param>
        public void returnChildern(int id, int index,List<ListSorterModel> listSorterModels)
        {
            for (var i = index + 1; i < listSorterModels.ToArray().Length; i++)
            {
                if (id == listSorterModels[i].ParentId)
                {
                    jsonData += ",subs:[";
                    while (i < listSorterModels.ToArray().Length)
                    {
                        if (listSorterModels[i].ParentId == id)
                        {
                            if (jsonData.Substring(jsonData.Length - 6) != "subs:[") jsonData += ",";
                            jsonData += "{id:" + listSorterModels[i].Id + ",title:`" + listSorterModels[i].Name + "`";
                            //Check for child
                            returnChildern(listSorterModels[i].Id, index + 1, listSorterModels);
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
        /// <param name="listSorterModels"></param>
        /// <returns></returns>
        public string SelectedOptionSort(List<ListSorterModel> listSorterModels)
        {
            string jsonData = "[";
            foreach(var item in listSorterModels)
            {
                if (listSorterModels.First() == item)
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
        public IEnumerable<Node<ListSorterModel>> HirearichyCreate (List<ListSorterModel> listSorterModels)
        {
            var hierarchy = listSorterModels.Hierarchize(
             0, // The "root level" key. We're using -1 to indicate root level.
             f => f.Id, // The ID property on your object
             f => f.ParentId,// The property on your object that points to its parent
            f => f.Position // The property on your object that specifies the order within its parent
            );
            return hierarchy;
        }
    }
}
