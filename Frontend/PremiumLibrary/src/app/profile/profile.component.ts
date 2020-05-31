import { Component, OnInit } from '@angular/core';
import { UserListingModel } from '../Model/User/userListingModel';
import { HttpUserService } from '../Service/http.userService';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
  providers: [HttpUserService]
})
export class ProfileComponent implements OnInit {

  userListingModel: UserListingModel;

  constructor(private httpUserService: HttpUserService) { }

  ngOnInit(): void {
    this.httpUserService.getUser()
      .subscribe((response: UserListingModel) => this.userListingModel = response);
  }

}
