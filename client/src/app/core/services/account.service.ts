import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {LoginByEmail} from "../models/LoginByEmail";
import {map} from "rxjs/operators";
import {User} from "../models/User";
import {ReplaySubject} from "rxjs";
import {UserRegister} from "../models/UserRegister";

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = 'https://localhost:7210/api/';
  private currentUserSource = new ReplaySubject<User>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) { }

  login(model: LoginByEmail){
    return this.http.post(this.baseUrl + 'auth/loginbyemail', model).pipe(
      map((response: User) => {
        const user = response;
        if (user) {
          localStorage.setItem('token', JSON.stringify(user.accessToken));
          this.currentUserSource.next(user);
        }
      })
    );
  }

  register(model: UserRegister){
    return this.http.post(this.baseUrl + 'auth/register', model).pipe(
      map((response: User) => {
        const user = response;
        if (user) {
          localStorage.setItem('token', JSON.stringify(user.accessToken));
          this.currentUserSource.next(user);
        }
      })
    )
  }

  setCurrentUser(user: User){
    this.currentUserSource.next(user);
  }

  logout() {
    this.currentUserSource.next(null);
    localStorage.removeItem('token');
  }
}
