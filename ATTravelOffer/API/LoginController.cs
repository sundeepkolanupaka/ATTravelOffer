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
    public class LoginController : ApiController
    {
        private string procedureName;
        private SqlParameter sqlParam;

        DataAccessObject dbObject = new DataAccessObject();
        SqlParameter[] ParamList;

        int paramCount;

        public Login Post(List<string> values)
        {
            Login loginDetails = new Login();
            loginDetails.LoginId = values[0];
            loginDetails.Password = values[1];

            ResultStatus resultStatus = new ResultStatus();
            resultStatus.StatusInd = -1;
            resultStatus.StatusMsg = "";

            Login loginResult = new Login();
            loginResult.ResultStatus = new ResultStatus();
            loginResult.ResultStatus.StatusInd = -1;
            loginResult.ResultStatus.StatusMsg = loginDetails.LoginId;

            try
            {
                procedureName = "AuthenticateUser";
                ParamList = new SqlParameter[1];

                paramCount = 0;
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@LoginId";
                sqlParam.Value = loginDetails.LoginId;
                ParamList[paramCount] = sqlParam;

                DataTable dtblResult = dbObject.OpenDataTable(procedureName, ParamList);

                if (dtblResult != null)
                {
                    if (dtblResult.Rows.Count > 0)
                    {
                        if (Convert.ToInt16(dtblResult.Rows[0]["STATUSIND"]) == -1)
                        {
                            loginResult.ResultStatus.StatusMsg = dtblResult.Rows[0]["STATUSMSG"].ToString();
                        }
                        else
                        {
                            loginResult.Password = dtblResult.Rows[0]["Password"].ToString();

                            Common common = new Common();
                            if (common.VerifyPassword(loginDetails.Password, loginResult.Password))
                            {
                                loginResult.ResultStatus.StatusInd = Convert.ToInt16(dtblResult.Rows[0]["STATUSIND"]);
                                loginResult.ResultStatus.StatusMsg = dtblResult.Rows[0]["STATUSMSG"].ToString();
                            }
                            else
                            {
                                loginResult.ResultStatus.StatusInd = -1;
                                loginResult.ResultStatus.StatusMsg = "Invalid password";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //loginResult.ResultStatus.StatusMsg = ex.Message;
                loginResult.ResultStatus.StatusInd = -1;
            }

            return loginResult;
        }
    }
}