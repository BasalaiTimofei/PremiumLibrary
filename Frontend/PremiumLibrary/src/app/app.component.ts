import { Component, Input } from '@angular/core';
import { Authorization } from './Model/User/authorization';
import { HttpUserService } from './Service/http.userService';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [HttpUserService]
})

export class AppComponent {
  title = 'PremiumLibrary';

  userId: string;
  autorisationModel: Authorization;
  userNameOrEmailAddress: string;
  password: string;

  constructor(private httpUserService: HttpUserService, private router: Router){}


  autorisation(){
    this.autorisationModel.userNameOrEmailAddress = this.userNameOrEmailAddress;
    this.autorisationModel.password = this.password;
    this.httpUserService.postAuthorization(this.autorisationModel)
      .subscribe((response: string) => this.userId = response);
    this.router.navigate(['/user/' + this.userId]);
  }

  adminAutorisation(){
    this.httpUserService.getAdminAutorisation();
  }
}
