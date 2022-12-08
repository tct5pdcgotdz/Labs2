using System;

namespace Reports.DAL.Tools;

public class NotExistLeaderIdException : Exception
{
    public NotExistLeaderIdException() 
        : base("Not Exist Leader Id")
    {
    }
}