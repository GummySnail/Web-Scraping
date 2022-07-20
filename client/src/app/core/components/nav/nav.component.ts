import { Component, OnInit } from '@angular/core';
import {AccountService} from "../../services/account.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(public accountService: AccountService, private router: Router) { }

  ngOnInit(): void {
  }

  logout(){
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }
}
