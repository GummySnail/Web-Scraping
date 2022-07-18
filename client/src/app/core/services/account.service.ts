import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {LoginByEmail} from "../models/LoginByEmail";

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = 'https://localhost:7210/api/';

  constructor(private http: HttpClient) { }

  login(model: LoginByEmail){
    return this.http.post(this.baseUrl + 'auth/loginbyemail', model);
  }
}
