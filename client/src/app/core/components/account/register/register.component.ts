import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {AccountService} from "../../../services/account.service";
import {Router} from "@angular/router";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;

  constructor(private fb: FormBuilder,
              private accountService: AccountService,
              private router: Router,
              private toastr: ToastrService)
  {
    this.registerForm = this.fb.group(
      {
        'email': ['', Validators.required],
        'userName': ['', Validators.required],
        'password': ['', Validators.required],
        'confirmPassword': ['', Validators.required]
      });
  }

  ngOnInit(): void {
  }

  register(){
    this.accountService.register(this.registerForm.value).subscribe(response => {
      console.log(response);
      this.cancel();
    }, error => {
      console.log(error);
      this.toastr.error(error.error);
    })
  }

  cancel(){
    this.router.navigateByUrl('/');
  }

}
