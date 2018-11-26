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
    public class PurchaseOrderController : ApiController
    {
        private string procedureName;
        private SqlParameter sqlParam;

        DataAccessObject dbObject = new DataAccessObject();
        SqlParameter[] ParamList;

        int paramCount;

        public ResultStatus Post(List<string> values)
        {
            PurchaseOrder purchaseOrder = new PurchaseOrder();
            purchaseOrder.BagModel = values[0];
            purchaseOrder.Price = Convert.ToDecimal(values[1]);
            purchaseOrder.Number = values[2];
            purchaseOrder.CustomerName = values[3];
            purchaseOrder.Age = Convert.ToInt16(values[4]);
            purchaseOrder.City = values[5];
            purchaseOrder.EmailId = values[6];
            purchaseOrder.PhoneNumber = values[7];

            ResultStatus resultStatus = new ResultStatus();
            resultStatus.StatusInd = -1;
            resultStatus.StatusMsg = "";

            try
            {
                procedureName = "InsertPO";
                ParamList = new SqlParameter[8];

                paramCount = 0;
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@BagModel";
                sqlParam.Value = purchaseOrder.BagModel;
                ParamList[paramCount] = sqlParam;

                paramCount++;
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Price";
                sqlParam.Value = purchaseOrder.Price;
                ParamList[paramCount] = sqlParam;

                paramCount++;
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@PONumber";
                sqlParam.Value = purchaseOrder.Number;
                ParamList[paramCount] = sqlParam;

                paramCount++;
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Name";
                sqlParam.Value = purchaseOrder.CustomerName;
                ParamList[paramCount] = sqlParam;

                paramCount++;
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Age";
                sqlParam.Value = purchaseOrder.Age;
                ParamList[paramCount] = sqlParam;

                paramCount++;
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@City";
                sqlParam.Value = purchaseOrder.City;
                ParamList[paramCount] = sqlParam;

                paramCount++;
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@EmailId";
                sqlParam.Value = purchaseOrder.EmailId;
                ParamList[paramCount] = sqlParam;

                paramCount++;
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@PhoneNumber";
                sqlParam.Value = purchaseOrder.PhoneNumber;
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