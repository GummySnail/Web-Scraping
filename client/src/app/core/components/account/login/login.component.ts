import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {AccountService} from "../../../services/account.service";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup

  constructor(private fb: FormBuilder,
              private accountService: AccountService,
              private toastr: ToastrService)
  {
    this.loginForm = this.fb.group(
      {
      'email': ['', Validators.required],
      'password': ['', Validators.required]
    });
  }

  ngOnInit(): void {
  }

  login(){
    this.accountService.login(this.loginForm.value).subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
      this.toastr.error(error.error);
    })
  }
}
