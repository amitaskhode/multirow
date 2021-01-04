using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolApp.ViewModel
{
    [System.Diagnostics.DebuggerDisplay("Result = {Result.ToString()} Message : {Message}")]
    public class ResultModel
    {
        public ResultModel()
        {
            Result = iResultType.iUnknown;
            Message = string.Empty;
            RowsAffected = -1;
            Data = null;
        }
        public iResultType Result { get; set; }
        public string Message { get; set; }
        public int RowsAffected { get; set; }
        public object Data { get; set; }
    }

    public enum iResultType
    {
        iUserAuthenticated = 0,
        iUserNameOrPasswordBad = 1,
        iUserIsInActive = 2,
        iError = 3,
        iWarning = 4,
        iInformation = 5,
        iSuccess = 6,
        iUnknown = 7,
        iEmptyModel = 8,
        iNoRecordFound = 9,
        iFileContentEmpty = 10,
        iKeyIDValueIsZero = 11,
        iUnauthorizedAccess = 12,
        iAlreadyExists = 13
    }    
}