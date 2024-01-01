using System.ComponentModel.DataAnnotations;
using MinimalServer.Comman.Const;

namespace MinimalServer.Comman.Enum;

public enum ApiResultStatusCode : short
{
    [Display(Name = App.Ok)]
    Success = 200,

    [Display(Name = App.ServerError)]
    ServerError = 500,

    [Display(Name = App.InputNotValid)]
    BadRequest = 400,

    [Display(Name = App.NotFound)]
    NotFound = 404,

    [Display(Name = App.EmptyList)]
    ListEmpty = 204,

    [Display(Name = App.ProcessError)]
    LoginError = 500,

    [Display(Name = App.UnAuthorize)]
    UnAuthorized = 401,

    [Display(Name = App.AccessError)]
    Forbidden = 403,

    [Display(Name = App.UnsupportedMediaType)]
    UnsupportedMediaType = 405
}