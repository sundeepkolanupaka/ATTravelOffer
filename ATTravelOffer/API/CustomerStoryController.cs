using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using ATTravelOffer.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ATTravelOffer.API
{
    public class CustomerStoryController : ApiController
    {
        private string procedureName;
        private SqlParameter sqlParam;

        DataAccessObject dbObject = new DataAccessObject();
        SqlParameter[] ParamList;

        int paramCount;

        public ResultStatus Post(List<string> values)
        {
            CustomerStory customerStory = new CustomerStory();
            customerStory.PONumber = values[0];
            customerStory.Story = values[1];

            ResultStatus resultStatus = new ResultStatus();
            resultStatus.StatusInd = -1;
            resultStatus.StatusMsg = "";

            try
            {
                procedureName = "InsertStory";
                ParamList = new SqlParameter[2];

                paramCount = 0;
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@PONumber";
                sqlParam.Value = customerStory.PONumber;
                ParamList[paramCount] = sqlParam;

                paramCount++;
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Story";
                sqlParam.Value = customerStory.Story;
                ParamList[paramCount] = sqlParam;

                DataTable dtblResult = dbObject.OpenDataTable(procedureName, ParamList);

                if (dtblResult != null)
                {
                    if (dtblResult.Rows.Count > 0)
                    {
                        resultStatus.StatusInd = Convert.ToInt16(dtblResult.Rows[0]["STATUSIND"]);
                        resultStatus.StatusMsg = dtblResult.Rows[0]["STATUSMSG"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                resultStatus.StatusMsg = ex.Message;
                resultStatus.StatusInd = -1;
            }

            return resultStatus;
        }
    }
}