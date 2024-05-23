namespace WebApi.Wrappers.DTOS.UserInfoDtos
{
    public class UserInfoResponse
    {
    public string? id{ get; set; }
    public string? address {get;set;}
    public string? avatar { get;set;}
    public string?  email { get;set;}
    public string? username { get;set;}
    public string? information { get;set;}
 
    public string?  name { get;set;}
   
   public string? phone { get;set;}

   public DateTime? created_at { get;set;}
   public DateTime? updated_by { get;set;}
    }
}
