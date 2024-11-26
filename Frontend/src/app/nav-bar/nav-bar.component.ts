import { Component, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { RouterModule } from '@angular/router';
import { AccountService } from '../services/account.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-nav-bar',
  imports: [RouterModule,MatIconModule,MatButtonModule,FormsModule],
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.css'
})
export class NavBarComponent {
  loggedIn = false;
  private accountService = inject(AccountService);
  body:any = {};

  login(){
    this.accountService.login(this.body).subscribe({
      next: response => {
        console.log(response);
        this.loggedIn = true;
      },
        error: error => console.log(error)
    })
  }
}
/*
const loginFormContainer = document.querySelector(".loginForm-container"),
loginFormLogin = document.getElementById("loginButton"),
login = document.getElementById("login"),
loginForm = document.querySelector(".login");

function closeLoginFormContainer(){
  loginFormContainer?.classList.remove("open");
}*/
function openForm(): void {
  (document.getElementById("login") as HTMLElement).style.display = "block";
}

function closeForm(): void {
  (document.getElementById("login") as HTMLElement).style.display = "none";
}