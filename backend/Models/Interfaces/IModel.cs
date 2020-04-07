using System;
using backend.Constants;

namespace backend.Models.Interfaces
{
    public interface IModel
    {
        bool IsValid();

        ModelErrorCodes GetErrorCode();
    }
}
