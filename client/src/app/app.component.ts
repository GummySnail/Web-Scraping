import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {AccountService} from "./core/services/account.service";
import {User} from "./core/models/User";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'Web.Scraping';

  constructor(private http: HttpClient, private accountService: AccountService) {}

  ngOnInit(): void {
  this.setCurrentUser();
  }

  setCurrentUser() {
    const user: User = JSON.parse(localStorage.getItem('user'));
    this.accountService.setCurrentUser(user);
  }
}
