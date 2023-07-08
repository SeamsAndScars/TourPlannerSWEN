using System.Collections.Generic;
using System.Linq;

public static class ChildFriendlinessConverter
{
    public static string ConvertToString(int childFriendliness)
    {
        if (childFriendliness >= 0 && childFriendliness < 25)
        {
            return "Very Good";
        }
        else if (childFriendliness >= 25 && childFriendliness < 50)
        {
            return "Good";
        }
        else if (childFriendliness >= 50 && childFriendliness < 75)
        {
            return "Neutral";
        }
        else if (childFriendliness >= 75 && childFriendliness < 100)
        {
            return "Bad";
        }
        else if (childFriendliness >= 100)
        {
            return "Very Bad";
        }
        else
        {
            return string.Empty;
        }
    }
}

