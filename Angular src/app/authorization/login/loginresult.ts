export class LoginResult{
    
    success!: boolean

    message!: string

    id!: string
    
    token!: string

    constructor(success: boolean, message: string, userId: string, token: string){
        this.success=success;
        this.message=message;
        this.id=userId;
        this.token=token;
    }
}