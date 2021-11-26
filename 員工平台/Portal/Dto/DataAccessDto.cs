using Bll;
using Bll.Token.Vdb;
using Bll.Tools;
using Dto.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dto
{
    public class DataAccessDto
    {
    //    public async Task<APIResult> RelaySendAsync(DataConditions Cond, Dictionary<string, string> dic, HttpMethod httpMethod,
    //        CancellationToken token = default(CancellationToken))
    //    {
    //        var AccessToken = Cond.AccessToken;
    //        var RefreshToken = Cond.RefreshToken;

    //        var mr = new APIResult();

    //        //呼叫api如果失敗要重新取得token 幾次以後就不要再呼叫
    //        var DoCall = true;
    //        var CallFrequency = 1;
    //        SigninRow rSignin = null;
    //        do
    //        {
    //            mr = await this.SendAsync(dic, HttpMethod.Post, token);

    //            //呼叫成功
    //            if (mr != null && mr.Status)
    //                DoCall = false;

    //            //超過系統設定上限次數
    //            if (DoCall && CallFrequency >= Constants.ReCallFrequencyMax)
    //                DoCall = false;

    //            //超過本方法設定上限次數
    //            if (DoCall && CallFrequency >= Cond.ReCallFrequencyMax)
    //                DoCall = false;

    //            if (DoCall)
    //            {
    //                var oRefreshToken = new RefreshTokenDto();
    //                var RefreshTokenCond = new RefreshTokenConditions();
    //                RefreshTokenCond.AccessToken = AccessToken;
    //                RefreshTokenCond.RefreshToken = RefreshToken;
    //                RefreshTokenCond.refreshToken = RefreshToken;
    //                var rs = await oRefreshToken.GetDataAsync(RefreshTokenCond, token);

    //                if (rs.Status)
    //                {
    //                    if (rs.Data != null)
    //                    {
    //                        rSignin = rs.Data as SigninRow;

    //                        AuthenticationHeaderBearerTokenValue = rSignin.AccessToken;
    //                    }
    //                    else
    //                        DoCall = false;
    //                }
    //                else
    //                    DoCall = false;

    //                CallFrequency = CallFrequency + 1;
    //                Thread.Sleep((Constants.ReCallIntervalSec + Cond.ReCallIntervalSec) * 1000);
    //            }
    //        } while (DoCall);

    //        mr.Signin = rSignin;

    //        return mr;
    //    }

    //    public APIResult RelaySend(DataConditions Cond, Dictionary<string, string> dic, HttpMethod httpMethod,
    //CancellationToken token = default(CancellationToken))
    //    {
    //        var AccessToken = Cond.AccessToken;
    //        var RefreshToken = Cond.RefreshToken;

    //        var mr = new APIResult();

    //        //呼叫api如果失敗要重新取得token 幾次以後就不要再呼叫
    //        var DoCall = true;
    //        var CallFrequency = 1;
    //        SigninRow rSignin = null;
    //        do
    //        {
    //            mr = this.SendAsync(dic, HttpMethod.Post, token);

    //            //呼叫成功
    //            if (mr != null && mr.Status)
    //                DoCall = false;

    //            //超過系統設定上限次數
    //            if (DoCall && CallFrequency >= Constants.ReCallFrequencyMax)
    //                DoCall = false;

    //            //超過本方法設定上限次數
    //            if (DoCall && CallFrequency >= Cond.ReCallFrequencyMax)
    //                DoCall = false;

    //            if (DoCall)
    //            {
    //                var oRefreshToken = new RefreshTokenDto();
    //                var RefreshTokenCond = new RefreshTokenConditions();
    //                RefreshTokenCond.AccessToken = AccessToken;
    //                RefreshTokenCond.RefreshToken = RefreshToken;
    //                RefreshTokenCond.refreshToken = RefreshToken;
    //                var rs = oRefreshToken.GetData(RefreshTokenCond, token);

    //                if (rs.Status)
    //                {
    //                    if (rs.Data != null)
    //                    {
    //                        rSignin = rs.Data as SigninRow;

    //                        AuthenticationHeaderBearerTokenValue = rSignin.AccessToken;
    //                    }
    //                    else
    //                        DoCall = false;
    //                }
    //                else
    //                    DoCall = false;

    //                CallFrequency = CallFrequency + 1;
    //                Thread.Sleep((Constants.ReCallIntervalSec + Cond.ReCallIntervalSec) * 1000);
    //            }
    //        } while (DoCall);

    //        mr.Signin = rSignin;

    //        return mr;
    //    }
    }
}