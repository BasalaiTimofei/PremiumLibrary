import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Registration } from '../Model/User/registration';
import { Authorization } from '../Model/User/authorization';
import { UserListingModel } from '../Model/User/userListingModel';

@Injectable()
export class HttpUserService{
    constructor(private http: HttpClient){}

    postRegistration(registrationModel: Registration){
        return this.http.post('https://localhost:44321/api/user/registration', registrationModel);
    }

    postAuthorization(authorizationModel: Authorization){
        return this.http.post('https://localhost:44321/api/user/authorization', authorizationModel);
    }

    getUsers(){
        return this.http.get<UserListingModel[]>('https://localhost:44321/api/user');
    }

    getUser(){
        return this.http.get<UserListingModel>('https://localhost:44321/api/user/byId');
    }

    getAdminAutorisation(){
        return this.http.get('https://localhost:44321/api/user/admin');

    }
}
