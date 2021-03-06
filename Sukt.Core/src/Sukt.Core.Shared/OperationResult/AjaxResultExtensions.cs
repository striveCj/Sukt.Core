﻿using Sukt.Core.Shared.Enums;
using Sukt.Core.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sukt.Core.Shared.OperationResult
{
    public static class AjaxResultExtensions
    {
        public static AjaxResult ToAjaxResult(this OperationResponse operationResponse)
        {
            var message = operationResponse.Message ?? operationResponse.Type.ToDescription();
            AjaxResultType type = operationResponse.Type.ToAjaxResultType();
            return new AjaxResult(message, type, operationResponse.Data) { Success = operationResponse.Successed };
        }



        public static AjaxResult ToAjaxResult<T>(this OperationResponse<T> operationResult)
        {
            var message = operationResult.Message ?? operationResult.Type.ToDescription();
            AjaxResultType type = operationResult.Type.ToAjaxResultType();
            return new AjaxResult(message, type, operationResult.Data) { Success = operationResult.Successed };
        }

        public static AjaxResultType ToAjaxResultType(this OperationEnumType responseType)
        {
            return responseType switch
            {
                OperationEnumType.Success => AjaxResultType.Success,
                OperationEnumType.NoChanged => AjaxResultType.Info,
                _ => AjaxResultType.Error,
            };
        }
    }
}
