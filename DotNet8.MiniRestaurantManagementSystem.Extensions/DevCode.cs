namespace DotNet8.MiniRestaurantManagementSystem.Extensions;

public static class DevCode
{
    public static string SerializeObject(this object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }
}