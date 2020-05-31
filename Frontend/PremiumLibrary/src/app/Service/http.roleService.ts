import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { RoleListingModel } from '../Model/Role/roleListingModel';
import { InviteOrLeaveUserFromRole } from '../Model/Role/inviteOrLeaveUserFromRole';

@Injectable()
export class HttpRoleService{
    constructor(private http: HttpClient){}

    postCreateRole(roleListingModel: RoleListingModel){
        return this.http.post('https://localhost:44321/api/role/create', roleListingModel);
    }

    postInviteOnRole(inviteOrLeaveUserFromRole: InviteOrLeaveUserFromRole){
        return this.http.post('https://localhost:44321/api/role/invite', inviteOrLeaveUserFromRole);
    }

    postLeaveFromRole(inviteOrLeaveUserFromRole: InviteOrLeaveUserFromRole){
        return this.http.post('https://localhost:44321/api/role/leave', inviteOrLeaveUserFromRole);
    }

    getRoles(){
        return this.http.get<RoleListingModel[]>('https://localhost:44321/api/role');
    }
}
