using System;
namespace backend.Constants
{
    public enum ModelErrorCodes
    {
        Ok = 0,
        Unknown_error = 401,
        Invalid_lat = 402,
        Invalid_long = 403,
        Invalid_name = 404,
        Invalid_address = 410,
        Invalid_city = 411,
        Invalid_distance = 412
    }
}
