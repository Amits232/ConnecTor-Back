using MediatR;

public class UserRegisterQuery : IRequest<bool>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int RegionID { get; set; }
    public int ProfessionID { get; set; }
    public string BusinessLicenseCode { get; set; }
    public string Telephone { get; set; }
    public string UserImage { get; set; }
    public int UserTypeID { get; set; }
}
