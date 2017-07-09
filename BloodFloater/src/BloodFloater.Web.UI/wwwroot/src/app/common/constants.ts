
export class Constants {

  public static AppName: string = "Blood Floaters";
  public static BaseApi: string = 'http://localhost:1365/';
  public static LookupApi: string = Constants.BaseApi + 'api/lookups/';
  public static AccountApi: string = Constants.BaseApi + 'api/account/';
  public static JwtAuthApi: string = Constants.BaseApi + 'api/jwt-auth/';
  public static ProfileApi : string = Constants.BaseApi + 'api/profile/';
  public static SearchApi : string = Constants.BaseApi + 'api/search/';
}