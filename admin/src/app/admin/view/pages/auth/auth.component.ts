import { Component, ViewChild } from "@angular/core";
import { NgForm } from "@angular/forms";

import { AuthService } from "src/app/admin/core/services/auth.service";

@Component({
  templateUrl: "auth.component.html",
  styleUrls: ["auth.component.scss"]
})
export class AuthComponent {
  @ViewChild("form", { static: false }) signupForm: NgForm;

  constructor(public authService: AuthService) {}
  showError: boolean = false;

  onLogin() {
    this.showError = false;
    this.authService.login(this.signupForm.value).subscribe(result => {
      this.showError = !result;
    });
  }
}
