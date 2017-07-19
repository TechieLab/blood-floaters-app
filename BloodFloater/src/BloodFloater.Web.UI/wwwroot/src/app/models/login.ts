
export class Login {
    UserName: string;
    Password: string;
}

export class SignUp {
   UserName: string;
   Password: string;
   FullName : string;
   PhoneNumber: string;
   ConfirmPassword:string;
   EmailId:string;
}

export class ChangePassword{
    CurrentPassword:string;
    NewPassword:string;  
}
