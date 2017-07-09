const App_Context: string = 'APP_Context';
const Auth_Token: string = 'Auth_Token';
const User_Name: string = 'User_Name';
const Client_Id ='Client_Id';
const Email_Id = 'Email_Id';

export class StorageService {

    static getItem(key: string): any {
        return localStorage.getItem(key);
    }

    static setItem(key: string, item: any): any {
        localStorage.setItem(key, item);
    }

    static getUserId(): any {
        return localStorage.getItem(Client_Id);
    }

    static setUserId(item: any): any {
        localStorage.setItem(Client_Id, item);
    }

    static hasContext(): boolean {
        return !!this.getItem(App_Context);
    }

    static getContext(): any {
        if (this.hasContext()) {
            return this.getItem(App_Context);
        }
    }
    static setContext(context: any) {
        localStorage.setItem(App_Context, context);
    }

    static removeContext(): void {
        localStorage.removeItem(App_Context);
    }

    static hasToken(): boolean {
        return !!this.getItem(Auth_Token);
    }

    static getToken(): string {
        if (this.hasToken()) {
            return this.getItem(Auth_Token);
        }
    }
    static setToken(response: any): void {
        localStorage.setItem(User_Name, response.userName);
        localStorage.setItem(Auth_Token, response.access_token);
        localStorage.setItem(Client_Id, response.userId);
        localStorage.setItem(Email_Id, response.emailId);
    }
   
    static removeToken(): void {
        localStorage.removeItem(User_Name);
        localStorage.removeItem(Auth_Token);
    }
}